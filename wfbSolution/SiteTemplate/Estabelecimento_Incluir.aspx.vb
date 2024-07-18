Option Explicit On
Imports System.ComponentModel.Design
Imports System.Data
Imports System.Web.ApplicationServices
Imports Newtonsoft.Json.Linq

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
        Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect("Select Id From TBL_ESTABELECIMENTOS Where CNPJ = '" & strCNPJ & "' ")
        If dtr.HasRows Then
            dtr.Read()
            Dim ID_ESTABELECIMENTO As String = dtr("Id").ToString
            m.Alert(Me, "CNPJ JÁ ESTÁ CADASTRADO", True, "Estabelecimento.aspx?idEstabelecimento=" & ID_ESTABELECIMENTO)
        End If

        Dim Retorno = s.consultarCNPJ(strCNPJ)
        Dim RAZAO_SOCIAL As String = m.ConvertText(Retorno.RazaoSocial)
        Dim NOME_FANTASIA As String = m.ConvertText(Retorno.NomeFantasia)
        If NOME_FANTASIA = "" Then NOME_FANTASIA = RAZAO_SOCIAL
        Dim NUMERO As String = m.ConvertText(Retorno.Numero)
        Dim ENDERECO As String = m.ConvertText(Retorno.Logradouro)
        If NUMERO = "" Then ENDERECO = ENDERECO Else ENDERECO = ENDERECO & " " & NUMERO
        Dim COMPLEMENTO As String = m.ConvertText(Retorno.Complemento)
        Dim BAIRRO As String = m.ConvertText(Retorno.Bairro)
        Dim CEP As String = m.ConvertText(Retorno.CEP)
        Dim CIDADE As String = m.ConvertText(Retorno.Cidade)
        Dim ESTADO As String = m.ConvertText(Retorno.Estado)
        Dim COD_IBGE As String = m.ConvertText(Retorno.CodIBGE)
        Dim COD_CNAE As String = m.ConvertText(Retorno.CodCNAE)
        Dim CNAE_DESCRICAO As String = m.ConvertText(Retorno.CNAEDescricao)
        Dim COD_NATUREZA_JURIDICA As String = m.ConvertText(Retorno.CodNaturezaJuridica)
        Dim NATUREZA_JURIDICA_DESCRICAO As String = m.ConvertText(Retorno.NaturezaJuridicaDescricao)
        Dim COD_ESFERA As String = ""
        Dim ESFERA As String = ""

        'Recupera COD_ESFERA E ESFERA
        Dim dtr1 As SqlClient.SqlDataReader = m.ExecuteSelect("Select COD_ESFERA From TBL_RF_NATUREZA_JURIDICA Where COD_NATUREZA_JURIDICA = '" & COD_NATUREZA_JURIDICA & "' ")
        If dtr1.HasRows Then
            dtr1.Read()
            COD_ESFERA = dtr1("COD_ESFERA")
        Else
            COD_ESFERA = "000"
        End If

        Dim dtr2 As SqlClient.SqlDataReader = m.ExecuteSelect("Select ESFERA From TBL_ESTABELECIMENTOS_ESFERA Where COD_ESFERA = '" & COD_ESFERA & "' ")
        If dtr2.HasRows Then
            dtr2.Read()
            ESFERA = dtr2("ESFERA")
        Else
            ESFERA = ""
        End If

        'POSTA NA PÁGINA
        CNPJ.Value = strCNPJ
        txt_NOME_FANTASIA.Value = NOME_FANTASIA
        txt_RAZAO_SOCIAL.Value = RAZAO_SOCIAL
        txt_ENDERECO.Value = ENDERECO
        txt_NUMERO.Value = NUMERO
        txt_COMPLEMENTO.Value = COMPLEMENTO
        txt_BAIRRO.Value = BAIRRO
        txt_CEP.Value = CEP
        txt_CIDADE.Value = CIDADE
        txt_UF.Value = ESTADO
        txt_COD_IBGE_7.Value = COD_IBGE
        txt_COD_CNAE.Value = COD_CNAE
        txt_CNAE_DESCRICAO.Value = CNAE_DESCRICAO
        txt_COD_NATUREZA_JURIDICA.Value = COD_NATUREZA_JURIDICA
        txt_NATUREZA_JURIDICA_DESCRICAO.Value = NATUREZA_JURIDICA_DESCRICAO
        txt_COD_ESFERA.Value = COD_ESFERA
        txt_ESFERA.Value = ESFERA

        Exit Sub
