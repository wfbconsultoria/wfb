
Partial Class Estabelecimentos_Ficha
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "rpt_Estabelecimentos_Produtividade.aspx"

    Dim cnn_linha_produto As New System.Data.SqlClient.SqlConnection
    Dim cmd_linha_produto As New System.Data.SqlClient.SqlCommand
    Dim dtr_linha_produto As System.Data.SqlClient.SqlDataReader
    Dim sql_linha_produto As String

    Dim cnn_estabelecimento As New System.Data.SqlClient.SqlConnection
    Dim cmd_estabelecimento As New System.Data.SqlClient.SqlCommand
    Dim dtr_estabelecimento As System.Data.SqlClient.SqlDataReader
    Dim sql_estabelecimento As String

    Dim cnn As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String

    Dim rw As TableRow
    Dim cel As TableCell
    Dim CNPJ As String
    Dim ANO_RETRASADO As Integer
    Dim ANO_PASSADO As Integer
    Dim ANO_ATUAL As Integer
    Dim MES_ATUAL As Integer
    Dim LINHA_PRODUTO As String
    Dim COD_GRUPO_BOMBA As Integer

    Dim JAN_DEMANDA_RETRASADO As Integer
    Dim FEV_DEMANDA_RETRASADO As Integer
    Dim MAR_DEMANDA_RETRASADO As Integer
    Dim ABR_DEMANDA_RETRASADO As Integer
    Dim MAI_DEMANDA_RETRASADO As Integer
    Dim JUN_DEMANDA_RETRASADO As Integer
    Dim JUL_DEMANDA_RETRASADO As Integer
    Dim AGO_DEMANDA_RETRASADO As Integer
    Dim SET_DEMANDA_RETRASADO As Integer
    Dim OUT_DEMANDA_RETRASADO As Integer
    Dim NOV_DEMANDA_RETRASADO As Integer
    Dim DEZ_DEMANDA_RETRASADO As Integer
    Dim TRI01_DEMANDA_RETRASADO As Integer
    Dim TRI02_DEMANDA_RETRASADO As Integer
    Dim TRI03_DEMANDA_RETRASADO As Integer
    Dim TRI04_DEMANDA_RETRASADO As Integer
    Dim TOTAL_DEMANDA_RETRASADO As Integer
    Dim YTD_DEMANDA_RETRASADO As Integer

    Dim JAN_DEMANDA_PASSADO As Integer
    Dim FEV_DEMANDA_PASSADO As Integer
    Dim MAR_DEMANDA_PASSADO As Integer
    Dim ABR_DEMANDA_PASSADO As Integer
    Dim MAI_DEMANDA_PASSADO As Integer
    Dim JUN_DEMANDA_PASSADO As Integer
    Dim JUL_DEMANDA_PASSADO As Integer
    Dim AGO_DEMANDA_PASSADO As Integer
    Dim SET_DEMANDA_PASSADO As Integer
    Dim OUT_DEMANDA_PASSADO As Integer
    Dim NOV_DEMANDA_PASSADO As Integer
    Dim DEZ_DEMANDA_PASSADO As Integer
    Dim TRI01_DEMANDA_PASSADO As Integer
    Dim TRI02_DEMANDA_PASSADO As Integer
    Dim TRI03_DEMANDA_PASSADO As Integer
    Dim TRI04_DEMANDA_PASSADO As Integer
    Dim TOTAL_DEMANDA_PASSADO As Integer
    Dim YTD_DEMANDA_PASSADO As Integer

    Dim JAN_DEMANDA_ATUAL As Integer
    Dim FEV_DEMANDA_ATUAL As Integer
    Dim MAR_DEMANDA_ATUAL As Integer
    Dim ABR_DEMANDA_ATUAL As Integer
    Dim MAI_DEMANDA_ATUAL As Integer
    Dim JUN_DEMANDA_ATUAL As Integer
    Dim JUL_DEMANDA_ATUAL As Integer
    Dim AGO_DEMANDA_ATUAL As Integer
    Dim SET_DEMANDA_ATUAL As Integer
    Dim OUT_DEMANDA_ATUAL As Integer
    Dim NOV_DEMANDA_ATUAL As Integer
    Dim DEZ_DEMANDA_ATUAL As Integer
    Dim TRI01_DEMANDA_ATUAL As Integer
    Dim TRI02_DEMANDA_ATUAL As Integer
    Dim TRI03_DEMANDA_ATUAL As Integer
    Dim TRI04_DEMANDA_ATUAL As Integer
    Dim TOTAL_DEMANDA_ATUAL As Integer
    Dim YTD_DEMANDA_ATUAL As Integer

    Dim JAN_BOMBAS_PASSADO As Integer
    Dim FEV_BOMBAS_PASSADO As Integer
    Dim MAR_BOMBAS_PASSADO As Integer
    Dim ABR_BOMBAS_PASSADO As Integer
    Dim MAI_BOMBAS_PASSADO As Integer
    Dim JUN_BOMBAS_PASSADO As Integer
    Dim JUL_BOMBAS_PASSADO As Integer
    Dim AGO_BOMBAS_PASSADO As Integer
    Dim SET_BOMBAS_PASSADO As Integer
    Dim OUT_BOMBAS_PASSADO As Integer
    Dim NOV_BOMBAS_PASSADO As Integer
    Dim DEZ_BOMBAS_PASSADO As Integer
    Dim TRI01_BOMBAS_PASSADO As Integer
    Dim TRI02_BOMBAS_PASSADO As Integer
    Dim TRI03_BOMBAS_PASSADO As Integer
    Dim TRI04_BOMBAS_PASSADO As Integer
    Dim TOTAL_BOMBAS_PASSADO As Integer
    Dim YTD_BOMBAS_PASSADO As Integer

    Dim JAN_BOMBAS_ATUAL As Integer
    Dim FEV_BOMBAS_ATUAL As Integer
    Dim MAR_BOMBAS_ATUAL As Integer
    Dim ABR_BOMBAS_ATUAL As Integer
    Dim MAI_BOMBAS_ATUAL As Integer
    Dim JUN_BOMBAS_ATUAL As Integer
    Dim JUL_BOMBAS_ATUAL As Integer
    Dim AGO_BOMBAS_ATUAL As Integer
    Dim SET_BOMBAS_ATUAL As Integer
    Dim OUT_BOMBAS_ATUAL As Integer
    Dim NOV_BOMBAS_ATUAL As Integer
    Dim DEZ_BOMBAS_ATUAL As Integer
    Dim TRI01_BOMBAS_ATUAL As Integer
    Dim TRI02_BOMBAS_ATUAL As Integer
    Dim TRI03_BOMBAS_ATUAL As Integer
    Dim TRI04_BOMBAS_ATUAL As Integer
    Dim TOTAL_BOMBAS_ATUAL As Integer
    Dim YTD_BOMBAS_ATUAL As Integer

    Dim JAN_BOMBAS_REP_ATUAL As Integer
    Dim FEV_BOMBAS_REP_ATUAL As Integer
    Dim MAR_BOMBAS_REP_ATUAL As Integer
    Dim ABR_BOMBAS_REP_ATUAL As Integer
    Dim MAI_BOMBAS_REP_ATUAL As Integer
    Dim JUN_BOMBAS_REP_ATUAL As Integer
    Dim JUL_BOMBAS_REP_ATUAL As Integer
    Dim AGO_BOMBAS_REP_ATUAL As Integer
    Dim SET_BOMBAS_REP_ATUAL As Integer
    Dim OUT_BOMBAS_REP_ATUAL As Integer
    Dim NOV_BOMBAS_REP_ATUAL As Integer
    Dim DEZ_BOMBAS_REP_ATUAL As Integer
    Dim TRI01_BOMBAS_REP_ATUAL As Integer
    Dim TRI02_BOMBAS_REP_ATUAL As Integer
    Dim TRI03_BOMBAS_REP_ATUAL As Integer
    Dim TRI04_BOMBAS_REP_ATUAL As Integer
    Dim TOTAL_BOMBAS_REP_ATUAL As Integer
    Dim YTD_BOMBAS_REP_ATUAL As Integer

    Dim JAN_BOMBAS_REP_PASSADO As Integer
    Dim FEV_BOMBAS_REP_PASSADO As Integer
    Dim MAR_BOMBAS_REP_PASSADO As Integer
    Dim ABR_BOMBAS_REP_PASSADO As Integer
    Dim MAI_BOMBAS_REP_PASSADO As Integer
    Dim JUN_BOMBAS_REP_PASSADO As Integer
    Dim JUL_BOMBAS_REP_PASSADO As Integer
    Dim AGO_BOMBAS_REP_PASSADO As Integer
    Dim SET_BOMBAS_REP_PASSADO As Integer
    Dim OUT_BOMBAS_REP_PASSADO As Integer
    Dim NOV_BOMBAS_REP_PASSADO As Integer
    Dim DEZ_BOMBAS_REP_PASSADO As Integer
    Dim TRI01_BOMBAS_REP_PASSADO As Integer
    Dim TRI02_BOMBAS_REP_PASSADO As Integer
    Dim TRI03_BOMBAS_REP_PASSADO As Integer
    Dim TRI04_BOMBAS_REP_PASSADO As Integer
    Dim TOTAL_BOMBAS_REP_PASSADO As Integer
    Dim YTD_BOMBAS_REP_PASSADO As Integer

    Dim JAN_BOMBAS_DST As Integer
    Dim FEV_BOMBAS_DST As Integer
    Dim MAR_BOMBAS_DST As Integer
    Dim ABR_BOMBAS_DST As Integer
    Dim MAI_BOMBAS_DST As Integer
    Dim JUN_BOMBAS_DST As Integer
    Dim JUL_BOMBAS_DST As Integer
    Dim AGO_BOMBAS_DST As Integer
    Dim SET_BOMBAS_DST As Integer
    Dim OUT_BOMBAS_DST As Integer
    Dim NOV_BOMBAS_DST As Integer
    Dim DEZ_BOMBAS_DST As Integer
    Dim TRI01_BOMBAS_DST As Integer
    Dim TRI02_BOMBAS_DST As Integer
    Dim TRI03_BOMBAS_DST As Integer
    Dim TRI04_BOMBAS_DST As Integer
    Dim TOTAL_BOMBAS_DST As Integer
    Dim YTD_BOMBAS_DST As Integer

    Dim JAN_BOMBAS_PRODUTIVIDADE_PASSADO As Integer
    Dim FEV_BOMBAS_PRODUTIVIDADE_PASSADO As Integer
    Dim MAR_BOMBAS_PRODUTIVIDADE_PASSADO As Integer
    Dim ABR_BOMBAS_PRODUTIVIDADE_PASSADO As Integer
    Dim MAI_BOMBAS_PRODUTIVIDADE_PASSADO As Integer
    Dim JUN_BOMBAS_PRODUTIVIDADE_PASSADO As Integer
    Dim JUL_BOMBAS_PRODUTIVIDADE_PASSADO As Integer
    Dim AGO_BOMBAS_PRODUTIVIDADE_PASSADO As Integer
    Dim SET_BOMBAS_PRODUTIVIDADE_PASSADO As Integer
    Dim OUT_BOMBAS_PRODUTIVIDADE_PASSADO As Integer
    Dim NOV_BOMBAS_PRODUTIVIDADE_PASSADO As Integer
    Dim DEZ_BOMBAS_PRODUTIVIDADE_PASSADO As Integer
    Dim TRI01_BOMBAS_PRODUTIVIDADE_PASSADO As Integer
    Dim TRI02_BOMBAS_PRODUTIVIDADE_PASSADO As Integer
    Dim TRI03_BOMBAS_PRODUTIVIDADE_PASSADO As Integer
    Dim TRI04_BOMBAS_PRODUTIVIDADE_PASSADO As Integer
    Dim TOTAL_BOMBAS_PRODUTIVIDADE_PASSADO As Integer
    Dim YTD_BOMBAS_PRODUTIVIDADE_PASSADO As Integer

    Dim JAN_BOMBAS_PRODUTIVIDADE_ATUAL As Integer
    Dim FEV_BOMBAS_PRODUTIVIDADE_ATUAL As Integer
    Dim MAR_BOMBAS_PRODUTIVIDADE_ATUAL As Integer
    Dim ABR_BOMBAS_PRODUTIVIDADE_ATUAL As Integer
    Dim MAI_BOMBAS_PRODUTIVIDADE_ATUAL As Integer
    Dim JUN_BOMBAS_PRODUTIVIDADE_ATUAL As Integer
    Dim JUL_BOMBAS_PRODUTIVIDADE_ATUAL As Integer
    Dim AGO_BOMBAS_PRODUTIVIDADE_ATUAL As Integer
    Dim SET_BOMBAS_PRODUTIVIDADE_ATUAL As Integer
    Dim OUT_BOMBAS_PRODUTIVIDADE_ATUAL As Integer
    Dim NOV_BOMBAS_PRODUTIVIDADE_ATUAL As Integer
    Dim DEZ_BOMBAS_PRODUTIVIDADE_ATUAL As Integer
    Dim TRI01_BOMBAS_PRODUTIVIDADE_ATUAL As Integer
    Dim TRI02_BOMBAS_PRODUTIVIDADE_ATUAL As Integer
    Dim TRI03_BOMBAS_PRODUTIVIDADE_ATUAL As Integer
    Dim TRI04_BOMBAS_PRODUTIVIDADE_ATUAL As Integer
    Dim TOTAL_BOMBAS_PRODUTIVIDADE_ATUAL As Integer
    Dim YTD_BOMBAS_PRODUTIVIDADE_ATUAL As Integer

    Dim JAN_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer
    Dim FEV_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer
    Dim MAR_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer
    Dim ABR_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer
    Dim MAI_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer
    Dim JUN_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer
    Dim JUL_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer
    Dim AGO_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer
    Dim SET_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer
    Dim OUT_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer
    Dim NOV_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer
    Dim DEZ_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer
    Dim TRI01_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer
    Dim TRI02_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer
    Dim TRI03_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer
    Dim TRI04_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer
    Dim TOTAL_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer
    Dim YTD_BOMBAS_PRODUTIVIDADE_REP_PASSADO As Integer

    Dim JAN_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer
    Dim FEV_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer
    Dim MAR_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer
    Dim ABR_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer
    Dim MAI_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer
    Dim JUN_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer
    Dim JUL_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer
    Dim AGO_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer
    Dim SET_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer
    Dim OUT_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer
    Dim NOV_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer
    Dim DEZ_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer
    Dim TRI01_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer
    Dim TRI02_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer
    Dim TRI03_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer
    Dim TRI04_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer
    Dim TOTAL_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer
    Dim YTD_BOMBAS_PRODUTIVIDADE_REP_ATUAL As Integer

    Dim JAN_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim FEV_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim MAR_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim ABR_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim MAI_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim JUN_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim JUL_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim AGO_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim SET_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim OUT_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim NOV_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim DEZ_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim TRI01_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim TRI02_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim TRI03_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim TRI04_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim TOTAL_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim YTD_BOMBAS_PRODUTIVIDADE_DST As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        'verifica se existe sessão de login
        If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Default.aspx")


        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

        'ABRE CONEXÃO
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()
        cnn_linha_produto.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn_linha_produto.Open()

        cnn_estabelecimento.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn_estabelecimento.Open()

        'DEFINE VARIAVEIS
        ANO_ATUAL = 0
        ANO_ATUAL = Val(cmb_Ano.Text)
        If ANO_ATUAL = 0 Then ANO_ATUAL = Year(Now())
        ANO_PASSADO = ANO_ATUAL - 1
        ANO_RETRASADO = ANO_ATUAL - 2
        MES_ATUAL = Month(Now())


        sql_estabelecimento = "Select * From TBL_ESTABELECIMENTOS WHERE CNPJ = '394544017150' ORDEr BY ESTABELECIMENTO"
        cmd_estabelecimento.Connection = cnn_estabelecimento
        cmd_estabelecimento.CommandText = sql_estabelecimento
        dtr_estabelecimento = cmd_estabelecimento.ExecuteReader

        If dtr_estabelecimento.HasRows Then
            Do While dtr_estabelecimento.Read
                CNPJ = dtr_estabelecimento("CNPJ")

                sql_linha_produto = "Select * From TBL_PRODUTOS_LINHAS Where COD_GRUPO_BOMBA <> 0 AND COD = '" & cmb_Linha_Produto.Text & "'  Order By ORDEM"
                cmd_linha_produto.Connection = cnn_linha_produto
                cmd_linha_produto.CommandText = sql_linha_produto
                dtr_linha_produto = cmd_linha_produto.ExecuteReader

                Linha_Titulo(dtr_estabelecimento("ESTABELECIMENTO"))

                If dtr_linha_produto.HasRows Then

                    Do While dtr_linha_produto.Read

                        Linha_Titulo(dtr_linha_produto("LINHA"))

                        'MONTA FICHA DO ESTABELECIMENTO
                        COD_GRUPO_BOMBA = 0
                        If Not IsDBNull(dtr_linha_produto("COD_GRUPO_BOMBA")) Then COD_GRUPO_BOMBA = dtr_linha_produto("COD_GRUPO_BOMBA")

                        If COD_GRUPO_BOMBA <> 0 Then


                            Linha_Vazia(30, "", True)
                            Linha_Cabecalho_Meses("Produtividade de Bombas")
                            Linha_Demanda_Passado(dtr_linha_produto("LINHA"), "Demanda " & ANO_PASSADO, True)
                            Linha_Bombas_Passado(dtr_linha_produto("LINHA"), "Alocadas " & ANO_PASSADO, True)
                            Linha_Bombas_Produtividade_Passado(dtr_linha_produto("LINHA"), "Produtividade " & ANO_PASSADO, True)
                            Linha_Bombas_Representante_Passado(dtr_linha_produto("LINHA"), "Alocadas Representante" & ANO_PASSADO, True)
                            Linha_Bombas_Produtividade_REP_Passado(dtr_linha_produto("LINHA"), "Produtividade Representante" & ANO_PASSADO, True)
                            Linha_Bombas_Passado(dtr_linha_produto("LINHA"), "INET ", True)

                            Linha_Vazia(30, "", True)
                            Linha_Cabecalho_Meses("Produtividade de Bombas")
                            Linha_Demanda_Atual(dtr_linha_produto("LINHA"), "Demanda " & ANO_ATUAL, True)
                            Linha_Bombas_Atual(dtr_linha_produto("LINHA"), "Alocadas " & ANO_ATUAL, True)
                            Linha_Bombas_Produtividade_Atual(dtr_linha_produto("LINHA"), "Produtividade " & ANO_ATUAL, True)
                            Linha_Bombas_Representante_Atual(dtr_linha_produto("LINHA"), "Alocadas Representante" & ANO_ATUAL, True)
                            Linha_Bombas_Produtividade_REP_Atual(dtr_linha_produto("LINHA"), "Produtividade Representante" & ANO_ATUAL, True)
                            Linha_Bombas_Atual(dtr_linha_produto("LINHA"), "INET ", True)
                        End If

                    Loop
                    dtr_linha_produto.Close()
                End If


            Loop
            dtr_estabelecimento.Close()
            cnn_linha_produto.Close()
            cnn_estabelecimento.Close()
        End If

        Linha_Vazia(30, "", True)
    End Sub

    Private Sub Linha_Titulo(TITULO As String)
        'LINHA DE titulo
        rw = New TableRow
        rw.BackColor = Drawing.Color.Transparent
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.ColumnSpan = 19
        cel.Text = TITULO

        cel.Font.Bold = True
        cel.Font.Size = 14
        cel.HorizontalAlign = HorizontalAlign.Left
        cel.VerticalAlign = VerticalAlign.Middle
        cel.BorderStyle = BorderStyle.None

    End Sub
    Private Sub Linha_Cabecalho_Meses(TITULO As String)
        'LINHA DE CABEÇALHO
        rw = New TableRow
        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO
        cel.Font.Size = 10
        cel.Font.Bold = True
        cel.VerticalAlign = VerticalAlign.Middle
        cel.HorizontalAlign = HorizontalAlign.Left
        cel.BorderWidth = 1
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Jan"
        If MES_ATUAL >= 1 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 1 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Fev"
        If MES_ATUAL >= 2 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 2 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Mar"
        If MES_ATUAL >= 3 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 3 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Abr"
        If MES_ATUAL >= 4 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 4 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Mai"
        If MES_ATUAL >= 5 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 5 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Jun"
        If MES_ATUAL >= 6 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 6 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Jul"
        If MES_ATUAL >= 7 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 7 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Ago"
        If MES_ATUAL >= 8 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 8 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Set"
        If MES_ATUAL >= 9 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 9 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Out"
        If MES_ATUAL >= 10 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 10 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Nov"
        If MES_ATUAL >= 11 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 11 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Dez"
        If MES_ATUAL >= 12 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 12 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "1º Tri"
        If MES_ATUAL >= 3 Then cel.BackColor = Drawing.Color.Gainsboro
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "2º Tri"
        If MES_ATUAL >= 6 Then cel.BackColor = Drawing.Color.Gainsboro
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "3º Tri"
        If MES_ATUAL >= 9 Then cel.BackColor = Drawing.Color.Gainsboro
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "4º Tri"
        If MES_ATUAL >= 12 Then cel.BackColor = Drawing.Color.Gainsboro
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Ytd"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Total"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

    End Sub
    Private Sub Linha_Vazia(Altura As Integer, Titulo As String, Negrito As Boolean)
        'LINHA vazia
        rw = New TableRow
        rw.BackColor = Drawing.Color.Transparent
        rw.Height = Altura
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.ColumnSpan = 19
        cel.Text = Titulo

        cel.Font.Bold = Negrito
        cel.Font.Size = 12
        cel.HorizontalAlign = HorizontalAlign.Left
        cel.VerticalAlign = VerticalAlign.Middle
        cel.BorderStyle = BorderStyle.None
    End Sub
    Private Sub Linha_Demanda_Retrasado(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        'RECUPERA INFORMAÇÕES
        JAN_DEMANDA_RETRASADO = 0
        FEV_DEMANDA_RETRASADO = 0
        MAR_DEMANDA_RETRASADO = 0
        ABR_DEMANDA_RETRASADO = 0
        MAI_DEMANDA_RETRASADO = 0
        JUN_DEMANDA_RETRASADO = 0
        JUL_DEMANDA_RETRASADO = 0
        AGO_DEMANDA_RETRASADO = 0
        SET_DEMANDA_RETRASADO = 0
        OUT_DEMANDA_RETRASADO = 0
        NOV_DEMANDA_RETRASADO = 0
        DEZ_DEMANDA_RETRASADO = 0
        TRI01_DEMANDA_RETRASADO = 0
        TRI02_DEMANDA_RETRASADO = 0
        TRI03_DEMANDA_RETRASADO = 0
        TRI04_DEMANDA_RETRASADO = 0
        TOTAL_DEMANDA_RETRASADO = 0
        YTD_DEMANDA_RETRASADO = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
        sql = sql & "WHERE (ANO = " & ANO_RETRASADO & ") AND (CNPJ = " & CNPJ & ") AND (LINHA = '" & LINHA_PRODUTO & "')"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_DEMANDA_RETRASADO = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_DEMANDA_RETRASADO = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_DEMANDA_RETRASADO = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_DEMANDA_RETRASADO = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_DEMANDA_RETRASADO = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_DEMANDA_RETRASADO = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_DEMANDA_RETRASADO = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_DEMANDA_RETRASADO = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_DEMANDA_RETRASADO = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_DEMANDA_RETRASADO = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_DEMANDA_RETRASADO = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_DEMANDA_RETRASADO = dtr("DEZ")
        End If
        dtr.Close()
        TRI01_DEMANDA_RETRASADO = JAN_DEMANDA_RETRASADO + FEV_DEMANDA_RETRASADO + MAR_DEMANDA_RETRASADO
        TRI02_DEMANDA_RETRASADO = ABR_DEMANDA_RETRASADO + MAI_DEMANDA_RETRASADO + JUN_DEMANDA_RETRASADO
        TRI03_DEMANDA_RETRASADO = JUL_DEMANDA_RETRASADO + AGO_DEMANDA_RETRASADO + SET_DEMANDA_RETRASADO
        TRI04_DEMANDA_RETRASADO = OUT_DEMANDA_RETRASADO + NOV_DEMANDA_RETRASADO + DEZ_DEMANDA_RETRASADO
        TOTAL_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + TRI02_DEMANDA_RETRASADO + TRI03_DEMANDA_RETRASADO + TRI04_DEMANDA_RETRASADO

        If MES_ATUAL = 1 Then YTD_DEMANDA_RETRASADO = 0
        If MES_ATUAL = 2 Then YTD_DEMANDA_RETRASADO = JAN_DEMANDA_RETRASADO
        If MES_ATUAL = 3 Then YTD_DEMANDA_RETRASADO = JAN_DEMANDA_RETRASADO + FEV_DEMANDA_RETRASADO
        If MES_ATUAL = 4 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO
        If MES_ATUAL = 5 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + ABR_DEMANDA_RETRASADO
        If MES_ATUAL = 6 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + +ABR_DEMANDA_RETRASADO + MAI_DEMANDA_RETRASADO
        If MES_ATUAL = 7 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + TRI02_DEMANDA_RETRASADO
        If MES_ATUAL = 8 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + TRI02_DEMANDA_RETRASADO + JUL_DEMANDA_RETRASADO
        If MES_ATUAL = 9 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + TRI02_DEMANDA_RETRASADO + JUL_DEMANDA_RETRASADO + AGO_DEMANDA_RETRASADO
        If MES_ATUAL = 10 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + TRI02_DEMANDA_RETRASADO + TRI03_DEMANDA_RETRASADO
        If MES_ATUAL = 11 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + TRI02_DEMANDA_RETRASADO + TRI03_DEMANDA_RETRASADO + OUT_DEMANDA_RETRASADO
        If MES_ATUAL = 12 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + TRI02_DEMANDA_RETRASADO + TRI03_DEMANDA_RETRASADO + +OUT_DEMANDA_RETRASADO + NOV_DEMANDA_RETRASADO

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        rw.BorderWidth = 1
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1


    End Sub
    Private Sub Linha_Demanda_Passado(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        'RECUPERA INFORMAÇÕES
        JAN_DEMANDA_PASSADO = 0
        FEV_DEMANDA_PASSADO = 0
        MAR_DEMANDA_PASSADO = 0
        ABR_DEMANDA_PASSADO = 0
        MAI_DEMANDA_PASSADO = 0
        JUN_DEMANDA_PASSADO = 0
        JUL_DEMANDA_PASSADO = 0
        AGO_DEMANDA_PASSADO = 0
        SET_DEMANDA_PASSADO = 0
        OUT_DEMANDA_PASSADO = 0
        NOV_DEMANDA_PASSADO = 0
        DEZ_DEMANDA_PASSADO = 0
        TRI01_DEMANDA_PASSADO = 0
        TRI02_DEMANDA_PASSADO = 0
        TRI03_DEMANDA_PASSADO = 0
        TRI04_DEMANDA_PASSADO = 0
        TOTAL_DEMANDA_PASSADO = 0
        YTD_DEMANDA_PASSADO = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
        sql = sql & "WHERE (ANO = " & ANO_PASSADO & ") AND (CNPJ = " & CNPJ & ") AND (LINHA = '" & LINHA_PRODUTO & "')"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then

            If Not (IsDBNull(dtr("JAN"))) Then JAN_DEMANDA_PASSADO = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_DEMANDA_PASSADO = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_DEMANDA_PASSADO = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_DEMANDA_PASSADO = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_DEMANDA_PASSADO = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_DEMANDA_PASSADO = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_DEMANDA_PASSADO = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_DEMANDA_PASSADO = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_DEMANDA_PASSADO = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_DEMANDA_PASSADO = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_DEMANDA_PASSADO = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_DEMANDA_PASSADO = dtr("DEZ")
        End If
        dtr.Close()
        TRI01_DEMANDA_PASSADO = JAN_DEMANDA_PASSADO + FEV_DEMANDA_PASSADO + MAR_DEMANDA_PASSADO
        TRI02_DEMANDA_PASSADO = ABR_DEMANDA_PASSADO + MAI_DEMANDA_PASSADO + JUN_DEMANDA_PASSADO
        TRI03_DEMANDA_PASSADO = JUL_DEMANDA_PASSADO + AGO_DEMANDA_PASSADO + SET_DEMANDA_PASSADO
        TRI04_DEMANDA_PASSADO = OUT_DEMANDA_PASSADO + NOV_DEMANDA_PASSADO + DEZ_DEMANDA_PASSADO
        TOTAL_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + TRI02_DEMANDA_PASSADO + TRI03_DEMANDA_PASSADO + TRI04_DEMANDA_PASSADO

        If MES_ATUAL = 1 Then YTD_DEMANDA_PASSADO = 0
        If MES_ATUAL = 2 Then YTD_DEMANDA_PASSADO = JAN_DEMANDA_PASSADO
        If MES_ATUAL = 3 Then YTD_DEMANDA_PASSADO = JAN_DEMANDA_PASSADO + FEV_DEMANDA_PASSADO
        If MES_ATUAL = 4 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO
        If MES_ATUAL = 5 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + ABR_DEMANDA_PASSADO
        If MES_ATUAL = 6 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + ABR_DEMANDA_PASSADO + MAI_DEMANDA_PASSADO
        If MES_ATUAL = 7 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + TRI02_DEMANDA_PASSADO
        If MES_ATUAL = 8 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + TRI02_DEMANDA_PASSADO + JUL_DEMANDA_PASSADO
        If MES_ATUAL = 9 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + TRI02_DEMANDA_PASSADO + JUL_DEMANDA_PASSADO + AGO_DEMANDA_PASSADO
        If MES_ATUAL = 10 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + TRI02_DEMANDA_PASSADO + TRI03_DEMANDA_PASSADO
        If MES_ATUAL = 11 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + TRI02_DEMANDA_PASSADO + TRI03_DEMANDA_PASSADO + OUT_DEMANDA_PASSADO
        If MES_ATUAL = 12 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + TRI02_DEMANDA_PASSADO + TRI03_DEMANDA_PASSADO + OUT_DEMANDA_PASSADO + NOV_DEMANDA_PASSADO

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow

        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        rw.BorderWidth = 1
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1


    End Sub
    Private Sub Linha_Demanda_Atual(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        'RECUPERA INFORMAÇÕES
        JAN_DEMANDA_ATUAL = 0
        FEV_DEMANDA_ATUAL = 0
        MAR_DEMANDA_ATUAL = 0
        ABR_DEMANDA_ATUAL = 0
        MAI_DEMANDA_ATUAL = 0
        JUN_DEMANDA_ATUAL = 0
        JUL_DEMANDA_ATUAL = 0
        AGO_DEMANDA_ATUAL = 0
        SET_DEMANDA_ATUAL = 0
        OUT_DEMANDA_ATUAL = 0
        NOV_DEMANDA_ATUAL = 0
        DEZ_DEMANDA_ATUAL = 0
        TRI01_DEMANDA_ATUAL = 0
        TRI02_DEMANDA_ATUAL = 0
        TRI03_DEMANDA_ATUAL = 0
        TRI04_DEMANDA_ATUAL = 0
        TOTAL_DEMANDA_ATUAL = 0
        YTD_DEMANDA_ATUAL = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
        sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (CNPJ = " & CNPJ & ") AND (LINHA = '" & LINHA_PRODUTO & "')"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_DEMANDA_ATUAL = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_DEMANDA_ATUAL = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_DEMANDA_ATUAL = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_DEMANDA_ATUAL = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_DEMANDA_ATUAL = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_DEMANDA_ATUAL = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_DEMANDA_ATUAL = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_DEMANDA_ATUAL = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_DEMANDA_ATUAL = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_DEMANDA_ATUAL = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_DEMANDA_ATUAL = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_DEMANDA_ATUAL = dtr("DEZ")
        End If
        dtr.Close()
        TRI01_DEMANDA_ATUAL = JAN_DEMANDA_ATUAL + FEV_DEMANDA_ATUAL + MAR_DEMANDA_ATUAL
        TRI02_DEMANDA_ATUAL = ABR_DEMANDA_ATUAL + MAI_DEMANDA_ATUAL + JUN_DEMANDA_ATUAL
        TRI03_DEMANDA_ATUAL = JUL_DEMANDA_ATUAL + AGO_DEMANDA_ATUAL + SET_DEMANDA_ATUAL
        TRI04_DEMANDA_ATUAL = OUT_DEMANDA_ATUAL + NOV_DEMANDA_ATUAL + DEZ_DEMANDA_ATUAL
        TOTAL_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + TRI02_DEMANDA_ATUAL + TRI03_DEMANDA_ATUAL + TRI04_DEMANDA_ATUAL

        If MES_ATUAL = 1 Then YTD_DEMANDA_ATUAL = 0
        If MES_ATUAL = 2 Then YTD_DEMANDA_ATUAL = JAN_DEMANDA_ATUAL
        If MES_ATUAL = 3 Then YTD_DEMANDA_ATUAL = JAN_DEMANDA_ATUAL + FEV_DEMANDA_ATUAL
        If MES_ATUAL = 4 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL
        If MES_ATUAL = 5 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + ABR_DEMANDA_ATUAL
        If MES_ATUAL = 6 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + +ABR_DEMANDA_ATUAL + MAI_DEMANDA_ATUAL
        If MES_ATUAL = 7 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + TRI02_DEMANDA_ATUAL
        If MES_ATUAL = 8 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + TRI02_DEMANDA_ATUAL + JUL_DEMANDA_ATUAL
        If MES_ATUAL = 9 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + TRI02_DEMANDA_ATUAL + JUL_DEMANDA_ATUAL + AGO_DEMANDA_ATUAL
        If MES_ATUAL = 10 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + TRI02_DEMANDA_ATUAL + TRI03_DEMANDA_ATUAL
        If MES_ATUAL = 11 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + TRI02_DEMANDA_ATUAL + TRI03_DEMANDA_ATUAL + OUT_DEMANDA_ATUAL
        If MES_ATUAL = 12 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + TRI02_DEMANDA_ATUAL + TRI03_DEMANDA_ATUAL + OUT_DEMANDA_ATUAL + NOV_DEMANDA_ATUAL

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow

        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        rw.BorderWidth = 1
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1


    End Sub
    Private Sub Linha_Bombas_Atual(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        If COD_GRUPO_BOMBA = 0 Then Exit Sub
        'RECUPERA INFORMAÇÕES
        JAN_BOMBAS_ATUAL = 0
        FEV_BOMBAS_ATUAL = 0
        MAR_BOMBAS_ATUAL = 0
        ABR_BOMBAS_ATUAL = 0
        MAI_BOMBAS_ATUAL = 0
        JUN_BOMBAS_ATUAL = 0
        JUL_BOMBAS_ATUAL = 0
        AGO_BOMBAS_ATUAL = 0
        SET_BOMBAS_ATUAL = 0
        OUT_BOMBAS_ATUAL = 0
        NOV_BOMBAS_ATUAL = 0
        DEZ_BOMBAS_ATUAL = 0
        TRI01_BOMBAS_ATUAL = 0
        TRI02_BOMBAS_ATUAL = 0
        TRI03_BOMBAS_ATUAL = 0
        TRI04_BOMBAS_ATUAL = 0
        TOTAL_BOMBAS_ATUAL = 0
        YTD_BOMBAS_ATUAL = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_BOMBAS_MOVIMENTO_MES_FINAL "
        sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (CNPJ_ESTABELECIMENTO = " & CNPJ & ") AND (COD_GRUPO_BOMBAS = '" & COD_GRUPO_BOMBA & "') AND (TIPO_MOVIMENTO = 'BOMBAS')"


        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_BOMBAS_ATUAL = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_BOMBAS_ATUAL = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_BOMBAS_ATUAL = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_BOMBAS_ATUAL = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_BOMBAS_ATUAL = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_BOMBAS_ATUAL = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_BOMBAS_ATUAL = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_BOMBAS_ATUAL = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_BOMBAS_ATUAL = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_BOMBAS_ATUAL = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_BOMBAS_ATUAL = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_BOMBAS_ATUAL = dtr("DEZ")
        End If
        dtr.Close()

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JAN_BOMBAS_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FEV_BOMBAS_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAR_BOMBAS_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ABR_BOMBAS_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAI_BOMBAS_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUN_BOMBAS_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUL_BOMBAS_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = AGO_BOMBAS_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = SET_BOMBAS_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = OUT_BOMBAS_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = NOV_BOMBAS_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = DEZ_BOMBAS_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro


    End Sub
    Private Sub Linha_Bombas_Passado(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        If COD_GRUPO_BOMBA = 0 Then Exit Sub
        'RECUPERA INFORMAÇÕES
        JAN_BOMBAS_PASSADO = 0
        FEV_BOMBAS_PASSADO = 0
        MAR_BOMBAS_PASSADO = 0
        ABR_BOMBAS_PASSADO = 0
        MAI_BOMBAS_PASSADO = 0
        JUN_BOMBAS_PASSADO = 0
        JUL_BOMBAS_PASSADO = 0
        AGO_BOMBAS_PASSADO = 0
        SET_BOMBAS_PASSADO = 0
        OUT_BOMBAS_PASSADO = 0
        NOV_BOMBAS_PASSADO = 0
        DEZ_BOMBAS_PASSADO = 0
        TRI01_BOMBAS_PASSADO = 0
        TRI02_BOMBAS_PASSADO = 0
        TRI03_BOMBAS_PASSADO = 0
        TRI04_BOMBAS_PASSADO = 0
        TOTAL_BOMBAS_PASSADO = 0
        YTD_BOMBAS_PASSADO = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_BOMBAS_MOVIMENTO_MES_FINAL "
        sql = sql & "WHERE (ANO = " & ANO_PASSADO & ") AND (CNPJ_ESTABELECIMENTO = " & CNPJ & ") AND (COD_GRUPO_BOMBAS = '" & COD_GRUPO_BOMBA & "') AND (TIPO_MOVIMENTO = 'BOMBAS')"


        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_BOMBAS_PASSADO = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_BOMBAS_PASSADO = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_BOMBAS_PASSADO = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_BOMBAS_PASSADO = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_BOMBAS_PASSADO = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_BOMBAS_PASSADO = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_BOMBAS_PASSADO = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_BOMBAS_PASSADO = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_BOMBAS_PASSADO = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_BOMBAS_PASSADO = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_BOMBAS_PASSADO = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_BOMBAS_PASSADO = dtr("DEZ")
        End If
        dtr.Close()

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JAN_BOMBAS_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FEV_BOMBAS_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAR_BOMBAS_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ABR_BOMBAS_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAI_BOMBAS_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUN_BOMBAS_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUL_BOMBAS_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = AGO_BOMBAS_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = SET_BOMBAS_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = OUT_BOMBAS_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = NOV_BOMBAS_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = DEZ_BOMBAS_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro


    End Sub
    Private Sub Linha_Bombas_Representante_Atual(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        If COD_GRUPO_BOMBA = 0 Then Exit Sub
        'RECUPERA INFORMAÇÕES
        JAN_BOMBAS_REP_ATUAL = 0
        FEV_BOMBAS_REP_ATUAL = 0
        MAR_BOMBAS_REP_ATUAL = 0
        ABR_BOMBAS_REP_ATUAL = 0
        MAI_BOMBAS_REP_ATUAL = 0
        JUN_BOMBAS_REP_ATUAL = 0
        JUL_BOMBAS_REP_ATUAL = 0
        AGO_BOMBAS_REP_ATUAL = 0
        SET_BOMBAS_REP_ATUAL = 0
        OUT_BOMBAS_REP_ATUAL = 0
        NOV_BOMBAS_REP_ATUAL = 0
        DEZ_BOMBAS_REP_ATUAL = 0
        TRI01_BOMBAS_REP_ATUAL = 0
        TRI02_BOMBAS_REP_ATUAL = 0
        TRI03_BOMBAS_REP_ATUAL = 0
        TRI04_BOMBAS_REP_ATUAL = 0
        TOTAL_BOMBAS_REP_ATUAL = 0
        YTD_BOMBAS_REP_ATUAL = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_BOMBAS_INVENTARIO_REPRESENTANTE "
        sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (CNPJ = " & CNPJ & ") AND (COD_GRUPO_BOMBA = '" & COD_GRUPO_BOMBA & "')"


        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_BOMBAS_REP_ATUAL = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_BOMBAS_REP_ATUAL = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_BOMBAS_REP_ATUAL = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_BOMBAS_REP_ATUAL = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_BOMBAS_REP_ATUAL = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_BOMBAS_REP_ATUAL = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_BOMBAS_REP_ATUAL = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_BOMBAS_REP_ATUAL = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_BOMBAS_REP_ATUAL = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_BOMBAS_REP_ATUAL = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_BOMBAS_REP_ATUAL = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_BOMBAS_REP_ATUAL = dtr("DEZ")
        End If
        dtr.Close()

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JAN_BOMBAS_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FEV_BOMBAS_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAR_BOMBAS_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ABR_BOMBAS_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAI_BOMBAS_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUN_BOMBAS_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUL_BOMBAS_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = AGO_BOMBAS_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = SET_BOMBAS_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = OUT_BOMBAS_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = NOV_BOMBAS_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = DEZ_BOMBAS_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro


    End Sub
    Private Sub Linha_Bombas_Representante_Passado(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        If COD_GRUPO_BOMBA = 0 Then Exit Sub
        'RECUPERA INFORMAÇÕES
        JAN_BOMBAS_REP_PASSADO = 0
        FEV_BOMBAS_REP_PASSADO = 0
        MAR_BOMBAS_REP_PASSADO = 0
        ABR_BOMBAS_REP_PASSADO = 0
        MAI_BOMBAS_REP_PASSADO = 0
        JUN_BOMBAS_REP_PASSADO = 0
        JUL_BOMBAS_REP_PASSADO = 0
        AGO_BOMBAS_REP_PASSADO = 0
        SET_BOMBAS_REP_PASSADO = 0
        OUT_BOMBAS_REP_PASSADO = 0
        NOV_BOMBAS_REP_PASSADO = 0
        DEZ_BOMBAS_REP_PASSADO = 0
        TRI01_BOMBAS_REP_PASSADO = 0
        TRI02_BOMBAS_REP_PASSADO = 0
        TRI03_BOMBAS_REP_PASSADO = 0
        TRI04_BOMBAS_REP_PASSADO = 0
        TOTAL_BOMBAS_REP_PASSADO = 0
        YTD_BOMBAS_REP_PASSADO = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_BOMBAS_INVENTARIO_REPRESENTANTE "
        sql = sql & "WHERE (ANO = " & ANO_PASSADO & ") AND (CNPJ = " & CNPJ & ") AND (COD_GRUPO_BOMBA = '" & COD_GRUPO_BOMBA & "')"


        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_BOMBAS_REP_PASSADO = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_BOMBAS_REP_PASSADO = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_BOMBAS_REP_PASSADO = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_BOMBAS_REP_PASSADO = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_BOMBAS_REP_PASSADO = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_BOMBAS_REP_PASSADO = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_BOMBAS_REP_PASSADO = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_BOMBAS_REP_PASSADO = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_BOMBAS_REP_PASSADO = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_BOMBAS_REP_PASSADO = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_BOMBAS_REP_PASSADO = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_BOMBAS_REP_PASSADO = dtr("DEZ")
        End If
        dtr.Close()

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JAN_BOMBAS_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FEV_BOMBAS_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAR_BOMBAS_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ABR_BOMBAS_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAI_BOMBAS_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUN_BOMBAS_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUL_BOMBAS_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = AGO_BOMBAS_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = SET_BOMBAS_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = OUT_BOMBAS_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = NOV_BOMBAS_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = DEZ_BOMBAS_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro


    End Sub
    Private Sub Linha_Bombas_Produtividade_Passado(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        If COD_GRUPO_BOMBA = 0 Then Exit Sub
        'RECUPERA INFORMAÇÕES
        JAN_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        FEV_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        MAR_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        ABR_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        MAI_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        JUN_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        JUL_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        AGO_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        SET_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        OUT_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        NOV_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        DEZ_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        TRI01_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        TRI02_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        TRI03_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        TRI04_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        TOTAL_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        YTD_BOMBAS_PRODUTIVIDADE_PASSADO = 0


        If JAN_BOMBAS_PASSADO = 0 Then
            JAN_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        Else
            If JAN_DEMANDA_PASSADO = 0 Then
                JAN_BOMBAS_PRODUTIVIDADE_PASSADO = 0
            Else
                JAN_BOMBAS_PRODUTIVIDADE_PASSADO = JAN_DEMANDA_PASSADO / JAN_BOMBAS_PASSADO
            End If
        End If

        If FEV_BOMBAS_PASSADO = 0 Then
            FEV_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        Else
            If FEV_DEMANDA_PASSADO = 0 Then
                FEV_BOMBAS_PRODUTIVIDADE_PASSADO = 0
            Else
                FEV_BOMBAS_PRODUTIVIDADE_PASSADO = FEV_DEMANDA_PASSADO / FEV_BOMBAS_PASSADO
            End If
        End If

        If MAR_BOMBAS_PASSADO = 0 Then
            MAR_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        Else
            If MAR_DEMANDA_PASSADO = 0 Then
                MAR_BOMBAS_PRODUTIVIDADE_PASSADO = 0
            Else
                MAR_BOMBAS_PRODUTIVIDADE_PASSADO = MAR_DEMANDA_PASSADO / MAR_BOMBAS_PASSADO
            End If
        End If

        If ABR_BOMBAS_PASSADO = 0 Then
            ABR_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        Else
            If ABR_DEMANDA_PASSADO = 0 Then
                ABR_BOMBAS_PRODUTIVIDADE_PASSADO = 0
            Else
                ABR_BOMBAS_PRODUTIVIDADE_PASSADO = ABR_DEMANDA_PASSADO / ABR_BOMBAS_PASSADO
            End If
        End If

        If MAI_BOMBAS_PASSADO = 0 Then
            MAI_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        Else
            If MAI_DEMANDA_PASSADO = 0 Then
                MAI_BOMBAS_PRODUTIVIDADE_PASSADO = 0
            Else
                MAI_BOMBAS_PRODUTIVIDADE_PASSADO = MAI_DEMANDA_PASSADO / MAI_BOMBAS_PASSADO
            End If
        End If

        If JUN_BOMBAS_PASSADO = 0 Then
            JUN_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        Else
            If JUN_DEMANDA_PASSADO = 0 Then
                JUN_BOMBAS_PRODUTIVIDADE_PASSADO = 0
            Else
                JUN_BOMBAS_PRODUTIVIDADE_PASSADO = JUN_DEMANDA_PASSADO / JUN_BOMBAS_PASSADO
            End If
        End If

        If JUL_BOMBAS_PASSADO = 0 Then
            JUL_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        Else
            If JUL_DEMANDA_PASSADO = 0 Then
                JUL_BOMBAS_PRODUTIVIDADE_PASSADO = 0
            Else
                JUL_BOMBAS_PRODUTIVIDADE_PASSADO = JUL_DEMANDA_PASSADO / JUL_BOMBAS_PASSADO
            End If
        End If

        If AGO_BOMBAS_PASSADO = 0 Then
            AGO_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        Else
            If AGO_DEMANDA_PASSADO = 0 Then
                AGO_BOMBAS_PRODUTIVIDADE_PASSADO = 0
            Else
                AGO_BOMBAS_PRODUTIVIDADE_PASSADO = AGO_DEMANDA_PASSADO / AGO_BOMBAS_PASSADO
            End If
        End If

        If SET_BOMBAS_PASSADO = 0 Then
            SET_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        Else
            If SET_DEMANDA_PASSADO = 0 Then
                SET_BOMBAS_PRODUTIVIDADE_PASSADO = 0
            Else
                SET_BOMBAS_PRODUTIVIDADE_PASSADO = SET_DEMANDA_PASSADO / SET_BOMBAS_PASSADO
            End If
        End If

        If OUT_BOMBAS_PASSADO = 0 Then
            OUT_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        Else
            If OUT_DEMANDA_PASSADO = 0 Then
                OUT_BOMBAS_PRODUTIVIDADE_PASSADO = 0
            Else
                OUT_BOMBAS_PRODUTIVIDADE_PASSADO = OUT_DEMANDA_PASSADO / OUT_BOMBAS_PASSADO
            End If
        End If

        If NOV_BOMBAS_PASSADO = 0 Then
            NOV_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        Else
            If NOV_DEMANDA_PASSADO = 0 Then
                NOV_BOMBAS_PRODUTIVIDADE_PASSADO = 0
            Else
                NOV_BOMBAS_PRODUTIVIDADE_PASSADO = NOV_DEMANDA_PASSADO / NOV_BOMBAS_PASSADO
            End If
        End If

        If DEZ_BOMBAS_PASSADO = 0 Then
            DEZ_BOMBAS_PRODUTIVIDADE_PASSADO = 0
        Else
            If DEZ_DEMANDA_PASSADO = 0 Then
                DEZ_BOMBAS_PRODUTIVIDADE_PASSADO = 0
            Else
                DEZ_BOMBAS_PRODUTIVIDADE_PASSADO = DEZ_DEMANDA_PASSADO / DEZ_BOMBAS_PASSADO
            End If
        End If

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JAN_BOMBAS_PRODUTIVIDADE_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FEV_BOMBAS_PRODUTIVIDADE_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAR_BOMBAS_PRODUTIVIDADE_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ABR_BOMBAS_PRODUTIVIDADE_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAI_BOMBAS_PRODUTIVIDADE_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUN_BOMBAS_PRODUTIVIDADE_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUL_BOMBAS_PRODUTIVIDADE_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = AGO_BOMBAS_PRODUTIVIDADE_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = SET_BOMBAS_PRODUTIVIDADE_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = OUT_BOMBAS_PRODUTIVIDADE_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = NOV_BOMBAS_PRODUTIVIDADE_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = DEZ_BOMBAS_PRODUTIVIDADE_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

    End Sub
    Private Sub Linha_Bombas_Produtividade_Atual(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        If COD_GRUPO_BOMBA = 0 Then Exit Sub
        'RECUPERA INFORMAÇÕES
        JAN_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        FEV_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        MAR_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        ABR_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        MAI_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        JUN_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        JUL_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        AGO_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        SET_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        OUT_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        NOV_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        DEZ_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        TRI01_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        TRI02_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        TRI03_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        TRI04_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        TOTAL_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        YTD_BOMBAS_PRODUTIVIDADE_ATUAL = 0


        If JAN_BOMBAS_ATUAL = 0 Then
            JAN_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        Else
            If JAN_DEMANDA_PASSADO = 0 Then
                JAN_BOMBAS_PRODUTIVIDADE_ATUAL = 0
            Else
                JAN_BOMBAS_PRODUTIVIDADE_ATUAL = JAN_DEMANDA_PASSADO / JAN_BOMBAS_ATUAL
            End If
        End If

        If FEV_BOMBAS_ATUAL = 0 Then
            FEV_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        Else
            If FEV_DEMANDA_PASSADO = 0 Then
                FEV_BOMBAS_PRODUTIVIDADE_ATUAL = 0
            Else
                FEV_BOMBAS_PRODUTIVIDADE_ATUAL = FEV_DEMANDA_PASSADO / FEV_BOMBAS_ATUAL
            End If
        End If

        If MAR_BOMBAS_ATUAL = 0 Then
            MAR_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        Else
            If MAR_DEMANDA_PASSADO = 0 Then
                MAR_BOMBAS_PRODUTIVIDADE_ATUAL = 0
            Else
                MAR_BOMBAS_PRODUTIVIDADE_ATUAL = MAR_DEMANDA_PASSADO / MAR_BOMBAS_ATUAL
            End If
        End If

        If ABR_BOMBAS_ATUAL = 0 Then
            ABR_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        Else
            If ABR_DEMANDA_PASSADO = 0 Then
                ABR_BOMBAS_PRODUTIVIDADE_ATUAL = 0
            Else
                ABR_BOMBAS_PRODUTIVIDADE_ATUAL = ABR_DEMANDA_PASSADO / ABR_BOMBAS_ATUAL
            End If
        End If

        If MAI_BOMBAS_ATUAL = 0 Then
            MAI_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        Else
            If MAI_DEMANDA_PASSADO = 0 Then
                MAI_BOMBAS_PRODUTIVIDADE_ATUAL = 0
            Else
                MAI_BOMBAS_PRODUTIVIDADE_ATUAL = MAI_DEMANDA_PASSADO / MAI_BOMBAS_ATUAL
            End If
        End If

        If JUN_BOMBAS_ATUAL = 0 Then
            JUN_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        Else
            If JUN_DEMANDA_PASSADO = 0 Then
                JUN_BOMBAS_PRODUTIVIDADE_ATUAL = 0
            Else
                JUN_BOMBAS_PRODUTIVIDADE_ATUAL = JUN_DEMANDA_PASSADO / JUN_BOMBAS_ATUAL
            End If
        End If

        If JUL_BOMBAS_ATUAL = 0 Then
            JUL_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        Else
            If JUL_DEMANDA_PASSADO = 0 Then
                JUL_BOMBAS_PRODUTIVIDADE_ATUAL = 0
            Else
                JUL_BOMBAS_PRODUTIVIDADE_ATUAL = JUL_DEMANDA_PASSADO / JUL_BOMBAS_ATUAL
            End If
        End If

        If AGO_BOMBAS_ATUAL = 0 Then
            AGO_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        Else
            If AGO_DEMANDA_PASSADO = 0 Then
                AGO_BOMBAS_PRODUTIVIDADE_ATUAL = 0
            Else
                AGO_BOMBAS_PRODUTIVIDADE_ATUAL = AGO_DEMANDA_PASSADO / AGO_BOMBAS_ATUAL
            End If
        End If

        If SET_BOMBAS_ATUAL = 0 Then
            SET_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        Else
            If SET_DEMANDA_PASSADO = 0 Then
                SET_BOMBAS_PRODUTIVIDADE_ATUAL = 0
            Else
                SET_BOMBAS_PRODUTIVIDADE_ATUAL = SET_DEMANDA_PASSADO / SET_BOMBAS_ATUAL
            End If
        End If

        If OUT_BOMBAS_ATUAL = 0 Then
            OUT_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        Else
            If OUT_DEMANDA_PASSADO = 0 Then
                OUT_BOMBAS_PRODUTIVIDADE_ATUAL = 0
            Else
                OUT_BOMBAS_PRODUTIVIDADE_ATUAL = OUT_DEMANDA_PASSADO / OUT_BOMBAS_ATUAL
            End If
        End If

        If NOV_BOMBAS_ATUAL = 0 Then
            NOV_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        Else
            If NOV_DEMANDA_PASSADO = 0 Then
                NOV_BOMBAS_PRODUTIVIDADE_ATUAL = 0
            Else
                NOV_BOMBAS_PRODUTIVIDADE_ATUAL = NOV_DEMANDA_PASSADO / NOV_BOMBAS_ATUAL
            End If
        End If

        If DEZ_BOMBAS_ATUAL = 0 Then
            DEZ_BOMBAS_PRODUTIVIDADE_ATUAL = 0
        Else
            If DEZ_DEMANDA_PASSADO = 0 Then
                DEZ_BOMBAS_PRODUTIVIDADE_ATUAL = 0
            Else
                DEZ_BOMBAS_PRODUTIVIDADE_ATUAL = DEZ_DEMANDA_PASSADO / DEZ_BOMBAS_ATUAL
            End If
        End If

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JAN_BOMBAS_PRODUTIVIDADE_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FEV_BOMBAS_PRODUTIVIDADE_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAR_BOMBAS_PRODUTIVIDADE_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ABR_BOMBAS_PRODUTIVIDADE_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAI_BOMBAS_PRODUTIVIDADE_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUN_BOMBAS_PRODUTIVIDADE_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUL_BOMBAS_PRODUTIVIDADE_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = AGO_BOMBAS_PRODUTIVIDADE_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = SET_BOMBAS_PRODUTIVIDADE_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = OUT_BOMBAS_PRODUTIVIDADE_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = NOV_BOMBAS_PRODUTIVIDADE_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = DEZ_BOMBAS_PRODUTIVIDADE_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

    End Sub

    Private Sub Linha_Bombas_Produtividade_REP_Passado(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        If COD_GRUPO_BOMBA = 0 Then Exit Sub
        'RECUPERA INFORMAÇÕES
        JAN_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        FEV_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        MAR_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        ABR_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        MAI_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        JUN_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        JUL_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        AGO_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        SET_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        OUT_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        NOV_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        DEZ_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        TRI01_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        TRI02_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        TRI03_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        TRI04_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        TOTAL_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        YTD_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0

        If JAN_BOMBAS_REP_PASSADO = 0 Then
            JAN_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        Else
            If JAN_DEMANDA_PASSADO = 0 Then
                JAN_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
            Else
                JAN_BOMBAS_PRODUTIVIDADE_REP_PASSADO = JAN_DEMANDA_PASSADO / JAN_BOMBAS_REP_PASSADO
            End If
        End If

        If FEV_BOMBAS_REP_PASSADO = 0 Then
            FEV_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        Else
            If FEV_DEMANDA_PASSADO = 0 Then
                FEV_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
            Else
                FEV_BOMBAS_PRODUTIVIDADE_REP_PASSADO = FEV_DEMANDA_PASSADO / FEV_BOMBAS_REP_PASSADO
            End If
        End If

        If MAR_BOMBAS_REP_PASSADO = 0 Then
            MAR_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        Else
            If MAR_DEMANDA_PASSADO = 0 Then
                MAR_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
            Else
                MAR_BOMBAS_PRODUTIVIDADE_REP_PASSADO = MAR_DEMANDA_PASSADO / MAR_BOMBAS_REP_PASSADO
            End If
        End If

        If ABR_BOMBAS_REP_PASSADO = 0 Then
            ABR_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        Else
            If ABR_DEMANDA_PASSADO = 0 Then
                ABR_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
            Else
                ABR_BOMBAS_PRODUTIVIDADE_REP_PASSADO = ABR_DEMANDA_PASSADO / ABR_BOMBAS_REP_PASSADO
            End If
        End If

        If MAI_BOMBAS_REP_PASSADO = 0 Then
            MAI_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        Else
            If MAI_DEMANDA_PASSADO = 0 Then
                MAI_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
            Else
                MAI_BOMBAS_PRODUTIVIDADE_REP_PASSADO = MAI_DEMANDA_PASSADO / MAI_BOMBAS_REP_PASSADO
            End If
        End If

        If JUN_BOMBAS_REP_PASSADO = 0 Then
            JUN_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        Else
            If JUN_DEMANDA_PASSADO = 0 Then
                JUN_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
            Else
                JUN_BOMBAS_PRODUTIVIDADE_REP_PASSADO = JUN_DEMANDA_PASSADO / JUN_BOMBAS_REP_PASSADO
            End If
        End If

        If JUL_BOMBAS_REP_PASSADO = 0 Then
            JUL_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        Else
            If JUL_DEMANDA_PASSADO = 0 Then
                JUL_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
            Else
                JUL_BOMBAS_PRODUTIVIDADE_REP_PASSADO = JUL_DEMANDA_PASSADO / JUL_BOMBAS_REP_PASSADO
            End If
        End If

        If AGO_BOMBAS_REP_PASSADO = 0 Then
            AGO_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        Else
            If AGO_DEMANDA_PASSADO = 0 Then
                AGO_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
            Else
                AGO_BOMBAS_PRODUTIVIDADE_REP_PASSADO = AGO_DEMANDA_PASSADO / AGO_BOMBAS_REP_PASSADO
            End If
        End If

        If SET_BOMBAS_REP_PASSADO = 0 Then
            SET_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        Else
            If SET_DEMANDA_PASSADO = 0 Then
                SET_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
            Else
                SET_BOMBAS_PRODUTIVIDADE_REP_PASSADO = SET_DEMANDA_PASSADO / SET_BOMBAS_REP_PASSADO
            End If
        End If

        If OUT_BOMBAS_REP_PASSADO = 0 Then
            OUT_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        Else
            If OUT_DEMANDA_PASSADO = 0 Then
                OUT_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
            Else
                OUT_BOMBAS_PRODUTIVIDADE_REP_PASSADO = OUT_DEMANDA_PASSADO / OUT_BOMBAS_REP_PASSADO
            End If
        End If

        If NOV_BOMBAS_REP_PASSADO = 0 Then
            NOV_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        Else
            If NOV_DEMANDA_PASSADO = 0 Then
                NOV_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
            Else
                NOV_BOMBAS_PRODUTIVIDADE_REP_PASSADO = NOV_DEMANDA_PASSADO / NOV_BOMBAS_REP_PASSADO
            End If
        End If

        If DEZ_BOMBAS_REP_PASSADO = 0 Then
            DEZ_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
        Else
            If DEZ_DEMANDA_PASSADO = 0 Then
                DEZ_BOMBAS_PRODUTIVIDADE_REP_PASSADO = 0
            Else
                DEZ_BOMBAS_PRODUTIVIDADE_REP_PASSADO = DEZ_DEMANDA_PASSADO / DEZ_BOMBAS_REP_PASSADO
            End If
        End If

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JAN_BOMBAS_PRODUTIVIDADE_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FEV_BOMBAS_PRODUTIVIDADE_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAR_BOMBAS_PRODUTIVIDADE_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ABR_BOMBAS_PRODUTIVIDADE_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAI_BOMBAS_PRODUTIVIDADE_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUN_BOMBAS_PRODUTIVIDADE_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUL_BOMBAS_PRODUTIVIDADE_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = AGO_BOMBAS_PRODUTIVIDADE_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = SET_BOMBAS_PRODUTIVIDADE_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = OUT_BOMBAS_PRODUTIVIDADE_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = NOV_BOMBAS_PRODUTIVIDADE_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = DEZ_BOMBAS_PRODUTIVIDADE_REP_PASSADO
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

    End Sub
    Private Sub Linha_Bombas_Produtividade_REP_Atual(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        If COD_GRUPO_BOMBA = 0 Then Exit Sub
        'RECUPERA INFORMAÇÕES
        JAN_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        FEV_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        MAR_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        ABR_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        MAI_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        JUN_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        JUL_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        AGO_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        SET_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        OUT_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        NOV_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        DEZ_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        TRI01_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        TRI02_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        TRI03_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        TRI04_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        TOTAL_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        YTD_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0

        If JAN_BOMBAS_REP_ATUAL = 0 Then
            JAN_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        Else
            If JAN_DEMANDA_PASSADO = 0 Then
                JAN_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
            Else
                JAN_BOMBAS_PRODUTIVIDADE_REP_ATUAL = JAN_DEMANDA_PASSADO / JAN_BOMBAS_REP_ATUAL
            End If
        End If

        If FEV_BOMBAS_REP_ATUAL = 0 Then
            FEV_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        Else
            If FEV_DEMANDA_PASSADO = 0 Then
                FEV_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
            Else
                FEV_BOMBAS_PRODUTIVIDADE_REP_ATUAL = FEV_DEMANDA_PASSADO / FEV_BOMBAS_REP_ATUAL
            End If
        End If

        If MAR_BOMBAS_REP_ATUAL = 0 Then
            MAR_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        Else
            If MAR_DEMANDA_PASSADO = 0 Then
                MAR_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
            Else
                MAR_BOMBAS_PRODUTIVIDADE_REP_ATUAL = MAR_DEMANDA_PASSADO / MAR_BOMBAS_REP_ATUAL
            End If
        End If

        If ABR_BOMBAS_REP_ATUAL = 0 Then
            ABR_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        Else
            If ABR_DEMANDA_PASSADO = 0 Then
                ABR_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
            Else
                ABR_BOMBAS_PRODUTIVIDADE_REP_ATUAL = ABR_DEMANDA_PASSADO / ABR_BOMBAS_REP_ATUAL
            End If
        End If

        If MAI_BOMBAS_REP_ATUAL = 0 Then
            MAI_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        Else
            If MAI_DEMANDA_PASSADO = 0 Then
                MAI_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
            Else
                MAI_BOMBAS_PRODUTIVIDADE_REP_ATUAL = MAI_DEMANDA_PASSADO / MAI_BOMBAS_REP_ATUAL
            End If
        End If

        If JUN_BOMBAS_REP_ATUAL = 0 Then
            JUN_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        Else
            If JUN_DEMANDA_PASSADO = 0 Then
                JUN_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
            Else
                JUN_BOMBAS_PRODUTIVIDADE_REP_ATUAL = JUN_DEMANDA_PASSADO / JUN_BOMBAS_REP_ATUAL
            End If
        End If

        If JUL_BOMBAS_REP_ATUAL = 0 Then
            JUL_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        Else
            If JUL_DEMANDA_PASSADO = 0 Then
                JUL_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
            Else
                JUL_BOMBAS_PRODUTIVIDADE_REP_ATUAL = JUL_DEMANDA_PASSADO / JUL_BOMBAS_REP_ATUAL
            End If
        End If

        If AGO_BOMBAS_REP_ATUAL = 0 Then
            AGO_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        Else
            If AGO_DEMANDA_PASSADO = 0 Then
                AGO_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
            Else
                AGO_BOMBAS_PRODUTIVIDADE_REP_ATUAL = AGO_DEMANDA_PASSADO / AGO_BOMBAS_REP_ATUAL
            End If
        End If

        If SET_BOMBAS_REP_ATUAL = 0 Then
            SET_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        Else
            If SET_DEMANDA_PASSADO = 0 Then
                SET_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
            Else
                SET_BOMBAS_PRODUTIVIDADE_REP_ATUAL = SET_DEMANDA_PASSADO / SET_BOMBAS_REP_ATUAL
            End If
        End If

        If OUT_BOMBAS_REP_ATUAL = 0 Then
            OUT_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        Else
            If OUT_DEMANDA_PASSADO = 0 Then
                OUT_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
            Else
                OUT_BOMBAS_PRODUTIVIDADE_REP_ATUAL = OUT_DEMANDA_PASSADO / OUT_BOMBAS_REP_ATUAL
            End If
        End If

        If NOV_BOMBAS_REP_ATUAL = 0 Then
            NOV_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        Else
            If NOV_DEMANDA_PASSADO = 0 Then
                NOV_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
            Else
                NOV_BOMBAS_PRODUTIVIDADE_REP_ATUAL = NOV_DEMANDA_PASSADO / NOV_BOMBAS_REP_ATUAL
            End If
        End If

        If DEZ_BOMBAS_REP_ATUAL = 0 Then
            DEZ_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
        Else
            If DEZ_DEMANDA_PASSADO = 0 Then
                DEZ_BOMBAS_PRODUTIVIDADE_REP_ATUAL = 0
            Else
                DEZ_BOMBAS_PRODUTIVIDADE_REP_ATUAL = DEZ_DEMANDA_PASSADO / DEZ_BOMBAS_REP_ATUAL
            End If
        End If

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JAN_BOMBAS_PRODUTIVIDADE_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FEV_BOMBAS_PRODUTIVIDADE_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAR_BOMBAS_PRODUTIVIDADE_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ABR_BOMBAS_PRODUTIVIDADE_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAI_BOMBAS_PRODUTIVIDADE_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUN_BOMBAS_PRODUTIVIDADE_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUL_BOMBAS_PRODUTIVIDADE_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = AGO_BOMBAS_PRODUTIVIDADE_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = SET_BOMBAS_PRODUTIVIDADE_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = OUT_BOMBAS_PRODUTIVIDADE_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = NOV_BOMBAS_PRODUTIVIDADE_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = DEZ_BOMBAS_PRODUTIVIDADE_REP_ATUAL
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

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
