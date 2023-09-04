
Partial Class Report
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Private Sub Report_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("USER_EMAIL") = "" Then Response.Redirect("Login")
        Page.Title = ConfigurationManager.AppSettings("UsersList.title")
        Dim dtr As System.Data.SqlClient.SqlDataReader = m.ExecuteSelect("Select * From tb_pbi_Reports Where Active = 1 Order By Active desc")
        Repeater1.DataSource = dtr
        Repeater1.DataBind()
    End Sub
End Class
