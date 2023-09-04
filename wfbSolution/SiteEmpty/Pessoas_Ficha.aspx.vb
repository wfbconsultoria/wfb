Public Class Pessoas_Ficha
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Request.QueryString("ID")) Then Response.Redirect("Default.aspx")
        If Request.QueryString("ID") = "" Then Response.Redirect("Default.aspx")
        Response.Write(Request.QueryString("ID"))



    End Sub

End Class