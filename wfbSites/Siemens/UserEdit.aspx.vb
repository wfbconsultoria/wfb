
Partial Class UserEdit
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Dim Message As string = ""
    Private Sub UserEdit_Load(sender As Object, e As EventArgs) Handles Me.Load
        'verifca se usuario está logado
        If Session("USER_EMAIL") = "" Then Response.Redirect("Login")
        Page.Title = ConfigurationManager.AppSettings("UserEdit.title")
        'verifica o se o id está presente se não retorna a lista de usuarios
        If Request.QueryString("ID").ToString = "" Then Response.Redirect("UsersList.aspx")

        rfv_UserName.ErrorMessage=ConfigurationManager.AppSettings("msg.FieldRequired")
        rfv_UserEmail.ErrorMessage=ConfigurationManager.AppSettings("msg.FieldRequired")
        rfv_UserProfile.ErrorMessage=ConfigurationManager.AppSettings("msg.FieldRequired")

        'verifica o tamanho do nome do usuario
        If Len (txt_UserName.Text) > 0 Then Update()

        'query para verificar
        Dim dtr As System.Data.SqlClient.SqlDataReader  = m.ExecuteSelect("Select * From vw_Users Where USER_ID = " & Request.QueryString("ID").ToString)

        'verifica se tem linhas
        If dtr.HasRows Then
            'le as linhas
            dtr.Read()

            'verifica se o email da sessão é igual o do banco
            If Session("USER_EMAIL").ToString = dtr("USER_EMAIL").ToString Then
                'emite msg avisando não é possivel fazer alteração com usuario logado
                Alert(ConfigurationManager.AppSettings("msg.UserUpdateLogged"), True, "UsersList.aspx")
            End If

            'atribui valor ao campo de nome
            txt_UserName.Text = dtr("USER_NAME")

            'atribui valor ao campo de email
            txt_UserEmail.Text = dtr("USER_EMAIL")

            'atribui valor ao campo de perfil do usuario
            cmb_UserProfile.Text = dtr("USER_PROFILE_CODE")

            'verifica se usuario está desativado
            If dtr("Active").ToString = "False" Then
                'atribui valores aos campos
                txt_UserStatus.Text = ConfigurationManager.AppSettings("msg.UserInactive").ToString
                txt_UserStatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#f2dede")
                cmd_off.Visible = False
                cmd_on.Visible = True
                txt_UserName.Enabled = False
                txt_UserEmail.Enabled = False
                cmb_UserProfile.Enabled = False
                cmd_Save.Visible = False
            Else
                'atribui valores aos campos
                txt_UserStatus.Text = ConfigurationManager.AppSettings("msg.UserActive").ToString
                txt_UserStatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#d9edf7")
                cmd_off.Visible = True
                cmd_on.Visible = False
                txt_UserName.Enabled = True
                txt_UserEmail.Enabled = True
                cmb_UserProfile.Enabled = True
                cmd_Save.Visible = True
            End If
            'desativa o campo do email
            txt_UserEmail.Enabled = False
        Else
            'emite menssagem e redireciona a lista de usuários
            Alert(ConfigurationManager.AppSettings("msg.UserNotFound"),True,"UsersList.aspx")
        End if
    End Sub

    Private Sub cmd_off_Click(sender As Object, e As EventArgs) Handles cmd_off.Click
        'declaração de variavel
        Dim sql As String = ""
        'query de atualização
        sql = sql & " Update tb_Users Set Active = 0, USER_STATUS_CODE = 'LOC' Where ID = " & Request.QueryString("ID")
        'executa query
        m.ExecuteSQL(sql)
        'envia email avisando que foi desativado
        m.EnviarEmail(txt_UserEmail.Text, ConfigurationManager.AppSettings("msg.UserInactivatedMail").ToString)
        'emite menssagem informando que foi desaticavo
        Alert(ConfigurationManager.AppSettings("msg.UserInactivated"), False, "")
        'redireciona a lista de usuários
        Response.Redirect("UsersList.aspx")
    End Sub

    Private Sub cmd_on_Click(sender As Object, e As EventArgs) Handles cmd_on.Click
        'declaração de variavel
        Dim sql As String = ""
        'query de atualização
        sql = sql & " Update tb_Users Set Active = 1, USER_STATUS_CODE = 'REG' Where ID = " & Request.QueryString("ID")
        'executa query
        m.ExecuteSQL(sql)
        'envia email ao usuario
        m.EnviarEmail(txt_UserEmail.Text, ConfigurationManager.AppSettings("msg.UserActivatedMail").ToString)
        'emite menssagem avisando que foi ativado
        Alert(ConfigurationManager.AppSettings("msg.UserActivated"), False, "")
        'redireciona a lista de usuarios
        Response.Redirect("UsersList.aspx")
    End Sub
    
     Private Sub cmd_Cancel_Click(sender As Object, e As EventArgs) Handles cmd_Cancel.Click
        Response.Redirect("UsersList.aspx")
    End Sub
    Private Sub Update()
        'declaração de variaveis
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String = ""
        Dim nivel As String = cmb_UserProfile.Text
        'Verifica o tipo de usuário
        If Session("USER_PROFILE_CODE") = "100" And nivel = "001" Then
            'emite menssagem avisando que não é permitido
            Response.Write("<script>alert('Você só pode registrar usuarios do mesmo nivel que o seu ou abaixo.');</script>")
        Else

            'limpa a variavél
            sql = ""

            'atribui query a variavél
            sql = "select * from tb_Users where USER_EMAIL='" & txt_UserEmail.Text & "'"

            'executa a query
            dtr = m.ExecuteSelect(sql)

            'verifica se tem linhas
            If dtr.HasRows Then
                'le as linhas
                dtr.Read()

                'verifica o perfil do usuário que vai ser altera com o que ta alterando
                If dtr("USER_PROFILE_CODE") = "001" And Session("USER_PROFILE_CODE") = "100" Then

                    'emite menssagem falando que o usuário é de nivel superior
                    Response.Write("<script>alert('Esse usuário é de nivel superior ao seu, não foi possível editá-lo');</script>")
                Else
                    'Cria query de atualização
                    sql = ""
                    sql = sql & " Update tb_Users Set "
                    sql = sql & " [USER_NAME] = '" & m.ConvertText(txt_UserName.Text, clsMaster.TextCaseOptions.UpperCase) & "', "
                    sql = sql & " [USER_PROFILE_CODE]  = '" & cmb_UserProfile.Text & "', "
                    sql = sql & " [Update_User]  = '" & Session("USER_EMAIL").ToString & "' "
                    sql = sql & " Where [USER_EMAIL] = '" & txt_UserEmail.Text & "'"

                    'executa query
                    If m.ExecuteSQL(sql) = True Then
                        'emite messagem de sucesso
                        Alert(ConfigurationManager.AppSettings("msg.UserUpdatedSuccess").ToString, False, "")
                    Else
                        'emite messagem de erro
                        m.SystemError(ConfigurationManager.AppSettings("msg.SystemError").ToString, ConfigurationManager.AppSettings("msg.SystemError").ToString, "", "")
                    End If
                End If
            Else
                Response.Write("<script>alert('Não Foi Possível encontrar usuário');</script>")
            End If
        End If

    End Sub
    Protected Function Alert(ByVal Texto_Mensagem As String, ByVal Redirecionar As Boolean, ByVal Pagina As String) As Boolean
        Dim jscript As String
        'CAIXA DE MENSAGEM
        If Redirecionar = True Then
            jscript = ""
            jscript += "<script language='JavaScript'>"
            jscript += ";alert('" & Texto_Mensagem & "'); document.location.href='" & Pagina & "'"
            jscript += "</script>"
        Else
            jscript = ""
            jscript += "<script language='JavaScript'>"
            jscript += ";alert('" & Texto_Mensagem & "');"
            jscript += "</script>"
        End If
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Mensagem", jscript)
        Alert = True
    End Function

End Class
