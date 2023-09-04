Imports Microsoft.VisualBasic

Public Class clsFiscal
    Public ANO As String
    Public MES As String
    Public Function Ano_Mes_Fiscal(ANO_FISCAL As String, MES_FISCAL As String) As Boolean
        On Error GoTo Err_Ano_Fiscal
        Ano_Mes_Fiscal = False

        'Váriaveis Padrão de Banco
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String

        sql = "Select DISTINCT ANO, MES From VIEW_DATAS Where ANO_FISCAL = '" & ANO_FISCAL & "' AND MES_FISCAL = '" & MES_FISCAL & "'"

        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnstr").ConnectionString
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("ANO")) Then ANO = dtr("ANO")
            If Not IsDBNull(dtr("MES")) Then MES = dtr("MES")
            Ano_Mes_Fiscal = True
            dtr.Close()
        Else
            Ano_Mes_Fiscal = False
        End If
        cnn.Close()
Err_Ano_Fiscal:
        Ano_Mes_Fiscal = False
    End Function
End Class
