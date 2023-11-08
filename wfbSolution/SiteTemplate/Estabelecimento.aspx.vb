
Partial Class Estabelecimento
    Inherits System.Web.UI.Page
    ReadOnly s As New clsEstabelecimentos
    Private Sub Estabelecimento_Load(sender As Object, e As EventArgs) Handles Me.Load
        dts.SelectCommand = s.sql_Estabelecimentos("ficha", Request.QueryString("idEstabelecimento"))
        dts.DataBind()
        dtr.DataBind()
    End Sub
End Class
