
Partial Class Estabelecimentos_Pesquisar
    Inherits System.Web.UI.Page
    ReadOnly M As New clsMaster

    Protected Sub cmd_Consultar_Click(sender As Object, e As System.EventArgs) Handles cmd_Consultar.Click
        On Error GoTo Err_cmd_Consultar_Click

        'verfica se campo está preenchido
        If Len(txt_DOCUMENTO.Text) = 0 Then
            Alert("DIGITE O NUMERO DO DOCUMENTO", False, "")
            Exit Sub
        End If

        'permite somente números
        If Not IsNumeric(txt_DOCUMENTO.Text) Then
            Alert("DIGITE SOMENTE NÚMEROS", False, "")
            Exit Sub
        End If

        'verifica tamnho do CNPJ
        If Len(txt_DOCUMENTO.Text) < 7 Or Len(txt_DOCUMENTO.Text) > 14 Then
            Alert("CNPJ DEVE CONTER  ENTRE 7 E 14 NÚMEROS ", False, "")
            Exit Sub
        End If

        'atribui o domuento na variavel CNPJ
        Dim CNPJ As String = Format(Val(M.Converte_Valor(txt_DOCUMENTO.Text)), "00000000000000")
        If M.CheckExists("TBL_ESTABELECIMENTOS", "CNPJ", Val(CNPJ).ToString) Then
            Alert("CNPJ JÁ ESTÁ CADASTRADO", False, "")
            Exit Sub
        End If

        'Declara o Servico que vai ser usado
        Dim oWebServices As New svcCDC.CDC
            'Declara o Objeto que contem as credenciais de Acesso
            Dim Credenciais As New svcCDC.Credenciais
        Dim Retorno As New svcCDC.PessoaJuridicaNFe
        'Preenche com sua credenciais o objeto "Credenciais"
        Credenciais.Email = ConfigurationManager.AppSettings("svcCDC.User").ToString
        Credenciais.Senha = ConfigurationManager.AppSettings("svcCDC.PassWord").ToString

        Retorno = oWebServices.PessoaJuridicaNFe(Credenciais, CNPJ)

        If Retorno.Status = False Then
            Alert("CNPJ NÃO ENCONTRADO NA RECEITA FEDERAL OU INVÁLIDO", False, "")
            Exit Sub
        End If

        Dim RAZAO_SOCIAL As String = M.ConverteTexto(Retorno.RazaoSocial)
        Dim NOME_FANTASIA As String = M.ConverteTexto(Retorno.NomeFantasia)
        If NOME_FANTASIA = "" Then NOME_FANTASIA = RAZAO_SOCIAL
        Dim DATA_FUNDACAO As String = M.Converte_Valor(Retorno.DataFundacao)
        Dim LOGRADOURO As String = ""
        Dim COMPLEMENTO As String = ""
        Dim NUMERO As String = ""
        Dim BAIRRO As String = ""
        Dim CEP As String = ""
        Dim CIDADE As String = ""
        Dim ESTADO As String = ""
        Dim COD_IBGE As String = ""
        'LOOP PARA PREENCHER ENDEREÇO A PARTIR DO ARRAY
        For Each Item As svcCDC.Endereco2 In Retorno.Enderecos
            LOGRADOURO = M.ConverteTexto(Item.Logradouro)
            COMPLEMENTO = M.ConverteTexto(Item.Complemento)
            NUMERO = M.Converte_Valor(Item.Numero)
            BAIRRO = M.ConverteTexto(Item.Bairro)
            CEP = M.Converte_Valor(Item.CEP)
            If CEP = "" Then
                CEP = "00000000"
            End If
            CIDADE = M.ConverteTexto(Item.Cidade)
            ESTADO = M.ConverteTexto(Item.Estado)
            COD_IBGE = M.Converte_Valor(Item.CodigoIBGE)
        Next
        Dim COD_CNAE As String = M.Converte_Valor(Retorno.CodigoAtividadeEconomica)
        Dim CNAE_DESCRICAO As String = M.ConverteTexto(Retorno.CodigoAtividadeEconomicaDescricao)
        Dim COD_NATUREZA_JURIDICA As String = M.Converte_Valor(Retorno.CodigoNaturezaJuridica)
        Dim NATUREZA_JURIDICA_DESCRICAO As String = M.ConverteTexto(Retorno.CodigoNaturezaJuridicaDescricao)
        Dim SITUACAORFB As String = M.ConverteTexto(Retorno.SituacaoRFB)
        Dim MOTIVO_SITUACAORRFB As String = M.ConverteTexto(Retorno.MotivoSituacaoRFB)
        Dim MOTIVO_ESPECIAL_SITUACAORFB As String = M.ConverteTexto(Retorno.MotivoEspecialSituacaoRFB)
        Dim DATA_SITUACAORFB As String = M.Converte_Valor(Retorno.DataSituacaoRFB)

        'INSERE INFORMAÇÕES NO BANCO DE DADOS DA WFB
        Dim SQL As String = ""
        SQL &= " INSERT INTO [dbo].[TBL_ESTABELECIMENTOS] "
        SQL &= " ([CNPJ] "
        'SQL &= " ,[CPF] "
        'SQL &= " ,[DOCUMENTO] "
        SQL &= " ,[COD_TIPO_PESSOA] "
        SQL &= " ,[CNES] "
        SQL &= " ,[RAZAO_SOCIAL] "
        SQL &= " ,[NOME_FANTASIA] "
        SQL &= " ,[DATA_FUNDACAO] "
        SQL &= " ,[LOGRADOURO] "
        SQL &= " ,[COMPLEMENTO] "
        SQL &= " ,[NUMERO] "
        SQL &= " ,[BAIRRO] "
        SQL &= " ,[CEP] "
        SQL &= " ,[CIDADE] "
        SQL &= " ,[ESTADO] "
        SQL &= " ,[COD_MUNICIPIO] "
        SQL &= " ,[COD_NATUREZA_JURIDICA] "
        SQL &= " ,[NATUREZA_JURIDICA_DESCRICAO] "
        SQL &= " ,[COD_CNAE] "
        SQL &= " ,[CNAE_DESCRICAO] "
        SQL &= " ,[SITUACAORFB] "
        SQL &= " ,[MOTIVO_SITUACAORFB] "
        SQL &= " ,[MOTIVO_ESPECIAL_SITUACAORFB] "
        SQL &= " ,[DATA_SITUACAORFB]) "
        SQL &= " VALUES( "
        SQL &= "  " & CNPJ & " ,"
        'SQL &= "  " & CNPJ & " ,"
        'SQL &= " '" & CNPJ & "',"
        SQL &= " 1,"
        SQL &= " NULL,"
        SQL &= " '" & RAZAO_SOCIAL & "',"
        SQL &= " '" & NOME_FANTASIA & "',"
        SQL &= " " & DATA_FUNDACAO & ","
        SQL &= " '" & LOGRADOURO & "',"
        SQL &= " '" & COMPLEMENTO & "',"
        SQL &= " '" & NUMERO & "',"
        SQL &= " '" & BAIRRO & "',"
        SQL &= " '" & CEP & "',"
        SQL &= " '" & CIDADE & "',"
        SQL &= " '" & ESTADO & "',"
        SQL &= " '" & COD_IBGE & "',"
        SQL &= "  " & COD_NATUREZA_JURIDICA & ","
        SQL &= " '" & NATUREZA_JURIDICA_DESCRICAO & "',"
        SQL &= " '" & COD_CNAE & "',"
        SQL &= " '" & CNAE_DESCRICAO & "',"
        SQL &= " '" & SITUACAORFB & "',"
        SQL &= " '" & MOTIVO_SITUACAORRFB & "',"
        SQL &= " '" & MOTIVO_ESPECIAL_SITUACAORFB & "',"
        SQL &= "  " & DATA_SITUACAORFB & ")"
        M.ExecutarSQL(SQL)
        Alert("CNPJ:" & CNPJ & " - " & NOME_FANTASIA & ", INCLUIDO COM SUCESSO!", False, "")

        Exit Sub
Err_cmd_Consultar_Click:
        Alert(Err.Number & " - " & Err.Description, False, "")
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