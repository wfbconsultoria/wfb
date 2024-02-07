Imports Microsoft.VisualBasic

Public Class clsVisitas
	Public Function sql_visitas_objetivos(Optional tipo As String = "", Optional COD_OBJETIVO As String = "") As String
		Dim sql As String = ""
		sql = ""
		sql &= " SELECT '' AS COD_OBJETIVO, '( Selecione )' AS OBJETIVO UNION ALL "
		sql &= " SELECT SELECT CONVERT(VARCHAR COD_OBJETIVO) AS COD_OBJETIVO, OBJETIVO FROM TBL_VISITAS_OBJETIVOS "

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
		sql &= " SELECT CONVERT(VARCHAR COD_AVALIACAO) AS COD_AVALIACAO, AVALIACAO FROM TBL_VISITAS_AVALIACOES "

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
			sql &= " WHERE ANALISAR = 1 "
		End If

		If tipo = "ficha" Then
			sql &= " WHERE COD_LINHA = '" & COD_LINHA & "'"
		End If
		sql &= " ORDER BY LINHA "
		sql_visitas_linhas = sql

	End Function
End Class
