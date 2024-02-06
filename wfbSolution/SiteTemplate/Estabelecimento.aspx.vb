
Imports System.Activities.Expressions
Imports System.Data
Imports System.Runtime.Serialization

Partial Class Estabelecimento
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly s As New clsEstabelecimentos
    ReadOnly d As New clsMedicos
    Dim IdEstabelecimento As String
    Private Sub Estabelecimento_Load(sender As Object, e As EventArgs) Handles Me.Load
        IdEstabelecimento = Request.QueryString("IdEstabelecimento")
        Atualiza_DTS()
    End Sub
    Private Sub Atualiza_DTS()

        If UF_CRM.Items.Count = 0 Then
            dts_UF.SelectCommand = s.sql_UF("lista")
            dts_UF.DataBind()
            UF_CRM.DataBind()
        End If

    End Sub

    Private Sub cmd_Novo_CRM_ServerClick(sender As Object, e As EventArgs) Handles cmd_Novo_CRM.ServerClick
        'Valida e Formata CRM
        Dim _CRM As String = ""
        Dim _UF_CRM As String = ""
        Dim CRM_UF As String = ""

        If d.FormatCRM(CRM.Value) = "00000000" Then
            m.Alert(Me, "CRM INVÁLIDO", False, "")
            Exit Sub
        Else
            _CRM = d.FormatCRM(CRM.Value)
        End If

        'Valida UF do CRM
        If UF_CRM.Text = "" Or Len(UF_CRM.Text) = 0 Or m.CheckExists("TBL_IBGE_ESTADOS", "UF", UF_CRM.Text) = False Then
            m.Alert(Me, "SELECIONE A UNIDADE DE FEDERAÇÃO Do CRM", False, "")
            Exit Sub
        Else
            _UF_CRM = UF_CRM.Text
        End If

        'Monta e Formata CRM_UF
        CRM_UF = _CRM & _UF_CRM
        Response.Redirect("Medico_Incluir.aspx?IdEStabelecimento=" & IdEstabelecimento & "&CRM_UF=" & CRM_UF)

        ''Verifica se o médico está cadastrado - DESABILITADO a verificação está sendo feita na página de inclusão
        'If m.CheckExists("APP_MEDICOS", "CRM_UF", CRM_UF) = False Then
        '    Response.Redirect("Medico_Incluir.aspx?IdEStabelecimento=" & IdEstabelecimento & "&CRM_UF=" & CRM_UF & "&Cadastrado=0")
        'Else
        '    'Verifica se cadastrado no ESTABELECIMENTO
        '    Dim dtr As SqlClient.SqlDataReader
        '    Dim sql As String = " Select * From APP_MEDICOS_ESTABELECIMENTOS Where IdEstabelecimento = '" & IdEstabelecimento & "' And CRM_UF = '" & CRM_UF & "' "
        '    dtr = m.ExecuteSelect(sql)
        '    If dtr.HasRows Then
        '        dtr.Read()
        '        Response.Redirect("Medico_Incluir.aspx?IdEStabelecimento=" & IdEstabelecimento & "&CRM_UF=" & CRM_UF & "&Cadastrado=1")
        '        Exit Sub
        '    Else
        '        Response.Redirect("Medico_Incluir.aspx?IdEStabelecimento=" & IdEstabelecimento & "&CRM_UF=" & CRM_UF & "&Cadastrado=0")
        '    End If

        'End If
    End Sub
End Class
