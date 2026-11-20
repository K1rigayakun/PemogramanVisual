# Pertemuan 5: Modul, Prosedur, Fungsi, Array, & Koleksi Data

## 1. Gambaran Umum & Analogi

Pada Pertemuan 5 di proyek [Praktikum 5](./Praktikum5.slnx), kita belajar merapikan arsitektur kode agar tidak menumpuk di dalam Form serta mengelola banyak data sekaligus secara terstruktur.

Bayangkan sebuah **restoran**:
- **Form (`FrmKoleksi`)** adalah **ruang makan & kasir**: tempat tamu melihat menu, mengisi pesanan, dan melihat hasilnya.
- **Module (`ModPerhitungan`)** adalah **dapur pusat**: seluruh resep perhitungan (`Function HitungLuas`), aturan standar (`nilaiUmum`), dan daftar bahan (`Nilai1D`, `Matriks2D`) disimpan rapi di sini sehingga ruangan mana pun bisa memakainya tanpa menulis ulang resepnya.
- **Access Modifier (`Public` vs `Private`)** adalah **pintu dapur**: bagian `Public` boleh dilihat dan dipanggil dari Form kasir, sedangkan bagian `Private` (`rahasiaInternal`) terkunci hanya untuk urusan internal di dalam modul itu sendiri.
- **Koleksi Data (`Array`, `List`, `Dictionary`, `HashSet`)** adalah **rak penyimpanan** dengan sifat berbeda: ada rak paten bersekat tetap (`Array`), rak elastis yang bisa ditambah-kurangi (`List`), loker berlabel kunci unik (`Dictionary`), dan kotak saringan yang menolak barang kembar (`HashSet`).

---

## 2. Ringkasan Konsep Materi

### A. Module, Access Modifier, Sub, dan Function
- **Module:** Wadah terpisah dari Form untuk menyimpan variabel, `Sub`, dan `Function` bersama agar program rapi dan kode bisa dipakai ulang (*reusable*). Anggota `Public` di `Module` dapat langsung dipanggil di Form tanpa `New`.
- **`Public` vs `Private`:** `Public` dapat diakses dari Form/Module mana saja di proyek; `Private` hanya bisa diakses di dalam Module/Class tempat ia dibuat.
- **`Sub` (Procedure):** Menjalankan serangkaian perintah tanpa mengembalikan nilai (contoh: menampilkan `MessageBox`).
- **`Function`:** Menjalankan perhitungan lalu **mengembalikan sebuah nilai** ke pemanggil lewat kata kunci `Return`.

### B. Perbandingan Array dan 3 Koleksi Data Dinamis (.NET)

| Struktur Data | Ukuran | Cara Mengakses Elemen | Duplikasi Nilai | Contoh Penggunaan Ideal |
| :--- | :--- | :--- | :--- | :--- |
| **`Array`** (`Nilai1D`, `Matriks2D`, `Ruang3D`) | Tetap (*Fixed*) | Indeks angka (`0, 1, ...`) atau `(baris, kolom)` | Boleh | Data ukuran pasti atau tabel matriks |
| **`List(Of T)`** | Dinamis (`.Add`, `.RemoveAt`) | Indeks angka (`0, 1, ...`) | Boleh | Daftar item yang sering ditambah dan dihapus |
| **`Dictionary(Of TKey, TValue)`** | Dinamis | Kata kunci unik (*Key*, misal `"NIM"`) | Key harus unik; Value boleh sama | Pencarian cepat data berpasangan (Key -> Value) |
| **`HashSet(Of T)`** | Dinamis | Dicek langsung isinya (tanpa indeks) | **Ditolak otomatis** | Menyaring agar seluruh nilai yang masuk selalu unik |

---

## 3. Daftar Komponen Antarmuka (UI Controls)

Berikut komponen utama pada [FrmKoleksi.Designer.vb](./FrmKoleksi.Designer.vb) yang dibagi ke dalam 3 tab pada `tabMateri`:

