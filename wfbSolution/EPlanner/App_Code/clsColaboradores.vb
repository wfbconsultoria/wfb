Imports System.Data

Public Class clsColaboradores
    ReadOnly m As New clsMaster
    ReadOnly l As New clsLojas

    Public Property ColaboradorId() As String
    Public Property ColaboradorId_Universo() As String
    Public Property ColaboradorUniverso() As String
    Public Property ColaboradorNome() As String
    Public Property ColaboradorEmail() As String
    Public Property ColaboradorTelefone() As String
    Public Property ColaboradorEndereco() As String
    Public Property ColaboradorCidade() As String
    Public Property ColaboradorUF() As String
    Public Property ColaboradorTipo() As String
    Public Property ColaboradorFuncao() As String
    Public Property ColaboradorEmpresa() As String
    Public Property ColaboradorFormacao_Data() As String
    Public Property ColaboradorAdmissao_Data() As String
    Public Property ColaboradorBrigadista() As String
    Public Property ColaboradorObservacao() As String
    Public Property ColaboradorInclusao() As String
    Public Property ColaboradorAtivo() As String
    Public Property ColaboradorAdministrador() As String
    Public Property ColaboradorSenha() As String
    Public Property ColaboradorStatus() As String
    Public Property ColaboradorCheckIn_Status() As String
    Public Property ColaboradorCheckIn_Date() As String
    Public Property ColaboradorId_Key() As String
    Public Property ColaboradorInsert_Date() As String
    Public Property ColaboradorInsert_User() As String
    Public Property ColaboradorUpdate_Date() As String
    Public Property ColaboradorUpdate_User() As String

    Public Function sqlColaboradores(Optional Tipo As String = "", Optional Ativo As String = "", Optional Ordem As String = "") As String

        sqlColaboradores = "SELECT * FROM view_Colaboradores Where (Loja_Sigla = '" & l.Loja_Sigla & "') "
        'Seleção por tipo de colaborador
        Select Case Tipo
            Case = "Brigadistas"
                sqlColaboradores &= " and (Tipo = 'Brigadista' )"
            Case = "Colaboradores"
                sqlColaboradores &= " and (Tipo = 'Brigadista' OR Tipo = 'Colaborador') "
            Case = "Nao_Brigadistas"
                sqlColaboradores &= " and (Tipo = 'Colaborador') "
            Case = "Terceiros"
                sqlColaboradores &= " and (Tipo = 'Terceiro') "
            Case = "Visitantes"
                sqlColaboradores &= " and (Tipo = 'Visitante') "
            Case = "Todos"
        End Select

        'Seleção se Ativo ou Inativo
        Select Case Ativo
            Case = "Sim"
                sqlColaboradores &= " and (Ativo = 'Sim') "
            Case = "Nao"
                sqlColaboradores &= " and (Ativo = 'Nao') "
        End Select

        If Ordem <> "" Then sqlColaboradores = sqlColaboradores & " Order By " & Ordem

    End Function

    Public Function GetInfoColaborador(IdColaborador As String, Optional IdKey As String = "", Optional Email As String = "") As Boolean
        On Error GoTo Err_GetInfoColaborador
        GetInfoColaborador = False
        Dim sqlColaborador As String = ""
        sqlColaborador = "Select * From view_Colaboradores Where Loja_Sigla = '" & l.Loja_Sigla & "' and Id = '" & IdColaborador & "'"
        If IdKey <> "" Then sqlColaborador = "Select * From view_Colaboradores Where Loja_Sigla = '" & l.Loja_Sigla & "' and Id_Key = '" & IdKey & "'"
        If Email <> "" Then sqlColaborador = "Select * From view_Colaboradores Where Loja_Sigla = '" & l.Loja_Sigla & "' and Email = '" & Email & "'"

        Reset_Variaveis_Colaborador()

        Dim cnnColaborador As New SqlClient.SqlConnection
        If Not IsNothing(cnnColaborador) Then
            If cnnColaborador.State = ConnectionState.Open Then cnnColaborador.Close()
        End If
        cnnColaborador.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        cnnColaborador.Open()

        Dim cmdColaborador As SqlClient.SqlCommand = cnnColaborador.CreateCommand
        cmdColaborador.Connection = cnnColaborador
        cmdColaborador.CommandText = sqlColaborador
        Dim dtrColaborador As SqlClient.SqlDataReader = cmdColaborador.ExecuteReader

        If dtrColaborador.HasRows Then
            GetInfoColaborador = True
            dtrColaborador.Read()
            If Not IsDBNull(dtrColaborador("Id")) Then ColaboradorId = dtrColaborador("Id").ToString Else ColaboradorId = ""
            If Not IsDBNull(dtrColaborador("Id_Universo")) Then ColaboradorId_Universo = dtrColaborador("Id_Universo").ToString Else ColaboradorId_Universo = ""
            If Not IsDBNull(dtrColaborador("Universo")) Then ColaboradorUniverso = dtrColaborador("Universo").ToString Else ColaboradorUniverso = ""
            If Not IsDBNull(dtrColaborador("Nome")) Then ColaboradorNome = dtrColaborador("Nome").ToString Else ColaboradorNome = ""
            If Not IsDBNull(dtrColaborador("Email")) Then ColaboradorEmail = dtrColaborador("Email").ToString Else ColaboradorEmail = ""
            If Not IsDBNull(dtrColaborador("Telefone")) Then ColaboradorTelefone = dtrColaborador("Telefone").ToString Else ColaboradorTelefone = ""
            If Not IsDBNull(dtrColaborador("Endereco")) Then ColaboradorEndereco = dtrColaborador("Endereco").ToString Else ColaboradorEndereco = ""
            If Not IsDBNull(dtrColaborador("Cidade")) Then ColaboradorCidade = dtrColaborador("Cidade").ToString Else ColaboradorCidade = ""
            If Not IsDBNull(dtrColaborador("UF")) Then ColaboradorUF = dtrColaborador("UF").ToString Else ColaboradorUF = ""
            If Not IsDBNull(dtrColaborador("Tipo")) Then ColaboradorTipo = dtrColaborador("Tipo").ToString Else ColaboradorTipo = ""
            If Not IsDBNull(dtrColaborador("Funcao")) Then ColaboradorFuncao = dtrColaborador("Funcao").ToString Else ColaboradorFuncao = ""
            If Not IsDBNull(dtrColaborador("Empresa")) Then ColaboradorEmpresa = dtrColaborador("Empresa").ToString Else ColaboradorEmpresa = ""
            If Not IsDBNull(dtrColaborador("Brigadista")) Then ColaboradorBrigadista = dtrColaborador("Brigadista").ToString Else ColaboradorBrigadista = ""
            If Not IsDBNull(dtrColaborador("Formacao_Data")) Then ColaboradorFormacao_Data = dtrColaborador("Formacao_Data").ToString Else ColaboradorFormacao_Data = ""
            If Not IsDBNull(dtrColaborador("Admissao_Data")) Then ColaboradorAdmissao_Data = dtrColaborador("Admissao_Data").ToString Else ColaboradorAdmissao_Data = ""
            If Not IsDBNull(dtrColaborador("Observacao")) Then ColaboradorObservacao = dtrColaborador("Observacao").ToString Else ColaboradorObservacao = ""
            If Not IsDBNull(dtrColaborador("Insert_Date")) Then ColaboradorInclusao = dtrColaborador("Insert_Date").ToString Else ColaboradorInclusao = ""
            If Not IsDBNull(dtrColaborador("Ativo")) Then ColaboradorAtivo = dtrColaborador("Ativo").ToString Else ColaboradorAtivo = ""
            If Not IsDBNull(dtrColaborador("Administrador")) Then ColaboradorAdministrador = dtrColaborador("Administrador").ToString Else ColaboradorAdministrador = ""
            If Not IsDBNull(dtrColaborador("Senha")) Then ColaboradorSenha = dtrColaborador("Senha").ToString Else ColaboradorSenha = ""
            If Not IsDBNull(dtrColaborador("Status")) Then ColaboradorStatus = dtrColaborador("Status").ToString Else ColaboradorStatus = ""
            If Not IsDBNull(dtrColaborador("CheckIn_Status")) Then ColaboradorCheckIn_Status = dtrColaborador("CheckIn_Status").ToString Else ColaboradorCheckIn_Status = ""
            If Not IsDBNull(dtrColaborador("CheckIn_Date")) Then ColaboradorCheckIn_Date = dtrColaborador("CheckIn_Date").ToString Else ColaboradorCheckIn_Date = ""
            If Not IsDBNull(dtrColaborador("Id_Key")) Then ColaboradorId_Key = dtrColaborador("Id_Key").ToString Else ColaboradorId_Key = ""
            If Not IsDBNull(dtrColaborador("Insert_Date")) Then ColaboradorInsert_Date = dtrColaborador("Insert_Date").ToString Else ColaboradorInsert_Date = ""
            If Not IsDBNull(dtrColaborador("Insert_User")) Then ColaboradorInsert_User = dtrColaborador("Insert_User").ToString Else ColaboradorInsert_User = ""
            If Not IsDBNull(dtrColaborador("Update_Date")) Then ColaboradorUpdate_Date = dtrColaborador("Update_Date").ToString Else ColaboradorUpdate_Date = ""
            If Not IsDBNull(dtrColaborador("Update_User")) Then ColaboradorUpdate_User = dtrColaborador("Update_User").ToString Else ColaboradorUpdate_User = ""
        End If
        dtrColaborador.Close()
        cnnColaborador.Close()
        Exit Function
