Imports Microsoft.VisualBasic

Public Class clsEstabelecimentos
	Public Function sql_Estabelecimentos(tipo As String, Optional id As String = "") As String
		Dim sql As String = ""
		sql = ""
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

	Public Function sql_estabelecimentos_representantes() As String
		Dim sql As String = ""
		sql = ""
		sql &= " SELECT '' AS EMAIL_REPRESENTANTE, '( Selecione )' AS REPRESENTANTE UNION ALL "
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
				sql &= ""
			Case = 1
				sql &= " Where GERENTES.EMAIL  = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
			Case = 3
				sql &= " Where REPRESENTANTES.EMAIL = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
		End Select
		sql &= " Group BY REPRESENTANTES.EMAIL, REPRESENTANTES.APELIDO "
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
End Class
