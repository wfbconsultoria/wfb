
Partial Class Shared_Master
    Inherits System.Web.UI.MasterPage

    Private Sub Shared_Master_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsNothing(HttpContext.Current.Session("EMAIL_LOGIN")) Or HttpContext.Current.Session("EMAIL_LOGIN") = "" Then
            Response.Redirect("Login/Login.aspx")
        End If
    End Sub
End Class

