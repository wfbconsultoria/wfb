Option Explicit On
Imports System.Data
Imports Newtonsoft.Json.Linq

Partial Class Estabelecimento_Incluir
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly s As New clsEstabelecimentos
    Private Sub cmd_Consultar_CNPJ_ServerClick(sender As Object, e As EventArgs) Handles cmd_Consultar_CNPJ.ServerClick
        Valida_CNPJ()
    End Sub

    Private Sub Valida_CNPJ()

        'verfica se campo está preenchido
        If Len(CNPJ_CONSULTAR.Value) = 0 Then
            m.Alert(Me, "DIGITE O NUMERO DO DOCUMENTO", False, "")
            Exit Sub
        End If

        'permite somente números
        If Not IsNumeric(CNPJ_CONSULTAR.Value) Then
            m.Alert(Me, "DIGITE SOMENTE NÚMEROS", False, "")
            Exit Sub
        End If

        'verifica tamnho do CNPJ
        If Len(CNPJ_CONSULTAR.Value) < 7 Or Len(CNPJ.Value) > 14 Then
            m.Alert(Me, "CNPJ DEVE CONTER  ENTRE 7 E 14 NÚMEROS ", False, "")
            Exit Sub
        End If

        'Verifica se o estabelecimento já existe
        Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect("Select Id From TBL_ESTABELECIMENTOS Where CNPJ = " & CNPJ_CONSULTAR.Value)
        If dtr.HasRows Then
            dtr.Read()
            Dim ID_ESTABELECIMENTO As String = dtr("ID").ToString
            m.Alert(Me, "CNPJ JÁ ESTÁ CADASTRADO", False, "")
            'Response.Redirect("Estabelecimento_Editar.aspx?IdEstabelecimento=" & ID_ESTABELECIMENTO.ToString)
            Exit Sub
        End If

        Consulta_RF(CNPJ_CONSULTAR.Value)
    End Sub
    Public Sub Consulta_RF(sCNPJ As String)
        On Error GoTo Err_Consulta_RF
        s.ConsultarCNPJ(sCNPJ)
        'atribui o NUMERO na variavel CNPJ
        Dim strCNPJ As String = s.Formata_CNPJ(sCNPJ)

        'POSTA NA PÁGINA
        CNPJ.Value = strCNPJ
        txt_NOME_FANTASIA.Value = s.NomeFantasia
        txt_RAZAO_SOCIAL.Value = s.RazaoSocial
        txt_ENDERECO.Value = s.Logradouro
        txt_NUMERO.Value = s.Numero
        txt_COMPLEMENTO.Value = s.Complemento
        txt_BAIRRO.Value = s.Bairro
        txt_CEP.Value = s.CEP
        txt_CIDADE.Value = s.Cidade
        txt_UF.Value = s.Estado
        txt_COD_IBGE_7.Value = s.CodigoIBGE
        txt_LATITUDE.Value = s.Latitude.ToString
        txt_LONGITUDE.Value = s.Longitude.ToString
        txt_PLUSCODE.Value = s.PlusCodes.ToString
        txt_COD_NATUREZA_JURIDICA.Value = s.CodigoNaturezaJuridica
        txt_NATUREZA_JURIDICA_DESCRICAO.Value = s.CodigoNaturezaJuridicaDescricao
        txt_CNAE.Value = s.CNAECodigo
        txt_CNAE_DESCRICAO.Value = s.CNAEDescricao
        txt_COD_ATIVIDADE_ECONOMICA.Value = s.CodigoAtividadeEconomica
        txt_ATIVIDADE_ECONOMICA.Value = s.CodigoAtividadeEconomicaDescricao
        txt_DATA_FUNDACAO.Value = s.DataFundacao
        txt_SITUACAO_RFB.Value = s.SituacaoRFB
        Exit Sub
