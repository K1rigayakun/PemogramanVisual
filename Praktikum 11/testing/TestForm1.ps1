Add-Type -AssemblyName System.Windows.Forms
Add-Type -AssemblyName System.Drawing

$dllPath = "M:\Smester 5\VISPRO PRAK\Praktikum pertemuan 11\bin\Debug\net10.0-windows\Praktikum pertemuan 11.dll"
if (-not (Test-Path $dllPath)) {
    Write-Error "Assembly not found: $dllPath"
    exit 1
}

$bytes = [System.IO.File]::ReadAllBytes($dllPath)
$asm = [System.Reflection.Assembly]::Load($bytes)

Write-Host "Assembly loaded successfully."

# 1. Test ModWindowsApi
$modType = $asm.GetType("Praktikum_pertemuan_11.ModWindowsApi")
if ($null -eq $modType) {
    Write-Error "ModWindowsApi not found in assembly."
    exit 1
}

$sisaMethod = $modType.GetMethod("HitungSisa")
$formatMethod = $modType.GetMethod("FormatSisa")

$sisa = $sisaMethod.Invoke($null, @([ulong]300000, [ulong]60000))
$format = $formatMethod.Invoke($null, @([ulong]240000))
Write-Host "ModWindowsApi test: HitungSisa(300000, 60000) = $sisa, FormatSisa(240000) = $format"

if ($sisa -ne [ulong]240000 -or $format -ne "04:00") {
    Write-Error "Calculation mismatch in ModWindowsApi"
    exit 1
}

# 2. Test Form1
$formType = $asm.GetType("Praktikum_pertemuan_11.Form1")
if ($null -eq $formType) {
    Write-Error "Form1 not found in assembly."
    exit 1
}

$form = [Activator]::CreateInstance($formType)

# Show form briefly off-screen to initialize handles and layout
$form.StartPosition = [System.Windows.Forms.FormStartPosition]::Manual
$form.Location = New-Object System.Drawing.Point(-2000, -2000)
$form.Show()
[System.Windows.Forms.Application]::DoEvents()

Write-Host "Form1 properties:"
Write-Host "  Text: $($form.Text)"
Write-Host "  lblTahap: $($form.lblTahap.Text)"
Write-Host "  lblSisa: $($form.lblSisa.Text)"
Write-Host "  btnMulai: $($form.btnMulai.Text)"
Write-Host "  nudMenit: $($form.nudMenit.Value)"
Write-Host "  nudDetik: $($form.nudDetik.Value)"
Write-Host "  chkTeratas: $($form.chkTeratas.Checked)"
Write-Host "  chkBunyi: $($form.chkBunyi.Checked)"

# Screenshot 1: Normal mode
$bmpNormal = New-Object System.Drawing.Bitmap($form.Width, $form.Height)
$form.DrawToBitmap($bmpNormal, (New-Object System.Drawing.Rectangle(0, 0, $form.Width, $form.Height)))
$ssNormal = "M:\Smester 5\VISPRO PRAK\Praktikum pertemuan 11\testing\screenshoot\form_normal.png"
$bmpNormal.Save($ssNormal, [System.Drawing.Imaging.ImageFormat]::Png)
$bmpNormal.Dispose()
Write-Host "Saved normal screenshot to $ssNormal"

# Test Ringkas Mode
$form.btnRingkas.PerformClick()
[System.Windows.Forms.Application]::DoEvents()
Write-Host "After btnRingkas click: pnlPengaturan.Visible = $($form.pnlPengaturan.Visible), btnRingkas.Text = $($form.btnRingkas.Text)"

# Screenshot 2: Compact mode
$bmpCompact = New-Object System.Drawing.Bitmap($form.Width, $form.Height)
$form.DrawToBitmap($bmpCompact, (New-Object System.Drawing.Rectangle(0, 0, $form.Width, $form.Height)))
$ssCompact = "M:\Smester 5\VISPRO PRAK\Praktikum pertemuan 11\testing\screenshoot\form_compact.png"
$bmpCompact.Save($ssCompact, [System.Drawing.Imaging.ImageFormat]::Png)
$bmpCompact.Dispose()
Write-Host "Saved compact screenshot to $ssCompact"

$form.Close()
$form.Dispose()
Write-Host "ALL TESTS PASSED SUCCESSFULLY!"
