Public Class FrmKasir
    Private ReadOnly daftarPesanan As New List(Of Pesanan)

    Private Sub FrmKasir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each layanan As String In daftarLayanan
            cboLayanan.Items.Add(layanan)
        Next

        bsPesanan.DataSource = daftarPesanan
        dgvPesanan.DataSource = bsPesanan

        dgvPesanan.Columns("Harga").HeaderText = "Harga Satuan"
        dgvPesanan.Columns("Harga").DefaultCellStyle.Format = "N0"
        dgvPesanan.Columns("Harga").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPesanan.Columns("Diskon").DefaultCellStyle.Format = "N0"
        dgvPesanan.Columns("Diskon").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPesanan.Columns("Subtotal").DefaultCellStyle.Format = "N0"
        dgvPesanan.Columns("Subtotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        Try
            errInput.Clear()
            Dim valid As Boolean = True
            Dim jumlah As Integer

            If cboLayanan.SelectedIndex = -1 Then
                errInput.SetError(cboLayanan, "Pilih layanan.")
                valid = False
            End If

            If Not Integer.TryParse(txtJumlah.Text, jumlah) OrElse jumlah < 1 OrElse jumlah > 1000 Then
                errInput.SetError(txtJumlah, "Jumlah Minimal 1.")
                valid = False
            End If

            If Not valid Then Return

            Dim layanan As String = cboLayanan.Text
            Dim harga As Decimal = HargaSatuan(layanan)
            Dim sudahAda As Boolean = False

            For Each psn As Pesanan In daftarPesanan
                If psn.Layanan = layanan Then
                    If psn.Jumlah + jumlah > 1000 Then
                        errInput.SetError(txtJumlah, "Jumlah gabungan lebih dari 1000.")
                        Return
                    End If

                    psn.Jumlah += jumlah
                    If psn.Jumlah >= 100 Then
                        psn.Diskon = (psn.Harga * psn.Jumlah) * 0.1D
                    Else
                        psn.Diskon = 0D
                    End If
                    psn.Subtotal = (psn.Harga * psn.Jumlah) - psn.Diskon

                    bsPesanan.ResetBindings(False)
                    sudahAda = True
                    Exit For
                End If
            Next

            If Not sudahAda Then
                Dim diskon As Decimal = 0D
                If jumlah >= 100 Then
                    diskon = (harga * jumlah) * 0.1D
                End If
                Dim subtotal As Decimal = (harga * jumlah) - diskon
                bsPesanan.Add(New Pesanan(layanan, jumlah, harga, diskon, subtotal))
            End If

            Dim total As Decimal = 0D
            For Each psn As Pesanan In daftarPesanan
                total += psn.Subtotal
            Next
            lblTotal.Text = "Rp " & total.ToString("N0")

            cboLayanan.SelectedIndex = -1
            txtJumlah.Clear()
            errInput.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        Dim jawaban As DialogResult = MessageBox.Show(
            "Hapus semua pesanan?", "Transaksi Baru",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If jawaban = DialogResult.Yes Then
            bsPesanan.Clear()
            lblTotal.Text = "Rp 0"
        End If
    End Sub
End Class