Public Class Form1
    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
        Dim nilai As Integer
        If Not Integer.TryParse(txtNilai.Text, nilai) Then
            MessageBox.Show("Masukkan Nilai yang benar")
            txtNilai.Focus()
            Return
        End If

        If nilai < 0 OrElse nilai > 100 Then
            MessageBox.Show("Hanya 0-100")
            txtNilai.Focus()
            Return
        End If

        If nilai <= 50 Then
            picImage.Image = Image.FromFile("Assets\1.gif")

        ElseIf nilai <= 70 Then
            picImage.Image = Image.FromFile("Assets\2.gif")

        Else
            picImage.Image = Image.FromFile("Assets\3.jpg")

        End If

    End Sub

    Private Sub txtNilai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilai.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub picImage_Click(sender As Object, e As EventArgs) Handles picImage.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class
