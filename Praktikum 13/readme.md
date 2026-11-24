# Pertemuan 13: Packaging Proyek Akhir WinForms, Supabase Auth/Data API, & RLS

## 1. Gambaran Umum & Analogi

Pada Pertemuan 13 di proyek [DaftarTugas](./DaftarTugas/DaftarTugas.vbproj), kita mempelajari cara menyiapkan aplikasi WinForms agar siap dibagikan (*packaging* / *publishing*) sekaligus mengamankan akses datanya menggunakan **Supabase Auth**, **Supabase Data API (REST)**, dan **Row Level Security (RLS)** di PostgreSQL.

Bayangkan sebuah **aplikasi loker pribadi di gedung perkantoran**:
- Pada pertemuan awal (Pertemuan 6), aplikasi langsung terhubung ke PostgreSQL menggunakan *connection string* dan password database. Cara ini **berbahaya** jika aplikasi dibagikan ke komputer pengguna lain karena password admin database bisa terbaca dari file konfigurasi/binary.
- Pada Pertemuan 13 ini, arsitektur diubah menjadi:
  **`WinForms -> Supabase Auth & Data API (HTTPS) -> PostgreSQL (RLS)`**
- **`ProjectUrl` dan `PublishableKey` (`sb_publishable_...`)** boleh terlihat di aplikasi klien (ibarat alamat gedung dan kartu akses tamu untuk masuk ke lobi).
- **Supabase Auth (`/auth/v1/token`)** memverifikasi email dan kata sandi pengguna lalu memberikan **token sesi (JWT)**.
- **Row Level Security (RLS)** di PostgreSQL memastikan bahwa meskipun semua pengguna memakai aplikasi yang sama, **Akun A hanya bisa membaca dan mengubah tugas miliknya sendiri**, dan tidak bisa menyentuh tugas milik Akun B.
- **Packaging (`Publish`)** membungkus aplikasi menjadi `.exe` lengkap dengan **nama aplikasi, ikon (`.ico`), versi (`1.0.0` / `1.0.0.0`), dan *runtime* `.NET` (*Self-contained*)** agar bisa dijalankan di komputer Windows x64 lain tanpa perlu menginstal .NET SDK terlebih dahulu.

---

## 2. Ringkasan Konsep Materi

### Konsep Kunci yang Dipelajari:
1. **Keamanan Kredensial pada Aplikasi Terdistribusi:**
   - **Boleh terlihat di klien:** `ProjectUrl` dan `PublishableKey` (`sb_publishable_...`).
   - **Wajib disimpan di luar aplikasi (jangan pernah di-hardcode/dibagikan):** Password PostgreSQL, kunci `sb_secret_...` / `service_role`, serta kata sandi akun uji.
2. **Row Level Security (RLS) & Hak Akses Minimum (*Least Privilege*):**
   - Mengaktifkan RLS (`alter table ... enable row level security`).
   - Mencabut seluruh hak akses bawaan (`revoke all ... from public, anon, authenticated`), lalu hanya memberi `select` dan `update (judul)` kepada peran `authenticated`. Peran `anon` (tanpa login) tidak diberi hak baca atau ubah sama sekali.
   - Kebijakan `SELECT` menggunakan `using ((select auth.uid()) = pemilik_id)`.
   - Kebijakan `UPDATE` menggunakan `using (...)` (memeriksa baris sebelum diubah) dan `with check (...)` (memeriksa hasil perubahan agar kepemilikan tidak bisa dialihkan).
3. **Autentikasi & Komunikasi REST API via `HttpClient`:**
   - Login dengan `POST /auth/v1/token?grant_type=password` untuk memperoleh `access_token`.
   - Mengirim `apikey` (Publishable Key) dan `Authorization: Bearer <token>` pada setiap request ke `/rest/v1/tugas_p13`.
   - Menggunakan `Async` / `Await` agar antarmuka WinForms tidak membeku saat menunggu respons jaringan.
4. **Metadata Aplikasi di `.vbproj`:**
   - Mengatur `AssemblyName`, `Product`, `Version`, `FileVersion`, `IncludeSourceRevisionInInformationalVersion`, dan `ApplicationIcon`.
5. **Profil Publish di Visual Studio / .NET CLI:**
   - `Configuration = Release`, `Deployment mode = Self-contained`, `Target runtime = win-x64`.
   - Seluruh isi folder hasil *publish* (`.exe` beserta berkas pendampingnya) dikemas menjadi `.zip` untuk didistribusikan.

