Public Class clsIV

    Public cnnIV As System.Data.SqlClient.SqlConnection
    ReadOnly m As New clsMaster
    Public Function DatabaseConnect() As Boolean
        On Error GoTo Err_DatabaseConnect

        DatabaseConnect = False
        cnnIV = New System.Data.SqlClient.SqlConnection
        cnnIV.ConnectionString = ConfigurationManager.ConnectionStrings("IVConnection").ConnectionString
        cnnIV.Open()
        DatabaseConnect = True
        Exit Function

Err_DatabaseConnect:
        DatabaseConnect = False
        m.SystemError(Err.Number, Err.Description, "", "Function: clsIV.DatabaseConnect")
    End Function
End Class
