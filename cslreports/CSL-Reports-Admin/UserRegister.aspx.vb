
Partial Class UserRegister
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Dim Message As String = ""

    Private Sub UserRegister_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Verifica se usuario está logado
        If Session("USER_EMAIL") = "" Then
            Response.Redirect("Login.aspx")
        End If
        'configurações
        Page.Title = ConfigurationManager.AppSettings("UserRegister.title")

        'validações
        rfv_UserName.ErrorMessage = ConfigurationManager.AppSettings("msg.FieldRequired")
        rfv_UserEmail.ErrorMessage = ConfigurationManager.AppSettings("msg.FieldRequired")
        rfv_UserProfile.ErrorMessage = ConfigurationManager.AppSettings("msg.FieldRequired")
    End Sub

    Private Sub cmd_Save_Click(sender As Object, e As EventArgs) Handles cmd_Save.Click
        'verifica email do usuario se não está vazio
        If m.CheckUserStatus(m.ConvertText(txt_UserEmail.Text, clsMaster.TextCaseOptions.LowerCase) & txt_EmailDomain.Text) = "000" Then
            'Declaração de Variaveis
            Dim sql As String = ""
            Dim senha As String = ""
            'Verifica se usuario é administrador
            If Session("USER_PROFILE_CODE") = 100 Then
                'Verifica se o campo de perfil está diferente de sytem administrador
                If cmb_UserProfile.Text <> "001" Then
                    'gera uma senha
                    senha = m.GenerateKey(clsMaster.KeyOptions.Password)
                    'cria query de inserção
                    sql = sql & " Insert Into tb_Users ([USER_NAME],[USER_EMAIL],[USER_PASSWORD],[USER_STATUS_CODE],[USER_PROFILE_CODE], [Insert_User]) "
                    sql = sql & "Values ('" & m.ConvertText(txt_UserName.Text, clsMaster.TextCaseOptions.UpperCase) & "', '" & m.ConvertText(txt_UserEmail.Text, clsMaster.TextCaseOptions.LowerCase) & txt_EmailDomain.Text & "', '" & senha & "','REG', '" & cmb_UserProfile.Text & "', '" & Session("USER_EMAIL").ToString & "')"
                    If m.ExecuteSQL(sql) = True Then
                        'envia email ao usuario informando que ele foi cadastrado
                        m.EnviarEmail(m.ConvertText(txt_UserEmail.Text, clsMaster.TextCaseOptions.LowerCase) & txt_EmailDomain.Text, ConfigurationManager.AppSettings("msg.UserRegisteredSuccess1").ToString & "CSL Reports" & " " & ConfigurationManager.AppSettings("msg.UserRegisteredSuccess2").ToString & " " & senha & " " & ConfigurationManager.AppSettings("msg.UserRegisteredSuccess3").ToString)
                        'informa que usuario foi cadastrado
                        Response.Write("<script>alert('" & m.ConvertText(txt_UserEmail.Text, clsMaster.TextCaseOptions.TextCase) & txt_EmailDomain.Text & " - " & ConfigurationManager.AppSettings("msg.UserRegisteredSuccess").ToString & "'); window.location='UsersList.aspx';</script>")
                    Else
                        'informa que deu erro ao cadastrar usuario
                        m.SystemError(ConfigurationManager.AppSettings("msg.SystemError").ToString, ConfigurationManager.AppSettings("msg.SystemError").ToString, "", "")
                    End If
                Else
                    'emite um alerta informando
                    Response.Write("<script>alert('Você só pode cadastrar usuários de nível igual ao seu ou de nivel menor');history.back();</script>")
                End If
            Else
                'gera uma senha
                senha = m.GenerateKey(clsMaster.KeyOptions.Password)
                'cria query de inserção
                sql = sql & " Insert Into tb_Users ([USER_NAME],[USER_EMAIL],[USER_PASSWORD],[USER_STATUS_CODE],[USER_PROFILE_CODE], [Insert_User]) "
                sql = sql & "Values ('" & m.ConvertText(txt_UserName.Text, clsMaster.TextCaseOptions.UpperCase) & "', '" & m.ConvertText(txt_UserEmail.Text, clsMaster.TextCaseOptions.LowerCase) & txt_EmailDomain.Text & "', '" & senha & "','REG', '" & cmb_UserProfile.Text & "', '" & Session("USER_EMAIL").ToString & "')"
                'verifica se executou
                If m.ExecuteSQL(sql) = True Then
                    'envia email informando que foi cadastrado
                    m.EnviarEmail(m.ConvertText(txt_UserEmail.Text, clsMaster.TextCaseOptions.LowerCase) & txt_EmailDomain.Text, ConfigurationManager.AppSettings("msg.UserRegisteredSuccess1").ToString & "CSL Reports" & " " & ConfigurationManager.AppSettings("msg.UserRegisteredSuccess2").ToString & " " & senha & " " & ConfigurationManager.AppSettings("msg.UserRegisteredSuccess3").ToString)
                    'informa que usuario foi cadastrado
                    Response.Write("<script>alert('" & m.ConvertText(txt_UserEmail.Text, clsMaster.TextCaseOptions.TextCase) & txt_EmailDomain.Text & " - " & ConfigurationManager.AppSettings("msg.UserRegisteredSuccess").ToString & "'); window.location='UsersList.aspx';</script>")
                Else
                    'informa que deu erro ao cadastrar usuario
                    Response.Write("<script>alert('" & m.ConvertText(txt_UserEmail.Text, clsMaster.TextCaseOptions.TextCase) & txt_EmailDomain.Text & " - " & ConfigurationManager.AppSettings("msg.UserRegisteredSuccess").ToString & "'); window.location='UsersList.aspx'</script>")
                End If
            End If
        Else
            'informa que email não é valido
            Alert(txt_UserEmail.Text & txt_EmailDomain.Text & " - " & ConfigurationManager.AppSettings("msg.UserRegisteredFailure").ToString, False, "")
        End If
    End Sub

    Private Sub cmd_Cancel_Click(sender As Object, e As EventArgs) Handles cmd_Cancel.Click
        'redireciona a lista de usuarios
        Response.Redirect("UsersList.aspx")
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
