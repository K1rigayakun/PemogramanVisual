# Dokumentasi Praktikum Pemrograman Visual (VB.NET / .NET 10)

Repositori ini berisi kumpulan proyek praktikum, tugas, dan dokumentasi pembelajaran mata kuliah **Praktikum Pemrograman Visual** menggunakan **Visual Basic .NET (VB.NET)** dan **Windows Forms (.NET 10)**.

- **Nama:** Michael Deryl Aaron Matthew
- **NIM:** 241712042
- **Kelas / Kom:** A2
- **Program Studi:** D3 Teknik Informatika, Universitas Sumatera Utara
- **Teknologi:** Visual Studio, .NET 10 (`net10.0-windows`), VB.NET (`Option Strict On`), WinForms, PostgreSQL / Supabase (`Npgsql`)

---

## Daftar Modul Praktikum

Setiap folder praktikum dilengkapi dengan proyek `.slnx` / `.sln` yang siap dibuka di Visual Studio serta file `readme.md` berisi penjelasan konsep, bedah kode baris demi baris, hasil eksekusi, dan skenario eksperimen perubahan variabel.

> **Catatan:** Pertemuan 09 dan Pertemuan 10 merupakan jadwal UTS / Responsi sehingga tidak terdapat modul praktikum reguler pada pertemuan tersebut.

| Pertemuan | Topik Pembahasan | Proyek / Solusi | Dokumentasi |
| :---: | :--- | :--- | :---: |
| **Pertemuan 01** | Orientasi & Pengenalan Pemrograman Visual | Teori & Contoh Dasar | [Buka Materi](./Praktikum%201/readme.md) |
| **Pertemuan 02** | Komponen Visual (`Form`, `Label`, `TextBox`, `Button`), Properti, & Event | [Praktikum2.slnx](./Praktikum%202/Praktikum2.slnx) | [Buka Materi](./Praktikum%202/readme.md) |
| **Pertemuan 03** | 5 Jenis Operator, Ekspresi, Percabangan (`If...ElseIf`), & Validasi `KeyPress` | [Praktikum 3.slnx](./Praktikum%203/Praktikum%203.slnx) | [Buka Materi](./Praktikum%203/readme.md) |
| **Pertemuan 04** | Struktur Perulangan (`For...Next`, `Step`, `While`, `Do...Loop`, `Nested Loop`) | [pertemuan 4.slnx](./Praktikum%204/pertemuan%204.slnx) | [Buka Materi](./Praktikum%204/readme.md) |
| **Pertemuan 05** | `Module`, `Public` vs `Private`, `Sub` vs `Function`, `Array` (1D/2D/3D), & Koleksi (`List`, `Dictionary`, `HashSet`) | [Praktikum5.slnx](./Praktikum%205/Praktikum5.slnx) | [Buka Materi](./Praktikum%205/readme.md) |
| **Pertemuan 06** | Koneksi Database PostgreSQL (Supabase) & Npgsql (`SELECT` & `INSERT`) | [Pertemuan 6.slnx](./Praktikum%206/Pertemuan%206.slnx) | [Buka Materi](./Praktikum%206/readme.md) |
| **Pertemuan 07** | Validasi Input (`TryParse`, `CobaDesimal`), `Try...Catch...Finally`, `ErrorProvider`, & Naming Convention | [FormPendaftaran.slnx](./Praktikum%207/FormPendaftaran.slnx) | [Buka Materi](./Praktikum%207/readme.md) |
| **Pertemuan 08** | `DataGridView`, Array 2D, `List(Of T)`, `DataTable`, `BindingSource`, & Pencarian (`Filter` vs Loop) | [DataMahasiswa.slnx](./Praktikum%208/DataMahasiswa.slnx) | [Buka Materi](./Praktikum%208/readme.md) |
| **Pertemuan 09–10** | Evaluasi Tengah Semester (UTS / Responsi) | Lihat Tabel Tugas di Bawah | - |
| **Pertemuan 11** | Windows API / P/Invoke (`GetTickCount64`, `SetWindowPos`, `RegisterHotKey`, `MessageBeep`) | [Praktikum pertemuan 11.slnx](./Praktikum%2011/Praktikum%20pertemuan%2011.slnx) | [Buka Materi](./Praktikum%2011/readme.md) |
| **Pertemuan 12** | `MenuStrip`, `ContextMenuStrip`, Dialog Modal, & Arsitektur MDI Administrasi Mahasiswa | [AdministrasiMahasiswaMdi.sln](./Praktikum%2012/AdministrasiMahasiswaMdi.sln) | [Buka Materi](./Praktikum%2012/readme.md) |
| **Pertemuan 13** | Packaging Proyek Akhir WinForms, Supabase Auth/Data API, & Row Level Security (RLS) | [DaftarTugas.vbproj](./Praktikum%2013/DaftarTugas/DaftarTugas.vbproj) | [Buka Materi](./Praktikum%2013/readme.md) |

