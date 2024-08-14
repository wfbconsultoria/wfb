
Imports System.Data

Partial Class Setorizacao_Representantes_Incluir
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Dim ACAO As String = ""
    Dim SETOR_ATUAL As String = ""
    Private Sub Setorizacao_Representantes_Incluir_Load(sender As Object, e As EventArgs) Handles Me.Load
        Atauliza_dts()
        Dim sql As String = "Select * From TBL_SETORIZACAO_SETORES Where Id = '" & Request.QueryString("Id") & "'"
        Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect(sql)
        If dtr.HasRows Then
            dtr.Read()
            SETOR_ATUAL = dtr("SETOR")
        End If
        If Request.QueryString("Id") = "NOVO" Then
            If IsPostBack() = False Then
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
                ACAO = "RecoverRecord"
                RecoverRecord()
            End If
            If IsPostBack() = True Then
                ACAO = "UpdateRecord"
                UpdateRecord()
            End If
        End If
    End Sub
    Sub Atauliza_dts()
        Dim sql As String = ""
        'REGIONAIS
        sql = ""
        sql &= "Select '@' AS Id, '( SELECIONE )' AS REGIONAL UNION ALL "
        sql &= "Select CONVERT(VARCHAR(64), Id) AS Id ,REGIONAL FROM TBL_SETORIZACAO_REGIONAIS Order By REGIONAL "
        dts_REGIONAIS.SelectCommand = sql
        dts_REGIONAIS.DataBind()
        'EMAIL
        sql = ""
        sql &= "Select '@' AS EMAIL, '( SELECIONE )' AS NOME UNION ALL "
        sql &= "Select EMAIL,NOME FROM TBL_USUARIOS Order By NOME "
        dts_EMAIL_RESPONSAVEL.SelectCommand = sql
        dts_EMAIL_RESPONSAVEL.DataBind()
        'ATIVO
        sql = "Select * From TBL_ATIVO_INATIVO Order By ATIVO_DESCRICAO"
        dts_ATIVO.SelectCommand = sql
        dts_ATIVO.DataBind()
    End Sub
    Function ValidateRecord() As Boolean
        ValidateRecord = False
        'SETOR
        If Id_REGIONAL.Text = "@" Then
            m.Alert(Me, "Selecione a REGIONAL", False, "")
            Exit Function
        End If
        'EMAIL
        If EMAIL_RESPONSAVEL.Text = "@" Then
            m.Alert(Me, "Selecione o RESPONSÁVEL", False, "")
            Exit Function
        End If
        'SETOR
        If Len(m.ConvertText(SETOR.Value, clsMaster.TextCaseOptions.UpperCase)) < 3 Then
            m.Alert(Me, "SETOR deve ter no mínimo 3 caracteres", False, "")
            Exit Function
        End If

        If ACAO = "InsertRecord" Then
            If m.CheckExists("TBL_SETORIZACAO_SETORES", "SETOR", m.ConvertText(SETOR.Value, clsMaster.TextCaseOptions.UpperCase)) = True Then
                m.Alert(Me, "Este SETOR já existe", False, "")
                Exit Function
            End If
        End If

        If ACAO = "UpdateRecord" Then
            If SETOR_ATUAL <> m.ConvertText(SETOR.Value, clsMaster.TextCaseOptions.UpperCase) Then
                If m.CheckExists("TBL_SETORIZACAO_SETORES", "SETOR", m.ConvertText(SETOR.Value, clsMaster.TextCaseOptions.LowerCase)) = True Then
                    m.Alert(Me, "Este SETOR já existe", False, "")
                    Exit Function
                End If
            End If
        End If

        ValidateRecord = True
    End Function
    Sub NewRecord()

    End Sub
    Sub InsertRecord()
        If ValidateRecord() = True Then
            Dim strEMAIL As String = m.ConvertText(EMAIL_RESPONSAVEL.Text, clsMaster.TextCaseOptions.LowerCase)
            Dim strSETOR As String = m.ConvertText(SETOR.Value, clsMaster.TextCaseOptions.UpperCase)
            Dim str_Id_REGIONAL As String = Id_REGIONAL.Text.ToString
            Dim strATIVO As String = ATIVO.Text

            Dim sql As String = ""
            sql &= "INSERT INTO [dbo].[TBL_SETORIZACAO_SETORES]"
            sql &= "("
            sql &= "[SETOR]"
            sql &= ",[Id_REGIONAL]"
            sql &= ",[EMAIL_RESPONSAVEL]"
            sql &= ",[ATIVO]"
            sql &= ",[EMAIL_INCLUSAO]"
            sql &= ") "
            sql &= "VALUES("
            sql &= "'" & strSETOR & "'"
            sql &= ",'" & str_Id_REGIONAL & "'"
            sql &= ",'" & strEMAIL & "'"
            sql &= ",'" & ATIVO.Text & "'"
            sql &= ",'" & Session("EMAIL_LOGIN") & "')"

            If m.ExecuteSQL(sql) = True Then
                sql = ""
                sql &= "Select Id From APP_SETORIZACAO_SETORES Where SETOR ='" & strSETOR & "'"
                Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect(sql)
                If dtr.HasRows Then
                    dtr.Read()
                    Dim Id = dtr("Id")
                    m.Alert(Me, "Setor Incluido com sucesso", True, "Setorizacao_Representantes_Incluir.aspx?Id=" & Id.ToString)
                End If
            End If
        End If
    End Sub
    Sub RecoverRecord()
        Dim sql As String = ""
        sql &= "Select SETOR,EMAIL_RESPONSAVEL, CONVERT(VARCHAR(64),Id_Regional) AS Id_REGIONAL, ATIVO "
        sql &= "From TBL_SETORIZACAO_SETORES Where Id = '" & Request.QueryString("Id") & "'"

        Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect(sql)
        If dtr.HasRows Then
            dtr.Read()
            SETOR.Value = dtr("SETOR")
            EMAIL_RESPONSAVEL.Text = dtr("EMAIL_RESPONSAVEL").ToString
            Id_REGIONAL.Text = dtr("Id_REGIONAL").ToString
            ATIVO.Text = dtr("ATIVO")
        End If
    End Sub
    Sub UpdateRecord()
        If ValidateRecord() = True Then
            Dim sql As String = ""
            sql &= "UPDATE [dbo].[TBL_SETORIZACAO_SETORES] "
            sql &= "SET "
            sql &= "[SETOR] = '" & SETOR.Value & "'"
            sql &= ",[EMAIL_RESPONSAVEL] = '" & EMAIL_RESPONSAVEL.Text & "'"
            sql &= ",[Id_REGIONAL] = '" & Id_REGIONAL.Text & "'"
            sql &= ",[ATIVO] = '" & ATIVO.Text & "'"
            sql &= ",[DATA_ALTERACAO] = '" & m.GettDateToString & "'"
            sql &= ",[EMAIL_ALTERACAO] = '" & Session("EMAIL_LOGIN") & "'"
            sql &= " WHERE Id = '" & Request.QueryString("Id") & "'"
            m.ExecuteSQL(sql)
            m.Alert(Me, "Setor ATUALIZADO com sucesso", True, "Setorizacao_Representantes_Incluir.aspx?Id=" & Request.QueryString("Id"))
        End If
    End Sub
End Class

