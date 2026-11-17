Public Class Form1
    Private Sub Keluar_Click(sender As Object, e As EventArgs) Handles Keluar.Click
        Me.Close()
    End Sub

    Private Sub Tampilkan_Click(sender As Object, e As EventArgs) Handles Tampilkan.Click
        MessageBox.Show("Halo, " & vbCrLf &
                        "Nama : " & nama.Text & vbCrLf &
                        "NIM  : " & nim.Text & vbCrLf &
                        "KOM  : " & kom.Text
        )
    End Sub

    Private Sub Hapus_Click(sender As Object, e As EventArgs) Handles Hapus.Click
        nama.Clear()
        nim.Clear()
        kom.Clear()
    End Sub
End Class
