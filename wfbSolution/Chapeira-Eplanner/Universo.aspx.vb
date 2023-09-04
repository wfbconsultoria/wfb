Public Class Universo
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Dim l As New clsLojas
    Dim u As New clsUniversos
    Dim c As New clsColaboradores
    Dim sql As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        l.GetInfoLoja()
        txt_Loja_Sigla.Value = l.Loja_Sigla
        txt_Loja.Value = l.Loja
        If Request.QueryString("Acao") = "EXCLUIR" Then
            DeleteRecord(Request.QueryString("IdUniverso"))
        End If
        If Request.QueryString("IdUniverso") = "NOVO" Then
            If IsPostBack() = False Then NewRecord()
            If IsPostBack() = True Then InsertRecord()
        Else
            If IsPostBack() = False Then RecoverRecord()
            If IsPostBack() = True Then SaveRecord()
        End If
    End Sub
    Sub NewRecord()
        txt_Id.Value = ""
        txt_Universo.Value = ""
        txt_Andar.Value = ""
        txt_Zona.Value = ""
    End Sub
    Sub InsertRecord()
        If u.GetInfoUniverso("", "", txt_Universo.Value) = True Then
            m.Alert(Me, "O Universo " & txt_Universo.Value & " ja está cadastrado")
            Exit Sub
        End If
        Dim IdKey = m.ConvertText(m.GenerateKey("UNI"), clsMaster.TextCaseOptions.UpperCase).ToString

        sql = ""
        sql = sql & "Insert Into tb_Universos (Id_Key,Loja_Sigla, Universo, Andar, Zona) Values ( "
        sql = sql & "'" & m.ConvertText(IdKey, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'" & m.ConvertText(txt_Loja_Sigla.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'" & m.ConvertText(txt_Universo.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'" & m.ConvertText(txt_Andar.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & "'" & m.ConvertText(txt_Zona.Value, clsMaster.TextCaseOptions.UpperCase) & "') "

        m.ExecuteSQL(sql)
        u.GetInfoUniverso("", IdKey)
        m.Alert(Me, "Universo " & txt_Universo.Value & " incluido com sucesso!", True, "Universo.aspx?IdUniverso=" & u.UniversoId)

    End Sub

    Sub SaveRecord()
        sql = ""
        sql = sql & " Update tb_Universos Set "
        sql = sql & " Loja_Sigla = '" & m.ConvertText(txt_Loja_Sigla.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Universo = '" & m.ConvertText(txt_Universo.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Andar = '" & m.ConvertText(txt_Andar.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Zona = '" & m.ConvertText(txt_Zona.Value, clsMaster.TextCaseOptions.UpperCase) & "' "
        sql = sql & " Where Id = '" & Request.QueryString("IdUniverso") & "'"
        m.ExecuteSQL(sql)
        m.Alert(Me, txt_Universo.Value & " atualizado com sucesso!", True, "Universo.aspx?IdUniverso=" & txt_Id.Value)

    End Sub
    Sub RecoverRecord()
        u.GetInfoUniverso(Request.QueryString("IdUniverso"))
        txt_Id.Value = u.UniversoId
        txt_Universo.Value = u.Universo
        txt_Andar.Value = u.UniversoAndar
        txt_Zona.Value = u.UniversoZona
    End Sub
    Sub DeleteRecord(Id As String)
        If m.CheckExists("tb_Colaboradores", "Id_Universo", Id) = True Then
            u.GetInfoUniverso(Id)
            m.Alert(Me, "Existem colaboradores associados ao universo " & u.Universo & " não é possivel excluir", True, "Universo.aspx?IdUniverso=" & Id)
            Exit Sub
        Else
            m.ExecuteSQL("Delete From tb_Universos Where Id = '" & Id & "'")
            m.Alert(Me, "Universo " & u.Universo & " EXCLUIDO com sucesso!", True, "Universos.aspx")
        End If
    End Sub

End Class