
Partial Class DisassociateReport
    Inherits System.Web.UI.Page
    Dim m As New clsMaster

    Private Sub DisassociateReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Verificando query string existe
        If Request.Params("id") Is Nothing Then
            Response.Write("<script>alert('Erro ao consultar registro');window.location.href='Report.aspx';</script>")
        ElseIf Request.Params("email") Is Nothing Then
            Response.Write("<script>alert('Erro ao consultar usuário associado');window.location.href='AssociateReport.aspx?id=" + Request.Params("id").ToString() + "';</script>")
        ElseIf Request.Item("id").ToString() = "" Then 'Verificando query string esta preenchida
            Response.Write("<script>alert('Erro ao consultar registro');window.location.href='Report.aspx';</script>")
        ElseIf Request.Params("email").ToString() = "" Then
            Response.Write("<script>alert('Erro ao consultar usuário associado');window.location.href='AssociateReport.aspx?id=" + Request.Params("id").ToString() + "';</script>")
        Else
            'Desassociar usuário
            Dim sql As String = "delete from tb_pbi_Reports_Users where REPORT_ID='" & Request.Params("ID").ToString & "' AND USER_EMAIL ='" & Request.Params("email") & "';"

            If m.ExecuteSQL(sql) = True Then
                'Usuário desassociado
                Dim download As String = ""
                sql = ""
                sql = "SELECT REPORT_NAME FROM tb_pbi_Reports WHERE ID = '" + Request.Params("id").ToString + "';"
                Dim dtr As Data.SqlClient.SqlDataReader = m.ExecuteSelect(sql)
                While dtr.Read()
                    download = dtr("REPORT_NAME").ToString()
                End While
                Dim message As String = " Você foi desassociado do relatório " & download & vbCrLf
                m.EnviarEmail(Request.Params("email").ToString(), message)
                Response.Write("<script>alert('Usuário desassociado');window.location.href='AssociateReport.aspx?id=" + Request.Params("id").ToString() + "';</script>")
            Else
                'Erro ao desassociar
                Response.Write("<script>alert('Erro ao desassociar usuário');window.location.href='AssociateReport.aspx?id=" + Request.Params("id").ToString() + "';</script>")
            End If
        End If
    End Sub
End Class
