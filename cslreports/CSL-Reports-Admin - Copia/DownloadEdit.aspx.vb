
Imports System.Data.SqlClient

Partial Class DownloadEdit
    Inherits System.Web.UI.Page
    Dim m As New clsMaster

    Private Sub DownloadEdit_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Verificando sessão ativa
        If Session("USER_EMAIL") = Nothing Then Response.Redirect("Login")
        If Session("USER_EMAIL") = "" Then Response.Redirect("Login")

        'Verificando query string
        If Request.Params("id") Is Nothing Then
            Response.Write(<script>alert('Erro ao carregar informações do registro');window.location.href='Download.aspx'</script>)
        ElseIf Request.Params("id").ToString() = "" Then
            Response.Write(<script>alert('Erro ao carregar informações do registro');window.location.href='Download.aspx'</script>)
        End If
    End Sub

    'Atribuindo informações do registro
    Private Sub DownloadEdit_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Dim sql As String = "SELECT * FROM tb_Downloads WHERE ID = '" + Request.Params("id").ToString() + "'"
        Dim dtr As SqlDataReader = m.ExecuteSelect(sql)

        If dtr.HasRows Then
            dtr.Read()
            txt_titulo.Text = dtr("DOWNLOAD_TITLE").ToString()
            txt_link.Text = dtr("DOWNLOAD_LINK").ToString()
            txt_descricao.Text = dtr("DOWNLOAD_DESCRIPTION").ToString()
        Else
            'Erro ao ler informações do registro
            Response.Write("<script>window.alert('Erro ao ler informações do registro');window.location='Download.aspx'</script>")
        End If
    End Sub

    'Atualizar registro
    Private Sub btn_atualizar_Click(sender As Object, e As EventArgs) Handles btn_atualizar.Click
        Dim sql As String = "UPDATE tb_Downloads SET DOWNLOAD_TITLE = '" & m.ConvertText(txt_titulo.Text, clsMaster.TextCaseOptions.TextCase) & "',"
        sql += " DOWNLOAD_DESCRIPTION = '" & m.ConvertText(txt_descricao.Text, clsMaster.TextCaseOptions.TextCase) & "',"
        sql += " DOWNLOAD_LINK = '" & Replace(txt_link.Text, "'", "") & "'"
        sql += " WHERE ID ='" & Request.Params("ID") & "'"

        If m.ExecuteSQL(sql) = True Then
            'Atualizado com sucesso
            Response.Write("<script language='javascript'>window.alert('Atualizado com sucesso');</script>")
        Else
            'Erro ao atualizar
            Response.Write("<script language='javascript'>window.alert('Erro ao Atualizar');</script>")
        End If
    End Sub

    'Excluir registro
    Private Sub btn_excluir_Click(sender As Object, e As EventArgs) Handles btn_excluir.Click
        'Excluindo todas as associações com usuários
        Dim sql As String = "DELETE FROM tb_Downloads_Users WHERE DOWNLOAD_ID ='" & Request.Params("ID") & "'"
        m.ExecuteSelect(sql)
        'Excluindo registro
        sql = ""
        sql = "DELETE FROM tb_Downloads WHERE ID ='" & Request.Params("ID") & "'"
        If m.ExecuteSQL(sql) = True Then
            'Excluído com sucesso
            Response.Write("<script language='javascript'>window.alert('Excluído com sucesso');window.location.href='Download.aspx';</script>")
        Else
            'Erro ao excluir
            Response.Write("<script language='javascript'>window.alert('Erro ao Atualizar');</script>")
        End If
    End Sub
End Class
