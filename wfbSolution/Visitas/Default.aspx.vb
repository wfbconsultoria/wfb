
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Default.aspx"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "Acessou a pa´gina inicial do sistema")
        End If
        Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        Session("URL_SITE") = Left(Request.Url.AbsoluteUri, Len(Request.Url.AbsoluteUri) - 13)
    End Sub
End Class
