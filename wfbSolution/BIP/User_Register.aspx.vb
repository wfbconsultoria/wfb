Public Class User_Register
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m.CheckLogin()
        If Session("UserProfileCode") <> "10" Then Response.Redirect("Default.aspx")
    End Sub

    Private Sub cmd_Salvar_ServerClick(sender As Object, e As EventArgs) Handles cmd_Salvar.ServerClick
        On Error GoTo Err_cmd_Salvar_ServerClick
        'Name
        If txt_Name.Value = "" Then
            m.Alert(Me, "Preencha o nome")
            Exit Sub
        End If
        'E-mail
        If txt_Email.Value = "" Then
            m.Alert(Me, "Preencha o e-mail")
            Exit Sub
        End If
        'Phone
        If txt_Phone.Value = "" Then
            m.Alert(Me, "Preencha o telefone")
            Exit Sub
        End If
        'User_Profile_Id
        If cmb_User_Profile_Id.Text = "0" Then
            m.Alert(Me, "Selecione o perfil")
            Exit Sub
        End If

        'Verifica se o e-mail já está cadastrado
        If m.CheckExists("tb_Users", "Email", txt_Email.Value) = True Then
            m.Alert(Me, "O e-mail " & m.ConvertText(txt_Email.Value, clsMaster.TextCaseOptions.LowerCase) & " já está em uso, não é possivel incluir o usuário")
            Exit Sub
        End If

        'Verifica se o nome já está cadastrado
        If m.CheckExists("tb_Users", "Name", txt_Email.Value) = True Then
            m.Alert(Me, "O nome " & m.ConvertText(txt_Name.Value, clsMaster.TextCaseOptions.LowerCase) & " já está em uso, altere para prosseguir com o registro")
            Exit Sub
        End If

        Dim Password = m.GenerateKey(4)
        Dim Email = m.ConvertText(txt_Email.Value, clsMaster.TextCaseOptions.LowerCase)
        Dim Name = m.ConvertText(txt_Name.Value, clsMaster.TextCaseOptions.UpperCase)
        Dim sql = ""
        sql &= " INSERT INTO [tb_Users] ([Email],[Name],[Password],[Phone],[User_Profile_Id],[Notes],[Insert_Date],[Insert_User],[Insert_IP]) VALUES( "
        sql &= " '" & Email & "', "
        sql &= " '" & Name & "', "
        sql &= " '" & Password & "', "
        sql &= " '" & m.ConvertText(txt_Phone.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql &= cmb_User_Profile_Id.Text & ", "
        sql &= " '" & m.ConvertText(txt_Notes.Value, clsMaster.TextCaseOptions.TextCase) & "', "
        sql &= " '" & m.GetDateTimeToString & "', "
        sql &= " '" & Session("Email").ToString & "', "
        sql &= " '" & Session("IP").ToString & "') "

        If m.ExecuteSQL(sql) = True Then
            'Assunto
            Dim Assunto As String = "Bem vindo ao " & ConfigurationManager.AppSettings("App.Name").ToString
            'Mensagem
            Dim Mensagem As String = ""
            Mensagem &= "<h3>Seu usuário foi incluido no " & ConfigurationManager.AppSettings("App.Name").ToString & ".</h3><br/>"
            Mensagem &= "<strong>" & Name & "</strong><br/>"
            Mensagem &= "Seu e-mail para acesso é  <strong>" & Email & "</strong><br/>"
            Mensagem &= "Sua senha é <strong>" & Password & "</strong><br/><br/>"
            Mensagem &= "No primeiro acesso sua senha deverá ser substituida por outra de sua escolha a qual somente você terá acesso<br/>"
            Mensagem &= "Para substituir sua senha, clique sobre o seu e-mail na barra de menus e selecione a opção <strong>ALTERAR SENHA</strong><br/>"
            Mensagem &= "<h3>LEIA COM ATENÇÃO</h3>"
            Mensagem &= "Declaro ser propriétário do e-mail " & Email & " que foi utilizado para registro e acesso ao site " & ConfigurationManager.AppSettings("App.Name").ToString & ".<br/>"
            Mensagem &= "Estou ciente de que minha senha é pessoal e intransferivel e só poderá ser recuperada ou alterada por mim através do email " & Email & ".<br/>"
            Mensagem &= "Estou ciente de que todas as ações realizadas no site " & ConfigurationManager.AppSettings("App.Name").ToString & " serão registradas em log sob o email " & Email & ".<br/>"
            Mensagem &= "Estou ciente de que todas as informações registradas neste site são de propriedade da " & ConfigurationManager.AppSettings("App.Customer").ToString & ".<br/>"
            Mensagem &= "<br/>"
            Mensagem &= "A sua senha definida durante registro é criptografada e nem os administradores e/ou usuários do " & ConfigurationManager.AppSettings("App.Name").ToString & " posssuem acesso.<br/>"
            Mensagem &= "Portanto todas as informações incluidas são de sua total responsabilidade quanto a veracidade.<br/>"
            Mensagem &= "<br/>"
            Mensagem &= "Caso não concorde com as condiçoes acima, envie um e-mail para " & ConfigurationManager.AppSettings("App.Email").ToString & " solicitando ocancelamento do seu registro e não efetue acesso ao sistema e nem altere sua senha<br/>"

            m.SendMail(Assunto, Mensagem, Email, Name, ConfigurationManager.AppSettings("App.Email").ToString, ConfigurationManager.AppSettings("App.Name").ToString)
            m.Alert(Me, txt_Email.Value & " incluido com sucesso")
        End If
        Exit Sub
Err_cmd_Salvar_ServerClick:
        m.Alert(Me, "Erro ao incluir usuário")
    End Sub
End Class