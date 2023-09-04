
Public Class clsValidate
    Public Function IsValidEmail(ByVal email As String) As Boolean
        Dim padraoRegex As String = "^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\." &
            "(com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$"
        Dim verifica As New RegularExpressions.Regex(padraoRegex, RegexOptions.IgnorePatternWhitespace)
        Dim valida As Boolean = False
        'verifica se foi informado um email
        If String.IsNullOrEmpty(email) Then
            valida = False
        Else
            'usar IsMatch para validar o email
            valida = verifica.IsMatch(email)
        End If
        'retorna o valor
        Return valida
    End Function
    Public Function IsValidIP(ByVal ip As String) As Boolean
        'cria o padrão regex
        Dim padraoRegex As String = "^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\." &
            "([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$"
        'cria o objeto Regex
        Dim verifica As New RegularExpressions.Regex(padraoRegex)
        'variavel boolean para tratar o status
        Dim valida As Boolean = False
        'verifica se o recurso foi fornecido
        If ip = "" Then
            'ip invalido
            valida = False
        Else
            'usa o método IsMatch Method para validar o regex
            valida = verifica.IsMatch(ip, 0)
        End If
        Return valida
    End Function
    Public Function isValidCep(ByVal cep As String) As Boolean
        'cria o padrão regex
        Dim padraoRegex As String = "^\d{5}-\d{3}$"
        Dim verifica As New RegularExpressions.Regex(padraoRegex)
        'variavel boolean para tratar o status
        Dim valida As Boolean = False
        'verifica se o recurso foi fornecido
        If cep = "" Then
            'cep invalido
            valida = False
        Else
            'usa o método IsMatch Method para validar o regex
            valida = verifica.IsMatch(cep, 0)
        End If
        Return valida
    End Function
    Public Function isValidSoNumeros(ByVal sonumeros As String) As Boolean
        'cria o padrão regex
        Dim padraoRegex As String = "^[0-9]*$"
        Dim verifica As New RegularExpressions.Regex(padraoRegex)
        'variavel boolean para tratar o status
        Dim valida As Boolean = False
        'verifica se o recurso foi fornecido
        If sonumeros = "" Then
            'cep invalido
            valida = False
        Else
            'usa o método IsMatch Method para validar o regex
            valida = verifica.IsMatch(sonumeros, 0)
        End If
        Return valida
    End Function
    Public Function isValidTelefone(ByVal telefone As String) As Boolean
        'cria o padrão regex
        '^\d{2}-\d{4}-\d{4}$ 
        Dim padraoRegex As String = "^[0-9]{2}-[0-9]{4}-[0-9]{4}$"
        'cria o objeto Regex
        Dim verifica As New RegularExpressions.Regex(padraoRegex)
        'variavel boolean para tratar o status
        Dim valida As Boolean = False
        'verifica se o recurso foi fornecido
        If telefone = "" Then
            'telefone invalido
            valida = False
        Else
            'usa o método IsMatch Method para validar o regex
            valida = verifica.IsMatch(telefone, 0)
        End If
        Return valida
    End Function
    Public Function isValidDataDDMMYYYY(ByVal ddmmyyyy As String) As Boolean
        'cria o padrão regex
        Dim padraoRegex As String = "^((0[1-9]|[12]\d)\/(0[1-9]|1[0-2])|30\/(0[13-9]|1[0-2])|31\/(0[13578]|1[02]))\/\d{4}$"
        Dim verifica As New RegularExpressions.Regex(padraoRegex)
        'variavel boolean para tratar o status
        Dim valida As Boolean = False
        'verifica se o recurso foi fornecido
        If ddmmyyyy = "" Then
            'telefone invalido
            valida = False
        Else
            'usa o método IsMatch Method para validar o regex
            valida = verifica.IsMatch(ddmmyyyy, 0)
        End If
        'return the results
        Return valida
    End Function
    Public Function isValidUrl(ByVal url As String) As Boolean
        'cria o padrão regex
        Dim padraoRegex As String = "^((http)|(https)|(ftp)):\/\/([\- \w]+\.)+\w{2,3}(\/ [%\-\w]+(\.\w{2,})?)*$"
        Dim verifica As New RegularExpressions.Regex(padraoRegex)
        Dim valida As Boolean = False
        If url = "" Then
            'telefone invalido
            valida = False
        Else
            valida = verifica.IsMatch(url, 0)
        End If
        Return valida
    End Function
    Public Function isValidCNPJ(ByVal cnpj As String) As Boolean
        Dim padraoRegex As String = "^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$"
        Dim verifica As New RegularExpressions.Regex(padraoRegex)
        Dim valida As Boolean = False
        If cnpj = "" Then
            valida = False
        Else
            valida = verifica.IsMatch(cnpj, 0)
        End If
        Return valida
    End Function
    Public Function ValidarCpf(ByVal cpf As String) As Boolean
        cpf = cpf.Replace("-", "")
        cpf = cpf.Replace(".", "")

        Dim reg As New Regex("(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)")
        If Not reg.IsMatch(cpf) Then
            Return False
        End If

        Dim d1 As Integer, d2 As Integer
        Dim soma As Integer = 0
        Dim digitado As String = ""
        Dim calculado As String = ""

        ' Pesos para calcular o primeiro digito
        Dim peso1 As Integer() = New Integer() {10, 9, 8, 7, 6, 5, 4, 3, 2}

        ' Pesos para calcular o segundo digito
        Dim peso2 As Integer() = New Integer() {11, 10, 9, 8, 7, 6, 5, 4, 3, 2}

        Dim n As Integer() = New Integer(10) {}

        Dim retorno As Boolean = False

        ' Limpa a string
        cpf = cpf.Replace(".", "").Replace("-", "").Replace("/", "").Replace("\", "")

        ' Se o tamanho for < 11 entao retorna como inválido
        If cpf.Length <> 11 Then
            Return False
        End If

        ' Caso coloque todos os numeros iguais
        Select Case cpf

            Case "11111111111"
                Return False
            Case "00000000000"
                Return False
            Case "2222222222"
                Return False
            Case "33333333333"
                Return False
            Case "44444444444"
                Return False
            Case "55555555555"
                Return False
            Case "66666666666"
                Return False
            Case "77777777777"
                Return False
            Case "88888888888"
                Return False
            Case "99999999999"
                Return False
        End Select

        Try
            ' Quebra cada digito do CPF
            n(0) = Convert.ToInt32(cpf.Substring(0, 1))
            n(1) = Convert.ToInt32(cpf.Substring(1, 1))
            n(2) = Convert.ToInt32(cpf.Substring(2, 1))
            n(3) = Convert.ToInt32(cpf.Substring(3, 1))
            n(4) = Convert.ToInt32(cpf.Substring(4, 1))
            n(5) = Convert.ToInt32(cpf.Substring(5, 1))
            n(6) = Convert.ToInt32(cpf.Substring(6, 1))
            n(7) = Convert.ToInt32(cpf.Substring(7, 1))
            n(8) = Convert.ToInt32(cpf.Substring(8, 1))
            n(9) = Convert.ToInt32(cpf.Substring(9, 1))
            n(10) = Convert.ToInt32(cpf.Substring(10, 1))
        Catch
            Return False
        End Try

        ' Calcula cada digito com seu respectivo peso
        For i As Integer = 0 To peso1.GetUpperBound(0)
            soma += (peso1(i) * Convert.ToInt32(n(i)))
        Next

        ' Pega o resto da divisao
        Dim resto As Integer = soma Mod 11

        If resto = 1 OrElse resto = 0 Then
            d1 = 0
        Else
            d1 = 11 - resto
        End If

        soma = 0

        ' Calcula cada digito com seu respectivo peso
        For i As Integer = 0 To peso2.GetUpperBound(0)
            soma += (peso2(i) * Convert.ToInt32(n(i)))
        Next

        ' Pega o resto da divisao
        resto = soma Mod 11

        If resto = 1 OrElse resto = 0 Then
            d2 = 0
        Else
            d2 = 11 - resto
        End If

        calculado = d1.ToString() + d2.ToString()
        digitado = n(9).ToString() + n(10).ToString()

        ' Se os ultimos dois digitos calculados bater com
        ' os dois ultimos digitos do cpf entao é válido
        If calculado = digitado Then
            retorno = True
        Else
            retorno = False
        End If

        Return retorno
    End Function
End Class

