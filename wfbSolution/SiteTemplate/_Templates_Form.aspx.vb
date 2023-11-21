
Partial Class _Templates_Form
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly s As New clsEstabelecimentos
    ReadOnly d As New clsMedicos
    ReadOnly c As New clsCEP

    Private Sub _Templates_Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        Atualiza_DTS()


    End Sub
    Private Sub Atualiza_DTS()


        If IsPostBack = False Then
            If UF_CRM.Items.Count < 0 Then
                dts_UF.SelectCommand = s.sql_UF("lista")
                dts_UF.DataBind()
                UF_CRM.DataBind()

                dts_ESPECIALIDADES.SelectCommand = d.sql_especialidades("lista")
                dts_ESPECIALIDADES.DataBind()
                ID_ESPECIALIDADE.DataBind()

                dts_TIPOS.SelectCommand = d.sql_tipos("lista")
                dts_TIPOS.DataBind()
                ID_TIPO.DataBind()
            End If
        End If
    End Sub

    Private Sub cmd_CEP_ServerClick(sender As Object, e As EventArgs) Handles cmd_CEP.ServerClick

        If c.consultarCEP(CEP.Value) = True Then
            ENDERECO.Value = c.ENDERECO
            BAIRRO.Value = c.BAIRRO
            CIDADE.Value = c.CIDADE
            UF.Value = c.UF
            COD_IBGE_7.Value = c.COD_IBGE_7
        Else
            CEP.Value = ""
            ENDERECO.Value = ""
            BAIRRO.Value = ""
            CIDADE.Value = ""
            UF.Value = ""
            COD_IBGE_7.Value = ""
            m.Alert(Me, "CEP INVÁLIDO", False, "")
        End If

    End Sub

    Private Function valida_Form() As Boolean

        valida_Form = True

    End Function
End Class
