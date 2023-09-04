Public Class _Default
    Inherits System.Web.UI.Page
    ReadOnly u As New clsUsers
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        u.CheckAccess()
    End Sub

End Class