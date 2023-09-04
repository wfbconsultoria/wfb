Imports System.Data

Public Class clsLojas
    ReadOnly m As New clsMaster
    Public Property Loja_Sigla() As String = ConfigurationManager.AppSettings("Loja_Sigla").ToString

    Public Property LojaId() As String
    Public Property Loja() As String
    Public Property Loja_Endereco() As String
    Public Property Loja_Cidade() As String
    Public Property Loja_UF() As String
    Public Property Loja_Telefone() As String
    Public Property Loja_Horario() As String

    Public Property Loja_Colaboradores_Ativos_Qtd() As String
    Public Property Loja_Colaboradores_Presentes_Qtd() As String
    Public Property Loja_Colaboradores_Presentes_Pct() As String
    Public Property Loja_Colaboradores_Ausentes_Qtd() As String
    Public Property Loja_Colaboradores_Ausentes_Pct() As String

    Public Property Loja_Brigadistas_Ativos_Qtd() As String
    Public Property Loja_Brigadistas_Ativos_Pct() As String
    Public Property Loja_Brigadistas_Presentes_Qtd() As String
    Public Property Loja_Brigadistas_Presentes_Pct() As String
    Public Property Loja_Brigadistas_Ausentes_Qtd() As String
    Public Property Loja_Brigadistas_Ausentes_Pct() As String

    Public Property Loja_NaoBrigadistas_Ativos_Qtd() As String
    Public Property Loja_NaoBrigadistas_Ativos_Pct() As String
    Public Property Loja_NaoBrigadistas_Presentes_Qtd() As String
    Public Property Loja_NaoBrigadistas_Presentes_Pct() As String
    Public Property Loja_NaoBrigadistas_Ausentes_Qtd() As String
    Public Property Loja_NaoBrigadistas_Ausentes_Pct() As String

    Public Property Loja_Terceiros_Ativos_Qtd() As String
    Public Property Loja_Terceiros_Presentes_Qtd() As String
    Public Property Loja_Terceiros_Presentes_Pct() As String
    Public Property Loja_Terceiros_Ausentes_Qtd() As String
    Public Property Loja_Terceiros_Ausentes_Pct() As String

    Public Property Loja_Visitantes_Ativos_Qtd() As String
    Public Property Loja_Visitantes_Presentes_Qtd() As String
    Public Property Loja_Visitantes_Presentes_Pct() As String
    Public Property Loja_Visitantes_Ausentes_Qtd() As String
    Public Property Loja_Visitantes_Ausentes_Pct() As String


    Public Sub GetInfoLoja()
        On Error GoTo Err_GetInfoLoja
        Reset_Variaveis_Loja()

        Dim sqlLoja As String = "Select * From view_Lojas Where Loja_Sigla = '" & Loja_Sigla & "'"
        Dim sqlTerceiros As String = "Select * From view_Terceiros_Loja Where Loja_Sigla = '" & Loja_Sigla & "'"
        Dim sqlVisitantes As String = "Select * From view_Visitantes_Loja Where Loja_Sigla = '" & Loja_Sigla & "'"

        Dim cnnLoja As New System.Data.SqlClient.SqlConnection
        If Not IsNothing(cnnLoja) Then
            If cnnLoja.State = ConnectionState.Open Then cnnLoja.Close()
        End If
        cnnLoja.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        cnnLoja.Open()

        Dim cmdLoja As System.Data.SqlClient.SqlCommand = cnnLoja.CreateCommand
        cmdLoja.CommandText = sqlLoja
        Dim dtrLoja As SqlClient.SqlDataReader = cmdLoja.ExecuteReader

        If dtrLoja.HasRows Then
            dtrLoja.Read()
            If Not IsDBNull(dtrLoja("Id_Loja")) Then LojaId = dtrLoja("Id_Loja").ToString
            If Not IsDBNull(dtrLoja("Loja")) Then Loja = dtrLoja("Loja").ToString
            If Not IsDBNull(dtrLoja("Loja_Endereco")) Then Loja_Endereco = dtrLoja("Loja_Endereco").ToString
            If Not IsDBNull(dtrLoja("Loja_Cidade")) Then Loja_Cidade = dtrLoja("Loja_Cidade").ToString
            If Not IsDBNull(dtrLoja("Loja_UF")) Then Loja_UF = dtrLoja("Loja_UF").ToString
            If Not IsDBNull(dtrLoja("Loja_Telefone")) Then Loja_Telefone = dtrLoja("Loja_Telefone").ToString
            If Not IsDBNull(dtrLoja("Loja_Horario")) Then Loja_Horario = dtrLoja("Loja_Horario").ToString

            If Not IsDBNull(dtrLoja("Qtd_Colaboradores")) Then Loja_Colaboradores_Ativos_Qtd = FormatNumber(dtrLoja("Qtd_Colaboradores"), 0)
            If Not IsDBNull(dtrLoja("Qtd_Colaboradores_Presentes")) Then Loja_Colaboradores_Presentes_Qtd = FormatNumber(dtrLoja("Qtd_Colaboradores_Presentes"), 0)
            If Not IsDBNull(dtrLoja("Qtd_Colaboradores_Ausentes")) Then Loja_Colaboradores_Ausentes_Qtd = FormatNumber(dtrLoja("Qtd_Colaboradores_Ausentes"), 0)
            If Not IsDBNull(dtrLoja("Pct_Colaboradores_Presentes")) Then Loja_Colaboradores_Presentes_Pct = FormatPercent(dtrLoja("Pct_Colaboradores_Presentes"), 1)
            If Not IsDBNull(dtrLoja("Pct_Colaboradores_Ausentes")) Then Loja_Colaboradores_Ausentes_Pct = FormatPercent(dtrLoja("Pct_Colaboradores_Ausentes"), 1)

            If Not IsDBNull(dtrLoja("Qtd_Brigadistas")) Then Loja_Brigadistas_Ativos_Qtd = FormatNumber(dtrLoja("Qtd_Brigadistas"), 0)
            If Not IsDBNull(dtrLoja("Qtd_Brigadistas_Presentes")) Then Loja_Brigadistas_Presentes_Qtd = FormatNumber(dtrLoja("Qtd_Brigadistas_Presentes"), 0)
            If Not IsDBNull(dtrLoja("Qtd_Brigadistas_Ausentes")) Then Loja_Brigadistas_Ausentes_Qtd = FormatNumber(dtrLoja("Qtd_Brigadistas_Ausentes"), 0)
            If Not IsDBNull(dtrLoja("Pct_Brigadistas")) Then Loja_Brigadistas_Ativos_Pct = FormatPercent(dtrLoja("Pct_Brigadistas"), 1)
            If Not IsDBNull(dtrLoja("Pct_Brigadistas_Presentes")) Then Loja_Brigadistas_Presentes_Pct = FormatPercent(dtrLoja("Pct_Brigadistas_Presentes"), 1)
            If Not IsDBNull(dtrLoja("Pct_Brigadistas_Ausentes")) Then Loja_Brigadistas_Ausentes_Pct = FormatPercent(dtrLoja("Pct_Brigadistas_Ausentes"), 1)

            If Not IsDBNull(dtrLoja("Qtd_Nao_Brigadistas")) Then Loja_NaoBrigadistas_Ativos_Qtd = FormatNumber(dtrLoja("Qtd_Nao_Brigadistas"), 0)
            If Not IsDBNull(dtrLoja("Qtd_Nao_Brigadistas_Presentes")) Then Loja_NaoBrigadistas_Presentes_Qtd = FormatNumber(dtrLoja("Qtd_Nao_Brigadistas_Presentes"), 0)
            If Not IsDBNull(dtrLoja("Qtd_Nao_Brigadistas_Ausentes")) Then Loja_NaoBrigadistas_Ausentes_Qtd = FormatNumber(dtrLoja("Qtd_Nao_Brigadistas_Ausentes"), 0)
            If Not IsDBNull(dtrLoja("Pct_Nao_Brigadistas")) Then Loja_NaoBrigadistas_Ativos_Pct = FormatPercent(dtrLoja("Pct_Nao_Brigadistas"), 1)
            If Not IsDBNull(dtrLoja("Pct_Nao_Brigadistas_Presentes")) Then Loja_NaoBrigadistas_Presentes_Pct = FormatPercent(dtrLoja("Pct_Nao_Brigadistas_Presentes"), 1)
            If Not IsDBNull(dtrLoja("Pct_Nao_Brigadistas_Ausentes")) Then Loja_NaoBrigadistas_Ausentes_Pct = FormatPercent(dtrLoja("Pct_Nao_Brigadistas_Ausentes"), 1)
        End If
        dtrLoja.Close()

        'Terceiros
        Dim cmdTerceiros As System.Data.SqlClient.SqlCommand = cnnLoja.CreateCommand
        cmdTerceiros.CommandText = sqlTerceiros
        Dim dtrTerceiros As SqlClient.SqlDataReader = cmdTerceiros.ExecuteReader

        If dtrTerceiros.HasRows Then
            dtrTerceiros.Read()
            If Not IsDBNull(dtrTerceiros("Qtd_Terceiros")) Then Loja_Terceiros_Ativos_Qtd = FormatNumber(dtrTerceiros("Qtd_Terceiros"), 0)
            If Not IsDBNull(dtrTerceiros("Qtd_Terceiros_Presentes")) Then Loja_Terceiros_Presentes_Qtd = FormatNumber(dtrTerceiros("Qtd_Terceiros_Presentes"), 0)
            If Not IsDBNull(dtrTerceiros("Qtd_Terceiros_Ausentes")) Then Loja_Terceiros_Ausentes_Qtd = FormatNumber(dtrTerceiros("Qtd_Terceiros_Ausentes"), 0)
            If Not IsDBNull(dtrTerceiros("Pct_Terceiros_Presentes")) Then Loja_Terceiros_Presentes_Pct = FormatPercent(dtrTerceiros("Pct_Terceiros_Presentes"), 1)
            If Not IsDBNull(dtrTerceiros("Pct_Terceiros_Ausentes")) Then Loja_Terceiros_Ausentes_Pct = FormatPercent(dtrTerceiros("Pct_Terceiros_Ausentes"), 1)
        End If
        dtrTerceiros.Close()

        'Visitantes
        Dim cmdVisitantes As System.Data.SqlClient.SqlCommand = cnnLoja.CreateCommand
        cmdVisitantes.CommandText = sqlVisitantes
        Dim dtrVisitantes As SqlClient.SqlDataReader = cmdVisitantes.ExecuteReader

        If dtrVisitantes.HasRows Then
            dtrVisitantes.Read()
            If Not IsDBNull(dtrVisitantes("Qtd_Visitantes")) Then Loja_Visitantes_Ativos_Qtd = FormatNumber(dtrVisitantes("Qtd_Visitantes"), 0)
            If Not IsDBNull(dtrVisitantes("Qtd_Visitantes_Presentes")) Then Loja_Visitantes_Presentes_Qtd = FormatNumber(dtrVisitantes("Qtd_Visitantes_Presentes"), 0)
            If Not IsDBNull(dtrVisitantes("Qtd_Visitantes_Ausentes")) Then Loja_Visitantes_Ausentes_Qtd = FormatNumber(dtrVisitantes("Qtd_Visitantes_Ausentes"), 0)
            If Not IsDBNull(dtrVisitantes("Pct_Visitantes_Presentes")) Then Loja_Visitantes_Presentes_Pct = FormatPercent(dtrVisitantes("Pct_Visitantes_Presentes"), 1)
            If Not IsDBNull(dtrVisitantes("Pct_Visitantes_Ausentes")) Then Loja_Visitantes_Ausentes_Pct = FormatPercent(dtrVisitantes("Pct_Visitantes_Ausentes"), 1)
        End If
        dtrVisitantes.Close()

        cnnLoja.Close()
        Exit Sub
