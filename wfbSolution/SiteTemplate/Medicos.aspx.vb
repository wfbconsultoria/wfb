
Imports System.Data

Partial Class Medicos
    Inherits System.Web.UI.Page
    ReadOnly d As New clsMedicos
    ReadOnly s As New clsEstabelecimentos
    ReadOnly v As New clsVisitas
    Private Sub Medicos_Load(sender As Object, e As EventArgs) Handles Me.Load

        Atualiza_DTS()
        Dim sql As String = ""
        sql = ""
        Select Case HttpContext.Current.Session("NIVEL_LOGIN")
            Case = 0
                sql = " SELECT * FROM APP_MEDICOS_ESTABELECIMENTOS WHERE EMAIL_REPRESENTANTE = '" & EMAIL_REPRESENTANTE.Text & "' "
            Case = 1
                sql = " SELECT * FROM APP_MEDICOS_ESTABELECIMENTOS WHERE EMAIL_REPRESENTANTE = '" & EMAIL_REPRESENTANTE.Text & "' "
            Case = 3
                sql = " SELECT * FROM APP_MEDICOS_ESTABELECIMENTOS WHERE EMAIL_REPRESENTANTE = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "' "
        End Select

        If ATIVO.Text = "" Then

            sql &= " And ATIVO_VISITAS = 1"

        Else
            sql &= " And ATIVO_VISITAS = " & ATIVO.Text
        End If

        If TIPO_CONTATO.Text <> "" Then
            If TIPO_CONTATO.Text <> "( Todos )" Then sql &= " And TIPO_CONTATO = '" & TIPO_CONTATO.Text & "'"
        End If

        If ID_FUNCAO.Text <> "" Then sql &= " And ID_FUNCAO = '" & ID_FUNCAO.Text & "'"
        If ID_TIPO.Text <> "" Then sql &= " And ID_TIPO = " & ID_TIPO.Text

        'Atualiza table_lista
        dts.SelectCommand = sql
        dts.DataBind()
        dtr.DataBind()

        'Atualiza table_totais
        dts_TOTAIS.SelectCommand = "SELECT COUNT(DISTINCT CRM_UF) AS MEDICOS, COUNT(CRM_UF) AS ESTABELECIMENTOS FROM (" & sql & ") AS AS TB_TOTAIS"
        dts_TOTAIS.DataBind()
        dtr_TOTAIS.DataBind()
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

        dts_ATIVO.SelectCommand = "SELECT * FROM TBL_ATIVO_INATIVO ORDER BY ATIVO_DESCRICAO"
        dts_ATIVO.DataBind()

    End Sub

End Class
