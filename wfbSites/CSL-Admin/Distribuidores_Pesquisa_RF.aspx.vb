
Partial Class Distribuidores_Pesquisa_RF
    Inherits System.Web.UI.Page

    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Distribuidores_Pesquisa_RF.aspx"
    Dim Modulo As String = "Distribuidor"
    Dim Titulo As String = "Pesquisar Distribuidor - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
    'Váriáveis da Página
    Public jscript As String
    Dim SQL As String
    Dim Mensagem As String
    Dim DOCUMENTO As String
    Dim INCLUSO_CLIENTE As Boolean
    Dim INCLUSO_RECEITA As Boolean
    Dim INCLUSO_DISTRIBUIDOR As Boolean
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
        txt_DOCUMENTO.Attributes.Add("OnKeyPress", "Digitar_Numeros(this);Mascara_Entrada(this,'00000000000000');")

    End Sub
    Protected Sub cmd_Consultar_Click(sender As Object, e As System.EventArgs) Handles cmd_Consultar.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader

        INCLUSO_CLIENTE = False
        INCLUSO_RECEITA = False
        INCLUSO_DISTRIBUIDOR = False
        DOCUMENTO = M.ConverteTexto(txt_DOCUMENTO.Text)

        'valida CNPJ pu CPF antes de pesquisar
        'permite somente números
        If Len(txt_DOCUMENTO.Text) = 0 Then
            Alert("DIGITE O NUMERO DO DOCUMENTO", False, "")
            Exit Sub
        End If
        If Not IsNumeric(txt_DOCUMENTO.Text) Then
            Alert("DIGITE SOMENTE NÚMEROS", False, "")
            Exit Sub
        End If
        'verifica tamnho do CNPJ
        If Len(txt_DOCUMENTO.Text) < 7 Or Len(txt_DOCUMENTO.Text) > 14 Then
            Alert("CNPJ DEVE CONTER  ENTRE 7 E 14 NÚMEROS ", False, "")
            Exit Sub
        End If

        'verifica se o cnpj está cadastrado no banco de dados do cliente
        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()

        'VERIFICA SE O CNPJ JÁ ESTÁ CADASTRADO NO BANCO DO DISTRIBUIDOR
        SQL = ""
        SQL = "Select *  From VIEW_DISTRIBUIDORES_001_DETALHADO Where CNPJ = " & DOCUMENTO & " AND COD_TIPO_PESSOA = '1'"
        cmd.Connection = cnn
        cmd.CommandText = SQL
        dtr = cmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            INCLUSO_DISTRIBUIDOR = True
        End If
        dtr.Close()

        'VERIFICA SE O CNPJ JÁ ESTÁ CADASTRADO NO BANCO DO CLIENTE
        SQL = ""
        SQL = "Select *  From VIEW_ESTABELECIMENTOS_001_DETALHADO Where CNPJ = " & DOCUMENTO & " AND COD_TIPO_PESSOA = '1'"
        cmd.Connection = cnn
        cmd.CommandText = SQL
        dtr = cmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            INCLUSO_CLIENTE = True
            If INCLUSO_DISTRIBUIDOR = True Then
                Response.Redirect("Distribuidor_Incluir_RF.aspx?CNPJ=" & DOCUMENTO & "&INCLUSO_CLIENTE=True&INCLUSO_DISTRIBUIDOR=True")
            Else
                Response.Redirect("Distribuidor_Incluir_RF.aspx?CNPJ=" & DOCUMENTO & "&INCLUSO_CLIENTE=True&INCLUSO_DISTRIBUIDOR=False")
            End If
        End If
            dtr.Close()
            cnn.Close()

            'VERIFICA SE O CNPJ JÁ ESTÁ CADASTRADO NO BANCO WFB
            If INCLUSO_CLIENTE = False Then
                'ABRE CONEXAO COM BANCO DE DADOS
                cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnReceitaFederal").ConnectionString
                cnn.Open()
                SQL = ""
                SQL = "Select *  From VIEW_ESTABELECIMENTOS Where CNPJ = " & DOCUMENTO & " AND COD_TIPO_PESSOA = '1'"
                cmd.Connection = cnn
                cmd.CommandText = SQL
                dtr = cmd.ExecuteReader
                If dtr.HasRows Then
                    dtr.Read()
                Response.Redirect("Distribuidor_Incluir_RF.aspx?CNPJ=" & DOCUMENTO & "&INCLUSO_CLIENTE=False&INCLUSO_DISTRIBUIDOR=False")
                End If
            End If
            dtr.Close()
            cnn.Close()
            'PESQUISA NA RECEITA FEDERAL E INCLUI NOS DOIS BANCO DE DADOS RECEITA E CLieNTE
            If INCLUSO_RECEITA = False And INCLUSO_CLIENTE = False Then
            Response.Redirect(ConfigurationManager.AppSettings("SITE_PESQUISA") & "/Pesquisa_RF.aspx?URL_SITE=" & Session("URL_SITE") & "&MODULO=" & Modulo & "&PAGINA=" & Pagina & "&CNPJ=" & txt_DOCUMENTO.Text)
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