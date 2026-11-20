# Pertemuan 8: DataGridView, Array, List(Of T), DataTable, & BindingSource

## 1. Gambaran Umum & Analogi

Pada Pertemuan 8 di proyek [Praktikum 8](./DataMahasiswa.slnx), kita menggantikan tampilan `ListBox` yang menumpuk teks satu baris dengan kontrol tabel profesional bernama **`DataGridView`**.

Bayangkan perbedaan antara mencatat daftar nilai di **kertas catatan biasa (`ListBox`)** vs **lembar kerja Excel (`DataGridView`)**:
- Di `ListBox`, 30 data mahasiswa dengan 5 informasi per orang sulit sejajar, tidak bisa diurutkan per kolom, dan angka IPK bercampur jadi teks.
- Di `DataGridView`, setiap mahasiswa mendapat 1 baris dan setiap atribut (`NIM`, `Nama`, `Jurusan`, `Angkatan`, `IPK`) menempati kolom rapi yang bisa diurutkan dan diformat.

Agar `DataGridView` tidak berhubungan langsung secara kaku dengan data mentah, kita memakai **`BindingSource`** sebagai **"petugas meja perpustakaan"**:
- Rak buku (**Sumber Data**: `List(Of Mahasiswa)` atau `DataTable`) menyimpan seluruh data utuh di memori.
- Petugas perpustakaan (**`BindingSource`**) menentukan baris mana yang boleh dilihat (**`Filter`**), urutannya (**`Sort`**), serta mencatat buku baru (**`Add`**).
- Pengunjung (**`DataGridView`**) cukup menampilkan apa yang disodorkan oleh petugas tersebut.

---

## 2. Ringkasan Konsep Materi

### Perbandingan 3 Sumber Data untuk `DataGridView`

| Aspek | Array 2D (`FrmDariArray`) | `List(Of T)` + Class (`FrmDariList` & `FrmCariList`) | `DataTable` (`FrmDataTable`) |
| :--- | :--- | :--- | :--- |
| **Ukuran** | Tetap (*Fixed*) | Dinamis | Dinamis |
| **Tipe Data Kolom** | Seragam satu tipe (`String`) | Sesuai tipe `Public Property` pada Class | Sesuai tipe kolom (`Columns.Add`) |
| **Cara Mengisi Grid** | Manual (`Rows.Add` + `Cells.Value`) | Otomatis via `DataSource` | Otomatis via `DataSource` |
| **Pembuatan Kolom** | Kolom dibuat manual di Designer | Otomatis dari properti Class `Mahasiswa` | Otomatis dari kolom `DataTable` |
| **Urut Klik Header** | Ya (sebagai teks; `"10"` sebelum `"9"`) | Tidak (default `List`) | **Ya** (sesuai tipe data angka/teks) |
| **Dukung `BindingSource.Filter`** | Tidak | Tidak (diabaikan tanpa error; cari pakai loop `For Each`) | **Ya** (langsung di memori dengan ekspresi `Filter`) |
| **Cocok Untuk** | Data statis ukuran kecil | Data objek yang banyak diolah lewat kode OOP | Tabel di memori yang butuh `Sort` & `Filter` cepat |

---

## 3. Daftar Komponen Antarmuka (UI Controls)

Proyek `DataMahasiswa` terdiri dari 5 Form:
1. **[FrmUtama](./FrmUtama.Designer.vb)**: `lblJudul`, `btnDariArray`, `btnDariList`, `btnDataTable`, `btnCariList`.
2. **[FrmDariArray](./FrmDariArray.Designer.vb)** (Mode *Unbound*): `dgvMahasiswa` (memiliki 5 kolom manual: `colNim`, `colNama`, `colJurusan`, `colAngkatan`, `colIpk`), `btnTampilkan`, `btnKosongkan`, `lblJumlah`.
3. **[FrmDariList](./FrmDariList.Designer.vb)** (Mode *Bound* + Input): `txtNim`, `txtNama`, `cboJurusan`, `txtAngkatan`, `txtIpk`, `btnTambah`, `dgvMahasiswa`, `lblJumlah`, serta di *Component Tray*: `bsMahasiswa` (`BindingSource`) dan `errInput` (`ErrorProvider`).
4. **[FrmDataTable](./FrmDataTable.Designer.vb)** (Mode *Bound* + Filter): `txtCari`, `btnRapikan`, `dgvMahasiswa`, `lblJumlah`, serta `bsMahasiswa` di *Component Tray*.
5. **[FrmCariList](./FrmCariList.Designer.vb)** (Mode *Bound* + Loop Cari): `txtCari`, `dgvMahasiswa`, `lblJumlah`, serta `bsMahasiswa` di *Component Tray*.

