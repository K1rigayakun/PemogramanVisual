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
        components = New ComponentModel.Container()
        lblJudulForm = New Label()
        lblKodeBuku = New Label()
        txtKodeBuku = New TextBox()
        lblJudul = New Label()
        txtJudul = New TextBox()
        lblKategori = New Label()
        cboKategori = New ComboBox()
        lblNamaPeminjam = New Label()
        txtNamaPeminjam = New TextBox()
        lblLamaPinjam = New Label()
        txtLamaPinjam = New TextBox()
        btnPinjam = New Button()
        btnBersihkan = New Button()
        lblDaftarPeminjaman = New Label()
        lstPeminjaman = New ListBox()
        btnEkspor = New Button()
        lblStatus = New Label()
        errPinjam = New ErrorProvider(components)
        CType(errPinjam, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblJudulForm
        ' 
        lblJudulForm.AutoSize = True
        lblJudulForm.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblJudulForm.Location = New Point(25, 15)
        lblJudulForm.Name = "lblJudulForm"
        lblJudulForm.Size = New Size(220, 32)
        lblJudulForm.TabIndex = 0
        lblJudulForm.Text = "Peminjaman Buku"
        ' 
        ' lblKodeBuku
        ' 
        lblKodeBuku.AutoSize = True
        lblKodeBuku.Font = New Font("Segoe UI", 9.5F)
        lblKodeBuku.Location = New Point(25, 55)
        lblKodeBuku.Name = "lblKodeBuku"
        lblKodeBuku.Size = New Size(84, 21)
        lblKodeBuku.TabIndex = 1
        lblKodeBuku.Text = "Kode Buku"
        ' 
        ' txtKodeBuku
        ' 
        txtKodeBuku.Font = New Font("Segoe UI", 9.5F)
        txtKodeBuku.Location = New Point(25, 78)
        txtKodeBuku.Name = "txtKodeBuku"
        txtKodeBuku.Size = New Size(280, 29)
        txtKodeBuku.TabIndex = 2
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.Font = New Font("Segoe UI", 9.5F)
        lblJudul.Location = New Point(25, 115)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(86, 21)
        lblJudul.TabIndex = 3
        lblJudul.Text = "Judul Buku"
        ' 
        ' txtJudul
        ' 
        txtJudul.Font = New Font("Segoe UI", 9.5F)
        txtJudul.Location = New Point(25, 138)
        txtJudul.MaxLength = 150
        txtJudul.Name = "txtJudul"
        txtJudul.Size = New Size(280, 29)
        txtJudul.TabIndex = 4
        ' 
        ' lblKategori
        ' 
        lblKategori.AutoSize = True
        lblKategori.Font = New Font("Segoe UI", 9.5F)
        lblKategori.Location = New Point(25, 175)
        lblKategori.Name = "lblKategori"
        lblKategori.Size = New Size(68, 21)
        lblKategori.TabIndex = 5
        lblKategori.Text = "Kategori"
        ' 
        ' cboKategori
        ' 
        cboKategori.DropDownStyle = ComboBoxStyle.DropDownList
        cboKategori.Font = New Font("Segoe UI", 9.5F)
        cboKategori.FormattingEnabled = True
        cboKategori.Items.AddRange(New Object() {"Fiksi", "Nonfiksi", "Referensi", "Majalah"})
        cboKategori.Location = New Point(25, 198)
        cboKategori.Name = "cboKategori"
        cboKategori.Size = New Size(280, 29)
        cboKategori.TabIndex = 6
        ' 
        ' lblNamaPeminjam
        ' 
        lblNamaPeminjam.AutoSize = True
        lblNamaPeminjam.Font = New Font("Segoe UI", 9.5F)
        lblNamaPeminjam.Location = New Point(25, 235)
        lblNamaPeminjam.Name = "lblNamaPeminjam"
        lblNamaPeminjam.Size = New Size(125, 21)
        lblNamaPeminjam.TabIndex = 7
        lblNamaPeminjam.Text = "Nama Peminjam"
        ' 
        ' txtNamaPeminjam
        ' 
        txtNamaPeminjam.Font = New Font("Segoe UI", 9.5F)
        txtNamaPeminjam.Location = New Point(25, 258)
        txtNamaPeminjam.MaxLength = 100
        txtNamaPeminjam.Name = "txtNamaPeminjam"
        txtNamaPeminjam.Size = New Size(280, 29)
        txtNamaPeminjam.TabIndex = 8
        ' 
        ' lblLamaPinjam
        ' 
        lblLamaPinjam.AutoSize = True
        lblLamaPinjam.Font = New Font("Segoe UI", 9.5F)
        lblLamaPinjam.Location = New Point(25, 295)
        lblLamaPinjam.Name = "lblLamaPinjam"
        lblLamaPinjam.Size = New Size(141, 21)
        lblLamaPinjam.TabIndex = 9
        lblLamaPinjam.Text = "Lama Pinjam (hari)"
        ' 
        ' txtLamaPinjam
        ' 
        txtLamaPinjam.Font = New Font("Segoe UI", 9.5F)
        txtLamaPinjam.Location = New Point(25, 318)
        txtLamaPinjam.MaxLength = 5
        txtLamaPinjam.Name = "txtLamaPinjam"
        txtLamaPinjam.Size = New Size(280, 29)
        txtLamaPinjam.TabIndex = 10
        ' 
        ' btnPinjam
        ' 
        btnPinjam.Font = New Font("Segoe UI", 9.5F)
        btnPinjam.Location = New Point(25, 365)
        btnPinjam.Name = "btnPinjam"
        btnPinjam.Size = New Size(135, 36)
        btnPinjam.TabIndex = 11
        btnPinjam.Text = "Pinjam"
        btnPinjam.UseVisualStyleBackColor = True
        ' 
        ' btnBersihkan
        ' 
        btnBersihkan.CausesValidation = False
        btnBersihkan.Font = New Font("Segoe UI", 9.5F)
        btnBersihkan.Location = New Point(170, 365)
        btnBersihkan.Name = "btnBersihkan"
        btnBersihkan.Size = New Size(135, 36)
        btnBersihkan.TabIndex = 12
        btnBersihkan.Text = "Bersihkan"
        btnBersihkan.UseVisualStyleBackColor = True
        ' 
        ' lblDaftarPeminjaman
        ' 
        lblDaftarPeminjaman.AutoSize = True
        lblDaftarPeminjaman.Font = New Font("Segoe UI", 9.5F)
        lblDaftarPeminjaman.Location = New Point(345, 55)
        lblDaftarPeminjaman.Name = "lblDaftarPeminjaman"
        lblDaftarPeminjaman.Size = New Size(144, 21)
        lblDaftarPeminjaman.TabIndex = 13
        lblDaftarPeminjaman.Text = "Daftar peminjaman"
        ' 
        ' lstPeminjaman
        ' 
        lstPeminjaman.Font = New Font("Segoe UI", 9.5F)
        lstPeminjaman.FormattingEnabled = True
        lstPeminjaman.HorizontalScrollbar = True
        lstPeminjaman.IntegralHeight = False
        lstPeminjaman.Location = New Point(345, 78)
        lstPeminjaman.Name = "lstPeminjaman"
        lstPeminjaman.Size = New Size(430, 269)
        lstPeminjaman.TabIndex = 14
        ' 
        ' btnEkspor
        ' 
        btnEkspor.CausesValidation = False
        btnEkspor.Font = New Font("Segoe UI", 9.5F)
        btnEkspor.Location = New Point(345, 365)
        btnEkspor.Name = "btnEkspor"
        btnEkspor.Size = New Size(430, 36)
        btnEkspor.TabIndex = 15
        btnEkspor.Text = "Ekspor ke CSV"
        btnEkspor.UseVisualStyleBackColor = True
        ' 
        ' lblStatus
        ' 
        lblStatus.BackColor = Color.Transparent
        lblStatus.Font = New Font("Segoe UI", 9.5F)
        lblStatus.Location = New Point(0, 411)
        lblStatus.Name = "lblStatus"
        lblStatus.Padding = New Padding(10, 0, 0, 0)
        lblStatus.Size = New Size(800, 35)
        lblStatus.TabIndex = 16
        lblStatus.Text = "Jumlah peminjaman: 0"
        lblStatus.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' errPinjam
        ' 
        errPinjam.ContainerControl = Me
        ' 
        ' Form1
        ' 
        AcceptButton = btnPinjam
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 455)
        Controls.Add(lblStatus)
        Controls.Add(btnEkspor)
        Controls.Add(lstPeminjaman)
        Controls.Add(lblDaftarPeminjaman)
        Controls.Add(btnBersihkan)
        Controls.Add(btnPinjam)
        Controls.Add(txtLamaPinjam)
        Controls.Add(lblLamaPinjam)
        Controls.Add(txtNamaPeminjam)
        Controls.Add(lblNamaPeminjam)
        Controls.Add(cboKategori)
        Controls.Add(lblKategori)
        Controls.Add(txtJudul)
        Controls.Add(lblJudul)
        Controls.Add(txtKodeBuku)
        Controls.Add(lblKodeBuku)
        Controls.Add(lblJudulForm)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Peminjaman Buku"
        CType(errPinjam, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudulForm As Label
    Friend WithEvents lblKodeBuku As Label
    Friend WithEvents txtKodeBuku As TextBox
    Friend WithEvents lblJudul As Label
    Friend WithEvents txtJudul As TextBox
    Friend WithEvents lblKategori As Label
    Friend WithEvents cboKategori As ComboBox
    Friend WithEvents lblNamaPeminjam As Label
    Friend WithEvents txtNamaPeminjam As TextBox
    Friend WithEvents lblLamaPinjam As Label
    Friend WithEvents txtLamaPinjam As TextBox
    Friend WithEvents btnPinjam As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents lblDaftarPeminjaman As Label
    Friend WithEvents lstPeminjaman As ListBox
    Friend WithEvents btnEkspor As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents errPinjam As ErrorProvider

End Class
