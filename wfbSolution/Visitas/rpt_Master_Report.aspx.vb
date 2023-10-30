
Partial Class rpt_Master_Report
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "rpt_Master_Report.aspx"
    Dim sql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Session("COD_PERFIL_LOGIN") = "0" Then Response.Redirect("rpt_Master_Report.aspx")
        If Session("COD_PERFIL_LOGIN") = "1" Then Response.Redirect("rpt_Master_Report_Diretor.aspx")
        If Session("COD_PERFIL_LOGIN") = "2" Then Response.Redirect("rpt_Master_Report_Gerente.aspx")
        If Session("COD_PERFIL_LOGIN") = "3" Then Response.Redirect("rpt_Master_Report_KeyAccount.aspx")
        If Session("COD_PERFIL_LOGIN") = "4" Then Response.Redirect("rpt_Master_Report_Representante.aspx")
        If Session("COD_PERFIL_LOGIN") = "5" Then Alert("Seu perfil não permite acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "6" Then Alert("Seu perfil não permite acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "7" Then Alert("Seu perfil não permite acesso a esta página", True, "Default.aspx")

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
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
   
    Protected Sub Atualiza_Relatório()
        rpt_Demanda.LocalReport.ReportPath = cmb_Reports.Text

        sql = " Select * From [VIEW_DEMANDA_001_DETALHADO] WHERE ANO = " & cmb_ANO.Text
        'LINHA
        If cmb_LINHA.Text <> "@" Then sql = sql & " and LINHA = '" & cmb_LINHA.Text & "' "
        'DISTRIBUIDOR
        If cmb_GRUPO_DISTRIBUIDOR.Text <> "@" Then sql = sql & " and GRUPO_DISTRIBUIDOR = '" & cmb_GRUPO_DISTRIBUIDOR.Text & "' "
        'MUNICIPIO
        If cmb_MUNICIPIO.Text <> "@" Then sql = sql & " and COD_MUNICIPIO = '" & cmb_MUNICIPIO.Text & "' "
        'ESTADO
        If cmb_ESTADO.Text <> "@" Then sql = sql & " and COD_UF = '" & cmb_ESTADO.Text & "' "
        'ESFERA
        If cmb_ESFERA.Text <> "@" Then sql = sql & " and ESFERA = '" & cmb_ESFERA.Text & "' "
        'DIRETOR
        If cmb_DIRETOR.Text <> "@" Then sql = sql & " and EMAIL_DIRETOR = '" & cmb_DIRETOR.Text & "' "
        'GERENTE
        If cmb_GERENTE.Text <> "@" Then sql = sql & " and EMAIL_GERENTE = '" & cmb_GERENTE.Text & "' "
        'REPRESENTANTE
        If cmb_REPRESENTANTE.Text <> "@" Then sql = sql & " and EMAIL_REPRESENTANTE = '" & cmb_REPRESENTANTE.Text & "' "
        'GERENTE DE CONTAS
        If cmb_GERENTE_CONTA.Text <> "@" Then sql = sql & " and EMAIL_GERENTE_CONTA = '" & cmb_GERENTE_CONTA.Text & "' "
        'GRUPO ESTABELECIMENTO
        If cmb_GRUPO_ESTABELECIMENTO.Text <> "@" Then sql = sql & " and GRUPO_ESTABELECIMENTO = '" & cmb_GRUPO_ESTABELECIMENTO.Text & "' "

        dts_Demanda.SelectCommand = sql
        dts_Demanda.DataBind()
        rpt_Demanda.DataBind()
        rpt_Demanda.LocalReport.Refresh()
    End Sub

    Protected Sub cmb_ANO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_ANO.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub

    Protected Sub cmb_LINHA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_LINHA.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub

    Protected Sub cmb_GRUPO_DISTRIBUIDOR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_GRUPO_DISTRIBUIDOR.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub

    Protected Sub cmb_ESTADO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_ESTADO.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub

    Protected Sub cmb_MUNICIPIO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_MUNICIPIO.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub

    Protected Sub cmb_ESFERA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_ESFERA.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub

    Protected Sub cmb_GERENTE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_GERENTE.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub

    Protected Sub cmb_REPRESENTANTE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_REPRESENTANTE.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub

    Protected Sub cmb_Reports_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Reports.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub

    Protected Sub cmb_DIRETOR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_DIRETOR.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub

    Protected Sub cmb_GERENTE_CONTA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_GERENTE_CONTA.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub

    Protected Sub cmb_GRUPO_ESTABELECIMENTO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_GRUPO_ESTABELECIMENTO.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub
End Class
