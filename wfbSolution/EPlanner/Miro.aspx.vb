Public Class Miro
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m.Alert(Me, "Carreguei a página do Miro", False, "")
    End Sub

End Class