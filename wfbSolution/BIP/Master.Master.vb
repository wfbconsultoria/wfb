Public Class Master
    Inherits System.Web.UI.MasterPage
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m.CheckLogin()
    End Sub

End Class