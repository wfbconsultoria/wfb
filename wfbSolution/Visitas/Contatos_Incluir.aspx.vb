
Partial Class Contatos_Incluir
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Contatos Incluir"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
            If Len(Request.QueryString("CNPJ")) > 0 Then Session("CNPJ") = Request.QueryString("CNPJ")
        End If

        'PERMITE SOMENTE A DIGITACAO DE NÚMEROS NOS CAMPOS CNPJ E CEP
        txt_TELEFONE.Attributes.Add("OnKeyPress", "Digitar_Numeros(this);Mascara_Entrada(this,'00 0000 0000');")
        txt_CELULAR.Attributes.Add("OnKeyPress", "Digitar_Numeros(this);Mascara_Entrada(this,'00 0000 0000');")
    End Sub
    Protected Sub cmd_Gravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Gravar.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim sql As String
        Dim Mensagem As String

        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()

        'CADASTRA CONTATO
        sql = ""
        sql = sql & "Insert Into TBL_CONTATOS ("
        sql = sql & "[CNPJ_ESTABELECIMENTO] "
        sql = sql & ",[ID_AREA] "
        sql = sql & ",[ID_CARGO] "
        sql = sql & ",[COD_TIPO] "
        sql = sql & ",[NOME] "
        'sql = sql & ",[ENDERECO] "
        'sql = sql & ",[BAIRRO] "
        'sql = sql & ",[CEP] "
        'sql = sql & ",[ID_MUNICIPIO] "
        sql = sql & ",[TELEFONE] "
        sql = sql & ",[CELULAR] "
        sql = sql & ",[EMAIL] "
        sql = sql & ",[MES_ANIVERSARIO] "
        sql = sql & ",[DIA_ANIVERSARIO] "
        sql = sql & ",[INCLUSAO_DATA]"
        sql = sql & ",[INCLUSAO_EMAIL])"
        sql = sql & " Values ("
        sql = sql & "'" & Session("CNPJ") & "', "
        sql = sql & "'" & cmb_ID_AREA.Text & "', "
        sql = sql & "'" & cmb_ID_CARGO.Text & "', "
        sql = sql & "'" & 0 & "', "
        sql = sql & "'" & M.ConverteTexto(txt_NOME.Text) & "', "
        'sql = sql & "'" & M.ConverteTexto(txt_Endereco.Text) & "', "
        'sql = sql & "'" & M.ConverteTexto(txt_Bairro.Text) & "', "
        'sql = sql & "'" & txt_CEP.Text & "', "
        'sql = sql & "'" & cmb_COD_MUNICIPIO.Text & "', "
        sql = sql & "'" & txt_TELEFONE.Text & "', "
        sql = sql & "'" & txt_CELULAR.Text & "', "
        sql = sql & "'" & txt_EMAIL.Text & "', "
        sql = sql & "'" & cmb_MES_ANIVERSARIO.Text & "', "
        sql = sql & "'" & cmb_DIA_ANIVERSARIO.Text & "', "
        sql = sql & "'" & M.RecuperaData & "', "
        sql = sql & "'" & Session("EMAIL_LOGIN") & "') "
        'Response.Write(sql)
        'Response.End()
        If M.ExecutarSQL(sql) = True Then
            Alert("Contato incluido com sucesso no estabelecimento", True, "Estabelecimentos_Ficha2.aspx?CNPJ=" & Session("CNPJ"))
        Else
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO INCLUSAO CONTATO", "NOME: " & txt_NOME.Text)
            Mensagem = "ERRO  - INCLUSÃO DE CONTATO" & Chr(10)
            Mensagem = Mensagem & "NOME: " & txt_NOME.Text & Chr(10) & " CNPJ DO ESTABELECIMENTO: " & Session("CNPJ")
            Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN")
            M.EnviarEmail("ERRO - INCLUSÃO DE CONTATO", Mensagem, True, False, "", "")
            Alert("Erro ao inserir contato, um e-mail foi mandado ao administrador!", True, "Estabelecimentos_Ficha.aspx?CNPJ=" & Session("CNPJ"))
        End If
    End Sub
    Protected Sub Alert(ByVal Texto_Mensagem As String, ByVal Redirecionar As Boolean, ByVal Pagina As String)
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
    End Sub

End Class
