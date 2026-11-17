<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class hitungpajak
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        txtPend = New TextBox()
        btnHitung = New Button()
        btnClose = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(158, 72)
        Label1.Name = "Label1"
        Label1.Size = New Size(609, 123)
        Label1.TabIndex = 0
        Label1.Text = "Pendapatan lebih dari 5 juta, 10% Pajak" & vbCrLf & "Pendapatan lebih dari 30 juta, 20% Pajak" & vbCrLf & "Pendapatan lebih dari 100 juta, 30% Pajak"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(312, 262)
        Label3.Name = "Label3"
        Label3.Size = New Size(259, 28)
        Label3.TabIndex = 2
        Label3.Text = "Masukkan Pendapatan Anda"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(266, 300)
        Label2.Name = "Label2"
        Label2.Size = New Size(40, 28)
        Label2.TabIndex = 3
        Label2.Text = "Rp."
        ' 
        ' txtPend
        ' 
        txtPend.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtPend.Location = New Point(312, 297)
        txtPend.Name = "txtPend"
        txtPend.Size = New Size(259, 34)
        txtPend.TabIndex = 4
        ' 
        ' btnHitung
        ' 
        btnHitung.Location = New Point(312, 361)
        btnHitung.Name = "btnHitung"
        btnHitung.Size = New Size(94, 29)
        btnHitung.TabIndex = 5
        btnHitung.Text = "Hitung"
        btnHitung.UseVisualStyleBackColor = True
        ' 
        ' btnClose
        ' 
        btnClose.Location = New Point(477, 361)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(94, 29)
        btnClose.TabIndex = 6
        btnClose.Text = "Keluar"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' hitungpajak
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(927, 562)
        Controls.Add(btnClose)
        Controls.Add(btnHitung)
        Controls.Add(txtPend)
        Controls.Add(Label2)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Name = "hitungpajak"
        Text = "Hitung Pajak"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPend As TextBox
    Friend WithEvents btnHitung As Button
    Friend WithEvents btnClose As Button
End Class
