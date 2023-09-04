
Partial Class Estabelecimentos_Ficha_Report
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Estabelecimentos_Ficha_Report.aspx"
    Dim Titulo As String = "Ralatório de Informações de Venda/Demanda - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
    Dim Mensagem As String
    Dim sql As String
    Public VIEW_TIPO_MOVIMENTO As String
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

        'Verifica se a existe variável de sessão para CNPJ
        If Request.QueryString("CNPJ") = "" Then
            Alert("Nenhum cliente selecionado, você será redirecionado para sua lista de clientes!", True, "Estabelecimentos_Localizar.aspx")
        End If

    End Sub
    Public Sub Recupera_Nome_View()
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader

        'ABRE CONEXAO
        cnn.ConnectionString = M.cnnStr
        cnn.Open()
        cmd.Connection = cnn
        'RECUPERA REGISTRO
        sql = ""
        sql = "SELECT * FROM [VIEW_CONFIG_TIPO_MOVIMENTO] WHERE COD_TIPO_MOVIMENTO = '" & cmb_TIPO_MOVIMENTO.Text & "'"
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("TABELA_ORIGEM")) Then VIEW_TIPO_MOVIMENTO = dtr("TABELA_ORIGEM")
        Else
            VIEW_TIPO_MOVIMENTO = "VIEW_MOVIMENTO_001_DETALHADO_FISCAL"
        End If
        dtr.Close()
        cnn.Close()
    End Sub
    Public Sub Atualiza_Relatório()
        rpt_Report.LocalReport.ReportPath = cmb_Reports.Text
        Recupera_Nome_View()
        sql = "Select * From [" & VIEW_TIPO_MOVIMENTO & "] WHERE CNPJ_ESTABELECIMENTO = '" & Request.QueryString("CNPJ") & "' AND (COD_TIPO_MOVIMENTO = '" & cmb_TIPO_MOVIMENTO.Text & "') "
        'ANO
        sql = sql & " and ANO = " & cmb_ANO.Text & ""

        dts_Reports.SelectCommand = sql
        dts_Reports.DataBind()
        rpt_Report.DataBind()
        rpt_Report.LocalReport.Refresh()
    End Sub
    Protected Sub cmb_TIPO_MOVIMENTO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_TIPO_MOVIMENTO.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub

    Protected Sub cmb_ANO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_ANO.SelectedIndexChanged
        Atualiza_Relatório()
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