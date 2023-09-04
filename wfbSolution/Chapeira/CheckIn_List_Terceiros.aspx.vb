Public Class CheckIn_List_Terceiros
    Inherits System.Web.UI.Page
    ReadOnly l As New clsLojas
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sql = "Select * From tb_Colaboradores Where Loja_Sigla = '" & l.Loja_Sigla & "' and Tipo = 'Terceiro' and Ativo = 'Sim' Order By Nome"
        dtsColaboradores.SelectCommand = sql
        dtsColaboradores.DataBind()
    End Sub

    Public Function FormataStatus(Parameter As String) As String
        FormataStatus = "A"
        If Parameter = "Presente" Then FormataStatus = "P"
    End Function
End Class