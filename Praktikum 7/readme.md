# Pertemuan 7: Validasi Input, Error Handling, & Naming Convention

## 1. Gambaran Umum & Analogi

Pada Pertemuan 7 di proyek [Praktikum 7](./FormPendaftaran.slnx), kita meningkatkan kualitas program dari sekadar "asal jalan" menjadi program yang tahan banting menghadapi kesalahan input pengguna dan gangguan luar.

Bayangkan sistem keamanan di sebuah gedung perkantoran:
- **Naming Convention (`txtNim`, `btnSimpan`, `cboJurusan`):** Seperti menamai setiap ruangan dengan jelas (*Ruang Arsip*, *Loket Pendaftaran*) alih-alih *Kamar 1*, *Kamar 2*, agar tim tidak bingung saat membaca kode.
- **Validasi Input (`TryParse`, `ModValidasi`):** Seperti **satpam di pintu masuk** yang memeriksa apakah formulir lengkap, NIM 9 digit angka, dan IPK masuk akal (`0.00`–`4.00`) sebelum boleh disimpan.
- **`ErrorProvider` (`errInput`):** Seperti **stiker tanda seru merah** yang ditempel tepat di kolom yang salah, jadi pendaftar langsung tahu bagian mana yang harus diperbaiki tanpa menutup 5 jendela `MessageBox` beruntun.
- **`Try ... Catch ... Finally`:** Seperti **jaring pengaman akrobat** saat program harus melakukan hal di luar kendali kita (misal menulis file CSV yang mungkin sedang dikunci oleh Excel).

---

## 2. Ringkasan Konsep Materi

### A. Aturan Naming Convention (`prefix + NamaFungsi`)

| Kontrol | Prefix | Contoh `(Name)` |
| :--- | :---: | :--- |
| Form | `frm` / `Frm` | `FrmUtama`, `FrmPendaftaran`, `FrmUjiKonversi` |
| Label | `lbl` | `lblJudul`, `lblNim`, `lblStatus` |
| TextBox | `txt` | `txtNim`, `txtNama`, `txtAngkatan`, `txtIpk` |
| Button | `btn` | `btnSimpan`, `btnBersihkan`, `btnEkspor` |
| ComboBox | `cbo` | `cboJurusan` |
| ListBox | `lst` | `lstMahasiswa` |
| ErrorProvider | `err` | `errInput` |

*Aturan Emas:* Ubah properti `(Name)` **sebelum** melakukan *double-click* untuk membuat event, agar nama prosedur event otomatis rapi (misal `btnSimpan_Click`, bukan `Button1_Click`).

### B. 3 Jenis Error & Perbandingan `CInt`, `Val`, dan `TryParse`
- **Syntax Error:** Salah ketik kode (ditandai garis merah di Visual Studio sebelum program jalan).
- **Runtime Error (Exception):** Error saat aplikasi berjalan (contoh: `FormatException`, `InvalidCastException`, `OverflowException`, `DivideByZeroException`, `IOException`). Ditangani dengan `Try...Catch...Finally`.
- **Logic Error:** Program berjalan tanpa error, tetapi hasilnya keliru (hanya ketahuan lewat pengujian data).

| Input | `CInt(teks)` | `Val(teks)` | `Integer.TryParse` |
| :--- | :--- | :--- | :--- |
| `"abc"` | `InvalidCastException` (crash) | `0` (diam-diam salah) | `False` (aman) |
| `"12abc"` | `InvalidCastException` (crash) | `12` (diam-diam lolos) | `False` (aman) |
| `"99999999999"` | `OverflowException` (crash) | `99999999999` | `False` (aman) |
| `""` (kosong) | `InvalidCastException` (crash) | `0` (diam-diam salah) | `False` (aman) |

*Prinsip Inti:* **Cegah dengan validasi apa yang bisa dicegah. Tangkap dengan `Try...Catch` apa yang tidak bisa dicegah** (seperti I/O file atau jaringan).

---

## 3. Daftar Komponen Antarmuka (UI Controls)

Proyek `FormPendaftaran` memiliki 3 Form utama:
1. [FrmUtama](./FrmUtama.Designer.vb): `lblJudul`, `btnUjiKonversi`, `btnPendaftaran`.
2. [FrmUjiKonversi](./FrmUjiKonversi.Designer.vb): `txtInput`, `btnCInt`, `btnVal`, `btnTryParse`, `btnTryCatch`, `btnCatchBertingkat`, `lblHasil`.
3. [FrmPendaftaran](./FrmPendaftaran.Designer.vb):

