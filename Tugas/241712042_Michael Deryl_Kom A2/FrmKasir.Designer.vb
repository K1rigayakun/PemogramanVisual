<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmKasir
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
        lblJudul = New Label()
        lblLayanan = New Label()
        lblJumlah = New Label()
        cboLayanan = New ComboBox()
        Label4 = New Label()
        Label5 = New Label()
        btnTambah = New Button()
        btnBaru = New Button()
        txtJumlah = New TextBox()
        dgvPesanan = New DataGridView()
        lblTotalBayar = New Label()
        lblTotal = New Label()
        errInput = New ErrorProvider(components)
        bsPesanan = New BindingSource(components)
        CType(dgvPesanan, ComponentModel.ISupportInitialize).BeginInit()
        CType(errInput, ComponentModel.ISupportInitialize).BeginInit()
        CType(bsPesanan, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblJudul.Location = New Point(43, 32)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(148, 28)
        lblJudul.TabIndex = 0
        lblJudul.Text = "Kasir Fotokopi"
        ' 
        ' lblLayanan
        ' 
        lblLayanan.AutoSize = True
        lblLayanan.Location = New Point(43, 78)
        lblLayanan.Name = "lblLayanan"
        lblLayanan.Size = New Size(63, 20)
        lblLayanan.TabIndex = 1
        lblLayanan.Text = "Layanan"
        ' 
        ' lblJumlah
        ' 
        lblJumlah.AutoSize = True
        lblJumlah.Location = New Point(43, 124)
        lblJumlah.Name = "lblJumlah"
        lblJumlah.Size = New Size(119, 20)
        lblJumlah.TabIndex = 2
        lblJumlah.Text = "Jumlah (Lembar)"
        ' 
        ' cboLayanan
        ' 
        cboLayanan.FormattingEnabled = True
        cboLayanan.Location = New Point(186, 75)
        cboLayanan.Name = "cboLayanan"
        cboLayanan.Size = New Size(191, 28)
        cboLayanan.TabIndex = 3
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(168, 78)
        Label4.Name = "Label4"
        Label4.Size = New Size(12, 20)
        Label4.TabIndex = 4
        Label4.Text = ":"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(168, 124)
        Label5.Name = "Label5"
        Label5.Size = New Size(12, 20)
        Label5.TabIndex = 5
        Label5.Text = ":"
        ' 
        ' btnTambah
        ' 
        btnTambah.Location = New Point(499, 74)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(94, 29)
        btnTambah.TabIndex = 6
        btnTambah.Text = "Tambah"
        btnTambah.UseVisualStyleBackColor = True
        ' 
        ' btnBaru
        ' 
        btnBaru.Location = New Point(641, 74)
        btnBaru.Name = "btnBaru"
        btnBaru.Size = New Size(119, 29)
        btnBaru.TabIndex = 7
        btnBaru.Text = "Transaksi Baru"
        btnBaru.UseVisualStyleBackColor = True
        ' 
        ' txtJumlah
        ' 
        txtJumlah.Location = New Point(186, 121)
        txtJumlah.Name = "txtJumlah"
        txtJumlah.Size = New Size(191, 27)
        txtJumlah.TabIndex = 8
        ' 
        ' dgvPesanan
        ' 
        dgvPesanan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPesanan.Location = New Point(43, 184)
        dgvPesanan.Name = "dgvPesanan"
        dgvPesanan.RowHeadersWidth = 51
        dgvPesanan.Size = New Size(717, 234)
        dgvPesanan.TabIndex = 9
        ' 
        ' lblTotalBayar
        ' 
        lblTotalBayar.AutoSize = True
        lblTotalBayar.Location = New Point(420, 467)
        lblTotalBayar.Name = "lblTotalBayar"
        lblTotalBayar.Size = New Size(94, 20)
        lblTotalBayar.TabIndex = 10
        lblTotalBayar.Text = "Total Bayar : "
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Location = New Point(520, 467)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(167, 20)
        lblTotal.TabIndex = 11
        lblTotal.Text = "                                Rp 0"
        ' 
        ' errInput
        ' 
        errInput.ContainerControl = Me
        ' 
        ' FrmKasir
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 531)
        Controls.Add(lblTotal)
        Controls.Add(lblTotalBayar)
        Controls.Add(dgvPesanan)
        Controls.Add(txtJumlah)
        Controls.Add(btnBaru)
        Controls.Add(btnTambah)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(cboLayanan)
        Controls.Add(lblJumlah)
        Controls.Add(lblLayanan)
        Controls.Add(lblJudul)
        Name = "FrmKasir"
        Text = "Kasir Fotokopi"
        CType(dgvPesanan, ComponentModel.ISupportInitialize).EndInit()
        CType(errInput, ComponentModel.ISupportInitialize).EndInit()
        CType(bsPesanan, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents lblLayanan As Label
    Friend WithEvents lblJumlah As Label
    Friend WithEvents cboLayanan As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnBaru As Button
    Friend WithEvents txtJumlah As TextBox
    Friend WithEvents dgvPesanan As DataGridView
    Friend WithEvents lblTotalBayar As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents errInput As ErrorProvider
    Public WithEvents bsPesanan As BindingSource

End Class
