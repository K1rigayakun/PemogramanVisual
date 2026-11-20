# Pertemuan 4: Struktur Perulangan (Looping)

## 1. Gambaran Umum & Analogi

Pada Pertemuan 4 di proyek [Praktikum 4](./pertemuan%204.slnx), kita mempelajari cara memerintahkan komputer mengulang tugas yang sama secara otomatis.

Bayangkan kamu harus menulis nomor antrean `1` sampai `100` ke dalam daftar kertas:
- **Tanpa perulangan:** Kamu harus menulis kode `lstHasil.Items.Add(...)` sebanyak 100 baris.
- **Dengan perulangan (`Looping`):** Cukup 3 baris kode (`For ... Next`), komputer akan menghitung dan mengisi seluruh daftar dalam sekejap.

---

## 2. Ringkasan Konsep Materi

### A. Counted Loop vs Uncounted Loop
1. **Counted Loop (`For ... Next`):** Dipakai ketika **jumlah pengulangan sudah diketahui pasti** dari awal (punya nilai awal, nilai akhir, dan langkah `Step`).
2. **Uncounted Loop (`While`, `Do ... Loop`):** Dipakai ketika **jumlah pengulangan tidak pasti** dan berhenti berdasarkan kondisi tertentu (`Boolean` menjadi `False`).

### B. Rangkuman Sintaks Perulangan di VB.NET

| Jenis Perulangan | Kapan Kondisi Dicek? | Minimal Jalan Berapa Kali? | Contoh Kode Singkat |
| :--- | :--- | :--- | :--- |
| **`For ... Next`** | Batas awal sampai akhir | 0 kali jika batas langsung terlewati | `For i As Integer = 1 To 5 : ... : Next` |
| **`For ... Next Step -1`** | Hitung mundur | 0 kali jika `awal < akhir` | `For i As Integer = 10 To 1 Step -1 : ... : Next` |
| **`While ... End While`** | Di **awal** sebelum masuk blok | 0 kali (jika kondisi awal `False`) | `While i <= 5 : ... : i += 1 : End While` |
| **`Do While ... Loop`** | Di **awal** | 0 kali | `Do While a <= 5 : ... : a += 1 : Loop` |
| **`Do ... Loop While`** | Di **akhir** setelah blok jalan | **Minimal 1 kali** meski kondisi awal `False` | `Do : ... : b += 1 : Loop While b <= 5` |
| **`Nested Loop`** | Loop di dalam loop | Bergantung loop luar & dalam | `For i = 1 To 3 : For j = 1 To 3 : ... : Next : Next` |

---

## 3. Daftar Komponen Antarmuka (UI Controls)

Berikut komponen pada [frmPerulangan.Designer.vb](./frmPerulangan.Designer.vb):

| Jenis Kontrol | Properti `(Name)` | Properti `Text` / Penting | Fungsi pada Aplikasi |
| :--- | :--- | :--- | :--- |
| `Form` | `frmPerulangan` | `ClientSize: 800, 572` | Jendela utama latihan perulangan |
| `Label` | `lblNilaiAwal` | `"Nilai Awal :"` | Label untuk batas awal perulangan |
| `Label` | `lblNilaiAkhir` | `"Nilai Akhir :"` | Label untuk batas akhir perulangan |
| `TextBox` | `txtNilaiAwal` | - | Kotak input angka mulai perulangan |
| `TextBox` | `txtNilaiAkhir` | - | Kotak input angka batas akhir perulangan |
| `Button` | `btnInput` | `"Input"` | Memicu eksekusi perulangan `For ... Step -2` |
| `ListBox` | `lstHasil` | `Size: 150, 104` | Daftar penampil setiap angka hasil iterasi |

---

## 4. Bedah Kode Program: Kodenya Ini Buat Apa?

Berikut isi kode lengkap dari [frmPerulangan.vb](./frmPerulangan.vb):

```vbnet
Public Class frmPerulangan
    Private Sub txtNilaiAwal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilaiAwal.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtNilaiAkhir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilaiAkhir.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
        Dim nilaiAwal As Integer
        Dim nilaiAkhir As Integer

        If Not Integer.TryParse(txtNilaiAwal.Text, nilaiAwal) Then
            MessageBox.Show("Masukkan dalam bentuk angka")
            txtNilaiAwal.Focus()
            Return
        End If

        If Not Integer.TryParse(txtNilaiAkhir.Text, nilaiAkhir) Then
            MessageBox.Show("Masukkan dalam bentuk angka")
            txtNilaiAkhir.Focus()
            Return
        End If

        lstHasil.Items.Clear()

        For i As Integer = nilaiAwal To nilaiAkhir Step -2
            lstHasil.Items.Add(i)
        Next

    End Sub

End Class
```

### Penjelasan Kode Bagian demi Bagian:
1. **Validasi Ketikan Angka (`txtNilaiAwal_KeyPress` dan `txtNilaiAkhir_KeyPress`)**:
   - Keduanya memblokir semua karakter keyboard selain digit angka `0`–`9` dan tombol kontrol (`Backspace`).
2. **Validasi Konversi (`Integer.TryParse`)**:
   - Memastikan kotak `txtNilaiAwal` dan `txtNilaiAkhir` tidak kosong dan benar-benar berisi angka bulat yang valid sebelum dipakai sebagai batas `For`.
