Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin

Partial Public Class Login
    Inherits Page
    ReadOnly m As New clsMaster
    ReadOnly u As New clsUsers
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        RegisterHyperLink.NavigateUrl = "Register"
        ' Ativar quando tiver a confirmação da conta habilitada para a funcionalidade de redefinição de senha
        ForgotPasswordHyperLink.NavigateUrl = "Forgot"
        'OpenAuthLogin.ReturnUrl = Request.QueryString("ReturnUrl")
        Dim returnUrl = HttpUtility.UrlEncode(Request.QueryString("ReturnUrl"))
        If Not [String].IsNullOrEmpty(returnUrl) Then
            RegisterHyperLink.NavigateUrl += "?ReturnUrl=" & returnUrl
        End If
    End Sub

    Protected Sub LogIn(sender As Object, e As EventArgs)

        If IsValid Then
            ' Valide a senha de usuário
            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            Dim signinManager = Context.GetOwinContext().GetUserManager(Of ApplicationSignInManager)()
            ' Isso não conta falhas de logon para bloqueio de conta
            ' Para habilitar falhas de senha para acionar o bloqueio, mude para shouldLockout := True
            Dim result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout:=False)

            Select Case result
                Case SignInStatus.Success
                    u.GetUserInfos(Email.Text)
                    Dim sql As String = ""
                    Dim IDSession As String = m.GenerateKey("LOG").ToString
                    Dim LogDate = m.GetDateTimeToString.ToString
                    Dim LogIP As String = Request.ServerVariables("REMOTE_ADDR").ToString
                    Dim LogSession As String = Session.SessionID.ToString
                    Dim LogBrowser As String = Request.ServerVariables("HTTP_USER_AGENT").ToString
                    Dim LogLocation As String = ""
                    Session("ID_SESSION") = IDSession
                    sql = sql & " Insert Into tb_Users_Logins (Email, LogIn_Date, LogIn_Ip, LogIn_Session, LogIn_Browser, Type, User_Status) Values( "
                    sql = sql & "'" & u.UserEmail & "', "
                    sql = sql & "'" & LogDate & "', "
                    sql = sql & "'" & LogIP & "', "
                    sql = sql & "'" & Session.SessionID.ToString & "', "
                    sql = sql & "'" & LogBrowser & "', "
                    sql = sql & "'LogIn', "
                    sql = sql & "'" & u.UserStatus & "') "
                    m.ExecuteSQL(sql)
                    m.ExecuteSQL("Update tb_Users Set Login = 1, LogOut = 0, LogOut_Date = NULL ,Login_Date = '" & LogDate & "', Login_Ip = '" & LogIP & "', Login_Session = '" & LogSession & "', Login_Browser = '" & LogBrowser & "', Login_Location = '" & LogLocation & "' Where Email = '" & Email.Text & "'")
                    m.Alert(Me, u.UserName & " Login efetuado com sucesso em " & m.GetDateTimeToString, True, "../Default")
                    Exit Select
                Case SignInStatus.LockedOut
                    Response.Redirect("/Account/Lockout")
                    Exit Select
                Case SignInStatus.RequiresVerification
                    Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                    Request.QueryString("ReturnUrl"),
                                                    RememberMe.Checked),
                                      True)
                    Exit Select
                Case Else
                    FailureText.Text = "Tentativa de logon inválida"
                    ErrorMessage.Visible = True
                    Exit Select
            End Select
        End If
    End Sub

End Class
