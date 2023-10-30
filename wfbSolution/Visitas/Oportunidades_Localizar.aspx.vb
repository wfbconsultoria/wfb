
Partial Class Oportunidades_Localizar
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Oportunidades_Localizar.aspx"
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

        'CONTROLA OS ACESSO E FUNÇÕES CONFORME O PERFIL DE ACESSO
        sql = ""
        sql = "Select * From VIEW_USUARIOS_ATIVOS Where PERFIL = 'Gerente'ORDER BY NOME"
        If Session("PERFIL_LOGIN") = "Administrador" Then sql = "Select * From VIEW_USUARIOS_ATIVOS Where PERFIL = 'Representante'ORDER BY NOME"
        If Session("PERFIL_LOGIN") = "Diretor" Then sql = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "' AND PERFIL = 'Representante'ORDER BY NOME"
        If Session("PERFIL_LOGIN") = "Gerente" Then sql = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' AND PERFIL = 'Representante'ORDER BY NOME"
        If Session("PERFIL_LOGIN") = "Coordenador" Then sql = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL = '" & Session("EMAIL_LOGIN") & "'"
        If Session("PERFIL_LOGIN") = "Representante" Then sql = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL = '" & Session("EMAIL_LOGIN") & "'"
        If Session("PERFIL_LOGIN") = "Assistente" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("PERFIL_LOGIN") = "Visitante" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("PERFIL_LOGIN") = "Distribuidor" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        dts_Representantes.SelectCommand = sql

        If Session("PERFIL_LOGIN") = "Coordenador" Then
            sql = "SELECT * FROM [VIEW_OPORTUNIDADES_001_DETALHADO] WHERE [PERIODO_CONCLUSAO] = '" & cmb_Ano_Conclcusao.Text ' AND [EMAIL_GERENTE_CONTA] = '" & Session("EMAIL_LOGIN") & "' ORDER BY [ESTABELECIMENTO], [ID_FASE_ATUAL] DESC, [QTD_TOTAL_INICIAL]"
            dts_Oportunidades.SelectCommand = sql
            Label1.Text = "Key Account"
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

    Protected Sub cmd_Excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Excel.Click
        'EXPORTA GRIG DE LOCALIZACAO PARA O EXCEL
        M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "EXPORTOU EXCEL", "")
        gdv_Oportunidades.Caption = "Oportunidades "
        gdv_Oportunidades.AllowPaging = "False"
        gdv_Oportunidades.DataBind()
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment;filename=Oportunidades.xls")
        Response.Charset = ""
        EnableViewState = False
        Controls.Add(frm)
        frm.Controls.Add(gdv_Oportunidades)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        gdv_Oportunidades.AllowPaging = "True"
        gdv_Oportunidades.DataBind()
    End Sub
End Class