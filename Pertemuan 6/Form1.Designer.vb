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
        btnTampilkan = New Button()
        dgvMahasiswa = New DataGridView()
        btnTambah = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        txtNIM = New TextBox()
        txtNama = New TextBox()
        txtJurusan = New TextBox()
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnTampilkan
        ' 
        btnTampilkan.Location = New Point(137, 334)
        btnTampilkan.Name = "btnTampilkan"
        btnTampilkan.Size = New Size(125, 29)
        btnTampilkan.TabIndex = 0
        btnTampilkan.Text = "Tampilkan"
        btnTampilkan.UseVisualStyleBackColor = True
        ' 
        ' dgvMahasiswa
        ' 
        dgvMahasiswa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMahasiswa.Location = New Point(12, 36)
        dgvMahasiswa.Name = "dgvMahasiswa"
        dgvMahasiswa.RowHeadersWidth = 51
        dgvMahasiswa.Size = New Size(400, 280)
        dgvMahasiswa.TabIndex = 1
        ' 
        ' btnTambah
        ' 
        btnTambah.Location = New Point(564, 287)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(125, 29)
        btnTambah.TabIndex = 2
        btnTambah.Text = "Tambah"
        btnTambah.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(444, 214)
        Label1.Name = "Label1"
        Label1.Size = New Size(57, 20)
        Label1.TabIndex = 3
        Label1.Text = "Jurusan"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(444, 156)
        Label2.Name = "Label2"
        Label2.Size = New Size(37, 20)
        Label2.TabIndex = 4
        Label2.Text = "NIM"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(444, 103)
        Label3.Name = "Label3"
        Label3.Size = New Size(49, 20)
        Label3.TabIndex = 5
        Label3.Text = "Nama"
        ' 
        ' txtNIM
        ' 
        txtNIM.Location = New Point(503, 153)
        txtNIM.Name = "txtNIM"
        txtNIM.Size = New Size(256, 27)
        txtNIM.TabIndex = 6
        ' 
        ' txtNama
        ' 
        txtNama.Location = New Point(503, 100)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(256, 27)
        txtNama.TabIndex = 7
        ' 
        ' txtJurusan
        ' 
        txtJurusan.Location = New Point(503, 211)
        txtJurusan.Name = "txtJurusan"
        txtJurusan.Size = New Size(256, 27)
        txtJurusan.TabIndex = 8
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(txtJurusan)
        Controls.Add(txtNama)
        Controls.Add(txtNIM)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnTambah)
        Controls.Add(dgvMahasiswa)
        Controls.Add(btnTampilkan)
        Name = "Form1"
        Text = "Form1"
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnTampilkan As Button
    Friend WithEvents dgvMahasiswa As DataGridView
    Friend WithEvents btnTambah As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNIM As TextBox
    Friend WithEvents txtNama As TextBox
    Friend WithEvents txtJurusan As TextBox

End Class
