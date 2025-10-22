
Imports System.Data

Partial Class _Default

    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster

    Protected Sub Timer1_Tick(sender As Object, e As EventArgs)
        Dim sql = "Select * From [tb_Postos] "
        Dim d As System.Data.SqlClient.SqlDataReader
        d = m.ExecuteSelect(sql)
        d.Read()

        P01_STATUS.Text = d("P01_STATUS")
        P01_LOCAL.Text = d("P01_LOCAL")
        P01_ALERTA.Text = d("P01_ALERTA")

        P02_STATUS.Text = d("P02_STATUS")
        P02_LOCAL.Text = d("P02_LOCAL")
        P02_ALERTA.Text = d("P02_ALERTA")

        P03_STATUS.Text = d("P03_STATUS")
        P03_LOCAL.Text = d("P03_LOCAL")
        P03_ALERTA.Text = d("P03_ALERTA")

        P04_STATUS.Text = d("P04_STATUS")
        P04_LOCAL.Text = d("P04_LOCAL")
        P04_ALERTA.Text = d("P04_ALERTA")

        P05_STATUS.Text = d("P05_STATUS")
        P05_LOCAL.Text = d("P05_LOCAL")
        P05_ALERTA.Text = d("P05_ALERTA")

        P06_STATUS.Text = d("P06_STATUS")
        P06_LOCAL.Text = d("P06_LOCAL")
        P06_ALERTA.Text = d("P06_ALERTA")

        P07_STATUS.Text = d("P07_STATUS")
        P07_LOCAL.Text = d("P07_LOCAL")
        P07_ALERTA.Text = d("P07_ALERTA")

        P08_STATUS.Text = d("P08_STATUS")
        P08_LOCAL.Text = d("P08_LOCAL")
        P08_ALERTA.Text = d("P08_ALERTA")

        P09_STATUS.Text = d("P09_STATUS")
        P09_LOCAL.Text = d("P09_LOCAL")
        P09_ALERTA.Text = d("P09_ALERTA")

        P10_STATUS.Text = d("P10_STATUS")
        P10_LOCAL.Text = d("P10_LOCAL")
        P10_ALERTA.Text = d("P10_ALERTA")

        P11_STATUS.Text = d("P11_STATUS")
        P11_LOCAL.Text = d("P11_LOCAL")
        P11_ALERTA.Text = d("P11_ALERTA")

        P12_STATUS.Text = d("P12_STATUS")
        P12_LOCAL.Text = d("P12_LOCAL")
        P12_ALERTA.Text = d("P12_ALERTA")

        P13_STATUS.Text = d("P13_STATUS")
        P13_LOCAL.Text = d("P13_LOCAL")
        P13_ALERTA.Text = d("P13_ALERTA")

        P14_STATUS.Text = d("P14_STATUS")
        P14_LOCAL.Text = d("P14_LOCAL")
        P14_ALERTA.Text = d("P14_ALERTA")

        P15_STATUS.Text = d("P15_STATUS")
        P15_LOCAL.Text = d("P15_LOCAL")
        P15_ALERTA.Text = d("P15_ALERTA")

    End Sub

    Private Sub cmdResetAll_Click(sender As Object, e As EventArgs) Handles cmdResetAll.Click
        Dim SQL As String = ""
        SQL &= "EXEC dbo.proc_LiberarTodos"
        m.ExecuteSQL(SQL)

    End Sub

    Private Sub cmdAlertAll_Click(sender As Object, e As EventArgs) Handles cmdAlertAll.Click
        Dim SQL As String = ""
        SQL &= "EXEC dbo.proc_AlertarTodos"
        m.ExecuteSQL(SQL)
    End Sub

    Public Function FormataAtivo(Parameter As String) As String
        FormataAtivo = "alert-danger text-center"
        If Parameter = "Sim" Then FormataAtivo = "alert-success text-center"
    End Function
    Public Function FormataIcone(Parameter As Integer) As String
        FormataIcone = "Images/SQUARE_GREEN.png"
        If Parameter = 1 Then FormataIcone = "Images/SQUARE_RED.png"
    End Function
End Class