---

## Daftar Proyek Tugas & Responsi

Seluruh tugas dan proyek responsi dikelompokkan di dalam folder `./Tugas/`:

| Tugas / Evaluasi | Studi Kasus | File Solusi |
| :--- | :--- | :--- |
| **Tugas 1 (Percabangan & Multi-Form)** | Sistem Login & Perhitungan Pajak Pendapatan | [TugasPajak.slnx](./Tugas/TugasPajak/TugasPajak.slnx) |
| **Tugas Perulangan** | Proyek Dasar Perulangan | [Tugas Perulangan.slnx](./Tugas/Tugas%20Perulangan/Tugas%20Perulangan.slnx) |
| **Tugas Pertemuan 07** | Form Peminjaman Buku (Validasi `ErrorProvider`, `TryParse`, Ekspor CSV) | [241712042_Michael_Deryl_Tugas07.slnx](./Tugas/241712042_Michael%20Deryl_Tugas07/241712042_Michael_Deryl_Tugas07.slnx) |
| **Tugas Pertemuan 08** | Inventaris Buku Perpustakaan (`DataTable`, `BindingSource.Filter`, Sorting) | [241712042_Michael_Deryl_Tugas_3.slnx](./Tugas/241712042_Michael%20Deryl_Tugas%203/241712042_Michael_Deryl_Tugas_3.slnx) |
| **Responsi / UTS** | Aplikasi Kasir Fotokopi (`List(Of Pesanan)`, `ModTarif`, Diskon Otomatis) | [241712042_Michael Deryl_Kom A2.slnx](./Tugas/241712042_Michael%20Deryl_Kom%20A2/241712042_Michael%20Deryl_Kom%20A2.slnx) |
| **Perbaikan Responsi** | Sistem Peminjaman Alat Laboratorium (dengan Skrip Pengujian Terotomasi) | [241712042_Michael_Deryl_RemedialUTS.slnx](./Tugas/Perbaikan%20Responsi/241712042_Michael_Deryl_RemedialUTS.slnx) |

---

## Cara Menjalankan Proyek

### Prasyarat
- Sistem Operasi Windows (karena menggunakan `Windows Forms` / `net10.0-windows`).
- **.NET 10 SDK** terpasang di sistem (`dotnet --version`).
- **Microsoft Visual Studio 2022 / 2026** (dengan beban kerja *.NET desktop development*) untuk membuka *Form Designer*.

### Opsi 1: Melalui Visual Studio (Disarankan untuk Belajar Desain UI)
1. Buka file `.slnx` atau `.sln` di dalam masing-masing folder praktikum (jangan gunakan *Open Folder* agar WinForms Designer termuat sempurna).
2. Klik kanan Form di *Solution Explorer* dan pilih **View Designer** (`Shift+F7`) untuk melihat tampilan visual, atau **View Code** (`F7`) untuk melihat kode `.vb`.
3. Tekan **F5** untuk menjalankan aplikasi.

### Opsi 2: Melalui Terminal / PowerShell (.NET CLI)
Masuk ke folder praktikum yang diinginkan, lalu jalankan build dan run:
```powershell
cd "Praktikum 8"
dotnet build DataMahasiswa.vbproj
dotnet run --project DataMahasiswa.vbproj
```

