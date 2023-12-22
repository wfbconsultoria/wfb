
Imports System.Data

Partial Class _Default
    Inherits System.Web.UI.Page
    ReadOnly M As New clsMaster
    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load

        If IsNothing(HttpContext.Current.Session("EMAIL_LOGIN")) Or HttpContext.Current.Session("EMAIL_LOGIN") = "" Then
            Response.Redirect("Login.aspx")
        End If

        pbiReport.Src = ""

        Dim pbiLink As String
        pbiLink = ""
        Dim dtr As SqlClient.SqlDataReader
        Dim sql As String = ""
        sql &= " SELECT LINK_RELATORIO FROM TBL_USUARIOS "
        sql &= " WHERE EMAIL = '" & Session("EMAIL_LOGIN").ToString & "'"
        dtr = m.ExecuteSelect(sql)
        If dtr.HasRows Then
            dtr.Read()
            pbiLink = dtr("LINK_RELATORIO").ToString
            pbiReport.Src = pbiLink
        End If

    End Sub
End Class
