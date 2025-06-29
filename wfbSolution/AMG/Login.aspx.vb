
Imports wsCorreios

Partial Class Login
    Inherits System.Web.UI.Page
    ReadOnly M As New clsMaster

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("ID_LOGIN") = ""
        Session("APELIDO") = ""
        Session("PERFIL_LOGIN") = ""
        Session("ID_PERFIL_LOGIN") = ""
        Session("IP_LOGIN") = ""
    End Sub

    Private Sub cmdLogin_ServerClick(sender As Object, e As EventArgs) Handles cmdLogin.ServerClick
        If ValidateLogin() = True Then Response.Redirect("Default.aspx")
    End Sub

    Private Sub cmdChangePassword_ServerClick(sender As Object, e As EventArgs) Handles cmdChangePassword.ServerClick

        If ValidateLogin() = False Then Exit Sub

        If Len(NewPassword.Value) = 0 Then
            M.Alert(Me, "DIGITE A NOVA SENHA", False, "")
            Exit Sub
        End If

        If Len(NewPasswordConfirm.Value) = 0 Then
            M.Alert(Me, "DIGITE A CONFIRMAÇÃO DA NOVA SENHA", False, "")
            Exit Sub
        End If

        If NewPasswordConfirm.Value <> NewPassword.Value Then
            M.Alert(Me, "AS SENHA E CONFIRMAÇÃO DEVEM SER IGUAIS", False, "")
            Exit Sub
        End If

        M.ExecuteSQL("Update TBL_USUARIOS SET SENHA = '" & NewPassword.Value & "' WHERE ID = '" & Session("ID_LOGIN") & "'")
        Response.Redirect("Login.aspx")
    End Sub

    Public Function ValidateLogin() As Boolean
        ValidateLogin = False

        'valida se email esta preenchido
        If Len(txtApelido.Value) = 0 Then
            M.Alert(Me, "PREENCHER APELIDO", False, "")
            Exit Function
        End If
        'valida se senha esta preenchida
        If Len(txtSenha.Value) = 0 Then
            M.Alert(Me, "PREENCHER SENHA", False, "")
            Exit Function
        End If
        'valida se usuario existe
        If M.CheckExists("TBL_USUARIOS", "APELIDO", txtApelido.Value) = False Then
            M.Alert(Me, "USUÁRIO NÃO EXISTE", False, "")
            Exit Function
        End If
        'valida usuario e senha e se esta ativo
        Dim SQL As String = "Select * From VW_USUARIOS_ATIVOS Where APELIDO = '" & txtApelido.Value & "' and SENHA = '" & txtSenha.Value & "'"
        Dim DTR = M.ExecuteSelect(SQL)
        DTR.Read()
        If DTR.HasRows Then
            If DTR("ATIVO") = "0" Then
                M.Alert(Me, "USUÁRIO INATIVO", False, "")
                Exit Function
            End If
            Session("ID_LOGIN") = DTR("ID").ToString
            Session("APELIDO_LOGIN") = DTR("APELIDO")
            Session("PERFIL_LOGIN") = DTR("PERFIL")
            Session("ID_PERFIL_LOGIN") = DTR("ID_PERFIL")
            Session("IP_LOGIN") = Request.ServerVariables("REMOTE_ADDR").ToString
            M.ExecuteSQL("Insert Into TBL_USUARIOS_LOGINS (ID_USUARIO) Values ('" & Session("ID_LOGIN") & "')")
        Else
            M.Alert(Me, "SENHA INVÁLIDA", False, "")
            Exit Function
        End If

        ValidateLogin = True

    End Function
End Class
