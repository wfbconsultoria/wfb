
Partial Class rpt_Estoque_12meses_Produto_Distribuidor
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "rpt_Estoque_12meses_Produto_Distribuidor.aspx"
    Dim Titulo As String = "Estoque 12 meses Produto Distribuidor - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
       Page.Title = Titulo
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
        Info.Text = ""
    End Sub

    Public Sub Atualiza_Relatório()
        Dim sql As String
        sql = ""
        sql = sql & " SELECT * FROM [VIEW_DISTRIBUIDORES_GRUPOS_MOVIMENTO_ESTOQUE_CALCULADO] "
        sql = sql & " WHERE TIPO <> 'Estoque Informado' AND "
        sql = sql & " [COD_PRODUTO] = '" & cmbPRODUTO.Text & "' "
        sql = sql & " ORDER BY [PRODUTO], [GRUPO_DISTRIBUIDOR], [PERIODO] "

        dts_Report.SelectCommand = sql
        dts_Report.DataBind()
        rptEstoque.DataBind()
        rptEstoque.LocalReport.Refresh()
    End Sub

    Protected Sub cmbPRODUTO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPRODUTO.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub
End Class
