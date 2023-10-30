
Partial Class Oportunidades_Manutencao

    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Oportunidades_Manutencao.aspx"
    Dim Pagina_Origem As String
    Dim sql As String
    Dim Mensagem As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("PAGINA_ORIGEM") <> "" Then Pagina_Origem = Request.QueryString("PAGINA_ORIGEM").ToString & ".aspx"

        If Request.QueryString("ID_OPORTUNIDADE") = "" Then
            Alert("Selecione uma oportunidade antes de efetuar manutenção!", True, Pagina_Origem)
        Else
            Session("ID_OPORTUNIDADE") = Request.QueryString("ID_OPORTUNIDADE").ToString
        End If

        Session("ANO_OPORTUNIDADE") = ""
        If Request.QueryString("ANO") < Session("ANO_ATUAL") Then
            cmd_Gravar.Visible = False
            cmb_Ano.Enabled = False
            cmb_Mes_Fechamento.Enabled = False
            cmb_Situacao.Enabled = False
            cmb_Fase.Enabled = False
        End If
        If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Default.aspx")
        If Session("ID_OPORTUNIDADE").ToString = "" Then Response.Redirect(Pagina_Origem)

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

        If txt_Acao.Text = "Gravar" Then Gravar()
        'PERMITE SOMENTE A DIGITACAO DE NÚMEROS NA QUANTIDADE
        txt_Qtd_Prevista.Attributes.Add("OnKeyPress", "Digitar_Numeros(this);Mascara_Entrada(this,'00000000');")
        txt_Qtd_Prevista.Attributes.Add("OnKeyPress", "Digitar_Numeros(this);")
        'definie acao de gravar
        cmd_Gravar.Attributes.Add("onclick", "txt_Acao.value = 'Gravar';")
        Localizar()
    End Sub

    Protected Sub Localizar()
        Dim CN As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String
        'ABRE CONEXAO
        CN.ConnectionString = M.cnnStr
        CN.Open()
        cmd.Connection = CN
        cmb_Cod_Linha_Produto.Enabled = True
        'RECUPERA REGISTRO
        sql = ""
        sql = "Select * From TBL_OPORTUNIDADES Where ID_OPORTUNIDADE = " & Session("ID_OPORTUNIDADE")
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("COD_LINHA_PRODUTO")) Then cmb_Cod_Linha_Produto.Text = dtr("COD_LINHA_PRODUTO")
            If Not IsDBNull(dtr("ID_FASE_ATUAL")) Then cmb_Fase.Text = dtr("ID_FASE_ATUAL")
            If Not IsDBNull(dtr("DESCRICAO")) Then txt_Descricao.Text = dtr("DESCRICAO")
            If Not IsDBNull(dtr("ID_AREA")) Then cmb_Area.Text = dtr("ID_AREA")
            If Not IsDBNull(dtr("AREA_LOCAL")) Then txt_Localizacao.Text = dtr("AREA_LOCAL")
            If Not IsDBNull(dtr("FASE_ATUAL_QTD_PREVISTA")) Then txt_Qtd_Prevista.Text = dtr("FASE_ATUAL_QTD_PREVISTA")
            If Not IsDBNull(dtr("ID_INFLUENCIADOR_ECONOMICO")) Then cmb_Influenciador_Economico.Text = dtr("ID_INFLUENCIADOR_ECONOMICO")
            If Not IsDBNull(dtr("ID_INFLUENCIADOR_TECNICO")) Then cmb_Influenciador_Tecnico.Text = dtr("ID_INFLUENCIADOR_TECNICO")
            If Not IsDBNull(dtr("ID_USUARIO")) Then cmb_Usuario.Text = dtr("ID_USUARIO")
            If Not IsDBNull(dtr("ID_TREINADOR")) Then cmb_Treinador.Text = dtr("ID_TREINADOR")
            If Not IsDBNull(dtr("ANO_OPORTUNIDADE")) Then cmb_Ano.Text = dtr("ANO_OPORTUNIDADE")
            If Not IsDBNull(dtr("MES_FECHAMENTO_PREVISTO")) Then cmb_Mes_Fechamento.Text = dtr("MES_FECHAMENTO_PREVISTO")
            If Not IsDBNull(dtr("ID_SITUACAO_OPORTUNIDADE")) Then cmb_Situacao.Text = dtr("ID_SITUACAO_OPORTUNIDADE")
        End If
        dtr.Close()
        CN.Close()
        cmb_Cod_Linha_Produto.Enabled = False
    End Sub

    Protected Sub Gravar()
        sql = ""
        sql = sql & " Update TBL_OPORTUNIDADES Set "
        sql = sql & " ANO_OPORTUNIDADE = " & cmb_Ano.Text & " , "
        sql = sql & " MES_FECHAMENTO_PREVISTO = " & cmb_Mes_Fechamento.Text & " , "
        sql = sql & " ID_AREA = " & cmb_Area.Text & " , "
        sql = sql & " DESCRICAO = '" & M.ConverteTexto(txt_Descricao.Text) & "' , "
        sql = sql & " ID_FASE_ATUAL = " & cmb_Fase.Text & " , "
        sql = sql & " ID_SITUACAO_OPORTUNIDADE = " & cmb_Situacao.Text & ", "
        sql = sql & " FASE_ATUAL_QTD_PREVISTA = " & txt_Qtd_Prevista.Text & " , "
        sql = sql & " ID_INFLUENCIADOR_ECONOMICO = '" & cmb_Influenciador_Economico.Text & "' , "
        sql = sql & " ID_INFLUENCIADOR_TECNICO = '" & cmb_Influenciador_Tecnico.Text & "' , "
        sql = sql & " ID_USUARIO = '" & cmb_Usuario.Text & "' , "
        sql = sql & " ID_TREINADOR = '" & cmb_Treinador.Text & "' , "
        sql = sql & " ALTERACAO_EMAIL = '" & Session("EMAIL_LOGIN") & "', "
        sql = sql & " ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " WHERE ID_OPORTUNIDADE = " & Session("ID_OPORTUNIDADE").ToString

        If M.ExecutarSQL(sql) = True Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ATUALIZOU OPORTUNIDADE ID: " & Session("ID_OPORTUNIDADE"), Session("ID_OPORTUNIDADE"))
            Alert("OPORTUNIDADE ATUALIZADA COM SUCESSO", False, "")
        Else
            Mensagem = "ERRO - ATUALIZAÇÃO DE OPORTUNIDADE - " & Now() & Chr(10)
            Mensagem = Mensagem & "CNPJ: " & Session("CNPJ") & Chr(10)
            Mensagem = Mensagem & "ID OPORTUNIDADE: " & Session("ID_OPORTUNIDADE") & Chr(10)
            Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN")
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO AO ATUALIZAR OPORTUNIDADE ID: " & Session("ID_OPORTUNIDADE"), Session("ID_OPORTUNIDADE"))
            M.EnviarEmail("ERRO - ATUALIZAÇÃO DE OPORTUNIDADE", Mensagem, True, False, "", "")
            Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
        End If

    End Sub
    Protected Sub Navegar(ByVal Pagina As String)
        Dim jscript As String
        jscript = ""
        jscript += "<script language='JavaScript'>"
        jscript += ";; document.location.href='" & Pagina & "'"
        jscript += "</script>"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Navegar", jscript)
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

End Class

