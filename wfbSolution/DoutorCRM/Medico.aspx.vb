Public Class Medico
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack() = False Then RecoverRecord()
        If IsPostBack() = True Then SaveRecord()

    End Sub
    Private Sub RecoverRecord()
        CRMUF.Value = Request.QueryString("CRMUF").ToString
        m.Alert(Me, "RECUPERADO CRMUF: " & CRMUF.Value)
    End Sub

    Private Sub SaveRecord()
        m.Alert(Me, "SALVO: " & NOME.Value)
    End Sub

    Private Sub cmd_ConsultaCEP_ServerClick(sender As Object, e As EventArgs) Handles cmd_ConsultaCEP.ServerClick
        ' ConsultaCEP()
        Dim cCEP As svcCEP.CEP1 = m.ConsultaCEP(CEP.Value)
        Try
            ENDERECO.Value = cCEP.TipoLogradouro & " " & cCEP.Logradouro.ToUpper
            BAIRRO.Value = cCEP.Bairro.ToUpper
            CIDADE.Value = cCEP.Cidade.ToUpper
            UF.Value = cCEP.UF

        Catch ex As Exception
            ENDERECO.Value = ""
            BAIRRO.Value = ""
            CIDADE.Value = ""
            UF.Value = ""
            m.Alert(Me, "CEP INVÁLIDO")
        End Try
    End Sub

    Private Sub cmd_ConsultaCPF_ServerClick(sender As Object, e As EventArgs) Handles cmd_ConsultaCPF.ServerClick
        If DATA_NASCIMENTO.Value = "" Then
            m.Alert(Me, "PARA VALIDAR O CPF É NECESSÁRIO A DATA DE NASCIMENTO", False, "")
            Exit Sub
        End If

        Dim pf As svcCDC.PessoaFisicaSimplificada = m.ConsultaPessoaFisicaSimplificada(CPF.Value, DATA_NASCIMENTO.Value)
        Try
            If pf.Status = False Then
                CPF.Value = ""
                m.Alert(Me, "CPF OU DATA DE NASCIMENTO INVALIDOS", False, "")
                Exit Sub
            End If
            NOME.Value = m.ConvertText(pf.Nome).ToUpper

        Catch ex As Exception
            CPF.Value = ""
            m.Alert(Me, "CPF OU DATA DE NASCIMENTO INVALIDOS", False, "")
        End Try
    End Sub

End Class