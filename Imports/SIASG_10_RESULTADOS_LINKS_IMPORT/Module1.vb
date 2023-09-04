
Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Module Module1
    Public titulo_aplicacao As String = "SIASG - RESULTADOS LINKS IMPORT"
    Public cnnStr As String = "Server=miro.bihospitalar.com.br;Port=5432;UserId=postgres;Password=@Mepm2412;Database=bih_datasus"
    Public cnn As New Npgsql.NpgsqlConnection
    Public cnn1 As New Npgsql.NpgsqlConnection
    Public cnn2 As New Npgsql.NpgsqlConnection
    Public schema As String = "SIASG"
    Public tabela As String = "TB_RESULTADOS_LINKS"
    Public strSql As String

    Public pasta_csv As String = "D:\SIASG\10_RESULTADOS_LINKS\ARQUIVOS"
    Public erros As Integer = 0
    Public erros_import As Integer = 0
    Public linha_arquivo As Long = 0
    Public linhas_importadas As Long = 0
    Public tipo_arquivo As String = "RESULTADOS_LINKS"

    Public tipo_processo As String = "IMPORT"
    Public mensagem_log As String
    Public importar As Integer = 1

    Public DI As New DirectoryInfo(pasta_csv)
    Public FI As FileInfo
    Public FIs() As FileInfo
    Dim arquivos As Integer

    'VARIAVEIS CORRESPONDENTES As COLUNAS DO ARQUIVO
    Public COD_LICITACAO As String = ""
    Public COD_PREGAO As String = ""
    Public COD_ITEM As String = ""
    Public NUMERO_PREGAO As String = ""
    Public COD_UASG As String = ""
    Public ID_FORNECEDOR As String = ""
    Public RESULTADO_LINK As String = ""

    'SIASG_10_RESULTADOS_LINKS_IMPORT
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
                Mensagem("IMPORTANDO - " & FI.FullName & " - " & FI.Length)
                Try

                    FI = FIs.GetValue(arquivos) 'RESULTADOS_01000105000012022
                    Dim arquivo As String = Replace(FI.Name, ".CSV", "")
                    COD_LICITACAO = Mid(arquivo, 12, 17)
                    COD_PREGAO = Left(COD_LICITACAO, 7) & Right(COD_LICITACAO, 9)

                    'APAGA LINHAS ANTES DE IMPORTAR PARA NÃO DUPLICAR
                    'strSql = "DELETE FROM |" & schema & "|." & "|" & tabela & "| WHERE |COD_LICITACAO| = '" & COD_LICITACAO & "' AND |COD_ITEM| = '" & COD_ITEM & "'"
                    'ExecuteSQL(strSql)
                    'strSql = "UPDATE |" & schema & "|.|TB_PREGOES_ITENS| SET "
                    'strSql &= "|PROPOSTA_IMPORTADA| = 0,"
                    'strSql &= "|PROPOSTA_IMPORTADA_STATUS| = 'IMPORTAR',"
                    'strSql &= "|PROPOSTA_IMPORTADA_LINHAS| = 0,"
                    'strSql &= "|PROPOSTA_IMPORTADA_ERROS| = 0"
                    'strSql &= " WHERE |COD_LICITACAO| = '" & COD_LICITACAO & "' AND |COD_ITEM| = '" & COD_ITEM & "'"
                    'ExecuteSQL(strSql)

                    'importar ARQIUVOS DE PROPOSTAS
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
                            linha_arquivo += 1

                            linhaAtual = leitorArquivoCSV.ReadFields()

                            'POSIÇÕES DAS COLUNAS NO ARQUIVO TXT EM D:\SIASG\10_RESULTADOS_LINKS\ARQUIVOS linhaAtual(i)
                            '1 [Itens do fornecedor > uri] character varying(4096)
                            'http://compras.dados.gov.br/pregoes/v1/itens_do_fornecedor.csv?nu_pregao=162021&co_uasg=782700&id_fornecedor=63833

                            strSql = "INSERT INTO |" & schema & "|." & "|" & tabela & "|("
                            strSql &= "|COD_LICITACAO|,"
                            strSql &= "|COD_PREGAO|,"
                            strSql &= "|NUMERO_PREGAO|,"
                            strSql &= "|COD_UASG|,"
                            strSql &= "|ID_FORNECEDOR|,"
                            strSql &= "|RESULTADO_LINK|"
                            strSql &= ")"
                            strSql &= "VALUES("

                            For Each campoAtual In linhaAtual
                                Dim campoatual_tamanho As Integer = Len(campoAtual)
                                'DESMONTA LINHA ARQUIVO PARA RECUPERAR CAMPOS
                                Dim NUMERO_PREGAO_inicio As Integer = campoAtual.IndexOf("nu_pregao") + 10 + 1
                                Dim NUMERO_PREGAO_fim As Integer = campoAtual.IndexOf("co_uasg")
                                Dim COD_UASG_inicio As Integer = campoAtual.IndexOf("co_uasg") + 8 + 1
                                Dim COD_UASG_fim As Integer = campoAtual.IndexOf("id_fornecedor")
                                Dim ID_FORNECEDOR_inicio As Integer = campoAtual.IndexOf("id_fornecedor") + 14 + 1
                                Dim ID_FORNECEDOR_fim As Integer = campoatual_tamanho - campoAtual.IndexOf("id_fornecedor") + 14
                                NUMERO_PREGAO = Mid(campoAtual, NUMERO_PREGAO_inicio, NUMERO_PREGAO_fim - NUMERO_PREGAO_inicio)
                                COD_UASG = Mid(campoAtual, COD_UASG_inicio, COD_UASG_fim - COD_UASG_inicio)
                                ID_FORNECEDOR = Mid(campoAtual, ID_FORNECEDOR_inicio, ID_FORNECEDOR_fim)
                                RESULTADO_LINK = "http://compras.dados.gov.br" & Replace(campoAtual, "/pregoes/v1/itens_do_fornecedor", "/pregoes/v1/itens_do_fornecedor.csv")
                            Next
                            strSql &= "'" & COD_LICITACAO & "',"
                            strSql &= "'" & COD_PREGAO & "',"
                            strSql &= "'" & NUMERO_PREGAO & "',"
                            strSql &= "'" & COD_UASG & "',"
                            strSql &= "'" & ID_FORNECEDOR & "',"
                            strSql &= "'" & RESULTADO_LINK & "')"

                            If ExecuteSQL(strSql) = True Then
                                linhas_importadas += 1
                                Mensagem("LINK DE RESULTADOS LINHA" & Format(linha_arquivo, "000000") & " INCLUIDA COM SUCESSO")
                            Else
                                erros_import += 1
                                Console.BackgroundColor = ConsoleColor.Red
                                Mensagem("LINK DE RESULTADOS LINHA " & Format(linha_arquivo, "000000") & " ERRO INCLUSAO")
                                Console.BackgroundColor = ConsoleColor.Black
                            End If
