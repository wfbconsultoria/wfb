
Partial Class Representantes_Visitas
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Representantes_Visitas.aspx"
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), HttpContext.Current.Handler.ToString, "ACESSOU", "")
        End If
        Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString

        'CONTROLA OS ACESSO E FUNÇÕES CONFORME O PERFIL DE ACESSO
        SQL = ""
        sql = "Select * From VIEW_USUARIOS_ATIVOS ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "0" Then sql = "Select * From VIEW_USUARIOS_ATIVOS Where COD_PERFIL = '1' Or COD_PERFIL = '2' Or COD_PERFIL = '3' Or COD_PERFIL = '4' Or EMAIL= '" & Session("EMAIL_LOGIN") & "' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "1" Then sql = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL_DIRETOR= '" & Session("EMAIL_LOGIN") & "' Or EMAIL= '" & Session("EMAIL_LOGIN") & "' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "2" Then sql = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL_GERENTE= '" & Session("EMAIL_LOGIN") & "' Or EMAIL= '" & Session("EMAIL_LOGIN") & "' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "3" Then sql = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL = '" & Session("EMAIL_LOGIN") & "'  ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "4" Then sql = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL = '" & Session("EMAIL_LOGIN") & "'  ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "5" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "6" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
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

