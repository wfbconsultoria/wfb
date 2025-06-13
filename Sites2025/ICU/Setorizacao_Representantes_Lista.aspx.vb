
Partial Class Setorizacao_Representantes_Lista
    Inherits System.Web.UI.Page

    Private Sub Setorizacao_Representantes_Lista_Load(sender As Object, e As EventArgs) Handles Me.Load
        dts.SelectCommand = "Select * From APP_SETORIZACAO_SETORES Order By SETOR"
        dts.DataBind()
    End Sub
End Class
