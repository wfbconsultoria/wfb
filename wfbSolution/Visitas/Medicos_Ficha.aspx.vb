
Partial Class Medicos_Ficha
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Medico Ficha"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Request.QueryString("CRMUF")) > 0 Then Session("CRMUF") = Request.QueryString("CRMUF")
        If Session("CRMUF").ToString = "" Then Response.Redirect("Medicos_Lista.aspx")
        If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Default.aspx")
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
        If Len(Request.QueryString("PAGINA")) > 0 Then Session("PAGINA") = Request.QueryString("PAGINA")

    End Sub
End Class
