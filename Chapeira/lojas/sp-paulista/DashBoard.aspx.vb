
Partial Class lojas_WFB_DashBoard
    Inherits System.Web.UI.Page

    ReadOnly l As New clsLojas
    ReadOnly r As New clsReports
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Loja
        l.GetInfoLoja()
        'colaboradores total
        txt_Colaboradores.Text = l.Loja_Colaboradores_Ativos_Qtd
        'colaboradores presentes
        txt_Colaboradores_Presentes.Text = l.Loja_Colaboradores_Presentes_Qtd
        txt_Colaboradores_Presentes_Percent.Text = l.Loja_Colaboradores_Presentes_Pct
        'colaboradores ausentes
        txt_Colaboradores_Ausentes.Text = l.Loja_Colaboradores_Ausentes_Qtd
        txt_Colaboradores_Ausentes_Percent.Text = l.Loja_Colaboradores_Ausentes_Pct
        'brigadistas total
        txt_Brigadistas.Text = l.Loja_Brigadistas_Ativos_Qtd
        'brigadistas presentes
        txt_Brigadistas_Presentes.Text = l.Loja_Brigadistas_Presentes_Qtd
        txt_Brigadistas_Presentes_Percent.Text = l.Loja_Brigadistas_Presentes_Pct
        'brigadistas ausentes
        txt_Brigadistas_Ausentes.Text = l.Loja_Brigadistas_Ausentes_Qtd
        txt_Brigadistas_Ausentes_Percent.Text = l.Loja_Brigadistas_Ausentes_Pct

        dtsLojas.SelectCommand = r.sqlDashboard("1")
        dtsLojas.DataBind()
        dtsAndares.SelectCommand = r.sqlDashboard("2")
        dtsAndares.DataBind()
        dtsZonas.SelectCommand = r.sqlDashboard("3")
        dtsZonas.DataBind()
        dtsUniversos.SelectCommand = r.sqlDashboard("4", " Pct_Colaboradores_Presentes Desc, Universo")
        dtsUniversos.DataBind()
        dtsTerceiros.SelectCommand = "Select * From view_Terceiros_Loja Where Loja_Sigla = '" & l.Loja_Sigla & "'"
        dtsTerceiros.DataBind()
        dtsVisitantes.SelectCommand = "Select * From view_Visitantes_Loja Where Loja_Sigla = '" & l.Loja_Sigla & "'"
        dtsVisitantes.DataBind()
    End Sub
End Class