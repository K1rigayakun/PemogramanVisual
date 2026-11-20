# Pertemuan 3: Operator, Ekspresi, & Struktur Pengendalian

## 1. Gambaran Umum & Analogi

Pada Pertemuan 3 di proyek [Praktikum 3](./Praktikum%203.slnx), program mulai punya "otak" untuk mengambil keputusan berdasarkan angka yang dimasukkan pengguna.

Bayangkan sebuah **mesin pengecek skor ujian otomatis**:
- Sebelum kertas jawaban dinilai, penjaga loket memastikan angka yang masuk bukan huruf (`KeyPress` + `TryParse`), dan berada di rentang `0` sampai `100`.
- Setelah lolos pemeriksaan, mesin bercabang tiga jalur:
  - Jika nilai `<= 50`, tampilkan gambar reaksi kategori pertama (`Assets\1.gif`).
  - Jika nilai `51` sampai `70`, tampilkan gambar reaksi kategori kedua (`Assets\2.gif`).
  - Jika nilai `> 70` (hingga `100`), tampilkan gambar reaksi kategori ketiga (`Assets\3.jpg`).

---

## 2. Ringkasan Konsep Materi

### A. 5 Jenis Operator di VB.NET
1. **Aritmatika:** `+` (tambah), `-` (kurang), `*` (kali), `/` (bagi desimal), `\` (bagi bulat tanpa koma), `Mod` (sisa pembagian).
2. **Penugasan:** `=`, `+=`, `-=`, `*=`, `/=`, `&=`.
3. **Perbandingan:** `=` (sama dengan), `<>` (tidak sama dengan), `>`, `<`, `>=`, `<=` (menghasilkan `True` atau `False`).
4. **Logika:** `And`, `AndAlso`, `Or`, `OrElse`, `Not`, `Xor`.
   - *Catatan:* `AndAlso` dan `OrElse` memakai evaluasi cepat (*short-circuit*): jika kondisi kiri sudah menentukan hasil akhir, kondisi kanan tidak perlu diperiksa lagi.
5. **Increment & Decrement:** `x += 1` (naik 1) dan `x -= 1` (turun 1).

### B. 5 Bentuk Struktur Percabangan
1. **`If ... Then ... End If`:** Menjalankan aksi hanya jika kondisi `True`.
2. **`If ... Then ... Else ... End If`:** Dua jalur pilihan (jika `True` atau `False`).
3. **`If ... ElseIf ... Else ... End If`:** Mengevaluasi banyak rentang kondisi berurutan dari atas ke bawah.
4. **`Select Case ... End Select`:** Alternatif rapi ketika membandingkan nilai pasti dari satu variabel yang sama.
5. **Operator Ternary `If(kondisi, nilaiTrue, nilaiFalse)`:** Percabangan singkat 1 baris.

---

## 3. Daftar Komponen Antarmuka (UI Controls)

Berikut komponen pada [Form1.Designer.vb](./Form1.Designer.vb):

| Jenis Kontrol | Properti `(Name)` | Properti Penting | Fungsi pada Aplikasi |
| :--- | :--- | :--- | :--- |
| `Form` | `Form1` | `ClientSize: 800, 450` | Jendela utama program |
| `PictureBox` | `picImage` | `Size: 175, 152`, `SizeMode: Zoom` | Menampilkan gambar/GIF sesuai kategori nilai agar proporsional tidak terpotong |
| `TextBox` | `txtNilai` | `Location: 297, 259` | Kotak input nilai angka (`0` s.d. `100`) |
| `Button` | `btnInput` | `Text: "Input"` | Memicu validasi rentang nilai dan pemilihan gambar |

Aset gambar di folder `Assets\` (disalin otomatis ke folder `bin/` lewat `<CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>` di `Praktikum 3.vbproj`):
- `Assets\1.gif` (untuk nilai `0` s.d. `50`)
- `Assets\2.gif` (untuk nilai `51` s.d. `70`)
- `Assets\3.jpg` (untuk nilai `71` s.d. `100`)

---

## 4. Bedah Kode Program: Kodenya Ini Buat Apa?

Berikut isi kode lengkap dari [Form1.vb](./Form1.vb):

```vbnet
Public Class Form1
    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
        Dim nilai As Integer
        If Not Integer.TryParse(txtNilai.Text, nilai) Then
            MessageBox.Show("Masukkan Nilai yang benar")
            txtNilai.Focus()
            Return
        End If

        If nilai < 0 OrElse nilai > 100 Then
            MessageBox.Show("Hanya 0-100")
            txtNilai.Focus()
            Return
        End If

        If nilai <= 50 Then
            picImage.Image = Image.FromFile("Assets\1.gif")

        ElseIf nilai <= 70 Then
            picImage.Image = Image.FromFile("Assets\2.gif")

        Else
            picImage.Image = Image.FromFile("Assets\3.jpg")

        End If

    End Sub

    Private Sub txtNilai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilai.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub picImage_Click(sender As Object, e As EventArgs) Handles picImage.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class
