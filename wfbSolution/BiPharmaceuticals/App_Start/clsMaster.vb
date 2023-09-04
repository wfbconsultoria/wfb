
Imports System.Net
Imports System.Net.Mail
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin

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
        Dim EmailMessage As String = ""
        Dim UrlError = ""
        SystemError = ""
        UrlError = UrlError & "ErrNumber=" & ErrNUmber & "&ErrDescription=" & ErrDescription & "&ErrMessage=" & ErrMessage & "&ErrLocation=" & ErrLocation
        UrlError = Replace(UrlError, Chr(10), " ")
        SystemError = UrlError
        HttpContext.Current.Response.Redirect("/_Page_Error?" & UrlError)
    End Function
    Public Function CheckQueryStringParameter(QryParameter As String, Optional RedirectPage As String = "") As String

        Try
            CheckQueryStringParameter = ""
            If QryParameter = Nothing _
                        Or QryParameter = "" _
                        Or IsNothing(QryParameter) _
                        Or IsDBNull(QryParameter) Then
                CheckQueryStringParameter = ""
                If RedirectPage <> "" Then HttpContext.Current.Response.Redirect(RedirectPage)
            Else
                CheckQueryStringParameter = QryParameter
            End If
        Catch ex As Exception
            CheckQueryStringParameter = ""
            If RedirectPage <> "" Then HttpContext.Current.Response.Redirect(RedirectPage)
        End Try

    End Function

    Public Function ConvertDate(ByVal Text As String) As String
        Dim StrDate As String = ""
        ConvertDate = ""
        If IsDBNull(Text) Or Text = "" Then
            Text = ""
        Else
            StrDate = Right(Text, 4) & "-"
            StrDate = StrDate & Mid(Text, 4, 2) & "-"
            StrDate = StrDate & Left(Text, 2)
        End If

        Return StrDate
    End Function
    Public Function GettDateToString() As String
        Dim UnivDate As Date = Now()
        Dim LocalDate As Date = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"))
        Dim strDate As String = ""

        strDate = strDate & Year(LocalDate) & "-"
        strDate = strDate & Month(LocalDate) & "-"
        strDate = strDate & Day(LocalDate)
        Return strDate


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

    Public Function ConvertCPFToString(ByVal strCPF As String) As String
        Dim apenasDigitos = New Regex("[^\d]")
        Return apenasDigitos.Replace(strCPF, "")
    End Function

    Public Function ConvertText(ByVal Text As String, TextCase As TextCaseOptions) As String
        ConvertText = ""
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
        ConvertText = Trim(Text)
    End Function
    Public Enum TextCaseOptions
        UpperCase
        LowerCase
        TextCase
    End Enum
    Public Function SendMail(MailToAddress As String, MailToName As String, MailSubject As String, MailMessage As String) As Boolean
        On Error GoTo Err_SendMail
        SendMail = False

        Dim credentials = New NetworkCredential(ConfigurationManager.AppSettings("App.SMTP.user").ToString, ConfigurationManager.AppSettings("App.SMTP.password").ToString)
        Dim smtp = New SmtpClient
        Dim msgFrom As New MailAddress(ConfigurationManager.AppSettings("App.Support.Email").ToString, ConfigurationManager.AppSettings("App.Support.Name").ToString)
        Dim msgTo As New MailAddress(MailToAddress, MailToName)
        Dim msg As New MailMessage(msgFrom, msgTo)

        smtp.Host = ConfigurationManager.AppSettings("App.SMTP.host").ToString
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network
        smtp.UseDefaultCredentials = False
        smtp.Port = ConfigurationManager.AppSettings("App.SMTP.port")
        smtp.Credentials = credentials

        msg.Subject = MailSubject
        msg.IsBodyHtml = True
        msg.Body = "<h2>" & MailSubject & "</h2> <br/> <h3>" & MailMessage & "</h3>"

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
    Public Function ConsultaPessoaFisicaSimplificada(ByVal Documento As String, ByVal DataNascimento As String) As svcCDC.PessoaFisicaSimplificada
        Dim pf As New svcCDC.PessoaFisicaSimplificada
        Dim credenciais As New svcCDC.Credenciais With {.Email = "miro@wfbconsultoria.com.br", .Senha = "mepm2412!"}
        Dim wsPessoaFisicaSimplificada As New svcCDC.CDC

        Try
            pf = wsPessoaFisicaSimplificada.PessoaFisicaSimplificada(credenciais, Documento, DataNascimento)
        Catch ex As Exception

        End Try

        Return pf
    End Function
    Public Function ConsultaCEP(ByVal strCEP As String) As svcCEP.CEP1
        Dim cCEP As New svcCEP.CEP1
        Dim credenciais As New svcCEP.Credenciais With {.Email = "miro@wfbconsultoria.com.br", .Senha = "mepm2412!"}
        Dim wsCEP As New svcCEP.CEP

        Try
            cCEP = wsCEP.ConsultaCEP(credenciais, strCEP)
        Catch ex As Exception

        End Try

        Return cCEP
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
            GenerateKey = GenerateKey & Number(Int(10 * Rnd()))
            GenerateKey = GenerateKey & Letter(Int(26 * Rnd()))
        Next

    End Function

End Class


