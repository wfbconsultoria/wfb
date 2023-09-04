
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
'SIASG_05_LICITACOES_IMPORT
Module Module1
    Public titulo_aplicacao As String = "SIASG - LICITACOES IMPORT"
    Public cnnStr As String = "Server=miro.bihospitalar.com.br;Port=5432;UserId=postgres;Password=@Mepm2412;Database=bih_datasus"
    Public cnn As New Npgsql.NpgsqlConnection
    Public cnn1 As New Npgsql.NpgsqlConnection
    Public cnn2 As New Npgsql.NpgsqlConnection
    Public schema As String = "SIASG"
    Public tabela As String = "TB_LICITACOES"
    Public strSql As String

    Public pasta_csv As String = "D:\SIASG\05_LICITACOES\ARQUIVOS"
    Public erros As Integer = 0
    Public linha_arquivo As Long = 0
    Public linhas_importadas As Long = 0
    Public tipo_arquivo As String = "LICITACOES"
    Public tipo_processo As String = "IMPORT"
    Public mensagem_log As String
    Public importar As Integer = 0

    Public DI As New DirectoryInfo(pasta_csv)
    Public FI As FileInfo
    Public FIs() As FileInfo
    Dim arquivos As Integer

    Public COD_LICITACAO As String = ""
    Public COD_PREGAO As String = ""
    Public ANO_EDITAL As String = ""
    Public MES_EDITAL As String = ""
    Public COD_MATERIAL As String = ""
    Public COD_MODALIDADE As String = ""
    Public MODALIDADE As String = ""
    Public TIPO_PREGAO As String = ""
    Public SITUACAO_AVISO As String = ""
    Public ITENS_LICITACAO As String = ""
    Public OBJETO As String = ""
    Public COD_UASG As String = ""
    Public UASG As String = ""


    'SIASG_05_LICITACOES_IMPORT
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
                                '..POSIÇÕES DAS COLUANS NO ARQUIVO TXT EM D:\SIASG\LICITACOES\ARQUIVOS linhaAtual(i)
                                '0 [UASG]
                                '1 [Modalidade da Licitação]
                                '2 [Número do Aviso da Licitação]
                                '3 [Identificador da Licitação]
                                '4 [Tipo do Pregão]
                                '5 [Situação do Aviso]
                                '6 [Objeto]
                                '7 [Informações Gerais]
                                '8 [Número do Processo]
                                '9 [Tipo de Recurso]
                                '10[Número de Itens na Licitação]
                                '11[Nome do Responsável]
                                '12[Função do Responsável]
                                '13"[Data de Entrega do Edital]
                                '14[Endereço de Entrega do Edital]
                                '15[Data de Abertura da Proposta]
                                '16[Data de Entrega da Proposta]
                                '17[Data de Publicação]," '17

                                'define variaveis






                                COD_MATERIAL = Mid(FI.Name, 21, 6)
                                COD_LICITACAO = Formata_Texto(linhaAtual(3))
                                COD_PREGAO = Left(Formata_Texto(linhaAtual(3)), 7) & Right(Formata_Texto(linhaAtual(3)), 9)
                                ANO_EDITAL = Mid(Formata_Texto(linhaAtual(13)), 7, 4)
                                MES_EDITAL = Mid(Formata_Texto(linhaAtual(13)), 4, 2)
                                COD_MODALIDADE = Left(Formata_Texto(linhaAtual(1)), 1)
                                MODALIDADE = Right(Formata_Texto(linhaAtual(1)), Len(Formata_Texto(linhaAtual(1))) - 3)
                                COD_UASG = Replace(Mid(linhaAtual(0), 1, InStr(linhaAtual(0), ":")), ":", "")
                                UASG = Formata_Texto(Right(linhaAtual(0), Len(linhaAtual(0)) - InStr(linhaAtual(0), ":")))
                                TIPO_PREGAO = Formata_Texto(linhaAtual(4))
                                SITUACAO_AVISO = Formata_Texto(linhaAtual(5))
                                ITENS_LICITACAO = Val(linhaAtual(10))
                                OBJETO = Formata_Texto(linhaAtual(6))

                                'VERIFICA SE ALINHA JÁ FOI IMPORTADA
                                strSql = "SELECT [COD_LICITACAO] FROM [" & schema & "]." & "[" & tabela & "] WHERE [COD_LICITACAO] = '" & COD_LICITACAO & "'"
                                Dim dtr_LICITACOES As Npgsql.NpgsqlDataReader = ExecuteSelect(strSql)
                                If dtr_LICITACOES.HasRows Then
                                    strSql = "UPDATE [" & schema & "]." & "[" & tabela & "] SET "
                                    strSql &= "[COD_LICITACAO] = '" & COD_LICITACAO & "',"
                                    strSql &= "[COD_PREGAO] = '" & COD_PREGAO & "',"
                                    strSql &= "[COD_UASG] = '" & COD_UASG & "',"
                                    strSql &= "[NOME_UASG] = '" & UASG & "',"
                                    strSql &= "[ANO_EDITAL] = '" & ANO_EDITAL & "',"
                                    strSql &= "[MES_EDITAL]= '" & MES_EDITAL & "',"
                                    strSql &= "[COD_MODALIDADE]= '" & COD_MODALIDADE & "',"
                                    strSql &= "[MODALIDADE]= '" & MODALIDADE & "',"
                                    strSql &= "[TIPO_PREGAO],"
                                    strSql &= "[SITUACAO_AVISO],"
                                    strSql &= "[ITENS_LICITACAO],"
                                    strSql &= "[OBJETO_LICITACAO],"
                                    strSql &= "[ATUALIZACAO],"
                                    strSql &= "[LICITACOES_ITENS_IMPORTAR],"
                                    strSql &= "[LICITACOES_ITENS_LINK],"
                                    strSql &= "[LICITACOES_ITENS_OFFSET],"
                                    strSql &= "[PREGOES_IMPORTAR],"
                                    strSql &= "[PREGOES_LINK],"
                                    strSql &= "[PREGOES_OFFSET]"

                                    Mensagem("LINHA " & Format(linha_arquivo, "000000") & "; COD_LICITACAO " & COD_LICITACAO & "; JÁ INCLUSA")
                                    GoTo PROXIMA_LINHA
                                End If

                                'DEFINE SE ITENS DA LICITACAO SERAO IMPORTADOS A PARTIR DE 2020 E SOMENTE PREGAO(5)
                                'If COD_MODALIDADE = "5" And Val(ANO_EDITAL) >= 2020 Then importar = 1 Else importar = 0
                                If COD_MODALIDADE = "5" Then importar = 1 Else importar = 0

                                strSql = "INSERT INTO [" & schema & "]." & "[" & tabela & "]("
                                strSql &= "[COD_LICITACAO],"
                                strSql &= "[COD_PREGAO],"
                                strSql &= "[COD_UASG],"
                                strSql &= "[NOME_UASG],"
                                strSql &= "[ANO_EDITAL],"
                                strSql &= "[MES_EDITAL],"
                                strSql &= "[COD_MODALIDADE],"
                                strSql &= "[MODALIDADE],"
                                strSql &= "[TIPO_PREGAO],"
                                strSql &= "[SITUACAO_AVISO],"
                                strSql &= "[ITENS_LICITACAO],"
                                strSql &= "[OBJETO_LICITACAO],"
                                strSql &= "[ATUALIZACAO],"
                                strSql &= "[LICITACOES_ITENS_IMPORTAR],"
                                strSql &= "[LICITACOES_ITENS_LINK],"
                                strSql &= "[LICITACOES_ITENS_OFFSET],"
                                strSql &= "[PREGOES_IMPORTAR],"
                                strSql &= "[PREGOES_LINK],"
                                strSql &= "[PREGOES_OFFSET]"
                                strSql &= ") Values ("
                                strSql &= "'" & COD_LICITACAO & "'," 'COD_LICITACAO
                                strSql &= "'" & COD_PREGAO & "'," 'COD_PREGAO
                                strSql &= "'" & COD_UASG & "'," 'COD_UASG
                                strSql &= "'" & UASG & "'," 'NOME_UASG
                                strSql &= "'" & ANO_EDITAL & "',"  'ANO_EDITAL
                                strSql &= "'" & MES_EDITAL & "',"  'MES_EDITAL
                                strSql &= "'" & COD_MODALIDADE & "'," 'COD_MODALIDADE
                                strSql &= "'" & Right(Formata_Texto(linhaAtual(1)), Len(Formata_Texto(linhaAtual(1))) - 3) & "'," 'MODALIDADE
                                strSql &= "'" & Formata_Texto(linhaAtual(4)) & "'," 'TIPO_PREGAO
                                strSql &= "'" & Formata_Texto(linhaAtual(5)) & "'," 'SITUACAO_AVISO
                                strSql &= Val(linhaAtual(10)) & "," 'ITENS
                                strSql &= "'" & Formata_Texto(linhaAtual(6)) & "'," 'OBJETO
                                strSql &= "'" & Agora() & "'," 'ATUALIZACAO
                                strSql &= importar & ", " 'LICITACOES_ITENS_IMPORTAR
                                strSql &= "'http://compras.dados.gov.br/licitacoes/doc/licitacao/" & COD_LICITACAO & "/itens.csv'," 'LICITACOES_ITENS_LINK
                                strSql &= -1 & "," 'LICITACOES_ITENS_OFFSET
                                strSql &= importar & ", " 'PREGOES_IMPORTAR
                                strSql &= "'http://compras.dados.gov.br/pregoes/id/pregao/" & COD_PREGAO & ".csv'," 'PREGOES_LINK
                                strSql &= -1  'PREGOES_OFFSET
                                strSql &= ")"

                                If ExecuteSQL(strSql) = True Then
                                    linhas_importadas += 1
                                    Mensagem("LINHA " & Format(linha_arquivo, "000000") & "; COD_LICITACAO " & COD_LICITACAO & "; INCLUIDA COM SUCESSO")
                                Else
                                    Console.BackgroundColor = ConsoleColor.Red
                                    Mensagem("LINHA " & Format(linha_arquivo, "000000") & "; COD_LICITACAO " & COD_LICITACAO & "; ERRO INCLUSAO; " & strSql & "")
                                    Console.BackgroundColor = ConsoleColor.Black
                                End If
                            Catch ex As MalformedLineException
                                LogErro(ex)
                            End Try
