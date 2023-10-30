
Partial Class Estabelecimentos_CNES
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Estabelecimentos CNES"
    Dim UF As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SQL As String
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
        If Len(txt_Parametro.Text) > 0 Then
            SQL = ""
            SQL = SQL & " Select * From " & cmb_Tabela.Text
            SQL = SQL & " Where " & cmb_Filtro.Text & " Like '%" & txt_Parametro.Text & "%' "
            SQL = SQL & " Order By " & cmb_Ordem.Text
            dts_CADGER.SelectCommand = SQL
            gdv_Localizar.DataBind()
            Alert("Pesquisa concluida", False, "")
        End If
        Session("CNPJ_INCLUIR") = ""
        Session("CNES_INCLUIR") = ""
        Session("ORIGEM_ESTABELECIMENTO") = ""

    End Sub

    Protected Sub gdv_Localizar_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gdv_Localizar.RowCommand
        Dim X As Integer = Convert.ToInt32(e.CommandArgument)
        Dim LINHA As GridViewRow = gdv_Localizar.Rows(X)
        Dim CNES As New ListItem
        Dim NOME_FANTASIA As New ListItem
        Dim ACAO As String

        ACAO = e.CommandName.ToString
        CNES.Text = Server.HtmlDecode(LINHA.Cells(1).Text)
        Session("CNPJ_INCLUIR") = txt_Parametro.Text
        Session("CNES_INCLUIR") = CNES.Text
        If ACAO = "INCLUIR" Then Navegar("Estabelecimentos_Incluir.aspx")

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