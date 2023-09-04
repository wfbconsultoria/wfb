
Partial Class Cadastro
    Inherits System.Web.UI.Page
    Dim m As New clsMaster

    Private Sub btn_incluir_Click(sender As Object, e As EventArgs) Handles btn_incluir.Click
        'declaração de variaveis
        Dim sql As String = ""

        'comandos sql
        sql = sql & "Insert into tb_pbi_Reports(REPORT_NAME, REPORT_DESCRIPTION, REPORT_STRING)"
        sql = sql & " Values("
        sql = sql & "'" & m.ConvertText(txt_nome.Text, clsMaster.TextCaseOptions.TextCase) & "',"
        sql = sql & "'" & m.ConvertText(txt_descricao.Text, clsMaster.TextCaseOptions.TextCase) & "',"
        sql = sql & "'" & m.ConvertText(txt_link.Text, clsMaster.TextCaseOptions.TextCase) & "')"
        'Executa a variavel sql
        If m.ExecuteSQL(sql) = True Then
            'Se for verdadeiro ele exibe a mensagem de sucesso e retorna para pagina inicial
            Response.Write("<script language='javascript'>window.alert('Incluido com Sucesso');window.location='Default.aspx'</script>")
        Else
            'Se não ele exibe mensagem e retorna para pagina de cadastro de report
            Response.Write("<script language='javascript'>window.alert('Erro ao incluir');window.location='Cadastro.aspx'</script>")
        End If
    End Sub
End Class
