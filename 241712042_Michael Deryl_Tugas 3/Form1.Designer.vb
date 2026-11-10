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
        lblPenulis = New Label()
        txtPenulis = New TextBox()
        lblKategori = New Label()
        cboKategori = New ComboBox()
        lblTahun = New Label()
        txtTahun = New TextBox()
        lblStok = New Label()
        txtStok = New TextBox()
        btnTambah = New Button()
        btnBersihkan = New Button()
        lblCari = New Label()
        txtCari = New TextBox()
        lblFilterKategori = New Label()
        cboFilterKategori = New ComboBox()
        lblUrut = New Label()
        cboUrut = New ComboBox()
        chkStokHabis = New CheckBox()
        dgvBuku = New DataGridView()
        lblJumlah = New Label()
        lblTotalStok = New Label()
        bsBuku = New BindingSource(components)
        errBuku = New ErrorProvider(components)
        CType(dgvBuku, ComponentModel.ISupportInitialize).BeginInit()
        CType(bsBuku, ComponentModel.ISupportInitialize).BeginInit()
        CType(errBuku, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblJudulForm
        ' 
        lblJudulForm.AutoSize = True
        lblJudulForm.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        lblJudulForm.Location = New Point(20, 15)
        lblJudulForm.Name = "lblJudulForm"
        lblJudulForm.Size = New Size(364, 35)
        lblJudulForm.TabIndex = 0
        lblJudulForm.Text = "Inventaris Buku Perpustakaan"
        ' 
        ' lblKodeBuku
        ' 
        lblKodeBuku.AutoSize = True
        lblKodeBuku.Font = New Font("Segoe UI", 9.5F)
        lblKodeBuku.Location = New Point(17, 63)
        lblKodeBuku.Name = "lblKodeBuku"
        lblKodeBuku.Size = New Size(84, 21)
        lblKodeBuku.TabIndex = 1
        lblKodeBuku.Text = "Kode Buku"
        ' 
        ' txtKodeBuku
        ' 
        txtKodeBuku.Font = New Font("Segoe UI", 9.5F)
        txtKodeBuku.Location = New Point(17, 86)
        txtKodeBuku.MaxLength = 6
        txtKodeBuku.Name = "txtKodeBuku"
        txtKodeBuku.Size = New Size(260, 29)
        txtKodeBuku.TabIndex = 2
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.Font = New Font("Segoe UI", 9.5F)
        lblJudul.Location = New Point(17, 148)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(86, 21)
        lblJudul.TabIndex = 3
        lblJudul.Text = "Judul Buku"
        ' 
        ' txtJudul
        ' 
        txtJudul.Font = New Font("Segoe UI", 9.5F)
        txtJudul.Location = New Point(17, 171)
        txtJudul.MaxLength = 150
        txtJudul.Name = "txtJudul"
        txtJudul.Size = New Size(260, 29)
        txtJudul.TabIndex = 4
        ' 
        ' lblPenulis
        ' 
        lblPenulis.AutoSize = True
        lblPenulis.Font = New Font("Segoe UI", 9.5F)
        lblPenulis.Location = New Point(17, 241)
        lblPenulis.Name = "lblPenulis"
        lblPenulis.Size = New Size(59, 21)
        lblPenulis.TabIndex = 5
        lblPenulis.Text = "Penulis"
        ' 
        ' txtPenulis
        ' 
        txtPenulis.Font = New Font("Segoe UI", 9.5F)
        txtPenulis.Location = New Point(17, 264)
        txtPenulis.MaxLength = 100
        txtPenulis.Name = "txtPenulis"
        txtPenulis.Size = New Size(260, 29)
        txtPenulis.TabIndex = 6
        ' 
        ' lblKategori
        ' 
        lblKategori.AutoSize = True
        lblKategori.Font = New Font("Segoe UI", 9.5F)
        lblKategori.Location = New Point(17, 331)
        lblKategori.Name = "lblKategori"
        lblKategori.Size = New Size(68, 21)
        lblKategori.TabIndex = 7
        lblKategori.Text = "Kategori"
        ' 
        ' cboKategori
        ' 
        cboKategori.DropDownStyle = ComboBoxStyle.DropDownList
        cboKategori.Font = New Font("Segoe UI", 9.5F)
        cboKategori.FormattingEnabled = True
        cboKategori.Items.AddRange(New Object() {"Fiksi", "Nonfiksi", "Referensi", "Majalah"})
        cboKategori.Location = New Point(17, 354)
        cboKategori.Name = "cboKategori"
        cboKategori.Size = New Size(260, 29)
        cboKategori.TabIndex = 8
        ' 
        ' lblTahun
        ' 
        lblTahun.AutoSize = True
        lblTahun.Font = New Font("Segoe UI", 9.5F)
        lblTahun.Location = New Point(17, 421)
        lblTahun.Name = "lblTahun"
        lblTahun.Size = New Size(93, 21)
        lblTahun.TabIndex = 9
        lblTahun.Text = "Tahun Terbit"
        ' 
        ' txtTahun
        ' 
        txtTahun.Font = New Font("Segoe UI", 9.5F)
        txtTahun.Location = New Point(17, 444)
        txtTahun.MaxLength = 4
        txtTahun.Name = "txtTahun"
        txtTahun.Size = New Size(260, 29)
        txtTahun.TabIndex = 10
        ' 
        ' lblStok
        ' 
        lblStok.AutoSize = True
        lblStok.Font = New Font("Segoe UI", 9.5F)
        lblStok.Location = New Point(17, 502)
        lblStok.Name = "lblStok"
        lblStok.Size = New Size(94, 21)
        lblStok.TabIndex = 11
        lblStok.Text = "Jumlah Stok"
        ' 
        ' txtStok
        ' 
        txtStok.Font = New Font("Segoe UI", 9.5F)
        txtStok.Location = New Point(17, 525)
        txtStok.MaxLength = 6
        txtStok.Name = "txtStok"
        txtStok.Size = New Size(260, 29)
        txtStok.TabIndex = 12
        ' 
        ' btnTambah
        ' 
        btnTambah.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
        btnTambah.Location = New Point(17, 569)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(125, 36)
        btnTambah.TabIndex = 13
        btnTambah.Text = "Tambah"
        btnTambah.UseVisualStyleBackColor = True
        ' 
        ' btnBersihkan
        ' 
        btnBersihkan.CausesValidation = False
        btnBersihkan.Font = New Font("Segoe UI", 9.5F)
        btnBersihkan.Location = New Point(152, 569)
        btnBersihkan.Name = "btnBersihkan"
        btnBersihkan.Size = New Size(125, 36)
        btnBersihkan.TabIndex = 14
        btnBersihkan.Text = "Bersihkan"
        btnBersihkan.UseVisualStyleBackColor = True
        ' 
        ' lblCari
        ' 
        lblCari.AutoSize = True
        lblCari.Font = New Font("Segoe UI", 9.5F)
        lblCari.Location = New Point(307, 63)
        lblCari.Name = "lblCari"
        lblCari.Size = New Size(147, 21)
        lblCari.TabIndex = 15
        lblCari.Text = "Cari (Judul/Penulis):"
        ' 
        ' txtCari
        ' 
        txtCari.Font = New Font("Segoe UI", 9.5F)
        txtCari.Location = New Point(307, 86)
        txtCari.Name = "txtCari"
        txtCari.Size = New Size(650, 29)
        txtCari.TabIndex = 16
        ' 
        ' lblFilterKategori
        ' 
        lblFilterKategori.AutoSize = True
        lblFilterKategori.Font = New Font("Segoe UI", 9.5F)
        lblFilterKategori.Location = New Point(307, 128)
        lblFilterKategori.Name = "lblFilterKategori"
        lblFilterKategori.Size = New Size(71, 21)
        lblFilterKategori.TabIndex = 17
        lblFilterKategori.Text = "Kategori:"
        ' 
        ' cboFilterKategori
        ' 
        cboFilterKategori.DropDownStyle = ComboBoxStyle.DropDownList
        cboFilterKategori.Font = New Font("Segoe UI", 9.5F)
        cboFilterKategori.FormattingEnabled = True
        cboFilterKategori.Items.AddRange(New Object() {"Semua", "Fiksi", "Nonfiksi", "Referensi", "Majalah"})
        cboFilterKategori.Location = New Point(304, 152)
        cboFilterKategori.Name = "cboFilterKategori"
        cboFilterKategori.Size = New Size(198, 29)
        cboFilterKategori.TabIndex = 18
        ' 
        ' lblUrut
        ' 
        lblUrut.AutoSize = True
        lblUrut.Font = New Font("Segoe UI", 9.5F)
        lblUrut.Location = New Point(689, 128)
        lblUrut.Name = "lblUrut"
        lblUrut.Size = New Size(69, 21)
        lblUrut.TabIndex = 19
        lblUrut.Text = "Urutkan:"
        ' 
        ' cboUrut
        ' 
        cboUrut.DropDownStyle = ComboBoxStyle.DropDownList
        cboUrut.Font = New Font("Segoe UI", 9.5F)
        cboUrut.FormattingEnabled = True
        cboUrut.Items.AddRange(New Object() {"Urutan awal", "Judul A-Z", "Tahun terbaru", "Stok terbanyak"})
        cboUrut.Location = New Point(689, 152)
        cboUrut.Name = "cboUrut"
        cboUrut.Size = New Size(268, 29)
        cboUrut.TabIndex = 20
        ' 
        ' chkStokHabis
        ' 
        chkStokHabis.AutoSize = True
        chkStokHabis.Font = New Font("Segoe UI", 9.5F)
        chkStokHabis.Location = New Point(508, 152)
        chkStokHabis.Name = "chkStokHabis"
        chkStokHabis.Size = New Size(150, 25)
        chkStokHabis.TabIndex = 21
        chkStokHabis.Text = "Hanya stok habis"
        chkStokHabis.UseVisualStyleBackColor = True
        ' 
        ' dgvBuku
        ' 
        dgvBuku.AllowUserToAddRows = False
        dgvBuku.AllowUserToDeleteRows = False
        dgvBuku.AllowUserToResizeRows = False
        dgvBuku.BackgroundColor = Color.White
        dgvBuku.BorderStyle = BorderStyle.Fixed3D
        dgvBuku.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBuku.Location = New Point(304, 206)
        dgvBuku.MultiSelect = False
        dgvBuku.Name = "dgvBuku"
        dgvBuku.ReadOnly = True
        dgvBuku.RowHeadersVisible = False
        dgvBuku.RowHeadersWidth = 51
        dgvBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvBuku.Size = New Size(653, 317)
        dgvBuku.TabIndex = 22
        ' 
        ' lblJumlah
        ' 
        lblJumlah.AutoSize = True
        lblJumlah.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblJumlah.Location = New Point(307, 552)
        lblJumlah.Name = "lblJumlah"
        lblJumlah.Size = New Size(218, 23)
        lblJumlah.TabIndex = 23
        lblJumlah.Text = "Menampilkan 0 dari 0 buku"
        ' 
        ' lblTotalStok
        ' 
        lblTotalStok.AutoSize = True
        lblTotalStok.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTotalStok.Location = New Point(307, 582)
        lblTotalStok.Name = "lblTotalStok"
        lblTotalStok.Size = New Size(100, 23)
        lblTotalStok.TabIndex = 24
        lblTotalStok.Text = "Total stok: 0"
        ' 
        ' errBuku
        ' 
        errBuku.ContainerControl = Me
        ' 
        ' Form1
        ' 
        AcceptButton = btnTambah
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(980, 625)
        Controls.Add(lblTotalStok)
        Controls.Add(lblJumlah)
        Controls.Add(dgvBuku)
        Controls.Add(chkStokHabis)
        Controls.Add(cboUrut)
        Controls.Add(lblUrut)
        Controls.Add(cboFilterKategori)
        Controls.Add(lblFilterKategori)
        Controls.Add(txtCari)
        Controls.Add(lblCari)
        Controls.Add(btnBersihkan)
        Controls.Add(btnTambah)
        Controls.Add(txtStok)
        Controls.Add(lblStok)
        Controls.Add(txtTahun)
        Controls.Add(lblTahun)
        Controls.Add(cboKategori)
        Controls.Add(lblKategori)
        Controls.Add(txtPenulis)
        Controls.Add(lblPenulis)
        Controls.Add(txtJudul)
        Controls.Add(lblJudul)
        Controls.Add(txtKodeBuku)
        Controls.Add(lblKodeBuku)
        Controls.Add(lblJudulForm)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Inventaris Buku Perpustakaan"
        CType(dgvBuku, ComponentModel.ISupportInitialize).EndInit()
        CType(bsBuku, ComponentModel.ISupportInitialize).EndInit()
        CType(errBuku, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudulForm As Label
    Friend WithEvents lblKodeBuku As Label
    Friend WithEvents txtKodeBuku As TextBox
    Friend WithEvents lblJudul As Label
    Friend WithEvents txtJudul As TextBox
    Friend WithEvents lblPenulis As Label
    Friend WithEvents txtPenulis As TextBox
    Friend WithEvents lblKategori As Label
    Friend WithEvents cboKategori As ComboBox
    Friend WithEvents lblTahun As Label
    Friend WithEvents txtTahun As TextBox
    Friend WithEvents lblStok As Label
    Friend WithEvents txtStok As TextBox
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents lblCari As Label
    Friend WithEvents txtCari As TextBox
    Friend WithEvents lblFilterKategori As Label
    Friend WithEvents cboFilterKategori As ComboBox
    Friend WithEvents lblUrut As Label
    Friend WithEvents cboUrut As ComboBox
    Friend WithEvents chkStokHabis As CheckBox
    Friend WithEvents dgvBuku As DataGridView
    Friend WithEvents bsBuku As BindingSource
    Friend WithEvents lblJumlah As Label
    Friend WithEvents lblTotalStok As Label
    Friend WithEvents errBuku As ErrorProvider

End Class
