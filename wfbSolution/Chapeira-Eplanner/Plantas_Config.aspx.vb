Imports System.IO
Public Class Plantas_Config
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

    Private Sub cmd_Planta01_Click(sender As Object, e As EventArgs) Handles cmd_Planta01.Click
        On Error GoTo Err_cmd_Planta01_Click

        Dim strTipo As String = fup_Planta01.PostedFile.ContentType
        Dim intTamanho As Integer = System.Convert.ToInt32(fup_Planta01.PostedFile.InputStream.Length)
        Dim byteImagem As Byte() = New Byte(intTamanho - 1) {}
        fup_Planta01.PostedFile.InputStream.Read(byteImagem, 0, intTamanho)
        InsertImage(1, "Planta Combate a Incêndio", "", byteImagem, intTamanho, strTipo)
        Exit Sub
Err_cmd_Planta01_Click:
        m.SystemError(Err.Number, Err.Description, "", "Function: Plantas_Config.cmd_Planta01_Click")
    End Sub

    Private Sub cmd_Planta02_Click(sender As Object, e As EventArgs) Handles cmd_Planta02.Click
        On Error GoTo Err_cmd_Planta02_Click
        Dim strTipo As String = fup_Planta02.PostedFile.ContentType
        Dim intTamanho As Integer = System.Convert.ToInt32(fup_Planta02.PostedFile.InputStream.Length)
        Dim byteImagem As Byte() = New Byte(intTamanho - 1) {}
        fup_Planta02.PostedFile.InputStream.Read(byteImagem, 0, intTamanho)
        InsertImage(2, "Planta Detectores de Fumaça", "", byteImagem, intTamanho, strTipo)
        Exit Sub
Err_cmd_Planta02_Click:
        m.SystemError(Err.Number, Err.Description, "", "Function: Plantas_Config.cmd_Planta02_Click")
    End Sub

    Public Function InsertImage(Id, strTitulo, StrDescricao, byteImage, IntTamanho, strTipo) As Boolean
        On Error GoTo Err_InsertImage
        InsertImage = False
        Dim sqlImage As String
        sqlImage = ""

        If Not IsNothing(m.cnn) Then
            If m.cnn.State = ConnectionState.Open Then m.cnn.Close()
        End If
        'Conexao
        m.DatabaseConnect()

        'Exclui
        'cmdImage.CommandText = "spExcluirImagem"
        'cmdImage.ExecuteNonQuery()
        m.ExecuteSQL("Delete From tb_LOjas_Imagens Where Loja_Sigla = '" & l.Loja_Sigla & "' and Id = " & Id)

        'Command para stored procedure 'Inclui
        Dim cmdImage As System.Data.SqlClient.SqlCommand = m.cnn.CreateCommand
        cmdImage.CommandType = CommandType.StoredProcedure
        cmdImage.CommandText = "spAdicionarImagem"
        cmdImage.Parameters.AddWithValue("@Loja_Sigla", l.Loja_Sigla)
        cmdImage.Parameters.AddWithValue("@Id", Id)
        cmdImage.Parameters.AddWithValue("@Titulo", strTitulo)
        cmdImage.Parameters.AddWithValue("@Descricao", StrDescricao)
        cmdImage.Parameters.AddWithValue("@Imagem", byteImage)
        cmdImage.Parameters.AddWithValue("@Tamanho", IntTamanho)
        cmdImage.Parameters.AddWithValue("@Tipo", strTipo)
        cmdImage.ExecuteNonQuery()
        InsertImage = True
        Response.Redirect("Plantas_Config.aspx")
        Exit Function

Err_InsertImage:
        InsertImage = False
        m.SystemError(Err.Number, Err.Description, sqlImage, "Function: clsMaster.ExecuteSQL_InsertImage")
    End Function

End Class