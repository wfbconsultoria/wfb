
Partial Class Setorizacao_Distritos_Lista
    Inherits System.Web.UI.Page

    Private Sub Setorizacao_Distritos_Lista_Load(sender As Object, e As EventArgs) Handles Me.Load
        dts.SelectCommand = "Select * From APP_SETORIZACAO_DISTRITOS Order By DISTRITO"
        dts.DataBind()
    End Sub
End Class