| Tab / Grup | Jenis Kontrol | Properti `(Name)` | Fungsi pada Aplikasi |
| :--- | :--- | :--- | :--- |
| Tab 1 (`tpModulFungsi`) | `TextBox` | `txtNama`, `txtPanjang`, `txtLebar` | Input nama sapaan dan angka panjang/lebar |
| Tab 1 (`grpFungsi`) | `Button` | `btnSapa`, `btnHitung` | Memanggil `Sub TampilkanPesan` dan `Function HitungLuas` / `HitungKeliling` |
| Tab 1 (`grpFungsi`) | `Label` | `lblHasilHitung`, `lblInfoAkses` | Menampilkan hasil fungsi serta contoh pembacaan variabel `Public` dan `Private` |
| Tab 2 (`grpArray`) | `Button` | `btnArray1D`, `btnArray2D`, `btnArray3D`, `btnBersihkanArray` | Menampilkan elemen array 1D, 2D, dan 3D ke daftar |
| Tab 2 (`grpArray`) | `ListBox`, `Label` | `lstArray`, `lblRingkasanArray` | Menampilkan rincian indeks serta contoh akses elemen array |
| Tab 3 (`grpKoleksi`) | `TextBox`, `Button`, `ListBox` | `txtItemList`, `btnTambahList`, `btnHapusList`, `lstDinamis` | Uji operasi `.Add()` dan `.RemoveAt()` pada `List(Of String)` |
| Tab 3 (`grpKoleksi`) | `TextBox`, `Button`, `Label` | `txtKeyDict`, `btnCariDict`, `lblHasilDict` | Uji pencarian berbasis `ContainsKey()` pada `Dictionary(Of String, String)` |
| Tab 3 (`grpKoleksi`) | `TextBox`, `Button`, `ListBox`, `Label` | `txtAngkaSet`, `btnTambahSet`, `lstSet`, `lblStatusSet` | Uji penolakan data kembar pada `HashSet(Of Integer)` |

---

## 4. Bedah Kode Program: Kodenya Ini Buat Apa?

### A. Kode di [ModPerhitungan.vb](./ModPerhitungan.vb)

```vbnet
Option Strict On

Public Module ModPerhitungan
    Public Const BatasLuas As Integer = 20
    Public nilaiUmum As Integer = 80

    Private rahasiaInternal As Integer = 100

    Public Function AmbilRahasiaInternal() As Integer
        Return rahasiaInternal
    End Function

    Public Sub TampilkanPesan(nama As String)
        Dim namaRapi As String = nama.Trim()
        If namaRapi = "" Then namaRapi = "Mahasiswa"
        MessageBox.Show("Halo, " & namaRapi & "! Nilai umum dari modul = " & nilaiUmum.ToString(),
                        "Pesan dari Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Function HitungLuas(panjang As Integer, lebar As Integer) As Integer
        Return panjang * lebar
    End Function

    Public Function HitungKeliling(panjang As Integer, lebar As Integer) As Integer
        Return 2 * (panjang + lebar)
    End Function

    Public ReadOnly Nilai1D() As Integer = {10, 20, 30, 40, 50}

    Public ReadOnly Matriks2D(,) As Integer = {
        {10, 20, 30},
        {40, 50, 60},
        {70, 80, 90}
    }

    Public ReadOnly Ruang3D(,,) As Integer = {
        {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        },
        {
            {10, 11, 12},
            {13, 14, 15},
            {16, 17, 18}
        }
    }
End Module
```

