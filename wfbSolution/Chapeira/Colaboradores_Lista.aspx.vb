Imports System.IO
Imports System.Net

Public Class Colaboradores_Lista
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString("rptId") = Nothing Or Request.QueryString("rptId") = "" Then
            Response.Redirect("Dashboard.aspx")
        Else
            ConfigReport(Request.QueryString("rptId").ToString)
        End If
    End Sub
    Sub ConfigReport(ReportId As String)
        Dim sql As String = ""
        Dim Titulo As String = ""
        sql = "Select * From View_Colaboradores Where Loja_Sigla = '" & ConfigurationManager.AppSettings("Loja_Sigla") & "' "
        Select Case ReportId
            Case = 1
                Titulo = "Coalboradores Presentes "
                sql = sql & " and Ativo = 'Sim' "
                sql = sql & " and Grupo = 'COLABORADORES' "

        End Select
        sql = sql & " Order By Nome"
        Page.Title = Titulo
        dtsColaboradores.SelectCommand = sql
        dtsColaboradores.DataBind()
    End Sub

    Private Sub cmd_SendEmail_Click(sender As Object, e As EventArgs) Handles cmd_SendEmail.Click

        'Dim msg As String
        'msg = RetornaDocumentText(HttpContext.Current.Request.Url.AbsoluteUri)
        'm.SendMail("miro@wfbconsultoria.com.br", "Miro", Page.Title, msg)
        Response.Redirect("Colaboradores_Lista_Mensagem.aspx?rptId=" & Request.QueryString("rptId").ToString)
    End Sub

    Private Function RetornaDocumentText(ByVal url As String) As String
        If Not url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) Then Return String.Empty
        Dim httpWebRequest As HttpWebRequest = CType(HttpWebRequest.Create(url), HttpWebRequest)
        Dim webResponse As WebResponse = httpWebRequest.GetResponse()
        Dim streamReader As StreamReader = New StreamReader(webResponse.GetResponseStream(), Encoding.UTF8)
        Return streamReader.ReadToEnd()
    End Function

End Class