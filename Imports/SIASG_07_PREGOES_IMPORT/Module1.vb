
Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Module Module1
    Public titulo_aplicacao As String = "SIASG - PREGOES IMPORT"
    Public cnnStr As String = "Server=miro.bihospitalar.com.br;Port=5432;UserId=postgres;Password=@Mepm2412;Database=bih_datasus"
    Public cnn As New Npgsql.NpgsqlConnection
    Public cnn1 As New Npgsql.NpgsqlConnection
    Public cnn2 As New Npgsql.NpgsqlConnection
    Public schema As String = "SIASG"
    Public tabela As String = "TB_PREGOES"
    Public strSql As String

    Public pasta_csv As String = "D:\SIASG\07_PREGOES\ARQUIVOS"
    Public erros As Integer = 0
    Public linha_arquivo As Long = 0
    Public linhas_importadas As Long = 0
    Public tipo_arquivo As String = "PREGOES"
    Public tipo_processo As String = "IMPORT"
    Public mensagem_log As String
    Public importar As Integer = 1

    Public DI As New DirectoryInfo(pasta_csv)
    Public FI As FileInfo
    Public FIs() As FileInfo
    Dim arquivos As Integer

    Public COD_LICITACAO As String = ""
    Public COD_PREGAO As String = ""
    Public COD_PROCESSO As String = ""
    Public TIPO_PREGAO As String = ""
    Public OBJETO_PREGAO As String = ""
    Public COD_UASG As String = ""
    Public NOME_UASG As String = ""
    Public SITUACAO_PREGAO As String = ""
    Public ANO_EDITAL As String = ""
    Public MES_EDITAL As String = ""

    Public ITENS_IMPORTAR As Integer = 0
    Public ITENS_LINK As String = ""
    Public ITENS_OFFSET As Integer = -1
    Public ITENS_ATUALIZACAO As String = ""
    Public ITENS_LOG As String = ""

    Public RESULTADOS_IMPORTAR As Integer = 0
    Public RESULTADOS_LINK As String = ""
    Public RESULTADOS_OFFSET As Integer = -1
    Public RESULTADOS_ATUALIZACAO As String = ""
    Public RESULTADOS_LOG As String = ""

    Public NUMERO_PREGAO As String = ""
    Public COD_MODALIDADE As String = ""
    Public MODALIDADE As String = ""

    'SIASG_07_PREGOES_IMPORT
    Sub Main()
        Console.Title = "SIASG " & tipo_arquivo & " " & tipo_processo & " Inicio " & Now()
        Console.BackgroundColor = ConsoleColor.Yellow
        Console.WriteLine(tipo_arquivo & " " & tipo_processo & " Inicio " & Now())
        Console.BackgroundColor = ConsoleColor.Black

        Try
            FIs = DI.GetFiles()
            For arquivos = 0 To FIs.Length - 1
                Try
                    FI = FIs.GetValue(arquivos)
                    If FI.Length = 0 Then
                        Console.BackgroundColor = ConsoleColor.Red
                        Mensagem("FILE EMPTY " & FI.Name)
                        Console.BackgroundColor = ConsoleColor.Black
                        FI.Delete()
                        GoTo PROXIMO_ARQUIVO
                    End If
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

                        'LE A LINHAS DO ARQUIVO E INSERE NO BANCO
                        linha_arquivo = 1
                        linhas_importadas = 0
                        While Not leitorArquivoCSV.EndOfData
                            linha_arquivo += 1
                            Try
                                linhaAtual = leitorArquivoCSV.ReadFields()
                                ',,,,,,,,,,,,,,,,
                                '..POSIÇÕES DAS COLUANS NO ARQUIVO TXT EM D:\SIASG\LICITACOES\ARQUIVOS linhaAtual(i)
                                '0 [Numero do Pregao]
                                '1 [Número portaria]
                                '2 [Data portaria]
                                '3 [Código processo]
                                '4 [Tipo do pregão]
                                '5 [Tipo de compra]
                                '6 [Objeto do pregão]
                                '7 [UASG]
                                '8 [Situação do pregão]
                                '9 [Data de Abertura do Edital]
                                '10[Data de início da proposta]
                                '11[Data do fim da proposta]
                                '12[Resultados do pregão > uri]
                                '13[Declarações do pregão > uri]
                                '14[Termos do pregão > uri]
                                '15[Orgão do pregão > uri]
                                '16[Itens do pregão > uri]

                                'PREGOES_11240805000012022_OFFSET_0000000000
                                'PREGOES_01000105000012020_OFFSET_0000000000

                                'define variaveis
                                COD_LICITACAO = Mid(FI.Name, 9, 17)
                                COD_PREGAO = Left(COD_LICITACAO, 7) & Right(COD_LICITACAO, 9)
                                NUMERO_PREGAO = Val(Right(COD_LICITACAO, 9))
                                COD_PROCESSO = Formata_Texto(linhaAtual(3))
                                TIPO_PREGAO = Formata_Texto(linhaAtual(4))
                                OBJETO_PREGAO = Formata_Texto(linhaAtual(6))
                                COD_UASG = Replace(Mid(linhaAtual(7), 1, InStr(linhaAtual(7), ":")), ":", "")
                                NOME_UASG = Formata_Texto(Right(linhaAtual(7), Len(linhaAtual(7)) - InStr(linhaAtual(7), ":")))
                                SITUACAO_PREGAO = ""
                                ANO_EDITAL = Mid(Formata_Texto(linhaAtual(9)), 7, 4)
                                MES_EDITAL = Mid(Formata_Texto(linhaAtual(9)), 4, 2)
                                ITENS_IMPORTAR = 1  'If(ANO_EDITAL > 2020, 1, 0) 'IMPORTA SOMENTE SE ANO FOR MAIOR QUE 2020
                                ITENS_LINK = "http://compras.dados.gov.br/pregoes/doc/pregao/" & COD_PREGAO & "/itens.csv"
                                ITENS_OFFSET = -1
                                ITENS_ATUALIZACAO = ""
                                ITENS_LOG = ""
                                RESULTADOS_IMPORTAR = If(ANO_EDITAL > 2020, 1, 0) 'IMPORTA SOMENTE SE ANO FOR MAIOR QUE 2020
                                RESULTADOS_LINK = "http://compras.dados.gov.br/pregoes/v1/resultados_pregao.csv?nu_pregao=" & NUMERO_PREGAO & "co_uasg=" & COD_UASG & ","
                                RESULTADOS_OFFSET = -1
                                RESULTADOS_ATUALIZACAO = ""
                                RESULTADOS_LOG = ""
                                COD_MODALIDADE = Mid(COD_LICITACAO, 8, 1)
                                MODALIDADE = ""

                                'VERIFICA SE ALINHA JÁ FOI IMPORTADA
                                strSql = "SELECT [COD_LICITACAO] FROM [" & schema & "]." & "[" & tabela & "] WHERE [COD_LICITACAO] = '" & COD_LICITACAO & "'"
                                Dim dtr_PREGOES As Npgsql.NpgsqlDataReader = ExecuteSelect(strSql)
                                If dtr_PREGOES.HasRows Then
                                    Mensagem("LINHA " & Format(linha_arquivo, "000000") & "; PREGAO PARA COD_LICITACAO " & COD_LICITACAO & "; JÁ INCLUSA")
                                    GoTo PROXIMA_LINHA
                                End If

                                strSql = "INSERT INTO [" & schema & "]." & "[" & tabela & "]("
                                strSql &= "[COD_LICITACAO],"
                                strSql &= "[COD_PREGAO],"
                                strSql &= "[COD_PROCESSO],"
                                strSql &= "[TIPO_PREGAO],"
                                strSql &= "[OBJETO_PREGAO],"
                                strSql &= "[COD_UASG],"
                                strSql &= "[NOME_UASG],"
                                strSql &= "[ANO_EDITAL],"
                                strSql &= "[MES_EDITAL],"
                                strSql &= "[ITENS_IMPORTAR],"
                                strSql &= "[ITENS_LINK],"
                                strSql &= "[ITENS_OFFSET],"
                                strSql &= "[RESULTADOS_IMPORTAR],"
                                strSql &= "[RESULTADOS_LINK],"
                                strSql &= "[RESULTADOS_OFFSET],"
                                strSql &= "[NUMERO_PREGAO],"
                                strSql &= "[COD_MODALIDADE]"
                                strSql &= ") Values ("
                                strSql &= "'" & COD_LICITACAO & "',"
                                strSql &= "'" & COD_PREGAO & "',"
                                strSql &= "'" & COD_PROCESSO & "',"
                                strSql &= "'" & TIPO_PREGAO & "',"
                                strSql &= "'" & OBJETO_PREGAO & "',"
                                strSql &= "'" & COD_UASG & "',"
                                strSql &= "'" & NOME_UASG & "',"
                                strSql &= "'" & ANO_EDITAL & "',"
                                strSql &= "'" & MES_EDITAL & "',"
                                strSql &= "'" & ITENS_IMPORTAR & "',"
                                strSql &= "'" & ITENS_LINK & "',"
                                strSql &= "'" & ITENS_OFFSET & "',"
                                strSql &= "'" & RESULTADOS_IMPORTAR & "',"
                                strSql &= "'" & RESULTADOS_LINK & "',"
                                strSql &= "'" & RESULTADOS_OFFSET & "',"
                                strSql &= "'" & NUMERO_PREGAO & "',"
                                strSql &= "'" & COD_MODALIDADE & "'"
                                strSql &= ")"

                                If ExecuteSQL(strSql) = True Then
                                    linhas_importadas += 1
                                    Mensagem("LINHA " & Format(linha_arquivo, "000000") & "; COD_PREGAO " & COD_PREGAO & "; INCLUIDO COM SUCESSO")
                                Else
                                    Console.BackgroundColor = ConsoleColor.Red
                                    Mensagem("LINHA " & Format(linha_arquivo, "000000") & "; COD_PREGAO " & COD_PREGAO & "; ERRO INCLUSAO; " & strSql & "")
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
                Catch exc1 As Exception
                    LogErro(exc1)
                Finally
                End Try
