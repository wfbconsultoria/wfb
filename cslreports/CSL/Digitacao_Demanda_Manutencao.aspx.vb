
Partial Class Digitar_Demanda_Manutencao
    Inherits System.Web.UI.Page
    Dim cmb_Produto As New clsMaster
    Dim Pagina As String = "Digitar_Demanda_Manutencao.aspx"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("SISTEMA") <> True Then
            Alert("Você não tem acesso a esta página", True, "Default.aspx")
        End If

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            cmb_Produto.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), HttpContext.Current.Handler.ToString, "ACESSOU", "")
        End If
        Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString

    End Sub
    Protected Sub frv_Movimento_Demanda_ItemDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewDeletedEventArgs) Handles frv_Movimento_Demanda.ItemDeleted
        gdv_Movimento_Demanda.DataBind()
        Alert("Registro Excluido com Sucesso", False, "")
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
    Protected Sub frv_Movimento_Demanda_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles frv_Movimento_Demanda.ItemUpdated
        gdv_Movimento_Demanda.DataBind()
        Alert("Registro Atualizado com Sucesso", False, "")
    End Sub
End Class