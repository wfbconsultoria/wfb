
Partial Class Produtos_Cadastro_Grupo
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Produtos_Cadastro_Grupo.aspx"
    Dim Titulo As String = "Grupos de Produto - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
    Dim Sql As String
    Dim Mensagem As String
    'Váriáveis da Página

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = True 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = False 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = False 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = False 'Cordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = False 'Representante
        If Session("COD_PERFIL_LOGIN") = 10 Then Acesso = False 'Key Account
        If Session("COD_PERFIL_LOGIN") = 20 Then Acesso = False 'Visitante
        If Session("COD_PERFIL_LOGIN") = 30 Then Acesso = False 'Distribuidor

        'Verifica se o perfil do usuário tem acesso a página
        If Acesso = True Then
            'Grava log de permissão de acesso
            If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSO PERMITIDO", "")
                Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
                Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
            End If
        Else
            'Grava log de recusa de acesso
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSO RECUSADO", "")
            Alert("Seu perfil de usuário não permite acesso a esta página!", True, "Default.aspx")
        End If
        '____________________________________________________________________________________________________________________________________________

        'Código customizado da página

    End Sub
    Protected Sub cmd_Gravar_Click(sender As Object, e As EventArgs) Handles cmd_Gravar.Click
        If Len(txt_Grupo.Text) = 0 Then
            Alert("Digite a grupo de produto antes de gravar!", False, "")
            Exit Sub
        End If
        Sql = ""
        Sql = "Insert Into TBL_PRODUTOS_GRUPOS (PRODUTO_GRUPO, INCLUSAO_EMAIL, INCLUSAO_DATA) Values "
        Sql = Sql & "('" & M.ConverteTexto(txt_Grupo.Text) & "', "
        Sql = Sql & "'" & Session("EMAIL_LOGIN") & "', "
        Sql = Sql & M.RecuperaData & ")"

        If M.ExecutarSQL(Sql) = True Then
            txt_Grupo.Text = ""
            dts_Lista.DataBind()
            gdv_Lista.DataBind()
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "Inclui divisão de produto", txt_Grupo.Text)
            Alert("Grupo de Produto incluida com sucesso!", False, "")
        Else
            Mensagem = "ERRO - INCLUSAO GRUPO DE PRODUTO - " & Pagina & " - " & Now() & Chr(10)
            Mensagem = Mensagem & "GRUPO DE PRODUTO: " & txt_Grupo.Text & Chr(10)
            Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN")
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO", txt_Grupo.Text)
            M.EnviarEmail("ERRO - INCLUSAO GRUPO DE PRODUTO", Mensagem, True, False, "", "")

            Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao suporte para verificação!", False, "")
        End If
    End Sub
    Protected Sub cmd_Excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Excel.Click
        'EXPORTA GRIG DE LOCALIZACAO PARA O EXCEL

        M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "EXPORTOU EXCEL", "")
        gdv_Lista.Caption = M.ConverteTexto(Titulo & " " & Session("USUARIO_LOGIN").ToString)
        gdv_Lista.AllowPaging = "False"
        gdv_Lista.DataBind()
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment;filename=" & M.ConverteTexto(Titulo & " " & Session("USUARIO_LOGIN").ToString) & "_" & M.RecuperaData & ".xls")
        Response.Charset = ""
        EnableViewState = False
        Controls.Add(frm)
        frm.Controls.Add(gdv_Lista)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        gdv_Lista.AllowPaging = "True"
        gdv_Lista.DataBind()
    End Sub
    Protected Sub gdv_Lista_RowUpdated(sender As Object, e As GridViewUpdatedEventArgs) Handles gdv_Lista.RowUpdated
        M.Inclui_Alteracao(gdv_Lista.SelectedValue, Session("EMAIL_LOGIN"), "COD_PRODUTO_GRUPO", "TBL_PRODUTOS_GRUPOS")
    End Sub
    Protected Sub gdv_Lista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gdv_Lista.SelectedIndexChanged
        Dim QTD_REGISTROS As Double = 0
        QTD_REGISTROS = M.Consiste_Exclusao(gdv_Lista.SelectedValue, "COD_PRODUTO_GRUPO", "TBL_PRODUTOS")
        If QTD_REGISTROS > 0 Then
            Alert("Este grupo não pode ser excluido pois existem " & QTD_REGISTROS & " produtos relacionados", False, "")
        Else
            If M.ExecutarSQL("Delete From TBL_PRODUTOS_GRUPOS Where COD_PRODUTO_GRUPO = " & gdv_Lista.SelectedValue) = True Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "Excluiu Grupo de produto COD", gdv_Lista.SelectedValue)
                Alert("Grupo excluido com sucesso ", False, "")
                dts_Lista.DataBind()
                gdv_Lista.DataBind()
            End If
        End If
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