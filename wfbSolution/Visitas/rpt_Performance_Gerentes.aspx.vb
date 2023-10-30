Imports System.Math
Partial Class rpt_Performance_Gerentes
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "rpt_Performance_Reps.aspx"

    Dim cnn_Representantes As New System.Data.SqlClient.SqlConnection
    Dim cmd_Representantes As New System.Data.SqlClient.SqlCommand
    Dim dtr_Representantes As System.Data.SqlClient.SqlDataReader
    Dim sql_Representantes As String

    Dim cnn_Gerentes As New System.Data.SqlClient.SqlConnection
    Dim cmd_Gerentes As New System.Data.SqlClient.SqlCommand
    Dim dtr_Gerentes As System.Data.SqlClient.SqlDataReader
    Dim sql_Gerentes As String

    Dim cnn_Diretores As New System.Data.SqlClient.SqlConnection
    Dim cmd_Diretores As New System.Data.SqlClient.SqlCommand
    Dim dtr_Diretores As System.Data.SqlClient.SqlDataReader
    Dim sql_Diretores As String

    Dim cnn As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String

    Dim rw As TableRow
    Dim cel As TableCell

    Dim ANO_RETRASADO As Integer
    Dim ANO_PASSADO As Integer
    Dim ANO_ATUAL As Integer
    Dim MES_ATUAL As Integer
    Dim LINHA_PRODUTO As String
    Dim REPRESENTANTE As String
    Dim EMAIL_REPRESENTANTE As String
    Dim GERENTE As String
    Dim EMAIL_GERENTE As String
    Dim DIRETOR As String
    Dim EMAIL_DIRETOR As String

    Dim DEMANDA As Double
    Dim COTA As Double
    Dim COBERTURA As Double

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'verifica se existe sessão de login
        If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Default.aspx")

        'If Session("COD_PERFIL_LOGIN") = "0" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "1" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        'If Session("COD_PERFIL_LOGIN") = "2" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "3" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "4" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "5" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "6" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

        'ABRE CONEXÃO
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()
        cnn_Representantes.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn_Representantes.Open()
        cnn_Gerentes.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn_Gerentes.Open()
        cnn_Diretores.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn_Diretores.Open()

        'DEFINE VARIAVEIS
        ANO_ATUAL = 0
        ANO_ATUAL = Val(cmb_Ano.Text)
        If ANO_ATUAL = 0 Then ANO_ATUAL = Year(Now())
        ANO_PASSADO = ANO_ATUAL - 1
        ANO_RETRASADO = ANO_ATUAL - 2
        MES_ATUAL = Month(Now())

        Linha_Cabecalho("GERENTES NACIONAIS")
        Linha_Performance_Diretores(True)
        Linha_Vazia(30, "", True)
        Linha_Cabecalho("GERENTES REGIONAIS")
        Linha_Performance_Gerentes(True)
        Linha_Vazia(30, "", True)
        Linha_Cabecalho("REPRESENTANTES")
        Linha_Performance_Reps(True)
        Linha_Vazia(30, "", True)
    End Sub

    Private Sub Linha_Cabecalho(TITULO As String)
        Dim x As Integer
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
        cel.Text = "EDDS"
        If MES_ATUAL >= 1 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 1 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.ColumnSpan = 3

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "GEMSTAR"
        If MES_ATUAL >= 1 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 1 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.ColumnSpan = 3

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "ANNE/APM"
        If MES_ATUAL >= 1 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 1 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.ColumnSpan = 3

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "CLAVE"
        If MES_ATUAL >= 1 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 1 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.ColumnSpan = 3

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "RECEPTAL"
        If MES_ATUAL >= 1 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 1 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.ColumnSpan = 3

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "SUPERCATH"
        If MES_ATUAL >= 1 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 1 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.ColumnSpan = 3

        rw = New TableRow
        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Nome"
        If MES_ATUAL >= 1 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 1 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        For x = 1 To 6
            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "Demanda"
            If MES_ATUAL >= 1 Then cel.BackColor = Drawing.Color.Gainsboro
            If MES_ATUAL = 1 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
            cel.BorderStyle = BorderStyle.Solid
            cel.BorderColor = Drawing.Color.Silver
            cel.BorderWidth = 1

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "Cota"
            If MES_ATUAL >= 1 Then cel.BackColor = Drawing.Color.Gainsboro
            If MES_ATUAL = 1 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
            cel.BorderStyle = BorderStyle.Solid
            cel.BorderColor = Drawing.Color.Silver
            cel.BorderWidth = 1

            cel = New TableCell
            rw.Cells.Add(cel)
            cel.Text = "% Cob"
            If MES_ATUAL >= 1 Then cel.BackColor = Drawing.Color.Gainsboro
            If MES_ATUAL = 1 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
            cel.BorderStyle = BorderStyle.Solid
            cel.BorderColor = Drawing.Color.Silver
            cel.BorderWidth = 1
        Next
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

    Private Sub Linha_Performance_Diretores(Exibir As Boolean)

        sql_Diretores = "Select * From VIEW_USUARIOS Where COD_PERFIL = 1 Order By NOME"
        cmd_Diretores.Connection = cnn_Diretores
        cmd_Diretores.CommandText = sql_Diretores
        dtr_Diretores = cmd_Diretores.ExecuteReader

        If dtr_Diretores.HasRows Then

            Do While dtr_Diretores.Read
                DIRETOR = dtr_Diretores("NOME")
                EMAIL_DIRETOR = dtr_Diretores("EMAIL")
                'MONTA RELATORIO


                'INCLUI LINHA PARA O DIRETOR
                If Exibir = False Then Exit Sub
                rw = New TableRow

                rw.BorderColor = Drawing.Color.Silver
                rw.BackColor = Drawing.Color.Transparent
                rw.BorderWidth = 1
                tbl_Report.Rows.Add(rw)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = DIRETOR
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1
                cel.HorizontalAlign = HorizontalAlign.Left


                'EDDS
                LINHA_PRODUTO = "EQUIPOS EDDS"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_DIRETOR = '" & EMAIL_DIRETOR & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_DIRETOR = '" & EMAIL_DIRETOR & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1


                'GEMSTAR
                LINHA_PRODUTO = "EQUIPOS GEMSTAR"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_DIRETOR = '" & EMAIL_DIRETOR & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_DIRETOR = '" & EMAIL_DIRETOR & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1


                'ANNE/APM
                LINHA_PRODUTO = "ANNE/APM"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_DIRETOR = '" & EMAIL_DIRETOR & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_DIRETOR = '" & EMAIL_DIRETOR & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                'CLAVE
                LINHA_PRODUTO = "CLAVE"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_DIRETOR = '" & EMAIL_DIRETOR & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_DIRETOR = '" & EMAIL_DIRETOR & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1


                'RECEPTAL
                LINHA_PRODUTO = "RECEPTAL"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_DIRETOR = '" & EMAIL_DIRETOR & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_DIRETOR = '" & EMAIL_DIRETOR & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1


                'SUPERCATH
                LINHA_PRODUTO = "SUPERCATH"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_DIRETOR = '" & EMAIL_DIRETOR & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_DIRETOR = '" & EMAIL_DIRETOR & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

            Loop
            dtr_Diretores.Close()
        End If


    End Sub

    Private Sub Linha_Performance_Gerentes(Exibir As Boolean)

        sql_Gerentes = "Select * From VIEW_USUARIOS Where COD_PERFIL = 2 AND EMAIL = '" & Session("EMAIL_LOGIN") & "' Order By NOME"
        cmd_Gerentes.Connection = cnn_Gerentes
        cmd_Gerentes.CommandText = sql_Gerentes
        dtr_Gerentes = cmd_Gerentes.ExecuteReader

        If dtr_Gerentes.HasRows Then

            Do While dtr_Gerentes.Read
                GERENTE = dtr_Gerentes("NOME")
                EMAIL_GERENTE = dtr_Gerentes("EMAIL")
                'MONTA RELATORIO


                'INCLUI LINHA PARA O GERENTE
                If Exibir = False Then Exit Sub
                rw = New TableRow

                rw.BorderColor = Drawing.Color.Silver
                rw.BackColor = Drawing.Color.Transparent
                rw.BorderWidth = 1
                tbl_Report.Rows.Add(rw)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = GERENTE
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1
                cel.HorizontalAlign = HorizontalAlign.Left


                'EDDS
                LINHA_PRODUTO = "EQUIPOS EDDS"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_GERENTE = '" & EMAIL_GERENTE & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_GERENTE = '" & EMAIL_GERENTE & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1


                'GEMSTAR
                LINHA_PRODUTO = "EQUIPOS GEMSTAR"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_GERENTE = '" & EMAIL_GERENTE & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_GERENTE = '" & EMAIL_GERENTE & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1


                'ANNE/APM
                LINHA_PRODUTO = "ANNE/APM"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_GERENTE = '" & EMAIL_GERENTE & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_GERENTE = '" & EMAIL_GERENTE & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                'CLAVE
                LINHA_PRODUTO = "CLAVE"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_GERENTE = '" & EMAIL_GERENTE & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_GERENTE = '" & EMAIL_GERENTE & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1


                'RECEPTAL
                LINHA_PRODUTO = "RECEPTAL"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_GERENTE = '" & EMAIL_GERENTE & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_GERENTE = '" & EMAIL_GERENTE & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1


                'SUPERCATH
                LINHA_PRODUTO = "SUPERCATH"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_GERENTE = '" & EMAIL_GERENTE & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_GERENTE = '" & EMAIL_GERENTE & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

            Loop
            dtr_Gerentes.Close()
        End If


    End Sub

    Private Sub Linha_Performance_Reps(Exibir As Boolean)

        sql_Representantes = "Select * From VIEW_USUARIOS Where COD_PERFIL = 4 And EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' Order By NOME"
        cmd_Representantes.Connection = cnn_Representantes
        cmd_Representantes.CommandText = sql_Representantes
        dtr_Representantes = cmd_Representantes.ExecuteReader

        If dtr_Representantes.HasRows Then

            Do While dtr_Representantes.Read
                REPRESENTANTE = dtr_Representantes("NOME")
                EMAIL_REPRESENTANTE = dtr_Representantes("EMAIL")
                'MONTA RELATORIO


                'INCLUI LINHA PARA O REP
                If Exibir = False Then Exit Sub
                rw = New TableRow

                rw.BorderColor = Drawing.Color.Silver
                rw.BackColor = Drawing.Color.Transparent
                rw.BorderWidth = 1
                tbl_Report.Rows.Add(rw)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = REPRESENTANTE
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1
                cel.HorizontalAlign = HorizontalAlign.Left


                'EDDS
                LINHA_PRODUTO = "EQUIPOS EDDS"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_REPRESENTANTE = '" & EMAIL_REPRESENTANTE & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL = '" & EMAIL_REPRESENTANTE & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1


                'GEMSTAR
                LINHA_PRODUTO = "EQUIPOS GEMSTAR"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_REPRESENTANTE = '" & EMAIL_REPRESENTANTE & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL = '" & EMAIL_REPRESENTANTE & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1


                'ANNE/APM
                LINHA_PRODUTO = "ANNE/APM"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ")AND (EMAIL_REPRESENTANTE = '" & EMAIL_REPRESENTANTE & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL = '" & EMAIL_REPRESENTANTE & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                'CLAVE
                LINHA_PRODUTO = "CLAVE"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_REPRESENTANTE = '" & EMAIL_REPRESENTANTE & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL = '" & EMAIL_REPRESENTANTE & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1


                'RECEPTAL
                LINHA_PRODUTO = "RECEPTAL"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_REPRESENTANTE = '" & EMAIL_REPRESENTANTE & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL = '" & EMAIL_REPRESENTANTE & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1


                'SUPERCATH
                LINHA_PRODUTO = "SUPERCATH"
                DEMANDA = 0
                COTA = 0
                COBERTURA = 0

                'demanda
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS DEMANDA "
                sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_REPRESENTANTE = '" & EMAIL_REPRESENTANTE & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("DEMANDA"))) Then DEMANDA = dtr("DEMANDA")
                End If
                dtr.Close()

                'cota
                sql = ""
                sql = sql & "SELECT SUM([" & cmb_Mes.Text & "]) AS COTA "
                sql = sql & "FROM dbo.VIEW_COTAS "
                sql = sql & "WHERE (ANO = " & ANO_ATUAL & ")AND (EMAIL = '" & EMAIL_REPRESENTANTE & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                dtr.Read()
                If dtr.HasRows Then
                    If Not (IsDBNull(dtr("COTA"))) Then COTA = dtr("COTA")
                End If
                dtr.Close()

                'cobertura
                If COTA <> 0 Then COBERTURA = Round((DEMANDA / COTA) * 100, 2, MidpointRounding.AwayFromZero)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(DEMANDA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COTA, 0)
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = FormatNumber(COBERTURA, 2) & " %"
                If COBERTURA < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
                If COBERTURA > 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 255, 0)
                If COBERTURA >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
                If COBERTURA >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
                If COTA = 0 Then cel.BackColor = Drawing.Color.White
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.Silver
                cel.BorderWidth = 1

            Loop
            dtr_Representantes.Close()
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
