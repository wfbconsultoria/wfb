
Partial Class _Default
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        On Error GoTo Err_Default_Load


        Exit Sub
Err_Default_Load:
    End Sub
End Class
