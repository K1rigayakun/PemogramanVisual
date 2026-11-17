<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        nama = New TextBox()
        nim = New TextBox()
        kom = New TextBox()
        Tampilkan = New Button()
        Hapus = New Button()
        Keluar = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(123, 60)
        Label1.Name = "Label1"
        Label1.Size = New Size(49, 20)
        Label1.TabIndex = 0
        Label1.Text = "Nama"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(123, 134)
        Label2.Name = "Label2"
        Label2.Size = New Size(41, 20)
        Label2.TabIndex = 1
        Label2.Text = "KOM"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(123, 98)
        Label3.Name = "Label3"
        Label3.Size = New Size(37, 20)
        Label3.TabIndex = 2
        Label3.Text = "NIM"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(178, 60)
        Label4.Name = "Label4"
        Label4.Size = New Size(12, 20)
        Label4.TabIndex = 3
        Label4.Text = ":"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(178, 98)
        Label5.Name = "Label5"
        Label5.Size = New Size(12, 20)
        Label5.TabIndex = 4
        Label5.Text = ":"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(178, 134)
        Label6.Name = "Label6"
        Label6.Size = New Size(12, 20)
        Label6.TabIndex = 5
        Label6.Text = ":"
        ' 
        ' nama
        ' 
        nama.Location = New Point(196, 57)
        nama.Name = "nama"
        nama.Size = New Size(125, 27)
        nama.TabIndex = 6
        ' 
        ' nim
        ' 
        nim.Location = New Point(196, 95)
        nim.Name = "nim"
        nim.Size = New Size(125, 27)
        nim.TabIndex = 7
        ' 
        ' kom
        ' 
        kom.Location = New Point(196, 134)
        kom.Name = "kom"
        kom.Size = New Size(125, 27)
        kom.TabIndex = 8
        ' 
        ' Tampilkan
        ' 
        Tampilkan.Location = New Point(123, 178)
        Tampilkan.Name = "Tampilkan"
        Tampilkan.Size = New Size(94, 29)
        Tampilkan.TabIndex = 9
        Tampilkan.Text = "Tampilkan"
        Tampilkan.UseVisualStyleBackColor = True
        ' 
        ' Hapus
        ' 
        Hapus.Location = New Point(227, 178)
        Hapus.Name = "Hapus"
        Hapus.Size = New Size(94, 29)
        Hapus.TabIndex = 10
        Hapus.Text = "Hapus"
        Hapus.UseVisualStyleBackColor = True
        ' 
        ' Keluar
        ' 
        Keluar.Location = New Point(178, 213)
        Keluar.Name = "Keluar"
        Keluar.Size = New Size(94, 29)
        Keluar.TabIndex = 11
        Keluar.Text = "Keluar"
        Keluar.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Keluar)
        Controls.Add(Hapus)
        Controls.Add(Tampilkan)
        Controls.Add(kom)
        Controls.Add(nim)
        Controls.Add(nama)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents nama As TextBox
    Friend WithEvents nim As TextBox
    Friend WithEvents kom As TextBox
    Friend WithEvents Tampilkan As Button
    Friend WithEvents Hapus As Button
    Friend WithEvents Keluar As Button

End Class
