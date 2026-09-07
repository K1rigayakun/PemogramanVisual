Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class login

    Private Nama() As String = {"michael", "fikri", "malik"}
    Private NIM() As String = {"241712042", "241712026", "241712027"}
    Private Role() As String = {"Staff", "Manajer", "Staff"}


    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim path As New Drawing2D.GraphicsPath()
        path.AddEllipse(0, 0, pictBox.Width, pictBox.Height)
        pictBox.Region = New Region(path)
        rolePilih.SelectedIndex = 0
    End Sub

    Private Sub pictBox_Click(sender As Object, e As EventArgs) Handles pictBox.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub rolePilih_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rolePilih.SelectedIndexChanged
        Select Case rolePilih.SelectedItem.ToString()
            Case "Staff"
                pictBox.Image = Image.FromFile("assets\staff.png")
            Case "Manajer"
                pictBox.Image = Image.FromFile("assets\manager.png")
        End Select
    End Sub

    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNIM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNIM.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNama_TextChanged(sender As Object, e As EventArgs) Handles txtNama.TextChanged

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Nama anda belum terisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNama.BackColor = Color.MistyRose
            txtNama.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtNIM.Text) Then
            MessageBox.Show("NIM anda belum terisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNIM.BackColor = Color.MistyRose
            txtNIM.Focus()
            Return
        End If

        txtNama.BackColor = Color.White
        txtNIM.BackColor = Color.White

        Dim namaInput As String = txtNama.Text.Trim().ToLower()
        Dim nimInput As String = txtNIM.Text.Trim()
        Dim roleInput As String = rolePilih.SelectedItem.ToString()

        Dim status As Boolean = False

        For i As Integer = 0 To Nama.Length - 1
            If Nama(i) = namaInput AndAlso NIM(i) = nimInput AndAlso Role(i) = roleInput Then
                status = True
                Exit For
            End If
        Next

        If status Then
            MessageBox.Show("Login Berhasil")
            Me.Hide()
            hitungpajak.Show()
        Else
            MessageBox.Show("Nama, NIM, atau Role tidak sesuai dengan data yang terdaftar!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNama.BackColor = Color.MistyRose
            txtNIM.BackColor = Color.MistyRose
        End If


    End Sub
End Class