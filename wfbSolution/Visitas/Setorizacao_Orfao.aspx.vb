
Partial Class Setorizacao_Orfao
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Setorizacao"
    Dim gdvRow As GridViewRow

    Dim cnn As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim SQL As String
        Dim SQL_REPRESENTANTE As String
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
        'CONTROLA OS ACESSO E FUNÇÕES CONFORME O PERFIL DE ACESSO
        SQL = ""
        SQL = "Select * From VIEW_USUARIOS_ATIVOS Where COD_PERFIL = '4' AND ORFAO = 'True' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "0" Then SQL = "Select * From VIEW_USUARIOS_ATIVOS Where COD_PERFIL = '4' AND ORFAO = 'True' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "1" Then SQL = "Select * From VIEW_USUARIOS_ATIVOS Where COD_PERFIL = '4' AND EMAIL_DIRETOR= '" & Session("EMAIL_LOGIN") & "' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "2" Then SQL = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL_GERENTE= '" & Session("EMAIL_LOGIN") & "' AND ORFAO = 'True' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "3" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "4" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "5" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "6" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "7" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("EMAIL_LOGIN") = "camila@wfbconsultoria.com.br" Then SQL = "Select * From VIEW_USUARIOS_ATIVOS Where COD_PERFIL = '4' ORDER BY NOME"

        dts_Usuarios.SelectCommand = SQL

        SQL_REPRESENTANTE = ""
        SQL_REPRESENTANTE = "Select * From VIEW_USUARIOS_ATIVOS Where COD_PERFIL = '4' ORDER BY NOME"
        If Session("EMAIL_LOGIN") = "camila@wfbconsultoria.com.br" Then SQL_REPRESENTANTE = "Select * From VIEW_USUARIOS_ATIVOS Where COD_PERFIL = '4' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "2" Then SQL_REPRESENTANTE = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL_GERENTE= '" & Session("EMAIL_LOGIN") & "' AND COD_PERFIL = '4' ORDER BY NOME"
        dts_Usuarios_Representante.SelectCommand = SQL_REPRESENTANTE

        SQL = ""
        SQL = SQL & " INSERT INTO TBL_SETORIZACAO (EMAIL,CNPJ,[TARGET])"
        SQL = SQL & " SELECT 'ORFAO',  CNPJ, 'NÃO' "
        SQL = SQL & " FROM VIEW_ESTABELECIMENTOS"
        SQL = SQL & " WHERE EMAIL_REPRESENTANTE IS NULL"
        If M.ExecutarSQL(SQL) = False Then
            Alert("Erro ao atualizar tabela de setorização", False, "")
            Exit Sub
        End If
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

    Protected Sub cmd_Gravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Gravar.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim Mensagem As String
        Dim SQL As String
        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()

        'VARIAVEIS DO LOOP
        Dim EMAIL As String
        Dim TARGET As String
        Dim CNPJ As String

        EMAIL = ""
        TARGET = ""
        CNPJ = ""

        For Each gdvrow As GridViewRow In gdv_Localizar.Rows
            EMAIL = CType(gdvrow.Cells(4).FindControl("cmb_EMAIL_REPRESENTANTE"), DropDownList).SelectedValue()
            TARGET = CType(gdvrow.Cells(3).FindControl("cmb_TARGET"), DropDownList).SelectedValue()
            CNPJ = gdvrow.Cells(0).Text

            SQL = "SELECT CNPJ FROM TBL_SETORIZACAO WHERE CNPJ = " & CNPJ
            cmd.Connection = cnn
            cmd.CommandText = SQL
            dtr = cmd.ExecuteReader
            dtr.Read()

            If dtr.HasRows Then
                SQL = ""
                SQL = SQL & " UPDATE TBL_SETORIZACAO SET"
                SQL = SQL & " EMAIL = '" & EMAIL & "', "
                SQL = SQL & " TARGET = '" & TARGET & "', "
                SQL = SQL & " INCLUSAO_DATA = " & M.RecuperaData & ", "
                SQL = SQL & " INCLUSAO_EMAIL = '" & Session("EMAIL_LOGIN") & "', "
                SQL = SQL & " ALTERACAO_DATA = NULL, "
                SQL = SQL & " ALTERACAO_EMAIL = 'NULL', "
                SQL = SQL & " EXCLUSAO_DATA = NULL, "
                SQL = SQL & " EXCLUSAO_EMAIL = 'NULL'"
                SQL = SQL & " WHERE CNPJ= " & M.Converte_Valor(CNPJ)
            Else
                SQL = ""
                SQL = SQL & " INSERT INTO TBL_SETORIZACAO (EMAIL, CNPJ, TARGET, INCLUSAO_DATA, INCLUSAO_EMAIL) VALUES ("
                SQL = SQL & "'" & EMAIL & "', "
                SQL = SQL & CNPJ & ", "
                SQL = SQL & "'" & TARGET & "', "
                SQL = SQL & M.RecuperaData & ", "
                SQL = SQL & "'" & Session("EMAIL_LOGIN") & "') "
            End If
            dtr.Close()
            If M.ExecutarSQL(SQL) = False Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO - ATUALIZAR SETORIZACAO", "CNPJ: " & CNPJ & " EMAIL: " & EMAIL)
                Mensagem = "ERRO  - ATUALIZAR SETORIZACAO" & Chr(10)
                Mensagem = Mensagem & "CNPJ " & CNPJ & Chr(10)
                Mensagem = Mensagem & "EMAIL " & EMAIL & Chr(10)
                M.EnviarEmail("ERRO  - ATUALIZAR SETORIZACAO", Mensagem, True, False, "", "")
                Alert("As atualizações não foram efeturadas, um e-mail foi enviado ao admiistrador do sistema paa correções", False, "")
                Exit Sub
            End If

        Next
        Alert("Atualizações efetuadas", False, "")
    End Sub

    Protected Sub Navegar(ByVal Pagina As String)
        Dim jscript As String
        jscript = ""
        jscript += "<script language='JavaScript'>"
        jscript += ";; document.location.href='" & Pagina & "'"
        jscript += "</script>"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Navegar", jscript)
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