
Partial Class Medicos
    Inherits System.Web.UI.Page
    ReadOnly d As New clsMedicos
    Private Sub Medicos_Load(sender As Object, e As EventArgs) Handles Me.Load
        dts.SelectCommand = d.sql_medicos("lista")
        dts.DataBind()
        dtr.DataBind()
    End Sub
End Class
