﻿Imports System.Data
Imports System.Net
Imports System.Net.Mail

Public Class clsMaster
    Public cnn As System.Data.SqlClient.SqlConnection
    Public Function DatabaseConnect() As Boolean
        On Error GoTo Err_DatabaseConnect

        DatabaseConnect = False
        cnn = New System.Data.SqlClient.SqlConnection With {
            .ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        }
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
        If Not IsNothing(cnn) Then
            If cnn.State = ConnectionState.Open Then cnn.Close()
        End If

        DatabaseConnect()

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
        SystemError(Err.Number, Err.Description, sql, "Function: clsMaster.CheckExists")
    End Function

    'Função para página de erro
    Public Function SystemError(ErrNUmber As String, ErrDescription As String, ErrMessage As String, ErrLocation As String) As String
        Dim UrlError = ""
        UrlError = UrlError & "ErrNumber=" & ErrNUmber & "&ErrDescription=" & ErrDescription & "&ErrMessage=" & ErrMessage & "&ErrLocation=" & ErrLocation
        UrlError = Replace(UrlError, Chr(10), " ")
        SystemError = UrlError
        HttpContext.Current.Response.Redirect("/Erro.aspx?" & UrlError)
    End Function
    Public Function CheckQueryString(QryParameter As String, Optional RedirectPage As String = "") As Boolean

        Try
            CheckQueryString = False
            If HttpContext.Current.Request.QueryString(QryParameter) = "" _
                Or IsNothing(HttpContext.Current.Request.QueryString(QryParameter)) _
                Or IsDBNull(HttpContext.Current.Request.QueryString(QryParameter)) _
                Or QryParameter = Nothing _
                Or QryParameter = "" _
                Or IsNothing(QryParameter) _
                Or IsDBNull(QryParameter) Then
                CheckQueryString = False
                If RedirectPage <> "" Then HttpContext.Current.Response.Redirect(RedirectPage)
            Else
                CheckQueryString = True
            End If
        Catch ex As Exception
            CheckQueryString = False
            If RedirectPage <> "" Then HttpContext.Current.Response.Redirect(RedirectPage)
        End Try

    End Function
    Public Function ConvertDateBR(varDate As Date) As String
        Dim StrDate As String

        If IsDBNull(varDate) Or varDate = "" Then
            StrDate = ""
        Else
            StrDate = Day(varDate) & "-"
            StrDate = Month(varDate) & "-"
            StrDate = Year(varDate)
        End If

        Return StrDate
    End Function
    Public Function ConvertDate(ByVal Text As String) As String
        Dim StrDate As String = ""
        If IsDBNull(Text) Or Text = "" Then
            StrDate = ""
        Else
            StrDate = Right(Text, 4) & "-"
            StrDate &= Mid(Text, 4, 2) & "-"
            StrDate &= Left(Text, 2)
        End If

        Return StrDate
    End Function
    Public Function GettDateToString() As String
        Dim LocalDate As Date = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"))
        Dim strDate As String = ""
        strDate = Year(LocalDate) & "-"
        strDate &= Month(LocalDate) & "-"
        strDate &= Day(LocalDate)

        Return strDate
    End Function
    Public Function GetDateTimeToString() As String
        Dim strDate As String = ""
        strDate = Now.Year() & "-"
        strDate &= Now.Month() & "-"
        strDate &= Now.Day() & " "
        strDate &= Now.Hour() & ":"
        strDate &= Now.Minute() & ":"
        strDate &= Now.Second() & "."
        strDate &= Now.Millisecond()
        Return strDate
    End Function

    Public Function ConvertCPFToString(ByVal strCPF As String) As String
        Dim apenasDigitos = New Regex("[^\d]")
        Return apenasDigitos.Replace(strCPF, "")
    End Function

    Public Function ConvertText(ByVal Text As String, Optional TextCase As TextCaseOptions = TextCaseOptions.UpperCase) As String

        If IsDBNull(Text) Then
            Text = ""
        Else
            Text = Trim(Text)
            Text = Replace(Text, "á", "a")
            Text = Replace(Text, "à", "a")
            Text = Replace(Text, "ã", "a")
            Text = Replace(Text, "â", "a")
            Text = Replace(Text, "é", "e")
            Text = Replace(Text, "è", "e")
            Text = Replace(Text, "ê", "e")
            Text = Replace(Text, "í", "i")
            Text = Replace(Text, "ì", "i")
            Text = Replace(Text, "ó", "o")
            Text = Replace(Text, "ò", "o")
            Text = Replace(Text, "ô", "o")
            Text = Replace(Text, "õ", "o")
            Text = Replace(Text, "ú", "u")
            Text = Replace(Text, "ù", "u")
            Text = Replace(Text, "û", "u")
            Text = Replace(Text, "~", "")
            Text = Replace(Text, ",", " ")
            Text = Replace(Text, "ç", "c")
            Text = Replace(Text, Chr(10), " ") 'LIMPA ASPAS
            Text = Replace(Text, Chr(34), " ") 'LIMPA ASPAS
            Text = Replace(Text, Chr(39), "") 'LIMPA APOSTROFE

            If TextCase = TextCaseOptions.UpperCase Then Text = UCase(Text)
            If TextCase = TextCaseOptions.LowerCase Then Text = LCase(Text)
            If TextCase = TextCaseOptions.TextCase Then Text = Text

        End If

        Return Trim(Text)
    End Function

    Public Function ConvertValue(ByVal strValue As String, Optional ValueOption As ValuesOptions = ValuesOptions.NumeroInteiro) As String

        If IsDBNull(strValue) Then strValue = "0"

        For Each A In strValue
            If Integer.TryParse(A, strValue) Then
            Else
                If ValueOption = ValuesOptions.NumeroInteiro Then Replace(strValue, A, "")
            End If
        Next
        ConvertValue = strValue
    End Function

    Public Function FormatDate(ByVal TextDate As String) As String
        'passar sempre a data no formato dd/mm/aaaa para converter para yyyy-mm-dd (sql server)
        Try
            FormatDate = ""
            If IsDBNull(TextDate) Then
                FormatDate = "1900-01-01"
            Else
                FormatDate = Right(TextDate, 4) & "-" & Mid(TextDate, 4, 2) & "-" & Left(TextDate, 2)
            End If
        Catch ex As Exception
            FormatDate = "1900-01-01"
        End Try
    End Function

    Public Enum TextCaseOptions
        UpperCase
        LowerCase
        TextCase
    End Enum
    Public Enum ValuesOptions
        NumeroInteiro
        NumeroDecimal
        NumeroMoeda
    End Enum
    Public Function SendMail(MailToAddress As String, MailToName As String, MailSubject As String, MailMessage As String) As Boolean
        On Error GoTo Err_SendMail

        'Assunto
        MailSubject = ConvertText(MailSubject, TextCaseOptions.UpperCase)

        'Assinatura'
        Dim MailKey As String = GenerateKey().ToString()
        Dim MailSignature As String
        MailSignature = ""
        MailSignature &= "<hr/>"
        MailSignature &= "<h3>" & ConfigurationManager.AppSettings("App.Support.Name").ToString & " (" & ConfigurationManager.AppSettings("App.Support.Email").ToString & ")</h3>"
        MailSignature &= "<p> Chave de identificação: " & MailKey & "</p>"
        MailSignature &= "<p> Mensagem automática, por favor, não responda</p>"

        'Mensagem
        MailMessage = ConvertText(MailMessage, TextCaseOptions.TextCase)
        Dim MailFromAddress As String = ConfigurationManager.AppSettings("App.Support.Email").ToString
        Dim MailFromName As String = ConfigurationManager.AppSettings("App.Support.Name").ToString
        Dim msgFrom As New MailAddress(MailFromAddress, MailFromName)
        Dim msgTo As New MailAddress(MailToAddress, MailToName)
        Dim msg As New MailMessage(msgFrom, msgTo) With {
            .Subject = MailSubject,
            .IsBodyHtml = True,
            .Body = "<h3>" & MailSubject & "</h3> <p>" & MailMessage & "</p>" & MailSignature
        }

        'SMTP
        Dim smtp = New SmtpClient
        Dim credentials = New NetworkCredential(ConfigurationManager.AppSettings("App.SMTP.user").ToString, ConfigurationManager.AppSettings("App.SMTP.password").ToString)
        smtp.Host = ConfigurationManager.AppSettings("App.SMTP.host").ToString
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network
        smtp.UseDefaultCredentials = False
        smtp.Port = ConfigurationManager.AppSettings("App.SMTP.port")
        smtp.Credentials = credentials
        smtp.EnableSsl = True
        smtp.Send(msg)

        SendMail = True

        Exit Function