**Penjelasan Bagian per Bagian:**
- `Public nilaiUmum As Integer = 80` vs `Private rahasiaInternal As Integer = 100`: `nilaiUmum` dapat dibaca langsung di `FrmKoleksi.vb`, sedangkan `rahasiaInternal` terkunci di dalam modul. Agar Form bisa mengetahui nilainya secara terkontrol, disediakan fungsi perantara `AmbilRahasiaInternal()`.
- `Public Sub TampilkanPesan(...)`: Tidak punya `As TipeData` dan tidak memakai `Return nilai`. Tugasnya hanya menampilkan kotak pesan.
- `Public Function HitungLuas(...) As Integer`: Punya tipe kembalian `As Integer` dan wajib mengembalikan angka lewat `Return panjang * lebar`.
- `Nilai1D()`, `Matriks2D(,)`, dan `Ruang3D(,,)`: Satu koma berarti Array 2 dimensi (baris, kolom), dua koma berarti Array 3 dimensi (blok, baris, kolom). Semuanya memakai pengindeksan mulai dari `0`.

### B. Potongan Kode Kunci di [FrmKoleksi.vb](./FrmKoleksi.vb)

```vbnet
    Private ReadOnly daftarAngka As New List(Of String) From {"10", "20", "30"}
    Private ReadOnly dataMhs As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
        {"NIM", "241712042"},
        {"Nama", "Michael Deryl"},
        {"Prodi", "D3 Teknik Informatika"}
    }
    Private ReadOnly himpunanUnik As New HashSet(Of Integer) From {10, 20}
```

- **`StringComparer.OrdinalIgnoreCase`** pada `Dictionary`: Membuat pencarian kunci tidak membedakan huruf besar/kecil (mengetik `"nim"` maupun `"NIM"` tetap cocok).
- **Nested loop pada Array 2D** (`btnArray2D_Click`):
  ```vbnet
  For baris As Integer = 0 To Matriks2D.GetUpperBound(0)
      Dim barisTeks As String = "Baris " & baris.ToString() & ": "
      For kolom As Integer = 0 To Matriks2D.GetUpperBound(1)
          barisTeks &= "[" & baris.ToString() & "," & kolom.ToString() & "]=" &
                       Matriks2D(baris, kolom).ToString() & "  "
      Next
      lstArray.Items.Add(barisTeks.TrimEnd())
  Next
  ```
  `GetUpperBound(0)` mengambil indeks baris terakhir (`2`), sedangkan `GetUpperBound(1)` mengambil indeks kolom terakhir (`2`).
- **Penolakan duplikat pada `HashSet`** (`btnTambahSet_Click`):
  Method `himpunanUnik.Add(angka)` mengembalikan nilai `Boolean`: `True` jika angka baru berhasil masuk, atau `False` jika angka tersebut sudah ada sebelumnya.

---

## 5. Apa yang Dihasilkan Program

1. **Tab Modul, Sub & Function:**
   - Saat Form dibuka, `lblInfoAkses` langsung menampilkan `nilaiUmum = 80` dan `rahasiaInternal = 100`.
   - Klik `btnSapa`: memunculkan `MessageBox` menyapa nama dari `txtNama`.
   - Klik `btnHitung` dengan `txtPanjang = 12` dan `txtLebar = 5`: `lblHasilHitung` menampilkan `HitungLuas(p, l) = 60` dan `HitungKeliling(p, l) = 34`.
2. **Tab Array (1D, 2D, 3D):**
   - Klik `btnArray1D`: menampilkan indeks `0` (`10`) sampai `4` (`50`), dan menyorot `Nilai1D(2) = 30`.
   - Klik `btnArray2D`: mencetak 3 baris matriks di `lstArray` dan menyorot `Matriks2D(1, 2) = 60`.
   - Klik `btnArray3D`: mencetak Blok 0 (`1..9`) dan Blok 1 (`10..18`), serta menyorot `Ruang3D(1, 2, 0) = 16`.
3. **Tab Koleksi Data Dinamis:**
   - `List`: menambah item ke `[3]`, atau menghapus baris yang sedang dipilih lewat `.RemoveAt(lstDinamis.SelectedIndex)`.
   - `Dictionary`: mengetik `"Prodi"` lalu klik `Cari` menampilkan `"Prodi -> D3 Teknik Informatika"`.
   - `HashSet`: mencoba menambah `20` (yang sudah ada) tidak mengubah isi `lstSet`, dan `lblStatusSet` melaporkan bahwa duplikat ditolak.

