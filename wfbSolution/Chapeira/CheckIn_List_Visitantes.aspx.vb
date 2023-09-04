Public Class CheckIn_List_Visitantes
    Inherits System.Web.UI.Page
    ReadOnly l As New clsLojas

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sql = "Select * From view_Visitantes_Ativos Where Loja_Sigla = '" & l.Loja_Sigla & "' Order By Nome"
        dtsVisitantes.SelectCommand = sql
        dtsVisitantes.DataBind()
    End Sub

End Class