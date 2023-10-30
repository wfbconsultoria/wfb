
Partial Class Estabelecimentos_Localizar
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Estabelecimentos_Localizar.aspx"
    'Váriáveis da Página
    Dim SQL_LOCALIZAR As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'LIMPA AS VARIAVEIS UTILIZADAS NESTA PAGINA
        Session("CNPJ") = ""
        
        'SELECIONA OS ESTABELECIMENTOS CONFORME O PERFIL E USUARIO LOGADO NO SISTEMA
        SQL_LOCALIZAR = ""
        SQL_LOCALIZAR = "Select * From VIEW_ESTABELECIMENTOS_001_DETALHADO ORDER BY ESTABELECIMENTO_CNPJ"
        If Session("COD_PERFIL_LOGIN") = 0 Then SQL_LOCALIZAR = "Select * From VIEW_ESTABELECIMENTOS_001_DETALHADO ORDER BY ESTABELECIMENTO_CNPJ"
        If Session("COD_PERFIL_LOGIN") = 1 Then SQL_LOCALIZAR = "Select * From VIEW_ESTABELECIMENTOS_001_DETALHADO Where EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "'ORDER BY ESTABELECIMENTO_CNPJ"
        If Session("COD_PERFIL_LOGIN") = 2 Then SQL_LOCALIZAR = "Select * From VIEW_ESTABELECIMENTOS_001_DETALHADO Where EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "'ORDER BY ESTABELECIMENTO_CNPJ"
        If Session("COD_PERFIL_LOGIN") = 3 Then SQL_LOCALIZAR = "Select * From VIEW_ESTABELECIMENTOS_001_DETALHADO Where EMAIL_GERENTE_CONTA = '" & Session("EMAIL_LOGIN") & "'ORDER BY ESTABELECIMENTO_CNPJ"
        If Session("COD_PERFIL_LOGIN") = 4 Then SQL_LOCALIZAR = "Select * From VIEW_ESTABELECIMENTOS_001_DETALHADO Where EMAIL_REPRESENTANTE = '" & Session("EMAIL_LOGIN") & "'ORDER BY ESTABELECIMENTO_CNPJ"
        If Session("COD_PERFIL_LOGIN") = 5 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 6 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 7 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 100 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        dts_Localizar.SelectCommand = SQL_LOCALIZAR

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
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
        gdv_Localizar.Caption = "Meus Estabelecimentos"
        gdv_Localizar.AllowPaging = "False"
        gdv_Localizar.DataBind()
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment;filename=Meus_Estabelecimentos.xls")
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


