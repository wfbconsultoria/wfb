
Partial Class rpt_Demanda_Detalhada
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "rpt_Demanda_Detalhada.aspx"
    Dim sql As String
    Dim CNPJ As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Session("COD_PERFIL_LOGIN") = "0" Then Response.Redirect("rpt_Master_Report.aspx")
        'If Session("COD_PERFIL_LOGIN") = "1" Then Response.Redirect("rpt_Master_Report_Diretor.aspx")
        'If Session("COD_PERFIL_LOGIN") = "2" Then Response.Redirect("rpt_Master_Report_Gerente.aspx")
        'If Session("COD_PERFIL_LOGIN") = "3" Then Response.Redirect("rpt_Master_Report_KeyAccount.aspx")
        'If Session("COD_PERFIL_LOGIN") = "4" Then Response.Redirect("rpt_Master_Report_Representante.aspx")
        If Session("COD_PERFIL_LOGIN") = "5" Then Alert("Seu perfil não permite acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "6" Then Alert("Seu perfil não permite acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "7" Then Alert("Seu perfil não permite acesso a esta página", True, "Default.aspx")

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
        CNPJ = ""
        If Request.QueryString("CNPJ") <> "" Then CNPJ = Request.QueryString("CNPJ")
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

    Protected Sub Atualiza_Relatório()
        rpt_Demanda.LocalReport.ReportPath = "Reports\rpt_Demanda_Detalhada_Estabelecimento.rdlc"

        sql = " Select * From [VIEW_DEMANDA_001_DETALHADO] WHERE ANO = " & cmb_ANO.Text

        sql = sql & " and CNPJ = '" & CNPJ & "' "

        dts_Demanda.SelectCommand = sql
        dts_Demanda.DataBind()
        rpt_Demanda.DataBind()
        rpt_Demanda.LocalReport.Refresh()
    End Sub

    Protected Sub cmb_ANO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_ANO.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub
End Class
