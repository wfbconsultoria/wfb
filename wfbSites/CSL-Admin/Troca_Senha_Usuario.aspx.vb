
Partial Class Troca_Senha_Usuario
    Inherits System.Web.UI.Page

    Dim M As New clsMaster
    Dim CN As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String
    Dim Mensagem As String
    Dim Usuario As String
    Dim Senha As String

    Dim Pagina As String = "Troca_Senha_Usuario.aspx"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Default.aspx")
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
        End If
    End Sub

    Protected Sub cmd_Gravar_Click(sender As Object, e As System.EventArgs) Handles cmd_Gravar.Click
        Pagina = "Troca senha"
        Dim Senha As String
        Senha = txt_Senha.Text
        sql = ""
        sql = sql & " Update TBL_USUARIOS Set SENHA = '" & Senha & "' Where EMAIL = '" & Session("EMAIL_LOGIN") & "'"

        If M.ExecutarSQL(sql) = True Then
            M.LogPagina(Session("SESSAO_LOGIN").ToString, Session("IP_LOGIN").ToString, Session("EMAIL_LOGIN").ToString, Pagina, "TROCOU SENHA ", "email=" & Session("EMAIL_LOGIN") & "  senha=" & Senha)
            Mensagem = "TROCA DE SENHA " & Chr(10) & Chr(10)
            Mensagem = Mensagem & "Sua senha de acesso ao " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString & " foi atualizada com sucesso." & Chr(10)
            Mensagem = Mensagem & "E-MAIL: " & Session("EMAIL_LOGIN") & Chr(10)
            Mensagem = Mensagem & "SENHA: " & Senha & Chr(10)
            Mensagem = Mensagem & "DATA/HORA: " & Now() & Chr(10)
            M.EnviarEmail("TROCA DE SENHA", Mensagem, True, False, Session("EMAIL_LOGIN"), "")
            Alert("SENHA ATUALIZADA COM SUCESSO", True, "Login.aspx")
        Else
            Mensagem = "ERRO - TROCA DE SENHA - " & Now() & Chr(10)
            Mensagem = Mensagem & "E-MAIL: " & Session("EMAIL_LOGIN") & Chr(10)
            Mensagem = Mensagem & "Por: " & Session("EMAIL_LOGIN")
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO AO ALTERAR SENHA", Session("EMAIL_LOGIN"))
            M.EnviarEmail("ERRO - TROCA DE SENHA", Mensagem, True, False, "", "")
            Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
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