### Catatan Khusus untuk Pertemuan 6 (Database Supabase)
Proyek `Praktikum 6` membaca Connection String dari file `appsettings.json`. Jika ingin menyambungkan ke proyek Supabase milikmu sendiri, sesuaikan isinya dengan format berikut:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=aws-0-ap-southeast-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.PROJECT_ID;Password=PASSWORD_SUPABASE_ANDA;SSL Mode=Require;Trust Server Certificate=true"
  }
}
```

---

## Kamus Sintaks & Rujukan Cepat VB.NET

Rujukan ringkas seluruh perintah, properti, dan fungsi penting dari Pertemuan 1 s.d. 13:

### 1. Komponen Antarmuka (UI Controls) & Naming Convention

Pola wajib penamaan kontrol adalah **`prefix + NamaFungsi`** (ubah `(Name)` sebelum melakukan *double-click* untuk membuat event):

| Kontrol | Prefix | Contoh `(Name)` | Properti & Method Penting |
| :--- | :---: | :--- | :--- |
| `Form` | `frm` / `Frm` | `FrmPendaftaran` | `ClientSize`, `StartPosition`, `FormBorderStyle`, `MaximizeBox`, `AcceptButton`, `CancelButton`, `Me.Close()` |
| `Label` | `lbl` | `lblStatus` | `Text`, `Font`, `AutoSize`, `ForeColor`, `BackColor` |
| `TextBox` | `txt` | `txtNim` | `Text`, `MaxLength`, `ReadOnly`, `PasswordChar`, `.Clear()`, `.Focus()`, `.SelectAll()` |
| `Button` | `btn` | `btnSimpan` | `Text`, `Enabled`, `CausesValidation` (`False` untuk tombol Batal/Bersihkan) |
| `ComboBox` | `cbo` | `cboJurusan` | `DropDownStyle = DropDownList`, `Items.Add(...)`, `SelectedIndex` (`-1` = belum dipilih) |
| `ListBox` | `lst` | `lstMahasiswa` | `Items.Add(...)`, `Items.Clear()`, `SelectedIndex`, `SelectedItem`, `HorizontalScrollbar` |
| `PictureBox` | `pic` | `picImage` | `Image = Image.FromFile("path")`, `SizeMode = PictureBoxSizeMode.Zoom` |
| `DataGridView` | `dgv` | `dgvMahasiswa` | `DataSource`, `ReadOnly`, `AllowUserToAddRows`, `AutoSizeColumnsMode`, `SelectionMode` |
| `BindingSource` | `bs` | `bsMahasiswa` | `DataSource`, `Filter`, `RemoveFilter()`, `Add()`, `ResetBindings(False)`, `Count` |
| `ErrorProvider` | `err` | `errInput` | `SetError(kontrol, pesan)`, `SetError(kontrol, "")`, `Clear()` |
| `MenuStrip` / `ContextMenuStrip` | `mns` / `cms` | `mnsUtama`, `cmsCatatan` | `MdiWindowListItem`, `ShortcutKeys`, `Enabled`, `Opening` |

### 2. Manipulasi String & Karakter (`String`, `Char`)

| Perintah / Method | Contoh | Penjelasan |
| :--- | :--- | :--- |
| `teks.Trim()` | `txtNama.Text.Trim()` | Menghapus spasi kosong di awal dan akhir teks. |
| `teks.Length` | `txtNim.Text.Length` | Mengembalikan jumlah total karakter dalam teks. |
| `teks.ToLower()` / `.ToUpper()` | `kata.ToLower()` | Mengubah teks menjadi huruf kecil semua / huruf kapital semua. |
| `teks.Replace(lama, baru)` | `teks.Replace(",", ".")` | Mengganti semua kemunculan substring `lama` dengan `baru`. |
| `teks.Contains(kata)` | `mhs.Nama.Contains("Andi")` | Mengembalikan `True` jika teks mengandung `kata`. |
| `teks.StartsWith(awalan)` | `kode.StartsWith("BK")` | Mengembalikan `True` jika teks diawali dengan `awalan`. |
| `teks.Substring(mulai, panjang)` | `kode.Substring(2, 4)` | Memotong teks mulai indeks ke-`mulai` sebanyak `panjang` karakter. |
| `String.Join(pemisah, koleksi)` | `String.Join(" AND ", syarat)` | Menggabungkan elemen koleksi menjadi satu string dengan `pemisah`. |
| `s1 & s2` | `"Halo, " & nama` | Operator penggabungan string resmi di VB.NET. |
| `vbCrLf` | `"Baris 1" & vbCrLf & "Baris 2"` | Karakter pindah baris baru (*newline*). |
| `Char.IsDigit(c)` | `Char.IsDigit(e.KeyChar)` | `True` jika karakter adalah digit `0`–`9`. |
| `Char.IsLetter(c)` | `Char.IsLetter(e.KeyChar)` | `True` jika karakter adalah huruf alfabet. |
| `Char.IsWhiteSpace(c)` | `Char.IsWhiteSpace(e.KeyChar)` | `True` jika karakter adalah spasi. |
| `Char.IsControl(c)` | `Char.IsControl(e.KeyChar)` | `True` untuk tombol kontrol seperti `Backspace` dan `Enter`. |

### 3. Operator, Ekspresi, & Percabangan

- **Aritmatika:** `+`, `-`, `*`, `/` (bagi desimal), `\` (bagi bulat tanpa sisa), `Mod` (sisa bagi).
- **Penugasan:** `=`, `+=`, `-=`, `*=`, `/=`, `&=`.
- **Perbandingan:** `=`, `<>` (tidak sama dengan), `>`, `<`, `>=`, `<=`.
- **Logika:** `And`, `AndAlso` (*short-circuit*), `Or`, `OrElse` (*short-circuit*), `Not`, `Xor`.
- **Percabangan:**
  - `If kondisi Then ... End If`
  - `If kondisi Then ... Else ... End If`
  - `If k1 Then ... ElseIf k2 Then ... Else ... End If`
  - `Select Case var ... Case nilai ... Case Else ... End Select`
  - Ternary 1 baris: `Dim status As String = If(nilai >= 75, "Lulus", "Tidak Lulus")`

### 4. Struktur Perulangan (*Looping*)

| Sintaks | Jenis | Catatan Penting |
| :--- | :--- | :--- |
| `For i As Integer = 1 To 10 ... Next` | *Counted Loop* | Jumlah putaran pasti; default naik `+1`. |
| `For i As Integer = 10 To 1 Step -2 ... Next` | *Counted Loop* | Hitung mundur dengan langkah `-2`. |
| `For Each item In koleksi ... Next` | Iterasi Koleksi | Menelusuri seluruh isi array, `List`, atau `DataRow`. |
| `While kondisi ... End While` | *Pre-test Loop* | Kondisi dicek di awal; tidak jalan jika awal `False`. |
| `Do While kondisi ... Loop` | *Pre-test Loop* | Kondisi dicek di awal; ubah variabel pengontrol di dalam blok. |
| `Do ... Loop While kondisi` | *Post-test Loop* | Kondisi dicek di akhir; **pasti berjalan minimal 1 kali**. |

### 5. Modul, Access Modifier, Sub, Function, Array, & Koleksi Data

| Konsep | Sintaks Dasar | Fungsi |
| :--- | :--- | :--- |
| `Module` | `Public Module ModPerhitungan ... End Module` | Wadah terpisah untuk variabel, `Sub`, dan `Function` bersama. |
| `Public` vs `Private` | `Public x As Integer` / `Private y As Integer` | `Public` bisa diakses antar Form/Module; `Private` hanya internal. |
| `Sub` vs `Function` | `Public Sub Sapa()` vs `Public Function Luas(...) As Integer` | `Sub` tanpa nilai balik; `Function` wajib mengembalikan nilai via `Return`. |
| `Array` 1D / 2D / 3D | `Dim a() As Integer`, `Dim m(,) As Integer`, `m.GetUpperBound(0)` | Ukuran tetap, indeks mulai `0`, seluruh baris Array 2D harus seragam. |
| `List(Of T)` | `Dim lst As New List(Of String)` | Koleksi dinamis (`.Add`, `.Remove`, `.RemoveAt`, `.Contains`, `.Count`). |
| `Dictionary(Of K, V)` | `Dim d As New Dictionary(Of String, String)` | Pasangan Key-Value unik; cek aman dengan `.ContainsKey(key)`. |
| `HashSet(Of T)` | `Dim s As New HashSet(Of Integer)` | Kumpulan nilai unik; `.Add(val)` otomatis menolak duplikat (`False`). |

### 6. Konversi Data, Format Angka, & Tanggal (`TryParse`, `CultureInfo`, `Date`)

| Perintah | Kegunaan |
| :--- | :--- |
| `Integer.TryParse(teks, hasil)` | Menguji & mengubah teks ke `Integer` dengan aman (`True`/`False` tanpa crash). |
| `Decimal.TryParse(teksTitik, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, hasil)` | Membaca angka desimal titik maupun koma secara konsisten di semua region Windows. |
| `Integer.Parse(teks)` / `CInt(teks)` | Konversi langsung (melempar `FormatException`/`InvalidCastException` jika salah). |
| `Convert.ToInt32(objek)` | Mengubah nilai bertipe `Object` (misal kolom `DataRowView`) menjadi `Integer`. |
| `angka.ToString("N2")` / `"0.00"` | Memformat angka menjadi 2 digit desimal di belakang koma. |
| `Date.Today.Year` / `Date.Today.AddDays(n)` | Mengambil tahun sistem saat ini atau menghitung tanggal `n` hari ke depan. |

### 7. Validasi Ketikan (`KeyPress`) & `ErrorProvider`

```vbnet
' Blokir karakter selain angka dan tombol kontrol (Backspace)
Private Sub txtAngka_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNim.KeyPress
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
        e.Handled = True
    End If
