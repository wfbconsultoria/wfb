Imports System.Net
Imports System.IO
Imports System.Net.WebRequestMethods

'SIASG_00_FORNECEDORES_DOWNLOAD
Module Module1
    'INFORMAÇÕES DE CONEXÃO
    Public cnnStr As String = "Server=miro.bihospitalar.com.br;Port=5432;UserId=postgres;Password=@Mepm2412;Database=bih_datasus"
    Public cnn As New Npgsql.NpgsqlConnection
    Public cnn1 As New Npgsql.NpgsqlConnection
    Public cnn2 As New Npgsql.NpgsqlConnection
    Public schema As String = "SIASG"
    Public tabela As String = "TB_FORNECEDORES_DOWNLOAD"
    Public view_download As String = "DOWNLOAD_00_FORNECEDORES"
    Public sql As String = ""

    'PASTA DE APLICAÇÃO ARQUIVOS ETC
    'Public pasta_csv As String = "D:\SIASG\00_FORNECEDORES\ARQUIVOS\"
    Public pasta_csv As String = "ftp://miro.bihospitalar.com.br/SIASG/00_FORNECEDORES/ARQUIVOS/"
    Public erros As Integer = 0
    Public tipo_arquivo As String = "FORNECEDORES"
    Public tipo_processo As String = "DOWNLOAD"
    Public mensagem_log As String

    Public OFF_SET As String = ""
    Public OPT_DOWNLOAD As String = ""
    'Public Property Timeout As Integer
    'SIASG_00_FORNECEDORES_DOWNLOAD
    Sub Main()

        Console.Title = tipo_arquivo & " " & tipo_processo & " Inicio " & Now()
        Console.BackgroundColor = ConsoleColor.Green
        Console.WriteLine(tipo_arquivo & " " & tipo_processo & " Inicio " & Now())

TENTAR_NOVAMENTE:
        Console.WriteLine(vbCrLf)
        Console.BackgroundColor = ConsoleColor.DarkBlue
        Console.WriteLine("SELECIONE A OPÇÃO DE DOWNLOAD")
        Console.WriteLine("1 - NÃO PROCESSADAS")
        Console.WriteLine("2 - PROCESSADAS COM FALHA (tentar novamente)")
        Console.WriteLine("3 - PROCESSADAS NÃO ENCONTRADAS (procurar novamente) ")
        Console.WriteLine("4 - TODAS")
        Console.WriteLine("5 - ENCERRAR DOWNLOAD")
        OPT_DOWNLOAD = Console.ReadLine
        Console.BackgroundColor = ConsoleColor.Black

        'MONTA SQL CONFORME A OPÇÃO SELECIONADAs
        sql = "SELECT * FROM [" & schema & "].[" & view_download & "]"
        Select Case OPT_DOWNLOAD
            Case = "1"
                sql &= " WHERE [LOG_DOWNLOAD] IS NULL "
                Console.Title = tipo_arquivo & " (NÃO PROCESSADAS) " & tipo_processo & " Inicio " & Now()
            Case = "2"
                sql &= " WHERE [ERRO] IS NOT NULL  AND [FOUND] Is NULL "
                Console.Title = tipo_arquivo & " (COM FALHA) " & tipo_processo & " Inicio " & Now()
            Case = "3"
                sql &= " WHERE [FOUND] IS NOT NULL "
                Console.Title = tipo_arquivo & " (NÃO ENCONTRADAS) " & tipo_processo & " Inicio " & Now()
            Case = "4"
                Console.Title = tipo_arquivo & " (TODAS) " & tipo_processo & " Inicio " & Now()

                'ESTE PROCESSO AINDA PRECISA DE MANUTENÇÃO
                Console.Title = tipo_arquivo & " " & tipo_processo & " ENCERRADO " & Now()
                Console.BackgroundColor = ConsoleColor.DarkYellow
                Console.WriteLine("ESTA OPÇÃO AINDA ESTÁ EM MANUTENÇÃO")
                Console.WriteLine("PRESSIONE PARA SELECIONAR OUTRA OPÇÃO")
                Console.ReadLine()
                GoTo TENTAR_NOVAMENTE

            Case = "5"
                Console.Title = tipo_arquivo & " " & tipo_processo & " ENCERRADO " & Now()
                Console.BackgroundColor = ConsoleColor.Red
                Console.WriteLine("PRESSIONE UMA TECLA PARA ENCERRAR")
                Console.ReadLine()
                GoTo FINAL
            Case Else
                Console.WriteLine(OPT_DOWNLOAD & " OPÇÃO INVÁLIDA, TENTE NOVAMENTE")
                GoTo TENTAR_NOVAMENTE
        End Select
        sql &= " ORDER BY [OFF_SET] "

        Try
            'Abre Tabela e varre todos os registros
            Dim dtr As Npgsql.NpgsqlDataReader = ExecuteSelect(sql)
            If dtr.HasRows Then
                Do While dtr.Read()
                    OFF_SET = dtr("OFF_SET")
                    Try
                        Dim remoteUri As String = dtr("LINK_DOWNLOAD")
                        Dim fileName As String = pasta_csv & dtr("ARQUIVO")
                        Dim myWebClient As New WebClient()

                        'Mensagem("SEARCH   ; " & Now() & "; " & fileName)
                        Dim i As Double = myWebClient.Timeout
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
                        ExecuteSQL("UPDATE [" & schema & "].[" & tabela & "] Set [LOG_DOWNLOAD] = 'ERRO - " & Replace((exc2.ToString), "'", "") & "', [DATA_DOWNLOAD] ='" & Agora() & "' WHERE [OFF_SET] = " & dtr("OFF_SET"))
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
            Console.Title = tipo_arquivo & " " & tipo_processo & " Inicio " & Now()
            Console.BackgroundColor = ConsoleColor.Yellow
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
    Private Class WebClient
        Inherits System.Net.WebClient
        Public Property Timeout As Integer = 100
        Protected Overrides Function GetWebRequest(ByVal uri As Uri) As WebRequest
            Dim lWebRequest As WebRequest = MyBase.GetWebRequest(uri)
            lWebRequest.Timeout = Timeout
            CType(lWebRequest, HttpWebRequest).ReadWriteTimeout = Timeout
            Return lWebRequest
        End Function
    End Class
End Module
