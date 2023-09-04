

Imports System.Net.Mail
Imports System.Data

Public Class clsMaster
Public cnn As System.Data.SqlClient.SqlConnection

'FUNÇÕES DE CONEXÃO E ACESSO A BANCO DE DADOS ----------------------------------------------------------------------------------------------------------------------------------------------------------------
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
    Public Function ExecuteSQL2(ByVal SQL As String) As Boolean
        On Error GoTo Err_ExecuteSQL2
        ExecuteSQL2 = False
        Dim Cnn2 As New System.Data.SqlClient.SqlConnection
        Dim cmd As System.Data.SqlClient.SqlCommand = Cnn2.CreateCommand

        Cnn2.ConnectionString = ConfigurationManager.ConnectionStrings("CnnStr3").ConnectionString

        If Cnn2.State = ConnectionState.Open Then
            Cnn2.Close()
        Else
            Cnn2.Open()
        End If

        cmd.CommandText = SQL
        cmd.ExecuteNonQuery()
        ExecuteSQL2 = True
        Cnn2.Close()
        Exit Function

Err_ExecuteSQL2:
        ExecuteSQL2 = False
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
        Dim Cnn2 As New System.Data.SqlClient.SqlConnection

        Cnn2.ConnectionString = ConfigurationManager.ConnectionStrings("CnnStr3").ConnectionString

        If Cnn2.State = ConnectionState.Open Then
            Cnn2.Close()
        Else
            Cnn2.Open()
        End If

        DatabaseConnect()

        Dim cmd As System.Data.SqlClient.SqlCommand = Cnn2.CreateCommand
        cmd.Connection = Cnn2
        cmd.CommandText = SQL
        ExecuteSelect2 = cmd.ExecuteReader
        Exit Function

Err_ExcuteSelect2:
        ExecuteSelect2 = Nothing
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

'FUNÇÕES DE USUARIOS E LOGIN ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Public Function CheckUserStatus(Email As String) As String
    On Error GoTo Err_CheckUserStatus
    Dim d As System.Data.SqlClient.SqlDataReader
    Dim sql As String

    CheckUserStatus = "000"

    sql = "Select * From [tb_Users] Where [User_Email] = '" & Email & "'"
    d = ExecuteSelect(sql)

    If d.HasRows Then
        d.Read()
        CheckUserStatus = d("USER_STATUS_CODE")
    End If

    d = Nothing
    Exit Function

Err_CheckUserStatus:
    CheckUserStatus = "ERR"
    SystemError(Err.Number, Err.Description, SQL, "Function: clsMaster.CheckUserStatus")
End Function
Public Function CheckUserAccess(Email As String, Password As string, AccessOption As UserAccessOptions) As Boolean
    On Error GoTo Err_CheckUserAccess
    Dim d As System.Data.SqlClient.SqlDataReader
    Dim sql As String = ""

    CheckUserAccess = false
    If AccessOption = UserAccessOptions.Application Then sql = "Select * From [tb_Users] Where [User_Email] = '" & Email & "' And [User_Password] = '" & Password & "'"

    d = ExecuteSelect(sql)

    If d.HasRows Then
        d.Read()
        CheckUserAccess = true
    End If

    d = Nothing
    Exit Function

Err_CheckUserAccess:
    CheckUserAccess = false
    SystemError(Err.Number, Err.Description, SQL, "Function: clsMaster.CheckUserAccess")
End Function
Public Function RequestUserInfo(Email As String, InfoType As UserInfoTypes) As String
    On Error GoTo Err_RequestUserInfo
    RequestUserInfo = ""

    Dim d As System.Data.SqlClient.SqlDataReader
    Dim sql As String
    sql = ""
    sql = sql & " SELECT tb_Users.ID, tb_Users.USER_EMAIL, tb_Users.USER_NAME, "
    sql = sql & " tb_Users.USER_PHONE, tb_Users.USER_STATUS_CODE, tb_Users_Status.USER_STATUS, "
    sql = sql & " tb_Users.USER_PROFILE_CODE, tb_Users_Profiles.USER_PROFILE, tb_Users.Active, "
    sql = sql & " tb_Users.Insert_Date, tb_Users.Update_Date "
    sql = sql & " FROM tb_Users INNER JOIN "
    sql = sql & " tb_Users_Profiles ON tb_Users.USER_PROFILE_CODE = tb_Users_Profiles.USER_PROFILE_CODE INNER JOIN "
    sql = sql & " tb_Users_Status ON tb_Users.USER_STATUS_CODE = tb_Users_Status.USER_STATUS_CODE "
    sql = sql & " WHERE tb_Users.USER_EMAIL = '" & Email & "'"

    d = ExecuteSelect(sql)

    If d.HasRows Then
        d.Read()
        Select Case InfoType
            Case UserInfoTypes.Id
                RequestUserInfo = d("ID").ToString
            Case UserInfoTypes.Email
                RequestUserInfo = d("USER_EMAIL").ToString
            Case UserInfoTypes.Name
                RequestUserInfo = d("USER_NAME").ToString
            Case UserInfoTypes.Phone
                RequestUserInfo = d("USER_PHONE").ToString
            Case UserInfoTypes.Profile_Code
                RequestUserInfo = d("USER_PROFILE_CODE").ToString
            Case UserInfoTypes.Profile
                RequestUserInfo = d("USER_PROFILE").ToString
            Case UserInfoTypes.Status_Code
                RequestUserInfo = d("USER_STATUS_CODE").ToString
            Case UserInfoTypes.Status
                RequestUserInfo = d("USER_STATUS").ToString
            Case UserInfoTypes.Active
                RequestUserInfo = d("Insert_Date").ToString
            Case UserInfoTypes.Insert_date
                RequestUserInfo = d("Active").ToString
            Case UserInfoTypes.Update_Date
                RequestUserInfo = d("Update_Date").ToString
        End Select
    End If

    d = Nothing

    Exit Function