End Sub
```
- `errInput.Clear()`: Hapus semua ikon merah di awal fungsi `ValidasiInput()`.
- `errInput.SetError(kontrol, "Pesan error")`: Tempel ikon merah dan pesan tooltip di sebelah `kontrol`.

### 8. Penanganan Eksepsi (`Try...Catch...Finally`) & File I/O

```vbnet
Dim penulis As StreamWriter = Nothing
Try
    penulis = New StreamWriter(lokasiEkspor)
    penulis.WriteLine("data;csv")
Catch ex As IOException
    MessageBox.Show("File sedang dipakai program lain: " & ex.Message)
Finally
    If penulis IsNot Nothing Then penulis.Close()
End Try
```
- Urutkan `Catch` dari exception paling spesifik (`FormatException`, `OverflowException`, `DivideByZeroException`, `IOException`) lalu `Catch ex As Exception` paling bawah.
- Blok `Finally` selalu dijalankan ada error maupun tidak.

### 9. Database PostgreSQL / Supabase dengan ADO.NET `Npgsql`

| Kelas Npgsql | Fungsi Utama |
| :--- | :--- |
| `NpgsqlConnection(connString)` | Membuka jalur koneksi ke server PostgreSQL / Supabase. |
| `NpgsqlCommand(sql, conn)` | Menjalankan kueri SQL; isi parameter lewat `cmd.Parameters.AddWithValue("@nama", nilai)` untuk mencegah SQL Injection. |
| `NpgsqlDataAdapter(cmd)` | Mengisi hasil kueri ke `DataTable` melalui `adapter.Fill(dt)`. |
| `cmd.ExecuteNonQuery()` | Mengeksekusi perintah `INSERT`, `UPDATE`, atau `DELETE`. |

### 10. `DataGridView`, `BindingSource`, & `DataTable`

- **Mode Unbound (Array):** Buat kolom di Designer, isi via `dgv.Rows.Clear()`, `Dim r As Integer = dgv.Rows.Add()`, lalu `dgv.Rows(r).Cells(c).Value = ...`.
- **Mode Bound (`List(Of T)` / `DataTable`):**
  - `bs.DataSource = sumberData` lalu `dgv.DataSource = bs`.
  - Tambah item pada `List(Of T)` lewat `bs.Add(objekBaru)` (bukan `list.Add`) agar grid ikut segar.
  - Pengaturan kolom otomatis (`dgv.Columns("Nama").FillWeight = 200`, `.DefaultCellStyle.Format = "N2"`) wajib dilakukan **sesudah** `DataSource` diisi.
  - Filter pada `DataTable`: `bs.Filter = "Nama LIKE '%" & AmankanTeksFilter(kata) & "%'"` dan `bs.RemoveFilter()`.

### 11. Windows API (P/Invoke)

- Deklarasikan fungsi DLL Windows (`kernel32.dll`, `user32.dll`) di module khusus memakai `Declare` atau `<DllImport("...", ExactSpelling:=True, SetLastError:=True)>`.
- Gunakan tipe ketat saat `Option Strict On` (`IntPtr`, `UInteger`, `ULong`).
- Tangkap pesan sistem seperti `WM_HOTKEY` (`&H312`) di dalam `Protected Overrides Sub WndProc(ByRef m As Message)`.
- Daftarkan hotkey di `HandleCreated` (`RegisterHotKey`) dan wajib lepaskan di `HandleDestroyed` (`UnregisterHotKey`).

### 12. `MenuStrip`, `ContextMenuStrip`, & MDI

- Set `IsMdiContainer = True` pada Form induk dan `baru.MdiParent = Me` sebelum `baru.Show()`.
- Cegah jendela anak kembar dengan menelusuri `Me.MdiChildren` (`TypeOf anak Is FrmTujuan`).
- Atur posisi jendela anak lewat `Me.LayoutMdi(MdiLayout.Cascade / TileHorizontal / TileVertical)`.
- Tahan penutupan Form jika user membatalkan lewat `e.Cancel = True` di event `FormClosing`.

### 13. Packaging Proyek Akhir WinForms, Supabase Auth/Data API, & RLS

- Aplikasi terdistribusi mengakses PostgreSQL melalui **Supabase Auth (`/auth/v1/token`) & Data API (`/rest/v1/...`)** via `HttpClient`, bukan koneksi langsung dengan password database.
- Aktifkan **Row Level Security (RLS)** (`auth.uid() = pemilik_id`) dan hak akses minimum (`grant select`, `grant update (kolom)`) untuk peran `authenticated`.
- Atur metadata rilis di `.vbproj` (`AssemblyName`, `Product`, `Version`, `FileVersion`, `ApplicationIcon`), lalu publish dengan konfigurasi `Release`, `Self-contained`, `win-x64`.
