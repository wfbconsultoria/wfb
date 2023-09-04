
Partial Class Cotas_Demanda
    Inherits System.Web.UI.Page
    Public jscript As String
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Cotas_Demanda.aspx"
    Dim Titulo As String = "Menutenção de Cotas de Demanda - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
    Dim Mensagem As String
    'Variaveis da pagina
    Dim ANO As String
    Dim SQL As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = True 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = False 'Diretor
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

        'bloqueia todos os campos ao entrar na tela
        txt_JAN_01.Enabled = False
        txt_FEV_01.Enabled = False
        txt_MAR_01.Enabled = False
        txt_ABR_01.Enabled = False
        txt_MAI_01.Enabled = False
        txt_JUN_01.Enabled = False
        txt_JUL_01.Enabled = False
        txt_AGO_01.Enabled = False
        txt_SET_01.Enabled = False
        txt_OUT_01.Enabled = False
        txt_NOV_01.Enabled = False
        txt_DEZ_01.Enabled = False

        txt_JAN_02.Enabled = False
        txt_FEV_02.Enabled = False
        txt_MAR_02.Enabled = False
        txt_ABR_02.Enabled = False
        txt_MAI_02.Enabled = False
        txt_JUN_02.Enabled = False
        txt_JUL_02.Enabled = False
        txt_AGO_02.Enabled = False
        txt_SET_02.Enabled = False
        txt_OUT_02.Enabled = False
        txt_NOV_02.Enabled = False
        txt_DEZ_02.Enabled = False

        txt_JAN_03.Enabled = False
        txt_FEV_03.Enabled = False
        txt_MAR_03.Enabled = False
        txt_ABR_03.Enabled = False
        txt_MAI_03.Enabled = False
        txt_JUN_03.Enabled = False
        txt_JUL_03.Enabled = False
        txt_AGO_03.Enabled = False
        txt_SET_03.Enabled = False
        txt_OUT_03.Enabled = False
        txt_NOV_03.Enabled = False
        txt_DEZ_03.Enabled = False

        txt_JAN_04.Enabled = False
        txt_FEV_04.Enabled = False
        txt_MAR_04.Enabled = False
        txt_ABR_04.Enabled = False
        txt_MAI_04.Enabled = False
        txt_JUN_04.Enabled = False
        txt_JUL_04.Enabled = False
        txt_AGO_04.Enabled = False
        txt_SET_04.Enabled = False
        txt_OUT_04.Enabled = False
        txt_NOV_04.Enabled = False
        txt_DEZ_04.Enabled = False

        txt_JAN_05.Enabled = False
        txt_FEV_05.Enabled = False
        txt_MAR_05.Enabled = False
        txt_ABR_05.Enabled = False
        txt_MAI_05.Enabled = False
        txt_JUN_05.Enabled = False
        txt_JUL_05.Enabled = False
        txt_AGO_05.Enabled = False
        txt_SET_05.Enabled = False
        txt_OUT_05.Enabled = False
        txt_NOV_05.Enabled = False
        txt_DEZ_05.Enabled = False

        'verifica se o ano foi selecionado
        If cmb_Anos.Text = "" Then
            ANO = Year(Now())
        Else
            ANO = cmb_Anos.Text
        End If

        'Monta o combo de representante

        ' Verifica perfil e carrega o combo de usuarios
        SQL = "Select '@' as EMAIL,  '# Selecione' AS NOME Union All "
        SQL = SQL & " Select EMAIL, NOME From VIEW_USUARIOS Where (COD_PERFIL = '4') And (ATIVO = 'True') "
        If Session("COD_PERFIL_LOGIN") = "0" Then SQL = SQL
        If Session("COD_PERFIL_LOGIN") = "1" Then SQL = SQL & " And (DIRETOR = '" & Session("EMAIL_LOGIN") & "')"
        If Session("COD_PERFIL_LOGIN") = "2" Then SQL = SQL & " And (GERENTE = '" & Session("EMAIL_LOGIN") & "')"
        If Session("COD_PERFIL_LOGIN") = "3" Then SQL = SQL & " And (EMAIL = '" & Session("EMAIL_LOGIN") & "')"
        If Session("COD_PERFIL_LOGIN") = "4" Then SQL = SQL & " And (EMAIL = '" & Session("EMAIL_LOGIN") & "')"
        SQL = SQL & " Order By NOME"
        dts_Usuarios.SelectCommand = SQL

        'libera os campos no casa de ter sido selecionado um representante
        ' aqui será onde irá fiar a validação se o mês está ou não aberto para lançamento de cotas
        If (cmb_Usuarios.Text <> "@" And cmb_Usuarios.Text <> "") Then
            txt_JAN_01.Enabled = True
            txt_FEV_01.Enabled = True
            txt_MAR_01.Enabled = True
            txt_ABR_01.Enabled = True
            txt_MAI_01.Enabled = True
            txt_JUN_01.Enabled = True
            txt_JUL_01.Enabled = True
            txt_AGO_01.Enabled = True
            txt_SET_01.Enabled = True
            txt_OUT_01.Enabled = True
            txt_NOV_01.Enabled = True
            txt_DEZ_01.Enabled = True

            txt_JAN_02.Enabled = True
            txt_FEV_02.Enabled = True
            txt_MAR_02.Enabled = True
            txt_ABR_02.Enabled = True
            txt_MAI_02.Enabled = True
            txt_JUN_02.Enabled = True
            txt_JUL_02.Enabled = True
            txt_AGO_02.Enabled = True
            txt_SET_02.Enabled = True
            txt_OUT_02.Enabled = True
            txt_NOV_02.Enabled = True
            txt_DEZ_02.Enabled = True

            txt_JAN_03.Enabled = True
            txt_FEV_03.Enabled = True
            txt_MAR_03.Enabled = True
            txt_ABR_03.Enabled = True
            txt_MAI_03.Enabled = True
            txt_JUN_03.Enabled = True
            txt_JUL_03.Enabled = True
            txt_AGO_03.Enabled = True
            txt_SET_03.Enabled = True
            txt_OUT_03.Enabled = True
            txt_NOV_03.Enabled = True
            txt_DEZ_03.Enabled = True

            txt_JAN_04.Enabled = True
            txt_FEV_04.Enabled = True
            txt_MAR_04.Enabled = True
            txt_ABR_04.Enabled = True
            txt_MAI_04.Enabled = True
            txt_JUN_04.Enabled = True
            txt_JUL_04.Enabled = True
            txt_AGO_04.Enabled = True
            txt_SET_04.Enabled = True
            txt_OUT_04.Enabled = True
            txt_NOV_04.Enabled = True
            txt_DEZ_04.Enabled = True

            txt_JAN_05.Enabled = True
            txt_FEV_05.Enabled = True
            txt_MAR_05.Enabled = True
            txt_ABR_05.Enabled = True
            txt_MAI_05.Enabled = True
            txt_JUN_05.Enabled = True
            txt_JUL_05.Enabled = True
            txt_AGO_05.Enabled = True
            txt_SET_05.Enabled = True
            txt_OUT_05.Enabled = True
            txt_NOV_05.Enabled = True
            txt_DEZ_05.Enabled = True
        End If

    End Sub
    Protected Sub cmd_Gravar_Click(sender As Object, e As EventArgs) Handles cmd_Gravar.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String

        'variaveis para check de sucesso no update das cotas
        Dim Linha01 As Boolean = False
        Dim Linha02 As Boolean = False
        Dim Linha03 As Boolean = False
        Dim Linha04 As Boolean = False
        Dim Linha05 As Boolean = False

        'variavel para recuperar dados para criar o LOG
        Dim ID As Integer
        Dim INCLUSAO_EMAIL As String = ""
        Dim INCLUSAO_DATA As String = ""

        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()

        'Update da DIVISAO 1
        sql = ""
        sql = "Update TBL_COTAS_DEMANDA SET "
        sql = sql & "JAN =" & txt_JAN_01.Text & ", FEV = " & txt_FEV_01.Text & ", MAR = " & txt_MAR_01.Text & ", "
        sql = sql & "ABR = " & txt_ABR_01.Text & ", MAI = " & txt_MAI_01.Text & ", JUN = " & txt_JUN_01.Text & ", "
        sql = sql & "JUL = " & txt_JUL_01.Text & ", AGO = " & txt_AGO_01.Text & ", [SET] = " & txt_SET_01.Text & ", "
        sql = sql & "OUT = " & txt_OUT_01.Text & ", NOV = " & txt_NOV_01.Text & ", DEZ = " & txt_DEZ_01.Text & ", "
        sql = sql & "ALTERACAO_EMAIL = '" & Session("EMAIL_LOGIN") & "', ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_Linha_Produtos_01.Text

        'Verifica se foi selecionado um representante
        If cmb_Usuarios.Text = "@" Then
            Alert("Escolha um Representante para inserir a cota!", False, "")
        Else
            'cria o log da DIVISAO 1
            If M.ExecutarSQL(sql) = True Then
                Linha01 = True
                'RECUPERA REGISTRO DA Divisao 1
                sql = ""
                sql = "Select * From TBL_COTAS_DEMANDA Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_Linha_Produtos_01.Text
                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    If Not IsDBNull(dtr("ID")) Then ID = dtr("ID")
                    If Not IsDBNull(dtr("INCLUSAO_EMAIL")) Then INCLUSAO_EMAIL = dtr("INCLUSAO_EMAIL")
                    If Not IsDBNull(dtr("INCLUSAO_DATA")) Then INCLUSAO_DATA = dtr("INCLUSAO_DATA")
                End If
                dtr.Close()

                'Insere log da Divisao 1
                sql = ""
                sql = sql & "Insert Into TBL_COTAS_DEMANDA_LOG (ID, EMAIL, ANO, COD_LINHA_PRODUTO, JAN, FEV, MAR, ABR, MAI, JUN, JUL, AGO, [SET], OUT, NOV, DEZ, INCLUSAO_EMAIL, INCLUSAO_DATA, ALTERACAO_EMAIL, ALTERACAO_DATA) "
                sql = sql & "Values (" & ID & ", '" & cmb_Usuarios.Text & "', " & cmb_Anos.Text & ", " & cmb_Linha_Produtos_01.Text & ", "
                sql = sql & txt_JAN_01.Text & ", " & txt_FEV_01.Text & ", " & txt_MAR_01.Text & ", " & txt_ABR_01.Text & ", " & txt_MAI_01.Text & ", "
                sql = sql & txt_JUN_01.Text & ", " & txt_JUL_01.Text & ", " & txt_AGO_01.Text & ", " & txt_SET_01.Text & ", " & txt_OUT_01.Text & ", "
                sql = sql & txt_NOV_01.Text & ", " & txt_DEZ_01.Text & ", '"
                sql = sql & INCLUSAO_EMAIL & "', " & INCLUSAO_DATA & ", '" & Session("EMAIL_LOGIN") & "', " & M.RecuperaData & ")"
                M.ExecutarSQL(sql)
            Else
                'Insere o check de ERRO ao atualizar cota
                Linha01 = False
            End If
        End If

        'Update da DIVISAO 2
        sql = ""
        sql = "Update TBL_COTAS_DEMANDA SET "
        sql = sql & "JAN =" & txt_JAN_02.Text & ", FEV = " & txt_FEV_02.Text & ", MAR = " & txt_MAR_02.Text & ", "
        sql = sql & "ABR = " & txt_ABR_02.Text & ", MAI = " & txt_MAI_02.Text & ", JUN = " & txt_JUN_02.Text & ", "
        sql = sql & "JUL = " & txt_JUL_02.Text & ", AGO = " & txt_AGO_02.Text & ", [SET] = " & txt_SET_02.Text & ", "
        sql = sql & "OUT = " & txt_OUT_02.Text & ", NOV = " & txt_NOV_02.Text & ", DEZ = " & txt_DEZ_02.Text & ", "
        sql = sql & "ALTERACAO_EMAIL = '" & Session("EMAIL_LOGIN") & "', ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_Linha_Produtos_02.Text

        'Verifica se foi selecionado um representante
        If cmb_Usuarios.Text = "@" Then
            Alert("Escolha um Representante para inserir a cota!", False, "")
        Else
            'cria o log da DIVISAO 2
            If M.ExecutarSQL(sql) = True Then
                Linha02 = True
                'RECUPERA REGISTRO DA Divisao 2
                sql = ""
                sql = "Select * From TBL_COTAS_DEMANDA Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_Linha_Produtos_02.Text
                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    If Not IsDBNull(dtr("ID")) Then ID = dtr("ID")
                    If Not IsDBNull(dtr("INCLUSAO_EMAIL")) Then INCLUSAO_EMAIL = dtr("INCLUSAO_EMAIL")
                    If Not IsDBNull(dtr("INCLUSAO_DATA")) Then INCLUSAO_DATA = dtr("INCLUSAO_DATA")
                End If
                dtr.Close()

                'Insere log da Divisao 2
                sql = ""
                sql = sql & "Insert Into TBL_COTAS_DEMANDA_LOG (ID, EMAIL, ANO, COD_LINHA_PRODUTO, JAN, FEV, MAR, ABR, MAI, JUN, JUL, AGO, [SET], OUT, NOV, DEZ, INCLUSAO_EMAIL, INCLUSAO_DATA, ALTERACAO_EMAIL, ALTERACAO_DATA) "
                sql = sql & "Values (" & ID & ", '" & cmb_Usuarios.Text & "', " & cmb_Anos.Text & ", " & cmb_Linha_Produtos_02.Text & ", "
                sql = sql & txt_JAN_02.Text & ", " & txt_FEV_02.Text & ", " & txt_MAR_02.Text & ", " & txt_ABR_02.Text & ", " & txt_MAI_02.Text & ", "
                sql = sql & txt_JUN_02.Text & ", " & txt_JUL_02.Text & ", " & txt_AGO_02.Text & ", " & txt_SET_02.Text & ", " & txt_OUT_02.Text & ", "
                sql = sql & txt_NOV_02.Text & ", " & txt_DEZ_02.Text & ", '"
                sql = sql & INCLUSAO_EMAIL & "', " & INCLUSAO_DATA & ", '" & Session("EMAIL_LOGIN") & "', " & M.RecuperaData & ")"
                M.ExecutarSQL(sql)
            Else
                'Insere o check de ERRO ao atualizar cota
                Linha02 = False
            End If
        End If

        'Update da DIVISAO 3
        sql = ""
        sql = "Update TBL_COTAS_DEMANDA SET "
        sql = sql & "JAN =" & txt_JAN_03.Text & ", FEV = " & txt_FEV_03.Text & ", MAR = " & txt_MAR_03.Text & ", "
        sql = sql & "ABR = " & txt_ABR_03.Text & ", MAI = " & txt_MAI_03.Text & ", JUN = " & txt_JUN_03.Text & ", "
        sql = sql & "JUL = " & txt_JUL_03.Text & ", AGO = " & txt_AGO_03.Text & ", [SET] = " & txt_SET_03.Text & ", "
        sql = sql & "OUT = " & txt_OUT_03.Text & ", NOV = " & txt_NOV_03.Text & ", DEZ = " & txt_DEZ_03.Text & ", "
        sql = sql & "ALTERACAO_EMAIL = '" & Session("EMAIL_LOGIN") & "', ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_Linha_Produtos_03.Text

        'Verifica se foi selecionado um representante
        If cmb_Usuarios.Text = "@" Then
            Alert("Escolha um Representante para inserir a cota!", False, "")
        Else
            'cria o log da DIVISAO 3
            If M.ExecutarSQL(sql) = True Then
                Linha03 = True
                'RECUPERA REGISTRO DA Divisao 3
                sql = ""
                sql = "Select * From TBL_COTAS_DEMANDA Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_Linha_Produtos_03.Text
                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    If Not IsDBNull(dtr("ID")) Then ID = dtr("ID")
                    If Not IsDBNull(dtr("INCLUSAO_EMAIL")) Then INCLUSAO_EMAIL = dtr("INCLUSAO_EMAIL")
                    If Not IsDBNull(dtr("INCLUSAO_DATA")) Then INCLUSAO_DATA = dtr("INCLUSAO_DATA")
                End If
                dtr.Close()

                'Insere log da Divisao 3
                sql = ""
                sql = sql & "Insert Into TBL_COTAS_DEMANDA_LOG (ID, EMAIL, ANO, COD_LINHA_PRODUTO, JAN, FEV, MAR, ABR, MAI, JUN, JUL, AGO, [SET], OUT, NOV, DEZ, INCLUSAO_EMAIL, INCLUSAO_DATA, ALTERACAO_EMAIL, ALTERACAO_DATA) "
                sql = sql & "Values (" & ID & ", '" & cmb_Usuarios.Text & "', " & cmb_Anos.Text & ", " & cmb_Linha_Produtos_03.Text & ", "
                sql = sql & txt_JAN_03.Text & ", " & txt_FEV_03.Text & ", " & txt_MAR_03.Text & ", " & txt_ABR_03.Text & ", " & txt_MAI_03.Text & ", "
                sql = sql & txt_JUN_03.Text & ", " & txt_JUL_03.Text & ", " & txt_AGO_03.Text & ", " & txt_SET_03.Text & ", " & txt_OUT_03.Text & ", "
                sql = sql & txt_NOV_03.Text & ", " & txt_DEZ_03.Text & ", '"
                sql = sql & INCLUSAO_EMAIL & "', " & INCLUSAO_DATA & ", '" & Session("EMAIL_LOGIN") & "', " & M.RecuperaData & ")"
                M.ExecutarSQL(sql)
            Else
                'Insere o check de ERRO ao atualizar cota
                Linha03 = False
            End If
        End If

        'Update da DIVISAO 4
        sql = ""
        sql = "Update TBL_COTAS_DEMANDA SET "
        sql = sql & "JAN =" & txt_JAN_04.Text & ", FEV = " & txt_FEV_04.Text & ", MAR = " & txt_MAR_04.Text & ", "
        sql = sql & "ABR = " & txt_ABR_04.Text & ", MAI = " & txt_MAI_04.Text & ", JUN = " & txt_JUN_04.Text & ", "
        sql = sql & "JUL = " & txt_JUL_04.Text & ", AGO = " & txt_AGO_04.Text & ", [SET] = " & txt_SET_04.Text & ", "
        sql = sql & "OUT = " & txt_OUT_04.Text & ", NOV = " & txt_NOV_04.Text & ", DEZ = " & txt_DEZ_04.Text & ", "
        sql = sql & "ALTERACAO_EMAIL = '" & Session("EMAIL_LOGIN") & "', ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_Linha_Produtos_04.Text

        'Verifica se foi selecionado um representante
        If cmb_Usuarios.Text = "@" Then
            Alert("Escolha um Representante para inserir a cota!", False, "")
        Else
            'cria o log da DIVISAO 4
            If M.ExecutarSQL(sql) = True Then
                Linha04 = True
                'RECUPERA REGISTRO DA Divisao 4
                sql = ""
                sql = "Select * From TBL_COTAS_DEMANDA Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_Linha_Produtos_04.Text
                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    If Not IsDBNull(dtr("ID")) Then ID = dtr("ID")
                    If Not IsDBNull(dtr("INCLUSAO_EMAIL")) Then INCLUSAO_EMAIL = dtr("INCLUSAO_EMAIL")
                    If Not IsDBNull(dtr("INCLUSAO_DATA")) Then INCLUSAO_DATA = dtr("INCLUSAO_DATA")
                End If
                dtr.Close()

                'Insere log da Divisao 4
                sql = ""
                sql = sql & "Insert Into TBL_COTAS_DEMANDA_LOG (ID, EMAIL, ANO, COD_LINHA_PRODUTO, JAN, FEV, MAR, ABR, MAI, JUN, JUL, AGO, [SET], OUT, NOV, DEZ, INCLUSAO_EMAIL, INCLUSAO_DATA, ALTERACAO_EMAIL, ALTERACAO_DATA) "
                sql = sql & "Values (" & ID & ", '" & cmb_Usuarios.Text & "', " & cmb_Anos.Text & ", " & cmb_Linha_Produtos_04.Text & ", "
                sql = sql & txt_JAN_04.Text & ", " & txt_FEV_04.Text & ", " & txt_MAR_04.Text & ", " & txt_ABR_04.Text & ", " & txt_MAI_04.Text & ", "
                sql = sql & txt_JUN_04.Text & ", " & txt_JUL_04.Text & ", " & txt_AGO_04.Text & ", " & txt_SET_04.Text & ", " & txt_OUT_04.Text & ", "
                sql = sql & txt_NOV_04.Text & ", " & txt_DEZ_04.Text & ", '"
                sql = sql & INCLUSAO_EMAIL & "', " & INCLUSAO_DATA & ", '" & Session("EMAIL_LOGIN") & "', " & M.RecuperaData & ")"
                M.ExecutarSQL(sql)
            Else
                'Insere o check de ERRO ao atualizar cota
                Linha04 = False
            End If
        End If

        'Update da DIVISAO 5
        sql = ""
        sql = "Update TBL_COTAS_DEMANDA SET "
        sql = sql & "JAN =" & txt_JAN_05.Text & ", FEV = " & txt_FEV_05.Text & ", MAR = " & txt_MAR_05.Text & ", "
        sql = sql & "ABR = " & txt_ABR_05.Text & ", MAI = " & txt_MAI_05.Text & ", JUN = " & txt_JUN_05.Text & ", "
        sql = sql & "JUL = " & txt_JUL_05.Text & ", AGO = " & txt_AGO_05.Text & ", [SET] = " & txt_SET_05.Text & ", "
        sql = sql & "OUT = " & txt_OUT_05.Text & ", NOV = " & txt_NOV_05.Text & ", DEZ = " & txt_DEZ_05.Text & ", "
        sql = sql & "ALTERACAO_EMAIL = '" & Session("EMAIL_LOGIN") & "', ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_Linha_Produtos_05.Text

        'Verifica se foi selecionado um representante
        If cmb_Usuarios.Text = "@" Then
            Alert("Escolha um Representante para inserir a cota!", False, "")
        Else
            'cria o log da DIVISAO 4
            If M.ExecutarSQL(sql) = True Then
                Linha05 = True
                'RECUPERA REGISTRO DA Divisao 4
                sql = ""
                sql = "Select * From TBL_COTAS_DEMANDA Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_Linha_Produtos_05.Text
                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                    If Not IsDBNull(dtr("ID")) Then ID = dtr("ID")
                    If Not IsDBNull(dtr("INCLUSAO_EMAIL")) Then INCLUSAO_EMAIL = dtr("INCLUSAO_EMAIL")
                    If Not IsDBNull(dtr("INCLUSAO_DATA")) Then INCLUSAO_DATA = dtr("INCLUSAO_DATA")
                End If
                dtr.Close()

                'Insere log da Divisao 4
                sql = ""
                sql = sql & "Insert Into TBL_COTAS_DEMANDA_LOG (ID, EMAIL, ANO, COD_LINHA_PRODUTO, JAN, FEV, MAR, ABR, MAI, JUN, JUL, AGO, [SET], OUT, NOV, DEZ, INCLUSAO_EMAIL, INCLUSAO_DATA, ALTERACAO_EMAIL, ALTERACAO_DATA) "
                sql = sql & "Values (" & ID & ", '" & cmb_Usuarios.Text & "', " & cmb_Anos.Text & ", " & cmb_Linha_Produtos_05.Text & ", "
                sql = sql & txt_JAN_05.Text & ", " & txt_FEV_05.Text & ", " & txt_MAR_05.Text & ", " & txt_ABR_05.Text & ", " & txt_MAI_05.Text & ", "
                sql = sql & txt_JUN_05.Text & ", " & txt_JUL_05.Text & ", " & txt_AGO_05.Text & ", " & txt_SET_05.Text & ", " & txt_OUT_05.Text & ", "
                sql = sql & txt_NOV_05.Text & ", " & txt_DEZ_05.Text & ", '"
                sql = sql & INCLUSAO_EMAIL & "', " & INCLUSAO_DATA & ", '" & Session("EMAIL_LOGIN") & "', " & M.RecuperaData & ")"
                M.ExecutarSQL(sql)
            Else
                'Insere o check de ERRO ao atualizar cota
                Linha05 = False
            End If
        End If

        'faz a verificação de quais cotas foram inseridas com sucesso e avisa ao usúario
        If (Linha01 = False) Or (Linha02 = False) Or (Linha03 = False) Or (Linha04 = False) Or (Linha05 = False) Then
            Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao suporte para verificação!", False, "")
        Else
            Alert("COTAS INCLUIDAS COM SUCESSO", False, "")
        End If
        cnn.Close()
    End Sub
    Protected Sub cmb_Usuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Usuarios.SelectedIndexChanged
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String

        'preenche campo com o valor 0 padrão de inicio
        txt_JAN_01.Text = 0
        txt_FEV_01.Text = 0
        txt_MAR_01.Text = 0
        txt_ABR_01.Text = 0
        txt_MAI_01.Text = 0
        txt_JUN_01.Text = 0
        txt_JUL_01.Text = 0
        txt_AGO_01.Text = 0
        txt_SET_01.Text = 0
        txt_OUT_01.Text = 0
        txt_NOV_01.Text = 0
        txt_DEZ_01.Text = 0

        txt_JAN_02.Text = 0
        txt_FEV_02.Text = 0
        txt_MAR_02.Text = 0
        txt_ABR_02.Text = 0
        txt_MAI_02.Text = 0
        txt_JUN_02.Text = 0
        txt_JUL_02.Text = 0
        txt_AGO_02.Text = 0
        txt_SET_02.Text = 0
        txt_OUT_02.Text = 0
        txt_NOV_02.Text = 0
        txt_DEZ_02.Text = 0

        txt_JAN_03.Text = 0
        txt_FEV_03.Text = 0
        txt_MAR_03.Text = 0
        txt_ABR_03.Text = 0
        txt_MAI_03.Text = 0
        txt_JUN_03.Text = 0
        txt_JUL_03.Text = 0
        txt_AGO_03.Text = 0
        txt_SET_03.Text = 0
        txt_OUT_03.Text = 0
        txt_NOV_03.Text = 0
        txt_DEZ_03.Text = 0

        txt_JAN_04.Text = 0
        txt_FEV_04.Text = 0
        txt_MAR_04.Text = 0
        txt_ABR_04.Text = 0
        txt_MAI_04.Text = 0
        txt_JUN_04.Text = 0
        txt_JUL_04.Text = 0
        txt_AGO_04.Text = 0
        txt_SET_04.Text = 0
        txt_OUT_04.Text = 0
        txt_NOV_04.Text = 0
        txt_DEZ_04.Text = 0

        txt_JAN_05.Text = 0
        txt_FEV_05.Text = 0
        txt_MAR_05.Text = 0
        txt_ABR_05.Text = 0
        txt_MAI_05.Text = 0
        txt_JUN_05.Text = 0
        txt_JUL_05.Text = 0
        txt_AGO_05.Text = 0
        txt_SET_05.Text = 0
        txt_OUT_05.Text = 0
        txt_NOV_05.Text = 0
        txt_DEZ_05.Text = 0


        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()

        'RECUPERA REGISTRO DA LINHA 1
        sql = ""
        sql = "Select * From TBL_COTAS_DEMANDA Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_Linha_Produtos_01.Text
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("JAN")) Then txt_JAN_01.Text = dtr("JAN")
            If Not IsDBNull(dtr("FEV")) Then txt_FEV_01.Text = dtr("FEV")
            If Not IsDBNull(dtr("MAR")) Then txt_MAR_01.Text = dtr("MAR")
            If Not IsDBNull(dtr("ABR")) Then txt_ABR_01.Text = dtr("ABR")
            If Not IsDBNull(dtr("MAI")) Then txt_MAI_01.Text = dtr("MAI")
            If Not IsDBNull(dtr("JUN")) Then txt_JUN_01.Text = dtr("JUN")
            If Not IsDBNull(dtr("JUL")) Then txt_JUL_01.Text = dtr("JUL")
            If Not IsDBNull(dtr("AGO")) Then txt_AGO_01.Text = dtr("AGO")
            If Not IsDBNull(dtr("SET")) Then txt_SET_01.Text = dtr("SET")
            If Not IsDBNull(dtr("OUT")) Then txt_OUT_01.Text = dtr("OUT")
            If Not IsDBNull(dtr("NOV")) Then txt_NOV_01.Text = dtr("NOV")
            If Not IsDBNull(dtr("DEZ")) Then txt_DEZ_01.Text = dtr("DEZ")
        Else
            sql = ""
            sql = sql & "Insert INTO TBL_COTAS_DEMANDA (EMAIL, ANO, COD_LINHA_PRODUTO, JAN, FEV, MAR, ABR, MAI, JUN, JUL, AGO, [SET], OUT, NOV, DEZ, INCLUSAO_EMAIL, INCLUSAO_DATA) "
            sql = sql & "Values ('" & cmb_Usuarios.Text & "', " & cmb_Anos.Text & ", " & cmb_Linha_Produtos_01.Text & ", 0.0,0,0,0,0,0,0,0,0,0,0,0,'" & Session("EMAIL_LOGIN") & "', " & M.RecuperaData & ")"
            If M.ExecutarSQL(sql) = False Then
                Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
            End If
        End If
        dtr.Close()


        'RECUPERA REGISTRO DA LINHA 2
        sql = ""
        sql = "Select * From TBL_COTAS_DEMANDA Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_Linha_Produtos_02.Text
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("JAN")) Then txt_JAN_02.Text = dtr("JAN")
            If Not IsDBNull(dtr("FEV")) Then txt_FEV_02.Text = dtr("FEV")
            If Not IsDBNull(dtr("MAR")) Then txt_MAR_02.Text = dtr("MAR")
            If Not IsDBNull(dtr("ABR")) Then txt_ABR_02.Text = dtr("ABR")
            If Not IsDBNull(dtr("MAI")) Then txt_MAI_02.Text = dtr("MAI")
            If Not IsDBNull(dtr("JUN")) Then txt_JUN_02.Text = dtr("JUN")
            If Not IsDBNull(dtr("JUL")) Then txt_JUL_02.Text = dtr("JUL")
            If Not IsDBNull(dtr("AGO")) Then txt_AGO_02.Text = dtr("AGO")
            If Not IsDBNull(dtr("SET")) Then txt_SET_02.Text = dtr("SET")
            If Not IsDBNull(dtr("OUT")) Then txt_OUT_02.Text = dtr("OUT")
            If Not IsDBNull(dtr("NOV")) Then txt_NOV_02.Text = dtr("NOV")
            If Not IsDBNull(dtr("DEZ")) Then txt_DEZ_02.Text = dtr("DEZ")
        Else
            sql = ""
            sql = sql & "Insert INTO TBL_COTAS_DEMANDA (EMAIL, ANO, COD_LINHA_PRODUTO, JAN, FEV, MAR, ABR, MAI, JUN, JUL, AGO, [SET], OUT, NOV, DEZ, INCLUSAO_EMAIL, INCLUSAO_DATA) "
            sql = sql & "Values ('" & cmb_Usuarios.Text & "', " & cmb_Anos.Text & ", " & cmb_Linha_Produtos_02.Text & ", 0,0,0,0,0,0,0,0,0,0,0,0,'" & Session("EMAIL_LOGIN") & "', " & M.RecuperaData & ")"
            If M.ExecutarSQL(sql) = False Then
                Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
            End If
        End If
        dtr.Close()

        'RECUPERA REGISTRO DA LINHA 3
        sql = ""
        sql = "Select * From TBL_COTAS_DEMANDA Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_Linha_Produtos_03.Text
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("JAN")) Then txt_JAN_03.Text = dtr("JAN")
            If Not IsDBNull(dtr("FEV")) Then txt_FEV_03.Text = dtr("FEV")
            If Not IsDBNull(dtr("MAR")) Then txt_MAR_03.Text = dtr("MAR")
            If Not IsDBNull(dtr("ABR")) Then txt_ABR_03.Text = dtr("ABR")
            If Not IsDBNull(dtr("MAI")) Then txt_MAI_03.Text = dtr("MAI")
            If Not IsDBNull(dtr("JUN")) Then txt_JUN_03.Text = dtr("JUN")
            If Not IsDBNull(dtr("JUL")) Then txt_JUL_03.Text = dtr("JUL")
            If Not IsDBNull(dtr("AGO")) Then txt_AGO_03.Text = dtr("AGO")
            If Not IsDBNull(dtr("SET")) Then txt_SET_03.Text = dtr("SET")
            If Not IsDBNull(dtr("OUT")) Then txt_OUT_03.Text = dtr("OUT")
            If Not IsDBNull(dtr("NOV")) Then txt_NOV_03.Text = dtr("NOV")
            If Not IsDBNull(dtr("DEZ")) Then txt_DEZ_03.Text = dtr("DEZ")
        Else
            sql = ""
            sql = sql & "Insert INTO TBL_COTAS_DEMANDA (EMAIL, ANO, COD_LINHA_PRODUTO, JAN, FEV, MAR, ABR, MAI, JUN, JUL, AGO, [SET], OUT, NOV, DEZ, INCLUSAO_EMAIL, INCLUSAO_DATA) "
            sql = sql & "Values ('" & cmb_Usuarios.Text & "', " & cmb_Anos.Text & ", " & cmb_Linha_Produtos_03.Text & ", 0.0,0,0,0,0,0,0,0,0,0,0,0,'" & Session("EMAIL_LOGIN") & "', " & M.RecuperaData & ")"
            If M.ExecutarSQL(sql) = False Then
                Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
            End If
        End If
        dtr.Close()

        'RECUPERA REGISTRO DA LINHA 4
        sql = ""
        sql = "Select * From TBL_COTAS_DEMANDA Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_Linha_Produtos_04.Text
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("JAN")) Then txt_JAN_04.Text = dtr("JAN")
            If Not IsDBNull(dtr("FEV")) Then txt_FEV_04.Text = dtr("FEV")
            If Not IsDBNull(dtr("MAR")) Then txt_MAR_04.Text = dtr("MAR")
            If Not IsDBNull(dtr("ABR")) Then txt_ABR_04.Text = dtr("ABR")
            If Not IsDBNull(dtr("MAI")) Then txt_MAI_04.Text = dtr("MAI")
            If Not IsDBNull(dtr("JUN")) Then txt_JUN_04.Text = dtr("JUN")
            If Not IsDBNull(dtr("JUL")) Then txt_JUL_04.Text = dtr("JUL")
            If Not IsDBNull(dtr("AGO")) Then txt_AGO_04.Text = dtr("AGO")
            If Not IsDBNull(dtr("SET")) Then txt_SET_04.Text = dtr("SET")
            If Not IsDBNull(dtr("OUT")) Then txt_OUT_04.Text = dtr("OUT")
            If Not IsDBNull(dtr("NOV")) Then txt_NOV_04.Text = dtr("NOV")
            If Not IsDBNull(dtr("DEZ")) Then txt_DEZ_04.Text = dtr("DEZ")
        Else
            sql = ""
            sql = sql & "Insert INTO TBL_COTAS_DEMANDA (EMAIL, ANO, COD_LINHA_PRODUTO, JAN, FEV, MAR, ABR, MAI, JUN, JUL, AGO, [SET], OUT, NOV, DEZ, INCLUSAO_EMAIL, INCLUSAO_DATA) "
            sql = sql & "Values ('" & cmb_Usuarios.Text & "', " & cmb_Anos.Text & ", " & cmb_Linha_Produtos_04.Text & ", 0.0,0,0,0,0,0,0,0,0,0,0,0,'" & Session("EMAIL_LOGIN") & "', " & M.RecuperaData & ")"
            If M.ExecutarSQL(sql) = False Then
                Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
            End If
        End If
        dtr.Close()

        'RECUPERA REGISTRO DA LINHA 5
        sql = ""
        sql = "Select * From TBL_COTAS_DEMANDA Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_Linha_Produtos_05.Text
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("JAN")) Then txt_JAN_05.Text = dtr("JAN")
            If Not IsDBNull(dtr("FEV")) Then txt_FEV_05.Text = dtr("FEV")
            If Not IsDBNull(dtr("MAR")) Then txt_MAR_05.Text = dtr("MAR")
            If Not IsDBNull(dtr("ABR")) Then txt_ABR_05.Text = dtr("ABR")
            If Not IsDBNull(dtr("MAI")) Then txt_MAI_05.Text = dtr("MAI")
            If Not IsDBNull(dtr("JUN")) Then txt_JUN_05.Text = dtr("JUN")
            If Not IsDBNull(dtr("JUL")) Then txt_JUL_05.Text = dtr("JUL")
            If Not IsDBNull(dtr("AGO")) Then txt_AGO_05.Text = dtr("AGO")
            If Not IsDBNull(dtr("SET")) Then txt_SET_05.Text = dtr("SET")
            If Not IsDBNull(dtr("OUT")) Then txt_OUT_05.Text = dtr("OUT")
            If Not IsDBNull(dtr("NOV")) Then txt_NOV_05.Text = dtr("NOV")
            If Not IsDBNull(dtr("DEZ")) Then txt_DEZ_05.Text = dtr("DEZ")
        Else
            sql = ""
            sql = sql & "Insert INTO TBL_COTAS_DEMANDA (EMAIL, ANO, COD_LINHA_PRODUTO, JAN, FEV, MAR, ABR, MAI, JUN, JUL, AGO, [SET], OUT, NOV, DEZ, INCLUSAO_EMAIL, INCLUSAO_DATA) "
            sql = sql & "Values ('" & cmb_Usuarios.Text & "', " & cmb_Anos.Text & ", " & cmb_Linha_Produtos_05.Text & ", 0.0,0,0,0,0,0,0,0,0,0,0,0,'" & Session("EMAIL_LOGIN") & "', " & M.RecuperaData & ")"
            If M.ExecutarSQL(sql) = False Then
                Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
            End If
        End If
        dtr.Close()

        cnn.Close()
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