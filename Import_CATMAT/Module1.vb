Imports Npgsql
Imports System.Data
Module Module1

    Sub Main()
        Try
            Dim Conexao As String = "Server=bihospitalar.com.br;Port=5432;UserId=postgres;Password=0000;Database=bih_datasus"
            'Instancia NpgsqlConnection na variavel conn
            Dim conn As NpgsqlConnection = New NpgsqlConnection(Conexao)
            ' Abre a conexão
            conn.Open()
            Console.WriteLine("Conexão OK")


            Dim SQL As String = "Select * From [MEDITRONIC].[VW_MERCADO_PDM]"
            SQL = Replace(SQL, "[", Chr(34))
            SQL = Replace(SQL, "]", Chr(34))
            Dim CMD As New Npgsql.NpgsqlCommand
            CMD.CommandText = SQL
            CMD.Connection = conn
            CMD.ExecuteReader()
            Dim DTR As Npgsql.NpgsqlDataReader(CMD)


        Catch e As Exception
            Console.WriteLine(e.Message)
            Console.Read()
        End Try
    End Sub

End Module
