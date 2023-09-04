Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin

Public Class AccountMessages
    Inherits System.Web.UI.Page
    ReadOnly u As New clsUsers
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MessageType As String = If(Request.QueryString("MessageType") = Nothing, "Message Nothing", Request.QueryString("MessageType").ToString).ToString

        pnl_Message.CssClass = "alert"
        ltr_Title.Text = ""
        ltr_Message.Text = ""
        cmdLogin.Visible = False
        cmdConfirm.Visible = False
        cmdProfile.Visible = False

        If MessageType = "NewUser" Then
            pnl_Message.CssClass = "alert alert-info"
            ltr_Title.Text = "Obrigado por fazer seu registro"
            ltr_Message.Text = "Você receberá um e-mail para confirmação do seu registro e liberação de acesso ao sistema, caso não tenha recebido é possivel reenviar, basta efetuar login!"
            cmdLogin.Visible = True
            cmdConfirm.Visible = False
            cmdProfile.Visible = False
            Exit Sub
        End If

        If MessageType = "UnAuthenticated" Then
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
            pnl_Message.CssClass = "alert alert-danger"
            ltr_Title.Text = "Usuário não está autenticado"
            ltr_Message.Text = "Você deve efetuar o LOGIN antes de acessar o " & ConfigurationManager.AppSettings("App.Name")
            cmdLogin.Visible = True
            cmdConfirm.Visible = False
            cmdProfile.Visible = False
            Exit Sub
        End If

        If MessageType = "UnConfirmed" Then
            pnl_Message.CssClass = "alert alert-warning"
            ltr_Title.Text = "Email não confirmado"
            ltr_Message.Text = "Você está registrado, porém, seu e-mail não foi confirmado, reenvie o e-mail de confirmação e aceite os termos para que seu login seja liberado"
            cmdLogin.Visible = False
            cmdConfirm.Visible = True
            cmdProfile.Visible = False
        End If


        If MessageType = "Registered" Then
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
            pnl_Message.CssClass = "alert alert-danger"
            ltr_Title.Text = "Este e-mail já está registrado"
            ltr_Message.Text = "Você deve efetuar o LOGIN antes de acessar as áreas restritas do " & ConfigurationManager.AppSettings("App.Name")
            cmdLogin.Visible = True
            cmdConfirm.Visible = False
            cmdProfile.Visible = False
            Exit Sub
        End If

        If MessageType = "SendConfirmation" Then
            pnl_Message.CssClass = "alert alert-success"
            ltr_Title.Text = "Conformação propriedade de email"
            ltr_Message.Text = "Seu email para confirmação foi enviado com sucesso, aguarde a liberação de acesso que será efetuada pelos administradores do sistema, caso não tenha recebido faça login novamente"
            cmdLogin.Visible = False
            cmdConfirm.Visible = False
            cmdProfile.Visible = False
            Exit Sub
        End If

        If MessageType = "UnRegistered" Then
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
            pnl_Message.CssClass = "alert alert-danger"
            ltr_Title.Text = "Usuário não registrado"
            ltr_Message.Text = "Faça seu registro antes de acessar o sistema "
            cmdLogin.Visible = True
            cmdConfirm.Visible = False
            cmdProfile.Visible = False
            Exit Sub
        End If

        If MessageType = "Locked" Then
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
            pnl_Message.CssClass = "alert alert-danger"
            ltr_Title.Text = "Usuário bloqueado"
            ltr_Message.Text = "Este (e-mail) usuário está bloqueado, não é possível acessar nem registar no sistema "
            cmdLogin.Visible = True
            cmdConfirm.Visible = False
            cmdProfile.Visible = False
            Exit Sub
        End If

        If MessageType = "ProfilePendig" Then
            pnl_Message.CssClass = "alert alert-warning"
            ltr_Title.Text = "Perfil não atualizado"
            ltr_Message.Text = "Você está registrado e seu e-mail confirmado, porém, suas informações de perfil devem ser atualizadas para que seu login seja liberado "
            cmdLogin.Visible = False
            cmdConfirm.Visible = False
            cmdProfile.Visible = True
        End If

    End Sub

    Private Sub cmdConfirm_Click(sender As Object, e As EventArgs) Handles cmdConfirm.Click
        Response.Redirect("~/Account/SendConfirm")
    End Sub

    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click
        Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
        Response.Redirect("~/Account/Login")
    End Sub
End Class