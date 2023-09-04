Imports System.IO
Imports System.Net
Public Class DashBoard_Detail
    Inherits System.Web.UI.Page

    ReadOnly m As New clsMaster
    ReadOnly v As New clsValidate
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
                Titulo = "Colaboradores"
                sql = sql & " and Ativo = 'Sim' "
                sql = sql & " and Grupo = 'COLABORADORES' "
            Case = 2
                Titulo = "Colaboradores Presentes"
                sql = sql & " and Ativo = 'Sim' "
                sql = sql & " and Grupo = 'COLABORADORES' "
                sql = sql & " and Status = 'Presente' "
            Case = 3
                Titulo = "Colaboradores Ausentes"
                sql = sql & " and Ativo = 'Sim' "
                sql = sql & " and Grupo = 'COLABORADORES' "
                sql = sql & " and Status = 'Ausente' "
            Case = 4
                Titulo = "Brigadistas"
                sql = sql & " and Ativo = 'Sim' "
                sql = sql & " and Tipo = 'Brigadista' "
            Case = 5
                Titulo = "Brigadistas Presentes"
                sql = sql & " and Ativo = 'Sim' "
                sql = sql & " and Tipo = 'Brigadista' "
                sql = sql & " and Status = 'Presente' "
            Case = 6
                Titulo = "Brigadistas Ausentes"
                sql = sql & " and Ativo = 'Sim' "
                sql = sql & " and Tipo = 'Brigadista' "
                sql = sql & " and Status = 'Ausente' "
        End Select
        sql = sql & " Order By Nome"
        Page.Title = Titulo
        dtsColaboradores.SelectCommand = sql
        dtsColaboradores.DataBind()
        Response.Flush()

    End Sub

    Private Function RetornaDocumentText(ByVal url As String) As String
        If Not url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) Then Return String.Empty
        Dim httpWebRequest As HttpWebRequest = CType(httpWebRequest.Create(url), HttpWebRequest)
        Dim webResponse As WebResponse = httpWebRequest.GetResponse()
        Dim streamReader As StreamReader = New StreamReader(webResponse.GetResponseStream(), Encoding.UTF8)
        Return streamReader.ReadToEnd()
    End Function

    Private Sub Enviar_Click(sender As Object, e As EventArgs) Handles Enviar.Click
        If v.IsValidEmail(Mailto.Value) Then
            Dim msg As String
            msg = RetornaDocumentText(HttpContext.Current.Request.Url.AbsoluteUri)
            Dim Email As String = Mailto.Value

            If m.SendMail(Email, "", Page.Title, msg) Then
                Mailto.Visible = True
                m.Alert(Me, Page.Title & ", enviado com sucesso para " & Email, False, "")
            Else
                m.Alert(Me, "NÃO FOI POSSÍVEL ENVIAR ESTE E-MAIL", True, "Dashboard.aspx")
            End If
        Else
            m.Alert(Me, "E-MAIL ESTÁ VAZIO OU É INVÁLIDO", False, "")
        End If
    End Sub
End Class