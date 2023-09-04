
Imports Microsoft.AspNet.Identity
Public Class User_Add_Info
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Private Sub User_Add_Info_Load(sender As Object, e As EventArgs) Handles Me.Load
        txt_Email.Text = Context.User.Identity.GetUserName().ToString
    End Sub
End Class