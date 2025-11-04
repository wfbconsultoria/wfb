Imports System.Globalization
Imports System.Net
Imports System.Net.Http
Imports System.Security.Policy
Imports Microsoft.VisualBasic
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Public Class clsEstabelecimentos
    ReadOnly m As New clsMaster
    ReadOnly c As New clsCEP
    Public Function sql_Estabelecimentos(tipo As String, Optional id As String = "") As String

        Dim sql As String = " SELECT * FROM VIEW_ESTABELECIMENTOS "
        If tipo = "lista" Then
            Select Case HttpContext.Current.Session("NIVEL_LOGIN")
                Case = 0

                Case = 1
                    sql &= " Where EMAIL_GERENTE  = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
                Case = 3
                    sql &= " Where EMAIL_REPRESENTANTE = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
            End Select
            sql &= " Order By ESTABELECIMENTO_CNPJ "
        End If
        If tipo = "ficha" Then
            sql &= " Where Id = '" & id & "'"
        End If
        sql_Estabelecimentos = sql
    End Function

    Public Function sql_classes_estabelecimentos() As String
        Dim sql As String = ""
        'sql &= " SELECT '' AS COD_CLASSE_ESTABELECIMENTO, '( Selecione )' AS CLASSE_ESTABELECIMENTO UNION ALL "
        sql &= " SELECT "
        sql &= " CONVERT (VARCHAR, COD_CLASSE_ESTABELECIMENTO) AS COD_CLASSE_ESTABELECIMENTO "
        sql &= " ,CLASSE_ESTABELECIMENTO "
        sql &= " FROM "
        sql &= " TBL_ESTABELECIMENTOS_CLASSES "
        sql &= " ORDER BY CLASSE_ESTABELECIMENTO "
        sql_classes_estabelecimentos = sql
    End Function

    Public Function sql_UF() As String
        sql_UF = ""
        sql_UF &= " Select '' as UF,  '( Selecione )' as ESTADO Union All"
        sql_UF &= " Select UF, ESTADO From TBL_IBGE_ESTADOS Where UF <> '00' And UF <> 'XX' Order By ESTADO"
    End Function

    Public Function sql_estabelecimentos_representantes() As String
        Dim sql As String = ""
        sql &= " SELECT  REPRESENTANTES.EMAIL AS EMAIL_REPRESENTANTE, REPRESENTANTES.APELIDO AS REPRESENTANTE "
        sql &= " FROM TBL_ESTABELECIMENTOS AS ESTABELECIMENTOS "
        sql &= " INNER JOIN TBL_SETORIZACAO_SETORES AS SETORES "
        sql &= " ON ESTABELECIMENTOS.ID_SETOR_DEMANDA = SETORES.ID_SETOR"
        sql &= " INNER JOIN TBL_USUARIOS AS REPRESENTANTES "
        sql &= " ON SETORES.EMAIL_RESPONSAVEL = REPRESENTANTES.EMAIL "
        sql &= " INNER JOIN TBL_SETORIZACAO_REGIONAIS AS REGIONAIS "
        sql &= " On SETORES.COD_REGIONAL = REGIONAIS.COD_REGIONAL "
        sql &= " INNER JOIN TBL_USUARIOS AS GERENTES "
        sql &= " On REGIONAIS.EMAIL_RESPONSAVEL = GERENTES.EMAIL "
        Select Case HttpContext.Current.Session("NIVEL_LOGIN")
            Case = 0
                sql &= " Group BY REPRESENTANTES.EMAIL, REPRESENTANTES.APELIDO "
                sql &= " UNION ALL SELECT '' AS EMAIL_REPRESENTANTE, '( Selecione )' AS REPRESENTANTE "
            Case = 1
                sql &= " Where GERENTES.EMAIL  = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
                sql &= " Group BY REPRESENTANTES.EMAIL, REPRESENTANTES.APELIDO "
                sql &= " UNION ALL SELECT '' AS EMAIL_REPRESENTANTE, '( Selecione )' AS REPRESENTANTE"
            Case = 3
                sql &= " Where REPRESENTANTES.EMAIL = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
                sql &= " Group BY REPRESENTANTES.EMAIL, REPRESENTANTES.APELIDO "
        End Select

        sql &= " ORDER BY REPRESENTANTE  "
        sql_estabelecimentos_representantes = sql
    End Function

    Public Function Formata_CNPJ(strCNPJ As String) As String
        'LIMPA STRING QE VAO SER USADA COMO VALOR

        If IsDBNull(strCNPJ) Then strCNPJ = ""
        If strCNPJ = "" Then strCNPJ = ""
        strCNPJ = Replace(strCNPJ, ".", "")
        strCNPJ = Replace(strCNPJ, "/", "")
        strCNPJ = Replace(strCNPJ, "\", "")
        strCNPJ = Replace(strCNPJ, "-", "")
        strCNPJ = Replace(strCNPJ, ",", "")
        strCNPJ = Replace(strCNPJ, " ", "")
        strCNPJ = Replace(strCNPJ, "'", "")
        strCNPJ = Replace(strCNPJ, "-", "")
        strCNPJ = Trim(strCNPJ)
        Dim tamanhoCNPJ = Len(strCNPJ)
        Dim str As String = "00000000000000"
        strCNPJ = Left(str, 14 - tamanhoCNPJ) & strCNPJ
        Formata_CNPJ = strCNPJ
    End Function

    Public Sub ConsultarCNPJ(sCNPJ As String)

        Dim strCNPJ As String = Formata_CNPJ(sCNPJ)

        'Consulta API
        Dim strUser = ConfigurationManager.AppSettings("SoaWebServices.User")
        Dim strPassword = ConfigurationManager.AppSettings("SoaWebServices.Password")
        Dim url As String = "https://services.soawebservices.com.br/api/v2/CDC/PessoaJuridicaNFe"
        Dim sb As New StringBuilder()
        sb.AppendLine("{")
        sb.AppendLine("  ""Credenciais"": {")
        sb.AppendLine("    ""Email"": """ & strUser & """,")
        sb.AppendLine("    ""Senha"": """ & strPassword & """")
        sb.AppendLine("  },")
        sb.AppendLine("  ""Documento"": """ & strCNPJ & """")
        sb.AppendLine("}")
        Dim jsonBody As String = sb.ToString()

        'Envia requisicao
        Dim client As New HttpClient()
        client.DefaultRequestHeaders.Accept.Clear()
        client.DefaultRequestHeaders.Accept.Add(New Headers.MediaTypeWithQualityHeaderValue("application/json"))
        Dim content As New StringContent(jsonBody, Encoding.UTF8, "application/json-patch+json")

        'Recebe resultado
        Dim response As HttpResponseMessage = client.PostAsync(url, content).Result
        If response.IsSuccessStatusCode Then
            Dim responseBody As String = response.Content.ReadAsStringAsync().Result

            'Parse JSON
            Dim jsonObj As JObject = JObject.Parse(responseBody)

            'Transacao
            Dim Transacao = jsonObj("Transacao")
            If Transacao IsNot Nothing AndAlso Transacao.HasValues Then
                Dim sTransacao = Transacao
                Status = sTransacao("Status").ToObject(Of Boolean)()
                CodigoStatus = sTransacao("CodigoStatus").ToString()
                CodigoStatusDescricao = sTransacao("CodigoStatusDescricao").ToString()
            Else
                Status = False
                CodigoStatus = ""
                CodigoStatusDescricao = ""
            End If

            'Empresa
            Documento = jsonObj("Documento").ToString()
            RazaoSocial = m.ConvertText(jsonObj("RazaoSocial").ToString(), clsMaster.TextCaseOptions.UpperCase)
            NomeFantasia = m.ConvertText(jsonObj("NomeFantasia").ToString(), clsMaster.TextCaseOptions.UpperCase)
            If Len(NomeFantasia) = 0 Then NomeFantasia = RazaoSocial
            CodigoNaturezaJuridica = m.ConvertText(jsonObj("CodigoNaturezaJuridica").ToString(), clsMaster.TextCaseOptions.UpperCase)
            CodigoNaturezaJuridicaDescricao = m.ConvertText(jsonObj("CodigoNaturezaJuridicaDescricao").ToString(), clsMaster.TextCaseOptions.UpperCase)
            CodigoAtividadeEconomica = m.ConvertText(jsonObj("CodigoAtividadeEconomica").ToString(), clsMaster.TextCaseOptions.UpperCase)
            CodigoAtividadeEconomicaDescricao = m.ConvertText(jsonObj("CodigoAtividadeEconomicaDescricao").ToString(), clsMaster.TextCaseOptions.UpperCase)
            SituacaoRFB = m.ConvertText(jsonObj("SituacaoRFB").ToString(), clsMaster.TextCaseOptions.UpperCase)
            MotivoSituacaoRFB = m.ConvertText(jsonObj("MotivoSituacaoRFB").ToString(), clsMaster.TextCaseOptions.UpperCase)
            DataFundacao = m.ConvertText(jsonObj("DataFundacao").ToString())

            'Endereco
            Dim enderecos = jsonObj("Enderecos")
            If enderecos IsNot Nothing AndAlso enderecos.HasValues Then
                Dim endereco = enderecos(0)
                Dim numeroFormatado As String = If(m.ConvertText(endereco("Numero").ToString()).Length > 0, m.ConvertText(endereco("Numero").ToString()), "S/N")

                Logradouro = m.ConvertText(endereco("Logradouro").ToString(), clsMaster.TextCaseOptions.UpperCase)
                Numero = numeroFormatado
                Bairro = m.ConvertText(endereco("Bairro").ToString(), clsMaster.TextCaseOptions.UpperCase)
                CEP = c.FormatCEP(endereco("CEP").ToString())
                CodigoIBGE = m.ConvertText(endereco("CodigoIBGE").ToString(), clsMaster.TextCaseOptions.UpperCase)
                Cidade = m.ConvertText(endereco("Cidade").ToString(), clsMaster.TextCaseOptions.UpperCase)
                Estado = m.ConvertText(endereco("Estado").ToString(), clsMaster.TextCaseOptions.UpperCase)

                'Converte Latitude e Longitude para string com ponto decimal
                Latitude = endereco("GeoLocalizacao")("Latitude").ToObject(Of Double)()
                Longitude = endereco("GeoLocalizacao")("Longitude").ToObject(Of Double)()
                Latitude = Latitude.Replace(",", ".").Trim().ToString
                Longitude = Longitude.Replace(",", ".").Trim().ToString

                PlusCodes = endereco("GeoLocalizacao")("PlusCodes").ToString()
                Geolocalizacao = Latitude & "," & Longitude
                EnderecoCompleto = m.ConvertText(
                    Logradouro & " " & numeroFormatado & " - " &
                    Bairro & " - " & Cidade & " - " & Estado & " - " & CEP,
                    clsMaster.TextCaseOptions.UpperCase)
            Else
                Logradouro = ""
                Numero = ""
                Bairro = ""
                CEP = ""
                CodigoIBGE = ""
                Cidade = ""
                Estado = ""
                Latitude = ""
                Longitude = ""
                PlusCodes = ""
                Geolocalizacao = ""
                EnderecoCompleto = ""
            End If

            'CNAE
            Dim CNAES = jsonObj("CNAES")
            If CNAES IsNot Nothing AndAlso CNAES.HasValues Then
                Dim sCNAES = CNAES(0)
                CNAECodigo = m.ConvertText(sCNAES("CNAECodigo").ToString(), clsMaster.TextCaseOptions.UpperCase)
                CNAEDescricao = m.ConvertText(sCNAES("CNAEDescricao").ToString(), clsMaster.TextCaseOptions.UpperCase)
                CNAECompleto = m.ConvertText(
                    CNAECodigo & " " & CNAEDescricao,
                    clsMaster.TextCaseOptions.UpperCase)
            Else
                CNAECodigo = ""
                CNAEDescricao = ""
                CNAECompleto = ""
            End If

            'consultarCNPJ = JsonConvert.DeserializeObject(Of retornoCNPJ)(responseBody)
            cnpjStatus = True
        Else
            cnpjStatus = False
        End If

    End Sub

    Public Property cnpjStatus As Boolean
    'Public Class retornoCNPJ
    'Empresa
    Public Property Documento As String
    Public Property RazaoSocial As String
    Public Property NomeFantasia As String
    Public Property DataFundacao As String
    Public Property MatrizFilial As String
    Public Property Capital As Decimal
    Public Property CodigoAtividadeEconomica As String
    Public Property CodigoAtividadeEconomicaDescricao As String
    Public Property CodigoNaturezaJuridica As String
    Public Property CodigoNaturezaJuridicaDescricao As String
    Public Property SituacaoRFB As String
    Public Property DataSituacaoRFB As DateTime
    Public Property DataConsultaRFB As DateTime
    Public Property MotivoSituacaoRFB As String
    Public Property MotivoEspecialSituacaoRFB As String
    Public Property DataMotivoEspecialSituacaoRFB As String
    Public Property CNAECodigo As String
    Public Property CNAEDescricao As String
    Public Property CNAECompleto As String

    'Endereco
    Public Property EnderecoCompleto As String
    Public Property Tipo As Integer
    Public Property Logradouro As String
    Public Property Numero As String
    Public Property Complemento As String
    Public Property Bairro As String
    Public Property Cidade As String
    Public Property Estado As String
    Public Property CEP As String
    Public Property CodigoIBGE As String
    Public Property Latitude As String
    Public Property Longitude As String
    Public Property PlusCodes As String
    Public Property Geolocalizacao As String
    'Transacao
    Public Property Status As Boolean
    Public Property CodigoStatus As String
    Public Property CodigoStatusDescricao As String

    'End Class
End Class
