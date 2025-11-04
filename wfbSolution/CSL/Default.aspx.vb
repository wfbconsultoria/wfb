
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page
    ReadOnly M As New clsMaster
    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load

        If IsNothing(HttpContext.Current.Session("EMAIL_LOGIN")) Or HttpContext.Current.Session("EMAIL_LOGIN") = "" Then
            Response.Redirect("Login.aspx")
        End If

        Dim reportLink As String = ""
        Dim dtr As SqlClient.SqlDataReader
        Dim sql As String = ""
        sql &= " SELECT LINK_PBI FROM TBL_USUARIOS_LINKS "
        sql &= " WHERE EMAIL = '" & Session("EMAIL_LOGIN").ToString & "'"
        dtr = M.ExecuteSelect(sql)
        If dtr.HasRows Then
            dtr.Read()
            reportLink = dtr("LINK_PBI").ToString
            frameReport.Attributes("src") = reportLink
        End If

    End Sub
End Class