---

## 6. Eksperimen: Jika Variabel atau Nilainya Diubah-Ubah Jadi Apa?

| Bagian / Variabel yang Diubah | Nilai Awal | Diubah Menjadi | Dampak & Hasil yang Terjadi |
| :--- | :--- | :--- | :--- |
| Access Modifier `nilaiUmum` di `ModPerhitungan.vb` | `Public nilaiUmum As Integer = 80` | `Private nilaiUmum As Integer = 80` | **Compile Error** di `FrmKoleksi.vb` (`'nilaiUmum' is not accessible in this context because it is 'Private'`). Form tidak boleh menyentuh variabel `Private` milik modul lain. |
| Tipe kembalian `HitungLuas` | `Public Function HitungLuas(...) As Integer` | Diubah menjadi `Public Sub HitungLuas(...)` dengan `Return` | **Compile Error!** `Sub` tidak boleh memiliki `As Integer` dan tidak boleh mengembalikan nilai lewat `Return panjang * lebar`. |
| Indeks akses `Matriks2D(1, 2)` | `Matriks2D(1, 2)` | `Matriks2D(2, 1)` | Hasil berubah dari `60` (baris 1 kolom 2) menjadi `80` (baris 2 kolom 1). Urutan indeks di matriks 2D adalah `(baris, kolom)`. |
| Indeks akses di luar batas | `Nilai1D(2)` | `Nilai1D(5)` | **Runtime Error (`IndexOutOfRangeException`)!** Karena `Nilai1D` berisi 5 elemen, indeks valid hanyalah `0, 1, 2, 3, 4`. |
| `StringComparer.OrdinalIgnoreCase` pada `dataMhs` | Menggunakan `OrdinalIgnoreCase` | Dihapus (`New Dictionary(Of String, String) From ...`) | Mengetik `"nama"` (huruf kecil) di `txtKeyDict` dianggap **tidak ditemukan**, karena key tersimpan sebagai `"Nama"` (peka huruf besar-kecil / *case-sensitive*). |
| Koleksi `himpunanUnik` pada blok Set | `New HashSet(Of Integer)` | `New List(Of Integer)` | Angka `20` yang sama bisa masuk berkali-kali ke dalam daftar karena `List` mengizinkan duplikasi, berbeda dengan `HashSet`. |
| Jumlah kolom pada salah satu baris `Matriks2D` | Baris 1 `{40, 50, 60}` (3 kolom) | `{40, 50}` (2 kolom) | **Compile Error!** Pada Array 2D persegi (*rectangular array*) di VB.NET, seluruh baris wajib memiliki jumlah elemen kolom yang sama persis. |

---

## 7. Kesalahan Umum & Tips Praktis

1. **Lupa bahwa indeks Array dan List selalu mulai dari `0`:** Array berisi 5 elemen memiliki indeks `0` sampai `4`, bukan `1` sampai `5`. Gunakan `.Length - 1` atau `.GetUpperBound(0)` agar aman.
2. **Mengakses key `Dictionary` tanpa `ContainsKey`:** Menulis langsung `dataMhs("Alamat")` ketika key `"Alamat"` tidak ada akan melempar `KeyNotFoundException` dan menghentikan program. Selalu periksa dengan `ContainsKey(kunci)` terlebih dahulu.
3. **Menumpuk semua perhitungan di dalam Form:** Pisahkan rumus perhitungan atau fungsi validasi umum ke `Module` agar kode di Form tetap ringkas dan mudah dibaca.

---

Navigasi: [Pertemuan 4](../Praktikum%204/readme.md) | [Kembali ke README Utama](../readme.md) | [Lanjut ke Pertemuan 6](../Praktikum%206/readme.md)
