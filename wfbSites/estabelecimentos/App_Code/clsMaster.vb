Imports Microsoft.VisualBasic
Imports System.Data

Public Class clsMaster
    Public cnn As System.Data.SqlClient.SqlConnection

    Public Function ConectaBanco() As Boolean
        On Error GoTo Err_ConectaBanco
        ConectaBanco = False
        cnn = New System.Data.SqlClient.SqlConnection
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()
        ConectaBanco = True
        Exit Function
Err_ConectaBanco:
        ConectaBanco = False
    End Function
    Public Function ExecutarSQL(ByVal SQL As String) As Boolean
        Dim cn As New System.Data.SqlClient.SqlConnection
        Dim cmd As System.Data.SqlClient.SqlCommand = cn.CreateCommand
        On Error GoTo Err_AbreTabela
        ExecutarSQL = False
        cn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cmd.CommandText = SQL
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        ExecutarSQL = True
        Return True
        Exit Function
Err_AbreTabela:
        ExecutarSQL = False
        Return False
    End Function

    Public Function ExecuteSelect(ByVal SQL As String) As System.Data.SqlClient.SqlDataReader
        On Error GoTo Err_ExcuteSelect
        ExecuteSelect = Nothing

        If Not IsNothing(cnn) Then
            If cnn.State = ConnectionState.Open Then cnn.Close()
        End If

        ConectaBanco()

        Dim cmd As System.Data.SqlClient.SqlCommand = cnn.CreateCommand
        cmd.Connection = cnn
        cmd.CommandText = SQL
        ExecuteSelect = cmd.ExecuteReader
        Exit Function

Err_ExcuteSelect:
        ExecuteSelect = Nothing
    End Function

    Public Function CheckExists(ByVal Table As String, ByVal KeyColumn As String, ByVal Parameter As String) As Boolean
        On Error GoTo Err_CheckExists

        CheckExists = False
        Dim d As System.Data.SqlClient.SqlDataReader
        Dim sql As String

        sql = "Select * From [" & Table & "] Where [" & KeyColumn & "] = '" & Parameter & "'"
        d = ExecuteSelect(sql)

        If d.HasRows Then CheckExists = True

        Exit Function
Err_CheckExists:
        CheckExists = False
    End Function

    Public Function Converte_Valor(ByVal strValor As String) As String
        'LIMPA STRING QE VAO SER USADS COMO VALOR
        Converte_Valor = 0
        If IsDBNull(strValor) Then strValor = "0"
        If strValor = "" Then strValor = "0"
        strValor = Replace(strValor, ".", "")
        strValor = Replace(strValor, "/", "")
        strValor = Replace(strValor, "\", "")
        strValor = Replace(strValor, "-", "")
        strValor = Replace(strValor, ",", "")
        strValor = Replace(strValor, " ", "")
        strValor = Replace(strValor, "'", "")
        strValor = Replace(strValor, "-", "")
        strValor = Trim(strValor)
        Converte_Valor = Val(strValor)
    End Function
    
    Public Function ConverteTexto(ByVal Texto As String) As String
        'LIMPA CARACTERES INVALIDOS DO TEXTO E TRANSFORMA EM MAIUSCULO
        If IsDBNull(Texto) Then Texto = ""
        If Len(Texto) = 0 Then Texto = ""

        Texto = Trim(Texto)
        Texto = LCase(Texto)
        Texto = Replace(Texto, "á", "a")
        Texto = Replace(Texto, "à", "a")
        Texto = Replace(Texto, "ã", "a")
        Texto = Replace(Texto, "â", "a")
        Texto = Replace(Texto, "é", "e")
        Texto = Replace(Texto, "è", "e")
        Texto = Replace(Texto, "ê", "e")
        Texto = Replace(Texto, "í", "i")
        Texto = Replace(Texto, "ì", "i")
        Texto = Replace(Texto, "ó", "o")
        Texto = Replace(Texto, "ò", "o")
        Texto = Replace(Texto, "ô", "o")
        Texto = Replace(Texto, "õ", "o")
        Texto = Replace(Texto, "ú", "u")
        Texto = Replace(Texto, "ù", "u")
        Texto = Replace(Texto, "û", "u")
        Texto = Replace(Texto, "'", "")
        Texto = Replace(Texto, "~", "")
        Texto = Replace(Texto, ",", " ")
        Texto = Replace(Texto, "ç", "c")
        Texto = Replace(Texto, Chr(33), "")
        Texto = Replace(Texto, Chr(34), "")
        Texto = UCase(Texto)
        ConverteTexto = Texto
    End Function

End Class

