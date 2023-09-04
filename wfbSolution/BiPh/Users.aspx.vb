Public Class Users
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m.CheckLogin()

        dtsTable.SelectCommand = "Select * From vw_Users"
        dtsTable.DataBind()
    End Sub

End Class
