
Partial Class Site_Public
    Inherits System.Web.UI.MasterPage
    Dim M As New clsMaster
    Dim Pagina As String = "Login.aspx"
    Dim Titulo As String = "Login - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim CN As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String
    Dim Mensagem As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'QUANDO PUBLICAR EM AMBIENTE DE PRODUÇÃO TIRARO COMENTÁRIO DAS LINHAS ABAIXO
        ' If Request.Url.GetLeftPart(UriPartial.Authority) <> "https://www.bihospitalar.com.br" Then
        'Response.Redirect("https://www.bihospitalar.com.br" & VirtualPathUtility.ToAbsolute("~"))
        'End If
        'If Not Request.IsSecureConnection Then
        '    'redirect visitor to SSL connection
        'Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"))
        'End If

        Page.Title = Titulo
        Session("IP_LOGIN") = Request.ServerVariables("REMOTE_ADDR").ToString
        Session("SESSAO_LOGIN") = Session.SessionID.ToString
        Session("HOJE") = Format(Year(Now()), "0000") & Format(Month(Now()), "00") & Format(Day(Now()), "00")

        'LIMPA TODAS AS CONFIGURACOES DO SISTEMA

        Session("HORA_LOGIN") = ""
        Session("EMAIL_LOGIN") = ""
        Session("USUARIO_LOGIN") = ""
        Session("PERFIL_LOGIN") = ""
        Session("COD_PERFIL_LOGIN") = ""
        Session("EMAIL_COORDENADOR") = ""
        Session("EMAIL_GERENTE") = ""
        Session("EMAIL_DIRETOR") = ""
        Session("SQL_REPRESENTANTES") = ""
        Session("SISTEMA") = ""
        Session("ADMINISTRADOR_SETORIZACAO") = ""
        Session("ADMINISTRADOR_COTAS") = ""
        Session("DOWNLOAD") = ""
        Session("UPLOAD") = ""
        Session("UPLOAD_MAPAS") = ""

    End Sub

    Protected Sub cmd_Login_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Login.Click

        Session("EMAIL_LOGIN") = cmb_Email.SelectedValue.ToString
        'ABRE CONEXAO
        CN.ConnectionString = M.cnnStr
        CN.Open()
        cmd.Connection = CN
        'VERIFICA SE O USUARIO E SENHA ESTÃO CORRETOS
        If cmb_Email.SelectedValue.ToString = "" And cmb_Email.Text = "#" Then
            Alert("Digite seu e-mail ou selecione seu nome no combo!", False, "")
        Else
            If cmb_Email.SelectedValue.ToString <> "" Then
                sql = ""
                sql = "Select * From VIEW_USUARIOS Where EMAIL = '" & Replace(cmb_Email.SelectedValue.ToString, "'", "") & "' And SENHA = '" & Replace(txt_SENHA.Text, "'", "") & "' And LOGIN = 'True' "
            ElseIf cmb_Email.Text <> "#" Then
                sql = ""
                sql = "Select * From VIEW_USUARIOS Where EMAIL = '" & Replace(cmb_Email.Text, "'", "") & "' And SENHA = '" & Replace(txt_SENHA.Text, "'", "") & "' And LOGIN = 'True' "
            End If
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader
            If dtr.HasRows Then
                dtr.Read()
                'DEFINE AS CONFIGURACOES GERAIS DO SISTEMA
                Session("ANO_ATUAL") = Year(Now())
                Session("ANO_PASSADO") = Year(Now())
                Session("ANO_RETRASADO") = Year(Now())
                Session("HORA_LOGIN") = M.RecuperaData.ToString
                Session("PERFIL_LOGIN") = dtr("PERFIL").ToString
                Session("COD_PERFIL_LOGIN") = dtr("COD_PERFIL").ToString
                Session("USUARIO_LOGIN") = dtr("NOME").ToString
                Session("EMAIL_LOGIN") = dtr("EMAIL").ToString
                Session("EMAIL_COORDENADOR") = dtr("COORDENADOR").ToString
                Session("EMAIL_GERENTE") = dtr("GERENTE").ToString
                Session("EMAIL_DIRETOR") = dtr("DIRETOR").ToString
                Session("SISTEMA") = dtr("SISTEMA")
                Session("ADMINISTRADOR_SETORIZACAO") = dtr("ADMINISTRADOR_SETORIZACAO")
                Session("ADMINISTRADOR_COTAS") = dtr("ADMINISTRADOR_COTAS")
                Session("DOWNLOAD") = dtr("DOWNLOAD")
                Session("UPLOAD") = dtr("UPLOAD")
                Session("UPLOAD_MAPAS") = dtr("UPLOAD_MAPAS")
                'GRAVA LOG NA TABELA TBL_LOG_SITE
                sql = ""
                sql = sql & " Insert Into TBL_LOG_SITE "
                sql = sql & " (SESSION_ID,IP,EMAIL,DATA,ANO,MES,DIA,HORA,MINUTO,SEGUNDO,VERSAO_SISTEMA) "
                sql = sql & " Values ("
                sql = sql & "'" & Session("SESSAO_LOGIN").ToString & "', "
                sql = sql & "'" & Session("IP_LOGIN").ToString & "', "
                sql = sql & "'" & Session("EMAIL_LOGIN").ToString & "', "
                sql = sql & Session("HORA_LOGIN") & ", "
                sql = sql & Left(Session("HORA_LOGIN"), 4) & ", " 'ANO
                sql = sql & Mid(Session("HORA_LOGIN"), 5, 2) & ", " 'MES
                sql = sql & Mid(Session("HORA_LOGIN"), 7, 2) & ", " 'DIA
                sql = sql & Mid(Session("HORA_LOGIN"), 9, 2) & ", " 'HORA
                sql = sql & Mid(Session("HORA_LOGIN"), 11, 2) & ", " 'MINUTO
                sql = sql & Mid(Session("HORA_LOGIN"), 13, 2) & ", " 'SEGUNDO
                sql = sql & "'" & ConfigurationManager.AppSettings("VERSAO_SISTEMA").ToString & "')"
                M.ExecutarSQL(sql)

                'GRAVA LOG DE ACESSO AO SISTEMA
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "LOGOU COM SUCESSO", "")
                Response.Redirect("Default.aspx")

            Else
                'envia mensagem apontado erro no login
                Mensagem = "ERRO LOGIN " & Chr(10) & Chr(10)
                Mensagem = Mensagem & "Alguém está tentando acessar o " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString & "." & Chr(10)
                Mensagem = Mensagem & "Com a senha " & txt_SENHA.Text & Chr(10)
                Mensagem = Mensagem & "Com o E-Mail: " & cmb_Email.SelectedValue.ToString & Chr(10)
                Mensagem = Mensagem & "IP: " & Session("IP_LOGIN") & Chr(10)
                Mensagem = Mensagem & "DATA/HORA: " & Now() & Chr(10)

                M.EnviarEmail("ERRO LOGIN", Mensagem, False, False, ConfigurationManager.AppSettings("EMAIL_SUPORTE").ToString, "")
                Alert("E-mail ou senha incorretos!", True, "Login.aspx")
            End If
            dtr.Close()

        End If

        CN.Close()
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

    Private Sub cmd_Forgot_Click(sender As Object, e As EventArgs) Handles cmd_Forgot.Click
        'Declaração de Variavél
        Dim senha As String = ""
        'VERIFICA SE O EMAIL INFORMADO EXISTE E NÃO ESTÁ BLOQUEADO
        sql = ""
        sql = "Select * From TBL_USUARIOS Where EMAIL = '" & cmb_Email.SelectedValue.ToString & "' And ATIVO = 'True' And BLOQUEADO  = 'False' "
        CN.ConnectionString = M.cnnStr
        CN.Open()
        cmd.Connection = CN
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            'Atribui valor a variavél
            senha = dtr("SENHA").ToString

            M.LogPagina(Session("SESSAO_LOGIN").ToString, Session("IP_LOGIN").ToString, Session("EMAIL_LOGIN").ToString, Pagina, "ALTEROU SENHA ", "email=" & cmb_Email.SelectedValue.ToString & "  senha=" & senha)
            Mensagem = "RECUPERA DE SENHA " & Chr(10) & Chr(10)
            Mensagem = Mensagem & "Sua senha de acesso ao " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString & " foi recuperada com sucesso." & Chr(10)
            Mensagem = Mensagem & "E-MAIL: " & cmb_Email.SelectedValue.ToString & Chr(10)
            Mensagem = Mensagem & "SENHA: " & Senha & Chr(10)
            Mensagem = Mensagem & "DATA/HORA: " & Now() & Chr(10)
            M.EnviarEmail("RECUPERAÇÃO DE SENHA", Mensagem, True, True, cmb_Email.SelectedValue.ToString, "")
            Alert("RECUPERAÇÃO REALIZADA COM SUCESSO, ACESSE SEU EMAIL PARA OBTER SUA SENHA", True, "Login.aspx")
        Else
            Alert("O EMAIL INFORMADO NÃO EXISTE OU ESTÁ BLOQUEADO PARA ACESSO", True, "Login.aspx")
        End If
    End Sub
End Class

