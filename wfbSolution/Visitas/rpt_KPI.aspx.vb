
Partial Class rpt_KPI
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "rpt_KPI.aspx"
    Dim Titulo As String = ConfigurationManager.AppSettings("SIGLA") & " - " & "KPI"
    Dim Acesso As Boolean
    Dim sql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Login.aspx")
        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = True 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = True 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = True 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = True 'Cordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = True 'Representante
        If Session("COD_PERFIL_LOGIN") = 5 Then Acesso = False 'Assistente
        If Session("COD_PERFIL_LOGIN") = 6 Then Acesso = False 'Visitante
        If Session("COD_PERFIL_LOGIN") = 7 Then Acesso = False 'Distribuidor
        If Session("SISTEMA") <> True Then Acesso = False 'Sistema

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

        'CONTROLA OS ACESSO E FUNÇÕES CONFORME O PERFIL DE ACESSO
        SQL = ""
        sql = "Select * From VIEW_USUARIOS Where COD_PERFIL = '4' AND ATIVO = True ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "0" Then SQL = "Select * From VIEW_USUARIOS_ATIVOS Where COD_PERFIL = '4' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "1" Then sql = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL_DIRETOR= '" & Session("EMAIL_LOGIN") & "' AND COD_PERFIL = '4' AND ATIVO = True ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "2" Then sql = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL_GERENTE= '" & Session("EMAIL_LOGIN") & "' AND COD_PERFIL = '4' AND ATIVO = True ORDER BY NOME"
        'If Session("COD_PERFIL_LOGIN") = "3" Then
        If Session("COD_PERFIL_LOGIN") = "4" Then sql = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL = '" & Session("EMAIL_LOGIN") & "' AND COD_PERFIL = '4' AND ATIVO = True ORDER BY NOME"
        dts_Usuarios.SelectCommand = sql
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