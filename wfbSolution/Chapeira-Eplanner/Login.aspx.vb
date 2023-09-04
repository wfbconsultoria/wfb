Public Class Login
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly c As New clsColaboradores
    ReadOnly l As New clsLojas
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        l.GetInfoLoja()
        Loja.InnerText = l.Loja
        Session("NOME_LOGIN") = ""
        Session("EMAIL_LOGIN") = ""
    End Sub

    Private Sub cmdLogin_ServerClick(sender As Object, e As EventArgs) Handles cmdLogin.ServerClick

        If Email.Value = "" Then
            m.Alert(Me, "Digite seu e-mail", False, "")
            Exit Sub
        End If
        If Password.Value = "" Then
            m.Alert(Me, "Digite sua senha", False, "")
            Exit Sub
        End If

        'VERIFICA SE O COLABORADOR EXISTE
        If c.GetInfoColaborador("", "", Email.Value) = False Then
            m.Alert(Me, "Email INVÁLIDO, INATIVO ou NÃO CADASTRADO")
            Exit Sub
        End If

        If c.ColaboradorAdministrador = "Nao" Then
            m.Alert(Me, "você não tem permissão de admnistrador")
            Exit Sub
        End If

        If Email.Value <> c.ColaboradorEmail Then
            m.Alert(Me, "Email inválido", False, "")
            Exit Sub
        End If

        If Password.Value <> c.ColaboradorSenha Then
            m.Alert(Me, "Senha inválida", False, "")
            Exit Sub
        End If
        'Registra log no site
        Dim sql As String = ""
        sql = sql & "Insert Into tb_Log_Site (Loja_Sigla, Login_Mail, Login_Date, Login_Ip, Session_Id) Values ("
        sql = sql & "'" & l.Loja_Sigla & "', '" & c.ColaboradorEmail & "', '" & m.GetDateTimeToString & "', '"
        sql = sql & HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString & "', '" & Session.SessionID & "')"
        m.ExecuteSQL(sql)

        Session("NOME_LOGIN") = c.ColaboradorNome
        Session("EMAIL_LOGIN") = c.ColaboradorEmail
        Response.Redirect("Default.aspx")
    End Sub

    Private Sub cmdRecoveryPassword_ServerClick(sender As Object, e As EventArgs) Handles cmdRecoveryPassword.ServerClick
        If Email.Value = "" Then
            m.Alert(Me, "Digite seu e-mail", False, "")
            Exit Sub
        End If

        'VERIFICA SE O COLABORADOR EXISTE
        If c.GetInfoColaborador("", "", Email.Value) = False Then
            m.Alert(Me, "Email INVÁLIDO, INATIVO ou NÃO CADASTRADO")
            Exit Sub
        End If
        Dim msg As String = ""
        msg = msg & "<p>Informações de acesso - " & ConfigurationManager.AppSettings("App.Name") & " - " & l.Loja & "</p>"
        msg = msg & "<h3>Usuário: " & c.ColaboradorEmail & " " & " " & "</h3>"
        msg = msg & "<h3>Senha: " & c.ColaboradorSenha & " " & " " & "</h3>"
        m.SendMail(c.ColaboradorEmail, c.ColaboradorNome, ConfigurationManager.AppSettings("App.Name") & " - " & l.Loja & " - RECUPERAÇÃO DE SENHA", msg)
        m.Alert(Me, "Email com recuperação de senha enviado para " & c.ColaboradorEmail)
    End Sub

    Private Sub cmdHome_ServerClick(sender As Object, e As EventArgs) Handles cmdHome.ServerClick
        Response.Redirect("Default.aspx")
    End Sub
End Class