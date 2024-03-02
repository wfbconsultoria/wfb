
Imports System.Data

Partial Class Medicos
    Inherits System.Web.UI.Page
    ReadOnly d As New clsMedicos
    ReadOnly s As New clsEstabelecimentos
    ReadOnly v As New clsVisitas
    Private Sub Medicos_Load(sender As Object, e As EventArgs) Handles Me.Load

        Atualiza_DTS()
        Dim sql As String = ""
        sql = " SELECT * FROM APP_MEDICOS_ESTABELECIMENTOS WHERE EMAIL_REPRESENTANTE = '" & EMAIL_REPRESENTANTE.Text & "'"


        If TIPO_CONTATO.Text <> "( Todos )" Then sql &= " And TIPO_CONTATO = '" & TIPO_CONTATO.Text & "'"
        If ID_FUNCAO.Text <> "" Then sql &= " And ID_FUNCAO = '" & ID_FUNCAO.Text & "'"
        If ID_TIPO.Text <> "" Then sql &= " And ID_TIPO = " & ID_TIPO.Text

        dts.SelectCommand = sql
        dts.DataBind()
        dtr.DataBind()

    End Sub
    Sub Atualiza_DTS()
        dts_REPRESENTANTES.SelectCommand = s.sql_estabelecimentos_representantes
        dts_REPRESENTANTES.DataBind()

        dts_TIPOS.SelectCommand = d.sql_tipos
        dts_TIPOS.DataBind()

        dts_TIPOS_CONTATOS.SelectCommand = d.sql_tipos_contatos
        dts_TIPOS_CONTATOS.DataBind()

        dts_FUNCOES.SelectCommand = d.sql_funcoes
        dts_FUNCOES.DataBind()

        dts_VISITAS_ANOS.SelectCommand = v.sql_visitas_anos
        dts_VISITAS_ANOS.DataBind()

        dts_VISITAS_MESES.SelectCommand = v.sql_visitas_meses
        dts_VISITAS_MESES.DataBind()
    End Sub
End Class
