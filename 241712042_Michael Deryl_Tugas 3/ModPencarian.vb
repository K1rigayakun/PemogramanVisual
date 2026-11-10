Option Strict On

''' <summary>
''' Modul pendukung untuk fungsi pencarian dan pengamanan ekspresi filter BindingSource / DataView.
''' </summary>
Public Module ModPencarian

    ''' <summary>
    ''' Mengamankan karakter khusus pada teks pencarian untuk ekspresi BindingSource.Filter
    ''' agar pengetikan tanda kutip tunggal dan karakter wildcard tidak menimbulkan error.
    ''' </summary>
    ''' <param name="teks">Teks masukan pengguna.</param>
    ''' <returns>Teks yang telah disanitasi.</returns>
    Public Function AmankanTeksFilter(teks As String) As String
        If teks Is Nothing Then
            Return ""
        End If

        Dim hasil As String = teks
        hasil = hasil.Replace("'", "''")
        hasil = hasil.Replace("[", "[[]")
        hasil = hasil.Replace("*", "[*]")
        hasil = hasil.Replace("%", "[%]")
        Return hasil
    End Function

End Module

