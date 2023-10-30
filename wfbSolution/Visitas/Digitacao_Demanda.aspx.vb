
Partial Class Digitacao_Demanda
    Inherits System.Web.UI.Page
    Public jscript As String
    Dim M As New clsMaster
    Dim Pagina As String = "Digitacao Demanda"
    Dim SQL As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'VERIFICA SE O PERFIL DE ACESSO PERMITE ACESSO A PAGINA
        If Session("COD_PERFIL_LOGIN") = 1 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 2 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 3 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 4 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 5 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 6 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 7 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 100 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")

        If Session("SISTEMA") <> True Then
            Alert("Você não tem acesso a esta página", True, "Default.aspx")
        End If

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

        If Len(txt_Parametro.Text) > 0 Then
            SQL = ""
            SQL = SQL & " Select * From VIEW_ESTABELECIMENTOS "
            SQL = SQL & " Where " & cmb_Filtro.Text & " Like '%" & txt_Parametro.Text & "%' "
            SQL = SQL & " Order By " & cmb_Ordem.Text
            dts_Estabelecimentos.SelectCommand = SQL
            gdv_Localizar.DataBind()

        Else
            SQL = ""
            SQL = SQL & " Select * From VIEW_ESTABELECIMENTOS Where CNPJ = -1"
            dts_Estabelecimentos.SelectCommand = SQL
            gdv_Localizar.DataBind()
        End If

        'PERMITE SOMENTE A DIGITACAO DE NÚMEROS NO CAMPO QTD
        txt_QTD.Attributes.Add("OnKeyPress", "Digitar_Numeros(this);")

    End Sub

    Protected Sub cmd_Gravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Gravar.Click
        Dim sql As String
        Dim Mensagem As String
        Dim CNPJ As String
        
        
        CNPJ = ""
        CNPJ = gdv_Localizar.SelectedValue
        If CNPJ = "" Then
            Alert("SELECIONE O ESTABELECIMENTO", False, "")
            Exit Sub
        End If

        If Len(txt_QTD.Text) = 0 Then
            Alert("DIGITE A QUANTIDADE", False, "")
            Exit Sub
        End If

        If txt_QTD.Text = 0 Then
            Alert("DIGITE A QUANTIDADE", False, "")
            Exit Sub
        End If



        sql = ""
        sql = sql & " Insert Into tbl_MOVIMENTO_DEMANDA "
        sql = sql & " (ANO, MES, CNPJ_DISTRIBUIDOR, CNPJ_ESTABELECIMENTO, COD_PRODUTO, QTD)"
        sql = sql & " Values ("
        sql = sql & cmb_ANO.Text & ", "
        sql = sql & cmb_MES.Text & ", "
        sql = sql & cmb_CNPJ_DISTRIBUIDOR.Text & ", "
        sql = sql & Val(CNPJ) & ", "
        sql = sql & "'" & cmb_COD_PRODUTO.Text & "', "
        sql = sql & txt_QTD.Text & ")"

        If M.ExecutarSQL(sql) = True Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "DIGITOU DEMANDA", "CNPJ DISTRIBUIDOR: " & cmb_CNPJ_DISTRIBUIDOR.Text & " CNPJ ESTABELECIMENTO: " & CNPJ & " COD PRODUTO " & cmb_COD_PRODUTO.Text & " QTD " & txt_QTD.Text)
            Alert("Registro Incluido com sucesso", False, "")
            txt_QTD.Text = ""
        Else
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO - DIGITAR DEMANDA", "CNPJ DISTRIBUIDOR: " & cmb_CNPJ_DISTRIBUIDOR.Text & " CNPJ ESTABELECIMENTO: " & CNPJ & " COD PRODUTO " & cmb_COD_PRODUTO.Text & " QTD " & txt_QTD.Text)
            Mensagem = "ERRO  - DIGITACAO DEMANDA" & Chr(10)
            Mensagem = Mensagem & "CNPJ DISTRIBUIDOR: " & cmb_CNPJ_DISTRIBUIDOR.Text & " CNPJ ESTABELECIMENTO: " & CNPJ & " COD PRODUTO " & cmb_COD_PRODUTO.Text & " QTD " & txt_QTD.Text
            M.EnviarEmail("ERRO  - SETORIZACAO DE ESTABELECIMENTOS", Mensagem, True, False, "", "")
            Alert("Erro ao incluir registro, verifique se a quantidade foi digitada corretamente", False, "")
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

