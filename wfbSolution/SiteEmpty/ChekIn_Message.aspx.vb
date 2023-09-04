Public Class ChekIn_Message
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sql = m.sqlPessoas
        If IsNothing(Request.QueryString("ID")) Then Response.Redirect("Default.aspx")
        sql = m.sqlPessoas & " and ID = '" & Request.QueryString("ID").ToString

        dtsPessoas.SelectCommand = sql
        dtsPessoas.DataBind()
    End Sub

End Class