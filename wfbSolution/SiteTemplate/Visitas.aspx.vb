
Partial Class Visitas
    Inherits System.Web.UI.Page
    ReadOnly v As New clsVisitas
    Dim sql As String
    Private Sub Visitas_Load(sender As Object, e As EventArgs) Handles Me.Load

        dts_REPRESENTANTES.SelectCommand = v.sql_visitas_representantes("lista")
        dts_REPRESENTANTES.DataBind()

        dts_TIPOS.SelectCommand = v.sql_visitas_tipos("lista")
        dts_TIPOS.DataBind()

        dts_ANOS.SelectCommand = v.sql_visitas_anos()
        dts_ANOS.DataBind()

        dts_MESES.SelectCommand = v.sql_visitas_meses()
        dts_MESES.DataBind()

        sql = ""
        sql &= " SELECT * FROM APP_VISITAS_MEDICOS  WHERE EMAIL_REPRESENTANTE = '" & EMAIL_REPRESENTANTE.Text & "' "

        If COD_TIPO.Text <> "" Then
            sql &= " AND VISITA_COD_TIPO = " & COD_TIPO.Text
        End If

        If ANO.Text <> "" Then
            sql &= " AND ANO = " & ANO.Text
        End If

        If MES.Text <> "" Then
            sql &= " AND MES = " & MES.Text
        End If

        dts_VISITAS.SelectCommand = sql
        dts_VISITAS.DataBind()

    End Sub

    Private Sub EMAIL_REPRESENTANTE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles EMAIL_REPRESENTANTE.SelectedIndexChanged
        dts_VISITAS.DataBind()
        dtr.DataBind()
    End Sub

    Private Sub ANO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ANO.SelectedIndexChanged
        dts_VISITAS.DataBind()
        dtr.DataBind()
    End Sub

    Private Sub MES_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MES.SelectedIndexChanged
        dts_VISITAS.DataBind()
        dtr.DataBind()
    End Sub

    Private Sub COD_TIPO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles COD_TIPO.SelectedIndexChanged
        dts_VISITAS.DataBind()
        dtr.DataBind()
    End Sub
End Class
