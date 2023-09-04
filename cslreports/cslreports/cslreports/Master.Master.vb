
Public Class Master
    Inherits System.Web.UI.MasterPage
    ReadOnly m As New clsMaster
    ReadOnly u As New clsUsers
    Private Sub Master_Load(sender As Object, e As EventArgs) Handles Me.Load
        m.DatabaseConnect()
    End Sub
    Private Sub btn_LogOut_ServerClick(sender As Object, e As EventArgs) Handles btn_LogOut.ServerClick
        u.Logout()
        '' Redirecionar para ~/Account/SignOut após sair.
        'Dim callbackUrl As String = Request.Url.GetLeftPart(UriPartial.Authority) & Response.ApplyAppPathModifier("~/Account/SignOut.aspx")

        'HttpContext.Current.GetOwinContext().Authentication.SignOut(
        '    New AuthenticationProperties() With {.RedirectUri = callbackUrl},
        '    OpenIdConnectAuthenticationDefaults.AuthenticationType,
        '    CookieAuthenticationDefaults.AuthenticationType)
    End Sub


End Class