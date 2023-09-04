Public Class Login
    Inherits System.Web.UI.Page
    ReadOnly M As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("EMAIL_LOGIN") = "".ToString
        Session("ADMINSTRADOR") = "".ToString
    End Sub

    Private Sub cmd_LOGIN_ServerClick(sender As Object, e As EventArgs) Handles cmd_LOGIN.ServerClick
        On Error GoTo Err_cmd_LOGIN_ServerClick
        Dim dtr As Data.SqlClient.SqlDataReader
        Dim sql As String
        Dim data_login As String = Now().ToString
        Dim ip_login As String = Request.ServerVariables("REMOTE_ADDR").ToString
        Dim session_login As String = Session.SessionID.ToString
        Dim browser_login As String = Request.ServerVariables("HTTP_USER_AGENT").ToString

        sql = "Select EMAIL, ADMINISTRADOR From TBL_USUARIOS Where EMAIL = '" & txt_EMAIL.Value & "' and SENHA = '" & txt_SENHA.Value & "'"
        dtr = M.ExecuteSelect(sql)

        If dtr.HasRows Then
            dtr.Read()
            Session("EMAIL_LOGIN") = txt_EMAIL.Value.ToString
            Session("ADMINISTRADOR") = dtr("ADMINISTRADOR").ToString
            sql = "Update TBL_USUARIOS Set LOGIN = '" & data_login & "', IP = '" & ip_login & "', SESSAO = '" & session_login & "', BROWSER = '" & browser_login & "' Where EMAIL = '" & txt_EMAIL.Value & "' and SENHA = '" & txt_SENHA.Value & "'"
                M.ExecuteSQL(sql)
                sql = "Insert Into TBL_LOG_SITE (EMAIL, LOGIN, IP, SESSAO, BROWSER) Values ('" & txt_EMAIL.Value & "', '" & data_login & "', '" & ip_login & "', '" & session_login & "', '" & browser_login & "')"
                M.ExecuteSQL(sql)
                Response.Redirect("Default.aspx")
            Else
                M.Alert(Me, "E-Mail ou senha inválido")
        End If
        Exit Sub
Err_cmd_LOGIN_ServerClick:
    End Sub
End Class