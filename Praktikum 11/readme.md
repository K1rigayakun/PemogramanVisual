# Pertemuan 11: Windows API (P/Invoke) — Asisten Presentasi

*(Catatan: Pertemuan 9 dan 10 merupakan jadwal UTS / Responsi sehingga modul praktikum reguler berlanjut langsung ke Pertemuan 11.)*

## 1. Gambaran Umum & Analogi

Pada Pertemuan 11 di proyek [Praktikum 11](./Praktikum%20pertemuan%2011.slnx), kita membuat aplikasi nyata **"Asisten Presentasi"**: sebuah timer hitung mundur yang bisa melayang di atas slide PowerPoint dan dikendalikan memakai pintasan keyboard global (`Ctrl+Alt+F9` dan `Ctrl+Alt+F10`).

Bayangkan aplikasi WinForms kita adalah seorang **tamu di dalam gedung perkantoran Windows**:
- Untuk tugas normal (menghitung angka, mengganti teks label), aplikasi cukup mengurus dirinya sendiri menggunakan .NET.
- Namun untuk tugas tingkat sistem operasi—seperti **memaksa jendela tetap di lapisan paling atas mengalahkan semua aplikasi lain**, **mendengar tombol keyboard meskipun aplikasi sedang tidak fokus**, atau **memutar bunyi peringatan standar Windows**—aplikasi harus "mengetuk pintu" dan memanggil fungsi asli milik sistem operasi Windows (`user32.dll` dan `kernel32.dll`).
- Jembatan pemanggil fungsi asli Windows dari dalam kode .NET inilah yang disebut **Windows API / P/Invoke (`Platform Invoke`)**.

---

## 2. Ringkasan Konsep Materi

### 5 Fungsi Windows API yang Digunakan di [ModWindowsApi.vb](./ModWindowsApi.vb)

| Nama Fungsi API | Pustaka DLL | Cara Deklarasi | Kegunaan di Aplikasi |
| :--- | :--- | :--- | :--- |
| **`GetTickCount64`** | `kernel32.dll` | `Public Declare Function ...` | Membaca waktu sistem dalam milidetik sejak komputer menyala, untuk menghitung waktu berlalu dengan presisi tinggi (tidak meleset seperti `Timer` biasa). |
| **`MessageBeep`** | `user32.dll` | `Public Declare Function ...` | Memutar suara notifikasi sistem Windows (`MB_ICONINFORMATION = &H40UI`) saat durasi presentasi habis. |
| **`SetWindowPos`** | `user32.dll` | `<DllImport("user32.dll", ...)>` | Mengubah posisi lapisan Z (*Z-order*) jendela ke `HWND_TOPMOST` (selalu di atas) atau `HWND_NOTOPMOST` (normal) tanpa mengubah ukuran/posisi (`SWP_NOMOVE Or SWP_NOSIZE`). |
| **`RegisterHotKey`** | `user32.dll` | `<DllImport("user32.dll", ...)>` | Mendaftarkan shortcut keyboard global (`Ctrl+Alt+F9` untuk mulai/jeda dan `Ctrl+Alt+F10` untuk ulangi) agar tetap berfungsi walau jendela presentasi PowerPoint yang sedang aktif. |
| **`UnregisterHotKey`** | `user32.dll` | `<DllImport("user32.dll", ...)>` | Melepaskan kembali pendaftaran hotkey saat handle Form dihancurkan (`HandleDestroyed`) agar tidak meninggalkan sampah di Windows. |

---

## 3. Daftar Komponen Antarmuka (UI Controls)

Berikut komponen utama pada [Form1.Designer.vb](./Form1.Designer.vb):

