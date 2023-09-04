Public Class Colaborador_Visitante
    Inherits System.Web.UI.Page

    ReadOnly m As New clsMaster
    ReadOnly l As New clsLojas
    ReadOnly c As New clsColaboradores
    Dim sql As String = ""
    Dim Tipo_Colaborador As String = "Visitante"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
        txt_Ativo.Value = "Sim"
        txt_Empresa.Value = ""
        txt_Funcao.Value = ""
        txt_Email.Value = ""
        txt_Telefone.Value = ""
        txt_Observacao.Value = ""
        Insert_User.Value = ""
        Insert_Date.Value = ""
        Update_User.Value = ""
        Update_Date.Value = ""
    End Sub
    Sub InsertRecord()

        Dim IdKey = m.ConvertText(m.GenerateKey("VIS"), clsMaster.TextCaseOptions.UpperCase).ToString

        sql = ""
        sql = sql & " Insert Into tb_Colaboradores (Id_Key, Loja_Sigla, Id_Universo, Nome, Funcao, Email, Telefone, "
        sql = sql & " Endereco, Cidade, UF, Tipo, Ativo, Administrador, Brigadista, Empresa, Admissao_Data, Observacao, CheckIn_Status, CheckIn, Senha, Insert_Date, Insert_User) Values ( "
        sql = sql & "'" & IdKey & "', "
        sql = sql & "'" & l.Loja_Sigla & "', "
        sql = sql & " '0', " 'Universo (não definido)
        sql = sql & "'" & m.ConvertText(txt_Nome.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'" & m.ConvertText(txt_Funcao.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'" & m.ConvertText(txt_Email.Value, clsMaster.TextCaseOptions.LowerCase) & "', "
        sql = sql & "'" & m.ConvertText(txt_Telefone.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'', " 'Endereço (não definido)
        sql = sql & "'', " 'Cidade (não definido)
        sql = sql & "'', " 'UF (não definido)
        sql = sql & "'" & Tipo_Colaborador & "', "
        sql = sql & "'" & txt_Ativo.Value & "', "
        sql = sql & "'Nao', " 'Administrador (sempre Nao)
        sql = sql & "'Nao', " 'Brigadista (sempre Nao)
        sql = sql & "'" & m.ConvertText(txt_Empresa.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'" & m.GettDateToStringBR & "', " 'data visita
        sql = sql & "'" & m.ConvertText(txt_Observacao.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'Ausente', "
        sql = sql & "'0', "
        sql = sql & "'AcessoBloqueado', "
        sql = sql & "'" & m.GetDateTimeToString & "', "
        sql = sql & "'" & Session("EMAIL_LOGIN") & "') "
        m.ExecuteSQL(sql)
        c.GetInfoColaborador("", IdKey)
        m.Alert(Me, txt_Nome.Value & " VISITANTE incluido com sucesso!", True, "Colaborador_Visitante.aspx?IdColaborador=" & c.ColaboradorId)
    End Sub

    Sub SaveRecord()

        sql = ""
        sql = sql & " Update tb_Colaboradores Set "
        sql = sql & " Loja_Sigla = '" & l.Loja_Sigla & "', "
        sql = sql & "Id_Universo =  '0', " 'Universo (não definido)
        sql = sql & "Nome = '" & m.ConvertText(txt_Nome.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "Funcao = '" & m.ConvertText(txt_Funcao.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "Email = '" & m.ConvertText(txt_Email.Value, clsMaster.TextCaseOptions.LowerCase) & "', "
        sql = sql & "Telefone = '" & m.ConvertText(txt_Telefone.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        'sql = sql & "Endereco = '" & m.ConvertText(txt_Endereco.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        'sql = sql & "Cidade = '" & m.ConvertText(txt_Cidade.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        'sql = sql & "UF = '" & m.ConvertText(txt_UF.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "Tipo = '" & Tipo_Colaborador & "', "
        sql = sql & "Ativo = '" & txt_Ativo.Value & "', "
        sql = sql & "Administrador = 'Nao', " 'Administrador (sempre Nao)
        sql = sql & "Brigadista = 'Nao', " 'Brigadista (sempre Nao)
        sql = sql & "Empresa = '" & m.ConvertText(txt_Empresa.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        'sql = sql & "Admissao_Data = '" & m.ConvertText(txt_Admissao_Data.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "Observacao = '" & m.ConvertText(txt_Observacao.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "Update_Date = '" & m.GetDateTimeToString & "',  "
        sql = sql & "Update_User = '" & Session("EMAIL_LOGIN") & "' "
        sql = sql & " Where Id = '" & Request.QueryString("IdColaborador") & "'"
        m.ExecuteSQL(sql)
        c.GetInfoColaborador(Request.QueryString("IdColaborador"))
        m.Alert(Me, txt_Nome.Value & " VISITANTE atualizado com sucesso!", True, "Colaborador_Visitante.aspx?IdColaborador=" & c.ColaboradorId)
    End Sub
    Sub RecoverRecord(Optional NewIdKey As String = "")
        If NewIdKey <> "" Then
            c.GetInfoColaborador("", Request.QueryString(NewIdKey))
        Else
            c.GetInfoColaborador(Request.QueryString("IdColaborador"))
        End If

        txt_Id.Value = c.ColaboradorId
        txt_Nome.Value = c.ColaboradorNome
        txt_Ativo.Value = c.ColaboradorAtivo
        txt_Funcao.Value = c.ColaboradorFuncao
        txt_Email.Value = LCase(c.ColaboradorEmail)
        txt_Telefone.Value = c.ColaboradorTelefone
        'txt_Endereco.Value = c.ColaboradorEndereco
        'txt_Cidade.Value = c.ColaboradorCidade
        'txt_UF.Value = c.ColaboradorUF
        txt_Empresa.Value = c.ColaboradorEmpresa
        txt_Admissao_Data.Value = c.ColaboradorAdmissao_Data
        txt_Observacao.Value = c.ColaboradorObservacao
        Insert_User.Value = c.ColaboradorInsert_User
        Insert_Date.Value = c.ColaboradorInsert_Date
        Update_User.Value = c.ColaboradorUpdate_User
        Update_Date.Value = c.ColaboradorUpdate_Date
    End Sub
End Class