*Pengaturan penting `DataGridView` di Designer pada seluruh Form:* `ReadOnly = True`, `AllowUserToAddRows = False` (mencegah baris kosong `*` ikut terhitung), `AllowUserToDeleteRows = False`, `RowHeadersVisible = False`, `SelectionMode = FullRowSelect`.

---

## 4. Bedah Kode Program: Kodenya Ini Buat Apa?

### A. Cetakan Objek [Mahasiswa.vb](./Mahasiswa.vb) & Data Contoh [ModDataContoh.vb](./ModDataContoh.vb)

```vbnet
Public Class Mahasiswa
    Public Property Nim As String
    Public Property Nama As String
    Public Property Jurusan As String
    Public Property Angkatan As Integer
    Public Property Ipk As Decimal

    Public Sub New(nim As String, nama As String, jurusan As String, angkatan As Integer, ipk As Decimal)
        Me.Nim = nim
        Me.Nama = nama
        Me.Jurusan = jurusan
        Me.Angkatan = angkatan
        Me.Ipk = ipk
    End Sub
End Class
```

**Penjelasan:** Setiap `New Mahasiswa(...)` membuat satu objek baris. `DataGridView` membaca setiap `Public Property` (`Nim`, `Nama`, `Jurusan`, `Angkatan`, `Ipk`) secara otomatis untuk dijadikan kolom tabel.

### B. Praktik 1: [FrmDariArray.vb](./FrmDariArray.vb) — Mengisi Grid Manual (*Unbound*)

```vbnet
    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        dgvMahasiswa.Rows.Clear()
        For i As Integer = 0 To dataMahasiswa.GetUpperBound(0)          ' baris
            Dim indeksBaris As Integer = dgvMahasiswa.Rows.Add()
            For j As Integer = 0 To dataMahasiswa.GetUpperBound(1)      ' kolom
                dgvMahasiswa.Rows(indeksBaris).Cells(j).Value = dataMahasiswa(i, j)
            Next
        Next
        lblJumlah.Text = "Jumlah data: " & dgvMahasiswa.Rows.Count.ToString()
    End Sub
```

**Penjelasan:**
- `dgvMahasiswa.Rows.Clear()` wajib dipanggil di awal agar klik tombol kedua kalinya tidak menggandakan baris yang sudah ada.
- `dgvMahasiswa.Rows.Add()` membuat satu baris kosong baru dan mengembalikan nomor indeks baris tersebut (`indeksBaris`).
- Nested loop `i` (baris) dan `j` (kolom) menyalin setiap sel dari array 2D `dataMahasiswa(i, j)` ke `Cells(j).Value`.

### C. Praktik 2: [FrmDariList.vb](./FrmDariList.vb) — Menambah Data Lewat `BindingSource`

```vbnet
        bsMahasiswa.DataSource = daftarMahasiswa        ' List -> BindingSource
        dgvMahasiswa.DataSource = bsMahasiswa           ' BindingSource -> DataGridView
```
Saat menambah data baru pada `btnTambah_Click`:
```vbnet
        bsMahasiswa.Add(baru)
```

**Penjelasan:** Mengapa memanggil `bsMahasiswa.Add(baru)` bukan `daftarMahasiswa.Add(baru)`? Karena `List(Of T)` biasa tidak memberi tahu `DataGridView` saat isinya bertambah. Menambah lewat `bsMahasiswa.Add(baru)` memasukkan objek ke `daftarMahasiswa` **sekaligus** menyegarkan tampilan tabel seketika.

### D. Praktik 3: [FrmDataTable.vb](./FrmDataTable.vb) + [ModPencarian.vb](./ModPencarian.vb) — Merapikan Kolom & Filter

