
Imports System.Data

Partial Class Estabelecimentos_Grupos_Incluir
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Dim ACAO As String = ""
    Dim GRUPO_ATUAL As String = ""
    Private Sub Estabelecimentos_Grupos_Incluir_Load(sender As Object, e As EventArgs) Handles Me.Load

        Atauliza_dts()
        Dim sql As String = "Select * From TBL_ESTABELECIMENTOS_GRUPOS Where Id = '" & Request.QueryString("Id") & "'"
        Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect(sql)
        If dtr.HasRows Then
            dtr.Read()
            GRUPO_ATUAL = dtr("GRUPO")
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
        sql &= "Select '@' AS EMAIL, '( SELECIONE )' AS NOME UNION ALL "
        sql &= "Select EMAIL,NOME FROM TBL_USUARIOS Order By NOME "
        'EMAIL_RESPOSNSAVEL
        dts_EMAIL_RESPONSAVEL.SelectCommand = sql
        dts_EMAIL_RESPONSAVEL.DataBind()
        'ATIVO
        sql = "Select * From TBL_ATIVO_INATIVO Order By ATIVO_DESCRICAO"
        dts_ATIVO.SelectCommand = sql
        dts_ATIVO.DataBind()
    End Sub
    Function ValidateRecord() As Boolean
        ValidateRecord = False
        'NIVEL
        If EMAIL_RESPONSAVEL.Text = "@" Then
            m.Alert(Me, "Selecione o RESPONSÁVEL", False, "")
            Exit Function
        End If
        'REGIONAL
        If Len(m.ConvertText(GRUPO.Value, clsMaster.TextCaseOptions.UpperCase)) < 3 Then
            m.Alert(Me, "GRUPO DISTRIBUIDOR deve ter no mínimo 3 caracteres", False, "")
            Exit Function
        End If

        If ACAO = "InsertRecord" Then
            If m.CheckExists("TBL_ESTABELECIMENTOS_GRUPOS", "GRUPO", m.ConvertText(GRUPO.Value, clsMaster.TextCaseOptions.UpperCase)) = True Then
                m.Alert(Me, "Este GRUPO já existe", False, "")
                Exit Function
            End If
        End If

        If ACAO = "UpdateRecord" Then
            If GRUPO_ATUAL <> m.ConvertText(GRUPO.Value, clsMaster.TextCaseOptions.UpperCase) Then
                If m.CheckExists("TBL_ESTABELECIMENTOS_GRUPOS", "GRUPO", m.ConvertText(GRUPO.Value, clsMaster.TextCaseOptions.LowerCase)) = True Then
                    m.Alert(Me, "Este GRUPO já existe", False, "")
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
            Dim strGRUPO As String = m.ConvertText(GRUPO.Value, clsMaster.TextCaseOptions.UpperCase)
            Dim strATIVO As String = ATIVO.Text

            Dim sql As String = ""
            sql &= "INSERT INTO [dbo].[TBL_ESTABELECIMENTOS_GRUPOS]"
            sql &= "("
            sql &= "[GRUPO]"
            sql &= ",[EMAIL_RESPONSAVEL]"
            sql &= ",[ATIVO]"
            sql &= ",[EMAIL_INCLUSAO]"
            sql &= ") "
            sql &= "VALUES("
            sql &= "'" & strGRUPO & "'"
            sql &= ",'" & strEMAIL & "'"
            sql &= ",'" & ATIVO.Text & "'"
            sql &= ",'" & Session("EMAIL_LOGIN") & "')"

            If m.ExecuteSQL(sql) = True Then
                sql = ""
                sql &= "Select Id From APP_ESTABELECIMENTOS_GRUPOS Where GRUPO ='" & strGRUPO & "'"
                Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect(sql)
                If dtr.HasRows Then
                    dtr.Read()
                    Dim Id = dtr("Id")
                    m.Alert(Me, "GRUPO incluido com sucesso", True, "Estabelecimentos_Grupos_Incluir.aspx?Id=" & Id.ToString)
                End If
            End If
        End If
    End Sub
    Sub RecoverRecord()
        Dim sql As String = "Select * From TBL_ESTABELECIMENTOS_GRUPOS Where Id = '" & Request.QueryString("Id") & "'"
        Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect(sql)
        If dtr.HasRows Then
            dtr.Read()
            GRUPO.Value = dtr("GRUPO")
            GRUPO_ATUAL = dtr("GRUPO")
            EMAIL_RESPONSAVEL.Text = dtr("EMAIL_RESPONSAVEL")
            ATIVO.Text = dtr("ATIVO")
        End If
    End Sub
    Sub UpdateRecord()
        If ValidateRecord() = True Then
            Dim sql As String = ""
            sql &= "UPDATE [dbo].[TBL_ESTABELECIMENTOS_GRUPOS] "
            sql &= "SET "
            sql &= "[GRUPO] = '" & GRUPO.Value & "'"
            sql &= ",[EMAIL_RESPONSAVEL] = '" & EMAIL_RESPONSAVEL.Text & "'"
            sql &= ",[ATIVO] = '" & ATIVO.Text & "'"
            sql &= ",[DATA_ALTERACAO] = '" & m.GettDateToString & "'"
            sql &= ",[EMAIL_ALTERACAO] = '" & Session("EMAIL_LOGIN") & "'"
            sql &= " WHERE Id = '" & Request.QueryString("Id") & "'"
            m.ExecuteSQL(sql)
            m.Alert(Me, "Grupo ATUALIZADO com sucesso", True, "Estabelecimentos_Grupos_Incluir.aspx?Id=" & Request.QueryString("Id"))
        End If
    End Sub
End Class