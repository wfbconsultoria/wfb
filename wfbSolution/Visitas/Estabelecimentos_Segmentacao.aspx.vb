
Partial Class Estabelecimentos_Segmentacao
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Estabelecimentos_Segmentacao.aspx"
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
        SQL = "Select * From VIEW_USUARIOS_ATIVOS Where COD_PERFIL = '4'ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "0" Then SQL = "Select * From VIEW_USUARIOS_ATIVOS Where COD_PERFIL = '4' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "1" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "2" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "3" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "4" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "5" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "6" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "7" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        dts_Usuarios.SelectCommand = SQL

    End Sub
    Protected Sub gdv_Localizar_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gdv_Localizar.RowCommand
        Dim X As Integer = Convert.ToInt32(e.CommandArgument)
        Dim LINHA As GridViewRow = gdv_Localizar.Rows(X)
        Dim CONTROLE As New ListItem
        Dim ACAO As String

        ACAO = e.CommandName.ToString
        CONTROLE.Text = Server.HtmlDecode(LINHA.Cells(1).Text)
        Session("CNPJ") = CONTROLE.Text
        If ACAO = "FICHA" Then Navegar("Estabelecimentos_Ficha.aspx")

    End Sub

    Protected Sub Navegar(ByVal Pagina As String)
        Dim jscript As String
        jscript = ""
        jscript += "<script language='JavaScript'>"
        jscript += ";; document.location.href='" & Pagina & "'"
        jscript += "</script>"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Navegar", jscript)
    End Sub

    Protected Sub cmd_Gravar_Click(sender As Object, e As System.EventArgs) Handles cmd_Gravar.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim Mensagem As String
        Dim SQL As String
        
        'VARIAVEIS DO LOOP
        Dim CLASSE As String
        Dim CNPJ As String

        CLASSE = ""
        CNPJ = ""
        For Each gdvrow As GridViewRow In gdv_Localizar.Rows
            CLASSE = CType(gdvrow.Cells(3).FindControl("cmb_CLASSE"), DropDownList).SelectedValue()
            CNPJ = gdvrow.Cells(0).Text

            SQL = ""
            SQL = SQL & " UPDATE TBL_ESTABELECIMENTOS SET"
            SQL = SQL & " COD_CLASSE = '" & CLASSE & "' "
            SQL = SQL & " WHERE CNPJ= " & M.Converte_Valor(CNPJ)
            If M.ExecutarSQL(SQL) = False Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO - ATUALIZAR SEGMENTAÇÃO", "CNPJ: " & CNPJ)
                Mensagem = "ERRO  - ATUALIZAR SEGMENTAÇÃO" & Chr(10)
                Mensagem = Mensagem & "CNPJ " & CNPJ & Chr(10)
                M.EnviarEmail("ERRO  - ATUALIZAR SEGMENTAÇÃO", Mensagem, True, False, "", "")
                Alert("As atualizações não foram efeturadas, um e-mail foi enviado ao admiistrador do sistema paa correções", False, "")
                Exit Sub
            End If

        Next
        Alert("Atualizações efetuadas", False, "")
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
    Protected Sub cmd_Excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Excel.Click
        'EXPORTA GRIG DE LOCALIZACAO PARA O EXCEL
        M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "EXPORTOU EXCEL", "")
        gdv_Localizar.Caption = "Segmentação"
        gdv_Localizar.AllowPaging = "False"
        gdv_Localizar.DataBind()
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment;filename=SETORIZACAO.xls")
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
End Class