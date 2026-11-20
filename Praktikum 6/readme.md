# Pertemuan 6: Koneksi Database PostgreSQL (Supabase) & Npgsql

## 1. Gambaran Umum & Analogi

Pada Pertemuan 6 di proyek [Praktikum 6](./Pertemuan%206.slnx), aplikasi kita mulai terhubung ke database sungguhan di internet (cloud) sehingga data tidak lagi hilang ketika program ditutup.

Bayangkan aplikasi kita ingin mengambil dan menyimpan data ke **gudang arsip di kota lain (Supabase)**:
- **PostgreSQL** adalah **sistem lemari arsip & aturan SQL** yang menyimpan tabel `mahasiswa` secara rapi dan permanen.
- **Supabase** adalah **gedung pengelola gudang di cloud** yang sudah menyiapkan mesin PostgreSQL, alamat host, dan dashboard web sehingga kita tidak perlu menginstal server database di laptop.
- **Npgsql** (diinstal via NuGet) adalah **kurir resmi .NET** yang mengerti bahasa VB.NET sekaligus bahasa PostgreSQL.
- **`appsettings.json`** adalah **kartu alamat & kunci akses** (Connection String) agar program tahu ke server mana ia harus terhubung tanpa menanam password langsung di file `.vb`.

---

## 2. Ringkasan Konsep Materi

### "4 Sekawan" Objek ADO.NET di Npgsql

| Komponen Npgsql | Analogi Kurir | Tugas Utama di Kode |
| :--- | :--- | :--- |
| **`NpgsqlConnection`** | Jalan tol & gerbang koneksi | Membuka dan mengelola jalur koneksi fisik ke server PostgreSQL/Supabase menggunakan Connection String. |
| **`NpgsqlCommand`** | Surat perintah resmi | Membawa perintah SQL (`SELECT`, `INSERT`, `UPDATE`, `DELETE`) beserta parameter `@` agar aman dari SQL Injection. |
| **`NpgsqlDataAdapter`** | Keranjang pengangkut tabel | Mengambil hasil kueri `SELECT` dari database dan menuangkannya ke objek `DataTable` di memori lewat `.Fill(dt)`. |
| **`NpgsqlCommandBuilder`** | Pembuat surat otomatis | Membuatkan kueri `INSERT`, `UPDATE`, dan `DELETE` secara otomatis untuk `NpgsqlDataAdapter` berdasarkan perintah `SELECT`. |

### Paket NuGet yang Digunakan di [Pertemuan 6.vbproj](./Pertemuan%206.vbproj)
- `Npgsql` (driver PostgreSQL untuk .NET 10)
- `Microsoft.Extensions.Configuration.Json` (untuk membaca Connection String dari `appsettings.json`)

---

## 3. Daftar Komponen Antarmuka (UI Controls)

Berikut komponen yang ada di dalam [Form1.Designer.vb](./Form1.Designer.vb):

| Jenis Kontrol | Properti `(Name)` | Properti `Text` / Penting | Fungsi pada Aplikasi |
| :--- | :--- | :--- | :--- |
| `Form` | `Form1` | `ClientSize: 800, 450` | Jendela utama CRUD dasar Supabase |
| `DataGridView` | `dgvMahasiswa` | `Size: 400, 280` | Menampilkan baris data dari tabel `mahasiswa` |
| `Button` | `btnTampilkan` | `"Tampilkan"` | Memanggil `ModQuery.TampilkanData()` untuk mengisi `dgvMahasiswa` |
| `Label` | `Label3`, `Label2`, `Label1` | `"Nama"`, `"NIM"`, `"Jurusan"` | Keterangan masing-masing kotak input |
| `TextBox` | `txtNama` | `Location: 503, 100` | Input nama mahasiswa (dibatasi huruf saja via `KeyPress`) |
| `TextBox` | `txtNIM` | `Location: 503, 153` | Input NIM mahasiswa (dibatasi angka saja via `KeyPress`) |
| `TextBox` | `txtJurusan` | `Location: 503, 211` | Input nama jurusan |
| `Button` | `btnTambah` | `"Tambah"` | Menyimpan data baru ke Supabase lalu me-refresh `dgvMahasiswa` |

---

## 4. Bedah Kode Program: Kodenya Ini Buat Apa?

Proyek ini membagi tugas menjadi 4 file yang rapi (arsitektur berlapis):

### A. [ModDatabase.vb](./ModDatabase.vb) — Membaca Konfigurasi & Cek Koneksi

```vbnet
Imports Microsoft.Extensions.Configuration
Imports Npgsql

Module ModDatabase
    Public Function GetConnectionString() As String
        Dim config As IConfiguration =
            New ConfigurationBuilder() _
            .SetBasePath(AppContext.BaseDirectory) _
            .AddJsonFile("Appsettings.json", optional:=False, reloadOnChange:=True) _
            .Build()

        Return config.GetConnectionString("DefaultConnection")
    End Function
    Public Sub DatabaseKoneksi()
        Try
            Using conn As New NpgsqlConnection(GetConnectionString)
                conn.Open()

                MessageBox.Show("Koneksi database berhasil")
            End Using
        Catch ex As Exception
            MessageBox.Show("Koneksi database gagal" & vbCrLf & ex.Message & "database")
        End Try
    End Sub
End Module
```

