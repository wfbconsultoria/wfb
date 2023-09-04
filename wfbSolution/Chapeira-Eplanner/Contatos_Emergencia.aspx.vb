Public Class Contatos_Emergencia
    Inherits System.Web.UI.Page
    ReadOnly l As New clsLojas
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtsContatosEmergencia.SelectCommand = "Select * From tb_Contatos_Emergencia Where Loja_Sigla = '" & l.Loja_Sigla & "' Order By Descricao"
        dtsContatosEmergencia.DataBind()
    End Sub

End Class