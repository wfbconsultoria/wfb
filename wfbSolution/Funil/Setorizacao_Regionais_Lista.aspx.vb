
Partial Class Setorizacao_Regionais_Lista
    Inherits System.Web.UI.Page

    Private Sub Setorizacao_Regionais_Lista_Load(sender As Object, e As EventArgs) Handles Me.Load
        dts.SelectCommand = "Select * From APP_SETORIZACAO_REGIONAIS Order By REGIONAL"
        dts.DataBind()
    End Sub
End Class
