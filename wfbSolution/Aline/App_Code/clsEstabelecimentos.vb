Imports System.Net

Imports System.Net.NetworkInformation
Imports Microsoft.VisualBasic
Imports Newtonsoft.Json

Public Class clsEstabelecimentos
	Public Property cnpjStatus As Boolean
	Public Function sql_Estabelecimentos(tipo As String, Optional id As String = "") As String
		Dim sql As String = ""
		sql = ""
		sql &= " SELECT * FROM APP_ESTABELECIMENTOS "
		If tipo = "lista" Then
			Select Case HttpContext.Current.Session("NIVEL_LOGIN")
				Case = 0

				Case = 1
					sql &= " Where EMAIL_GERENTE  = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
				Case = 3
					sql &= " Where EMAIL_REPRESENTANTE = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
			End Select
			sql &= " Order By MEDICOS Desc "
		End If
		If tipo = "ficha" Then
			sql &= " Where Id = '" & id & "'"
		End If
		sql_Estabelecimentos = sql
	End Function

	Public Function sql_classes_estabelecimentos() As String
		Dim sql As String = ""
		sql = ""
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
		'LIMPA STRING QE VAO SER USADS COMO VALOR
		Formata_CNPJ = ""
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
	Public Function consultarCNPJ(strCNPJ As String) As retornoCNPJ
		cnpjStatus = False
		Try
			strCNPJ = Formata_CNPJ(strCNPJ)

			Dim apiURL As String = "https://estabelecimentos-app.azurewebsites.net/soa"

			Dim client = New WebClient()
			client.Headers("Content-Type") = "application/json"
			Dim clientCNPJ As New Dictionary(Of String, Object) From {{"cnpj", strCNPJ}}
			Dim jsonbody As String = JsonConvert.SerializeObject(clientCNPJ)
			Dim responseBytes As Byte() = client.UploadData(apiURL, "POST", Encoding.UTF8.GetBytes(jsonbody))
			Dim responseString As String = Encoding.UTF8.GetString(responseBytes)
			consultarCNPJ = JsonConvert.DeserializeObject(Of retornoCNPJ)(responseString)
			cnpjStatus = True
		Catch
			cnpjStatus = False
			consultarCNPJ = Nothing
		End Try
	End Function

	Public Class Root
		Public Property meta As Meta
		Public Property result As retornoCNPJ
	End Class
	Public Class Meta
		Public Property currentPage As Integer
		Public Property itemsPerPage As Integer
		Public Property totalOfItems As Integer
		Public Property totalOfPages As Integer
	End Class

	Public Class Result
		Public Property street As String
		Public Property complement As String
		Public Property district As String
		Public Property districtId As Integer
		Public Property city As String
		Public Property cityId As Integer
		Public Property ibgeId As Integer
		Public Property state As String
		Public Property stateShortname As String
		Public Property zipcode As String
		Public Property code As String
		<JsonProperty("error")>
		Public Property erro As String

	End Class


	Public Class retornoCNPJ
		<JsonProperty("cnpj")>
		Public Property CNPJ As String

		<JsonProperty("cpf")>
		Public Property CPF As Object

		<JsonProperty("documento")>
		Public Property Documento As String

		<JsonProperty("cod_tipo_pessoa")>
		Public Property CodTipoPessoa As Integer

		<JsonProperty("cnes")>
		Public Property CNES As String

		<JsonProperty("razao_social")>
		Public Property RazaoSocial As String

		<JsonProperty("nome_fantasia")>
		Public Property NomeFantasia As String

		<JsonProperty("data_fundacao")>
		Public Property DataFundacao As String

		<JsonProperty("logradouro")>
		Public Property Logradouro As String

		<JsonProperty("complemento")>
		Public Property Complemento As String

		<JsonProperty("numero")>
		Public Property Numero As String

		<JsonProperty("bairro")>
		Public Property Bairro As String

		<JsonProperty("cep")>
		Public Property CEP As String

		<JsonProperty("cidade")>
		Public Property Cidade As String

		<JsonProperty("estado")>
		Public Property Estado As String

		<JsonProperty("cod_ibge")>
		Public Property CodIBGE As String

		<JsonProperty("cod_natureza_juridica")>
		Public Property CodNaturezaJuridica As String

		<JsonProperty("natureza_juridica_descricao")>
		Public Property NaturezaJuridicaDescricao As String

		<JsonProperty("cod_cnae")>
		Public Property CodCNAE As String

		<JsonProperty("cnae_descricao")>
		Public Property CNAEDescricao As String

		<JsonProperty("situacao_rfb")>
		Public Property SituacaoRFB As String

		<JsonProperty("motivo_rfb")>
		Public Property MotivoRFB As String

		<JsonProperty("motivo_especial_rfb")>
		Public Property MotivoEspecialRFB As String

		<JsonProperty("data_rfb")>
		Public Property DataRFB As String

		<JsonProperty("inclusao_email")>
		Public Property InclusaoEmail As String

		<JsonProperty("inclusao_data")>
		Public Property InclusaoData As String

		<JsonProperty("manual")>
		Public Property Manual As String
	End Class



End Class
