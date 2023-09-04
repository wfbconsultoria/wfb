
Partial Class rpt_Master_Report
    Inherits System.Web.UI.Page
   
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "rpt_Master_Report.aspx"
    Dim Titulo As String = "Master Report - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
    Dim Mensagem As String
    'Váriaveis da página
    Dim sql As String
    Public VIEW_TIPO_MOVIMENTO As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.Url.GetLeftPart(UriPartial.Authority) <> "https://www.bihospitalar.com.br" Then
            Response.Redirect("https://www.bihospitalar.com.br" & VirtualPathUtility.ToAbsolute("~"))
        End If
        If Not Request.IsSecureConnection Then
            ' redirect visitor to SSL connection
            Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"))
        End If
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
        If Session("COD_PERFIL_LOGIN") = 10 Then Acesso = True 'Key Account
        If Session("COD_PERFIL_LOGIN") = 20 Then Acesso = False 'Visitante
        If Session("COD_PERFIL_LOGIN") = 30 Then Acesso = False 'Distribuidor

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

        'Código customizado da página
        Atualiza_Relatório()
    End Sub
    Public Sub Atualiza_Relatório()
        rpt_Demanda.LocalReport.ReportPath = Request.QueryString("REPORTS")
        sql = "Select * From [" & Request.QueryString("VIEW_TIPO_MOVIMENTO") & "] WHERE (COD_TIPO_MOVIMENTO = '" & Request.QueryString("COD_TIPO_MOVIMENTO") & "') "
        'ANO
        sql = sql & " and ANO = " & Request.QueryString("ANO") & ""
        'LINHA
        If Request.QueryString("LINHA") <> "0" Then sql = sql & " and COD_PRODUTO_LINHA = '" & Request.QueryString("LINHA") & "' "
        'COD_PRODUTO_GRUPO
        If Request.QueryString("PRODUTO_GRUPO") <> "0" Then sql = sql & " and COD_PRODUTO_GRUPO= '" & Request.QueryString("PRODUTO_GRUPO") & "' "
        'DISTRIBUIDOR
        If Request.QueryString("GRUPO_DISTRIBUIDOR") <> "@" Then sql = sql & " and GRUPO_DISTRIBUIDOR = '" & Request.QueryString("GRUPO_DISTRIBUIDOR") & "' "
        'MUNICIPIO
        If Request.QueryString("MUNICIPIO") <> "@" Then sql = sql & " and MUNICIPIO = '" & Request.QueryString("MUNICIPIO") & "' "
        'ESTADO
        If Request.QueryString("UF") <> "@" Then sql = sql & " and UF = '" & Request.QueryString("UF") & "' "
        'ESFERA
        If Request.QueryString("ESFERA") <> "@" Then sql = sql & " and ESFERA = '" & Request.QueryString("ESFERA") & "' "

        'ESFERA
        If Request.QueryString("TARGET") <> "@" Then sql = sql & " and TARGET = '" & Request.QueryString("TARGET") & "' "

        If Request.QueryString("SEM_SETORIZACAO") = True Then
            sql = sql & " and EMAIL_REPRESENTANTE is NULL "
        Else
            'DIRETOR
            If Request.QueryString("DIRETOR") <> "@" Then sql = sql & " and EMAIL_DIRETOR = '" & Request.QueryString("DIRETOR") & "' "
            'GERENTE
            If Request.QueryString("GERENTE") <> "@" Then sql = sql & " and EMAIL_GERENTE = '" & Request.QueryString("EMAIL_GERENTE") & "' "
            'GERENTE Distrital
            If Request.QueryString("GERENTE_DISTRITAL") <> "@" And Request.QueryString("GERENTE_DISTRITAL") <> "" Then sql = sql & " and EMAIL_COORDENADOR = '" & Request.QueryString("GERENTE_DISTRITAL") & "' "
            'REPRESENTANTE
            If Request.QueryString("REPRESENTANTE") <> "@" Then sql = sql & " and EMAIL_REPRESENTANTE = '" & Request.QueryString("REPRESENTANTE") & "' "
            'GERENTE DE CONTAS
            If Request.QueryString("GERENTE_CONTA") <> "@" Then sql = sql & " and EMAIL_GERENTE_CONTA = '" & Request.QueryString("GERENTE_CONTA") & "' "
        End If
        'GRUPO ESTABELECIMENTO
        If Request.QueryString("GRUPO_ESTABELECIMENTO") <> "@" Then sql = sql & " and GRUPO_ESTABELECIMENTO = '" & Request.QueryString("GRUPO_ESTABELECIMENTO") & "' "

        dts_Reports.SelectCommand = sql
        dts_Reports.DataBind()
        rpt_Demanda.DataBind()
        rpt_Demanda.LocalReport.Refresh()
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