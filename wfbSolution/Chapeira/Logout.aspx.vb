Public Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub cmdLogout_ServerClick(sender As Object, e As EventArgs) Handles cmdLogout.ServerClick
        Session("EMAIL_LOGIN") = Nothing
        Session("NOME_LOGIN") = Nothing
        Response.Redirect("Default.aspx")
    End Sub
End Class