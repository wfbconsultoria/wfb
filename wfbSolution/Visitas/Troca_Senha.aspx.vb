
Partial Class Troca_Senha
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim CN As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String
    Dim Mensagem As String
    Dim Usuario As String
    Dim Senha As String
    Dim Pagina As String = "Troca_Senha.aspx"
   
    Protected Sub cmd_Troca_Senha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Troca_Senha.Click

        'VERIFICA SE O EMAIL INFORMADO EXISTE E NÃO ESTÁ BLOQUEADO
        sql = ""
        sql = "Select EMAIL From TBL_USUARIOS Where EMAIL = '" & txt_EMAIL.Text & "' And ATIVO = 'True' And BLOQUEADO  = 'False' "
        CN.ConnectionString = M.cnnStr
        CN.Open()
        cmd.Connection = CN
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            Senha = M.GerarSenha
            sql = ""
            sql = sql & " Update TBL_USUARIOS Set SENHA = '" & Senha & "' Where EMAIL = '" & txt_EMAIL.Text & "'"

            If M.ExecutarSQL(sql) = True Then
                'M.LogPagina(Session("SESSAO_LOGIN").ToString, Session("IP_LOGIN").ToString, Session("EMAIL_LOGIN").ToString, Pagina, "ALTEROU SENHA ", "email=" & txt_EMAIL.Text & "  senha=" & Senha)
                Mensagem = "TROCA DE SENHA " & Chr(10) & Chr(10)
                Mensagem = Mensagem & "Sua senha de acesso ao " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString & " foi atualizada com sucesso." & Chr(10)
                Mensagem = Mensagem & "E-MAIL: " & txt_EMAIL.Text & Chr(10)
                Mensagem = Mensagem & "SENHA: " & Senha & Chr(10)
                Mensagem = Mensagem & "DATA/HORA: " & Now() & Chr(10)
                Mensagem = Mensagem & "Você DEVERÁ trocar por uma senha de sua escolha após acessar o sistema no menu Troca de Senha"
                M.EnviarEmail("SOLICITAÇÃO DE NOVA SENHA", Mensagem, True, True, txt_EMAIL.Text, "")
                Alert("SOLICITAÇÃO REALIZADA COM SUCESSO", True, "Login.aspx")
            Else
                Mensagem = "ERRO - SOLICITAÇÃO DE NOVA SENHA - " & Now() & Chr(10)
                Mensagem = Mensagem & "E-MAIL: " & txt_EMAIL.Text & Chr(10)
                Mensagem = Mensagem & "Por: " & Session("EMAIL_LOGIN")
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO AO ALTERAR SENHA", Session("EMAIL_LOGIN"))
                M.EnviarEmail("ERRO - SOLICITAÇÃO DE NOVA SENHA", Mensagem, True, False, "", "")
                Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", True, "Login.aspx")
            End If
        Else
            Alert("O EMAIL INFORMADO NÃO EXISTE OU ESTÁ BLOQUEADO PARA ACESSO", True, "Login.aspx")
        End If
    End Sub

    Protected Function Alert(ByVal Texto_Mensagem As String, ByVal Redirecionar As Boolean, ByVal Pagina As String) As Boolean
        Dim jscript As String
        'CAIXA DE MENSAGEM
        If Redirecionar = True Then
            jscript = ""
            jscript += "<script language='JavaScript'>"
            jscript += ";alert('" & Texto_Mensagem & "'); document.location.href='" & Pagina & "'"
            jscript += "</script>"
        Else
            jscript = ""
            jscript += "<script language='JavaScript'>"
            jscript += ";alert('" & Texto_Mensagem & "');"
            jscript += "</script>"
        End If
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Mensagem", jscript)
        Alert = True
    End Function

End Class