3. **Membersihkan Output Lama (`lstHasil.Items.Clear()`)**:
   - Sangat penting! Sebelum loop berjalan, semua item hasil perhitungan sebelumnya dihapus dulu agar angka baru tidak menumpuk di bawah angka lama.
4. **Blok Perulangan Mundur (`For i As Integer = nilaiAwal To nilaiAkhir Step -2`)**:
   - Variabel `i` berfungsi sebagai **variabel pengontrol** yang melacak posisi hitungan saat ini.
   - `nilaiAwal` adalah angka awal `i`.
   - `nilaiAkhir` adalah angka tujuan berhenti.
   - `Step -2` artinya setiap 1 putaran selesai (`Next`), nilai `i` **dikurangi 2** (`i = i - 2`).
   - Karena `Step`-nya bernilai negatif (`-2`), loop ini dirancang untuk menghitung **mundur** (`nilaiAwal` lebih besar dari `nilaiAkhir`).

---

## 5. Apa yang Dihasilkan Program

| `txtNilaiAwal` | `txtNilaiAkhir` | Hasil yang Tampil di `lstHasil` |
| :--- | :--- | :--- |
| `10` | `1` | `10`, `8`, `6`, `4`, `2` (berhenti sebelum `0` karena `0 < 1`) |
| `10` | `2` | `10`, `8`, `6`, `4`, `2` |
| `9` | `1` | `9`, `7`, `5`, `3`, `1` |
| `1` | `10` | **Kosong!** Karena `Step -2` bergerak turun dari `1`, sementara `1` sudah lebih kecil dari `10`, sehingga loop langsung berhenti tanpa berputar sekali pun. |
| Kosong | `1` | Muncul pop-up `"Masukkan dalam bentuk angka"`, kursor pindah ke `txtNilaiAwal`. |

---

## 6. Eksperimen: Jika Variabel atau Nilainya Diubah-Ubah Jadi Apa?

| Bagian / Variabel yang Diubah | Nilai Awal | Diubah Menjadi | Dampak & Hasil yang Terjadi |
| :--- | :--- | :--- | :--- |
| Nilai `Step` | `Step -2` | `Step -1` | Hitung mundur melangkah 1 per 1: untuk `10` ke `1` hasilnya menjadi `10, 9, 8, 7, 6, 5, 4, 3, 2, 1`. |
| Nilai `Step` | `Step -2` | `Step 2` (atau `Step` dihapus karena default adalah `+1`) | Arah loop berbalik menjadi **hitung maju/naik**. Input `1` ke `10` menghasilkan `1, 3, 5, 7, 9`, sedangkan `10` ke `1` menjadi kosong. |
| Baris `lstHasil.Items.Clear()` | Ada sebelum `For` | Dihapus atau diberi komentar `'` | Setiap tombol `Input` diklik berkali-kali, hasil baru terus menempel di bawah hasil lama di dalam `ListBox`. |
| Letak `lstHasil.Items.Clear()` | Di luar (sebelum) `For` | Dipindahkan ke dalam blok `For` (sebelum `lstHasil.Items.Add(i)`) | **Logic Error!** Pada setiap putaran daftar dibersihkan lagi, sehingga di akhir loop `lstHasil` hanya berisi **1 angka terakhir** saja (misal hanya `2`). |
| Nilai `Step -2` | `Step -2` | `Step 0` | **Infinite Loop (Program Macet/Hang)!** Nilai `i` tidak pernah bertambah maupun berkurang, sehingga `For` berputar selamanya jika `nilaiAwal` cocok dan aplikasi tidak merespons. |
| Diganti menjadi `While` | `For i As Integer = nilaiAwal To nilaiAkhir Step -2` | `Dim i As Integer = nilaiAwal` lalu `While i >= nilaiAkhir` ... `i -= 2` | Hasilnya identik dengan `For ... Step -2`, namun pengurangan `i -= 2` harus ditulis manual (jika lupa ditulis, program macet karena *infinite loop*). |
| Diganti menjadi `Nested Loop` (di dalam `For i`) | Hanya 1 loop `For i` | Ditambah `For j As Integer = 1 To 3` di dalam `For i` | Untuk setiap satu angka `i`, `j` berjalan lengkap `1, 2, 3`. Cocok untuk menampilkan pasangan koordinat atau perkalian tabel. |

---

## 7. Kesalahan Umum & Tips Praktis

1. **Arah `Step` berlawanan dengan nilai awal dan akhir:** Jika menghitung mundur (`10` ke `1`), `Step` **wajib** negatif (`Step -1`, `Step -2`). Jika tidak ditulis, VB.NET menganggap `Step 1` sehingga loop tidak berjalan sama sekali.
2. **Lupa menaikkan/menurunkan variabel pengontrol pada `While` atau `Do...Loop`:** Berbeda dengan `For...Next` yang otomatis mengubah `i`, pada `While` kita wajib menulis `i += 1` atau `i -= 2` agar program tidak terjebak *infinite loop*.
3. **Lupa `.Items.Clear()` sebelum mengisi ulang `ListBox`:** Membuat tampilan penuh dengan data duplikat dari percobaan sebelumnya.

---

Navigasi: [Pertemuan 3](../Praktikum%203/readme.md) | [Kembali ke README Utama](../readme.md) | [Lanjut ke Pertemuan 5](../Praktikum%205/readme.md)
