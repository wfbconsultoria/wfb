
Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Module Module1
    Public titulo_aplicacao As String = "SIASG - PROPOSTAS IMPORT"
    Public cnnStr As String = "Server=miro.bihospitalar.com.br;Port=5432;UserId=postgres;Password=@Mepm2412;Database=bih_datasus"
    Public cnn As New Npgsql.NpgsqlConnection
    Public cnn1 As New Npgsql.NpgsqlConnection
    Public cnn2 As New Npgsql.NpgsqlConnection
    Public schema As String = "SIASG"
    Public tabela As String = "TB_PROPOSTAS"
    Public strSql As String

    Public pasta_csv As String = "D:\SIASG\09_PROPOSTAS\ARQUIVOS"
    Public erros As Integer = 0
    Public erros_import As Integer = 0
    Public linha_arquivo As Long = 0
    Public linhas_importadas As Long = 0
    Public tipo_arquivo As String = "PROPOSTAS"
    Public tipo_processo As String = "IMPORT"
    Public mensagem_log As String
    Public importar As Integer = 1

    Public DI As New DirectoryInfo(pasta_csv)
    Public FI As FileInfo
    Public FIs() As FileInfo
    Dim arquivos As Integer

    'VARIAVEIS CORRESPONDENTES As COLUNAS DO ARQUIVO
    Public COD_LICITACAO As String = ""
    Public COD_ITEM As String = ""
    'SIASG_09_PROPOSTAS_IMPORT
    Sub Main()
        Console.Title = "SIASG " & tipo_arquivo & " " & tipo_processo & " Inicio " & Now()
        Try
            FIs = DI.GetFiles()
            For arquivos = 0 To FIs.Length - 1
                FI = FIs.GetValue(arquivos)
                If FI.Length = 0 Then
                    Console.BackgroundColor = ConsoleColor.Red
                    Mensagem("FILE EMPTY " & FI.Name)
                    Console.BackgroundColor = ConsoleColor.Black
                    FI.Delete()
                    GoTo PROXIMO_ARQUIVO
                End If

                Try

                    FI = FIs.GetValue(arquivos) 'PROPOSTAS_01000105000022021_24632660
                    Mensagem("IMPORTANDO - " & FI.FullName & " - " & FI.Length)
                    Dim arquivo As String = Replace(FI.Name, ".CSV", "")
                    COD_LICITACAO = Mid(arquivo, 11, 17)
                    COD_ITEM = Right(arquivo, Len(arquivo) - 28)

                    'APAGA LINHAS DA PROPOSTA ANTES DE IMPORTAR PARA NÃO DUPLICAR
                    strSql = "DELETE FROM |" & schema & "|." & "|" & tabela & "| WHERE |COD_LICITACAO| = '" & COD_LICITACAO & "' AND |COD_ITEM| = '" & COD_ITEM & "'"
                    ExecuteSQL(strSql)
                    'ATUALIZA STATUS DO ITEM NA TABELA PREGÕES ITENS
                    strSql = "UPDATE |" & schema & "|.|TB_PREGOES_ITENS| SET "
                    strSql &= "|PROPOSTA_IMPORTADA| = 0,"
                    strSql &= "|PROPOSTA_IMPORTADA_STATUS| = 'IMPORTAR',"
                    strSql &= "|PROPOSTA_IMPORTADA_LINHAS| = 0,"
                    strSql &= "|PROPOSTA_IMPORTADA_ERROS| = 0"
                    strSql &= " WHERE |COD_LICITACAO| = '" & COD_LICITACAO & "' AND |COD_ITEM| = '" & COD_ITEM & "'"
                    ExecuteSQL(strSql)

                    'importar ARQUIVOS DE PROPOSTAS
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
                        erros_import = 0

                        While Not leitorArquivoCSV.EndOfData
                            Try
                                linha_arquivo += 1
                                linhaAtual = leitorArquivoCSV.ReadFields()

                                'POSIÇÕES DAS COLUNAS NO ARQUIVO TXT EM D:\SIASG\PREGOES_ITENS\ARQUIVOS linhaAtual(i)
                                '1 [Descrição do Item] character varying(4096)
                                '2 [Quantidade de itens] character varying(128)
                                '3 [Valor estimado do item] character varying(2128)
                                '4 [Descrição complementar do item] character varying(8192)
                                '4 [Tratamento diferenciado] character varying(128)
                                '6 [Decreto 7174] character varying(128)
                                '7 [Margem preferencial] character varying(128)
                                '8 [Unidade de fornecimento] character varying(128)
                                '9 [Situação do item] character varying(128)
                                '10[Fornecedor vencedor] character varying(4096)
                                '11[Valor menor lance] character varying(128)
                                '12[Número cpf/cnpj fornecedor] character varying(128)
                                '13[Fornecedor proposta] character varying(4096)
                                '14[Marca do item] character varying(4096)
                                '15[Descrição fabricante do item] character varying(8192)
                                '16[Descrição detalhada do item] character varying(4096)
                                '17[Porte da empresa] character varying(128)
                                '18[Declaração ME/EPP/COOP] character varying(128)
                                '19[Quantidade itens da proposta] character varying(128)
                                '20[Valor unitário] character varying(128)
                                '21[Valor global] character varying(128)
                                '22[Desconto] character varying(128)
                                '23[Valor com Desconto] character varying(128)
                                '24[Data do registro] character varying(128)
                                '25[Data das declarações] character varying(128)
                                '26[Declaração superveniente] character varying(128)
                                '27[Declaração infantil] character varying(128)
                                '28[Declaração independente] character varying(128)
                                '29[Descrição declaração ciência] character varying(4096)
                                '30[Descrição motivo cancelamento] character varying(4096)
                                '31[Valor classificado] character varying(128)
                                '32[Valor negociado] character varying(128)
                                '33[Observações] character varying(255)
                                '34[Anexos da proposta > uri] character varying(4096)

                                strSql = "INSERT INTO |" & schema & "|." & "|" & tabela & "|("
                                strSql &= "|Descrição do Item|, |Quantidade de itens|, |Valor estimado do item|, |Descrição complementar do item|,"
                                strSql &= "|Tratamento diferenciado|, |Decreto 7174|, |Margem preferencial|, |Unidade de fornecimento|,"
                                strSql &= "|Situação do item|, |Fornecedor vencedor|, |Valor menor lance|, |Número cpf/cnpj fornecedor|, |Fornecedor proposta|,"
                                strSql &= "|Marca do item|, |Descrição fabricante do item|, |Descrição detalhada do item|, |Porte da empresa|,"
                                strSql &= "|Declaração ME/EPP/COOP|, |Quantidade itens da proposta|, |Valor unitário|, |Valor global|, |Desconto|,"
                                strSql &= "|Valor com Desconto|, |Data do registro|, |Data das declarações|, |Declaração superveniente|, |Declaração infantil|,"
                                strSql &= "|Declaração independente|, |Descrição declaração ciência|, |Descrição motivo cancelamento|, |Valor classificado|,"
                                strSql &= "|Valor negociado|, |Observações|, |Anexos da proposta > uri|,"
                                strSql &= "|COD_LICITACAO|, |COD_ITEM|"
                                strSql &= ")"
                                strSql &= "VALUES("
                                For Each campoAtual In linhaAtual
                                    strSql &= "'" & Trim(Left(Formata_Texto(campoAtual.ToString), 4195)) & "',"
                                Next
                                strSql &= "'" & COD_LICITACAO & "',"
                                strSql &= "'" & COD_ITEM & "')"

                                If ExecuteSQL(strSql) = True Then
                                    linhas_importadas += 1
                                    Mensagem("PROPOSTAS LINHA " & Format(linha_arquivo, "000000") & " INCLUIDA COM SUCESSO")
                                Else
                                    erros_import += 1
                                    Console.BackgroundColor = ConsoleColor.Red
                                    Mensagem("PROPOSTAS LINHA " & Format(linha_arquivo, "000000") & " ERRO INCLUSAO")
                                    Console.BackgroundColor = ConsoleColor.Black
                                End If
                            Catch excLInha As Exception
                                LogErro(excLInha)
                            Finally
