Option Explicit On

Partial Class Pesquisa_CEP
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly c As New clsCEP
    Private Sub cmd_CEP_ServerClick(sender As Object, e As EventArgs) Handles cmd_CEP.ServerClick

        Dim endereco = c.consultarCEP(CEP.Value)
        If c.cepStatus = False Then
            m.Alert(Me, "cep inválido")
        Else
            LOGRADOURO.Value = endereco.street
            COMPLEMENTO.Value = endereco.complement
            BAIRRO.Value = endereco.district
            COD_IBGE_7.Value = endereco.cityId
            CIDADE.Value = endereco.city
            UF.Value = endereco.stateShortname
        End If
    End Sub

End Class
