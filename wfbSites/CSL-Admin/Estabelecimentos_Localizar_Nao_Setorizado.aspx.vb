
Partial Class Estabelecimentos_Localizar_Nao_Setorizado
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Estabelecimentos_Localizar_Nao_Setorizado.aspx"
    Dim Titulo As String = "Clientes Orfãos - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean

    'Váriáveis da Página
    Dim SQL_LOCALIZAR As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = True 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = True 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = True 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = True 'Cordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = True 'Representante
        If Session("COD_PERFIL_LOGIN") = 10 Then Acesso = True 'Key Account
        If Session("COD_PERFIL_LOGIN") = 20 Then Acesso = False 'Visitante
        If Session("COD_PERFIL_LOGIN") = 30 Then Acesso = False 'Distribuidor

        If Session("ADMINISTRADOR_SETORIZACAO") = True Then Acesso = True 'Administrador de setorização

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
            Alert("Seu perfil de usuário não permite acesso a esta página!", True, "Estabelecimentos_Localizar.aspx")
        End If
        '____________________________________________________________________________________________________________________________________________

        'SELECIONA OS ESTABELECIMENTOS CONFORME O PERFIL E USUARIO LOGADO NO SISTEMA
        SQL_LOCALIZAR = ""
        SQL_LOCALIZAR = M.SQL_PADRAO("VIEW_ESTABELECIMENTOS_001_DETALHADO_ORFAOS")
        SQL_LOCALIZAR = SQL_LOCALIZAR & " ORDER BY ESTABELECIMENTO_CNPJ"
        dts_Localizar.SelectCommand = SQL_LOCALIZAR

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
    Protected Sub cmd_Excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Excel.Click
        'EXPORTA GRIG DE LOCALIZACAO PARA O EXCEL

        M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "EXPORTOU EXCEL", "")
        gdv_Localizar.Caption = M.ConverteTexto(Titulo & " " & Session("USUARIO_LOGIN").ToString)
        gdv_Localizar.AllowPaging = "False"
        gdv_Localizar.DataBind()
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment;filename=" & M.ConverteTexto(Titulo & " " & Session("USUARIO_LOGIN").ToString) & "_" & M.RecuperaData & ".xls")
        Response.Charset = ""
        EnableViewState = False
        Controls.Add(frm)
        frm.Controls.Add(gdv_Localizar)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        gdv_Localizar.AllowPaging = "True"
        gdv_Localizar.DataBind()
    End Sub
End Class
