
Partial Class Contatos_Ficha
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Contatos_Ficha.aspx"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Request.QueryString("CNPJ")) > 0 Then Session("CNPJ") = Request.QueryString("CNPJ")
        If Len(Request.QueryString("ID")) > 0 Then Session("ID_CONTATO") = Request.QueryString("ID")
        If Session("ID_CONTATO").ToString = "" Then Response.Redirect("Estabelecimentos_Localizar.aspx")
        If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Default.aspx")

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

    End Sub
End Class