| Jenis Kontrol | Properti `(Name)` | Properti Kunci | Fungsi pada Aplikasi |
| :--- | :--- | :--- | :--- |
| `Panel` | `pnlTimer` | `BackColor: RGB(23, 50, 77)` | Panel layar hitung mundur (berubah warna menjadi oranye gelap saat waktu habis) |
| `Label` | `lblTahap`, `lblSisa`, `lblKeterangan` | `lblSisa` font `58pt Bold`, awal `"05:00"` | Menampilkan tahap timer, angka sisa waktu `MM:SS`, dan panduan singkat |
| `Button` | `btnMulai`, `btnUlangi` | `Text: "&Mulai presentasi"`, `"&Ulangi"` | Memulai/menjeda timer serta mereset timer ke durasi awal |
| `CheckBox` | `chkTeratas` | `Text: "&Tetap di atas aplikasi lain"` | Mengaktifkan/menonaktifkan mode *Always on Top* via `SetWindowPos` |
| `Button` | `btnRingkas` | `Text: "Mode &ringkas"` | Menyembunyikan panel pengaturan (`pnlPengaturan`) dan mengecilkan tinggi Form |
| `Panel` | `pnlPengaturan` | Berisi `nudMenit`, `nudDetik`, `chkBunyi`, `lblShortcut` | Panel pengaturan durasi (0–180 menit, 0–59 detik), opsi bunyi selesai, dan status shortcut |
| `Label` | `lblStatus` | `Anchor: Bottom, Left, Right` | Baris informasi status operasi dan kode error Windows jika API gagal |
| `Timer` | `tmrHitung` | Di *Component Tray* | Pemicu pembaruan tampilan layar secara berkala setiap tick |

---

## 4. Bedah Kode Program: Kodenya Ini Buat Apa?

### A. [ModWindowsApi.vb](./ModWindowsApi.vb) — Definisi Konstanta, P/Invoke, & Pembantu Hitungan

```vbnet
Option Strict On
Imports System.Runtime.InteropServices

Public Module ModWindowsApi
    Public Const MB_ICONINFORMATION As UInteger = &H40UI
    Public Const WM_HOTKEY As Integer = &H312
    Public Const ID_MULAI As Integer = 1
    Public Const ID_ULANGI As Integer = 2
    Public Const MOD_CONTROL As UInteger = &H2UI
    Public Const MOD_ALT As UInteger = &H1UI
    Public Const MOD_NOREPEAT As UInteger = &H4000UI
    Public Const VK_F9 As UInteger = &H78UI
    Public Const VK_F10 As UInteger = &H79UI
    Public Const SWP_NOSIZE As UInteger = &H1UI
    Public Const SWP_NOMOVE As UInteger = &H2UI
    Public Const SWP_NOACTIVATE As UInteger = &H10UI
    Public ReadOnly HWND_TOPMOST As New IntPtr(-1)
    Public ReadOnly HWND_NOTOPMOST As New IntPtr(-2)
```

**Penjelasan:**
- Akhiran `UI` (misal `&H40UI`) wajib ditulis saat `Option Strict On` aktif karena fungsi Windows API mengharapkan tipe bilangan tak bertanda (`UInteger`), sedangkan `0UL` menandakan `ULong`.
- `<DllImport("user32.dll", ExactSpelling:=True, SetLastError:=True)>`: Memberi tahu .NET agar memanggil fungsi persis di `user32.dll` serta menyimpan kode error Windows bila gagal (yang dapat dibaca lewat `Marshal.GetLastPInvokeError()`).
- **`HitungSisa(durasi, terpakai)`** dan **`FormatSisa(milidetik)`**: Menghitung sisa waktu dalam milidetik lalu membulatkannya ke atas ke detik terdekat dalam format `MM:SS` (misal `05:00`).

### B. [Form1.vb](./Form1.vb) — Siklus Hotkey, `WndProc`, Timer Presisi, & Mode Ringkas

1. **Mendaftarkan & Melepaskan Hotkey (`HandleCreated` & `HandleDestroyed`)**:
   ```vbnet
   Private Sub Form1_HandleCreated(sender As Object, e As EventArgs) Handles MyBase.HandleCreated
       handleShortcut = Me.Handle
       Dim modifier As UInteger = MOD_CONTROL Or MOD_ALT Or MOD_NOREPEAT
       shortcutMulai = RegisterHotKey(handleShortcut, ID_MULAI, modifier, VK_F9)
       shortcutUlangi = RegisterHotKey(handleShortcut, ID_ULANGI, modifier, VK_F10)
       ...
   End Sub

   Private Sub Form1_HandleDestroyed(sender As Object, e As EventArgs) Handles MyBase.HandleDestroyed
       If shortcutMulai Then UnregisterHotKey(handleShortcut, ID_MULAI)
       If shortcutUlangi Then UnregisterHotKey(handleShortcut, ID_ULANGI)
       ...
   End Sub
   ```
   - `Me.Handle` adalah alamat pengenal jendela (*window handle / HWND*) yang diberikan Windows saat jendela dibuat.
   - `MOD_NOREPEAT` mencegah shortcut terpanggil puluhan kali per detik jika tombol ditahan terlalu lama.
   - Begitu jendela ditutup/dihancurkan, `HandleDestroyed` melepaskan hotkey agar tombol `Ctrl+Alt+F9`/`F10` kembali bebas dipakai aplikasi lain.

