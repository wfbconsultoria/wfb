Imports Microsoft.VisualBasic

Public Class clsMedicos
    ReadOnly m As New clsMaster


	Public Function sql_medicos(Optional tipo As String = "", Optional id As String = "") As String
		Dim sql As String = ""
		sql &= " SELECT * FROM APP_MEDICOS_ESTABELECIMENTOS "

		If tipo = "lista" Then
			Select Case HttpContext.Current.Session("NIVEL_LOGIN")

				Case = 0
					sql &= sql
				Case = 1
					sql &= " Where EMAIL_GERENTE = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
				Case = 3
					sql &= " Where EMAIL_REPRESENTANTE = '" & HttpContext.Current.Session("EMAIL_LOGIN") & "'"
			End Select
			sql &= " Order By NOME_SOBRENOME "
		End If

		If tipo = "ficha" Then

			sql &= " Where IdMedico = '" & id & "'"

		End If
		sql_medicos = sql
	End Function
	Public Function sql_especialidades(Optional tipo As String = "", Optional id As String = "") As String
		Dim sql As String = ""
		sql = ""
		sql &= " SELECT '' AS ID_ESPECIALIDADE, '( Selecione )' AS ESPECIALIDADE UNION ALL "
		sql &= " SELECT "
		sql &= " CONVERT (VARCHAR, TBL_MEDICOS_ESPECIALIDADES.ID_ESPECIALIDADE) AS ID_ESPECIALIDADE "
		sql &= " ,TBL_MEDICOS_ESPECIALIDADES.ESPECIALIDADE "
		sql &= " FROM "
		sql &= " TBL_MEDICOS_ESPECIALIDADES "

		If tipo = "lista" Then
			sql &= " ORDER BY ESPECIALIDADE "
		End If

		If tipo = "ficha" Then
			sql &= " WHERE TBL_MEDICOS_ESPECIALIDADES.ID_ESPECIALIDADE = '" & id & "'"
		End If
		sql_especialidades = sql

	End Function
	Public Function sql_tipos(Optional tipo As String = "", Optional id As String = "") As String
		Dim sql As String = ""

		sql = ""
		sql &= " SELECT '' AS ID_TIPO, '( Selecione )' AS TIPO UNION ALL "
		sql &= " SELECT "
		sql &= " CONVERT( VARCHAR, TBL_MEDICOS_TIPOS.ID_TIPO ) AS ID_TIPO "
		sql &= " ,TBL_MEDICOS_TIPOS.TIPO "
		sql &= " FROM "
		sql &= " TBL_MEDICOS_TIPOS "

		If tipo = "lista" Then
			sql &= " ORDER BY TIPO "
		End If

		If tipo = "ficha" Then
			sql &= " WHERE TBL_MEDICOS_TIPOS.ID_TIPO = '" & id & "'"
		End If
		sql_tipos = sql

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