Err_GetInfoColaborador:
        GetInfoColaborador = False
        m.SystemError(Err.Number, Err.Description, sqlColaborador, "Function: clsColaboradores.GetInfoColaborador")
    End Function

    Public Function CheckLogin(Optional Redirect As Boolean = True, Optional PageTarget As String = "") As Boolean
        CheckLogin = False
        If IsNothing(HttpContext.Current.Session("EMAIL_LOGIN")) Or HttpContext.Current.Session("EMAIL_LOGIN") = "" Then
            CheckLogin = False
            If Redirect = True Then
                If PageTarget <> "" Then
                    HttpContext.Current.Response.Redirect(PageTarget)
                Else
                    HttpContext.Current.Response.Redirect("Default.aspx")
                End If
            End If
        Else
            CheckLogin = True
        End If
    End Function

    Private Sub Reset_Variaveis_Colaborador()
        ColaboradorId = ""
        ColaboradorId_Universo = ""
        ColaboradorUniverso = ""
        ColaboradorNome = ""
        ColaboradorEmail = ""
        ColaboradorTelefone = ""
        ColaboradorEndereco = ""
        ColaboradorCidade = ""
        ColaboradorUF = ""
        ColaboradorTipo = ""
        ColaboradorFuncao = ""
        ColaboradorEmpresa = ""
        ColaboradorBrigadista = ""
        ColaboradorAdmissao_Data = ""
        ColaboradorFormacao_Data = ""
        ColaboradorObservacao = ""
        ColaboradorInclusao = ""
        ColaboradorAtivo = ""
        ColaboradorAdministrador = ""
        ColaboradorSenha = ""
        ColaboradorStatus = ""
        ColaboradorCheckIn_Status = ""
        ColaboradorCheckIn_Date = ""
        ColaboradorId_Key = ""
    End Sub

End Class