2. **Menangkap Pesan Windows (`Overrides Sub WndProc`)**:
   ```vbnet
   Protected Overrides Sub WndProc(ByRef m As Message)
       If m.Msg = WM_HOTKEY Then
           If m.WParam.ToInt32() = ID_MULAI AndAlso shortcutMulai Then MulaiAtauJeda()
           If m.WParam.ToInt32() = ID_ULANGI AndAlso shortcutUlangi Then UlangiTimer()
       End If
       MyBase.WndProc(m)
   End Sub
   ```
   - Setiap jendela Windows menerima aliran pesan sistem (*Windows Messages*). Saat user menekan shortcut yang sudah didaftarkan, Windows mengirim pesan bertipe `WM_HOTKEY` (`&H312`) beserta nomor ID-nya di `m.WParam`.

3. **Perhitungan Waktu Anti-Drift (`GetTickCount64`)**:
   - Mengapa tidak sekadar mengurangi `sisa -= 1` setiap `tmrHitung_Tick`? Karena `Windows Forms Timer` bisa meleset jika CPU sibuk.
   - Dengan menyimpan waktu mulai (`mulaiTick = GetTickCount64()`) dan mengakumulasi waktu jeda (`terpakai`), lalu menghitung `elapsed = terpakai + GetTickCount64() - mulaiTick`, waktu hitung mundur selalu akurat mengikuti jam internal sistem!

4. **Mode Selalu di Atas (`chkTeratas_CheckedChanged`) & Mode Ringkas (`btnRingkas_Click`)**:
   - `SetWindowPos(Me.Handle, posisi, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE Or SWP_NOACTIVATE)` hanya memindahkan posisi tumpukan jendela (`HWND_TOPMOST` / `HWND_NOTOPMOST`) tanpa menggeser lokasi maupun mencuri fokus aktif.
   - `btnRingkas_Click` menyembunyikan `pnlPengaturan` dan memperhitungkan ketebalan bingkai jendela (`Me.Width - Me.ClientSize.Width`, `Me.Height - Me.ClientSize.Height`) agar tampilan ringkas tetap pas.

---

## 5. Apa yang Dihasilkan Program

1. Saat dibuka, timer siap pada posisi default **`05:00`** dengan panel biru dongker (`RGB(23, 50, 77)`), tombol `&Mulai presentasi`, serta status shortcut `Ctrl+Alt+F9` dan `Ctrl+Alt+F10`.
2. Klik **Mulai presentasi** (atau tekan `Ctrl+Alt+F9`): kotak `nudMenit` dan `nudDetik` terkunci, tombol berubah menjadi **Jeda**, dan hitungan mundur berjalan akurat.
3. Centang **Tetap di atas aplikasi lain** (`chkTeratas`): jendela timer tetap mengambang di depan jendela lain (seperti browser atau PowerPoint).
4. Klik **Mode ringkas**: bagian pengaturan durasi dan teks shortcut disembunyikan, jendela mengecil rapi hanya menampilkan timer dan tombol kendali utama (verifikasi tampilan tersedia di [testing/screenshoot/form_normal.png](./testing/screenshoot/form_normal.png) dan [testing/screenshoot/form_compact.png](./testing/screenshoot/form_compact.png)).
5. Ketika hitungan mencapai `00:00`: panel timer berubah warna menjadi jingga gelap (`RGB(133, 52, 21)`), muncul teks `"Waktu habis"`, dan komputer berbunyi satu kali via `MessageBeep(MB_ICONINFORMATION)` jika `chkBunyi` dicentang.

