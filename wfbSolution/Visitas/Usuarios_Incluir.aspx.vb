
Partial Class Usuarios
    Inherits System.Web.UI.Page
    Public M As New clsMaster
    Dim Pagina As String = "Usuarios Inclusao"
    Dim Senha As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Verifica permisão de acesso da página
        If Session("COD_PERFIL_LOGIN") <> 0 Then
            Alert("Somente administradores têm acesso a esta funcionalidade", True, "Default.aspx")
        End If

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

        'LIMPA AS VARIAVEIS UTILIZADAS PELA PAGINA
        Session("EMAIL_USUARIO") = ""
        Session("NOME_USUARIO") = ""
        txt_ANO_NASCIMENTO.Attributes.Add("OnKeyPress", "Digitar_Numeros(this);")
        txt_DIA_NASCIMENTO.Attributes.Add("OnKeyPress", "Digitar_Numeros(this);")
        'Acesso SIstema
        If Session("SISTEMA") = True Then
            opt_Sistema.Visible = True
            opt_Upload.Visible = True
        End If
    End Sub

    Protected Sub Gravar()

        Dim CN As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String
        Dim Mensagem As String

        'verifica se este usuário não está cadastrado
        CN.ConnectionString = M.cnnStr
        CN.Open()
        cmd.Connection = CN
        sql = ""
        sql = "Select * From VIEW_USUARIOS Where EMAIL = '" & txt_EMAIL.Text & "'"
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            Session("EMAIL_USUARIO") = dtr("EMAIL")
            Alert("Este EMAIL já está cadastrado para " & dtr("NOME"), False, "")
            Exit Sub
        End If
        dtr.Close()
        CN.Close()

        'CONSISTE OS REGISTROS ANTES DE GRAVAR
        'VERIFICA SE O PERFIL FOI SELECIONADO
        If cmb_PERFIL.Text = "-1" Then
            Alert("Selecione o PERFIL", False, "")
            Exit Sub
        End If
        
        Senha = M.GerarSenha
        'INCLUI O REGISTRO
        sql = ""
        sql = sql & " Insert Into TBL_USUARIOS "
        sql = sql & " (EMAIL, NOME,  ATIVO, BLOQUEADO, SISTEMA, DOWNLOAD, UPLOAD, UPLOAD_MAPAS, LOGIN, SENHA, COD_PERFIL, TELEFONE, GERENTE, COORDENADOR, DIRETOR, "
        sql = sql & " ANO_NASCIMENTO, MES_NASCIMENTO, DIA_NASCIMENTO, TERRITORIO, INCLUSAO_EMAIL, INCLUSAO_DATA) "
        sql = sql & " Values ("
        sql = sql & "'" & LCase(txt_EMAIL.Text) & "', "
        sql = sql & "'" & M.ConverteTexto(txt_NOME.Text) & "', "
        sql = sql & "'" & opt_Ativo.Checked & "', "
        sql = sql & "'" & opt_Bloqueado.Checked & "', "
        sql = sql & "'" & opt_Sistema.Checked & "', "
        sql = sql & "'" & opt_Download.Checked & "', "
        sql = sql & "'" & opt_Upload.Checked & "', "
        sql = sql & "'" & opt_Upload_Mapas.Checked & "', "
        sql = sql & "'" & opt_Login.Checked & "', "
        sql = sql & "'" & Senha & "', "
        sql = sql & cmb_PERFIL.Text & ", "
        sql = sql & "'" & M.ConverteTexto(txt_TELEFONE.Text) & "', "
        sql = sql & "'" & LCase(cmb_EMAIL_GERENTE.Text) & "', "
        sql = sql & "'" & LCase(cmb_EMAIL_COORDENADOR.Text) & "', "
        sql = sql & "'" & LCase(cmb_EMAIL_DIRETOR.Text) & "', "
        sql = sql & M.Converte_Valor(txt_ANO_NASCIMENTO.Text) & ", "
        sql = sql & M.Converte_Valor(cmb_MES_NASCIMENTO.Text) & ", "
        sql = sql & M.Converte_Valor(txt_DIA_NASCIMENTO.Text) & ", "
        sql = sql & "'" & M.ConverteTexto(txt_Territorio.Text) & "', "
        sql = sql & "'" & Session("EMAIL_LOGIN") & "', "
        sql = sql & M.RecuperaData & ")"

        If M.ExecutarSQL(sql) = True Then
            Session("EMAIL_USUARIO") = txt_EMAIL.Text
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "INCLUIU USUARIO", txt_EMAIL.Text)
            Mensagem = "INCLUSAO DE USUARIO - " & Now() & Chr(10)
            Mensagem = Mensagem & "Seu acesso foi incluido e liberado no " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString & Chr(10) & Chr(10)
            Mensagem = Mensagem & "Verifique seus dados abaixo, memorize sua senha e não encaminhe este e-mail para ninguém" & Chr(10)
            Mensagem = Mensagem & "Sua senha e acesso são pessoais e intransferiveis, todos os acessos e operações efetuadas no sistema serão registrados em arquivo de log" & Chr(10) & Chr(10)
            Mensagem = Mensagem & "Após o primeiro acesso você deverá trocar sua senha na opção TROCAR SENHA  no menu OPERAÇÕES" & Chr(10) & Chr(10)
            Mensagem = Mensagem & "E-mail acesso: " & txt_EMAIL.Text & Chr(10)
            Mensagem = Mensagem & "Senha: " & Senha & Chr(10)
            Mensagem = Mensagem & "Nome: " & M.ConverteTexto(txt_NOME.Text) & Chr(10)

            M.EnviarEmail("INCLUSAO DE USUARIO", Mensagem, False, False, txt_EMAIL.Text, "")
            Alert("Usuário incluido com sucesso", True, "Usuarios_Localizacao.aspx")
            txt_Acao.Text = "Inclusão ok"
        Else
            Mensagem = "ERRO - INCLUSAO DE USUARIO - " & Now() & Chr(10)
            Mensagem = Mensagem & "E-mail inclusão: " & txt_EMAIL.Text & Chr(10)
            Mensagem = Mensagem & "Nome: " & M.ConverteTexto(txt_NOME.Text) & Chr(10)
            Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN") & Chr(10)
            Mensagem = Mensagem & "SQL:" & sql & Chr(10)
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO", txt_EMAIL.Text)
            M.EnviarEmail("ERRO - INCLUSAO DE USUARIO", Mensagem, True, False, "", "")
            Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
            txt_Acao.Text = "Não foi possível efetuar a inclusão"
        End If
    End Sub
    Protected Function Alert(ByVal Texto_Mensagem As String, ByVal Redirecionar As Boolean, ByVal Pagina As String) As Boolean
        Dim jscript As String
        'caixa de mensagem
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
    Protected Sub cmd_Gravar_Click(sender As Object, e As EventArgs) Handles cmd_Gravar.Click
        Gravar()
    End Sub
End Class
