
Partial Class DisassociateDownload
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Private Sub DisassociateDownload_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Verificando query string existe
        If Request.Params("id") Is Nothing Then
            Response.Write("<script>alert('Erro ao consultar registro');window.location.href='Download.aspx';</script>")
        ElseIf Request.Params("email") Is Nothing Then
            Response.Write("<script>alert('Erro ao consultar usuário associado');window.location.href='AssociateDownload.aspx?id=" + Request.Params("id").ToString() + "';</script>")
        ElseIf Request.Item("id").ToString() = "" Then 'Verificando query string esta preenchida
            Response.Write("<script>alert('Erro ao consultar registro');window.location.href='Download.aspx';</script>")
        ElseIf Request.Params("email").ToString() = "" Then
            Response.Write("<script>alert('Erro ao consultar usuário associado');window.location.href='AssociateDownload.aspx?id=" + Request.Params("id").ToString() + "';</script>")
        Else
            'Desassociar usuário
            Dim sql As String = "DELETE tb_Downloads_Users WHERE DOWNLOAD_ID ='" + Request.Params("id").ToString() + "' AND USER_EMAIL ='" + Request.Params("email").ToString() + "';"

            If m.ExecuteSQL(sql) = True Then
                'Usuário desassociado
                Dim download As String = ""
                sql = ""
                sql = "SELECT DOWNLOAD_TITLE FROM tb_Downloads WHERE ID = '" + Request.Params("id").ToString + "';"
                Dim dtr As Data.SqlClient.SqlDataReader = m.ExecuteSelect(sql)
                While dtr.Read()
                    download = dtr("DOWNLOAD_TITLE").ToString()
                End While
                Dim message As String = " Você foi desassociado do download " & download & vbCrLf
                m.EnviarEmail(Request.Params("email").ToString(), message)
                Response.Write("<script>alert('Usuário desassociado');window.location.href='AssociateDownload.aspx?id=" + Request.Params("id").ToString() + "';</script>")
            Else
                'Erro ao desassociar
                Response.Write("<script>alert('Erro ao desassociar usuário');window.location.href='AssociateDownload.aspx?id=" + Request.Params("id").ToString() + "';</script>")
            End If
        End If
    End Sub
End Class
