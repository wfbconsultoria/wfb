
Partial Class Contatos_Alterar
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Contatos_Alterar.aspx"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
    End Sub

    Protected Sub cmb_LinhaProduto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Usuarios.SelectedIndexChanged
        rpt_Performance_Rep.DataBind()
        rpt_Performance_Rep.LocalReport.Refresh()
    End Sub
End Class
