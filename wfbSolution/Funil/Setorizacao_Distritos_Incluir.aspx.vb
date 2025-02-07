
Imports System.Data

Partial Class Setorizacao_Distritos_Incluir
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Dim ACAO As String = ""
    Dim DISTRITO_ATUAL As String = ""
    Dim strCOD_DISTRITO As String = ""
    Dim strCOD_REGIONAL_ATUAL As String = ""


    Private Sub Setorizacao_Distritos_Incluir_Load(sender As Object, e As EventArgs) Handles Me.Load
        Atauliza_dts()
        Dim sql As String = "Select * From APP_SETORIZACAO_DISTRITOS Where ID = '" & Request.QueryString("Id") & "'"
        Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect(sql)

        'recupera valores atuais
        If dtr.HasRows Then
            dtr.Read()
            DISTRITO_ATUAL = m.ConvertText(dtr("DISTRITO"), clsMaster.TextCaseOptions.UpperCase)
            strCOD_REGIONAL_ATUAL = dtr("COD_REGIONAL")
        End If

        If Request.QueryString("Id") = "NOVO" Then
            If IsPostBack() = False Then
                COD_DISTRITO.Disabled = False
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
                COD_DISTRITO.Disabled = True
                ACAO = "RecoverRecord"
                RecoverRecord()
            End If
            If IsPostBack() = True Then
                COD_DISTRITO.Disabled = True
                ACAO = "UpdateRecord"
                UpdateRecord()
            End If
        End If
    End Sub

    Sub Atauliza_dts()
        Dim sql As String = ""

        'COD_REGIONAL
        sql = ""
        sql &= "Select '@' AS COD_REGIONAL, '( SELECIONE )' AS REGIONAL UNION ALL "
        sql &= "Select COD_REGIONAL,COD_REGIONAL + ' - ' + REGIONAL + '(' + GERENTE + ')' AS REGIONAL FROM APP_SETORIZACAO_REGIONAIS Order By COD_REGIONAL "
        dts_REGIONAL.SelectCommand = sql
        dts_REGIONAL.DataBind()

        'EMAIL_SUPERVISOR
        sql = ""
        sql &= "Select '@' AS EMAIL, '( SELECIONE )' AS NOME UNION ALL "
        sql &= "Select EMAIL,NOME FROM APP_USUARIOS Order By NOME "
        dts_EMAIL_SUPERVISOR.SelectCommand = sql
        dts_EMAIL_SUPERVISOR.DataBind()

        'ATIVO
        sql = "Select * From TBL_ATIVO_INATIVO Order By ATIVO_DESCRICAO"
        dts_ATIVO.SelectCommand = sql
        dts_ATIVO.DataBind()
    End Sub
    Function ValidateRecord() As Boolean
        ValidateRecord = False

        'COD_REGIONAL
        If COD_REGIONAL.Text = "@" Then
            m.Alert(Me, "Selecione a REGIONAL", False, "")
            Exit Function
        End If

        'COD_DISTRITO
        If Len(COD_DISTRITO.Value) < 1 Then
            m.Alert(Me, "Digite o Codigo do Distrito", False, "")
            Exit Function
        Else
            'formata COD_REGIONAL para dois caracteres 00
            If Len(COD_DISTRITO.Value) = 1 Then
                strCOD_DISTRITO = "0" & COD_DISTRITO.Value
            Else
                strCOD_DISTRITO = COD_DISTRITO.Value
            End If
        End If

        'DISTRITO
        If Len(m.ConvertText(DISTRITO.Value, clsMaster.TextCaseOptions.UpperCase)) < 3 Then
            m.Alert(Me, "DISTRITO deve ter no mínimo 3 caracteres", False, "")
            Exit Function
        End If

        'EMAIL_SUPERVISOR
        If EMAIL_SUPERVISOR.Text = "@" Then
            m.Alert(Me, "Selecione o SUPERVISOR", False, "")
            Exit Function
        End If

        'valida a inclusao de novo registro
        If ACAO = "InsertRecord" Then

            'Verifica se o ID_DISTRITO (COD_REGIONAL + COD_DISTRITO) já existe
            If m.CheckExists("APP_SETORIZACAO_DISTRITOS", "ID_DISTRITO", COD_REGIONAL.Text & strCOD_DISTRITO & "00") = True Then
                m.Alert(Me, "Este Codigo de DISTRITO já existe nesta REGIONAL. Selecione OUTRA REGIONAL ou MUDE o Codigo Do DISTRITO", False, "")
                Exit Function
            End If

            'Verifica se o nome do DISTRITO já existe
            If m.CheckExists("APP_SETORIZACAO_DISTRITOS", "DISTRITO", m.ConvertText(DISTRITO.Value, clsMaster.TextCaseOptions.UpperCase)) = True Then
                m.Alert(Me, "Este nome para o DISTRITO já está em uso", False, "")
                Exit Function
            End If

        End If
        'valida a atualizacao do registro
        If ACAO = "UpdateRecord" Then
            'Verifica se o ID_DISTRITO (COD_REGIONAL + COD_DISTRITO) já existe
            If COD_REGIONAL.Text <> strCOD_REGIONAL_ATUAL Then
                If m.CheckExists("APP_SETORIZACAO_DISTRITOS", "ID_DISTRITO", COD_REGIONAL.Text & COD_DISTRITO.Value & "00") = True Then
                    COD_REGIONAL.Text = strCOD_REGIONAL_ATUAL
                    m.Alert(Me, "Nao Este Codigo de DISTRITO já existe nesta REGIONAL. Selecione OUTRA REGIONAL ou MUDE o Codigo Do DISTRITO. O sistema reverteu para a REGIONAL anterior", False, "")
                    Exit Function
                End If
            End If

            'Verifica se o nome do DISTRITO já existe
            If DISTRITO_ATUAL <> m.ConvertText(DISTRITO.Value, clsMaster.TextCaseOptions.UpperCase) Then
                If m.CheckExists("APP_SETORIZACAO_DISTRITOS", "DISTRITO", m.ConvertText(DISTRITO.Value, clsMaster.TextCaseOptions.UpperCase)) = True Then
                    m.Alert(Me, "Este nome para o DISTRITO já está em uso", False, "")
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

            'COD_DISTRITO é carregado na funcao validate
            Dim strCOD_REGIONAL As String = COD_REGIONAL.Text
            Dim strDISTRITO As String = m.ConvertText(DISTRITO.Value, clsMaster.TextCaseOptions.UpperCase)
            Dim strEMAIL As String = m.ConvertText(EMAIL_SUPERVISOR.Text, clsMaster.TextCaseOptions.LowerCase)
            Dim strATIVO As String = ATIVO.Text

            Dim sql As String = ""
            sql &= "INSERT INTO [TBL_SETORIZACAO_DISTRITOS]"
            sql &= "("
            sql &= "[COD_REGIONAL]"
            sql &= ", [COD_DISTRITO]"
            sql &= ", [DISTRITO]"
            sql &= ", [EMAIL_SUPERVISOR]"
            sql &= ", [ATIVO]"
            sql &= ", [INCLUSAO_EMAIL]"
            sql &= ") Then "
            sql &= "VALUES("
            sql &= "'" & strCOD_REGIONAL & "'"
            Sql &= ",'" & strCOD_DISTRITO & "'"
            Sql &= ",'" & strDISTRITO & "'"
            Sql &= ",'" & strEMAIL & "'"
            Sql &= ",'" & ATIVO.Text & "'"
            Sql &= ",'" & Session("EMAIL_LOGIN") & "')"

            If m.ExecuteSQL(Sql) = True Then
                Sql = ""
                Sql &= "Select ID From APP_SETORIZACAO_DISTRITOS Where DISTRITO ='" & strDISTRITO & "'"
                Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect(Sql)
                If dtr.HasRows Then
                    dtr.Read()
                    Dim Id = dtr("ID")
                    m.Alert(Me, "DISTRITO incluidO com sucesso", True, "Setorizacao_Distritos_Incluir.aspx?Id=" & Id.ToString)
                End If
            End If
        End If
        End Sub
    Sub RecoverRecord()
        Dim sql As String = "Select * From APP_SETORIZACAO_DISTRITOS Where ID = '" & Request.QueryString("Id") & "'"
        Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect(sql)
        If dtr.HasRows Then
            dtr.Read()
            COD_REGIONAL.Text = dtr("COD_REGIONAL")
            COD_DISTRITO.Value = dtr("COD_DISTRITO")
            DISTRITO.Value = dtr("DISTRITO")
            EMAIL_SUPERVISOR.Text = dtr("EMAIL_SUPERVISOR")
            ATIVO.Text = dtr("ATIVO")
        End If
    End Sub
    Sub UpdateRecord()
        If ValidateRecord() = True Then
            Dim sql As String = ""
            sql &= "UPDATE [TBL_SETORIZACAO_DISTRITOS] "
            sql &= "SET "
            sql &= "[COD_REGIONAL] = '" & COD_REGIONAL.Text & "'"
            sql &= ",[DISTRITO] = '" & m.ConvertText(DISTRITO.Value, clsMaster.TextCaseOptions.UpperCase) & "'"
            sql &= ",[EMAIL_SUPERVISOR] = '" & m.ConvertText(EMAIL_SUPERVISOR.Text, clsMaster.TextCaseOptions.LowerCase) & "'"
            sql &= ",[ATIVO] = '" & ATIVO.Text & "'"
            sql &= ",[ATUALIZACAO_DATA] = '" & m.GettDateToString & "'"
            sql &= ",[ATUALIZACAO_EMAIL] = '" & Session("EMAIL_LOGIN") & "'"
            sql &= " WHERE ID = '" & Request.QueryString("Id") & "'"
            m.ExecuteSQL(sql)
            m.Alert(Me, "DISTRITO atualizado com sucesso", True, "Setorizacao_Distritos_Incluir.aspx?Id=" & Request.QueryString("Id"))
        End If
    End Sub
End Class