Public Class Contatos_Emergencia_Form
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly l As New clsLojas
    ReadOnly c As New clsColaboradores

    Dim sql As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        c.CheckLogin()
        l.GetInfoLoja()
        txt_Loja_Sigla.Value = l.Loja_Sigla
        txt_Loja.Value = l.Loja

        If Request.QueryString("IdContato") = "NOVO" Then
            If IsPostBack() = False Then NewRecord()
            If IsPostBack() = True Then InsertRecord()
        Else
            If IsPostBack() = False Then RecoverRecord()
            If IsPostBack() = True Then SaveRecord()
        End If
    End Sub
    Private Sub cmd_Delete_Click(sender As Object, e As EventArgs) Handles cmd_Delete.Click
        DeleteRecord()
    End Sub
    Sub NewRecord()
        txt_Id.Value = ""
        txt_Endereco.Value = ""
        txt_Telefone.Value = ""
        txt_Descricao.Value = ""
        Insert_User.Value = ""
        Insert_Date.Value = ""
        Update_User.Value = ""
        Update_Date.Value = ""
    End Sub
    Sub InsertRecord()
        sql = ""
        sql = sql & " Insert Into [tb_Contatos_Emergencia] "
        sql = sql & " ([Loja_Sigla],[Telefone],[Descricao],[Endereco],[Insert_User]) "
        sql = sql & " VALUES ("
        sql = sql & " '" & m.ConvertText(txt_Loja_Sigla.Value, clsMaster.TextCaseOptions.UpperCase) & "',"
        sql = sql & " '" & m.ConvertText(txt_Telefone.Value, clsMaster.TextCaseOptions.UpperCase) & "',"
        sql = sql & " '" & m.ConvertText(txt_Descricao.Value, clsMaster.TextCaseOptions.TextCase) & "',"
        sql = sql & " '" & m.ConvertText(txt_Endereco.Value, clsMaster.TextCaseOptions.TextCase) & "',"
        sql = sql & "'" & Session("EMAIL_LOGIN") & "') "
        m.ExecuteSQL(sql)
        m.Alert(Me, m.ConvertText(txt_Descricao.Value, clsMaster.TextCaseOptions.UpperCase) & " incluido com sucesso!", True, "Contatos_Emergencia_Lista.aspx")

    End Sub

    Sub DeleteRecord()
        sql = ""
        sql = sql & " Delete From [tb_Contatos_Emergencia]  Where Id = '" & txt_Id.Value & "'"
        m.ExecuteSQL(sql)
        m.Alert(Me, m.ConvertText(txt_Descricao.Value, clsMaster.TextCaseOptions.UpperCase) & "CONTATO EXCLUIDO", True, "Contatos_Emergencia_Lista.aspx")

    End Sub

    Sub SaveRecord()
        sql = ""
        sql = sql & " UPDATE [tb_Contatos_Emergencia] SET "
        sql = sql & " Loja_Sigla = '" & m.ConvertText(txt_Loja_Sigla.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Telefone = '" & m.ConvertText(txt_Telefone.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Descricao = '" & m.ConvertText(txt_Descricao.Value, clsMaster.TextCaseOptions.TextCase) & "', "
        sql = sql & "Endereco = '" & m.ConvertText(txt_Endereco.Value, clsMaster.TextCaseOptions.TextCase) & "', "
        sql = sql & "Update_Date = '" & m.GetDateTimeToString & "',  "
        sql = sql & "Update_User = '" & Session("EMAIL_LOGIN") & "' "
        sql = sql & " Where Id = '" & Request.QueryString("IdContato") & "'"
        m.ExecuteSQL(sql)
        m.Alert(Me, m.ConvertText(txt_Descricao.Value, clsMaster.TextCaseOptions.UpperCase) & " atualizado com sucesso!", True, "Contatos_Emergencia_Lista.aspx")

    End Sub
    Sub RecoverRecord()
        Dim dtr As SqlClient.SqlDataReader
        dtr = m.ExecuteSelect("Select * From [tb_Contatos_Emergencia] Where Id = " & Request.QueryString("IdContato"))
        If dtr.HasRows Then
            dtr.Read()
            txt_Loja_Sigla.Value = l.Loja_Sigla
            txt_Loja.Value = l.Loja
            If Not IsDBNull(dtr("Id")) Then txt_Id.Value = dtr("Id") Else txt_Id.Value = ""
            If Not IsDBNull(dtr("Telefone")) Then txt_Telefone.Value = dtr("Telefone") Else txt_Telefone.Value = ""
            If Not IsDBNull(dtr("Descricao")) Then txt_Descricao.Value = dtr("Descricao") Else txt_Descricao.Value = ""
            If Not IsDBNull(dtr("Endereco")) Then txt_Endereco.Value = dtr("Endereco") Else txt_Endereco.Value = ""
            If Not IsDBNull(dtr("Insert_User")) Then Insert_User.Value = dtr("Insert_User") Else Insert_User.Value = ""
            If Not IsDBNull(dtr("Insert_Date")) Then Insert_Date.Value = dtr("Insert_Date") Else Insert_Date.Value = ""
            If Not IsDBNull(dtr("Update_User")) Then Update_User.Value = dtr("Update_User") Else Update_User.Value = ""
            If Not IsDBNull(dtr("Update_Date")) Then Update_Date.Value = dtr("Update_Date") Else Update_Date.Value = ""
        Else
            m.Alert(Me, "Contato não localizado", True, "Contatos_Emergencia_Lista.aspx")
        End If
    End Sub


End Class