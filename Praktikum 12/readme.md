# Pertemuan 12: MenuStrip, ContextMenuStrip, & MDI (Administrasi Mahasiswa)

## 1. Gambaran Umum & Analogi

Pada Pertemuan 12 di proyek [Praktikum 12](./AdministrasiMahasiswaMdi.sln), kita menggabungkan berbagai form ke dalam satu aplikasi terpadu berarsitektur **MDI (*Multiple Document Interface*)**.

Bayangkan **meja kerja komputer atau aplikasi pengolah dokumen seperti Microsoft Excel lama**:
- **`FrmUtama` (`IsMdiContainer = True`)** adalah **ruang kerja induk (bingkai utama)** yang memiliki bilah menu di atas (**`MenuStrip`**).
- **`FrmMahasiswa`** dan **`FrmJurusan`** adalah **jendela anak (*MDI Child*)** yang hanya hidup dan bergerak di dalam batas bingkai `FrmUtama`.
- **`FrmTentang`** adalah **kotak dialog modal (*Modal Dialog*)** yang membuka lewat `ShowDialog(Me)`: selama jendela Tentang terbuka, pengguna harus menutupnya dulu sebelum menyentuh menu utama.
- **`ContextMenuStrip`** (`cmsCatatan`) adalah **menu klik kanan** yang muncul tepat di tempat kursor berada saat mengklik kanan kotak catatan di `FrmMahasiswa`.

---

## 2. Ringkasan Konsep Materi

### Konsep Kunci yang Dipelajari:
1. **`IsMdiContainer = True` & `MdiParent = Me`:** Mengubah Form induk menjadi wadah MDI dan mengikat Form anak ke dalamnya.
2. **Pola *Singleton Child Window* (`Me.MdiChildren`):** Memeriksa apakah Form anak bertipe tertentu sudah terbuka; jika sudah ada, cukup pulihkan bila diminimalkan lalu aktifkan (`anak.Activate()`) agar tidak terbuka kembar berkali-kali.
3. **`MenuStrip` & `MdiWindowListItem`:** Menyatukan navigasi menu (`&Berkas`, `&Data`, `&Jendela`, `B&antuan`), shortcut (`Ctrl+1`, `Ctrl+2`, `Ctrl+W`, `Ctrl+Q`, `F1`), serta daftar otomatis seluruh anak MDI yang sedang terbuka.
4. **`LayoutMdi(MdiLayout.*)`:** Menyusun jendela anak secara otomatis dalam mode bertumpuk (`Cascade`), mendatar (`TileHorizontal`), atau tegak (`TileVertical`).
5. **`ContextMenuStrip` & Sinkronisasi State UI:** Menonaktifkan tombol/menu `Pilih semua` dan `Bersihkan` ketika kotak catatan kosong, dan mengaktifkannya saat ada teks.
6. **Konfirmasi Keluar (`FormClosing`):** Menahan penutupan aplikasi dengan `e.Cancel = True` apabila pengguna memilih `No` pada kotak konfirmasi.

---

## 3. Daftar Komponen Antarmuka (UI Controls)

Aplikasi terdiri dari 4 Form dan 1 Module startup ([Program.vb](./Program.vb)):

1. **[FrmUtama](./FrmUtama.Designer.vb)** (`IsMdiContainer: True`, `ClientSize: 1200, 867`):
   - `mnsUtama` (`MenuStrip`, `MdiWindowListItem: mnuJendela`)
   - Menu `&Berkas`: `mnuKeluar` (`Ctrl+Q`)
   - Menu `&Data`: `mnuDataMahasiswa` (`Ctrl+1`), `mnuDataJurusan` (`Ctrl+2`)
   - Menu `&Jendela`: `mnuBertumpuk`, `mnuHorizontal`, `mnuVertikal`, `mnuTutupAktif` (`Ctrl+W`), `mnuTutupSemua`
   - Menu `B&antuan`: `mnuTentang` (`F1`)
2. **[FrmMahasiswa](./FrmMahasiswa.Designer.vb)** (`ClientSize: 625, 396`):
   - `lblJudul`, `dgvMahasiswa` (`ReadOnly: True`, `AllowUserToAddRows: False`, `SelectionMode: FullRowSelect`)
   - `lblCatatan`, `txtCatatan` (`Multiline: True`, `ContextMenuStrip: cmsCatatan`), `btnBersihkanCatatan`
   - `cmsCatatan` (`ContextMenuStrip`): `mnuPilihSemuaCatatan`, `mnuBersihkanCatatan`
3. **[FrmJurusan](./FrmJurusan.Designer.vb)** (`ClientSize: 420, 270`):
   - `lblJudul`, `lstJurusan` (berisi 3 jurusan), `lblKeterangan`
4. **[FrmTentang](./FrmTentang.Designer.vb)** (`FormBorderStyle: FixedDialog`, `ShowInTaskbar: False`):
   - `lblIsi`, `btnTutup` (`DialogResult.Cancel`, sekaligus `AcceptButton` & `CancelButton`)