```vbnet
    Private Sub AturKolom()
        dgvMahasiswa.Columns("Nim").HeaderText = "NIM"
        dgvMahasiswa.Columns("Ipk").HeaderText = "IPK"
        dgvMahasiswa.Columns("Ipk").DefaultCellStyle.Format = "N2"
        dgvMahasiswa.Columns("Ipk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMahasiswa.Columns("Angkatan").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvMahasiswa.Columns("Nama").FillWeight = 200
        dgvMahasiswa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub
```
Dan pencarian di `txtCari_TextChanged`:
```vbnet
    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        If tabelMahasiswa Is Nothing Then Return
        Dim kata As String = AmankanTeksFilter(txtCari.Text.Trim())
        If kata = "" Then
            bsMahasiswa.RemoveFilter()
        Else
            bsMahasiswa.Filter = "Nama LIKE '%" & kata & "%' OR Nim LIKE '%" & kata & "%'"
        End If
        PerbaruiJumlah()
    End Sub
```

**Penjelasan:**
- `AturKolom()` dijalankan **setelah** `DataSource` diisi, karena kolom `"Nim"`, `"Ipk"`, `"Nama"`, dll. baru tercipta saat binding terjadi. Format `"N2"` membuat angka `3.8` selalu tampil 2 desimal (`3.80` / `3,80`).
- `AmankanTeksFilter` di `ModPencarian.vb` menggandakan kutip tunggal (`'` menjadi `''`) serta membungkus karakter liar `[ ] * %` ke dalam `[...]`. Tanpa pengaman ini, mencari nama seperti `"Ma'ruf"` akan langsung membuat ekspresi `Filter` crash!

### E. Praktik 4: [FrmCariList.vb](./FrmCariList.vb) — Pencarian `List(Of Mahasiswa)` dengan Perulangan

```vbnet
    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        If daftarMahasiswa Is Nothing Then Return
        Dim kata As String = txtCari.Text.Trim().ToLower()
        Dim hasil As New List(Of Mahasiswa)
        For Each mhs As Mahasiswa In daftarMahasiswa
            If mhs.Nama.ToLower().Contains(kata) OrElse mhs.Nim.Contains(kata) Then
                hasil.Add(mhs)
            End If
        Next
        bsMahasiswa.DataSource = hasil
        lblJumlah.Text = "Menampilkan " & hasil.Count.ToString() & " dari " &
                         daftarMahasiswa.Count.ToString() & " data"
    End Sub
```

**Penjelasan:** Karena `BindingSource.Filter` hanya bekerja pada `DataTable` (dan diabaikan pada `List(Of T)`), kita menyaring data dengan membuat `List` sementara (`hasil`), memasukkan objek yang cocok memakai `For Each`, lalu memasang `hasil` ke `bsMahasiswa.DataSource`. Data asli `daftarMahasiswa` tetap utuh!

---

## 5. Apa yang Dihasilkan Program

1. **Menu Utama (`FrmUtama`):** Menampilkan 4 tombol praktikum Pertemuan 8 yang membuka masing-masing form secara modal (`ShowDialog`).
2. **Praktik 1 (`FrmDariArray`):** Tabel awalnya kosong (`Jumlah data: 0`). Klik `Tampilkan` memuat 8 mahasiswa dari array 2D; klik `Kosongkan` mengosongkan tabel kembali.
3. **Praktik 2 (`FrmDariList`):** Langsung menampilkan 4 data awal. Mengisi form kiri lalu klik `Tambah ke List` memvalidasi input (menggunakan `ModValidasi.vb` dari Pertemuan 7) dan langsung menambah baris baru ke `dgvMahasiswa`.
4. **Praktik 3 (`FrmDataTable`):** Menampilkan 8 data dari `DataTable`. Klik `Rapikan Kolom` mengubah header `Nim` -> `NIM`, `Ipk` -> `IPK`, memformat IPK 2 desimal rata kanan, dan memperlebar kolom `Nama`. Mengetik di `txtCari` langsung menyaring baris secara *real-time* (aman untuk tanda petik `'`).
5. **Praktik 4 (`FrmCariList`):** Menampilkan 8 data dari `ModDataContoh.BuatDaftarMahasiswa()`. Mengetik potongan nama atau NIM langsung memperbarui `dgvMahasiswa` beserta label jumlah tampil tanpa merusak daftar asli.

