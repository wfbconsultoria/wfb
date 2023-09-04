
Partial Class ReportEdit
    Inherits System.Web.UI.Page
    Dim m As New clsMaster

    Private Sub ReportEdit_Load(sender As Object, e As EventArgs) Handles Me.Load
        'declaração de variaveis
        Dim sql As String
        Dim d As System.Data.SqlClient.SqlDataReader
        Dim nome As String = txt_nome.Text
        Dim descricao As String = txt_descricao.Text
        Dim link As String = txt_link.Text
        'recebe valor para update
        ltr_nome.Text = nome.ToString
        ltr_descricao.Text = descricao.ToString
        ltr_link.Text = link.ToString
        'comandos sql
        sql = ""
        sql = "select * from tb_pbi_Reports where id=" & Request.Params("ID")
        d = m.ExecuteSelect(sql)
        If d.HasRows = True Then
            d.Read()
            txt_id.Text = Request.Params("ID")
            txt_nome.Text = d("REPORT_NAME").ToString
            txt_descricao.Text = d("REPORT_DESCRIPTION").ToString
            txt_link.Text = d("REPORT_STRING").ToString
        Else
            Response.Write("<script language='javascript'>window.alert('Página em manutenção');window.location='Report.aspx'</script>")
        End If
    End Sub
    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        'declaração de variavél
        Dim sql As String = ""
        'comandos sql
        sql = sql & "update tb_pbi_Reports set REPORT_NAME='" & m.ConvertText(ltr_nome.Text, clsMaster.TextCaseOptions.TextCase) & "',"
        sql = sql & " REPORT_DESCRIPTION='" & m.ConvertText(ltr_descricao.Text, clsMaster.TextCaseOptions.TextCase) & "',"
        sql = sql & " REPORT_STRING='" & m.ConvertText(ltr_link.Text, clsMaster.TextCaseOptions.TextCase) & "'"
        sql = sql & " where id='" & Request.Params("ID") & "'"
        'msg.Text = sql
        If m.ExecuteSQL(sql) Then
            'Se for verdadeiro ele exibe a mensagem de sucesso e retorna para pagina inicial
            Response.Write("<script language='javascript'>window.alert('atualizado com sucesso');window.location='report.aspx'</script>")
        Else
            'Se não ele exibe mensagem e retorna para pagina de cadastro de report
            Response.Write("<script language='javascript'>window.alert('Erro ao Atualizar');window.location='cadastro.aspx'</script>")
        End If
    End Sub

    Private Sub btn_deletar_Click(sender As Object, e As EventArgs) Handles btn_deletar.Click
        'declaração de variaveis
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String = ""
        'seleciona os relatorios associados a alguém
        sql = "select * from tb_pbi_Reports_Users where Report_id= " & txt_id.Text
        dtr = m.ExecuteSelect(sql)
        'verificados se tem linhas
        If dtr.HasRows Then
            'le as linhas
            dtr.Read()
            'apaga relatorio associado a alguém
            sql = ""
            sql = "delete from tb_pbi_Reports_Users where Report_Id=" & txt_id.Text
            If m.ExecuteSQL(sql) = True Then
                'apaga o relatorio
                sql = ""
                sql = "delete from tb_pbi_Reports where ID= " & txt_id.Text
                If m.ExecuteSQL(sql) = True Then
                    'avisa que foi apagado com sucesso
                    Response.Write("<script language='javascript'>window.alert('Relatorio apagado com sucesso');window.location='report.aspx';</script>")
                Else
                    'avisa que deu problema ao apagar
                    Response.Write("<script language='javascript'>window.alert('Erro ao apagar relatorio');</script>")
                End If
            Else
                'avisa que deu problema ao apagar
                Response.Write("<script language='javascript'>window.alert('Erro ao apagar relatorio');</script>")
            End If
        Else
            sql = ""
            'apaga o relatorio
            sql = "delete from tb_pbi_Reports where ID= " & txt_id.Text
            If m.ExecuteSQL(sql) = True Then
                'avisa que foi apagado com sucesso
                Response.Write("<script language='javascript'>window.alert('Relatorio apagado com sucesso');window.location='report.aspx';</script>")
            Else
                'avisa que deu problema ao apagar
                Response.Write("<script language='javascript'>window.alert('Erro ao apagar relatorio');</script>")
            End If
        End If
    End Sub
End Class