---

## 3. Struktur Berkas Proyek

Proyek Pertemuan 13 terdiri dari skrip SQL penyiapan database dan proyek WinForms `DaftarTugas`:

1. **[siapkan-database.sql](./siapkan-database.sql)** — Skrip SQL transaksional (`begin; ... commit;`) untuk membuat tabel `public.tugas_p13`, indeks `pemilik_id`, mengaktifkan RLS, mengatur hak akses minimum, dan membuat kebijakan `SELECT` serta `UPDATE`.
2. **[DaftarTugas.vbproj](./DaftarTugas/DaftarTugas.vbproj)** — Konfigurasi proyek `.NET 10` (`net10.0-windows`), `OptionStrict On`, nama assembly `DaftarTugas`, versi `1.0.0` (`FileVersion` `1.0.0.0`), dan ikon `DaftarTugas.ico`.
3. **[SupabaseApi.vb](./DaftarTugas/SupabaseApi.vb)** — Kelas pembungkus `HttpClient` untuk login (`LoginAsync`), mengambil daftar tugas (`ListAsync`), dan memperbarui judul tugas (`UpdateAsync`).
4. **[FrmUtama.vb](./DaftarTugas/FrmUtama.vb)** — Berisi `Module Program` (titik masuk aplikasi) dan `FrmUtama` yang membangun seluruh kontrol UI secara terprogram (`TableLayoutPanel`, `TextBox`, `ListBox`, `Button`, `Label`) beserta penanganan error asinkron.
5. **[DaftarTugas.ico](./DaftarTugas/DaftarTugas.ico)** — Berkas ikon aplikasi yang tertanam ke berkas `.exe`.

---

## 4. Bedah Kode Program: Kodenya Ini Buat Apa?

### A. [siapkan-database.sql](./siapkan-database.sql) — Tabel, Hak Minimum, & Kebijakan RLS

```sql
alter table public.tugas_p13 enable row level security;

revoke all on public.tugas_p13 from public, anon, authenticated;
grant select on public.tugas_p13 to authenticated;
grant update (judul) on public.tugas_p13 to authenticated;

create policy "Baca tugas sendiri"
on public.tugas_p13 for select to authenticated
using ((select auth.uid()) = pemilik_id);

create policy "Ubah tugas sendiri"
on public.tugas_p13 for update to authenticated
using ((select auth.uid()) = pemilik_id)
with check ((select auth.uid()) = pemilik_id);
```

**Penjelasan:**
- Kolom `judul` memiliki batasan `check (char_length(btrim(judul)) between 1 and 100)` agar judul kosong atau lebih dari 100 karakter ditolak langsung di level database.
- `grant update (judul)` membatasi bahwa peran `authenticated` **hanya boleh mengubah kolom `judul`**, tidak boleh mengubah kolom `id` atau `pemilik_id`.
- `auth.uid()` mengembalikan User UID dari token JWT pengguna yang sedang login, sehingga setiap kueri `SELECT` dan `PATCH` otomatis tersaring hanya untuk baris milik pengguna tersebut.

### B. [SupabaseApi.vb](./DaftarTugas/SupabaseApi.vb) — Validasi Kunci & Permintaan HTTP

```vbnet
    Private Shared Function CreateRequest(method As HttpMethod, path As String,
                                          Optional token As String = Nothing) As HttpRequestMessage
        If ProjectUrl.Contains("GANTI-REF") OrElse PublishableKey = "sb_publishable_GANTI" Then
            Throw New InvalidOperationException("Isi ProjectUrl dan PublishableKey di SupabaseApi.vb.")
        End If
        If Not PublishableKey.StartsWith("sb_publishable_", StringComparison.Ordinal) Then
            Throw New InvalidOperationException("Gunakan API key yang berawalan sb_publishable_.")
        End If
        Dim uri = New Uri(ProjectUrl.TrimEnd("/"c) & path)
        If uri.Scheme <> Uri.UriSchemeHttps Then
            Throw New InvalidOperationException("Gunakan URL Supabase dengan HTTPS.")
        End If
        Dim request As New HttpRequestMessage(method, uri)
        request.Headers.Add("apikey", PublishableKey)
        If token IsNot Nothing Then
            request.Headers.Authorization = New AuthenticationHeaderValue("Bearer", token)
        End If
        Return request
    End Function
```