---

## 4. Bedah Kode Program: Kodenya Ini Buat Apa?

### A. [FrmUtama.vb](./FrmUtama.vb) — Mengelola Anak MDI, Tata Letak, & Konfirmasi Tutup

```vbnet
    Private Sub BukaMahasiswa()
        For Each anak As Form In Me.MdiChildren
            If TypeOf anak Is FrmMahasiswa Then
                If anak.WindowState = FormWindowState.Minimized Then
                    anak.WindowState = FormWindowState.Normal
                End If
                anak.Activate()
                Return
            End If
        Next
        Dim baru As New FrmMahasiswa()
        baru.MdiParent = Me
        baru.Show()
    End Sub
```

**Penjelasan:**
- Perulangan `For Each anak As Form In Me.MdiChildren` menyisir seluruh jendela anak yang sedang terbuka di dalam `FrmUtama`.
- `If TypeOf anak Is FrmMahasiswa Then`: Jika jendela `FrmMahasiswa` sudah ada, tidak dibuat jendela kedua. Jika sebelumnya diperkecil (*minimized*), dikembalikan ke ukuran `Normal`, lalu dibawa ke depan (`anak.Activate()`), dan `Return`.
- Jika belum ada, barulah dibuat `New FrmMahasiswa()`, ditetapkan induknya (`baru.MdiParent = Me`), dan ditampilkan dengan `baru.Show()` (bukan `ShowDialog()`, karena anak MDI tidak boleh bersifat modal!).

**Memperbarui Status Menu Jendela Secara Otomatis:**
```vbnet
    Private Sub PerbaruiMenuJendela(sender As Object, e As EventArgs) _
        Handles MyBase.MdiChildActivate, mnuJendela.DropDownOpening
        Dim adaAnak As Boolean = Me.MdiChildren.Length > 0
        mnuTutupAktif.Enabled = Me.ActiveMdiChild IsNot Nothing
        mnuTutupSemua.Enabled = adaAnak
        mnuBertumpuk.Enabled = adaAnak
        mnuHorizontal.Enabled = adaAnak
        mnuVertikal.Enabled = adaAnak
    End Sub
```
- Satu prosedur menangani dua event sekaligus (`MdiChildActivate` dan `mnuJendela.DropDownOpening`). Ketika belum ada form anak yang terbuka (`adaAnak = False`), menu tata letak dan tutup otomatis dinonaktifkan (`Enabled = False`) agar tidak diklik sia-sia.

**Konfirmasi Sebelum Keluar (`FrmUtama_FormClosing`):**
```vbnet
    Private Sub FrmUtama_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason <> CloseReason.UserClosing Then Return
        Dim jawaban As DialogResult = MessageBox.Show(Me,
            "Keluar dari aplikasi? Catatan sementara pada child akan hilang.", "Konfirmasi keluar",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        e.Cancel = jawaban <> DialogResult.Yes
    End Sub
```
- `MessageBoxDefaultButton.Button2` menempatkan fokus default pada tombol **No** (tombol ke-2), sehingga jika pengguna tidak sengaja menekan Enter, aplikasi tidak langsung tertutup.
- `e.Cancel = jawaban <> DialogResult.Yes`: jika pengguna tidak memilih `Yes`, `e.Cancel` bernilai `True` sehingga proses penutupan Form dibatalkan.

### B. [FrmMahasiswa.vb](./FrmMahasiswa.vb) — `DataTable`, Event Bersama, & `ContextMenuStrip`

```vbnet
    Private Sub Bersihkan_Click(sender As Object, e As EventArgs) _
        Handles btnBersihkanCatatan.Click, mnuBersihkanCatatan.Click
        BersihkanCatatan()
    End Sub
```
- Baik tombol `btnBersihkanCatatan` maupun menu klik kanan `mnuBersihkanCatatan` ditangani oleh **satu prosedur yang sama** (`Handles btnBersihkanCatatan.Click, mnuBersihkanCatatan.Click`), menghindari duplikasi kode.
- `PerbaruiMenuCatatan()` mengecek `txtCatatan.TextLength > 0` agar menu klik kanan (`cmsCatatan.Opening`) dan tombol selalu sinkron saat catatan berisi teks atau kosong.

### C. [FrmJurusan.vb](./FrmJurusan.vb) & [FrmTentang.vb](./FrmTentang.vb)

- `FrmJurusan`: Memeriksa `If lstJurusan.SelectedItem Is Nothing Then Return` sebelum membaca `.ToString()`, mencegah `NullReferenceException` ketika tidak ada item yang terpilih.
- `FrmTentang`: Tombol `btnTutup` memanggil `Me.Close()` (serta mendukung tombol `Esc` karena diset sebagai `CancelButton` pada Form).

---

## 5. Apa yang Dihasilkan Program

