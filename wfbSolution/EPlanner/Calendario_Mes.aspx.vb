Public Class Calendario_Mes
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly p As New clsPlanner
    Dim rw As TableRow
    Dim cel As TableCell


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'm.CheckLogin()

        Dim AnoMes As Double = Val(cmb_AnoMes.Text)
        If AnoMes = 0 Then AnoMes = Val(Format(Now.Year, "0000") & Format(Now.Month, "00"))

        Dim ano As Integer = Val(Left(AnoMes, 4))
        Dim mes As Integer = Val(Right(AnoMes, 2))
        Dim dia As Integer = 1
        Dim linha As Integer
        Dim coluna As Integer
        Dim celula As Integer = 0

        Dim dtr As Data.SqlClient.SqlDataReader = m.ExecuteSelect(p.sql_Calendario_Mes(ano, mes, dia))
        If dtr.HasRows Then
            dtr.Read()
            'CALENDARIO DO COLABORADOR
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
                            Dim sql As String = ""
                            Dim DATA_ID As Double = Val(Format(ano, "0000") & Format(mes, "00") & Format(dia, "00"))
                            sql = "Select * From VIEW_PLANNER WHERE DATA_ID = " & DATA_ID & " AND LOJA_SIGLA = '" & Session("LOJA_SIGLA") & "' AND EMAIL = '" & Session("EMAIL_LOGIN") & "'"
                            Dim dtr_Dia As Data.SqlClient.SqlDataReader = m.ExecuteSelect(sql)
                            If dtr_Dia.HasRows Then
                                dtr_Dia.Read()
                                NewCell(
                                        "<a href=Planificar.aspx?dia=" & Format(dia, "00") & "&mes=" & Format(mes, "00") & "&ano=" & Format(ano, "0000") & ">" &
                                        "<div h-100 justify-content-top align-items-left>" & Right(dtr_Dia("DATA_ID"), 2) & "</div>" &
                                        "<h6 h-100 justify-content-center align-items-center>" &
                                        "<span class='badge' style ='background-color:" & dtr_Dia("COR_FUNDO") & "; color:" & dtr_Dia("COR_FONTE") & "; font-weight: bold; text-align: center; vertical-align: middle'>" & dtr_Dia("PLANNER_SIGLA") & "</span></h6></a>"
                                       )
                            Else
                                NewCell("<a href=Planificar.aspx?dia=" & Format(dia, "00") & "&mes=" & Format(mes, "00") & "&ano=" & Format(ano, "0000") & ">" & Format(dia, "00") & "</a>")
                            End If
                        End If
                        dia = dia + 1
                    End If
                Next
            Next

            'CALENDARIO DA LOJA
            dia = 1
            For linha = 1 To dtr("ULTIMA_SEMANA_MES")
                NewRow(tb_CALENDARIO_LOJA)

                For coluna = 1 To 7
                    celula = celula + 1
                    If celula < dtr("DIA_SEMANA") Then
                        NewCell("")
                    Else
                        If dia > dtr("ULTIMO_DIA_MES") Then
                            NewCell("")
                        Else
                            Dim sql_loja As String = ""
                            Dim DATA_ID_LOJA As Double = Val(Format(ano, "0000") & Format(mes, "00") & Format(dia, "00"))
                            sql_loja = "Select * From VIEW_PLANNER_LOJA WHERE DATA_ID = " & DATA_ID_LOJA & " AND LOJA_SIGLA = '" & Session("LOJA_SIGLA") & "' ORDER BY DATA_ID, ORDEM"
                            Dim dtr_Dia_loja As Data.SqlClient.SqlDataReader = m.ExecuteSelect(sql_loja)
                            If dtr_Dia_loja.HasRows Then
                                Dim str_celula = ""
                                Dim qt_siglas As Integer = 0

                                Do While dtr_Dia_loja.Read
                                If qt_siglas = 0 Then str_celula &= "<div h-100 justify-content-top align-items-left>" & Right(dtr_Dia_loja("DATA_ID"), 2) & "</div>"
                                str_celula &= "<h6 h-100 justify-content-center align-items-center>"
                                str_celula &= "<span class='badge' style ='background-color:" & dtr_Dia_loja("COR_FUNDO") & "; color:" & dtr_Dia_loja("COR_FONTE") & "; font-weight: bold; text-align: center; vertical-align: middle'>" & dtr_Dia_loja("PLANNER_SIGLA") & "-" & dtr_Dia_loja("QTD_COLABORADORES") & "</span></h6></a>"
                                qt_siglas = qt_siglas + 1
                                Loop
                                NewCell(str_celula)

                            Else
                                NewCell("<div h-100 justify-content-top align-items-left>" & Format(dia, "00") & "</div>")
                            End If
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
    End Sub

End Class