Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Module Module1

    Public cnnStr As String = "Server=bihospitalar.com.br;Port=5432;UserId=postgres;Password=@Mepm2412j;Database=bih_datasus"
    Public cnn As New Npgsql.NpgsqlConnection
    Public cnn1 As New Npgsql.NpgsqlConnection
    Public cnn2 As New Npgsql.NpgsqlConnection
    Public schema As String = "MEDITRONIC"

    Dim DIRETORIO As String = "D:\SIASG\ARQUIVOS\CATMAT"
    Dim DI As DirectoryInfo = New DirectoryInfo(DIRETORIO)
    Dim FI As FileInfo
    Dim FIs() As FileInfo
    Dim i As Integer
    Sub Main()
        'LOOP NO DIRETORIO
        FIs = DI.GetFiles()
        For i = 0 To FIs.Length - 1

            FI = FIs.GetValue(i)
            Console.WriteLine(Format(i + 1, "00000") & " - " & FI.FullName & " - " & FI.Length)

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
                While Not leitorArquivoCSV.EndOfData
                    Try
                        linhaAtual = leitorArquivoCSV.ReadFields()
                        Dim campoAtual As String
                        Dim sql As String
                        sql = "Insert Into tabela (coluna1, coluna2) Values ("
                        For Each campoAtual In linhaAtual
                            sql += "'" & campoAtual & "',"
                        Next
                        sql = Left(sql, Len(sql) - 1) & ")"
                        Console.WriteLine(sql)
                    Catch ex As MalformedLineException
                        Console.WriteLine("A linha  " & ex.Message & " não é valida e será descartada.")
                    End Try
                End While

            End Using
        Next
        Console.Read()

    End Sub



    Function ConectaBanco() As Boolean
        Try
            'Conexão Postgres


            cnn = New Npgsql.NpgsqlConnection(cnnStr)
            cnn.Open()
            Console.WriteLine("CONEXAO OK")
            ConectaBanco = True
        Catch e As Exception

            LogErro(e)
            ConectaBanco = False
            Console.Read()
        End Try
    End Function


End Module
