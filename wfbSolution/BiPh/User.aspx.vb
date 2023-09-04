Public Class User
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m.CheckLogin()
        m.CheckString(Request.QueryString("UserEmail"), "Users.aspx")
        Page.Title = Request.QueryString("UserEmail")

        dtsUser.SelectCommand = "Select * From vw_Users Where Email = '" & Request.QueryString("UserEmail") & "'"
        dtsUser.DataBind()

    End Sub

End Class
