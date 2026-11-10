Public Class Pesanan
    Public Property Layanan As String
    Public Property Jumlah As Integer
    Public Property Harga As Decimal
    Public Property Diskon As Decimal
    Public Property Subtotal As Decimal

    Public Sub New(layanan As String, jumlah As Integer, harga As Decimal, diskon As Decimal, subtotal As Decimal)
        Me.Layanan = layanan
        Me.Jumlah = jumlah
        Me.Harga = harga
        Me.Diskon = diskon
        Me.Subtotal = subtotal
    End Sub
End Class