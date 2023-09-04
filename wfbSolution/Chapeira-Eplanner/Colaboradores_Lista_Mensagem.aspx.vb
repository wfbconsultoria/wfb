Imports System.IO
Imports System.Net
Public Class Colaboradores_Lista_Mensagem
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Email As String = "miro@wfbconsultoria.com.br"
        If Request.QueryString("rptId") = Nothing Or Request.QueryString("rptId") = "" Then
            Response.Redirect("Dashboard.aspx")
        Else
            ConfigReport(Request.QueryString("rptId").ToString, Email)
        End If
    End Sub
    Sub ConfigReport(ReportId As String, Mailto As String)
        'Configurar
        Dim sql As String = ""
        Dim Titulo As String = ""
        sql = "Select * From View_Colaboradores Where Loja_Sigla = '" & ConfigurationManager.AppSettings("Loja_Sigla") & "' "
        Select Case ReportId
            Case = 1
                Titulo = "Colaboradores Presentes "
                sql = sql & " and Ativo = 'Sim' "
                sql = sql & " and Grupo = 'COLABORADORES' "
                sql = sql & " and Status = 'Presente' "
        End Select
        sql = sql & " Order By Nome"
        Page.Title = Titulo
        dtsColaboradores.SelectCommand = sql
        dtsColaboradores.DataBind()
        Response.Flush()

    End Sub

    Private Function RetornaDocumentText(ByVal url As String) As String
        If Not url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) Then Return String.Empty
        Dim httpWebRequest As HttpWebRequest = CType(HttpWebRequest.Create(url), HttpWebRequest)
        Dim webResponse As WebResponse = httpWebRequest.GetResponse()
        Dim streamReader As StreamReader = New StreamReader(webResponse.GetResponseStream(), Encoding.UTF8)
        Return streamReader.ReadToEnd()
    End Function

    Private Sub Enviar_Click(sender As Object, e As EventArgs) Handles Enviar.Click
        Dim msg As String
        msg = RetornaDocumentText(HttpContext.Current.Request.Url.AbsoluteUri)
        Dim Email As String = Mailto.Value
        Mailto.Visible = False
        m.SendMail(Email, "Miro", Page.Title, msg)
        Mailto.Visible = True
        m.Alert(Me, "Email enviado com sucesso", False, "")
    End Sub
End Class