**Penjelasan:**
- Fungsi `CreateRequest` melakukan pagar pengaman sebelum mengirim request: memastikan placeholder sudah diganti, kunci harus berawalan `sb_publishable_` (mencegah penggunaan kunci admin `sb_secret_...` di aplikasi klien), dan protokol wajib `https://`.
- Pada `UpdateAsync`, header `Prefer: return=representation` ditambahkan agar Supabase mengembalikan baris yang berhasil diubah. Jika panjang `rows.Count = 1`, berarti pembaruan berhasil; jika `0`, berarti baris tidak ditemukan atau ditolak oleh RLS.

### C. [FrmUtama.vb](./DaftarTugas/FrmUtama.vb) — Eksekusi Asinkron & Sinkronisasi State Kontrol

```vbnet
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
```

**Penjelasan:**
- `JalankanAsync` membungkus seluruh operasi jaringan (`LoginAsync`, `ListAsync`, `UpdateAsync`) dengan satu mekanisme penanganan error dan penguncian UI terpusat.
- Selama `sibuk = True`, `AturKontrol()` menonaktifkan tombol dan input agar pengguna tidak mengirim permintaan ganda saat proses sedang berjalan.
- Blok `Finally` menjamin `sibuk` kembali `False` dan state kontrol diperbarui kembali meskipun terjadi error jaringan atau sesi kedaluwarsa.
- Saat `Masuk` dipanggil, nilai `txtPassword.Text` langsung disalin ke variabel lokal dan `txtPassword.Clear()` segera dijalankan agar kata sandi tidak tertinggal di antarmuka.

### D. [DaftarTugas.vbproj](./DaftarTugas/DaftarTugas.vbproj) — Metadata Packaging

```xml
    <AssemblyName>DaftarTugas</AssemblyName>
    <Product>Daftar Tugas</Product>
    <Version>1.0.0</Version>
    <FileVersion>1.0.0.0</FileVersion>
    <IncludeSourceRevisionInInformationalVersion>false</IncludeSourceRevisionInInformationalVersion>
    <ApplicationIcon>DaftarTugas.ico</ApplicationIcon>
```

**Penjelasan:**
- `<AssemblyName>` menentukan nama file `.exe` keluaran (`DaftarTugas.exe`).
- `<ApplicationIcon>` menyematkan ikon ke `.exe`, yang juga dibaca saat runtime oleh `Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)` di `FrmUtama`.
- `<Version>` dan `<FileVersion>` tampil pada tab **Properties -> Details -> File version** di Windows Explorer.
- `<IncludeSourceRevisionInInformationalVersion>false</IncludeSourceRevisionInInformationalVersion>` menjaga agar string versi informasi produk bersih tanpa tambahan hash commit Git.

---

## 5. Langkah Penyiapan, Pengujian, & Publish

### A. Penyiapan Supabase & Dua Akun Uji
1. Buka Supabase Dashboard -> **Authentication -> Users**, buat dua akun uji (misal Akun A dan Akun B) dan pastikan keduanya berstatus **terkonfirmasi**.
2. Buka **SQL Editor -> New query**, jalankan seluruh isi [siapkan-database.sql](./siapkan-database.sql).
3. Buka **Table Editor -> `tugas_p13`**, tambahkan minimal satu baris tugas untuk masing-masing akun dengan mengisi kolom `pemilik_id` menggunakan **User UID** dari menu Authentication -> Users.
4. Pastikan pada **Table Editor -> `tugas_p13` -> RLS policies**, RLS aktif dan terdapat kebijakan `Baca tugas sendiri` (`SELECT`) serta `Ubah tugas sendiri` (`UPDATE`) untuk peran `authenticated`.
5. Salin **Project URL** dan **Publishable Key** (`sb_publishable_...`) dari dialog Connect Supabase, lalu isi ke `ProjectUrl` dan `PublishableKey` di [SupabaseApi.vb](./DaftarTugas/SupabaseApi.vb).

### B. Pengujian Fungsional & Keamanan Dua Akun
- **Tanpa login:** Akses baca ke API ditolak karena peran `anon` tidak memiliki hak `SELECT`.
- **Login dengan Akun A:** Hanya tugas milik Akun A yang tampil di `lstTugas`. Mengubah judul tugas A akan tersimpan dan tetap ada saat tombol **Muat ulang** diklik.
- **Akun A mencoba mengubah tugas B:** Data tugas milik Akun B tetap utuh (ditolak oleh RLS).

