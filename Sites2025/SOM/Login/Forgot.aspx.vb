
Partial Class Login_Forgot
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
            Dim NOME As String = DTR("NOME")
            If DTR.HasRows Then
                If DTR("ATIVO") = "0" Then
                    M.Alert(Me, "USUÁRIO INATIVO", False, "")
                    Exit Sub
                End If

                Dim NOVA_SENHA = ConfigurationManager.AppSettings("App.Initials") & M.GeneratePassword
                SQL = ""
                SQL &= "UPDATE [dbo].[TBL_USUARIOS] SET "
                SQL &= "SENHA = '" & NOVA_SENHA & "'"
                SQL &= ",SENHA_SISTEMA = '" & NOVA_SENHA & "'"
                SQL &= " WHERE EMAIL = '" & txtEmail.Value & "'"
                M.ExecuteSQL(SQL)
                Dim strMESSAGE = ""
                strMESSAGE &= NOME & ",o sistema enviou uma NOVA SENHA! <br/>"
                strMESSAGE &= "Acesse https://icumedical.azurewebsites.net <br/> "
                strMESSAGE &= "Utilize seu EMAIL e a senha temporária " & NOVA_SENHA & "<br/>"
                strMESSAGE &= "Você deverá susbtituir pela senha de sua preferencia após o primeiro login <br/>"
                M.SendMail(txtEmail.Value, NOME, ConfigurationManager.AppSettings("App.Initials") & " - RECUPERAÇÃO DE SENHA", strMESSAGE)
                M.Alert(Me, "FOI ENVIADO UM EMAIL COM A NOVA SENHA", True, "Login.aspx")
            End If
        End If
    End Sub
End Class
