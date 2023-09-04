
Partial Class Estabelecimento_Incluir_PF_RF
    Inherits System.Web.UI.Page
    Public jscript As String
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Estabelecimento_Incluir_PF_RF.aspx"
    Dim Titulo As String = "Pesquisa Receita Federal - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
    Dim Mensagem As String
    Dim sql As String

    'Váriáveis da Página
    Dim DOCUMENTO As String
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
    Dim EMAIL_GERENTE_CONTA As String
    Dim EMAIL_REPRESENTANTE_VENDA As String


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
            Alert("Seu perfil de usuário não permite acesso a esta página!", True, "Estabelecimentos_Ficha.aspx?CNPJ=" & Request.QueryString("CNPJ"))
        End If
        '____________________________________________________________________________________________________________________________________________

        'Código customizado da página

        DOCUMENTO = Request.QueryString("CPF")

        'Bloqueia alteração no caso do CPF ja estiver cadastrado
        If Request.QueryString("INCLUSO_CLIENTE") = True Then
            txt_CEP.Enabled = False
            txt_Complemento.Enabled = False
            cmd_Pesquisar.Visible = False
            txt_Numero.Enabled = False
        End If

        sql = "Select '@' as EMAIL,  '# Não setorizar este estabelecimento' AS NOME Union All "
        sql = sql & " Select EMAIL, NOME From TBL_USUARIOS Where (COD_PERFIL = '4') And (ATIVO = 'True') "
        If Session("COD_PERFIL_LOGIN") = "0" Then sql = sql
        If Session("COD_PERFIL_LOGIN") = "1" Then sql = sql
        If Session("COD_PERFIL_LOGIN") = "2" Then sql = sql & " And (GERENTE = '" & Session("EMAIL_LOGIN") & "')"
        If Session("COD_PERFIL_LOGIN") = "3" Then sql = sql & " And (COORDENADOR = '" & Session("EMAIL_LOGIN") & "')"
        If Session("COD_PERFIL_LOGIN") = "4" Then sql = sql & " And (EMAIL = '" & Session("EMAIL_LOGIN") & "')"

        sql = sql & " Order By NOME"
        dts_USUARIOS.SelectCommand = sql

        'recupera valores da querystring pesquisaCEP
        If Request.QueryString("CEP") <> "" Then
            txt_CEP.Text = Request.QueryString("CEP")
            txt_Logradouro.Text = Request.QueryString("TIPO_LOGRADOURO") & " " & Request.QueryString("LOGRADOURO")
            txt_Bairro.Text = Request.QueryString("BAIRRO")
            COD_IBGE = Request.QueryString("COD_IBGE")
            txt_Cidade.Text = Request.QueryString("CIDADE")
            UF = Request.QueryString("UF")
            txt_Estado.Text = Request.QueryString("ESTADO")
        End If

        'verifica se ouve a pesquisa de cep, se não, bloqueia campo numero e complemento
        If Request.QueryString("CEP") = "" Then
            txt_Numero.Enabled = False
            txt_Complemento.Enabled = False
        End If

        If Request.QueryString("INCLUSO_CLIENTE") = False Then
            Dim cnn As New System.Data.SqlClient.SqlConnection
            Dim cmd As New System.Data.SqlClient.SqlCommand
            Dim dtr As System.Data.SqlClient.SqlDataReader

            'ABRE CONEXAO COM BANCO DE DADOS
            cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnReceitaFederal").ConnectionString
            cnn.Open()

            'recupera o valor na tabela estabelecimentos
            sql = ""
            sql = "Select *  From VIEW_ESTABELECIMENTOS Where CNPJ = " & DOCUMENTO & " AND COD_TIPO_PESSOA = 2"
            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader
            If dtr.HasRows Then

                dtr.Read()
                'preenche os campos da página com os dados do Banco Estabelecimentos
                If Not IsDBNull(dtr("CNPJ_FORMATADO")) Then txt_Documento.Text = dtr("CNPJ_FORMATADO")
                If Not IsDBNull(dtr("RAZAO_SOCIAL")) Then txt_Nome.Text = dtr("RAZAO_SOCIAL")
                If Not IsDBNull(dtr("LOGRADOURO")) Then txt_Logradouro.Text = dtr("LOGRADOURO")
                If Not IsDBNull(dtr("COMPLEMENTO")) Then txt_Complemento.Text = dtr("COMPLEMENTO")
                If Not IsDBNull(dtr("NUMERO")) Then txt_Numero.Text = dtr("NUMERO")
                If Not IsDBNull(dtr("BAIRRO")) Then txt_Bairro.Text = dtr("BAIRRO")
                If Not IsDBNull(dtr("CIDADE")) Then txt_Cidade.Text = dtr("CIDADE")
                If Not IsDBNull(dtr("ESTADO")) Then txt_Estado.Text = dtr("ESTADO")
                If Not IsDBNull(dtr("COD_IBGE")) Then COD_IBGE = dtr("COD_IBGE")
                If Not IsDBNull(dtr("ESFERA")) Then txt_Esfera.Text = dtr("ESFERA")

                'carrega valores pesquisados no banco da receita nas variaveis
                If Not IsDBNull(dtr("CNPJ")) Then DOCUMENTO = M.Converte_Valor(dtr("CNPJ"))
                If Not IsDBNull(dtr("CNPJ_FORMATADO")) Then CNPJ_FORMATADO = dtr("CNPJ_FORMATADO")
                If Not IsDBNull(dtr("TIPO_PESSOA")) Then TIPO_PESSOA = dtr("TIPO_PESSOA")
                If Not IsDBNull(dtr("COD_TIPO_PESSOA")) Then COD_TIPO_PESSOA = dtr("COD_TIPO_PESSOA")
                If Not IsDBNull(dtr("ESTABELECIMENTO")) Then ESTABELECIMENTO = dtr("ESTABELECIMENTO")
                If Not IsDBNull(dtr("ESTABELECIMENTO_CNPJ")) Then ESTABELECIMENTO_CNPJ = dtr("ESTABELECIMENTO_CNPJ")
                If Not IsDBNull(dtr("RAZAO_SOCIAL")) Then RAZAO_SOCIAL = dtr("RAZAO_SOCIAL")
                If Not IsDBNull(dtr("NOME_FANTASIA")) Then NOME_FANTASIA = dtr("NOME_FANTASIA")
                If Not IsDBNull(dtr("REGIAO")) Then REGIAO = dtr("REGIAO")
                If Not IsDBNull(dtr("REGIAO_SAUDE")) Then REGIAO_SAUDE = M.ConverteTexto(dtr("REGIAO_SAUDE"))
                If Not IsDBNull(dtr("MICRO_REGIAO_SAUDE")) Then MICRO_REGIAO_SAUDE = M.ConverteTexto(dtr("MICRO_REGIAO_SAUDE"))
                If Not IsDBNull(dtr("COD_NATUREZA_JURIDICA")) Then COD_NATUREZA_JURIDICA = dtr("COD_NATUREZA_JURIDICA")
                If Not IsDBNull(dtr("NATUREZA_JURIDICA_DESCRICAO")) Then NATUREZA_JURIDICA_DESCRICAO = dtr("NATUREZA_JURIDICA_DESCRICAO")
                If Not IsDBNull(dtr("COD_ESFERA_ADMINISTRATIVA")) Then COD_ESFERA_ADMINISTRATIVA = dtr("COD_ESFERA_ADMINISTRATIVA")
                If Not IsDBNull(dtr("ESFERA")) Then ESFERA = dtr("ESFERA")
                If Not IsDBNull(dtr("GESTAO")) Then GESTAO = dtr("GESTAO")
                If Not IsDBNull(dtr("COD_CNAE")) Then COD_CNAE = dtr("COD_CNAE")
                If Not IsDBNull(dtr("CNAE_DESCRICAO")) Then CNAE_DESCRICAO = dtr("CNAE_DESCRICAO")
                If Not IsDBNull(dtr("UF")) Then UF = dtr("UF")
                EMAIL_GERENTE_CONTA = "orfao@vago"
                EMAIL_REPRESENTANTE_VENDA = "orfao@vago"
            Else
                Alert("Cliente não encontrado!", True, "Estabelecimentos_Pesquisa_RF.aspx")
            End If
            cnn.Close()
            dtr.Close()
        Else
            Dim cnn As New System.Data.SqlClient.SqlConnection
            Dim cmd As New System.Data.SqlClient.SqlCommand
            Dim dtr As System.Data.SqlClient.SqlDataReader

            'ABRE CONEXAO COM BANCO DE DADOS
            cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
            cnn.Open()

            'recupera o valor na tabela estabelecimentos
            sql = ""
            sql = "Select *  From VIEW_ESTABELECIMENTOS_001_DETALHADO Where CNPJ = " & DOCUMENTO & " AND COD_TIPO_PESSOA = 2"
            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader
            If dtr.HasRows Then

                dtr.Read()
                'preenche os campos da página com os dados da tabela estabelecimentos do cliente
                If Not IsDBNull(dtr("CNPJ_FORMATADO")) Then txt_Documento.Text = dtr("CNPJ_FORMATADO")
                If Not IsDBNull(dtr("RAZAO_SOCIAL")) Then txt_Nome.Text = dtr("RAZAO_SOCIAL")
                If Not IsDBNull(dtr("LOGRADOURO")) Then txt_Logradouro.Text = dtr("LOGRADOURO")
                If Not IsDBNull(dtr("COMPLEMENTO")) Then txt_Complemento.Text = dtr("COMPLEMENTO")
                If Not IsDBNull(dtr("NUMERO")) Then txt_Numero.Text = dtr("NUMERO")
                If Not IsDBNull(dtr("BAIRRO")) Then txt_Bairro.Text = dtr("BAIRRO")
                If Not IsDBNull(dtr("MUNICIPIO")) Then txt_Cidade.Text = dtr("MUNICIPIO")
                If Not IsDBNull(dtr("ESTADO")) Then txt_Estado.Text = dtr("ESTADO")
                If Not IsDBNull(dtr("ESFERA")) Then txt_Esfera.Text = dtr("ESFERA")
            Else
                Alert("Cliente não encontrado!", True, "Estabelecimentos_Pesquisa_RF.aspx")
            End If
            cnn.Close()
            dtr.Close()
        End If
    End Sub
    Protected Sub cmd_Pesquisar_Click(sender As Object, e As EventArgs) Handles cmd_Pesquisar.Click
        If txt_CEP.Text = "" Then
            Alert("Digite um CEP antes de Pesquisar!", False, "")
        Else
            Response.Redirect(ConfigurationManager.AppSettings("SITE_PESQUISA") & "/Pesquisa_CEP.aspx?URL_SITE=" & Session("URL_SITE") & "&PAGINA=" & Pagina & "&CPF=" & DOCUMENTO & "&CEP=" & txt_CEP.Text & "&INCLUSO_CLIENTE=" & Request.QueryString("INCLUSO_CLIENTE"))
        End If
    End Sub
    Protected Sub btn_Gravar_Click(sender As Object, e As EventArgs) Handles cmd_Gravar.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        'verifica o codigo tipo natureza juridica
        If COD_NATUREZA_JURIDICA = 2 Then
            COD_NATUREZA_JURIDICA = 1000
        End If
        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()

        'carrega valores retornados da pesquisa de CEP
        LOGRADOURO = txt_Logradouro.Text
        BAIRRO = txt_Bairro.Text
        CIDADE = txt_Cidade.Text
        ESTADO = txt_Estado.Text
        ENDERECO = Replace(txt_Logradouro.Text & " " & txt_Numero.Text, "'", "")

        'carrega valores EDITAVEIS NA PÁGINA
        NUMERO = txt_Numero.Text
        COMPLEMENTO = txt_Complemento.Text
        CEP = txt_CEP.Text

        sql = ""
        sql = sql & " Insert Into TBL_ESTABELECIMENTOS "
        sql = sql & " (CNPJ, CNPJ_FORMATADO, TIPO_PESSOA, COD_TIPO_PESSOA, ESTABELECIMENTO, ESTABELECIMENTO_CNPJ,RAZAO_SOCIAL, NOME_FANTASIA, "
        sql = sql & " ENDERECO, LOGRADOURO, NUMERO, COMPLEMENTO, BAIRRO, CEP, COD_MUNICIPIO, CIDADE, UF, ESTADO, REGIAO, REGIAO_SAUDE, MICRO_REGIAO_SAUDE, "
        sql = sql & " COD_NATUREZA_JURIDICA, NATUREZA_JURIDICA_DESCRICAO, COD_ESFERA_ADMINISTRATIVA, ESFERA, GESTAO, COD_CNAE, CNAE_DESCRICAO, "
        sql = sql & " INCLUSAO_DATA, INCLUSAO_EMAIL,EMAIL_GERENTE_CONTA,EMAIL_REPRESENTANTE_VENDA)"
        sql = sql & " Values ("
        sql = sql & M.Converte_Valor(DOCUMENTO) & ", "
        sql = sql & "'" & CNPJ_FORMATADO & "',"
        sql = sql & "'" & TIPO_PESSOA & "',"
        sql = sql & "'" & COD_TIPO_PESSOA & "',"
        sql = sql & "'" & ESTABELECIMENTO & "',"
        sql = sql & "'" & ESTABELECIMENTO_CNPJ & "',"
        sql = sql & "'" & RAZAO_SOCIAL & "',"
        sql = sql & "'" & NOME_FANTASIA & "',"
        sql = sql & "'" & ENDERECO & "',"
        sql = sql & "'" & LOGRADOURO & "',"
        sql = sql & "'" & Replace(NUMERO, "'", "") & "',"
        sql = sql & "'" & Replace(COMPLEMENTO, "'", "") & "',"
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
        sql = sql & "'" & Session("EMAIL_LOGIN") & "', "
        sql = sql & "'" & EMAIL_GERENTE_CONTA & "', "
        sql = sql & "'" & EMAIL_REPRESENTANTE_VENDA & "') "

        If Request.QueryString("INCLUSO_CLIENTE") = False Then
            If M.ExecutarSQL(sql) = True Then
                If (cmb_USUARIOS.Text = "@") Then
                    Alert("Cliente incluido com Sucesso", True, "Estabelecimentos_Pesquisa_RF.aspx")
                    Exit Sub
                Else
                    'VERIFICA SE JA ESTA SETORIZADO
                    sql = ""
                    sql = "Select *  From TBL_SETORIZACAO Where CNPJ = " & M.Converte_Valor(DOCUMENTO)
                    cmd.Connection = cnn
                    cmd.CommandText = sql
                    dtr = cmd.ExecuteReader
                    If dtr.HasRows Then
                        Alert("Este cliente já está setorizado!", False, "")
                    Else
                        'SETORIZA O ESTABELECIMENTO
                        sql = ""
                        sql = sql & " Insert Into TBL_SETORIZACAO "
                        sql = sql & " (CNPJ, EMAIL,TARGET, INCLUSAO_DATA, INCLUSAO_EMAIL)"
                        sql = sql & " Values ("
                        sql = sql & M.Converte_Valor(DOCUMENTO) & ", "
                        sql = sql & "'" & cmb_USUARIOS.Text & "', "
                        sql = sql & "'" & cmb_TARGET.Text & "', "
                        sql = sql & "'" & M.RecuperaData & "', "
                        sql = sql & "'" & Session("EMAIL_LOGIN") & "') "

                        If M.ExecutarSQL(sql) = True Then

                            'LOG DE SETORIZAÇÃO DE ESTABELECIMENTO
                            sql = ""
                            sql = sql & " Insert Into TBL_SETORIZACAO_LOG "
                            sql = sql & " (CNPJ, EMAIL, TARGET, INCLUSAO_DATA, INCLUSAO_EMAIL)"
                            sql = sql & " Values ("
                            sql = sql & M.Converte_Valor(DOCUMENTO) & ", "
                            sql = sql & "'" & cmb_USUARIOS.Text & "', "
                            sql = sql & "'" & cmb_TARGET.Text & "', "
                            sql = sql & "'" & M.RecuperaData & "', "
                            sql = sql & "'" & Session("EMAIL_LOGIN") & "') "
                            M.ExecutarSQL(sql)

                            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "SETORIZOU ESTABELECIMENTO", "CNPJ: " & Session("CNPJ") & " - " & " PARA: " & cmb_USUARIOS.Text)
                            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "SETORIZOU ESTABELECIMENTO", "CNPJ: " & DOCUMENTO)
                            Alert("Cliente incluido e setorizado com  sucesso!", True, "Estabelecimentos_Pesquisa_RF.aspx")
                        Else
                            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO EM SETORIZAR ESTABELECIMENTO", "CNPJ: " & Session("CNPJ") & " PARA: " & cmb_USUARIOS.Text)
                            Mensagem = "ERRO  - SETORIZACAO DE ESTABELECIMENTOS" & Chr(10)
                            Mensagem = Mensagem & "CNPJ: " & Session("CNPJ") & Chr(10)
                            Mensagem = Mensagem & "Para: " & cmb_USUARIOS.Text & Chr(10)
                            M.EnviarEmail("ERRO  - SETORIZACAO DE ESTABELECIMENTOS", Mensagem, True, False, "", "")
                            Alert("Cliente, mas não setorizado! O Erro foi enviado ao suporte e será analisado!", True, "Estabelecimentos_Pesquisa_RF.aspx")
                        End If
                        Exit Sub
                    End If
                    dtr.Close()
                End If

            End If
            Response.Write("<script>alert('Não foi possível incluir');history.back();</script>")
        Else
            If (cmb_USUARIOS.Text = "@") Then
                Alert("Este cliente já está cadastrado no sistema, peça a um administrador de setorização que faça a setorização deste cliente.", False, "")
                Exit Sub
            Else
                'VERIFICA SE JA ESTA SETORIZADO
                sql = ""
                sql = "Select *  From TBL_SETORIZACAO Where EMAIL = '" & cmb_USUARIOS.Text & "' And CNPJ = " & M.Converte_Valor(DOCUMENTO)
                cmd.Connection = cnn
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                If dtr.HasRows Then
                    Alert("Este estabelecimento já está setorizado!", False, "")
                Else
                    'SETORIZA O ESTABELECIMENTO
                    sql = ""
                    sql = sql & " Insert Into TBL_SETORIZACAO "
                    sql = sql & " (CNPJ, EMAIL,TARGET, INCLUSAO_DATA, INCLUSAO_EMAIL)"
                    sql = sql & " Values ("
                    sql = sql & M.Converte_Valor(DOCUMENTO) & ", "
                    sql = sql & "'" & cmb_USUARIOS.Text & "', "
                    sql = sql & "'" & cmb_TARGET.Text & "', "
                    sql = sql & "'" & M.RecuperaData & "', "
                    sql = sql & "'" & Session("EMAIL_LOGIN") & "') "
                    If M.ExecutarSQL(sql) = True Then

                        'LOG DE SETORIZAÇÃO DE ESTABELECIMENTO
                        sql = ""
                        sql = sql & " Insert Into TBL_SETORIZACAO_LOG "
                        sql = sql & " (CNPJ, EMAIL, TARGET, INCLUSAO_DATA, INCLUSAO_EMAIL)"
                        sql = sql & " Values ("
                        sql = sql & M.Converte_Valor(DOCUMENTO) & ", "
                        sql = sql & "'" & cmb_USUARIOS.Text & "', "
                        sql = sql & "'" & cmb_TARGET.Text & "', "
                        sql = sql & "'" & M.RecuperaData & "', "
                        sql = sql & "'" & Session("EMAIL_LOGIN") & "') "
                        M.ExecutarSQL(sql)

                        M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "SETORIZOU ESTABELECIMENTO", "CNPJ: " & Session("CNPJ") & " - " & " PARA: " & cmb_USUARIOS.Text)
                        M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "SETORIZOU ESTABELECIMENTO", "CNPJ: " & DOCUMENTO)
                        Alert("Cliente foi setorizado com sucesso!", True, "Estabelecimentos_Pesquisa_RF.aspx")
                    Else
                        M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO EM SETORIZAR ESTABELECIMENTO", "CNPJ: " & Session("CNPJ") & " PARA: " & cmb_USUARIOS.Text)
                        Mensagem = "ERRO  - SETORIZACAO DE ESTABELECIMENTOS" & Chr(10)
                        Mensagem = Mensagem & "CNPJ: " & Session("CNPJ") & Chr(10)
                        Mensagem = Mensagem & "Para: " & cmb_USUARIOS.Text & Chr(10)
                        M.EnviarEmail("ERRO  - SETORIZACAO DE ESTABELECIMENTOS", Mensagem, True, False, "", "")
                        Alert("Erro ao setorizar o estabelecimento! O Erro foi enviado ao suporte e será analisado!", True, "Estabelecimentos_Pesquisa_RF.aspx")
                    End If
                    Exit Sub
                End If
                dtr.Close()
            End If
            dtr.Close()
        End If
        cnn.Close()
    End Sub
    Protected Sub cmd_Cancelar_Click(sender As Object, e As EventArgs) Handles cmd_Cancelar.Click
        Response.Redirect("Estabelecimentos_Pesquisa_RF.aspx")
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