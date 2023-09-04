Imports System.Data
Imports System.Net
Imports System.Net.Mail

Public Class clsMaster
    Public cnn As System.Data.SqlClient.SqlConnection
    Public Function DatabaseConnect() As Boolean
        On Error GoTo Err_DatabaseConnect
        DatabaseConnect = False

        cnn = New Data.SqlClient.SqlConnection
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        cnn.Open()

        DatabaseConnect = True
        Exit Function
Err_DatabaseConnect:
        DatabaseConnect = False
    End Function

    Public Function ExecuteSQL(ByVal SQL As String) As Boolean
        On Error GoTo Err_ExecuteSQL
        Dim cn As New System.Data.SqlClient.SqlConnection
        Dim cmd As System.Data.SqlClient.SqlCommand = cn.CreateCommand
        ExecuteSQL = False

        cn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        cmd.CommandText = SQL
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()

        ExecuteSQL = True
        Exit Function
Err_ExecuteSQL:
        ExecuteSQL = False
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

    Public Function SendMail(MailToAddress As String, MailToName As String, MailSubject As String, MailMessage As String) As Boolean
        On Error GoTo Err_SendMail
        SendMail = False

        Dim credentials = New NetworkCredential(ConfigurationManager.AppSettings("App.SMTP.user").ToString, ConfigurationManager.AppSettings("App.SMTP.password").ToString)
        Dim smtp = New SmtpClient
        Dim msgFrom As New MailAddress(ConfigurationManager.AppSettings("App.MailFrom").ToString, ConfigurationManager.AppSettings("App.Name").ToString)
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

    Public Function ClearText(ByVal strText As String) As String
        On Error GoTo Err_ClearText
        'CLEAN INVALID TEXT CHARACTERS
        If IsDBNull(strText) Then
            strText = ""
        Else
            strText = Trim(strText)
            strText = LCase(strText)
            strText = Replace(strText, "á", "a")
            strText = Replace(strText, "à", "a")
            strText = Replace(strText, "ã", "a")
            strText = Replace(strText, "â", "a")
            strText = Replace(strText, "é", "e")
            strText = Replace(strText, "è", "e")
            strText = Replace(strText, "ê", "e")
            strText = Replace(strText, "í", "i")
            strText = Replace(strText, "ì", "i")
            strText = Replace(strText, "ó", "o")
            strText = Replace(strText, "ò", "o")
            strText = Replace(strText, "ô", "o")
            strText = Replace(strText, "õ", "o")
            strText = Replace(strText, "ú", "u")
            strText = Replace(strText, "ù", "u")
            strText = Replace(strText, "û", "u")
            strText = Replace(strText, "~", "")
            strText = Replace(strText, ",", "")
            strText = Replace(strText, "ç", "c")
            strText = Replace(strText, "–", "-")
            strText = Replace(strText, Chr(33), "")
            strText = Replace(strText, Chr(34), "")
            strText = Replace(strText, Chr(39), "")
            strText = UCase(strText)
        End If
        ClearText = strText
        Exit Function
Err_ClearText:
    End Function
    Public Function Alert(MyPage As Page, Mensagem As String, Redirecionar As Boolean, ParaPagina As String) As Boolean
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
