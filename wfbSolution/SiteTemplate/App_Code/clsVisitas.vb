Imports Microsoft.VisualBasic

Public Class clsVisitas

	Public Function sql_visitas(Optional tipo As String = "", Optional ID_VISITA As String = "") As String
		Dim sql As String = ""
		sql = ""
		sql &= " SELECT * FROM APP_VISITAS_MEDICOS"

		If tipo = "lista" Then
			Select Case HttpContext.Current.Session("NIVEL_LOGIN")
				Case = 0
					sql &= ""
				Case = 1
					sql &= " Where EMAIL_GERENTE  = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
				Case = 3
					sql &= " Where EMAIL_REPRESENTANTE = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
			End Select
		End If

		If tipo = "ficha" Then
			sql &= " WHERE ID_VISITA = '" & ID_VISITA & "'"
		End If
		sql &= " ORDER BY DATA_VISITA  "

		sql_visitas = sql

	End Function

	Public Function sql_visitas_representantes(Optional tipo As String = "", Optional EMAIL_REPRESENTANTE As String = "") As String
		Dim sql As String = ""
		sql = ""

		sql = ""
		sql &= " SELECT '' AS EMAIL_REPRESENTANTE, '( Selecione )' AS REPRESENTANTE UNION ALL "
		sql &= " SELECT DISTINCT EMAIL_REPRESENTANTE, REPRESENTANTE FROM APP_VISITAS_MEDICOS"

		If tipo = "lista" Then
			Select Case HttpContext.Current.Session("NIVEL_LOGIN")
				Case = 0
					sql &= ""
				Case = 1
					sql &= " Where EMAIL_GERENTE  = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
				Case = 3
					sql &= " Where EMAIL_REPRESENTANTE = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
			End Select
		End If

		If tipo = "ficha" Then
			sql &= " WHERE EMAIL_REPRESENTANTE = '" & EMAIL_REPRESENTANTE & "'"
		End If
		sql &= " ORDER BY REPRESENTANTE  "

		sql_visitas_representantes = sql

	End Function

	Public Function sql_visitas_anos() As String
		Dim sql As String = ""
		sql = ""

		sql = ""
		sql &= " SELECT '' AS ANO, '( Selecione )' AS ANO_DESC UNION ALL "
		sql &= " SELECT DISTINCT CONVERT(VARCHAR, APP_VISITAS_MEDICOS.ANO) AS ANO, CONVERT(VARCHAR, APP_VISITAS_MEDICOS.ANO) AS ANO_DESC "
		sql &= " FROM APP_VISITAS_MEDICOS "

		Select Case HttpContext.Current.Session("NIVEL_LOGIN")
			Case = 0
				sql &= ""
			Case = 1
				sql &= " Where EMAIL_GERENTE  = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
			Case = 3
				sql &= " Where EMAIL_REPRESENTANTE = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
		End Select
		sql &= " ORDER BY ANO  "

		sql_visitas_anos = sql

	End Function

	Public Function sql_visitas_meses() As String
		Dim sql As String = ""
		sql = ""

		sql = ""
		sql &= " SELECT '' AS MES, '( Selecione )' AS MES_SIGLA UNION ALL "

		sql &= " SELECT DISTINCT CONVERT(VARCHAR, APP_VISITAS_MEDICOS.MES) AS MES, TBL_DATAS_MESES.Mes_Sigla AS MES_SIGLA "
		sql &= " FROM APP_VISITAS_MEDICOS INNER JOIN TBL_DATAS_MESES ON APP_VISITAS_MEDICOS.MES = TBL_DATAS_MESES.Mes_Numero "


		Select Case HttpContext.Current.Session("NIVEL_LOGIN")
			Case = 0
				sql &= ""
			Case = 1
				sql &= " Where EMAIL_GERENTE  = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
			Case = 3
				sql &= " Where EMAIL_REPRESENTANTE = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
		End Select

		sql &= " ORDER BY MES  "

		sql_visitas_meses = sql

	End Function

	Public Function sql_visitas_objetivos(Optional tipo As String = "", Optional COD_OBJETIVO As String = "") As String
		Dim sql As String = ""
		sql = ""
		sql &= " SELECT '' AS COD_OBJETIVO, '( Selecione )' AS OBJETIVO UNION ALL "
		sql &= " SELECT CONVERT(VARCHAR, COD_OBJETIVO) AS COD_OBJETIVO, OBJETIVO FROM TBL_VISITAS_OBJETIVOS "

		If tipo = "lista" Then
			sql &= " ORDER BY OBJETIVO "
		End If

		If tipo = "ficha" Then
			sql &= " WHERE COD_OBJETIVO = '" & COD_OBJETIVO & "'"
		End If
		sql_visitas_objetivos = sql

	End Function

	Public Function sql_visitas_avaliacoes(Optional tipo As String = "", Optional COD_AVALIACAO As String = "") As String
		Dim sql As String = ""
		sql = ""
		sql &= " SELECT '' AS COD_AVALIACAO, '( Selecione )' AS AVALIACAO UNION ALL "
		sql &= " SELECT CONVERT(VARCHAR, COD_AVALIACAO) AS COD_AVALIACAO, AVALIACAO FROM TBL_VISITAS_AVALIACOES "

		If tipo = "lista" Then
			sql &= " ORDER BY AVALIACAO "
		End If

		If tipo = "ficha" Then
			sql &= " WHERE COD_AVALIACAO = '" & COD_AVALIACAO & "'"
		End If
		sql_visitas_avaliacoes = sql

	End Function

	Public Function sql_visitas_linhas(Optional tipo As String = "", Optional COD_LINHA As String = "") As String
		Dim sql As String = ""
		sql = ""
		sql &= " SELECT '' AS COD_LINHA, '( Selecione )' AS LINHA UNION ALL "
		sql &= " SELECT COD_LINHA, LINHA FROM TBL_PRODUTOS_LINHAS "

		If tipo = "lista" Then
			sql &= " WHERE ANALISAR = 1 OR COD_LINHA = '000'"
		End If

		If tipo = "ficha" Then
			sql &= " WHERE COD_LINHA = '" & COD_LINHA & "'"
		End If
		sql &= " ORDER BY LINHA "
		sql_visitas_linhas = sql

	End Function

	Public Function sql_visitas_formas(Optional tipo As String = "", Optional COD_FORMA As String = "") As String
		Dim sql As String = ""
		sql = ""
		sql &= " SELECT '' AS COD_FORMA, '( Selecione )' AS FORMA UNION ALL "
		sql &= " SELECT CONVERT(VARCHAR,COD_FORMA) as COD_FORMA, FORMA FROM TBL_VISITAS_FORMA "

		If tipo = "lista" Then
			sql &= " ORDER BY FORMA "
		End If

		If tipo = "ficha" Then
			sql &= " WHERE COD_FORMA = '" & COD_FORMA & "'"
		End If

		sql_visitas_formas = sql

	End Function

	Public Function sql_visitas_tipos(Optional tipo As String = "", Optional COD_TIPO As String = "") As String
		Dim sql As String = ""
		sql = ""
		sql &= " SELECT '' AS COD_TIPO, '( Selecione )' AS TIPO UNION ALL "
		sql &= " SELECT CONVERT(VARCHAR,COD_TIPO) as COD_TIPO, TIPO FROM TBL_VISITAS_TIPOS "

		If tipo = "lista" Then
			sql &= " ORDER BY TIPO "
		End If

		If tipo = "ficha" Then
			sql &= " WHERE COD_TIPO = '" & COD_TIPO & "'"
		End If

		sql_visitas_tipos = sql

	End Function

End Class
