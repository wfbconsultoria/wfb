
Partial Class Distribuidores_Grupos_Lista
    Inherits System.Web.UI.Page
    Private Sub Distribuidores_Grupos_Lista_Load(sender As Object, e As EventArgs) Handles Me.Load
        dts.SelectCommand = "Select * From APP_DISTRIBUIDORES_GRUPOS Order By GRUPO_DISTRIBUIDOR"
        dts.DataBind()
    End Sub
End Class