Err_GetInfoLoja:
        m.SystemError(Err.Number, Err.Description, sqlLoja, "Function: clsLojas.GetInfoLoja")
    End Sub

    Private Sub Reset_Variaveis_Loja()
        LojaId = ""
        Loja = ""
        Loja_Endereco = ""
        Loja_Cidade = ""
        Loja_UF = ""
        Loja_Telefone = ""
        Loja_Horario = ""

        Loja_Colaboradores_Ativos_Qtd = 0
        Loja_Colaboradores_Presentes_Qtd = 0
        Loja_Colaboradores_Presentes_Pct = 0
        Loja_Colaboradores_Ausentes_Qtd = 0
        Loja_Colaboradores_Ausentes_Pct = 0

        Loja_Brigadistas_Ativos_Qtd = 0
        Loja_Brigadistas_Ativos_Pct = 0
        Loja_Brigadistas_Presentes_Qtd = 0
        Loja_Brigadistas_Presentes_Pct = 0
        Loja_Brigadistas_Ausentes_Qtd = 0
        Loja_Brigadistas_Ausentes_Pct = 0

        Loja_NaoBrigadistas_Ativos_Qtd = 0
        Loja_NaoBrigadistas_Ativos_Pct = 0
        Loja_NaoBrigadistas_Presentes_Qtd = 0
        Loja_NaoBrigadistas_Presentes_Pct = 0
        Loja_NaoBrigadistas_Ausentes_Qtd = 0
        Loja_NaoBrigadistas_Ausentes_Pct = 0

        Loja_Terceiros_Ativos_Qtd = 0
        Loja_Terceiros_Presentes_Qtd = 0
        Loja_Terceiros_Presentes_Pct = 0
        Loja_Terceiros_Ausentes_Qtd = 0
        Loja_Terceiros_Ausentes_Pct = 0

        Loja_Visitantes_Ativos_Qtd = 0
        Loja_Visitantes_Presentes_Qtd = 0
        Loja_Visitantes_Presentes_Pct = 0
        Loja_Visitantes_Ausentes_Qtd = 0
        Loja_Visitantes_Ausentes_Pct = 0
    End Sub
End Class
