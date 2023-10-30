
Partial Class Estoque_Mapa_Distribuidor
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Estoque_Mapa_Distribuidor.aspx"
    Dim Titulo As String = "Mapa de Estoque por Distribuidor - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
    Dim Mensagem As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = True 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = True 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = True 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = True 'Cordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = True 'Representante
        If Session("COD_PERFIL_LOGIN") = 10 Then Acesso = True 'Key Account
        If Session("COD_PERFIL_LOGIN") = 20 Then Acesso = False 'Visitante
        If Session("COD_PERFIL_LOGIN") = 30 Then Acesso = False 'Distribuidor
        'If Session("SISTEMA") = True Then Acesso = True 'Sistema

        'Verifica se o perfil do usuário tem acesso a página
        If Acesso = True Then
            'Grava log de permissão de acesso
            If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSO PERMITIDO", "")
                Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
                Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
            End If
        Else
            'Grava log de recusa de acesso
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSO RECUSADO", "")
            Alert("Seu perfil de usuário não permite acesso a esta página!", True, "Default.aspx")
        End If
        '____________________________________________________________________________________________________________________________________________

        'Código customizado da página
    End Sub
    Protected Sub Atualiza_Relatorio()
        Dim sql As String
        dts_Grupo_Distribuidor.DataBind()
        dts_distribuidores.DataBind()

        sql = "SELECT * FROM [VIEW_MOVIMENTO_ESTOQUE] WHERE [ANO] = " & cmb_ANO.Text & " AND [MES] = " & cmb_MES.Text
            'Grupo Distribuidor
        sql = sql & " and GRUPO_DISTRIBUIDOR = '" & cmb_Grupo_Distribuidores.Text & "' "

            'Distribuidor
        If cmb_Distribuidores.Text <> "0" Then sql = sql & " and CNPJ_DISTRIBUIDOR = '" & cmb_Distribuidores.Text & "' "

        dts_estoque.SelectCommand = sql
        dts_estoque.DataBind()
        rpt_Report.DataBind()
        rpt_Report.LocalReport.Refresh()
    End Sub
    Protected Sub cmb_Grupo_Distribuidores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Grupo_Distribuidores.SelectedIndexChanged
        Atualiza_Relatorio()
    End Sub
    Protected Sub cmb_Distribuidores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Distribuidores.SelectedIndexChanged
        Atualiza_Relatorio()
    End Sub
    Protected Sub cmb_ANO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_ANO.SelectedIndexChanged
        Atualiza_Relatorio()
    End Sub
    Protected Sub cmb_MES_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_MES.SelectedIndexChanged
        Atualiza_Relatorio()
    End Sub
    'Funções Padrão para todas as páginas
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