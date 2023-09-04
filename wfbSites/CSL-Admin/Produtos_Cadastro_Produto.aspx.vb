
Partial Class Produtos_Cadastro_Produto
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Produtos_Cadastro_Produto.aspx"
    Dim Titulo As String = "Produtos - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
    Dim Sql As String
    Dim Mensagem As String

    Dim cnn As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
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
        If cmb_Divisao.Text = 0 Then
            Alert("Preencha todos os campos, todos são obrigatórios!", False, "")
            Exit Sub
        ElseIf cmb_Grupo.Text = 0 Then
            Alert("Preencha todos os campos, todos são obrigatórios!", False, "")
            Exit Sub
        ElseIf cmb_Linha.Text = 0 Then
            Alert("Preencha todos os campos, todos são obrigatórios!", False, "")
            Exit Sub
        ElseIf cmb_Embalagem_Venda.Text = 0 Then
            Alert("Preencha todos os campos, todos são obrigatórios!", False, "")
            Exit Sub
        ElseIf cmb_Unidade_Venda.Text = 0 Then
            Alert("Preencha todos os campos, todos são obrigatórios!", False, "")
            Exit Sub
        ElseIf cmb_Unidade_Equivalente.Text = 0 Then
            Alert("Preencha todos os campos, todos são obrigatórios!", False, "")
            Exit Sub
        ElseIf txt_Cod_Produto.Text = "" Then
            Alert("Preencha todos os campos, todos são obrigatórios!", False, "")
            Exit Sub
        ElseIf txt_Produto.Text = "" Then
            Alert("Preencha todos os campos, todos são obrigatórios!", False, "")
            Exit Sub
        ElseIf txt_Qtd_Unidades_Embalagem.Text = "" Then
            Alert("Preencha todos os campos, todos são obrigatórios!", False, "")
            Exit Sub
        ElseIf txt_Fator_Conversao_Unidade.Text = "" Then
            Alert("Preencha todos os campos, todos são obrigatórios!", False, "")
            Exit Sub
        ElseIf txt_Preco_Base_Unidade.Text = "" Then
            Alert("Preencha todos os campos, todos são obrigatórios!", False, "")
            Exit Sub
        End If

        'ABRE CONEXAO
        cnn.ConnectionString = M.cnnStr
        cnn.Open()
        cmd.Connection = cnn

        'RECUPERA REGISTRO
        Sql = ""
        Sql = "Select * From TBL_PRODUTOS Where COD_PRODUTO = '" & txt_Cod_Produto.Text & "'"

        cmd.CommandText = Sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            Alert("Já existe um produto com esse código!", False, "")
            Exit Sub
        Else
            Sql = ""
            Sql = "Insert Into TBL_PRODUTOS "
            Sql = Sql & "(COD_PRODUTO, PRODUTO, COD_PRODUTO_LINHA, COD_PRODUTO_GRUPO, COD_PRODUTO_DIVISAO, COD_PRODUTO_EMBALAGEM_VENDA, COD_PRODUTO_UNIDADE_VENDA, COD_PRODUTO_UNIDADE_EQUIVALENTE, QTD_UNIDADES_EMBALAGEM_VENDA, FATOR_CONVERSAO_UNIDADE_EQUIVALENTE, PRECO_BASE_UNIDADE_VENDA, OPERADOR, COTA_VENDA_UNIDADE, COTA_VENDA_VALOR, INCLUSAO_EMAIL, INCLUSAO_DATA) "
            Sql = Sql & "Values ("
            Sql = Sql & "'" & M.ConverteTexto(txt_Cod_Produto.Text) & "', "
            Sql = Sql & "'" & M.ConverteTexto(txt_Produto.Text) & "', "
            Sql = Sql & cmb_Linha.Text & ", "
            Sql = Sql & cmb_Grupo.Text & ", "
            Sql = Sql & cmb_Divisao.Text & ", "
            Sql = Sql & cmb_Embalagem_Venda.Text & ", "
            Sql = Sql & cmb_Unidade_Venda.Text & ", "
            Sql = Sql & cmb_Unidade_Equivalente.Text & ", "
            Sql = Sql & M.Converte_Valor(txt_Qtd_Unidades_Embalagem.Text) & ", "
            Sql = Sql & Replace(Replace(txt_Fator_Conversao_Unidade.Text, ".", ""), ",", ".") & ", "
            Sql = Sql & Replace(Replace(txt_Preco_Base_Unidade.Text, ".", ""), ",", ".") & ", "
            Sql = Sql & "'" & cmb_Operador.Text & "', "
            Sql = Sql & "'" & chk_Cota_Venda_Unidade.Checked & "', "
            Sql = Sql & "'" & chk_Cota_Venda_Valor.Checked & "', "
            Sql = Sql & "'" & Session("EMAIL_LOGIN") & "', "
            Sql = Sql & M.RecuperaData & ")"

            If M.ExecutarSQL(Sql) = True Then
                txt_Cod_Produto.Text = ""
                dts_Lista.DataBind()
                gdv_Lista.DataBind()
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "Inclui produto codigo", txt_Cod_Produto.Text)
                Alert("Produto incluido com sucesso!", False, "")

                'Limpa campos do formulario de inclusão
                cmb_Divisao.Text = 0
                cmb_Grupo.Text = 0
                cmb_Linha.Text = 0
                cmb_Embalagem_Venda.Text = 0
                cmb_Unidade_Venda.Text = 0
                cmb_Unidade_Equivalente.Text = 0
                txt_Cod_Produto.Text = ""
                txt_Produto.Text = ""
                txt_Qtd_Unidades_Embalagem.Text = ""
                txt_Fator_Conversao_Unidade.Text = ""
                txt_Preco_Base_Unidade.Text = ""
                chk_Cota_Venda_Unidade.Checked = False
                chk_Cota_Venda_Valor.Checked = False
            Else
                Mensagem = "ERRO - INCLUSAO DE PRODUTO - " & Pagina & " - " & Now() & Chr(10)
                Mensagem = Mensagem & "PRODUTO: " & txt_Cod_Produto.Text & Chr(10)
                Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN")
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO", txt_Cod_Produto.Text)
                M.EnviarEmail("ERRO - INCLUSAO DE PRODUTO", Mensagem, True, False, "", "")
                Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao suporte para verificação!", False, "")
            End If
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
        M.Inclui_Alteracao(gdv_Lista.SelectedValue, Session("EMAIL_LOGIN"), "COD_PRODUTO", "TBL_PRODUTOS")
    End Sub
    Protected Sub gdv_Lista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gdv_Lista.SelectedIndexChanged
        Dim QTD_REGISTROS As Double = 0
        QTD_REGISTROS = M.Consiste_Exclusao(gdv_Lista.SelectedValue, "COD_PRODUTO", "TBL_MOVIMENTO_VENDA")
        'QTD_REGISTROS = QTD_REGISTROS + M.Consiste_Exclusao(gdv_Lista.SelectedValue, "COD_PRODUTO", "TBL_MOVIMENTO_VENDA")
        If QTD_REGISTROS > 0 Then
            Alert("Este produto não pode ser excluido pois existem " & QTD_REGISTROS & " produtos relacionados", False, "")
        Else
            If M.ExecutarSQL("Delete From TBL_PRODUTOS Where COD_PRODUTO = '" & gdv_Lista.SelectedValue & "'") = True Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "Excluiu Produto COD", gdv_Lista.SelectedValue)
                Alert("Produto excluida com sucesso ", False, "")
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