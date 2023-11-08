Imports Microsoft.VisualBasic

Public Class clsEstabelecimentos
	Public Function sql_Estabelecimentos(tipo As String, Optional id As String = "") As String
		sql_Estabelecimentos = ""
		sql_Estabelecimentos &= " SELECT "
		sql_Estabelecimentos &= " TBL_ESTABELECIMENTOS_BIH.ID AS Id "
		sql_Estabelecimentos &= " ,TBL_ESTABELECIMENTOS_BIH.CNPJ AS CNPJ "
		sql_Estabelecimentos &= " ,TBL_ESTABELECIMENTOS_BIH.ESTABELECIMENTO AS Estabelecimento "
		sql_Estabelecimentos &= " ,TBL_ESTABELECIMENTOS_BIH.ENDERECO AS Endereco "
		sql_Estabelecimentos &= " ,TBL_ESTABELECIMENTOS_BIH.COMPLEMENTO AS Complemento "
		sql_Estabelecimentos &= " ,TBL_ESTABELECIMENTOS_BIH.BAIRRO AS Bairro "
		sql_Estabelecimentos &= " ,TBL_ESTABELECIMENTOS_BIH.CEP AS CEP "
		sql_Estabelecimentos &= " ,TBL_IBGE_MUNICIPIOS.MUNICIPIO AS Cidade "
		sql_Estabelecimentos &= " ,TBL_IBGE_MUNICIPIOS.UF AS UF "
		sql_Estabelecimentos &= " ,TBL_SETORIZACAO_SETORES.ID_SETOR AS Id_Setor "
		sql_Estabelecimentos &= " ,TBL_SETORIZACAO_SETORES.SETOR AS Setor "
		sql_Estabelecimentos &= " ,TBL_SETORIZACAO_SETORES.EMAIL_RESPONSAVEL AS Email_Representante "
		sql_Estabelecimentos &= " ,REPRESENTANTES.NOME AS Representante "
		sql_Estabelecimentos &= " ,TBL_SETORIZACAO_REGIONAIS.ID_REGIONAL AS Id_Regional "
		sql_Estabelecimentos &= " ,TBL_SETORIZACAO_REGIONAIS.EMAIL_RESPONSAVEL AS Email_Gerente "
		sql_Estabelecimentos &= " ,GERENTES.NOME AS Gerente "
		sql_Estabelecimentos &= " ,TBL_ESTABELECIMENTOS_BIH.ID_GRUPO_ESTABELECIMENTO AS Id_Grupo "
		sql_Estabelecimentos &= " ,TBL_ESTABELECIMENTOS_GRUPOS.GRUPO AS Grupo "
		sql_Estabelecimentos &= " ,TBL_ESTABELECIMENTOS_BIH.COD_ESFERA AS Cod_Esfera "
		sql_Estabelecimentos &= " ,TBL_ESTABELECIMENTOS_ESFERA.ESFERA AS Esfera "
		sql_Estabelecimentos &= " ,TBL_ESTABELECIMENTOS_BIH.ID_GRUPO_DISTRIBUIDOR AS Id_Grupo_Distribuidor "
		sql_Estabelecimentos &= " ,TBL_DISTRIBUIDORES_GRUPOS.GRUPO_DISTRIBUIDOR AS [Grupo Distribuidor] "

		sql_Estabelecimentos &= " FROM "
		sql_Estabelecimentos &= " TBL_IBGE_MUNICIPIOS INNER JOIN TBL_ESTABELECIMENTOS_BIH "
		sql_Estabelecimentos &= " ON TBL_IBGE_MUNICIPIOS.COD_IBGE_7 = TBL_ESTABELECIMENTOS_BIH.COD_IBGE_7 "
		sql_Estabelecimentos &= " INNER JOIN TBL_SETORIZACAO_SETORES "
		sql_Estabelecimentos &= " ON TBL_ESTABELECIMENTOS_BIH.COD_DISTRITO = TBL_SETORIZACAO_SETORES.COD_DISTRITO "
		sql_Estabelecimentos &= " AND TBL_ESTABELECIMENTOS_BIH.COD_REGIONAL = TBL_SETORIZACAO_SETORES.COD_REGIONAL "
		sql_Estabelecimentos &= " AND TBL_ESTABELECIMENTOS_BIH.COD_SETOR = TBL_SETORIZACAO_SETORES.COD_SETOR "
		sql_Estabelecimentos &= " INNER JOIN TBL_USUARIOS AS REPRESENTANTES "
		sql_Estabelecimentos &= " ON TBL_SETORIZACAO_SETORES.EMAIL_RESPONSAVEL = REPRESENTANTES.EMAIL "
		sql_Estabelecimentos &= " INNER JOIN TBL_SETORIZACAO_REGIONAIS	"
		sql_Estabelecimentos &= " ON TBL_SETORIZACAO_SETORES.COD_REGIONAL = TBL_SETORIZACAO_REGIONAIS.COD_REGIONAL "
		sql_Estabelecimentos &= " INNER JOIN TBL_USUARIOS AS GERENTES "
		sql_Estabelecimentos &= " ON TBL_SETORIZACAO_REGIONAIS.EMAIL_RESPONSAVEL = GERENTES.EMAIL "
		sql_Estabelecimentos &= " INNER JOIN TBL_ESTABELECIMENTOS_ESFERA "
		sql_Estabelecimentos &= " ON TBL_ESTABELECIMENTOS_BIH.COD_ESFERA = TBL_ESTABELECIMENTOS_ESFERA.COD_ESFERA "
		sql_Estabelecimentos &= " INNER JOIN TBL_ESTABELECIMENTOS_GRUPOS "
		sql_Estabelecimentos &= " ON TBL_ESTABELECIMENTOS_BIH.ID_GRUPO_ESTABELECIMENTO = TBL_ESTABELECIMENTOS_GRUPOS.ID_GRUPO "
		sql_Estabelecimentos &= " LEFT JOIN TBL_DISTRIBUIDORES_GRUPOS "
		sql_Estabelecimentos &= " ON TBL_ESTABELECIMENTOS_BIH.ID_GRUPO_DISTRIBUIDOR = TBL_DISTRIBUIDORES_GRUPOS.ID_GRUPO_DISTRIBUIDOR "

		If tipo = "lista" Then
			Select Case HttpContext.Current.Session("NIVEL_LOGIN")
				Case = 3
					sql_Estabelecimentos &= " Where TBL_SETORIZACAO_SETORES.EMAIL_RESPONSAVEL = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
			End Select
			sql_Estabelecimentos &= " Order By TBL_ESTABELECIMENTOS_BIH.ESTABELECIMENTO "
		End If

		If tipo = "ficha" Then

			sql_Estabelecimentos &= " Where TBL_ESTABELECIMENTOS_BIH.ID = '" & id & "'"

		End If

	End Function
End Class
