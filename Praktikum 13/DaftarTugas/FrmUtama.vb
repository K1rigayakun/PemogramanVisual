Imports System.Drawing
Imports System.Net.Http
Imports System.Windows.Forms

Module Program
    <STAThread>
    Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New FrmUtama())
    End Sub
End Module

Friend Class FrmUtama
    Inherits Form

    Private ReadOnly txtEmail As New TextBox With {.Dock = DockStyle.Fill}
    Private ReadOnly txtPassword As New TextBox With {.Dock = DockStyle.Fill, .UseSystemPasswordChar = True}
    Private ReadOnly txtJudul As New TextBox With {.Dock = DockStyle.Fill, .MaxLength = 100}
    Private ReadOnly lstTugas As New ListBox With {.Dock = DockStyle.Fill, .DisplayMember = NameOf(Tugas.Judul)}
    Private ReadOnly btnMasuk As New Button With {.Text = "Masuk", .AutoSize = True}
    Private ReadOnly btnKeluar As New Button With {.Text = "Keluar dari sesi", .AutoSize = True}
    Private ReadOnly btnMuat As New Button With {.Text = "Muat ulang", .AutoSize = True}
    Private ReadOnly btnSimpan As New Button With {.Text = "Simpan judul", .AutoSize = True}
    Private ReadOnly lblStatus As New Label With {.Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleLeft}
    Private token As String
    Private sibuk As Boolean

    Public Sub New()
        Text = "Daftar Tugas"
        Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        Font = New Font("Segoe UI", 10)
        AutoScaleMode = AutoScaleMode.Font
        StartPosition = FormStartPosition.CenterScreen
        ClientSize = New Size(560, 400)
        MinimumSize = New Size(500, 410)

        Dim panel As New TableLayoutPanel With {
            .Dock = DockStyle.Fill, .ColumnCount = 2, .RowCount = 7,
            .Padding = New Padding(16)
        }
        panel.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
        panel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
        panel.RowStyles.Add(New RowStyle(SizeType.Absolute, 34))
        panel.RowStyles.Add(New RowStyle(SizeType.Absolute, 34))
        panel.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        panel.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
        panel.RowStyles.Add(New RowStyle(SizeType.Absolute, 34))
        panel.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
        panel.RowStyles.Add(New RowStyle(SizeType.Absolute, 46))
        panel.Controls.Add(New Label With {.Text = "Email", .AutoSize = True}, 0, 0)
        panel.Controls.Add(txtEmail, 1, 0)
        panel.Controls.Add(New Label With {.Text = "Kata sandi", .AutoSize = True}, 0, 1)
        panel.Controls.Add(txtPassword, 1, 1)
        AddFullRow(panel, 2, Buttons(btnMasuk, btnKeluar, btnMuat))
        lstTugas.AccessibleName = "Daftar tugas"
        AddFullRow(panel, 3, lstTugas)
        panel.Controls.Add(New Label With {.Text = "Judul tugas", .AutoSize = True}, 0, 4)
        panel.Controls.Add(txtJudul, 1, 4)
        AddFullRow(panel, 5, Buttons(btnSimpan))
        AddFullRow(panel, 6, lblStatus)
        Controls.Add(panel)
        AcceptButton = btnMasuk

        AddHandler btnMasuk.Click, AddressOf Masuk
        AddHandler btnKeluar.Click, AddressOf Keluar
        AddHandler btnMuat.Click, AddressOf Muat
        AddHandler btnSimpan.Click, AddressOf Simpan
        AddHandler lstTugas.SelectedIndexChanged, AddressOf PilihTugas
        Keluar(Me, EventArgs.Empty)
    End Sub

    Private Shared Function Buttons(ParamArray controls As Button()) As FlowLayoutPanel
        Dim panel As New FlowLayoutPanel With {.Dock = DockStyle.Fill, .Margin = Padding.Empty}
        panel.Controls.AddRange(controls)
        Return panel
    End Function

    Private Shared Sub AddFullRow(panel As TableLayoutPanel, row As Integer, control As Control)
        panel.Controls.Add(control, 0, row)
        panel.SetColumnSpan(control, 2)
    End Sub

    Private Async Sub Masuk(sender As Object, e As EventArgs)
        If txtEmail.Text.Trim() = "" OrElse txtPassword.Text = "" Then
            lblStatus.Text = "Isi email dan kata sandi."
            Return
        End If
        Dim password = txtPassword.Text
        txtPassword.Clear()
        Await JalankanAsync(Async Function()
                                token = Await SupabaseApi.LoginAsync(txtEmail.Text.Trim(), password)
                                Await MuatDataAsync()
                            End Function)
    End Sub

    Private Sub Keluar(sender As Object, e As EventArgs)
        token = Nothing
        txtPassword.Clear()
        lstTugas.DataSource = Nothing
        txtJudul.Clear()
        lblStatus.Text = "Masuk untuk melihat tugas Anda."
        AturKontrol()
    End Sub

    Private Async Sub Muat(sender As Object, e As EventArgs)
        Await JalankanAsync(Function() MuatDataAsync())
    End Sub

    Private Async Function MuatDataAsync(Optional pilih As Guid = Nothing) As Task
        Dim rows = Await SupabaseApi.ListAsync(token)
        lstTugas.DataSource = rows
        Dim index = rows.FindIndex(Function(row) row.Id = pilih)
        If index >= 0 Then lstTugas.SelectedIndex = index
        lblStatus.Text = If(rows.Count = 0, "Akun ini belum memiliki tugas.", $"{rows.Count} tugas dimuat.")
    End Function

    Private Sub PilihTugas(sender As Object, e As EventArgs)
        Dim selected = TryCast(lstTugas.SelectedItem, Tugas)
        txtJudul.Text = If(selected?.Judul, "")
        AturKontrol()
    End Sub

    Private Async Sub Simpan(sender As Object, e As EventArgs)
        Dim selected = TryCast(lstTugas.SelectedItem, Tugas)
        Dim judul = txtJudul.Text.Trim()
        If selected Is Nothing OrElse judul = "" Then
            lblStatus.Text = "Pilih tugas dan isi judul baru."
            Return
        End If
        Await JalankanAsync(Async Function()
                                If Await SupabaseApi.UpdateAsync(token, selected.Id, judul) Then
                                    Await MuatDataAsync(selected.Id)
                                    lblStatus.Text = "Judul berhasil disimpan."
                                Else
                                    lblStatus.Text = "Tidak ada data yang diubah. Muat ulang daftar tugas."
                                End If
                            End Function)
    End Sub

    Private Async Function JalankanAsync(kegiatan As Func(Of Task)) As Task
        sibuk = True
        lblStatus.Text = "Memproses permintaan..."
        AturKontrol()
        Try
            Await kegiatan()
        Catch ex As InvalidOperationException
            lblStatus.Text = ex.Message
        Catch ex As HttpRequestException
            lblStatus.Text = If(ex.StatusCode.HasValue,
                                $"Permintaan ditolak (HTTP {CInt(ex.StatusCode.GetValueOrDefault())}).",
                                "Supabase tidak dapat dijangkau. Periksa koneksi internet.")
        Catch ex As OperationCanceledException
            lblStatus.Text = "Waktu permintaan habis. Coba lagi."
        Catch ex As System.Text.Json.JsonException
            lblStatus.Text = "Format respons server tidak sesuai."
        Finally
            sibuk = False
            AturKontrol()
        End Try
    End Function

    Private Sub AturKontrol()
        Dim masuk = token IsNot Nothing
        txtEmail.Enabled = Not sibuk AndAlso Not masuk
        txtPassword.Enabled = txtEmail.Enabled
        btnMasuk.Enabled = txtEmail.Enabled
        btnKeluar.Enabled = Not sibuk AndAlso masuk
        btnMuat.Enabled = btnKeluar.Enabled
        lstTugas.Enabled = btnKeluar.Enabled
        btnSimpan.Enabled = btnKeluar.Enabled AndAlso lstTugas.SelectedItem IsNot Nothing
        txtJudul.Enabled = btnSimpan.Enabled
    End Sub
End Class
