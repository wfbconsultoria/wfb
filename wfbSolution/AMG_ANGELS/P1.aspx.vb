Imports System.Data
Partial Class P1
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Dim posto As String = "P01"
    Private Sub P1_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim d As System.Data.SqlClient.SqlDataReader
        Dim sql = ""
        sql &= "Select "
        sql &= posto & "_STATUS, "
        sql &= posto & "_LOCAL, "
        sql &= posto & "_ALERTA, "
        sql &= posto & "_FISCAL "
        sql &= "From tb_postos"
        d = m.ExecuteSelect2(sql)
        d.Read()

        POSTO_LOCAL.Text = posto & " - " & d(1)
        POSTO_FISCAL.Text = d(3)

    End Sub

    Private Sub cmdAlert_Click(sender As Object, e As EventArgs) Handles cmdAlert.Click
        Dim SQL As String
        Dim ALERTA As String = "PISTA ESCORREGADIA"
        Dim STATUS As Integer = 1
        Dim CNN2 As System.Data.SqlClient.SqlConnection
        CNN2 = New System.Data.SqlClient.SqlConnection
        CNN2.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        CNN2.Open()

        Dim cmd2 As System.Data.SqlClient.SqlCommand = CNN2.CreateCommand
        SQL = "Update tb_Postos Set " & posto & "_STATUS = " & STATUS & ", " & posto & "_ALERTA = '" & ALERTA & "' "
        cmd2.CommandText = SQL
        cmd2.ExecuteNonQuery()

    End Sub

End Class
