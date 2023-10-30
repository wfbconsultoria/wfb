
Partial Class rpt_Visitas
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "rpt_Demanda_Distribuidor.aspx"
    Dim Sql As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

        'VERIFICA SE O PERFIL DE ACESSO PERMITE ACESSO A PAGINA
        If Session("COD_PERFIL_LOGIN") = 5 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 6 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 7 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = 100 Then Alert("Você não tem acesso a esta página", True, "Default.aspx")


    End Sub

    Protected Sub cmb_Mes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Mes.SelectedIndexChanged
        Sql = ""


        If Session("COD_PERFIL_LOGIN") = 0 Then Sql = "Select * From VIEW_VISITAS_GERAL WHERE MES_VISITA_SIGLA = '" & cmb_Mes.Text & "' AND ANO_VISITA = '" & cmb_Ano.Text & "'"
        If Session("COD_PERFIL_LOGIN") = 1 Then Sql = "Select * From VIEW_VISITAS_GERAL WHERE MES_VISITA_SIGLA = '" & cmb_Mes.Text & "' AND ANO_VISITA = '" & cmb_Ano.Text & "' AND EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "'"
        If Session("COD_PERFIL_LOGIN") = 2 Then Sql = "Select * From VIEW_VISITAS_GERAL WHERE MES_VISITA_SIGLA = '" & cmb_Mes.Text & "' AND ANO_VISITA = '" & cmb_Ano.Text & "' AND EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "'"
        If Session("COD_PERFIL_LOGIN") = 3 Then Sql = "Select * From VIEW_VISITAS_GERAL WHERE MES_VISITA_SIGLA = '" & cmb_Mes.Text & "' AND ANO_VISITA = '" & cmb_Ano.Text & "' AND EMAIL_GERENTE_CONTA = '" & Session("EMAIL_LOGIN") & "'"
        If Session("COD_PERFIL_LOGIN") = 4 Then Sql = "Select * From VIEW_VISITAS_GERAL WHERE MES_VISITA_SIGLA = '" & cmb_Mes.Text & "' AND ANO_VISITA = '" & cmb_Ano.Text & "' AND EMAIL_VISITANTE = '" & Session("EMAIL_LOGIN") & "'"

        dts_Visitas.SelectCommand = Sql
        dts_Visitas.DataBind()
        rptVisitas.LocalReport.Refresh()
    End Sub
    Protected Sub cmb_Ano_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Ano.SelectedIndexChanged
        Sql = ""

        If Session("COD_PERFIL_LOGIN") = 0 Then Sql = "Select * From VIEW_VISITAS_GERAL WHERE MES_VISITA_SIGLA = '" & cmb_Mes.Text & "' AND ANO_VISITA = '" & cmb_Ano.Text & "'"
        If Session("COD_PERFIL_LOGIN") = 1 Then Sql = "Select * From VIEW_VISITAS_GERAL WHERE MES_VISITA_SIGLA = '" & cmb_Mes.Text & "' AND ANO_VISITA = '" & cmb_Ano.Text & "' AND EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "'"
        If Session("COD_PERFIL_LOGIN") = 2 Then Sql = "Select * From VIEW_VISITAS_GERAL WHERE MES_VISITA_SIGLA = '" & cmb_Mes.Text & "' AND ANO_VISITA = '" & cmb_Ano.Text & "' AND EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "'"
        If Session("COD_PERFIL_LOGIN") = 3 Then Sql = "Select * From VIEW_VISITAS_GERAL WHERE MES_VISITA_SIGLA = '" & cmb_Mes.Text & "' AND ANO_VISITA = '" & cmb_Ano.Text & "' AND EMAIL_GERENTE_CONTA = '" & Session("EMAIL_LOGIN") & "'"
        If Session("COD_PERFIL_LOGIN") = 4 Then Sql = "Select * From VIEW_VISITAS_GERAL WHERE MES_VISITA_SIGLA = '" & cmb_Mes.Text & "' AND ANO_VISITA = '" & cmb_Ano.Text & "' AND EMAIL_VISITANTE = '" & Session("EMAIL_LOGIN") & "'"

        dts_Visitas.SelectCommand = Sql
        dts_Visitas.DataBind()
        rptVisitas.LocalReport.Refresh()
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