---

## 6. Eksperimen: Jika Variabel atau Nilainya Diubah-Ubah Jadi Apa?

| Bagian / Variabel yang Diubah | Nilai Awal | Diubah Menjadi | Dampak & Hasil yang Terjadi |
| :--- | :--- | :--- | :--- |
| Mencampur `DataSource` dan `Rows.Add()` | Mengisi grid lewat `bsMahasiswa.DataSource` | Menambahkan baris `dgvMahasiswa.Rows.Add()` di form yang memakai `DataSource` | **Runtime Error (`InvalidOperationException`)!** Grid yang terikat `DataSource` tidak boleh ditambah baris secara manual lewat `Rows.Add`. |
| Urutan pemanggilan `AturKolom()` di `FrmDataTable.vb` | Dipanggil **sesudah** `dgvMahasiswa.DataSource = bsMahasiswa` | Dipanggil **sebelum** `dgvMahasiswa.DataSource = bsMahasiswa` | **Runtime Error (`NullReferenceException`)!** Karena kolom `"Nim"` dan `"Ipk"` belum dibuat oleh `DataGridView`, sehingga `dgvMahasiswa.Columns("Nim")` bernilai `Nothing`. |
| Properti `AllowUserToAddRows` di Designer | `False` | `True` (default WinForms) | Di bagian paling bawah tabel muncul satu baris kosong bertanda bintang `*`, dan `dgvMahasiswa.Rows.Count` bertambah 1 dari jumlah data sebenarnya. |
| Method tambah data di `FrmDariList.vb` | `bsMahasiswa.Add(baru)` | `daftarMahasiswa.Add(baru)` (tanpa `ResetBindings`) | Data masuk ke memori `daftarMahasiswa`, namun **baris baru tidak muncul di layar `DataGridView`** sampai `bsMahasiswa.ResetBindings(False)` dipanggil. |
| Pembersihan karakter di `FrmDataTable.vb` | `AmankanTeksFilter(txtCari.Text.Trim())` | `txtCari.Text.Trim()` langsung tanpa `AmankanTeksFilter` | Saat pengguna mengetik `'` (misalnya mencari `Ma'ruf`) atau `[`, program langsung **crash (`SyntaxErrorException` / `EvaluateException`)**. |
| Sumber `DataSource` pada `List(Of String)` | `List(Of Mahasiswa)` (class dengan 5 Property) | `List(Of String)` | `DataGridView` tidak menampilkan teks isi stringnya, melainkan hanya menampilkan 1 kolom bernama **`Length`** (karena satu-satunya `Public Property` bawaan kelas `String` adalah `.Length`!). |
| Pencarian di `FrmCariList.vb` | `bsMahasiswa.DataSource = hasil` via loop | `bsMahasiswa.Filter = "Nama LIKE '%" & ..."` | Tidak terjadi error, tetapi **tabel tidak tersaring sama sekali** karena `List(Of T)` tidak mendukung fitur `BindingSource.Filter`. |
| `Nama.FillWeight` di `AturKolom()` | `200` (sementara kolom lain default `100`) | `50` | Kolom `Nama` menyempit menjadi separuh lebar kolom lainnya sehingga nama mahasiswa terpotong `...`. |

---

## 7. Kesalahan Umum & Tips Praktis

1. **Selalu atur `ReadOnly = True` dan `AllowUserToAddRows = False` di Designer** untuk tabel yang bersifat tampilan laporan agar pengguna tidak bingung oleh baris bintang kosong di bawah tabel.
2. **Jangan pernah mencampur mode `Rows.Add` dengan `DataSource`:** Pilih satu cara sejak awal.
3. **Untuk pencarian berbasis `DataTable`, selalu gunakan `AmankanTeksFilter`** agar karakter spesial `'` atau `%` dari input pengguna tidak memecahkan sintaks filter.

---

Navigasi: [Pertemuan 7](../Praktikum%207/readme.md) | [Kembali ke README Utama](../readme.md) | [Lanjut ke Pertemuan 11](../Praktikum%2011/readme.md)
