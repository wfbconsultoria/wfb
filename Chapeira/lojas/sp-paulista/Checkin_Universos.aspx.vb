
Partial Class lojas_WFB_Checkin_Universos
    Inherits System.Web.UI.Page
    Dim u As New clsUniversos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtsUniversos.SelectCommand = u.sqlUniversos("", "Universo")
        dtsUniversos.DataBind()
    End Sub
End Class