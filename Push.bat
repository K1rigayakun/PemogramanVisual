@echo off
if "%~1"=="" (
    start "Git Auto Push" cmd /k "%~f0" run
    exit /b
)

title Git Auto Push
cd /d "%~dp0"

echo ==============================
echo   GIT ADD - COMMIT - PUSH
echo ==============================
echo Folder: %cd%
echo.

git rev-parse --is-inside-work-tree >nul 2>&1
if errorlevel 1 (
    echo [ERROR] Folder ini bukan git repository, atau git belum terinstall / tidak ada di PATH.
    echo.
    pause
    goto :eof
)

set "haschanges="
for /f "delims=" %%i in ('git status --porcelain') do set "haschanges=1"

if not defined haschanges (
    echo [INFO] Tidak ada perubahan untuk di-commit.
    echo.
    pause
    goto :eof
)

echo Perubahan terdeteksi:
git status -s
echo.

git add .

set /p commitmsg="Masukkan pesan commit: "

if "%commitmsg%"=="" (
    echo [ERROR] Pesan commit tidak boleh kosong.
    echo.
    pause
    goto :eof
)

git commit -m "%commitmsg%"

for /f "delims=" %%b in ('git branch --show-current') do set "branch=%%b"

echo.
echo Push ke branch: %branch%
git push origin %branch%

echo.
echo [DONE] Selesai.
echo.
pause