Option Strict On

Public Module ModPerhitungan
    ' Konstanta dan variabel Public dapat diakses langsung dari Form atau Module lain
    Public Const BatasLuas As Integer = 20
    Public nilaiUmum As Integer = 80

    ' Variabel Private hanya dapat diakses dari dalam ModPerhitungan ini saja
    Private rahasiaInternal As Integer = 100

    ' Fungsi Public sebagai jembatan resmi untuk membaca nilai variabel Private
    Public Function AmbilRahasiaInternal() As Integer
        Return rahasiaInternal
    End Function

    ' Procedure (Sub): Menjalankan tugas tanpa mengembalikan nilai
    Public Sub TampilkanPesan(nama As String)
        Dim namaRapi As String = nama.Trim()
        If namaRapi = "" Then namaRapi = "Mahasiswa"
        MessageBox.Show("Halo, " & namaRapi & "! Nilai umum dari modul = " & nilaiUmum.ToString(),
                        "Pesan dari Module", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Function: Melakukan perhitungan dan mengembalikan nilai Integer
    Public Function HitungLuas(panjang As Integer, lebar As Integer) As Integer
        Return panjang * lebar
    End Function

    Public Function HitungKeliling(panjang As Integer, lebar As Integer) As Integer
        Return 2 * (panjang + lebar)
    End Function

    ' Array Satu Dimensi (5 elemen, indeks 0 sampai 4)
    Public ReadOnly Nilai1D() As Integer = {10, 20, 30, 40, 50}

    ' Array Dua Dimensi (3 baris x 3 kolom)
    Public ReadOnly Matriks2D(,) As Integer = {
        {10, 20, 30},
        {40, 50, 60},
        {70, 80, 90}
    }

    ' Array Tiga Dimensi (2 blok x 3 baris x 3 kolom)
    Public ReadOnly Ruang3D(,,) As Integer = {
        {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        },
        {
            {10, 11, 12},
            {13, 14, 15},
            {16, 17, 18}
        }
    }
End Module
