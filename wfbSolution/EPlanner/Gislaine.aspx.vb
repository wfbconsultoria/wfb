Public Class Gislaine
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m.Alert(Me, "Pagina em contrução", False, "")
    End Sub

End Class