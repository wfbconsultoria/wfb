Imports Microsoft.VisualBasic

Public Class clsContatos
    Public COD_CONTATO As String
    Public CRM As String
    Public UF_CRM As String
    'variaveis do CONTATO
    Public NOME As String
    Public ID_TIPO_CONTATO As String
    Public CRMUF As String
    Public ID_TIPO1 As String
    Public ID_TIPO2 As String
    Public ID_TIPO3 As String
    Public LOGRADOURO As String
    Public NUMERO As String
    Public COMPLEMENTO As String
    Public BAIRRO As String
    Public CEP As String
    Public CIDADE As String
    Public UF As String
    Public OBSERVACAO As String
    Public ESPECIALIDADE As String
    Public TELEFONE As String
    Public CELULAR As String
    Public EMAIL As String
    Public MES_ANIVERSARIO As String
    Public DIA_ANIVERSARIO As String
    Public ID_TIPO_ENDERECO As String
    Public ID_OPERADORA As String
    Public ID_TIPO_TELEFONE As String
    'Variaveis dos CONTATOS_ESTABELECIMENTOS
    Public ID_CARGO As String
    Public ID_AREA As String
    Public ID_PERFIL As String
    Public TELEFONE_ESTABELECIMENTO As String
    'Varicavei do CFM MEDICOS
    Public CFM_NOME As String
    Public CFM_CRMUF As String
    Public CFM_ESPECIALIDADE As String

    Public Function Recupera_Contato(Codigo_Contato As String) As Boolean
        On Error GoTo Err_Recupera_Contato
        Recupera_Contato = False

        'Váriaveis Padrão de Banco
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String

        sql = "Select * From TBL_CONTATOS Where COD_CONTATO = '" & Codigo_Contato & "'"

        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnstr").ConnectionString
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            COD_CONTATO = dtr("COD_CONTATO")
            ID_TIPO_CONTATO = dtr("ID_TIPO_CONTATO")
            NOME = dtr("NOME")
            CRMUF = dtr("CRMUF")
            If Not IsDBNull(dtr("CRMUF")) Then CRM = Right(dtr("CRMUF"), 10)
            If Not IsDBNull(dtr("CRMUF")) Then UF_CRM = Left(dtr("CRMUF"), 2)


            Recupera_Contato = True
        Else
            Recupera_Contato = False
        End If
        Exit Function
Err_Recupera_Contato:
        Recupera_Contato = False
    End Function
    Public Function Atualiza_Contato(Codigo_Contato As String, Coluna As String, Valor As String) As Boolean
        On Error GoTo Err_Atualiza_CONTATO
        Atualiza_Contato = False
        'Váriaveis Padrão de Banco
        Dim M As New clsMaster
        If M.ExecutarSQL("Update TBL_CONTATOS Set " & Coluna & "='" & Valor & "' Where COD_CONTATO = '" & Codigo_Contato & "'") = True Then Atualiza_Contato = True
        Recupera_Contato(Codigo_Contato)
        Exit Function
