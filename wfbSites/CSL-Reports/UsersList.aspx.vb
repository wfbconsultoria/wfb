
Partial Class UsersList
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Private Sub UsersList_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("USER_EMAIL")="" Then Response.Redirect("Login")
         Page.Title = ConfigurationManager.AppSettings("UsersList.title")
         Dim dtr As System.Data.SqlClient.SqlDataReader  = m.ExecuteSelect("Select * From vw_Users Where Show = 1 Order By Active desc")
        Repeater1.DataSource = dtr
        Repeater1.DataBind
    End Sub

     Public FUNCTION FormatRow(Parameter As STRING) As STRING
        FormatRow = "bg-info"
        If Parameter = "False" then FormatRow = "bg-danger"
    End FUNCTION
End Class