**Penjelasan:**
- `GetConnectionString()` membaca file `appsettings.json` yang berada di folder output aplikasi (`AppContext.BaseDirectory`, yaitu folder `bin\Debug\net10.0-windows\`) lalu mengambil kunci `"DefaultConnection"`.
- Format `appsettings.json` yang digunakan proyek ini (ganti placeholder dengan kredensial proyek Supabase milikmu sendiri):
  ```json
  {
    "ConnectionStrings": {
      "DefaultConnection": "Host=aws-0-ap-southeast-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.PROJECT_ID;Password=PASSWORD_SUPABASE_ANDA;SSL Mode=Require;Trust Server Certificate=true"
    }
  }
  ```
- Blok `Using conn As New NpgsqlConnection(...)`: Memastikan jalur koneksi otomatis ditutup dan dibersihkan dari memori begitu blok `End Using` selesai, bahkan jika terjadi error di tengah jalan.

### B. [ModFunction.vb](./ModFunction.vb) — Mesin Pengambil (`SELECT`) & Penulis (`INSERT`/`UPDATE`/`DELETE`)

```vbnet
Imports Npgsql
Imports System.Data
Module ModFunction

    Public Function AmbilData(query As String) As DataTable
        Dim dt As New DataTable

        Try
            Using conn As New NpgsqlConnection(ModDatabase.GetConnectionString())
                conn.Open()
                Using cmd As New NpgsqlCommand(query, conn)
                    Using adapter As New NpgsqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal mengambil data" & vbCrLf & ex.Message, " database")
        End Try

        Return dt
    End Function
    Public Function EksekusiData(query As String, parameters As Dictionary(Of String, Object)) As Boolean
        Try
            Using conn As New NpgsqlConnection(ModDatabase.GetConnectionString())
                conn.Open()

                Using cmd As New NpgsqlCommand(query, conn)
                    For Each parameter In parameters
                        cmd.Parameters.AddWithValue(parameter.Key, parameter.Value)
                    Next
                    cmd.ExecuteNonQuery()
                    Return True
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(
            "Gagal mengeksekusi data:" & vbCrLf & ex.Message,
            "Error Database"
        )
            Return False
        End Try
    End Function

End Module
```

**Penjelasan:**
- `AmbilData(query)`: Membuka koneksi, menjalankan kueri SQL `SELECT` lewat `NpgsqlCommand`, mengisi tabel sementara di memori (`dt As DataTable`) dengan `adapter.Fill(dt)`, lalu mengembalikan `dt` untuk dipasang ke `DataGridView`.
- `EksekusiData(query, parameters)`: Menerima perintah SQL (seperti `INSERT`) dan daftar nilai `Dictionary(Of String, Object)` untuk diisi ke parameter `@` lewat `cmd.Parameters.AddWithValue(parameter.Key, parameter.Value)`. Penggunaan parameter ini mencegah celah keamanan **SQL Injection** dan error akibat tanda kutip pada nama orang.
- `cmd.ExecuteNonQuery()`: Menjalankan perintah yang tidak mengembalikan tabel (`INSERT`, `UPDATE`, `DELETE`).

### C. [ModQuery.vb](./ModQuery.vb) — Daftar Kueri Spesifik Tabel `mahasiswa`

```vbnet
Imports System.Data
Module ModQuery
    Public Function TambahData(
        nim As String,
        nama As String,
        jurusan As String
    ) As Boolean
        Dim query As String =
            "INSERT INTO mahasiswa (nim, nama, jurusan) " &
            "VALUES (@nim, @nama, @jurusan)"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@nim", nim},
            {"@nama", nama},
            {"@jurusan", jurusan}
        }
        Return ModFunction.EksekusiData(query, parameters)
    End Function

    Public Function TampilkanData() As DataTable
        Return ModFunction.AmbilData(
            "SELECT * FROM mahasiswa ORDER BY id ASC"
        )
    End Function

End Module
```

**Penjelasan:**
- Memisahkan teks SQL dari `Form1.vb` sehingga `Form1` cukup memanggil `ModQuery.TampilkanData()` atau `ModQuery.TambahData(nim, nama, jurusan)` tanpa harus tahu struktur kueri SQL-nya.

### D. [Form1.vb](./Form1.vb) — Interaksi Tombol & Penyaringan Ketikan

```vbnet
Public Class Form1
    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        dgvMahasiswa.AutoGenerateColumns = True
        dgvMahasiswa.DataSource = ModQuery.TampilkanData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If ModQuery.TambahData(
            txtNIM.Text,
            txtNama.Text,
            txtJurusan.Text
        ) Then

            dgvMahasiswa.AutoGenerateColumns = True
            dgvMahasiswa.DataSource = ModQuery.TampilkanData()
            MessageBox.Show("Data berhasil disimpan")
        End If

        txtJurusan.Clear()
        txtNama.Clear()
        txtNIM.Clear()
    End Sub

    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNIM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNIM.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class
