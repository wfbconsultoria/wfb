Imports System.Data.SqlClient

Partial Class RegisterDownload
    Inherits System.Web.UI.Page
    Dim m As New clsMaster

    Private Sub btn_incluir_Click(sender As Object, e As EventArgs) Handles btn_incluir.Click
        'Cadastrar download no banco de dados
        Dim sql As String
        Dim dtr As SqlDataReader

        'Verificando se o link já está em uso
        sql = "SELECT DOWNLOAD_LINK FROM tb_Downloads WHERE DOWNLOAD_LINK = '" + Replace(txt_link.Text, "'", "") + "';"
        dtr = m.ExecuteSelect(sql)

        If dtr.HasRows Then
            'Link já cadastrado
            Response.Write(<script>alert('O link de download já está sendo usado em outro registro')</script>)
            txt_link.Focus()
        Else
            'Cadastrar download
            Dim link As String = Replace(txt_link.Text, "'", "")
            Dim titulo As String = m.ConvertText(txt_titulo.Text, clsMaster.TextCaseOptions.TextCase)
            Dim descricao As String = m.ConvertText(txt_descricao.Text, clsMaster.TextCaseOptions.TextCase)

            sql = ""
            sql = "INSERT tb_Downloads(DOWNLOAD_TITLE, DOWNLOAD_LINK, DOWNLOAD_DESCRIPTION, Insert_User) VALUES ("
            sql += "'" + titulo + "', "
            sql += "'" + link + "', "
            sql += "'" + descricao + "', "
            sql += "'" + Session("USER_EMAIL") + "');"

            If m.ExecuteSQL(sql) Then
                'Cadastrado com sucesso
                Response.Write(<script>alert('Cadastrado com sucesso!')</script>)
                txt_titulo.Text = ""
                txt_link.Text = ""
                txt_descricao.Text = ""
            Else
                'Erro ao cadastrar
                Response.Write(<script>alert('Erro ao cadastrar!')</script>)
            End If
        End If
    End Sub

End Class
