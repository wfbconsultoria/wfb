
Imports System.Data

Partial Class Medico
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly s As New clsEstabelecimentos
    ReadOnly d As New clsMedicos
    ReadOnly c As New clsCEP
    Dim IdMedico As String
    Private Sub Medico_Load(sender As Object, e As EventArgs) Handles Me.Load
        IdMedico = Request.QueryString("IdMedico")
        Gravar()
        Atualiza_DTS()

        Dim sql As String = "Select * From APP_MEDICOS Where IdMedico = '" & IdMedico & "'"
        m.ExecuteSelect("Select * From APP_MEDICOS Where IdMedico = '" & IdMedico & "'")
        dts_MEDICO.SelectCommand = sql
        Dim dtr As SqlClient.SqlDataReader
        dtr = m.ExecuteSelect(sql)
        If dtr.HasRows Then
            dtr.Read()
            CRM.Value = dtr("CRM")
            UF_CRM.Value = dtr("UF_CRM")
            NOME.Value = dtr("NOME")
            ID_ESPECIALIDADE.Text = dtr("ID_ESPECIALIDADE")
            ID_TIPO.Text = dtr("ID_TIPO")
        Else

        End If

    End Sub
    Private Sub Atualiza_DTS()

        dts_ESPECIALIDADES.SelectCommand = d.sql_especialidades
        dts_ESPECIALIDADES.DataBind()
        dts_TIPOS.SelectCommand = d.sql_tipos
        dts_TIPOS.DataBind()


    End Sub
    Private Sub Gravar()
        If IsPostBack = True Then
            Dim sql As String = ""
            sql &= "Update TBL_MEDICOS Set "
            sql &= " ID_ESPECIALIDADE = " & ID_ESPECIALIDADE.Text & ", "
            sql &= " ID_TIPO = " & ID_TIPO.Text & ", "
            sql &= " NOME = '" & m.ConvertText(NOME.Value) & "'"
            sql &= " Where Id = '" & IdMedico & "'"
            If m.ExecuteSQL(sql) = True Then
                m.Alert(Me, "Atualização ok", False, "")
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub cmd_CEP_ServerClick(sender As Object, e As EventArgs) Handles cmd_CEP.ServerClick
        'If c.consultarCEP(CEP.Value) = True Then
        '    ENDERECO.Value = c.ENDERECO
        '    BAIRRO.Value = c.BAIRRO
        '    CIDADE.Value = c.CIDADE
        '    UF.Value = c.UF
        '    COD_IBGE_7.Value = c.COD_IBGE_7
        'Else
        '    CEP.Value = ""
        '    ENDERECO.Value = ""
        '    BAIRRO.Value = ""
        '    CIDADE.Value = ""
        '    UF.Value = ""
        '    COD_IBGE_7.Value = ""
        '    m.Alert(Me, "CEP INVÁLIDO", False, "")
        'End If
    End Sub

End Class