```

---

## 5. Apa yang Dihasilkan Program

1. Saat tombol **Tampilkan** (`btnTampilkan`) diklik:
   - Aplikasi menghubungi server Supabase menggunakan `appsettings.json`.
   - Jika koneksi sukses dan tabel `mahasiswa` tersedia, seluruh baris data langsung muncul otomatis di `dgvMahasiswa` berurutan dari `id` terkecil (`ORDER BY id ASC`).
   - Jika tidak ada internet atau password salah, `Catch ex As Exception` di `ModFunction` menampilkan `MessageBox` `"Gagal mengambil data"` dan program tidak crash.
2. Saat mengetik di kotak **Nama** (`txtNama`):
   - Hanya huruf alfabet dan tombol kontrol (`Backspace`) yang diterima. Angka otomatis ditolak.
3. Saat mengetik di kotak **NIM** (`txtNIM`):
   - Hanya angka `0`–`9` dan tombol kontrol (`Backspace`) yang diterima.
4. Saat tombol **Tambah** (`btnTambah`) diklik:
   - Data dikirim ke Supabase lewat `INSERT INTO mahasiswa ...`.
   - Jika berhasil (`True`), grid langsung menyegarkan isinya dengan memanggil ulang `ModQuery.TampilkanData()`, menampilkan pesan `"Data berhasil disimpan"`, dan mengosongkan ketiga kotak input.

---

## 6. Eksperimen: Jika Variabel atau Nilainya Diubah-Ubah Jadi Apa?

| Bagian / Variabel yang Diubah | Nilai Awal | Diubah Menjadi | Dampak & Hasil yang Terjadi |
| :--- | :--- | :--- | :--- |
| `<CopyToOutputDirectory>` pada `appsettings.json` di `.vbproj` | `PreserveNewest` | `Never` (atau lupa disalin) | Saat dijalankan, `GetConnectionString()` melempar **`FileNotFoundException`** karena `appsettings.json` tidak ada di sebelah file `.exe`/`.dll` di folder `bin\`. |
| Pengisian `txtNama_KeyPress` | `Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar)` | Ditambahkan `AndAlso Not Char.IsWhiteSpace(e.KeyChar)` | Pengguna kini bisa mengetik **spasi** pada nama lengkap (misal `"Michael Deryl"`). Pada kode awal, spasi ikut terblokir karena `IsLetter(" "c)` bernilai `False`! |
| Urutan pengurutan di `TampilkanData()` | `ORDER BY id ASC` | `ORDER BY id DESC` | Data mahasiswa yang paling baru ditambahkan (`id` terbesar) tampil di baris paling atas tabel. |
| Nilai `Password` di `appsettings.json` | Password proyek Supabase aktif | Salah ketik 1 huruf | Tidak terjadi crash mendadak; `Catch ex As Exception` di `AmbilData` / `EksekusiData` menangkap error autentikasi (`28P01`) dan menampilkannya di `MessageBox`. |
| Pembersihan kotak input di `btnTambah` | `txtJurusan.Clear()`, `txtNama.Clear()`, `txtNIM.Clear()` berada di luar `If` | Dipindahkan ke **dalam** blok `If ModQuery.TambahData(...) Then` | Jika penyimpanan ke database gagal (misal internet putus), teks yang sudah capek-capek diketik pengguna tidak langsung terhapus sehingga bisa dicoba kirim ulang. |
| Parameter `@nama` di `ModQuery.TambahData` | Menggunakan `@nama` dan `cmd.Parameters.AddWithValue` | Menyambung string SQL langsung (`"... '" & nama & "' ..."`) | Jika nama mengandung tanda petik tunggal seperti `"Ma'ruf"`, perintah SQL langsung **rusak/error** dan rentan terhadap serangan **SQL Injection**. |
| `dgvMahasiswa.AutoGenerateColumns` | `True` | `False` (padahal tidak ada kolom manual di Designer) | Meskipun `DataTable` dari Supabase terisi data, `dgvMahasiswa` tampak **kosong tanpa kolom sama sekali** karena kolom tidak dibuat otomatis. |

---

## 7. Kesalahan Umum & Tips Praktis

1. **Perhatikan `txtNama_KeyPress` pada kode latihan awal:** Karena hanya mengecek `IsLetter`, tombol spasi ikut ditolak saat mengetik nama dua kata. Tambahkan `OrElse Char.IsWhiteSpace(e.KeyChar)` jika ingin menerima nama lengkap berspasi.
2. **Nama file sensitif pada beberapa konfigurasi (`Appsettings.json` vs `appsettings.json`):** Di Windows tidak masalah, namun biasakan menulis nama file konsisten huruf kecil/besar sesuai file aslinya.
3. **Koneksi Supabase menggunakan Pooler Port 5432 / 6543 dan `SSL Mode=Require`:** Jangan menghapus parameter SSL pada Connection String Supabase agar koneksi terenkripsi diterima oleh server cloud.

---

Navigasi: [Pertemuan 5](../Praktikum%205/readme.md) | [Kembali ke README Utama](../readme.md) | [Lanjut ke Pertemuan 7](../Praktikum%207/readme.md)
