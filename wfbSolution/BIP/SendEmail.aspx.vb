Public Class SendEmail
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m.CheckLogin()
        txt_Email.Value = Session("Email").ToString
        txt_Nome.Value = Session("UserName").ToString
        txt_Telefone.Value = Session("UserPhone").ToString

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
            Assunto = m.ConvertText(txt_Assunto.Value, clsMaster.TextCaseOptions.UpperCase)
        End If

        'Mensagem
        If m.CheckString(txt_Mensagem.Value) = False Then
            m.Alert(Me, "Preencha a mensagem")
            Exit Sub
        Else
            Mensagem = m.ConvertText(txt_Mensagem.Value, clsMaster.TextCaseOptions.TextCase)
        End If

        'Telefone
        If m.CheckString(txt_Telefone.Value) = False Then
            m.Alert(Me, "Preencha o telefone")
            Exit Sub
        Else
            Telefone = " - TEL: " & m.ConvertText(txt_Telefone.Value, clsMaster.TextCaseOptions.UpperCase)
        End If

        Dim ParaEmail As String = ConfigurationManager.AppSettings("App.Email")
        Dim ParaNome As String = ConfigurationManager.AppSettings("App.Name")
        Dim DeEmail As String = Session("Email").ToString
        Dim DeNome As String = Session("UserName").ToString & Telefone
        If m.SendMail(Assunto, Mensagem, ParaEmail, ParaNome, DeEmail, DeNome) = True Then
            m.Alert(Me, "Mensagem enviada com sucesso")
        Else
            m.Alert(Me, "Erro ao enviar mensagem")
        End If
    End Sub
End Class