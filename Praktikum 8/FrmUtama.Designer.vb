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
        btnDariArray = New Button()
        btnDariList = New Button()
        btnDataTable = New Button()
        btnCariList = New Button()
        SuspendLayout()
        '
        ' lblJudul
        '
        lblJudul.AutoSize = True
        lblJudul.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblJudul.Location = New Point(24, 18)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(220, 25)
        lblJudul.TabIndex = 0
        lblJudul.Text = "Contoh Pertemuan 8"
        '
        ' btnDariArray
        '
        btnDariArray.Location = New Point(64, 68)
        btnDariArray.Name = "btnDariArray"
        btnDariArray.Size = New Size(292, 34)
        btnDariArray.TabIndex = 1
        btnDariArray.Text = "1. DataGridView dari Array"
        btnDariArray.UseVisualStyleBackColor = True
        '
        ' btnDariList
        '
        btnDariList.Location = New Point(64, 112)
        btnDariList.Name = "btnDariList"
        btnDariList.Size = New Size(292, 34)
        btnDariList.TabIndex = 2
        btnDariList.Text = "2. Binding List(Of Mahasiswa)"
        btnDariList.UseVisualStyleBackColor = True
        '
        ' btnDataTable
        '
        btnDataTable.Location = New Point(64, 156)
        btnDataTable.Name = "btnDataTable"
        btnDataTable.Size = New Size(292, 34)
        btnDataTable.TabIndex = 3
        btnDataTable.Text = "3. DataTable, Rapikan Kolom && Filter"
        btnDataTable.UseVisualStyleBackColor = True
        '
        ' btnCariList
        '
        btnCariList.Location = New Point(64, 200)
        btnCariList.Name = "btnCariList"
        btnCariList.Size = New Size(292, 34)
        btnCariList.TabIndex = 4
        btnCariList.Text = "4. Pencarian dengan Perulangan"
        btnCariList.UseVisualStyleBackColor = True
        '
        ' FrmUtama
        '
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(420, 260)
        Controls.Add(btnCariList)
        Controls.Add(btnDataTable)
        Controls.Add(btnDariList)
        Controls.Add(btnDariArray)
        Controls.Add(lblJudul)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FrmUtama"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Pertemuan 8 - DataGridView, Array & Koleksi Data"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents btnDariArray As Button
    Friend WithEvents btnDariList As Button
    Friend WithEvents btnDataTable As Button
    Friend WithEvents btnCariList As Button
End Class
