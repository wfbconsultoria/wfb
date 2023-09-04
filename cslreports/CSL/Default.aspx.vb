
Partial Class _Default
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Default.aspx"
    Dim Titulo As String = "Início - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean

      Dim SQL_LOCALIZAR As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
        Session("URL_SITE") = Left(Request.Url.AbsoluteUri, Len(Request.Url.AbsoluteUri) - 13)
        Session("HOJE") = Format(Year(Now()), "0000") & Format(Month(Now()), "00") & Format(Day(Now()), "00")

        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        'Acesso = true
       ' Page.Title = Titulo

       ' If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = False 'Administrador
       ' If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = False 'Diretor
       ' If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = False 'Gerente
       ' If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = False 'Cordenador
       ' If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = False 'Representante
       ' If Session("COD_PERFIL_LOGIN") = 5 Then Acesso = False 'Assistente
       ' If Session("COD_PERFIL_LOGIN") = 30 Then Acesso = true
       ' If Session("COD_PERFIL_LOGIN") = 7 Then Acesso = False 'Distribuidor
       ' If Session("SISTEMA") = True Then Acesso = True 'USUARIO DE SISTEMA

       '' Verifica se o perfil do usuário tem acesso a página
       ' If Acesso = True Then
       '     'Grava log de permissão de acesso
       '     If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
       '         M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSO PERMITIDO", "")
       '         Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
       '         Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
       '     End If
       ' Else
       '     'Grava log de recusa de acesso
       '     M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSO RECUSADO", "")
       '     Alert("Site em manutenção!", True, "Login.aspx")
       ' End If
       ' ____________________________________________________________________________________________________________________________________________
    End Sub
    'Funções Padrão para todas as páginas
    'Protected Function Alert(ByVal Texto_Mensagem As String, ByVal Redirecionar As Boolean, ByVal Pagina As String) As Boolean
    '    Dim jscript As String
    '    'caixa de mensagem
    '    If Redirecionar = True Then
    '        jscript = ""
    '        jscript += "<script language='JavaScript'>"
    '        jscript += ";alert('" & Texto_Mensagem & "'); document.location.href='" & Pagina & "'"
    '        jscript += "</script>"
    '    Else
    '        jscript = ""
    '        jscript += "<script language='JavaScript'>"
    '        jscript += ";alert('" & Texto_Mensagem & "');"
    '        jscript += "</script>"
    '    End If
    '    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Mensagem", jscript)
    '    Alert = True
    ' End Function
    End Class
