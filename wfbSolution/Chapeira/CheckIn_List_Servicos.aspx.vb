Public Class CheckIn_List_Servicos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sql = "Select * From view_Terceiros_Ativos Order By Nome"
        dtsTerceiros.SelectCommand = sql
        dtsTerceiros.DataBind()
    End Sub

End Class