Imports System.IO
Imports System.Net
Public Class DashBoard_Detail_Brigadistas
    Inherits System.Web.UI.Page
    Dim rptId As String
    Dim Id_Andar As String
    Dim Id_Zona As String
    Dim Id_Universo As String
    Dim Universo As String = ""
    Dim Email As String
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("rptId") = Nothing Or Request.QueryString("rptId").ToString = "" Then Response.Redirect("Dashboard.aspx") Else rptId = Request.QueryString("rptId").ToString
        If Request.QueryString("Id_Andar") = Nothing Or Request.QueryString("Id_Andar").ToString = "" Then Id_Andar = "0" Else Id_Andar = Request.QueryString("Id_Andar").ToString
        If Request.QueryString("Id_Zona") = Nothing Or Request.QueryString("Id_Zona").ToString = "" Then Id_Zona = "0" Else Id_Zona = Request.QueryString("Id_Zona").ToString
        If Request.QueryString("Id_Universo") = Nothing Or Request.QueryString("Id_Universo").ToString = "" Then Id_Universo = "0" Else Id_Universo = Request.QueryString("Id_Universo").ToString

        If Id_Universo <> "0" Then
            Dim u As New clsUniversos
            u.GetInfoUniverso(Id_Universo)
            Universo = u.Universo & " (" & u.UniversoAndar & "º Andar Zona " & u.UniversoZona & ")"
        End If

        ConfigReport(rptId)

    End Sub
    Sub ConfigReport(ReportId As String)
        'Configurar - Somente informações de colaboradores ativos

        Dim Titulo As String = ""
        Dim sql As String = "Select * From View_Colaboradores Where Loja_Sigla = '" & ConfigurationManager.AppSettings("Loja_Sigla") & "'and Tipo = 'Brigadista' and Ativo = 'Sim' "
        Select Case ReportId
            Case = 1
                Titulo = "Brigadistas " 'Brigadistas presentes e ausentes
            Case = 2
                Titulo = "Brigadistas Presentes" 'Brigadistas presentes somente
                sql &= " and Status = 'Presente' "
            Case = 3
                Titulo = "Brigadistas Ausentes" 'Brigadistas ausentes somente
                sql = sql & " and Status = 'Ausente' "
            Case = 4
                Titulo = "Brigadistas - Zona " & Id_Zona & " (" & Id_Andar & "º andar)" 'Brigadistas ausentes somente
                sql = sql & " and Id_Andar = '" & Id_Andar & "' "
                sql = sql & " and Id_Zona = '" & Id_Zona & "' "
            Case = 5
                Titulo = "Brigadistas Presentes - Zona " & Id_Zona & " (" & Id_Andar & "º andar)" 'Brigadistas ausentes somente
                sql = sql & " and Id_Andar = '" & Id_Andar & "' "
                sql = sql & " and Id_Zona = '" & Id_Zona & "' "
                sql = sql & " and Status = 'Presente' "
            Case = 6
                Titulo = "Brigadistas Ausentes - Zona " & Id_Zona & " (" & Id_Andar & "º andar)" 'Brigadistas ausentes somente
                sql = sql & " and Id_Andar = '" & Id_Andar & "' "
                sql = sql & " and Id_Zona = '" & Id_Zona & "' "
                sql = sql & " and Status = 'Ausente' "
        End Select
        sql = sql & " Order By Andar, Zona, Universo, Status, Nome"
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
        Dim msg As String
        msg = RetornaDocumentText(HttpContext.Current.Request.Url.AbsoluteUri)
        Email = Mailto.Value
        Mailto.Visible = False
        m.SendMail(Email, "", Page.Title, msg)
        Mailto.Visible = True
        m.Alert(Me, "Email enviado com sucesso", False, "")
    End Sub

    Public Function FormataStatus(Parameter As String) As String
        FormataStatus = "text-danger"
        If Parameter = "Presente" Then FormataStatus = "text-success"
    End Function

    Public Function FormataTipo(Parameter As String) As String
        FormataTipo = "text-danger"
        If Parameter = "Brigadista" Then FormataTipo = "text-danger"
        If Parameter = "Não Brigadista" Then FormataTipo = "text-warning"
    End Function

End Class