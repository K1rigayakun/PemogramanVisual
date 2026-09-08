Public Class hitungpajak
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub


    Private Sub txtPend_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPend.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnHitung_Click(sender As Object, e As EventArgs) Handles btnHitung.Click

        Dim pendapatan As Long = Convert.ToInt64(txtPend.Text)
        Dim persenPajak As Double = 0
        Dim jumlahPajak As Double = 0

        If pendapatan > 100000000 Then
            persenPajak = 30
        ElseIf pendapatan > 30000000 Then
            persenPajak = 20
        ElseIf pendapatan > 5000000 Then
            persenPajak = 10
        Else
            persenPajak = 0
        End If

        jumlahPajak = pendapatan * (persenPajak / 100)

        MessageBox.Show("Pendapatan: Rp " & pendapatan.ToString("N0", New Globalization.CultureInfo("id-ID")) & vbCrLf &
                         "Pajak: " & persenPajak & "%" & vbCrLf &
                         "Jumlah Pajak: Rp " & jumlahPajak.ToString("N0", New Globalization.CultureInfo("id-ID")), "Informasi")


    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        login.Show()
        login.txtNIM.Clear()
        login.txtNama.Clear()

    End Sub
End Class