Public Class DashBoard_Detail_Colaboradores_Data
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txt_Data.Value = Now()
    End Sub

End Class