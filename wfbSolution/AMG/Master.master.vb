
Partial Class Master
    Inherits System.Web.UI.MasterPage
    ReadOnly m As New clsMaster
    Private Sub Master_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsNothing(HttpContext.Current.Session("ID_LOGIN").ToString) Or HttpContext.Current.Session("ID_LOGIN").ToString = "" Then
            Response.Redirect("Login.aspx")
        End If
    End Sub
End Class

