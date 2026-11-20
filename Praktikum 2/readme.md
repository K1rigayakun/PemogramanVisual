# Pertemuan 2: Komponen Visual, Properti, & Event

## 1. Gambaran Umum & Analogi

Pada Pertemuan 2, kita mulai membangun aplikasi Windows Forms nyata di folder proyek [Praktikum 2](./Praktikum2.slnx).

Bayangkan sebuah **formulir kertas pendaftaran di loket kampus**:
- **Form** adalah papan alas/kertas formulirnya.
- **Label** adalah tulisan tercetak di kertas seperti `"Nama :"`, `"NIM :"`, dan `"KOM :"`.
- **TextBox** adalah kotak kosong tempat pendaftar menulis jawaban memakai pulpen.
- **Button** adalah stempel atau tombol panggil petugas: baru ketika ditekan, petugas memproses kertas tersebut (`Tampilkan`), menghapus coretan (`Hapus`), atau menutup loket (`Keluar`).

---

## 2. Ringkasan Konsep Materi

### Tiga Pilar Pemrograman Antarmuka (WinForms)
1. **Control (Komponen Visual):** Elemen di *Toolbox* yang ditaruh di atas `Form` untuk menerima input dari pengguna atau menampilkan output.
2. **Property (Properti):** Atribut pengatur sifat atau penampilan komponen (seperti `(Name)`, `Text`, `Location`, `Size`, `BackColor`, `ForeColor`, `Font`, `Enabled`, `Visible`, `StartPosition`).
3. **Event (Kejadian):** Peristiwa yang menimpa komponen (misalnya tombol diklik -> `Click`) yang menjadi pemicu berjalannya blok kode `Sub`.

### Perbedaan Penting: `(Name)` vs `Text`
- **`(Name)`** adalah **nama panggilan komponen di dalam kode** (contoh: `nama`, `nim`, `Tampilkan`). Tidak terlihat oleh pengguna aplikasi, tetapi dipakai oleh programmer.
- **`Text`** adalah **tulisan yang dilihat oleh pengguna di layar** (contoh: tulisan `"Tampilkan"` di atas tombol atau tulisan `"Nama"` di label).

---

## 3. Daftar Komponen Antarmuka (UI Controls)

Berikut daftar seluruh komponen yang terdapat di dalam [Form1.Designer.vb](./Form1.Designer.vb):

| Jenis Kontrol | Properti `(Name)` | Properti `Text` | Lokasi (`Location`) | Ukuran (`Size`) | Fungsi pada Aplikasi |
| :--- | :--- | :--- | :--- | :--- | :--- |
| `Form` | `Form1` | `"Form1"` | - | `ClientSize: 800, 450` | Jendela utama wadah semua komponen |
| `Label` | `Label1` | `"Nama"` | `123, 60` | `AutoSize` | Keterangan kolom input nama |
| `Label` | `Label3` | `"NIM"` | `123, 98` | `AutoSize` | Keterangan kolom input NIM |
| `Label` | `Label2` | `"KOM"` | `123, 134` | `AutoSize` | Keterangan kolom input KOM/Kelas |
| `Label` | `Label4`, `Label5`, `Label6` | `":"` | `x: 178` | `AutoSize` | Tanda titik dua sejajar di sebelah label |
| `TextBox` | `nama` | `""` | `196, 57` | `125, 27` | Kotak isian untuk mengetik Nama |
| `TextBox` | `nim` | `""` | `196, 95` | `125, 27` | Kotak isian untuk mengetik NIM |
| `TextBox` | `kom` | `""` | `196, 134` | `125, 27` | Kotak isian untuk mengetik KOM |
| `Button` | `Tampilkan` | `"Tampilkan"` | `123, 178` | `94, 29` | Menampilkan ringkasan input ke `MessageBox` |
| `Button` | `Hapus` | `"Hapus"` | `227, 178` | `94, 29` | Mengosongkan ketiga `TextBox` |
| `Button` | `Keluar` | `"Keluar"` | `178, 213` | `94, 29` | Menutup jendela `Form1` |

---

## 4. Bedah Kode Program: Kodenya Ini Buat Apa?

Berikut isi kode lengkap dari [Form1.vb](./Form1.vb):

```vbnet
Public Class Form1
    Private Sub Keluar_Click(sender As Object, e As EventArgs) Handles Keluar.Click
        Me.Close()
    End Sub

    Private Sub Tampilkan_Click(sender As Object, e As EventArgs) Handles Tampilkan.Click
        MessageBox.Show("Halo, " & vbCrLf &
                        "Nama : " & nama.Text & vbCrLf &
                        "NIM  : " & nim.Text & vbCrLf &
                        "KOM  : " & kom.Text
        )
    End Sub

    Private Sub Hapus_Click(sender As Object, e As EventArgs) Handles Hapus.Click
        nama.Clear()
        nim.Clear()
        kom.Clear()
    End Sub
End Class
```

### Penjelasan Kode Bagian demi Bagian:
1. **`Keluar_Click(...) Handles Keluar.Click`**
   - Berjalan ketika pengguna menekan tombol `Keluar`.
   - `Me.Close()` memerintahkan jendela `Form1` (`Me`) untuk menutup dirinya sendiri dan menghentikan aplikasi karena `Form1` adalah Form utama.
