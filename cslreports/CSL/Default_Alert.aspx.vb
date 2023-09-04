
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Default.aspx"
    Dim Titulo As String = "Início - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = Titulo
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString

        End If
        Session("URL_SITE") = Left(Request.Url.AbsoluteUri, Len(Request.Url.AbsoluteUri) - 13)
        Session("HOJE") = Format(Year(Now()), "0000") & Format(Month(Now()), "00") & Format(Day(Now()), "00")
    End Sub
End Class