PROXIMO_ARQUIVO:
            Next

        Catch exc3 As Exception
            LogErro(exc3)
        Finally
            Console.WriteLine(tipo_processo & "_" & tipo_arquivo & " CONCLUIDO")
            If erros = 0 Then
                Console.BackgroundColor = ConsoleColor.Green
                Mensagem("SEM ERROS")
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
    End Sub
    Function ConectaBanco() As Boolean
        Try
            'Conexão Postgres
            cnn = New Npgsql.NpgsqlConnection(cnnStr)
            cnn.Open()
            ConectaBanco = True
        Catch e As Exception
            Console.BackgroundColor = ConsoleColor.Red
            Mensagem("ERRO CONEXÃO BANCO DE DADOS")
            Console.BackgroundColor = ConsoleColor.Black
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
        Console.WriteLine(mensagem)
        mensagem_log = mensagem_log & mensagem & vbCrLf
    End Sub
    Public Sub LogErro(e As Exception, Optional mensagem_erro As String = "")
        erros += 1
        Console.BackgroundColor = ConsoleColor.Red
        If mensagem_erro = "" Then
            Mensagem("LINHA " & Format(linha_arquivo, "000000") & "; ERRO;" & Replace(e.Message.ToString, vbCrLf, " "))
        Else
            Mensagem("LINHA " & Format(linha_arquivo, "000000") & "; ERRO;" & Replace(e.Message.ToString, vbCrLf, " ") & "; " & mensagem_erro)
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

            texto = Substitui_Palavras(texto)
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
            texto = Replace(texto, "HOSPI TALAR", "HOSPITALAR")
            texto = Replace(texto, "SECRETARI A", " SECRETARIA")
            texto = Replace(texto, "PRODU TOS", "PRODUTOS")
            texto = Replace(texto, "ESPECIFIC ACOES", "ESPECIFICACOES")
            texto = Replace(texto, "MATER IAL", "MATERIAL")
            texto = Replace(texto, "EQUIP AMENTOS", "EQUIPAMENTOS")
            texto = Replace(texto, "ES CALPES", "ESCALPES")
            texto = Replace(texto, "MEDICAME NTOS", "MEDICAMENTOS")
            texto = Replace(texto, "ESTERIL IZACAO", "ESTERILIZACAO")
            texto = Replace(texto, "AN TI", "ANTI")
            texto = Replace(texto, "ANTISS EPTICOS", "ANTISSEPTICOS")
            texto = Replace(texto, "HIGIENI ZACAO", "HIGIENIZACAO")
            texto = Replace(texto, "SAUD E", "SAUDE")
            texto = Replace(texto, "DESFI BRILADOR", "DESFIBRILADOR")

            Substitui_Palavras = texto
        Catch
            Substitui_Palavras = texto
        End Try

    End Function
End Module

