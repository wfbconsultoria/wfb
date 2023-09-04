Imports System.Net
Module Module1
    Sub Main()

        Dim t_inicio As Date
        Dim t_fim As Date
        Dim t_diferenca As TimeSpan

        Using MyWebClient = New WebClient()
            Try
                t_inicio = Now
                Console.BackgroundColor = ConsoleColor.Green
                Console.Write("DOWNLOAD INICIO: " & Now() & vbCrLf)
                MyWebClient.Timeout = 600 * 60 * 1
                MyWebClient.DownloadFile("http://compras.dados.gov.br/fornecedores/v1/fornecedores.csv?offset=0", "D:\ARQUIVO.CSV")
                'lWebClient.DownloadString("http://compras.dados.gov.br/fornecedores/v1/fornecedores.csv?offset=0")
                t_fim = Now()
                t_diferenca = t_fim.Subtract(t_inicio)
                Console.Write(t_diferenca.TotalSeconds.ToString("000.000000") & " SEGUNDOS" & vbCrLf)
                Console.Write(vbCrLf)
                Console.Read()
            Catch e As WebException
                Console.BackgroundColor = ConsoleColor.Red
                t_fim = Now()
                t_diferenca = t_fim.Subtract(t_inicio)
                Console.Write(t_diferenca.TotalSeconds.ToString("0.000000") & " segundos" & vbCrLf)
                Console.Write("Timeout: " & MyWebClient.Timeout & " - " & e.ToString)
                Console.Read()
            End Try
        End Using

    End Sub
    Private Class WebClient
        Inherits System.Net.WebClient
        Public Property Timeout As Integer

        Protected Overrides Function GetWebRequest(ByVal uri As Uri) As WebRequest
            Dim lWebRequest As WebRequest = MyBase.GetWebRequest(uri)
            lWebRequest.Timeout = Timeout
            CType(lWebRequest, HttpWebRequest).ReadWriteTimeout = Timeout
            Return lWebRequest
        End Function
    End Class

    'Private Function GetRequest(ByVal aURL As String) As String

    'End Function


End Module