PROXIMA_LINHA:
                        End While

                        'If erros_import = 0 Then
                        '    strSql = "UPDATE |" & schema & "|.|TB_PREGOES_ITENS| SET "
                        '    strSql &= "|PROPOSTA_IMPORTADA| = 1, "
                        '    strSql &= "|PROPOSTA_IMPORTADA_STATUS| = 'SUCESSO', "
                        '    strSql &= "|PROPOSTA_IMPORTADA_LINHAS| = " & linhas_importadas & ", "
                        '    strSql &= "|PROPOSTA_IMPORTADA_ERROS| = " & erros_import
                        '    strSql &= " WHERE |COD_LICITACAO| = '" & COD_LICITACAO & "' AND |COD_ITEM| = '" & COD_ITEM & "'"
                        '    ExecuteSQL(strSql)
                        '    leitorArquivoCSV.Close()
                        '    'FI.MoveTo(pasta_csv & "\IMPORTADOS\" & FI.Name)
                        'Else
                        '    strSql = "UPDATE |" & schema & "|.|TB_PREGOES_ITENS| SET "
                        '    strSql &= "|PROPOSTA_IMPORTADA| = 0, "
                        '    strSql &= "|PROPOSTA_IMPORTADA_STATUS| = 'COM ERROS', "
                        '    strSql &= "|PROPOSTA_IMPORTADA_LINHAS| = " & linhas_importadas & ", "
                        '    strSql &= "|PROPOSTA_IMPORTADA_ERROS| = " & erros_import
                        '    strSql &= " WHERE |COD_LICITACAO| = '" & COD_LICITACAO & "' AND |COD_ITEM| = '" & COD_ITEM & "'"
                        '    ExecuteSQL(strSql)
                        '    leitorArquivoCSV.Close()
                        'End If
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

