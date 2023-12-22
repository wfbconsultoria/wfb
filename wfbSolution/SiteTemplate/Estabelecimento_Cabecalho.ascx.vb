
Imports System.Data

Partial Class Estabelecimento_Cabecalho
    Inherits System.Web.UI.UserControl
    ReadOnly m As New clsMaster
    ReadOnly s As New clsEstabelecimentos
    Public Property ID_ESTABELECIMENTO As String = ""
    Public Property CNPJ As String = ""
    Public Property ESTABELECIMENTO As String = ""
    Public Property REPRESENTANTE As String = ""
    Public Property EMAIL_REPRESENTANTE As String = ""
    Public Property GERENTE As String = ""
    Public Property EMAIL_GERENTE As String = ""
    Public Property ENDERECO As String = ""
    Public Property COMPLEMENTO As String = ""
    Public Property BAIRRO As String = ""
    Public Property CEP As String = ""
    Public Property CIDADE As String = ""
    Public Property COD_IBGE_7 As String = ""
    Public Property UF As String = ""

    Private Sub Estabelecimento_Cabecalho_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Verifica se o ID do ESTABELECIMENTO foi passado na query string
        If m.CheckQueryString("IdEstabelecimento") = False Then
            div_PRINCIPAL_ESTABELECIMENTO.Visible = False
            div_MENSAGEM_ESTABELECIMENTO.Visible = True
        Else
            ID_ESTABELECIMENTO = Request.QueryString("IdEstabelecimento")
            Dim dtr As SqlClient.SqlDataReader
            dtr = M.ExecuteSelect(s.sql_Estabelecimentos("ficha", ID_ESTABELECIMENTO))
            If dtr.HasRows Then
                dtr.Read()

                'ATRIBUI VALORES AS PROPRIEDADES
                If Not IsDBNull(dtr("CNPJ")) Then CNPJ = m.ConvertText(dtr("CNPJ"))
                If Not IsDBNull(dtr("Estabelecimento")) Then ESTABELECIMENTO = m.ConvertText(dtr("Estabelecimento"))
                If Not IsDBNull(dtr("Representante")) Then REPRESENTANTE = m.ConvertText(dtr("Representante"))
                If Not IsDBNull(dtr("Email_Representante")) Then EMAIL_REPRESENTANTE = m.ConvertText(dtr("Email_Representante"))
                If Not IsDBNull(dtr("Gerente")) Then GERENTE = m.ConvertText(dtr("Gerente"))
                If Not IsDBNull(dtr("Email_Gerente")) Then EMAIL_GERENTE = m.ConvertText(dtr("Email_Gerente"))
                If Not IsDBNull(dtr("Endereco")) Then ENDERECO = m.ConvertText(dtr("Endereco"))
                If Not IsDBNull(dtr("Bairro")) Then BAIRRO = m.ConvertText(dtr("Bairro"))
                If Not IsDBNull(dtr("Complemento")) Then COMPLEMENTO = m.ConvertText(dtr("Complemento"))
                If Not IsDBNull(dtr("Cidade")) Then CIDADE = m.ConvertText(dtr("Cidade"))
                If Not IsDBNull(dtr("UF")) Then UF = m.ConvertText(dtr("UF"))
                If Not IsDBNull(dtr("Cod_IBGE_7")) Then COD_IBGE_7 = m.ConvertText(dtr("Cod_IBGE_7"))

                'ATRIBUI VALORES ASO CAMPOS DA PAGINA
                txt_CNPJ.Value = CNPJ
                txt_ESTABELECIMENTO.Value = ESTABELECIMENTO
                txt_REPRESENTANTE.Value = REPRESENTANTE
                txt_ENDERECO.Value = ENDERECO
                txt_BAIRRO.Value = BAIRRO
                txt_CIDADE.Value = CIDADE
                txt_UF.Value = UF
                div_PRINCIPAL_ESTABELECIMENTO.Visible = True
                div_MENSAGEM_ESTABELECIMENTO.Visible = False
            Else
                div_PRINCIPAL_ESTABELECIMENTO.Visible = False
                div_MENSAGEM_ESTABELECIMENTO.Visible = True
            End If
        End If
    End Sub

End Class
