<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        pictBox = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        rolePilih = New ComboBox()
        txtNama = New TextBox()
        txtNIM = New TextBox()
        btnLogin = New Button()
        CType(pictBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pictBox
        ' 
        resources.ApplyResources(pictBox, "pictBox")
        pictBox.Name = "pictBox"
        pictBox.TabStop = False
        ' 
        ' Label1
        ' 
        resources.ApplyResources(Label1, "Label1")
        Label1.Name = "Label1"
        ' 
        ' Label2
        ' 
        resources.ApplyResources(Label2, "Label2")
        Label2.Name = "Label2"
        ' 
        ' Label3
        ' 
        resources.ApplyResources(Label3, "Label3")
        Label3.Name = "Label3"
        ' 
        ' Label4
        ' 
        resources.ApplyResources(Label4, "Label4")
        Label4.Name = "Label4"
        ' 
        ' Label5
        ' 
        resources.ApplyResources(Label5, "Label5")
        Label5.Name = "Label5"
        ' 
        ' Label6
        ' 
        resources.ApplyResources(Label6, "Label6")
        Label6.Name = "Label6"
        ' 
        ' rolePilih
        ' 
        rolePilih.DropDownStyle = ComboBoxStyle.DropDownList
        rolePilih.FormattingEnabled = True
        rolePilih.Items.AddRange(New Object() {resources.GetString("rolePilih.Items"), resources.GetString("rolePilih.Items1")})
        resources.ApplyResources(rolePilih, "rolePilih")
        rolePilih.Name = "rolePilih"
        ' 
        ' txtNama
        ' 
        resources.ApplyResources(txtNama, "txtNama")
        txtNama.Name = "txtNama"
        ' 
        ' txtNIM
        ' 
        resources.ApplyResources(txtNIM, "txtNIM")
        txtNIM.Name = "txtNIM"
        ' 
        ' btnLogin
        ' 
        resources.ApplyResources(btnLogin, "btnLogin")
        btnLogin.Name = "btnLogin"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' login
        ' 
        resources.ApplyResources(Me, "$this")
        AutoScaleMode = AutoScaleMode.Dpi
        BackColor = SystemColors.Control
        Controls.Add(btnLogin)
        Controls.Add(txtNIM)
        Controls.Add(txtNama)
        Controls.Add(rolePilih)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(pictBox)
        Name = "login"
        CType(pictBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pictBox As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents rolePilih As ComboBox
    Friend WithEvents txtNama As TextBox
    Friend WithEvents txtNIM As TextBox
    Friend WithEvents btnLogin As Button

End Class
