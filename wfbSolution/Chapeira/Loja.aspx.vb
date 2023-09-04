Public Class Loja
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Dim l As New clsLojas
    Dim sql As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("EMAIL_LOGIN")) Or Session("EMAIL_LOGIN") = "" Then Response.Redirect("Default.aspx")
        txt_Loja_Sigla.Value = l.Loja_Sigla
        If IsPostBack() = True Then SaveRecord()
        RecoverRecord()
    End Sub

    Sub SaveRecord()
        sql = ""
        sql = sql & " Update tb_Lojas Set "
        sql = sql & " Loja = '" & m.ConvertText(txt_Loja.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Loja_Endereco = '" & m.ConvertText(txt_Loja_Endereco.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Loja_Cidade = '" & m.ConvertText(txt_Loja_Cidade.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Loja_UF = '" & m.ConvertText(txt_Loja_UF.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Loja_Telefone = '" & m.ConvertText(txt_Loja_Telefone.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Loja_Horario = '" & m.ConvertText(txt_Loja_Horario.Value, clsMaster.TextCaseOptions.UpperCase) & "' "
        sql = sql & " Where Loja_Sigla = '" & l.Loja_Sigla & "'"
        m.ExecuteSQL(sql)
        m.Alert(Me, "Loja atualizada !", False, "")
        RecoverRecord()
    End Sub
    Sub RecoverRecord()
        l.GetInfoLoja()
        txt_Loja.Value = l.Loja
        txt_Loja_Endereco.Value = l.Loja_Endereco
        txt_Loja_Cidade.Value = l.Loja_Cidade
        txt_Loja_UF.Value = l.Loja_UF
        txt_Loja_Telefone.Value = l.Loja_Telefone
        txt_Loja_Horario.Value = l.Loja_Horario
    End Sub
End Class