```

### Penjelasan Kode Bagian demi Bagian:
1. **Penyaringan Ketikan Real-Time (`txtNilai_KeyPress`)**:
   - Berjalan setiap kali satu tombol keyboard ditekan saat kursor berada di `txtNilai`.
   - `Char.IsDigit(e.KeyChar)` bernilai `True` jika tombol yang ditekan adalah angka `0`–`9`.
   - `Char.IsControl(e.KeyChar)` bernilai `True` untuk tombol kendali seperti `Backspace` (agar pengguna tetap bisa menghapus salah ketik).
   - Jika tombol **bukan** tombol kontrol dan **bukan** angka (`Not ... AndAlso Not ...`), maka `e.Handled = True` membatalkan karakter tersebut sehingga huruf atau simbol tidak akan muncul di layar.
2. **Validasi Konversi (`Integer.TryParse`)**:
   - `Integer.TryParse(txtNilai.Text, nilai)` mencoba mengubah isi kotak teks ke bilangan bulat dan menaruh hasilnya ke variabel `nilai`.
   - Jika gagal (misalnya kotak dibiarkan kosong saat tombol `Input` diklik), program menampilkan pesan `"Masukkan Nilai yang benar"`, memindahkan kursor ke `txtNilai.Focus()`, dan keluar dari prosedur menggunakan `Return`.
3. **Validasi Rentang dengan Operator Logika (`OrElse`)**:
   - `If nilai < 0 OrElse nilai > 100 Then`: Memastikan `nilai` berada di rentang `0` s.d. `100`. Jika di luar itu, muncul pesan `"Hanya 0-100"` dan langsung `Return`.
4. **Percabangan Bertingkat (`If ... ElseIf ... Else`)**:
   - Jika `nilai <= 50`, muat file `Assets\1.gif` ke `picImage.Image`.
   - Karena syarat `<= 50` sudah dicek lebih dulu, cabang `ElseIf nilai <= 70` otomatis hanya menangkap nilai `51` sampai `70`, dan memuat `Assets\2.gif`.
   - Cabang `Else` menangkap sisanya (`71` sampai `100`) dan memuat `Assets\3.jpg`.

---

## 5. Apa yang Dihasilkan Program

| Input Pengguna di `txtNilai` | Reaksi Sistem |
| :--- | :--- |
| Menekan tombol huruf (`a`, `b`, `!`, `-`) | Ketikan langsung ditolak oleh `txtNilai_KeyPress`; tidak muncul huruf di dalam kotak. |
| Kotak dikosongkan lalu klik `Input` | Muncul `MessageBox`: `"Masukkan Nilai yang benar"`, kursor kembali ke `txtNilai`. |
| Mengisi `150` lalu klik `Input` | Muncul `MessageBox`: `"Hanya 0-100"`, gambar tidak berubah. |
| Mengisi `45` lalu klik `Input` | `picImage` menampilkan animasi `Assets\1.gif`. |
| Mengisi `65` lalu klik `Input` | `picImage` menampilkan animasi `Assets\2.gif`. |
| Mengisi `90` lalu klik `Input` | `picImage` menampilkan gambar `Assets\3.jpg`. |

---

## 6. Eksperimen: Jika Variabel atau Nilainya Diubah-Ubah Jadi Apa?

| Bagian / Variabel yang Diubah | Nilai Awal | Diubah Menjadi | Dampak & Hasil yang Terjadi |
| :--- | :--- | :--- | :--- |
| Urutan `If nilai <= 50` dan `ElseIf nilai <= 70` dibalik | `<= 50` di atas, `<= 70` di bawah | `If nilai <= 70` ditaruh paling atas, `ElseIf nilai <= 50` di bawah | **Logic Error!** Nilai `40` memenuhi syarat `<= 70`, sehingga selalu masuk ke `Assets\2.gif` dan `Assets\1.gif` tidak akan pernah muncul lagi. |
| Kondisi `e.Handled = True` di `txtNilai_KeyPress` | `If Not Char.IsControl(...) AndAlso Not Char.IsDigit(...)` | Menghapus `Not Char.IsControl(e.KeyChar)` | Pengguna masih bisa mengetik angka, tetapi **tombol Backspace ikut diblokir**, sehingga angka yang terlanjur diketik tidak bisa dihapus. |
| Batas rentang `nilai > 100` | `nilai < 0 OrElse nilai > 100` | `nilai < 0 OrElse nilai > 80` | Nilai `85` yang sebelumnya valid masuk `Assets\3.jpg` kini ditolak oleh validasi rentang dan memunculkan pesan `"Hanya 0-100"`. |
| Operator logika `OrElse` diganti `AndAlso` | `nilai < 0 OrElse nilai > 100` | `nilai < 0 AndAlso nilai > 100` | **Logic Error!** Tidak ada angka di dunia ini yang sekaligus lebih kecil dari 0 DAN lebih besar dari 100. Validasi rentang selalu bernilai `False`, sehingga angka `999` lolos masuk ke cabang `Else` (`Assets\3.jpg`). |
| Properti `picImage.SizeMode` | `PictureBoxSizeMode.Zoom` | `PictureBoxSizeMode.Normal` atau `StretchImage` | `Normal`: gambar besar terpotong oleh ukuran kotak `175x152`. `StretchImage`: gambar ditarik paksa memenuhi kotak sehingga bentuknya tampak gepeng/lonjong. |
| Jalur file `"Assets\1.gif"` | `"Assets\1.gif"` | `"Assets\tidakada.gif"` | Saat nilai `<= 50` diinput dan diklik, program **crash** dengan `FileNotFoundException` karena file tidak ditemukan (belum dibungkus `Try...Catch` atau `File.Exists`). |
| Nilai di `ElseIf nilai <= 70` | `<= 70` | `< 70` | Nilai tepat `70` tidak lagi masuk kategori `2.gif`, melainkan bergeser masuk ke cabang `Else` (`3.jpg`). |

---

## 7. Kesalahan Umum & Tips Praktis

1. **Mengabaikan `Char.IsControl` di event `KeyPress`:** Tanpa `Char.IsControl(e.KeyChar)`, pengguna tidak bisa menekan `Backspace` atau tombol `Enter`.
2. **Menulis syarat besar di atas syarat kecil pada `If...ElseIf`:** Jika memakai operator `<=`, selalu urutkan dari batas terkecil (`<= 50`, lalu `<= 70`). Jika memakai `>=`, urutkan dari batas terbesar (`>= 85`, lalu `>= 75`, dst.).
3. **File di folder `Assets\` lupa diset *Copy to Output Directory*:** Jika folder `Assets` tidak ikut disalin ke `bin\Debug\...`, `Image.FromFile("Assets\1.gif")` akan gagal menemukan berkas saat aplikasi dijalankan.

---

Navigasi: [Pertemuan 2](../Praktikum%202/readme.md) | [Kembali ke README Utama](../readme.md) | [Lanjut ke Pertemuan 4](../Praktikum%204/readme.md)
