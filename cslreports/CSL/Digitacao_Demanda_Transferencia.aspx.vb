
Partial Class Digitacao_Demanda_Transferencia
    Inherits System.Web.UI.Page
    Public jscript As String
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Digitacao_Demanda_Transferencia.aspx"
    Dim Titulo As String = "Transferência de Demanda- " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
    Dim sql As String

    'Váriáveis da Página

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = True 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = False 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = False 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = False 'Cordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = False 'Representante
        If Session("COD_PERFIL_LOGIN") = 10 Then Acesso = False 'Key Account
        If Session("COD_PERFIL_LOGIN") = 20 Then Acesso = False 'Visitante
        If Session("COD_PERFIL_LOGIN") = 30 Then Acesso = False 'Distribuidor
        If Session("SISTEMA") <> True Then Acesso = True 'Sistema

        'Verifica se o perfil do usuário tem acesso a página
        If Acesso = True Then
            'Grava log de permissão de acesso
            If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSO PERMITIDO", "")
                Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
                Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
            End If
        Else
            'Grava log de recusa de acesso
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSO RECUSADO", "")
            Alert("Seu perfil de usuário não permite acesso a esta página!", True, "Default.aspx")
        End If
        '____________________________________________________________________________________________________________________________________________

    End Sub
    Protected Sub cmd_Gravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Gravar.Click
        Dim sql As String
        Dim Mensagem As String
        Dim OK As Boolean

        OK = False
        'DEMANDA
        sql = ""
        sql = sql & " Update TBL_MOVIMENTO_DEMANDA "
        sql = sql & " SET CNPJ_ESTABELECIMENTO = " & cmb_CNPJ_ESTABELECIMENTO_PARA.Text & ", "
        sql = sql & " DEMANDA_TRANSFERIDA_DE = " & cmb_CNPJ_ESTABELECIMENTO_DE.Text & ", "
        sql = sql & " DEMANDA_TRANSFERIDA_EM =" & M.RecuperaData & ", "
        sql = sql & " DEMANDA_TRANSFERIDA_POR = '" & Session("EMAIL_LOGIN") & "' "
        sql = sql & " Where CNPJ_ESTABELECIMENTO = " & cmb_CNPJ_ESTABELECIMENTO_DE.Text

        If M.ExecutarSQL(sql) = True Then
            OK = True
        Else
            OK = False
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO TRANSFERIR DEMANDA DE:", "CNPJ DE: " & cmb_CNPJ_ESTABELECIMENTO_DE.Text & " PARA CNPJ PARA: " & cmb_CNPJ_ESTABELECIMENTO_PARA.Text)
            Mensagem = "ERRO  - TRANSFERIR DEMANDA" & Chr(10)
            Mensagem = Mensagem & "ERRO TRANSFERIR DEMANDA DE CNPJ DE: " & cmb_CNPJ_ESTABELECIMENTO_DE.Text & " PARA CNPJ PARA: " & cmb_CNPJ_ESTABELECIMENTO_PARA.Text
            M.EnviarEmail("ERRO  - TRANSFERENCIA DE DEMANDA", Mensagem, True, False, "", "")
            Alert("Erro ao trasnsferir demanda", False, "")
            Exit Sub
        End If

        If OK = True Then

            'OPORTUNIDADES
            sql = ""
            sql = sql & " Update TBL_OPORTUNIDADES "
            sql = sql & " SET CNPJ = " & cmb_CNPJ_ESTABELECIMENTO_PARA.Text & ", "
            sql = sql & " OPORTUNIDADE_TRANSFERIDA_DE = " & cmb_CNPJ_ESTABELECIMENTO_DE.Text & ", "
            sql = sql & " OPORTUNIDADE_TRANSFERIDA_EM =" & M.RecuperaData & ", "
            sql = sql & " OPORTUNIDADE_TRANSFERIDA_POR = '" & Session("EMAIL_LOGIN") & "' "
            sql = sql & " Where CNPJ = " & cmb_CNPJ_ESTABELECIMENTO_DE.Text

            If M.ExecutarSQL(sql) = True Then
                OK = True
            Else
                OK = False
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO TRANSFERIR TRANSFERIR OPORTUNIDADES DE:", "CNPJ DE: " & cmb_CNPJ_ESTABELECIMENTO_DE.Text & " PARA CNPJ PARA: " & cmb_CNPJ_ESTABELECIMENTO_PARA.Text)
                Mensagem = "ERRO  - DIGITACAO DEMANDA" & Chr(10)
                Mensagem = Mensagem & "ERRO TRANSFERIR OPORTUNIDADES DE CNPJ DE: " & cmb_CNPJ_ESTABELECIMENTO_DE.Text & " PARA CNPJ PARA: " & cmb_CNPJ_ESTABELECIMENTO_PARA.Text
                M.EnviarEmail("ERRO  - TRANSFERENCIA DE OPORTUNIDADES ", Mensagem, True, False, "", "")
                Alert("Erro ao trasnsferir oportunidades", False, "")
                Exit Sub
            End If

        End If

        If OK = True Then

            'ESTABELECIMENTO
            sql = ""
            sql = sql & " Update TBL_ESTABELECIMENTOS "
            sql = sql & " SET TRANSFERIR_PARA = " & cmb_CNPJ_ESTABELECIMENTO_PARA.Text & ", "
            sql = sql & " TRANSFERIDO_EM =" & M.RecuperaData & ", "
            sql = sql & " TRANSFERIDO_POR = '" & Session("EMAIL_LOGIN") & "' "
            sql = sql & " Where CNPJ = " & cmb_CNPJ_ESTABELECIMENTO_DE.Text

            If M.ExecutarSQL(sql) = True Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "TRANSFERIU ESTABELECIMENTO DE:", "CNPJ DE: " & cmb_CNPJ_ESTABELECIMENTO_DE.Text & " PARA CNPJ PARA: " & cmb_CNPJ_ESTABELECIMENTO_PARA.Text)
                Alert("Transferência efetuada com suscesso", False, "")
            Else
                OK = False
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO TRANSFERIR ESTABELECIMENTO DE:", "CNPJ DE: " & cmb_CNPJ_ESTABELECIMENTO_DE.Text & " PARA CNPJ PARA: " & cmb_CNPJ_ESTABELECIMENTO_PARA.Text)
                Mensagem = "ERRO  - DIGITACAO DEMANDA" & Chr(10)
                Mensagem = Mensagem & "ERRO TRANSFERIR ESTABELECIMENTO DE CNPJ DE: " & cmb_CNPJ_ESTABELECIMENTO_DE.Text & " PARA CNPJ PARA: " & cmb_CNPJ_ESTABELECIMENTO_PARA.Text
                M.EnviarEmail("ERRO  - DEPARA DE ESTABELECIMENTO", Mensagem, True, False, "", "")
                Alert("Erro ao trasnsferir ESTABELECIMENTO", False, "")
                Exit Sub
            End If

        End If
    End Sub
    Protected Function Alert(ByVal Texto_Mensagem As String, ByVal Redirecionar As Boolean, ByVal Pagina As String) As Boolean
        Dim jscript As String
        'caixa de mensagem
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