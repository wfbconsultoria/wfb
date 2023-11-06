Public Class Establishments
    Inherits System.Web.UI.Page
    ReadOnly s As New cslEstablishments
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dts.SelectCommand = s.sql_Stablishments
        dts.DataBind()
        dtr.DataBind()
    End Sub

End Class