Err_SendMail:

        SendMail = False
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

    Public Function GenerateKey(Optional Sigla As String = "") As String

        Dim KeyLength As Integer = 32
        GenerateKey = ConfigurationManager.AppSettings("App.Initials").ToString & "-" & Format(Now.Year, "0000") & "-" & Format(Now.Month, "00") & "-" & Format(Now.Day, "00") & "-" & Format(Now.Hour, "00") & "-" & Format(Now.Minute, "00") & "-" & Format(Now.Second, "00") & "-" & Format(Now.Millisecond, "0000") & Sigla & "-"
        Dim Number(26) As String
        Number(0) = "0"
        Number(1) = "1"
        Number(2) = "2"
        Number(3) = "3"
        Number(4) = "4"
        Number(5) = "5"
        Number(6) = "6"
        Number(7) = "7"
        Number(8) = "8"
        Number(9) = "9"

        Dim Letter(26) As String
        Letter(0) = "A"
        Letter(1) = "B"
        Letter(2) = "C"
        Letter(3) = "D"
        Letter(4) = "E"
        Letter(5) = "F"
        Letter(6) = "G"
        Letter(7) = "H"
        Letter(8) = "I"
        Letter(9) = "J"
        Letter(10) = "K"
        Letter(11) = "L"
        Letter(12) = "M"
        Letter(13) = "N"
        Letter(14) = "O"
        Letter(15) = "P"
        Letter(16) = "Q"
        Letter(17) = "R"
        Letter(18) = "S"
        Letter(19) = "T"
        Letter(20) = "U"
        Letter(21) = "V"
        Letter(22) = "X"
        Letter(23) = "W"
        Letter(24) = "Y"
        Letter(25) = "Z"

        Randomize()

        For I = 1 To KeyLength
            GenerateKey &= Number(Int(10 * Rnd()))
            GenerateKey &= Letter(Int(26 * Rnd()))
        Next

    End Function
    Public Function GenerateContactKey(CNPJ As String, Optional Sigla As String = "") As String
        GenerateContactKey = "CC" & CNPJ & Format(Now.Year, "0000") & "-" & Format(Now.Month, "00") & "-" & Format(Now.Day, "00") & "-" & Format(Now.Hour, "00") & "-" & Format(Now.Minute, "00") & "-" & Format(Now.Second, "00") & "-" & Format(Now.Millisecond, "0000")
    End Function
    Public Function GeneratePassword() As String
        GeneratePassword = ""
        Dim KeyLength As Integer = 8
        Dim Number(26) As String
        Number(0) = "0"
        Number(1) = "1"
        Number(2) = "2"
        Number(3) = "3"
        Number(4) = "4"
        Number(5) = "5"
        Number(6) = "6"
        Number(7) = "7"
        Number(8) = "8"
        Number(9) = "9"

        Dim Letter(26) As String
        Letter(0) = "A"
        Letter(1) = "B"
        Letter(2) = "C"
        Letter(3) = "D"
        Letter(4) = "E"
        Letter(5) = "F"
        Letter(6) = "G"
        Letter(7) = "H"
        Letter(8) = "I"
        Letter(9) = "J"
        Letter(10) = "K"
        Letter(11) = "L"
        Letter(12) = "M"
        Letter(13) = "N"
        Letter(14) = "O"
        Letter(15) = "P"
        Letter(16) = "Q"
        Letter(17) = "R"
        Letter(18) = "S"
        Letter(19) = "T"
        Letter(20) = "U"
        Letter(21) = "V"
        Letter(22) = "X"
        Letter(23) = "W"
        Letter(24) = "Y"
        Letter(25) = "Z"

        Randomize()

        For I = 1 To KeyLength
            GeneratePassword &= Number(Int(10 * Rnd()))
            GeneratePassword &= Letter(Int(26 * Rnd()))
        Next

    End Function
End Class


