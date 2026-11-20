<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmKoleksi
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
        tabMateri = New TabControl()
        tpModulFungsi = New TabPage()
        grpFungsi = New GroupBox()
        lblNama = New Label()
        txtNama = New TextBox()
        btnSapa = New Button()
        lblPanjang = New Label()
        txtPanjang = New TextBox()
        lblLebar = New Label()
        txtLebar = New TextBox()
        btnHitung = New Button()
        lblHasilHitung = New Label()
        lblInfoAkses = New Label()
        tpArray = New TabPage()
        grpArray = New GroupBox()
        btnArray1D = New Button()
        btnArray2D = New Button()
        btnArray3D = New Button()
        btnBersihkanArray = New Button()
        lstArray = New ListBox()
        lblRingkasanArray = New Label()
        tpKoleksi = New TabPage()
        grpKoleksi = New GroupBox()
        lblJudulList = New Label()
        txtItemList = New TextBox()
        btnTambahList = New Button()
        btnHapusList = New Button()
        lstDinamis = New ListBox()
        lblJudulDict = New Label()
        txtKeyDict = New TextBox()
        btnCariDict = New Button()
        lblHasilDict = New Label()
        lblJudulSet = New Label()
        txtAngkaSet = New TextBox()
        btnTambahSet = New Button()
        lstSet = New ListBox()
        lblStatusSet = New Label()
        lblJudul = New Label()

        tabMateri.SuspendLayout()
        tpModulFungsi.SuspendLayout()
        grpFungsi.SuspendLayout()
        tpArray.SuspendLayout()
        grpArray.SuspendLayout()
        tpKoleksi.SuspendLayout()
        grpKoleksi.SuspendLayout()
        SuspendLayout()

        ' lblJudul
        lblJudul.AutoSize = True
        lblJudul.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        lblJudul.Location = New Point(16, 12)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(420, 25)
        lblJudul.TabIndex = 0
        lblJudul.Text = "Pertemuan 5 - Modul, Fungsi, Array & Koleksi Data"

        ' tabMateri
        tabMateri.Controls.Add(tpModulFungsi)
        tabMateri.Controls.Add(tpArray)
        tabMateri.Controls.Add(tpKoleksi)
        tabMateri.Location = New Point(16, 48)
        tabMateri.Name = "tabMateri"
        tabMateri.SelectedIndex = 0
        tabMateri.Size = New Size(660, 390)
        tabMateri.TabIndex = 1

        ' tpModulFungsi
        tpModulFungsi.Controls.Add(grpFungsi)
        tpModulFungsi.Location = New Point(4, 24)
        tpModulFungsi.Name = "tpModulFungsi"
        tpModulFungsi.Padding = New Padding(8)
        tpModulFungsi.Size = New Size(652, 362)
        tpModulFungsi.TabIndex = 0
        tpModulFungsi.Text = "Modul, Sub & Function"
        tpModulFungsi.UseVisualStyleBackColor = True

        ' grpFungsi
        grpFungsi.Controls.Add(lblNama)
        grpFungsi.Controls.Add(txtNama)
        grpFungsi.Controls.Add(btnSapa)
        grpFungsi.Controls.Add(lblPanjang)
        grpFungsi.Controls.Add(txtPanjang)
        grpFungsi.Controls.Add(lblLebar)
        grpFungsi.Controls.Add(txtLebar)
        grpFungsi.Controls.Add(btnHitung)
        grpFungsi.Controls.Add(lblHasilHitung)
        grpFungsi.Controls.Add(lblInfoAkses)
        grpFungsi.Location = New Point(12, 12)
        grpFungsi.Name = "grpFungsi"
        grpFungsi.Size = New Size(628, 336)
        grpFungsi.TabIndex = 0
        grpFungsi.TabStop = False
        grpFungsi.Text = "Pemanggilan Prosedur (Sub) & Fungsi (Function) dari ModPerhitungan"

        lblNama.AutoSize = True
        lblNama.Location = New Point(18, 36)
        lblNama.Name = "lblNama"
        lblNama.Size = New Size(82, 15)
        lblNama.TabIndex = 0
        lblNama.Text = "Nama Anda:"

        txtNama.Location = New Point(116, 33)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(240, 23)
        txtNama.TabIndex = 1
        txtNama.Text = "Michael Deryl"

        btnSapa.Location = New Point(372, 31)
        btnSapa.Name = "btnSapa"
        btnSapa.Size = New Size(220, 28)
        btnSapa.TabIndex = 2
        btnSapa.Text = "Panggil Sub TampilkanPesan"
        btnSapa.UseVisualStyleBackColor = True

        lblPanjang.AutoSize = True
        lblPanjang.Location = New Point(18, 86)
        lblPanjang.Name = "lblPanjang"
        lblPanjang.Size = New Size(52, 15)
        lblPanjang.TabIndex = 3
        lblPanjang.Text = "Panjang:"

        txtPanjang.Location = New Point(116, 83)
        txtPanjang.MaxLength = 6
        txtPanjang.Name = "txtPanjang"
        txtPanjang.Size = New Size(110, 23)
        txtPanjang.TabIndex = 4
        txtPanjang.Text = "12"

        lblLebar.AutoSize = True
        lblLebar.Location = New Point(246, 86)
        lblLebar.Name = "lblLebar"
        lblLebar.Size = New Size(40, 15)
        lblLebar.TabIndex = 5
        lblLebar.Text = "Lebar:"

        txtLebar.Location = New Point(296, 83)
        txtLebar.MaxLength = 6
        txtLebar.Name = "txtLebar"
        txtLebar.Size = New Size(110, 23)
        txtLebar.TabIndex = 6
        txtLebar.Text = "5"

        btnHitung.Location = New Point(422, 81)
        btnHitung.Name = "btnHitung"
        btnHitung.Size = New Size(170, 28)
        btnHitung.TabIndex = 7
        btnHitung.Text = "Hitung Luas & Keliling"
        btnHitung.UseVisualStyleBackColor = True

        lblHasilHitung.BorderStyle = BorderStyle.FixedSingle
        lblHasilHitung.Location = New Point(18, 134)
        lblHasilHitung.Name = "lblHasilHitung"
        lblHasilHitung.Padding = New Padding(8)
        lblHasilHitung.Size = New Size(574, 88)
        lblHasilHitung.TabIndex = 8
        lblHasilHitung.Text = "Tekan tombol Hitung untuk memanggil Function HitungLuas dan HitungKeliling."

        lblInfoAkses.Location = New Point(18, 238)
        lblInfoAkses.Name = "lblInfoAkses"
        lblInfoAkses.Size = New Size(574, 78)
        lblInfoAkses.TabIndex = 9
        lblInfoAkses.Text = "Access Modifier:"

        ' tpArray
        tpArray.Controls.Add(grpArray)
        tpArray.Location = New Point(4, 24)
        tpArray.Name = "tpArray"
        tpArray.Padding = New Padding(8)
        tpArray.Size = New Size(652, 362)
        tpArray.TabIndex = 1
        tpArray.Text = "Array (1D, 2D, 3D)"
        tpArray.UseVisualStyleBackColor = True

        ' grpArray
        grpArray.Controls.Add(btnArray1D)
        grpArray.Controls.Add(btnArray2D)
        grpArray.Controls.Add(btnArray3D)
        grpArray.Controls.Add(btnBersihkanArray)
        grpArray.Controls.Add(lstArray)
        grpArray.Controls.Add(lblRingkasanArray)
        grpArray.Location = New Point(12, 12)
        grpArray.Name = "grpArray"
        grpArray.Size = New Size(628, 336)
        grpArray.TabIndex = 0
        grpArray.TabStop = False
        grpArray.Text = "Demonstrasi Array Satu Dimensi & Multi-Dimensi"

        btnArray1D.Location = New Point(18, 30)
        btnArray1D.Name = "btnArray1D"
        btnArray1D.Size = New Size(138, 30)
        btnArray1D.TabIndex = 0
        btnArray1D.Text = "Tampilkan Array 1D"
        btnArray1D.UseVisualStyleBackColor = True

        btnArray2D.Location = New Point(168, 30)
        btnArray2D.Name = "btnArray2D"
        btnArray2D.Size = New Size(138, 30)
        btnArray2D.TabIndex = 1
        btnArray2D.Text = "Tampilkan Array 2D"
        btnArray2D.UseVisualStyleBackColor = True

        btnArray3D.Location = New Point(318, 30)
        btnArray3D.Name = "btnArray3D"
        btnArray3D.Size = New Size(138, 30)
        btnArray3D.TabIndex = 2
        btnArray3D.Text = "Tampilkan Array 3D"
        btnArray3D.UseVisualStyleBackColor = True

        btnBersihkanArray.Location = New Point(468, 30)
        btnBersihkanArray.Name = "btnBersihkanArray"
        btnBersihkanArray.Size = New Size(140, 30)
        btnBersihkanArray.TabIndex = 3
        btnBersihkanArray.Text = "Bersihkan Daftar"
        btnBersihkanArray.UseVisualStyleBackColor = True

        lstArray.FormattingEnabled = True
        lstArray.Location = New Point(18, 74)
        lstArray.Name = "lstArray"
        lstArray.Size = New Size(590, 204)
        lstArray.TabIndex = 4

        lblRingkasanArray.Location = New Point(18, 290)
        lblRingkasanArray.Name = "lblRingkasanArray"
        lblRingkasanArray.Size = New Size(590, 34)
        lblRingkasanArray.TabIndex = 5
        lblRingkasanArray.Text = "Pilih salah satu tombol Array di atas untuk melihat indeks dan elemennya."

        ' tpKoleksi
        tpKoleksi.Controls.Add(grpKoleksi)
        tpKoleksi.Location = New Point(4, 24)
        tpKoleksi.Name = "tpKoleksi"
        tpKoleksi.Padding = New Padding(8)
        tpKoleksi.Size = New Size(652, 362)
        tpKoleksi.TabIndex = 2
        tpKoleksi.Text = "Koleksi Data Dinamis"
        tpKoleksi.UseVisualStyleBackColor = True

        ' grpKoleksi
        grpKoleksi.Controls.Add(lblJudulList)
        grpKoleksi.Controls.Add(txtItemList)
        grpKoleksi.Controls.Add(btnTambahList)
        grpKoleksi.Controls.Add(btnHapusList)
        grpKoleksi.Controls.Add(lstDinamis)
        grpKoleksi.Controls.Add(lblJudulDict)
        grpKoleksi.Controls.Add(txtKeyDict)
        grpKoleksi.Controls.Add(btnCariDict)
        grpKoleksi.Controls.Add(lblHasilDict)
        grpKoleksi.Controls.Add(lblJudulSet)
        grpKoleksi.Controls.Add(txtAngkaSet)
        grpKoleksi.Controls.Add(btnTambahSet)
        grpKoleksi.Controls.Add(lstSet)
        grpKoleksi.Controls.Add(lblStatusSet)
        grpKoleksi.Location = New Point(12, 12)
        grpKoleksi.Name = "grpKoleksi"
        grpKoleksi.Size = New Size(628, 336)
        grpKoleksi.TabIndex = 0
        grpKoleksi.TabStop = False
        grpKoleksi.Text = "List(Of T), Dictionary(Of TKey, TValue), dan HashSet(Of T)"

        ' Kolom kiri: List(Of String)
        lblJudulList.AutoSize = True
        lblJudulList.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblJudulList.Location = New Point(16, 28)
        lblJudulList.Name = "lblJudulList"
        lblJudulList.Size = New Size(130, 15)
        lblJudulList.TabIndex = 0
        lblJudulList.Text = "1. List(Of String)"

        txtItemList.Location = New Point(16, 50)
        txtItemList.Name = "txtItemList"
        txtItemList.Size = New Size(178, 23)
        txtItemList.TabIndex = 1

        btnTambahList.Location = New Point(16, 80)
        btnTambahList.Name = "btnTambahList"
        btnTambahList.Size = New Size(86, 26)
        btnTambahList.TabIndex = 2
        btnTambahList.Text = "Tambah"
        btnTambahList.UseVisualStyleBackColor = True

        btnHapusList.Location = New Point(108, 80)
        btnHapusList.Name = "btnHapusList"
        btnHapusList.Size = New Size(86, 26)
        btnHapusList.TabIndex = 3
        btnHapusList.Text = "Hapus"
        btnHapusList.UseVisualStyleBackColor = True

        lstDinamis.FormattingEnabled = True
        lstDinamis.Location = New Point(16, 114)
        lstDinamis.Name = "lstDinamis"
        lstDinamis.Size = New Size(178, 199)
        lstDinamis.TabIndex = 4

        ' Kolom tengah: Dictionary
        lblJudulDict.AutoSize = True
        lblJudulDict.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblJudulDict.Location = New Point(218, 28)
        lblJudulDict.Name = "lblJudulDict"
        lblJudulDict.Size = New Size(185, 15)
        lblJudulDict.TabIndex = 5
        lblJudulDict.Text = "2. Dictionary (Key: NIM/Nama/Prodi)"

        txtKeyDict.Location = New Point(218, 50)
        txtKeyDict.Name = "txtKeyDict"
        txtKeyDict.Size = New Size(188, 23)
        txtKeyDict.TabIndex = 6
        txtKeyDict.Text = "Nama"

        btnCariDict.Location = New Point(218, 80)
        btnCariDict.Name = "btnCariDict"
        btnCariDict.Size = New Size(188, 26)
        btnCariDict.TabIndex = 7
        btnCariDict.Text = "Cari Berdasarkan Key"
        btnCariDict.UseVisualStyleBackColor = True

        lblHasilDict.BorderStyle = BorderStyle.FixedSingle
        lblHasilDict.Location = New Point(218, 114)
        lblHasilDict.Name = "lblHasilDict"
        lblHasilDict.Padding = New Padding(6)
        lblHasilDict.Size = New Size(188, 199)
        lblHasilDict.TabIndex = 8
        lblHasilDict.Text = "Ketik key NIM, Nama, atau Prodi lalu klik Cari."

        ' Kolom kanan: HashSet
        lblJudulSet.AutoSize = True
        lblJudulSet.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblJudulSet.Location = New Point(428, 28)
        lblJudulSet.Name = "lblJudulSet"
        lblJudulSet.Size = New Size(170, 15)
        lblJudulSet.TabIndex = 9
        lblJudulSet.Text = "3. HashSet(Of Integer) (Unik)"

        txtAngkaSet.Location = New Point(428, 50)
        txtAngkaSet.Name = "txtAngkaSet"
        txtAngkaSet.Size = New Size(180, 23)
        txtAngkaSet.TabIndex = 10
        txtAngkaSet.Text = "20"

        btnTambahSet.Location = New Point(428, 80)
        btnTambahSet.Name = "btnTambahSet"
        btnTambahSet.Size = New Size(180, 26)
        btnTambahSet.TabIndex = 11
        btnTambahSet.Text = "Tambah Angka ke Set"
        btnTambahSet.UseVisualStyleBackColor = True

        lstSet.FormattingEnabled = True
        lstSet.Location = New Point(428, 114)
        lstSet.Name = "lstSet"
        lstSet.Size = New Size(180, 147)
        lstSet.TabIndex = 12

        lblStatusSet.Location = New Point(428, 268)
        lblStatusSet.Name = "lblStatusSet"
        lblStatusSet.Size = New Size(180, 48)
        lblStatusSet.TabIndex = 13
        lblStatusSet.Text = "Total elemen unik: 2"

        ' FrmKoleksi
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(692, 454)
        Controls.Add(tabMateri)
        Controls.Add(lblJudul)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FrmKoleksi"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Pertemuan 5 - Modul, Fungsi, Array & Koleksi Data"

        tabMateri.ResumeLayout(False)
        tpModulFungsi.ResumeLayout(False)
        grpFungsi.ResumeLayout(False)
        grpFungsi.PerformLayout()
        tpArray.ResumeLayout(False)
        grpArray.ResumeLayout(False)
        tpKoleksi.ResumeLayout(False)
        grpKoleksi.ResumeLayout(False)
        grpKoleksi.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents tabMateri As TabControl
    Friend WithEvents tpModulFungsi As TabPage
    Friend WithEvents grpFungsi As GroupBox
    Friend WithEvents lblNama As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents btnSapa As Button
    Friend WithEvents lblPanjang As Label
    Friend WithEvents txtPanjang As TextBox
    Friend WithEvents lblLebar As Label
    Friend WithEvents txtLebar As TextBox
    Friend WithEvents btnHitung As Button
    Friend WithEvents lblHasilHitung As Label
    Friend WithEvents lblInfoAkses As Label
    Friend WithEvents tpArray As TabPage
    Friend WithEvents grpArray As GroupBox
    Friend WithEvents btnArray1D As Button
    Friend WithEvents btnArray2D As Button
    Friend WithEvents btnArray3D As Button
    Friend WithEvents btnBersihkanArray As Button
    Friend WithEvents lstArray As ListBox
    Friend WithEvents lblRingkasanArray As Label
    Friend WithEvents tpKoleksi As TabPage
    Friend WithEvents grpKoleksi As GroupBox
    Friend WithEvents lblJudulList As Label
    Friend WithEvents txtItemList As TextBox
    Friend WithEvents btnTambahList As Button
    Friend WithEvents btnHapusList As Button
    Friend WithEvents lstDinamis As ListBox
    Friend WithEvents lblJudulDict As Label
    Friend WithEvents txtKeyDict As TextBox
    Friend WithEvents btnCariDict As Button
    Friend WithEvents lblHasilDict As Label
    Friend WithEvents lblJudulSet As Label
    Friend WithEvents txtAngkaSet As TextBox
    Friend WithEvents btnTambahSet As Button
    Friend WithEvents lstSet As ListBox
    Friend WithEvents lblStatusSet As Label
End Class
