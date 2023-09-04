
Imports System.Data.SqlClient

Partial Class AssociateReport
    Inherits System.Web.UI.Page
    Dim m As New clsMaster

    Private Sub AssociateReport_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        Dim dtr As SqlDataReader = m.ExecuteSelect("select * from tb_pbi_Reports where id=" & Request.Params("ID"))

        dtr.Read()
        Session("ID_R") = dtr("ID").ToString
        lbl_title.InnerText = dtr("REPORT_NAME").ToString()
        dtr.Close()

        'Resgatando dados para tabela
        dtr = m.ExecuteSelect("SELECT  tb_pbi_Reports_Users.USER_EMAIL, tb_pbi_Reports_Users.REPORT_ID, tb_Users.USER_NAME FROM tb_pbi_Reports_Users INNER JOIN tb_Users ON tb_Users.USER_EMAIL = tb_pbi_Reports_Users.USER_EMAIL WHERE tb_pbi_Reports_Users.REPORT_ID = '" & Request.Params("id").ToString & "'ORDER BY tb_pbi_Reports_Users.USER_EMAIL")

        Repeater1.DataSource = dtr
        Repeater1.DataBind()
    End Sub

    'Resgatando dados para select dos usuários associados
    Private Sub AssociateReport_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'Montando where para não trazer usuários já associados
        Dim dtr As SqlDataReader = m.ExecuteSelect("SELECT USER_EMAIL, REPORT_ID, ID From tb_pbi_Reports_Users Where REPORT_ID = '" & Request.Params("id").ToString & "'" & "ORDER BY USER_EMAIL ASC")
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

    Private Sub btn_associar_Click(sender As Object, e As EventArgs) Handles btn_associar.Click
        'declaração de variaveis
        Dim sql As String = ""
        Dim dtr As Data.SqlClient.SqlDataReader

        'comandos sql
        sql = "select * from tb_pbi_Reports_Users where USER_EMAIL='" & ddl_associado.SelectedValue & "' and REPORT_ID=" & Request.Params("ID")
        dtr = m.ExecuteSelect(sql)
        'verifica se tem linhas 
        If dtr.HasRows = True Then
            'le linhas
            dtr.Read()

            'verifica se tem o mesmo id do report no usuario do banco
            If Request.Params("ID") = dtr("REPORT_ID") Then
                'caso tenha manda mensagem avisando que já tem
                Response.Write("<script language='javascript'>window.alert('Report já está associado a esse usuário')</script>")
            End If
        Else
            'sql recebe comando para insert
            sql = ""
            sql = sql & "insert into tb_pbi_Reports_Users(REPORT_ID, USER_EMAIL)"
            sql = sql & "Values("
            sql = sql & "'" & Request.Params("ID") & "',"
            sql = sql & "'" & ddl_associado.SelectedValue & "')"
            'exucuta e verifica se é verdadeiro
            If m.ExecuteSQL(sql) = True Then
                'manda mensagem avisando  que foi associado com sucesso e redireciona para página default
                'Se for verdadeiro ele exibe a mensagem de sucesso e retorna para pagina inicial
                Dim message As String = " Você foi associado ao relatório " & m.ConvertText(lbl_title.InnerText, clsMaster.TextCaseOptions.TextCase) & vbCrLf
                message += "Para visualizá-lo entre na aba meus relatórios e busque pelo nome " & vbCrLf
                m.EnviarEmail(ddl_associado.SelectedValue, message)
                Response.Write("<script language='javascript'>window.alert('Report associado com sucesso');window.locate='AssociateReport.aspx';history.back();</script>")
            Else
                'Manda mensagem
                Response.Write("<script language='javascript'>window.alert('Erro ao associar Report');</script>")
            End If
        End If
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Response.Redirect("Report.aspx")
    End Sub

End Class
