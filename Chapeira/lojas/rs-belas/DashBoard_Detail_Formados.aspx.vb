
Partial Class lojas_WFB_DashBoard_Detail_Formados
    Inherits System.Web.UI.Page
    Dim rptId As String
    Dim Id_Andar As String
    Dim Id_Zona As String
    Dim Id_Universo As String
    Dim Universo As String = ""
    Dim Email As String
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
        'Configurar
        l.GetInfoLoja()
        Dim Titulo As String = ""
        Dim sql As String = " Select * From View_Colaboradores Where Loja_Sigla = '" & m.LOJA_SIGLA & "' and Ativo = 'Sim' and Grupo = 'COLABORADORES' "
        Select Case ReportId
            Case = 1
                Titulo = "Colaboradores Brigadistas/Não Brigadistas"
            Case = 2
                Titulo = "Brigadistas Formados"
                sql &= " and Tipo = 'Brigadista' "
            Case = 3
                Titulo = "Não Brigadistas"
                sql &= " and Tipo = 'Colaborador' "
            Case = 4
                Titulo = "Colaboradores Brigadistas/Não Brigadistas - Zona " & Request.QueryString("Id_Zona") & " (" & Request.QueryString("Id_Andar") & "º Andar)"
                sql &= " And Id_Andar = '" & Request.QueryString("Id_Andar") & "'"
                sql &= " and Id_Zona = '" & Request.QueryString("Id_Zona") & "'"
            Case = 5
                Titulo = "Brigadistas Formados - Zona " & Request.QueryString("Id_Zona") & " (" & Request.QueryString("Id_Andar") & "º Andar)"
                sql &= " and Tipo = 'Brigadista' "
                sql &= " and Id_Andar = '" & Request.QueryString("Id_Andar") & "'"
                sql &= " and Id_Zona = '" & Request.QueryString("Id_Zona") & "'"
            Case = 6
                Titulo = "Não Brigadistas - Zona " & Request.QueryString("Id_Zona") & " (" & Request.QueryString("Id_Andar") & "º Andar)"
                sql &= " and Tipo = 'Colaborador' "
                sql &= " and Id_Andar = '" & Request.QueryString("Id_Andar") & "'"
                sql &= " and Id_Zona = '" & Request.QueryString("Id_Zona") & "'"
        End Select
        sql &= " Order By Andar, Zona, Brigadista_Desc, Nome"
        Page.Title = l.Loja
        ltrTitulo.Text = Titulo
        dtsColaboradores.SelectCommand = sql
        dtsColaboradores.DataBind()
        Response.Flush()

    End Sub

    Public Function FormataTipo(Parameter As String) As String
        FormataTipo = "text-warning"
        If Parameter = "Brigadista" Then FormataTipo = "text-danger"
    End Function

End Class