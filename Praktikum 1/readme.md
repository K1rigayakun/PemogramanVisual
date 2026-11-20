# Pertemuan 1: Pengenalan Pemrograman Visual

## 1. Gambaran Umum & Analogi

Bayangkan kamu sedang menyusun ruang kerja atau merakit balok Lego.

- **Pemrograman Teks Murni (Konvensional):** Seperti menukang lemari dari nol hanya bermodalkan papan kayu dan gergaji. Setiap posisi tombol, lebar jendela, dan garis kotak harus dihitung serta diketik manual lewat ratusan baris teks.
- **Pemrograman Visual (Visual Programming):** Seperti menyusun balok Lego siap pakai. Kamu tinggal memilih komponen visual (tombol, kotak ketik, teks keterangan) dari kotak perkakas (*Toolbox*), menariknya ke atas layar (*drag-and-drop*), lalu menulis logika program di balik komponen tersebut.

Pada mata kuliah ini, kita membangun aplikasi desktop Windows menggunakan:
1. **Visual Studio** sebagai bengkel kerja (*IDE / Integrated Development Environment*) tempat mendesain tampilan, menulis kode, dan menguji aplikasi.
2. **.NET 10 (Windows Forms)** sebagai kerangka kerja (*framework*) modern yang menyediakan jendela (*Form*) dan komponen antarmuka siap pakai.
3. **Visual Basic .NET (VB.NET)** sebagai bahasa pemrograman dengan struktur kalimat mendekati bahasa Inggris sehari-hari.

---

## 2. Ringkasan Konsep Materi

### A. Pengertian & Karakteristik Utama
**Pemrograman Visual** adalah pendekatan pengembangan program melalui manipulasi elemen grafis (blok, diagram, atau komponen visual) untuk merepresentasikan struktur dan alur logika program.

Tiga karakteristik utamanya:
1. **Representasi Visual:** Logika atau struktur antarmuka digambarkan lewat elemen grafis yang saling terhubung.
2. **Mekanisme Drag-and-Drop:** Komponen program dan tampilan disusun langsung dengan klik-tarik-lepas di atas kanvas (*Form Designer*).
3. **Umpan Balik Langsung:** Perubahan desain maupun tata letak dapat dilihat seketika sebelum aplikasi dijalankan.

### B. Tujuan, Manfaat & Keterbatasan

| Aspek | Poin Penting |
| :--- | :--- |
| **Tujuan & Manfaat** | 1. Mempermudah pemahaman konsep dasar pemrograman.<br>2. Menyajikan alur program secara visual dan terstruktur.<br>3. Mempersiapkan pemula sebelum masuk ke sintaks kode yang kompleks.<br>4. Meminimalkan kesalahan ketik (*syntax error*) saat menyusun antarmuka. |
| **Keterbatasan** | 1. **Fleksibilitas Terbatas:** Bergantung pada komponen bawaan yang disediakan platform.<br>2. **Kurang Efisien untuk Proyek Raksasa:** Jika seluruh logika menumpuk di tampilan tanpa pemisahan modul, proyek menjadi sulit dirawat.<br>3. **Ketergantungan Platform:** Aplikasi WinForms VB.NET terikat pada ekosistem .NET dan sistem operasi Windows. |

### C. Contoh Platform Pemrograman Visual

| Platform | Gaya Pemrograman | Cocok Untuk |
| :--- | :--- | :--- |
| **Scratch** | Blok visual murni (menyusun puzzle) | Belajar logika dasar dan animasi sederhana |
| **MIT App Inventor** | Blok visual + perancangan layar | Aplikasi Android dasar tanpa mengetik sintaks |
| **Visual Basic .NET (VB.NET)** | Desain GUI *drag-and-drop* + kode berbasis *event* | Aplikasi desktop Windows dengan logika bisnis terstruktur |
| **JavaFX (Scene Builder)** | Desain GUI berbasis FXML + bahasa Java | Aplikasi desktop lintas sistem operasi berbasis Java |

---

## 3. Contoh Kode Pertama di VB.NET: Kodenya Ini Buat Apa?

Pertemuan 1 berfokus pada pengenalan teori dan lingkungan Visual Studio (belum ada proyek tugas di folder ini). Namun, sebagai gambaran awal bagaimana tampilan visual terhubung dengan kode di VB.NET, perhatikan contoh paling dasar berikut:

```vbnet
Option Strict On

Public Class FrmSapa
    ' Prosedur ini otomatis berjalan ketika pengguna mengklik tombol btnSapa
    Private Sub btnSapa_Click(sender As Object, e As EventArgs) Handles btnSapa.Click
        Dim namaPengguna As String = "Mahasiswa"
        Dim jumlahKlik As Integer = 1

        lblPesan.Text = "Halo, " & namaPengguna & "! Klik ke-" & jumlahKlik.ToString()
        Me.Text = "Aplikasi Pertemuan 1"
    End Sub
End Class
```

