
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

    Public Sub Atualiza_Relatorio()
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
        Dim dtr_ESTABELECIMENTOS As System.Data.SqlClient.SqlDataReader
        Dim sql_ESTABELECIMENTOS As String



        Dim LINHA_PRODUTO As String
        Dim GRUPO_DISTRIBUIDOR As String
        Dim X As Integer
        Dim Y As Integer
        Dim ANO As Integer
        Dim rw As TableRow
        Dim cel As TableCell


        Dim JAN_ESTABELECIMENTOS As Integer
        Dim FEV_ESTABELECIMENTOS As Integer
        Dim MAR_ESTABELECIMENTOS As Integer
        Dim ABR_ESTABELECIMENTOS As Integer
        Dim MAI_ESTABELECIMENTOS As Integer
        Dim JUN_ESTABELECIMENTOS As Integer
        Dim JUL_ESTABELECIMENTOS As Integer
        Dim AGO_ESTABELECIMENTOS As Integer
        Dim SET_ESTABELECIMENTOS As Integer
        Dim OUT_ESTABELECIMENTOS As Integer
        Dim NOV_ESTABELECIMENTOS As Integer
        Dim DEZ_ESTABELECIMENTOS As Integer

        Dim JAN_DIAS As Integer
        Dim FEV_DIAS As Integer
        Dim MAR_DIAS As Integer
        Dim ABR_DIAS As Integer
        Dim MAI_DIAS As Integer
        Dim JUN_DIAS As Integer
        Dim JUL_DIAS As Integer
        Dim AGO_DIAS As Integer
        Dim SET_DIAS As Integer
        Dim OUT_DIAS As Integer
        Dim NOV_DIAS As Integer
        Dim DEZ_DIAS As Integer

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
        Dim TOTAL_DEMANDA As Integer

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
        cel.Text = "TOTAL"
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
            cel.Font.Bold = True
            cel.HorizontalAlign = HorizontalAlign.Center
        Loop
        dtr.Close()

        'COLUNA TOTAL
        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "TOTAL"
        cel.Font.Bold = True
        cel.HorizontalAlign = HorizontalAlign.Center
        cel.BackColor = Drawing.Color.Gainsboro


        'LINHA VENDAS
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        'CELULA TIPO
        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "VENDA "
        cel.HorizontalAlign = HorizontalAlign.Center

        'RECUPERA VENDAS
        sql = ""
        sql = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_TOTAL_GERAL WHERE TIPO = '01 VENDA' AND ANO = " & ANO & " AND LINHA = '" & LINHA_PRODUTO & "'"

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

            'CELULA TOTAL
            cel = New TableCell
            rw.Cells.Add(cel)
            TOTAL_VENDA = JAN_VENDA + FEV_VENDA + MAR_VENDA + ABR_VENDA + MAI_VENDA + JUN_VENDA + JUL_VENDA + AGO_VENDA + SET_VENDA + OUT_VENDA + NOV_VENDA + DEZ_VENDA
            cel.Text = FormatNumber(TOTAL_VENDA, 0)
            cel.HorizontalAlign = HorizontalAlign.Center
        Else
            For X = 1 To 13
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
            TOTAL_VENDA = 0
        End If
        dtr.Close()

        'LINHA DEMANDA 
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        'CELULA TIPO
        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "DEMANDA "
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
            'CELULA TOTAL
            cel = New TableCell
            rw.Cells.Add(cel)
            TOTAL_DEMANDA = JAN_DEMANDA + FEV_DEMANDA + MAR_DEMANDA + ABR_DEMANDA + MAI_DEMANDA + JUN_DEMANDA + JUL_DEMANDA + AGO_DEMANDA + SET_DEMANDA + OUT_DEMANDA + NOV_DEMANDA + DEZ_DEMANDA
            cel.Text = FormatNumber(TOTAL_DEMANDA, 0)
            cel.HorizontalAlign = HorizontalAlign.Center
        Else
            For X = 1 To 13
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
            TOTAL_DEMANDA = 0
        End If
        dtr.Close()


        'LINHA ESTOQUE 
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        'CELULA TIPO
        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "ESTOQUE "
        cel.HorizontalAlign = HorizontalAlign.Center

        'RECUPERA ESTOQUE INICIAL DO ANO
        sql = ""
        sql = "SELECT * FROM TBL_MOVIMENTO_ESTOQUE_INICIAL WHERE GRUPO_DISTRIBUIDOR = 'TOTAL' AND TIPO = '03 ESTOQUE' AND ANO = " & ANO & " AND LINHA = '" & LINHA_PRODUTO & "'"

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
        sql = ""
        sql = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_TOTAL_GERAL WHERE TIPO = '03 ESTOQUE' AND ANO = " & ANO & " AND LINHA = '" & LINHA_PRODUTO & "'"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If ANO = 2015 Then
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
                cel.BackColor = Drawing.Color.Lavender
                cel.ForeColor = Drawing.Color.DimGray
                'MAR_ESTOQUE = FormatNumber(dtr("MAR"), 0)
                MAR_ESTOQUE = FEV_ESTOQUE + MAR_VENDA - MAR_DEMANDA
                cel.Text = FormatNumber(MAR_ESTOQUE, 0)

                'CELULA ABR
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("ABR"), 0)
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
            ElseIf ANO < 2015 Then

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
            For X = 1 To 13
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

        'Recupera GRUPOS_DISTRIBUIDORES

        sql_Dst = "SELECT DISTINCT GRUPO FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_TOTAL WHERE ANO = " & ANO & " ORDER BY GRUPO "
        cmd_Dst.Connection = cnn_Dst
        cmd_Dst.CommandText = sql_Dst
        dtr_Dst = cmd_Dst.ExecuteReader

        GRUPO_DISTRIBUIDOR = ""
        Do While dtr_Dst.Read
            GRUPO_DISTRIBUIDOR = ""
            GRUPO_DISTRIBUIDOR = dtr_Dst("GRUPO")

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
                cel.Font.Bold = True
                cel.HorizontalAlign = HorizontalAlign.Center
                cel.BackColor = Drawing.Color.WhiteSmoke
            Loop
            dtr.Close()

            'COLUNA TOTAL
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "TOTAL"
            cel.Font.Bold = True
            cel.HorizontalAlign = HorizontalAlign.Center
            cel.BackColor = Drawing.Color.WhiteSmoke


            'LINHA VENDAS
            rw = New TableRow
            tbl_Report.Rows.Add(rw)

            'CELULA TIPO
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "VENDA "
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

                'CELULA TOTAL
                cel = New TableCell
                rw.Cells.Add(cel)
                TOTAL_VENDA = JAN_VENDA + FEV_VENDA + MAR_VENDA + ABR_VENDA + MAI_VENDA + JUN_VENDA + JUL_VENDA + AGO_VENDA + SET_VENDA + OUT_VENDA + NOV_VENDA + DEZ_VENDA
                cel.Text = FormatNumber(TOTAL_VENDA, 0)
                cel.HorizontalAlign = HorizontalAlign.Center
            Else
                For X = 1 To 13
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
                TOTAL_VENDA = 0
            End If
            dtr.Close()

            'LINHA DEMANDA 
            rw = New TableRow
            tbl_Report.Rows.Add(rw)

            'CELULA TIPO
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "DEMANDA "
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
                'CELULA TOTAL
                cel = New TableCell
                rw.Cells.Add(cel)
                TOTAL_DEMANDA = JAN_DEMANDA + FEV_DEMANDA + MAR_DEMANDA + ABR_DEMANDA + MAI_DEMANDA + JUN_DEMANDA + JUL_DEMANDA + AGO_DEMANDA + SET_DEMANDA + OUT_DEMANDA + NOV_DEMANDA + DEZ_DEMANDA
                cel.Text = FormatNumber(TOTAL_DEMANDA, 0)
                cel.HorizontalAlign = HorizontalAlign.Center
            Else
                For X = 1 To 13
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
                TOTAL_DEMANDA = 0
            End If
            dtr.Close()


            'LINHA ESTOQUE 
            rw = New TableRow
            tbl_Report.Rows.Add(rw)

            'CELULA TIPO
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "ESTOQUE "
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
                    cel.BackColor = Drawing.Color.Lavender
                    cel.ForeColor = Drawing.Color.DimGray
                    'MAR_ESTOQUE = FormatNumber(dtr("MAR"), 0)
                    MAR_ESTOQUE = FEV_ESTOQUE + MAR_VENDA - MAR_DEMANDA
                    cel.Text = FormatNumber(MAR_ESTOQUE, 0)

                    'CELULA ABR
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = FormatNumber(dtr("ABR"), 0)
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
                ElseIf ANO < 2015 Then

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
            dtr.Close()
        Loop
        '    'LINHA ESTOQUE 
        '    rw = New TableRow
        '    tbl_Report.Rows.Add(rw)

        '    'CELULA TIPO
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = "ESTOQUE "
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'ESTOQUE JAN
        '    If DEZ_ESTOQUE + JAN_VENDA - JAN_DEMANDA < 0 Then
        '        JAN_ESTOQUE = 0
        '    Else
        '        JAN_ESTOQUE = DEZ_ESTOQUE + JAN_VENDA - JAN_DEMANDA
        '    End If
        '    If JUL_DEMANDA = 0 Then
        '        JUL_DIAS = 0
        '    Else
        '        JUL_DIAS = JUL_ESTOQUE / (JUL_DEMANDA / 30)
        '    End If

        '    'DIAS AGO
        '    If AGO_DEMANDA = 0 Then
        '        AGO_DIAS = 0

        '    'ESTOQUE FEV
        '    If FEV_VENDA - FEV_DEMANDA + JAN_ESTOQUE < 0 Then
        '        FEV_ESTOQUE = 0
        '    Else
        '        FEV_ESTOQUE = FEV_VENDA - FEV_DEMANDA + JAN_ESTOQUE
        '    End If

        '    'ESTOQUE MAR
        '    If MAR_VENDA - MAR_DEMANDA + FEV_ESTOQUE < 0 Then
        '        MAR_ESTOQUE = 0
        '    Else
        '        MAR_ESTOQUE = MAR_VENDA - MAR_DEMANDA + FEV_ESTOQUE
        '    End If

        '    'ESTOQUE ABR
        '    If ABR_VENDA - ABR_DEMANDA + MAR_ESTOQUE < 0 Then
        '        ABR_ESTOQUE = 0
        '    Else
        '        ABR_ESTOQUE = ABR_VENDA - ABR_DEMANDA + MAR_ESTOQUE
        '    End If

        '    'ESTOQUE MAI
        '    If MAI_VENDA - MAI_DEMANDA + ABR_ESTOQUE < 0 Then
        '        MAI_ESTOQUE = 0
        '    Else
        '        MAI_ESTOQUE = MAI_VENDA - MAI_DEMANDA + ABR_ESTOQUE
        '    End If

        '    'ESTOQUE JUN
        '    If JUN_VENDA - JUN_DEMANDA + MAI_ESTOQUE < 0 Then
        '        JUN_ESTOQUE = 0
        '    Else
        '        JUN_ESTOQUE = JUN_VENDA - JUN_DEMANDA + MAI_ESTOQUE
        '    End If

        '    'ESTOQUE JUL
        '    If JUL_VENDA - JUL_DEMANDA + JUN_ESTOQUE < 0 Then
        '        JUL_ESTOQUE = 0
        '    Else
        '        JUL_ESTOQUE = JUL_VENDA - JUL_DEMANDA + JUN_ESTOQUE
        '    End If

        '    'ESTOQUE AGO
        '    If AGO_VENDA - AGO_DEMANDA + JUL_ESTOQUE < 0 Then
        '        AGO_ESTOQUE = 0
        '    Else
        '        AGO_ESTOQUE = AGO_VENDA - AGO_DEMANDA + JUL_ESTOQUE
        '    End If

        '    'ESTOQUE SET
        '    If SET_VENDA - SET_DEMANDA + AGO_ESTOQUE < 0 Then
        '        SET_ESTOQUE = 0
        '    Else
        '        SET_ESTOQUE = SET_VENDA - SET_DEMANDA + AGO_ESTOQUE
        '    End If

        '    'ESTOQUE OUT
        '    If OUT_VENDA - OUT_DEMANDA + SET_ESTOQUE < 0 Then
        '        OUT_ESTOQUE = 0
        '    Else
        '        OUT_ESTOQUE = OUT_VENDA - OUT_DEMANDA + SET_ESTOQUE
        '    End If

        '    'ESTOQUE NOV
        '    If NOV_VENDA - NOV_DEMANDA + OUT_ESTOQUE < 0 Then
        '        NOV_ESTOQUE = 0
        '    Else
        '        NOV_ESTOQUE = NOV_VENDA - NOV_DEMANDA + OUT_ESTOQUE
        '    End If

        '    'ESTOQUE DEZ
        '    If DEZ_VENDA - DEZ_DEMANDA + NOV_ESTOQUE < 0 Then
        '        DEZ_ESTOQUE = 0
        '    Else
        '        DEZ_ESTOQUE = DEZ_VENDA - DEZ_DEMANDA + NOV_ESTOQUE
        '    End If


        '    'CELULA JAN
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = JAN_ESTOQUE
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA FEV
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = FEV_ESTOQUE
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA MAR
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = MAR_ESTOQUE
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA ABR
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = ABR_ESTOQUE
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA MAI
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = MAI_ESTOQUE
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA JUN
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = JUN_ESTOQUE
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA JUL
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = JUL_ESTOQUE
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA AGO
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = AGO_ESTOQUE
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA SET
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = SET_ESTOQUE
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA OUT
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = OUT_ESTOQUE
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA NOV
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = NOV_ESTOQUE
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA DEZ
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = DEZ_ESTOQUE
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA TOTAL
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = " "
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    '--------------------------------------------------------------------------------------------------------------------------------------------
        '    'LINHA DIAS
        '    rw = New TableRow
        '    tbl_Report.Rows.Add(rw)

        '    'CELULA TIPO
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = "DIAS"
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'DIAS JAN
        '    If JAN_DEMANDA = 0 Then
        '        JAN_DIAS = 0
        '    Else
        '        JAN_DIAS = JAN_ESTOQUE / (JAN_DEMANDA / 30)
        '    End If

        '    'DIAS FEV
        '    If FEV_DEMANDA = 0 Then
        '        FEV_DIAS = 0
        '    Else
        '        FEV_DIAS = FEV_ESTOQUE / (FEV_DEMANDA / 30)
        '    End If

        '    'DIAS MAR
        '    If MAR_DEMANDA = 0 Then
        '        MAR_DIAS = 0
        '    Else
        '        MAR_DIAS = MAR_ESTOQUE / (MAR_DEMANDA / 30)
        '    End If

        '    'DIAS ABR
        '    If ABR_DEMANDA = 0 Then
        '        ABR_DIAS = 0
        '    Else
        '        ABR_DIAS = ABR_ESTOQUE / (ABR_DEMANDA / 30)
        '    End If

        '    'DIAS MAI
        '    If MAI_DEMANDA = 0 Then
        '        MAI_DIAS = 0
        '    Else
        '        MAI_DIAS = MAI_ESTOQUE / (MAI_DEMANDA / 30)
        '    End If

        '    'DIAS JUN
        '    If JUN_DEMANDA = 0 Then
        '        JUN_DIAS = 0
        '    Else
        '        JUN_DIAS = JUN_ESTOQUE / (JUN_DEMANDA / 30)
        '    End If

        '    'DIAS JUL
        '    Else
        '        AGO_DIAS = AGO_ESTOQUE / (AGO_DEMANDA / 30)
        '    End If

        '    'DIAS SET
        '    If SET_DEMANDA = 0 Then
        '        SET_DIAS = 0
        '    Else
        '        SET_DIAS = SET_ESTOQUE / (SET_DEMANDA / 30)
        '    End If

        '    'DIAS OUT
        '    If OUT_DEMANDA = 0 Then
        '        OUT_DIAS = 0
        '    Else
        '        OUT_DIAS = OUT_ESTOQUE / (OUT_DEMANDA / 30)
        '    End If

        '    'DIAS NOV
        '    If NOV_DEMANDA = 0 Then
        '        NOV_DIAS = 0
        '    Else
        '        NOV_DIAS = NOV_ESTOQUE / (NOV_DEMANDA / 30)
        '    End If

        '    'DIAS DEZ
        '    If DEZ_DEMANDA = 0 Then
        '        DEZ_DIAS = 0
        '    Else
        '        DEZ_DIAS = DEZ_ESTOQUE / (DEZ_DEMANDA / 30)
        '    End If


        '    'CELULA JAN
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = JAN_DIAS
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA FEV
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = FEV_DIAS
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA MAR
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = MAR_DIAS
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA ABR
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = ABR_DIAS
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA MAI
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = MAI_DIAS
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA JUN
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = JUN_DIAS
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA JUL
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = JUL_DIAS
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA AGO
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = AGO_DIAS
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA SET
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = SET_DIAS
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA OUT
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = OUT_DIAS
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA NOV
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = NOV_DIAS
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA DEZ
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = DEZ_DIAS
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'CELULA TOTAL
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = " "
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    '--------------------------------------------------------------------------------------------------------------------------------------------
        '    'LINHA QTD CLIENTES
        '    rw = New TableRow
        '    tbl_Report.Rows.Add(rw)

        '    'CELULA TIPO
        '    cel = New TableCell
        '    rw.Cells.Add(cel)
        '    cel.Text = "ESTABELECIMENTOS"
        '    cel.HorizontalAlign = HorizontalAlign.Center

        '    'RECUPERA QTD ESTABELECIMENTOS
        '    sql = ""
        '    sql = "SELECT * FROM VIEW_QTD_ESTABELECIMENTOS_DISTRIBUIDORES WHERE DISTRIBUIDOR = '" & cmb_GRUPO_DISTRIBUIDOR.Text & "' AND ANO = " & ANO & " AND LINHA = '" & cmb_LINHA.Text & "'"
        '    If cmb_GRUPO_DISTRIBUIDOR.Text = "01 - HOSPIRA" Then sql = "SELECT * FROM VIEW_QTD_ESTABELECIMENTOS_BRASIL WHERE ANO = " & ANO & " AND LINHA = '" & cmb_LINHA.Text & "'"
        '    cmd.Connection = cnn
        '    cmd.CommandText = sql
        '    dtr = cmd.ExecuteReader
        '    dtr.Read()
        '    If dtr.HasRows Then
        '        'CELULA JAN
        '        cel = New TableCell
        '        rw.Cells.Add(cel)
        '        cel.Text = dtr("JAN")
        '        cel.HorizontalAlign = HorizontalAlign.Center
        '        JAN_ESTABELECIMENTOS = dtr("JAN")
        '        'CELULA FEV
        '        cel = New TableCell
        '        rw.Cells.Add(cel)
        '        cel.Text = dtr("FEV")
        '        cel.HorizontalAlign = HorizontalAlign.Center
        '        FEV_ESTABELECIMENTOS = dtr("FEV")
        '        'CELULA MAR
        '        cel = New TableCell
        '        rw.Cells.Add(cel)
        '        cel.Text = dtr("MAR")
        '        cel.HorizontalAlign = HorizontalAlign.Center
        '        MAR_ESTABELECIMENTOS = dtr("MAR")
        '        'CELULA ABR
        '        cel = New TableCell
        '        rw.Cells.Add(cel)
        '        cel.Text = dtr("ABR")
        '        cel.HorizontalAlign = HorizontalAlign.Center
        '        ABR_ESTABELECIMENTOS = dtr("ABR")
        '        'CELULA MAI
        '        cel = New TableCell
        '        rw.Cells.Add(cel)
        '        cel.Text = dtr("MAI")
        '        cel.HorizontalAlign = HorizontalAlign.Center
        '        MAI_ESTABELECIMENTOS = dtr("MAI")
        '        'CELULA JUN
        '        cel = New TableCell
        '        rw.Cells.Add(cel)
        '        cel.Text = dtr("JUN")
        '        cel.HorizontalAlign = HorizontalAlign.Center
        '        JUN_ESTABELECIMENTOS = dtr("JUN")
        '        'CELULA JUL
        '        cel = New TableCell
        '        rw.Cells.Add(cel)
        '        cel.Text = dtr("JUL")
        '        cel.HorizontalAlign = HorizontalAlign.Center
        '        JUL_ESTABELECIMENTOS = dtr("JUL")
        '        'CELULA AGO
        '        cel = New TableCell
        '        rw.Cells.Add(cel)
        '        cel.Text = dtr("AGO")
        '        cel.HorizontalAlign = HorizontalAlign.Center
        '        AGO_ESTABELECIMENTOS = dtr("AGO")
        '        'CELULA SET
        '        cel = New TableCell
        '        rw.Cells.Add(cel)
        '        cel.Text = dtr("SET")
        '        cel.HorizontalAlign = HorizontalAlign.Center
        '        SET_ESTABELECIMENTOS = dtr("SET")
        '        'CELULA OUT
        '        cel = New TableCell
        '        rw.Cells.Add(cel)
        '        cel.Text = dtr("OUT")
        '        cel.HorizontalAlign = HorizontalAlign.Center
        '        OUT_ESTABELECIMENTOS = dtr("OUT")
        '        'CELULA NOV
        '        cel = New TableCell
        '        rw.Cells.Add(cel)
        '        cel.Text = dtr("NOV")
        '        cel.HorizontalAlign = HorizontalAlign.Center
        '        NOV_ESTABELECIMENTOS = dtr("NOV")
        '        'CELULA DEZ
        '        cel = New TableCell
        '        rw.Cells.Add(cel)
        '        cel.Text = dtr("DEZ")
        '        cel.HorizontalAlign = HorizontalAlign.Center
        '        DEZ_ESTABELECIMENTOS = dtr("DEZ")
        '        'CELULA TOTAL
        '        cel = New TableCell
        '        rw.Cells.Add(cel)
        '        cel.Text = " "
        '        cel.HorizontalAlign = HorizontalAlign.Center
        '    Else
        '        For X = 1 To 12
        '            cel = New TableCell
        '            rw.Cells.Add(cel)
        '            cel.Text = 0
        '            cel.HorizontalAlign = HorizontalAlign.Center
        '        Next
        '        cel = New TableCell
        '        rw.Cells.Add(cel)
        '        cel.Text = " "
        '        cel.HorizontalAlign = HorizontalAlign.Center

        '        JAN_ESTABELECIMENTOS = 0
        '        FEV_ESTABELECIMENTOS = 0
        '        MAR_ESTABELECIMENTOS = 0
        '        ABR_ESTABELECIMENTOS = 0
        '        MAI_ESTABELECIMENTOS = 0
        '        JUN_ESTABELECIMENTOS = 0
        '        JUL_ESTABELECIMENTOS = 0
        '        AGO_ESTABELECIMENTOS = 0
        '        SET_ESTABELECIMENTOS = 0
        '        OUT_ESTABELECIMENTOS = 0
        '        NOV_ESTABELECIMENTOS = 0
        '        DEZ_ESTABELECIMENTOS = 0
        '    End If
        '    dtr.Close()

        'Next
        ''LINHA VAZIA
        'rw = New TableRow
        'tbl_Report.Rows.Add(rw)
        'cel = New TableCell
        'rw.Cells.Add(cel)
        'cel.Text = "."
        'cel.ColumnSpan = 14
        'cel.ForeColor = Drawing.Color.White
        ''LINHA VAZIA
        'rw = New TableRow
        'tbl_Report.Rows.Add(rw)
        'cel = New TableCell
        'rw.Cells.Add(cel)
        'cel.Text = "DEMANDA NOS ESTABELECIMENTOS ANO ATUAL"
        'cel.ColumnSpan = 14
        'cel.ForeColor = Drawing.Color.Black
        'cel.HorizontalAlign = HorizontalAlign.Left
        ''---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'If cmb_GRUPO_DISTRIBUIDOR.Text = "Selecione o Distribuidor" Then
        '    tbl_Report.Visible = False
        '    gdv_Report.Visible = False
        'Else
        '    tbl_Report.Visible = True
        '    gdv_Report.Visible = True
        'End If
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

    Protected Sub cmb_Anos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Anos.SelectedIndexChanged
        Atualiza_Relatorio()
    End Sub

    Protected Sub cmb_LINHA_Load(sender As Object, e As EventArgs) Handles cmb_LINHA.Load
        Atualiza_Relatorio()
    End Sub
End Class