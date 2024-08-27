
Partial Class Estabelecimentos_Grupos_Lista
    Inherits System.Web.UI.Page

    Private Sub Estabelecimentos_Grupos_Lista_Load(sender As Object, e As EventArgs) Handles Me.Load
        dts.SelectCommand = "Select * From APP_ESTABELECIMENTOS_GRUPOS Order By GRUPO"
        dts.DataBind()
    End Sub
End Class