Err_RequestUserInfo:
    RequestUserInfo = ""
    SystemError(Err.Number, Err.Description, SQL, "Function: clsMaster.RequestUserInfo")
End Function
Public Function ValidateEmailDomain(ByVal Email As String) As Boolean
    On Error GoTo Err_ValidateEmailDomain
    ValidateEmailDomain = True
    If ConfigurationManager.AppSettings("Application.ValidadeEmailDomain").ToString = "Validate" Then
        Dim Position As Integer = InStr(Email, "@")
        Dim EmailLength As Integer = Len(Email)
        Dim EmailDomain As String = Right(Email, EmailLength - Position)
        If Checkexists("tb_Users_Domains", "USER_DOMAIN", EmailDomain) = False Then ValidateEmailDomain = False
    End If
    Exit Function
Err_ValidateEmailDomain:
    ValidateEmailDomain = False
    SystemError(Err.Number, Err.Description, Email, "Function: ValidateEmailDomain")
End Function
Public Function ValidateEmail(ByVal Email As String) As Boolean
    Dim padraoRegex As String = "^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\." &
    "(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$"
    Dim verify As New RegularExpressions.Regex(padraoRegex, RegexOptions.IgnorePatternWhitespace)
    Dim validate As Boolean = False
    'verifica se foi informado um email
    If String.IsNullOrEmpty(Email) Then
        validate = False
    Else
        'usar IsMatch para validar o email
        validate = verify.IsMatch(Email)
    End If
    'retorna o valor
    Return validate
End Function
Public Function UserRegister(USER_EMAIL As STRING, USER_NAME As STRING, USER_PROFILE_CODE As STRING, USER_COUNTRY_CODE As STRING, ARR_COUNTRIES As STRING) As Boolean
    On Error GoTo Err_UserRegister
    UserRegister=False
        
    Exit Function
Err_UserRegister:
    UserRegister=False
    SystemError(Err.Number, Err.Description, USER_EMAIL, "Function: _UserRegister")
End Function

'FUNÇÕES DE RELATORIOS ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Public Function RequestReportInfo(ReportFile As String, InfoType As ReportInfoTypes) As String
    On Error GoTo Err_RequestReportInfo
    RequestReportInfo = ""

    Dim d As System.Data.SqlClient.SqlDataReader
    Dim sql As String
    sql = ""
    sql = sql & " SELECT * From tb_Reports Where REPORT_FILE = '"& ReportFile & "'"
    
    d = ExecuteSelect(sql)

    If d.HasRows Then
        d.Read()
        Select Case InfoType
            Case ReportInfoTypes.Description
                RequestReportInfo = d("REPORT_DESC").ToString
            Case ReportInfoTypes.File
                RequestReportInfo = d("REPORT_FILE").ToString
            Case ReportInfoTypes.Name
                RequestReportInfo = d("REPORT_NAME").ToString
            Case ReportInfoTypes.Page
               RequestReportInfo = d("REPORT_PAGE").ToString
        End Select
    End If

    d = Nothing

    Exit Function
Err_RequestReportInfo:
    RequestReportInfo = ""
    SystemError(Err.Number, Err.Description, SQL, "Function: clsMaster.RequestReportInfo")
