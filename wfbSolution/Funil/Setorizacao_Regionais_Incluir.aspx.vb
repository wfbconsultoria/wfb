
Imports System.Data

Partial Class Setorizacao_Regionais_Incluir
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Dim ACAO As String = ""
    Dim REGIONAL_ATUAL As String = ""
    Dim strCOD_REGIONAL As String = ""

    Private Sub Setorizacao_Regionais_Incluir_Load(sender As Object, e As EventArgs) Handles Me.Load

        Atauliza_dts()
        Dim sql As String = "Select * From APP_SETORIZACAO_REGIONAIS Where ID = '" & Request.QueryString("Id") & "'"
        Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect(sql)
        If dtr.HasRows Then
            dtr.Read()
            REGIONAL_ATUAL = m.ConvertText(dtr("REGIONAL"), clsMaster.TextCaseOptions.UpperCase)
        End If
        If Request.QueryString("Id") = "NOVO" Then
            If IsPostBack() = False Then
                COD_REGIONAL.Disabled = False
                ATIVO.Text = True
                ATIVO.Enabled = False
                ACAO = "NewRecord"
                NewRecord()
            End If
            If IsPostBack() = True Then
                ACAO = "InsertRecord"
                InsertRecord()
            End If
        Else
            If IsPostBack() = False Then
                COD_REGIONAL.Disabled = True
                ACAO = "RecoverRecord"
                RecoverRecord()
            End If
            If IsPostBack() = True Then
                COD_REGIONAL.Disabled = True
                ACAO = "UpdateRecord"
                UpdateRecord()
            End If
        End If
    End Sub
    Sub Atauliza_dts()
        Dim sql As String = ""
        'EMAIL_GERENTE
        sql &= "Select '@' AS EMAIL, '( SELECIONE )' AS NOME UNION ALL "
        sql &= "Select EMAIL,NOME FROM APP_USUARIOS Order By NOME "
        dts_EMAIL_GERENTE.SelectCommand = sql
        dts_EMAIL_GERENTE.DataBind()

        'ATIVO
        sql = "Select * From TBL_ATIVO_INATIVO Order By ATIVO_DESCRICAO"
        dts_ATIVO.SelectCommand = sql
        dts_ATIVO.DataBind()
    End Sub
    Function ValidateRecord() As Boolean
        ValidateRecord = False

        'COD_REGIONAL
        If Len(COD_REGIONAL.Value) < 1 Then
            m.Alert(Me, "Digite o Codigo da REGIONAL", False, "")
            Exit Function
        Else
            'formata COD_REGIONAL para dois caracteres 00
            If Len(COD_REGIONAL.Value) = 1 Then
                strCOD_REGIONAL = "0" & COD_REGIONAL.Value
            Else
                strCOD_REGIONAL = COD_REGIONAL.Value
            End If
        End If

            'REGIONAL
            If Len(m.ConvertText(REGIONAL.Value, clsMaster.TextCaseOptions.UpperCase)) < 3 Then
            m.Alert(Me, "REGIONAL deve ter no mínimo 3 caracteres", False, "")
            Exit Function
        End If

        'EMAIL_GERENTE
        If EMAIL_GERENTE.Text = "@" Then
            m.Alert(Me, "Selecione o GERENTE", False, "")
            Exit Function
        End If

        'valida a inclusao de novo registro
        If ACAO = "InsertRecord" Then

            'Verifica se o codigo da REGIONAL já existe
            If m.CheckExists("APP_SETORIZACAO_REGIONAIS", "COD_REGIONAL", strCOD_REGIONAL) = True Then
                m.Alert(Me, "Este Codigo de  REGIONAL já existe", False, "")
                Exit Function
            End If

            'Verifica se o nome da REGIONAL já existe
            If m.CheckExists("APP_SETORIZACAO_REGIONAIS", "REGIONAL", m.ConvertText(REGIONAL.Value, clsMaster.TextCaseOptions.UpperCase)) = True Then
                m.Alert(Me, "Esta REGIONAL já existe", False, "")
                Exit Function
            End If

        End If

        If ACAO = "UpdateRecord" Then
            If REGIONAL_ATUAL <> m.ConvertText(REGIONAL.Value, clsMaster.TextCaseOptions.UpperCase) Then
                If m.CheckExists("APP_SETORIZACAO_REGIONAIS", "REGIONAL", m.ConvertText(REGIONAL.Value, clsMaster.TextCaseOptions.UpperCase)) = True Then
                    m.Alert(Me, "Esta REGIONAL já existe", False, "")
                    Exit Function
                End If
            End If
        End If

        ValidateRecord = True
    End Function
    Sub NewRecord()
        m.Alert(Me, "New Record", False, "")
    End Sub
    Sub InsertRecord()
        If ValidateRecord() = True Then

            'COD_REGIONAL é carregado na funcao validate
            Dim strREGIONAL As String = m.ConvertText(REGIONAL.Value, clsMaster.TextCaseOptions.UpperCase)
            Dim strEMAIL As String = m.ConvertText(EMAIL_GERENTE.Text, clsMaster.TextCaseOptions.LowerCase)
            Dim strATIVO As String = ATIVO.Text

            Dim sql As String = ""
            sql &= "INSERT INTO [TBL_SETORIZACAO_REGIONAIS]"
            sql &= "("
            sql &= "[COD_REGIONAL]"
            sql &= ",[REGIONAL]"
            sql &= ",[EMAIL_GERENTE]"
            sql &= ",[ATIVO]"
            sql &= ",[INCLUSAO_EMAIL]"
            sql &= ") "
            sql &= "VALUES("
            sql &= "'" & strCOD_REGIONAL & "'"
            sql &= ",'" & strREGIONAL & "'"
            sql &= ",'" & strEMAIL & "'"
            sql &= ",'" & ATIVO.Text & "'"
            sql &= ",'" & Session("EMAIL_LOGIN") & "')"

            If m.ExecuteSQL(sql) = True Then
                sql = ""
                sql &= "Select Id From APP_SETORIZACAO_REGIONAIS Where REGIONAL ='" & strREGIONAL & "'"
                Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect(sql)
                If dtr.HasRows Then
                    dtr.Read()
                    Dim Id = dtr("ID")
                    m.Alert(Me, "Regional incluida com sucesso", True, "Setorizacao_Regionais_Incluir.aspx?Id=" & Id.ToString)
                End If
            End If
        End If
    End Sub
    Sub RecoverRecord()
        Dim sql As String = "Select * From APP_SETORIZACAO_REGIONAIS Where ID = '" & Request.QueryString("Id") & "'"
        Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect(sql)
        If dtr.HasRows Then
            dtr.Read()
            'REGIONAL_ATUAL = dtr("REGIONAL")
            COD_REGIONAL.Value = dtr("COD_REGIONAL")
            REGIONAL.Value = dtr("REGIONAL")
            EMAIL_GERENTE.Text = dtr("EMAIL_GERENTE")
            ATIVO.Text = dtr("ATIVO")
        End If
    End Sub
    Sub UpdateRecord()
        If ValidateRecord() = True Then
            Dim sql As String = ""
            sql &= "UPDATE [TBL_SETORIZACAO_REGIONAIS] "
            sql &= "SET "
            sql &= "[REGIONAL] = '" & m.ConvertText(REGIONAL.Value, clsMaster.TextCaseOptions.UpperCase) & "'"
            sql &= ",[EMAIL_GERENTE] = '" & m.ConvertText(EMAIL_GERENTE.Text, clsMaster.TextCaseOptions.LowerCase) & "'"
            sql &= ",[ATIVO] = '" & ATIVO.Text & "'"
            sql &= ",[ATUALIZACAO_DATA] = '" & m.GettDateToString & "'"
            sql &= ",[ATUALIZACAO_EMAIL] = '" & Session("EMAIL_LOGIN") & "'"
            sql &= " WHERE ID = '" & Request.QueryString("Id") & "'"
            m.ExecuteSQL(sql)
            m.Alert(Me, "Regional ATUALIZADA com sucesso", True, "Setorizacao_Regionais_Incluir.aspx?Id=" & Request.QueryString("Id"))
        End If
    End Sub
End Class