
Partial Class Pump_Register
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim CN As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String
        'ABRE CONEXAO
        CN.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        CN.Open()
        cmd.Connection = CN

        'RECUPERA REGISTRO
        sql = ""
        sql = "Select * From vw_Customers Where Customer_Id = '" & Session("Customer_Id") & "'"
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            txt_Customer_Name.Text = dtr("Customer_Name").ToString
            Session("Pumps_OK") = 0
            Session("Pumps_OK") = dtr("Pumps_OK")
        End If
        dtr.Close()
        CN.Close()
    End Sub

    Private Sub cmd_Register_Click(sender As Object, e As EventArgs) Handles cmd_Register.Click
        Dim sql_pump As String
        Session("Pumps_OK") = Session("Pumps_OK") + 1
        sql_pump = ""
        sql_pump = sql_pump & "Update tb_Customers Set Pumps_OK = " & Session("Pumps_OK") & " Where Customer_Id = '" & Session("Customer_Id") & "'"
        m.ExecuteSQL(sql_pump)
        Response.Redirect("Customer.aspx?ID=" & Session("Customer_Id").ToString)

    End Sub
End Class
