
Partial Class Setores_Gerentes_Lista
    Inherits System.Web.UI.Page

    Private Sub Setores_Gerentes_Lista_Load(sender As Object, e As EventArgs) Handles Me.Load
        dts.SelectCommand = "Select * From APP_SETORIZACAO_REGIONAIS Order By REGIONAL"
        dts.DataBind()
    End Sub
End Class