| Jenis Kontrol | Properti `(Name)` | Properti Kunci | Fungsi pada Aplikasi |
| :--- | :--- | :--- | :--- |
| `TextBox` | `txtNim` | `MaxLength: 9` | Input NIM tepat 9 digit angka; punya event `Validating` |
| `TextBox` | `txtNama` | `MaxLength: 100` | Input nama lengkap mahasiswa (wajib isi) |
| `ComboBox` | `cboJurusan` | `DropDownStyle: DropDownList` | Memaksa pengguna memilih dari 4 daftar jurusan saja |
| `TextBox` | `txtAngkatan` | `MaxLength: 4` | Input tahun angkatan (`2015` s.d. tahun berjalan) |
| `TextBox` | `txtIpk` | `MaxLength: 4` | Input IPK desimal (`0.00` s.d. `4.00`, mendukung titik maupun koma) |
| `Button` | `btnSimpan` | `AcceptButton` milik Form | Memvalidasi semua isian lalu menyimpan ke `lstMahasiswa` |
| `Button` | `btnBersihkan` | `CausesValidation: False` | Mengosongkan form tanpa terhalang `Validating` |
| `ListBox` | `lstMahasiswa` | `HorizontalScrollbar: True` | Daftar mahasiswa yang sudah lolos validasi |
| `Button` | `btnEkspor` | `CausesValidation: False` | Mengekspor isi `lstMahasiswa` ke `Documents\data-mahasiswa.csv` |
| `Label` | `lblStatus` | `Text: "Siap."` | Menampilkan status proses atau arahan perbaikan |
| `ErrorProvider` | `errInput` | Muncul di *Component Tray* | Memasang ikon seru merah di sebelah input yang tidak valid |

---

## 4. Bedah Kode Program: Kodenya Ini Buat Apa?

### A. [ModValidasi.vb](./ModValidasi.vb) — Fungsi Bantu Validasi Lintas Form

```vbnet
Public Module ModValidasi
    Public Function Kosong(teks As String) As Boolean
        Return teks.Trim() = ""
    End Function

    Public Function SemuaDigit(teks As String, panjang As Integer) As Boolean
        If teks.Length <> panjang Then Return False
        For Each karakter As Char In teks
            If karakter < "0"c OrElse karakter > "9"c Then Return False
        Next
        Return True
    End Function

    Public Function CobaDesimal(teks As String, ByRef hasil As Decimal) As Boolean
        Dim teksTitik As String = teks.Trim().Replace(",", ".")
        Return Decimal.TryParse(teksTitik, NumberStyles.AllowDecimalPoint,
                                CultureInfo.InvariantCulture, hasil)
    End Function
End Module
```

**Penjelasan:**
- **`Kosong(teks)`**: `.Trim()` menghapus spasi di kiri/kanan. Jadi jika pengguna mengetik `"   "` (hanya spasi), tetap dianggap kosong (`True`).
- **`SemuaDigit(teks, panjang)`**: Mengecek dua hal sekaligus: panjang teks wajib tepat sama dengan `panjang` (misal `9`) dan setiap karakternya berada di rentang karakter `'0'` s.d. `'9'`.
- **`CobaDesimal(teks, ByRef hasil)`**: Mengatasi jebakan perbedaan bahasa Windows! Pada Windows setelan Indonesia, koma dianggap pemisah desimal sedangkan titik dianggap pemisah ribuan (`"3.75"` bisa terbaca `375`). Dengan mengganti `","` menjadi `"."` lalu mem-parsing memakai `CultureInfo.InvariantCulture`, baik input `"3,75"` maupun `"3.75"` selalu menghasilkan angka desimal `3.75` secara konsisten.

### B. [FrmUjiKonversi.vb](./FrmUjiKonversi.vb) — Demonstrasi `CInt`, `Val`, `TryParse`, dan `Catch` Bertingkat

```vbnet
    Private Sub btnCatchBertingkat_Click(sender As Object, e As EventArgs) Handles btnCatchBertingkat.Click
        Try
            Dim angka As Integer = Integer.Parse(txtInput.Text)
            Dim hasil As Integer = 1000 \ angka
            lblHasil.Text = "1000 \ " & angka.ToString() & " = " & hasil.ToString()
        Catch ex As FormatException
            lblHasil.Text = "Format salah: input bukan bilangan bulat."
        Catch ex As OverflowException
            lblHasil.Text = "Angka terlalu besar untuk tipe Integer."
        Catch ex As DivideByZeroException
            lblHasil.Text = "Pembagian dengan nol tidak diperbolehkan."
        Catch ex As Exception
            lblHasil.Text = "Error lain: " & ex.Message
        End Try
    End Sub
```

