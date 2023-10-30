
Partial Class Usuarios_Localizacao
    Inherits System.Web.UI.Page
    Public M As New clsMaster
    Dim Pagina As String = "Usuarios Localizacao"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
        'LIMPA AS VARIAVEIS UTILIZADAS PELA PAGINA
        Session("EMAIL_USUARIO") = ""
        Session("NOME_USUARIO") = ""
    End Sub
    Protected Sub gdv_Localizar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gdv_Localizar.SelectedIndexChanged
        Session("EMAIL_USUARIO") = gdv_Localizar.SelectedValue.ToString
        M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "SELECIONOU", Session("EMAIL_USUARIO"))
        Response.Redirect("Usuarios_Atualizar.aspx")
    End Sub
    Protected Sub cmd_Excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Excel.Click
        M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "EXPORTOU EXCEL", "")
        gdv_Localizar.Caption = "Lista de Usuarios " & M._NOME_SISTEMA & " emissão " & Now()
        gdv_Localizar.AllowPaging = "False"
        gdv_Localizar.DataBind()
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment;filename=Lista de Usuarios.xls")
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
