Option Strict On

' Kumpulan fungsi validasi terpusat untuk aplikasi peminjaman buku
Public Module ModValidasi

    ''' <summary>
    ''' Memeriksa apakah teks bernilai Nothing, kosong, atau hanya berisi spasi.
    ''' </summary>
    Public Function Kosong(teks As String) As Boolean
        If teks Is Nothing Then Return True
        Return teks.Trim() = ""
    End Function

    ''' <summary>
    ''' Memeriksa apakah panjang teks tepat dan semua karakternya adalah digit 0-9.
    ''' </summary>
    Public Function SemuaDigit(teks As String, panjang As Integer) As Boolean
        If teks Is Nothing OrElse teks.Length <> panjang Then Return False
        For Each karakter As Char In teks
            If karakter < "0"c OrElse karakter > "9"c Then Return False
        Next
        Return True
    End Function

    ''' <summary>
    ''' Memeriksa format kode buku: harus diawali "BK" (case-insensitive)
    ''' dan diikuti tepat 4 digit angka (total panjang 6 karakter, contoh: BK0012).
    ''' </summary>
    Public Function KodeBukuValid(kode As String) As Boolean
        If Kosong(kode) Then Return False
        Dim kodeBersih As String = kode.Trim().ToUpper()
        If kodeBersih.Length <> 6 Then Return False
        If Not kodeBersih.StartsWith("BK") Then Return False
        Return SemuaDigit(kodeBersih.Substring(2), 4)
    End Function

End Module

