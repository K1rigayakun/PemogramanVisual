Option Strict On

''' <summary>
''' Modul fungsi validasi terpusat untuk aplikasi inventaris buku perpustakaan.
''' </summary>
Public Module ModValidasi

    ''' <summary>
    ''' Memeriksa apakah teks bernilai Nothing, kosong, atau hanya terdiri dari spasi.
    ''' </summary>
    ''' <param name="teks">Teks yang diperiksa.</param>
    ''' <returns>True jika kosong, False jika ada karakter valid.</returns>
    Public Function Kosong(teks As String) As Boolean
        If teks Is Nothing Then
            Return True
        End If
        Return teks.Trim().Length = 0
    End Function

    ''' <summary>
    ''' Memeriksa apakah seluruh karakter dalam string berupa digit angka numerik (0-9) dengan panjang tepat.
    ''' </summary>
    ''' <param name="teks">String masukan.</param>
    ''' <param name="panjang">Panjang karakter yang diwajibkan.</param>
    ''' <returns>True jika seluruh karakter berupa digit sesuai panjang, False jika tidak.</returns>
    Public Function SemuaDigit(teks As String, panjang As Integer) As Boolean
        If teks Is Nothing OrElse teks.Length <> panjang Then
            Return False
        End If
        For Each karakter As Char In teks
            If karakter < "0"c OrElse karakter > "9"c Then
                Return False
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' Memeriksa format kode buku: harus diawali prefix "BK" (case-insensitive)
    ''' dan diikuti tepat 4 digit angka (total 6 karakter, contoh: BK0012).
    ''' </summary>
    ''' <param name="kode">Kode buku yang akan diuji.</param>
    ''' <returns>True jika format valid, False jika format tidak sesuai.</returns>
    Public Function KodeBukuValid(kode As String) As Boolean
        If Kosong(kode) Then
            Return False
        End If
        Dim kodeBersih As String = kode.Trim().ToUpper()
        If kodeBersih.Length <> 6 Then
            Return False
        End If
        If Not kodeBersih.StartsWith("BK") Then
            Return False
        End If
        Return SemuaDigit(kodeBersih.Substring(2), 4)
    End Function

End Module

