
Partial Class Visitas
    Inherits System.Web.UI.Page

    Private Sub Visitas_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim SQL As String
        SQL = "Select * from APP_VISITAS_MEDICOS"
        dts_VISITAS.SelectCommand = SQL
        dts_VISITAS.DataBind()
    End Sub
End Class
