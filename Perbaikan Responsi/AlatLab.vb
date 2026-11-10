Option Strict On
Option Explicit On

Public Class AlatLab

    Public Property NamaAlat As String
    Public Property StokAwal As Integer
    Public Property Tersedia As Integer
    Public Property Dipinjam As Integer

    Public Sub New()
    End Sub

    Public Sub New(nama As String, stok As Integer)
        Me.NamaAlat = nama
        Me.StokAwal = stok
        Me.Tersedia = stok
        Me.Dipinjam = 0
    End Sub

End Class
