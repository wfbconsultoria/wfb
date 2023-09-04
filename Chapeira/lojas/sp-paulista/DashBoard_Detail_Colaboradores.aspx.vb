

Partial Class lojas_WFB_DashBoard_Detail_Colaboradores
    Inherits System.Web.UI.Page
    Dim rptId As String
    Dim Id_Andar As String
    Dim Id_Zona As String
    Dim Id_Universo As String
    Dim Universo As String = ""
    Dim Email As String
    Dim Titulo As String = ""
    ReadOnly m As New clsMaster
    ReadOnly l As New clsLojas
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
        l.GetInfoLoja()

        Dim sql As String = "Select * From View_Colaboradores Where Loja_Sigla = '" & m.LOJA_SIGLA & "' and Ativo = 'Sim' and Grupo = 'COLABORADORES' "
        Select Case ReportId
            Case = "1"
                Titulo = "Colaboradores " 'Colaboradores presentes e ausentes
            Case = "2"
                Titulo = "Colaboradores Presentes" 'Colaboradores presentes somente
                sql &= " and Status = 'Presente' "
            Case = "3"
                Titulo = "Colaboradores Ausentes" 'Colaboradores ausentes somente
                sql &= " and Status = 'Ausente' "
            Case = "4"
                Titulo = "Colaboradores - " & Universo 'Colaboradores presentes e ausentes por universo
                sql &= " and Id_Universo = '" & Id_Universo & "' "
            Case = "5"
                Titulo = "Colaboradores Presentes - " & Universo 'Colaboradores presentes somente por universo
                sql &= " and Status = 'Presente' "
                sql &= " and Id_Universo = '" & Id_Universo & "' "
            Case = "6"
                Titulo = "Colaboradores Ausentes - " & Universo 'Colaboradores ausentes somente por universo
                sql &= " and Status = 'Ausente' "
                sql &= " and Id_Universo = '" & Id_Universo & "' "
        End Select

        sql &= " Order By Andar, Zona, Universo, Status DESC, Brigadista_Desc, Nome "

        'Page.Title = Titulo
        Page.Title = l.Loja
        ltrTitulo.Text = Titulo
        dtsColaboradores.SelectCommand = sql
        dtsColaboradores.DataBind()

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