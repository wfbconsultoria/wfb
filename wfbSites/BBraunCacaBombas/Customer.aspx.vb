
Partial Class Customer
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
        If Request.QueryString("ID") = "" Then
            m.Alert(Me, "Selecione o cliente", True, "Customers.aspx")
        End If
        Session("Customer_Id") = Request.QueryString("ID").ToString

        sql = ""
        sql = "Select * From vw_Customers Where Customer_Id = '" & Session("Customer_Id").ToString & "'"
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            txt_Customer_Id.Text = dtr("Customer_Code").ToString
            txt_Customer_Name.Text = dtr("Customer_Name").ToString
            txt_Pumps_Qtde.Text = dtr("Pumps_Qtde").ToString
            txt_Pumps_Qtde_OK.Text = dtr("Pumps_OK").ToString
            txt_CNES_Pumps.Text = dtr("CNES_Pumps-Qtde").ToString
            txt_Customer_Address.Text = dtr("Customer_Address").ToString
            txt_Customer_City.Text = dtr("Customer_City").ToString
            txt_Customer_Account_Executive.Text = "B|Braun Account Executive"
            txt_Customer_Nurse.Text = "B|Braun Nurse"
        End If
        dtr.Close()
        CN.Close()

    End Sub
End Class
