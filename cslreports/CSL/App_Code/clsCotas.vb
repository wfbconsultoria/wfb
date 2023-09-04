Imports Microsoft.VisualBasic

Public Class clsCotas
    Dim F As New clsFiscal
    Dim M As New clsMaster

    Public COTAS_MES1 As Double
    Public COTAS_MES2 As Double
    Public COTAS_MES3 As Double
    Public COTAS_MES4 As Double
    Public COTAS_MES5 As Double
    Public COTAS_MES6 As Double
    Public COTAS_MES7 As Double
    Public COTAS_MES8 As Double
    Public COTAS_MES9 As Double
    Public COTAS_MES10 As Double
    Public COTAS_MES11 As Double
    Public COTAS_MES12 As Double
    Public Function IncluiCotas(TABELA As String, ANO As String, EMAIL As String, COD_PRODUTO_LINHA As String, COD_TIPO_MOVIMENTO As String, INCLUSAO_EMAIL As String) As Boolean
        On Error GoTo Err_IncluiCotas
        IncluiCotas = False
        'Váriaveis Padrão de Banco
        Dim sql As String


        F.Ano_Mes_Fiscal(ANO, "1")
        sql = ""
        sql = sql & "Insert INTO " & TABELA & " (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, INCLUSAO_EMAIL, INCLUSAO_DATA) "
        sql = sql & "Values ('" & F.ANO & "', " & F.MES & ", '1', '" & EMAIL & "', " & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", 0.0,'" & INCLUSAO_EMAIL & "', " & M.RecuperaData & ")"
        M.ExecutarSQL(sql)

        F.Ano_Mes_Fiscal(ANO, "2")
        sql = ""
        sql = sql & "Insert INTO " & TABELA & " (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, INCLUSAO_EMAIL, INCLUSAO_DATA) "
        sql = sql & "Values ('" & F.ANO & "', " & F.MES & ", '1', '" & EMAIL & "', " & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", 0.0,'" & INCLUSAO_EMAIL & "', " & M.RecuperaData & ")"
        M.ExecutarSQL(sql)

        F.Ano_Mes_Fiscal(ANO, "3")
        sql = ""
        sql = sql & "Insert INTO " & TABELA & " (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, INCLUSAO_EMAIL, INCLUSAO_DATA) "
        sql = sql & "Values ('" & F.ANO & "', " & F.MES & ", '1', '" & EMAIL & "', " & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", 0.0,'" & INCLUSAO_EMAIL & "', " & M.RecuperaData & ")"
        M.ExecutarSQL(sql)

        F.Ano_Mes_Fiscal(ANO, "4")
        sql = ""
        sql = sql & "Insert INTO " & TABELA & " (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, INCLUSAO_EMAIL, INCLUSAO_DATA) "
        sql = sql & "Values ('" & F.ANO & "', " & F.MES & ", '1', '" & EMAIL & "', " & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", 0.0,'" & INCLUSAO_EMAIL & "', " & M.RecuperaData & ")"
        M.ExecutarSQL(sql)

        F.Ano_Mes_Fiscal(ANO, "5")
        sql = ""
        sql = sql & "Insert INTO " & TABELA & " (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, INCLUSAO_EMAIL, INCLUSAO_DATA) "
        sql = sql & "Values ('" & F.ANO & "', " & F.MES & ", '1', '" & EMAIL & "', " & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", 0.0,'" & INCLUSAO_EMAIL & "', " & M.RecuperaData & ")"
        M.ExecutarSQL(sql)

        F.Ano_Mes_Fiscal(ANO, "6")
        sql = ""
        sql = sql & "Insert INTO " & TABELA & " (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, INCLUSAO_EMAIL, INCLUSAO_DATA) "
        sql = sql & "Values ('" & F.ANO & "', " & F.MES & ", '1', '" & EMAIL & "', " & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", 0.0,'" & INCLUSAO_EMAIL & "', " & M.RecuperaData & ")"
        M.ExecutarSQL(sql)

        F.Ano_Mes_Fiscal(ANO, "7")
        sql = ""
        sql = sql & "Insert INTO " & TABELA & " (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, INCLUSAO_EMAIL, INCLUSAO_DATA) "
        sql = sql & "Values ('" & F.ANO & "', " & F.MES & ", '1', '" & EMAIL & "', " & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", 0.0,'" & INCLUSAO_EMAIL & "', " & M.RecuperaData & ")"
        M.ExecutarSQL(sql)

        F.Ano_Mes_Fiscal(ANO, "8")
        sql = ""
        sql = sql & "Insert INTO " & TABELA & " (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, INCLUSAO_EMAIL, INCLUSAO_DATA) "
        sql = sql & "Values ('" & F.ANO & "', " & F.MES & ", '1', '" & EMAIL & "', " & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", 0.0,'" & INCLUSAO_EMAIL & "', " & M.RecuperaData & ")"
        M.ExecutarSQL(sql)

        F.Ano_Mes_Fiscal(ANO, "9")
        sql = ""
        sql = sql & "Insert INTO " & TABELA & " (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, INCLUSAO_EMAIL, INCLUSAO_DATA) "
        sql = sql & "Values ('" & F.ANO & "', " & F.MES & ", '1', '" & EMAIL & "', " & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", 0.0,'" & INCLUSAO_EMAIL & "', " & M.RecuperaData & ")"
        M.ExecutarSQL(sql)

        F.Ano_Mes_Fiscal(ANO, "10")
        sql = ""
        sql = sql & "Insert INTO " & TABELA & " (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, INCLUSAO_EMAIL, INCLUSAO_DATA) "
        sql = sql & "Values ('" & F.ANO & "', " & F.MES & ", '1', '" & EMAIL & "', " & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", 0.0,'" & INCLUSAO_EMAIL & "', " & M.RecuperaData & ")"
        M.ExecutarSQL(sql)

        F.Ano_Mes_Fiscal(ANO, "11")
        sql = ""
        sql = sql & "Insert INTO " & TABELA & " (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, INCLUSAO_EMAIL, INCLUSAO_DATA) "
        sql = sql & "Values ('" & F.ANO & "', " & F.MES & ", '1', '" & EMAIL & "', " & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", 0.0,'" & INCLUSAO_EMAIL & "', " & M.RecuperaData & ")"
        M.ExecutarSQL(sql)

        F.Ano_Mes_Fiscal(ANO, "12")
        sql = ""
        sql = sql & "Insert INTO " & TABELA & " (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, INCLUSAO_EMAIL, INCLUSAO_DATA) "
        sql = sql & "Values ('" & F.ANO & "', " & F.MES & ", '1', '" & EMAIL & "', " & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", 0.0,'" & INCLUSAO_EMAIL & "', " & M.RecuperaData & ")"
        M.ExecutarSQL(sql)



        IncluiCotas = True
        Exit Function
