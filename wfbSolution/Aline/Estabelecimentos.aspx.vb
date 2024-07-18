
Partial Class Estabelecimentos
    Inherits System.Web.UI.Page
    ReadOnly s As New clsEstabelecimentos
    Private Sub Estabelecimentos_Load(sender As Object, e As EventArgs) Handles Me.Load
        dts.SelectCommand = s.sql_Estabelecimentos("lista")
        dts.DataBind()
        dtr.DataBind()
    End Sub
End Class
