Public Class Password_Change
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Dim l As New clsLojas
    Dim c As New clsColaboradores
    Dim sql As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If c.CheckLogin(False) = False Then
            m.Alert(Me, "Você deve estar logado para alterar a senha", True, "Default.aspx")
            Exit Sub
        End If
        RecoverRecord()
        If IsPostBack() = True Then SaveRecord()
    End Sub
    Sub RecoverRecord(Optional NewIdKey As String = "")
        l.GetInfoLoja()
        txt_Loja_Sigla.Value = l.Loja_Sigla
        txt_Loja.Value = l.Loja

        c.GetInfoColaborador("", "", Session("EMAIL_LOGIN"))
        txt_Id.Value = c.ColaboradorId
        txt_Nome.Value = c.ColaboradorNome
        txt_Email.Value = LCase(c.ColaboradorEmail)
    End Sub
    Sub SaveRecord()

        'verifica se asenha atual está correta
        If txt_Senha_Atual.Value <> c.ColaboradorSenha Then
            m.Alert(Me, "A senha atual não confere", False, "")
            Exit Sub
        End If

        If txt_Senha_Nova.Value <> txt_Senha_Confirmacao.Value Then
            m.Alert(Me, "A nova senha está diferente da confirmação", False, "")
            Exit Sub
        End If

        sql = ""
        sql = sql & " Update tb_Colaboradores Set Senha = '" & m.ConvertText(txt_Senha_Nova.Value, clsMaster.TextCaseOptions.TextCase) & "' Where Email = '" & txt_Email.Value & "' and Loja_Sigla = '" & l.Loja_Sigla & "'"
        m.ExecuteSQL(sql)
        c.GetInfoColaborador("", "", Session("EMAIL_LOGIN"))
        Dim msg As String = ""
        msg = msg & "Senha Alterada - " & ConfigurationManager.AppSettings("App.Name") & " - " & l.Loja & " " & "#"
        msg = msg & "Usuário: " & c.ColaboradorEmail & " " & " " & "#"
        msg = msg & "Senha: " & c.ColaboradorSenha & " " & " " & "#"

        m.SendMail(c.ColaboradorEmail, c.ColaboradorNome, ConfigurationManager.AppSettings("App.Name") & " - " & l.Loja & " - ALTERAÇÃO DE SENHA", msg)
        m.Alert(Me, "Senha alterada com sucesso! Email com confirmação da nova senha enviado para " & c.ColaboradorEmail & ". Efetue login novamente", True, "Login.aspx")
    End Sub
End Class