Err_Consulta_RF:
        m.Alert(Me, Err.Number & " - " & Err.Description, False, "")
    End Sub

    Private Sub cmd_Gravar_ServerClick(sender As Object, e As EventArgs) Handles cmd_Gravar.ServerClick
        Dim SQL As String = ""

        SQL &= "INSERT INTO [dbo].[TBL_ESTABELECIMENTOS]"
        SQL &= " ([CNPJ]"
        SQL &= ",[CNES]"
        SQL &= ",[RAZAO_SOCIAL]"
        SQL &= ",[NOME_FANTASIA]"
        SQL &= ",[CLASSE_ESTABELECIMENTO_ID]"
        SQL &= ",[GRUPO_ESTABELECIMENTO_ID]"

        SQL &= ",[LOGRADOURO]"
        SQL &= ",[NUMERO]"
        SQL &= ",[COMPLEMENTO]"
        SQL &= ",[BAIRRO]"
        SQL &= ",[CEP]"
        SQL &= ",[MUNICIPIO_ID]"
        SQL &= ",[CIDADE_RF]"
        SQL &= ",[UF_RF]"
        SQL &= ",[LATITUDE]"
        SQL &= ",[LONGITUDE]"
        SQL &= ",[PLUS_CODE]"

        SQL &= ",[NATUREZA_ID]"
        SQL &= ",[NATUREZA_DESCRICAO]"
        SQL &= ",[CNAE]"
        SQL &= ",[CNAE_DESCRICAO]"
        SQL &= ",[ATIVIDADE_ECONOMICA_ID]"
        SQL &= ",[ATIVIDADE_ECONOMICA_DESCRICAO]"

        SQL &= ",[DATA_FUNDACAO]"
        SQL &= ",[SITUACAO_RF]"

        SQL &= ",[GRUPO_DISTRIBUIDOR_ID]"
        SQL &= ",[MINISTERIO]"
        SQL &= ",[ATIVO]"
        SQL &= ",[INCLUSAO_EMAIL])"

        SQL &= " VALUES ("
        SQL &= "'" & s.Formata_CNPJ(CNPJ.Value) & "'," '[CNPJ]
        SQL &= "'0000000'," '[CNES]
        SQL &= "'" & m.ConvertText(txt_RAZAO_SOCIAL.Value, clsMaster.TextCaseOptions.UpperCase) & "',"  '[RAZAO_SOCIAL]"
        SQL &= "'" & m.ConvertText(txt_NOME_FANTASIA.Value, clsMaster.TextCaseOptions.UpperCase) & "'," '[NOME_FANTASIA]
        SQL &= "'0'," '[CLASSE_ESTABELECIMENTO_ID]
        SQL &= "'0'," '[GRUPO_ESTABELECIMENTO_ID]

        SQL &= "'" & m.ConvertText(txt_ENDERECO.Value, clsMaster.TextCaseOptions.UpperCase) & "',"      '[LOGRADOURO]
        SQL &= "'" & m.ConvertText(txt_NUMERO.Value, clsMaster.TextCaseOptions.UpperCase) & "',"        '[NUMERO]
        SQL &= "'" & m.ConvertText(txt_COMPLEMENTO.Value, clsMaster.TextCaseOptions.UpperCase) & "',"   '[COMPLEMENTO]
        SQL &= "'" & m.ConvertText(txt_BAIRRO.Value, clsMaster.TextCaseOptions.UpperCase) & "',"        '[BAIRRO]
        SQL &= "'" & m.ConvertText(txt_CEP.Value, clsMaster.TextCaseOptions.UpperCase) & "',"           '[CEP]
        SQL &= "'" & m.ConvertText(txt_COD_IBGE_7.Value, clsMaster.TextCaseOptions.UpperCase) & "',"    '[MUNICIPIO_ID]
        SQL &= "'" & m.ConvertText(txt_CIDADE.Value, clsMaster.TextCaseOptions.UpperCase) & "',"        '[CIDADE_RF]
        SQL &= "'" & m.ConvertText(txt_UF.Value, clsMaster.TextCaseOptions.UpperCase) & "',"        '[UF_RF]
        SQL &= "'" & txt_LATITUDE.Value.ToString & "',"     '[LATITUDE]
        SQL &= "'" & txt_LONGITUDE.Value.ToString & "',"    '[LONGITUDE]
        SQL &= "'" & txt_PLUSCODE.Value.ToString & "',"     '[PLUS_CODE]

        SQL &= "'" & m.ConvertText(txt_COD_NATUREZA_JURIDICA.Value, clsMaster.TextCaseOptions.UpperCase) & "',"         '[NATUREZA_ID]
        SQL &= "'" & m.ConvertText(txt_NATUREZA_JURIDICA_DESCRICAO.Value, clsMaster.TextCaseOptions.UpperCase) & "',"   '[NATUREZA_DESCRICAO]
        SQL &= "'" & m.ConvertText(txt_CNAE.Value, clsMaster.TextCaseOptions.UpperCase) & "',"              '[CNAE]
        SQL &= "'" & m.ConvertText(txt_CNAE_DESCRICAO.Value, clsMaster.TextCaseOptions.UpperCase) & "',"    '[CNAE_DESCRICAO]
        SQL &= "'" & m.ConvertText(txt_COD_ATIVIDADE_ECONOMICA.Value, clsMaster.TextCaseOptions.UpperCase) & "'," '[ATIVIDADE_ECONOMICA_ID]
        SQL &= "'" & m.ConvertText(txt_ATIVIDADE_ECONOMICA.Value, clsMaster.TextCaseOptions.UpperCase) & "',"     '[ATIVIDADE_ECONOMICA_DESCRICAO]
        SQL &= "'" & txt_DATA_FUNDACAO.Value.ToString & "',"      '[DATA_FUNDACAO]
        SQL &= "'" & txt_SITUACAO_RFB.Value.ToString & "',"       '[SITUACAO_RF]    

        SQL &= "'0'," '[GRUPO_DISTRIBUIDOR_ID]
        SQL &= "'0'," '[MINISTERIO]
        SQL &= "'1'," '[ATIVO]
        SQL &= "'" & Session("EMAIL_LOGIN") & "')" '[INCLUSAO_EMAIL]

        If m.ExecuteSQL(SQL) = True Then
            Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect("Select ID From TBL_ESTABELECIMENTOS Where CNPJ = " & CNPJ.Value)
            If dtr.HasRows Then
                dtr.Read()
                Dim ID_ESTABELECIMENTO = dtr("ID")
                Response.Redirect("Estabelecimento_Editar.aspx?IdEstabelecimento=" & ID_ESTABELECIMENTO.ToString)
                'm.Alert(Me, "ESTABELECIMENTO CADASTRADO COM SUCESSO", True, "Estabelecimento_Editar.aspx?IdEstabelecimento=" & ID_ESTABELECIMENTO.ToString)
            Else
                m.Alert(Me, "ERRO AO CADASTRAR ESTABELECIMENTO", False, "")
            End If
        End If
    End Sub

End Class