Err_Atualiza_CONTATO:
        Atualiza_Contato = False
    End Function
    Public Function Pesquisa_Contato(Codigo_Contato As String) As Boolean
        ' FALTA RECUPERAR ALGUNS CAMPOS

        On Error GoTo Err_Pesquisa_Contato
        Pesquisa_Contato = False

        'Váriaveis Padrão de Banco
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String

        sql = ""
        sql = "Select * From TBL_CONTATOS Where COD_CONTATO = '" & Codigo_Contato & "' "
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnstr").ConnectionString
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("ID_TIPO1")) Then ID_TIPO1 = dtr("ID_TIPO1")
            If Not IsDBNull(dtr("ID_TIPO2")) Then ID_TIPO2 = dtr("ID_TIPO2")
            If Not IsDBNull(dtr("ID_TIPO3")) Then ID_TIPO3 = dtr("ID_TIPO3")
            If Not IsDBNull(dtr("LOGRADOURO")) Then LOGRADOURO = dtr("LOGRADOURO")
            If Not IsDBNull(dtr("NUMERO")) Then NUMERO = dtr("NUMERO")
            If Not IsDBNull(dtr("COMPLEMENTO")) Then COMPLEMENTO = dtr("COMPLEMENTO")
            If Not IsDBNull(dtr("BAIRRO")) Then BAIRRO = dtr("BAIRRO")
            If Not IsDBNull(dtr("CEP")) Then CEP = dtr("CEP")
            If Not IsDBNull(dtr("CIDADE")) Then CIDADE = dtr("CIDADE")
            If Not IsDBNull(dtr("UF")) Then UF = dtr("UF")
            If Not IsDBNull(dtr("OBSERVACAO")) Then OBSERVACAO = dtr("OBSERVACAO")
            If Not IsDBNull(dtr("ESPECIALIDADE")) Then ESPECIALIDADE = dtr("ESPECIALIDADE")
            If Not IsDBNull(dtr("CRMUF")) Then CRMUF = dtr("CRMUF")
            If Not IsDBNull(dtr("TELEFONE")) Then TELEFONE = dtr("TELEFONE")
            If Not IsDBNull(dtr("CELULAR")) Then CELULAR = dtr("CELULAR")
            If Not IsDBNull(dtr("EMAIL")) Then EMAIL = dtr("EMAIL")
            If Not IsDBNull(dtr("MES_ANIVERSARIO")) Then MES_ANIVERSARIO = dtr("MES_ANIVERSARIO")
            If Not IsDBNull(dtr("DIA_ANIVERSARIO")) Then DIA_ANIVERSARIO = dtr("DIA_ANIVERSARIO")
            If Not IsDBNull(dtr("ID_TIPO_ENDERECO")) Then ID_TIPO_ENDERECO = dtr("ID_TIPO_ENDERECO")
            If Not IsDBNull(dtr("ID_OPERADORA")) Then ID_OPERADORA = dtr("ID_OPERADORA")
            If Not IsDBNull(dtr("ID_TIPO_TELEFONE")) Then ID_TIPO_TELEFONE = dtr("ID_TIPO_TELEFONE")
            Pesquisa_Contato = True
            dtr.Close()
            cnn.Close()
        Else
            Pesquisa_Contato = False
            dtr.Close()
            cnn.Close()
        End If
        Exit Function
Err_Pesquisa_Contato:
        Pesquisa_Contato = False
    End Function
    Public Function Pesquisa_Contato_Estabelecimento(CNPJ As String, Codigo_Contato As String) As Boolean
        On Error GoTo Err_Pesquisa_Contato_Estabelecimento
        Pesquisa_Contato_Estabelecimento = False

        'Váriaveis Padrão de Banco
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String

        sql = ""
        sql = "Select * From TBL_CONTATOS_ESTABELECIMENTOS Where (CNPJ_ESTABELECIMENTO = '" & CNPJ & "') AND (COD_CONTATO = '" & Codigo_Contato & "')"
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnstr").ConnectionString
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("ID_CARGO")) Then ID_CARGO = dtr("ID_CARGO")
            If Not IsDBNull(dtr("ID_AREA")) Then ID_AREA = dtr("ID_AREA")
            If Not IsDBNull(dtr("ID_PERFIL")) Then ID_PERFIL = dtr("ID_PERFIL")
            If Not IsDBNull(dtr("TELEFONE")) Then TELEFONE_ESTABELECIMENTO = dtr("TELEFONE")
            Pesquisa_Contato_Estabelecimento = True
            dtr.Close()
            cnn.Close()
        Else
            Pesquisa_Contato_Estabelecimento = False
            dtr.Close()
            cnn.Close()
        End If
        Exit Function
Err_Pesquisa_Contato_Estabelecimento:
        Pesquisa_Contato_Estabelecimento = False
    End Function
    Public Function Pesquisa_Medico(Codigo_Contato As String) As Boolean
        On Error GoTo Err_Pesquisa_Contato_Estabelecimento
        Pesquisa_Medico = False

        'Váriaveis Padrão de Banco
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String

        sql = ""
        sql = "Select * From VIEW_MEDICOS_CFM Where CRMUF = '" & CRMUF & "'"
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnMedicos").ConnectionString
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("NOME")) Then CFM_NOME = dtr("NOME")
            If Not IsDBNull(dtr("CRMUF")) Then CFM_CRMUF = dtr("CRMUF")
            If Not IsDBNull(dtr("ESPECIALIDADE")) Then CFM_ESPECIALIDADE = dtr("ESPECIALIDADE")
            Pesquisa_Medico = True
            dtr.Close()
            cnn.Close()
        Else
            Pesquisa_Medico = False
            dtr.Close()
            cnn.Close()
        End If
        Exit Function
Err_Pesquisa_Contato_Estabelecimento:
        Pesquisa_Medico = False
    End Function
End Class
