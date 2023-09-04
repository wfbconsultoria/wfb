
Partial Class rpt_Master_Report
    Inherits System.Web.UI.Page
   
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "rpt_Master_Report.aspx"
    Dim Titulo As String = "Master Report - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
    Dim Mensagem As String
    'Váriaveis da página
    Dim sql As String
    Public VIEW_TIPO_MOVIMENTO As String
    Dim Filtros As String
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

        'carrega combos de usuarios conforme hierarquia
        Controle_Hierarquia()


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
    Public Sub Gerar_Relatório()


        Recupera_Nome_View()

        Filtros = "REPORTS=" & cmb_Reports.Text & "&VIEW_TIPO_MOVIMENTO=" & VIEW_TIPO_MOVIMENTO & "&COD_TIPO_MOVIMENTO=" & cmb_TIPO_MOVIMENTO.Text
        Filtros = Filtros & "&ANO=" & cmb_ANO.Text & "&LINHA=" & cmb_LINHA.Text & "&PRODUTO_GRUPO=" & cmb_Grupo_Produto.Text
        Filtros = Filtros & "&GRUPO_DISTRIBUIDOR=" & cmb_GRUPO_DISTRIBUIDOR.Text & "&MUNICIPIO=" & cmb_MUNICIPIO.Text
        Filtros = Filtros & "&UF=" & cmb_ESTADO.Text & "&ESFERA=" & cmb_ESFERA.Text & "&TARGET=" & cmb_TARGET.Text
        Filtros = Filtros & "&SEM_SETORIZACAO=" & chk_Sem_Setorização.Checked & "&DIRETOR=" & cmb_DIRETOR.Text
        Filtros = Filtros & "&GERENTE=" & cmb_GERENTE.Text & "&GERENTE_DISTRITAL" & cmb_GERENTE_DISTRITAL.Text
        Filtros = Filtros & "&REPRESENTANTE=" & cmb_REPRESENTANTE.Text & "&GERENTE_CONTA=" & cmb_GERENTE_CONTA.Text
        Filtros = Filtros & "&GRUPO_ESTABELECIMENTO=" & cmb_GRUPO_ESTABELECIMENTO.Text

        cmd_Gerar_Relatorio.OnClientClick = "javascript: window.open('rpt_Master_Report_Relatorio.aspx?&" & Filtros & "'); return false;"
    End Sub
    Protected Sub cmb_TIPO_MOVIMENTO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_TIPO_MOVIMENTO.SelectedIndexChanged
        Carrega_Controle()
    End Sub
    Protected Sub cmb_TARGET_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_TARGET.SelectedIndexChanged
        Gerar_Relatório()
    End Sub
    Protected Sub cmb_ANO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_ANO.SelectedIndexChanged
        Gerar_Relatório()
    End Sub
    Protected Sub cmb_Grupo_Produto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Grupo_Produto.SelectedIndexChanged
        Gerar_Relatório()
    End Sub
    Protected Sub cmb_LINHA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_LINHA.SelectedIndexChanged
        Gerar_Relatório()
    End Sub

    Protected Sub cmb_GRUPO_DISTRIBUIDOR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_GRUPO_DISTRIBUIDOR.SelectedIndexChanged
        Gerar_Relatório()
    End Sub

    Protected Sub cmb_ESTADO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_ESTADO.SelectedIndexChanged
        Gerar_Relatório()
    End Sub

    Protected Sub cmb_MUNICIPIO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_MUNICIPIO.SelectedIndexChanged
        Gerar_Relatório()
    End Sub

    Protected Sub cmb_ESFERA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_ESFERA.SelectedIndexChanged
        Gerar_Relatório()
    End Sub

    Protected Sub cmb_GERENTE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_GERENTE.SelectedIndexChanged
        Gerar_Relatório()
    End Sub

    Protected Sub cmb_REPRESENTANTE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_REPRESENTANTE.SelectedIndexChanged
        Gerar_Relatório()
    End Sub

    Protected Sub cmb_Reports_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Reports.SelectedIndexChanged
        Gerar_Relatório()
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

            'TARGET
            cmb_TARGET.DataBind()
            cmb_TARGET.Enabled = False

        Else
            If Session("COD_PERFIL_LOGIN") = 0 Then 'Administrador 

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

                'TARGET
                cmb_TARGET.DataBind()
                cmb_TARGET.Enabled = True

            End If
            If Session("COD_PERFIL_LOGIN") = 1 Then 'Diretor

                'Anos
                dts_Anos.SelectCommand = "SELECT 9999 AS ANO, '# Selecione' AS ANO_DESC UNION ALL SELECT DISTINCT ANO AS ANO, CONVERT(VARCHAR, ANO) AS ANO_DESC FROM " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "' ORDER BY ANO DESC"
                dts_Anos.DataBind()

                'Linhas
                dts_Linha.SelectCommand = "SELECT '0' AS COD_PRODUTO_LINHA, '# Todos' AS PRODUTO_LINHA UNION ALL SELECT DISTINCT COD_PRODUTO_LINHA, PRODUTO_LINHA FROM " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "' ORDER BY PRODUTO_LINHA"
                dts_Linha.DataBind()

                'Grupo Distribuidor
                dts_Distribuidores.SelectCommand = "SELECT '@' AS GRUPO, '# Todos' as GRUPO_DISTRIBUIDOR UNION ALL SELECT DISTINCT GRUPO_DISTRIBUIDOR AS GRUPO , GRUPO_DISTRIBUIDOR  AS GRUPO_DISTRIBUIDOR FROM  " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "' ORDER BY GRUPO_DISTRIBUIDOR"
                dts_Distribuidores.DataBind()

                'Grupo ESTABELECIMENTO
                dts_Grupo_Estabeleicmento.SelectCommand = "SELECT '@' AS GRUPO, '# Todos' as GRUPO_ESTABELECIMENTO UNION ALL SELECT DISTINCT [GRUPO_ESTABELECIMENTO] as GRUPO, [GRUPO_ESTABELECIMENTO] as GRUPO_ESTABELECIMENTO FROM [" & VIEW_TIPO_MOVIMENTO & " ] WHERE EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "' ORDER BY [GRUPO_ESTABELECIMENTO]"
                dts_Grupo_Estabeleicmento.DataBind()

                'Estado
                dts_ESTADO.SelectCommand = "SELECT '@' AS UF, '# Todos' as UF_DESC  UNION ALL SELECT DISTINCT UF AS UF, UF as UF_DESC FROM  " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "' ORDER BY UF"
                dts_ESTADO.DataBind()

                'Municipio
                dts_MUNICIPIO.SelectCommand = "SELECT '@' AS MUNICIPIO, '# Todos' as MUNICIPIO_DESC UNION ALL SELECT DISTINCT MUNICIPIO AS MUNICIPIO, MUNICIPIO AS MUNICIPIO_DESC FROM  " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "' ORDER BY MUNICIPIO"
                dts_MUNICIPIO.DataBind()

                'Grupo ESFERA
                dts_Esfera.SelectCommand = "SELECT '@' AS ESFERA_ADMINISTRATIVA, '# Todos' as ESFERA UNION ALL SELECT DISTINCT [ESFERA] AS ESFERA_ADMINISTRATIVA, [ESFERA] FROM [" & VIEW_TIPO_MOVIMENTO & " ] WHERE EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "' ORDER BY [ESFERA]"
                dts_Esfera.DataBind()

                'TARGET
                cmb_TARGET.DataBind()
                cmb_TARGET.Enabled = True

            End If
            If Session("COD_PERFIL_LOGIN") = 2 Then 'Gerente

                'Anos
                dts_Anos.SelectCommand = "SELECT 9999 AS ANO, '# Selecione' AS ANO_DESC UNION ALL SELECT DISTINCT ANO AS ANO, CONVERT(VARCHAR, ANO) AS ANO_DESC FROM " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' ORDER BY ANO DESC"
                dts_Anos.DataBind()

                'Linhas
                dts_Linha.SelectCommand = "SELECT '0' AS COD_PRODUTO_LINHA, '# Todos' AS PRODUTO_LINHA UNION ALL SELECT DISTINCT COD_PRODUTO_LINHA, PRODUTO_LINHA FROM " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' ORDER BY PRODUTO_LINHA"
                dts_Linha.DataBind()

                'Grupo Distribuidor
                dts_Distribuidores.SelectCommand = "SELECT '@' AS GRUPO, '# Todos' as GRUPO_DISTRIBUIDOR UNION ALL SELECT DISTINCT GRUPO_DISTRIBUIDOR AS GRUPO , GRUPO_DISTRIBUIDOR  AS GRUPO_DISTRIBUIDOR FROM  " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' ORDER BY GRUPO_DISTRIBUIDOR"
                dts_Distribuidores.DataBind()

                'Grupo ESTABELECIMENTO
                dts_Grupo_Estabeleicmento.SelectCommand = "SELECT '@' AS GRUPO, '# Todos' as GRUPO_ESTABELECIMENTO UNION ALL SELECT DISTINCT [GRUPO_ESTABELECIMENTO] as GRUPO, [GRUPO_ESTABELECIMENTO] as GRUPO_ESTABELECIMENTO FROM [" & VIEW_TIPO_MOVIMENTO & " ] WHERE EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' ORDER BY [GRUPO_ESTABELECIMENTO]"
                dts_Grupo_Estabeleicmento.DataBind()

                'Estado
                dts_ESTADO.SelectCommand = "SELECT '@' AS UF, '# Todos' as UF_DESC  UNION ALL SELECT DISTINCT UF AS UF, UF as UF_DESC FROM  " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' ORDER BY UF"
                dts_ESTADO.DataBind()

                'Municipio
                dts_MUNICIPIO.SelectCommand = "SELECT '@' AS MUNICIPIO, '# Todos' as MUNICIPIO_DESC UNION ALL SELECT DISTINCT MUNICIPIO AS MUNICIPIO, MUNICIPIO AS MUNICIPIO_DESC FROM  " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' ORDER BY MUNICIPIO"
                dts_MUNICIPIO.DataBind()

                'Grupo ESFERA
                dts_Esfera.SelectCommand = "SELECT '@' AS ESFERA_ADMINISTRATIVA, '# Todos' as ESFERA UNION ALL SELECT DISTINCT [ESFERA] AS ESFERA_ADMINISTRATIVA, [ESFERA] FROM [" & VIEW_TIPO_MOVIMENTO & " ] WHERE EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' ORDER BY [ESFERA]"
                dts_Esfera.DataBind()

                'TARGET
                cmb_TARGET.DataBind()
                cmb_TARGET.Enabled = True

            End If
            If Session("COD_PERFIL_LOGIN") = 3 Then 'Coordenador

                'Anos
                dts_Anos.SelectCommand = "SELECT 9999 AS ANO, '# Selecione' AS ANO_DESC UNION ALL SELECT DISTINCT ANO AS ANO, CONVERT(VARCHAR, ANO) AS ANO_DESC FROM " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "' ORDER BY ANO DESC"
                dts_Anos.DataBind()

                'Linhas
                dts_Linha.SelectCommand = "SELECT '0' AS COD_PRODUTO_LINHA, '# Todos' AS PRODUTO_LINHA UNION ALL SELECT DISTINCT COD_PRODUTO_LINHA, PRODUTO_LINHA FROM " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "' ORDER BY PRODUTO_LINHA"
                dts_Linha.DataBind()

                'Grupo Distribuidor
                dts_Distribuidores.SelectCommand = "SELECT '@' AS GRUPO, '# Todos' as GRUPO_DISTRIBUIDOR UNION ALL SELECT DISTINCT GRUPO_DISTRIBUIDOR AS GRUPO , GRUPO_DISTRIBUIDOR  AS GRUPO_DISTRIBUIDOR FROM  " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "' ORDER BY GRUPO_DISTRIBUIDOR"
                dts_Distribuidores.DataBind()

                'Grupo ESTABELECIMENTO
                dts_Grupo_Estabeleicmento.SelectCommand = "SELECT '@' AS GRUPO, '# Todos' as GRUPO_ESTABELECIMENTO UNION ALL SELECT DISTINCT [GRUPO_ESTABELECIMENTO] as GRUPO, [GRUPO_ESTABELECIMENTO] as GRUPO_ESTABELECIMENTO FROM [" & VIEW_TIPO_MOVIMENTO & " ] WHERE EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "' ORDER BY [GRUPO_ESTABELECIMENTO]"
                dts_Grupo_Estabeleicmento.DataBind()

                'Estado
                dts_ESTADO.SelectCommand = "SELECT '@' AS UF, '# Todos' as UF_DESC  UNION ALL SELECT DISTINCT UF AS UF, UF as UF_DESC FROM  " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "' ORDER BY UF"
                dts_ESTADO.DataBind()

                'Municipio
                dts_MUNICIPIO.SelectCommand = "SELECT '@' AS MUNICIPIO, '# Todos' as MUNICIPIO_DESC UNION ALL SELECT DISTINCT MUNICIPIO AS MUNICIPIO, MUNICIPIO AS MUNICIPIO_DESC FROM  " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "' ORDER BY MUNICIPIO"
                dts_MUNICIPIO.DataBind()

                'Grupo ESFERA
                dts_Esfera.SelectCommand = "SELECT '@' AS ESFERA_ADMINISTRATIVA, '# Todos' as ESFERA UNION ALL SELECT DISTINCT [ESFERA] AS ESFERA_ADMINISTRATIVA, [ESFERA] FROM [" & VIEW_TIPO_MOVIMENTO & " ] WHERE EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "' ORDER BY [ESFERA]"
                dts_Esfera.DataBind()

                'TARGET
                cmb_TARGET.DataBind()
                cmb_TARGET.Enabled = True

            End If
            If Session("COD_PERFIL_LOGIN") = 4 Then 'Representante
                'Anos
                dts_Anos.SelectCommand = "SELECT 9999 AS ANO, '# Selecione' AS ANO_DESC UNION ALL SELECT DISTINCT ANO AS ANO, CONVERT(VARCHAR, ANO) AS ANO_DESC FROM " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_REPRESENTANTE = '" & Session("EMAIL_LOGIN") & "' ORDER BY ANO DESC"
                dts_Anos.DataBind()

                'Linhas
                dts_Linha.SelectCommand = "SELECT '0' AS COD_PRODUTO_LINHA, '# Todos' AS PRODUTO_LINHA UNION ALL SELECT DISTINCT COD_PRODUTO_LINHA, PRODUTO_LINHA FROM " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_REPRESENTANTE = '" & Session("EMAIL_LOGIN") & "' ORDER BY PRODUTO_LINHA"
                dts_Linha.DataBind()

                'Grupo Distribuidor
                dts_Distribuidores.SelectCommand = "SELECT '@' AS GRUPO, '# Todos' as GRUPO_DISTRIBUIDOR UNION ALL SELECT DISTINCT GRUPO_DISTRIBUIDOR AS GRUPO , GRUPO_DISTRIBUIDOR  AS GRUPO_DISTRIBUIDOR FROM  " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_REPRESENTANTE = '" & Session("EMAIL_LOGIN") & "' ORDER BY GRUPO_DISTRIBUIDOR"
                dts_Distribuidores.DataBind()

                'Grupo ESTABELECIMENTO
                dts_Grupo_Estabeleicmento.SelectCommand = "SELECT '@' AS GRUPO, '# Todos' as GRUPO_ESTABELECIMENTO UNION ALL SELECT DISTINCT [GRUPO_ESTABELECIMENTO] as GRUPO, [GRUPO_ESTABELECIMENTO] as GRUPO_ESTABELECIMENTO FROM [" & VIEW_TIPO_MOVIMENTO & " ] WHERE EMAIL_REPRESENTANTE = '" & Session("EMAIL_LOGIN") & "' ORDER BY [GRUPO_ESTABELECIMENTO]"
                dts_Grupo_Estabeleicmento.DataBind()

                'Estado
                dts_ESTADO.SelectCommand = "SELECT '@' AS UF, '# Todos' as UF_DESC  UNION ALL SELECT DISTINCT UF AS UF, UF as UF_DESC FROM  " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_REPRESENTANTE = '" & Session("EMAIL_LOGIN") & "' ORDER BY UF"
                dts_ESTADO.DataBind()

                'Municipio
                dts_MUNICIPIO.SelectCommand = "SELECT '@' AS MUNICIPIO, '# Todos' as MUNICIPIO_DESC UNION ALL SELECT DISTINCT MUNICIPIO AS MUNICIPIO, MUNICIPIO AS MUNICIPIO_DESC FROM  " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_REPRESENTANTE = '" & Session("EMAIL_LOGIN") & "' ORDER BY MUNICIPIO"
                dts_MUNICIPIO.DataBind()

                'Grupo ESFERA
                dts_Esfera.SelectCommand = "SELECT '@' AS ESFERA_ADMINISTRATIVA, '# Todos' as ESFERA UNION ALL SELECT DISTINCT [ESFERA] AS ESFERA_ADMINISTRATIVA, [ESFERA] FROM [" & VIEW_TIPO_MOVIMENTO & " ] WHERE EMAIL_REPRESENTANTE = '" & Session("EMAIL_LOGIN") & "' ORDER BY [ESFERA]"
                dts_Esfera.DataBind()

                'TARGET
                cmb_TARGET.DataBind()
                cmb_TARGET.Enabled = True

            End If
            If Session("COD_PERFIL_LOGIN") = 10 Then 'Gerente de Conta

                'Anos
                dts_Anos.SelectCommand = "SELECT 9999 AS ANO, '# Selecione' AS ANO_DESC UNION ALL SELECT DISTINCT ANO AS ANO, CONVERT(VARCHAR, ANO) AS ANO_DESC FROM " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_GERENTE_CONTA = '" & Session("EMAIL_LOGIN") & "' ORDER BY ANO DESC"
                dts_Anos.DataBind()

                'Linhas
                dts_Linha.SelectCommand = "SELECT '0' AS COD_PRODUTO_LINHA, '# Todos' AS PRODUTO_LINHA UNION ALL SELECT DISTINCT COD_PRODUTO_LINHA, PRODUTO_LINHA FROM " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_GERENTE_CONTA = '" & Session("EMAIL_LOGIN") & "' ORDER BY PRODUTO_LINHA"
                dts_Linha.DataBind()

                'Grupo Distribuidor
                dts_Distribuidores.SelectCommand = "SELECT '@' AS GRUPO, '# Todos' as GRUPO_DISTRIBUIDOR UNION ALL SELECT DISTINCT GRUPO_DISTRIBUIDOR AS GRUPO , GRUPO_DISTRIBUIDOR  AS GRUPO_DISTRIBUIDOR FROM  " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_GERENTE_CONTA = '" & Session("EMAIL_LOGIN") & "' ORDER BY GRUPO_DISTRIBUIDOR"
                dts_Distribuidores.DataBind()

                'Grupo ESTABELECIMENTO
                dts_Grupo_Estabeleicmento.SelectCommand = "SELECT '@' AS GRUPO, '# Todos' as GRUPO_ESTABELECIMENTO UNION ALL SELECT DISTINCT [GRUPO_ESTABELECIMENTO] as GRUPO, [GRUPO_ESTABELECIMENTO] as GRUPO_ESTABELECIMENTO FROM [" & VIEW_TIPO_MOVIMENTO & " ] WHERE EMAIL_GERENTE_CONTA = '" & Session("EMAIL_LOGIN") & "' ORDER BY [GRUPO_ESTABELECIMENTO]"
                dts_Grupo_Estabeleicmento.DataBind()

                'Estado
                dts_ESTADO.SelectCommand = "SELECT '@' AS UF, '# Todos' as UF_DESC  UNION ALL SELECT DISTINCT UF AS UF, UF as UF_DESC FROM  " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_GERENTE_CONTA = '" & Session("EMAIL_LOGIN") & "' ORDER BY UF"
                dts_ESTADO.DataBind()

                'Municipio
                dts_MUNICIPIO.SelectCommand = "SELECT '@' AS MUNICIPIO, '# Todos' as MUNICIPIO_DESC UNION ALL SELECT DISTINCT MUNICIPIO AS MUNICIPIO, MUNICIPIO AS MUNICIPIO_DESC FROM  " & VIEW_TIPO_MOVIMENTO & "  WHERE EMAIL_GERENTE_CONTA = '" & Session("EMAIL_LOGIN") & "' ORDER BY MUNICIPIO"
                dts_MUNICIPIO.DataBind()

                'Grupo ESFERA
                dts_Esfera.SelectCommand = "SELECT '@' AS ESFERA_ADMINISTRATIVA, '# Todos' as ESFERA UNION ALL SELECT DISTINCT [ESFERA] AS ESFERA_ADMINISTRATIVA, [ESFERA] FROM [" & VIEW_TIPO_MOVIMENTO & " ] WHERE EMAIL_GERENTE_CONTA = '" & Session("EMAIL_LOGIN") & "' ORDER BY [ESFERA]"
                dts_Esfera.DataBind()

                'TARGET
                cmb_TARGET.DataBind()
                cmb_TARGET.Enabled = True

            End If
        End If
    End Sub
    Public Sub Controle_Hierarquia()
        If Session("COD_PERFIL_LOGIN") = 0 Then 'Administrador
            'Libera o Filtro de não setorizados
            chk_Sem_Setorização.Enabled = True

            'DIRETOR
            dts_Diretores.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '1') AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Diretores.DataBind()

            'GERENTE
            dts_Gerentes.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '2') AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Gerentes.DataBind()

            'COORDENADOR
            dts_Gerentes_Distrital.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '3') AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Gerentes_Distrital.DataBind()

            'REPRESENTANTE
            dts_Representantes.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '4') AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Representantes.DataBind()

            'GERENTE CONTA
            dts_Gerente_Conta.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '10') AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Gerente_Conta.DataBind()

        End If
        If Session("COD_PERFIL_LOGIN") = 1 Then 'Diretor
            'Libera o Filtro de não setorizados
            chk_Sem_Setorização.Enabled = False

            'DIRETOR
            dts_Diretores.SelectCommand = "SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '1') AND EMAIL = '" & Session("EMAIL_LOGIN") & "'  AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Diretores.DataBind()
            cmb_DIRETOR.Enabled = False

            'GERENTE
            dts_Gerentes.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '2') AND EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "'  AND ATIVO = 'True'  ORDER BY [NOME]"
            dts_Gerentes.DataBind()

            'COORDENADOR
            dts_Gerentes_Distrital.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '3') AND EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "' AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Gerentes_Distrital.DataBind()

            'REPRESENTANTE
            dts_Representantes.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '4') AND EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "' AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Representantes.DataBind()

            'GERENTE CONTA
            dts_Gerente_Conta.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '10') AND EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "' AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Gerente_Conta.DataBind()

        End If
        If Session("COD_PERFIL_LOGIN") = 2 Then 'Gerente
            'Libera o Filtro de não setorizados
            chk_Sem_Setorização.Enabled = False

            'DIRETOR
            dts_Diretores.SelectCommand = "SELECT EMAIL_DIRETOR as EMAIL, DIRETOR AS NOME FROM [VIEW_USUARIOS] WHERE EMAIL = '" & Session("EMAIL_LOGIN") & "' AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Diretores.DataBind()
            cmb_DIRETOR.Enabled = False

            'GERENTE
            dts_Gerentes.SelectCommand = "SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE EMAIL = '" & Session("EMAIL_LOGIN") & "' AND ATIVO = 'True'  ORDER BY [NOME]"
            dts_Gerentes.DataBind()
            cmb_GERENTE.Enabled = False

            'COORDENADOR
            dts_Gerentes_Distrital.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '3') AND EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Gerentes_Distrital.DataBind()

            'REPRESENTANTE
            dts_Representantes.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '4') AND EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Representantes.DataBind()

            'GERENTE CONTA
            dts_Gerente_Conta.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '10') AND EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Gerente_Conta.DataBind()

        End If
        If Session("COD_PERFIL_LOGIN") = 3 Then 'Coordenador
            'Libera o Filtro de não setorizados
            chk_Sem_Setorização.Enabled = False

            'DIRETOR
            dts_Diretores.SelectCommand = "SELECT EMAIL_DIRETOR as EMAIL, DIRETOR AS NOME FROM [VIEW_USUARIOS] WHERE EMAIL = '" & Session("EMAIL_LOGIN") & "' AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Diretores.DataBind()
            cmb_DIRETOR.Enabled = False

            'GERENTE
            dts_Gerentes.SelectCommand = "SELECT EMAIL_GERENTE as EMAIL, GERENTE AS NOME FROM [VIEW_USUARIOS] WHERE EMAIL = '" & Session("EMAIL_LOGIN") & "' AND ATIVO = 'True'  ORDER BY [NOME]"
            dts_Gerentes.DataBind()
            cmb_GERENTE.Enabled = False

            'COORDENADOR
            dts_Gerentes_Distrital.SelectCommand = "SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '3') AND EMAIL = '" & Session("EMAIL_LOGIN") & "'  AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Gerentes_Distrital.DataBind()
            cmb_GERENTE_DISTRITAL.Enabled = False

            'REPRESENTANTE
            dts_Representantes.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '4') AND EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "' AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Representantes.DataBind()

            'GERENTE CONTA
            dts_Gerente_Conta.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '10') AND EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "' AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Gerente_Conta.DataBind()

        End If
        If Session("COD_PERFIL_LOGIN") = 4 Then 'Representante
            'Libera o Filtro de não setorizados
            chk_Sem_Setorização.Enabled = False

            'DIRETOR
            dts_Diretores.SelectCommand = "SELECT EMAIL_DIRETOR as EMAIL, DIRETOR AS NOME FROM [VIEW_USUARIOS] WHERE EMAIL = '" & Session("EMAIL_LOGIN") & "' AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Diretores.DataBind()
            cmb_DIRETOR.Enabled = False

            'GERENTE
            dts_Gerentes.SelectCommand = "SELECT EMAIL_GERENTE as EMAIL, GERENTE AS NOME FROM [VIEW_USUARIOS] WHERE EMAIL = '" & Session("EMAIL_LOGIN") & "' AND ATIVO = 'True'  ORDER BY [NOME]"
            dts_Gerentes.DataBind()
            cmb_GERENTE.Enabled = False

            'COORDENADOR
            dts_Gerentes_Distrital.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL_COORDENADOR as EMAIL, COORDENADOR AS NOME FROM [VIEW_USUARIOS] WHERE EMAIL = '" & Session("EMAIL_LOGIN") & "' AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Gerentes_Distrital.DataBind()
            cmb_GERENTE_DISTRITAL.Enabled = False

            'REPRESENTANTE
            dts_Representantes.SelectCommand = "SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '4') AND EMAIL = '" & Session("EMAIL_LOGIN") & "' AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Representantes.DataBind()
            cmb_REPRESENTANTE.Enabled = False

            'GERENTE CONTA
            dts_Gerente_Conta.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '10') AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Gerente_Conta.DataBind()
            cmb_GERENTE_CONTA.Enabled = False

        End If
        If Session("COD_PERFIL_LOGIN") = 10 Then 'Gerente de Conta
            'Libera o Filtro de não setorizados
            chk_Sem_Setorização.Enabled = False

            'DIRETOR
            dts_Diretores.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '1') AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Diretores.DataBind()
            cmb_DIRETOR.Enabled = False

            'GERENTE
            dts_Gerentes.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '2')  AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Gerentes.DataBind()
            cmb_GERENTE.Enabled = False

            'COORDENADOR
            dts_Gerentes_Distrital.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '3') AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Gerentes_Distrital.DataBind()
            cmb_GERENTE_DISTRITAL.Enabled = False

            'REPRESENTANTE
            dts_Representantes.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '4') AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Representantes.DataBind()
            cmb_REPRESENTANTE.Enabled = False

            'GERENTE CONTA
            dts_Gerente_Conta.SelectCommand = "SELECT '@' AS EMAIL, '# Todos' as NOME UNION ALL SELECT EMAIL as EMAIL, NOME AS NOME FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = '10') AND EMAIL = '" & Session("EMAIL_LOGIN") & "' AND ATIVO = 'True' ORDER BY [NOME]"
            dts_Gerente_Conta.DataBind()
            cmb_GERENTE_CONTA.Enabled = False
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
End Class