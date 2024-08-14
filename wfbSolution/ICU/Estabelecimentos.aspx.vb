
Partial Class Estabelecimentos
    Inherits System.Web.UI.Page
    ReadOnly s As New clsEstabelecimentos
    Private Sub Estabelecimentos_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sql As String = ""


        dts.SelectCommand = "Select * From APP_ESTABELECIMENTOS Order By NOME_FANTASIA"
        dts.DataBind()
        dtr.DataBind()

    End Sub
End Class
