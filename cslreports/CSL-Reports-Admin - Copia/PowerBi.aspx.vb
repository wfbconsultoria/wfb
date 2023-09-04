
Partial Class PowerBi
    Inherits System.Web.UI.Page

    Private Sub PowerBi_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ifram As HtmlControl = CType(Me.FindControl("frmPower"), HtmlControl)
    
        frmPower.Src = "https://app.powerbi.com/view?r="& Request.QueryString("rptId").ToString

    End Sub
End Class
