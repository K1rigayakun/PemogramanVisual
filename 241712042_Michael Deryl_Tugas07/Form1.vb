Option Strict On

Imports System.ComponentModel
Imports System.IO

Public Class Form1

    ' Menyimpan daftar kode buku yang sedang dipinjam untuk mencegah peminjaman ganda
    Private ReadOnly daftarBukuDipinjam As New List(Of String)

    ' Lokasi penyimpanan file CSV di folder Documents pengguna
    Private ReadOnly lokasiEkspor As String =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "peminjaman.csv")

    ''' <summary>
    ''' Memeriksa seluruh isian pada form secara terpusat menggunakan ErrorProvider.
    ''' Semua isian divalidasi sekaligus tanpa berhenti di kesalahan pertama.
    ''' </summary>
    ''' <returns>True jika semua isian valid, False jika ada satu atau lebih isian yang salah.</returns>
    Private Function ValidasiInput() As Boolean
        errPinjam.Clear()
        Dim valid As Boolean = True

        ' 1. Validasi Kode Buku: harus format "BK" diikuti 4 digit dan belum dipinjam
        Dim kodeInput As String = txtKodeBuku.Text.Trim().ToUpper()
        If Kosong(txtKodeBuku.Text) Then
            errPinjam.SetError(txtKodeBuku, "Kode buku wajib diisi.")
            valid = False
        ElseIf Not KodeBukuValid(txtKodeBuku.Text) Then
            errPinjam.SetError(txtKodeBuku, "Kode buku harus diawali 'BK' dan diikuti 4 digit angka (contoh: BK0012).")
            valid = False
        ElseIf daftarBukuDipinjam.Contains(kodeInput) Then
            errPinjam.SetError(txtKodeBuku, "Buku ini sedang dipinjam.")
            valid = False
        End If

        ' 2. Validasi Judul Buku: wajib diisi
        If Kosong(txtJudul.Text) Then
            errPinjam.SetError(txtJudul, "Judul buku wajib diisi.")
            valid = False
        End If

        ' 3. Validasi Kategori: wajib memilih salah satu opsi
        If cboKategori.SelectedIndex = -1 Then
            errPinjam.SetError(cboKategori, "Pilih salah satu kategori buku.")
            valid = False
        End If

        ' 4. Validasi Nama Peminjam: minimal 3 karakter (tidak termasuk spasi di awal/akhir)
        If txtNamaPeminjam.Text.Trim().Length < 3 Then
            errPinjam.SetError(txtNamaPeminjam, "Nama peminjam minimal 3 karakter.")
            valid = False
        End If

        ' 5. Validasi Lama Pinjam: bilangan bulat 1 sampai 14 hari via Integer.TryParse
        Dim lamaPinjam As Integer
        If Not Integer.TryParse(txtLamaPinjam.Text.Trim(), lamaPinjam) OrElse
           lamaPinjam < 1 OrElse lamaPinjam > 14 Then
            errPinjam.SetError(txtLamaPinjam, "Lama pinjam harus bilangan bulat antara 1 sampai 14 hari.")
            valid = False
        End If

        Return valid
    End Function

    ''' <summary>
    ''' Validasi instan format kode buku saat fokus berpindah dari kotak teks.
    ''' </summary>
    Private Sub txtKodeBuku_Validating(sender As Object, e As CancelEventArgs) Handles txtKodeBuku.Validating
        If Kosong(txtKodeBuku.Text) Then
            errPinjam.SetError(txtKodeBuku, "")
            Return
        End If

        Dim kodeBersih As String = txtKodeBuku.Text.Trim().ToUpper()

        If Not KodeBukuValid(kodeBersih) Then
            errPinjam.SetError(txtKodeBuku, "Kode buku harus diawali 'BK' dan diikuti 4 digit angka (contoh: BK0012).")
        ElseIf daftarBukuDipinjam.Contains(kodeBersih) Then
            errPinjam.SetError(txtKodeBuku, "Buku ini sedang dipinjam.")
        Else
            errPinjam.SetError(txtKodeBuku, "")
        End If
    End Sub

    ''' <summary>
    ''' Mencatat data peminjaman jika lolos validasi, menambahkan ke ListBox,
    ''' dan memperbarui status jumlah peminjaman.
    ''' </summary>
    Private Sub btnPinjam_Click(sender As Object, e As EventArgs) Handles btnPinjam.Click
        If Not ValidasiInput() Then
            lblStatus.Text = "Periksa isian yang bertanda merah."
            Return
        End If

        ' Format kode buku selalu disimpan dalam huruf kapital
        Dim kode As String = txtKodeBuku.Text.Trim().ToUpper()
        Dim judul As String = txtJudul.Text.Trim()
        Dim kategori As String = cboKategori.Text
        Dim peminjam As String = txtNamaPeminjam.Text.Trim()

        Dim lamaPinjam As Integer
        Integer.TryParse(txtLamaPinjam.Text.Trim(), lamaPinjam)

        ' Hitung tanggal kembali: hari ini + lama pinjam
        Dim tglKembali As String = Date.Today.AddDays(lamaPinjam).ToString("dd/MM/yyyy")

        ' Format baris data: BK0012 | Laskar Pelangi | Fiksi | Rina Lubis | 7 hari | kembali 28/10/2026
        Dim barisData As String = kode & " | " & judul & " | " & kategori & " | " & peminjam & " | " &
                                  lamaPinjam.ToString() & " hari | kembali " & tglKembali

        lstPeminjaman.Items.Add(barisData)
        daftarBukuDipinjam.Add(kode)

        lblStatus.Text = "Jumlah peminjaman: " & lstPeminjaman.Items.Count.ToString()
        BersihkanForm()
    End Sub

    ''' <summary>
    ''' Mengosongkan form input dan menghapus semua indikator error ErrorProvider.
    ''' </summary>
    Private Sub BersihkanForm()
        txtKodeBuku.Clear()
        txtJudul.Clear()
        cboKategori.SelectedIndex = -1
        txtNamaPeminjam.Clear()
        txtLamaPinjam.Clear()
        errPinjam.Clear()
        txtKodeBuku.Focus()
    End Sub

    ''' <summary>
    ''' Menangani klik tombol Bersihkan untuk mereset input tanpa menghapus data peminjaman yang tersimpan.
    ''' </summary>
    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
        BersihkanForm()
        lblStatus.Text = "Jumlah peminjaman: " & lstPeminjaman.Items.Count.ToString()
    End Sub

    ''' <summary>
    ''' Mengamankan teks yang akan ditulis ke file CSV bertitik-koma dengan mengapit tanda petik jika diperlukan.
    ''' </summary>
    Private Function EscapeCsv(teks As String) As String
        If teks.Contains(";") OrElse teks.Contains("""") OrElse teks.Contains(vbCrLf) Then
            Return """" & teks.Replace("""", """""") & """"
        Else
            Return teks
        End If
    End Function

    ''' <summary>
    ''' Mengekspor daftar peminjaman ke file peminjaman.csv di folder Documents.
    ''' Menggunakan Try...Catch...Finally dengan penanganan IOException dan UnauthorizedAccessException secara spesifik.
    ''' </summary>
    Private Sub btnEkspor_Click(sender As Object, e As EventArgs) Handles btnEkspor.Click
        ' Tolak ekspor jika daftar masih kosong
        If lstPeminjaman.Items.Count = 0 Then
            MessageBox.Show("Daftar peminjaman masih kosong. Tidak ada data yang dapat diekspor.",
                            "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim penulis As StreamWriter = Nothing
        Try
            penulis = New StreamWriter(lokasiEkspor, False, System.Text.Encoding.UTF8)

            ' Baris header dengan pemisah titik koma
            penulis.WriteLine("Kode Buku;Judul Buku;Kategori;Nama Peminjam;Lama Pinjam;Tanggal Kembali")

            ' Tulis setiap entri peminjaman
            For Each item As Object In lstPeminjaman.Items
                Dim baris As String = item.ToString()
                Dim kolom() As String = baris.Split(New String() {" | "}, StringSplitOptions.None)
                If kolom.Length = 6 Then
                    Dim barisCsv As String = String.Format("{0};{1};{2};{3};{4};{5}",
                                                           EscapeCsv(kolom(0)),
                                                           EscapeCsv(kolom(1)),
                                                           EscapeCsv(kolom(2)),
                                                           EscapeCsv(kolom(3)),
                                                           EscapeCsv(kolom(4)),
                                                           EscapeCsv(kolom(5)))
                    penulis.WriteLine(barisCsv)
                Else
                    penulis.WriteLine(baris.Replace(" | ", ";"))
                End If
            Next

            lblStatus.Text = "Data berhasil diekspor ke peminjaman.csv (" & lstPeminjaman.Items.Count.ToString() & " data)."
            MessageBox.Show("Data peminjaman berhasil diekspor ke:" & vbCrLf & lokasiEkspor,
                            "Ekspor Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As IOException
            ' Penjelasan apa yang harus dilakukan pengguna jika file terkunci
            MessageBox.Show("File peminjaman.csv sedang digunakan oleh aplikasi lain (seperti Microsoft Excel)." & vbCrLf &
                            "Silakan tutup file tersebut di Excel terlebih dahulu, kemudian klik Ekspor kembali.",
                            "File Sedang Terbuka", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As UnauthorizedAccessException
            ' Penjelasan apa yang harus dilakukan pengguna jika akses ditolak
            MessageBox.Show("Aplikasi tidak memiliki izin untuk menyimpan file di folder Documents." & vbCrLf &
                            "Pastikan Anda memiliki hak akses folder atau jalankan aplikasi sebagai Administrator.",
                            "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan tidak terduga saat mengekspor:" & vbCrLf & ex.Message,
                            "Ekspor Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            ' StreamWriter wajib ditutup di blok Finally sesuai spesifikasi tugas
            If penulis IsNot Nothing Then
                penulis.Close()
            End If
        End Try
    End Sub

End Class
