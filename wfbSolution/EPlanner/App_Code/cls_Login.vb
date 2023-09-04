
Imports System.Data

Public Class cls_Login
    ReadOnly m As New clsMaster

    Public Function Login(Email As String, Senha As String) As Integer
        Dim d As SqlClient.SqlDataReader
        Dim sql As String
        Dim qt_Id As Integer
        Dim Id As Long

        Try
            SessionVariables_Reset()
            qt_Id = 0
            sql = ""
            sql &= "EXEC sp_Login "
            sql &= "'" & Email & "',"
            sql &= "'" & Senha & "',"
            sql &= "'" & ConfigurationManager.AppSettings("Loja_Sigla") & "'"
            d = m.ExecuteSelect(sql)
            d.Read()
            qt_Id = d("qt_Id")
            Id = d("Id")

            If qt_Id = 1 Then
                sql = ""
                sql &= "EXEC sp_log_site "
                sql &= "'" & ConfigurationManager.AppSettings("App.Name") & "',"
                sql &= "'" & ConfigurationManager.AppSettings("Loja_Sigla") & "',"
                sql &= "'" & Id & "',"
                sql &= "'" & Email & "'"
                m.ExecuteSQL(sql)
            End If

        Catch

        End Try
        Login = qt_Id
    End Function

    Public Function SessionVariables_Reset() As Boolean

        SessionVariables_Reset = False
        Try
            HttpContext.Current.Session.RemoveAll()
            HttpContext.Current.Session("Login_Email") = ""
            HttpContext.Current.Session("Login_Colaborador") = ""
            HttpContext.Current.Session("Login_Funcao_Sigla") = ""
            HttpContext.Current.Session("Login_Funcao") = ""
            HttpContext.Current.Session("Login_Loja_Sigla") = ""
            HttpContext.Current.Session("Login_Loja") = ""
            HttpContext.Current.Session("Login_Universo_Sigla") = ""
            HttpContext.Current.Session("Login_Universo") = ""
            HttpContext.Current.Session("Login_Administrador") = ""
            HttpContext.Current.Session("Login_Date") = ""
            HttpContext.Current.Session("Login_Session") = ""
            HttpContext.Current.Session("Login_Ip") = ""
            HttpContext.Current.Session("Login_Browser") = ""

        Catch
            SessionVariables_Reset = False
        End Try

    End Function
End Class



