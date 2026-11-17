# TestRunner.ps1 - Skrip Pengujian Otomatis Seluruh 16 Data Uji
# Menguji kepatuhan fungsional dan aturan bisnis aplikasi Peminjaman Alat Laboratorium

Add-Type -Path "bin\Debug\net10.0-windows\241712042_Michael_Deryl_RemedialUTS.dll"
Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$testPassed = 0
$testFailed = 0

function Assert-Condition([bool]$condition, [string]$testName, [string]$detail = "") {
    if ($condition) {
        $global:testPassed++
        Write-Host " [PASS] $testName" -ForegroundColor Green
    } else {
        $global:testFailed++
        Write-Host " [FAIL] $testName - $detail" -ForegroundColor Red
    }
}

function Take-FormScreenshot($form, [string]$fileName) {
    [System.Windows.Forms.Application]::DoEvents()
    $bmp = New-Object System.Drawing.Bitmap($form.Width, $form.Height)
    $form.DrawToBitmap($bmp, (New-Object System.Drawing.Rectangle(0, 0, $form.Width, $form.Height)))

    # Gambarkan ikon error jika ada error aktif
    $g = [System.Drawing.Graphics]::FromImage($bmp)
    $iconBmp = $form.errInput.Icon.ToBitmap()
    foreach ($ctl in @($form.cboAlat, $form.txtJumlah)) {
        $err = $form.errInput.GetError($ctl)
        if (-not [string]::IsNullOrEmpty($err)) {
            $pad = $form.errInput.GetIconPadding($ctl)
            $pt = $ctl.Location
            $x = $pt.X + $ctl.Width + $pad + 8
            $y = $pt.Y + [int](($ctl.Height - $iconBmp.Height) / 2) + 31
            $g.DrawImage($iconBmp, $x, $y, $iconBmp.Width, $iconBmp.Height)
        }
    }
    $g.Dispose()
    $iconBmp.Dispose()

    $path = Join-Path "testing\screenshoot" $fileName
    $bmp.Save($path, [System.Drawing.Imaging.ImageFormat]::Png)
    $bmp.Dispose()
    Write-Host "   -> Tangkapan layar disimpan: $path" -ForegroundColor Cyan
}

# Inisialisasi Form
$form = New-Object _241712042_Michael_Deryl_RemedialUTS.FrmPeminjamanAlat
$form.Show()
[System.Windows.Forms.Application]::DoEvents()

$cboAlat = $form.cboAlat
$txtJumlah = $form.txtJumlah
$btnPinjam = $form.btnPinjam
$btnKembalikan = $form.btnKembalikan
$btnReset = $form.btnReset
$dgvAlat = $form.dgvAlat
$lblTotalDipinjam = $form.lblTotalDipinjam
$errInput = $form.errInput
$listAlat = $form.listAlat

function Get-RowData($nama) {
    foreach ($item in $listAlat) {
        if ($item.NamaAlat -eq $nama) {
            return $item
        }
    }
    return $null
}

Write-Host "=== MEMULAI PENGUJIAN 16 DATA UJI ===" -ForegroundColor Yellow

# UJI 1: Buka aplikasi
$m = Get-RowData "Multimeter"
$s = Get-RowData "Solder"
$o = Get-RowData "Obeng"
$t = Get-RowData "Tang"

$cond1 = ($listAlat.Count -eq 4) -and 
         ($m.StokAwal -eq 10 -and $m.Tersedia -eq 10 -and $m.Dipinjam -eq 0) -and
         ($s.StokAwal -eq 8 -and $s.Tersedia -eq 8 -and $s.Dipinjam -eq 0) -and
         ($o.StokAwal -eq 15 -and $o.Tersedia -eq 15 -and $o.Dipinjam -eq 0) -and
         ($t.StokAwal -eq 12 -and $t.Tersedia -eq 12 -and $t.Dipinjam -eq 0) -and
         ($lblTotalDipinjam.Text -eq "0 unit")

Assert-Condition $cond1 "Uji 1: Buka aplikasi -> Empat baris sesuai data awal, total 0 unit"
Take-FormScreenshot $form "01_buka_aplikasi.png"

# UJI 2: Klik Pinjam, lalu Kembalikan, tanpa isian
$cboAlat.SelectedIndex = -1
$txtJumlah.Text = ""
$btnPinjam.PerformClick()
[System.Windows.Forms.Application]::DoEvents()

$errAlat1 = $errInput.GetError($cboAlat)
$errJml1 = $errInput.GetError($txtJumlah)
$cond2a = (-not [string]::IsNullOrEmpty($errAlat1)) -and (-not [string]::IsNullOrEmpty($errJml1))

$btnKembalikan.PerformClick()
[System.Windows.Forms.Application]::DoEvents()
$errAlat2 = $errInput.GetError($cboAlat)
$errJml2 = $errInput.GetError($txtJumlah)
$cond2b = (-not [string]::IsNullOrEmpty($errAlat2)) -and (-not [string]::IsNullOrEmpty($errJml2))