PROXIMA_LINHA:
                            'VERIFICA COD_LICITACAO E COD_MATERIAL JÁ ESTA NA TABELA LICITACOES MATERIAIS
                            strSql = "SELECT [COD_LICITACAO] FROM [" & schema & "].[TB_LICITACOES_MATERIAIS] WHERE [COD_LICITACAO] = '" & COD_LICITACAO & "' AND [COD_MATERIAL] = '" & COD_MATERIAL & "'"
                            Dim dtr_MATERIAL As Npgsql.NpgsqlDataReader = ExecuteSelect(strSql)
                            If dtr_MATERIAL.HasRows Then
                            Else
                                strSql = "INSERT INTO [" & schema & "]." & "[TB_LICITACOES_MATERIAIS] ([COD_LICITACAO],[COD_MATERIAL]) VALUES ('" & COD_LICITACAO & "','" & COD_MATERIAL & "')"
                                ExecuteSQL(strSql)
                            End If
                        End While

                        'GRAVA NA TABELA TB_CATMAT_MATERIAS A QUANTIDADE DE LICITACOES PARA CADA COD_MATERIAL
                        strSql = "UPDATE [" & schema & "]." & "[TB_CATMAT_MATERIAIS] SET [LICITACOES_LINHAS_IMPORTADAS] = " & linhas_importadas & "WHERE [COD_MATERIAL] = '" & COD_MATERIAL & "'"
                        ExecuteSQL(strSql)
                        Mensagem("LINHAS_IMPORTADAS_COD_MATERIAL;" & COD_MATERIAL & ";" & linhas_importadas)

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
                Console.BackgroundColor = ConsoleColor.Black
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

            Dim x As Integer
            For x = 1 To 10
                texto = Replace(texto, "          ", "") '10 espaços
                texto = Replace(texto, "         ", "") '9 espaços
                texto = Replace(texto, "        ", "") '8 espaços
                texto = Replace(texto, "       ", "") '7 espaços
                texto = Replace(texto, "      ", "") '6 espaços
                texto = Replace(texto, "     ", "") '5 espaços
                texto = Replace(texto, "    ", "") '4 espaços
                texto = Replace(texto, "   ", "") '3 espaços
                texto = Replace(texto, "  ", "") '2 espaços
            Next

            texto = Replace(texto, Chr(39), "")
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

End Module

