
Partial Class Representantes_Visitas
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Representantes_Visitas.aspx"
    Dim Titulo As String = "Lista de Visitas - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
    Dim Mensagem As String
    Dim sql As String
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

        'CONTROLA OS ACESSO E FUNÇÕES CONFORME O PERFIL DE ACESSO
        SQL = ""
        sql = "Select * From VIEW_USUARIOS Where PERFIL = 'Representante'ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "0" Then sql = "Select * From VIEW_USUARIOS WHERE COD_PERFIL = '2' Or COD_PERFIL = '3' Or COD_PERFIL = '4' Or EMAIL = '" & Session("EMAIL_LOGIN") & "' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "1" Then sql = "Select * From VIEW_USUARIOS Where EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "' Or EMAIL= '" & Session("EMAIL_LOGIN") & "' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "2" Then sql = "Select * From VIEW_USUARIOS Where EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' Or EMAIL= '" & Session("EMAIL_LOGIN") & "' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "3" Then sql = "Select * From VIEW_USUARIOS Where EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "' Or EMAIL= '" & Session("EMAIL_LOGIN") & "' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "4" Then sql = "Select * From VIEW_USUARIOS Where EMAIL = '" & Session("EMAIL_LOGIN") & "'  ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "10" Then sql = "Select * From VIEW_USUARIOS Where EMAIL = '" & Session("EMAIL_LOGIN") & "'  ORDER BY NOME"
        dts_REPRESENTANTE.SelectCommand = SQL
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
    Protected Sub cmd_Excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Excel.Click
        M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "EXPORTOU EXCEL", "")
        gdv_LISTA_VISITAS.Caption = "Visitas"
        gdv_LISTA_VISITAS.AllowPaging = "False"
        gdv_LISTA_VISITAS.DataBind()
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment;filename=VISITAS.xls")
        Response.Charset = ""
        EnableViewState = False
        Controls.Add(frm)
        frm.Controls.Add(gdv_LISTA_VISITAS)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        gdv_LISTA_VISITAS.AllowPaging = "True"
        gdv_LISTA_VISITAS.DataBind()
    End Sub
End Class