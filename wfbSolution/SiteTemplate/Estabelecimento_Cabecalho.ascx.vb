
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
                If Not IsDBNull(dtr("Estabelecimento")) Then ESTABELECIMENTO = m.ConvertText(dtr("ESTABELECIMENTO"))
                If Not IsDBNull(dtr("Representante")) Then REPRESENTANTE = m.ConvertText(dtr("REPRESENTANTE"))
                If Not IsDBNull(dtr("Email_Representante")) Then EMAIL_REPRESENTANTE = m.ConvertText(dtr("EMAIL_REPRESENTANTE"))
                If Not IsDBNull(dtr("Gerente")) Then GERENTE = m.ConvertText(dtr("GERENTE"))
                If Not IsDBNull(dtr("Email_Gerente")) Then EMAIL_GERENTE = m.ConvertText(dtr("EMAIL_GERENTE"))
                If Not IsDBNull(dtr("Endereco")) Then ENDERECO = m.ConvertText(dtr("ENDERECO"))
                If Not IsDBNull(dtr("Bairro")) Then BAIRRO = m.ConvertText(dtr("BAIRRO"))
                If Not IsDBNull(dtr("Complemento")) Then COMPLEMENTO = m.ConvertText(dtr("COMPLEMENTO"))
                If Not IsDBNull(dtr("Cidade")) Then CIDADE = m.ConvertText(dtr("CIDADE"))
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

        dts_MEDICOS.SelectCommand = "Select * from APP_MEDICOS_ESTABELECIMENTOS Where IdEstabelecimento  = '" & ID_ESTABELECIMENTO & "' And MEDICO_ATIVO_NO_ESTABELECIMENTO = 1 Order By NOME_SOBRENOME"
        dts_MEDICOS.DataBind()

    End Sub

End Class