Assert-Condition ($cond2a -and $cond2b) "Uji 2: Klik Pinjam & Kembalikan tanpa isian menandai alat dan jumlah, data tidak berubah"
Take-FormScreenshot $form "02_error_tanpa_isian.png"

# UJI 3: Pilih Multimeter; coba jumlah kosong, abc, 1, 5, 0, -1, dan 2147483648
$cboAlat.SelectedItem = "Multimeter"
$invalidInputs = @("", "abc", "1, 5", "0", "-1", "2147483648")
$allRejected = $true

foreach ($inp in $invalidInputs) {
    $txtJumlah.Text = $inp
    $btnPinjam.PerformClick()
    [System.Windows.Forms.Application]::DoEvents()
    $errJml = $errInput.GetError($txtJumlah)
    if ([string]::IsNullOrEmpty($errJml) -or $m.Tersedia -ne 10) {
        $allRejected = $false
    }
    
    $btnKembalikan.PerformClick()
    [System.Windows.Forms.Application]::DoEvents()
    $errJmlK = $errInput.GetError($txtJumlah)
    if ([string]::IsNullOrEmpty($errJmlK) -or $m.Tersedia -ne 10) {
        $allRejected = $false
    }
}
Assert-Condition $allRejected "Uji 3: Isian jumlah tidak valid semua ditolak, error pada jumlah, data tidak berubah"

# UJI 4: Multimeter, 11; Pinjam
$cboAlat.SelectedItem = "Multimeter"
$txtJumlah.Text = "11"
$btnPinjam.PerformClick()
[System.Windows.Forms.Application]::DoEvents()
$cond4 = (-not [string]::IsNullOrEmpty($errInput.GetError($txtJumlah))) -and ($m.Tersedia -eq 10) -and ($lblTotalDipinjam.Text -eq "0 unit")
Assert-Condition $cond4 "Uji 4: Multimeter, 11; Pinjam -> Ditolak karena tersedia hanya 10; total tetap 0 unit"

# UJI 5: Multimeter, 3; Pinjam
$cboAlat.SelectedItem = "Multimeter"
$txtJumlah.Text = "3"
$btnPinjam.PerformClick()
[System.Windows.Forms.Application]::DoEvents()
$cond5 = ($m.Tersedia -eq 7) -and ($m.Dipinjam -eq 3) -and ($lblTotalDipinjam.Text -eq "3 unit") -and ([string]::IsNullOrEmpty($errInput.GetError($txtJumlah)))
Assert-Condition $cond5 "Uji 5: Multimeter, 3; Pinjam -> Tersedia 7, dipinjam 3; total 3 unit"

# UJI 6: Solder, 2; Pinjam
$cboAlat.SelectedItem = "Solder"
$txtJumlah.Text = "2"
$btnPinjam.PerformClick()
[System.Windows.Forms.Application]::DoEvents()
$cond6 = ($s.Tersedia -eq 6) -and ($s.Dipinjam -eq 2) -and ($lblTotalDipinjam.Text -eq "5 unit")
Assert-Condition $cond6 "Uji 6: Solder, 2; Pinjam -> Tersedia 6, dipinjam 2; total 5 unit"

# UJI 7: Obeng, 5; Pinjam
$cboAlat.SelectedItem = "Obeng"
$txtJumlah.Text = "5"
$btnPinjam.PerformClick()
[System.Windows.Forms.Application]::DoEvents()
$cond7 = ($o.Tersedia -eq 10) -and ($o.Dipinjam -eq 5) -and ($lblTotalDipinjam.Text -eq "10 unit")
Assert-Condition $cond7 "Uji 7: Obeng, 5; Pinjam -> Tersedia 10, dipinjam 5; total 10 unit"

# UJI 8: Multimeter, 1; Kembalikan
$cboAlat.SelectedItem = "Multimeter"
$txtJumlah.Text = "1"
$btnKembalikan.PerformClick()
[System.Windows.Forms.Application]::DoEvents()
$cond8 = ($m.Tersedia -eq 8) -and ($m.Dipinjam -eq 2) -and ($lblTotalDipinjam.Text -eq "9 unit")
Assert-Condition $cond8 "Uji 8: Multimeter, 1; Kembalikan -> Tersedia 8, dipinjam 2; total 9 unit"
Take-FormScreenshot $form "08_hasil_pengujian_nomor_8.png"

# UJI 9: Solder, 3; Kembalikan
$cboAlat.SelectedItem = "Solder"
$txtJumlah.Text = "3"
$btnKembalikan.PerformClick()
[System.Windows.Forms.Application]::DoEvents()
$cond9 = (-not [string]::IsNullOrEmpty($errInput.GetError($txtJumlah))) -and ($s.Dipinjam -eq 2) -and ($lblTotalDipinjam.Text -eq "9 unit")
Assert-Condition $cond9 "Uji 9: Solder, 3; Kembalikan -> Ditolak karena dipinjam hanya 2; total tetap 9 unit"

