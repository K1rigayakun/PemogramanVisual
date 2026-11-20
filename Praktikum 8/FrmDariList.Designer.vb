<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDariList
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        lblJudul = New Label()
        lblNim = New Label()
        lblNama = New Label()
        lblJurusan = New Label()
        lblAngkatan = New Label()
        lblIpk = New Label()
        txtNim = New TextBox()
        txtNama = New TextBox()
        cboJurusan = New ComboBox()
        txtAngkatan = New TextBox()
        txtIpk = New TextBox()
        btnTambah = New Button()
        dgvMahasiswa = New DataGridView()
        lblJumlah = New Label()
        bsMahasiswa = New BindingSource(components)
        errInput = New ErrorProvider(components)
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
        CType(bsMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
        CType(errInput, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        ' lblJudul
        '
        lblJudul.AutoSize = True
        lblJudul.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        lblJudul.Location = New Point(16, 14)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(280, 25)
        lblJudul.TabIndex = 0
        lblJudul.Text = "Data dari List(Of Mahasiswa)"
        '
        ' lblNim
        '
        lblNim.AutoSize = True
        lblNim.Location = New Point(16, 56)
        lblNim.Name = "lblNim"
        lblNim.Size = New Size(30, 15)
        lblNim.TabIndex = 1
        lblNim.Text = "NIM"
        '
        ' lblNama
        '
        lblNama.AutoSize = True
        lblNama.Location = New Point(16, 94)
        lblNama.Name = "lblNama"
        lblNama.Size = New Size(39, 15)
        lblNama.TabIndex = 2
        lblNama.Text = "Nama"
        '
        ' lblJurusan
        '
        lblJurusan.AutoSize = True
        lblJurusan.Location = New Point(16, 132)
        lblJurusan.Name = "lblJurusan"
        lblJurusan.Size = New Size(47, 15)
        lblJurusan.TabIndex = 3
        lblJurusan.Text = "Jurusan"
        '
        ' lblAngkatan
        '
        lblAngkatan.AutoSize = True
        lblAngkatan.Location = New Point(16, 170)
        lblAngkatan.Name = "lblAngkatan"
        lblAngkatan.Size = New Size(58, 15)
        lblAngkatan.TabIndex = 4
        lblAngkatan.Text = "Angkatan"
        '
        ' lblIpk
        '
        lblIpk.AutoSize = True
        lblIpk.Location = New Point(16, 208)
        lblIpk.Name = "lblIpk"
        lblIpk.Size = New Size(24, 15)
        lblIpk.TabIndex = 5
        lblIpk.Text = "IPK"
        '
        ' txtNim
        '
        txtNim.Location = New Point(96, 53)
        txtNim.MaxLength = 9
        txtNim.Name = "txtNim"
        txtNim.Size = New Size(190, 23)
        txtNim.TabIndex = 6
        '
        ' txtNama
        '
        txtNama.Location = New Point(96, 91)
        txtNama.MaxLength = 100
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(190, 23)
        txtNama.TabIndex = 7
        '
        ' cboJurusan
        '
        cboJurusan.DropDownStyle = ComboBoxStyle.DropDownList
        cboJurusan.FormattingEnabled = True
        cboJurusan.Items.AddRange(New Object() {"Teknik Informatika", "Sistem Informasi", "Manajemen Informatika", "Teknik Komputer"})
        cboJurusan.Location = New Point(96, 129)
        cboJurusan.Name = "cboJurusan"
        cboJurusan.Size = New Size(190, 23)
        cboJurusan.TabIndex = 8
        '
        ' txtAngkatan
        '
        txtAngkatan.Location = New Point(96, 167)
        txtAngkatan.MaxLength = 4
        txtAngkatan.Name = "txtAngkatan"
        txtAngkatan.Size = New Size(190, 23)
        txtAngkatan.TabIndex = 9
        '
        ' txtIpk
        '
        txtIpk.Location = New Point(96, 205)
        txtIpk.MaxLength = 4
        txtIpk.Name = "txtIpk"
        txtIpk.Size = New Size(190, 23)
        txtIpk.TabIndex = 10
        '
        ' btnTambah
        '
        btnTambah.Location = New Point(96, 246)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(190, 32)
        btnTambah.TabIndex = 11
        btnTambah.Text = "Tambah ke List"
        btnTambah.UseVisualStyleBackColor = True
        '
        ' dgvMahasiswa
        '
        dgvMahasiswa.AllowUserToAddRows = False
        dgvMahasiswa.AllowUserToDeleteRows = False
        dgvMahasiswa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMahasiswa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMahasiswa.Location = New Point(316, 53)
        dgvMahasiswa.MultiSelect = False
        dgvMahasiswa.Name = "dgvMahasiswa"
        dgvMahasiswa.ReadOnly = True
        dgvMahasiswa.RowHeadersVisible = False
        dgvMahasiswa.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMahasiswa.Size = New Size(560, 260)
        dgvMahasiswa.TabIndex = 12
        '
        ' lblJumlah
        '
        lblJumlah.Location = New Point(640, 326)
        lblJumlah.Name = "lblJumlah"
        lblJumlah.Size = New Size(236, 20)
        lblJumlah.TabIndex = 13
        lblJumlah.Text = "Jumlah data: 0"
        lblJumlah.TextAlign = ContentAlignment.MiddleRight
        '
        ' errInput
        '
        errInput.ContainerControl = Me
        '
        ' FrmDariList
        '
        AcceptButton = btnTambah
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(892, 362)
        Controls.Add(lblJumlah)
        Controls.Add(dgvMahasiswa)
        Controls.Add(btnTambah)
        Controls.Add(txtIpk)
        Controls.Add(txtAngkatan)
        Controls.Add(cboJurusan)
        Controls.Add(txtNama)
        Controls.Add(txtNim)
        Controls.Add(lblIpk)
        Controls.Add(lblAngkatan)
        Controls.Add(lblJurusan)
        Controls.Add(lblNama)
        Controls.Add(lblNim)
        Controls.Add(lblJudul)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FrmDariList"
        StartPosition = FormStartPosition.CenterParent
        Text = "Binding List(Of Mahasiswa)"
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).EndInit()
        CType(bsMahasiswa, ComponentModel.ISupportInitialize).EndInit()
        CType(errInput, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents lblNim As Label
    Friend WithEvents lblNama As Label
    Friend WithEvents lblJurusan As Label
    Friend WithEvents lblAngkatan As Label
    Friend WithEvents lblIpk As Label
    Friend WithEvents txtNim As TextBox
    Friend WithEvents txtNama As TextBox
    Friend WithEvents cboJurusan As ComboBox
    Friend WithEvents txtAngkatan As TextBox
    Friend WithEvents txtIpk As TextBox
    Friend WithEvents btnTambah As Button
    Friend WithEvents dgvMahasiswa As DataGridView
    Friend WithEvents lblJumlah As Label
    Friend WithEvents bsMahasiswa As BindingSource
    Friend WithEvents errInput As ErrorProvider
End Class
