Public Class User_Password_Change
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If m.CheckLogin(False) = False Then
            m.Alert(Me, "Você deve estar logado para alterar a senha", True, "Default.aspx")
            Exit Sub
        End If

        If IsPostBack() = True Then SaveRecord()
    End Sub
    Sub SaveRecord()
        Dim sql As String
        Dim senha_atual As String

        If txt_Senha_Nova.Value <> txt_Senha_Confirmacao.Value Then
            m.Alert(Me, "A nova senha está diferente da confirmação")
            Exit Sub
        End If

        'verifica se asenha atual está correta
        sql = "Select SENHA From TBL_USUARIOS Where EMAIL = '" & Session("EMAIL_LOGIN").ToString & "' And SENHA = '" & txt_Senha_Atual.Value & "'"
        Dim dtr = m.ExecuteSelect(sql)
        If dtr.HasRows Then
            dtr.Read()
            senha_atual = dtr("SENHA")
            sql = "Update TBL_USUARIOS Set SENHA = '" & txt_Senha_Nova.Value & "' Where EMAIL = '" & Session("EMAIL_LOGIN").ToString & "'"
            If m.ExecuteSQL(sql) = True Then
                m.Alert(Me, "Senha atualizada com sucesso!", True, "Login.aspx")
            End If
        Else
            m.Alert(Me, "Senha atual está incorreta!")
            Exit Sub
        End If

Err_cmd_Salvar_ServerClick:

    End Sub
End Class