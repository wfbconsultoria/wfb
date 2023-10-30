
Partial Class Contatos_Ativos
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Medicos_Ativos.aspx"
    Dim gdvRow As GridViewRow

    Dim cnn As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SQL As String
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
        'CONTROLA OS ACESSO E FUNÇÕES CONFORME O PERFIL DE ACESSO
        SQL = ""
        SQL = "Select * From VIEW_USUARIOS_ATIVOS Where COD_PERFIL = '4' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "0" Then SQL = "Select * From VIEW_USUARIOS_ATIVOS Where COD_PERFIL = '4' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "1" Then SQL = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL_DIRETOR= '" & Session("EMAIL_LOGIN") & "' AND COD_PERFIL = '4'ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "2" Then SQL = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL_GERENTE= '" & Session("EMAIL_LOGIN") & "' AND COD_PERFIL = '4'ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "3" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "4" Then SQL = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL= '" & Session("EMAIL_LOGIN") & "' AND COD_PERFIL = '4' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "5" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "6" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "7" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        dts_Usuarios.SelectCommand = SQL

    End Sub
    Protected Sub cmd_Gravar_Click(sender As Object, e As System.EventArgs) Handles cmd_Gravar.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim Mensagem As String
        Dim SQL As String
        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()

        'VARIAVEIS DO LOOP
        Dim ATIVO As String
        Dim ID_CONTATO As String

        ATIVO = False
        ID_CONTATO = ""
        For Each gdvrow As GridViewRow In gdv_Localizar.Rows
            ATIVO = CType(gdvrow.Cells(3).FindControl("cmb_CONTATO_ATIVO"), DropDownList).SelectedValue()
            ID_CONTATO = gdvrow.Cells(0).Text


            SQL = "SELECT ID_CONTATO FROM TBL_CONTATOS WHERE ID_CONTATO = " & ID_CONTATO
            cmd.Connection = cnn
            cmd.CommandText = SQL
            dtr = cmd.ExecuteReader
            dtr.Read()
            If dtr.HasRows Then
                SQL = ""
                SQL = SQL & " UPDATE TBL_CONTATOS SET"
                SQL = SQL & " ATIVO = '" & ATIVO & "', "
                SQL = SQL & " ALTERACAO_EMAIL = '" & Session("EMAIL_LOGIN") & "', "
                SQL = SQL & " ALTERACAO_DATA = '" & M.RecuperaData & "' "
                SQL = SQL & " WHERE ID_CONTATO = " & ID_CONTATO
            End If
            dtr.Close()
            If M.ExecutarSQL(SQL) = False Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO - ATUALIZAR SETORIZACAO", "ID_CONTATO: " & ID_CONTATO)
                Mensagem = "ERRO  - ATUALIZAR MEDICO" & Chr(10)
                Mensagem = Mensagem & "ID_CONTATO " & ID_CONTATO & Chr(10)
                Mensagem = Mensagem & "ATIVO " & ATIVO & Chr(10)
                Mensagem = Mensagem & "SQL " & SQL & Chr(10)
                M.EnviarEmail("ERRO  - ATUALIZAR MEDICO", Mensagem, True, False, "", "")
                Alert("As atualizações não foram efeturadas, um e-mail foi enviado ao suporte do sistema paa correções", False, "")
                Exit Sub
            End If

        Next
        Alert("Atualizações efetuadas", False, "")
        dts_Localizar.DataBind()
        gdv_Localizar.DataBind()
    End Sub
    Protected Sub cmd_Excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Excel.Click
        'EXPORTA GRIG DE LOCALIZACAO PARA O EXCEL
        M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "EXPORTOU EXCEL", "")
        gdv_Localizar.Caption = "Contatos"
        gdv_Localizar.AllowPaging = "False"
        gdv_Localizar.DataBind()
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment;filename=CONTATOS.xls")
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