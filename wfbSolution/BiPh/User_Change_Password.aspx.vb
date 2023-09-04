Public Class User_Change_Password
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m.CheckLogin()
    End Sub
    Private Sub cmd_Salvar_ServerClick(sender As Object, e As EventArgs) Handles cmd_Salvar.ServerClick
        On Error GoTo Err_cmd_Salvar_ServerClick
        'Senha Atual
        If txt_Password.Value = "" Then
            m.Alert(Me, "Preencha a senha atual")
            Exit Sub
        End If
        'Nova Senha
        If txt_New_Password.Value = "" Then
            m.Alert(Me, "Preencha nova senha")
            Exit Sub
        End If
        'Confirmar Senha
        If txt_Confirm_Password.Value = "" Then
            m.Alert(Me, "Preencha confirmação da senha")
            Exit Sub
        End If
        'User_Profile_Id
        If txt_New_Password.Value <> txt_Confirm_Password.Value Then
            m.Alert(Me, "A nova senha e a confirmação devem ser idênticas")
            Exit Sub
        End If

        Dim sql As String = " Select * From vw_Users Where Email = '" & Session("Email").ToString & "' and Password = '" & txt_Password.Value & "'"

        Dim dtr = m.ExecuteSelect(sql)
        If dtr.HasRows Then
            dtr.Read()
            'Verfica se o usuário está bloqueado
            If dtr("User_Profile_Id") = 100 Then
                m.Alert(Me, "Usuário INATIVO,  NÃO É POSSÍVEL ALTEAR A SENHA, contate o suporte do " & ConfigurationManager.AppSettings("App.Name").ToString)
                Exit Sub
            End If

            'Altera a senha
            sql = ""
            sql &= "Update tb_Users Set "
            sql &= "Password = '" & txt_New_Password.Value & "', "
            sql &= "Update_User = '" & Session("Email").ToString & "', "
            sql &= "Update_Date = '" & m.GetDateTimeToString & "' "
            sql &= " Where Email = '" & Session("Email").ToString & "'"
            If m.ExecuteSQL(sql) = True Then
                'Assunto
                Dim Assunto As String = "Senha Alterada"
                'Mensagem
                Dim Mensagem As String = ""
                Mensagem &= "<h3>" & Session("UserName").ToString & " sua senha foi alterada</h3><br/>"
                Mensagem &= "Email registrado: <strong>" & Session("Email").ToString & "</strong><br/>"
                Mensagem &= "Senha anterior: <strong>" & txt_Password.Value & "</strong><br/>"
                Mensagem &= "Senha atual: <strong>" & txt_New_Password.Value & "</strong><br/>"
                m.SendMail(Assunto, Mensagem, Session("Email").ToString, Session("UserName").ToString, ConfigurationManager.AppSettings("App.Email").ToString, ConfigurationManager.AppSettings("App.Name").ToString)
                m.Alert(Me, "O " & ConfigurationManager.AppSettings("App.Name").ToString & " alterou sua senha com sucesso!, efetue login novamente", "Login.aspx")
            End If
        Else
            m.Alert(Me, "Senha atual é inválida")
        End If
        Exit Sub
Err_cmd_Salvar_ServerClick:

    End Sub
End Class