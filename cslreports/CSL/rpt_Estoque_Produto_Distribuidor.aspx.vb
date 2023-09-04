
Partial Class rpt_Estoque_Produto_Distribuidor
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Estoque"
    Dim Titulo As String = "Estoque - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = True 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = True 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = True 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = False 'Cordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = False 'Representante
        If Session("COD_PERFIL_LOGIN") = 10 Then Acesso = False 'Key Account
        If Session("COD_PERFIL_LOGIN") = 20 Then Acesso = False 'Distribuidor
        If Session("COD_PERFIL_LOGIN") = 30 Then Acesso = True 'Visitante (Para acesso do usuário do SAC
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

    Protected Sub cmb_LINHA_DataBound(sender As Object, e As EventArgs) Handles cmb_LINHA.DataBound
        If Request.QueryString("LINHA") <> "" Then
            cmb_LINHA.SelectedValue = Request.QueryString("LINHA")
        End If
        If Request.QueryString("LINHA") <> "" And Request.QueryString("GRUPO") <> "" And Request.QueryString("ANO") <> "" Then
            Atualiza_Relatorio()
        End If
    End Sub
    Protected Sub cmb_DISTRIBUIDOR_DataBound(sender As Object, e As EventArgs) Handles cmb_DISTRIBUIDOR.DataBound
        If Request.QueryString("GRUPO") <> "" Then
            cmb_DISTRIBUIDOR.SelectedValue = Request.QueryString("GRUPO")
        End If
        If Request.QueryString("LINHA") <> "" And Request.QueryString("GRUPO") <> "" And Request.QueryString("ANO") <> "" Then
            Atualiza_Relatorio()
        End If
    End Sub
    Protected Sub cmb_Anos_DataBound(sender As Object, e As EventArgs) Handles cmb_Anos.DataBound
        If Request.QueryString("ANO") <> "" Then
            cmb_Anos.SelectedValue = Request.QueryString("ANO")
        End If
        If Request.QueryString("LINHA") <> "" And Request.QueryString("GRUPO") <> "" And Request.QueryString("ANO") <> "" Then
            Atualiza_Relatorio()
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
        'Dim dtr_ESTABELECIMENTOS As System.Data.SqlClient.SqlDataReader
        'Dim sql_ESTABELECIMENTOS As String

        Dim LINHA_PRODUTO As String
        Dim GRUPO_DISTRIBUIDOR As String
        Dim PRODUTO As String
        Dim X As Integer
        'Dim Y As Integer
        Dim ANO As Integer
        Dim rw As TableRow
        Dim cel As TableCell


        'Dim JAN_ESTABELECIMENTOS As Integer
        'Dim FEV_ESTABELECIMENTOS As Integer
        'Dim MAR_ESTABELECIMENTOS As Integer
        'Dim ABR_ESTABELECIMENTOS As Integer
        'Dim MAI_ESTABELECIMENTOS As Integer
        'Dim JUN_ESTABELECIMENTOS As Integer
        'Dim JUL_ESTABELECIMENTOS As Integer
        'Dim AGO_ESTABELECIMENTOS As Integer
        'Dim SET_ESTABELECIMENTOS As Integer
        'Dim OUT_ESTABELECIMENTOS As Integer
        'Dim NOV_ESTABELECIMENTOS As Integer
        'Dim DEZ_ESTABELECIMENTOS As Integer

        'Dim JAN_DIAS As Integer
        'Dim FEV_DIAS As Integer
        'Dim MAR_DIAS As Integer
        'Dim ABR_DIAS As Integer
        'Dim MAI_DIAS As Integer
        'Dim JUN_DIAS As Integer
        'Dim JUL_DIAS As Integer
        'Dim AGO_DIAS As Integer
        'Dim SET_DIAS As Integer
        'Dim OUT_DIAS As Integer
        'Dim NOV_DIAS As Integer
        'Dim DEZ_DIAS As Integer

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
        Dim YTD_VENDA As Integer
        Dim YTD_VENDA_MEDIA As Double


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
        Dim YTD_DEMANDA As Integer
        Dim YTD_DEMANDA_MEDIA As Double

        'RECUPERA ANO INICIAL E LINHA DE PRODUTOS
        LINHA_PRODUTO = cmb_LINHA.Text
        GRUPO_DISTRIBUIDOR = cmb_DISTRIBUIDOR.Text
        'ANO = Year(Now())
        Integer.TryParse(cmb_Anos.Text, ANO)

        'ABRE CONEXÕES
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnSTR").ConnectionString
        cnn.Open()
        cnn_Dst.ConnectionString = ConfigurationManager.ConnectionStrings("cnnSTR").ConnectionString
        cnn_Dst.Open()

        'Recupera PRODUTOS
        sql_Dst = "SELECT DISTINCT PRODUTO FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_FISCAL_UN_OR WHERE ANO = " & ANO & " and LINHA = '" & LINHA_PRODUTO & "' AND GRUPO = '" & GRUPO_DISTRIBUIDOR & "' ORDER BY PRODUTO "
        cmd_Dst.Connection = cnn_Dst
        cmd_Dst.CommandText = sql_Dst
        dtr_Dst = cmd_Dst.ExecuteReader

        PRODUTO = ""
        Do While dtr_Dst.Read
            PRODUTO = ""
            PRODUTO = dtr_Dst("PRODUTO")

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

            'COLUNA NOME DO PRODUTO
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = PRODUTO
            cel.Font.Bold = True
            cel.HorizontalAlign = HorizontalAlign.Left
            cel.BackColor = Drawing.Color.WhiteSmoke

            'COLUNAS MESES
            sql = "SELECT MES, MES_FISCAL,MES_SIGLA FROM TBL_DATAS_MESES WHERE MES_FISCAL > 0 ORDER BY MES_FISCAL"
            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader

            Do While dtr.Read
                cel = New TableCell
                rw.Cells.Add(cel)
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
            cel.BackColor = Drawing.Color.WhiteSmoke

            'COLUNA YTD
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "Média YTD"
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
            sql = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_FISCAL_UN_OR WHERE PRODUTO='" & PRODUTO & "' AND GRUPO = '" & GRUPO_DISTRIBUIDOR & "' AND TIPO = 'VENDA UNIDADES ORIGINAL FISCAL' AND ANO = " & ANO & " AND LINHA = '" & LINHA_PRODUTO & "'"
            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader
            dtr.Read()
            If dtr.HasRows Then

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

                'CELULA YTD
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("YTD"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                YTD_VENDA = FormatNumber(dtr("YTD"), 0)
                'CELULA MEDIA
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("MEDIA_YTD"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                YTD_VENDA_MEDIA = FormatNumber(dtr("MEDIA_YTD"), 0)


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
                YTD_VENDA = 0
                YTD_VENDA_MEDIA = 0
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
            sql = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_FISCAL_UN_OR WHERE PRODUTO='" & PRODUTO & "' AND GRUPO = '" & GRUPO_DISTRIBUIDOR & "' AND TIPO = 'DEMANDA UNIDADES ORIGINAL FISCAL' AND ANO = " & ANO & " AND LINHA = '" & LINHA_PRODUTO & "'"

            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader
            dtr.Read()
            If dtr.HasRows Then
                
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

                'CELULA YTD
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("YTD"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                YTD_DEMANDA = FormatNumber(dtr("YTD"), 0)
                'CELULA MEDIA
                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(dtr("MEDIA_YTD"), 0)
                cel.HorizontalAlign = HorizontalAlign.Center
                YTD_DEMANDA_MEDIA = FormatNumber(dtr("MEDIA_YTD"), 0)

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
                YTD_DEMANDA = 0
                YTD_DEMANDA_MEDIA = 0
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
            sql = "SELECT * FROM VIEW_MOVIMENTO_ESTOQUE_INICIAL_LINHA WHERE GRUPO_DISTRIBUIDOR = '" & GRUPO_DISTRIBUIDOR & "' AND TIPO = '03 ESTOQUE' AND ANO = " & ANO & " AND LINHA = '" & LINHA_PRODUTO & "'"

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
                sql = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_FISCAL_UN_OR WHERE PRODUTO='" & PRODUTO & "' AND GRUPO = '" & GRUPO_DISTRIBUIDOR & "' AND TIPO = 'ESTOQUE UNIDADES ORIGINAL FISCAL' AND ANO = " & ANO & " AND LINHA = '" & LINHA_PRODUTO & "'"
            Else
                sql = ""
                sql = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_FISCAL_UN_OR WHERE PRODUTO='" & PRODUTO & "' AND GRUPO = '" & GRUPO_DISTRIBUIDOR & "' AND TIPO = 'ESTOQUE UNIDADES ORIGINAL FISCAL' AND ANO = " & ANO & " OR ANO = 2015 AND LINHA = '" & LINHA_PRODUTO & "'"
            End If

            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader
            dtr.Read()
            If dtr.HasRows Then
                If ANO < 2015 Then
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

                    'CELULA TOTAL
                    'cel = New TableCell
                    'rw.Cells.Add(cel)
                    ''cel.Text = FormatNumber(dtr("TOTAL"), 0)
                    'cel.BackColor = Drawing.Color.LightGray
                    'cel.HorizontalAlign = HorizontalAlign.Center
                ElseIf ANO = 2015 Then
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
                    cel.Text = FormatNumber((MAI_ESTOQUE + JUN_VENDA) - JUN_DEMANDA, 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.MediumTurquoise
                    JUN_ESTOQUE = FormatNumber((MAI_ESTOQUE + JUN_VENDA) - JUN_DEMANDA, 0)

                    'CELULA TOTAL
                    'cel = New TableCell
                    'rw.Cells.Add(cel)
                    ''cel.Text = FormatNumber(dtr("TOTAL"), 0)
                    'cel.BackColor = Drawing.Color.LightGray
                    'cel.HorizontalAlign = HorizontalAlign.Center
                ElseIf ANO > 2015 Then
                    'CELULA JUL
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = FormatNumber((ESTOQUE_INICIAL + JUL_VENDA) - JUL_DEMANDA, 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.MediumTurquoise
                    JUL_ESTOQUE = FormatNumber((ESTOQUE_INICIAL + JUL_VENDA) - JUL_DEMANDA, 0)

                    'CELULA AGO
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = FormatNumber((JUL_ESTOQUE + AGO_VENDA) - AGO_DEMANDA, 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.MediumTurquoise
                    AGO_ESTOQUE = FormatNumber((JUL_ESTOQUE + AGO_VENDA) - AGO_DEMANDA, 0)

                    'CELULA SET
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = FormatNumber((AGO_ESTOQUE + SET_VENDA) - SET_DEMANDA, 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.MediumTurquoise
                    SET_ESTOQUE = FormatNumber((AGO_ESTOQUE + SET_VENDA) - SET_DEMANDA, 0)

                    'CELULA OUT
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = FormatNumber((SET_ESTOQUE + OUT_VENDA) - OUT_DEMANDA, 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.MediumTurquoise
                    OUT_ESTOQUE = FormatNumber((SET_ESTOQUE + OUT_VENDA) - OUT_DEMANDA, 0)

                    'CELULA NOV
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = FormatNumber((OUT_ESTOQUE + NOV_VENDA) - NOV_DEMANDA, 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.MediumTurquoise
                    NOV_ESTOQUE = FormatNumber((OUT_ESTOQUE + NOV_VENDA) - NOV_DEMANDA, 0)

                    'CELULA DEZ
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = FormatNumber((NOV_ESTOQUE + DEZ_VENDA) - DEZ_DEMANDA, 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.MediumTurquoise
                    DEZ_ESTOQUE = FormatNumber((NOV_ESTOQUE + DEZ_VENDA) - DEZ_DEMANDA, 0)

                    'CELULA JAN
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = FormatNumber((DEZ_ESTOQUE + JAN_VENDA) - JAN_DEMANDA, 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.MediumTurquoise
                    JAN_ESTOQUE = FormatNumber((DEZ_ESTOQUE + JAN_VENDA) - JAN_DEMANDA, 0)

                    'CELULA FEV
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = FormatNumber((JAN_ESTOQUE + FEV_VENDA) - FEV_DEMANDA, 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.MediumTurquoise
                    FEV_ESTOQUE = FormatNumber((JAN_ESTOQUE + FEV_VENDA) - FEV_DEMANDA, 0)

                    'CELULA MAR
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = FormatNumber((FEV_ESTOQUE + MAR_VENDA) - MAR_DEMANDA, 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.MediumTurquoise
                    MAR_ESTOQUE = FormatNumber((FEV_ESTOQUE + MAR_VENDA) - MAR_DEMANDA, 0)

                    'CELULA ABR
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = FormatNumber((MAR_ESTOQUE + ABR_VENDA) - ABR_DEMANDA, 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.MediumTurquoise
                    ABR_ESTOQUE = FormatNumber((MAR_ESTOQUE + ABR_VENDA) - ABR_DEMANDA, 0)

                    'CELULA MAI
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = FormatNumber((ABR_ESTOQUE + MAI_VENDA) - MAI_DEMANDA, 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.MediumTurquoise
                    MAI_ESTOQUE = FormatNumber((ABR_ESTOQUE + MAI_VENDA) - MAI_DEMANDA, 0)

                    'CELULA JUN
                    cel = New TableCell
                    rw.Cells.Add(cel)
                    cel.Text = FormatNumber((MAI_ESTOQUE + JUN_VENDA) - JUN_DEMANDA, 0)
                    cel.HorizontalAlign = HorizontalAlign.Center
                    cel.BackColor = Drawing.Color.MediumTurquoise
                    JUN_ESTOQUE = FormatNumber((MAI_ESTOQUE + JUN_VENDA) - JUN_DEMANDA, 0)

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
        dts_PRODUTOS.DataBind()
        cmb_LINHA.DataBind()
        Atualiza_Relatorio()
    End Sub
    Protected Sub cmb_LINHA_Load(sender As Object, e As EventArgs) Handles cmb_LINHA.Load
        Atualiza_Relatorio()
    End Sub
End Class