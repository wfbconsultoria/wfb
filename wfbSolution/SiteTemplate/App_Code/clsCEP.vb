Imports System.Data

Public Class clsCEP
    ReadOnly m As New clsMaster
    Public Property CEP As String = ""
    Public Property LOGRADOURO As String = ""
    Public Property ENDERECO As String = ""
    Public Property BAIRRO As String = ""
    Public Property CIDADE As String = ""
    Public Property UF As String = ""
    Public Property COD_IBGE_7 As String = ""

    Public Function FormatCEP(CEP As String) As String
        Dim CEP_Numero As Integer
        For Each A In CEP
            If Integer.TryParse(A, CEP_Numero) Then
            Else
                Replace(CEP, A, "")
            End If
        Next

        CEP = Replace(CEP, " ", "")
        If IsDBNull(CEP) Or CEP = "" Or Len(Trim(CEP)) = 0 Then
            FormatCEP = "00000000"
        Else
            FormatCEP = Right("00000000" & CEP, 8)
        End If
    End Function
    Public Function consultarCEP(strCEP As String) As Boolean

        Try
            Dim WS As New wsCorreios.AtendeClienteClient
            Dim wsCEP = WS.consultaCEP(strCEP)
            CEP = wsCEP.cep
            ENDERECO = wsCEP.end
            BAIRRO = wsCEP.bairro
            CIDADE = wsCEP.cidade
            UF = wsCEP.uf

            Dim dtr As SqlClient.SqlDataReader
            Dim sql As String = "Select COD_IBGE_7 From TBL_IBGE_MUNICIPIOS Where MUNICIPIO = '" & CIDADE & "' And UF = '" & UF & "'"
            dtr = m.ExecuteSelect(sql)
            If dtr.HasRows Then
                dtr.Read()
                COD_IBGE_7 = dtr("COD_IBGE_7")
            End If

            consultarCEP = True
        Catch ex As Exception
            consultarCEP = False
        End Try

    End Function

End Class
