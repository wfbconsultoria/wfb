
Partial Class Medicos_CRM
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Medicos Inclusão"

    'Variáveis da Página
    Dim cnn As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Verifica se o usuario está logado
        If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Login.aspx")

        'Verifica se a existe variável de sessão para CNPJ
        Session("CNPJ") = ""
        Session("CNPJ") = Request.QueryString("CNPJ")
        If Session("CNPJ").ToString = "" Then Response.Redirect("Estabelecimentos_Localizar.aspx")


        If Len(Request.QueryString("CRMUF")) > 0 Then Session("CRMUF") = Request.QueryString("CRMUF")

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
    End Sub

    Protected Sub cmd_Pesquisar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Pesquisar.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand


        Dim CRM As String
        Dim UF As String
        Dim CRMUF As String
        Dim CNPJ As String
        CNPJ = Session("CNPJ")

        'LIMPA OS CAMPOS DO FORMULARIO
        cmb_ESPECIALIDADE.Text = "0"
        txt_NOME.Text = " "
        txt_CRMUF.Text = " "
        txt_Endereco.Text = " "
        txt_Bairro.Text = " "
        txt_CEP.Text = " "
        cmb_COD_MUNICIPIO.Text = "0000000"
        txt_TELEFONE.Text = " "
        txt_CELULAR.Text = " "
        txt_EMAIL.Text = " "
        cmb_MES_ANIVERSARIO.Text = "0"
        cmb_DIA_ANIVERSARIO.Text = "0"

        txt_TELEFONE_ESTABELECIMENTO.Text = " "
        cmb_ID_ESPECIALIDADE.Text = "0"
        cmb_ID_AREA.Text = "0"
        cmb_ID_CARGO.Text = "0"
        cmb_ID_PERFIL.Text = "0"

        'MONTA O CRMUF DO MÉDICO
        CRM = Left("0000000000", 10 - Len(txt_CRM.Text)) & txt_CRM.Text
        UF = cmb_UF.Text
        CRMUF = UF & CRM

        'VERIFICA SE O MEDICO ESTÁ CADASTRADO NA TABELA MEDICOS
        sql = ""
        sql = "Select * From TBL_MEDICOS Where CRMUF = '" & CRMUF & "' "
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnstr").ConnectionString
        cnn.Open()
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            Session("TABELA_MEDICOS") = True
            Session("CRMUF_INCLUIR") = CRMUF
            dtr.Read()
            txt_NOME.Text = dtr("NOME")
            txt_CRMUF.Text = dtr("CRMUF")

            If Not IsDBNull(dtr("ID_ESPECIALIDADE")) Then cmb_ESPECIALIDADE.Text = dtr("ID_ESPECIALIDADE")
            If Not IsDBNull(dtr("TELEFONE")) Then txt_TELEFONE.Text = dtr("TELEFONE")
            If Not IsDBNull(dtr("CELEULAR")) Then txt_CELULAR.Text = dtr("CELEULAR")
            If Not IsDBNull(dtr("EMAIL")) Then txt_EMAIL.Text = dtr("EMAIL")
            If Not IsDBNull(dtr("MES_ANIVERSARIO")) Then cmb_MES_ANIVERSARIO.Text = dtr("MES_ANIVERSARIO")
            If Not IsDBNull(dtr("DIA_ANIVERSARIO")) Then cmb_DIA_ANIVERSARIO.Text = dtr("DIA_ANIVERSARIO")
            cmb_ESPECIALIDADE.Enabled = False
            txt_TELEFONE.Enabled = False
            txt_CELULAR.Enabled = False
            txt_EMAIL.Enabled = False
            cmb_MES_ANIVERSARIO.Enabled = False
            cmb_DIA_ANIVERSARIO.Enabled = False
            dtr.Close()
            cnn.Close()
        Else
            Session("TABELA_MEDICOS") = False
            cmb_ESPECIALIDADE.Enabled = True
            txt_TELEFONE.Enabled = True
            txt_CELULAR.Enabled = True
            txt_EMAIL.Enabled = True
            cmb_MES_ANIVERSARIO.Enabled = True
            cmb_DIA_ANIVERSARIO.Enabled = True
            dtr.Close()
            cnn.Close()
        End If

        'VERIFICA SE O MEDICO ESTÁ CADASTRADO NA TABELA MEDICOS ESTABELECIMENTOS
        If Session("TABELA_MEDICOS") = True Then
            sql = ""
            sql = "Select * From TBL_MEDICOS_ESTABELECIMENTOS Where (CNPJ = '" & CNPJ & "') AND (CRMUF = '" & CRMUF & "')"
            cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnstr").ConnectionString
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader
            If dtr.HasRows Then
                dtr.Read()
                If (dtr("ATIVO") = "SIM") Then
                    Alert("Este médico já está cadastrado nesse estabelecimento", True, "Estabelecimentos_Ficha2.aspx?CNPJ=" & Session("CNPJ"))
                Else
                    sql = ""
                    sql = sql & " Update TBL_MEDICOS_ESTABELECIMENTOS Set "
                    sql = sql & " ATIVO ='SIM'"
                    sql = sql & " WHERE (CRMUF = '" & CRMUF & "')"
                    sql = sql & " AND (CNPJ = '" & CNPJ & "')"
                    M.ExecutarSQL(sql)
                    Alert("Este médico já estava cadastrado nesse estabelecimento, e está sendo reativado", True, "Estabelecimentos_Ficha2.aspx?CNPJ=" & Session("CNPJ"))
                End If
                dtr.Close()
                cnn.Close()
            Else
                dtr.Close()
                cnn.Close()
                Exit Sub
            End If
        End If
        If Session("TABELA_MEDICOS") = False Then
            'VERIFICA SE O MEDICO ESTÁ CADASTRADO NO CFM
            sql = ""
            sql = "Select * From VIEW_MEDICOS_CFM Where CRMUF = '" & CRMUF & "'"
            cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnMedicos").ConnectionString
            cnn.Open()
            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader
            If dtr.HasRows Then
                dtr.Read()
                txt_NOME.Text = dtr("NOME")
                txt_CRMUF.Text = dtr("CRMUF")
                Session("CRMUF_INCLUIR") = CRMUF
                Alert(dtr("NOME") & " ENCONTRADO", False, "")
                Exit Sub
            Else
                Session("CRMUF_INCLUIR") = ""
                txt_NOME.Text = ""
                Alert("Este MÉDICO não consta no cadastro do CFM", False, "")
            End If
            dtr.Close()
            cnn.Close()
        End If
    End Sub
    Protected Sub cmd_Gravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Gravar.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String
        Dim Mensagem As String
        Dim CNPJ As String
        Dim CRMUF As String


        If Session("CRMUF_INCLUIR") = "" Then
            Alert("Pesquise o médico no CFM antes de incluir", False, "")
            Exit Sub
        End If

        CNPJ = Session("CNPJ")
        CRMUF = Session("CRMUF_INCLUIR")

        'CADASTRA MÉDICO NA TBL_MÉDICOS
        If Session("TABELA_MEDICOS") = False Then
            
            sql = ""
            sql = sql & "Insert Into TBL_MEDICOS ("
            sql = sql & "[CRMUF] "
            sql = sql & ",[NOME]"
            sql = sql & ",[ID_ESPECIALIDADE]"
            sql = sql & ",[TELEFONE]"
            sql = sql & ",[CELEULAR]"
            sql = sql & ",[EMAIL]"
            sql = sql & ",[MES_ANIVERSARIO]"
            sql = sql & ",[DIA_ANIVERSARIO]"
            sql = sql & ",[INCLUSAO_DATA]"
            sql = sql & ",[INCLUSAO_EMAIL])"
            sql = sql & " Values ("
            sql = sql & "'" & Session("CRMUF_INCLUIR") & "', "
            sql = sql & "'" & M.ConverteTexto(txt_NOME.Text) & "', "
            sql = sql & cmb_ESPECIALIDADE.Text & ", "
            sql = sql & "'" & M.ConverteTexto(txt_TELEFONE.Text) & "', "
            sql = sql & "'" & M.ConverteTexto(txt_CELULAR.Text) & "', "
            sql = sql & "'" & M.ConverteTexto(txt_EMAIL.Text) & "', "
            sql = sql & cmb_MES_ANIVERSARIO.Text & ", "
            sql = sql & cmb_DIA_ANIVERSARIO.Text & ", "
            sql = sql & "'" & M.RecuperaData & "', "
            sql = sql & "'" & Session("EMAIL_LOGIN") & "') "
            
            If M.ExecutarSQL(sql) = True Then
                Session("TABELA_MEDICOS") = True
            Else
                Alert("Erro ao Incluir Médico", False, "")
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO INCLUSAO MEDICO", "CRM: " & Session("CRMUF_INCLUIR") & " NOME: " & txt_NOME.Text)
                Mensagem = "ERRO  - INCLUSÃO DE MEDICO" & Chr(10)
                Mensagem = Mensagem & " CRM: " & Session("CRMUF_INCLUIR") & " NOME: " & txt_NOME.Text & Chr(10) & " CNPJ DO ESTABELECIMENTO: " & Session("CNPJ")
                Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN")
                M.EnviarEmail("ERRO - INCLUSÃO DE MEDICO", Mensagem, True, False, "", "")
                Exit Sub
            End If
        End If
        'CADASTRA MÉDICO NO ESTABELECIMENTO
        Session("TABELA_MEDICOS") = True
        sql = ""
        sql = sql & "Insert into TBL_MEDICOS_ESTABELECIMENTOS ([CRMUF],[CNPJ],[ID_PERFIL],[ID_ESPECIALIDADE],[ID_AREA],[ID_CARGO],[TELEFONE],[INCLUSAO_DATA], [INCLUSAO_EMAIL]) Values ("
        sql = sql & "'" & Session("CRMUF_INCLUIR") & "', "
        sql = sql & "'" & Session("CNPJ") & "', "
        sql = sql & cmb_ID_PERFIL.Text & ", "
        sql = sql & cmb_ID_ESPECIALIDADE.Text & ", "
        sql = sql & cmb_ID_AREA.Text & ", "
        sql = sql & cmb_ID_CARGO.Text & ", "
        sql = sql & "'" & M.ConverteTexto(txt_TELEFONE_ESTABELECIMENTO.Text) & "', "
        sql = sql & "'" & M.RecuperaData & "', "
        sql = sql & "'" & Session("EMAIL_LOGIN") & "') "

        If M.ExecutarSQL(sql) = True Then
            Alert("Médico incluido com sucesso no estabelecimento", True, "Estabelecimentos_Ficha2.aspx?CNPJ=" & Session("CNPJ"))
        Else
            Alert("Erro ao Incluir Perfil do Médico", False, "")
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO INCLUSAO MEDICO NO ESTABELECIMENTO", "CRM: " & Session("CRMUF_INCLUIR") & " NOME: " & txt_NOME.Text)
            Mensagem = "ERRO  - INCLUSÃO DE MEDICO NO ESTABELECIMENTO" & Chr(10)
            Mensagem = Mensagem & " CRM: " & Session("CRMUF_INCLUIR") & " NOME: " & txt_NOME.Text & Chr(10) & " CNPJ DO ESTABELECIMENTO: " & Session("CNPJ")
            Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN")
            M.EnviarEmail("ERRO - INCLUSÃO DE MEDICO NO ESTABELECIMENTO", Mensagem, True, False, "", "")
            Exit Sub
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