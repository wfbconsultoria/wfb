Public Class PageError
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ERR_APP As String = m.ConvertText(ConfigurationManager.AppSettings("App.Name").ToString & " - " & ConfigurationManager.AppSettings("Loja").ToString, clsMaster.TextCaseOptions.UpperCase)
        Dim ERR_NUMBER As String = "000"
        Dim ERR_DESC As String = "NÃO INDENTIFICADO"
        Dim ERR_MSG As String = "ERRO NÃO INDENTIFICADO, ENTRE EM CONTATO IMEDIATAMENTE COM O DEPARTAMENTO DE DESENVOLVIMENTO E INFORME ERRO NA APLICAÇÃO " & ERR_APP
        Dim ERR_LOC As String = "MÓDULO NÃO IDENTIFICADO"
        Dim ERR_IP As String = HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString

        If m.CheckString(Request.QueryString("ErrNumber")) Then ERR_NUMBER = Request.QueryString("ErrNumber")
        If m.CheckString(Request.QueryString("ErrDescription")) Then ERR_DESC = Request.QueryString("ErrDescription")
        If m.CheckString(Request.QueryString("ErrMessage")) Then ERR_MSG = Request.QueryString("ErrMessage")
        If m.CheckString(Request.QueryString("ErrLocation")) Then ERR_LOC = Request.QueryString("ErrLocation")

        lbl_ErrDescription.Text = ERR_NUMBER & " - " & ERR_DESC
        lbl_ErrMessage.Text = ERR_MSG
        lbl_ErrLocation.Text = ERR_LOC
        lbl_IP.Text = ERR_IP

        Dim Mailto As String = ConfigurationManager.AppSettings("App.Email").ToString
        Dim MailtoName As String = ConfigurationManager.AppSettings("App.Name").ToString
        Dim MailSubject As String = "ERRO DE SISTEMA EM - " & ERR_APP
        Dim MailMessage As String = ""
        MailMessage &= "<h2>" & MailSubject & "<h2/>"
        MailMessage &= "<h3> NUMERO - " & ERR_NUMBER & "<h3/>"
        MailMessage &= "<h3> DESCRICAO - " & ERR_DESC & "<h3/>"
        MailMessage &= "<h3> MENSAGEM - " & ERR_MSG & "<h3/>"
        MailMessage &= "<h3> LOCAL - " & Request.QueryString("ErrLocation").ToString & "<h3/>"
        MailMessage &= "<h3> IP - " & ERR_IP & "<h3/>"
        MailMessage &= "<h3> O SISTEMA ENVIUOU AUTOMATICAMENTE UMA MENSAGEM AO SUPORTE<h3/>"
        m.SendMail(Mailto, MailtoName, MailSubject, MAILMESSAGE)
    End Sub

End Class