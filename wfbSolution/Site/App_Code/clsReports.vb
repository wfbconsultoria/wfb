Public Class clsReports
    ReadOnly l As New clsLojas
    Public Function sqlDashboard(Nivel As String, Optional Ordem As String = "") As String
        sqlDashboard = "Select * From bi_DashBoard Where Loja_Sigla = '" & l.Loja_Sigla & "' and Id_Nivel = '" & Nivel & "' Order By Nivel "
        If Ordem <> "" Then
            sqlDashboard = sqlDashboard & ", " & Ordem
        End If
    End Function

End Class
