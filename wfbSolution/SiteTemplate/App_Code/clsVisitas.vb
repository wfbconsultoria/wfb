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
	Public Function sql_visitas_representantes() As String
		Dim sql As String = ""
		sql = ""
		sql &= " SELECT '' AS EMAIL_REPRESENTANTE, '( Selecione )' AS REPRESENTANTE UNION ALL "
		sql &= " SELECT DISTINCT EMAIL_REPRESENTANTE, REPRESENTANTE FROM APP_VISITAS_MEDICOS"
		Select Case HttpContext.Current.Session("NIVEL_LOGIN")
			Case = 0
				sql &= ""
			Case = 1
				sql &= " Where EMAIL_GERENTE  = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
			Case = 3
				sql &= " Where EMAIL_REPRESENTANTE = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
		End Select
		sql &= " ORDER BY REPRESENTANTE  "
		sql_visitas_representantes = sql
	End Function
	Public Function sql_visitas_anos() As String
		Dim sql As String = ""
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

	Public Function sql_visitas_objetivos() As String
		Dim sql As String = ""
		sql = ""
		sql &= " SELECT '' AS COD_OBJETIVO, '( Selecione )' AS OBJETIVO UNION ALL "
		sql &= " SELECT CONVERT(VARCHAR, COD_OBJETIVO) AS COD_OBJETIVO, OBJETIVO FROM TBL_VISITAS_OBJETIVOS "
		sql &= " ORDER BY OBJETIVO "
		sql_visitas_objetivos = sql
	End Function

	Public Function sql_visitas_avaliacoes() As String
		Dim sql As String = ""
		sql = ""
		sql &= " SELECT '' AS COD_AVALIACAO, '( Selecione )' AS AVALIACAO UNION ALL "
		sql &= " SELECT CONVERT(VARCHAR, COD_AVALIACAO) AS COD_AVALIACAO, AVALIACAO FROM TBL_VISITAS_AVALIACOES "
		sql &= " ORDER BY AVALIACAO "
		sql_visitas_avaliacoes = sql
	End Function

	Public Function sql_visitas_linhas() As String
		Dim sql As String = ""
		sql = ""
		sql &= " SELECT '' AS COD_LINHA, '( Selecione )' AS LINHA UNION ALL "
		sql &= " SELECT COD_LINHA, LINHA FROM TBL_PRODUTOS_LINHAS "
		sql &= " ORDER BY LINHA "
		sql_visitas_linhas = sql
	End Function

	Public Function sql_visitas_formas() As String
		Dim sql As String = ""
		sql = ""
		sql &= " SELECT '' AS COD_FORMA, '( Selecione )' AS FORMA UNION ALL "
		sql &= " SELECT CONVERT(VARCHAR,COD_FORMA) as COD_FORMA, FORMA FROM TBL_VISITAS_FORMA "
		sql_visitas_formas = sql
	End Function

	Public Function sql_visitas_tipos() As String
		Dim sql As String = ""
		sql = ""
		sql &= " SELECT '' AS COD_TIPO, '( Selecione )' AS TIPO UNION ALL "
		sql &= " SELECT CONVERT(VARCHAR,COD_TIPO) as COD_TIPO, TIPO FROM TBL_VISITAS_TIPOS "
		sql &= " ORDER BY TIPO "
		sql_visitas_tipos = sql
	End Function

End Class
