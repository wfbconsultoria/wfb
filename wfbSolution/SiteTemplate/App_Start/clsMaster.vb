
Imports System.Net
Imports System.Net.Mail
Imports Microsoft.AspNet.Identity
Public Class clsMaster

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


