
Partial Class Visitas
    Inherits System.Web.UI.Page
    ReadOnly v As New clsVisitas
    Private Sub Visitas_Load(sender As Object, e As EventArgs) Handles Me.Load

        dts_Representantes.SelectCommand = v.sql_visitas_representantes("lista")
        dts_Representantes.DataBind()

        dts_VISITAS.SelectCommand = v.sql_visitas("lista")
        dts_VISITAS.DataBind()

    End Sub
End Class
