
Partial Class SitePowerBi
    Inherits MasterPage
    Dim m As New clsMaster
    Private Sub SiteMaster_Load(sender As Object, e As EventArgs) Handles Me.Load
        'se a sessão estiver vazia redireciona a página de login 
        If Session("USER_EMAIL") = Nothing Then Response.Redirect("Login")
        If Session("USER_EMAIL") = "" Then Response.Redirect("Login")
    End Sub

    Private Sub cmdLogOff_Click(sender As Object, e As EventArgs) Handles cmdLogOff.Click
        'esvazia a sessão e manda para a página de login
        Session("USER_EMAIL") = ""
        Response.Redirect("Login")
    End Sub
End Class

