<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        txtNilai = New TextBox()
        btnInput = New Button()
        picImage = New PictureBox()
        CType(picImage, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtNilai
        ' 
        txtNilai.Location = New Point(297, 259)
        txtNilai.Name = "txtNilai"
        txtNilai.Size = New Size(125, 27)
        txtNilai.TabIndex = 0
        ' 
        ' btnInput
        ' 
        btnInput.Location = New Point(311, 292)
        btnInput.Name = "btnInput"
        btnInput.Size = New Size(94, 29)
        btnInput.TabIndex = 1
        btnInput.Text = "Input"
        btnInput.UseVisualStyleBackColor = True
        ' 
        ' picImage
        ' 
        picImage.InitialImage = Nothing
        picImage.Location = New Point(270, 77)
        picImage.Name = "picImage"
        picImage.Size = New Size(175, 152)
        picImage.SizeMode = PictureBoxSizeMode.Zoom
        picImage.TabIndex = 2
        picImage.TabStop = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(picImage)
        Controls.Add(btnInput)
        Controls.Add(txtNilai)
        Name = "Form1"
        Text = "Form1"
        CType(picImage, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtNilai As TextBox
    Friend WithEvents btnInput As Button
    Friend WithEvents picImage As PictureBox

End Class
