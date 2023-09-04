
Partial Class Digitacao_Demanda
    Inherits System.Web.UI.Page
    Public jscript As String
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Digitacao_Demanda.aspx"
    Dim Titulo As String = "Digitação de Demanda - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
    Dim sql As String

    'Váriáveis da Página

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = True 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = False 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = False 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = False 'Cordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = False 'Representante
        If Session("COD_PERFIL_LOGIN") = 10 Then Acesso = False 'Key Account
        If Session("COD_PERFIL_LOGIN") = 20 Then Acesso = False 'Visitante
        If Session("COD_PERFIL_LOGIN") = 30 Then Acesso = False 'Distribuidor
        If Session("SISTEMA") <> True Then Acesso = True 'Sistema

        'Verifica se o perfil do usuário tem acesso a página
        If Acesso = True Then
            'Grava log de permissão de acesso
            If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSO PERMITIDO", "")
                Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
                Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
            End If
        Else
            'Grava log de recusa de acesso
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSO RECUSADO", "")
            Alert("Seu perfil de usuário não permite acesso a esta página!", True, "Default.aspx")
        End If
        '____________________________________________________________________________________________________________________________________________

        If Len(txt_Parametro.Text) > 0 Then
            SQL = ""
            SQL = SQL & " Select * From VIEW_ESTABELECIMENTOS_001_DETALHADO "
            SQL = SQL & " Where " & cmb_Filtro.Text & " Like '%" & txt_Parametro.Text & "%' "
            SQL = SQL & " Order By " & cmb_Ordem.Text
            dts_Estabelecimentos.SelectCommand = SQL
            gdv_Localizar.DataBind()
        End If
    End Sub
    Protected Sub cmd_Gravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Gravar.Click
        Dim sql As String
        Dim Mensagem As String
        Dim CNPJ As String
        
        'verifica se os campos estão preenchidos
        If Len(txt_QTD.Text) = 0 Or txt_QTD.Text = "" Or txt_QTD.Text = 0 Then
            Alert("DIGITE A QUANTIDADE", False, "")
            Exit Sub
        End If

        CNPJ = ""
        CNPJ = gdv_Localizar.SelectedValue
        If CNPJ = "" Then
            Alert("SELECIONE O ESTABELECIMENTO", False, "")
        End If
        sql = ""
        sql = sql & " Insert Into TBL_MOVIMENTO_DEMANDA "
        sql = sql & " (ANO, MES,DIA, CNPJ_DISTRIBUIDOR, CNPJ_ESTABELECIMENTO, COD_PRODUTO, QTD)"
        sql = sql & " Values ("
        sql = sql & cmb_ANO.Text & ", "
        sql = sql & cmb_MES.Text & ", "
        sql = sql & cmb_DIA.Text & ", "
        sql = sql & cmb_CNPJ_DISTRIBUIDOR.Text & ", "
        sql = sql & Val(CNPJ) & ", "
        sql = sql & "'" & cmb_COD_PRODUTO.Text & "', "
        sql = sql & txt_QTD.Text & ")"


        If M.ExecutarSQL(sql) = True Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "DIGITOU DEMANDA", "CNPJ DISTRIBUIDOR: " & cmb_CNPJ_DISTRIBUIDOR.Text & " CNPJ ESTABELECIMENTO: " & CNPJ & " COD PRODUTO " & cmb_COD_PRODUTO.Text & " QTD " & txt_QTD.Text)
            Alert("Registro Incluido com sucesso", False, "")
            txt_QTD.Text = ""
        Else
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO - DIGITACAO DEMANDA", "CNPJ DISTRIBUIDOR: " & cmb_CNPJ_DISTRIBUIDOR.Text & " CNPJ ESTABELECIMENTO: " & CNPJ & " COD PRODUTO " & cmb_COD_PRODUTO.Text & " QTD " & txt_QTD.Text)
            Mensagem = "ERRO  - DIGITACAO DEMANDA" & Chr(10)
            Mensagem = Mensagem & "CNPJ DISTRIBUIDOR: " & cmb_CNPJ_DISTRIBUIDOR.Text & " CNPJ ESTABELECIMENTO: " & CNPJ & " COD PRODUTO " & cmb_COD_PRODUTO.Text & " QTD " & txt_QTD.Text
            M.EnviarEmail("ERRO  - DIGITACAO DEMANDA", Mensagem, True, False, "", "")
            Alert("Erro ao incluir registro", False, "")
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