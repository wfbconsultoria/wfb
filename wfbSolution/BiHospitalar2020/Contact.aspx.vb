Public Class Contact
    Inherits Page
    Dim m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Private Sub cmd_SendMail_Click(sender As Object, e As EventArgs) Handles cmd_SendMail.Click
        m.SendMail(txt_MailTo.Text, "", "Contato via site", txt_MailMessage.Text)
    End Sub
End Class