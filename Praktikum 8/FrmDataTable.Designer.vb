<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDataTable
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
        lblCari = New Label()
        txtCari = New TextBox()
        btnRapikan = New Button()
        dgvMahasiswa = New DataGridView()
        lblJumlah = New Label()
        bsMahasiswa = New BindingSource(components)
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
        CType(bsMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        ' lblJudul
        '
        lblJudul.AutoSize = True
        lblJudul.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        lblJudul.Location = New Point(16, 14)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(310, 25)
        lblJudul.TabIndex = 0
        lblJudul.Text = "DataTable, Rapikan Kolom & Filter"
        '
        ' lblCari
        '
        lblCari.AutoSize = True
        lblCari.Location = New Point(16, 56)
        lblCari.Name = "lblCari"
        lblCari.Size = New Size(115, 15)
        lblCari.TabIndex = 1
        lblCari.Text = "Cari Nama / NIM:"
        '
        ' txtCari
        '
        txtCari.Location = New Point(136, 53)
        txtCari.Name = "txtCari"
        txtCari.Size = New Size(280, 23)
        txtCari.TabIndex = 2
        '
        ' btnRapikan
        '
        btnRapikan.Location = New Point(526, 51)
        btnRapikan.Name = "btnRapikan"
        btnRapikan.Size = New Size(140, 28)
        btnRapikan.TabIndex = 3
        btnRapikan.Text = "Rapikan Kolom"
        btnRapikan.UseVisualStyleBackColor = True
        '
        ' dgvMahasiswa
        '
        dgvMahasiswa.AllowUserToAddRows = False
        dgvMahasiswa.AllowUserToDeleteRows = False
        dgvMahasiswa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMahasiswa.Location = New Point(16, 92)
        dgvMahasiswa.MultiSelect = False
        dgvMahasiswa.Name = "dgvMahasiswa"
        dgvMahasiswa.ReadOnly = True
        dgvMahasiswa.RowHeadersVisible = False
        dgvMahasiswa.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMahasiswa.Size = New Size(650, 240)
        dgvMahasiswa.TabIndex = 4
        '
        ' lblJumlah
        '
        lblJumlah.Location = New Point(416, 344)
        lblJumlah.Name = "lblJumlah"
        lblJumlah.Size = New Size(250, 20)
        lblJumlah.TabIndex = 5
        lblJumlah.Text = "Menampilkan 0 dari 0 data"
        lblJumlah.TextAlign = ContentAlignment.MiddleRight
        '
        ' FrmDataTable
        '
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(682, 378)
        Controls.Add(lblJumlah)
        Controls.Add(dgvMahasiswa)
        Controls.Add(btnRapikan)
        Controls.Add(txtCari)
        Controls.Add(lblCari)
        Controls.Add(lblJudul)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FrmDataTable"
        StartPosition = FormStartPosition.CenterParent
        Text = "DataTable, Rapikan Kolom & Filter"
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).EndInit()
        CType(bsMahasiswa, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents lblCari As Label
    Friend WithEvents txtCari As TextBox
    Friend WithEvents btnRapikan As Button
    Friend WithEvents dgvMahasiswa As DataGridView
    Friend WithEvents lblJumlah As Label
    Friend WithEvents bsMahasiswa As BindingSource
End Class
