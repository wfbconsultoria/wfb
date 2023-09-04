
Partial Class Log_Site
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Log Site"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("COD_PERFIL_LOGIN") <> 0 Then Alert("Somente Administradores têm acesso a esta funcionalidade", True, "Default.aspx")
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
    End Sub
    Public Sub Atualiza_Relatório()
        Dim sql As String
        sql = ""
        sql = "SELECT top(5000) * FROM [VIEW_LOG_SITE] WHERE SISTEMA = 'False' AND IP <> '189.111.216.129' "
        'ANO
        If cmb_Anos.Text <> "9999" Then sql = sql & " and ANO = " & cmb_Anos.Text
        'MES
        If cmb_Mes.Text <> "0" Then sql = sql & " and MES = " & cmb_Mes.Text
        'USUARIO
        If cmb_usuario.Text <> "@" Then sql = sql & " and EMAIL = '" & cmb_usuario.Text & "'"
        sql = sql & " ORDER BY [DATA] DESC, [HORA] DESC, [MINUTO] DESC"
        dts_VIEW_LOG_SITE.SelectCommand = sql
        dts_VIEW_LOG_SITE.DataBind()
        gdv_Log_Site.DataBind()
    End Sub
    Protected Sub cmb_Anos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Anos.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub
    Protected Sub cmb_Mes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Mes.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub
    Protected Sub cmb_usuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_usuario.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub
    Protected Sub cmd_Excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Excel.Click
        gdv_Log_Site.Caption = "Log de Acesso ao site " & Now()
        gdv_Log_Site.AllowPaging = "False"
        gdv_Log_Site.DataBind()
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment;filename=Log de acesso " & Session("USUARIO_LOGIN") & ".xls")
        Response.Charset = ""
        EnableViewState = False
        Controls.Add(frm)
        frm.Controls.Add(gdv_Log_Site)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        gdv_Log_Site.AllowPaging = "True"
        gdv_Log_Site.DataBind()
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