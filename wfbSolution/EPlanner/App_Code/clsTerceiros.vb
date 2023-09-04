Imports System.Data

Public Class clsTerceiros

    ReadOnly m As New clsMaster
    ReadOnly l As New clsLojas

    Public Property TerceiroId() As String
    Public Property TerceiroNome() As String
    Public Property TerceiroEmail() As String
    Public Property TerceiroTelefone() As String
    Public Property TerceiroEndereco() As String
    Public Property TerceiroCidade() As String
    Public Property TerceiroUF() As String
    Public Property TerceiroTipo() As String
    Public Property TerceiroFuncao() As String
    Public Property TerceiroInicio_Data() As String
    Public Property TerceiroEmpresa() As String
    Public Property TerceiroObservacao() As String
    Public Property TerceiroInclusao() As String
    Public Property TerceiroAtivo() As String
    Public Property TerceiroStatus() As String
    Public Property TerceiroCheckIn_Status() As String
    Public Property TerceiroCheckIn_Date() As String
    Public Property TerceiroId_Key() As String

    Public Function sqlTerceiros(Optional Onde As String = "", Optional Ordem As String = "") As String

        sqlTerceiros = "Select * From view_Terceiros Where Loja_Sigla = '" & l.Loja_Sigla & "'"
        If Ordem <> "" Then sqlTerceiros = "Select * From view_Terceiros Where Loja_Sigla = '" & l.Loja_Sigla & "' Order By " & Ordem

    End Function

    Public Function GetInfoTerceiro(IdTerceiro As String, Optional IdKey As String = "") As Boolean
        On Error GoTo Err_GetInfoTerceiro
        GetInfoTerceiro = False
        Dim sqlTerceiro As String = ""
        sqlTerceiro = "Select * From view_Terceiros Where Loja_Sigla = '" & l.Loja_Sigla & "' and Id = '" & IdTerceiro & "'"
        If IdKey <> "" Then sqlTerceiro = "Select * From view_Terceiros Where Loja_Sigla = '" & l.Loja_Sigla & "' and Id_Key = '" & IdKey & "'"


        Reset_Variaveis_Terceiro()

        Dim cnnTerceiro As New Data.SqlClient.SqlConnection
        If Not IsNothing(cnnTerceiro) Then
            If cnnTerceiro.State = ConnectionState.Open Then cnnTerceiro.Close()
        End If
        cnnTerceiro.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        cnnTerceiro.Open()

        Dim cmdTerceiro As Data.SqlClient.SqlCommand = cnnTerceiro.CreateCommand
        cmdTerceiro.Connection = cnnTerceiro
        cmdTerceiro.CommandText = sqlTerceiro
        Dim dtrTerceiro As SqlClient.SqlDataReader = cmdTerceiro.ExecuteReader

        If dtrTerceiro.HasRows Then
            GetInfoTerceiro = True
            dtrTerceiro.Read()
            If Not IsDBNull(dtrTerceiro("Id")) Then TerceiroId = dtrTerceiro("Id").ToString Else TerceiroId = ""
            If Not IsDBNull(dtrTerceiro("Nome")) Then TerceiroNome = dtrTerceiro("Nome").ToString Else TerceiroNome = ""
            If Not IsDBNull(dtrTerceiro("Email")) Then TerceiroEmail = dtrTerceiro("Email").ToString Else TerceiroEmail = ""
            If Not IsDBNull(dtrTerceiro("Telefone")) Then TerceiroTelefone = dtrTerceiro("Telefone").ToString Else TerceiroTelefone = ""
            If Not IsDBNull(dtrTerceiro("Endereco")) Then TerceiroEndereco = dtrTerceiro("Endereco").ToString Else TerceiroEndereco = ""
            If Not IsDBNull(dtrTerceiro("Cidade")) Then TerceiroCidade = dtrTerceiro("Cidade").ToString Else TerceiroCidade = ""
            If Not IsDBNull(dtrTerceiro("UF")) Then TerceiroUF = dtrTerceiro("UF").ToString Else TerceiroUF = ""
            If Not IsDBNull(dtrTerceiro("Tipo")) Then TerceiroTipo = dtrTerceiro("Tipo").ToString Else TerceiroTipo = ""
            If Not IsDBNull(dtrTerceiro("Funcao")) Then TerceiroFuncao = dtrTerceiro("Funcao").ToString Else TerceiroFuncao = ""
            If Not IsDBNull(dtrTerceiro("Observacao")) Then TerceiroObservacao = dtrTerceiro("Observacao").ToString Else TerceiroObservacao = ""
            If Not IsDBNull(dtrTerceiro("Insert_Date")) Then TerceiroInclusao = dtrTerceiro("Insert_Date").ToString Else TerceiroInclusao = ""
            If Not IsDBNull(dtrTerceiro("Ativo")) Then TerceiroAtivo = dtrTerceiro("Ativo").ToString Else TerceiroAtivo = ""
            If Not IsDBNull(dtrTerceiro("Status")) Then TerceiroStatus = dtrTerceiro("Status").ToString Else TerceiroStatus = ""
            If Not IsDBNull(dtrTerceiro("CheckIn_Status")) Then TerceiroCheckIn_Status = dtrTerceiro("CheckIn_Status").ToString Else TerceiroCheckIn_Status = ""
            If Not IsDBNull(dtrTerceiro("CheckIn_Date")) Then TerceiroCheckIn_Date = dtrTerceiro("CheckIn_Date").ToString Else TerceiroCheckIn_Date = ""
            If Not IsDBNull(dtrTerceiro("Id_Key")) Then TerceiroId_Key = dtrTerceiro("Id_Key").ToString Else TerceiroId_Key = ""
        End If
        dtrTerceiro.Close()
        cnnTerceiro.Close()
        Exit Function
Err_GetInfoTerceiro:
        GetInfoTerceiro = False
        m.SystemError(Err.Number, Err.Description, sqlTerceiro, "Function: clsTerceiroes.GetInfoTerceiro")
    End Function

    Private Sub Reset_Variaveis_Terceiro()
        TerceiroId = ""
        TerceiroNome = ""
        TerceiroEmail = ""
        TerceiroTelefone = ""
        TerceiroEndereco = ""
        TerceiroCidade = ""
        TerceiroUF = ""
        TerceiroTipo = ""
        TerceiroFuncao = ""
        TerceiroObservacao = ""
        TerceiroInclusao = ""
        TerceiroAtivo = ""
        TerceiroStatus = ""
        TerceiroCheckIn_Status = ""
        TerceiroCheckIn_Date = ""
        TerceiroId_Key = ""
    End Sub


End Class
