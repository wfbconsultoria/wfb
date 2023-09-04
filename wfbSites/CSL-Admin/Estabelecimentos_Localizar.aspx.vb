Imports System.Drawing
Imports System.IO

Partial Class Estabelecimentos_Localizar
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Estabelecimentos_Localizar.aspx"
    Dim Titulo As String = "Clientes - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean

    'Váriáveis da Página
    Dim SQL_LOCALIZAR As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = True 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = True 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = True 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = True 'Cordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = True 'Representante
        If Session("COD_PERFIL_LOGIN") = 10 Then Acesso = True 'Key Account
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

        'SELECIONA OS ESTABELECIMENTOS CONFORME O PERFIL E USUARIO LOGADO NO SISTEMA
        SQL_LOCALIZAR = ""
        SQL_LOCALIZAR = "SELECT VIEW_ESTABELECIMENTOS_001_DETALHADO.CNPJ, VIEW_ESTABELECIMENTOS_001_DETALHADO.CNPJ_FORMATADO, VIEW_ESTABELECIMENTOS_001_DETALHADO.CNES, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.COD_INTERNO, VIEW_ESTABELECIMENTOS_001_DETALHADO.ID_GRUPO_ESTABELECIMENTO, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.GRUPO_ESTABELECIMENTO, VIEW_ESTABELECIMENTOS_001_DETALHADO.ESTABELECIMENTO, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.ESTABELECIMENTO_CNPJ, VIEW_ESTABELECIMENTOS_001_DETALHADO.RAZAO_SOCIAL, VIEW_ESTABELECIMENTOS_001_DETALHADO.NOME_FANTASIA, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.ENDERECO, VIEW_ESTABELECIMENTOS_001_DETALHADO.LOGRADOURO, VIEW_ESTABELECIMENTOS_001_DETALHADO.NUMERO, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.COMPLEMENTO, VIEW_ESTABELECIMENTOS_001_DETALHADO.BAIRRO, VIEW_ESTABELECIMENTOS_001_DETALHADO.CEP, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.COD_MUNICIPIO, VIEW_ESTABELECIMENTOS_001_DETALHADO.MUNICIPIO, VIEW_ESTABELECIMENTOS_001_DETALHADO.UF, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.ESTADO, VIEW_ESTABELECIMENTOS_001_DETALHADO.REGIAO, VIEW_ESTABELECIMENTOS_001_DETALHADO.MICRO_REGIAO_SAUDE, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.REGIAO_SAUDE, VIEW_ESTABELECIMENTOS_001_DETALHADO.COD_TIPO_PESSOA, VIEW_ESTABELECIMENTOS_001_DETALHADO.TIPO_PESSOA, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.COD_ESFERA_ADMINISTRATIVA, VIEW_ESTABELECIMENTOS_001_DETALHADO.ESFERA, VIEW_ESTABELECIMENTOS_001_DETALHADO.GESTAO, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.COD_NATUREZA_JURIDICA, VIEW_ESTABELECIMENTOS_001_DETALHADO.NATUREZA_JURIDICA_DESCRICAO, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.COD_CNAE, VIEW_ESTABELECIMENTOS_001_DETALHADO.CNAE_DESCRICAO, VIEW_ESTABELECIMENTOS_001_DETALHADO.DATA_FUNDACAO, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.DATA_SITUACAORFB, VIEW_ESTABELECIMENTOS_001_DETALHADO.SITUACAORFB, VIEW_ESTABELECIMENTOS_001_DETALHADO.SETORIZADO, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.QTD_SETORIZACOES, VIEW_ESTABELECIMENTOS_001_DETALHADO.SETORIZADO_VALOR, VIEW_ESTABELECIMENTOS_001_DETALHADO.INCLUSAO, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.ALTERACAO, VIEW_ESTABELECIMENTOS_001_DETALHADO.EXCLUSAO, VIEW_ESTABELECIMENTOS_001_DETALHADO.INCLUSAO_DATA, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.INCLUSAO_EMAIL, VIEW_ESTABELECIMENTOS_001_DETALHADO.ALTERACAO_DATA, VIEW_ESTABELECIMENTOS_001_DETALHADO.ALTERACAO_EMAIL, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.EXCLUSAO_DATA, VIEW_ESTABELECIMENTOS_001_DETALHADO.EXCLUSAO_EMAIL, VIEW_ESTABELECIMENTOS_001_DETALHADO.ATUALIZACAO_RECEITA_DATA,"
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.ATUALIZACAO_RECEITA_EMAIL, VIEW_ESTABELECIMENTOS_001_DETALHADO.ATUALIZACAO_RECEITA_CHECK, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_ESTABELECIMENTOS_001_DETALHADO.ULTIMA_ATUALIZACAO_RECEITA, VIEW_ESTABELECIMENTOS_001_DETALHADO.APELIDO, VIEW_USUARIOS.EMAIL_DIRETOR, VIEW_USUARIOS.DIRETOR, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_USUARIOS.EMAIL_GERENTE, VIEW_USUARIOS.GERENTE, VIEW_USUARIOS.EMAIL_COORDENADOR, VIEW_USUARIOS.COORDENADOR, VIEW_USUARIOS.EMAIL AS EMAIL_REPRESENTANTE, "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "VIEW_USUARIOS.NOME AS REPRESENTANTE FROM TBL_SETORIZACAO LEFT OUTER JOIN VIEW_USUARIOS ON TBL_SETORIZACAO.EMAIL = VIEW_USUARIOS.EMAIL "
        SQL_LOCALIZAR = SQL_LOCALIZAR & "RIGHT OUTER JOIN VIEW_ESTABELECIMENTOS_001_DETALHADO ON TBL_SETORIZACAO.CNPJ = VIEW_ESTABELECIMENTOS_001_DETALHADO.CNPJ "


        If Session("COD_PERFIL_LOGIN") = 0 Then SQL_LOCALIZAR = SQL_LOCALIZAR
        If Session("COD_PERFIL_LOGIN") = 1 Then SQL_LOCALIZAR = SQL_LOCALIZAR & " WHERE VIEW_USUARIOS.EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "' "
        If Session("COD_PERFIL_LOGIN") = 2 Then SQL_LOCALIZAR = SQL_LOCALIZAR & " WHERE VIEW_USUARIOS.EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' "
        If Session("COD_PERFIL_LOGIN") = 3 Then SQL_LOCALIZAR = SQL_LOCALIZAR & " WHERE VIEW_USUARIOS.EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "' "
        If Session("COD_PERFIL_LOGIN") = 4 Then SQL_LOCALIZAR = SQL_LOCALIZAR & " WHERE VIEW_USUARIOS.EMAIL = '" & Session("EMAIL_LOGIN") & "' "
        If Session("COD_PERFIL_LOGIN") = 10 Then SQL_LOCALIZAR = SQL_LOCALIZAR & " WHERE VIEW_ESTABELECIMENTOS_001_DETALHADO.EMAIL_GERENTE_CONTA = '" & Session("EMAIL_LOGIN") & "' "

        SQL_LOCALIZAR = SQL_LOCALIZAR & "ORDER BY VIEW_ESTABELECIMENTOS_001_DETALHADO.ESTABELECIMENTO"

        'LIMITANDO QUANTIDADE DE REGISTROS NA TABELA
        If Request.Params("de") Is Nothing Or Request.Params("ate") Is Nothing Then
            Response.Redirect("Estabelecimentos_Localizar.aspx?de=0&ate=10")
        Else
            cmb_Quantidade.SelectedValue = Request.Params("ate").ToString
            SQL_LOCALIZAR = SQL_LOCALIZAR & " OFFSET " & Request.Params("de").ToString & " ROWS FETCH NEXT " & Request.Params("ate").ToString & " ROWS ONLY "
        End If

        'Atribuindo query no dts da tabela
        dts_Localizar.SelectCommand = SQL_LOCALIZAR

        'CONTANDO O TOTAL DE REGISTROS
        Dim total As Int64 = 0
        Dim SQL_CONTADOR As String = ""
        Dim dtr As System.Data.SqlClient.SqlDataReader

        SQL_CONTADOR = "SELECT COUNT(VIEW_ESTABELECIMENTOS_001_DETALHADO.CNPJ) FROM TBL_SETORIZACAO LEFT OUTER Join VIEW_USUARIOS On TBL_SETORIZACAO.EMAIL = VIEW_USUARIOS.EMAIL "
        SQL_CONTADOR = SQL_CONTADOR & "RIGHT OUTER Join VIEW_ESTABELECIMENTOS_001_DETALHADO On TBL_SETORIZACAO.CNPJ = VIEW_ESTABELECIMENTOS_001_DETALHADO.CNPJ "
        If Session("COD_PERFIL_LOGIN") = 0 Then SQL_CONTADOR = SQL_CONTADOR
        If Session("COD_PERFIL_LOGIN") = 1 Then SQL_CONTADOR = SQL_CONTADOR & " WHERE VIEW_USUARIOS.EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "' "
        If Session("COD_PERFIL_LOGIN") = 2 Then SQL_CONTADOR = SQL_CONTADOR & " WHERE VIEW_USUARIOS.EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' "
        If Session("COD_PERFIL_LOGIN") = 3 Then SQL_CONTADOR = SQL_CONTADOR & " WHERE VIEW_USUARIOS.EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "' "
        If Session("COD_PERFIL_LOGIN") = 4 Then SQL_CONTADOR = SQL_CONTADOR & " WHERE VIEW_USUARIOS.EMAIL = '" & Session("EMAIL_LOGIN") & "' "
        If Session("COD_PERFIL_LOGIN") = 10 Then SQL_CONTADOR = SQL_CONTADOR & " WHERE VIEW_ESTABELECIMENTOS_001_DETALHADO.EMAIL_GERENTE_CONTA = '" & Session("EMAIL_LOGIN") & "' "

        dtr = M.ExecutarSelect(SQL_CONTADOR)
        If dtr.HasRows Then
            dtr.Read()
            total = Int64.Parse(dtr(0).ToString)
        Else
            'Erro ao resgatar número de páginas
            Response.Write(<script>alert('Erro ao montar paginação dos registros, contate o administrador.')</script>)
            Exit Sub
        End If

        'Condições para bloquear botões de navegação-------------------------------------
        If Request.Params("de").ToString <= 0 Then ' Desabilitando botão de voltar caso a base for zero
            btn_Anterior.Disabled = True
        End If

        'Verificando se pode passar para a página seguinte
        If total < (Int64.Parse(Request.Params("de").ToString) + Int64.Parse(Request.Params("ate").ToString)) Then
            btn_Proximo.Disabled = True
        End If

    End Sub
    'Funções Padrão para todas as páginas
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

    'Passar para os próximos registros
    Private Sub btn_Proximo_Click(sender As Object, e As EventArgs) Handles btn_Proximo.ServerClick
        'Enviando query para tabela
        Dim de As Int64 = Int64.Parse(Request.Params("de").ToString) + cmb_Quantidade.SelectedValue
        Response.Redirect("Estabelecimentos_Localizar.aspx?de=" & de & "&ate=" & Request.Params("ate").ToString)
    End Sub
    'Votar aos registros anteriores
    Private Sub btn_Anterior_ServerClick(sender As Object, e As EventArgs) Handles btn_Anterior.ServerClick
        'Enviando query para tabela
        Dim de As Int64 = (Int64.Parse(Request.Params("de").ToString) - cmb_Quantidade.SelectedValue)

        'Verificando se o retorno é menor que 0
        If de < 0 Then
            de = (Int64.Parse(Request.Params("de").ToString) - 10)
        End If

        Response.Redirect("Estabelecimentos_Localizar.aspx?de=" & de & "&ate=" & Request.Params("ate").ToString)
    End Sub

    Private Sub cmd_Excel_Click(sender As Object, e As EventArgs) Handles cmd_Excel.Click
        'Instancia um novo grid
        Dim dg As New DataGrid
        dg.AutoGenerateColumns = True
        'base e ligação com os dados
        dg.DataSource = dts_Exportar
        dg.DataBind()
        'Estilizações do datagrid
        dg.HeaderStyle.HorizontalAlign = HorizontalAlign.Center
        dg.HeaderStyle.ForeColor = Color.Black
        dg.HeaderStyle.Height = 30%
        dg.CellPadding = 100%
        dg.Width = 100%
        dg.ItemStyle.HorizontalAlign = HorizontalAlign.Justify
        dg.BorderStyle = BorderStyle.Solid
        'limpar a tela e configurar o xls
        Response.Clear()
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment;filename=" & M.ConverteTexto(Titulo & " " & Session("USUARIO_LOGIN").ToString) & "_" & M.RecuperaData & ".xls")
        dg.EnableViewState = False
        'configurações para retornar grid como excel
        Dim tw As New StringWriter()
        Dim hw As New HtmlTextWriter(tw)
        dg.RenderControl(hw)
        Response.Write(M.ConverteTexto(tw.ToString()))
        Response.End()

    End Sub
End Class