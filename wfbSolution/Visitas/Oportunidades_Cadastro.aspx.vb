
Partial Class Oportunidades_Cadastro
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Oportunidades_Cadastro.aspx"
    Dim sql As String
    Dim sql_log As String
    Dim Mensagem As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Verifica se a existe variável de sessão para CNPJ
        Session("CNPJ") = ""
        Session("CNPJ") = Request.QueryString("CNPJ")
        If Session("CNPJ").ToString = "" Then Response.Redirect("Estabelecimentos_Localizar.aspx")

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

        'PERMITE SOMENTE A DIGITACAO DE NÚMEROS NA QUANTIDADE
        txt_Qtd_Prevista.Attributes.Add("OnKeyPress", "Digitar_Numeros(this);")

    End Sub

    Protected Sub cmd_Gravar_Click(sender As Object, e As System.EventArgs) Handles cmd_Gravar.Click
        Dim ANO_OPORTUNIDADE As Integer
        ANO_OPORTUNIDADE = Year(Now())

        'verifica se mês foi selecionado corretamente
        If Year(Now()) = Year(Now()) Then
            If cmb_Mes_Fechamento.Text < Month(Now) Then
                Alert("O Mês de fechamento deve ser superior a " & Month(Now) - 1, False, "")
                Exit Sub
            End If
        End If

        sql = ""
        sql = sql & " Insert Into TBL_OPORTUNIDADES (ANO_OPORTUNIDADE, MES_FECHAMENTO_PREVISTO, CNPJ, COD_LINHA_PRODUTO, ID_AREA, AREA_LOCAL, DESCRICAO, ID_FASE_INICIAL, ID_FASE_ATUAL, ID_SITUACAO_OPORTUNIDADE, FASE_ATUAL_DATA_INICIO, FASE_ATUAL_QTD_PREVISTA, "
        Select Case cmb_Fase.Text
            Case Is = 1 'PROSPECCAO
                sql = sql & " INCLUSAO_EMAIL, INCLUSAO_DATA, "
                sql = sql & " ID_INFLUENCIADOR_ECONOMICO, "
                sql = sql & " ID_INFLUENCIADOR_TECNICO, "
                sql = sql & " ID_USUARIO, "
                sql = sql & " ID_TREINADOR "
                sql = sql & ")"
                sql = sql & " Values ( "

                'OPORTUNIDADE
                sql = sql & ANO_OPORTUNIDADE & ", " & cmb_Mes_Fechamento.Text & ", "
                sql = sql & Session("CNPJ") & ", " & cmb_Cod_Linha_Produto.Text & ", "
                sql = sql & cmb_Area.Text & ", "
                sql = sql & "'" & M.ConverteTexto(txt_Localizacao.Text) & "', "
                sql = sql & "'" & M.ConverteTexto(txt_Descricao.Text) & "', "
                sql = sql & 1 & ", " 'FASE INICIAL = PROSPECCAO
                sql = sql & 1 & ", " 'FASE ATUAL = PROSPECAO
                sql = sql & 1 & ", " 'SITUACAO OPORTUNIDADE = EM ANDAMENTO
                sql = sql & M.RecuperaData & ", " 'INICIO DA FASE ATUAL = DATA DE CADASTRO
                sql = sql & 0 & ", " 'FASE_ATUAL_QTD_PREVISTA

                'verifica se a quantidade está preenchida
                If Len(txt_Qtd_Prevista.Text) = 0 Or txt_Qtd_Prevista.Text.ToString <> "0" Then
                    Alert("A QUANTIDADE PREVISTA DEVE SER IGUAL ZERO (0) ", False, "")
                    Exit Sub
                End If

            Case Is = 2 ' QUALIFICACAO
                sql = sql & " INCLUSAO_EMAIL, INCLUSAO_DATA,"
                sql = sql & " ID_INFLUENCIADOR_ECONOMICO, "
                sql = sql & " ID_INFLUENCIADOR_TECNICO, "
                sql = sql & " ID_USUARIO, "
                sql = sql & " ID_TREINADOR "
                sql = sql & ")"
                sql = sql & " Values ( "

                'OPORTUNIDADE
                sql = sql & ANO_OPORTUNIDADE & ", " & cmb_Mes_Fechamento.Text & ", "
                sql = sql & Session("CNPJ") & ", " & cmb_Cod_Linha_Produto.Text & ", "
                sql = sql & cmb_Area.Text & ", "
                sql = sql & "'" & M.ConverteTexto(txt_Localizacao.Text) & "', "
                sql = sql & "'" & M.ConverteTexto(txt_Descricao.Text) & "', "
                sql = sql & 2 & ", " 'FASE INICIAL = QUALIFICACAO
                sql = sql & 2 & ", " 'FASE ATUAL = QUALIFICACAO
                sql = sql & 1 & ", " 'SITUACAO OPORTUNIDADE = EM ANDAMENTO
                sql = sql & M.RecuperaData & ", " 'INICIO DA FASE ATUAL = DATA DE CADASTRO
                sql = sql & txt_Qtd_Prevista.Text & " , " 'FASE_ATUAL_QTD_PREVISTA


                'verifica se a quantidade está preenchida
                If Len(txt_Qtd_Prevista.Text) = 0 Or txt_Qtd_Prevista.Text.ToString = "0" Then
                    Alert("Preencher a quantidade prevista", False, "")
                    Exit Sub
                End If

            Case Is = 3 'COBRIR AS BASES
                sql = sql & " INCLUSAO_EMAIL, INCLUSAO_DATA,"
                sql = sql & " ID_INFLUENCIADOR_ECONOMICO, "
                sql = sql & " ID_INFLUENCIADOR_TECNICO, "
                sql = sql & " ID_USUARIO, "
                sql = sql & " ID_TREINADOR "
                sql = sql & ")"
                sql = sql & " Values ( "

                'OPORTUNIDADE
                sql = sql & ANO_OPORTUNIDADE & ", " & cmb_Mes_Fechamento.Text & ", "
                sql = sql & Session("CNPJ") & ", " & cmb_Cod_Linha_Produto.Text & ", "
                sql = sql & cmb_Area.Text & ", "
                sql = sql & "'" & M.ConverteTexto(txt_Localizacao.Text) & "', "
                sql = sql & "'" & M.ConverteTexto(txt_Descricao.Text) & "', "
                sql = sql & 3 & ", " 'FASE INICIAL = COBRIR AS BASES
                sql = sql & 3 & ", " 'FASE ATUAL = COBRIR AS BASES
                sql = sql & 1 & ", " 'SITUACAO OPORTUNIDADE = EM ANDAMENTO
                sql = sql & M.RecuperaData & ", " 'INICIO DA FASE ATUAL = DATA DE CADASTRO
                sql = sql & txt_Qtd_Prevista.Text & " , " 'FASE_ATUAL_QTD_PREVISTA

                'verifica se a quantidade está preenchida
                If Len(txt_Qtd_Prevista.Text) = 0 Or txt_Qtd_Prevista.Text.ToString = "0" Then
                    Alert("Preencher a quantidade prevista", False, "")
                    Exit Sub
                End If

            Case Is = 4 'FECHAMENTO
                sql = sql & " INCLUSAO_EMAIL, INCLUSAO_DATA,"
                sql = sql & " ID_INFLUENCIADOR_ECONOMICO, "
                sql = sql & " ID_INFLUENCIADOR_TECNICO, "
                sql = sql & " ID_USUARIO, "
                sql = sql & " ID_TREINADOR "
                sql = sql & ")"
                sql = sql & " Values ( "

                'OPORTUNIDADE
                sql = sql & ANO_OPORTUNIDADE & ", " & cmb_Mes_Fechamento.Text & ", "
                sql = sql & Session("CNPJ") & ", " & cmb_Cod_Linha_Produto.Text & ", "
                sql = sql & cmb_Area.Text & ", "
                sql = sql & "'" & M.ConverteTexto(txt_Localizacao.Text) & "', "
                sql = sql & "'" & M.ConverteTexto(txt_Descricao.Text) & "', "
                sql = sql & 4 & ", " 'FASE INICIAL = COBRIR AS BASES
                sql = sql & 4 & ", " 'FASE ATUAL = COBRIR AS BASES
                sql = sql & 1 & ", " 'SITUACAO OPORTUNIDADE = EM ANDAMENTO
                sql = sql & M.RecuperaData & ", " 'INICIO DA FASE ATUAL = DATA DE CADASTRO
                sql = sql & txt_Qtd_Prevista.Text & " , " 'FASE_ATUAL_QTD_PREVISTA

                If Len(txt_Qtd_Prevista.Text) = 0 Or txt_Qtd_Prevista.Text.ToString = "0" Then
                    Alert("Preencher a quantidade prevista", False, "")
                    Exit Sub
                End If
        End Select

        sql = sql & "'" & Session("EMAIL_LOGIN") & "', "
        sql = sql & M.RecuperaData & ","
        If (cmb_Influenciador_Economico.Text = "@") Then
            sql = sql & "" & "NULL" & ", "
        Else
            sql = sql & "'" & cmb_Influenciador_Economico.Text & "', "
        End If
        If (cmb_Influenciador_Tecnico.Text = "@") Then
            sql = sql & "" & "NULL" & ", "
        Else
            sql = sql & "'" & cmb_Influenciador_Tecnico.Text & "', "
        End If
        If (cmb_Usuario.Text = "@") Then
            sql = sql & "" & "NULL" & ", "
        Else
            sql = sql & "'" & cmb_Usuario.Text & "', "
        End If
        If (cmb_Treinador.Text = "@") Then
            sql = sql & "" & "NULL" & ") "
        Else
            sql = sql & "'" & cmb_Treinador.Text & "') "
        End If

        'INCLUI VALORES NA TABELA OPORTUNIDADE MOVIMENTO

        If M.ExecutarSQL(sql) = True Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "INCLUIU OPORTUNIDADE CNPJ:", Session("CNPJ"))
            Alert("OPORTUNIDADE INCLUIDA COM SUCESSO", True, "Estabelecimentos_Ficha.aspx?CNPJ=" & Session("CNPJ"))
        Else
            Mensagem = "ERRO - INCLUSAO DE OPORTUNIDADE - " & Now() & Chr(10)
            Mensagem = Mensagem & "CNPJ: " & Session("CNPJ") & Chr(10)
            Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN")
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO AO CADASTRAR OPORTUNIDADE", Session("CNPJ"))
            M.EnviarEmail("ERRO - INCLUSAO DE OPORTUNIDADE", Mensagem, True, False, "", "")
            Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
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
