Public Class Support_SendEmail
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Verifica se os campos estão preeenchidos
        If m.CheckString(Session("Email")) = True Then txt_Email.Value = Session("Email")
        If m.CheckString(Session("UserName")) = True Then txt_Nome.Value = Session("UserName")
        If m.CheckString(Session("UserPhone")) = True Then txt_Telefone.Value = Session("UserPhone")
    End Sub

    Private Sub cmd_Enviar_ServerClick(sender As Object, e As EventArgs) Handles cmd_Enviar.ServerClick

        Dim Assunto As String = ""
        Dim Mensagem As String = ""
        Dim Telefone As String = ""

        'Assunto
        If m.CheckString(txt_Assunto.Value) = False Then
            m.Alert(Me, "Preencha o assunto")
            Exit Sub
        Else
            Assunto = "Solicitação de Suporte - " & m.ConvertText(txt_Assunto.Value, clsMaster.TextCaseOptions.UpperCase)
        End If

        'Mensagem
        If m.CheckString(txt_Mensagem.Value) = False Then
            m.Alert(Me, "Preencha a mensagem")
            Exit Sub
        Else
            Mensagem = ""
            Mensagem &= "<h3>De: " & m.ConvertText(txt_Nome.Value, clsMaster.TextCaseOptions.UpperCase) & "</h3>"
            Mensagem &= "<p> E-mail: " & m.ConvertText(txt_Email.Value, clsMaster.TextCaseOptions.LowerCase) & " Telefone: " & m.ConvertText(txt_Telefone.Value, clsMaster.TextCaseOptions.LowerCase) & "</p>"
            Mensagem &= "<h3>" & m.ConvertText(txt_Mensagem.Value, clsMaster.TextCaseOptions.TextCase) & "</h3>"
        End If

        'Telefone
        If m.CheckString(txt_Telefone.Value) = False Then
            m.Alert(Me, "Preencha o telefone")
            Exit Sub
        Else
            Telefone = " - TEL: " & m.ConvertText(txt_Telefone.Value, clsMaster.TextCaseOptions.UpperCase)
        End If

        Dim ParaEmail As String = ConfigurationManager.AppSettings("App.Email")
        Dim ParaEmailCopia As String = m.ConvertText(txt_Email.Value, clsMaster.TextCaseOptions.LowerCase)
        Dim ParaNome As String = ConfigurationManager.AppSettings("App.Name")
        Dim ParaNomeCopia As String = m.ConvertText(txt_Email.Value, clsMaster.TextCaseOptions.LowerCase)
        Dim DeEmail As String = ConfigurationManager.AppSettings("App.Email")
        Dim DeNome As String = txt_Nome.Value
        If m.SendMail(Assunto, Mensagem, ParaEmail, ParaNome, DeEmail, DeNome) = True Then
            'copia a quem enviou
            m.SendMail("Copia de sua mensagem enviada - " & Assunto, "<p>Copia de sua mensagem enviada</p>" & Mensagem, ParaEmailCopia, ParaNomeCopia, DeEmail, ConfigurationManager.AppSettings("App.Name"))
            m.Alert(Me, "Mensagem enviada com sucesso", "Default.aspx")
        Else
            m.Alert(Me, "Erro ao enviar mensagem")
        End If
    End Sub
End Class