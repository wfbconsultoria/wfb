
Partial Class Forgot
    Inherits System.Web.UI.Page
    ReadOnly M As New clsMaster
    Private Sub cmdRecover_ServerClick(sender As Object, e As EventArgs) Handles cmdRecover.ServerClick

        If Len(txtEmail.Value) = 0 Then
            M.Alert(Me, "PREENCHER EMAIL", False, "")
            Exit Sub
        End If


        If M.CheckExists("TBL_USUARIOS", "EMAIL", txtEmail.Value) = False Then
            M.Alert(Me, "USUÁRIO NÃO EXISTE", False, "")
            Exit Sub
        Else
            Dim SQL As String = "Select * From TBL_USUARIOS Where EMAIL = '" & txtEmail.Value & "'"
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

                M.SendMail(txtEmail.Value, txtEmail.Value, "Password Recovery", "Your Password is: " & DTR("SENHA"))

                Session("EMAIL_LOGIN") = DTR("EMAIL")
                Session("NOME_LOGIN") = DTR("APELIDO")
                Session("PERFIL_LOGIN") = DTR("COD_FUNCAO")
                Session("NIVEL_LOGIN") = DTR("NIVEL")
                Session("IP_LOGIN") = Request.ServerVariables("REMOTE_ADDR").ToString
                Session("LINK_PBI_LOGIN") = DTR("LINK_RELATORIO")

                M.ExecuteSQL("Insert Into TBL_USUARIOS_LOGIN (EMAIL) Values ('" & Session("EMAIL_LOGIN") & "')")
                Response.Redirect("Login.aspx")
            End If
        End If


    End Sub
End Class