**Penjelasan:**
- `Catch` diperiksa **dari atas ke bawah** dan hanya blok pertama yang cocok yang dijalankan.
- Oleh sebab itu, exception yang spesifik (`FormatException`, `OverflowException`, `DivideByZeroException`) **wajib** ditaruh di atas, sedangkan `Catch ex As Exception` (induk segala error) wajib berada paling bawah sebagai penangkap cadangan.

### C. [FrmPendaftaran.vb](./FrmPendaftaran.vb) — Validasi Terpusat, `Validating`, & Ekspor CSV dengan `Finally`

1. **`ValidasiInput()`** (pola periksa semua sekaligus):
   - Memanggil `errInput.Clear()` di baris pertama agar ikon merah kesalahan sebelumnya hilang.
   - Menggunakan variabel penanda `Dim valid As Boolean = True`. Setiap input (`txtNama`, `txtAngkatan`, `txtNim`, `cboJurusan`, `txtIpk`) dicek **semuanya** tanpa langsung `Return` di tengah jalan, sehingga pengguna melihat seluruh kesalahan sekaligus.
   - Mengecek keunikan NIM dengan `ElseIf daftarNim.Contains(txtNim.Text)`.
2. **`btnSimpan_Click`**:
   - Memakai pola *"periksa dulu, keluar jika gagal"*: `If Not ValidasiInput() Then ... Return`.
   - Karena semua input sudah dipastikan valid oleh `ValidasiInput()`, pemanggilan `CobaDesimal(txtIpk.Text, ipk)` dan penyimpanan tidak memerlukan `Try...Catch`.
3. **`txtNim_Validating`**:
   - Berjalan otomatis setiap kursor berpindah keluar dari `txtNim`. Memberikan umpan balik cepat tanpa mengunci fokus (`e.Cancel = True` sengaja tidak dipakai agar tombol `Bersihkan` dan tombol silang X tetap bisa diklik kapan saja).
4. **`btnEkspor_Click`** (menggunakan `Try ... Catch ... Finally`):
   ```vbnet
        Dim penulis As StreamWriter = Nothing
        Try
            penulis = New StreamWriter(lokasiEkspor)
            For Each baris As Object In lstMahasiswa.Items
                penulis.WriteLine(baris.ToString().Replace(" | ", ";"))
            Next
            lblStatus.Text = "Data diekspor ke " & lokasiEkspor
        Catch ex As IOException
            MessageBox.Show("File sedang dipakai program lain atau tidak bisa ditulis." &
                            vbCrLf & ex.Message, "Ekspor Gagal")
        Finally
            If penulis IsNot Nothing Then penulis.Close()   ' file selalu ditutup
        End Try
   ```
   - Blok `Finally` **pasti selalu dijalankan**, baik saat ekspor sukses maupun saat gagal (`IOException`), sehingga file tidak tertinggal dalam kondisi terkunci di sistem operasi.

---

## 5. Apa yang Dihasilkan Program

1. Saat membuka menu **1. Uji Konversi & Try...Catch** (`FrmUjiKonversi`):
   - Input `"abc"` + klik `Uji CInt`: program berhenti dengan `InvalidCastException` (demonstrasi bahaya tanpa penanganan error).
   - Input `"12abc"` + klik `Uji Val`: menampilkan `12` (demonstrasi bahaya `Val` yang meloloskan teks salah).
   - Input `"abc"` + klik `Uji Integer.TryParse`: program tetap aman dan menampilkan `"Bukan bilangan bulat yang valid."`.
   - Pada `Catch Bertingkat`: input `"abc"` masuk `FormatException`, `"99999999999"` masuk `OverflowException`, `"0"` masuk `DivideByZeroException`, dan `"25"` menampilkan `"1000 \ 25 = 40"`.
