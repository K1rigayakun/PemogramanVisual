<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDariArray
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
        lblJudul = New Label()
        dgvMahasiswa = New DataGridView()
        colNim = New DataGridViewTextBoxColumn()
        colNama = New DataGridViewTextBoxColumn()
        colJurusan = New DataGridViewTextBoxColumn()
        colAngkatan = New DataGridViewTextBoxColumn()
        colIpk = New DataGridViewTextBoxColumn()
        btnTampilkan = New Button()
        btnKosongkan = New Button()
        lblJumlah = New Label()
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        ' lblJudul
        '
        lblJudul.AutoSize = True
        lblJudul.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        lblJudul.Location = New Point(16, 14)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(220, 25)
        lblJudul.TabIndex = 0
        lblJudul.Text = "Data dari Array 2 Dimensi"
        '
        ' dgvMahasiswa
        '
        dgvMahasiswa.AllowUserToAddRows = False
        dgvMahasiswa.AllowUserToDeleteRows = False
        dgvMahasiswa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMahasiswa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMahasiswa.Columns.AddRange(New DataGridViewColumn() {colNim, colNama, colJurusan, colAngkatan, colIpk})
        dgvMahasiswa.Location = New Point(16, 52)
        dgvMahasiswa.MultiSelect = False
        dgvMahasiswa.Name = "dgvMahasiswa"
        dgvMahasiswa.ReadOnly = True
        dgvMahasiswa.RowHeadersVisible = False
        dgvMahasiswa.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMahasiswa.Size = New Size(650, 260)
        dgvMahasiswa.TabIndex = 1
        '
        ' colNim
        '
        colNim.HeaderText = "NIM"
        colNim.Name = "colNim"
        colNim.ReadOnly = True
        '
        ' colNama
        '
        colNama.FillWeight = 160F
        colNama.HeaderText = "Nama"
        colNama.Name = "colNama"
        colNama.ReadOnly = True
        '
        ' colJurusan
        '
        colJurusan.FillWeight = 150F
        colJurusan.HeaderText = "Jurusan"
        colJurusan.Name = "colJurusan"
        colJurusan.ReadOnly = True
        '
        ' colAngkatan
        '
        colAngkatan.HeaderText = "Angkatan"
        colAngkatan.Name = "colAngkatan"
        colAngkatan.ReadOnly = True
        '
        ' colIpk
        '
        colIpk.HeaderText = "IPK"
        colIpk.Name = "colIpk"
        colIpk.ReadOnly = True
        '
        ' btnTampilkan
        '
        btnTampilkan.Location = New Point(16, 326)
        btnTampilkan.Name = "btnTampilkan"
        btnTampilkan.Size = New Size(116, 32)
        btnTampilkan.TabIndex = 2
        btnTampilkan.Text = "Tampilkan"
        btnTampilkan.UseVisualStyleBackColor = True
        '
        ' btnKosongkan
        '
        btnKosongkan.Location = New Point(144, 326)
        btnKosongkan.Name = "btnKosongkan"
        btnKosongkan.Size = New Size(116, 32)
        btnKosongkan.TabIndex = 3
        btnKosongkan.Text = "Kosongkan"
        btnKosongkan.UseVisualStyleBackColor = True
        '
        ' lblJumlah
        '
        lblJumlah.Location = New Point(440, 333)
        lblJumlah.Name = "lblJumlah"
        lblJumlah.Size = New Size(226, 20)
        lblJumlah.TabIndex = 4
        lblJumlah.Text = "Jumlah data: 0"
        lblJumlah.TextAlign = ContentAlignment.MiddleRight
        '
        ' FrmDariArray
        '
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(682, 374)
        Controls.Add(lblJumlah)
        Controls.Add(btnKosongkan)
        Controls.Add(btnTampilkan)
        Controls.Add(dgvMahasiswa)
        Controls.Add(lblJudul)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FrmDariArray"
        StartPosition = FormStartPosition.CenterParent
        Text = "DataGridView dari Array"
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents dgvMahasiswa As DataGridView
    Friend WithEvents colNim As DataGridViewTextBoxColumn
    Friend WithEvents colNama As DataGridViewTextBoxColumn
    Friend WithEvents colJurusan As DataGridViewTextBoxColumn
    Friend WithEvents colAngkatan As DataGridViewTextBoxColumn
    Friend WithEvents colIpk As DataGridViewTextBoxColumn
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents btnKosongkan As Button
    Friend WithEvents lblJumlah As Label
End Class
