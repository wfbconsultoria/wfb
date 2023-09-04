
Partial Class Login
    Inherits System.Web.UI.Page
    Dim M As New clsmaster
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("UserSessionID") = HttpContext.Current.Session.SessionID.ToString
        Session("UserIP") = HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString()
        Session("UserLoginDate") = ""
        Session("USER_ID") = ""
        Session("USER_EMAIL") = ""
        Session("USER_NAME") = ""
        Session("USER_PHONE") = ""
        Session("USER_STATUS_CODE") = ""
        Session("USER_STATUS") = ""
        Session("USER_PROFILE_CODE") = ""
        Session("USER_PROFILE") = ""
        Session("USER_ACTIVE") = ""
        Session("USER_INSERT_DATE") = ""
        Session("USER_UPDATE_DATE") = ""
    End Sub
    Private Sub cmdLogin_Click(sender As Object, e As EventArgs) Handles cmdLogin.Click

        'Validação de campos preenchidos
        If Len(txtEmail.Text) = 0 Then
            Alert(ConfigurationManager.AppSettings("msg.ErrEmailRequired").ToString, False, "")
            Exit Sub
        End If

        If Len(txtPassword.Text) = 0 Then
            Alert(ConfigurationManager.AppSettings("msg.ErrPasswordRequired").ToString, False, "")
            Exit Sub
        End If

        'Validar dados de login
        If M.CheckUserAccess(M.ConvertText(txtEmail.Text, clsMaster.TextCaseOptions.LowerCase).ToString & EmailDomain.Text, M.ConvertText(txtPassword.Text, clsMaster.TextCaseOptions.LowerCase).ToString, clsMaster.UserAccessOptions.Application) = False Then
            'Mensagem de erro
            Session("USER_EMAIL") = ""
            Alert(ConfigurationManager.AppSettings("msg.ErrLOgin").ToString, False, "")
            Exit Sub
            'Select no banco
        Else
            Dim dtr As System.Data.SqlClient.SqlDataReader
            Dim sql As String = "Select * From vw_Users Where USER_EMAIL='" & M.ConvertText(txtEmail.Text, clsMaster.TextCaseOptions.LowerCase).ToString & EmailDomain.Text & "'"
            dtr = M.ExecuteSelect(sql)
            If dtr.HasRows Then
                dtr.Read()

                'Carregar as sessões com informações do usuário
                Session("USER_ID") = dtr("USER_ID").ToString
                Session("USER_EMAIL") = dtr("USER_EMAIL").ToString
                Session("USER_NAME") = dtr("USER_NAME").ToString
                Session("UserLoginDate") = Replace(Now.ToString("u"), "Z", "")
                If Not IsDBNull(dtr("USER_PHONE")) Then Session("USER_PHONE") = dtr("USER_PHONE").ToString
                If Not IsDBNull(dtr("USER_STATUS_CODE")) Then Session("USER_STATUS_CODE") = dtr("USER_STATUS_CODE").ToString
                If Not IsDBNull(dtr("USER_STATUS")) Then Session("USER_STATUS") = dtr("USER_STATUS").ToString
                If Not IsDBNull(dtr("USER_PROFILE_CODE")) Then Session("USER_PROFILE_CODE") = dtr("USER_PROFILE_CODE").ToString
                If Not IsDBNull(dtr("USER_PROFILE")) Then Session("USER_PROFILE") = dtr("USER_PROFILE").ToString
                If Not IsDBNull(dtr("Active")) Then Session("USER_ACTIVE") = dtr("Active").ToString

                'Registro de acesso no site
                sql = ""
                sql = sql & " Insert Into tb_Log_Site (Login_Mail, Login_Key, Login_Date, Login_IP, Session_ID) Values("
                sql = sql & " '" & Session("USER_EMAIL") & "', "
                sql = sql & " '" & M.GenerateKey(clsMaster.KeyOptions.LongKey).ToString() & "', "
                sql = sql & " '" & Session("UserLoginDate").ToString & "', "
                sql = sql & " '" & Session("UserIP").ToString & "', "
                sql = sql & " '" & Session("UserSessionID").ToString & "') "
                M.ExecuteSQL(sql)
                Response.Redirect("Default")
            End If
        End If

    End Sub
    Private Sub cmd_Forgot_Click(sender As Object, e As EventArgs) Handles cmd_Forgot.Click
        'Redefinir senha

        'Checar se o usuário foi preenchido
        If Len(txtEmail.Text) = 0 Then
            Alert(ConfigurationManager.AppSettings("msg.ErrEmailRequired").ToString, False, "")
            Exit Sub
        End If

        Dim d As System.Data.SqlClient.SqlDataReader
        Dim sql As String = "Select * From vw_Users Where USER_EMAIL='" & M.ConvertText(txtEmail.Text, clsMaster.TextCaseOptions.LowerCase).ToString & EmailDomain.Text & "' and Active = 1"
        d = M.ExecuteSelect(sql)
        If d.HasRows Then
            d.Read()
            Dim message As String = " Foi solicitado a recuperação de senha no sistema CSL Reports, Segue abaixo as informações sobre seu cadastro: " & vbCrLf
            message += " E-mail: " & d("User_Email") & vbCrLf & " Senha: " & d("User_Password") & vbCrLf
            M.EnviarEmail(d("USER_EMAIL").ToString, message)
            Alert(ConfigurationManager.AppSettings("msg.SendPassword"), False, "")
        Else
            Alert(ConfigurationManager.AppSettings("msg.ErrRecoveryPassword"), False, "")
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


