Imports System.Data
Partial Class Cadastrar_Manual
    Inherits System.Web.UI.Page
    'Variaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Cadastrar_Manual.aspx"
    Dim Titulo As String = "Cadastro Manual de Estabelecimentos"

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        slc_tipo_pessoa.Value = 2
        pnl_cadastrar.Visible = False
        Painel_PF.Visible = False
        btn_cadastrar.Visible = False
    End Sub

    Private Sub btn_verificar_Click(sender As Object, e As EventArgs) Handles btn_verificar.Click

        'Validação cnpj preenchido
        If txt_cnpj.Text = "" Then
            Response.Write("<script>alert ('Digite o CNPJ !'); history.back();</script>")
        ElseIf slc_tipo_pessoa.Value = "" Then
            Response.Write("<script>alert ('Selecione o tipo de pessoa'); history.back();</script>")
        Else

            'Verificando se cliente existe
            Dim dtr As SqlClient.SqlDataReader = M.ExecuteSelect("Select CNPJ From TBL_ESTABELECIMENTOS Where CNPJ =" & Val(txt_cnpj.Text))

            If dtr.HasRows Then
                dtr.Read()
                If txt_cnpj.Text = dtr("CNPJ").ToString Then
                    Response.Write("<script>alert ('Cliente já Cadastrado !');</script>")
                End If
            Else
                Response.Write("<script>alert ('Continue o Cadastro !');</script>")

                If slc_tipo_pessoa.Value = 2 Then
                    txt_cnpj.Enabled = "False"
                    btn_verificar.Visible = "False"
                    Painel_PF.Visible = True
                    btn_cadastrar.Visible = True
                    slc_tipo_pessoa.Disabled = True

                Else
                    txt_cnpj.Enabled = "False"
                    btn_verificar.Visible = "False"
                    Painel_PF.Visible = True
                    pnl_cadastrar.Visible = True
                    btn_cadastrar.Visible = True
                    slc_tipo_pessoa.Disabled = True
                End If
            End If
        End If
    End Sub

    Private Sub dpd_estados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dpd_estados.SelectedIndexChanged
        dpd_cidades.DataBind()
        dts_cidades.DataBind()
        'Pegando codigo ibge 
        Dim dtr As SqlClient.SqlDataReader = M.ExecuteSelect("SELECT [COD_MUNICIPIO], [MUNICIPIO] FROM [TBL_MUNICIPIOS]  Where COD_MUNICIPIO = '" & dpd_cidades.Text & "' and UF = '" & dpd_estados.Text & "'")

        If dtr.HasRows Then
            dtr.Read()
            txt_cod_ibge.Text = dtr("COD_MUNICIPIO").ToString
        Else
            Response.Write("<script>alert ('Erro ao consultar código IBGE');history.back();</script>")
        End If
        'Tornando campos invisiveis
        If slc_tipo_pessoa.Value = 2 Then
            Painel_PF.Visible = True
            btn_cadastrar.Visible = True
        Else
            Painel_PF.Visible = True
            pnl_cadastrar.Visible = True
            btn_cadastrar.Visible = True
        End If
    End Sub

    '----------------------------------------------------------------------------------------------------------------Validação dos Campos-------------------------------------------------------------------------------------------------------------------------
    Private Sub btn_cadastrar_Click(sender As Object, e As EventArgs) Handles btn_cadastrar.Click

        Dim comprimento As Integer
        comprimento = Len(txt_cod_ibge.Text)


        If slc_tipo_pessoa.Value = "2" Then

            'CNPJ
            If txt_cnpj.Text = "" Then

            ElseIf slc_tipo_pessoa.Value = "" Then
                Response.Write("<script>alert ('Selecione o tipo de pessoa !'); history.back();</script>")
                'Razao Social

                'Razao Social
            ElseIf txt_razao_social.Text = "" Then
                Response.Write("<script>alert ('Digite o Razão Social !'); history.back();</script>")

                'Estado
            ElseIf dpd_estados.Text = "" Then
                Response.Write("<script>alert ('Selecione o Estado !'); history.back();</script>")

                'Cidade
            ElseIf dpd_cidades.Text = "" Then
                Response.Write("<script>alert ('Digite o Cidade !'); history.back();</script>")

                'Código IBGE
            ElseIf txt_cod_ibge.Text = "" Then
                Response.Write("<script>alert ('Digite o Código IBGE !'); history.back();</script>")
            End If
        Else

            'CNPJ
            If txt_cnpj.Text = "" Then
                Response.Write("<script>alert ('Digite o CNPJ !'); history.back();</script>")
                Exit Sub
                'Tipo de Pessoa
            ElseIf slc_tipo_pessoa.value = "" Then
                Response.Write("<script>alert ('Selecione o tipo de pessoa !'); history.back();</script>")
                Exit Sub
                'Razao Social
            ElseIf txt_razao_social.Text = "" Then
                Response.Write("<script>alert ('Digite o Razão Social !'); history.back();</script>")
                Exit Sub
                'Nome Fantasia
            ElseIf txt_nome_fantasia.Text = "" Then
                Response.Write("<script>alert ('Digite o Nome Fantasia !'); history.back();</script>")
                Exit Sub
                'Logradouro
            ElseIf txt_logradouro.Text = "" Then
                Response.Write("<script>alert ('Digite o Logradouro !'); history.back();</script>")
                Exit Sub
                'Número
            ElseIf txt_numero.Text = "" Then
                Response.Write("<script>alert ('Digite o Numero !'); history.back();</script>")
                Exit Sub
                'Bairro
            ElseIf txt_bairro.Text = "" Then
                Response.Write("<script>alert ('Digite o Bairro !'); history.back();</script>")
                Exit Sub
                'CEP
            ElseIf txt_cep.Text = "" Then
                Response.Write("<script>alert ('Digite o Cep !'); history.back();</script>")
                Exit Sub
                'Cidade
            ElseIf dpd_cidades.Text = "" Then
                Response.Write("<script>alert ('Digite o Cidade !'); history.back();</script>")
                Exit Sub
                'Estado
            ElseIf dpd_estados.Text = "" Then
                Response.Write("<script>alert ('Selecione o Estado !'); history.back();</script>")
                Exit Sub
                'Código IBGE
            ElseIf txt_cod_ibge.Text = "" Then
                Response.Write("<script>alert ('Digite o Código IBGE !'); history.back();</script>")
                Exit Sub
            ElseIf comprimento <> 7 Then
                Response.Write("<script>alert ('Digite corretamente o  Código IBGE !'); history.back();</script>")
                Exit Sub
                'Cod natureza Juridica
            ElseIf txt_cod_natureza_juridica.Text = "" Then
                Response.Write("<script>alert ('Digite o Código natureza juridica!'); history.back();</script>")
                Exit Sub
                'natureza Juridica descrição
            ElseIf dpd_Natura_Descricao.Text = "" Then
                Response.Write("<script>alert ('Digite a Natureza juridica Descrição!'); history.back();</script>")
                Exit Sub
                'Código CNAE
            ElseIf txt_cod_cnae.Text = "" Then
                Response.Write("<script>alert ('Digite o Código CNAE !'); history.back();</script>")
                Exit Sub
                'CNAE Descrição
            ElseIf txt_cnae_descricao.Text = "" Then
                Response.Write("<script>alert ('Digite o CNAE Descrição !'); history.back();</script>")
                Exit Sub

            End If
        End If
        '------------------------------------------------------------------------------------------------------------------------------Validação de Usuário Cadastrado -------------------------------------------------------------------------------------------
        Dim dtr As SqlClient.SqlDataReader = M.ExecuteSelect("Select CNPJ From TBL_ESTABELECIMENTOS Where CNPJ =" & txt_cnpj.Text)


        If dtr.HasRows Then

            dtr.Read()
            If txt_cnpj.Text = dtr("CNPJ").ToString Then
                Response.Write("<script>alert ('Cliente já Cadastrado !');</script>")
            End If
        Else

            If slc_tipo_pessoa.Value = 2 Then

                txt_nome_fantasia.Text = txt_razao_social.Text
                txt_logradouro.Text = "@NAO_INFORMADO"
                txt_complemento.Text = "@NAO_INFORMADO"
                txt_numero.Text = "0"
                txt_bairro.Text = "@NAO_INFORMADO"
                txt_cep.Text = "00000000"
                txt_cod_natureza_juridica.Text = "1000"
                dpd_Natura_Descricao.Text = "100-0 - Pessoas Físicas"
                txt_cod_cnae.Text = "000000"
                txt_cnae_descricao.Text = "@NAO_INFORMADO"

            End If


            '-----------------------------------------------------------------------------------------------------------------------------Enviar pro banco -----------------------------------------------------------------------------------------------------------
            Dim sql As String

            sql = ""
            sql = "INSERT INTO [dbo].[TBL_ESTABELECIMENTOS]"
            sql &= " ([CNPJ]"
            'sql &= " ,[CPF]"
            'sql &= " ,[DOCUMENTO]"
            sql &= " ,[COD_TIPO_PESSOA]"
            sql &= " ,[CNES]"
            sql &= " ,[RAZAO_SOCIAL]"
            sql &= " ,[NOME_FANTASIA]"
            sql &= " ,[DATA_FUNDACAO]"
            sql &= " ,[LOGRADOURO]"
            sql &= " ,[COMPLEMENTO]"
            sql &= " ,[NUMERO]"
            sql &= " ,[BAIRRO]"
            sql &= " ,[CEP]"
            sql &= " ,[CIDADE]"
            sql &= " ,[ESTADO]"
            sql &= " ,[COD_MUNICIPIO]"
            sql &= " ,[COD_NATUREZA_JURIDICA]"
            sql &= " ,[NATUREZA_JURIDICA_DESCRICAO]"
            sql &= " ,[COD_CNAE]"
            sql &= " ,[CNAE_DESCRICAO]"
            sql &= " ,[SITUACAORFB]"
            sql &= " ,[MOTIVO_SITUACAORFB]"
            sql &= " ,[MOTIVO_ESPECIAL_SITUACAORFB]"
            sql &= " ,[DATA_SITUACAORFB]"
            sql &= " ,[INCLUSAO_EMAIL]"
            sql &= " ,[INCLUSAO_DATA])"
            'sql &= " ,[MANUAL])"
            sql &= "  VALUES ("
            sql &= txt_cnpj.Text
            'sql &= ", " & txt_cnpj.Text
            'sql &= ", '" & txt_cnpj.Text & "'"
            sql &= ", " & slc_tipo_pessoa.Value
            sql &= ", NULL"
            sql &= ", '" & txt_razao_social.Text & "'"
            sql &= ", '" & txt_nome_fantasia.Text & "'"
            sql &= ", 00000000"
            sql &= ", '" & txt_logradouro.Text & "'"
            sql &= ", '" & txt_complemento.Text & "'"
            sql &= ", '" & txt_numero.Text & "'"
            sql &= ", '" & txt_bairro.Text & "'"
            sql &= ", '" & txt_cep.Text & "'"
            sql &= ", '" & dpd_cidades.Text & "'"
            sql &= ", '" & dpd_estados.Text & "'"
            sql &= ", '" & txt_cod_ibge.Text & "'"
            sql &= ", " & txt_cod_natureza_juridica.Text
            sql &= ", '" & dpd_Natura_Descricao.Text & "'"
            sql &= ", '" & txt_cod_cnae.Text & "'"
            sql &= ", '" & txt_cnae_descricao.Text & "'"
            sql &= ", 'ATIVA'"
            sql &= ", '@NAO_INFORMADO'"
            sql &= ", '@NAO_INFORMADO'"
            sql &= ", 00000000"
            sql &= ", '" & dpd_inclusao_email.Text & "'"
            sql &= ", 00000000)"
            'sql &= ",1) "

            If M.ExecutarSQL(sql) = True Then
                Response.Write("<script>alert ('Cliente Cadastrado com sucesso !');window.location.href='Default.aspx'</script>")
            Else
                Response.Write("<script>alert('Erro ao cadastrar cliente !');</script>")
            End If
        End If

    End Sub


    Private Sub dpd_cidades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dpd_cidades.SelectedIndexChanged
        'Pegando codigo ibge 
        Dim dtr As SqlClient.SqlDataReader = M.ExecuteSelect("Select COD_MUNICIPIO, MUNICIPIO From TBL_MUNICIPIOS Where COD_MUNICIPIO = '" & dpd_cidades.Text & "' and UF = '" & dpd_estados.Text & "'")
        If dtr.HasRows Then
            dtr.Read()
            txt_cod_ibge.Text = dtr("COD_MUNICIPIO").ToString
        Else
            Response.Write("<script>alert ('Erro ao consultar código IBGE');history.back();</script>")
        End If
        'Tornando campos invisiveis
        If slc_tipo_pessoa.Value = 2 Then
            Painel_PF.Visible = True
            btn_cadastrar.Visible = True
        Else
            Painel_PF.Visible = True
            pnl_cadastrar.Visible = True
            btn_cadastrar.Visible = True
        End If
    End Sub





    Private Sub dpd_Natura_Descricao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dpd_Natura_Descricao.SelectedIndexChanged
        'Pegando codigo ibge 
        Dim dtr As SqlClient.SqlDataReader = M.ExecuteSelect("SELECT NATUREZA_JURIDICA, COD_NATUREZA_JURIDICA  FROM TBL_RF_NATUREZA_JURIDICA WHERE NATUREZA_JURIDICA = '" & dpd_Natura_Descricao.Text & "'")
        If dtr.HasRows Then
            dtr.Read()
            txt_cod_natureza_juridica.Text = dtr("COD_NATUREZA_JURIDICA").ToString
        Else
            Response.Write("<script>alert ('Erro ao consultar código Natureza Juridica');history.back();</script>")
        End If
        'Tornando campos invisiveis
        If slc_tipo_pessoa.Value = 2 Then
            Painel_PF.Visible = True
            btn_cadastrar.Visible = True
        Else
            Painel_PF.Visible = True
            pnl_cadastrar.Visible = True
            btn_cadastrar.Visible = True
        End If
    End Sub

    Private Sub dpd_inclusao_email_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dpd_inclusao_email.SelectedIndexChanged
        'Tornando campos invisiveis
        If slc_tipo_pessoa.Value = 2 Then
            Painel_PF.Visible = True
            btn_cadastrar.Visible = True
        Else
            Painel_PF.Visible = True
            pnl_cadastrar.Visible = True
            btn_cadastrar.Visible = True
        End If
    End Sub
End Class

