Public Class Modelo
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly p As New clsPlanner
    Dim rw As TableRow
    Dim cel As TableCell

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'm.CheckLogin()
        txt_ANO.Value = Year(Now())
        txt_MES.Value = Month(Now())

        Dim dtr As Data.SqlClient.SqlDataReader = m.ExecuteSelect(p.sql_Calendario_Mes(txt_ANO.Value, txt_MES.Value, 1))
        If dtr.HasRows Then
            dtr.Read()

            Dim linha As Integer
            Dim coluna As Integer
            Dim celula As Integer = 0
            Dim dia As Integer = 1
            Dim mes As Integer = txt_MES.Value
            Dim ano As Integer = txt_ANO.Value
            For linha = 1 To dtr("ULTIMA_SEMANA_MES")
                NewRow(tb_CALENDARIO)

                For coluna = 1 To 7
                    celula = celula + 1
                    If celula < dtr("DIA_SEMANA") Then
                        NewCell("")
                    Else
                        If dia > dtr("ULTIMO_DIA_MES") Then
                            NewCell("")
                        Else


                            NewCell("<a href=Planificar.aspx?dia=" & Format(dia, "00") & "&mes=" & Format(mes, "00") & "&ano=" & Format(ano, "0000") & "><div h-100 justify-content-top align-items-left>" & Format(dia, "00") & "</div><h5 h-100 justify-content-center align-items-center><span class='badge badge-danger'>HO</span></h5></a>")

                        End If
                        dia = dia + 1
                    End If
                Next
            Next
        End If
    End Sub


    Protected Sub NewRow(tbl As Table)
        rw = New TableRow
        rw.HorizontalAlign = HorizontalAlign.Center
        tbl.Rows.Add(rw)

    End Sub
    Protected Sub NewCell(valor As String)
        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = valor
        cel.Wrap = True
    End Sub

End Class
