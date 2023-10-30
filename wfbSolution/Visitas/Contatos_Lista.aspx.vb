
Partial Class Contatos_Lista
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Contatos_Lista.aspx"
    Dim SQL_LOCALIZAR As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

        'SELECIONA OS CONTATOS CONFORME O PERFIL E USUARIO LOGADO NO SISTEMA
        SQL_LOCALIZAR = ""
        SQL_LOCALIZAR = "Select * From VIEW_CONTATOS ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = 0 Then SQL_LOCALIZAR = "Select * From VIEW_CONTATOS Where STATUS_ATIVO = '" & cmb_ativo.Text & "' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = 1 Then SQL_LOCALIZAR = "Select * From VIEW_CONTATOS  Where EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "' And STATUS_ATIVO = '" & cmb_ativo.Text & "' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = 2 Then SQL_LOCALIZAR = "Select * From VIEW_CONTATOS  Where EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' And STATUS_ATIVO = '" & cmb_ativo.Text & "' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = 3 Then SQL_LOCALIZAR = "Select * From VIEW_CONTATOS  Where EMAIL_GERENTE_CONTA = '" & Session("EMAIL_LOGIN") & "' And STATUS_ATIVO = '" & cmb_ativo.Text & "' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = 4 Then SQL_LOCALIZAR = "Select * From VIEW_CONTATOS  Where EMAIL_REPRESENTANTE = '" & Session("EMAIL_LOGIN") & "' And STATUS_ATIVO = '" & cmb_ativo.Text & "' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = 5 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 6 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 7 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 100 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        dts_Contatos.SelectCommand = SQL_LOCALIZAR
    End Sub
    Protected Sub cmd_Excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Excel.Click

        M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "EXPORTOU EXCEL", "")
        gdv_CONTATOS.Caption = "Visitas"
        gdv_CONTATOS.AllowPaging = "False"
        gdv_CONTATOS.DataBind()
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment;filename=VISITAS.xls")
        Response.Charset = ""
        EnableViewState = False
        Controls.Add(frm)
        frm.Controls.Add(gdv_CONTATOS)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        gdv_CONTATOS.AllowPaging = "True"
        gdv_CONTATOS.DataBind()
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
