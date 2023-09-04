
Imports System.Net
Imports System.Net.Mail
Public Class clsMaster
    Public Function SendMail(Mailto As String, MailSubject As String, MailMessage As String) As Boolean
        On Error GoTo Err_SendMail

        Dim credentials = New NetworkCredential(ConfigurationManager.AppSettings("App.Email").ToString, ConfigurationManager.AppSettings("App.SMTP.password").ToString)
        Dim smtp = New SmtpClient
        Dim msgFrom As New MailAddress(ConfigurationManager.AppSettings("App.Email").ToString, ConfigurationManager.AppSettings("App.Name").ToString)
        Dim msgTo As New MailAddress(Mailto)
        Dim msg As New MailMessage(msgFrom, msgTo)

        'Assinatura do e-mail
        Dim MailSignature As String
        MailSignature = ""
        MailSignature &= "<br/><hr/>"
        MailSignature &= "<h3>" & ConfigurationManager.AppSettings("App.Name").ToString & " (" & ConfigurationManager.AppSettings("App.Email").ToString & ")</h3>"
        MailSignature &= "<p>Mensagem automática, por favor, não responda</p>"

        'Configurações do Email
        MailSubject = ConfigurationManager.AppSettings("App.Name").ToString & " - " & UCase(MailSubject)
        msg.Subject = MailSubject
        msg.IsBodyHtml = True
        msg.Body = "<h3>" & MailSubject & "</h3> <hr/> <p>" & MailMessage & MailSignature & "</p>"

        'Configurações de SMTP
        smtp.Host = ConfigurationManager.AppSettings("App.SMTP.host").ToString
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network
        smtp.UseDefaultCredentials = False
        smtp.Port = ConfigurationManager.AppSettings("App.SMTP.port")
        smtp.Credentials = credentials
        smtp.EnableSsl = True

        'Envia o e-mail
        smtp.Send(msg)
        SendMail = True

        Exit Function
Err_SendMail:
        SendMail = False
    End Function
End Class
