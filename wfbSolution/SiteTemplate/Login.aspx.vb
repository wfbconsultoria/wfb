
Partial Class Login
    Inherits System.Web.UI.Page

    ReadOnly M As New clsMaster

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("EMAIL_LOGIN") = ""
        Session("NOME_LOGIN") = ""
        Session("PERFIL_LOGIN") = ""
        Session("NIVEL_LOGIN") = ""
    End Sub

    Private Sub cmdLogin_ServerClick(sender As Object, e As EventArgs) Handles cmdLogin.ServerClick

        If Len(txtEmail.Value) = 0 Then
            M.Alert(Me, "PREENCHER EMAIL", False, "")
            Exit Sub
        End If
        If Len(txtPassword.Value) = 0 Then
            M.Alert(Me, "PREENCHER SENHA", False, "")
            Exit Sub
        End If

        If M.CheckExists("TBL_USUARIOS", "EMAIL", txtEmail.Value) = False Then
            M.Alert(Me, "USUÁRIO NÃO EXISTE", False, "")
            Exit Sub
        Else
            Dim SQL As String = "Select * From TBL_USUARIOS Where EMAIL = '" & txtEmail.Value & "' and SENHA = '" & txtPassword.Value & "'"
            Dim DTR = M.ExecuteSelect(SQL)
            DTR.Read()
            If DTR.HasRows Then
                If DTR("BLOQUEADO") = "1" Then
                    M.Alert(Me, "USUÁRIO BLOQUEADO", False, "")
                    Exit Sub
                End If
                If DTR("ATIVO") = "0" Then
                    M.Alert(Me, "USUÁRIO INATIVO", False, "")
                    Exit Sub
                End If
                If DTR("NIVEL") = "99" Then
                    M.Alert(Me, "USUÁRIO SEM NIVEL DE ACESSO", False, "")
                    Exit Sub
                End If

                Session("EMAIL_LOGIN") = DTR("EMAIL")
                Session("NOME_LOGIN") = DTR("APELIDO")
                Session("PERFIL_LOGIN") = DTR("COD_FUNCAO")
                Session("NIVEL_LOGIN") = DTR("NIVEL")

                Response.Redirect("Default.aspx")
            Else
                M.Alert(Me, "SENHA INVÁLIDA", False, "")
                Exit Sub
            End If
        End If
    End Sub
End Class
