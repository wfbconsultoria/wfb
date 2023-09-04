
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin

Partial Public Class Register
    Inherits Page
    Dim m As New clsMaster
    Dim u As New clsUsers
    Dim Status As String = "!"
    Private Sub Register_Load(sender As Object, e As EventArgs) Handles Me.Load
        If u.Authenticated Then u.Logout(True, "/Account/Register")
        If Left(PageMessage.Text, 1) = "!" Then FormManager("")
        cmdRegister.Visible = False
    End Sub

    Sub CreateUser_Click(sender As Object, e As EventArgs)

        Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
        Dim signInManager = Context.GetOwinContext().Get(Of ApplicationSignInManager)()
        Dim user = New ApplicationUser() With {.UserName = Email.Text, .Email = Email.Text}
        Dim result = manager.Create(user, Password.Text)
        If result.Succeeded Then

            'Customizado WFB verifica se o usuario esta registrado tb_Users e caso nao esteja inclui
            If m.CheckExists("tb_Users", "Email", Email.Text) = False Then
                m.ExecuteSQL("Delete From tb_Users  Where Email ='" & Email.Text & "'")
                m.ExecuteSQL("Insert Into tb_Users (Email, Name, Birth_Date, Document, User_Status) Values ('" & Email.Text & "', '" & Name.Text & "', '" & Birth_Date.Text & "', '" & Document.Text & "', 'UnConfirmed')")
            End If

            ' Para obter mais informações sobre como habilitar a confirmação da conta e redefinição de senha, visite https://go.microsoft.com/fwlink/?LinkID=320771
            Dim code = manager.GenerateEmailConfirmationToken(user.Id)
            Dim callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request)

            Dim confirmMessage As String
            confirmMessage = ""
            confirmMessage = confirmMessage & "<h3>LEIA COM ATENÇÃO</h3>" & vbCrLf
            confirmMessage = confirmMessage & " Declaro ser propriétário do e-mail " & user.UserName & " que será utilizado para registro e acesso ao site " & ConfigurationManager.AppSettings("App.Name").ToString & ".<br/>"
            confirmMessage = confirmMessage & " Estou ciente de que minha senha é pessoal e intransferivel e só poderá ser recuperada ou alterada por mim através do email " & user.UserName & ".<br/>"
            confirmMessage = confirmMessage & " Estou ciente de que todas as ações realizadas no site " & ConfigurationManager.AppSettings("App.Name").ToString & " serão registradas em log sob o email " & user.UserName & ".<br/>"
            confirmMessage = confirmMessage & " Estou ciente de que todas as informações registradas neste site são de propriedade da " & ConfigurationManager.AppSettings("App.Customer").ToString & ".<br/>"
            confirmMessage = confirmMessage & "<br/>"
            confirmMessage = confirmMessage & " A sua senha definida durante registro é criptografada e nem os administradores e/ou usuários do " & ConfigurationManager.AppSettings("App.Name").ToString & " posssuem acesso.<br/>"
            confirmMessage = confirmMessage & " Portanto todas as informações incluidas são de sua total responsabilidade quanto a veracidade.<br/>"
            confirmMessage = confirmMessage & "<br/><br/>"

            manager.SendEmail(user.Id, "Confirmar registro sua conta e propriedade do e-mail", confirmMessage & " Confirme se realmente é proprietário do e-mail " & user.UserName & " e está ciente <br/><br/><a href=""" & callbackUrl & """>Confirmo a propriedade do referido e-mail e estou ciente </a>.")
            'Faz login automatico desabiltiado por WFB
            'signInManager.SignIn(user, isPersistent:=False, rememberBrowser:=True)

            'Custom WFBDireciona para página de mensagens de usuarios
            Response.Redirect("~/Account/AccountMessages?MessageType=NewUser")
            'IdentityHelper.RedirectToReturnUrl(Request.QueryString("ReturnUrl"), Response)
        Else
            PageMessage.Text = result.Errors.FirstOrDefault()
        End If
    End Sub

    Sub Validate_User(sender As Object, e As EventArgs)
        If ValidateEmail() = False Then Exit Sub
        If ValidateDocument() = False Then Exit Sub
        FormManager("ValidateOK")
    End Sub

    Function ValidateEmail() As Boolean
        Try
            If u.GetUserInfos(Email.Text) = True Then
                FormManager("RegisteredEMail")
                Return False
            Else
                FormManager("ValidEMail")
                Return True
            End If
        Catch ex As Exception
            FormManager("ErrorEMail")
            Return False
        End Try
    End Function
    Function ValidateDocument() As Boolean
        If u.CheckUserDocument(Document.Text) <> "UnRegistered" Then
            FormManager("RegisteredDocument")
            Return False
        End If
        Try
            Dim pf As New svcCDC.PessoaFisicaSimplificada
            Dim strDocument = m.ConvertText(Document.Text, clsMaster.TextCaseOptions.UpperCase).ToString
            Dim strBirthDate = Birth_Date.Text.ToString
            pf = m.ConsultaPessoaFisicaSimplificada(strDocument, strBirthDate)
            Name.Text = pf.Nome.ToUpper
            FormManager("ValidDocument")
            Return True
        Catch ex As Exception
            Name.Text = "ERRO - CPF ou DATA DE NASCIMENTO INVÁLIDOS"
            FormManager("InvalidDocument")
            Return False
        End Try
    End Function
    Sub Clear_Form(sender As Object, e As EventArgs)
        FormManager("Clear")
    End Sub

    Sub FormManager(ValidationStatus As String, Optional Message As String = "")
        Select Case ValidationStatus
            Case = "Clear"
                PageMessage.Text = "! - Preencher e validar suas informações E-mail, CPF, Nascimento"
                PageMessage.CssClass = "form-control alert-info"
                cmdRegister.Visible = False
                cmdValidate.Visible = True
                cmdClear.Visible = True
                Email.Text = ""
                Email.Enabled = True
                Email.CssClass = ("form-control")
                Document.Text = ""
                Document.Enabled = True
                Document.CssClass = ("form-control")
                Birth_Date.Text = ""
                Birth_Date.Enabled = True
                Birth_Date.CssClass = ("form-control")
                Name.Text = ""
                Name.Enabled = False
                Password.Text = "Password"
                Password.Enabled = False
                ConfirmPassword.Text = "Confirm Password"
                ConfirmPassword.Enabled = False
            Case = "RegisteredEMail"
                PageMessage.Text = "E-mail em uso, indisponível para registro"
                PageMessage.CssClass = "form-control alert-danger"
                Email.Enabled = True
                Email.CssClass = ("form-control is-invalid")
            Case = "ValidEMail"
                PageMessage.Text = "E-mail válido disponível para registro"
                PageMessage.CssClass = "form-control alert-sucess"
                Email.Enabled = False
                Email.CssClass = ("form-control is-valid")
            Case = "ErrorEMail"
                PageMessage.Text = "Erro ao validar e-mail, tente novamente"
                PageMessage.CssClass = "form-control alert-danger"
                Email.Enabled = True
                Email.CssClass = ("form-control is-invalid")
            Case = "RegisteredDocument"
                PageMessage.Text = "CPF já associado a outro e-mail, indisponível para registro"
                PageMessage.CssClass = "form-control alert-danger"
                Document.Enabled = True
                Document.CssClass = ("form-control is-invalid")
                Birth_Date.Enabled = True
                Birth_Date.CssClass = ("form-control is-invalid")
            Case = "InvalidDocument"
                PageMessage.Text = "CPF ou Data de Nascimento inválidos"
                PageMessage.CssClass = "form-control alert-danger"
                Document.Enabled = True
                Document.CssClass = ("form-control is-invalid")
                Birth_Date.Enabled = True
                Birth_Date.CssClass = ("form-control is-invalid")
            Case = "ErrorDocument"
                PageMessage.Text = "Erro ao validar CPF, tente novamente"
                PageMessage.CssClass = "form-control alert-danger"
                Document.Enabled = True
                Document.CssClass = ("form-control is-invalid")
                Birth_Date.Enabled = True
                Birth_Date.CssClass = ("form-control is-invalid")
            Case = "ValidDocument"
                PageMessage.Text = "CPF e Data de Nascimento Válidos"
                PageMessage.CssClass = "form-control alert-success"
                Document.Enabled = False
                Document.CssClass = ("form-control is-valid")
                Birth_Date.Enabled = False
                Birth_Date.CssClass = ("form-control is-valid")
            Case = "ValidateOK"
                PageMessage.Text = "Informações válidas, verifique se estão corretas e registre-se"
                PageMessage.CssClass = "form-control alert-success"
                Email.Enabled = False
                Email.CssClass = ("form-control is-valid")
                Document.Enabled = False
                Document.CssClass = ("form-control is-valid")
                Birth_Date.Enabled = False
                Birth_Date.CssClass = ("form-control is-valid")
                cmdClear.Visible = True
                cmdRegister.Visible = True
                cmdValidate.Visible = False
                Password.Text = "Password"
                Password.Enabled = True
                ConfirmPassword.Text = "Confirm Password"
                ConfirmPassword.Enabled = True
        End Select

    End Sub
End Class

