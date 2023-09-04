Public Class Planificar
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Public DATA_ID As Double
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txt_DATA.Value = Format(Val(Request.QueryString("dia")), "00") & "/" & Format(Val(Request.QueryString("mes")), "00") & "/" & Format(Val(Request.QueryString("ano")), "0000")
        DATA_ID = Val(Format(Val(Request.QueryString("ano")), "0000") & Format(Val(Request.QueryString("mes")), "00") & Format(Val(Request.QueryString("dia")), "00"))

    End Sub

    Private Sub cmd_PLANIFICAR_Click(sender As Object, e As EventArgs) Handles cmd_PLANIFICAR.Click
        Dim sql As String
        Dim HORA_INICIO As String = "08:00"
        Dim HORA_FINAL As String = "18:00"

        sql = "DELETE FROM TBL_PLANNER WHERE DATA_ID = " & DATA_ID & " AND LOJA_SIGLA = '" & Session("LOJA_SIGLA") & "' AND EMAIL = '" & Session("EMAIL_LOGIN") & "'"
        m.ExecuteSQL(sql)
        sql = "INSERT TBL_PLANNER (LOJA_SIGLA, EMAIL, DATA_ID, PLANNER_SIGLA,HORA_INICIO, HORA_FINAL) VALUES ("
        sql &= "'" & Session("LOJA_SIGLA") & "', '" & Session("EMAIL_LOGIN") & "', " & DATA_ID & ", '" & cmb_PLANNER_SIGLA.Text & "', '" & HORA_INICIO & "', '" & HORA_FINAL & "')"
        m.ExecuteSQL(sql)
        Response.Redirect("Calendario_Mes.aspx")
    End Sub

    Private Sub cmd_CANCELAR_Click(sender As Object, e As EventArgs) Handles cmd_CANCELAR.Click
        Response.Redirect("Calendario_Mes.aspx")
    End Sub
End Class