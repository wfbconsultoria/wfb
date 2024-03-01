Option Explicit On
Partial Class Estabelecimento_Incluir
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly s As New clsEstabelecimentos
    Private Sub Estabelecimento_Incluir_Load(sender As Object, e As EventArgs) Handles Me.Load
        Atualiza_DTS()
    End Sub
    Private Sub cmd_Consultar_ServerClick(sender As Object, e As EventArgs) Handles cmd_Consultar.ServerClick
        Consulta_RF()

    End Sub
    Public Sub Consulta_RF()
        On Error GoTo Err_Consulta_RF
        'verfica se campo está preenchido
        If Len(CNPJ.Value) = 0 Then
            m.Alert(Me, "DIGITE O NUMERO DO DOCUMENTO", False, "")
            Exit Sub
        End If

        'permite somente números
        If Not IsNumeric(CNPJ.Value) Then
            m.Alert(Me, "DIGITE SOMENTE NÚMEROS", False, "")
            Exit Sub
        End If

        'verifica tamnho do CNPJ
        If Len(CNPJ.Value) < 7 Or Len(CNPJ.Value) > 14 Then
            m.Alert(Me, "CNPJ DEVE CONTER  ENTRE 7 E 14 NÚMEROS ", False, "")
            Exit Sub
        End If

        'atribui o domuento na variavel CNPJ
        Dim strCNPJ As String = s.Formata_CNPJ(CNPJ.Value)

        'Verifica se o estabelecimento já existe
        If m.CheckExists("TBL_ESTABELECIMENTOS", "CNPJ", strCNPJ) Then
            m.Alert(Me, "CNPJ JÁ ESTÁ CADASTRADO", False, "")
            Exit Sub
        End If

        'Declara o Servico que vai ser usado
        Dim oWebServices As New svcCDC.CDC

        'Declara o Objeto que contem as credenciais de Acesso
        Dim Credenciais As New svcCDC.Credenciais
        Dim Retorno As New svcCDC.PessoaJuridicaNFe
        'Preenche com sua credenciais o objeto "Credenciais"
        Credenciais.Email = ConfigurationManager.AppSettings("SoaWebServices.User").ToString
        Credenciais.Senha = ConfigurationManager.AppSettings("SoaWebServices.Password").ToString
        Retorno = oWebServices.PessoaJuridicaNFe(Credenciais, strCNPJ)

        If Retorno.Status = False Then
            m.Alert(Me, "CNPJ NÃO ENCONTRADO NA RECEITA FEDERAL OU INVÁLIDO", False, "")
            Exit Sub
        End If

        Dim RAZAO_SOCIAL As String = m.ConvertText(Retorno.RazaoSocial)
        Dim NOME_FANTASIA As String = m.ConvertText(Retorno.NomeFantasia)
        If NOME_FANTASIA = "" Then NOME_FANTASIA = RAZAO_SOCIAL
        Dim ENDERECO As String = ""
        Dim NUMERO As String = ""
        Dim COMPLEMENTO As String = ""
        Dim BAIRRO As String = ""
        Dim CEP As String = ""
        Dim CIDADE As String = ""
        Dim ESTADO As String = ""
        Dim COD_IBGE As String = ""
        'LOOP PARA PREENCHER ENDEREÇO A PARTIR DO ARRAY
        For Each Item As svcCDC.Endereco2 In Retorno.Enderecos
            ENDERECO = m.ConvertText(Item.Logradouro)
            COMPLEMENTO = m.ConvertText(Item.Complemento)
            NUMERO = m.ConvertText(Item.Numero)
            BAIRRO = m.ConvertText(Item.Bairro)
            CEP = m.ConvertText(Item.CEP)
            If CEP = "" Then
                CEP = "00000000"
            End If
            CIDADE = m.ConvertText(Item.Cidade)
            ESTADO = m.ConvertText(Item.Estado)
            COD_IBGE = m.ConvertText(Item.CodigoIBGE)
        Next
        Dim COD_CNAE As String = m.ConvertText(Retorno.CodigoAtividadeEconomica)
        Dim CNAE_DESCRICAO As String = m.ConvertText(Retorno.CodigoAtividadeEconomicaDescricao)
        Dim COD_NATUREZA_JURIDICA As String = m.ConvertText(Retorno.CodigoNaturezaJuridica)
        Dim NATUREZA_JURIDICA_DESCRICAO As String = m.ConvertText(Retorno.CodigoNaturezaJuridicaDescricao)
        Dim SITUACAO_RF As String = m.ConvertText(Retorno.SituacaoRFB)


        'INSERE INFORMAÇÕES NO BANCO DE DADOS DA WFB
        'Dim SQL As String = ""
        'SQL &= " INSERT INTO [dbo].[TBL_ESTABELECIMENTOS] "
        'SQL &= " ([CNPJ] "
        ''SQL &= " ,[CPF] "
        ''SQL &= " ,[DOCUMENTO] "
        'SQL &= " ,[COD_TIPO_PESSOA] "
        'SQL &= " ,[CNES] "
        'SQL &= " ,[RAZAO_SOCIAL] "
        'SQL &= " ,[NOME_FANTASIA] "
        'SQL &= " ,[DATA_FUNDACAO] "
        'SQL &= " ,[LOGRADOURO] "
        'SQL &= " ,[COMPLEMENTO] "
        'SQL &= " ,[NUMERO] "
        'SQL &= " ,[BAIRRO] "
        'SQL &= " ,[CEP] "
        'SQL &= " ,[CIDADE] "
        'SQL &= " ,[ESTADO] "
        'SQL &= " ,[COD_MUNICIPIO] "
        'SQL &= " ,[COD_NATUREZA_JURIDICA] "
        'SQL &= " ,[NATUREZA_JURIDICA_DESCRICAO] "
        'SQL &= " ,[COD_CNAE] "
        'SQL &= " ,[CNAE_DESCRICAO] "
        'SQL &= " ,[SITUACAORFB] "
        'SQL &= " ,[MOTIVO_SITUACAORFB] "
        'SQL &= " ,[MOTIVO_ESPECIAL_SITUACAORFB] "
        'SQL &= " ,[DATA_SITUACAORFB]) "
        'SQL &= " VALUES( "
        'SQL &= "  " & CNPJ & " ,"
        ''SQL &= "  " & CNPJ & " ,"
        ''SQL &= " '" & CNPJ & "',"
        'SQL &= " 1,"
        'SQL &= " NULL,"
        'SQL &= " '" & RAZAO_SOCIAL & "',"
        'SQL &= " '" & NOME_FANTASIA & "',"
        'SQL &= " " & DATA_FUNDACAO & ","
        'SQL &= " '" & LOGRADOURO & "',"
        'SQL &= " '" & COMPLEMENTO & "',"
        'SQL &= " '" & NUMERO & "',"
        'SQL &= " '" & BAIRRO & "',"
        'SQL &= " '" & CEP & "',"
        'SQL &= " '" & CIDADE & "',"
        'SQL &= " '" & ESTADO & "',"
        'SQL &= " '" & COD_IBGE & "',"
        'SQL &= "  " & COD_NATUREZA_JURIDICA & ","
        'SQL &= " '" & NATUREZA_JURIDICA_DESCRICAO & "',"
        'SQL &= " '" & COD_CNAE & "',"
        'SQL &= " '" & CNAE_DESCRICAO & "',"
        'SQL &= " '" & SITUACAORFB & "',"
        'SQL &= " '" & MOTIVO_SITUACAORRFB & "',"
        'SQL &= " '" & MOTIVO_ESPECIAL_SITUACAORFB & "',"
        'SQL &= "  " & DATA_SITUACAORFB & ")"
        'm.ExecutarSQL(SQL)
        'Alert("CNPJ:" & CNPJ & " - " & NOME_FANTASIA & ", INCLUIDO COM SUCESSO!", False, "")

        Exit Sub
Err_Consulta_RF:
        m.Alert(Me, Err.Number & " - " & Err.Description, False, "")
    End Sub
    Private Sub Atualiza_DTS()
        'Atualiza datasources da página
        dts_CLASSES_ESTABELECIMENTOS.SelectCommand = s.sql_classes_estabelecimentos()
        dts_CLASSES_ESTABELECIMENTOS.DataBind()
    End Sub


End Class
