Public Class RegisterReport
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Private Sub RegisterReport_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub btn_incluir_Click(sender As Object, e As EventArgs) Handles btn_incluir.Click
        'declaração de variaveis
        Dim sql As String = ""
        Dim dtr As System.Data.SqlClient.SqlDataReader
        sql = "select * from tb_pbi_Reports where REPORT_STRING='" & m.ConvertText(txt_link.Text, clsMaster.TextCaseOptions.TextCase) & "'"
        dtr = m.ExecuteSelect(sql)
        If dtr.HasRows Then
            dtr.Read()
            Response.Write("<script>alert('Este relátorio já esta presente no site.');history.back();</script>")
        Else
            'comandos sql
            sql = ""
            sql = "Insert into tb_pbi_Reports(REPORT_NAME, REPORT_DESCRIPTION, REPORT_STRING)"
            sql = sql & " Values("
            sql = sql & "'" & m.ConvertText(txt_nome.Text, clsMaster.TextCaseOptions.TextCase) & "',"
            sql = sql & "'" & m.ConvertText(txt_descricao.Text, clsMaster.TextCaseOptions.TextCase) & "',"
            sql = sql & "'" & m.ConvertText(txt_link.Text, clsMaster.TextCaseOptions.TextCase) & "')"
            'Executa a variavel sql
            If m.ExecuteSQL(sql) = True Then
                'Se for verdadeiro ele exibe a mensagem de sucesso e retorna para pagina inicial
                Dim message As String = " Você incluiu o relatório " & m.ConvertText(txt_nome.Text, clsMaster.TextCaseOptions.TextCase) & " para associá-lo a uma pessoa: " & vbCrLf
                message += "na aba administrar clique no nome do relatório, " & vbCrLf
                message += "escolha o email da pessoa e clique em associar." & vbCrLf
                'm.EnviarEmail(Session("USER_EMAIL").ToString, message)
                Response.Write("<script language='javascript'>window.alert('Incluido com Sucesso');window.location='Report.aspx'</script>")
            Else
                'Se não ele exibe mensagem e retorna para pagina de cadastro de report
                Response.Write("<script language='javascript'>window.alert('Erro ao incluir');window.location='Cadastro.aspx'</script>")
            End If
        End If
    End Sub

End Class