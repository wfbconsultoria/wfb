﻿Imports System.Net
Imports System.IO
'SIASG_04_MATERIAIS_DOWNLOAD 6515
Module Module1
    Public titulo_aplicacao As String = "SIASG - MATERIAIS DOWNLOAD"
    Public cnnStr As String = "Server=miro.bihospitalar.com.br;Port=5432;UserId=postgres;Password=@Mepm2412;Database=bih_datasus"
    Public cnn As New Npgsql.NpgsqlConnection
    Public cnn1 As New Npgsql.NpgsqlConnection
    Public cnn2 As New Npgsql.NpgsqlConnection
    Public schema As String = "SIASG"
    Public tabela As String = "TB_CATMAT_PDM"
    Public pasta_csv As String = "D:\SIASG\04_MATERIAIS\ARQUIVOS\"
    Public erros As Integer = 0
    Public tipo_arquivo As String = "MATERIAIS"
    Public tipo_processo As String = "DOWNLOAD"
    Public mensagem_log As String = ""
    Public produto As String = ""

    Public COD_CLASSE As String = ""
    'SIASG_04_MATERIAIS_DOWNLOAD_GHI_MEDITRONIC
    Sub Main()

        Console.Title = "MEDITRONIC " & tipo_arquivo & " " & tipo_processo & " Inicio " & Now()
        Console.BackgroundColor = ConsoleColor.Green
        Console.WriteLine("INICIO " & Now())
        Console.BackgroundColor = ConsoleColor.Black

        Dim offset As Long = 0
        Try
            Dim sql As String = "Select * FROM [GHI].[VW_GHI_PDM_MEDITRONIC] WHERE [" & tipo_arquivo & "_OFFSET] < 0 "
            Dim dtr As Npgsql.NpgsqlDataReader = ExecuteSelect(sql)
            If dtr.HasRows Then
                Do While dtr.Read()
                    Do
                        Try
                            produto = dtr("COD_PDM").ToString & "-" & dtr("PDM").ToString
                            Dim remoteUri As String = dtr(tipo_arquivo & "_LINK") & "&offset=" & offset
                            Dim fileName As String = pasta_csv & "MATERIAS_PDM_" & Format(Val(dtr("COD_PDM")), "000000") & "_OFFSET_" & Format(offset, "0000000000") & ".CSV"
                            Dim myWebClient As New WebClient()

                            Mensagem("SEARCH   ; " & Now() & "; " & produto & "; offset " & Format(offset, "0000000000"))
                            myWebClient.DownloadFile(remoteUri, fileName)

                            Dim fi As New System.IO.FileInfo(fileName)
                            Dim fi_size As Double = fi.Length
                            If fi_size > 0 Then
                                Mensagem("COMPLETE ; " & Now() & "; " & produto)
                                Mensagem("FILE SAVE; " & Now() & "; " & fileName)
                                ExecuteSQL("UPDATE [" & schema & "].[" & tabela & "] Set [" & tipo_arquivo & "_OFFSET] = " & offset & ", [" & tipo_arquivo & "_ATUALIZACAO] = '" & Agora() & "', [" & tipo_arquivo & "_LOG] = 'SUCESSO' WHERE [Código] = '" & dtr("COD_PDM") & "'")
                                offset += 500
                            Else
                                If offset = 0 Then
                                    erros += 1
                                    Mensagem("NOT FOUND; " & Now() & "; " & produto)
                                    ExecuteSQL("UPDATE [" & schema & "].[" & tabela & "] Set [" & tipo_arquivo & "_OFFSET] = " & -1 & ", [" & tipo_arquivo & "_ATUALIZACAO] = '" & Agora() & "', [" & tipo_arquivo & "_LOG] = 'FALHA - EMPTY FILE OR NOT FOUND' WHERE [Código] = '" & dtr("COD_PDM") & "'")
                                    Exit Do
                                Else
                                    Exit Do
                                End If
                            End If
                        Catch exc2 As Exception
                            If offset = 0 Then
                                ExecuteSQL("UPDATE [" & schema & "].[" & tabela & "] Set [" & tipo_arquivo & "_OFFSET] = " & -1 & ", [" & tipo_arquivo & "_ATUALIZACAO] = '" & Agora() & "', [" & tipo_arquivo & "_LOG] = 'FALHA " & exc2.Message & "' WHERE [Código] = '" & dtr("COD_PDM") & "'")
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
                Mensagem(tipo_arquivo & " " & tipo_processo & " CONCLUIDO SEM ERROS " & Now())
            Else
                Console.BackgroundColor = ConsoleColor.Red
                Mensagem(tipo_arquivo & " " & tipo_processo & " CONCLUIDO COM " & erros & " ERROS " & Now())
            End If
            Console.BackgroundColor = ConsoleColor.Black
            Console.WriteLine("CRIANDO ARQUIVO DE LOG, AGUARDE...")
            Arquivo_Log()
            Console.Title = Console.Title & " Final " & Now()
            Console.WriteLine("CONCLUIDO, PRESSIONE UMA TECLA PARA ENCERRAR - " & Now())
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