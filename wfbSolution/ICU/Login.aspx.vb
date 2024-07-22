
Partial Class Login
    Inherits System.Web.UI.Page
    ReadOnly M As New clsMaster

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("EMAIL_LOGIN") = ""
        Session("NOME_LOGIN") = ""
        Session("NIVEL_LOGIN") = ""
        Session("IP_LOGIN") = ""
    End Sub

    Private Sub cmdLogin_ServerClick(sender As Object, e As EventArgs) Handles cmdLogin.ServerClick
        Response.Redirect("Default.aspx")
    End Sub

    Private Sub cmdChangePassword_ServerClick(sender As Object, e As EventArgs) Handles cmdChangePassword.ServerClick
        Response.Redirect("Login.aspx")
    End Sub

    Public Function ValidateLogin() As Boolean
        ValidateLogin = False
        'valida se email esta preenchido
        If Len(txtEmail.Value) = 0 Then
            M.Alert(Me, "PREENCHER EMAIL", False, "")
            Exit Function
        End If
        'valida se senha esta preenchida
        If Len(txtPassword.Value) = 0 Then
            M.Alert(Me, "PREENCHER SENHA", False, "")
            Exit Function
        End If
        'valida se usuario existe
        If M.CheckExists("TBL_USUARIOS", "EMAIL", txtEmail.Value) = False Then
            M.Alert(Me, "USUÁRIO NÃO EXISTE", False, "")
            Exit Function
        End If
        'valida usuario e senha e se esta ativo
        Dim SQL As String = "Select * From TBL_USUARIOS Where EMAIL = '" & txtEmail.Value & "' and SENHA = '" & txtPassword.Value & "'"
        Dim DTR = M.ExecuteSelect(SQL)
        DTR.Read()
        If DTR.HasRows Then
            If DTR("ATIVO") = "0" Then
                M.Alert(Me, "USUÁRIO INATIVO", False, "")
                Exit Function
            End If
            Session("EMAIL_LOGIN") = DTR("EMAIL")
            Session("NOME_LOGIN") = DTR("NOME")
            Session("NIVEL_LOGIN") = DTR("NIVEL")
            Session("IP_LOGIN") = Request.ServerVariables("REMOTE_ADDR").ToString
            M.ExecuteSQL("Insert Into TBL_USUARIOS_LOGIN (EMAIL) Values ('" & Session("EMAIL_LOGIN") & "')")
        Else
            M.Alert(Me, "SENHA INVÁLIDA", False, "")
            Exit Function
        End If
    End Function
End Class