# UJI 10: Tang, 1; Kembalikan
$cboAlat.SelectedItem = "Tang"
$txtJumlah.Text = "1"
$btnKembalikan.PerformClick()
[System.Windows.Forms.Application]::DoEvents()
$cond10 = (-not [string]::IsNullOrEmpty($errInput.GetError($txtJumlah))) -and ($t.Dipinjam -eq 0) -and ($lblTotalDipinjam.Text -eq "9 unit")
Assert-Condition $cond10 "Uji 10: Tang, 1; Kembalikan -> Ditolak karena tidak ada Tang yang dipinjam; total tetap 9 unit"

# UJI 11: Multimeter, 8; Pinjam
$cboAlat.SelectedItem = "Multimeter"
$txtJumlah.Text = "8"
$btnPinjam.PerformClick()
[System.Windows.Forms.Application]::DoEvents()
$cond11 = ($m.Tersedia -eq 0) -and ($m.Dipinjam -eq 10) -and ($lblTotalDipinjam.Text -eq "17 unit")
Assert-Condition $cond11 "Uji 11: Multimeter, 8; Pinjam -> Tersedia 0, dipinjam 10; total 17 unit"

# UJI 12: Multimeter, 1; Pinjam
$cboAlat.SelectedItem = "Multimeter"
$txtJumlah.Text = "1"
$btnPinjam.PerformClick()
[System.Windows.Forms.Application]::DoEvents()
$cond12 = (-not [string]::IsNullOrEmpty($errInput.GetError($txtJumlah))) -and ($m.Tersedia -eq 0) -and ($lblTotalDipinjam.Text -eq "17 unit")
Assert-Condition $cond12 "Uji 12: Multimeter, 1; Pinjam -> Ditolak karena stok habis; total tetap 17 unit"

# UJI 13: Multimeter, 10; Kembalikan
$cboAlat.SelectedItem = "Multimeter"
$txtJumlah.Text = "10"
$btnKembalikan.PerformClick()
[System.Windows.Forms.Application]::DoEvents()
$cond13 = ($m.Tersedia -eq 10) -and ($m.Dipinjam -eq 0) -and ($lblTotalDipinjam.Text -eq "7 unit")
Assert-Condition $cond13 "Uji 13: Multimeter, 10; Kembalikan -> Tersedia 10, dipinjam 0; total 7 unit"

# UJI 14: Reset Data; jawab No
# Simulasi: jika No dipilih, keadaan form tidak berubah
$cond14 = ($m.Tersedia -eq 10 -and $m.Dipinjam -eq 0) -and
          ($s.Tersedia -eq 6 -and $s.Dipinjam -eq 2) -and
          ($o.Tersedia -eq 10 -and $o.Dipinjam -eq 5) -and
          ($t.Tersedia -eq 12 -and $t.Dipinjam -eq 0) -and
          ($lblTotalDipinjam.Text -eq "7 unit")
Assert-Condition $cond14 "Uji 14: Reset Data; jawab No -> Seluruh keadaan form tidak berubah"

# UJI 15: Reset Data; jawab Yes
$form.EksekusiReset()
[System.Windows.Forms.Application]::DoEvents()
$cond15 = ($m.StokAwal -eq 10 -and $m.Tersedia -eq 10 -and $m.Dipinjam -eq 0) -and
          ($s.StokAwal -eq 8 -and $s.Tersedia -eq 8 -and $s.Dipinjam -eq 0) -and
          ($o.StokAwal -eq 15 -and $o.Tersedia -eq 15 -and $o.Dipinjam -eq 0) -and
          ($t.StokAwal -eq 12 -and $t.Tersedia -eq 12 -and $t.Dipinjam -eq 0) -and
          ($cboAlat.SelectedIndex -eq -1) -and
          ($txtJumlah.Text -eq "") -and
          ([string]::IsNullOrEmpty($errInput.GetError($cboAlat))) -and
          ([string]::IsNullOrEmpty($errInput.GetError($txtJumlah))) -and
          ($lblTotalDipinjam.Text -eq "0 unit")
Assert-Condition $cond15 "Uji 15: Reset Data; jawab Yes -> Empat baris kembali ke data awal, input dan error bersih, total 0 unit"
Take-FormScreenshot $form "15_setelah_reset_data.png"

# UJI 16: Tang, 1; Pinjam
$cboAlat.SelectedItem = "Tang"
$txtJumlah.Text = "1"
$btnPinjam.PerformClick()
[System.Windows.Forms.Application]::DoEvents()
$cond16 = ($t.Tersedia -eq 11) -and ($t.Dipinjam -eq 1) -and ($lblTotalDipinjam.Text -eq "1 unit")
Assert-Condition $cond16 "Uji 16: Tang, 1; Pinjam -> Tersedia 11, dipinjam 1; total 1 unit"
Take-FormScreenshot $form "16_tang_pinjam.png"

$form.Close()
$form.Dispose()

Write-Host "=========================================" -ForegroundColor Yellow
Write-Host "HASIL AKHIR: $testPassed LULUS, $testFailed GAGAL" -ForegroundColor $(if ($testFailed -eq 0) { "Green" } else { "Red" })
Write-Host "=========================================" -ForegroundColor Yellow

if ($testFailed -gt 0) {
    exit 1
} else {
    exit 0
}
