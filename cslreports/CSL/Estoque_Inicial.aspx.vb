
Partial Class Estoque_Inicial
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Estoque Inicial"
    Dim Titulo As String = "Estoque Inicial - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As String

    'variaveis da página
    Dim cnn As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String

    Dim cnn_Dst As New System.Data.SqlClient.SqlConnection
    Dim cmd_Dst As New System.Data.SqlClient.SqlCommand
    Dim dtr_Dst As System.Data.SqlClient.SqlDataReader
    Dim sql_Dst As String

    Dim cnn_Calc As New System.Data.SqlClient.SqlConnection
    Dim cmd_Calc As New System.Data.SqlClient.SqlCommand
    Dim dtr_Calc As System.Data.SqlClient.SqlDataReader
    Dim sql_Calc As String

    Dim cnn_vazios As New System.Data.SqlClient.SqlConnection
    Dim cmd_vazios As New System.Data.SqlClient.SqlCommand
    Dim dtr_vazios As System.Data.SqlClient.SqlDataReader
    Dim sql_vazios As String

    Dim sql_insert As String
    Dim sql_delete As String

    Dim PRODUTO As String
    Dim X As Integer
    Dim Y As Integer
    Dim ANO As Integer
    Dim rw As TableRow
    Dim cel As TableCell

    Dim Demanda As Integer
    Dim Venda As Integer
    Dim Estoque_Calculado As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = False 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = False 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = False 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = False 'Coordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = False 'Representante
        If Session("COD_PERFIL_LOGIN") = 10 Then Acesso = False 'Key Account
        If Session("COD_PERFIL_LOGIN") = 20 Then Acesso = False 'Distribuidor
        If Session("COD_PERFIL_LOGIN") = 30 Then Acesso = True 'Visitante (Para acesso do usuário do SAC)
        If Session("SISTEMA") = True Then Acesso = True 'Sistema

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
        'RECUPERA ANO INICIAL
        ANO = Year(Now())
    End Sub

    Public Sub Atualiza_Estoque_Vazio()
        Alert("Teste", False, "")
    End Sub
    Public Sub Atualiza_Estoque_Total()
        'ABRE CONEXÕES
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnSTR").ConnectionString
        cnn.Open()
        cnn_Dst.ConnectionString = ConfigurationManager.ConnectionStrings("cnnSTR").ConnectionString
        cnn_Dst.Open()
        cnn_Calc.ConnectionString = ConfigurationManager.ConnectionStrings("cnnSTR").ConnectionString
        cnn_Calc.Open()

        sql_delete = ""
        sql_delete = "DELETE FROM TBL_MOVIMENTO_ESTOQUE_INICIAL WHERE ANO = " & ANO + 1 & " AND GRUPO_DISTRIBUIDOR = 'TOTAL'"
        M.ExecutarSQL(sql_delete)
        Response.Write(sql_delete)

        sql_Dst = ""
        sql_Dst = "SELECT DISTINCT PRODUTO FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_GERAL_FISCAL_UN_OR WHERE ANO = " & ANO & " ORDER BY PRODUTO "
        cmd_Dst.Connection = cnn_Dst
        cmd_Dst.CommandText = sql_Dst
        dtr_Dst = cmd_Dst.ExecuteReader
        'Recupera produtos
        dtr_Dst.Read()
        Response.Write(sql_Dst)
        Do While dtr_Dst.Read
            Response.Write("1")
            PRODUTO = ""
            PRODUTO = dtr_Dst("Produto")
            sql = ""
            sql = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_GERAL_FISCAL_UN_OR WHERE TIPO = 'ESTOQUE UNIDADES ORIGINAL FISCAL' AND ANO = " & ANO & " AND PRODUTO = '" & PRODUTO & "'"
            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader
            dtr.Read()
            'Recupera linhas por totais e insere
            If dtr.HasRows Then
                Response.Write("2")
                'RECUPERA DEMANDA
                sql_Calc = ""
                sql_Calc = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_GERAL_FISCAL_UN_OR WHERE TIPO = 'DEMANDA UNIDADES ORIGINAL FISCAL' AND ANO = " & ANO & " AND PRODUTO = '" & PRODUTO & "'"

                cmd_Calc.Connection = cnn_Calc
                cmd_Calc.CommandText = sql_Calc
                dtr_Calc = cmd_Calc.ExecuteReader
                dtr_Calc.Read()
                If dtr_Calc.HasRows Then
                    Response.Write("3")
                    Demanda = dtr_Calc("JUN")
                End If
                dtr_Calc.Close()

                'RECUPERA VENDAS
                sql_Calc = ""
                sql_Calc = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_GERAL_FISCAL_UN_OR WHERE TIPO = 'VENDA UNIDADES ORIGINAL FISCAL' AND ANO = " & ANO & " AND PRODUTO = '" & PRODUTO & "'"

                cmd_Calc.Connection = cnn_Calc
                cmd_Calc.CommandText = sql_Calc
                dtr_Calc = cmd_Calc.ExecuteReader
                dtr_Calc.Read()
                If dtr_Calc.HasRows Then
                    Response.Write("4")
                    Venda = dtr_Calc("JUN")
                End If
                dtr_Calc.Close()

                'calculo de estoque
                Estoque_Calculado = FormatNumber(dtr("MAI"), 0)
                Estoque_Calculado = (Estoque_Calculado + Venda) - Demanda

                sql_insert = ""
                sql_insert = "INSERT INTO TBL_MOVIMENTO_ESTOQUE_INICIAL ([TIPO],[ANO],[GRUPO_DISTRIBUIDOR],[LINHA],[PRODUTO],[QTD],[INCLUSAO_EMAIL],[INCLUSAO_DATA])"
                sql_insert = sql_insert & " VALUES('03 ESTOQUE', " & ANO + 1 & ", 'TOTAL','" & dtr("LINHA") & "','" & dtr("PRODUTO") & "','" & Estoque_Calculado & "','" & Session("EMAIL_LOGIN") & "','" & M.RecuperaData & "')"
                If M.ExecutarSQL(sql_insert) = False Then
                    Response.Write(sql_insert)
                    Alert("Erro ao Inserir na Tabela, Função Parada!", False, "")
                    Exit Sub
                End If
            End If
            dtr.Close()
        Loop
        cnn.Close()
        cnn_Calc.Close()
        cnn_Dst.Close()
        dtr_Dst.Close()
    End Sub
    Public Sub Atualiza_Estoque_Distribuidor()

        'ABRE CONEXÕES
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnSTR").ConnectionString
        cnn.Open()
        cnn_Dst.ConnectionString = ConfigurationManager.ConnectionStrings("cnnSTR").ConnectionString
        cnn_Dst.Open()
        cnn_vazios.ConnectionString = ConfigurationManager.ConnectionStrings("cnnSTR").ConnectionString
        cnn_vazios.Open()
        cnn_Calc.ConnectionString = ConfigurationManager.ConnectionStrings("cnnSTR").ConnectionString
        cnn_Calc.Open()

        sql_delete = ""
        sql_delete = "DELETE FROM TBL_MOVIMENTO_ESTOQUE_INICIAL WHERE ANO = " & ANO + 1 & " AND GRUPO_DISTRIBUIDOR <> 'TOTAL'"
        M.ExecutarSQL(sql_delete)

        'Recupera PRODUTOS
        sql_Dst = "SELECT DISTINCT PRODUTO FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_FISCAL_UN_OR WHERE ANO = " & ANO & " ORDER BY PRODUTO "
        cmd_Dst.Connection = cnn_Dst
        cmd_Dst.CommandText = sql_Dst
        dtr_Dst = cmd_Dst.ExecuteReader

        PRODUTO = ""

        Do While dtr_Dst.Read
            PRODUTO = ""
            PRODUTO = dtr_Dst("PRODUTO")

            sql = ""
            sql = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_FISCAL_UN_OR WHERE PRODUTO='" & PRODUTO & "' AND TIPO = 'ESTOQUE UNIDADES ORIGINAL FISCAL' AND ANO = '" & ANO & "' AND GRUPO <> '01 - CSL BEHRING (Venda Direta)' AND GRUPO <> '(Venda Direta)'"

            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader
            'Recupera linhas pro distribuidor e insere na tabela
            Do While dtr.Read()
                If dtr.HasRows Then

                    'RECUPERA DEMANDA
                    sql_Calc = ""
                    sql_Calc = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_FISCAL_UN_OR WHERE GRUPO = '" & dtr("GRUPO") & "' AND TIPO = 'DEMANDA UNIDADES ORIGINAL FISCAL' AND ANO = " & ANO & " AND PRODUTO = '" & PRODUTO & "'"

                    cmd_Calc.Connection = cnn_Calc
                    cmd_Calc.CommandText = sql_Calc
                    dtr_Calc = cmd_Calc.ExecuteReader
                    dtr_Calc.Read()
                    If dtr_Calc.HasRows Then
                        Demanda = dtr_Calc("JUN")
                    End If
                    dtr_Calc.Close()

                    'RECUPERA VENDAS
                    sql_Calc = ""
                    sql_Calc = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_FISCAL_UN_OR WHERE GRUPO = '" & dtr("GRUPO") & "' AND TIPO = 'VENDA UNIDADES ORIGINAL FISCAL' AND ANO = " & ANO & " AND PRODUTO = '" & PRODUTO & "'"

                    cmd_Calc.Connection = cnn_Calc
                    cmd_Calc.CommandText = sql_Calc
                    dtr_Calc = cmd_Calc.ExecuteReader
                    dtr_Calc.Read()
                    If dtr_Calc.HasRows Then
                        Venda = dtr_Calc("JUN")
                    End If
                    dtr_Calc.Close()

                    'calculo de estoque
                    Estoque_Calculado = FormatNumber(dtr("MAI"), 0)
                    Estoque_Calculado = (Estoque_Calculado + Venda) - Demanda

                    sql_insert = ""
                    sql_insert = "INSERT INTO TBL_MOVIMENTO_ESTOQUE_INICIAL ([TIPO],[ANO],[GRUPO_DISTRIBUIDOR],[LINHA],[PRODUTO],[QTD],[INCLUSAO_EMAIL],[INCLUSAO_DATA])"
                    sql_insert = sql_insert & " VALUES('03 ESTOQUE', " & ANO + 1 & ", '" & dtr("GRUPO") & "','" & dtr("LINHA") & "','" & dtr("PRODUTO") & "','" & Estoque_Calculado & "','" & Session("EMAIL_LOGIN") & "','" & M.RecuperaData & "')"
                    If M.ExecutarSQL(sql_insert) = False Then
                        Response.Write(sql_insert)
                        Alert("Erro ao Inserir na Tabela, Função Parada!", False, "")
                        Exit Sub
                    End If
                Else
                    Alert("Erro Ao Deletar Tabela", False, "")
                End If
            Loop
            dtr.Close()

            ''Recupera GRUPOS_DISTRIBUIDORES
            'sql = ""
            'sql = "SELECT DISTINCT GRUPO FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_FISCAL_UN_OR WHERE ANO = " & ANO & " AND GRUPO <> '01 - CSL BEHRING (Venda Direta)' AND GRUPO <> '(Venda Direta)' ORDER BY GRUPO "
            'cmd.Connection = cnn
            'cmd.CommandText = sql
            'dtr = cmd.ExecuteReader
            'Do While dtr.Read
            '    sql = ""
            '    sql = "SELECT * FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_FISCAL_UN_OR WHERE ANO = " & ANO & " AND PRODUTO = '" & PRODUTO & "' AND GRUPO <> '01 - CSL BEHRING (Venda Direta)' AND GRUPO <> '(Venda Direta)' ORDER BY GRUPO "
            '    cmd_vazios.Connection = cnn_vazios
            '    cmd_vazios.CommandText = sql
            '    dtr_vazios = cmd_vazios.ExecuteReader
            '    dtr_vazios.Read()
            '    If Not dtr_vazios.HasRows Then
            '        sql_insert = ""
            '        sql_insert = "INSERT INTO TBL_MOVIMENTO_ESTOQUE_INICIAL ([TIPO],[ANO],[GRUPO_DISTRIBUIDOR],[LINHA],[PRODUTO],[QTD],[INCLUSAO_EMAIL],[INCLUSAO_DATA])"
            '        sql_insert = sql_insert & " VALUES('03 ESTOQUE', " & ANO + 1 & ", '" & dtr("GRUPO") & "','" & dtr("LINHA") & "','" & dtr("PRODUTO") & "','0','" & Session("EMAIL_LOGIN") & "','" & M.RecuperaData & "')"
            '        If M.ExecutarSQL(sql_insert) = False Then
            '            Response.Write(sql_insert)
            '            Exit Sub
            '        End If
            '    End If
            '    dtr_vazios.Close()
            'Loop
            'dtr.Close()

        Loop
        dtr_Dst.Close()
        cnn_Calc.Close()
        cnn.Close()
        cnn_Dst.Close()
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

    Protected Sub cmd_Atualizar_Estoque_Distribuidor_Click(sender As Object, e As EventArgs) Handles cmd_Atualizar_Estoque_Distribuidor.Click
        Atualiza_Estoque_Distribuidor()
    End Sub

    Protected Sub cmd_Atualizar_Estoque_Total_Click(sender As Object, e As EventArgs) Handles cmd_Atualizar_Estoque_Total.Click
        Atualiza_Estoque_Total()
    End Sub

    Protected Sub cmd_Atualizar_Estoque_Vazio_Click(sender As Object, e As EventArgs) Handles cmd_Atualizar_Estoque_Vazio.Click
        Atualiza_Estoque_Vazio()
    End Sub
End Class