---

## 6. Eksperimen: Jika Variabel atau Nilainya Diubah-Ubah Jadi Apa?

| Bagian / Variabel yang Diubah | Nilai Awal | Diubah Menjadi | Dampak & Hasil yang Terjadi |
| :--- | :--- | :--- | :--- |
| Modifier `MOD_NOREPEAT` pada `HandleCreated` | `MOD_CONTROL Or MOD_ALT Or MOD_NOREPEAT` | `MOD_CONTROL Or MOD_ALT` (tanpa `MOD_NOREPEAT`) | Jika pengguna menahan tombol `Ctrl+Alt+F9` selama 1 detik saja, timer terus berulang-ulang berpindah `Mulai -> Jeda -> Mulai` berkali-kali. |
| Konstanta `HWND_TOPMOST` & `HWND_NOTOPMOST` | `New IntPtr(-1)` dan `New IntPtr(-2)` | `HWND_TOPMOST` diganti `New IntPtr(1)` (`HWND_BOTTOM`) | Saat `chkTeratas` dicentang, jendela bukannya melayang paling depan, malah **tenggelam ke lapisan paling belakang** di balik jendela lain. |
| Baris `MyBase.WndProc(m)` di `WndProc` | Dipanggil di akhir `WndProc` | Dihapus | **Jendela rusak total!** Semua pesan dasar Windows (klik mouse, menggambar ulang layar, tombol tutup X) tidak lagi diproses oleh Form sehingga aplikasi beku/blank. |
| Nilai `VK_F9` & `VK_F10` di `ModWindowsApi.vb` | `&H78UI` (F9) dan `&H79UI` (F10) | `&H77UI` (F8) dan `&H7AUI` (F11) | Pintasan keyboard global berubah menjadi `Ctrl+Alt+F8` untuk mulai/jeda dan `Ctrl+Alt+F11` untuk ulangi. |
| Tipe konstanta `MB_ICONINFORMATION` | `&H40UI` | `&H10UI` (`MB_ICONHAND` / ikon error) | Saat waktu presentasi habis, nada bunyi Windows yang diputar berubah dari suara notifikasi lembut menjadi bunyi peringatan error sistem. |
| Pendaftaran `UnregisterHotKey` di `HandleDestroyed` | Ada | Dihapus | Saat aplikasi ditutup dan dibuka ulang (atau aplikasi lain ingin memakai `Ctrl+Alt+F9`), hotkey masih terdaftar atas handle lama sampai proses dibersihkan sistem. |
| Flag `SWP_NOACTIVATE` di `chkTeratas_CheckedChanged` | `SWP_NOMOVE Or SWP_NOSIZE Or SWP_NOACTIVATE` | Menghapus `SWP_NOMOVE` dan `SWP_NOSIZE` | Jendela berpindah ke pojok kiri atas layar `(0, 0)` dan mengecil menjadi ukuran `0 x 0` karena parameter `x, y, cx, cy` di fungsi `SetWindowPos` bernilai `0, 0, 0, 0`! |

---

## 7. Kesalahan Umum & Tips Praktis

1. **Melupakan `Option Strict` atau memakai tipe `Integer` pada parameter `UInteger` P/Invoke:** Penanda fungsi Windows API wajib mencocokkan lebar bit dan sifat *signed/unsigned* (`ULong`, `UInteger`, `IntPtr`) agar tidak terjadi korupsi memori atau error `BC30512`.
2. **Hotkey gagal didaftarkan (`RegisterHotKey` mengembalikan `False`):** Terjadi jika kombinasi tombol sudah dipakai aplikasi lain di Windows (misal aplikasi perekam layar). Karena itu kode selalu menyiapkan tombol klik biasa sebagai cadangan dan melaporkannya di `lblShortcut`.
3. **Menghitung waktu hanya dengan `sisa -= 1` di `Timer.Tick`:** Selalu gunakan jam sistem seperti `GetTickCount64` atau `Stopwatch` untuk timer presisi.

---

Navigasi: [Pertemuan 8](../Praktikum%208/readme.md) | [Kembali ke README Utama](../readme.md) | [Lanjut ke Pertemuan 12](../Praktikum%2012/readme.md)
