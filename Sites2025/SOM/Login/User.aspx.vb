﻿
Imports System.Data

Partial Class Login_User
    Inherits System.Web.UI.Page

    ReadOnly m As New clsMaster
    Dim ACAO As String = ""

    Private Sub Usuario_Incluir_Load(sender As Object, e As EventArgs) Handles Me.Load
        If m.CheckQueryString("acao") = True Then ACAO = Request.QueryString("acao").ToString

        Atauliza_dts()
        If ACAO = "DeleteRecord" Then DeleteRecord()

        If Request.QueryString("EMAIL") = "NOVO" Then
            If IsPostBack() = False Then
                ATIVO.Text = True
                ATIVO.Enabled = False
                EMAIL.Value = Request.QueryString("EMAIL2")

                NewRecord()
            End If
            If IsPostBack() = True Then InsertRecord()
        Else
            If IsPostBack() = False Then RecoverRecord()
            If IsPostBack() = True Then UpdateRecord()
        End If
    End Sub
    Sub Atauliza_dts()
        'NIVEL
        dts_NIVEL.SelectCommand = "Select * From TBL_USUARIOS_NIVEL Order By NIVEL"
        dts_NIVEL.DataBind()
        'ATIVO
        dts_ATIVO.SelectCommand = "Select * From TBL_ATIVO_INATIVO Order By ATIVO_DESCRICAO"
        dts_ATIVO.DataBind()
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

    End Sub
    Sub InsertRecord()
        If ValidateRecord() = True Then
            Dim strEMAIL As String = m.ConvertText(EMAIL.Value, clsMaster.TextCaseOptions.LowerCase)
            Dim strNOME As String = m.ConvertText(NOME.Value, clsMaster.TextCaseOptions.UpperCase)
            Dim strSENHA As String = ConfigurationManager.AppSettings(".Initials") & m.GeneratePassword

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
            sql &= ",[SENHA_SISTEMA]"
            sql &= ") "
            sql &= "VALUES("
            sql &= "'" & strEMAIL & "'"
            sql &= ",'" & strNOME & "'"
            sql &= ",'" & m.ConvertText(CELULAR.Value, clsMaster.TextCaseOptions.UpperCase) & "'"
            sql &= ",'" & NIVEL.Text & "'"
            sql &= ",'" & strSENHA & "'"
            sql &= ",'" & ATIVO.Text & "'"
            sql &= ",'" & Session("EMAIL_LOGIN") & "'"
            sql &= ",'" & strSENHA & "')"
            If m.ExecuteSQL(sql) = True Then
                Dim strMESSAGE = ""
                strMESSAGE &= strNOME & "<br/>"
                strMESSAGE &= "Seu login foi incluido com sucesso! <br/>"
                strMESSAGE &= "Acesse https://icumedical.azurewebsites.net <br/> "
                strMESSAGE &= "Utilize seu EMAIL e a senha temporária " & strSENHA & "<br/>"
                strMESSAGE &= "Você deverá susbtituir pela senha de sua preferencia após o primeiro login <br/>"
                m.SendMail(strEMAIL, strNOME, ConfigurationManager.AppSettings("App.Name") & " - SEU LOGIN FOI INCLUIDO", strMESSAGE)
                m.Alert(Me, "Usuário incluido com sucesso", True, "User.aspx?EMAIL=" & strEMAIL)
            End If
        End If
    End Sub
    Sub RecoverRecord()
        Dim sql As String = "Select * From APP_USUARIOS Where EMAIL = '" & Request.QueryString("EMAIL") & "'"
        Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect(sql)
        If dtr.HasRows Then
            dtr.Read()
            EMAIL_EXCLUIR.Value = dtr("EMAIL")
            EMAIL.Value = dtr("EMAIL")
            NOME.Value = dtr("NOME")
            CELULAR.Value = dtr("CELULAR")
            NIVEL.Text = dtr("NIVEL")
            ATIVO.Text = dtr("ATIVO")
        End If
    End Sub
    Sub UpdateRecord()

        If m.CheckExists("SYS_REGISTROS_SISTEMA", "VALOR", EMAIL.Value) = True Then
            m.Alert(Me, "NÃO É POSSIVEL ALTERAR " & EMAIL.Value & ", registro do sistema", False, "")
            RecoverRecord()
        End If

        If ValidateRecord() = True Then
            Dim sql As String = ""
            sql &= "UPDATE [dbo].[TBL_USUARIOS] "
            sql &= "SET "
            sql &= "[NOME] = '" & NOME.Value & "'"
            sql &= ",[CELULAR] = '" & CELULAR.Value & "'"
            sql &= ",[NIVEL] = '" & NIVEL.Text & "'"
            sql &= ",[ATIVO] = '" & ATIVO.Text & "'"
            sql &= ",[ALTERACAO_DATA] = '" & m.GettDateToString & "'"
            sql &= ",[ALTERACAO_EMAIL] = '" & Session("EMAIL_LOGIN") & "'"
            sql &= " WHERE EMAIL = '" & EMAIL.Value & "'"
            m.ExecuteSQL(sql)

            If RESET_SENHA.Value = 1 Then
                Dim NOVA_SENHA = ConfigurationManager.AppSettings("App.Initials") & m.GeneratePassword
                sql = ""
                sql &= "UPDATE [dbo].[TBL_USUARIOS] SET "
                sql &= "SENHA = '" & NOVA_SENHA & "'"
                sql &= ",SENHA_SISTEMA = '" & NOVA_SENHA & "'"
                sql &= " WHERE EMAIL = '" & EMAIL.Value & "'"
                m.ExecuteSQL(sql)
                Dim strMESSAGE = ""
                strMESSAGE &= NOME.Value & "<br/>"
                strMESSAGE &= "Sua SENHA foi ALTERADA pelo administrador! <br/>"
                strMESSAGE &= "Acesse https://icumedical.azurewebsites.net <br/> "
                strMESSAGE &= "Utilize seu EMAIL e a senha temporária " & NOVA_SENHA & "<br/>"
                strMESSAGE &= "Você deverá susbtituir pela senha de sua preferencia após o primeiro login <br/"
                m.SendMail(EMAIL.Value, NOME.Value, ConfigurationManager.AppSettings("App.Initials") & " - SUA SENHA FOI ALTERADA", strMESSAGE)
            End If
        End If
        m.Alert(Me, "Usuário ATUALIZADO com sucesso", True, "User.aspx?EMAIL=" & EMAIL.Value)
    End Sub

    Sub DeleteRecord()
        RecoverRecord()
        'check tabelas

        If m.CheckExists("TBL_USUARIOS", "EMAIL", EMAIL.Value) = False Then
            m.Alert(Me, "NÃO É POSSIVEL EXCLUIR " & EMAIL.Value & ", NÃO CADASTRADO", True, "Usuarios_Lista.aspx")
            Exit Sub
        End If

        If m.CheckExists("SYS_REGISTROS_SISTEMA", "VALOR", EMAIL.Value) = True Then
            m.Alert(Me, "NÃO É POSSIVEL EXCLUIR " & EMAIL.Value & ", registro do sistema", True, "Usuarios_Lista.aspx")
            Exit Sub
        End If

        If m.CheckExists("TBL_SETORIZACAO_SETORES", "EMAIL_RESPONSAVEL", EMAIL.Value) = True Then
            m.Alert(Me, "NÃO É POSSIVEL EXCLUIR " & EMAIL.Value & ", associado a um ou mais SETORES", True, "Usuario_Incluir.aspx?EMAIL=" & EMAIL.Value)
            Exit Sub
        End If
        If m.CheckExists("TBL_SETORIZACAO_REGIONAIS", "EMAIL_RESPONSAVEL", EMAIL.Value) = True Then
            m.Alert(Me, "NÃO É POSSIVEL EXCLUIR " & EMAIL.Value & ", associado a uma ou mais REGIONAIS", True, "Usuario_Incluir.aspx?EMAIL=" & EMAIL.Value)
            Exit Sub
        End If
        If m.CheckExists("TBL_DISTRIBUIDORES_GRUPOS", "EMAIL_RESPONSAVEL", EMAIL.Value) = True Then
            m.Alert(Me, "NÃO É POSSIVEL EXCLUIR " & EMAIL.Value & ", associado a um ou mais DISTRIBUIDORES", True, "Usuario_Incluir.aspx?EMAIL=" & EMAIL.Value)
            Exit Sub
        End If

        If m.CheckExists("TBL_ESTABELECIMENTOS_GRUPOS", "EMAIL_RESPONSAVEL", EMAIL.Value) = True Then
            m.Alert(Me, "NÃO É POSSIVEL EXCLUIR " & EMAIL.Value & ", associado a um ou mais GRUPOS DE ESTABELECIMENTOS", True, "Usuario_Incluir.aspx?EMAIL=" & EMAIL.Value)
            Exit Sub
        End If

        'exclui
        Dim sql As String = ""
        sql = "Delete From TBL_USUARIOS Where EMAIL = '" & EMAIL.Value & "'"
        If m.ExecuteSQL(sql) = True Then
            m.Alert(Me, "USUARIO EXCLUIDO COM SUCESSO", True, "Usuarios_Lista.aspx")
            Exit Sub
        End If

    End Sub

    Private Sub cmd_Excluir_ServerClick(sender As Object, e As EventArgs) Handles cmd_Excluir.ServerClick
        Response.Redirect("User.aspx?EMAIL=" & EMAIL.Value & "&acao=DeleteRecord")
    End Sub
End Class