2. Saat membuka menu **2. Studi Kasus: Form Pendaftaran** (`FrmPendaftaran`):
   - Klik `Simpan` saat form kosong: muncul 5 ikon merah `ErrorProvider` sekaligus di sebelah NIM, Nama, Jurusan, Angkatan, dan IPK.
   - Isi data valid (misal NIM `241712042`, Nama `Michael Deryl`, Jurusan `Teknik Informatika`, Angkatan `2024`, IPK `3,85` atau `3.85`) -> tersimpan rapi ke `lstMahasiswa` dengan IPK terformat `3,85` / `3.85`, NIM dicatat di `daftarNim`, dan form otomatis dibersihkan.
   - Memasukkan NIM `241712042` lagi -> ditolak dengan pesan `"NIM sudah terdaftar."`.
   - Klik `Ekspor ke CSV` -> membuat file `data-mahasiswa.csv` di folder `Documents` dengan pemisah `;` agar rapi dibuka di Excel.

---

## 6. Eksperimen: Jika Variabel atau Nilainya Diubah-Ubah Jadi Apa?

| Bagian / Variabel yang Diubah | Nilai Awal | Diubah Menjadi | Dampak & Hasil yang Terjadi |
| :--- | :--- | :--- | :--- |
| Urutan `Catch ex As Exception` di `FrmUjiKonversi.vb` | Paling bawah | Dipindah ke paling atas (sebelum `FormatException`) | **Compile Error** di VB.NET! Karena `Exception` adalah induk semua error, `Catch` di bawahnya menjadi kode mati (*unreachable*) dan ditolak compiler. |
| Baris `errInput.Clear()` di awal `ValidasiInput()` | Ada di awal fungsi | Dihapus | Ikon merah pada kontrol yang sebenarnya **sudah diperbaiki** oleh pengguna tetap menempel tidak mau hilang sampai form di-reset. |
| Fungsi `CobaDesimal` di `ModValidasi.vb` | Memakai `Replace(",", ".")` dan `CultureInfo.InvariantCulture` | Diganti menjadi `Decimal.TryParse(teks, hasil)` biasa | Pada Windows berbahasa Indonesia, input `"3.85"` (pakai titik) terbaca sebagai `385` dan ditolak karena `> 4D`. Pada Windows berbahasa Inggris, input `"3,85"` (pakai koma) justru terbaca `385` atau gagal. |
| Komentar `' e.Cancel = True` di `txtNim_Validating` | Dikomentari (tidak dipakai) | Diaktifkan (`e.Cancel = True`) | Jika NIM belum 9 digit, **kursor terkunci mati di dalam `txtNim`**; pengguna bahkan tidak bisa menekan tombol X untuk menutup form kecuali tombol `Bersihkan` (`CausesValidation = False`). |
| Properti `btnBersihkan.CausesValidation` | `False` | `True` (default) | Saat NIM masih salah dan pengguna mengklik `Bersihkan`, event `txtNim_Validating` tetap ikut terpanggil lebih dulu sebelum form dibersihkan. |
| Rentang validasi di `ValidasiInput()` | `angkatan < 2015 OrElse angkatan > Date.Today.Year` | `angkatan < 2020 OrElse angkatan > 2026` | Mahasiswa angkatan `2019` yang sebelumnya valid kini ditolak oleh validator dengan ikon merah. |
| Pemisah kolom di `btnEkspor_Click` | `.Replace(" | ", ";")` | `.Replace(" | ", ",")` | File CSV memakai pemisah koma (standar internasional), namun pada Excel region Indonesia seluruh kolom bisa menyatu dalam 1 kolom karena Excel lokal mengharapkan `;`. |

---

## 7. Kesalahan Umum & Tips Praktis

1. **Catch kosong (`Catch ex As Exception` tanpa isi):** Menyembunyikan error diam-diam membuat bug mustahil dilacak. Selalu tampilkan pesan yang jelas untuk pengguna atau catat detail masalahnya.
2. **Menampilkan `ex.ToString()` mentah-mentah ke pengguna:** Pengguna awam bingung melihat *stack trace* bahasa teknis. Berikan arahan perbaikan yang jelas dan jadikan `ex.Message` sebagai detail tambahan bila perlu.
3. **Lupa menutup `StreamWriter` tanpa `Finally`:** Jika error terjadi saat menulis file dan `penulis.Close()` hanya ditaruh di akhir `Try`, file tetap terkunci sampai aplikasi ditutup. Gunakan selalu `Finally` atau blok `Using`.

---

Navigasi: [Pertemuan 6](../Praktikum%206/readme.md) | [Kembali ke README Utama](../readme.md) | [Lanjut ke Pertemuan 8](../Praktikum%208/readme.md)
