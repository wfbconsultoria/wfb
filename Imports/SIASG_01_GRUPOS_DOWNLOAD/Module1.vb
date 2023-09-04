Imports System.Net
Imports System.IO

Module Module1
    Public cnnStr As String = "Server=miro.bihospitalar.com.br;Port=5432;UserId=postgres;Password=@Mepm2412;Database=bih_datasus"
    Public cnn As New Npgsql.NpgsqlConnection
    Public cnn1 As New Npgsql.NpgsqlConnection
    Public cnn2 As New Npgsql.NpgsqlConnection
    Public schema As String = "SIASG"
    Public pasta_csv As String = "D:\SIASG\01_GRUPOS\ARQUIVOS"
    Public erros As Integer = 0
    Public tipo_arquivo As String = "GRUPOS"
    Public tipo_processo As String = "DOWNLOAD"
    Public mensagem_log As String

    Sub Main()
        Console.Title = "SIASG " & tipo_arquivo & " " & tipo_processo & " Inicio " & Now()
        Console.WriteLine("INICIO " & Now())
        Try
            Dim remoteUri As String = "http://compras.dados.gov.br/materiais/v1/grupos.csv"
            Dim fileName As String = pasta_csv & "\000000_" & tipo_arquivo & "_OFFSET_0000000000" & ".CSV"
            Dim myWebClient As New WebClient()
            Mensagem("SEARCH " & fileName)

            myWebClient.DownloadFile(remoteUri, fileName)
            Mensagem("DOWNLOAD COMPLETE " & fileName)

        Catch exc1 As Exception
            LogErro(exc1)
        Finally

        End Try
        Console.WriteLine("DOWNLOAD " & tipo_arquivo & " CONCLUIDO")
        If erros = 0 Then
            Console.BackgroundColor = ConsoleColor.Green
            Mensagem("SEM ERROS")
        Else
            Console.BackgroundColor = ConsoleColor.Red
            Console.WriteLine(erros & " ERROS - ")
        End If
        Console.BackgroundColor = ConsoleColor.Black
        Console.WriteLine("CRIANDO ARQUIVO DE LOG, AGUARDE...")
        Arquivo_Log()
        Console.WriteLine("CONCLUIDO " & Now() & " PRESSIONE UMA TECLA PARA ENCERRAR")
        Console.Read()
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
        Dim log_filename As String = pasta_csv & "\LOG\LOG_" & tipo_processo & "_" & tipo_arquivo & "_" & TimeStamp() & ".txt"
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