End Function
    'Função para página de erro
    Public Function SystemError(ErrNUmber As String, ErrDescription As String, ErrMessage As String, ErrLocation As String) As String
        Dim EmailMessage As String = ""
        Dim UrlError = ""
        SystemError = ""
        UrlError = UrlError & "ErrNumber=" & ErrNUmber & "&ErrDescription=" & ErrDescription & "&ErrMessage=" & ErrMessage & "&ErrLocation=" & ErrLocation
        UrlError = Replace(UrlError, Chr(10), " ")
        SystemError = UrlError
        HttpContext.Current.Response.Redirect(HttpContext.Current.Request.ApplicationPath & "\ErrorPage.aspx?" & UrlError)
    End Function
    'Novo metodo de envio de email 
    Public Function EnviarEmail(emailDestinatario As String, mensagem As String) As Boolean
        ' Instanciação de objetos
        Dim objSmtp As New SmtpClient()
        Dim objEmail As New MailMessage()
        Dim assinatura As String
        assinatura = vbCrLf & vbCrLf
        assinatura += "Site: " & ConfigurationManager.AppSettings("Application.URL").ToString() & vbCrLf
        assinatura += ConfigurationManager.AppSettings("Mail.Name.System").ToString() & ": Este e-mail é gerado automaticamente pelo sistema, por favor não responda." & vbCrLf
        assinatura += ConfigurationManager.AppSettings("Application.Signature").ToString() & " - " & Date.Now.Year() & "."

        ' Configurações do E-mail
        objSmtp.UseDefaultCredentials = False
        objSmtp.Credentials = New Net.NetworkCredential(ConfigurationManager.AppSettings("Mail.SMTP.Username").ToString(), ConfigurationManager.AppSettings("Mail.SMTP.Password").ToString())
        objSmtp.Port = ConfigurationManager.AppSettings("Mail.SMTP.Port").ToString()
        objSmtp.Host = ConfigurationManager.AppSettings("Mail.SMTP.Host").ToString()
        objSmtp.EnableSsl = True


        'Dados do email
        objEmail = New MailMessage
        'Para uso de e-mails microsof use o a credencial no from, caso do gmail use o email do destinatario
        objEmail.From = New MailAddress(ConfigurationManager.AppSettings("Mail.SMTP.Username").ToString())
        objEmail.To.Add(emailDestinatario)
        objEmail.Subject = ConfigurationManager.AppSettings("Mail.Name.System")
        objEmail.Body = mensagem & assinatura
        objEmail.Priority = MailPriority.Normal
        objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")
        objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")


        Try
            objSmtp.Send(objEmail)

            'Retorno
            EnviarEmail = True
            objEmail.Dispose()

        Catch ex As Exception
            'Retorno
            EnviarEmail = False
            objEmail.Dispose()

        End Try
    End Function
    Public Sub SendEmail(ByVal MailFrom As MailFromOptions, ByVal MailTo As String, ByVal Subject As String, ByVal MailMessage As String, ByVal RegisterLog As Boolean)
        Dim objSmtp As New System.Net.Mail.SmtpClient
        Dim objEmail As New System.Net.Mail.MailMessage()
        Dim sqlEmail As String
        Dim MailSignature As String
        Dim MailFromName As String
        Dim Mail_IP As String = HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString()
        Dim Mail_Session = HttpContext.Current.Session.SessionID.ToString()
        Dim MailKey As String = GenerateKey(KeyOptions.MailKey).ToString()

        'Set the name of who is sending the message
        MailFromName = ConfigurationManager.AppSettings("Application.Name") & " - "
        If MailFrom = MailFromOptions.System Then MailFromName = MailFromName & ConfigurationManager.AppSettings("Mail.Name.System").ToString()
        If MailFrom = MailFromOptions.Suport Then MailFromName = MailFromName & ConfigurationManager.AppSettings("Mail.Name.Suport").ToString()
        If MailFrom = MailFromOptions.Security Then MailFromName = MailFromName & ConfigurationManager.AppSettings("Mail.Name.Security").ToString()
        If MailFrom = MailFromOptions.UserLogged Then MailFromName = MailFromName & HttpContext.Current.Session("USER_NAME").ToString() & " (" & HttpContext.Current.Session("USER_EMAIL").ToString()

        'Set the Mail Signature
        MailSignature = ""
        MailSignature = MailSignature & Chr(10) & Chr(10) & Chr(10)
        MailSignature = MailSignature & "Message sent automatically by" & Chr(10)
        MailSignature = MailSignature & MailFromName
        MailSignature = MailSignature & "Please do not reply " & Chr(10) & Chr(10) & Chr(10)

        MailSignature = MailSignature & "MAIL LOG" & Chr(10)
        MailSignature = MailSignature & "User Logged: " & HttpContext.Current.Session("USER_NAME").ToString() & " - " & HttpContext.Current.Session("USER_PROFILE").ToString() & " " & Chr(10) & Chr(10)
        MailSignature = MailSignature & "User Email: " & HttpContext.Current.Session("USER_EMAIL").ToString() & " " & Chr(10)
        MailSignature = MailSignature & "Send In: " & Now().ToString() & " " & Chr(10)
        MailSignature = MailSignature & "IP: " & HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString() & " " & Chr(10)
        MailSignature = MailSignature & "Session ID: " & HttpContext.Current.Session.SessionID.ToString() & " " & Chr(10)
        MailSignature = MailSignature & "Mail Key: " & MailKey

        'Set the SQL Mail TO LOG
        sqlEmail = ""
        sqlEmail = sqlEmail & " Insert into tb_Log_Mail(MailKey, Send_Ip, Session_ID, MailFrom, MailFromName, MailTo, MailSubject, MailMessage, UserLogged, UserName, MailStatus) Values ("
        sqlEmail = sqlEmail & "'" & MailKey & "', "
        sqlEmail = sqlEmail & "'" & HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString() & "', "
        sqlEmail = sqlEmail & "'" & HttpContext.Current.Session.SessionID.ToString() & "', "
        sqlEmail = sqlEmail & "'" & ConfigurationManager.AppSettings("Mail").ToString() & "', "
        sqlEmail = sqlEmail & "'" & MailFromName & "', "
        sqlEmail = sqlEmail & "'" & MailTo & "', "
        sqlEmail = sqlEmail & "'" & ConvertText(Subject, TextCaseOptions.TextCase) & "', "
        sqlEmail = sqlEmail & "'" & ConvertText(MailMessage, TextCaseOptions.TextCase) & "', "
        sqlEmail = sqlEmail & "'" & HttpContext.Current.Session("USER_NAME") & "', "
        sqlEmail = sqlEmail & "'" & HttpContext.Current.Session("USER_EMAIL") & "', "

        'Mail Settings
        objEmail.From = New MailAddress(ConfigurationManager.AppSettings("Mail"), MailFromName)
        objEmail.Subject = Subject
        objEmail.Body = MailMessage & MailSignature
        objEmail.Priority = System.Net.Mail.MailPriority.Normal
        objEmail.IsBodyHtml = False
        objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")
        objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")
        objEmail.To.Add(MailTo)

        Try
            'CONFIGURAÇÕESDO E-MAIL DE ENVIO
            Dim c As New System.Net.NetworkCredential
            c.Password = ConfigurationManager.AppSettings("Mail.SMTP.Password").ToString()
            c.UserName = ConfigurationManager.AppSettings("Mail.SMTP.UserName").ToString()
            objSmtp.UseDefaultCredentials = False
            objSmtp.Credentials = c
            objSmtp.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            'objSmtp.EnableSsl = True
            objSmtp.Port = ConfigurationManager.AppSettings("Mail.SMTP.Port").ToString()
            objSmtp.Host = ConfigurationManager.AppSettings("Mail.SMTP.Host").ToString()
            objSmtp.Send(objEmail)
            sqlEmail = sqlEmail & " 'Success') "
        Catch ex As Exception
            objEmail.To.Clear()
            sqlEmail = sqlEmail & " 'Failure') "
        End Try
        If RegisterLog = True Then ExecuteSQL(sqlEmail)

        objEmail.Dispose()
    End Sub
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
    Public Function GenerateKey(KeyOption As KeyOptions) As String
        GenerateKey = ConfigurationManager.AppSettings("Application.Abb").ToString

        Dim KeyLength As Integer

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

        If KeyOption = KeyOptions.LongKey Then KeyLength = 32
        If KeyOption = KeyOptions.Password Then KeyLength = 8
        If KeyOption = KeyOptions.MailKey Then KeyLength = 16
        If KeyOption = KeyOptions.ValidateCode Then KeyLength = 12

        Randomize
        For I = 1 To KeyLength
            GenerateKey = GenerateKey & Number(Int(10 * Rnd()))
            GenerateKey = GenerateKey & Letter(Int(26 * Rnd()))
        Next

    End Function
    'Função para resgatar dominio
    Public Function onlyDomain(ByVal email As String) As String
        Dim Position As Integer = InStr(email, "@")
        Dim EmailLength As Integer = Len(email)
        Dim EmailDomain As String = Right(email, EmailLength - Position)

        Return EmailDomain
    End Function

    'ENUMERADORES LISTAS DE OPÇÕES E TIPOS---- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
    Public Enum UserAccessOptions
        Action
        Application
        Page
    End Enum
    Public Enum UserInfoTypes
        Id
        Active
        Email
        Name
        Phone
        Profile_Code
        Profile
        Status_Code
        Status
        Insert_date
        Update_Date
    End Enum
    Public Enum TextCaseOptions
        UpperCase
        LowerCase
        TextCase
    End Enum
    Public Enum MailFromOptions
        'Todas as páginas do sistema devem estar cadastradas nesta lista
        System
        Suport
        Security
        UserLogged
    End Enum
    Public Enum KeyOptions
        Password
        MailKey
        ValidateCode
        LongKey
    End Enum
    Public Enum ReportInfoTypes
        Description
        File
        Name
        Page
    End Enum

    

End Class