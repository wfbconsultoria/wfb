Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin

Public Class _Page_Header_Private
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        If Context.User.Identity.IsAuthenticated = False Then Response.Redirect("/Account/AccountMessages")
        If manager.IsEmailConfirmed(Context.User.Identity.GetUserId) = False Then Response.Redirect("/Account/AccountMessages")

    End Sub

End Class