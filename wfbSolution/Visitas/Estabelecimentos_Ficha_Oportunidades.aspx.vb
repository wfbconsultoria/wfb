
Partial Class Estabelecimentos_Ficha_Oportunidades
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Estabelecimentos_Ficha_Oportunidades.aspx"

    
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'verifica se existe sessão de login
        If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Default.aspx")
        If Session("CNPJ") = "" Then Response.Redirect("Estabelecimentos_Localizar.aspx")

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
    End Sub

    Protected Sub gdv_Oportunidades_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gdv_Oportunidades.RowCommand
        Dim X As Integer = Convert.ToInt32(e.CommandArgument)
        Dim LINHA As GridViewRow = gdv_Oportunidades.Rows(X)
        Dim CONTROLE As New ListItem
        Dim ACAO As String
        Dim ANO As New ListItem

        ACAO = e.CommandName.ToString
        CONTROLE.Text = Server.HtmlDecode(LINHA.Cells(1).Text)
        ANO.Text = Server.HtmlDecode(LINHA.Cells(2).Text)
        Session("ID_OPORTUNIDADE") = CONTROLE.Text
        If ACAO = "OPORTUNIDADE" Then Navegar("Oportunidades_Manutencao.aspx?ANO=" & ANO.Text)
    End Sub

    Protected Sub Navegar(ByVal Pagina As String)
        Dim jscript As String
        jscript = ""
        jscript += "<script language='JavaScript'>"
        jscript += ";; document.location.href='" & Pagina & "'"
        jscript += "</script>"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Navegar", jscript)
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
