Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Public Class SendConfirm
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly u As New clsUsers
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("Email") = "" Then Response.Redirect("LogOut")
        u.GetLoggedUserInfos()
        Name.InnerHtml = u.LoggedName
        Email.InnerHtml = u.LoggedEmail
    End Sub

    Private Sub cmdConfirm_Click(sender As Object, e As EventArgs) Handles cmdConfirm.Click

        u.GetLoggedUserInfos()
        If u.LoggedStatus = "UnConfirmed" Then
            u.GetLoggedUserInfos()
            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            Dim signInManager = Context.GetOwinContext().Get(Of ApplicationSignInManager)()
            Dim code = manager.GenerateEmailConfirmationToken(u.LoggedId)
            Dim callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, u.LoggedId, Request)
            Dim confirmMessage As String
            confirmMessage = ""
            confirmMessage = confirmMessage & "<h3>LEIA COM ATENÇÃO</h3>" & vbCrLf
            confirmMessage = confirmMessage & " Declaro ser propriétário do e-mail " & u.LoggedEmail & " utilizado para registro e acesso ao site " & ConfigurationManager.AppSettings("App.Name").ToString & ".<br/>"
            confirmMessage = confirmMessage & " Estou ciente de que minha senha é pessoal e intransferivel e só poderá ser recuperada ou alterada por mim através do email " & u.LoggedEmail & ".<br/>"
            confirmMessage = confirmMessage & " Estou ciente de que todas as ações realizadas no site " & ConfigurationManager.AppSettings("App.Name").ToString & " poderão ser registradas em log sob o email " & u.LoggedEmail & ".<br/>"
            confirmMessage = confirmMessage & " Estou ciente de que todas as informações registradas neste site são de propriedade da  " & ConfigurationManager.AppSettings("App.Customer").ToString & ".<br/>"
            confirmMessage = confirmMessage & "<br/>"
            confirmMessage = confirmMessage & " A sua senha definina durante registro é criptografada e nem os administradores e/ou usuários do " & ConfigurationManager.AppSettings("App.Name").ToString & " posssuem acesso.<br/>"
            confirmMessage = confirmMessage & " Portanto todas as informações incluidas são  de sua total responsabilidade quanto a veracidade.<br/>"
            confirmMessage = confirmMessage & "<br/><br/>"
            manager.SendEmail(u.LoggedId, "Confirmar registro sua conta e propriedade do e-mail", confirmMessage & " Confirme se realmente é proprietário do e-mail " & u.LoggedEmail & " e está ciente <br/><br/><a href=""" & callbackUrl & """>Confirmo a propriedade do referido e-mail e estou ciente </a>.")
            m.Alert(Me, "Status: " & u.LoggedStatus & " - Email de confirmação enviado com sucesso", True, "LogOut")
        Else
            m.Alert(Me, "Status: " & u.LoggedStatus & " - Não é possivel reenviar e-mail de confirmação", True, "LogOut")
        End If


    End Sub
End Class



