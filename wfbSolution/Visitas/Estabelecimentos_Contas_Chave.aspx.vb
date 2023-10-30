
Partial Class Estabelecimentos_Contas_Chave
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Estabelecimentos_Contas_Chave.aspx"
    Dim gdvRow As GridViewRow

    Dim cnn As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'If Session("COD_PERFIL_LOGIN") = "0" Then
        If Session("COD_PERFIL_LOGIN") = "1" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "2" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "3" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "4" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "5" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "6" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "7" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
    End Sub
    Protected Sub cmd_Gravar_Click(sender As Object, e As System.EventArgs) Handles cmd_Gravar.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim Mensagem As String
        Dim SQL As String
        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()

        'VARIAVEIS DO LOOP
        Dim CONTAS_CHAVE As Boolean
        Dim CNPJ As String

        CONTAS_CHAVE = False
        CNPJ = ""
        For Each gdvrow As GridViewRow In gdv_Localizar.Rows
            CONTAS_CHAVE = CType(gdvrow.Cells(3).FindControl("chk_CONTAS_CHAVE"), CheckBox).Checked
            CNPJ = gdvrow.Cells(0).Text


            SQL = "SELECT CNPJ FROM TBL_ESTABELECIMENTOS WHERE CNPJ = " & CNPJ
            cmd.Connection = cnn
            cmd.CommandText = SQL
            dtr = cmd.ExecuteReader
            dtr.Read()
            If dtr.HasRows Then
                SQL = ""
                SQL = SQL & " UPDATE TBL_ESTABELECIMENTOS SET"
                SQL = SQL & " CONTAS_CHAVE = '" & CONTAS_CHAVE & "' "
                SQL = SQL & " WHERE CNPJ= " & M.Converte_Valor(CNPJ)
            End If
            dtr.Close()
            If M.ExecutarSQL(SQL) = False Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO - ATUALIZAR SETORIZACAO", "CNPJ: " & CNPJ & " CONTAS CHAVE: " & CONTAS_CHAVE)
                Mensagem = "ERRO  - ATUALIZAR CONTAS CHAVE" & Chr(10)
                Mensagem = Mensagem & "CNPJ " & CNPJ & Chr(10)
                Mensagem = Mensagem & "CONTAS_CHAVE " & CONTAS_CHAVE & Chr(10)
                Mensagem = Mensagem & "SQL " & SQL & Chr(10)
                M.EnviarEmail("ERRO  - ATUALIZAR CONTAS_CHAVE", Mensagem, True, False, "", "")
                Alert("As atualizações não foram efeturadas, um e-mail foi enviado ao suporte do sistema paa correções", False, "")
                Exit Sub
            End If

        Next
        Alert("Atualizações efetuadas", False, "")
    End Sub
    Protected Sub cmd_Excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Excel.Click
        'EXPORTA GRIG DE LOCALIZACAO PARA O EXCEL
        M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "EXPORTOU EXCEL", "")
        gdv_Localizar.Caption = "Contas Chave"
        gdv_Localizar.AllowPaging = "False"
        gdv_Localizar.DataBind()
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment;filename=CONTAS_CHAVE.xls")
        Response.Charset = ""
        EnableViewState = False
        Controls.Add(frm)
        frm.Controls.Add(gdv_Localizar)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        gdv_Localizar.AllowPaging = "True"
        gdv_Localizar.DataBind()
    End Sub
    Protected Function Alert(ByVal Texto_Mensagem As String, ByVal Redirecionar As Boolean, ByVal Pagina As String) As Boolean
        Dim jscript As String
        'caixa de mensagem
        If Redirecionar = True Then
            jscript = ""
            jscript += "<script language='JavaScript'>"
            jscript += ";alert('" & Texto_Mensagem & "'); document.location.href='" & Pagina & "'"
            jscript += "</script>"
        Else
            jscript = ""
            jscript += "<script language='JavaScript'>"
            jscript += ";alert('" & Texto_Mensagem & "');"
            jscript += "</script>"
        End If
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Mensagem", jscript)
        Alert = True
    End Function
End Class
