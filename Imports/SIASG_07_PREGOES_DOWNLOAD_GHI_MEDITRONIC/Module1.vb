Imports System.Net
Imports System.IO

'SIASG_07_PREGOES_DOWNLOAD_GHI_MEDITRONIC
Module Module1
    Public titulo_aplicacao As String = "SIASG - PREGOES DOWNLOAD"
    Public cnnStr As String = "Server=miro.bihospitalar.com.br;Port=5432;UserId=postgres;Password=@Mepm2412;Database=bih_datasus"
    Public cnn As New Npgsql.NpgsqlConnection
    Public cnn1 As New Npgsql.NpgsqlConnection
    Public cnn2 As New Npgsql.NpgsqlConnection
    Public schema As String = "SIASG"
    Public tabela As String = "TB_LICITACOES"
    Public pasta_csv As String = "D:\SIASG\07_PREGOES\ARQUIVOS\"
    Public erros As Integer = 0
    Public tipo_arquivo As String = "PREGOES"
    Public tipo_processo As String = "DOWNLOAD"
    Public mensagem_log As String

    Public COD_CLASSE As String = ""
    'SIASG_07_PREGOES_DOWNLOAD_GHI_MEDITRONIC
    Sub Main()
        Console.Title = "MEDTRONIC " & tipo_arquivo & " " & tipo_processo & " Inicio " & Now()
        'SOLICITA PARAMETROS DE DOWNLOAD PARA O USUARIO
        Console.BackgroundColor = ConsoleColor.DarkBlue

        'ANO EDITAL DA LICITACOA INICIAL
        Console.WriteLine("ANO INICIAL A IMPORTAR")
        Dim OPT_ANO_EDITAL As String = Console.ReadLine()
        If IsNumeric(OPT_ANO_EDITAL) Then
        Else
            Console.BackgroundColor = ConsoleColor.Red
            Console.WriteLine("ANO INICIAL INVALIDO, INICIE NOVAMENTE")
            Console.Read()
            GoTo FINAL
        End If

        'SE IMPORTA LICITACOES AINDA NÃO IMPORTADAS OU LICITACOES COM FALHA NA TENTATIVA DE DOWNLOAD
        Console.WriteLine(tipo_arquivo & " A IMPORTAR (1=NÃO IMPORTADOS; 2=IMPORTADOS COM FALHA)")
        Dim OPT_DOWNLOAD As String = Console.ReadLine()

        Dim offset As Long = 0

        Try
            'Abre Tabela e varre todos os registros
            Dim sql As String = ""
            Select Case OPT_DOWNLOAD
                Case = "1"
                    sql = "SELECT * From [GHI].[VW_GHI_LICITACOES_MEDITRONIC] Where [" & tipo_arquivo & "_OFFSET] < 0 And [ANO_EDITAL]::INT >= " & Val(OPT_ANO_EDITAL) & " And [" & tipo_arquivo & "_LOG] IS NULL "
                    Console.Title = "MEDTRONIC " & tipo_arquivo & " (NÃO IMPORTADAS, ANO INICIAL=" & OPT_ANO_EDITAL & ") " & tipo_processo & " Inicio " & Now()
                Case = "2"
                    sql = "SELECT * From [GHI].[VW_GHI_LICITACOES_MEDITRONIC] Where [" & tipo_arquivo & "_OFFSET] < 0 And [ANO_EDITAL]::INT >= " & Val(OPT_ANO_EDITAL) & " And [" & tipo_arquivo & "_LOG] IS NOT NULL "
                    Console.Title = "MEDTRONIC " & tipo_arquivo & " (COM FALHA, ANO INICIAL=" & OPT_ANO_EDITAL & ") " & tipo_processo & " Inicio " & Now()
                Case Else
                    Console.BackgroundColor = ConsoleColor.Red
                    Console.WriteLine(OPT_DOWNLOAD & " OPÇÃO INVÁLIDA, INICIE NOVAMENTE")
                    Console.Read()
                    GoTo FINAL
            End Select
            Console.WriteLine("AGUARDE, INICIANDO DOWNLOAD....")

            Dim dtr As Npgsql.NpgsqlDataReader = ExecuteSelect(sql)
            If dtr.HasRows Then
                Do While dtr.Read()
                    Do
                        Try
                            Dim remoteUri As String = dtr(tipo_arquivo & "_LINK") '& "&offset=" & offset
                            Dim fileName As String = pasta_csv & "PREGOES_" & dtr("COD_LICITACAO") & "_OFFSET_" & Format(offset, "0000000000") & ".CSV"
                            Dim myWebClient As New WebClient()

                            Mensagem("SEARCH   ; " & Now() & "; " & fileName)
                            myWebClient.DownloadFile(remoteUri, fileName)

                            Dim fi As New System.IO.FileInfo(fileName)
                            Dim fi_size As Double = fi.Length
                            If fi_size > 0 Then
                                Mensagem("COMPLETE ; " & Now() & "; " & fileName)
                                Mensagem("FILE SAVE; " & Now() & "; " & fileName)
                                ExecuteSQL("UPDATE [" & schema & "].[" & tabela & "] Set [" & tipo_arquivo & "_OFFSET] = " & offset & ", [" & tipo_arquivo & "_ATUALIZACAO] = '" & Agora() & "', [" & tipo_arquivo & "_LOG] = 'SUCESSO' WHERE [COD_LICITACAO] = '" & dtr("COD_LICITACAO") & "'")
                                Exit Do 'offset = offset + 500
                            Else
                                If offset = 0 Then
                                    erros += 1
                                    Mensagem("NOT FOUND; " & Now() & "; " & fileName)
                                    ExecuteSQL("UPDATE [" & schema & "].[" & tabela & "] Set [" & tipo_arquivo & "_OFFSET] = " & -1 & ", [" & tipo_arquivo & "_ATUALIZACAO] = '" & Agora() & "', [" & tipo_arquivo & "_LOG] = 'FALHA - EMPTY FILE OR NOT FOUND' WHERE [COD_LICITACAO] = '" & dtr("COD_LICITACAO") & "'")
                                    Exit Do
                                Else
                                    Exit Do
                                End If
                            End If
                        Catch exc2 As Exception
                            If offset = 0 Then
                                ExecuteSQL("UPDATE [" & schema & "].[" & tabela & "] Set [" & tipo_arquivo & "_OFFSET] = " & -1 & ", [" & tipo_arquivo & "_ATUALIZACAO] = '" & Agora() & "', [" & tipo_arquivo & "_LOG] = 'FALHA " & exc2.Message & "' WHERE [COD_LICITACAO] = '" & dtr("COD_LICITACAO") & "'")
                                LogErro(exc2)
                                Exit Do
                            Else
                                offset = 0
                                Exit Do
                            End If
                        End Try
                    Loop
PROXIMO:
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
            Console.WriteLine("CONCLUIDO, PRESSIONE UMA TECLA PARA ENCERRAR")
            Console.Read()
        End Try
FINAL:
    End Sub
    Function ConectaBanco() As Boolean
        Try
            'Conexão Postgres

            cnn = New Npgsql.NpgsqlConnection(cnnStr)
            cnn.Open()
            Console.BackgroundColor = ConsoleColor.Green
            Console.WriteLine("CONEXAO OK")
            Console.BackgroundColor = ConsoleColor.Black
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
        Mensagem("ERRO " & Format(erros, "000000") & " - " & e.Message)
        
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
