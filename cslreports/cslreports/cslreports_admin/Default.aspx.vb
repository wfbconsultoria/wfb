Imports System.Math
Partial Class _Default
    Inherits Page
    Dim m As New clsMaster
    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If  Session("USER_EMAIL")= NOTHING Then Response.Redirect("Login")
        If Session("USER_EMAIL") = "" Then Response.Redirect("Login")

        Page.Title = ConfigurationManager.AppSettings("UsersList.title")
        Dim dtr As System.Data.SqlClient.SqlDataReader = m.ExecuteSelect("Select * From vw_pbi_Reports_Users Where Active = 1 and Show = 1 and USER_EMAIL = '" & Session("USER_EMAIL").ToString & "'" & "Order By REPORT_NAME")
        Repeater1.DataSource = dtr
        Repeater1.DataBind()



    End Sub
End Class
