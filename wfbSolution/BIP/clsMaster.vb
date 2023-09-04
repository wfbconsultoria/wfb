Imports System.Net
Imports System.Net.Mail
'BIP
Public Class clsMaster
    Public cnn As System.Data.SqlClient.SqlConnection
    'BIP Função para página de erro
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
    'BIP 
    Public Function ExecuteSQL(ByVal SQL As String) As Boolean
        On Error GoTo Err_ExecutarSQL
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
    'BIP 
    Public Function ExecuteSelect(ByVal SQL As String) As System.Data.SqlClient.SqlDataReader
        On Error GoTo Err_ExcuteSelect

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
    'BIP Função para página de erro
    Public Function SystemError(ErrNUmber As String, ErrDescription As String, ErrMessage As String, ErrLocation As String) As String
        Dim EmailMessage As String = ""
        Dim UrlError = ""
        SystemError = ""
        If CheckString(ErrNUmber) = False Then ErrNUmber = "000"
        If CheckString(ErrDescription) = False Then ErrNUmber = "Erro não especificado"
        If CheckString(ErrMessage) = False Then ErrNUmber = "Contate o administrador do sistema"
        If CheckString(ErrLocation) = False Then ErrNUmber = "Módulo não especificado"

        UrlError = UrlError & "ErrNumber=" & ErrNUmber & "&ErrDescription=" & ErrDescription & "&ErrMessage=" & ErrMessage & "&ErrLocation=" & ErrLocation
        UrlError = Replace(UrlError, Chr(10), " ")
        SystemError = UrlError
        HttpContext.Current.Response.Redirect("Error.aspx?" & UrlError)
    End Function
    'BIP - Verfica se o registro existe na tabela
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
    'BIP - Verfica se existe usuário logado
    Public Sub CheckLogin()

        If HttpContext.Current.Session("Email") Is Nothing Then HttpContext.Current.Response.Redirect("Login.aspx")
        If IsDBNull(HttpContext.Current.Session("Email")) Then HttpContext.Current.Response.Redirect("Login.aspx")
        If HttpContext.Current.Session("Email") = "" Then HttpContext.Current.Response.Redirect("Login.aspx")
        If HttpContext.Current.Session("Email").ToString = "" Then HttpContext.Current.Response.Redirect("Login.aspx")

    End Sub
    'BIP 
    Public Function CheckString(strParameter As String, Optional Opcional_RedirectPage As String = "") As Boolean
        On Error GoTo Err_CheckString
        If strParameter = Nothing _
                        Or strParameter = "" _
                        Or IsNothing(strParameter) _
                        Or IsDBNull(strParameter) Then
            CheckString = False
            If Opcional_RedirectPage <> "" Then HttpContext.Current.Response.Redirect(Opcional_RedirectPage)
        Else
            CheckString = True
        End If
        Exit Function
Err_CheckString:
        CheckString = False
    End Function
    'BIP - Exibe caixa de mensagem
    Public Function Alert(MyPage As Page, Mensagem As String, Optional Opcional_RedirectPage As String = "") As Boolean
        On Error GoTo Err_Alert

        Alert = False
        Dim jscript As String
        'CAIXA DE MENSAGEM
        If Opcional_RedirectPage <> "" Then
            jscript = ""
            jscript += "<script language='JavaScript'>"
            jscript += ";alert('" & Mensagem & "'); document.location.href='" & Opcional_RedirectPage & "'"
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
    'BIP - Converte e limpa caracters especiais do texto
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
            Text = Replace(Text, Chr(10), "") 'LIMPA ASPAS
            Text = Replace(Text, Chr(34), "") 'LIMPA ASPAS
            Text = Replace(Text, Chr(39), "") 'LIMPA APOSTROFE

            If TextCase = TextCaseOptions.UpperCase Then Text = UCase(Text)
            If TextCase = TextCaseOptions.LowerCase Then Text = LCase(Text)
            If TextCase = TextCaseOptions.TextCase Then Text = Text

        End If
        ConvertText = Trim(Text)
    End Function
    'BIP 
    Public Enum TextCaseOptions
        UpperCase
        LowerCase
        TextCase
    End Enum
    'BIP - Recupera e formata Data e Hora atual
    Public Function GetDateTimeToString() As String
        Dim strDate As String = (Format(Now.Year, "0000") & "-" & Format(Now.Month, "00") & "-" & Format(Now.Day, "00") & " " & Format(Now.Hour, "00") & ":" & Format(Now.Minute, "00") & ":" & Format(Now.Second, "00") & "." & Format(Now.Millisecond, "000")).ToString
        Return strDate

    End Function
    'BIP - Gerar uma string aleatorio utilizada para senhas
    Public Function GenerateKey(Length As Integer, Optional Prefix As Boolean = False) As String

        Dim KeyLength As Integer = Length
        Dim PrefixKey As String = ""
        GenerateKey = ""
        If Prefix = True Then PrefixKey = ConfigurationManager.AppSettings("App.Initials").ToString & "-" & Format(Now.Year, "0000") & Format(Now.Month, "00") & Format(Now.Day, "00") & Format(Now.Hour, "00") & Format(Now.Minute, "00") & Format(Now.Second, "00") & Format(Now.Millisecond, "0000")
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
        GenerateKey = prefixkey & GenerateKey
    End Function

    'BIP - envia email
    Public Function SendMail(MailSubject As String, MailMessage As String, MailToAddress As String, MailToName As String, MailFromAddress As String, MailFromName As String) As Boolean
        On Error GoTo Err_SendMail
        SendMail = False

        'Assunto
        MailSubject = ConvertText(MailSubject, TextCaseOptions.UpperCase)
        'Mensagem
        MailMessage = ConvertText(MailMessage, TextCaseOptions.TextCase)

        Dim credentials = New NetworkCredential(ConfigurationManager.AppSettings("App.SMTP.user").ToString, ConfigurationManager.AppSettings("App.SMTP.password").ToString)
        Dim smtp = New SmtpClient
        Dim msgFrom As New MailAddress(MailFromAddress, MailFromName)
        Dim msgTo As New MailAddress(MailToAddress, MailToName)
        Dim msg As New MailMessage(msgFrom, msgTo)

        smtp.Host = ConfigurationManager.AppSettings("App.SMTP.host").ToString
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network
        smtp.UseDefaultCredentials = False
        smtp.Port = ConfigurationManager.AppSettings("App.SMTP.port")
        smtp.Credentials = credentials

        msg.Subject = MailSubject
        msg.IsBodyHtml = True
        msg.Body = "<h3>" & MailSubject & "</h3> <hr/> <p>" & MailMessage & "</p>"

        smtp.Send(msg)
        SendMail = True

        'Grava na tb_Log_Email
        Dim sql_Email = ""
        sql_Email &= " INSERT INTO [tb_Log_Email] "
        sql_Email &= " ([EmailFrom], [NameFrom], [EmailTo], [NameTo], [Subject], [Message]) "
        sql_Email &= "VALUES ( "
        sql_Email &= " '" & MailFromAddress & "', "
        sql_Email &= " '" & MailFromName & "', "
        sql_Email &= " '" & MailToAddress & "', "
        sql_Email &= " '" & MailToName & "', "
        sql_Email &= " '" & MailSubject & "', "
        sql_Email &= " '" & MailMessage & "') "

        If Not IsNothing(cnn) Then DatabaseConnect()
        Dim cmd_Email As System.Data.SqlClient.SqlCommand = cnn.CreateCommand
        cmd_Email.CommandText = sql_Email
        cmd_Email.ExecuteNonQuery()

        Exit Function
Err_SendMail:
        SendMail = False
    End Function
End Class
