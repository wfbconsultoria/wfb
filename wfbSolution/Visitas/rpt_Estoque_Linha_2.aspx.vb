Imports System.Math
Partial Class rpt_Estoque_Linha
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Estoque"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'CONTROLA OS ACESSO E FUNÇÕES CONFORME O PERFIL DE ACESSO
        If Session("COD_PERFIL_LOGIN") = "3" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "4" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "5" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "6" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
    End Sub
    Protected Sub cmb_Anos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Anos.SelectedIndexChanged
        If cmb_LINHA.Text <> "# Selecione" And cmb_Anos.Text <> "9999" Then
            Atualiza_Relatorio()
        End If
    End Sub

    Protected Sub cmb_LINHA_Load(sender As Object, e As EventArgs) Handles cmb_LINHA.Load
        If cmb_LINHA.Text <> "# Selecione" And cmb_Anos.Text <> "9999" Then
            Atualiza_Relatorio()
        End If
    End Sub
    Public Sub Atualiza_Relatorio()
        ' Variaveis---------------------------------------------------------------------------------------------------------------------------------------------------
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String

        Dim cnn_Dst As New System.Data.SqlClient.SqlConnection
        Dim cmd_Dst As New System.Data.SqlClient.SqlCommand
        Dim dtr_Dst As System.Data.SqlClient.SqlDataReader
        Dim sql_Dst As String

        Dim cnn_ESTABELECIMENTOS As New System.Data.SqlClient.SqlConnection
        Dim cmd_ESTABELECIMENTOS As New System.Data.SqlClient.SqlCommand

        Dim LINHA_PRODUTO As String
        Dim GRUPO_DISTRIBUIDOR As String
        Dim X As Integer
        Dim Y As Integer
        Dim ANO As Integer
        Dim rw As TableRow
        Dim cel As TableCell

        Dim JAN_ESTOQUE As Integer
        Dim FEV_ESTOQUE As Integer
        Dim MAR_ESTOQUE As Integer
        Dim ABR_ESTOQUE As Integer
        Dim MAI_ESTOQUE As Integer
        Dim JUN_ESTOQUE As Integer
        Dim JUL_ESTOQUE As Integer
        Dim AGO_ESTOQUE As Integer
        Dim SET_ESTOQUE As Integer
        Dim OUT_ESTOQUE As Integer
        Dim NOV_ESTOQUE As Integer
        Dim DEZ_ESTOQUE As Integer
        Dim TOTAL_ESTOQUE As Integer
        Dim ESTOQUE_INICIAL As Integer

        Dim JAN_VENDA As Integer
        Dim FEV_VENDA As Integer
        Dim MAR_VENDA As Integer
        Dim ABR_VENDA As Integer
        Dim MAI_VENDA As Integer
        Dim JUN_VENDA As Integer
        Dim JUL_VENDA As Integer
        Dim AGO_VENDA As Integer
        Dim SET_VENDA As Integer
        Dim OUT_VENDA As Integer
        Dim NOV_VENDA As Integer
        Dim DEZ_VENDA As Integer
        Dim YTD_VENDA As Integer
        Dim YTD_VENDA_MEDIA As Integer
        Dim TOTAL_VENDA As Integer

        Dim JAN_DEMANDA As Integer
        Dim FEV_DEMANDA As Integer
        Dim MAR_DEMANDA As Integer
        Dim ABR_DEMANDA As Integer
        Dim MAI_DEMANDA As Integer
        Dim JUN_DEMANDA As Integer
        Dim JUL_DEMANDA As Integer
        Dim AGO_DEMANDA As Integer
        Dim SET_DEMANDA As Integer
        Dim OUT_DEMANDA As Integer
        Dim NOV_DEMANDA As Integer
        Dim DEZ_DEMANDA As Integer
        Dim YTD_DEMANDA As Integer
        Dim YTD_DEMANDA_MEDIA As Integer
        Dim TOTAL_DEMANDA As Integer

        Dim JAN_VENDA_TOTAL As Integer
        Dim FEV_VENDA_TOTAL As Integer
        Dim MAR_VENDA_TOTAL As Integer
        Dim ABR_VENDA_TOTAL As Integer
        Dim MAI_VENDA_TOTAL As Integer
        Dim JUN_VENDA_TOTAL As Integer
        Dim JUL_VENDA_TOTAL As Integer
        Dim AGO_VENDA_TOTAL As Integer
        Dim SET_VENDA_TOTAL As Integer
        Dim OUT_VENDA_TOTAL As Integer
        Dim NOV_VENDA_TOTAL As Integer
        Dim DEZ_VENDA_TOTAL As Integer
        Dim YTD_VENDA_TOTAL As Integer
        Dim YTD_VENDA_TOTAL_MEDIA As Integer
        Dim TOTAL_VENDA_TOTAL As Integer

        Dim JAN_DEMANDA_TOTAL As Integer
        Dim FEV_DEMANDA_TOTAL As Integer
        Dim MAR_DEMANDA_TOTAL As Integer
        Dim ABR_DEMANDA_TOTAL As Integer
        Dim MAI_DEMANDA_TOTAL As Integer
        Dim JUN_DEMANDA_TOTAL As Integer
        Dim JUL_DEMANDA_TOTAL As Integer
        Dim AGO_DEMANDA_TOTAL As Integer
        Dim SET_DEMANDA_TOTAL As Integer
        Dim OUT_DEMANDA_TOTAL As Integer
        Dim NOV_DEMANDA_TOTAL As Integer
        Dim DEZ_DEMANDA_TOTAL As Integer
        Dim YTD_DEMANDA_TOTAL As Integer
        Dim YTD_DEMANDA_TOTAL_MEDIA As Integer
        Dim TOTAL_DEMANDA_TOTAL As Integer

        Dim JAN_COTA As Double
        Dim FEV_COTA As Double
        Dim MAR_COTA As Double
        Dim ABR_COTA As Double
        Dim MAI_COTA As Double
        Dim JUN_COTA As Double
        Dim JUL_COTA As Double
        Dim AGO_COTA As Double
        Dim SET_COTA As Double
        Dim OUT_COTA As Double
        Dim NOV_COTA As Double
        Dim DEZ_COTA As Double
        Dim TOTAL_COTA As Double
        Dim YTD_COTA As Double

        Dim JAN_PERFORMANCE As Double
        Dim FEV_PERFORMANCE As Double
        Dim MAR_PERFORMANCE As Double
        Dim ABR_PERFORMANCE As Double
        Dim MAI_PERFORMANCE As Double
        Dim JUN_PERFORMANCE As Double
        Dim JUL_PERFORMANCE As Double
        Dim AGO_PERFORMANCE As Double
        Dim SET_PERFORMANCE As Double
        Dim OUT_PERFORMANCE As Double
        Dim NOV_PERFORMANCE As Double
        Dim DEZ_PERFORMANCE As Double
        Dim TRI01_PERFORMANCE As Double
        Dim TRI02_PERFORMANCE As Double
        Dim TRI03_PERFORMANCE As Double
        Dim TRI04_PERFORMANCE As Double
        Dim TOTAL_PERFORMANCE As Double
        Dim YTD_PERFORMANCE As Double

        Dim JAN_PARTICIPACAO_VENDA As Double
        Dim FEV_PARTICIPACAO_VENDA As Double
        Dim MAR_PARTICIPACAO_VENDA As Double
        Dim ABR_PARTICIPACAO_VENDA As Double
        Dim MAI_PARTICIPACAO_VENDA As Double
        Dim JUN_PARTICIPACAO_VENDA As Double
        Dim JUL_PARTICIPACAO_VENDA As Double
        Dim AGO_PARTICIPACAO_VENDA As Double
        Dim SET_PARTICIPACAO_VENDA As Double
        Dim OUT_PARTICIPACAO_VENDA As Double
        Dim NOV_PARTICIPACAO_VENDA As Double
        Dim DEZ_PARTICIPACAO_VENDA As Double
        Dim TRI01_PARTICIPACAO_VENDA As Double
        Dim TRI02_PARTICIPACAO_VENDA As Double
        Dim TRI03_PARTICIPACAO_VENDA As Double
        Dim TRI04_PARTICIPACAO_VENDA As Double
        Dim TOTAL_PARTICIPACAO_VENDA As Double
        Dim YTD_PARTICIPACAO_VENDA As Double

        Dim JAN_PARTICIPACAO_VENDA_HOSPIRA As Double
        Dim FEV_PARTICIPACAO_VENDA_HOSPIRA As Double
        Dim MAR_PARTICIPACAO_VENDA_HOSPIRA As Double
        Dim ABR_PARTICIPACAO_VENDA_HOSPIRA As Double
        Dim MAI_PARTICIPACAO_VENDA_HOSPIRA As Double
        Dim JUN_PARTICIPACAO_VENDA_HOSPIRA As Double
        Dim JUL_PARTICIPACAO_VENDA_HOSPIRA As Double
        Dim AGO_PARTICIPACAO_VENDA_HOSPIRA As Double
        Dim SET_PARTICIPACAO_VENDA_HOSPIRA As Double
        Dim OUT_PARTICIPACAO_VENDA_HOSPIRA As Double
        Dim NOV_PARTICIPACAO_VENDA_HOSPIRA As Double
        Dim DEZ_PARTICIPACAO_VENDA_HOSPIRA As Double
        Dim TRI01_PARTICIPACAO_VENDA_HOSPIRA As Double
        Dim TRI02_PARTICIPACAO_VENDA_HOSPIRA As Double
        Dim TRI03_PARTICIPACAO_VENDA_HOSPIRA As Double
        Dim TRI04_PARTICIPACAO_VENDA_HOSPIRA As Double
        Dim TOTAL_PARTICIPACAO_VENDA_HOSPIRA As Double
        Dim YTD_PARTICIPACAO_VENDA_HOSPIRA As Double

        Dim JAN_PARTICIPACAO_DEMANDA As Double
        Dim FEV_PARTICIPACAO_DEMANDA As Double
        Dim MAR_PARTICIPACAO_DEMANDA As Double
        Dim ABR_PARTICIPACAO_DEMANDA As Double
        Dim MAI_PARTICIPACAO_DEMANDA As Double
        Dim JUN_PARTICIPACAO_DEMANDA As Double
        Dim JUL_PARTICIPACAO_DEMANDA As Double
        Dim AGO_PARTICIPACAO_DEMANDA As Double
        Dim SET_PARTICIPACAO_DEMANDA As Double
        Dim OUT_PARTICIPACAO_DEMANDA As Double
        Dim NOV_PARTICIPACAO_DEMANDA As Double
        Dim DEZ_PARTICIPACAO_DEMANDA As Double
        Dim TRI01_PARTICIPACAO_DEMANDA As Double
        Dim TRI02_PARTICIPACAO_DEMANDA As Double
        Dim TRI03_PARTICIPACAO_DEMANDA As Double
        Dim TRI04_PARTICIPACAO_DEMANDA As Double
        Dim TOTAL_PARTICIPACAO_DEMANDA As Double
        Dim YTD_PARTICIPACAO_DEMANDA As Double

        ' ----------------------------------------------------Monta Cabeçalho Total -------------------------------------------------------------------------------------------------------------------
        'RECUPERA ANO INICIAL E LINHA DE PRODUTOS
        LINHA_PRODUTO = cmb_LINHA.Text
        Integer.TryParse(cmb_Anos.Text, ANO)

        'ABRE CONEXÕES
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnSTR").ConnectionString
        cnn.Open()
        cnn_Dst.ConnectionString = ConfigurationManager.ConnectionStrings("cnnSTR").ConnectionString
        cnn_Dst.Open()

        'LINHA DE TOTAL - SOMA TODOS OS RESULTADOS
        'LINHA CABECALHO
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        'COLUNA NOME DO GRUPO DISTRIBUIDOR
        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Brasil"
        cel.Font.Bold = True
        cel.HorizontalAlign = HorizontalAlign.Left
        cel.BackColor = Drawing.Color.Gainsboro

        'COLUNAS MESES
        sql = "SELECT MES_NUMERO_VALOR,MES_SIGLA FROM TBL_DATAS_MESES WHERE MES_NUMERO_VALOR > 0 ORDER BY MES_NUMERO_VALOR"
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader

        Do While dtr.Read
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.BackColor = Drawing.Color.Gainsboro
            cel.Text = dtr("MES_SIGLA")
            cel.Font.Bold = False
            cel.HorizontalAlign = HorizontalAlign.Center
        Loop
        dtr.Close()


        'COLUNA YTD
        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "YTD"
        cel.Font.Bold = False
        cel.HorizontalAlign = HorizontalAlign.Center
        cel.BackColor = Drawing.Color.Gainsboro

        'COLUNA YTD
        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Média YTD"
        cel.Font.Bold = False
        cel.HorizontalAlign = HorizontalAlign.Center
        cel.BackColor = Drawing.Color.Gainsboro

        'COLUNA TOTAL
        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Total"
        cel.Font.Bold = False
        cel.HorizontalAlign = HorizontalAlign.Center
        cel.BackColor = Drawing.Color.Gainsboro


        ' ----------------------------------------------------Venda - Total -------------------------------------------------------------------------------------------------------------------

        'LINHA VENDAS
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        'CELULA TIPO
        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Venda "
        cel.HorizontalAlign = HorizontalAlign.Center

        'RECUPERA VENDA_TOTALS
        sql = ""
        sql = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_TOTAL_GERAL WHERE TIPO = '01 VENDA' AND ANO = " & ANO & " AND LINHA = '" & LINHA_PRODUTO & "'"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            'Response.Write(sql)
            'CELULA JAN
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("JAN"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            JAN_VENDA_TOTAL = FormatNumber(dtr("JAN"), 0)
            'CELULA FEV
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("FEV"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            FEV_VENDA_TOTAL = FormatNumber(dtr("FEV"), 0)
            'CELULA MAR
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("MAR"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            MAR_VENDA_TOTAL = FormatNumber(dtr("MAR"), 0)
            'CELULA ABR
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("ABR"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            ABR_VENDA_TOTAL = FormatNumber(dtr("ABR"), 0)
            'CELULA MAI
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("MAI"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            MAI_VENDA_TOTAL = FormatNumber(dtr("MAI"), 0)
            'CELULA JUN
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("JUN"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            JUN_VENDA_TOTAL = FormatNumber(dtr("JUN"), 0)
            'CELULA JUL
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("JUL"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            JUL_VENDA_TOTAL = FormatNumber(dtr("JUL"), 0)
            'CELULA AGO
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("AGO"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            AGO_VENDA_TOTAL = FormatNumber(dtr("AGO"), 0)
            'CELULA SET
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("SET"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            SET_VENDA_TOTAL = FormatNumber(dtr("SET"), 0)
            'CELULA OUT
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("OUT"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            OUT_VENDA_TOTAL = FormatNumber(dtr("OUT"), 0)
            'CELULA NOV
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("NOV"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            NOV_VENDA_TOTAL = FormatNumber(dtr("NOV"), 0)
            'CELULA DEZ
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("DEZ"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            DEZ_VENDA_TOTAL = FormatNumber(dtr("DEZ"), 0)

            'CELULA YTD
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("YTD"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            YTD_VENDA_TOTAL = FormatNumber(dtr("YTD"), 0)

            'CELULA MEDIA
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("MEDIA_YTD"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            YTD_VENDA_TOTAL_MEDIA = FormatNumber(dtr("MEDIA_YTD"), 0)

            'CELULA TOTAL
            cel = New TableCell
            rw.Cells.Add(cel)
            TOTAL_VENDA_TOTAL = JAN_VENDA_TOTAL + FEV_VENDA_TOTAL + MAR_VENDA_TOTAL + ABR_VENDA_TOTAL + MAI_VENDA_TOTAL + JUN_VENDA_TOTAL + JUL_VENDA_TOTAL + AGO_VENDA_TOTAL + SET_VENDA_TOTAL + OUT_VENDA_TOTAL + NOV_VENDA_TOTAL + DEZ_VENDA_TOTAL
            cel.Text = FormatNumber(TOTAL_VENDA_TOTAL, 0)
            cel.HorizontalAlign = HorizontalAlign.Center
        Else
            For X = 1 To 15
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = 0
                cel.HorizontalAlign = HorizontalAlign.Center
            Next
            JAN_VENDA_TOTAL = 0
            FEV_VENDA_TOTAL = 0
            MAR_VENDA_TOTAL = 0
            ABR_VENDA_TOTAL = 0
            MAI_VENDA_TOTAL = 0
            JUN_VENDA_TOTAL = 0
            JUL_VENDA_TOTAL = 0
            AGO_VENDA_TOTAL = 0
            SET_VENDA_TOTAL = 0
            OUT_VENDA_TOTAL = 0
            NOV_VENDA_TOTAL = 0
            DEZ_VENDA_TOTAL = 0
            TOTAL_VENDA_TOTAL = 0
            YTD_VENDA_TOTAL = 0
            YTD_VENDA_TOTAL_MEDIA = 0
        End If
        dtr.Close()

        ' ----------------------------------------------------Demanda - Total -------------------------------------------------------------------------------------------------------------------

        'LINHA DEMANDA 
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        'CELULA TIPO
        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Demanda "
        cel.HorizontalAlign = HorizontalAlign.Center

        'RECUPERA DEMANDA
        sql = ""
        sql = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_TOTAL_GERAL WHERE TIPO = '02 DEMANDA' AND ANO = " & ANO & " AND LINHA = '" & LINHA_PRODUTO & "'"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            'CELULA JAN
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("JAN"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            JAN_DEMANDA_TOTAL = FormatNumber(dtr("JAN"), 0)
            'CELULA FEV
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("FEV"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            FEV_DEMANDA_TOTAL = FormatNumber(dtr("FEV"), 0)
            'CELULA MAR
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("MAR"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            MAR_DEMANDA_TOTAL = FormatNumber(dtr("MAR"), 0)
            'CELULA ABR
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("ABR"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            ABR_DEMANDA_TOTAL = FormatNumber(dtr("ABR"), 0)
            'CELULA MAI
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("MAI"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            MAI_DEMANDA_TOTAL = FormatNumber(dtr("MAI"), 0)
            'CELULA JUN
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("JUN"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            JUN_DEMANDA_TOTAL = FormatNumber(dtr("JUN"), 0)
            'CELULA JUL
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("JUL"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            JUL_DEMANDA_TOTAL = FormatNumber(dtr("JUL"), 0)
            'CELULA AGO
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("AGO"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            AGO_DEMANDA_TOTAL = FormatNumber(dtr("AGO"), 0)
            'CELULA SET
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("SET"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            SET_DEMANDA_TOTAL = FormatNumber(dtr("SET"), 0)
            'CELULA OUT
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("OUT"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            OUT_DEMANDA_TOTAL = FormatNumber(dtr("OUT"), 0)
            'CELULA NOV
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("NOV"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            NOV_DEMANDA_TOTAL = FormatNumber(dtr("NOV"), 0)
            'CELULA DEZ
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("DEZ"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            DEZ_DEMANDA_TOTAL = FormatNumber(dtr("DEZ"), 0)

            'CELULA YTD
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("YTD"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            YTD_DEMANDA_TOTAL = FormatNumber(dtr("YTD"), 0)

            'CELULA MEDIA
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("MEDIA_YTD"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            YTD_DEMANDA_TOTAL_MEDIA = FormatNumber(dtr("MEDIA_YTD"), 0)

            'CELULA TOTAL
            cel = New TableCell
            rw.Cells.Add(cel)
            TOTAL_DEMANDA_TOTAL = JAN_DEMANDA_TOTAL + FEV_DEMANDA_TOTAL + MAR_DEMANDA_TOTAL + ABR_DEMANDA_TOTAL + MAI_DEMANDA_TOTAL + JUN_DEMANDA_TOTAL + JUL_DEMANDA_TOTAL + AGO_DEMANDA_TOTAL + SET_DEMANDA_TOTAL + OUT_DEMANDA_TOTAL + NOV_DEMANDA_TOTAL + DEZ_DEMANDA_TOTAL
            cel.Text = FormatNumber(TOTAL_DEMANDA_TOTAL, 0)
            cel.HorizontalAlign = HorizontalAlign.Center
        Else
            For X = 1 To 15
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = 0
                cel.HorizontalAlign = HorizontalAlign.Center
            Next
            JAN_DEMANDA_TOTAL = 0
            FEV_DEMANDA_TOTAL = 0
            MAR_DEMANDA_TOTAL = 0
            ABR_DEMANDA_TOTAL = 0
            MAI_DEMANDA_TOTAL = 0
            JUN_DEMANDA_TOTAL = 0
            JUL_DEMANDA_TOTAL = 0
            AGO_DEMANDA_TOTAL = 0
            SET_DEMANDA_TOTAL = 0
            OUT_DEMANDA_TOTAL = 0
            NOV_DEMANDA_TOTAL = 0
            DEZ_DEMANDA_TOTAL = 0
            TOTAL_DEMANDA_TOTAL = 0
            YTD_DEMANDA_TOTAL = 0
            YTD_DEMANDA_TOTAL_MEDIA = 0
        End If
        dtr.Close()

        ' ----------------------------------------------------Cota - Total -------------------------------------------------------------------------------------------------------------------

        'LINHA COTA 
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        'CELULA TIPO
        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Cota de Demanda "
        cel.HorizontalAlign = HorizontalAlign.Center

        'RECUPERA COTA
        sql = ""
        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ, "
        sql = sql & "SUM(TOTAL) AS TOTAL, SUM(TRI1) AS TRI01, SUM(TRI2) AS TRI02,SUM(TRI3) AS TRI03,SUM(TRI4) AS TRI04, SUM(YTD) AS YTD "
        sql = sql & "FROM dbo.VIEW_COTAS "
        sql = sql & "WHERE (ANO = '" & ANO & "' AND LINHA_PRODUTO = '" & LINHA_PRODUTO & "') "

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows And Not IsDBNull(dtr("JAN")) Then

            'CELULA JAN
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("JAN"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            JAN_COTA = FormatNumber(dtr("JAN"), 0)
            'CELULA FEV
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("FEV"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            FEV_COTA = FormatNumber(dtr("FEV"), 0)
            'CELULA MAR
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("MAR"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            MAR_COTA = FormatNumber(dtr("MAR"), 0)
            'CELULA ABR
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("ABR"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            ABR_COTA = FormatNumber(dtr("ABR"), 0)
            'CELULA MAI
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("MAI"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            MAI_COTA = FormatNumber(dtr("MAI"), 0)
            'CELULA JUN
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("JUN"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            JUN_COTA = FormatNumber(dtr("JUN"), 0)
            'CELULA JUL
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("JUL"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            JUL_COTA = FormatNumber(dtr("JUL"), 0)
            'CELULA AGO
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("AGO"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            AGO_COTA = FormatNumber(dtr("AGO"), 0)
            'CELULA SET
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("SET"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            SET_COTA = FormatNumber(dtr("SET"), 0)
            'CELULA OUT
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("OUT"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            OUT_COTA = FormatNumber(dtr("OUT"), 0)
            'CELULA NOV
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("NOV"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            NOV_COTA = FormatNumber(dtr("NOV"), 0)
            'CELULA DEZ
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("DEZ"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            DEZ_COTA = FormatNumber(dtr("DEZ"), 0)

            'CELULA YTD
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(dtr("YTD"), 0)
            cel.HorizontalAlign = HorizontalAlign.Center
            YTD_COTA = FormatNumber(dtr("YTD"), 0)

            'CELULA YTD
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = ""
            cel.HorizontalAlign = HorizontalAlign.Center

            'CELULA TOTAL
            cel = New TableCell
            rw.Cells.Add(cel)
            TOTAL_COTA = JAN_COTA + FEV_COTA + MAR_COTA + ABR_COTA + MAI_COTA + JUN_COTA + JUL_COTA + AGO_COTA + SET_COTA + OUT_COTA + NOV_COTA + DEZ_COTA
            cel.Text = FormatNumber(TOTAL_COTA, 0)
            cel.HorizontalAlign = HorizontalAlign.Center
        Else
            For X = 1 To 15
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = 0
                cel.HorizontalAlign = HorizontalAlign.Center
            Next
            JAN_COTA = 0
            FEV_COTA = 0
            MAR_COTA = 0
            ABR_COTA = 0
            MAI_COTA = 0
            JUN_COTA = 0
            JUL_COTA = 0
            AGO_COTA = 0
            SET_COTA = 0
            OUT_COTA = 0
            NOV_COTA = 0
            DEZ_COTA = 0
            TOTAL_COTA = 0
            YTD_COTA = 0
        End If
        dtr.Close()
        ' ----------------------------------------------------Perfomance - Total  -------------------------------------------------------------------------------------------------------------------
        JAN_PERFORMANCE = 0
        FEV_PERFORMANCE = 0
        MAR_PERFORMANCE = 0
        ABR_PERFORMANCE = 0
        MAI_PERFORMANCE = 0
        JUN_PERFORMANCE = 0
        JUL_PERFORMANCE = 0
        AGO_PERFORMANCE = 0
        SET_PERFORMANCE = 0
        OUT_PERFORMANCE = 0
        NOV_PERFORMANCE = 0
        DEZ_PERFORMANCE = 0
        TRI01_PERFORMANCE = 0
        TRI02_PERFORMANCE = 0
        TRI03_PERFORMANCE = 0
        TRI04_PERFORMANCE = 0
        TOTAL_PERFORMANCE = 0
        YTD_PERFORMANCE = 0

        If JAN_COTA <> 0 Then JAN_PERFORMANCE = Round((JAN_DEMANDA_TOTAL / JAN_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If FEV_COTA <> 0 Then FEV_PERFORMANCE = Round((FEV_DEMANDA_TOTAL / FEV_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If MAR_COTA <> 0 Then MAR_PERFORMANCE = Round((MAR_DEMANDA_TOTAL / MAR_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If ABR_COTA <> 0 Then ABR_PERFORMANCE = Round((ABR_DEMANDA_TOTAL / ABR_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If MAI_COTA <> 0 Then MAI_PERFORMANCE = Round((MAI_DEMANDA_TOTAL / MAI_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If JUN_COTA <> 0 Then JUN_PERFORMANCE = Round((JUN_DEMANDA_TOTAL / JUN_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If JUL_COTA <> 0 Then JUL_PERFORMANCE = Round((JUL_DEMANDA_TOTAL / JUL_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If AGO_COTA <> 0 Then AGO_PERFORMANCE = Round((AGO_DEMANDA_TOTAL / AGO_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If SET_COTA <> 0 Then SET_PERFORMANCE = Round((SET_DEMANDA_TOTAL / SET_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If OUT_COTA <> 0 Then OUT_PERFORMANCE = Round((OUT_DEMANDA_TOTAL / OUT_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If NOV_COTA <> 0 Then NOV_PERFORMANCE = Round((NOV_DEMANDA_TOTAL / NOV_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If DEZ_COTA <> 0 Then DEZ_PERFORMANCE = Round((DEZ_DEMANDA_TOTAL / DEZ_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If YTD_COTA <> 0 Then YTD_PERFORMANCE = Round((YTD_DEMANDA_TOTAL / YTD_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If TOTAL_COTA <> 0 Then TOTAL_PERFORMANCE = Round((TOTAL_DEMANDA_TOTAL / TOTAL_COTA) * 100, 2, MidpointRounding.AwayFromZero)



        'LINHA Perfomance
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        'CELULA TIPO
        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Performance "
        cel.HorizontalAlign = HorizontalAlign.Center


        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_PERFORMANCE, 2) & " %"
        If JAN_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If JAN_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If JAN_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If JAN_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.HorizontalAlign = HorizontalAlign.Center

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_PERFORMANCE, 2) & " %"
        If FEV_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If FEV_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If FEV_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If FEV_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.HorizontalAlign = HorizontalAlign.Center

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_PERFORMANCE, 2) & " %"
        If MAR_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If MAR_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If MAR_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If MAR_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.HorizontalAlign = HorizontalAlign.Center

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_PERFORMANCE, 2) & " %"
        If ABR_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If ABR_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If ABR_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If ABR_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.HorizontalAlign = HorizontalAlign.Center

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_PERFORMANCE, 2) & " %"
        If MAI_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If MAI_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If MAI_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If MAI_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.HorizontalAlign = HorizontalAlign.Center

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_PERFORMANCE, 2) & " %"
        If JUN_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If JUN_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If JUN_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If JUN_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.HorizontalAlign = HorizontalAlign.Center

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_PERFORMANCE, 2) & " %"
        If JUL_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If JUL_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If JUL_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If JUL_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.HorizontalAlign = HorizontalAlign.Center

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_PERFORMANCE, 2) & " %"
        If AGO_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If AGO_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If AGO_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If AGO_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.HorizontalAlign = HorizontalAlign.Center

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_PERFORMANCE, 2) & " %"
        If SET_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If SET_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If SET_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If SET_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.HorizontalAlign = HorizontalAlign.Center

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_PERFORMANCE, 2) & " %"
        If OUT_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If OUT_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If OUT_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If OUT_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.HorizontalAlign = HorizontalAlign.Center

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_PERFORMANCE, 2) & " %"
        If NOV_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If NOV_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If NOV_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If NOV_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.HorizontalAlign = HorizontalAlign.Center

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_PERFORMANCE, 2) & " %"
        If DEZ_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If DEZ_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If DEZ_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If DEZ_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.HorizontalAlign = HorizontalAlign.Center

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_PERFORMANCE, 2) & " %"
        If YTD_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If YTD_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If YTD_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If YTD_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.HorizontalAlign = HorizontalAlign.Center

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.HorizontalAlign = HorizontalAlign.Center

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_PERFORMANCE, 2) & " %"
        If TOTAL_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If TOTAL_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If TOTAL_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If TOTAL_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.HorizontalAlign = HorizontalAlign.Center

        ' ----------------------------------------------------Hospira -------------------------------------------------------------------------------------------------------------------

        'Recupera GRUPOS_DISTRIBUIDORES

        sql_Dst = "SELECT DISTINCT GRUPO FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_TOTAL WHERE ANO = " & ANO & " AND GRUPO = '01 - Hospira' ORDER BY GRUPO "
        cmd_Dst.Connection = cnn_Dst
        cmd_Dst.CommandText = sql_Dst
        dtr_Dst = cmd_Dst.ExecuteReader
        Do While dtr_Dst.Read
            GRUPO_DISTRIBUIDOR = ""

            GRUPO_DISTRIBUIDOR = dtr_Dst("GRUPO")

            ' ----------------------------------------------------Monta Cabeçalho - Hospira -------------------------------------------------------------------------------------------------------------------
            'LINHA VAZIA
            rw = New TableRow
            tbl_Report.Rows.Add(rw)
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "."
            cel.ColumnSpan = 14
            cel.ForeColor = Drawing.Color.White
            cel.BorderStyle = BorderStyle.None

            'LINHA CABECALHO
            rw = New TableRow
            tbl_Report.Rows.Add(rw)

            'COLUNA NOME DO GRUPO DISTRIBUIDOR
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = GRUPO_DISTRIBUIDOR
            cel.Font.Bold = True
            cel.HorizontalAlign = HorizontalAlign.Left
            cel.BackColor = Drawing.Color.WhiteSmoke

            'COLUNAS MESES
            sql = "SELECT MES_SIGLA FROM TBL_DATAS_MESES WHERE MES_NUMERO_VALOR > 0 ORDER BY MES_NUMERO_VALOR"
            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader

            Do While dtr.Read
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = dtr("MES_SIGLA")
                cel.Font.Bold = False
                cel.HorizontalAlign = HorizontalAlign.Center
                cel.BackColor = Drawing.Color.WhiteSmoke
            Loop
            dtr.Close()

            'COLUNA YTD
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "YTD"
            cel.Font.Bold = False
            cel.HorizontalAlign = HorizontalAlign.Center
            cel.BackColor = Drawing.Color.WhiteSmoke

            'COLUNA TOTAL
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "Total"
            cel.Font.Bold = False
            cel.HorizontalAlign = HorizontalAlign.Center
            cel.BackColor = Drawing.Color.WhiteSmoke

            'COLUNA YTD
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "Média YTD"
            cel.Font.Bold = False
            cel.HorizontalAlign = HorizontalAlign.Center
            cel.BackColor = Drawing.Color.WhiteSmoke


            ' ----------------------------------------------------Venda Direta (Demanda) - Hospira -------------------------------------------------------------------------------------------------------------------

            'LINHA Venda 
            rw = New TableRow
            tbl_Report.Rows.Add(rw)

            'CELULA TIPO
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "Venda Direta "
            cel.HorizontalAlign = HorizontalAlign.Center

            'RECUPERA VENDA DIRETA (DEMANDA)
            sql = ""
            sql = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_TOTAL WHERE GRUPO = '" & GRUPO_DISTRIBUIDOR & "' AND TIPO = '02 DEMANDA' AND ANO = " & ANO & " AND LINHA = '" & LINHA_PRODUTO & "'"

            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader
            dtr.Read()
            If dtr.HasRows Then
                'CELULA JAN
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("JAN"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                JAN_DEMANDA = FormatNumber(dtr("JAN"), 0)
                'CELULA FEV
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("FEV"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                FEV_DEMANDA = FormatNumber(dtr("FEV"), 0)
                'CELULA MAR
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("MAR"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                MAR_DEMANDA = FormatNumber(dtr("MAR"), 0)
                'CELULA ABR
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("ABR"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                ABR_DEMANDA = FormatNumber(dtr("ABR"), 0)
                'CELULA MAI
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("MAI"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                MAI_DEMANDA = FormatNumber(dtr("MAI"), 0)
                'CELULA JUN
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("JUN"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                JUN_DEMANDA = FormatNumber(dtr("JUN"), 0)
                'CELULA JUL
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("JUL"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                JUL_DEMANDA = FormatNumber(dtr("JUL"), 0)
                'CELULA AGO
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("AGO"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                AGO_DEMANDA = FormatNumber(dtr("AGO"), 0)
                'CELULA SET
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("SET"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                SET_DEMANDA = FormatNumber(dtr("SET"), 0)
                'CELULA OUT
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("OUT"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                OUT_DEMANDA = FormatNumber(dtr("OUT"), 0)
                'CELULA NOV
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("NOV"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                NOV_DEMANDA = FormatNumber(dtr("NOV"), 0)
                'CELULA DEZ
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("DEZ"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                DEZ_DEMANDA = FormatNumber(dtr("DEZ"), 0)
                'CELULA YTD
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("YTD"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                YTD_DEMANDA = FormatNumber(dtr("YTD"), 0)

                'CELULA TOTAL
                cel = New TableCell
                rw.Cells.Add(cel)
                TOTAL_DEMANDA = JAN_DEMANDA + FEV_DEMANDA + MAR_DEMANDA + ABR_DEMANDA + MAI_DEMANDA + JUN_DEMANDA + JUL_DEMANDA + AGO_DEMANDA + SET_DEMANDA + OUT_DEMANDA + NOV_DEMANDA + DEZ_DEMANDA
                cel.Text = FormatNumber(TOTAL_DEMANDA, 0)
                cel.HorizontalAlign = HorizontalAlign.Center

                'CELULA MEDIA
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("MEDIA_YTD"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                YTD_DEMANDA_MEDIA = FormatNumber(dtr("MEDIA_YTD"), 0)

            Else
                For X = 1 To 15
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                Next
                JAN_DEMANDA = 0
                FEV_DEMANDA = 0
                MAR_DEMANDA = 0
                ABR_DEMANDA = 0
                MAI_DEMANDA = 0
                JUN_DEMANDA = 0
                JUL_DEMANDA = 0
                AGO_DEMANDA = 0
                SET_DEMANDA = 0
                OUT_DEMANDA = 0
                NOV_DEMANDA = 0
                DEZ_DEMANDA = 0
                YTD_DEMANDA = 0
                YTD_DEMANDA_MEDIA = 0
                TOTAL_DEMANDA = 0
            End If

            ' ----------------------------------------------------Participação Venda - Hospira -------------------------------------------------------------------------------------------------------------------

            JAN_PARTICIPACAO_VENDA_HOSPIRA = 0
            FEV_PARTICIPACAO_VENDA_HOSPIRA = 0
            MAR_PARTICIPACAO_VENDA_HOSPIRA = 0
            ABR_PARTICIPACAO_VENDA_HOSPIRA = 0
            MAI_PARTICIPACAO_VENDA_HOSPIRA = 0
            JUN_PARTICIPACAO_VENDA_HOSPIRA = 0
            JUL_PARTICIPACAO_VENDA_HOSPIRA = 0
            AGO_PARTICIPACAO_VENDA_HOSPIRA = 0
            SET_PARTICIPACAO_VENDA_HOSPIRA = 0
            OUT_PARTICIPACAO_VENDA_HOSPIRA = 0
            NOV_PARTICIPACAO_VENDA_HOSPIRA = 0
            DEZ_PARTICIPACAO_VENDA_HOSPIRA = 0
            TRI01_PARTICIPACAO_VENDA_HOSPIRA = 0
            TRI02_PARTICIPACAO_VENDA_HOSPIRA = 0
            TRI03_PARTICIPACAO_VENDA_HOSPIRA = 0
            TRI04_PARTICIPACAO_VENDA_HOSPIRA = 0
            TOTAL_PARTICIPACAO_VENDA_HOSPIRA = 0
            YTD_PARTICIPACAO_VENDA_HOSPIRA = 0

            If JAN_VENDA_TOTAL <> 0 Then JAN_PARTICIPACAO_VENDA_HOSPIRA = Round((JAN_DEMANDA / JAN_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If FEV_VENDA_TOTAL <> 0 Then FEV_PARTICIPACAO_VENDA_HOSPIRA = Round((FEV_DEMANDA / FEV_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If MAR_VENDA_TOTAL <> 0 Then MAR_PARTICIPACAO_VENDA_HOSPIRA = Round((MAR_DEMANDA / MAR_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If ABR_VENDA_TOTAL <> 0 Then ABR_PARTICIPACAO_VENDA_HOSPIRA = Round((ABR_DEMANDA / ABR_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If MAI_VENDA_TOTAL <> 0 Then MAI_PARTICIPACAO_VENDA_HOSPIRA = Round((MAI_DEMANDA / MAI_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If JUN_VENDA_TOTAL <> 0 Then JUN_PARTICIPACAO_VENDA_HOSPIRA = Round((JUN_DEMANDA / JUN_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If JUL_VENDA_TOTAL <> 0 Then JUL_PARTICIPACAO_VENDA_HOSPIRA = Round((JUL_DEMANDA / JUL_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If AGO_VENDA_TOTAL <> 0 Then AGO_PARTICIPACAO_VENDA_HOSPIRA = Round((AGO_DEMANDA / AGO_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If SET_VENDA_TOTAL <> 0 Then SET_PARTICIPACAO_VENDA_HOSPIRA = Round((SET_DEMANDA / SET_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If OUT_VENDA_TOTAL <> 0 Then OUT_PARTICIPACAO_VENDA_HOSPIRA = Round((OUT_DEMANDA / OUT_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If NOV_VENDA_TOTAL <> 0 Then NOV_PARTICIPACAO_VENDA_HOSPIRA = Round((NOV_DEMANDA / NOV_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If DEZ_VENDA_TOTAL <> 0 Then DEZ_PARTICIPACAO_VENDA_HOSPIRA = Round((DEZ_DEMANDA / DEZ_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If YTD_VENDA_TOTAL <> 0 Then YTD_PARTICIPACAO_VENDA_HOSPIRA = Round((YTD_DEMANDA / YTD_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If TOTAL_VENDA_TOTAL <> 0 Then TOTAL_PARTICIPACAO_VENDA_HOSPIRA = Round((TOTAL_DEMANDA / TOTAL_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)

            'LINHA Perfomance
            rw = New TableRow
            tbl_Report.Rows.Add(rw)

            'CELULA TIPO
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "Participação na Venda % "
            cel.HorizontalAlign = HorizontalAlign.Center


            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(JAN_PARTICIPACAO_VENDA_HOSPIRA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(FEV_PARTICIPACAO_VENDA_HOSPIRA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(MAR_PARTICIPACAO_VENDA_HOSPIRA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(ABR_PARTICIPACAO_VENDA_HOSPIRA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(MAI_PARTICIPACAO_VENDA_HOSPIRA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(JUN_PARTICIPACAO_VENDA_HOSPIRA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(JUL_PARTICIPACAO_VENDA_HOSPIRA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(AGO_PARTICIPACAO_VENDA_HOSPIRA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(SET_PARTICIPACAO_VENDA_HOSPIRA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(OUT_PARTICIPACAO_VENDA_HOSPIRA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(NOV_PARTICIPACAO_VENDA_HOSPIRA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(DEZ_PARTICIPACAO_VENDA_HOSPIRA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(YTD_PARTICIPACAO_VENDA_HOSPIRA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(TOTAL_PARTICIPACAO_VENDA_HOSPIRA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = ""
            cel.HorizontalAlign = HorizontalAlign.Center

            JAN_PARTICIPACAO_VENDA_HOSPIRA = 0
            FEV_PARTICIPACAO_VENDA_HOSPIRA = 0
            MAR_PARTICIPACAO_VENDA_HOSPIRA = 0
            ABR_PARTICIPACAO_VENDA_HOSPIRA = 0
            MAI_PARTICIPACAO_VENDA_HOSPIRA = 0
            JUN_PARTICIPACAO_VENDA_HOSPIRA = 0
            JUL_PARTICIPACAO_VENDA_HOSPIRA = 0
            AGO_PARTICIPACAO_VENDA_HOSPIRA = 0
            SET_PARTICIPACAO_VENDA_HOSPIRA = 0
            OUT_PARTICIPACAO_VENDA_HOSPIRA = 0
            NOV_PARTICIPACAO_VENDA_HOSPIRA = 0
            DEZ_PARTICIPACAO_VENDA_HOSPIRA = 0
            TRI01_PARTICIPACAO_VENDA_HOSPIRA = 0
            TRI02_PARTICIPACAO_VENDA_HOSPIRA = 0
            TRI03_PARTICIPACAO_VENDA_HOSPIRA = 0
            TRI04_PARTICIPACAO_VENDA_HOSPIRA = 0
            TOTAL_PARTICIPACAO_VENDA_HOSPIRA = 0
            YTD_PARTICIPACAO_VENDA_HOSPIRA = 0

            ' ----------------------------------------------------Participação DEMANDA - Hospira -------------------------------------------------------------------------------------------------------------------

            JAN_PARTICIPACAO_DEMANDA = 0
            FEV_PARTICIPACAO_DEMANDA = 0
            MAR_PARTICIPACAO_DEMANDA = 0
            ABR_PARTICIPACAO_DEMANDA = 0
            MAI_PARTICIPACAO_DEMANDA = 0
            JUN_PARTICIPACAO_DEMANDA = 0
            JUL_PARTICIPACAO_DEMANDA = 0
            AGO_PARTICIPACAO_DEMANDA = 0
            SET_PARTICIPACAO_DEMANDA = 0
            OUT_PARTICIPACAO_DEMANDA = 0
            NOV_PARTICIPACAO_DEMANDA = 0
            DEZ_PARTICIPACAO_DEMANDA = 0
            TRI01_PARTICIPACAO_DEMANDA = 0
            TRI02_PARTICIPACAO_DEMANDA = 0
            TRI03_PARTICIPACAO_DEMANDA = 0
            TRI04_PARTICIPACAO_DEMANDA = 0
            TOTAL_PARTICIPACAO_DEMANDA = 0
            YTD_PARTICIPACAO_DEMANDA = 0

            If JAN_DEMANDA_TOTAL <> 0 Then JAN_PARTICIPACAO_DEMANDA = Round((JAN_DEMANDA / JAN_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If FEV_DEMANDA_TOTAL <> 0 Then FEV_PARTICIPACAO_DEMANDA = Round((FEV_DEMANDA / FEV_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If MAR_DEMANDA_TOTAL <> 0 Then MAR_PARTICIPACAO_DEMANDA = Round((MAR_DEMANDA / MAR_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If ABR_DEMANDA_TOTAL <> 0 Then ABR_PARTICIPACAO_DEMANDA = Round((ABR_DEMANDA / ABR_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If MAI_DEMANDA_TOTAL <> 0 Then MAI_PARTICIPACAO_DEMANDA = Round((MAI_DEMANDA / MAI_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If JUN_DEMANDA_TOTAL <> 0 Then JUN_PARTICIPACAO_DEMANDA = Round((JUN_DEMANDA / JUN_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If JUL_DEMANDA_TOTAL <> 0 Then JUL_PARTICIPACAO_DEMANDA = Round((JUL_DEMANDA / JUL_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If AGO_DEMANDA_TOTAL <> 0 Then AGO_PARTICIPACAO_DEMANDA = Round((AGO_DEMANDA / AGO_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If SET_DEMANDA_TOTAL <> 0 Then SET_PARTICIPACAO_DEMANDA = Round((SET_DEMANDA / SET_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If OUT_DEMANDA_TOTAL <> 0 Then OUT_PARTICIPACAO_DEMANDA = Round((OUT_DEMANDA / OUT_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If NOV_DEMANDA_TOTAL <> 0 Then NOV_PARTICIPACAO_DEMANDA = Round((NOV_DEMANDA / NOV_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If DEZ_DEMANDA_TOTAL <> 0 Then DEZ_PARTICIPACAO_DEMANDA = Round((DEZ_DEMANDA / DEZ_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If YTD_DEMANDA_TOTAL <> 0 Then YTD_PARTICIPACAO_DEMANDA = Round((YTD_DEMANDA / YTD_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If TOTAL_DEMANDA_TOTAL <> 0 Then TOTAL_PARTICIPACAO_DEMANDA = Round((TOTAL_DEMANDA / TOTAL_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)

            'LINHA Perfomance
            rw = New TableRow
            tbl_Report.Rows.Add(rw)

            'CELULA TIPO
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "Participação na Demanda % "
            cel.HorizontalAlign = HorizontalAlign.Center


            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(JAN_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(FEV_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(MAR_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(ABR_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(MAI_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(JUN_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(JUL_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(AGO_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(SET_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(OUT_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(NOV_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(DEZ_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(YTD_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(TOTAL_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = ""
            cel.HorizontalAlign = HorizontalAlign.Center

        Loop
        dtr.Close()
        dtr_Dst.Close()

        JAN_PARTICIPACAO_DEMANDA = 0
        FEV_PARTICIPACAO_DEMANDA = 0
        MAR_PARTICIPACAO_DEMANDA = 0
        ABR_PARTICIPACAO_DEMANDA = 0
        MAI_PARTICIPACAO_DEMANDA = 0
        JUN_PARTICIPACAO_DEMANDA = 0
        JUL_PARTICIPACAO_DEMANDA = 0
        AGO_PARTICIPACAO_DEMANDA = 0
        SET_PARTICIPACAO_DEMANDA = 0
        OUT_PARTICIPACAO_DEMANDA = 0
        NOV_PARTICIPACAO_DEMANDA = 0
        DEZ_PARTICIPACAO_DEMANDA = 0
        TRI01_PARTICIPACAO_DEMANDA = 0
        TRI02_PARTICIPACAO_DEMANDA = 0
        TRI03_PARTICIPACAO_DEMANDA = 0
        TRI04_PARTICIPACAO_DEMANDA = 0
        TOTAL_PARTICIPACAO_DEMANDA = 0
        YTD_PARTICIPACAO_DEMANDA = 0
        ' ----------------------------------------------------Distribuidores -------------------------------------------------------------------------------------------------------------------

        'Recupera GRUPOS_DISTRIBUIDORES

        sql_Dst = "SELECT DISTINCT GRUPO FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_TOTAL WHERE ANO = " & ANO & " AND GRUPO <> '01 - Hospira' AND GRUPO <> 'Venda Direta' ORDER BY GRUPO "
        cmd_Dst.Connection = cnn_Dst
        cmd_Dst.CommandText = sql_Dst
        dtr_Dst = cmd_Dst.ExecuteReader
    
        GRUPO_DISTRIBUIDOR = ""
        Do While dtr_Dst.Read
            GRUPO_DISTRIBUIDOR = ""
            GRUPO_DISTRIBUIDOR = dtr_Dst("GRUPO")
            ' ----------------------------------------------------Monta Cabeçalho - Distribuidores -------------------------------------------------------------------------------------------------------------------
            'LINHA VAZIA
            rw = New TableRow
            tbl_Report.Rows.Add(rw)
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "."
            cel.ColumnSpan = 14
            cel.ForeColor = Drawing.Color.White
            cel.BorderStyle = BorderStyle.None

            'LINHA CABECALHO
            rw = New TableRow
            tbl_Report.Rows.Add(rw)
            Dim link As New HyperLink
            link.Text = GRUPO_DISTRIBUIDOR
            link.NavigateUrl = "rpt_Estoque_Distribuidor_Produto_Sugestao.aspx?ANO=" & ANO & "&GRUPO=" & GRUPO_DISTRIBUIDOR & "&LINHA=" & LINHA_PRODUTO
            'COLUNA NOME DO GRUPO DISTRIBUIDOR
            cel = New TableCell
            cel.Controls.Add(link)
            rw.Cells.Add(cel)
            cel.Font.Bold = True
            cel.HorizontalAlign = HorizontalAlign.Left
            cel.BackColor = Drawing.Color.WhiteSmoke

            'COLUNAS MESES
            sql = "SELECT MES_SIGLA FROM TBL_DATAS_MESES WHERE MES_NUMERO_VALOR > 0 ORDER BY MES_NUMERO_VALOR"
            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader

            Do While dtr.Read
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = dtr("MES_SIGLA")
                cel.Font.Bold = False
                cel.HorizontalAlign = HorizontalAlign.Center
                cel.BackColor = Drawing.Color.WhiteSmoke
            Loop
            dtr.Close()

            'COLUNA YTD
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "YTD"
            cel.Font.Bold = False
            cel.HorizontalAlign = HorizontalAlign.Center
            cel.BackColor = Drawing.Color.WhiteSmoke

            'COLUNA TOTAL
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "Total"
            cel.Font.Bold = False
            cel.HorizontalAlign = HorizontalAlign.Center
            cel.BackColor = Drawing.Color.WhiteSmoke

            'COLUNA YTD
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "Média YTD"
            cel.Font.Bold = False
            cel.HorizontalAlign = HorizontalAlign.Center
            cel.BackColor = Drawing.Color.WhiteSmoke

            ' ----------------------------------------------------Venda - Distribuidores -------------------------------------------------------------------------------------------------------------------

            'LINHA VENDAS
            rw = New TableRow
            tbl_Report.Rows.Add(rw)

            'CELULA TIPO
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "Venda "
            cel.HorizontalAlign = HorizontalAlign.Center

            'RECUPERA VENDAS
            sql = ""
            sql = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_TOTAL WHERE GRUPO = '" & GRUPO_DISTRIBUIDOR & "' AND TIPO = '01 VENDA' AND ANO = " & ANO & " AND LINHA = '" & LINHA_PRODUTO & "'"

            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader
            dtr.Read()
            If dtr.HasRows Then
                'CELULA JAN
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("JAN"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                JAN_VENDA = FormatNumber(dtr("JAN"), 0)
                'CELULA FEV
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("FEV"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                FEV_VENDA = FormatNumber(dtr("FEV"), 0)
                'CELULA MAR
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("MAR"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                MAR_VENDA = FormatNumber(dtr("MAR"), 0)
                'CELULA ABR
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("ABR"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                ABR_VENDA = FormatNumber(dtr("ABR"), 0)
                'CELULA MAI
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("MAI"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                MAI_VENDA = FormatNumber(dtr("MAI"), 0)
                'CELULA JUN
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("JUN"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                JUN_VENDA = FormatNumber(dtr("JUN"), 0)


                'CELULA JUL
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("JUL"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                JUL_VENDA = FormatNumber(dtr("JUL"), 0)
                'CELULA AGO
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("AGO"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                AGO_VENDA = FormatNumber(dtr("AGO"), 0)
                'CELULA SET
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("SET"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                SET_VENDA = FormatNumber(dtr("SET"), 0)
                'CELULA OUT
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("OUT"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                OUT_VENDA = FormatNumber(dtr("OUT"), 0)
                'CELULA NOV
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("NOV"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                NOV_VENDA = FormatNumber(dtr("NOV"), 0)
                'CELULA DEZ
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("DEZ"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                DEZ_VENDA = FormatNumber(dtr("DEZ"), 0)

                'CELULA YTD
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("YTD"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                YTD_VENDA = FormatNumber(dtr("YTD"), 0)

                'CELULA TOTAL
                cel = New TableCell
                rw.Cells.Add(cel)
                TOTAL_VENDA = JAN_VENDA + FEV_VENDA + MAR_VENDA + ABR_VENDA + MAI_VENDA + JUN_VENDA + JUL_VENDA + AGO_VENDA + SET_VENDA + OUT_VENDA + NOV_VENDA + DEZ_VENDA
                cel.Text = FormatNumber(TOTAL_VENDA, 0)
                cel.HorizontalAlign = HorizontalAlign.Center

                'CELULA MEDIA
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("MEDIA_YTD"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                YTD_VENDA_MEDIA = FormatNumber(dtr("MEDIA_YTD"), 0)
            Else
                For X = 1 To 15
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                Next
                JAN_VENDA = 0
                FEV_VENDA = 0
                MAR_VENDA = 0
                ABR_VENDA = 0
                MAI_VENDA = 0
                JUN_VENDA = 0
                JUL_VENDA = 0
                AGO_VENDA = 0
                SET_VENDA = 0
                OUT_VENDA = 0
                NOV_VENDA = 0
                DEZ_VENDA = 0
                YTD_VENDA = 0
                YTD_VENDA_MEDIA = 0
                TOTAL_VENDA = 0
            End If
            dtr.Close()

            ' ----------------------------------------------------Participação Venda - Distribuirores -------------------------------------------------------------------------------------------------------------------

            JAN_PARTICIPACAO_VENDA = 0
            FEV_PARTICIPACAO_VENDA = 0
            MAR_PARTICIPACAO_VENDA = 0
            ABR_PARTICIPACAO_VENDA = 0
            MAI_PARTICIPACAO_VENDA = 0
            JUN_PARTICIPACAO_VENDA = 0
            JUL_PARTICIPACAO_VENDA = 0
            AGO_PARTICIPACAO_VENDA = 0
            SET_PARTICIPACAO_VENDA = 0
            OUT_PARTICIPACAO_VENDA = 0
            NOV_PARTICIPACAO_VENDA = 0
            DEZ_PARTICIPACAO_VENDA = 0
            TRI01_PARTICIPACAO_VENDA = 0
            TRI02_PARTICIPACAO_VENDA = 0
            TRI03_PARTICIPACAO_VENDA = 0
            TRI04_PARTICIPACAO_VENDA = 0
            TOTAL_PARTICIPACAO_VENDA = 0
            YTD_PARTICIPACAO_VENDA = 0

            If JAN_VENDA_TOTAL <> 0 Then JAN_PARTICIPACAO_VENDA = Round((JAN_VENDA / JAN_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If FEV_VENDA_TOTAL <> 0 Then FEV_PARTICIPACAO_VENDA = Round((FEV_VENDA / FEV_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If MAR_VENDA_TOTAL <> 0 Then MAR_PARTICIPACAO_VENDA = Round((MAR_VENDA / MAR_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If ABR_VENDA_TOTAL <> 0 Then ABR_PARTICIPACAO_VENDA = Round((ABR_VENDA / ABR_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If MAI_VENDA_TOTAL <> 0 Then MAI_PARTICIPACAO_VENDA = Round((MAI_VENDA / MAI_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If JUN_VENDA_TOTAL <> 0 Then JUN_PARTICIPACAO_VENDA = Round((JUN_VENDA / JUN_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If JUL_VENDA_TOTAL <> 0 Then JUL_PARTICIPACAO_VENDA = Round((JUL_VENDA / JUL_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If AGO_VENDA_TOTAL <> 0 Then AGO_PARTICIPACAO_VENDA = Round((AGO_VENDA / AGO_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If SET_VENDA_TOTAL <> 0 Then SET_PARTICIPACAO_VENDA = Round((SET_VENDA / SET_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If OUT_VENDA_TOTAL <> 0 Then OUT_PARTICIPACAO_VENDA = Round((OUT_VENDA / OUT_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If NOV_VENDA_TOTAL <> 0 Then NOV_PARTICIPACAO_VENDA = Round((NOV_VENDA / NOV_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If DEZ_VENDA_TOTAL <> 0 Then DEZ_PARTICIPACAO_VENDA = Round((DEZ_VENDA / DEZ_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If YTD_VENDA_TOTAL <> 0 Then YTD_PARTICIPACAO_VENDA = Round((YTD_VENDA / YTD_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If TOTAL_VENDA_TOTAL <> 0 Then TOTAL_PARTICIPACAO_VENDA = Round((TOTAL_VENDA / TOTAL_VENDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)

            'LINHA Perfomance
            rw = New TableRow
            tbl_Report.Rows.Add(rw)

            'CELULA TIPO
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "Participação na Venda % "
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center


            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(JAN_PARTICIPACAO_VENDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(FEV_PARTICIPACAO_VENDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(MAR_PARTICIPACAO_VENDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(ABR_PARTICIPACAO_VENDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(MAI_PARTICIPACAO_VENDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(JUN_PARTICIPACAO_VENDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(JUL_PARTICIPACAO_VENDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(AGO_PARTICIPACAO_VENDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(SET_PARTICIPACAO_VENDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(OUT_PARTICIPACAO_VENDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(NOV_PARTICIPACAO_VENDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(DEZ_PARTICIPACAO_VENDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(YTD_PARTICIPACAO_VENDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(TOTAL_PARTICIPACAO_VENDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = ""
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center



            ' ----------------------------------------------------Demanda - Distribuidores -------------------------------------------------------------------------------------------------------------------

            'LINHA DEMANDA 
            rw = New TableRow
            tbl_Report.Rows.Add(rw)

            'CELULA TIPO
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "Demanda "
            cel.HorizontalAlign = HorizontalAlign.Center

            'RECUPERA DEMANDA
            sql = ""
            sql = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_TOTAL WHERE GRUPO = '" & GRUPO_DISTRIBUIDOR & "' AND TIPO = '02 DEMANDA' AND ANO = " & ANO & " AND LINHA = '" & LINHA_PRODUTO & "'"

            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader
            dtr.Read()
            If dtr.HasRows Then
                'CELULA JAN
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("JAN"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                JAN_DEMANDA = FormatNumber(dtr("JAN"), 0)
                'CELULA FEV
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("FEV"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                FEV_DEMANDA = FormatNumber(dtr("FEV"), 0)
                'CELULA MAR
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("MAR"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                MAR_DEMANDA = FormatNumber(dtr("MAR"), 0)
                'CELULA ABR
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("ABR"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                ABR_DEMANDA = FormatNumber(dtr("ABR"), 0)
                'CELULA MAI
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("MAI"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                MAI_DEMANDA = FormatNumber(dtr("MAI"), 0)
                'CELULA JUN
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("JUN"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                JUN_DEMANDA = FormatNumber(dtr("JUN"), 0)
                'CELULA JUL
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("JUL"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                JUL_DEMANDA = FormatNumber(dtr("JUL"), 0)
                'CELULA AGO
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("AGO"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                AGO_DEMANDA = FormatNumber(dtr("AGO"), 0)
                'CELULA SET
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("SET"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                SET_DEMANDA = FormatNumber(dtr("SET"), 0)
                'CELULA OUT
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("OUT"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                OUT_DEMANDA = FormatNumber(dtr("OUT"), 0)
                'CELULA NOV
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("NOV"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                NOV_DEMANDA = FormatNumber(dtr("NOV"), 0)
                'CELULA DEZ
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("DEZ"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                DEZ_DEMANDA = FormatNumber(dtr("DEZ"), 0)
                'CELULA YTD
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("YTD"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                YTD_DEMANDA = FormatNumber(dtr("YTD"), 0)

                'CELULA TOTAL
                cel = New TableCell
                rw.Cells.Add(cel)
                TOTAL_DEMANDA = JAN_DEMANDA + FEV_DEMANDA + MAR_DEMANDA + ABR_DEMANDA + MAI_DEMANDA + JUN_DEMANDA + JUL_DEMANDA + AGO_DEMANDA + SET_DEMANDA + OUT_DEMANDA + NOV_DEMANDA + DEZ_DEMANDA
                cel.Text = FormatNumber(TOTAL_DEMANDA, 0)
                cel.HorizontalAlign = HorizontalAlign.Center

                'CELULA MEDIA
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("MEDIA_YTD"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                YTD_DEMANDA_MEDIA = FormatNumber(dtr("MEDIA_YTD"), 0)
            Else
                For X = 1 To 15
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                Next
                JAN_DEMANDA = 0
                FEV_DEMANDA = 0
                MAR_DEMANDA = 0
                ABR_DEMANDA = 0
                MAI_DEMANDA = 0
                JUN_DEMANDA = 0
                JUL_DEMANDA = 0
                AGO_DEMANDA = 0
                SET_DEMANDA = 0
                OUT_DEMANDA = 0
                NOV_DEMANDA = 0
                DEZ_DEMANDA = 0
                YTD_DEMANDA = 0
                YTD_DEMANDA_MEDIA = 0
                TOTAL_DEMANDA = 0
            End If
            dtr.Close()

            ' ----------------------------------------------------Participação DEMANDA - Hospira -------------------------------------------------------------------------------------------------------------------

            JAN_PARTICIPACAO_DEMANDA = 0
            FEV_PARTICIPACAO_DEMANDA = 0
            MAR_PARTICIPACAO_DEMANDA = 0
            ABR_PARTICIPACAO_DEMANDA = 0
            MAI_PARTICIPACAO_DEMANDA = 0
            JUN_PARTICIPACAO_DEMANDA = 0
            JUL_PARTICIPACAO_DEMANDA = 0
            AGO_PARTICIPACAO_DEMANDA = 0
            SET_PARTICIPACAO_DEMANDA = 0
            OUT_PARTICIPACAO_DEMANDA = 0
            NOV_PARTICIPACAO_DEMANDA = 0
            DEZ_PARTICIPACAO_DEMANDA = 0
            TRI01_PARTICIPACAO_DEMANDA = 0
            TRI02_PARTICIPACAO_DEMANDA = 0
            TRI03_PARTICIPACAO_DEMANDA = 0
            TRI04_PARTICIPACAO_DEMANDA = 0
            TOTAL_PARTICIPACAO_DEMANDA = 0
            YTD_PARTICIPACAO_DEMANDA = 0

            If JAN_DEMANDA_TOTAL <> 0 Then JAN_PARTICIPACAO_DEMANDA = Round((JAN_DEMANDA / JAN_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If FEV_DEMANDA_TOTAL <> 0 Then FEV_PARTICIPACAO_DEMANDA = Round((FEV_DEMANDA / FEV_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If MAR_DEMANDA_TOTAL <> 0 Then MAR_PARTICIPACAO_DEMANDA = Round((MAR_DEMANDA / MAR_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If ABR_DEMANDA_TOTAL <> 0 Then ABR_PARTICIPACAO_DEMANDA = Round((ABR_DEMANDA / ABR_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If MAI_DEMANDA_TOTAL <> 0 Then MAI_PARTICIPACAO_DEMANDA = Round((MAI_DEMANDA / MAI_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If JUN_DEMANDA_TOTAL <> 0 Then JUN_PARTICIPACAO_DEMANDA = Round((JUN_DEMANDA / JUN_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If JUL_DEMANDA_TOTAL <> 0 Then JUL_PARTICIPACAO_DEMANDA = Round((JUL_DEMANDA / JUL_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If AGO_DEMANDA_TOTAL <> 0 Then AGO_PARTICIPACAO_DEMANDA = Round((AGO_DEMANDA / AGO_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If SET_DEMANDA_TOTAL <> 0 Then SET_PARTICIPACAO_DEMANDA = Round((SET_DEMANDA / SET_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If OUT_DEMANDA_TOTAL <> 0 Then OUT_PARTICIPACAO_DEMANDA = Round((OUT_DEMANDA / OUT_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If NOV_DEMANDA_TOTAL <> 0 Then NOV_PARTICIPACAO_DEMANDA = Round((NOV_DEMANDA / NOV_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If DEZ_DEMANDA_TOTAL <> 0 Then DEZ_PARTICIPACAO_DEMANDA = Round((DEZ_DEMANDA / DEZ_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If YTD_DEMANDA_TOTAL <> 0 Then YTD_PARTICIPACAO_DEMANDA = Round((YTD_DEMANDA / YTD_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)
            If TOTAL_DEMANDA_TOTAL <> 0 Then TOTAL_PARTICIPACAO_DEMANDA = Round((TOTAL_DEMANDA / TOTAL_DEMANDA_TOTAL) * 100, 2, MidpointRounding.AwayFromZero)

            'LINHA Perfomance
            rw = New TableRow
            tbl_Report.Rows.Add(rw)

            'CELULA TIPO
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "Participação na Demanda % "
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center


            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(JAN_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(FEV_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(MAR_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(ABR_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(MAI_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(JUN_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(JUL_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(AGO_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(SET_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(OUT_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(NOV_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(DEZ_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(YTD_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = FormatNumber(TOTAL_PARTICIPACAO_DEMANDA, 2) & " %"
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = ""
            cel.Font.Size = 10
            cel.HorizontalAlign = HorizontalAlign.Center

            dtr.Close()


            ' ----------------------------------------------------Estoque Calculado - Distribuidores -------------------------------------------------------------------------------------------------------------------

            'LINHA ESTOQUE 
            rw = New TableRow
            tbl_Report.Rows.Add(rw)

            'CELULA TIPO
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "Estoque Calculado"
            cel.HorizontalAlign = HorizontalAlign.Center

            'RECUPERA ESTOQUE INICIAL DO ANO
            sql = ""
            sql = "SELECT * FROM TBL_MOVIMENTO_ESTOQUE_INICIAL WHERE GRUPO_DISTRIBUIDOR = '" & GRUPO_DISTRIBUIDOR & "' AND TIPO = '03 ESTOQUE' AND ANO = " & ANO & " AND LINHA = '" & LINHA_PRODUTO & "'"

            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader
            dtr.Read()
            If dtr.HasRows Then
                ESTOQUE_INICIAL = 0
                ESTOQUE_INICIAL = FormatNumber(dtr("QTD"), 0)
            End If
            dtr.Close()

            'RECUPERA ESTOQUE 

            'SELECIONA O ANO MANUALMENTE PARA PODER TRAZER DISTRIBUIDORES SEM ESTOQUE INFORMADO NO ANO ATUAL
            If ANO = 2015 Then
                sql = ""
                sql = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_TOTAL WHERE GRUPO = '" & GRUPO_DISTRIBUIDOR & "' AND TIPO = '03 ESTOQUE' AND ANO = " & ANO & " AND LINHA = '" & LINHA_PRODUTO & "'"
            Else
                sql = ""
                sql = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_TOTAL WHERE GRUPO = '" & GRUPO_DISTRIBUIDOR & "' AND TIPO = '03 ESTOQUE' AND ANO = " & ANO & " OR ANO = 2015 AND LINHA = '" & LINHA_PRODUTO & "'"
            End If

            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader
            dtr.Read()
            If dtr.HasRows Then
                If ANO = 2015 Then
                    'CELULA JAN
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.WhiteSmoke
                    JAN_ESTOQUE = FormatNumber(dtr("JAN"), 0)
                    'CELULA FEV
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.WhiteSmoke
                    FEV_ESTOQUE = FormatNumber(dtr("FEV"), 0)
                    'CELULA MAR
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    MAR_ESTOQUE = FEV_ESTOQUE + MAR_VENDA - MAR_DEMANDA
                    cel.Text = FormatNumber(MAR_ESTOQUE, 0)

                    'CELULA ABR
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    ABR_ESTOQUE = MAR_ESTOQUE + ABR_VENDA - ABR_DEMANDA
                    cel.Text = FormatNumber(ABR_ESTOQUE, 0)

                    'CELULA MAI
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    MAI_ESTOQUE = ABR_ESTOQUE + MAI_VENDA - MAI_DEMANDA
                    cel.Text = FormatNumber(MAI_ESTOQUE, 0)

                    'CELULA JUN
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    JUN_ESTOQUE = MAI_ESTOQUE + JUN_VENDA - JUN_DEMANDA
                    cel.Text = FormatNumber(JUN_ESTOQUE, 0)

                    'CELULA JUL
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    JUL_ESTOQUE = JUN_ESTOQUE + JUL_VENDA - JUL_DEMANDA
                    cel.Text = FormatNumber(JUL_ESTOQUE, 0)

                    'CELULA AGO
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    AGO_ESTOQUE = JUL_ESTOQUE + AGO_VENDA - AGO_DEMANDA
                    cel.Text = FormatNumber(AGO_ESTOQUE, 0)

                    'CELULA SET
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    SET_ESTOQUE = AGO_ESTOQUE + SET_VENDA - SET_DEMANDA
                    cel.Text = FormatNumber(SET_ESTOQUE, 0)

                    'CELULA OUT
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    OUT_ESTOQUE = SET_ESTOQUE + OUT_VENDA - OUT_DEMANDA
                    cel.Text = FormatNumber(OUT_ESTOQUE, 0)

                    'CELULA NOV
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    NOV_ESTOQUE = OUT_ESTOQUE + NOV_VENDA - NOV_DEMANDA
                    cel.Text = FormatNumber(NOV_ESTOQUE, 0)

                    'CELULA DEZ
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    DEZ_ESTOQUE = NOV_ESTOQUE + DEZ_VENDA - DEZ_DEMANDA
                    cel.Text = FormatNumber(DEZ_ESTOQUE, 0)

                ElseIf ANO < 2015 Then

                    'CELULA JAN
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.WhiteSmoke
                    JAN_ESTOQUE = FormatNumber(dtr("JAN"), 0)
                    'CELULA FEV
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.WhiteSmoke
                    FEV_ESTOQUE = FormatNumber(dtr("FEV"), 0)
                    'CELULA MAR
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.WhiteSmoke
                    MAR_ESTOQUE = FormatNumber(dtr("MAR"), 0)
                    'CELULA ABR
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.WhiteSmoke
                    ABR_ESTOQUE = FormatNumber(dtr("ABR"), 0)

                    'CELULA MAI
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.WhiteSmoke
                    MAI_ESTOQUE = FormatNumber(dtr("MAI"), 0)

                    'CELULA JUN
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.WhiteSmoke
                    JUN_ESTOQUE = FormatNumber(dtr("JUN"), 0)

                    'CELULA JUL
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.WhiteSmoke
                    JUL_ESTOQUE = FormatNumber(dtr("JUL"), 0)

                    'CELULA AGO
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.WhiteSmoke
                    AGO_ESTOQUE = FormatNumber(dtr("AGO"), 0)

                    'CELULA SET
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.WhiteSmoke
                    SET_ESTOQUE = FormatNumber(dtr("SET"), 0)

                    'CELULA OUT
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.WhiteSmoke
                    OUT_ESTOQUE = FormatNumber(dtr("OUT"), 0)

                    'CELULA NOV
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.WhiteSmoke
                    NOV_ESTOQUE = FormatNumber(dtr("NOV"), 0)

                    'CELULA DEZ
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.WhiteSmoke
                    DEZ_ESTOQUE = FormatNumber(dtr("DEZ"), 0)
                Else

                    'CELULA JAN
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    'cel.Text = FormatNumber(dtr("JAN"), 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    'JAN_ESTOQUE = FormatNumber(dtr("JAN"), 0)
                    JAN_ESTOQUE = ESTOQUE_INICIAL + JAN_VENDA - JAN_DEMANDA
                    cel.Text = FormatNumber(JAN_ESTOQUE, 0)

                    'CELULA FEV
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    'cel.Text = FormatNumber(dtr("FEV"), 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    'FEV_ESTOQUE = FormatNumber(dtr("FEV"), 0)
                    FEV_ESTOQUE = JAN_ESTOQUE + FEV_VENDA - FEV_DEMANDA
                    cel.Text = FormatNumber(FEV_ESTOQUE, 0)

                    'CELULA MAR
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    'cel.Text = FormatNumber(dtr("MAR"), 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    'MAR_ESTOQUE = FormatNumber(dtr("MAR"), 0)
                    MAR_ESTOQUE = FEV_ESTOQUE + MAR_VENDA - MAR_DEMANDA
                    cel.Text = FormatNumber(MAR_ESTOQUE, 0)

                    'CELULA ABR
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    'cel.Text = FormatNumber(dtr("ABR"), 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    'ABR_ESTOQUE = FormatNumber(dtr("ABR"), 0)
                    ABR_ESTOQUE = MAR_ESTOQUE + ABR_VENDA - ABR_DEMANDA
                    cel.Text = FormatNumber(ABR_ESTOQUE, 0)

                    'CELULA MAI
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    'cel.Text = FormatNumber(dtr("MAI"), 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    'MAI_ESTOQUE = FormatNumber(dtr("MAI"), 0)
                    MAI_ESTOQUE = ABR_ESTOQUE + MAI_VENDA - MAI_DEMANDA
                    cel.Text = FormatNumber(MAI_ESTOQUE, 0)

                    'CELULA JUN
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    'cel.Text = FormatNumber(dtr("JUN"), 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    'JUN_ESTOQUE = FormatNumber(dtr("JUN"), 0)
                    JUN_ESTOQUE = MAI_ESTOQUE + JUN_VENDA - JUN_DEMANDA
                    cel.Text = FormatNumber(JUN_ESTOQUE, 0)

                    'CELULA JUL
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    'cel.Text = FormatNumber(dtr("JUL"), 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    'JUL_ESTOQUE = FormatNumber(dtr("JUL"), 0)
                    JUL_ESTOQUE = JUN_ESTOQUE + JUL_VENDA - JUL_DEMANDA
                    cel.Text = FormatNumber(JUL_ESTOQUE, 0)

                    'CELULA AGO
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    'cel.Text = FormatNumber(dtr("AGO"), 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    'AGO_ESTOQUE = FormatNumber(dtr("AGO"), 0)
                    AGO_ESTOQUE = JUL_ESTOQUE + AGO_VENDA - AGO_DEMANDA
                    cel.Text = FormatNumber(AGO_ESTOQUE, 0)

                    'CELULA SET
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    'cel.Text = FormatNumber(dtr("SET"), 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    'SET_ESTOQUE = FormatNumber(dtr("SET"), 0)
                    SET_ESTOQUE = AGO_ESTOQUE + SET_VENDA - SET_DEMANDA
                    cel.Text = FormatNumber(SET_ESTOQUE, 0)

                    'CELULA OUT
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    'cel.Text = FormatNumber(dtr("OUT"), 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    'OUT_ESTOQUE = FormatNumber(dtr("OUT"), 0)
                    OUT_ESTOQUE = SET_ESTOQUE + OUT_VENDA - OUT_DEMANDA
                    cel.Text = FormatNumber(OUT_ESTOQUE, 0)

                    'CELULA NOV
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    'cel.Text = FormatNumber(dtr("NOV"), 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    'NOV_ESTOQUE = FormatNumber(dtr("NOV"), 0)
                    NOV_ESTOQUE = OUT_ESTOQUE + NOV_VENDA - NOV_DEMANDA
                    cel.Text = FormatNumber(NOV_ESTOQUE, 0)

                    'CELULA DEZ
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    'cel.Text = FormatNumber(dtr("DEZ"), 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    'DEZ_ESTOQUE = FormatNumber(dtr("DEZ"), 0)
                    DEZ_ESTOQUE = NOV_ESTOQUE + DEZ_VENDA - DEZ_DEMANDA
                    cel.Text = FormatNumber(DEZ_ESTOQUE, 0)

                    'CELULA TOTAL
                    'cel = New TableCell
                    'rw.Cells.Add(cel)
                    ''cel.Text = FormatNumber(dtr("TOTAL"), 0)
                    'cel.BackColor = Drawing.Color.LightGray
                    'cel.HorizontalAlign = HorizontalAlign.Center

                End If


            Else
                For X = 1 To 12
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                Next
                JAN_ESTOQUE = 0
                FEV_ESTOQUE = 0
                MAR_ESTOQUE = 0
                ABR_ESTOQUE = 0
                MAI_ESTOQUE = 0
                JUN_ESTOQUE = 0
                JUL_ESTOQUE = 0
                AGO_ESTOQUE = 0
                SET_ESTOQUE = 0
                OUT_ESTOQUE = 0
                NOV_ESTOQUE = 0
                DEZ_ESTOQUE = 0
                TOTAL_ESTOQUE = 0
            End If

            ' ----------------------------------------------------Estoque Informado - Distribuidores -------------------------------------------------------------------------------------------------------------------

            'LINHA ESTOQUE 
            rw = New TableRow
            tbl_Report.Rows.Add(rw)

            'CELULA TIPO
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "Estoque Informado"
            cel.HorizontalAlign = HorizontalAlign.Center

            If dtr.HasRows Then
                'CELULA JAN
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("JAN"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                cel.BackColor = Drawing.Color.White
                JAN_ESTOQUE = FormatNumber(dtr("JAN"), 0)
                'CELULA FEV
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("FEV"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                cel.BackColor = Drawing.Color.White
                FEV_ESTOQUE = FormatNumber(dtr("FEV"), 0)
                'CELULA MAR
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("MAR"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                cel.BackColor = Drawing.Color.White
                MAR_ESTOQUE = FormatNumber(dtr("MAR"), 0)
                'CELULA ABR
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("ABR"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                cel.BackColor = Drawing.Color.White
                ABR_ESTOQUE = FormatNumber(dtr("ABR"), 0)

                'CELULA MAI
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("MAI"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                cel.BackColor = Drawing.Color.White
                MAI_ESTOQUE = FormatNumber(dtr("MAI"), 0)

                'CELULA JUN
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("JUN"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                cel.BackColor = Drawing.Color.White
                JUN_ESTOQUE = FormatNumber(dtr("JUN"), 0)

                'CELULA JUL
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("JUL"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                cel.BackColor = Drawing.Color.White
                JUL_ESTOQUE = FormatNumber(dtr("JUL"), 0)

                'CELULA AGO
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("AGO"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                cel.BackColor = Drawing.Color.White
                AGO_ESTOQUE = FormatNumber(dtr("AGO"), 0)

                'CELULA SET
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("SET"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                cel.BackColor = Drawing.Color.White
                SET_ESTOQUE = FormatNumber(dtr("SET"), 0)

                'CELULA OUT
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("OUT"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                cel.BackColor = Drawing.Color.White
                OUT_ESTOQUE = FormatNumber(dtr("OUT"), 0)

                'CELULA NOV
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("NOV"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                cel.BackColor = Drawing.Color.White
                NOV_ESTOQUE = FormatNumber(dtr("NOV"), 0)

                'CELULA DEZ
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("DEZ"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                cel.BackColor = Drawing.Color.White
                DEZ_ESTOQUE = FormatNumber(dtr("DEZ"), 0)


                'CELULA TOTAL
                'cel = New TableCell
                'rw.Cells.Add(cel)
                ''cel.Text = FormatNumber(dtr("TOTAL"), 0)
                'cel.BackColor = Drawing.Color.LightGray
                'cel.HorizontalAlign = HorizontalAlign.Center

            Else
                For X = 1 To 12
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = 0
                    cel.HorizontalAlign = HorizontalAlign.Center
                Next
                JAN_ESTOQUE = 0
                FEV_ESTOQUE = 0
                MAR_ESTOQUE = 0
                ABR_ESTOQUE = 0
                MAI_ESTOQUE = 0
                JUN_ESTOQUE = 0
                JUL_ESTOQUE = 0
                AGO_ESTOQUE = 0
                SET_ESTOQUE = 0
                OUT_ESTOQUE = 0
                NOV_ESTOQUE = 0
                DEZ_ESTOQUE = 0
                TOTAL_ESTOQUE = 0
            End If
            dtr.Close()
        Loop

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