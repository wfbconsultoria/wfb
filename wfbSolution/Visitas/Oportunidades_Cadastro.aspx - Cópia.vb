
Partial Class Oportunidades_Cadastro
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Oportunidades_Cadastro.aspx"
    Dim sql As String
    Dim Mensagem As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Default.aspx")
        If Session("CNPJ").ToString = "" Then Response.Redirect("Estabelecimentos_Localizar.aspx")
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

        'PERMITE SOMENTE A DIGITACAO DE NÚMEROS NA QUANTIDADE
        txt_Qtd_Prevista.Attributes.Add("OnKeyPress", "Digitar_Numeros(this);Mascara_Entrada(this,'00000000');")
        'PERMITE SOMENTE A DIGITACAO DE NÚMEROS NO CEP
        txt_Qtd_Prevista.Attributes.Add("OnKeyPress", "Digitar_Numeros(this);")

    End Sub

    Protected Sub Navegar(ByVal Pagina As String)
        Dim jscript As String
        jscript = ""
        jscript += "<script language='JavaScript'>"
        jscript += ";; document.location.href='" & Pagina & "'"
        jscript += "</script>"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Navegar", jscript)
    End Sub

    Protected Sub cmd_Gravar_Click(sender As Object, e As System.EventArgs) Handles cmd_Gravar.Click

        If cmb_Fase.Text = 1 Then txt_Qtd_Prevista.Text = 0
        sql = ""
        sql = sql & " Insert Into TBL_OPORTUNIDADES (ANO_OPORTUNIDADE, MES_FECHAMENTO_PREVISTO, "
        sql = sql & " CNPJ, COD_LINHA_PRODUTO, ID_AREA, AREA_LOCAL, DESCRICAO, "
        sql = sql & " ID_FASE_ATUAL, FASE_ATUAL_QTD_PREVISTA, ID_INFLUENCIADOR_ECONOMICO , ID_INFLUENCIADOR_TECNICO , ID_USUARIO , ID_TREINADOR, ID_SITUACAO_OPORTUNIDADE, "
        sql = sql & " INCLUSAO_DATA, INCLUSAO_EMAIL )"
        sql = sql & " Values ( "
        sql = sql & Val(Year(Now)) & ", " & cmb_Mes_Fechamento.Text & ", " 'ANO E MES
        sql = sql & Session("CNPJ") & ", " & cmb_Cod_Linha_Produto.Text & ", " 'COD LINHA PRODUTO
        sql = sql & cmb_Area.Text & ", " ' ID_AREA
        sql = sql & "'" & M.ConverteTexto(txt_Localizacao.Text) & "', " 'AREA_LOCAL
        sql = sql & "'" & M.ConverteTexto(txt_Descricao.Text) & "', " 'DESCRICAO
        sql = sql & cmb_Fase.Text & ", " 'FASE ATUAL
        sql = sql & txt_Qtd_Prevista.Text & ", '" 'QUANTIDADE PREVISTA
        sql = sql & cmb_Influenciador_Economico.Text & "', '"
        sql = sql & cmb_Influenciador_Tecnico.Text & "', '"
        sql = sql & cmb_Usuario.Text & "', '"
        sql = sql & cmb_Treinador.Text & "', "
        sql = sql & 1 & ", " 'SITUACAO OPORTUNIDADE = EM ANDAMENTO
        sql = sql & M.RecuperaData & ", " 'DATA DE INICIO = DATA DE CADASTRO
        sql = sql & "'" & Session("EMAIL_LOGIN") & "' )" 'EMAIL DE QUEM CRIOU A OPORTUNIDADE
        If M.ExecutarSQL(sql) = True Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "INCLUIU OPORTUNIDADE CNPJ:", Session("CNPJ"))
            Alert("OPORTUNIADE INCLUIDA COM SUCESSO", True, "Estabelecimentos_Ficha_Oportunidades.aspx" & "?CNPJ=" & Session("CNPJ"))
        Else
            Mensagem = "ERRO - INCLUSAO DE OPORTUNIDADE - " & Now() & Chr(10)
            Mensagem = Mensagem & "CNPJ: " & Session("CNPJ") & Chr(10)
            Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN")
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO AO CADASTRAR OPORTUNIDADE", Session("CNPJ"))
            M.EnviarEmail("ERRO - INCLUSAO DE OPORTUNIDADE", Mensagem, True, False, "", "")
            Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
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
End Class