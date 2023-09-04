Public Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        dtsDefault.SelectCommand = "SELECT * FROM [vw_pbi_Reports_Users] Where USER_EMAIL = '" & Context.User.Identity.Name & "' ORDER BY REPORT_NAME"
        dtsDefault.DataBind()
        dtrDefault.DataBind()

    End Sub
End Class