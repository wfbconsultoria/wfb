
Imports Newtonsoft.Json.Linq

Partial Class Usuario_Incluir
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly U As New clsUsuarios

    Private Sub Usuario_Incluir_Load(sender As Object, e As EventArgs) Handles Me.Load
        dts.SelectCommand = "Select * From TBL_USUARIOS_NIVEL Order By NIVEL"
        dts.DataBind()
        If Request.QueryString("EMAIL") = "NOVO" Then
            If IsPostBack() = False Then NewRecord()
            If IsPostBack() = True Then InsertRecord()
        Else
            If IsPostBack() = False Then RecoverRecord()
            If IsPostBack() = True Then SaveRecord()
        End If
    End Sub

    Private Sub cmd_Gravar_ServerClick(sender As Object, e As EventArgs) Handles cmd_Gravar.ServerClick
        Dim SQL As String = ""
        SQL = "Insert Into TBL_USUARIOS"
        m.ExecuteSQL(SQL)
    End Sub
    Function ValidateRecord() As Boolean
        ValidateRecord = False
        'NIVEL
        If NIVEL.Text = -1 Then
            m.Alert(Me, "Selecione o NIVEL de acesso", False, "")
            Exit Function
        End If
        'EMAIL
        If Len(m.ConvertText(EMAIL.Value, clsMaster.TextCaseOptions.LowerCase)) < 6 Then
            m.Alert(Me, "Email deve ter no mínimo 6 caracteres (x@.com)", False, "")
            Exit Function
        End If
        'NOME
        If Len(m.ConvertText(NOME.Value, clsMaster.TextCaseOptions.UpperCase)) < 3 Then
            m.Alert(Me, "Nome deve ter no mínimo 3 caracteres", False, "")
            Exit Function
        End If

        ValidateRecord = True
    End Function

    Sub NewRecord()
        m.Alert(Me, "NewRecord", False, "")
    End Sub
    Sub InsertRecord()
        If ValidateRecord() = True Then
            Dim strEMAIL As String = m.ConvertText(EMAIL.Value, clsMaster.TextCaseOptions.LowerCase)
            Dim strNOME As String = m.ConvertText(NOME.Value, clsMaster.TextCaseOptions.UpperCase)
            Dim strSENHA As String = U.GeneratePassword

            Dim sql As String = ""
            sql &= "INSERT INTO [dbo].[TBL_USUARIOS]"
            sql &= "("
            sql &= "[EMAIL]"
            sql &= ",[NOME]"
            sql &= ",[CELULAR]"
            sql &= ",[NIVEL]"
            sql &= ",[SENHA]"
            sql &= ",[ATIVO]"
            sql &= ",[INCLUSAO_EMAIL]"
            sql &= ") "
            sql &= "VALUES("
            sql &= "'" & strEMAIL & "'"
            sql &= ",'" & strNOME & "'"
            sql &= ",'" & m.ConvertText(CELULAR.Value, clsMaster.TextCaseOptions.UpperCase) & "'"
            sql &= ",'" & NIVEL.Text & "'"
            sql &= ",'" & strSENHA & "'"
            sql &= ",1"
            sql &= ",'" & Session("EMAIL_LOGIN") & "')"
            If m.ExecuteSQL(sql) = True Then
                Dim strMESSAGE = ""
                strMESSAGE &= strNOME & ", seu login foi incluido com sucesso !" & vbCrLf
                strMESSAGE &= strNOME & "Acesse https://icumedical.azurewebsites.net " & vbCrLf
                strMESSAGE &= strNOME & "Utilize seu EMAIL e a senha temporária " & strSENHA & vbCrLf
                strMESSAGE &= strNOME & "Você deverá susbtituir pela senha de sua preferencia após o primeiro login"
                m.SendMail(strEMAIL, strNOME, ConfigurationManager.AppSettings("App.Name") & " - SEU LOGIN FOI INCLUIDO", strMESSAGE)
                m.Alert(Me, "Usuário incluido com sucesso", False, "")
            End If
        End If
    End Sub

    Sub RecoverRecord()
        m.Alert(Me, "RecorverRecord", False, "")
    End Sub
    Sub SaveRecord()
        If ValidateRecord() = True Then
            m.Alert(Me, "InsertRecord " & NIVEL.Text, False, "")
        End If
    End Sub
End Class
