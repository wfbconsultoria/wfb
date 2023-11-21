
Partial Class Medico_Consulta_CRM
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly s As New clsEstabelecimentos
    ReadOnly d As New clsMedicos

    Private Sub Medico_Consulta_CRM_Load(sender As Object, e As EventArgs) Handles Me.Load
        dts_UF.SelectCommand = s.sql_UF
        dts_UF.DataBind()
        dts_UF.DataBind()
    End Sub

    Private Sub cmd_check_ServerClick(sender As Object, e As EventArgs) Handles cmd_check.ServerClick
        Dim CRM As String = ""
        Dim CRM_UF As String = ""
        Dim UF As String = ""

        If d.FormatCRM(txt_CRM.Value) = "00000000" Then
            m.Alert(Me, "CRM INVÁLIDO", False, "")
            Exit Sub
        Else
            CRM = d.FormatCRM(txt_CRM.Value)
        End If

        If (cmb_CRM_UF.Text) = "" Or Len(cmb_CRM_UF) = 0 Or m.CheckExists("TBL_IBGE_ESTADOS", "UF", cmb_CRM_UF.Text) = False Then
            m.Alert(Me, "SELECIONE A UNIDADE DE FEDERAÇÃO DO CRM", False, "")
        Else
            UF = cmb_CRM_UF.Text
        End If

        CRM_UF = CRM & UF

        If m.CheckExists("TBL_MEDICOS", "CRM_UF", "CRM_UF") = False Then

        Else
        End If


    End Sub
End Class
