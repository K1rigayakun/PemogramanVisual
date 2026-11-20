<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPendaftaran
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
        btnSimpan = New Button()
        btnBersihkan = New Button()
        lblDaftar = New Label()
        lstMahasiswa = New ListBox()
        btnEkspor = New Button()
        lblStatus = New Label()
        errInput = New ErrorProvider(components)
        CType(errInput, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        ' lblJudul
        '
        lblJudul.AutoSize = True
        lblJudul.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblJudul.Location = New Point(16, 14)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(220, 25)
        lblJudul.TabIndex = 0
        lblJudul.Text = "Pendaftaran Mahasiswa"
        '
        ' lblNim
        '
        lblNim.AutoSize = True
        lblNim.Location = New Point(16, 62)
        lblNim.Name = "lblNim"
        lblNim.Size = New Size(30, 15)
        lblNim.TabIndex = 1
        lblNim.Text = "NIM"
        '
        ' lblNama
        '
        lblNama.AutoSize = True
        lblNama.Location = New Point(16, 102)
        lblNama.Name = "lblNama"
        lblNama.Size = New Size(39, 15)
        lblNama.TabIndex = 2
        lblNama.Text = "Nama"
        '
        ' lblJurusan
        '
        lblJurusan.AutoSize = True
        lblJurusan.Location = New Point(16, 142)
        lblJurusan.Name = "lblJurusan"
        lblJurusan.Size = New Size(47, 15)
        lblJurusan.TabIndex = 3
        lblJurusan.Text = "Jurusan"
        '
        ' lblAngkatan
        '
        lblAngkatan.AutoSize = True
        lblAngkatan.Location = New Point(16, 182)
        lblAngkatan.Name = "lblAngkatan"
        lblAngkatan.Size = New Size(58, 15)
        lblAngkatan.TabIndex = 4
        lblAngkatan.Text = "Angkatan"
        '
        ' lblIpk
        '
        lblIpk.AutoSize = True
        lblIpk.Location = New Point(16, 222)
        lblIpk.Name = "lblIpk"
        lblIpk.Size = New Size(24, 15)
        lblIpk.TabIndex = 5
        lblIpk.Text = "IPK"
        '
        ' txtNim
        '
        txtNim.Location = New Point(104, 59)
        txtNim.MaxLength = 9
        txtNim.Name = "txtNim"
        txtNim.Size = New Size(216, 23)
        txtNim.TabIndex = 6
        '
        ' txtNama
        '
        txtNama.Location = New Point(104, 99)
        txtNama.MaxLength = 100
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(216, 23)
        txtNama.TabIndex = 7
        '
        ' cboJurusan
        '
        cboJurusan.DropDownStyle = ComboBoxStyle.DropDownList
        cboJurusan.FormattingEnabled = True
        cboJurusan.Items.AddRange(New Object() {"Teknik Informatika", "Sistem Informasi", "Manajemen Informatika", "Teknik Komputer"})
        cboJurusan.Location = New Point(104, 139)
        cboJurusan.Name = "cboJurusan"
        cboJurusan.Size = New Size(216, 23)
        cboJurusan.TabIndex = 8
        '
        ' txtAngkatan
        '
        txtAngkatan.Location = New Point(104, 179)
        txtAngkatan.MaxLength = 4
        txtAngkatan.Name = "txtAngkatan"
        txtAngkatan.Size = New Size(216, 23)
        txtAngkatan.TabIndex = 9
        '
        ' txtIpk
        '
        txtIpk.Location = New Point(104, 219)
        txtIpk.MaxLength = 4
        txtIpk.Name = "txtIpk"
        txtIpk.Size = New Size(216, 23)
        txtIpk.TabIndex = 10
        '
        ' btnSimpan
        '
        btnSimpan.Location = New Point(104, 264)
        btnSimpan.Name = "btnSimpan"
        btnSimpan.Size = New Size(100, 30)
        btnSimpan.TabIndex = 11
        btnSimpan.Text = "Simpan"
        btnSimpan.UseVisualStyleBackColor = True
        '
        ' btnBersihkan
        '
        btnBersihkan.CausesValidation = False
        btnBersihkan.Location = New Point(220, 264)
        btnBersihkan.Name = "btnBersihkan"
        btnBersihkan.Size = New Size(100, 30)
        btnBersihkan.TabIndex = 12
        btnBersihkan.Text = "Bersihkan"
        btnBersihkan.UseVisualStyleBackColor = True
        '
        ' lblDaftar
        '
        lblDaftar.AutoSize = True
        lblDaftar.Location = New Point(352, 36)
        lblDaftar.Name = "lblDaftar"
        lblDaftar.Size = New Size(90, 15)
        lblDaftar.TabIndex = 13
        lblDaftar.Text = "Data Tersimpan"
        '
        ' lstMahasiswa
        '
        lstMahasiswa.FormattingEnabled = True
        lstMahasiswa.HorizontalScrollbar = True
        lstMahasiswa.IntegralHeight = False
        lstMahasiswa.Location = New Point(352, 59)
        lstMahasiswa.Name = "lstMahasiswa"
        lstMahasiswa.Size = New Size(330, 235)
        lstMahasiswa.TabIndex = 14
        '
        ' btnEkspor
        '
        btnEkspor.CausesValidation = False
        btnEkspor.Location = New Point(352, 308)
        btnEkspor.Name = "btnEkspor"
        btnEkspor.Size = New Size(140, 30)
        btnEkspor.TabIndex = 15
        btnEkspor.Text = "Ekspor ke CSV"
        btnEkspor.UseVisualStyleBackColor = True
        '
        ' lblStatus
        '
        lblStatus.Location = New Point(16, 356)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(666, 24)
        lblStatus.TabIndex = 16
        lblStatus.Text = "Siap."
        '
        ' errInput
        '
        errInput.ContainerControl = Me
        '
        ' FrmPendaftaran
        '
        AcceptButton = btnSimpan
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(700, 392)
        Controls.Add(lblStatus)
        Controls.Add(btnEkspor)
        Controls.Add(lstMahasiswa)
        Controls.Add(lblDaftar)
        Controls.Add(btnBersihkan)
        Controls.Add(btnSimpan)
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
        Name = "FrmPendaftaran"
        StartPosition = FormStartPosition.CenterParent
        Text = "Pendaftaran Mahasiswa"
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
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents lblDaftar As Label
    Friend WithEvents lstMahasiswa As ListBox
    Friend WithEvents btnEkspor As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents errInput As ErrorProvider
End Class