1. Saat aplikasi dijalankan, muncul jendela induk MDI besar (`1200 x 867`) dengan 4 menu di bagian atas. Menu `Jendela` awalnya memiliki sub-menu yang nonaktif (`Enabled = False`).
2. Tekan `Ctrl+1` atau klik **Data -> Mahasiswa**: muncul jendela anak `Data Mahasiswa` berisi tabel 3 mahasiswa latihan (`Alya`, `Bima`, `Citra`) dan kotak catatan sementara.
3. Tekan `Ctrl+2` atau klik **Data -> Jurusan**: muncul jendela anak `Data Jurusan` di dalam area abu-abu MDI. Mengklik salah satu jurusan langsung memperbarui `lblKeterangan`.
4. Klik **Jendela -> Berdampingan Vertikal** (atau **Horizontal** / **Bertumpuk**): kedua jendela anak otomatis tertata rapi berdampingan di dalam `FrmUtama`.
5. Klik kanan pada kotak `txtCatatan` di `FrmMahasiswa`: muncul `ContextMenuStrip` dengan opsi *Pilih semua* dan *Bersihkan*.
6. Klik **Bantuan -> Tentang** (atau tekan `F1`): muncul jendela dialog `FrmTentang` yang mengunci jendela induk sampai ditutup.
7. Klik tombol X atau `Ctrl+Q`: muncul dialog konfirmasi keluar; memilih **No** membatalkan penutupan, memilih **Yes** menutup aplikasi.

---

## 6. Eksperimen: Jika Variabel atau Nilainya Diubah-Ubah Jadi Apa?

| Bagian / Variabel yang Diubah | Nilai Awal | Diubah Menjadi | Dampak & Hasil yang Terjadi |
| :--- | :--- | :--- | :--- |
| Properti `IsMdiContainer` di `FrmUtama.Designer.vb` | `True` | `False` | **Runtime Error (`InvalidOperationException`)!** Baris `baru.MdiParent = Me` langsung melempar exception karena Form induk bukan lagi kontainer MDI. |
| Baris `baru.MdiParent = Me` di `BukaMahasiswa()` | Ada | Dihapus | `FrmMahasiswa` terbuka sebagai jendela bebas yang bisa ditarik **keluar** dari area `FrmUtama`, tidak ikut tertata oleh `LayoutMdi()`, dan `Me.MdiChildren.Length` tetap `0`. |
| Perulangan `For Each anak` di `BukaMahasiswa()` | Mengecek `If TypeOf anak Is FrmMahasiswa Then` | Langsung `Dim baru As New FrmMahasiswa()` tanpa perulangan | Setiap kali klik `Data -> Mahasiswa`, muncul **jendela kembar baru** (`FrmMahasiswa` ke-2, ke-3, dst.) menumpuk di layar. |
| Pemanggilan `dialog.ShowDialog(Me)` di `mnuTentang_Click` | `dialog.ShowDialog(Me)` | `dialog.Show()` | Jendela `Tentang` menjadi non-modal: pengguna masih bisa mengklik menu utama dan membuka jendela lain di belakangnya tanpa menutup `FrmTentang` terlebih dahulu. |
| `e.Cancel = jawaban <> DialogResult.Yes` di `FrmUtama_FormClosing` | `e.Cancel = jawaban <> DialogResult.Yes` | Dihapus | Meskipun pengguna menekan tombol **No** pada dialog konfirmasi keluar, jendela utama tetap langsung menutup diri. |
| Klausa `If lstJurusan.SelectedItem Is Nothing` di `FrmJurusan.vb` | Ada penjagaan `Is Nothing` | Dihapus | Jika `SelectedIndex` berubah menjadi `-1` (tidak ada item terpilih), pemanggilan `lstJurusan.SelectedItem.ToString()` langsung memicu **`NullReferenceException`**. |
| `mnsUtama.MdiWindowListItem` di `FrmUtama.Designer.vb` | `mnuJendela` | `Nothing` (dihapus) | Daftar nama jendela anak yang sedang terbuka (misal `1 Data Mahasiswa`, `2 Data Jurusan`) tidak lagi muncul otomatis di bagian bawah menu `Jendela`. |

---

## 7. Kesalahan Umum & Tips Praktis

1. **Mencoba memanggil `ShowDialog()` pada MDI Child (`baru.MdiParent = Me`):** Form yang sudah ditetapkan `MdiParent`-nya **tidak boleh** dibuka dengan `.ShowDialog()`, wajib menggunakan `.Show()`.
2. **Menulis logika penghapusan yang sama berulang kali untuk tombol dan menu klik kanan:** Gunakan satu `Sub` dengan multiple `Handles` (contoh: `Handles btnBersihkanCatatan.Click, mnuBersihkanCatatan.Click`).
3. **Menutup semua MDI child dengan `For Each anak In Me.MdiChildren` perlu kehati-hatian pada versi koleksi tertentu:** Pada WinForms .NET, `Me.MdiChildren` mengembalikan array *snapshot* `Form()`, sehingga aman diiterasi untuk `.Close()`.

---

Navigasi: [Pertemuan 11](../Praktikum%2011/readme.md) | [Kembali ke README Utama](../readme.md)
