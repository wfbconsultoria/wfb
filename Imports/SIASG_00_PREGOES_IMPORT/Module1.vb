
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
'SIASG_00_PREGOES_IMPORT
Module Module1
    Public cnnStr As String = "Server=miro.bihospitalar.com.br;Port=5432;UserId=postgres;Password=@Mepm2412;Database=bih_datasus"
    Public cnn As New Npgsql.NpgsqlConnection
    Public cnn1 As New Npgsql.NpgsqlConnection
    Public cnn2 As New Npgsql.NpgsqlConnection
    Public schema As String = "SIASG"
    Public tabela As String = "TB_PREGOES_DOWNLOAD_ITENS"
    Public colunas_tabela As Integer = 18
    Public colunas_arquivo As Integer = 0
    Public strSql As String
    Public pasta_csv As String = "D:\SIASG\00_PREGOES\ARQUIVOS"
    Public erros As Integer = 0
    Public linha_arquivo As Long = 0
    Public linhas_importadas As Long = 0
    Public tipo_arquivo As String = "PREGOES"
    Public tipo_processo As String = "IMPORT"
    Public mensagem_log As String

    Public DI As New DirectoryInfo(pasta_csv)
    Public FI As FileInfo
    Public FIs() As FileInfo
    Dim arquivos As Integer


    Sub Main()
        Console.BackgroundColor = ConsoleColor.Green
        Console.Title = "SIASG " & tipo_arquivo & " " & tipo_processo & " Inicio " & Now()
        Console.WriteLine("INICIO " & Now())
        Console.BackgroundColor = ConsoleColor.Black

        Try

            FIs = DI.GetFiles()
            For arquivos = 0 To FIs.Length - 1
                FI = FIs.GetValue(arquivos)
                If FI.Length = 0 Then GoTo PROXIMO_ARQUIVO
                Mensagem("IMPORTANDO - " & FI.FullName & " - " & FI.Length)

                Using leitorArquivoCSV As New TextFieldParser(FI.FullName)
                    'define o tipo de arquivo como delimitado
                    leitorArquivoCSV.TextFieldType = FileIO.FieldType.Delimited
                    'define o delimitador usado no arquivo
                    leitorArquivoCSV.SetDelimiters(",")
                    ''Informa que existe um campo que esta envolto em aspas duplas (")
                    leitorArquivoCSV.HasFieldsEnclosedInQuotes = True
                    'define um array de string
                    Dim linhaAtual As String()
                    'pula a primeira linha do arquivo 
                    leitorArquivoCSV.ReadLine()

                    'LER A LINHAS DO ARQUIVO E INSERE NO BANCO
                    linha_arquivo = 1
                    While Not leitorArquivoCSV.EndOfData
                        linha_arquivo += 1
                        Try
                            linhaAtual = leitorArquivoCSV.ReadFields()
                            Dim campoAtual As String

                            strSql = "INSERT INTO [" & schema & "]." & "[" & tabela & "] ("
                            strSql &= "[Numero do Pregao],"
                            strSql &= "[Número portaria],"
                            strSql &= "[Data portaria],"
                            strSql &= "[Código processo],"
                            strSql &= "[Tipo do pregão],"
                            strSql &= "[Tipo de compra],"
                            strSql &= "[Objeto do pregão],"
                            strSql &= "[UASG],"
                            strSql &= "[Situação do pregão],"
                            strSql &= "[Data de Abertura do Edital],"
                            strSql &= "[Data de início da proposta],"
                            strSql &= "[Data do fim da proposta],"
                            strSql &= "[Resultados do pregão > uri],"
                            strSql &= "[Declarações do pregão > uri],"
                            strSql &= "[Termos do pregão > uri],"
                            strSql &= "[Orgão do pregão > uri],"
                            strSql &= "[Itens do pregão > uri]"
                            strSql &= ") Values ("
                            colunas_arquivo = 0
                            For Each campoAtual In linhaAtual
                                colunas_arquivo += 1
                                strSql &= "'" & campoAtual & "',"
                                If colunas_arquivo = colunas_tabela Then Exit For
                            Next

                            'strSql &= "'" & linhaAtual(0) & "',"
                            'strSql &= "'" & linhaAtual(1) & "',"
                            'strSql &= "'" & linhaAtual(2) & "',"
                            'strSql &= "'" & Formata_Texto(linhaAtual(0)) & "',"
                            'strSql &= "'" & Formata_Texto(linhaAtual(1)) & "',"
                            'strSql &= "'" & Left(Formata_Texto(linhaAtual(2)), 2) & "',"
                            'strSql &= "'" & FI.Name & "',"
                            'strSql &= "'" & Format(linha_arquivo, "000000") & "',"
                            'strSql &= "'" & Agora() & "',"
                            'strSql &= "'SUCESSO',"
                            'strSql &= 0
                            strSql &= ")"
                            strSql = Replace(strSql, ",)", ")")

                            If ExecuteSQL(strSql) = True Then
                                linhas_importadas += 1
                                Console.WriteLine("LINHA " & Format(linha_arquivo, "00000000") & "; INCLUIDO COM SUCESSO")
                            Else
                                Console.BackgroundColor = ConsoleColor.Red
                                Console.WriteLine("LINHA " & Format(linha_arquivo, "00000000") & "; ERRO")
                                Console.BackgroundColor = ConsoleColor.Black
                            End If

                        Catch ex As MalformedLineException
                            LogErro(ex)
                        End Try
PROXIMA_LINHA:
                    End While

                    'MOVE ARQUIVO PARA A PASTA IMPORTADOS
                    leitorArquivoCSV.Close()
                    Try
                        FI.CopyTo(pasta_csv & "\COPIA\" & FI.Name)
                        FI.MoveTo(pasta_csv & "\IMPORTADOS\" & TimeStamp() & "_" & FI.Name)
                    Catch excMoveFile As Exception
                        LogErro(excMoveFile)
                    End Try
                End Using

PROXIMO_ARQUIVO:
                If FI.Length = 0 Then
                    Console.BackgroundColor = ConsoleColor.Red
                    Mensagem("FILE EMPTY " & FI.Name)
                    Console.BackgroundColor = ConsoleColor.Black
                End If
                Console.BackgroundColor = ConsoleColor.Black
            Next

        Catch exc1 As Exception
            LogErro(exc1)
        Finally

        End Try
        Console.WriteLine(tipo_processo & "_" & tipo_arquivo & " CONCLUIDO")
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
            ExecuteSQL = False
            LogErro(e, SQL)
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
        Console.WriteLine(mensagem & vbCrLf)
        mensagem_log = mensagem_log & mensagem & vbCrLf
    End Sub
    Public Sub LogErro(e As Exception, Optional mensagem_erro As String = "")
        erros += 1
        Console.BackgroundColor = ConsoleColor.Red
        If mensagem_erro = "" Then
            Mensagem("LINHA;" & Format(linha_arquivo, "000000") & ";ERRO;" & Replace(e.Message.ToString, vbCrLf, " "))
        Else
            Mensagem("LINHA;" & Format(linha_arquivo, "000000") & ";ERRO;" & Replace(e.Message.ToString, vbCrLf, " ") & ";" & mensagem_erro)
        End If
        
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

    Function Formata_Texto(texto As String)
        Try
            If Len(texto) = 0 Or IsDBNull(texto) Then texto = ""
            texto = UCase(texto)
            texto = Substitui_Palavras(texto)
            texto = Trim(texto)
            'texto = Regex.Replace(texto, "[^\w\.@-]", "")
            texto = Replace(texto, Chr(39), "")
            texto = Replace(texto, Chr(34), "")
            texto = Replace(texto, "~", "")
            texto = Replace(texto, "^", "")
            texto = Replace(texto, "`", "")
            texto = Replace(texto, "´", "")
            texto = Replace(texto, "¨", "")
            texto = Replace(texto, ",", " ")
            texto = Replace(texto, ";", " ")
            texto = Replace(texto, "|", " ")
            texto = Replace(texto, "&", " ")
            texto = Replace(texto, "#", "")

            texto = Replace(texto, "Á", "A")
            texto = Replace(texto, "À", "A")
            texto = Replace(texto, "Â", "A")
            texto = Replace(texto, "Ã", "A")
            texto = Replace(texto, "Ä", "A")

            texto = Replace(texto, "É", "E")
            texto = Replace(texto, "È", "E")
            texto = Replace(texto, "Ê", "E")
            texto = Replace(texto, "Ë", "E")

            texto = Replace(texto, "Í", "I")
            texto = Replace(texto, "Ì", "I")
            texto = Replace(texto, "Î", "I")
            texto = Replace(texto, "", "I")
            texto = Replace(texto, "Ï", "I")

            texto = Replace(texto, "Ó", "O")
            texto = Replace(texto, "Ò", "O")
            texto = Replace(texto, "Ô", "O")
            texto = Replace(texto, "Õ", "O")
            texto = Replace(texto, "Ö", "O")

            texto = Replace(texto, "Ç", "C")

            texto = Replace(texto, "Ú", "U")
            texto = Replace(texto, "Ù", "U")
            texto = Replace(texto, "Û", "U")
            texto = Replace(texto, "Ü", "U")

            texto = Replace(texto, "Ñ", "N")
            texto = Replace(texto, "Ý", "Y")
        Catch
            texto = "ERRO CONVERSAO"
        End Try

        Formata_Texto = texto
    End Function
    Function Substitui_Palavras(texto As String) As String
        Try
            texto = Replace(texto, "MA-NUTENÇÃO", "MANUTENCAO")
            texto = Replace(texto, "REATO-RES", "REATORES")
            texto = Replace(texto, "Ó-TICAS", "OTICA")
            texto = Replace(texto, "VETERINÁ-RIO", "VETERINARIO")
            texto = Replace(texto, "TEX-TO", "TEXTO")
            texto = Replace(texto, "DISTRI-BUIÇÃO", "DISTRIBUICAO")
            texto = Replace(texto, "CIRCULAÇÃODE", "CIRCULACAO DE")
            texto = Replace(texto, "CIRCULAÇÃODE", "CIRCULACAO DE")
            texto = Replace(texto, "CIRCULAÇÃODE", "CIRCULACAO DE")
            texto = Replace(texto, "CIRCULAÇÃODE", "CIRCULACAO DE")
            Substitui_Palavras = texto
        Catch
            Substitui_Palavras = texto
        End Try

    End Function
End Module

