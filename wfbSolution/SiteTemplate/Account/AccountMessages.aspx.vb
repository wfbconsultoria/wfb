Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin

Public Class AccountMessages
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MessageType = If(Request.QueryString("MessageType") = Nothing, "", Request.QueryString("MessageType").ToString)

        cmdLogin.Visible = False
        cmdConfirm.Visible = False
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()


        If MessageType = "NewUser" Then
            pnl_Message.CssClass = "alert alert-info"
            ltr_Title.Text = "Obrigado por fazer seu registro"
            ltr_Message.Text = "Você receberá um e-mail para confirmação do seu registro e liberação de acesso ao sistema, caso não tenha recebido é possivel reenviar!"
            cmdLogin.Visible = False
            cmdConfirm.Visible = True
            Exit Sub
        End If

        If Context.User.Identity.IsAuthenticated = False Then
            pnl_Message.CssClass = "alert alert-danger"
            ltr_Title.Text = "Pagina Privada"
            ltr_Message.Text = "Você deve estar registrado e fazer login"
            cmdLogin.Visible = True
            cmdConfirm.Visible = False
            Exit Sub
        End If

        If manager.IsEmailConfirmed(Context.User.Identity.GetUserId) = False Or MessageType = "Confirm" Then
            pnl_Message.CssClass = "alert alert-warning"
            ltr_Title.Text = "Email não confirmado"
            ltr_Message.Text = "Você está registrado porém seu e-mail não fo confirmado"
            cmdLogin.Visible = False
            cmdConfirm.Visible = True
        End If

    End Sub

    Private Sub cmdConfirm_Click(sender As Object, e As EventArgs) Handles cmdConfirm.Click
        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim code = manager.GenerateEmailConfirmationToken(Context.User.Identity.GetUserId)
        Dim callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, Context.User.Identity.GetUserId, Request)
        manager.SendEmail(Context.User.Identity.GetUserId, "Confirme sua conta", "Confirme sua conta clicando <a href=""" & callbackUrl & """>aqui</a>.")
    End Sub

    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click
        Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
        Response.Redirect("~/Account/Login")
    End Sub
End Class