2. **`Tampilkan_Click(...) Handles Tampilkan.Click`**
   - Berjalan ketika pengguna menekan tombol `Tampilkan`.
   - `MessageBox.Show(...)` memunculkan jendela pop-up pesan di layar.
   - `nama.Text`, `nim.Text`, dan `kom.Text` membaca teks apa pun yang sedang diketik pengguna di masing-masing kotak `TextBox`.
   - `vbCrLf` (Carriage Return + Line Feed) berfungsi sebagai tombol **Enter / baris baru** agar Nama, NIM, dan KOM tersusun rapi ke bawah, tidak memanjang satu baris.
   - Operator `&` menyambungkan teks statis (`"Nama : "`) dengan isi kotak teks (`nama.Text`).
3. **`Hapus_Click(...) Handles Hapus.Click`**
   - Berjalan ketika pengguna menekan tombol `Hapus`.
   - `.Clear()` mengosongkan seluruh karakter di dalam masing-masing `TextBox` (`nama`, `nim`, `kom`).

---

## 5. Apa yang Dihasilkan Program

1. Ketika proyek dijalankan, muncul jendela berukuran `800 x 450` piksel dengan tiga label (`Nama`, `NIM`, `KOM`), tiga kotak teks kosong (`nama`, `nim`, `kom`), dan tiga tombol (`Tampilkan`, `Hapus`, `Keluar`).
2. Jika pengguna mengisi:
   - `nama` = `"Michael Deryl"`
   - `nim` = `"241712042"`
   - `kom` = `"A2"`
   lalu mengklik tombol **Tampilkan**, maka muncul pop-up bertuliskan:
   ```text
   Halo, 
   Nama : Michael Deryl
   NIM  : 241712042
   KOM  : A2
   ```
3. Jika pengguna mengklik tombol **Hapus**, seluruh isi pada kotak `nama`, `nim`, dan `kom` langsung bersih kembali menjadi kosong.
4. Jika pengguna mengklik tombol **Keluar**, jendela tertutup dan eksekusi program berhenti.

---

## 6. Eksperimen: Jika Variabel atau Nilainya Diubah-Ubah Jadi Apa?

| Bagian / Variabel yang Diubah | Nilai Awal | Diubah Menjadi | Dampak & Hasil yang Terjadi |
| :--- | :--- | :--- | :--- |
| `vbCrLf` di dalam `Tampilkan_Click` | Ada `vbCrLf` di akhir tiap baris | Dihapus semua `vbCrLf` | Seluruh output menumpuk menyamping dalam satu baris panjang: `"Halo, Nama : ...NIM  : ...KOM  : ..."`. |
| `Me.Close()` di `Keluar_Click` | `Me.Close()` | `Me.Hide()` | Jendela hanya disembunyikan dari layar, tetapi aplikasi **masih berjalan di background** (harus dihentikan lewat Stop Debugging di Visual Studio). |
| Tambahan `nama.Focus()` di `Hapus_Click` | Hanya `Clear()` tanpa `Focus()` | Ditambah `nama.Focus()` di baris terakhir `Hapus_Click` | Setelah tombol `Hapus` diklik, kursor ketikan otomatis melompat siap mengetik di kotak `nama` tanpa perlu klik mouse lagi. |
| Properti `nim.MaxLength` di Designer | Default (`32767`) | `9` | Pengguna tidak bisa mengetik lebih dari 9 karakter di kotak NIM, mencegah kesalahan panjang digit sejak awal. |
| Operator `&` di `Tampilkan_Click` | `nama.Text` | `nama.Text.Trim()` | Jika pengguna tidak sengaja mengetik spasi berlebih di awal/akhir nama, spasi tersebut otomatis dibersihkan sebelum tampil di `MessageBox`. |
| Parameter `MessageBox.Show(...)` | 1 argumen (hanya isi pesan) | `MessageBox.Show("...", "Biodata", MessageBoxButtons.OK, MessageBoxIcon.Information)` | Kotak pesan tampil lebih rapi: judul pop-up berubah menjadi `"Biodata"` (bukan kosong) dan muncul ikon informasi biru di samping teks. |
| Properti `(Name)` komponen `nama` | `"nama"` | `"txtNama"` di Properties tanpa memperbaiki `Form1.vb` | Muncul **Compile Error** di `Form1.vb` (`'nama' is not declared`) karena kode masih memanggil nama lama. Seluruh referensi `nama` di `Form1.vb` harus ikut disesuaikan menjadi `txtNama`. |

---

## 7. Kesalahan Umum & Tips Praktis

1. **Mengubah `Text` dikira mengubah `(Name)`:** Mengubah `Text` menjadi `"Tampilkan"` hanya mengubah tulisan di permukaan tombol. Pastikan `(Name)` juga diberi nama yang bermakna (untuk proyek besar selanjutnya, ikuti *prefix* 3 huruf seperti `txtNama`, `btnTampilkan`, `lblNim`).
2. **Menamai kontrol setelah melakukan double-click:** Jika telanjur *double-click* tombol sebelum mengganti `(Name)`, nama prosedur tetap `Button1_Click(...)`. Biasakan ubah `(Name)` dulu baru buat event.
3. **Salah jalur menjalankan kode:** Pastikan tidak memanggil `.Text` ke objek kontrol itu sendiri (misal `MessageBox.Show(nama)` salah karena `nama` adalah objek `TextBox`; yang benar adalah `nama.Text`).

---

Navigasi: [Pertemuan 1](../Praktikum%201/readme.md) | [Kembali ke README Utama](../readme.md) | [Lanjut ke Pertemuan 3](../Praktikum%203/readme.md)
