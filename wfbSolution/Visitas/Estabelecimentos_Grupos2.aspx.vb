
Partial Class Estabelecimentos_Grupos2
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Estabelecimentos_Grupos2.aspx"
    Dim Titulo As String = ConfigurationManager.AppSettings("SIGLA") & " - " & "Estabelecimentos Grupo 2"
    Dim Acesso As Boolean
    Dim Sql As String
    Dim Mensagem As String
    'Váriáveis da Página
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Login.aspx")
        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = False 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = False 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = False 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = False 'Cordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = False 'Representante
        If Session("COD_PERFIL_LOGIN") = 5 Then Acesso = False 'Assistente
        If Session("COD_PERFIL_LOGIN") = 6 Then Acesso = False 'Visitante
        If Session("COD_PERFIL_LOGIN") = 7 Then Acesso = False 'Distribuidor
        If Session("SISTEMA") = True Then Acesso = True ' Sistema

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
    Protected Sub cmd_Gravar_Click(sender As Object, e As EventArgs) Handles cmd_Gravar.Click
        If Len(txt_Grupo.Text) = 0 Then
            Alert("Digite o nome do Grupo antes de gravar!", False, "")
            Exit Sub
        End If
        Sql = ""
        Sql = "Insert Into TBL_ESTABELECIMENTOS_GRUPOS2 (GRUPO2, COD_ESFERA_GRUPO2, INCLUSAO_EMAIL, INCLUSAO_DATA) Values "
        Sql = Sql & "('" & M.ConverteTexto(txt_Grupo.Text) & "', "
        Sql = Sql & "'" & cmb_ESFERA_ADMINISTRATIVA.Text & "', "
        Sql = Sql & "'" & Session("EMAIL_LOGIN") & "', "
        Sql = Sql & M.RecuperaData & ")"

        If M.ExecutarSQL(Sql) = True Then
            txt_Grupo.Text = ""
            dts_ESTABELECIMENTOS_GRUPOS2.DataBind()
            gdv_GRUPOS2.DataBind()
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "Inclui grupo de Estabelecimento", txt_Grupo.Text)
            Alert("Grupo de Estabelecimento incluido com sucesso!", False, "")
        Else
            Mensagem = "ERRO - INCLUSAO GRUPO DE ESTABELECIMENTO - " & Pagina & " - " & Now() & Chr(10)
            Mensagem = Mensagem & " GRUPO DE ESTABELECIMENTO: " & txt_Grupo.Text & Chr(10)
            Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN")
            Mensagem = Mensagem & "SQL: " & Sql
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO", txt_Grupo.Text)
            M.EnviarEmail("ERRO - INCLUSAO GRUPO DE PRODUTO", Mensagem, True, False, "", "")

            Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao suporte para verificação!", False, "")
        End If
    End Sub
    Protected Sub gdv_Lista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gdv_GRUPOS2.SelectedIndexChanged
        Dim QTD_REGISTROS As Double = 0
        QTD_REGISTROS = M.Consiste_Exclusao(gdv_GRUPOS2.SelectedValue, "COD_GRUPO2", "TBL_ESTABELECIMENTOS")
        If QTD_REGISTROS > 0 Then
            Alert("Este grupo não pode ser excluido pois existem " & QTD_REGISTROS & " Estabelecimentos relacionados", False, "")
        Else
            If M.ExecutarSQL("Delete From TBL_ESTABELECIMENTOS_GRUPOS2 Where COD_GRUPO2 = " & gdv_GRUPOS2.SelectedValue) = True Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "Excluiu Grupo de produto COD", gdv_GRUPOS2.SelectedValue)
                Alert("Grupo excluido com sucesso ", False, "")
                dts_ESTABELECIMENTOS_GRUPOS2.DataBind()
                gdv_GRUPOS2.DataBind()
            End If
        End If
    End Sub
    'Funções Padrão para todas as páginas
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