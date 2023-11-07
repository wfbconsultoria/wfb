
Partial Class Login
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Login.aspx"
    Dim CN As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String
    Dim Mensagem As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ''REDIRECIONAMENTO HTTPS WWW.BIHOSPITALAR.COM.BR
        'LIMPA TODAS AS CONFIGURACOES DO SISTEMA
        Session("HORA_LOGIN") = ""
        Session("HOJE") = ""
        Session("ANO_ATUAL") = ""
        Session("MES_ATUAL") = ""
        Session("IP_LOGIN") = Request.ServerVariables("REMOTE_ADDR").ToString
        Session("SESSAO_LOGIN") = ""
        Session("EMAIL_LOGIN") = ""
        Session("USUARIO_LOGIN") = ""
        Session("PERFIL_LOGIN") = ""
        Session("COD_PERFIL_LOGIN") = ""
        Session("EMAIL_COORDENADOR") = ""
        Session("EMAIL_GERENTE") = ""
        Session("EMAIL_DIRETOR") = ""
        Session("SQL_REPRESENTANTES") = ""
        Session("DOWNLOAD") = ""
        Session("UPLOAD") = ""
        Session("UPLOAD_MAPAS") = ""

        txt_EMAIL.Enabled = True
        txt_SENHA.Enabled = True
        cmd_Login.Visible = True

    End Sub

    Protected Sub cmd_Login_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Login.Click
       
        Session("EMAIL_LOGIN") = txt_EMAIL.Text
        'ABRE CONEXAO
        CN.ConnectionString = M.cnnStr
        CN.Open()
        cmd.Connection = CN
        'VERIFICA SE O USUARIO E SENHA ESTÃO CORRETOS
        sql = ""
        sql = "Select * From VIEW_USUARIOS Where EMAIL = '" & Replace(txt_EMAIL.Text, "'", "") & "' And SENHA = '" & Replace(txt_SENHA.Text, "'", "") & "' And LOGIN = 'True' "

        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            'DEFINE AS CONFIGURACOES GERAIS DO SISTEMA
            Session("HORA_LOGIN") = M.RecuperaData.ToString
            Session("HOJE") = Format(Year(Now()), "0000") & Format(Month(Now()), "00") & Format(Day(Now()), "00")
            Session("ANO_ATUAL") = Format(Year(Now()), "0000")
            Session("MES_ATUAL") = Month(Now())
            Session("IP_LOGIN") = Request.ServerVariables("REMOTE_ADDR").ToString
            Session("SESSAO_LOGIN") = Session.SessionID.ToString
            Session("SESSAO_LOGIN") = Session("SESSAO_LOGIN") & Left(Session("HORA_LOGIN"), 4)    'ANO
            Session("SESSAO_LOGIN") = Session("SESSAO_LOGIN") & Mid(Session("HORA_LOGIN"), 5, 2)  'MES
            Session("SESSAO_LOGIN") = Session("SESSAO_LOGIN") & Mid(Session("HORA_LOGIN"), 7, 2)  'DIA
            Session("SESSAO_LOGIN") = Session("SESSAO_LOGIN") & Mid(Session("HORA_LOGIN"), 9, 2)  'HORA
            Session("SESSAO_LOGIN") = Session("SESSAO_LOGIN") & Mid(Session("HORA_LOGIN"), 11, 2) 'MINUTO
            Session("SESSAO_LOGIN") = Session("SESSAO_LOGIN") & Mid(Session("HORA_LOGIN"), 13, 2) 'SEGUNDO
            Session("PERFIL_LOGIN") = dtr("PERFIL").ToString
            Session("COD_PERFIL_LOGIN") = dtr("COD_PERFIL").ToString
            Session("USUARIO_LOGIN") = dtr("NOME").ToString
            Session("EMAIL_LOGIN") = dtr("EMAIL").ToString
            Session("EMAIL_COORDENADOR") = dtr("COORDENADOR").ToString
            Session("EMAIL_GERENTE") = dtr("GERENTE").ToString
            Session("EMAIL_DIRETOR") = dtr("DIRETOR").ToString
            Session("SISTEMA") = dtr("SISTEMA")
            Session("DOWNLOAD") = dtr("DOWNLOAD")
            Session("UPLOAD") = dtr("UPLOAD")
            Session("UPLOAD_MAPAS") = dtr("UPLOAD_MAPAS")

            'DEFINE ORIGEM DE DADOS DA LISTA DE REPRESENTANTES
            Session("SQL_REPRESENTANTES") = " Select * From TBL_USUARIOS Where (COD_PERFIL = 4 And ATIVO = 'True' And BLOQUEADO = 'False') Or COD_PERFIL = 100 Order By NOME"
            'Administrador
            If Session("COD_PERFIL_LOGIN") = 0 Then Session("SQL_REPRESENTANTES") = " Select * From TBL_USUARIOS Where (COD_PERFIL = 4 And ATIVO = 'True' And BLOQUEADO = 'False') Or COD_PERFIL = 100 Order By NOME"
            'Diretor
            If Session("COD_PERFIL_LOGIN") = 1 Then Session("SQL_REPRESENTANTES") = " Select * From TBL_USUARIOS Where (COD_PERFIL = 4 And ATIVO = 'True' And BLOQUEADO = 'False' And DIRETOR = '" & Session("EMAIL_LOGIN") & "') Or COD_PERFIL = 100 Order By NOME"
            'Gerente
            If Session("COD_PERFIL_LOGIN") = 2 Then Session("SQL_REPRESENTANTES") = " Select * From TBL_USUARIOS Where (COD_PERFIL = 4 And ATIVO = 'True' And BLOQUEADO = 'False' And GERENTE = '" & Session("EMAIL_LOGIN") & "') Or COD_PERFIL = 100 Order By NOME"
            'Coordenador
            If Session("COD_PERFIL_LOGIN") = 3 Then Session("SQL_REPRESENTANTES") = " Select * From TBL_USUARIOS Where (COD_PERFIL = 4 And ATIVO = 'True' And BLOQUEADO = 'False' And COORDENADOR = '" & Session("EMAIL_LOGIN") & "') Or COD_PERFIL = 100 Order By NOME"
            'Representante
            If Session("COD_PERFIL_LOGIN") = 4 Then Session("SQL_REPRESENTANTES") = " Select * From TBL_USUARIOS Where COD_PERFIL = 4 And ATIVO = 'True' And BLOQUEADO = 'False' And EMAIL = '" & Session("EMAIL_LOGIN") & "'"
            'Assistente
            If Session("COD_PERFIL_LOGIN") = 5 Then Session("SQL_REPRESENTANTES") = "Select * From  TBL_USUARIOS Where COD_PERFIL = 100 "
            'Visitante
            If Session("COD_PERFIL_LOGIN") = 5 Then Session("SQL_REPRESENTANTES") = "Select * From  TBL_USUARIOS Where COD_PERFIL = 100 "
            'Distribuidor
            If Session("COD_PERFIL_LOGIN") = 5 Then Session("SQL_REPRESENTANTES") = "Select * From  TBL_USUARIOS Where COD_PERFIL = 100 "
            '@Selecione
            If Session("COD_PERFIL_LOGIN") = 5 Then Session("SQL_REPRESENTANTES") = "Select * From  TBL_USUARIOS Where COD_PERFIL = 100 "

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
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "LOGIN", "Acessou o sistema com sucesso")
            Response.Redirect("Default.aspx")

        Else
            'envia mensagem apontado erro no login
            Mensagem = "ERRO LOGIN " & Chr(10) & Chr(10)
            Mensagem = Mensagem & "Alguém está tentando acessar o " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString & " com seu usuário." & Chr(10)
            Mensagem = Mensagem & "Com a senha " & txt_SENHA.Text & Chr(10)
            Mensagem = Mensagem & "Com o E-Mail: " & txt_EMAIL.Text & Chr(10)
            Mensagem = Mensagem & "IP: " & Session("IP_LOGIN") & Chr(10)
            Mensagem = Mensagem & "DATA/HORA: " & Now() & Chr(10)

            M.EnviarEmail("ERRO LOGIN", Mensagem, False, False, ConfigurationManager.AppSettings("EMAIL_SUPORTE").ToString, "")
            Alert("E-mail ou senha incorretos!", True, "Login.aspx")
        End If
        dtr.Close()
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

End Class
