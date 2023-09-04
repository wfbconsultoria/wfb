Public Class Colaborador
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Dim l As New clsLojas
    Dim c As New clsColaboradores
    Dim sql As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dtsUniversos.SelectCommand = "Select * From tb_Universos Where Loja_Sigla = '" & l.Loja_Sigla & "' Order By Universo"
        dtsUniversos.DataBind()

        l.GetInfoLoja()
        txt_Loja_Sigla.Value = l.Loja_Sigla
        txt_Loja.Value = l.Loja
        If Request.QueryString("IdColaborador") = "NOVO" Then
            If IsPostBack() = False Then NewRecord()
            If IsPostBack() = True Then InsertRecord()
        Else
            If IsPostBack() = False Then RecoverRecord()
            If IsPostBack() = True Then SaveRecord()
        End If
    End Sub

    Sub NewRecord()
        txt_Id.Value = ""
        txt_Nome.Value = ""
        cmb_Id_Universo.ClearSelection()
        txt_Ativo.Value = "Sim"
        txt_Administrador.Value = "Nao"
        cmb_Brigadista.Value = "Nao"
        txt_Formacao_Data.Value = ""
        txt_Admissao_Data.Value = ""
        txt_Funcao.Value = ""
        txt_Email.Value = ""
        txt_Telefone.Value = ""
        txt_Endereco.Value = ""
        txt_Cidade.Value = ""
        txt_UF.Value = ""
        txt_Observacao.Value = ""
        Insert_User.Value = ""
        Insert_Date.Value = ""
        Update_User.Value = ""
        Update_Date.Value = ""
    End Sub
    Sub InsertRecord()
        If c.GetInfoColaborador("", "", txt_Email.Value) = True Then
            m.Alert(Me, "O e-mail " & txt_Email.Value & " ja está cadastrado para " & c.ColaboradorNome)
            Exit Sub
        End If
        Dim IdKey = m.ConvertText(m.GenerateKey("COL"), clsMaster.TextCaseOptions.UpperCase).ToString
        Dim tipo As String = ""
        If cmb_Brigadista.Value = "Sim" Then tipo = "Brigadista" Else tipo = "Colaborador"
        sql = ""
        sql = sql & " Insert Into tb_Colaboradores (Id_Key, Loja_Sigla, Id_Universo, Nome, Funcao, Email, Telefone, "
        sql = sql & " Endereco, Cidade, UF, Tipo, Ativo, Administrador, Brigadista, Formacao_Data, Admissao_Data, Observacao, CheckIn_Status, CheckIn, Senha, Insert_Date, Insert_User) Values ( "
        sql = sql & "'" & IdKey & "', "
        sql = sql & "'" & m.ConvertText(txt_Loja_Sigla.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " '" & cmb_Id_Universo.Text & "', "
        sql = sql & "'" & m.ConvertText(txt_Nome.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'" & m.ConvertText(txt_Funcao.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'" & m.ConvertText(txt_Email.Value, clsMaster.TextCaseOptions.LowerCase) & "', "
        sql = sql & "'" & m.ConvertText(txt_Telefone.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'" & m.ConvertText(txt_Endereco.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'" & m.ConvertText(txt_Cidade.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'" & m.ConvertText(txt_UF.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'" & tipo & "', "
        sql = sql & "'" & txt_Ativo.Value & "', "
        sql = sql & "'" & txt_Administrador.Value & "', "
        sql = sql & "'" & cmb_Brigadista.Value & "', "
        sql = sql & "'" & m.ConvertText(txt_Formacao_Data.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'" & m.ConvertText(txt_Admissao_Data.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'" & m.ConvertText(txt_Observacao.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'Ausente', "
        sql = sql & "'0', "
        sql = sql & "'" & m.GeneratePassword & "', "
        sql = sql & "'" & m.GetDateTimeToString & "', "
        sql = sql & "'" & Session("EMAIL_LOGIN") & "') "
        m.ExecuteSQL(sql)
        c.GetInfoColaborador("", IdKey)

        'Verifica se o usuário foi cadastrado como administrador e envia e-mail com a senha
        If c.ColaboradorAdministrador = "Sim" Then
            Dim msg As String = ""

            msg = msg & "Informações de acesso de administrador para " & ConfigurationManager.AppSettings("App.Name") & " - " & l.Loja & " " & "#"
            msg = msg & "Usuário: " & c.ColaboradorEmail & " " & "#"
            msg = msg & "Senha: " & c.ColaboradorSenha & " " & "#"
            m.SendMail(c.ColaboradorEmail, c.ColaboradorNome, ConfigurationManager.AppSettings("App.Name") & " - " & l.Loja & " - ACESSO DE ADMNISTRADOR", msg)
            m.Alert(Me, txt_Nome.Value & " ADMINISTRADOR incluido com sucesso! Será enviado um e-mail com as informações de acesso", True, "Colaborador.aspx?IdColaborador=" & c.ColaboradorId)
        Else
            m.Alert(Me, txt_Nome.Value & " COLABORADOR incluido com sucesso!", True, "Colaborador.aspx?IdColaborador=" & c.ColaboradorId)
        End If

    End Sub

    Sub SaveRecord()

        Dim tipo As String = ""
        If cmb_Brigadista.Value = "Sim" Then tipo = "Brigadista" Else tipo = "Colaborador"
        sql = ""
        sql = sql & " Update tb_Colaboradores Set "
        sql = sql & " Loja_Sigla = '" & m.ConvertText(txt_Loja_Sigla.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "Id_Universo =  '" & cmb_Id_Universo.Text & "', "
        sql = sql & "Nome = '" & m.ConvertText(txt_Nome.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "Funcao = '" & m.ConvertText(txt_Funcao.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "Email = '" & m.ConvertText(txt_Email.Value, clsMaster.TextCaseOptions.LowerCase) & "', "
        sql = sql & "Telefone = '" & m.ConvertText(txt_Telefone.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "Endereco = '" & m.ConvertText(txt_Endereco.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "Cidade = '" & m.ConvertText(txt_Cidade.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "UF = '" & m.ConvertText(txt_UF.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "Tipo = '" & tipo & "', "
        sql = sql & "Ativo = '" & txt_Ativo.Value & "', "
        sql = sql & "Administrador = '" & txt_Administrador.Value & "', "
        sql = sql & "Brigadista = '" & cmb_Brigadista.Value & "', "
        sql = sql & "Formacao_Data = '" & m.ConvertText(txt_Formacao_Data.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "Admissao_Data = '" & m.ConvertText(txt_Admissao_Data.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "Observacao = '" & m.ConvertText(txt_Observacao.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "Update_Date = '" & m.GetDateTimeToString & "',  "
        sql = sql & "Update_User = '" & Session("EMAIL_LOGIN") & "' "
        sql = sql & " Where Id = '" & Request.QueryString("IdColaborador") & "'"
        m.ExecuteSQL(sql)

        If c.ColaboradorSenha = "DefaultPassword" Then
            sql = ""
            sql = "Update tb_Colaboradores Set Senha = '" & m.GeneratePassword & "' Where Id = '" & Request.QueryString("IdColaborador") & "'"
            m.ExecuteSQL(sql)
        End If

        c.GetInfoColaborador(Request.QueryString("IdColaborador"))

        'Verifica se o usuário foi alterado par  como administrador e envia e-mail com a senha
        If c.ColaboradorAdministrador = "Sim" Then
            Dim msg As String = ""
            msg = msg & "Informações de acesso de adminstrador para " & ConfigurationManager.AppSettings("App.Name") & " - " & l.Loja & " " & "#"
            msg = msg & "Usuário: " & c.ColaboradorEmail & " " & "#"
            msg = msg & "Senha: " & c.ColaboradorSenha & " " & "#"
            m.SendMail(c.ColaboradorEmail, c.ColaboradorNome, ConfigurationManager.AppSettings("App.Name") & " - " & l.Loja & " - ACESSO DE ADMNISTRADOR", msg)
            m.Alert(Me, txt_Nome.Value & " ADMINISTRADOR atualizado com sucesso!", True, "Colaborador.aspx?IdColaborador=" & c.ColaboradorId)
        Else
            m.Alert(Me, txt_Nome.Value & " COLABORADOR atualizado com sucesso!", True, "Colaborador.aspx?IdColaborador=" & c.ColaboradorId)
        End If

    End Sub
    Sub RecoverRecord(Optional NewIdKey As String = "")
        If NewIdKey <> "" Then
            c.GetInfoColaborador("", Request.QueryString(NewIdKey))
        Else
            c.GetInfoColaborador(Request.QueryString("IdColaborador"))
        End If

        txt_Id.Value = c.ColaboradorId
        cmb_Id_Universo.Text = c.ColaboradorId_Universo
        txt_Nome.Value = c.ColaboradorNome
        txt_Ativo.Value = c.ColaboradorAtivo
        txt_Administrador.Value = c.ColaboradorAdministrador
        txt_Funcao.Value = c.ColaboradorFuncao
        txt_Email.Value = LCase(c.ColaboradorEmail)
        txt_Telefone.Value = c.ColaboradorTelefone
        txt_Endereco.Value = c.ColaboradorEndereco
        txt_Cidade.Value = c.ColaboradorCidade
        txt_UF.Value = c.ColaboradorUF
        cmb_Brigadista.Value = c.ColaboradorBrigadista
        txt_Formacao_Data.Value = c.ColaboradorFormacao_Data
        txt_Admissao_Data.Value = c.ColaboradorAdmissao_Data
        txt_Observacao.Value = c.ColaboradorObservacao
        Insert_User.Value = c.ColaboradorInsert_User
        Insert_Date.Value = c.ColaboradorInsert_Date
        Update_User.Value = c.ColaboradorUpdate_User
        Update_Date.Value = c.ColaboradorUpdate_Date
    End Sub
End Class