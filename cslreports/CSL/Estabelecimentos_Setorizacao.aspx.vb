
Partial Class Estabelecimentos_Setorizacao
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Public jscript As String
    Dim Pagina As String = "Estabelecimentos_Setorizacao.aspx"
    Dim Titulo As String = "Setorização de Cliente - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean

    'Váriáveis da Página
    Dim gdvRow As GridViewRow
    Dim Mensagem As String
    Dim CNPJ As String

    Dim cnn As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String
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
            Alert("Seu perfil de usuário não permite acesso a esta página!", True, "Estabelecimentos_Ficha.aspx?CNPJ=" & Request.QueryString("CNPJ"))
        End If
        '____________________________________________________________________________________________________________________________________________

        'Código customizado da página

        'Verifica se a existe variável de sessão para CNPJ
        Session("CNPJ") = ""
        Session("CNPJ") = Request.QueryString("CNPJ")
        CNPJ = Request.QueryString("CNPJ")
        If Session("CNPJ").ToString = "" Then Response.Redirect("Estabelecimentos_Localizar.aspx")

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

        'Monta o combo de representante

        ' Verifica perfil e carrega o combo de usuarios
        sql = "Select '@' as EMAIL,  '# Selecione' AS NOME Union All "
        sql = sql & " Select EMAIL, NOME From VIEW_USUARIOS Where (COD_PERFIL = '4') And (ATIVO = 'True') "
        If Session("COD_PERFIL_LOGIN") = "0" Then sql = sql
        If Session("COD_PERFIL_LOGIN") = "1" Then sql = sql & " And (DIRETOR = '" & Session("EMAIL_LOGIN") & "')"
        If Session("COD_PERFIL_LOGIN") = "2" Then sql = sql & " And (GERENTE = '" & Session("EMAIL_LOGIN") & "')"
        If Session("COD_PERFIL_LOGIN") = "3" Then sql = sql & " And (EMAIL = '" & Session("EMAIL_LOGIN") & "')"
        If Session("COD_PERFIL_LOGIN") = "4" Then sql = sql & " And (EMAIL = '" & Session("EMAIL_LOGIN") & "')"
        
        sql = sql & " Order By NOME"
        dts_Representantes.SelectCommand = sql
    End Sub
    Protected Sub cmd_Setorizar_Click(sender As Object, e As EventArgs) Handles cmd_Setorizar.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim Mensagem As String

        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()

        If cmb_Representante.Text = "@" Then
            Alert("Selecione um representante para setorizar!", False, "")
        Else
            sql = "SELECT CNPJ FROM TBL_SETORIZACAO WHERE CNPJ = " & CNPJ & " AND EMAIL = '" & cmb_Representante.Text & "'"
            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader
            dtr.Read()
            If dtr.HasRows Then
                Alert("Este estabelecimento já está setorizado para esse representante!", False, "")
            Else
                'SETORIZA O ESTABELECIMENTO
                sql = ""
                sql = sql & " Insert Into TBL_SETORIZACAO "
                sql = sql & " (CNPJ, EMAIL, TARGET, INCLUSAO_DATA, INCLUSAO_EMAIL)"
                sql = sql & " Values ("
                sql = sql & Session("CNPJ") & ", "
                sql = sql & "'" & cmb_Representante.Text & "', "
                sql = sql & "'" & cmb_TARGET.Text & "', "
                sql = sql & "'" & M.RecuperaData & "', "
                sql = sql & "'" & Session("EMAIL_LOGIN") & "') "
                If M.ExecutarSQL(sql) = True Then
                    'LOG DE SETORIZAÇÃO DE ESTABELECIMENTO
                    sql = ""
                    sql = sql & " Insert Into TBL_SETORIZACAO_LOG "
                    sql = sql & " (CNPJ, EMAIL, TARGET, INCLUSAO_DATA, INCLUSAO_EMAIL)"
                    sql = sql & " Values ("
                    sql = sql & Session("CNPJ") & ", "
                    sql = sql & "'" & cmb_Representante.Text & "', "
                    sql = sql & "'" & cmb_TARGET.Text & "', "
                    sql = sql & "'" & M.RecuperaData & "', "
                    sql = sql & "'" & Session("EMAIL_LOGIN") & "') "
                    M.ExecutarSQL(sql)

                    Alert("Estabelecimento setorizado com sucesso!", False, "")
                    M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "SETORIZOU ESTABELECIMENTO", "CNPJ: " & Session("CNPJ") & " - PARA: " & cmb_Representante.Text)
                    gdv_Localizar.DataBind()
                Else
                    M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO EM SETORIZAR ESTABELECIMENTO", "CNPJ: " & Session("CNPJ") & " - PARA: " & cmb_Representante.Text)
                    Mensagem = "ERRO  - SETORIZACAO DE ESTABELECIMENTOS" & Chr(10)
                    Mensagem = Mensagem & "CNPJ: " & Session("CNPJ") & " - " & cmb_Representante.Text & Chr(10)
                    Mensagem = Mensagem & "Para: " & cmb_Representante.Text & Chr(10)
                    M.EnviarEmail("ERRO  - SETORIZACAO DE ESTABELECIMENTOS", Mensagem, True, False, "", "")
                    Alert("Erro ao Setorizar. Um Email foi enviado ao Administrador para ser avaliado.", False, "")
                End If
            End If
        End If
    End Sub
    Protected Sub cmd_Gravar_Click(sender As Object, e As EventArgs) Handles cmd_Gravar.Click
        Dim EMAIL As String
        Dim EXCLUIR As String
        Dim TARGET As String

        For Each gdvrow As GridViewRow In gdv_Localizar.Rows

            EMAIL = CType(gdvrow.Cells(0).FindControl("cmb_EMAIL_REPRESENTANTE"), DropDownList).SelectedValue()
            EXCLUIR = CType(gdvrow.Cells(3).FindControl("chk_Excluir"), CheckBox).Checked()
            TARGET = CType(gdvrow.Cells(1).FindControl("cmb_TARGET"), DropDownList).SelectedValue()

            If EXCLUIR = True Then
                sql = "DELETE FROM TBL_SETORIZACAO WHERE CNPJ = " & M.Converte_Valor(CNPJ) & " AND EMAIL = '" & EMAIL & "'"
                If M.ExecutarSQL(sql) = True Then
                    'LOG DE SETORIZAÇÃO DE ESTABELECIMENTO
                    sql = ""
                    sql = sql & " Insert Into TBL_SETORIZACAO_LOG "
                    sql = sql & " (CNPJ, EMAIL, TARGET, EXCLUSAO_DATA, EXCLUSAO_EMAIL)"
                    sql = sql & " Values ("
                    sql = sql & M.Converte_Valor(CNPJ) & ", "
                    sql = sql & "'" & EMAIL & "', "
                    sql = sql & "'" & TARGET & "', "
                    sql = sql & "'" & M.RecuperaData & "', "
                    sql = sql & "'" & Session("EMAIL_LOGIN") & "') "
                End If
            Else
                sql = ""
                sql = sql & " Update TBL_SETORIZACAO set "
                sql = sql & " TARGET = "
                sql = sql & "'" & TARGET & "' "
                sql = sql & " WHERE CNPJ = " & M.Converte_Valor(CNPJ) & " AND EMAIL = '" & EMAIL & "'"
                If M.ExecutarSQL(sql) = True Then
                    'LOG DE SETORIZAÇÃO DE ESTABELECIMENTO
                    sql = ""
                    sql = sql & " Insert Into TBL_SETORIZACAO_LOG "
                    sql = sql & " (CNPJ, EMAIL, TARGET, ALTERACAO_DATA, ALTERACAO_EMAIL)"
                    sql = sql & " Values ("
                    sql = sql & M.Converte_Valor(CNPJ) & ", "
                    sql = sql & "'" & EMAIL & "', "
                    sql = sql & "'" & TARGET & "', "
                    sql = sql & "'" & M.RecuperaData & "', "
                    sql = sql & "'" & Session("EMAIL_LOGIN") & "') "
                End If
            End If
        Next
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