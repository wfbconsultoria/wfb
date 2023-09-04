Public Class PBI
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ifram As HtmlControl = CType(Me.FindControl("frmPower"), HtmlControl)

        frmPower.Src = "https://app.powerbi.com/view?r=" & Request.QueryString("rptId").ToString
    End Sub

End Class