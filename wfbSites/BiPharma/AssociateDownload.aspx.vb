
Imports System.Data.SqlClient

Partial Class AssociateDownload
    Inherits System.Web.UI.Page
    Dim m As New clsMaster

    Private Sub AssociateDownload_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Verificando sessão ativa
        If Session("USER_EMAIL") = Nothing Then Response.Redirect("Login")
        If Session("USER_EMAIL") = "" Then Response.Redirect("Login")

        'Verificando query string
        If Request.Params("id") Is Nothing Then
            Response.Write(<script>alert('Erro ao carregar informações do registro');window.location.href='Download.aspx'</script>)
        ElseIf Request.Params("id").ToString() = "" Then
            Response.Write(<script>alert('Erro ao carregar informações do registro');window.location.href='Download.aspx'</script>)
        End If
        'Carregando informações do download
        Dim dtr As SqlDataReader = m.ExecuteSelect("SELECT DOWNLOAD_TITLE, DOWNLOAD_DESCRIPTION From vw_Downloads_Users Where Active = 1 and ID = '" & Request.Params("id").ToString & "'")

        dtr.Read()
        lbl_title.InnerText = dtr("DOWNLOAD_TITLE").ToString()
        dtr.Close()

        'Resgatando dados para tabela
        dtr = m.ExecuteSelect("SELECT USER_EMAIL, USER_NAME, ID From vw_Downloads_Users Where Active = 1 and ID = '" & Request.Params("id").ToString & "'" & "ORDER BY USER_EMAIL ASC")

        Repeater1.DataSource = dtr
        Repeater1.DataBind()
    End Sub

    'Resgatando dados para select 
    Private Sub AssociateDownload_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'Montando where para não trazer usuários já associados
        Dim dtr As SqlDataReader = m.ExecuteSelect("SELECT USER_EMAIL, USER_NAME, ID From vw_Downloads_Users Where Active = 1 and ID = '" & Request.Params("id").ToString & "'" & "ORDER BY USER_EMAIL ASC")
        Dim where As String = ""
        While (dtr.Read)
            where += "AND USER_EMAIL <> '" + dtr("USER_EMAIL").ToString() + "' "
        End While
        dtr.Close()

        'Atribuindo data reader ao dropdown list
        dtr = m.ExecuteSelect("SELECT USER_EMAIL, USER_NAME, USER_NAME + ' - ' + USER_EMAIL AS 'Usuario' From tb_Users WHERE Active = 1 AND Show = 1 " + where + " ORDER BY USER_NAME ASC")
        ddl_associado.DataSource = dtr
        ddl_associado.DataTextField = "Usuario"
        ddl_associado.DataValueField = "USER_EMAIL"
        ddl_associado.DataBind()
    End Sub

    'Associar usuário
    Private Sub btn_associar_Click(sender As Object, e As EventArgs) Handles btn_associar.Click
        Dim sql As String = "INSERT tb_Downloads_Users (USER_EMAIL, DOWNLOAD_ID) VALUES("
        sql += "'" + ddl_associado.Text + "', "
        sql += "'" + Request.Params("id").ToString() + "');"

        If m.ExecuteSQL(sql) = True Then
            Response.Write("<script>alert('Usuário associado com sucesso');window.location.href='AssociateDownload.aspx?id=" + Request.Params("id").ToString() + "'</script>")
        Else
            Response.Write("<script>alert('Erro ao associar usuário')</script>")
        End If
    End Sub

    'Voltar
    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Response.Redirect("Download.aspx")
    End Sub
End Class
