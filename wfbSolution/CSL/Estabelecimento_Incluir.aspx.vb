Option Explicit On
Imports System.Data

Partial Class Estabelecimento_Incluir
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly s As New clsEstabelecimentos
    Private Sub cmd_Consultar_CNPJ_ServerClick(sender As Object, e As EventArgs) Handles cmd_Consultar_CNPJ.ServerClick
        Consulta_RF()
    End Sub
    Public Sub Consulta_RF()
        On Error GoTo Err_Consulta_RF
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

        'atribui o domuento na variavel CNPJ
        Dim strCNPJ As String = s.Formata_CNPJ(CNPJ_CONSULTAR.Value)

        'Verifica se o estabelecimento já existe
        Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect("Select Id From TBL_ESTABELECIMENTOS Where CNPJ = '" & strCNPJ & "' ")
        If dtr.HasRows Then
            dtr.Read()
            Dim ID_ESTABELECIMENTO As String = dtr("ID").ToString
            m.Alert(Me, "CNPJ JÁ ESTÁ CADASTRADO", True, "Estabelecimento_Editar.aspx?idEstabelecimento=" & ID_ESTABELECIMENTO)
        End If

        Dim Retorno = s.consultarCNPJ(strCNPJ)
        Dim RAZAO_SOCIAL As String = m.ConvertText(Retorno.RazaoSocial)
        Dim NOME_FANTASIA As String = m.ConvertText(Retorno.NomeFantasia)
        If NOME_FANTASIA = "" Then NOME_FANTASIA = RAZAO_SOCIAL
        Dim NUMERO As String = m.ConvertText(Retorno.Numero)
        Dim ENDERECO As String = m.ConvertText(Retorno.Logradouro)
        Dim COMPLEMENTO As String = m.ConvertText(Retorno.Complemento)
        Dim BAIRRO As String = m.ConvertText(Retorno.Bairro)
        Dim CEP As String = m.ConvertText(Retorno.CEP)
        Dim CIDADE As String = m.ConvertText(Retorno.Cidade)
        Dim ESTADO As String = m.ConvertText(Retorno.Estado)
        Dim COD_IBGE As String = m.ConvertText(Retorno.CodIBGE)
        Dim COD_NATUREZA_JURIDICA As String = m.ConvertText(Retorno.CodNaturezaJuridica)
        Dim NATUREZA_JURIDICA_DESCRICAO As String = m.ConvertText(Retorno.NaturezaJuridicaDescricao)
        Dim CNAE As String = Replace(Replace(m.ConvertText(Retorno.CodCNAE), "/", ""), "-", "")
        Dim CNAE_DESCRICAO As String = m.ConvertText(Retorno.CNAEDescricao)

        'POSTA NA PÁGINA
        CNPJ.Value = strCNPJ
        txt_NOME_FANTASIA.Value = NOME_FANTASIA
        txt_RAZAO_SOCIAL.Value = RAZAO_SOCIAL
        txt_ENDERECO.Value = ENDERECO
        txt_NUMERO.Value = NUMERO
        txt_COMPLEMENTO.Value = COMPLEMENTO
        txt_BAIRRO.Value = BAIRRO
        txt_CEP.Value = CEP
        txt_CIDADE.Value = CIDADE
        txt_UF.Value = ESTADO
        txt_COD_IBGE_7.Value = COD_IBGE
        txt_COD_NATUREZA_JURIDICA.Value = COD_NATUREZA_JURIDICA
        txt_NATUREZA_JURIDICA_DESCRICAO.Value = NATUREZA_JURIDICA_DESCRICAO
        txt_CNAE.Value = CNAE
        txt_CNAE_DESCRICAO.Value = CNAE_DESCRICAO
        Exit Sub
Err_Consulta_RF:
        m.Alert(Me, Err.Number & " - " & Err.Description, False, "")
    End Sub

    Private Sub cmd_Gravar_ServerClick(sender As Object, e As EventArgs) Handles cmd_Gravar.ServerClick
        Dim SQL As String = ""
        SQL &= "INSERT INTO [dbo].[TBL_ESTABELECIMENTOS]"
        SQL &= "([CNPJ]"
        SQL &= ",[NOME_FANTASIA],[RAZAO_SOCIAL]"
        SQL &= ",[LOGRADOURO],[NUMERO],[COMPLEMENTO],[BAIRRO]"
        SQL &= ",[CEP],[MUNICIPIO_ID]"
        SQL &= ",[NATUREZA_ID]"
        SQL &= ",[INCLUSAO_EMAIL])"
        SQL &= " VALUES ("
        SQL &= "'" & s.Formata_CNPJ(CNPJ.Value) & "',"
        SQL &= "'" & txt_NOME_FANTASIA.Value & "',"
        SQL &= "'" & txt_RAZAO_SOCIAL.Value & "',"
        SQL &= "'" & txt_ENDERECO.Value & "',"
        SQL &= "'" & txt_NUMERO.Value & "',"
        SQL &= "'" & txt_COMPLEMENTO.Value & "',"
        SQL &= "'" & txt_BAIRRO.Value & "',"
        SQL &= "'" & txt_CEP.Value & "',"
        SQL &= "'" & txt_COD_IBGE_7.Value & "',"
        SQL &= "'" & txt_COD_NATUREZA_JURIDICA.Value & "',"
        SQL &= "'" & Session("EMAIL_LOGIN") & "')"

        If m.ExecuteSQL(SQL) = True Then
            Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect("Select ID From TBL_ESTABELECIMENTOS Where CNPJ = " & CNPJ.Value)
            If dtr.HasRows Then
                dtr.Read()
                Dim ID_ESTABELECIMENTO = dtr("ID")
                m.Alert(Me, "ESTABELECIMENTO CADASTRADO COM SUCESSO", True, "Estabelecimento_Editar.aspx?IdEstabelecimento=" & ID_ESTABELECIMENTO.ToString)
            Else
                m.Alert(Me, "ERRO AO CADASTRAR ESTABELECIMENTO", False, "")
            End If
        End If
    End Sub

End Class
