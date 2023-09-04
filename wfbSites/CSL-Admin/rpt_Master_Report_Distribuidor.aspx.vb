
Partial Class rpt_Master_Report_Distribuidor
    Inherits System.Web.UI.Page

    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "rpt_Master_Report_Distribuidor.aspx"
    Dim Titulo As String = "Master Report Distribuidor - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
    Dim Mensagem As String
    'Váriaveis da página
    Dim sql As String
    Public VIEW_TIPO_MOVIMENTO As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo
        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = True 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = True 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = False 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = False 'Cordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = False 'Representante
        If Session("COD_PERFIL_LOGIN") = 10 Then Acesso = False 'Key Account
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
        rpt_Demanda.LocalReport.ReportPath = cmb_Reports.Text
        Recupera_Nome_View()
        sql = "Select * From [" & VIEW_TIPO_MOVIMENTO & "] WHERE (COD_TIPO_MOVIMENTO = '" & cmb_TIPO_MOVIMENTO.Text & "') "
        'ANO
        sql = sql & " and ANO = " & cmb_ANO.Text & ""
        'LINHA
        If cmb_LINHA.Text <> "0" Then sql = sql & " and COD_PRODUTO_LINHA = '" & cmb_LINHA.Text & "' "
        'COD_PRODUTO_GRUPO
        If cmb_Grupo_Produto.Text <> "0" Then sql = sql & " and COD_PRODUTO_GRUPO= '" & cmb_Grupo_Produto.Text & "' "
        'DISTRIBUIDOR
        If cmb_GRUPO_DISTRIBUIDOR.Text <> "@" Then sql = sql & " and GRUPO_DISTRIBUIDOR = '" & cmb_GRUPO_DISTRIBUIDOR.Text & "' "
        'MUNICIPIO
        If cmb_MUNICIPIO.Text <> "@" Then sql = sql & " and MUNICIPIO = '" & cmb_MUNICIPIO.Text & "' "
        'ESTADO
        If cmb_ESTADO.Text <> "@" Then sql = sql & " and UF = '" & cmb_ESTADO.Text & "' "
        'ESFERA
        If cmb_ESFERA.Text <> "@" Then sql = sql & " and ESFERA = '" & cmb_ESFERA.Text & "' "

        dts_Reports.SelectCommand = sql
        dts_Reports.DataBind()
        rpt_Demanda.DataBind()
        rpt_Demanda.LocalReport.Refresh()
    End Sub
    Protected Sub cmb_TIPO_MOVIMENTO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_TIPO_MOVIMENTO.SelectedIndexChanged
        Carrega_Controle()
    End Sub
    Protected Sub cmb_ANO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_ANO.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub
    Protected Sub cmb_Grupo_Produto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Grupo_Produto.SelectedIndexChanged
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

    Protected Sub cmb_Reports_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Reports.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub
    Public Sub Carrega_Controle()
        'Define o Datasource dos combos conforem o perfil de acesso
        Recupera_Nome_View()

        If cmb_TIPO_MOVIMENTO.Text = "@" Then
            'Anos
            dts_Anos.SelectCommand = "SELECT 9999 AS ANO, '# Selecione' AS ANO_DESC ORDER BY ANO DESC"
            dts_Anos.DataBind()

            'Grupos de Produto
            dts_Grupos_Produtos.SelectCommand = "SELECT '0' AS COD_PRODUTO_GRUPO, '# Todos' AS PRODUTO_GRUPO ORDER BY PRODUTO_GRUPO"
            dts_Linha.DataBind()

            'Linhas
            dts_Linha.SelectCommand = "SELECT '0' AS COD_PRODUTO_LINHA, '# Todos' AS PRODUTO_LINHA ORDER BY PRODUTO_LINHA"
            dts_Linha.DataBind()

            'Grupo Distribuidor
            dts_Distribuidores.SelectCommand = "SELECT '@' AS GRUPO, '# Todos' as GRUPO_DISTRIBUIDOR ORDER BY GRUPO_DISTRIBUIDOR"
            dts_Distribuidores.DataBind()

            'Grupo ESTABELECIMENTO
            dts_Grupo_Estabeleicmento.SelectCommand = "SELECT '@' AS GRUPO, '# Todos' as GRUPO_ESTABELECIMENTO ORDER BY [GRUPO_ESTABELECIMENTO]"
            dts_Grupo_Estabeleicmento.DataBind()

            'Estado
            dts_ESTADO.SelectCommand = "SELECT '@' AS UF, '# Todos' as UF_DESC ORDER BY UF"
            dts_ESTADO.DataBind()

            'Municipio
            dts_MUNICIPIO.SelectCommand = "SELECT '@' AS MUNICIPIO, '# Todos' as MUNICIPIO_DESC ORDER BY MUNICIPIO"
            dts_MUNICIPIO.DataBind()

            'Grupo ESFERA
            dts_Esfera.SelectCommand = "SELECT '@' AS ESFERA_ADMINISTRATIVA, '# Todos' as ESFERA ORDER BY [ESFERA]"
            dts_Esfera.DataBind()


        Else

            'Anos
            dts_Anos.SelectCommand = "SELECT 9999 AS ANO, '# Selecione' AS ANO_DESC UNION ALL SELECT DISTINCT ANO AS ANO, CONVERT(VARCHAR, ANO) AS ANO_DESC FROM " & VIEW_TIPO_MOVIMENTO & "  ORDER BY ANO DESC"
            dts_Anos.DataBind()

            'Grupos de Produto
            dts_Grupos_Produtos.SelectCommand = "SELECT '0' AS COD_PRODUTO_GRUPO, '# Todos' AS PRODUTO_GRUPO UNION ALL SELECT DISTINCT COD_PRODUTO_GRUPO, PRODUTO_GRUPO FROM " & VIEW_TIPO_MOVIMENTO & "  ORDER BY PRODUTO_GRUPO"
            dts_Linha.DataBind()

            'Linhas
            dts_Linha.SelectCommand = "SELECT '0' AS COD_PRODUTO_LINHA, '# Todos' AS PRODUTO_LINHA UNION ALL SELECT DISTINCT COD_PRODUTO_LINHA, PRODUTO_LINHA FROM " & VIEW_TIPO_MOVIMENTO & "  ORDER BY PRODUTO_LINHA"
            dts_Linha.DataBind()

            'Grupo Distribuidor
            dts_Distribuidores.SelectCommand = "SELECT '@' AS GRUPO, '# Todos' as GRUPO_DISTRIBUIDOR UNION ALL SELECT DISTINCT GRUPO_DISTRIBUIDOR AS GRUPO , GRUPO_DISTRIBUIDOR  AS GRUPO_DISTRIBUIDOR FROM  " & VIEW_TIPO_MOVIMENTO & "  ORDER BY GRUPO_DISTRIBUIDOR"
            dts_Distribuidores.DataBind()

            'Grupo ESTABELECIMENTO
            dts_Grupo_Estabeleicmento.SelectCommand = "SELECT '@' AS GRUPO, '# Todos' as GRUPO_ESTABELECIMENTO UNION ALL SELECT DISTINCT [GRUPO_ESTABELECIMENTO] as GRUPO, [GRUPO_ESTABELECIMENTO] as GRUPO_ESTABELECIMENTO FROM [" & VIEW_TIPO_MOVIMENTO & " ] ORDER BY [GRUPO_ESTABELECIMENTO]"
            dts_Grupo_Estabeleicmento.DataBind()

            'Estado
            dts_ESTADO.SelectCommand = "SELECT '@' AS UF, '# Todos' as UF_DESC  UNION ALL SELECT DISTINCT UF AS UF, UF as UF_DESC FROM  " & VIEW_TIPO_MOVIMENTO & "  ORDER BY UF"
            dts_ESTADO.DataBind()

            'Municipio
            dts_MUNICIPIO.SelectCommand = "SELECT '@' AS MUNICIPIO, '# Todos' as MUNICIPIO_DESC UNION ALL SELECT DISTINCT MUNICIPIO AS MUNICIPIO, MUNICIPIO AS MUNICIPIO_DESC FROM  " & VIEW_TIPO_MOVIMENTO & "  ORDER BY MUNICIPIO"
            dts_MUNICIPIO.DataBind()

            'Grupo ESFERA
            dts_Esfera.SelectCommand = "SELECT '@' AS ESFERA_ADMINISTRATIVA, '# Todos' as ESFERA UNION ALL SELECT DISTINCT [ESFERA] AS ESFERA_ADMINISTRATIVA, [ESFERA] FROM [" & VIEW_TIPO_MOVIMENTO & " ] ORDER BY [ESFERA]"
            dts_Esfera.DataBind()

        End If
        rpt_Demanda.LocalReport.Refresh()
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