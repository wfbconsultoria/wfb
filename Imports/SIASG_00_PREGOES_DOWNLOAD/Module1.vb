Imports System.Net
Imports System.IO
'SIASG_00_PREGOES_DOWNLOAD
Module Module1
    Public titulo_aplicacao As String = "SIASG_00_PREGOES_DOWNLOAD"
    Public cnnStr As String = "Server=miro.bihospitalar.com.br;Port=5432;UserId=postgres;Password=@Mepm2412;Database=bih_datasus"
    Public cnn As New Npgsql.NpgsqlConnection
    Public cnn1 As New Npgsql.NpgsqlConnection
    Public cnn2 As New Npgsql.NpgsqlConnection
    Public schema As String = "SIASG"
    Public tabela As String = "TB_PREGOES_DOWNLOAD"
    Public pasta_csv As String = "D:\SIASG\00_PREGOES\ARQUIVOS\"
    Public erros As Integer = 0
    Public tipo_arquivo As String = "PREGOES"
    Public tipo_processo As String = "DOWNLOAD"
    Public mensagem_log As String
    Public OFF_SET As String = ""

    Sub Main()

        Console.Title = "SIASG " & tipo_arquivo & " " & tipo_processo & " Inicio " & Now()
        Console.BackgroundColor = ConsoleColor.Yellow
        Console.WriteLine(tipo_arquivo & " " & tipo_processo & " Inicio " & Now())
        Console.BackgroundColor = ConsoleColor.Black

        Try
            Dim sql As String = ""
            'EXCLUI REGISTROS DA TB_PREGOES_DOWNLOAD
            'Console.WriteLine("EXCLUINDO REGISTROS DA TB_PREGOES_DOWNLOAD, AGUARDE...")


            'sql &= "DELETE FROM [" & schema & "].[" & tabela & "] "
            'ExecuteSQL(sql)

            'CRIA REGISTROS DA TB_PREGOES_DOWNLOAD
            'Console.WriteLine("INCLUIDO REGISTROS DA TB_PREGOES_DOWNLOAD, AGUARDE...")
            'Dim offset As Long = 0
            'For offset = 0 To 1000000
            '    sql = ""
            '    sql &= " INSERT INTO [" & schema & "].[" & tabela & "] "
            '    sql &= " ([OFF_SET],[ARQUIVO], [LOG_DOWNLOAD],[LINK_DOWNLOAD]) "
            '    sql &= " VALUES (" & offset & ", 'PREGOES_OFFSET_" & Format(offset, "0000000000") & ".CSV',"
            '    sql &= " 'PENDENTE', 'http://compras.dados.gov.br/pregoes/v1/pregoes.csv?" & "offset=" & offset & "')"
            '    ExecuteSQL(sql)
            '    offset += 499
            'Next

            'Abre Tabela e varre todos os registros
            sql = ""
            sql &= "SELECT * FROM [" & schema & "].[" & tabela & "] WHERE [LOG_DOWNLOAD] <> 'OK' ORDER BY [OFF_SET]"
            Dim dtr As Npgsql.NpgsqlDataReader = ExecuteSelect(sql)
            If dtr.HasRows Then
                Do While dtr.Read()
                    OFF_SET = dtr("OFF_SET")
                    Try
                        Dim remoteUri As String = dtr("LINK_DOWNLOAD")
                        Dim fileName As String = pasta_csv & dtr("ARQUIVO")
                        Dim myWebClient As New WebClient()

                        'Mensagem("SEARCH   ; " & Now() & "; " & fileName)
                        myWebClient.DownloadFile(remoteUri, fileName)

                        Dim fi As New System.IO.FileInfo(fileName)
                        Dim fi_size As Double = fi.Length
                        If fi_size > 0 Then
                            Mensagem("COMPLETE ; " & Now() & "; " & fileName)
                            'Mensagem("FILE SAVE; " & Now() & "; " & fileName)
                            ExecuteSQL("UPDATE [" & schema & "].[" & tabela & "] Set [LOG_DOWNLOAD] = 'OK', [DATA_DOWNLOAD] ='" & Agora() & "' WHERE [OFF_SET] = " & dtr("OFF_SET"))
                        Else
                            erros += 1
                            Mensagem("NOT FOUND; " & Now() & "; " & fileName)
                            ExecuteSQL("UPDATE [" & schema & "].[" & tabela & "] Set [LOG_DOWNLOAD] = 'VAZIO', [DATA_DOWNLOAD] ='" & Agora() & "' WHERE [OFF_SET] = " & dtr("OFF_SET"))
                        End If

                    Catch exc2 As Exception
                        ExecuteSQL("UPDATE [" & schema & "].[" & tabela & "] Set [LOG_DOWNLOAD] = 'ERRO - " & exc2.ToString & "', [DATA_DOWNLOAD] ='" & Agora() & "' WHERE [OFF_SET] = " & dtr("OFF_SET"))
                        LogErro(exc2)
                    End Try
                Loop
            End If

        Catch exc1 As Exception
            LogErro(exc1)
        Finally
            If erros = 0 Then
                Console.BackgroundColor = ConsoleColor.Green
                Mensagem("SEM ERROS ")
            Else
                Console.BackgroundColor = ConsoleColor.Red
                Mensagem(erros & " ERROS ")
            End If

            Console.BackgroundColor = ConsoleColor.Black
            Console.WriteLine("CRIANDO ARQUIVO DE LOG, AGUARDE...")
            Arquivo_Log()
            Console.Title = Console.Title & " Final " & Now()
            Console.BackgroundColor = ConsoleColor.Yellow
            Console.WriteLine("CONCLUIDO, PRESSIONE UMA TECLA PARA ENCERRAR")
            Console.Read()

        End Try
    End Sub
    Function ConectaBanco() As Boolean
        Try
            'Conexão Postgres

            cnn = New Npgsql.NpgsqlConnection(cnnStr)
            cnn.Open()
            ConectaBanco = True
        Catch e As Exception
            LogErro(e)
            ConectaBanco = False
        End Try
    End Function
    Public Function ExecuteSQL(SQL As String) As Boolean
        SQL = ConverteSQL_PSQL(SQL)
        Try
            ExecuteSQL = False
            cnn2 = New Npgsql.NpgsqlConnection(cnnStr)
            cnn2.Open()

            Dim cmd2 As Npgsql.NpgsqlCommand = cnn2.CreateCommand
            cmd2.CommandText = SQL
            cmd2.ExecuteNonQuery()
            ExecuteSQL = True
        Catch e As Exception
            Console.WriteLine(e.Message)
            Console.Read()
            ExecuteSQL = False
        Finally
            cnn2.Close()
        End Try

    End Function
    Public Function ExecuteSelect(SQL As String) As Npgsql.NpgsqlDataReader
        SQL = ConverteSQL_PSQL(SQL)
        Try
            If Not IsNothing(cnn) Then
                If cnn.State = Data.ConnectionState.Open Then cnn.Close()
            End If
            ConectaBanco()
            Dim cmd As Npgsql.NpgsqlCommand = cnn.CreateCommand
            cmd.Connection = cnn
            cmd.CommandText = SQL
            ExecuteSelect = cmd.ExecuteReader
        Catch e As Exception
            LogErro(e)
            ExecuteSelect = Nothing
        End Try

    End Function
    Function ConverteSQL_PSQL(SQL As String) As String
        Try
            SQL = Replace(SQL, "[", Chr(34))
            SQL = Replace(SQL, "]", Chr(34))
        Catch
            SQL = ""
        End Try
        ConverteSQL_PSQL = SQL
    End Function
    Sub Mensagem(mensagem As String)
        Console.WriteLine(mensagem)
        mensagem_log = mensagem_log & mensagem & vbCrLf
    End Sub
    Public Sub LogErro(e As Exception)
        erros += 1
        Console.BackgroundColor = ConsoleColor.Red
        Mensagem("ERRO " & Format(erros, "000000") & " - " & OFF_SET & " - " & e.Message)
        
        Console.BackgroundColor = ConsoleColor.Black
    End Sub
    Sub Arquivo_Log()
        Dim log_filename As String = pasta_csv & "LOG\LOG_" & tipo_processo & "_" & tipo_arquivo & "_" & TimeStamp() & ".txt"
        Try
            Using outputFile As New StreamWriter(log_filename)
                outputFile.WriteLine(mensagem_log)
            End Using
            Console.WriteLine("VERIFIQUE O ARQUIVO DE LOG: " & log_filename)
        Catch e As Exception
            Console.WriteLine("ERRO AO CRIAR ARQUIVO " & log_filename)
            Console.WriteLine(e.Message)
            Return
        End Try
    End Sub
    Function Agora() As String
        Agora = Now().Year & "-" & Now.Month & "-" & Now().Day
    End Function
    Function TimeStamp() As String
        TimeStamp = Format(Now.Year, "0000") & "-" & Format(Now.Month, "00") & "-" & Format(Now.Day, "00") & "-" & Format(Now.Hour, "00") & "-" & Format(Now.Minute, "00") & "-" & Format(Now.Second, "00")
    End Function

End Module
