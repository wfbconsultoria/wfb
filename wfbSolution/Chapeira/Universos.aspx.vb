Public Class Universos
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Dim u As New clsUniversos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("EMAIL_LOGIN")) Or Session("EMAIL_LOGIN") = "" Then Response.Redirect("Default.aspx")
        dtsUniversos.SelectCommand = u.sqlUniversos("", "Universo")
        dtsUniversos.DataBind()
    End Sub

End Class