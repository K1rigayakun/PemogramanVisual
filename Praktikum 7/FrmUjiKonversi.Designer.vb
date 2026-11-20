<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUjiKonversi
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
        lblInput = New Label()
        txtInput = New TextBox()
        btnCInt = New Button()
        btnVal = New Button()
        btnTryParse = New Button()
        btnTryCatch = New Button()
        btnCatchBertingkat = New Button()
        lblHasil = New Label()
        SuspendLayout()
        '
        ' lblJudul
        '
        lblJudul.AutoSize = True
        lblJudul.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        lblJudul.Location = New Point(20, 16)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(320, 25)
        lblJudul.TabIndex = 0
        lblJudul.Text = "Uji Konversi & Penanganan Exception"
        '
        ' lblInput
        '
        lblInput.AutoSize = True
        lblInput.Location = New Point(20, 62)
        lblInput.Name = "lblInput"
        lblInput.Size = New Size(110, 15)
        lblInput.TabIndex = 1
        lblInput.Text = "Masukkan Teks/Angka:"
        '
        ' txtInput
        '
        txtInput.Location = New Point(160, 59)
        txtInput.Name = "txtInput"
        txtInput.Size = New Size(260, 23)
        txtInput.TabIndex = 2
        '
        ' btnCInt
        '
        btnCInt.Location = New Point(20, 102)
        btnCInt.Name = "btnCInt"
        btnCInt.Size = New Size(192, 32)
        btnCInt.TabIndex = 3
        btnCInt.Text = "Uji CInt (Tanpa Pengaman)"
        btnCInt.UseVisualStyleBackColor = True
        '
        ' btnVal
        '
        btnVal.Location = New Point(228, 102)
        btnVal.Name = "btnVal"
        btnVal.Size = New Size(192, 32)
        btnVal.TabIndex = 4
        btnVal.Text = "Uji Val (Diam-Diam Salah)"
        btnVal.UseVisualStyleBackColor = True
        '
        ' btnTryParse
        '
        btnTryParse.Location = New Point(20, 144)
        btnTryParse.Name = "btnTryParse"
        btnTryParse.Size = New Size(192, 32)
        btnTryParse.TabIndex = 5
        btnTryParse.Text = "Uji Integer.TryParse"
        btnTryParse.UseVisualStyleBackColor = True
        '
        ' btnTryCatch
        '
        btnTryCatch.Location = New Point(228, 144)
        btnTryCatch.Name = "btnTryCatch"
        btnTryCatch.Size = New Size(192, 32)
        btnTryCatch.TabIndex = 6
        btnTryCatch.Text = "Uji Try...Catch"
        btnTryCatch.UseVisualStyleBackColor = True
        '
        ' btnCatchBertingkat
        '
        btnCatchBertingkat.Location = New Point(20, 186)
        btnCatchBertingkat.Name = "btnCatchBertingkat"
        btnCatchBertingkat.Size = New Size(400, 32)
        btnCatchBertingkat.TabIndex = 7
        btnCatchBertingkat.Text = "Uji Catch Bertingkat (1000 \ input)"
        btnCatchBertingkat.UseVisualStyleBackColor = True
        '
        ' lblHasil
        '
        lblHasil.BorderStyle = BorderStyle.FixedSingle
        lblHasil.Location = New Point(20, 234)
        lblHasil.Name = "lblHasil"
        lblHasil.Padding = New Padding(8)
        lblHasil.Size = New Size(400, 62)
        lblHasil.TabIndex = 8
        lblHasil.Text = "Hasil pengujian akan tampil di sini."
        '
        ' FrmUjiKonversi
        '
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(440, 316)
        Controls.Add(lblHasil)
        Controls.Add(btnCatchBertingkat)
        Controls.Add(btnTryCatch)
        Controls.Add(btnTryParse)
        Controls.Add(btnVal)
        Controls.Add(btnCInt)
        Controls.Add(txtInput)
        Controls.Add(lblInput)
        Controls.Add(lblJudul)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FrmUjiKonversi"
        StartPosition = FormStartPosition.CenterParent
        Text = "Uji Konversi Input & Try...Catch"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents lblInput As Label
    Friend WithEvents txtInput As TextBox
    Friend WithEvents btnCInt As Button
    Friend WithEvents btnVal As Button
    Friend WithEvents btnTryParse As Button
    Friend WithEvents btnTryCatch As Button
    Friend WithEvents btnCatchBertingkat As Button
    Friend WithEvents lblHasil As Label
End Class
