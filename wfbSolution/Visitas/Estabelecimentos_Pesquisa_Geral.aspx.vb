
Partial Class Estabelecimentos_Pesquisa_Geral
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
            SQL = SQL & " Select * From VIEW_ESTABELECIMENTOS_001_DETALHADO Where"
            SQL = SQL & " " & cmb_Filtro.Text & " Like '%" & txt_Parametro.Text & "%' "
            If cmb_UF.Text <> "@@" Then
                SQL = SQL & " And UF = '" & cmb_UF.Text & "' "
            End If
            dts_ESTABELECIMENTOS.SelectCommand = SQL
            gdv_Localizar.DataBind()
            Alert("Pesquisa concluida", False, "")
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