Err_IncluiCotas:
        IncluiCotas = False
    End Function
    Public Function AnoMesFechado(Ano As String, Mes As String) As Boolean
        On Error GoTo Err_AnoMesFechado
        AnoMesFechado = False

        F.Ano_Mes_Fiscal(Ano, Mes)
        If HttpContext.Current.Session("EMAIL_LOGIN") = "heloiza@wfbconsultoria.com.br" Then
            AnoMesFechado = True
        ElseIf HttpContext.Current.Session("EMAIL_LOGIN") = "aline@wfbconsultoria.com.br" Then
            If F.ANO = Year(Now()) Then
                If F.MES = 2 Then
                    AnoMesFechado = True
                End If
            End If
        Else
            If F.ANO >= Year(Now()) Then
                If F.ANO = Year(Now()) Then
                    If F.MES + 1 >= Month(Now()) Then
                        AnoMesFechado = True
                    Else
                        AnoMesFechado = False
                    End If
                ElseIf F.ANO > Year(Now()) Then
                    AnoMesFechado = True
                End If
            Else
                If F.MES = 12 And Month(Now()) = 1 Then
                    AnoMesFechado = True
                Else
                    AnoMesFechado = False
                End If
            End If
        End If


            Exit Function
Err_AnoMesFechado:
            AnoMesFechado = False
    End Function
    Public Function RecuperaCota(TABELA As String, ANO As String, EMAIL As String, COD_PRODUTO_LINHA As String, COD_TIPO_MOVIMENTO As String) As Boolean

        On Error GoTo Err_RecuperaCota
        RecuperaCota = False

        'Váriaveis Padrão de Banco
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String

        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()

        F.Ano_Mes_Fiscal(ANO, "1")
        'RECUPERA REGISTRO De cota solicitado e carrega as variaveis dos meses
        sql = ""
        sql = "Select * From " & TABELA & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES =" & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("QTD")) Then COTAS_MES1 = dtr("QTD")
            RecuperaCota = True
        Else
            RecuperaCota = False
        End If
        dtr.Close()

        F.Ano_Mes_Fiscal(ANO, "2")
        'RECUPERA REGISTRO De cota solicitado e carrega as variaveis dos meses
        sql = ""
        sql = "Select * From " & TABELA & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES =" & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("QTD")) Then COTAS_MES2 = dtr("QTD")
            RecuperaCota = True
        Else
            RecuperaCota = False
        End If
        dtr.Close()

        F.Ano_Mes_Fiscal(ANO, "3")
        'RECUPERA REGISTRO De cota solicitado e carrega as variaveis dos meses
        sql = ""
        sql = "Select * From " & TABELA & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES =" & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("QTD")) Then COTAS_MES3 = dtr("QTD")
            RecuperaCota = True
        Else
            RecuperaCota = False
        End If
        dtr.Close()

        F.Ano_Mes_Fiscal(ANO, "4")
        'RECUPERA REGISTRO De cota solicitado e carrega as variaveis dos meses
        sql = ""
        sql = "Select * From " & TABELA & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES =" & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("QTD")) Then COTAS_MES4 = dtr("QTD")
            RecuperaCota = True
        Else
            RecuperaCota = False
        End If
        dtr.Close()

        F.Ano_Mes_Fiscal(ANO, "5")
        'RECUPERA REGISTRO De cota solicitado e carrega as variaveis dos meses
        sql = ""
        sql = "Select * From " & TABELA & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES =" & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("QTD")) Then COTAS_MES5 = dtr("QTD")
            RecuperaCota = True
        Else
            RecuperaCota = False
        End If
        dtr.Close()

        F.Ano_Mes_Fiscal(ANO, "6")
        'RECUPERA REGISTRO De cota solicitado e carrega as variaveis dos meses
        sql = ""
        sql = "Select * From " & TABELA & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES =" & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("QTD")) Then COTAS_MES6 = dtr("QTD")
            RecuperaCota = True
        Else
            RecuperaCota = False
        End If
        dtr.Close()

        F.Ano_Mes_Fiscal(ANO, "7")
        'RECUPERA REGISTRO De cota solicitado e carrega as variaveis dos meses
        sql = ""
        sql = "Select * From " & TABELA & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES =" & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("QTD")) Then COTAS_MES7 = dtr("QTD")
            RecuperaCota = True
        Else
            RecuperaCota = False
        End If
        dtr.Close()

        F.Ano_Mes_Fiscal(ANO, "8")
        'RECUPERA REGISTRO De cota solicitado e carrega as variaveis dos meses
        sql = ""
        sql = "Select * From " & TABELA & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES =" & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("QTD")) Then COTAS_MES8 = dtr("QTD")
            RecuperaCota = True
        Else
            RecuperaCota = False
        End If
        dtr.Close()

        F.Ano_Mes_Fiscal(ANO, "9")
        'RECUPERA REGISTRO De cota solicitado e carrega as variaveis dos meses
        sql = ""
        sql = "Select * From " & TABELA & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES =" & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("QTD")) Then COTAS_MES9 = dtr("QTD")
            RecuperaCota = True
        Else
            RecuperaCota = False
        End If
        dtr.Close()

        F.Ano_Mes_Fiscal(ANO, "10")
        'RECUPERA REGISTRO De cota solicitado e carrega as variaveis dos meses
        sql = ""
        sql = "Select * From " & TABELA & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES =" & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("QTD")) Then COTAS_MES10 = dtr("QTD")
            RecuperaCota = True
        Else
            RecuperaCota = False
        End If
        dtr.Close()

        F.Ano_Mes_Fiscal(ANO, "11")
        'RECUPERA REGISTRO De cota solicitado e carrega as variaveis dos meses
        sql = ""
        sql = "Select * From " & TABELA & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES =" & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("QTD")) Then COTAS_MES11 = dtr("QTD")
            RecuperaCota = True
        Else
            RecuperaCota = False
        End If
        dtr.Close()

        F.Ano_Mes_Fiscal(ANO, "12")
        'RECUPERA REGISTRO De cota solicitado e carrega as variaveis dos meses
        sql = ""
        sql = "Select * From " & TABELA & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES =" & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("QTD")) Then COTAS_MES12 = dtr("QTD")
            RecuperaCota = True
        Else
            RecuperaCota = False
        End If
        dtr.Close()
        cnn.Close()

        Exit Function
