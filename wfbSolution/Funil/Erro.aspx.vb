
Partial Class Erro
    Inherits System.Web.UI.Page

    Private Sub Erro_Load(sender As Object, e As EventArgs) Handles Me.Load
        lbl_ErrDescription.Text = Request.QueryString("ErrNumber").ToString & " - " & Request.QueryString("ErrDescription").ToString
        lbl_ErrMessage.Text = Request.QueryString("ErrMessage").ToString
        lbl_ErrLocation.Text = Request.QueryString("ErrLocation").ToString
    End Sub
End Class
