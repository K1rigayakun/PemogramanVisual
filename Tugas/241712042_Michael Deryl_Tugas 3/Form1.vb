Option Strict On

Imports System.ComponentModel

''' <summary>
''' Form utama aplikasi Inventaris Buku Perpustakaan.
''' Mengimplementasikan pengelolaan data berbasis DataTable di memori,
''' data binding dua arah via BindingSource, validasi form dengan ErrorProvider,
''' pencarian gabungan (teks & kategori), pengurutan, dan perhitungan ringkasan real-time.
''' </summary>
Public Class Form1

    ' DataTable di memori untuk menyimpan seluruh data inventaris buku tanpa database
    Private tabelBuku As DataTable

    ''' <summary>
    ''' Menangani inisialisasi awal saat Form dimuat: pembentukan struktur DataTable,
    ''' pengisian data awal, pengikatan BindingSource ke DataGridView, serta penyesuaian kolom.
    ''' </summary>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InisialisasiDataAwal()
        RapikanGrid()

        ' Mengatur pilihan default untuk dropdown filter dan pengurutan
        cboFilterKategori.SelectedIndex = 0 ' Opsi "Semua"
        cboUrut.SelectedIndex = 0           ' Opsi "Urutan awal"

        PerbaruiRingkasan()
    End Sub

    ''' <summary>
    ''' Membentuk skema DataTable dan mengisi minimal 10 data buku awal
    ''' yang mencakup 4 kategori (Fiksi, Nonfiksi, Referensi, Majalah)
    ''' dengan minimal dua buku memiliki stok 0.
    ''' </summary>
    Private Sub InisialisasiDataAwal()
        tabelBuku = New DataTable("Buku")

        ' Definisi kolom tabel sesuai spesifikasi tugas
        tabelBuku.Columns.Add("KodeBuku", GetType(String))
        tabelBuku.Columns.Add("Judul", GetType(String))
        tabelBuku.Columns.Add("Penulis", GetType(String))
        tabelBuku.Columns.Add("Kategori", GetType(String))
        tabelBuku.Columns.Add("Tahun", GetType(Integer))
        tabelBuku.Columns.Add("Stok", GetType(Integer))

        ' Pengisian 10 data awal
        tabelBuku.Rows.Add("BK0001", "Laskar Pelangi", "Andrea Hirata", "Fiksi", 2005, 8)
        tabelBuku.Rows.Add("BK0002", "Bumi Manusia", "Pramoedya Ananta Toer", "Fiksi", 1980, 0)
        tabelBuku.Rows.Add("BK0003", "Laut Bercerita", "Leila S. Chudori", "Fiksi", 2017, 5)
        tabelBuku.Rows.Add("BK0004", "Filosofi Teras", "Henry Manampiring", "Nonfiksi", 2018, 12)
        tabelBuku.Rows.Add("BK0005", "Atomic Habits", "James Clear", "Nonfiksi", 2018, 7)
        tabelBuku.Rows.Add("BK0006", "Sapiens", "Yuval Noah Harari", "Nonfiksi", 2014, 4)
        tabelBuku.Rows.Add("BK0007", "Kamus Besar Bahasa Indonesia", "Tim Balai Pustaka", "Referensi", 2016, 0)
        tabelBuku.Rows.Add("BK0008", "Ensiklopedia Sains Modern", "Robert Winston", "Referensi", 2020, 3)
        tabelBuku.Rows.Add("BK0009", "National Geographic Edisi 10", "Tim Redaksi NG", "Majalah", 2023, 6)
        tabelBuku.Rows.Add("BK0010", "Tempo Investigasi", "Pusat Data Tempo", "Majalah", 2024, 5)

        ' Menghubungkan DataTable ke DataGridView melalui perantara BindingSource
        bsBuku.DataSource = tabelBuku
        dgvBuku.DataSource = bsBuku
    End Sub

    ''' <summary>
    ''' Mengatur tata letak kolom DataGridView: judul header yang rapi,
    ''' perataan tengah untuk kolom Tahun dan Stok, serta pembobotan lebar kolom (FillWeight).
    ''' </summary>
    Private Sub RapikanGrid()
        If dgvBuku.Columns.Contains("KodeBuku") Then
            dgvBuku.Columns("KodeBuku").HeaderText = "Kode Buku"
            dgvBuku.Columns("KodeBuku").FillWeight = 85
            dgvBuku.Columns("KodeBuku").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        If dgvBuku.Columns.Contains("Judul") Then
            dgvBuku.Columns("Judul").HeaderText = "Judul Buku"
            dgvBuku.Columns("Judul").FillWeight = 180
        End If

        If dgvBuku.Columns.Contains("Penulis") Then
            dgvBuku.Columns("Penulis").HeaderText = "Penulis"
            dgvBuku.Columns("Penulis").FillWeight = 135
        End If

        If dgvBuku.Columns.Contains("Kategori") Then
            dgvBuku.Columns("Kategori").HeaderText = "Kategori"
            dgvBuku.Columns("Kategori").FillWeight = 90
        End If

        If dgvBuku.Columns.Contains("Tahun") Then
            dgvBuku.Columns("Tahun").HeaderText = "Tahun"
            dgvBuku.Columns("Tahun").FillWeight = 70
            dgvBuku.Columns("Tahun").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        If dgvBuku.Columns.Contains("Stok") Then
            dgvBuku.Columns("Stok").HeaderText = "Stok"
            dgvBuku.Columns("Stok").FillWeight = 65
            dgvBuku.Columns("Stok").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If

        dgvBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    ''' <summary>
    ''' Melakukan validasi menyeluruh pada seluruh kotak isian form dengan ErrorProvider
    ''' tanpa berhenti di kesalahan pertama.
    ''' </summary>
    ''' <returns>True jika seluruh isian valid, False jika ada satu atau lebih kesalahan.</returns>
    Private Function ValidasiInput() As Boolean
        errBuku.Clear()
        Dim valid As Boolean = True

        ' 1. Validasi Kode Buku: harus format "BK" + 4 digit angka dan belum terdaftar di tabelBuku
        Dim kodeInput As String = txtKodeBuku.Text.Trim().ToUpper()
        If Kosong(txtKodeBuku.Text) Then
            errBuku.SetError(txtKodeBuku, "Kode buku wajib diisi.")
            valid = False
        ElseIf Not KodeBukuValid(kodeInput) Then
            errBuku.SetError(txtKodeBuku, "Kode buku harus diawali 'BK' dan diikuti 4 digit angka (contoh: BK0012).")
            valid = False
        Else
            ' Pemeriksaan kode unik dengan perulangan pada tabelBuku.Rows
            Dim sudahAda As Boolean = False
            For Each baris As DataRow In tabelBuku.Rows
                If baris.RowState <> DataRowState.Deleted Then
                    If String.Equals(baris("KodeBuku").ToString().Trim(), kodeInput, StringComparison.OrdinalIgnoreCase) Then
                        sudahAda = True
                        Exit For
                    End If
                End If
            Next

            If sudahAda Then
                errBuku.SetError(txtKodeBuku, "Kode buku sudah terdaftar dalam tabel inventaris.")
                valid = False
            End If
        End If

        ' 2. Validasi Judul Buku: wajib diisi
        If Kosong(txtJudul.Text) Then
            errBuku.SetError(txtJudul, "Judul buku wajib diisi.")
            valid = False
        End If

        ' 3. Validasi Penulis: wajib diisi
        If Kosong(txtPenulis.Text) Then
            errBuku.SetError(txtPenulis, "Penulis buku wajib diisi.")
            valid = False
        End If

        ' 4. Validasi Kategori: wajib dipilih salah satu opsi
        If cboKategori.SelectedIndex = -1 Then
            errBuku.SetError(cboKategori, "Pilih salah satu kategori buku.")
            valid = False
        End If

        ' 5. Validasi Tahun Terbit: bilangan bulat dari 1900 sampai tahun ini
        Dim tahun As Integer
        Dim tahunSekarang As Integer = Date.Today.Year
        If Not Integer.TryParse(txtTahun.Text.Trim(), tahun) OrElse tahun < 1900 OrElse tahun > tahunSekarang Then
            errBuku.SetError(txtTahun, "Tahun terbit harus berupa bilangan bulat antara 1900 dan " & tahunSekarang.ToString() & ".")
            valid = False
        End If

        ' 6. Validasi Stok: bilangan bulat 0 atau lebih
        Dim stok As Integer
        If Not Integer.TryParse(txtStok.Text.Trim(), stok) OrElse stok < 0 Then
            errBuku.SetError(txtStok, "Jumlah stok harus berupa bilangan bulat 0 atau lebih.")
            valid = False
        End If

        Return valid
    End Function

    ''' <summary>
    ''' Memberikan feedback validasi langsung pada kode buku saat kursor/fokus berpindah kontrol.
    ''' </summary>
    Private Sub txtKodeBuku_Validating(sender As Object, e As CancelEventArgs) Handles txtKodeBuku.Validating
        If Kosong(txtKodeBuku.Text) Then
            errBuku.SetError(txtKodeBuku, "")
            Return
        End If

        Dim kodeInput As String = txtKodeBuku.Text.Trim().ToUpper()
        If Not KodeBukuValid(kodeInput) Then
            errBuku.SetError(txtKodeBuku, "Kode buku harus diawali 'BK' dan diikuti 4 digit angka (contoh: BK0012).")
            Return
        End If

        Dim sudahAda As Boolean = False
        If tabelBuku IsNot Nothing Then
            For Each baris As DataRow In tabelBuku.Rows
                If baris.RowState <> DataRowState.Deleted Then
                    If String.Equals(baris("KodeBuku").ToString().Trim(), kodeInput, StringComparison.OrdinalIgnoreCase) Then
                        sudahAda = True
                        Exit For
                    End If
                End If
            Next
        End If

        If sudahAda Then
            errBuku.SetError(txtKodeBuku, "Kode buku sudah terdaftar dalam tabel inventaris.")
        Else
            errBuku.SetError(txtKodeBuku, "")
        End If
    End Sub

    ''' <summary>
    ''' Menambahkan buku baru ke DataTable jika lolos seluruh aturan validasi.
    ''' Baris baru akan langsung tampak pada DataGridView secara reaktif melalui BindingSource.
    ''' </summary>
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If Not ValidasiInput() Then
            Return
        End If

        Dim kode As String = txtKodeBuku.Text.Trim().ToUpper()
        Dim judul As String = txtJudul.Text.Trim()
        Dim penulis As String = txtPenulis.Text.Trim()
        Dim kategori As String = cboKategori.Text
        Dim tahun As Integer = Integer.Parse(txtTahun.Text.Trim())
        Dim stok As Integer = Integer.Parse(txtStok.Text.Trim())

        ' Penambahan baris langsung ke DataTable
        tabelBuku.Rows.Add(kode, judul, penulis, kategori, tahun, stok)

        BersihkanIsian()
        PerbaruiRingkasan()
    End Sub

    ''' <summary>
    ''' Mengosongkan isian formulir input buku dan menghapus penanda kesalahan ErrorProvider.
    ''' </summary>
    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
        BersihkanIsian()
    End Sub

    ''' <summary>
    ''' Prosedur pembantu untuk mereset seluruh kontrol input ke kondisi semula.
    ''' </summary>
    Private Sub BersihkanIsian()
        txtKodeBuku.Clear()
        txtJudul.Clear()
        txtPenulis.Clear()
        cboKategori.SelectedIndex = -1
        txtTahun.Clear()
        txtStok.Clear()
        errBuku.Clear()
        txtKodeBuku.Focus()
    End Sub

    ''' <summary>
    ''' Menjalankan filter gabungan secara otomatis saat pengguna mengetik kata pencarian.
    ''' </summary>
    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        TerapkanFilter()
    End Sub

    ''' <summary>
    ''' Menjalankan filter gabungan saat kategori dropdown filter berubah.
    ''' </summary>
    Private Sub cboFilterKategori_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterKategori.SelectedIndexChanged
        TerapkanFilter()
    End Sub

    ''' <summary>
    ''' Menjalankan filter gabungan saat status checkbox stok habis diubah.
    ''' </summary>
    Private Sub chkStokHabis_CheckedChanged(sender As Object, e As EventArgs) Handles chkStokHabis.CheckedChanged
        TerapkanFilter()
    End Sub

    ''' <summary>
    ''' Menggabungkan seluruh syarat filter aktif (kata kunci, kategori, dan opsi stok habis)
    ''' ke dalam satu ekspresi BindingSource.Filter dengan operator AND.
    ''' </summary>
    Private Sub TerapkanFilter()
        Dim syaratList As New List(Of String)()

        ' Syarat 1: Pencarian teks pada kolom Judul ATAU Penulis
        Dim kata As String = txtCari.Text.Trim()
        If kata.Length > 0 Then
            Dim kataAman As String = AmankanTeksFilter(kata)
            syaratList.Add(String.Format("(Judul LIKE '%{0}%' OR Penulis LIKE '%{0}%')", kataAman))
        End If

        ' Syarat 2: Pembatasan kategori jika tidak memilih "Semua"
        Dim kategori As String = cboFilterKategori.Text.Trim()
        If kategori.Length > 0 AndAlso kategori <> "Semua" Then
            Dim kategoriAman As String = AmankanTeksFilter(kategori)
            syaratList.Add(String.Format("Kategori = '{0}'", kategoriAman))
        End If

        ' Syarat 3 (Tantangan): Menampilkan hanya buku dengan stok habis (Stok = 0)
        If chkStokHabis.Checked Then
            syaratList.Add("Stok = 0")
        End If

        ' Terapkan filter gabungan jika ada syarat, atau kosongkan filter jika tidak ada syarat
        If syaratList.Count = 0 Then
            bsBuku.RemoveFilter()
        Else
            bsBuku.Filter = String.Join(" AND ", syaratList)
        End If

        PerbaruiRingkasan()
    End Sub

    ''' <summary>
    ''' Fitur tantangan tambahan: Mengatur pengurutan data DataGridView melalui BindingSource.Sort.
    ''' </summary>
    Private Sub cboUrut_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUrut.SelectedIndexChanged
        Select Case cboUrut.Text
            Case "Judul A-Z"
                bsBuku.Sort = "Judul ASC"
            Case "Tahun terbaru"
                bsBuku.Sort = "Tahun DESC"
            Case "Stok terbanyak"
                bsBuku.Sort = "Stok DESC"
            Case Else
                bsBuku.RemoveSort()
        End Select
    End Sub

    ''' <summary>
    ''' Menghitung dan memperbarui jumlah data buku yang sedang ditampilkan
    ''' serta total stok dari seluruh baris DataGridView yang terlihat.
    ''' </summary>
    Private Sub PerbaruiRingkasan()
        Dim tampil As Integer = bsBuku.Count
        Dim totalSemua As Integer = 0
        If tabelBuku IsNot Nothing Then
            totalSemua = tabelBuku.Rows.Count
        End If

        ' Menampilkan format: "Menampilkan X dari Y buku"
        lblJumlah.Text = String.Format("Menampilkan {0} dari {1} buku", tampil, totalSemua)

        ' Menghitung total stok buku yang sedang tampil dengan perulangan pada dgvBuku.Rows
        Dim totalStok As Integer = 0
        For Each baris As DataGridViewRow In dgvBuku.Rows
            If Not baris.IsNewRow AndAlso baris.Cells("Stok").Value IsNot Nothing Then
                totalStok += CInt(baris.Cells("Stok").Value)
            End If
        Next

        lblTotalStok.Text = String.Format("Total stok: {0}", totalStok)
    End Sub

End Class
