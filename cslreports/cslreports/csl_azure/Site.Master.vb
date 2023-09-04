Imports System
Imports System.Collections.Generic
Imports System.Security.Claims
Imports System.Security.Principal
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Microsoft.Owin.Security
Imports Microsoft.Owin.Security.Cookies
Imports Microsoft.Owin.Security.OpenIdConnect

Partial Public Class SiteMaster
    Inherits MasterPage
    
    Protected Sub Page_Load(sender As Object, e As EventArgs)

    End Sub

    Protected Sub Unnamed_LoggingOut(sender As Object, e As LoginCancelEventArgs)
        ' Redirecionar para ~/Account/SignOut após sair.
        Dim callbackUrl As String = Request.Url.GetLeftPart(UriPartial.Authority) & Response.ApplyAppPathModifier("~/Account/SignOut")

        HttpContext.Current.GetOwinContext().Authentication.SignOut(
            New AuthenticationProperties() With { .RedirectUri = callbackUrl },
            OpenIdConnectAuthenticationDefaults.AuthenticationType,
            CookieAuthenticationDefaults.AuthenticationType)
    End Sub

    Protected Sub Unnamed_Click(sender As Object, e As EventArgs)
        If Not Request.IsAuthenticated Then
            HttpContext.Current.GetOwinContext().Authentication.Challenge(
                New AuthenticationProperties With { .RedirectUri = "/" },
                OpenIdConnectAuthenticationDefaults.AuthenticationType)
        End If
    End Sub
End Class