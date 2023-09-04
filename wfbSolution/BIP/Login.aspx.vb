Public Class Login
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Variaveis do Ususario logado
        Session("Email") = ""
        Session("UserName") = ""
        Session("UserProfileCode") = ""
        Session("UserProfile") = ""
        Session("UserPhone") = ""
        'Variaveis do WEB Server
        Session("ID") = ""
        Session("IP") = ""
        Session("Browser") = ""
        Session("LoginDate") = ""
    End Sub

    Private Sub cmd_Login_ServerClick(sender As Object, e As EventArgs) Handles cmd_Login.ServerClick
        On Error GoTo Err_cmd_Login_ServerClick
        'Email
        If m.CheckString(txt_Email.Value) = False Then
            m.Alert(Me, "Preencha o e-mail")
            Exit Sub
        End If
        'Password
        If m.CheckString(txt_Password.Value) = False Then
            m.Alert(Me, "Preencha a senha")
            Exit Sub
        End If
        Dim sql As String = " Select * From vw_Users Where Email = '" & txt_Email.Value & "' and Password = '" & txt_Password.Value & "'"

        Dim dtrLogin = m.ExecuteSelect(sql)
        If dtrLogin.HasRows Then
            dtrLogin.Read()
            'Verfica se o usuário está bloqueado
            If dtrLogin("User_Profile_Id") = 100 Then
                m.Alert(Me, "Usuário INATIVO, contate o suporte do " & ConfigurationManager.AppSettings("App.Name").ToString)
                Exit Sub
            End If

            'Recuperar variaveis de sessão da vw_Users
            Session("Email") = txt_Email.Value.ToString
            Session("UserName") = dtrLogin("Name").ToString
            Session("UserProfileCode") = dtrLogin("User_Profile_Id").ToString
            Session("UserProfile") = dtrLogin("User_Profile").ToString
            Session("UserPhone") = dtrLogin("Phone").ToString
            'Recuperar do WEB Server
            Session("ID") = Session.SessionID.ToString
            Session("IP") = Request.ServerVariables("REMOTE_ADDR").ToString
            Session("Browser") = Request.ServerVariables("HTTP_USER_AGENT").ToString()
            Session("LoginDate") = m.GetDateTimeToString

            sql = ""
            sql &= "INSERT INTO [tb_Log_Site] ([Email],[Login_Date],[Login_IP],[Login_ID],[Login_Browser]) VALUES ("
            sql &= "'" & Session("Email") & "', "
            sql &= "'" & Session("LoginDate") & "', "
            sql &= "'" & Session("IP") & "', "
            sql &= "'" & Session("ID") & "', "
            sql &= "'" & Session("Browser") & "') "
            m.ExecuteSQL(sql)
            m.Alert(Me, Session("UserName") & ", bem vindo ao " & ConfigurationManager.AppSettings("App.Name").ToString & "!", "Default.aspx")
        Else
            m.Alert(Me, "E-mail ou senha não conferem")
        End If
        Exit Sub
Err_cmd_Login_ServerClick:

    End Sub

    Private Sub cmd_Forgot_ServerClick(sender As Object, e As EventArgs) Handles cmd_Forgot.ServerClick
        On Error GoTo Err_cmd_Forgot_ServerClick
        'Email
        If m.CheckString(txt_Email.Value) = False Then
            m.Alert(Me, "Para recuperar sua senha, preencha o seu e-mail")
            Exit Sub
        End If

        Dim sql As String = " Select * From vw_Users Where Email = '" & txt_Email.Value & "'"
        Dim dtrForgot = m.ExecuteSelect(sql)
        If dtrForgot.HasRows Then
            dtrForgot.Read()
            Dim Email = dtrForgot("Email").ToString
            Dim Password = dtrForgot("Password").ToString
            Dim Name = dtrForgot("Name").ToString
            'Verfica se o usuário está bloqueado
            If dtrForgot("User_Profile_Id") = 100 Then
                m.Alert(Me, "Usuário INATIVO, NÃO É POSSIVEL RECUPERAR A SENHA, contate o suporte do " & ConfigurationManager.AppSettings("App.Name").ToString)
                Exit Sub
            End If

            'Assunto
            Dim Assunto As String = "Senha Recuperada"
            'Mensagem
            Dim Mensagem As String = ""
            Mensagem &= "<h3>" & Name & " sua senha foi recuperada</h3><br/>"
            Mensagem &= "Email registrado: <strong>" & Email & "</strong><br/>"
            Mensagem &= "Senha atual: <strong>" & Password & "</strong><br/>"
            m.SendMail(Assunto, Mensagem, Email, Name, ConfigurationManager.AppSettings("App.Email").ToString, ConfigurationManager.AppSettings("App.Name").ToString)
            m.Alert(Me, "O " & ConfigurationManager.AppSettings("App.Name").ToString & " enviou sua senha para " & Email)
        Else
            m.Alert(Me, "E-mail NÃO REGISTRADO, NÃO É POSSIVEL RECUPERAR A SENHA")
        End If
        Exit Sub
Err_cmd_Forgot_ServerClick:

    End Sub
End Class