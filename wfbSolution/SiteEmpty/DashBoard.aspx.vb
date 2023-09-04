
Imports System.Data.SqlClient
Public Class DashBoard
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Loja
        Dim dtr As SqlDataReader = m.ExecuteSelect("qtdPessoasLoja")
        If dtr.HasRows Then
            dtr.Read()
            'colaboradores total
            txt_Colaboradores.Text = Convert.ToUInt32(dtr("Qtd_Colaboradores"))
            'colaboradores presentes
            txt_Colaboradores_Presentes.Text = Convert.ToUInt32(dtr("Qtd_Colaboradores_Presentes"))
            txt_Colaboradores_Presentes_Percent.Text = FormatPercent(m.Percentual(dtr("Qtd_Colaboradores_Presentes"), dtr("Qtd_Colaboradores")), 1)
            'colaboradores ausentes
            txt_Colaboradores_Ausentes.Text = Convert.ToUInt32(dtr("Qtd_Colaboradores_Ausentes"))
            txt_Colaboradores_Ausentes_Percent.Text = FormatPercent(m.Percentual(dtr("Qtd_Colaboradores_Ausentes"), dtr("Qtd_Colaboradores")), 1)




            txt_Brigadistas.Text = Convert.ToUInt32(dtr("Qtd_Brigadistas"))
            txt_Brigadistas_Presentes.Text = Convert.ToUInt32(dtr("Qtd_Brigadistas_Presentes"))
            'txt_Brigadistas_Presentes_Percent.Text = FormatPercent(dtr("Pct_Brigadistas_Presentes"))
        End If
        dtsLojas.SelectCommand = m.sqlLoja & " Order By Loja "
        dtsAndares.SelectCommand = m.sqlAndar & " Order By Loja, Andar "
        dtsZonas.SelectCommand = m.sqlZona & " Order By Loja, Andar, Zona "
        dtsUniversos.SelectCommand = m.sqlUniverso & " Order By Qtd_Pessoas_Presentes desc "
        'dtsPessoas.SelectCommand = m.sqlPessoas

        dtsLojas.DataBind()
        dtsAndares.DataBind()
        dtsZonas.DataBind()
        dtsUniversos.DataBind()
        'dtsPessoas.DataBind()
    End Sub

End Class