
Imports Microsoft.Owin.Security
Imports Microsoft.Owin.Security.OpenIdConnect
Public Class SignOut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.IsAuthenticated Then
            ' Redirecionar para a página inicial se o usuário estiver autenticado.
            Response.Redirect("~/")
        End If
    End Sub
    Private Sub btn_Login_ServerClick(sender As Object, e As EventArgs) Handles btn_Login.ServerClick
        If Not Request.IsAuthenticated Then
            HttpContext.Current.GetOwinContext().Authentication.Challenge(
                New AuthenticationProperties With {.RedirectUri = "/"},
                OpenIdConnectAuthenticationDefaults.AuthenticationType)
        End If
    End Sub
End Class


