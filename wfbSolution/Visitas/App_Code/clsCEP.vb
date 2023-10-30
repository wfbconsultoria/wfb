Imports Microsoft.VisualBasic
'IMPORTS PARA BUSCA DE CEP
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Collections.Generic
Imports System.ComponentModel

'Chave do site www.buscar.cep.com.br
'Chave: 1L82P5R15nBp28Q2Vpx747CAa9RnPD0
'Seu link ficará assim:
'XML: http://www.buscarcep.com.br/?cep=CEP_AQUI&formato=xml&chave=1L82P5R15nBp28Q2Vpx747CAa9RnPD0
'STRING: http://www.buscarcep.com.br/?cep=CEP_AQUI&formato=string&chave=1L82P5R15nBp28Q2Vpx747CAa9RnPD0

Public Class clsCEP
    Public Class DadosEndereco
        Private _cep As String
        Private _uf As String
        Private _cidade As String
        Private _bairro As String
        Private _tipo_logradouro As String
        Private _logradouro As String
        Private _resultado As String
        Private _resultado_txt As String

        Public Sub New( _
                    ByVal cep As String, _
                    ByVal uf As String, _
                    ByVal cidade As String, _
                    ByVal bairro As String, _
                    ByVal tipo_logradouro As String, _
                    ByVal logradouro As String, _
                    ByVal resultado As String)

            Me.Cep = cep
            Me.Uf = uf
            Me.Cidade = cidade
            Me.Bairro = bairro
            Me.Tipo_logradouro = tipo_logradouro
            Me.Logradouro = logradouro
            Me.Resultado = resultado

        End Sub

        Public Property Cep() As String
            Get
                Return _cep
            End Get
            Set(ByVal Valor As String)
                _cep = Valor
            End Set
        End Property

        Public Property Uf() As String
            Get
                Return _uf
            End Get
            Set(ByVal Valor As String)
                _uf = Valor
            End Set
        End Property

        Public Property Cidade() As String
            Get
                Return _cidade
            End Get
            Set(ByVal Valor As String)
                _cidade = Valor
            End Set
        End Property

        Public Property Bairro() As String
            Get
                Return _bairro
            End Get
            Set(ByVal Valor As String)
                _bairro = Valor
            End Set
        End Property

        Public Property Tipo_logradouro() As String
            Get
                Return _tipo_logradouro
            End Get
            Set(ByVal Valor As String)
                _tipo_logradouro = Valor
            End Set
        End Property

        Public Property Logradouro() As String
            Get
                Return _logradouro
            End Get
            Set(ByVal Valor As String)
                _logradouro = Valor
            End Set
        End Property

        Public Property Resultado() As String
            Get
                Return _resultado
            End Get
            Set(ByVal Valor As String)
                _resultado = Valor
            End Set
        End Property

    End Class

    Public Function ConsultaEndereco(ByVal txtCep As String) As List(Of DadosEndereco)
        Dim link As String = "http://www.buscarcep.com.br/?cep=" + txtCep + "&formato=string"
        Dim web As New Net.WebClient()
        Dim retorno As String = Web.DownloadString(link)
        Dim lista As String() = retorno.Split("&")

        Dim cep As String
        Dim uf As String
        Dim cidade As String
        Dim bairro As String
        Dim tipo_logradouro As String
        Dim logradouro As String
        Dim resultado As String = ""
        Dim Cod_Municipio As String = ""
        If lista(1).Substring(0, 9) = "resultado" Then

            resultado = lista(1).Substring(10, lista(1).Length - 10)
            cep = ""
            uf = ""
            cidade = ""
            bairro = ""
            tipo_logradouro = ""
            logradouro = ""

        Else
            ' CEP OK
            cep = lista(1).Substring(4, lista(1).Length - 4)
            uf = lista(2).Substring(3, lista(2).Length - 3)
            cidade = lista(3).Substring(7, lista(3).Length - 7)
            bairro = lista(4).Substring(7, lista(4).Length - 7)
            tipo_logradouro = lista(5).Substring(16, lista(5).Length - 16)
            logradouro = lista(6).Substring(11, lista(6).Length - 11)
            resultado = lista(8).Substring(10, lista(8).Length - 10)
            Cod_Municipio = lista(12).Substring(14, lista(12).Length - 14)
        End If
        Dim listaResult As New List(Of DadosEndereco)

        listaResult.Add(New DadosEndereco(cep.ToString(), _
                        uf.ToString(), _
                        cidade.ToString(), _
                        bairro.ToString(), _
                        tipo_logradouro.ToString(), _
                        logradouro.ToString(), _
                        resultado.ToString()))

        Return listaResult
    End Function

End Class

