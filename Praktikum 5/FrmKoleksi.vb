Option Strict On

Public Class FrmKoleksi
    ' Koleksi data dinamis yang dipelihara selama form terbuka
    Private ReadOnly daftarAngka As New List(Of String) From {"10", "20", "30"}
    Private ReadOnly dataMhs As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase) From {
        {"NIM", "241712042"},
        {"Nama", "Michael Deryl"},
        {"Prodi", "D3 Teknik Informatika"}
    }
    Private ReadOnly himpunanUnik As New HashSet(Of Integer) From {10, 20}

    Private Sub FrmKoleksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblInfoAkses.Text =
            "Access Modifier di ModPerhitungan:" & vbCrLf &
            "- Public nilaiUmum (dapat dibaca langsung oleh Form) = " & nilaiUmum.ToString() & vbCrLf &
            "- Private rahasiaInternal (dibaca lewat fungsi Public AmbilRahasiaInternal) = " &
            AmbilRahasiaInternal().ToString()

        SegarkanList()
        SegarkanSet()
    End Sub

    Private Sub btnSapa_Click(sender As Object, e As EventArgs) Handles btnSapa.Click
        TampilkanPesan(txtNama.Text)
    End Sub

    Private Sub btnHitung_Click(sender As Object, e As EventArgs) Handles btnHitung.Click
        Dim panjang As Integer
        Dim lebar As Integer

        If Not Integer.TryParse(txtPanjang.Text.Trim(), panjang) OrElse panjang <= 0 Then
            MessageBox.Show("Panjang harus berupa bilangan bulat lebih dari 0.", "Input Tidak Valid",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPanjang.Focus()
            Return
        End If

        If Not Integer.TryParse(txtLebar.Text.Trim(), lebar) OrElse lebar <= 0 Then
            MessageBox.Show("Lebar harus berupa bilangan bulat lebih dari 0.", "Input Tidak Valid",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLebar.Focus()
            Return
        End If

        Dim luas As Integer = HitungLuas(panjang, lebar)
        Dim keliling As Integer = HitungKeliling(panjang, lebar)

        lblHasilHitung.Text =
            "Panjang = " & panjang.ToString() & ", Lebar = " & lebar.ToString() & vbCrLf &
            "Function HitungLuas(p, l) = " & luas.ToString() & vbCrLf &
            "Function HitungKeliling(p, l) = " & keliling.ToString()
    End Sub

    Private Sub btnArray1D_Click(sender As Object, e As EventArgs) Handles btnArray1D.Click
        lstArray.Items.Clear()
        For i As Integer = 0 To Nilai1D.Length - 1
            lstArray.Items.Add("Nilai1D(" & i.ToString() & ") = " & Nilai1D(i).ToString())
        Next
        lblRingkasanArray.Text = "Array 1D memiliki " & Nilai1D.Length.ToString() &
                                 " elemen (indeks 0 s.d. " & (Nilai1D.Length - 1).ToString() &
                                 "). Contoh: Nilai1D(2) = " & Nilai1D(2).ToString()
    End Sub

    Private Sub btnArray2D_Click(sender As Object, e As EventArgs) Handles btnArray2D.Click
        lstArray.Items.Clear()
        For baris As Integer = 0 To Matriks2D.GetUpperBound(0)
            Dim barisTeks As String = "Baris " & baris.ToString() & ": "
            For kolom As Integer = 0 To Matriks2D.GetUpperBound(1)
                barisTeks &= "[" & baris.ToString() & "," & kolom.ToString() & "]=" &
                             Matriks2D(baris, kolom).ToString() & "  "
            Next
            lstArray.Items.Add(barisTeks.TrimEnd())
        Next
        lblRingkasanArray.Text = "Array 2D (3x3). Contoh akses Matriks2D(1, 2) = " & Matriks2D(1, 2).ToString()
    End Sub

    Private Sub btnArray3D_Click(sender As Object, e As EventArgs) Handles btnArray3D.Click
        lstArray.Items.Clear()
        For blok As Integer = 0 To Ruang3D.GetUpperBound(0)
            lstArray.Items.Add("--- Blok (Kedalaman) ke-" & blok.ToString() & " ---")
            For baris As Integer = 0 To Ruang3D.GetUpperBound(1)
                Dim teksBaris As String = "  Baris " & baris.ToString() & ": "
                For kolom As Integer = 0 To Ruang3D.GetUpperBound(2)
                    teksBaris &= Ruang3D(blok, baris, kolom).ToString() & "  "
                Next
                lstArray.Items.Add(teksBaris.TrimEnd())
            Next
        Next
        lblRingkasanArray.Text = "Array 3D (2x3x3). Contoh akses Ruang3D(1, 2, 0) = " & Ruang3D(1, 2, 0).ToString()
    End Sub

    Private Sub btnBersihkanArray_Click(sender As Object, e As EventArgs) Handles btnBersihkanArray.Click
        lstArray.Items.Clear()
        lblRingkasanArray.Text = "Daftar array dibersihkan."
    End Sub

    Private Sub SegarkanList()
        lstDinamis.Items.Clear()
        For i As Integer = 0 To daftarAngka.Count - 1
            lstDinamis.Items.Add("[" & i.ToString() & "] " & daftarAngka(i))
        Next
    End Sub

    Private Sub btnTambahList_Click(sender As Object, e As EventArgs) Handles btnTambahList.Click
        Dim itemBaru As String = txtItemList.Text.Trim()
        If itemBaru = "" Then
            MessageBox.Show("Isi nilai terlebih dahulu untuk ditambahkan ke List.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtItemList.Focus()
            Return
        End If
        daftarAngka.Add(itemBaru)
        txtItemList.Clear()
        txtItemList.Focus()
        SegarkanList()
    End Sub

    Private Sub btnHapusList_Click(sender As Object, e As EventArgs) Handles btnHapusList.Click
        If lstDinamis.SelectedIndex = -1 Then
            MessageBox.Show("Pilih salah satu item di List terlebih dahulu untuk dihapus.", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        daftarAngka.RemoveAt(lstDinamis.SelectedIndex)
        SegarkanList()
    End Sub

    Private Sub btnCariDict_Click(sender As Object, e As EventArgs) Handles btnCariDict.Click
        Dim kunci As String = txtKeyDict.Text.Trim()
        If kunci = "" Then
            lblHasilDict.Text = "Masukkan key (NIM, Nama, atau Prodi)."
            Return
        End If

        If dataMhs.ContainsKey(kunci) Then
            lblHasilDict.Text = "Key ditemukan!" & vbCrLf & vbCrLf &
                                kunci & " -> " & dataMhs(kunci)
        Else
            lblHasilDict.Text = "Key '" & kunci & "' tidak ditemukan di Dictionary." & vbCrLf & vbCrLf &
                                "Gunakan key: NIM, Nama, atau Prodi."
        End If
    End Sub

    Private Sub SegarkanSet()
        lstSet.Items.Clear()
        For Each angka As Integer In himpunanUnik
            lstSet.Items.Add(angka.ToString())
        Next
    End Sub

    Private Sub btnTambahSet_Click(sender As Object, e As EventArgs) Handles btnTambahSet.Click
        Dim angka As Integer
        If Not Integer.TryParse(txtAngkaSet.Text.Trim(), angka) Then
            lblStatusSet.Text = "Masukkan bilangan bulat yang valid."
            txtAngkaSet.Focus()
            Return
        End If

        If himpunanUnik.Add(angka) Then
            SegarkanSet()
            lblStatusSet.Text = "Angka " & angka.ToString() & " ditambahkan. Total unik: " & himpunanUnik.Count.ToString()
        Else
            lblStatusSet.Text = "Nilai " & angka.ToString() & " sudah ada (duplikat ditolak oleh HashSet)."
        End If

        txtAngkaSet.Clear()
        txtAngkaSet.Focus()
    End Sub
End Class