Err_Consulta_RF:
        m.Alert(Me, Err.Number & " - " & Err.Description, False, "")
    End Sub
    Private Sub Atualiza_DTS()
        'Atualiza datasources da página
        dts_CLASSES_ESTABELECIMENTOS.SelectCommand = s.sql_classes_estabelecimentos()
        dts_CLASSES_ESTABELECIMENTOS.DataBind()
    End Sub

    Private Sub cmd_Gravar_ServerClick(sender As Object, e As EventArgs) Handles cmd_Gravar.ServerClick
        Dim SQL As String = ""
        Dim COD_ESFERA As String = ""
        Dim ESFERA As String = ""

        If cmb_COD_CLASSE_ESTABELECIMENTO.Text = "0" Then
            m.Alert(Me, "Selecione a CLASSE do estabelecimento", False, "")
        End If

        Dim dtr1 As SqlClient.SqlDataReader = m.ExecuteSelect("Select COD_ESFERA From TBL_RF_NATUREZA_JURIDICA Where COD_NATUREZA_JURIDICA = '" & txt_COD_NATUREZA_JURIDICA.Value & "' ")
        If dtr1.HasRows Then
            dtr1.Read()
            COD_ESFERA = dtr1("COD_ESFERA")
        Else
            COD_ESFERA = "000"
        End If

        SQL &= "INSERT INTO [dbo].[TBL_ESTABELECIMENTOS]"
        SQL &= "([CNPJ],[CNPJ_RAIZ]"
        SQL &= ",[ESTABELECIMENTO],[RAZAO_SOCIAL]"
        SQL &= ",[ENDERECO],[COMPLEMENTO],[BAIRRO]"
        SQL &= ",[CEP],[COD_IBGE_7],[CIDADE],[UF]"
        SQL &= ",[COD_ESFERA],[COD_NATUREZA_JURIDICA],[COD_CLASSE_ESTABELECIMENTO])"
        SQL &= " VALUES ("
        SQL &= "'" & s.Formata_CNPJ(CNPJ.Value) & "',"
        SQL &= "'" & Left(s.Formata_CNPJ(CNPJ.Value), 7) & "',"
        SQL &= "'" & txt_NOME_FANTASIA.Value & "',"
        SQL &= "'" & txt_RAZAO_SOCIAL.Value & "',"
        SQL &= "'" & txt_ENDERECO.Value & "',"
        SQL &= "'" & txt_COMPLEMENTO.Value & "',"
        SQL &= "'" & txt_BAIRRO.Value & "',"
        SQL &= "'" & txt_CEP.Value & "',"
        SQL &= "'" & txt_COD_IBGE_7.Value & "',"
        SQL &= "'" & txt_CIDADE.Value & "',"
        SQL &= "'" & txt_UF.Value & "',"
        SQL &= "'" & COD_ESFERA & "',"
        SQL &= "'" & txt_COD_NATUREZA_JURIDICA.Value & "',"
        SQL &= "'" & cmb_COD_CLASSE_ESTABELECIMENTO.Text & "')"

        If m.ExecuteSQL(SQL) = True Then
            Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect("Select Id From TBL_ESTABELECIMENTOS Where CNPJ = '" & s.Formata_CNPJ(CNPJ.Value) & "' ")
            If dtr.HasRows Then
                dtr.Read()
                Dim ID_ESTABELECIMENTO As String = dtr("Id").ToString
                m.Alert(Me, "ESTABELECIMENTO CADASTRADO COM SUCESSO", True, "Estabelecimento.aspx?idEstabelecimento=" & ID_ESTABELECIMENTO)
            Else
                m.Alert(Me, "ERRO AO CADASTRAR ESTABELECIMENTO", False, "")
            End If

        End If
    End Sub
End Class
