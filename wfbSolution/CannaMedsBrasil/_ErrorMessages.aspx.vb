Imports Microsoft.AspNet.Identity

Public Class _ErrorMessages
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MessageType = If(Request.QueryString("MessageType") = Nothing, "", Request.QueryString("MessageType").ToString)

        cmdLogin.Visible = False
        cmdBack.Visible = False

        If MessageType = "Error" Or MessageType = "" Then
            pnl_Message.CssClass = "alert alert-info"
            ltr_Title.Text = "Erro do sistema"
            ltr_Message.Text = "Mensagem de erro do sistema"
            m.SendMail(ConfigurationManager.AppSettings("App.Support.Email"), ConfigurationManager.AppSettings("App.Support.Name") & "-" & ConfigurationManager.AppSettings("App.Name"), ltr_Title.Text, ltr_Message.Text)
            cmdLogin.Visible = False
            cmdBack.Visible = True
            Exit Sub
        End If

    End Sub

    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click
        Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
        Response.Redirect("~/Account/Login")
    End Sub

    Private Sub cmdBack_Click(sender As Object, e As EventArgs) Handles cmdBack.Click

    End Sub
End Class

