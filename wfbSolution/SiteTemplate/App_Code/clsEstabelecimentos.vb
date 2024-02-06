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

	Public Function sql_UF(Optional tipo As String = "", Optional id As String = "") As String
		sql_UF = ""
		sql_UF &= " Select '' as UF,  '( Selecione )' as ESTADO Union All"
		sql_UF &= " Select UF, ESTADO From TBL_IBGE_ESTADOS Where UF <> '00' And UF <> 'XX' Order By ESTADO"
	End Function



End Class
