Public Class _Page_Error
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbl_ErrDescription.Text = Request.QueryString("ErrNumber").ToString & " - " & Request.QueryString("ErrDescription").ToString
        lbl_ErrMessage.Text = Request.QueryString("ErrMessage").ToString
        lbl_ErrLocation.Text = Request.QueryString("ErrLocation").ToString
    End Sub

End Class