
Imports System.Activities.Expressions
Imports System.Data
Imports System.Runtime.Serialization
Imports ASP

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

        dts_FUNCAO.SelectCommand = d.sql_funcoes("lista")
        dts_FUNCAO.DataBind()

        dts_MEDICOS.SelectCommand = "Select * from APP_MEDICOS_ESTABELECIMENTOS Where IdEstabelecimento  = '" & IdEstabelecimento & "' And MEDICO_ATIVO_NO_ESTABELECIMENTO = 1 Order By NOME_SOBRENOME"
        dts_MEDICOS.DataBind()

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

    End Sub

    Private Sub cmd_Novo_Contato_ServerClick(sender As Object, e As EventArgs) Handles cmd_Novo_Contato.ServerClick

        Dim CNPJ As String = ""
        Dim dtr As SqlClient.SqlDataReader
        dtr = m.ExecuteSelect(s.sql_Estabelecimentos("ficha", IdEstabelecimento))
        If dtr.HasRows Then
            dtr.Read()
            'ATRIBUI VALORES AS PROPRIEDADES
            If Not IsDBNull(dtr("CNPJ")) Then CNPJ = m.ConvertText(dtr("CNPJ"))
        Else
            m.Alert(Me, "Selecione novamente o ESTABELECIMENTO", True, "estabelecimentos.aspx")
        End If

        Dim CRM_UF = "CC" & CNPJ & Format(Now.Year, "0000") & Format(Now.Month, "00") & Format(Now.Day, "00") & Format(Now.Hour, "00") & Format(Now.Minute, "00") & Format(Now.Second, "00") & Format(Now.Millisecond, "0000")
        Response.Redirect("Medico_Incluir.aspx?IdEStabelecimento=" & IdEstabelecimento & "&CRM_UF=" & CRM_UF)
    End Sub
End Class