Err_RecuperaCota:
        RecuperaCota = False
    End Function
    Public Function AtualizaCotas(TABELA As String, ANO As String, C1 As Double, C2 As Double, C3 As Double, C4 As Double, C5 As Double, C6 As Double, C7 As Double, C8 As Double, C9 As Double, C10 As Double, C11 As Double, C12 As Double, EMAIL As String, COD_PRODUTO_LINHA As String, COD_TIPO_MOVIMENTO As String, ALTERACAO_EMAIL As String) As Boolean
        On Error GoTo Err_IncluiCotas
        AtualizaCotas = False
        Dim mensagem As String

        'Váriaveis Padrão de Banco
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String

        F.Ano_Mes_Fiscal(ANO, "1")
        sql = ""
        sql = "Update " & TABELA & " SET "
        sql = sql & "QTD = " & Replace(Replace(C1, ".", ""), ",", ".") & ", "
        sql = sql & " ALTERACAO_EMAIL = '" & ALTERACAO_EMAIL & "', ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES = " & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        If M.ExecutarSQL(sql) = True Then
            sql = ""
            sql = sql & "Insert Into " & TABELA & "_LOG (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, ALTERACAO_EMAIL, ALTERACAO_DATA) "
            sql = sql & "Values (" & ANO & ", '" & F.MES & "', 1, '" & EMAIL & "'," & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", " & Replace(Replace(C1, ".", ""), ",", ".") & ", "
            sql = sql & "'" & ALTERACAO_EMAIL & "', " & M.RecuperaData & ")"
            M.ExecutarSQL(sql)
        Else
            mensagem = "ERRO - Atualização de Cota - " & Now() & Chr(10)
            mensagem = mensagem & "Por: " & ALTERACAO_EMAIL & Chr(10)
            Mensagem = Mensagem & "SQL : " & sql & Chr(10)
            M.EnviarEmail("ERRO - ATUALIZAÇÃO de Cotars", mensagem, True, False, "", "")

            AtualizaCotas = False
        End If

        F.Ano_Mes_Fiscal(ANO, "2")
        sql = ""
        sql = "Update " & TABELA & " SET "
        sql = sql & "QTD = " & Replace(Replace(C2, ".", ""), ",", ".") & ", "
        sql = sql & " ALTERACAO_EMAIL = '" & ALTERACAO_EMAIL & "', ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES = " & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        If M.ExecutarSQL(sql) = True Then
            sql = ""
            sql = sql & "Insert Into " & TABELA & "_LOG (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, ALTERACAO_EMAIL, ALTERACAO_DATA) "
            sql = sql & "Values (" & ANO & ", '" & F.MES & "', 1, '" & EMAIL & "'," & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", " & Replace(Replace(C2, ".", ""), ",", ".") & ", "
            sql = sql & "'" & ALTERACAO_EMAIL & "', " & M.RecuperaData & ")"
            M.ExecutarSQL(sql)
        Else
            mensagem = "ERRO - Atualização de Cota - " & Now() & Chr(10)
            mensagem = mensagem & "Por: " & ALTERACAO_EMAIL & Chr(10)
            mensagem = mensagem & "SQL : " & sql & Chr(10)
            M.EnviarEmail("ERRO - ATUALIZAÇÃO de Cotars", mensagem, True, False, "", "")

            AtualizaCotas = False
        End If

        F.Ano_Mes_Fiscal(ANO, "3")
        sql = ""
        sql = "Update " & TABELA & " SET "
        sql = sql & "QTD = " & Replace(Replace(C3, ".", ""), ",", ".") & ", "
        sql = sql & " ALTERACAO_EMAIL = '" & ALTERACAO_EMAIL & "', ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES = " & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        If M.ExecutarSQL(sql) = True Then
            sql = ""
            sql = sql & "Insert Into " & TABELA & "_LOG (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, ALTERACAO_EMAIL, ALTERACAO_DATA) "
            sql = sql & "Values (" & ANO & ", '" & F.MES & "', 1, '" & EMAIL & "'," & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", " & Replace(Replace(C3, ".", ""), ",", ".") & ", "
            sql = sql & "'" & ALTERACAO_EMAIL & "', " & M.RecuperaData & ")"
            M.ExecutarSQL(sql)
        Else
            mensagem = "ERRO - Atualização de Cota - " & Now() & Chr(10)
            mensagem = mensagem & "Por: " & ALTERACAO_EMAIL & Chr(10)
            mensagem = mensagem & "SQL : " & sql & Chr(10)
            M.EnviarEmail("ERRO - ATUALIZAÇÃO de Cotars", mensagem, True, False, "", "")

            AtualizaCotas = False
        End If

        F.Ano_Mes_Fiscal(ANO, "4")
        sql = ""
        sql = "Update " & TABELA & " SET "
        sql = sql & "QTD = " & Replace(Replace(C4, ".", ""), ",", ".") & ", "
        sql = sql & " ALTERACAO_EMAIL = '" & ALTERACAO_EMAIL & "', ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES = " & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        If M.ExecutarSQL(sql) = True Then
            sql = ""
            sql = sql & "Insert Into " & TABELA & "_LOG (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, ALTERACAO_EMAIL, ALTERACAO_DATA) "
            sql = sql & "Values (" & ANO & ", '" & F.MES & "', 1, '" & EMAIL & "'," & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", " & Replace(Replace(C4, ".", ""), ",", ".") & ", "
            sql = sql & "'" & ALTERACAO_EMAIL & "', " & M.RecuperaData & ")"
            M.ExecutarSQL(sql)
        Else
            mensagem = "ERRO - Atualização de Cota - " & Now() & Chr(10)
            mensagem = mensagem & "Por: " & ALTERACAO_EMAIL & Chr(10)
            mensagem = mensagem & "SQL : " & sql & Chr(10)
            M.EnviarEmail("ERRO - ATUALIZAÇÃO de Cotars", mensagem, True, False, "", "")

            AtualizaCotas = False
        End If

        F.Ano_Mes_Fiscal(ANO, "5")
        sql = ""
        sql = "Update " & TABELA & " SET "
        sql = sql & "QTD = " & Replace(Replace(C5, ".", ""), ",", ".") & ", "
        sql = sql & " ALTERACAO_EMAIL = '" & ALTERACAO_EMAIL & "', ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES = " & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        If M.ExecutarSQL(sql) = True Then
            sql = ""
            sql = sql & "Insert Into " & TABELA & "_LOG (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, ALTERACAO_EMAIL, ALTERACAO_DATA) "
            sql = sql & "Values (" & ANO & ", '" & F.MES & "', 1, '" & EMAIL & "'," & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", " & Replace(Replace(C5, ".", ""), ",", ".") & ", "
            sql = sql & "'" & ALTERACAO_EMAIL & "', " & M.RecuperaData & ")"
            M.ExecutarSQL(sql)
        Else
            mensagem = "ERRO - Atualização de Cota - " & Now() & Chr(10)
            mensagem = mensagem & "Por: " & ALTERACAO_EMAIL & Chr(10)
            mensagem = mensagem & "SQL : " & sql & Chr(10)
            M.EnviarEmail("ERRO - ATUALIZAÇÃO de Cotars", mensagem, True, False, "", "")

            AtualizaCotas = False
        End If

        F.Ano_Mes_Fiscal(ANO, "6")
        sql = ""
        sql = "Update " & TABELA & " SET "
        sql = sql & "QTD = " & Replace(Replace(C6, ".", ""), ",", ".") & ", "
        sql = sql & " ALTERACAO_EMAIL = '" & ALTERACAO_EMAIL & "', ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES = " & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        If M.ExecutarSQL(sql) = True Then
            sql = ""
            sql = sql & "Insert Into " & TABELA & "_LOG (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, ALTERACAO_EMAIL, ALTERACAO_DATA) "
            sql = sql & "Values (" & ANO & ", '" & F.MES & "', 1, '" & EMAIL & "'," & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", " & Replace(Replace(C6, ".", ""), ",", ".") & ", "
            sql = sql & "'" & ALTERACAO_EMAIL & "', " & M.RecuperaData & ")"
            M.ExecutarSQL(sql)
        Else
            mensagem = "ERRO - Atualização de Cota - " & Now() & Chr(10)
            mensagem = mensagem & "Por: " & ALTERACAO_EMAIL & Chr(10)
            mensagem = mensagem & "SQL : " & sql & Chr(10)
            M.EnviarEmail("ERRO - ATUALIZAÇÃO de Cotars", mensagem, True, False, "", "")

            AtualizaCotas = False
        End If

        F.Ano_Mes_Fiscal(ANO, "7")
        sql = ""
        sql = "Update " & TABELA & " SET "
        sql = sql & "QTD = " & Replace(Replace(C7, ".", ""), ",", ".") & ", "
        sql = sql & " ALTERACAO_EMAIL = '" & ALTERACAO_EMAIL & "', ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES = " & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        If M.ExecutarSQL(sql) = True Then
            sql = ""
            sql = sql & "Insert Into " & TABELA & "_LOG (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, ALTERACAO_EMAIL, ALTERACAO_DATA) "
            sql = sql & "Values (" & ANO & ", '" & F.MES & "', 1, '" & EMAIL & "'," & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", " & Replace(Replace(C7, ".", ""), ",", ".") & ", "
            sql = sql & "'" & ALTERACAO_EMAIL & "', " & M.RecuperaData & ")"
            M.ExecutarSQL(sql)
        Else
            mensagem = "ERRO - Atualização de Cota - " & Now() & Chr(10)
            mensagem = mensagem & "Por: " & ALTERACAO_EMAIL & Chr(10)
            mensagem = mensagem & "SQL : " & sql & Chr(10)
            M.EnviarEmail("ERRO - ATUALIZAÇÃO de Cotars", mensagem, True, False, "", "")

            AtualizaCotas = False
        End If

        F.Ano_Mes_Fiscal(ANO, "8")
        sql = ""
        sql = "Update " & TABELA & " SET "
        sql = sql & "QTD = " & Replace(Replace(C8, ".", ""), ",", ".") & ", "
        sql = sql & " ALTERACAO_EMAIL = '" & ALTERACAO_EMAIL & "', ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES = " & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        If M.ExecutarSQL(sql) = True Then
            sql = ""
            sql = sql & "Insert Into " & TABELA & "_LOG (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, ALTERACAO_EMAIL, ALTERACAO_DATA) "
            sql = sql & "Values (" & ANO & ", '" & F.MES & "', 1, '" & EMAIL & "'," & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", " & Replace(Replace(C8, ".", ""), ",", ".") & ", "
            sql = sql & "'" & ALTERACAO_EMAIL & "', " & M.RecuperaData & ")"
            M.ExecutarSQL(sql)
        Else
            mensagem = "ERRO - Atualização de Cota - " & Now() & Chr(10)
            mensagem = mensagem & "Por: " & ALTERACAO_EMAIL & Chr(10)
            mensagem = mensagem & "SQL : " & sql & Chr(10)
            M.EnviarEmail("ERRO - ATUALIZAÇÃO de Cotars", mensagem, True, False, "", "")

            AtualizaCotas = False
        End If

        F.Ano_Mes_Fiscal(ANO, "9")
        sql = ""
        sql = "Update " & TABELA & " SET "
        sql = sql & "QTD = " & Replace(Replace(C9, ".", ""), ",", ".") & ", "
        sql = sql & " ALTERACAO_EMAIL = '" & ALTERACAO_EMAIL & "', ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES = " & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        If M.ExecutarSQL(sql) = True Then
            sql = ""
            sql = sql & "Insert Into " & TABELA & "_LOG (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, ALTERACAO_EMAIL, ALTERACAO_DATA) "
            sql = sql & "Values (" & ANO & ", '" & F.MES & "', 1, '" & EMAIL & "'," & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", " & Replace(Replace(C9, ".", ""), ",", ".") & ", "
            sql = sql & "'" & ALTERACAO_EMAIL & "', " & M.RecuperaData & ")"
            M.ExecutarSQL(sql)
        Else
            mensagem = "ERRO - Atualização de Cota - " & Now() & Chr(10)
            mensagem = mensagem & "Por: " & ALTERACAO_EMAIL & Chr(10)
            mensagem = mensagem & "SQL : " & sql & Chr(10)
            M.EnviarEmail("ERRO - ATUALIZAÇÃO de Cotars", mensagem, True, False, "", "")

            AtualizaCotas = False
        End If

        F.Ano_Mes_Fiscal(ANO, "10")
        sql = ""
        sql = "Update " & TABELA & " SET "
        sql = sql & "QTD = " & Replace(Replace(C10, ".", ""), ",", ".") & ", "
        sql = sql & " ALTERACAO_EMAIL = '" & ALTERACAO_EMAIL & "', ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES = " & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        If M.ExecutarSQL(sql) = True Then
            sql = ""
            sql = sql & "Insert Into " & TABELA & "_LOG (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, ALTERACAO_EMAIL, ALTERACAO_DATA) "
            sql = sql & "Values (" & ANO & ", '" & F.MES & "', 1, '" & EMAIL & "'," & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", " & Replace(Replace(C10, ".", ""), ",", ".") & ", "
            sql = sql & "'" & ALTERACAO_EMAIL & "', " & M.RecuperaData & ")"
            M.ExecutarSQL(sql)
        Else
            mensagem = "ERRO - Atualização de Cota - " & Now() & Chr(10)
            mensagem = mensagem & "Por: " & ALTERACAO_EMAIL & Chr(10)
            mensagem = mensagem & "SQL : " & sql & Chr(10)
            M.EnviarEmail("ERRO - ATUALIZAÇÃO de Cotars", mensagem, True, False, "", "")

            AtualizaCotas = False
        End If

        F.Ano_Mes_Fiscal(ANO, "11")
        sql = ""
        sql = "Update " & TABELA & " SET "
        sql = sql & "QTD = " & Replace(Replace(C11, ".", ""), ",", ".") & ", "
        sql = sql & " ALTERACAO_EMAIL = '" & ALTERACAO_EMAIL & "', ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES = " & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        If M.ExecutarSQL(sql) = True Then
            sql = ""
            sql = sql & "Insert Into " & TABELA & "_LOG (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, ALTERACAO_EMAIL, ALTERACAO_DATA) "
            sql = sql & "Values (" & ANO & ", '" & F.MES & "', 1, '" & EMAIL & "'," & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", " & Replace(Replace(C11, ".", ""), ",", ".") & ", "
            sql = sql & "'" & ALTERACAO_EMAIL & "', " & M.RecuperaData & ")"
            M.ExecutarSQL(sql)
        Else
            mensagem = "ERRO - Atualização de Cota - " & Now() & Chr(10)
            mensagem = mensagem & "Por: " & ALTERACAO_EMAIL & Chr(10)
            mensagem = mensagem & "SQL : " & sql & Chr(10)
            M.EnviarEmail("ERRO - ATUALIZAÇÃO de Cotars", mensagem, True, False, "", "")

            AtualizaCotas = False
        End If

        F.Ano_Mes_Fiscal(ANO, "12")
        sql = ""
        sql = "Update " & TABELA & " SET "
        sql = sql & "QTD = " & Replace(Replace(C12, ".", ""), ",", ".") & ", "
        sql = sql & " ALTERACAO_EMAIL = '" & ALTERACAO_EMAIL & "', ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & EMAIL & "' AND ANO = " & F.ANO & " AND MES = " & F.MES & " AND COD_PRODUTO_LINHA = " & COD_PRODUTO_LINHA & " AND COD_TIPO_MOVIMENTO = " & COD_TIPO_MOVIMENTO
        If M.ExecutarSQL(sql) = True Then
            sql = ""
            sql = sql & "Insert Into " & TABELA & "_LOG (ANO, MES, DIA, EMAIL, COD_PRODUTO_LINHA, COD_TIPO_MOVIMENTO, QTD, ALTERACAO_EMAIL, ALTERACAO_DATA) "
            sql = sql & "Values (" & ANO & ", '" & F.MES & "', 1, '" & EMAIL & "'," & COD_PRODUTO_LINHA & ", " & COD_TIPO_MOVIMENTO & ", " & Replace(Replace(C12, ".", ""), ",", ".") & ", "
            sql = sql & "'" & ALTERACAO_EMAIL & "', " & M.RecuperaData & ")"
            M.ExecutarSQL(sql)
        Else
            mensagem = "ERRO - Atualização de Cota - " & Now() & Chr(10)
            mensagem = mensagem & "Por: " & ALTERACAO_EMAIL & Chr(10)
            mensagem = mensagem & "SQL : " & sql & Chr(10)
            M.EnviarEmail("ERRO - ATUALIZAÇÃO de Cotars", mensagem, True, False, "", "")

            AtualizaCotas = False
        End If

        AtualizaCotas = True
        Exit Function
Err_IncluiCotas:
        AtualizaCotas = False
    End Function
End Class
