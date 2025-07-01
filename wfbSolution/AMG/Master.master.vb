
Partial Class Master
    Inherits System.Web.UI.MasterPage
    ReadOnly m As New clsMaster
    Private Sub Master_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsNothing(HttpContext.Current.Session("ID_LOGIN")) Or HttpContext.Current.Session("ID_LOGIN") = "" Then
            Response.Redirect("Login.aspx")
        End If
    End Sub
End Class

