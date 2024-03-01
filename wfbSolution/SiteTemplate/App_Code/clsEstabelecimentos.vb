Imports Microsoft.VisualBasic

Public Class clsEstabelecimentos
	Public Function sql_Estabelecimentos(tipo As String, Optional id As String = "") As String
		Dim sql As String = ""
		sql &= " SELECT * FROM APP_ESTABELECIMENTOS "

		If tipo = "lista" Then
			Select Case HttpContext.Current.Session("NIVEL_LOGIN")

				Case = 0
					'sql &= " Where TBL_ESTABELECIMENTOS_BIH.CNPJ = '01571702000198'"
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


End Class
