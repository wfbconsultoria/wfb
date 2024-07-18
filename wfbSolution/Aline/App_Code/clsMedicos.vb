
Public Class clsMedicos
    ReadOnly m As New clsMaster

	Public Function sql_medicos(Optional tipo As String = "", Optional id As String = "") As String
		Dim sql As String = ""
		sql &= " SELECT * FROM APP_MEDICOS "

		If tipo = "lista" Then
			Select Case HttpContext.Current.Session("NIVEL_LOGIN")
				Case = 0

				Case = 1
					sql &= " Where EMAIL_GERENTE = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "' "
				Case = 3
					sql &= " Where EMAIL_REPRESENTANTE = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "' "
			End Select

			sql &= " Order By NOME_SOBRENOME "
		End If

		If tipo = "ficha" Then
			sql &= " Where IdMedico = '" & id & "'"
		End If

		sql_medicos = sql
	End Function

	Public Function sql_medicos_estabelecimentos(Optional tipo As String = "", Optional id As String = "") As String
		Dim sql As String = ""
		sql &= " SELECT * FROM APP_MEDICOS_ESTABELECIMENTOS "

		If tipo = "lista" Then
			Select Case HttpContext.Current.Session("NIVEL_LOGIN")
				Case = 0

				Case = 1
					sql &= " Where EMAIL_GERENTE = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "' "
				Case = 3
					sql &= " Where EMAIL_REPRESENTANTE = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "' "
			End Select

			sql &= " Order By NOME_SOBRENOME "
		End If

		If tipo = "ficha" Then
			sql &= " Where  = '" & id & "'"
		End If

		sql_medicos_estabelecimentos = sql
	End Function
	Public Function sql_especialidades() As String
		Dim sql As String = ""
		sql &= " SELECT '' AS ID_ESPECIALIDADE, '( Selecione )' AS ESPECIALIDADE UNION ALL "
		sql &= " SELECT "
		sql &= " CONVERT (VARCHAR, TBL_MEDICOS_ESPECIALIDADES.ID_ESPECIALIDADE) AS ID_ESPECIALIDADE "
		sql &= " ,TBL_MEDICOS_ESPECIALIDADES.ESPECIALIDADE "
		sql &= " FROM "
		sql &= " TBL_MEDICOS_ESPECIALIDADES "
		sql &= " ORDER BY ESPECIALIDADE "

		sql_especialidades = sql
	End Function
	Public Function sql_funcoes() As String

		Dim sql As String = ""
		sql &= " SELECT '' AS ID_FUNCAO, '( Selecione )' AS FUNCAO UNION ALL "
		sql &= " SELECT "
		sql &= " CONVERT( VARCHAR, TBL_MEDICOS_FUNCOES.ID_FUNCAO ) AS ID_FUNCAO "
		sql &= " ,TBL_MEDICOS_FUNCOES.FUNCAO "
		sql &= " FROM "
		sql &= " TBL_MEDICOS_FUNCOES "
		sql &= " ORDER BY FUNCAO "

		sql_funcoes = sql
	End Function
	Public Function sql_tipos() As String
		Dim sql As String = ""
		sql &= " SELECT '' AS ID_TIPO, '( Selecione )' AS TIPO UNION ALL "
		sql &= " SELECT "
		sql &= " CONVERT( VARCHAR, TBL_MEDICOS_TIPOS.ID_TIPO ) AS ID_TIPO "
		sql &= " ,TBL_MEDICOS_TIPOS.TIPO "
		sql &= " FROM "
		sql &= " TBL_MEDICOS_TIPOS "
		sql &= " ORDER BY TIPO "

		sql_tipos = sql
	End Function
	Public Function sql_tipos_contatos() As String
		Dim sql As String = ""
		sql &= " SELECT '( Todos )' AS TIPO_CONTATO UNION ALL "
		sql &= " SELECT DISTINCT TIPO_CONTATO FROM APP_MEDICOS_ESTABELECIMENTOS "

		Select Case HttpContext.Current.Session("NIVEL_LOGIN")
			Case = 0
				'sql &= Where MEDICO_ATIVO_NO_ESTABELECIMENTO = 1
			Case = 1
				sql &= " Where EMAIL_GERENTE = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "' " '& And MEDICO_ATIVO_NO_ESTABELECIMENTO = 1
			Case = 3
				sql &= " Where EMAIL_REPRESENTANTE = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "' " '& And MEDICO_ATIVO_NO_ESTABELECIMENTO = 1
		End Select

		sql &= " Order By TIPO_CONTATO "

		sql_tipos_contatos = sql
	End Function

	Public Function sql_motivo_inativar() As String
		Dim sql As String = ""
		sql &= " SELECT * FROM TBL_MEDICOS_MOTIVO_INATIVAR ORDER BY ID_MOTIVO "
		sql_motivo_inativar = sql
	End Function
	Public Function FormatCRM(CRM As String) As String
		Dim CRM_Numero As Integer
		For Each A In CRM
			If Integer.TryParse(A, CRM_Numero) Then
			Else
				Replace(CRM, A, "")
            End If
        Next

        CRM = Replace(CRM, " ", "")
        If IsDBNull(CRM) Or CRM = "" Or Len(Trim(CRM)) = 0 Then
            FormatCRM = "00000000"
        Else
            FormatCRM = Right("00000000" & CRM, 8)
        End If
    End Function

End Class
