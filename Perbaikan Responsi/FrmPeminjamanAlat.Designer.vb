<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPeminjamanAlat
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        Dim dgvCellStyleHeader As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim dgvCellStyleLeft As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim dgvCellStyleRight As DataGridViewCellStyle = New DataGridViewCellStyle()

        lblJudul = New Label()
        lblAlat = New Label()
        cboAlat = New ComboBox()
        lblJumlah = New Label()
        txtJumlah = New TextBox()
        btnPinjam = New Button()
        btnKembalikan = New Button()
        btnReset = New Button()
        dgvAlat = New DataGridView()
        colNamaAlat = New DataGridViewTextBoxColumn()
        colStokAwal = New DataGridViewTextBoxColumn()
        colTersedia = New DataGridViewTextBoxColumn()
        colDipinjam = New DataGridViewTextBoxColumn()
        lblKeteranganTotal = New Label()
        lblTotalDipinjam = New Label()
        lblCatatan = New Label()
        bsAlat = New BindingSource(components)
        errInput = New ErrorProvider(components)

        CType(dgvAlat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(bsAlat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(errInput, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()

        lblJudul.AutoSize = True
        lblJudul.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold, GraphicsUnit.Point)
        lblJudul.Location = New Point(22, 18)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(244, 21)
        lblJudul.TabIndex = 0
        lblJudul.Text = "Peminjaman Alat Laboratorium"

        lblAlat.AutoSize = True
        lblAlat.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular, GraphicsUnit.Point)
        lblAlat.Location = New Point(22, 58)
        lblAlat.Name = "lblAlat"
        lblAlat.Size = New Size(28, 15)
        lblAlat.TabIndex = 1
        lblAlat.Text = "Alat"

        cboAlat.DropDownStyle = ComboBoxStyle.DropDownList
        cboAlat.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular, GraphicsUnit.Point)
        cboAlat.FormattingEnabled = True
        cboAlat.Location = New Point(110, 54)
        cboAlat.Name = "cboAlat"
        cboAlat.Size = New Size(170, 23)
        cboAlat.TabIndex = 2

        btnPinjam.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular, GraphicsUnit.Point)
        btnPinjam.Location = New Point(310, 52)
        btnPinjam.Name = "btnPinjam"
        btnPinjam.Size = New Size(80, 27)
        btnPinjam.TabIndex = 3
        btnPinjam.Text = "Pinjam"
        btnPinjam.UseVisualStyleBackColor = True

        btnKembalikan.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular, GraphicsUnit.Point)
        btnKembalikan.Location = New Point(400, 52)
        btnKembalikan.Name = "btnKembalikan"
        btnKembalikan.Size = New Size(95, 27)
        btnKembalikan.TabIndex = 4
        btnKembalikan.Text = "Kembalikan"
        btnKembalikan.UseVisualStyleBackColor = True

        btnReset.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular, GraphicsUnit.Point)
        btnReset.Location = New Point(505, 52)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(95, 27)
        btnReset.TabIndex = 5
        btnReset.Text = "Reset Data"
        btnReset.UseVisualStyleBackColor = True

        lblJumlah.AutoSize = True
        lblJumlah.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular, GraphicsUnit.Point)
        lblJumlah.Location = New Point(22, 93)
        lblJumlah.Name = "lblJumlah"
        lblJumlah.Size = New Size(73, 15)
        lblJumlah.TabIndex = 6
        lblJumlah.Text = "Jumlah (unit)"

        txtJumlah.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular, GraphicsUnit.Point)
        txtJumlah.Location = New Point(110, 90)
        txtJumlah.Name = "txtJumlah"
        txtJumlah.Size = New Size(80, 23)
        txtJumlah.TabIndex = 7

        dgvAlat.AllowUserToAddRows = False
        dgvAlat.AllowUserToDeleteRows = False
        dgvAlat.AllowUserToResizeRows = False
        dgvAlat.AutoGenerateColumns = False
        dgvAlat.BackgroundColor = SystemColors.AppWorkspace
        dgvAlat.BorderStyle = BorderStyle.FixedSingle
        dgvCellStyleHeader.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvCellStyleHeader.BackColor = SystemColors.Control
        dgvCellStyleHeader.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular, GraphicsUnit.Point)
        dgvCellStyleHeader.ForeColor = SystemColors.WindowText
        dgvCellStyleHeader.SelectionBackColor = SystemColors.Control
        dgvCellStyleHeader.SelectionForeColor = SystemColors.WindowText
        dgvCellStyleHeader.WrapMode = DataGridViewTriState.True
        dgvAlat.ColumnHeadersDefaultCellStyle = dgvCellStyleHeader
        dgvAlat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAlat.Columns.AddRange(New DataGridViewColumn() {colNamaAlat, colStokAwal, colTersedia, colDipinjam})
        dgvAlat.Location = New Point(22, 126)
        dgvAlat.MultiSelect = False
        dgvAlat.Name = "dgvAlat"
        dgvAlat.ReadOnly = True
        dgvAlat.RowHeadersVisible = False
        dgvAlat.RowTemplate.Height = 25
        dgvAlat.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAlat.Size = New Size(578, 170)
        dgvAlat.TabIndex = 8

        colNamaAlat.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        colNamaAlat.DataPropertyName = "NamaAlat"
        dgvCellStyleLeft.Alignment = DataGridViewContentAlignment.MiddleLeft
        colNamaAlat.DefaultCellStyle = dgvCellStyleLeft
        colNamaAlat.HeaderText = "Nama Alat"
        colNamaAlat.Name = "colNamaAlat"
        colNamaAlat.ReadOnly = True

        colStokAwal.DataPropertyName = "StokAwal"
        dgvCellStyleRight.Alignment = DataGridViewContentAlignment.MiddleRight
        colStokAwal.DefaultCellStyle = dgvCellStyleRight
        colStokAwal.HeaderText = "Stok Awal"
        colStokAwal.Name = "colStokAwal"
        colStokAwal.ReadOnly = True
        colStokAwal.Width = 100

        colTersedia.DataPropertyName = "Tersedia"
        colTersedia.DefaultCellStyle = dgvCellStyleRight
        colTersedia.HeaderText = "Tersedia"
        colTersedia.Name = "colTersedia"
        colTersedia.ReadOnly = True
        colTersedia.Width = 100

        colDipinjam.DataPropertyName = "Dipinjam"
        colDipinjam.DefaultCellStyle = dgvCellStyleRight
        colDipinjam.HeaderText = "Dipinjam"
        colDipinjam.Name = "colDipinjam"
        colDipinjam.ReadOnly = True
        colDipinjam.Width = 100

        lblKeteranganTotal.AutoSize = True
        lblKeteranganTotal.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular, GraphicsUnit.Point)
        lblKeteranganTotal.Location = New Point(22, 310)
        lblKeteranganTotal.Name = "lblKeteranganTotal"
        lblKeteranganTotal.Size = New Size(106, 15)
        lblKeteranganTotal.TabIndex = 9
        lblKeteranganTotal.Text = "Total unit dipinjam"

        lblTotalDipinjam.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold, GraphicsUnit.Point)
        lblTotalDipinjam.Location = New Point(440, 307)
        lblTotalDipinjam.Name = "lblTotalDipinjam"
        lblTotalDipinjam.Size = New Size(160, 20)
        lblTotalDipinjam.TabIndex = 10
        lblTotalDipinjam.Text = "0 unit"
        lblTotalDipinjam.TextAlign = ContentAlignment.MiddleRight

        lblCatatan.AutoSize = True
        lblCatatan.Font = New Font("Segoe UI", 8.25!, FontStyle.Regular, GraphicsUnit.Point)
        lblCatatan.ForeColor = Color.FromArgb(70, 70, 70)
        lblCatatan.Location = New Point(22, 342)
        lblCatatan.Name = "lblCatatan"
        lblCatatan.Size = New Size(245, 13)
        lblCatatan.TabIndex = 11
        lblCatatan.Text = "Stok tersedia + dipinjam selalu sama dengan stok awal."

        errInput.BlinkStyle = ErrorBlinkStyle.NeverBlink
        errInput.ContainerControl = Me

        AutoScaleDimensions = New SizeF(7.0!, 15.0!)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(628, 380)
        Controls.Add(lblCatatan)
        Controls.Add(lblTotalDipinjam)
        Controls.Add(lblKeteranganTotal)
        Controls.Add(dgvAlat)
        Controls.Add(txtJumlah)
        Controls.Add(lblJumlah)
        Controls.Add(btnReset)
        Controls.Add(btnKembalikan)
        Controls.Add(btnPinjam)
        Controls.Add(cboAlat)
        Controls.Add(lblAlat)
        Controls.Add(lblJudul)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FrmPeminjamanAlat"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Peminjaman Alat Laboratorium"

        CType(dgvAlat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(bsAlat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(errInput, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Public WithEvents lblJudul As Label
    Public WithEvents lblAlat As Label
    Public WithEvents cboAlat As ComboBox
    Public WithEvents lblJumlah As Label
    Public WithEvents txtJumlah As TextBox
    Public WithEvents btnPinjam As Button
    Public WithEvents btnKembalikan As Button
    Public WithEvents btnReset As Button
    Public WithEvents dgvAlat As DataGridView
    Public WithEvents colNamaAlat As DataGridViewTextBoxColumn
    Public WithEvents colStokAwal As DataGridViewTextBoxColumn
    Public WithEvents colTersedia As DataGridViewTextBoxColumn
    Public WithEvents colDipinjam As DataGridViewTextBoxColumn
    Public WithEvents lblKeteranganTotal As Label
    Public WithEvents lblTotalDipinjam As Label
    Public WithEvents lblCatatan As Label
    Public WithEvents bsAlat As BindingSource
    Public WithEvents errInput As ErrorProvider
End Class
