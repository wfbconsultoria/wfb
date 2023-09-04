Public Class Login
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Dim l As New cls_Login
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ''Exclui e cria variáveis de sessão vazias
        Session.RemoveAll()
        Session("EMAIL_LOGIN") = ""
        Session("NOME_LOGIN") = ""
        Session("PERFIL_ID_LOGIN") = ""
        Session("PERFIL_LOGIN") = ""
        Session("LOJA_SIGLA") = ""
        Session("LOJA") = ""
        Session("UNIVERSO_SIGLA") = ""
        Session("UNIVERSO") = ""
        Session("ADMINSTRATOR_LOGIN") = ""
        Session("DATE_LOGIN") = ""
        Session("SESSION_LOGIN") = ""
        Session("IP_LOGIN") = ""
        Session("BROWSER_LOGIN") = ""

        ''Verifica login

        If IsPostBack Then
            Select Case l.Login(txt_Email.Value, txt_Senha.Value)

                Case = 0
                    Response.Redirect("LoginMessage.aspx")

                Case = 1
                    Response.Redirect("Default.aspx")

                Case > 1
                    Response.Redirect("LoginMessage.aspx")
            End Select
            '    Dim sql As String = "Select * From VIEW_COLABORADORES Where EMAIL = '" & txt_email.Value & "' and SENHA = '" & txt_password.Value & "' and ATIVO = 1"
            '    Dim dtr As Data.SqlClient.SqlDataReader = m.ExecuteSelect(sql)
            '    If dtr.HasRows Then
            '        dtr.Read()
            '        'Atribui valores as variaves de sessão
            '        Session("LOJA_SIGLA") = dtr("LOJA_SIGLA").ToString
            '        Session("LOJA") = dtr("LOJA").ToString
            '        Session("UNIVERSO_SIGLA") = dtr("UNIVERSO_SIGLA").ToString
            '        Session("UNIVERSO") = dtr("UNIVERSO").ToString
            '        Session("EMAIL_LOGIN") = dtr("EMAIL").ToString
            '        Session("NOME_LOGIN") = dtr("NOME").ToString
            '        Session("PERFIL_ID_LOGIN") = dtr("PERFIL").ToString
            '        Session("PERFIL_LOGIN") = dtr("PERFIL").ToString
            '        Session("ADMINSTRATOR_LOGIN") = dtr("ADMINISTRADOR").ToString
            '        Session("DATE_LOGIN") = Now().ToString
            '        Session("SESSION_LOGIN") = Session.SessionID.ToString
            '        Session("IP_LOGIN") = Request.ServerVariables("REMOTE_ADDR").ToString
            '        Session("BROWSER_LOGIN") = Request.ServerVariables("HTTP_USER_AGENT").ToString
            '        'Atualiza tabeLa de usuarios
            '        sql = ""
            '        sql &= "Update TBL_USUARIOS Set "
            '        sql &= "LOGIN = '" & Session("DATE_LOGIN").ToString & "', "
            '        sql &= "IP = '" & Session("IP_LOGIN").ToString & "', "
            '        sql &= "SESSAO = '" & Session("SESSION_LOGIN") & "', "
            '        sql &= "BROWSER = '" & Session("BROWSER_LOGIN").ToString & "' "
            '        sql &= "Where EMAIL = '" & Session("EMAIL_LOGIN").ToString & "' and LOJA_SIGLA = '" & Session("LOJA_SIGLA").ToString & "'"
            '        m.ExecuteSQL(sql)
            '        'Registra LOG
            '        sql = ""
            '        sql &= "Insert Into TBL_LOG_SITE (LOJA_SIGLA, EMAIL, LOGIN, IP, SESSAO, BROWSER) Values ("
            '        sql &= "'" & Session("LOJA_SIGLA").ToString & "',"
            '        sql &= "'" & Session("EMAIL_LOGIN").ToString & "',"
            '        sql &= "'" & Session("DATE_LOGIN").ToString & "',"
            '        sql &= "'" & Session("IP_LOGIN").ToString & "',"
            '        sql &= "'" & Session("SESSION_LOGIN").ToString & "',"
            '        sql &= "'" & Session("BROWSER_LOGIN") & "')"
            '        m.ExecuteSQL(sql)

            '        Response.Redirect("Default.aspx")
            'End If
            '    m.Alert(Me, "E-Mail ou senha inválido")
        End If
    End Sub

End Class