PROXIMA_LINHA:
                            End Try
                        End While

                        If erros_import = 0 Then
                            strSql = "UPDATE |" & schema & "|.|TB_PREGOES_ITENS| SET "
                            strSql &= "|PROPOSTA_IMPORTADA| = 1, "
                            strSql &= "|PROPOSTA_IMPORTADA_STATUS| = 'SUCESSO', "
                            strSql &= "|PROPOSTA_IMPORTADA_LINHAS| = " & linhas_importadas & ", "
                            strSql &= "|PROPOSTA_IMPORTADA_ERROS| = " & erros_import
                            strSql &= " WHERE |COD_LICITACAO| = '" & COD_LICITACAO & "' AND |COD_ITEM| = '" & COD_ITEM & "'"
                            ExecuteSQL(strSql)
                            leitorArquivoCSV.Close()
                            'FI.MoveTo(pasta_csv & "\IMPORTADOS\" & FI.Name)
                        Else
                            strSql = "UPDATE |" & schema & "|.|TB_PREGOES_ITENS| SET "
                            strSql &= "|PROPOSTA_IMPORTADA| = 1, "
                            strSql &= "|PROPOSTA_IMPORTADA_STATUS| = 'COM ERROS', "
                            strSql &= "|PROPOSTA_IMPORTADA_LINHAS| = " & linhas_importadas & ", "
                            strSql &= "|PROPOSTA_IMPORTADA_ERROS| = " & erros_import
                            strSql &= " WHERE |COD_LICITACAO| = '" & COD_LICITACAO & "' AND |COD_ITEM| = '" & COD_ITEM & "'"
                            ExecuteSQL(strSql)
                            leitorArquivoCSV.Close()
                        End If

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
            SQL = Replace(SQL, "|", Chr(34))
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
            Mensagem("PROPOSTAS LINHA " & Format(linha_arquivo, "000000") & " ERRO " & Replace(e.Message.ToString, vbCrLf, " "))
        Else
            Mensagem("PROPOSTAS LINHA " & Format(linha_arquivo, "000000") & " ERRO " & Replace(e.Message.ToString, vbCrLf, " ") & "; " & mensagem_erro)
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
        If IsDBNull(strValor) Or Len(strValor) = 0 Then strValor = "0"
        Try
            strValor = Replace(strValor, "R$", "")
            strValor = Replace(strValor, ",", "")
            strValor = Trim(strValor)
        Catch ex As Exception
            strValor = "0.00"
        Finally
            FormataValorReais = strValor
        End Try
    End Function
    Function FormataCodIitem(texto As String) As String
        '/pregoes/v1/proposta_item_pregao.html?item=24854440&co_pregao=908090
        Try
            texto = Trim(texto)
            Dim posInicial As Integer = InStr(texto, "?item=") + Len("?item=")
            Dim posFinal As Integer = InStr(texto, "&co_pregao=")
            FormataCodIitem = Mid(texto, posInicial, posFinal - posInicial)
        Catch
            FormataCodIitem = ""
        End Try

    End Function

    Function FormataCodPregao2(texto As String) As String
        Try
            texto = Trim(texto)
            Dim posInicial As Integer = InStr(texto, "&co_pregao=") + Len("&co_pregao=")
            Dim posFinal As Integer = Len(texto)
            FormataCodPregao2 = Mid(texto, posInicial, posFinal + 1 - posInicial)
        Catch
            FormataCodPregao2 = ""
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

