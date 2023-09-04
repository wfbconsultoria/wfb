Public Class Planta_Loja
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly l As New clsLojas
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dtr1 As SqlClient.SqlDataReader = m.ExecuteSelect("Select * From tb_Lojas_Imagens Where Id = 1 and Loja_Sigla = '" & l.Loja_Sigla & "'")
        If dtr1.HasRows Then
            dtr1.Read()
            Dim img As Byte() = CType(dtr1("Imagem"), Byte())
            Dim base64string As String = Convert.ToBase64String(img, 0, img.Length)
            Img1.Src = "data:image/png;base64," & base64string
        Else
        End If

        Dim dtr2 As SqlClient.SqlDataReader = m.ExecuteSelect("Select * From tb_Lojas_Imagens Where Id = 2 and Loja_Sigla = '" & l.Loja_Sigla & "'")
        If dtr2.HasRows Then
            dtr2.Read()
            Dim img As Byte() = CType(dtr2("Imagem"), Byte())
            Dim base64string As String = Convert.ToBase64String(img, 0, img.Length)
            Img2.Src = "data:image/png;base64," & base64string
        Else

        End If
    End Sub
End Class