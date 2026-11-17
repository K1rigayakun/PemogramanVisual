Option Strict On
Option Explicit On

Imports System.Globalization

Public Class FrmPeminjamanAlat

    Public ReadOnly listAlat As New List(Of AlatLab)()

    Private Sub FrmPeminjamanAlat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            listAlat.Clear()
            cboAlat.Items.Clear()

            For Each nama As String In ModInventaris.DaftarAlat
                Dim stok As Integer = ModInventaris.StokAwal(nama)
                Dim item As New AlatLab(nama, stok)
                listAlat.Add(item)
                cboAlat.Items.Add(nama)
            Next

            bsAlat.DataSource = listAlat
            dgvAlat.DataSource = bsAlat

            cboAlat.SelectedIndex = -1
            txtJumlah.Clear()
            errInput.Clear()
            dgvAlat.ClearSelection()

            HitungTotalDipinjam()
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memuat data awal: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function ValidasiInput(ByRef jumlahOutput As Integer) As Boolean
        Dim isValid As Boolean = True
        errInput.Clear()

        If cboAlat.SelectedIndex = -1 OrElse cboAlat.SelectedItem Is Nothing Then
            errInput.SetError(cboAlat, "Pilih alat terlebih dahulu.")
            isValid = False
        End If

        Dim teksJumlah As String = txtJumlah.Text.Trim()
        Dim parseBerhasil As Boolean = Integer.TryParse(
            teksJumlah,
            NumberStyles.Integer,
            CultureInfo.InvariantCulture,
            jumlahOutput
        )

        If Not parseBerhasil OrElse jumlahOutput <= 0 Then
            errInput.SetError(txtJumlah, "Jumlah harus berupa bilangan bulat positif.")
            isValid = False
        End If

        Return isValid
    End Function

    Private Sub btnPinjam_Click(sender As Object, e As EventArgs) Handles btnPinjam.Click
        Try
            Dim jumlahPinjam As Integer = 0
            If Not ValidasiInput(jumlahPinjam) Then
                Exit Sub
            End If

            Dim namaDipilih As String = cboAlat.SelectedItem.ToString()
            Dim targetAlat As AlatLab = Nothing

            For Each alat As AlatLab In listAlat
                If String.Equals(alat.NamaAlat, namaDipilih, StringComparison.OrdinalIgnoreCase) Then
                    targetAlat = alat
                    Exit For
                End If
            Next

            If targetAlat IsNot Nothing Then
                If targetAlat.Tersedia = 0 Then
                    errInput.SetError(txtJumlah, "Stok alat sudah habis.")
                    Exit Sub
                End If

                If jumlahPinjam > targetAlat.Tersedia Then
                    errInput.SetError(txtJumlah, $"Jumlah melebihi stok yang tersedia ({targetAlat.Tersedia} unit).")
                    Exit Sub
                End If

                targetAlat.Tersedia -= jumlahPinjam
                targetAlat.Dipinjam += jumlahPinjam

                bsAlat.ResetBindings(False)
                HitungTotalDipinjam()
                dgvAlat.ClearSelection()

                cboAlat.SelectedIndex = -1
                txtJumlah.Clear()
                errInput.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan pada proses peminjaman: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnKembalikan_Click(sender As Object, e As EventArgs) Handles btnKembalikan.Click
        Try
            Dim jumlahKembali As Integer = 0
            If Not ValidasiInput(jumlahKembali) Then
                Exit Sub
            End If

            Dim namaDipilih As String = cboAlat.SelectedItem.ToString()
            Dim targetAlat As AlatLab = Nothing

            For Each alat As AlatLab In listAlat
                If String.Equals(alat.NamaAlat, namaDipilih, StringComparison.OrdinalIgnoreCase) Then
                    targetAlat = alat
                    Exit For
                End If
            Next

            If targetAlat IsNot Nothing Then
                If targetAlat.Dipinjam = 0 Then
                    errInput.SetError(txtJumlah, "Tidak ada alat ini yang sedang dipinjam.")
                    Exit Sub
                End If

                If jumlahKembali > targetAlat.Dipinjam Then
                    errInput.SetError(txtJumlah, $"Jumlah melebihi unit yang sedang dipinjam ({targetAlat.Dipinjam} unit).")
                    Exit Sub
                End If

                targetAlat.Tersedia += jumlahKembali
                targetAlat.Dipinjam -= jumlahKembali

                bsAlat.ResetBindings(False)
                HitungTotalDipinjam()
                dgvAlat.ClearSelection()

                cboAlat.SelectedIndex = -1
                txtJumlah.Clear()
                errInput.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan pada proses pengembalian: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            Dim konfirmasi As DialogResult = MessageBox.Show(
                "Kembalikan seluruh stok ke kondisi awal?",
                "Reset Data",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

            If konfirmasi = DialogResult.Yes Then
                EksekusiReset()
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat mereset data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub EksekusiReset()
        For Each alat As AlatLab In listAlat
            alat.Tersedia = alat.StokAwal
            alat.Dipinjam = 0
        Next

        bsAlat.ResetBindings(False)
        HitungTotalDipinjam()
        dgvAlat.ClearSelection()

        cboAlat.SelectedIndex = -1
        txtJumlah.Clear()
        errInput.Clear()
    End Sub

    Public Sub HitungTotalDipinjam()
        Dim total As Integer = 0
        For Each alat As AlatLab In listAlat
            total += alat.Dipinjam
        Next
        lblTotalDipinjam.Text = $"{total} unit"
    End Sub

End Class
