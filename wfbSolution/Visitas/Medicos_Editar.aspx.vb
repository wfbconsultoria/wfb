
Partial Class Medicos_Editar
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Medico Editar"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Default.aspx")
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

    End Sub
    Protected Sub frv_Medicos_Editar_ItemUpdated(sender As Object, e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles frv_Medicos_Editar.ItemUpdated
        Response.Redirect("Medicos_Ficha.aspx")
    End Sub
End Class
