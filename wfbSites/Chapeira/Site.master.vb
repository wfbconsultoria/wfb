Imports System.Collections.Generic
Imports System.Security.Claims
Imports System.Security.Principal
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Partial Class SiteMaster
    Inherits MasterPage
    Dim m As New clsMaster
    Private Sub SiteMaster_Load(sender As Object, e As EventArgs) Handles Me.Load
        If  Session("USER_EMAIL")= NOTHING Then Response.Redirect("Login")
        If Session("USER_EMAIL") = "" Then Response.Redirect("~/Login.aspx")
    End Sub

    Private Sub cmdLogOff_Click(sender As Object, e As EventArgs) Handles cmdLogOff.Click
         Session("USER_EMAIL")=""
        Response.Redirect("Login")
    End Sub

End Class