### C. Menerbitkan Aplikasi (*Publish*)
Melalui **Visual Studio**:
1. Klik kanan proyek `DaftarTugas` -> **Publish** -> **Folder**.
2. Buka pengaturan profil (*Show all settings*), atur:
   - **Configuration:** `Release`
   - **Deployment mode:** `Self-contained`
   - **Target runtime:** `win-x64`
3. Klik **Publish**, lalu buka folder keluarannya.

Atau melalui **Terminal / PowerShell**:
```powershell
dotnet publish "Praktikum 13\DaftarTugas\DaftarTugas.vbproj" -c Release -r win-x64 --self-contained true
```
4. Kompres seluruh isi folder publish menjadi satu berkas `.zip` (pastikan seluruh berkas pendamping tetap bersama `DaftarTugas.exe`).
5. Ekstrak `.zip` di komputer Windows x64 lain, jalankan `DaftarTugas.exe`, periksa judul jendela, ikon, dan **Properties -> Details -> File version**, lalu ulangi uji login dan ubah judul tugas.

---

## 6. Eksperimen: Jika Variabel atau Nilainya Diubah-Ubah Jadi Apa?

| Bagian / Variabel yang Diubah | Nilai Awal | Diubah Menjadi | Dampak & Hasil yang Terjadi |
| :--- | :--- | :--- | :--- |
| `PublishableKey` di `SupabaseApi.vb` | `"sb_publishable_..."` | Kunci yang tidak berawalan `sb_publishable_` | Aplikasi langsung menampilkan pesan `"Gunakan API key yang berawalan sb_publishable_."` tanpa mengirim request. |
| `ProjectUrl` di `SupabaseApi.vb` | `"https://....supabase.co"` | `"http://....supabase.co"` | Ditolak oleh validasi `uri.Scheme <> Uri.UriSchemeHttps` dengan pesan `"Gunakan URL Supabase dengan HTTPS."`. |
| Klausa `grant update (judul)` di `siapkan-database.sql` | `grant update (judul)` | `grant update` (tanpa pembatasan kolom) | Peran `authenticated` secara teknis diizinkan mencoba memperbarui kolom lain (meski perubahan `pemilik_id` tetap dijaga oleh `WITH CHECK`). |
| Kebijakan `with check` pada policy `UPDATE` | `with check ((select auth.uid()) = pemilik_id)` | Dihapus | Pengguna bisa mengubah baris miliknya, tetapi berisiko tidak memvalidasi nilai kolom baru setelah `UPDATE` (misalnya jika pembaruan kolom `pemilik_id` juga diizinkan). |
| `Deployment mode` saat Publish | `Self-contained` | `Framework-dependent` | Ukuran folder publish jauh lebih kecil, tetapi komputer tujuan **wajib** sudah menginstal .NET Desktop Runtime 10 agar `DaftarTugas.exe` bisa dibuka. |
| `IncludeSourceRevisionInInformationalVersion` di `.vbproj` | `false` | `true` (default SDK) | Metadata *Product version* di Windows Properties akan ditempeli hash commit Git (contoh: `1.0.0+abc1234`). |

---

## 7. Kesalahan Umum & Tips Praktis

1. **Membagikan file publish yang masih menyimpan password PostgreSQL, `sb_secret_...` / `service_role`, atau kata sandi akun uji:** Selalu periksa ulang sebelum membuat arsip `.zip`. Hanya `ProjectUrl` dan `PublishableKey` (`sb_publishable_...`) yang boleh ada di kode klien.
2. **Hanya menyalin `DaftarTugas.exe` tanpa berkas pendampingnya di folder publish:** Pada mode *Self-contained* tanpa *single-file*, `DaftarTugas.exe` membutuhkan file `.dll` dan `.runtimeconfig.json` di folder yang sama agar bisa berjalan. Selalu `.zip` seluruh isi folder publish.
3. **Lupa mengonfirmasi akun uji di Supabase Auth:** Akun yang belum terkonfirmasi tidak akan bisa login dan akan memicu HTTP 400 (`InvalidOperationException: "Login gagal. Periksa email, kata sandi, dan status konfirmasi akun."`).

---

Navigasi: [Pertemuan 12](../Praktikum%2012/readme.md) | [Kembali ke README Utama](../readme.md)
