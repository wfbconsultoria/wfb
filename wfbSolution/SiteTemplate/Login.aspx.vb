
Partial Class Login
    Inherits System.Web.UI.Page

    ReadOnly M As New clsMaster

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("EMAIL_LOGIN") = ""
    End Sub

    Private Sub cmdLogin_ServerClick(sender As Object, e As EventArgs) Handles cmdLogin.ServerClick
        If M.CheckExists("TBL_USUARIOS", "EMAIL", txtEmail.Value) = False Then
            M.Alert(Me, "Usuário não cadastrado", True, "Login.aspx")
        Else
            Session("EMAIL_LOGIN") = txtEmail.Value
            Response.Redirect("Default.aspx")
        End If
    End Sub
End Class
