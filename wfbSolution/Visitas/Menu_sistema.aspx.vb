
Partial Class Menu_sistema
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Menu_sistema.aspx"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("SISTEMA") = False Then
            Response.Write("Default.aspx")
        End If
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
    End Sub
End Class