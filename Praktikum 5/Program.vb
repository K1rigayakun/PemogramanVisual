Option Strict On

Friend Module Program
    <STAThread()>
    Friend Sub Main()
        Application.SetHighDpiMode(HighDpiMode.SystemAware)
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New FrmKoleksi())
    End Sub
End Module
