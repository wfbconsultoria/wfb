Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin

Partial Public Class Confirm
    Inherits System.Web.UI.Page
    ReadOnly u As New clsUsers
    ReadOnly m As New clsMaster
    Protected Property StatusMessage() As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim code As String = IdentityHelper.GetCodeFromRequest(Request)
        Dim userId As String = IdentityHelper.GetUserIdFromRequest(Request)
        If code IsNot Nothing AndAlso userId IsNot Nothing Then
            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            Dim result = manager.ConfirmEmail(userId, code)
            If result.Succeeded Then
                Dim email = manager.GetEmail(userId)
                u.GetUserInfos(email)
                Dim sql = ""
                sql = sql & " Update tb_Users Set "
                sql = sql & " User_Status = 'Confirmed', "
                sql = sql & " Confirmed = 1, "
                sql = sql & " Confirmed_Date = '" & m.GettDateToString & "', "
                sql = sql & " Confirmed_User = '" & email & "', "
                sql = sql & " Confirmed_IP = '" & HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString & "' "
                sql = sql & " Where Email = '" & email & "' "
                m.ExecuteSQL(sql)

                Dim confirmMessage As String
                'envia e-mail para o usuário
                confirmMessage = ""
                confirmMessage = confirmMessage & "<h3>Propriedade do e-mail confirmada</h3>"
                confirmMessage = confirmMessage & " A propriedade do e-mail " & email & " utilizado para registro e acesso ao site " & ConfigurationManager.AppSettings("App.Name").ToString & ".<br/>"
                confirmMessage = confirmMessage & " Foi confirmada com sucesso <br/>"
                confirmMessage = confirmMessage & " Aguarde a liberação de acesso que será efetuada pelo adminstrador do sistema <br/>"
                confirmMessage = confirmMessage & " Você receberá um e-mail confirmando a liberação <br/>"
                confirmMessage = confirmMessage & "<br/>"
                confirmMessage = confirmMessage & "<br/><br/>"
                m.SendMail(u.UserEmail, u.UserName, "Propriedade do e-mail confirmada", confirmMessage)

                'envia e-mail para o suporte
                confirmMessage = ""
                confirmMessage = confirmMessage & "<h3>Autorizar acesso ao " & ConfigurationManager.AppSettings("App.Name").ToString & " - Email: " & email & "</h3>"
                confirmMessage = confirmMessage & "A propriedade do Email " & email & " registrado no " & ConfigurationManager.AppSettings("App.Name").ToString & ".<br/>"
                confirmMessage = confirmMessage & " Foi confirmada com sucesso <br/>"
                confirmMessage = confirmMessage & " Favor proceder o processo de autorização de acesso ao usuário <br/>"
                m.SendMail(ConfigurationManager.AppSettings("App.Support.Email"), ConfigurationManager.AppSettings("App.Support.Email"), "Autorizar acesso " & u.UserName, confirmMessage)

                successPanel.Visible = True
                Return
            End If
        End If
        successPanel.Visible = False
        errorPanel.Visible = True
    End Sub

End Class