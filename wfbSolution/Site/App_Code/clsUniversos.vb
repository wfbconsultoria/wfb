Imports System.Data

Public Class clsUniversos
    ReadOnly m As New clsMaster
    ReadOnly l As New clsLojas

    Public Property UniversoId() As String
    Public Property UniversoLoja_Sigla() As String
    Public Property Universo() As String
    Public Property UniversoAndar() As String
    Public Property UniversoZona() As String

    Public Function sqlUniversos(Optional Onde As String = "", Optional Ordem As String = "") As String

        sqlUniversos = "Select * From tb_Universos Where Loja_Sigla = '" & l.Loja_Sigla & "'"
        If Ordem <> "" Then sqlUniversos = "Select * From tb_Universos Where Loja_Sigla = '" & l.Loja_Sigla & "' Order By " & Ordem

    End Function

    Public Function GetInfoUniverso(IdUniverso As String, Optional IdKey As String = "", Optional strUniverso As String = "") As Boolean
        On Error GoTo Err_GetInfoUniverso
        GetInfoUniverso = False
        Reset_Variaveis_Universo()

        Dim sqlUniverso As String = ""
        sqlUniverso = "Select * From tb_Universos Where Loja_Sigla = '" & l.Loja_Sigla & "' and Id = '" & IdUniverso & "'"
        If IdKey <> "" Then sqlUniverso = "Select * From tb_Universos Where Loja_Sigla = '" & l.Loja_Sigla & "' and Id_Key = '" & IdKey & "'"
        If strUniverso <> "" Then sqlUniverso = "Select * From tb_Universos Where Loja_Sigla = '" & l.Loja_Sigla & "'and Universo = '" & strUniverso & "'"

        Dim cnnUniverso As New System.Data.SqlClient.SqlConnection
        If Not IsNothing(cnnUniverso) Then
            If cnnUniverso.State = ConnectionState.Open Then cnnUniverso.Close()
        End If
        cnnUniverso.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        cnnUniverso.Open()

        Dim cmdUniverso As System.Data.SqlClient.SqlCommand = cnnUniverso.CreateCommand
        cmdUniverso.Connection = cnnUniverso
        cmdUniverso.CommandText = sqlUniverso
        Dim dtrUniverso As SqlClient.SqlDataReader = cmdUniverso.ExecuteReader

        If dtrUniverso.HasRows Then
            GetInfoUniverso = True
            dtrUniverso.Read()
            If Not IsDBNull(dtrUniverso("Id")) Then UniversoId = dtrUniverso("Id").ToString Else UniversoId = ""
            If Not IsDBNull(dtrUniverso("Loja_Sigla")) Then UniversoLoja_Sigla = dtrUniverso("Loja_Sigla").ToString Else UniversoLoja_Sigla = ""
            If Not IsDBNull(dtrUniverso("Universo")) Then Universo = dtrUniverso("Universo") Else Universo = ""
            If Not IsDBNull(dtrUniverso("Andar")) Then UniversoAndar = dtrUniverso("Andar") Else UniversoAndar = ""
            If Not IsDBNull(dtrUniverso("Zona")) Then UniversoZona = dtrUniverso("Zona") Else UniversoZona = ""
        End If

        Exit Function
Err_GetInfoUniverso:
        m.SystemError(Err.Number, Err.Description, sqlUniverso, "Function: clsUniversos.GetInfoUniverso")
    End Function

    Private Sub Reset_Variaveis_Universo()
        UniversoId = ""
        UniversoLoja_Sigla = ""
        Universo = ""
        UniversoAndar = ""
        UniversoZona = ""
    End Sub

End Class
