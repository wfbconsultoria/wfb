
Partial Class Estabelecimentos_Setorizacao_NS
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Public jscript As String
    Dim Pagina As String = "Estabelecimentos_Setorizacao_NS.aspx"
    Dim Titulo As String = "Setorização de Órfãos - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean

    'Váriáveis da Página
    Dim gdvRow As GridViewRow
    Dim Mensagem As String

    Dim cnn As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = False 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = False 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = False 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = False 'Cordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = False 'Representante
        If Session("COD_PERFIL_LOGIN") = 10 Then Acesso = False 'Key Account
        If Session("COD_PERFIL_LOGIN") = 20 Then Acesso = False 'Visitante
        If Session("COD_PERFIL_LOGIN") = 30 Then Acesso = False 'Distribuidor
        If Session("ADMINISTRADOR_SETORIZACAO") = True Then Acesso = True 'Administrador de Setorização


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
        'CONTROLA OS ACESSO E FUNÇÕES CONFORME O PERFIL DE ACESSO
        sql = ""
        sql = "Select * From VIEW_USUARIOS Where COD_PERFIL = '4' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "0" Then sql = "SELECT '@' AS EMAIL, '# Orfão' as NOME UNION ALL Select EMAIL, NOME From VIEW_USUARIOS Where COD_PERFIL = '4' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "1" Then sql = "SELECT '@' AS EMAIL, '# Orfão' as NOME UNION ALL Select EMAIL, NOME From VIEW_USUARIOS Where EMAIL_DIRETOR= '" & Session("EMAIL_LOGIN") & "' AND COD_PERFIL = '4' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "2" Then sql = "SELECT '@' AS EMAIL, '# Orfão' as NOME UNION ALL Select EMAIL, NOME From VIEW_USUARIOS Where EMAIL_GERENTE= '" & Session("EMAIL_LOGIN") & "' AND COD_PERFIL = '4' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "3" Then sql = "SELECT '@' AS EMAIL, '# Orfão' as NOME UNION ALL Select EMAIL, NOME From VIEW_USUARIOS Where EMAIL_COORDENADOR= '" & Session("EMAIL_LOGIN") & "' AND COD_PERFIL = '4'  ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "4" Then sql = "SELECT '@' AS EMAIL, '# Orfão' as NOME UNION ALL Select EMAIL, NOME From VIEW_USUARIOS Where EMAIL = '" & Session("EMAIL_LOGIN") & "' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "5" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "6" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        dts_Usuarios.SelectCommand = sql

    End Sub
    Protected Sub Atualiza_Relatório()

        sql = " Select * From VIEW_ESTABELECIMENTOS_001_DETALHADO_ORFAOS WHERE CNPJ <> 0 "

        'ESTADO
        If cmb_ESTADO.Text <> "@" Then sql = sql & "and UF = '" & cmb_ESTADO.Text & "' "

        'MUNICIPIO
        If cmb_MUNICIPIO.Text <> "@" Then sql = sql & "and MUNICIPIO = '" & cmb_MUNICIPIO.Text & "' "

        'ESFERA
        If cmb_ESFERA.Text <> "@" Then sql = sql & " and ESFERA = '" & cmb_ESFERA.Text & "' "

        sql = sql & "ORDER BY ESTABELECIMENTO"

        dts_Localizar.SelectCommand = sql
    End Sub
    Protected Sub cmb_ESTADO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_ESTADO.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub

    Protected Sub cmb_MUNICIPIO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_MUNICIPIO.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub

    Protected Sub cmb_ESFERA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_ESFERA.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub
    Protected Sub cmd_Gravar_Click(sender As Object, e As System.EventArgs) Handles cmd_Gravar.Click
        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()

        'VARIAVEIS DO LOOP
        Dim EMAIL As String
        Dim TARGET As String
        Dim CNPJ As String

        'limpa variaveis
        EMAIL = ""
        TARGET = ""
        CNPJ = ""

        For Each gdvrow As GridViewRow In gdv_Localizar.Rows
            EMAIL = CType(gdvrow.Cells(6).FindControl("cmb_EMAIL_REPRESENTANTE"), DropDownList).SelectedValue()
            TARGET = CType(gdvrow.Cells(5).FindControl("cmb_TARGET"), DropDownList).SelectedValue()
            CNPJ = gdvrow.Cells(0).Text

            If EMAIL <> "@" Then
                'SETORIZA O ESTABELECIMENTO
                sql = ""
                sql = sql & " Insert Into TBL_SETORIZACAO "
                sql = sql & " (CNPJ, EMAIL,TARGET, INCLUSAO_DATA, INCLUSAO_EMAIL)"
                sql = sql & " Values ("
                sql = sql & M.Converte_Valor(CNPJ) & ", "
                sql = sql & "'" & EMAIL & "', "
                sql = sql & "'" & TARGET & "', "
                sql = sql & "'" & M.RecuperaData & "', "
                sql = sql & "'" & Session("EMAIL_LOGIN") & "') "

                If M.ExecutarSQL(sql) = True Then
                    'LOG DE SETORIZAÇÃO DE ESTABELECIMENTO
                    sql = ""
                    sql = sql & " Insert Into TBL_SETORIZACAO_LOG "
                    sql = sql & " (CNPJ, EMAIL, TARGET, INCLUSAO_DATA, INCLUSAO_EMAIL)"
                    sql = sql & " Values ("
                    sql = sql & M.Converte_Valor(CNPJ) & ", "
                    sql = sql & "'" & EMAIL & "', "
                    sql = sql & "'" & TARGET & "', "
                    sql = sql & "'" & M.RecuperaData & "', "
                    sql = sql & "'" & Session("EMAIL_LOGIN") & "') "

                    M.ExecutarSQL(sql)
                End If
            End If
        Next
        dts_Localizar.DataBind()
        gdv_Localizar.DataBind()
        Alert("Atualizações efetuadas", False, "")
        Atualiza_Relatório()
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