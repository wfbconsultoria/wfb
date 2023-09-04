Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin

Public Class _Page_Header_Private
    Inherits System.Web.UI.UserControl
    Dim m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Try
        '    If (Context.User.Identity.IsAuthenticated) = False Then Response.Redirect("/Account/AccountMessages?MessageType=Unauthenticated")
        '    If (Context.User.Identity.GetUserName) = "" Then Response.Redirect("/Account/AccountMessages?MessageType=Unauthenticated")
        '    If (Context.User.Identity.GetUserId) = "" Then Response.Redirect("/Account/AccountMessages?MessageType=Unauthenticated")
        '    Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        '    If manager.FindById(Context.User.Identity.GetUserId).ToString = "" Then Response.Redirect("/Account/AccountMessages?MessageType=Unauthenticated")
        '    If manager.IsEmailConfirmed(Context.User.Identity.GetUserId) = False Then Response.Redirect("/Account/AccountMessages?MessageType=Unconfirmed")
        'Catch ex As Exception
        '    Response.Redirect("/Account/AccountMessages?MessageType=Unauthenticated")
        'End Try
    End Sub

End Class