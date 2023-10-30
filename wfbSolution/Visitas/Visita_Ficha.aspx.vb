
Partial Class Visita_Ficha
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Representantes_Visitas.aspx"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''Verifica se a existe variável de sessão para CNPJ
        'Session("CNPJ") = ""
        'Session("CNPJ") = Request.QueryString("CNPJ")
        'If Session("CNPJ").ToString = "" Then Response.Redirect("Estabelecimentos_Localizar.aspx")1'    '

        ''Verifica se a existe variável de sessão para ID_VISITA
        Session("ID_VISITA") = ""
        Session("ID_VISITA") = Request.QueryString("ID_VISITA")
        Session("PAGINA") = Request.QueryString("PAGINA")
        'If Session("ID_VISITA").ToString = "" Then Response.Redirect("Estabelecimentos_Localizar.aspx")

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), HttpContext.Current.Handler.ToString, "ACESSOU", "")
        End If
        Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
    End Sub
End Class
