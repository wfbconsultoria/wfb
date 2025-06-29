Imports System
Imports System.Collections.Generic
Imports Twilio
Imports Twilio.Rest.Api.V2010.Account
Imports Twilio.Types
Partial Class SMS
    Inherits System.Web.UI.Page

    Private Sub cmdSMS_ServerClick(sender As Object, e As EventArgs) Handles cmdSMS.ServerClick
        Dim accountSid = "ACb51e7f47fe56a9a0eaccb9768af8d610"
        Dim authToken = "42a50e6a863b6d65c0b4ead99af9ebda"
        TwilioClient.Init(accountSid, authToken)
        Dim messageOptions = New CreateMessageOptions(New PhoneNumber("+5511939350161"))
        messageOptions.MessagingServiceSid = "MG913a2070dd221bb9c386f54dda4c3321"
        messageOptions.Body = "Ahoy 👋"
        Dim message = MessageResource.Create(messageOptions)
        Console.WriteLine(message.Body)
    End Sub
End Class
