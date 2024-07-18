Imports System.Data
Imports Newtonsoft.Json
Imports System.Net

Public Class clsCEP
    ReadOnly m As New clsMaster
    Public Property cepStatus As Boolean

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
    Public Function consultarCEP(strCEP As String) As Result

        cepStatus = False
        Try
            strCEP = FormatCEP(strCEP)
            Dim apiURL As String = "https://api.brasilaberto.com/v1/zipcode/"
            'Dim apiURL As String = "https://api.brasilaberto.com/v2/zipcode/" api paga que retorna latitude longitude
            apiURL = apiURL & strCEP
            Dim client = New WebClient()
            client.Encoding = Encoding.UTF8
            client.Headers(HttpRequestHeader.Authorization) = "Bearer ywrDQmn4IQmctYX7rExhQIKOt2BNq0BEbvwJbW0W3PX2rxWD9qpXkbXJNT8xai9B"
            Dim response = client.DownloadString(New Uri(apiURL))
            'Dim retorno As Root = JsonConvert.DeserializeObject(Of Root)(response).result
            consultarCEP = JsonConvert.DeserializeObject(Of Root)(response).result
            cepStatus = True
        Catch
            cepStatus = False
            consultarCEP = Nothing
        End Try
    End Function

    Public Class Root
        Public Property meta As Meta
        Public Property result As Result
    End Class
    Public Class Meta
        Public Property currentPage As Integer
        Public Property itemsPerPage As Integer
        Public Property totalOfItems As Integer
        Public Property totalOfPages As Integer
    End Class

    Public Class Result
        Public Property street As String
        Public Property complement As String
        Public Property district As String
        Public Property districtId As Integer
        Public Property city As String
        Public Property cityId As Integer
        Public Property ibgeId As Integer
        Public Property state As String
        Public Property stateShortname As String
        Public Property zipcode As String
        Public Property code As String
        <JsonProperty("error")>
        Public Property erro As String

    End Class


End Class
