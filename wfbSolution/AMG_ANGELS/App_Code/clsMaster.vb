
Imports System.Data

Public Class clsMaster
    Public cnn As System.Data.SqlClient.SqlConnection
    Public Function DatabaseConnect() As Boolean
        On Error GoTo Err_DatabaseConnect

        DatabaseConnect = False
        cnn = New System.Data.SqlClient.SqlConnection
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        cnn.Open()
        DatabaseConnect = True
        Exit Function

Err_DatabaseConnect:
        DatabaseConnect = False
        SystemError(Err.Number, Err.Description, "", "Function: clsMaster.ConectaBanco")
    End Function
    Public Function ExecuteSQL(ByVal SQL As String) As Boolean
        On Error GoTo Err_ExecutarSQL
        ExecuteSQL = False

        If IsNothing(cnn) Then DatabaseConnect()

        If cnn.State = ConnectionState.Closed Then DatabaseConnect()
        Dim cmd As System.Data.SqlClient.SqlCommand = cnn.CreateCommand
        cmd.CommandText = SQL
        cmd.ExecuteNonQuery()
        ExecuteSQL = True
        Exit Function

Err_ExecutarSQL:
        ExecuteSQL = False
        SystemError(Err.Number, Err.Description, SQL, "Function: clsMaster.ExecuteSQL")
    End Function
    Public Function ExecuteSelect(ByVal SQL As String) As System.Data.SqlClient.SqlDataReader
        On Error GoTo Err_ExcuteSelect
        ExecuteSelect = Nothing

        If Not IsNothing(cnn) Then
            If cnn.State = ConnectionState.Open Then cnn.Close()
        End If

        DatabaseConnect()

        Dim cmd As System.Data.SqlClient.SqlCommand = cnn.CreateCommand
        cmd.Connection = cnn
        cmd.CommandText = SQL
        ExecuteSelect = cmd.ExecuteReader
        Exit Function

Err_ExcuteSelect:

        ExecuteSelect = Nothing
        SystemError(Err.Number, Err.Description, SQL, "Function: clsMaster.ExecuteSelect")
    End Function

    Public Function ExecuteSelect2(ByVal SQL As String) As System.Data.SqlClient.SqlDataReader
        On Error GoTo Err_ExcuteSelect2
        ExecuteSelect2 = Nothing

        If Not IsNothing(cnn) Then
            If cnn.State = ConnectionState.Open Then cnn.Close()
        End If

        DatabaseConnect()

        Dim cmd As System.Data.SqlClient.SqlCommand = cnn.CreateCommand
        cmd.Connection = cnn
        cmd.CommandText = SQL
        ExecuteSelect2 = cmd.ExecuteReader
        Exit Function

Err_ExcuteSelect2:

        ExecuteSelect2 = Nothing
        SystemError(Err.Number, Err.Description, SQL, "Function: clsMaster.ExecuteSelect")
    End Function


    'Função para página de erro
    Public Function SystemError(ErrNUmber As String, ErrDescription As String, ErrMessage As String, ErrLocation As String) As String
        Dim EmailMessage As String = ""
        Dim UrlError = ""
        SystemError = ""
        UrlError = UrlError & "ErrNumber=" & ErrNUmber & "&ErrDescription=" & ErrDescription & "&ErrMessage=" & ErrMessage & "&ErrLocation=" & ErrLocation
        UrlError = Replace(UrlError, Chr(10), " ")
        SystemError = UrlError
        HttpContext.Current.Response.Redirect("/Erro.aspx?" & UrlError)
    End Function

    Public Function ConvertDateBR(varDate As Date) As String
        Dim StrDate As String = ""
        ConvertDateBR = ""
        If IsDBNull(varDate) Or varDate = "" Then
            varDate = ""
        Else
            StrDate = Day(varDate) & "-"
            StrDate = Month(varDate) & "-"
            StrDate = Year(varDate)
        End If

        Return StrDate
    End Function

    Public Function GetDateTimeToString() As String
        Dim strDate As String = ""
        strDate = strDate & Now.Year() & "-"
        strDate = strDate & Now.Month() & "-"
        strDate = strDate & Now.Day() & " "
        strDate = strDate & Now.Hour() & ":"
        strDate = strDate & Now.Minute() & ":"
        strDate = strDate & Now.Second() & "."
        strDate = strDate & Now.Millisecond()
        Return strDate
    End Function

    Public Function Alert(MyPage As Page, Mensagem As String, Optional Redirecionar As Boolean = False, Optional ParaPagina As String = "") As Boolean
        On Error GoTo Err_Alert

        Alert = False
        Dim jscript As String
        'CAIXA DE MENSAGEM
        If Redirecionar = True Then
            jscript = ""
            jscript += "<script language='JavaScript'>"
            jscript += ";alert('" & Mensagem & "'); document.location.href='" & ParaPagina & "'"
            jscript += "</script>"
        Else
            jscript = ""
            jscript += "<script language='JavaScript'>"
            jscript += ";alert('" & Mensagem & "');"
            jscript += "</script>"
        End If
        MyPage.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Mensagem", jscript)

        Alert = True
        Exit Function
Err_Alert:
        Alert = False
    End Function


End Class
