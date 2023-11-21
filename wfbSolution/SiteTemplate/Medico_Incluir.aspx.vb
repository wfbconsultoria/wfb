
Partial Class Medico_Incluir
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly s As New clsEstabelecimentos
    ReadOnly d As New clsMedicos
    Private Sub Medico_Incluir_Load(sender As Object, e As EventArgs) Handles Me.Load
        dts_UF.SelectCommand = s.sql_UF
        dts_UF.DataBind()

        dts_ESPECIALIDADES.SelectCommand = d.sql_especialidades("lista")
        dts_ESPECIALIDADES.DataBind()

        dts_TIPOS.SelectCommand = d.sql_tipos("lista")
        dts_TIPOS.DataBind()

    End Sub
End Class
