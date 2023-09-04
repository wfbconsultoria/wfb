
Public Class Avisos_Sonoros
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo Err_Page_Load
        Dim player As System.Media.SoundPlayer = New System.Media.SoundPlayer("D:\WEB\Chapeira_Eplanner\pr-maringa\Avisos_Sonoros\Chapeira01.wav")
        player.Play()
Err_Page_Load:
        Response.Write(Err.Number & " - " & Err.Description)
    End Sub

End Class