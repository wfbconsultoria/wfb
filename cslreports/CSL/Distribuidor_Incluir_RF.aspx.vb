
Partial Class Distribuidor_Incluir_RF
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Distribuidor_Incluir_RF.aspx"
    Dim Titulo As String = "Inclusão de Distribuidor - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean

    'Váriáveis da Página
    Dim sql As String
    Dim Mensagem As String
    Dim CNPJ As String
    Dim CNPJ_FORMATADO As String
    Dim TIPO_PESSOA As String
    Dim COD_TIPO_PESSOA As String
    Dim ESTABELECIMENTO As String
    Dim ESTABELECIMENTO_CNPJ As String
    Dim RAZAO_SOCIAL As String
    Dim NOME_FANTASIA As String
    Dim ENDERECO As String
    Dim LOGRADOURO As String
    Dim NUMERO As String
    Dim COMPLEMENTO As String
    Dim BAIRRO As String
    Dim CEP As String
    Dim COD_IBGE As String
    Dim CIDADE As String
    Dim UF As String
    Dim ESTADO As String
    Dim REGIAO As String
    Dim REGIAO_SAUDE As String
    Dim MICRO_REGIAO_SAUDE As String
    Dim COD_NATUREZA_JURIDICA As String
    Dim NATUREZA_JURIDICA_DESCRICAO As String
    Dim COD_ESFERA_ADMINISTRATIVA As String
    Dim ESFERA As String
    Dim GESTAO As String
    Dim COD_CNAE As String
    Dim CNAE_DESCRICAO As String
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

        'Verifica se a existe variável de sessão para CNPJ
        If Request.QueryString("CNPJ") = "" Then
            Session("CNPJ") = ""
            Alert("Nenhum distribuidor selecionado, você será redirecionado para sua lista de distribuidores!", True, "Distribuidores_Localizar.aspx")
        Else
            CNPJ = Request.QueryString("CNPJ")
        End If


        'variaveis de conexão e acesso ao banmco de dados
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader

        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnReceitaFederal").ConnectionString
        cnn.Open()

        'recupera o valor na tabela estabelecimentos na receita 
        sql = ""
        sql = "Select *  From VIEW_ESTABELECIMENTOS Where CNPJ = " & CNPJ
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            'preenche os campos da página
            If Not IsDBNull(dtr("CNPJ_FORMATADO")) Then txt_Documento.Text = dtr("CNPJ_FORMATADO")
            If Not IsDBNull(dtr("RAZAO_SOCIAL")) Then txt_Razao_Social.Text = dtr("RAZAO_SOCIAL")
            If Not IsDBNull(dtr("NOME_FANTASIA")) Then txt_Nome_Fantasia.Text = dtr("NOME_FANTASIA")
            If Not IsDBNull(dtr("LOGRADOURO")) Then txt_Logradouro.Text = dtr("LOGRADOURO")
            If Not IsDBNull(dtr("COMPLEMENTO")) Then txt_Complemento.Text = dtr("COMPLEMENTO")
            If Not IsDBNull(dtr("NUMERO")) Then txt_Numero.Text = dtr("NUMERO")
            If Not IsDBNull(dtr("BAIRRO")) Then txt_Bairro.Text = dtr("BAIRRO")
            If Not IsDBNull(dtr("CEP")) Then txt_CEP.Text = dtr("CEP")
            If Not IsDBNull(dtr("CIDADE")) Then txt_Cidade.Text = dtr("CIDADE")
            If Not IsDBNull(dtr("ESTADO")) Then txt_Estado.Text = dtr("ESTADO")
            If Not IsDBNull(dtr("COD_IBGE")) Then COD_IBGE = dtr("COD_IBGE")
            If Not IsDBNull(dtr("COD_ESFERA_ADMINISTRATIVA")) Then COD_ESFERA_ADMINISTRATIVA = dtr("COD_ESFERA_ADMINISTRATIVA")
            If Not IsDBNull(dtr("ESFERA")) Then txt_Esfera_Administrativa.Text = dtr("ESFERA")

            'carrega valores pesquisados nas variaveis
            If Not IsDBNull(dtr("CNPJ")) Then CNPJ = M.Converte_Valor(dtr("CNPJ"))
            If Not IsDBNull(dtr("CNPJ_FORMATADO")) Then CNPJ_FORMATADO = dtr("CNPJ_FORMATADO")
            If Not IsDBNull(dtr("TIPO_PESSOA")) Then TIPO_PESSOA = dtr("TIPO_PESSOA")
            If Not IsDBNull(dtr("COD_TIPO_PESSOA")) Then COD_TIPO_PESSOA = dtr("COD_TIPO_PESSOA")
            If Not IsDBNull(dtr("ESTABELECIMENTO")) Then ESTABELECIMENTO = dtr("ESTABELECIMENTO")
            If Not IsDBNull(dtr("ESTABELECIMENTO_CNPJ")) Then ESTABELECIMENTO_CNPJ = dtr("ESTABELECIMENTO_CNPJ")
            If Not IsDBNull(dtr("RAZAO_SOCIAL")) Then RAZAO_SOCIAL = dtr("RAZAO_SOCIAL")
            If Not IsDBNull(dtr("NOME_FANTASIA")) Then NOME_FANTASIA = dtr("NOME_FANTASIA")
            If Not IsDBNull(dtr("ENDERECO")) Then ENDERECO = M.ConverteTexto(dtr("ENDERECO"))
            If Not IsDBNull(dtr("LOGRADOURO")) Then LOGRADOURO = M.ConverteTexto(dtr("LOGRADOURO"))
            If Not IsDBNull(dtr("NUMERO")) Then NUMERO = dtr("NUMERO")
            If Not IsDBNull(dtr("COMPLEMENTO")) Then COMPLEMENTO = M.ConverteTexto(dtr("COMPLEMENTO"))
            If Not IsDBNull(dtr("BAIRRO")) Then BAIRRO = M.ConverteTexto(dtr("BAIRRO"))
            If Not IsDBNull(dtr("CEP")) Then CEP = dtr("CEP")
            If Not IsDBNull(dtr("COD_IBGE")) Then COD_IBGE = dtr("COD_IBGE")
            If Not IsDBNull(dtr("CIDADE")) Then CIDADE = M.ConverteTexto(dtr("CIDADE"))
            If Not IsDBNull(dtr("UF")) Then UF = dtr("UF")
            If Not IsDBNull(dtr("ESTADO")) Then ESTADO = dtr("ESTADO")
            If Not IsDBNull(dtr("REGIAO")) Then REGIAO = dtr("REGIAO")
            If Not IsDBNull(dtr("REGIAO_SAUDE")) Then REGIAO_SAUDE = M.ConverteTexto(dtr("REGIAO"))
            If Not IsDBNull(dtr("MICRO_REGIAO_SAUDE")) Then MICRO_REGIAO_SAUDE = M.ConverteTexto(dtr("MICRO_REGIAO_SAUDE"))
            If Not IsDBNull(dtr("COD_NATUREZA_JURIDICA")) Then COD_NATUREZA_JURIDICA = dtr("COD_NATUREZA_JURIDICA")
            If Not IsDBNull(dtr("NATUREZA_JURIDICA_DESCRICAO")) Then NATUREZA_JURIDICA_DESCRICAO = dtr("NATUREZA_JURIDICA_DESCRICAO")
            If Not IsDBNull(dtr("COD_ESFERA_ADMINISTRATIVA")) Then COD_ESFERA_ADMINISTRATIVA = dtr("COD_ESFERA_ADMINISTRATIVA")
            If Not IsDBNull(dtr("ESFERA")) Then ESFERA = dtr("ESFERA")
            If Not IsDBNull(dtr("GESTAO")) Then GESTAO = dtr("GESTAO")
            If Not IsDBNull(dtr("COD_CNAE")) Then COD_CNAE = dtr("COD_CNAE")
            If Not IsDBNull(dtr("CNAE_DESCRICAO")) Then CNAE_DESCRICAO = dtr("CNAE_DESCRICAO")
        Else
            Alert("Estabelecimento não encontrado!", True, "Distribuidores_Pesquisa_RF.aspx")
        End If
    End Sub
    Protected Sub cmd_Gravar_Click(sender As Object, e As EventArgs) Handles cmd_Gravar.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand

        If Request.QueryString("INCLUSO_CLIENTE") = False Then
            sql = ""
            sql = sql & " Insert Into TBL_ESTABELECIMENTOS "
            sql = sql & " (CNPJ, CNPJ_FORMATADO, TIPO_PESSOA, COD_TIPO_PESSOA, ESTABELECIMENTO, ESTABELECIMENTO_CNPJ,RAZAO_SOCIAL, NOME_FANTASIA, "
            sql = sql & " ENDERECO, LOGRADOURO, NUMERO, COMPLEMENTO, BAIRRO, CEP, COD_MUNICIPIO, CIDADE, UF, ESTADO, REGIAO, REGIAO_SAUDE, MICRO_REGIAO_SAUDE, "
            sql = sql & " COD_NATUREZA_JURIDICA, NATUREZA_JURIDICA_DESCRICAO, COD_ESFERA_ADMINISTRATIVA, ESFERA, GESTAO, COD_CNAE, CNAE_DESCRICAO, "
            sql = sql & " INCLUSAO_DATA, INCLUSAO_EMAIL)"
            sql = sql & " Values ("
            sql = sql & M.Converte_Valor(CNPJ) & ", "
            sql = sql & "'" & CNPJ_FORMATADO & "',"
            sql = sql & "'" & TIPO_PESSOA & "',"
            sql = sql & "'" & COD_TIPO_PESSOA & "',"
            sql = sql & "'" & ESTABELECIMENTO & "',"
            sql = sql & "'" & ESTABELECIMENTO_CNPJ & "',"
            sql = sql & "'" & RAZAO_SOCIAL & "',"
            sql = sql & "'" & NOME_FANTASIA & "',"
            sql = sql & "'" & ENDERECO & "',"
            sql = sql & "'" & LOGRADOURO & "',"
            sql = sql & "'" & NUMERO & "',"
            sql = sql & "'" & COMPLEMENTO & "',"
            sql = sql & "'" & BAIRRO & "',"
            sql = sql & "'" & CEP & "',"
            sql = sql & "'" & COD_IBGE & "',"
            sql = sql & "'" & CIDADE & "',"
            sql = sql & "'" & UF & "',"
            sql = sql & "'" & ESTADO & "',"
            sql = sql & "'" & REGIAO & "',"
            sql = sql & "'" & REGIAO_SAUDE & "',"
            sql = sql & "'" & MICRO_REGIAO_SAUDE & "',"
            sql = sql & "'" & COD_NATUREZA_JURIDICA & "',"
            sql = sql & "'" & NATUREZA_JURIDICA_DESCRICAO & "',"
            sql = sql & "'" & COD_ESFERA_ADMINISTRATIVA & "',"
            sql = sql & "'" & ESFERA & "',"
            sql = sql & "'" & GESTAO & "',"
            sql = sql & "'" & COD_CNAE & "',"
            sql = sql & "'" & CNAE_DESCRICAO & "',"
            sql = sql & "'" & M.RecuperaData & "', "
            sql = sql & "'" & Session("EMAIL_LOGIN") & "') "

            If M.ExecutarSQL(sql) = True Then
                sql = ""
                sql = sql & " Insert Into TBL_DISTRIBUIDORES "
                sql = sql & " (CNPJ, CNPJ_FORMATADO, TIPO_PESSOA, COD_TIPO_PESSOA, ESTABELECIMENTO, ESTABELECIMENTO_CNPJ,RAZAO_SOCIAL, NOME_FANTASIA, "
                sql = sql & " ENDERECO, LOGRADOURO, NUMERO, COMPLEMENTO, BAIRRO, CEP, COD_MUNICIPIO, CIDADE, UF, ESTADO, REGIAO, REGIAO_SAUDE, MICRO_REGIAO_SAUDE, "
                sql = sql & " COD_NATUREZA_JURIDICA, NATUREZA_JURIDICA_DESCRICAO, COD_ESFERA_ADMINISTRATIVA, ESFERA, GESTAO, COD_CNAE, CNAE_DESCRICAO, "
                sql = sql & " INCLUSAO_DATA, INCLUSAO_EMAIL)"
                sql = sql & " Values ("
                sql = sql & M.Converte_Valor(CNPJ) & ", "
                sql = sql & "'" & CNPJ_FORMATADO & "',"
                sql = sql & "'" & TIPO_PESSOA & "',"
                sql = sql & "'" & COD_TIPO_PESSOA & "',"
                sql = sql & "'" & ESTABELECIMENTO & "',"
                sql = sql & "'" & ESTABELECIMENTO_CNPJ & "',"
                sql = sql & "'" & RAZAO_SOCIAL & "',"
                sql = sql & "'" & NOME_FANTASIA & "',"
                sql = sql & "'" & ENDERECO & "',"
                sql = sql & "'" & LOGRADOURO & "',"
                sql = sql & "'" & NUMERO & "',"
                sql = sql & "'" & COMPLEMENTO & "',"
                sql = sql & "'" & BAIRRO & "',"
                sql = sql & "'" & CEP & "',"
                sql = sql & "'" & COD_IBGE & "',"
                sql = sql & "'" & CIDADE & "',"
                sql = sql & "'" & UF & "',"
                sql = sql & "'" & ESTADO & "',"
                sql = sql & "'" & REGIAO & "',"
                sql = sql & "'" & REGIAO_SAUDE & "',"
                sql = sql & "'" & MICRO_REGIAO_SAUDE & "',"
                sql = sql & "'" & COD_NATUREZA_JURIDICA & "',"
                sql = sql & "'" & NATUREZA_JURIDICA_DESCRICAO & "',"
                sql = sql & "'" & COD_ESFERA_ADMINISTRATIVA & "',"
                sql = sql & "'" & ESFERA & "',"
                sql = sql & "'" & GESTAO & "',"
                sql = sql & "'" & COD_CNAE & "',"
                sql = sql & "'" & CNAE_DESCRICAO & "',"
                sql = sql & "'" & M.RecuperaData & "', "
                sql = sql & "'" & Session("EMAIL_LOGIN") & "') "
                If M.ExecutarSQL(sql) = True Then
                    Alert("Distribuidor incluido com sucesso!\n\n Você será redirecionado para a página de edição de distribuidor.\n\n Preencha os campos adicionais solicitados para completar o cadastro do distribuidor", True, "Distribuidores_Editar.aspx?CNPJ=" & CNPJ)
                Else
                    M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO EM INCLUIR DISTRIBUIDOR", "CNPJ: " & Session("CNPJ"))
                    Mensagem = "ERRO  - INCLUSAO DE DISTRIBUIDOR" & Chr(10)
                    Mensagem = Mensagem & "CNPJ: " & CNPJ & Chr(10)
                    Mensagem = Mensagem & "SQL: " & sql & Chr(10)
                    M.EnviarEmail("ERRO  - NCLUSAO DE DISTRIBUIDOR", Mensagem, True, False, "", "")
                    Alert("Erro ao incluir distribuidor! O Erro foi enviado ao suporte e será analisado!", True, "Distribuidores_Pesquisa_RF.aspx")
                End If
            End If
        Else
            If Request.QueryString("INCLUSO_DISTRIBUIDOR") = False Then
                sql = ""
                sql = sql & " Insert Into TBL_DISTRIBUIDORES "
                sql = sql & " (CNPJ, CNPJ_FORMATADO, TIPO_PESSOA, COD_TIPO_PESSOA, ESTABELECIMENTO, ESTABELECIMENTO_CNPJ,RAZAO_SOCIAL, NOME_FANTASIA, "
                sql = sql & " ENDERECO, LOGRADOURO, NUMERO, COMPLEMENTO, BAIRRO, CEP, COD_MUNICIPIO, CIDADE, UF, ESTADO, REGIAO, REGIAO_SAUDE, MICRO_REGIAO_SAUDE, "
                sql = sql & " COD_NATUREZA_JURIDICA, NATUREZA_JURIDICA_DESCRICAO, COD_ESFERA_ADMINISTRATIVA, ESFERA, GESTAO, COD_CNAE, CNAE_DESCRICAO, "
                sql = sql & " INCLUSAO_DATA, INCLUSAO_EMAIL)"
                sql = sql & " Values ("
                sql = sql & M.Converte_Valor(CNPJ) & ", "
                sql = sql & "'" & CNPJ_FORMATADO & "',"
                sql = sql & "'" & TIPO_PESSOA & "',"
                sql = sql & "'" & COD_TIPO_PESSOA & "',"
                sql = sql & "'" & ESTABELECIMENTO & "',"
                sql = sql & "'" & ESTABELECIMENTO_CNPJ & "',"
                sql = sql & "'" & RAZAO_SOCIAL & "',"
                sql = sql & "'" & NOME_FANTASIA & "',"
                sql = sql & "'" & ENDERECO & "',"
                sql = sql & "'" & LOGRADOURO & "',"
                sql = sql & "'" & NUMERO & "',"
                sql = sql & "'" & COMPLEMENTO & "',"
                sql = sql & "'" & BAIRRO & "',"
                sql = sql & "'" & CEP & "',"
                sql = sql & "'" & COD_IBGE & "',"
                sql = sql & "'" & CIDADE & "',"
                sql = sql & "'" & UF & "',"
                sql = sql & "'" & ESTADO & "',"
                sql = sql & "'" & REGIAO & "',"
                sql = sql & "'" & REGIAO_SAUDE & "',"
                sql = sql & "'" & MICRO_REGIAO_SAUDE & "',"
                sql = sql & "'" & COD_NATUREZA_JURIDICA & "',"
                sql = sql & "'" & NATUREZA_JURIDICA_DESCRICAO & "',"
                sql = sql & "'" & COD_ESFERA_ADMINISTRATIVA & "',"
                sql = sql & "'" & ESFERA & "',"
                sql = sql & "'" & GESTAO & "',"
                sql = sql & "'" & COD_CNAE & "',"
                sql = sql & "'" & CNAE_DESCRICAO & "',"
                sql = sql & "'" & M.RecuperaData & "', "
                sql = sql & "'" & Session("EMAIL_LOGIN") & "') "
                If M.ExecutarSQL(sql) = True Then
                    Alert("Distribuidor incluido com sucesso!\n\n Você será redirecionado para a página de edição de distribuidor.\n\n Preencha os campos adicionais solicitados para completar o cadastro do distribuidor", True, "Distribuidores_Editar.aspx?CNPJ=" & CNPJ)
                Else
                    M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO EM INCLUIR DISTRIBUIDOR", "CNPJ: " & Session("CNPJ"))
                    Mensagem = "ERRO  - INCLUSAO DE DISTRIBUIDOR" & Chr(10)
                    Mensagem = Mensagem & "CNPJ: " & CNPJ & Chr(10)
                    Mensagem = Mensagem & "SQL: " & sql & Chr(10)
                    M.EnviarEmail("ERRO  - NCLUSAO DE DISTRIBUIDOR", Mensagem, True, False, "", "")
                    Alert("Erro ao incluir distribuidor! O Erro foi enviado ao suporte e será analisado!", False, "Distribuidores_Pesquisa_RF.aspx")
                End If
            Else
                Alert("Este distribuidor ja está cadastrado!\n\n Você será redirecionado para a página de edição de distribuidor.\n\n Preencha os campos adicionais solicitados para completar o cadastro do distribuidor", True, "Distribuidores_Editar.aspx?CNPJ=" & CNPJ)
            End If  
        End If
        cnn.Close()
    End Sub
    Protected Sub cmd_Cancelar_Click(sender As Object, e As EventArgs) Handles cmd_Cancelar.Click
        Response.Redirect("Distribuidores_Pesquisa_RF.aspx")
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