### Penjelasan Kode Baris demi Baris:
- `Option Strict On`: "Satpam" tipe data. Menyuruh VB.NET menolak pencampuran tipe data secara sembarangan (misal angka harus diubah ke teks memakai `.ToString()` sebelum digabungkan ke kalimat).
- `Public Class FrmSapa`: Menandakan semua kode di dalam blok ini milik jendela bernama `FrmSapa`.
- `Private Sub btnSapa_Click(...) Handles btnSapa.Click`: Blok kode ini tidak berjalan terus-menerus, melainkan menunggu **kejadian (*event*)** tombol `btnSapa` diklik (`Click`).
- `Dim namaPengguna As String = "Mahasiswa"`: Membuat variabel penyimpan teks bernama `namaPengguna` dengan isi awal `"Mahasiswa"`.
- `Dim jumlahKlik As Integer = 1`: Membuat variabel penyimpan bilangan bulat bernama `jumlahKlik` bernilai `1`.
- `lblPesan.Text = ...`: Mengubah tulisan yang tampil pada komponen label `lblPesan` di layar. Tanda `&` dipakai untuk menyambung teks.
- `Me.Text = ...`: Kata kunci `Me` merujuk ke Form yang sedang terbuka, sehingga baris ini mengubah judul di bagian atas jendela Form.

---

## 4. Apa yang Dihasilkan Program

Saat program contoh di atas dijalankan (tekan **F5** di Visual Studio):
1. Muncul satu jendela Form di layar berisi teks awal pada `lblPesan` dan satu tombol `btnSapa`.
2. Sebelum tombol diklik, kode di dalam `btnSapa_Click` belum bekerja.
3. Begitu pengguna mengklik `btnSapa`, teks di `lblPesan` langsung berubah menjadi `Halo, Mahasiswa! Klik ke-1` dan judul jendela di pojok kiri atas berubah menjadi `Aplikasi Pertemuan 1`.

---

## 5. Eksperimen: Jika Variabel atau Nilainya Diubah-Ubah Jadi Apa?

Gunakan tabel berikut untuk memahami bagaimana setiap perubahan kecil di kode langsung mengubah hasil di layar:

| Bagian / Variabel yang Diubah | Nilai Awal | Diubah Menjadi | Dampak & Hasil yang Terjadi |
| :--- | :--- | :--- | :--- |
| Isi variabel `namaPengguna` | `"Mahasiswa"` | `"Michael Deryl"` | Tulisan di `lblPesan` berubah menjadi `"Halo, Michael Deryl! Klik ke-1"`. |
| Tipe data `jumlahKlik` | `As Integer = 1` | `As Integer = "Satu"` | **Compile Error** (garis merah di editor) karena dengan `Option Strict On`, teks `"Satu"` tidak boleh masuk ke variabel angka `Integer`. |
| Pemisah `&` pada penggabungan teks | `"Halo, " & namaPengguna` | `"Halo, " + namaPengguna` *(lalu digabung Integer tanpa `.ToString()`)* | Jika memakai `+` antara `String` dan `Integer` tanpa `.ToString()`, VB.NET mencoba menjumlahkan angka dan memicu error tipe data. Karena itu di VB.NET selalu gunakan `&`. |
| Letak `Dim jumlahKlik As Integer = 1` | Di dalam `Sub btnSapa_Click` | Dipindah ke atas `Sub` (level Class) lalu ditambah `jumlahKlik += 1` | Nilai `jumlahKlik` tidak direset ke 1 lagi tiap klik. Setiap tombol diklik, angkanya naik menjadi `Klik ke-2`, `Klik ke-3`, dst. |
| Kata kunci `Me.Text` | `"Aplikasi Pertemuan 1"` | `""` (string kosong) | Judul jendela di bilah atas Form menjadi kosong tidak bertuliskan apa-apa. |
| Klausa `Handles btnSapa.Click` | Ada (`Handles btnSapa.Click`) | Dihapus | Saat tombol diklik berkali-kali, tidak terjadi apa-apa karena Sub tidak lagi terhubung ke event klik tombol tersebut. |

---

## 6. Kesalahan Umum & Tips Praktis

1. **Salah memilih template proyek saat membuat project baru:** Pastikan selalu memilih **Windows Forms App** dengan target **.NET 10** (bukan *Console App* dan bukan *.NET Framework* lawas).
2. **Mengira desain tampilan saja sudah cukup:** Komponen yang ditarik dari Toolbox ke Form tidak akan melakukan aksi apa pun sebelum kamu menuliskan logika pada event-nya (seperti `Click`).
3. **Menghapus atau memindahkan baris `Handles ...`:** Jika tombol mendadak tidak merespons klik, periksa bagian ujung kanan baris `Private Sub ...` apakah masih memiliki `Handles namaTombol.Click`.

---

Navigasi: [Kembali ke README Utama](../readme.md) | [Lanjut ke Pertemuan 2](../Praktikum%202/readme.md)
