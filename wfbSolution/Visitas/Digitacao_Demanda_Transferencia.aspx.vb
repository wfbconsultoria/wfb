
Partial Class Digitacao_Demanda_Transferencia
    Inherits System.Web.UI.Page
    Public jscript As String
    Dim M As New clsMaster
    Dim Pagina As String = "Digitacao Demanda"
    Dim SQL As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'VERIFICA SE O PERFIL DE ACESSO PERMITE ACESSO A PAGINA
        If Session("COD_PERFIL_LOGIN") = 1 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 2 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 3 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 4 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 5 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 6 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 7 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 100 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")

        If Session("SISTEMA") <> True Then
            Alert("Você não tem acesso a esta página", True, "Default.aspx")
        End If

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

    End Sub


    Protected Sub cmd_Gravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Gravar.Click
        Dim sql As String
        Dim Mensagem As String

        sql = ""
        sql = sql & " Update TBL_MOVIMENTO_DEMANDA "
        sql = sql & " SET CNPJ_ESTABELECIMENTO = " & cmb_CNPJ_ESTABELECIMENTO_PARA.Text & ", "
        sql = sql & " DEMANDA_TRANSFERIDA_DE = " & cmb_CNPJ_ESTABELECIMENTO_DE.Text & ", "
        sql = sql & " DEMANDA_TRANSFERIDA_EM =" & M.RecuperaData & ", "
        sql = sql & " DEMANDA_TRANSFERIDA_POR = '" & Session("EMAIL_LOGIN") & "' "
        sql = sql & " Where CNPJ_ESTABELECIMENTO = " & cmb_CNPJ_ESTABELECIMENTO_DE.Text

        If M.ExecutarSQL(sql) = True Then
            sql = ""
            sql = sql & " Update TBL_OPORTUNIDADES "
            sql = sql & " SET CNPJ = " & cmb_CNPJ_ESTABELECIMENTO_PARA.Text & ", "
            sql = sql & " OPORTUNIDADE_TRANSFERIDA_DE = " & cmb_CNPJ_ESTABELECIMENTO_DE.Text & ", "
            sql = sql & " OPORTUNIDADE_TRANSFERIDA_EM =" & M.RecuperaData & ", "
            sql = sql & " OPORTUNIDADE_TRANSFERIDA_POR = '" & Session("EMAIL_LOGIN") & "' "
            sql = sql & " Where CNPJ = " & cmb_CNPJ_ESTABELECIMENTO_DE.Text
            If M.ExecutarSQL(sql) = True Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "TRANSFERIU DEMANDA e OPORTUNIDADES DE:", "CNPJ DE: " & cmb_CNPJ_ESTABELECIMENTO_DE.Text & " PARA CNPJ PARA: " & cmb_CNPJ_ESTABELECIMENTO_PARA.Text)
                Alert("Transferência efetuada com suscesso", False, "")
            Else
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO TRANSFERIR DEMANDA E OPORTUNIDADES DE:", "CNPJ DE: " & cmb_CNPJ_ESTABELECIMENTO_DE.Text & " PARA CNPJ PARA: " & cmb_CNPJ_ESTABELECIMENTO_PARA.Text)
                Mensagem = "ERRO  - TRANSFERENCIA DE DEMANDA E OPORTUNIDADES" & Chr(10)
                Mensagem = Mensagem & "ERRO TRANSFERIR DEMANDA E OPORTUNIDADES DE CNPJ DE: " & cmb_CNPJ_ESTABELECIMENTO_DE.Text & " PARA CNPJ PARA: " & cmb_CNPJ_ESTABELECIMENTO_PARA.Text
                M.EnviarEmail("ERRO  - TRANSFERENCIA DE DEMANDA E OPORTUNIDADES ", Mensagem, True, False, "", "")
                Alert("Erro ao trasnsferir Demanda e Oportunidades", False, "")
            End If
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO TRANSFERIR DEMANDA E OPORTUNIDADES DE:", "CNPJ DE: " & cmb_CNPJ_ESTABELECIMENTO_DE.Text & " PARA CNPJ PARA: " & cmb_CNPJ_ESTABELECIMENTO_PARA.Text)
            Mensagem = "ERRO  - TRANSFERENCIA DE DEMANDA E OPORTUNIDADES" & Chr(10)
            Mensagem = Mensagem & "ERRO TRANSFERIR DEMANDA E OPORTUNIDADES DE CNPJ DE: " & cmb_CNPJ_ESTABELECIMENTO_DE.Text & " PARA CNPJ PARA: " & cmb_CNPJ_ESTABELECIMENTO_PARA.Text
            M.EnviarEmail("ERRO  - TRANSFERENCIA DE DEMANDA E OPORTUNIDADES ", Mensagem, True, False, "", "")
            Alert("Erro ao trasnsferir Demanda e Oportunidades", False, "")
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