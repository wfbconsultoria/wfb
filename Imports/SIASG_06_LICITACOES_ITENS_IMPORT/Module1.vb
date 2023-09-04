
Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Module Module1
    Public titulo_aplicacao As String = "SIASG - LICITACOES ITENS IMPORT"
    Public cnnStr As String = "Server=miro.bihospitalar.com.br;Port=5432;UserId=postgres;Password=@Mepm2412;Database=bih_datasus"
    Public cnn As New Npgsql.NpgsqlConnection
    Public cnn1 As New Npgsql.NpgsqlConnection
    Public cnn2 As New Npgsql.NpgsqlConnection
    Public schema As String = "SIASG"
    Public tabela As String = "TB_LICITACOES_ITENS"
    Public strSql As String

    Public pasta_csv As String = "D:\SIASG\06_LICITACOES_ITENS\ARQUIVOS"
    Public erros As Integer = 0
    Public linha_arquivo As Long = 0
    Public linhas_importadas As Long = 0
    Public tipo_arquivo As String = "LICITACOES_ITENS"
    Public tipo_processo As String = "IMPORT"
    Public mensagem_log As String
    Public importar As Integer = 1

    Public DI As New DirectoryInfo(pasta_csv)
    Public FI As FileInfo
    Public FIs() As FileInfo
    Dim arquivos As Integer

    'VARIAVEIS CORRESPONDENTES As COLUNAS DO ARQUIVO
    Public COD_UASG As String = ""
    Public UASG As String = ""
    Public COD_MODALIDADE As String = ""
    Public MODALIDADE As String = ""
    Public NUMERO_AVISO As String = ""
    Public COD_LICITACAO As String = ""
    Public ITEM_LICITACAO As String = ""
    Public COD_MATERIAL As String = ""
    Public MATERIAL As String = ""
    Public DESCRICAO_MATERIAL As String = ""
    Public QTD As Long = 0
    Public UNIDADE As String = ""
    Public CNPJ_VENCEDOR As String = ""
    Public VALOR_ESTIMADO As Double = 0
    Public CRITERIO As String = ""
    'SIASG_06_LICITACOES_ITENS_IMPORT
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
                            If linha_arquivo = 375 Then
                                Console.WriteLine("375")
                            End If
                            Try
                                linhaAtual = leitorArquivoCSV.ReadFields()
                                '..POSIÇÕES DAS COLUNAS NO ARQUIVO TXT EM D:\SIASG\LICITACOES\ARQUIVOS linhaAtual(i)
                                '0 [UASG]
                                '1 [Modalidade da Licitação]
                                '2 [Número do Aviso da Licitação]
                                '3 [Número da Licitação]
                                '4 [Número do Item na Licitação]
                                '5 [Código do Serviço]
                                '6 [Código do Material]
                                '7 [Descrição do Item]
                                '8 [Item sustentável?]
                                '9 [Quantidade]
                                '10[Unidade de medida]
                                '11[CNPJ do Vencedor]
                                '12[CPF do Vencedor]
                                '13[Benefício]
                                '14[Valor estimado]
                                '15[Decreto 7174]
                                '16[Critério de Julgamento]
                                Try
                                    'define variaveis
                                    COD_UASG = Replace(Mid(linhaAtual(0), 1, InStr(linhaAtual(0), ":")), ":", "")
                                    UASG = Formata_Texto(Right(linhaAtual(0), Len(linhaAtual(0)) - InStr(linhaAtual(0), ":")))
                                    COD_MODALIDADE = Left(Formata_Texto(linhaAtual(1)), 1)
                                    MODALIDADE = Right(Formata_Texto(linhaAtual(1)), Len(Formata_Texto(linhaAtual(1))) - 3)
                                    NUMERO_AVISO = Formata_Texto(linhaAtual(2))
                                    COD_LICITACAO = Right(Formata_Texto(linhaAtual(3)), 17)
                                    ITEM_LICITACAO = Format(Val(linhaAtual(4)), "000")
                                    COD_MATERIAL = Left(Formata_Texto(linhaAtual(6)), 6)
                                    MATERIAL = Right(Formata_Texto(linhaAtual(6)), Len(Formata_Texto(linhaAtual(6))) - 8)
                                    DESCRICAO_MATERIAL = Formata_Texto(linhaAtual(7))
                                    QTD = Val(Formata_Texto(linhaAtual(9)))
                                    UNIDADE = Formata_Texto(linhaAtual(10))
                                    CNPJ_VENCEDOR = Formata_Texto(linhaAtual(11))
                                    VALOR_ESTIMADO = FormataValorReais(linhaAtual(14))
                                    CRITERIO = Formata_Texto(linhaAtual(16))

                                    'VERIFICA SE ALINHA JÁ FOI IMPORTADA
                                    strSql = "SELECT [COD_LICITACAO] FROM [" & schema & "]." & "[" & tabela & "] WHERE [COD_LICITACAO] = '" & COD_LICITACAO & "' AND [ITEM_LICITACAO] = '" & ITEM_LICITACAO & "'"

                                    Dim dtr_LICITACOES As Npgsql.NpgsqlDataReader = ExecuteSelect(strSql)
                                    If dtr_LICITACOES.HasRows Then
                                        Mensagem("LINHA " & Format(linha_arquivo, "000000") & "; COD_LICITACAO " & COD_LICITACAO & " ITEM " & ITEM_LICITACAO & "; JÁ INCLUSA")
                                        GoTo PROXIMA_LINHA
                                    End If

                                    strSql = "INSERT INTO [" & schema & "]." & "[" & tabela & "]("
                                    strSql &= "[COD_LICITACAO],"
                                    strSql &= "[ITEM_LICITACAO],"
                                    strSql &= "[NUMERO_AVISO],"
                                    strSql &= "[COD_MODALIDADE],"
                                    strSql &= "[MODALIDADE],"
                                    strSql &= "[COD_MATERIAL],"
                                    strSql &= "[MATERIAL],"
                                    strSql &= "[DESCRICAO_MATERIAL],"


                                    strSql &= "[QTD],"
                                    strSql &= "[UNIDADE],"
                                    strSql &= "[VALOR_ESTIMADO],"
                                    strSql &= "[COD_UASG],"
                                    strSql &= "[UASG],"
                                    strSql &= "[CNPJ_VENCEDOR],"
                                    strSql &= "[CRITERIO]"
                                    strSql &= ") Values ("


                                    strSql &= "'" & COD_LICITACAO & "',"
                                    strSql &= "'" & ITEM_LICITACAO & "',"
                                    strSql &= "'" & NUMERO_AVISO & "',"
                                    strSql &= "'" & COD_MODALIDADE & "',"
                                    strSql &= "'" & MODALIDADE & "',"
                                    strSql &= "'" & COD_MATERIAL & "',"
                                    strSql &= "'" & MATERIAL & "',"
                                    strSql &= "'" & DESCRICAO_MATERIAL & "',"
                                    strSql &= "'" & QTD & "',"
                                    strSql &= "'" & UNIDADE & "',"
                                    strSql &= "'" & VALOR_ESTIMADO & "',"
                                    strSql &= "'" & COD_UASG & "',"
                                    strSql &= "'" & UASG & "',"
                                    strSql &= "'" & CNPJ_VENCEDOR & "',"
                                    strSql &= "'" & CRITERIO & "'"
                                    strSql &= ")"
                                Catch exLinha As Exception
                                    LogErro(exLinha)
                                    GoTo PROXIMA_LINHA
                                End Try

                                If ExecuteSQL(strSql) = True Then
                                        linhas_importadas += 1
                                        Mensagem("LINHA " & Format(linha_arquivo, "000000") & "; COD_LICITACAO " & COD_LICITACAO & " ITEM " & ITEM_LICITACAO & "; INCLUIDA COM SUCESSO")
                                    Else
                                        Console.BackgroundColor = ConsoleColor.Red
                                        Mensagem("LINHA " & Format(linha_arquivo, "000000") & "; COD_LICITACAO " & COD_LICITACAO & " ITEM " & ITEM_LICITACAO & "; ERRO INCLUSAO")
                                        Console.BackgroundColor = ConsoleColor.Black
                                    End If
                                Catch ex As MalformedLineException
                                    LogErro(ex)
                            End Try
PROXIMA_LINHA:
                        End While

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
                Console.BackgroundColor = ConsoleColor.Black
            Next

        Catch exc3 As Exception
            LogErro(exc3)
        Finally
            Console.WriteLine(tipo_processo & "_" & tipo_arquivo & " CONCLUIDO")
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

    Function FormataValorReais(strValor) As String
        Try
            FormataValorReais = Replace(strValor, "R$", "")
            FormataValorReais = Replace(strValor, ",", "")
        Catch ex As Exception
            FormataValorReais = "0.00"
        End Try
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

