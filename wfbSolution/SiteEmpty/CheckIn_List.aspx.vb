Public Class CheckIn_List
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sql = m.sqlPessoas
        If IsNothing(Request.QueryString("TipoPessoa")) Then Response.Redirect("Default.aspx")
        sql = m.sqlPessoas & " Order By Nome"
        If Request.QueryString("TipoPessoa") = "visitante" Then sql = m.sqlPessoas & " and Tipo = 'Visitante' Order By Nome"
        If Request.QueryString("TipoPessoa") <> "visitante" Then sql = m.sqlPessoas & " and Tipo <> 'Visitante' Order By Nome"

        dtsPessoas.SelectCommand = sql
        dtsPessoas.DataBind()

    End Sub
End Class