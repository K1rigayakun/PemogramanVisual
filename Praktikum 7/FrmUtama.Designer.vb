<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUtama
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
        btnUjiKonversi = New Button()
        btnPendaftaran = New Button()
        SuspendLayout()
        '
        ' lblJudul
        '
        lblJudul.AutoSize = True
        lblJudul.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblJudul.Location = New Point(24, 20)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(280, 25)
        lblJudul.TabIndex = 0
        lblJudul.Text = "Contoh Pertemuan 7"
        '
        ' btnUjiKonversi
        '
        btnUjiKonversi.Location = New Point(56, 78)
        btnUjiKonversi.Name = "btnUjiKonversi"
        btnUjiKonversi.Size = New Size(268, 36)
        btnUjiKonversi.TabIndex = 1
        btnUjiKonversi.Text = "1. Uji Konversi && Try...Catch"
        btnUjiKonversi.UseVisualStyleBackColor = True
        '
        ' btnPendaftaran
        '
        btnPendaftaran.Location = New Point(56, 128)
        btnPendaftaran.Name = "btnPendaftaran"
        btnPendaftaran.Size = New Size(268, 36)
        btnPendaftaran.TabIndex = 2
        btnPendaftaran.Text = "2. Studi Kasus: Form Pendaftaran"
        btnPendaftaran.UseVisualStyleBackColor = True
        '
        ' FrmUtama
        '
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(380, 206)
        Controls.Add(btnPendaftaran)
        Controls.Add(btnUjiKonversi)
        Controls.Add(lblJudul)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FrmUtama"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Pertemuan 7 - Validasi Input & Error Handling"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents btnUjiKonversi As Button
    Friend WithEvents btnPendaftaran As Button
End Class
