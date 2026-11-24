Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Net.Http.Json
Imports System.Text.Json.Serialization

Friend NotInheritable Class SupabaseApi
    Private Const ProjectUrl As String = "https://GANTI-REF.supabase.co"
    Private Const PublishableKey As String = "sb_publishable_GANTI"
    Private Shared ReadOnly Client As New HttpClient With {.Timeout = TimeSpan.FromSeconds(20)}

    Public Shared Async Function LoginAsync(email As String, password As String) As Task(Of String)
        Using request = CreateRequest(HttpMethod.Post, "/auth/v1/token?grant_type=password")
            request.Content = JsonContent.Create(New With {.email = email, .password = password})
            Using response = Await Client.SendAsync(request)
                If response.StatusCode = HttpStatusCode.BadRequest OrElse response.StatusCode = HttpStatusCode.Unauthorized Then
                    Throw New InvalidOperationException("Login gagal. Periksa email, kata sandi, dan status konfirmasi akun.")
                End If
                response.EnsureSuccessStatusCode()
                Dim session = Await response.Content.ReadFromJsonAsync(Of LoginResponse)()
                If String.IsNullOrEmpty(session?.AccessToken) Then
                    Throw New InvalidOperationException("Token login tidak diterima.")
                End If
                Return session.AccessToken
            End Using
        End Using
    End Function

    Public Shared Async Function ListAsync(token As String) As Task(Of List(Of Tugas))
        Using request = CreateRequest(HttpMethod.Get, "/rest/v1/tugas_p13?select=id,judul&order=judul", token)
            Using response = Await Client.SendAsync(request)
                EnsureDataSuccess(response)
                Return If(Await response.Content.ReadFromJsonAsync(Of List(Of Tugas))(), New List(Of Tugas))
            End Using
        End Using
    End Function

    Public Shared Async Function UpdateAsync(token As String, id As Guid, judul As String) As Task(Of Boolean)
        Using request = CreateRequest(HttpMethod.Patch, $"/rest/v1/tugas_p13?id=eq.{id:D}&select=id,judul", token)
            request.Headers.Add("Prefer", "return=representation")
            request.Content = JsonContent.Create(New With {.judul = judul})
            Using response = Await Client.SendAsync(request)
                EnsureDataSuccess(response)
                Dim rows = Await response.Content.ReadFromJsonAsync(Of List(Of Tugas))()
                Return rows IsNot Nothing AndAlso rows.Count = 1
            End Using
        End Using
    End Function

    Private Shared Sub EnsureDataSuccess(response As HttpResponseMessage)
        If response.StatusCode = HttpStatusCode.Unauthorized Then
            Throw New InvalidOperationException("Sesi sudah tidak berlaku. Keluar dari sesi, lalu masuk kembali.")
        End If
        response.EnsureSuccessStatusCode()
    End Sub

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

    Private Class LoginResponse
        <JsonPropertyName("access_token")>
        Public Property AccessToken As String
    End Class
End Class

Friend Class Tugas
    Public Property Id As Guid
    Public Property Judul As String
End Class
