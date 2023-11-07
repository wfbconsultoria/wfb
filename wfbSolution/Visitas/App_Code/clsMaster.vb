Imports Microsoft.VisualBasic

Public Class clsMaster
    Public cnn As System.Data.SqlClient.SqlConnection

    'VARIAVEIS GLOBAIS DO SISTEMA CARREGADAS NO LOGIN
    'CONEXOES
    Public cnnStr As String = ConfigurationManager.ConnectionStrings("cnnStr").ToString
    'Public cnnCNES As String = ConfigurationManager.ConnectionStrings("cnnCNES").ToString
    'Public cnnMedicos As String = ConfigurationManager.ConnectionStrings("cnnMedicos").ToString
    'INFORMAÇÕES DE E-MAIL
    Public _EMAIL_SUPORTE As String = ConfigurationManager.AppSettings("EMAIL_SUPORTE").ToString
    Public _EMAIL_SISTEMA As String = ConfigurationManager.AppSettings("EMAIL_SISTEMA").ToString
    Public _EMAIL_ADMINISTRADOR As String = ConfigurationManager.AppSettings("EMAIL_ADMINISTRADOR").ToString
    Public _EMAIL_SMTP As String = ConfigurationManager.AppSettings("EMAIL_SMTP").ToString
    Public _SENHA_SMTP As String = ConfigurationManager.AppSettings("SENHA_SMTP").ToString
    Public _SMTP As String = ConfigurationManager.AppSettings("SMTP").ToString
    'INFORMAÇÕES DO SISTEMA
    Public _SIGLA As String = ConfigurationManager.AppSettings("SIGLA").ToString
    Public _CLIENTE As String = ConfigurationManager.AppSettings("CLIENTE").ToString
    Public _VERSAO_SISTEMA As String = ConfigurationManager.AppSettings("VERSAO_SISTEMA").ToString
    Public _NOME_SISTEMA As String = ConfigurationManager.AppSettings("NOME_SISTEMA").ToString


    Public Function ConectaBanco() As Boolean
        On Error GoTo Err_ConectaBanco
        ConectaBanco = False
        cnn = New System.Data.SqlClient.SqlConnection
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()
        ConectaBanco = True
        Exit Function
Err_ConectaBanco:
        ConectaBanco = False
    End Function

    Public Function ExecutarSQL_ReceitaFederal(ByVal SQL As String) As Boolean
        Dim cn As New System.Data.SqlClient.SqlConnection
        Dim cmd As System.Data.SqlClient.SqlCommand = cn.CreateCommand
        On Error GoTo Err_AbreTabela
        ExecutarSQL_ReceitaFederal = False
        cn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnReceitaFederal").ConnectionString
        cmd.CommandText = SQL
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        ExecutarSQL_ReceitaFederal = True
        Return True
        Exit Function
Err_AbreTabela:
        ExecutarSQL_ReceitaFederal = False
        Return False
    End Function
    Public Function ExecutarSQL(ByVal SQL As String) As Boolean
        Dim cn As New System.Data.SqlClient.SqlConnection
        Dim cmd As System.Data.SqlClient.SqlCommand = cn.CreateCommand
        On Error GoTo Err_AbreTabela
        ExecutarSQL = False
        cn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cmd.CommandText = SQL
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        ExecutarSQL = True
        Return True
        Exit Function
Err_AbreTabela:
        ExecutarSQL = False
        Return False
    End Function


    
    Public Function FormataData(ByVal ValorData As Double) As String
        'TRANSFORMA A DATA DO FORMATO NUMERICO EM UMA STRING NO FORMATO DD/MM/YYY HH:MM:SS
        FormataData = ""
        FormataData = FormataData & Mid(ValorData, 7, 2) & "/" 'DIA
        FormataData = FormataData & Mid(ValorData, 5, 2) & "/" 'MES
        FormataData = FormataData & Left(ValorData, 4) & " " 'ANO
        FormataData = FormataData & Mid(ValorData, 9, 2) & ":" 'HORA
        FormataData = FormataData & Mid(ValorData, 11, 2) & ":" 'MINUTO
        FormataData = FormataData & Right(ValorData, 2) 'SEGUNDO
    End Function
    Public Function RecuperaData() As String
        'RECUPERA A DATA DO SISTEMA NOW() E TRANSFORMA EM UM VALOR YYYYMMDDHHMMSS
        RecuperaData = ""
        RecuperaData = RecuperaData & Format(Year(Now), "0000") 'ANO
        RecuperaData = RecuperaData & Format(Month(Now), "00") 'MES
        RecuperaData = RecuperaData & Format(Day(Now), "00") 'DIA
        RecuperaData = RecuperaData & Format(Hour(Now), "00") 'HORA
        RecuperaData = RecuperaData & Format(Minute(Now), "00") 'MINUTO
        RecuperaData = RecuperaData & Format(Second(Now), "00") 'SEGUNDO
    End Function
    Public Function Converte_Valor(ByVal strValor As String) As String
        'LIMPA STRING QE VAO SER USADS COMO VALOR
        Converte_Valor = 0
        If strValor = "" Then strValor = "0"
        strValor = Replace(strValor, ".", "")
        strValor = Replace(strValor, "/", "")
        strValor = Replace(strValor, "\", "")
        strValor = Replace(strValor, "-", "")
        strValor = Replace(strValor, ",", "")
        strValor = Replace(strValor, " ", "")
        strValor = Replace(strValor, "'", "")
        strValor = Trim(strValor)
        Converte_Valor = Val(strValor)
    End Function
    
    Public Function ConverteTexto(ByVal Texto As String) As String
        'LIMPA CAACTERES INVALIDOS DO TEXTO E TRANSFORMA EM MAIUSCULO
        If IsDBNull(Texto) Then
            Texto = ""
        Else
            Texto = Trim(Texto)
            Texto = LCase(Texto)
            Texto = Replace(Texto, "á", "a")
            Texto = Replace(Texto, "à", "a")
            Texto = Replace(Texto, "ã", "a")
            Texto = Replace(Texto, "â", "a")
            Texto = Replace(Texto, "é", "e")
            Texto = Replace(Texto, "è", "e")
            Texto = Replace(Texto, "ê", "e")
            Texto = Replace(Texto, "í", "i")
            Texto = Replace(Texto, "ì", "i")
            Texto = Replace(Texto, "ó", "o")
            Texto = Replace(Texto, "ò", "o")
            Texto = Replace(Texto, "ô", "o")
            Texto = Replace(Texto, "õ", "o")
            Texto = Replace(Texto, "ú", "u")
            Texto = Replace(Texto, "ù", "u")
            Texto = Replace(Texto, "û", "u")
            Texto = Replace(Texto, "'", "")
            Texto = Replace(Texto, "~", "")
            Texto = Replace(Texto, ",", " ")
            Texto = Replace(Texto, "ç", "c")
            Texto = Replace(Texto, Chr(33), "")
            Texto = Replace(Texto, Chr(34), "")
            Texto = UCase(Texto)
        End If
        ConverteTexto = Texto
    End Function
    Public Sub EnviarEmail( _
        ByVal Assunto As String, _
        ByVal Mensagem As String, _
        ByVal Enviar_Suporte As Boolean, _
        ByVal Enviar_Administrador As Boolean, _
        ByVal Email1 As String, _
        ByVal Email2 As String _
        )
        Dim Para As String
        Dim objSmtp As New System.Net.Mail.SmtpClient
        Dim objEmail As New System.Net.Mail.MailMessage()
        Dim sqlEmail As String

        'Define o remetente do e-mail.
        objEmail.From = New System.Net.Mail.MailAddress(_EMAIL_SUPORTE, _NOME_SISTEMA)
        'Define o título do e-mail.
        objEmail.Subject = Assunto
        'Define o corpo do e-mail.
        objEmail.Body = Mensagem & Chr(10) & Chr(10) & Chr(10) & "E-mail enviado automaticamente por " & _NOME_SISTEMA & Chr(10)
        'Define a prioridade do e-mail.
        objEmail.Priority = System.Net.Mail.MailPriority.High
        'Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
        objEmail.IsBodyHtml = False
        'Para evitar problemas com caracteres "estranhos", configuramos o Charset para "ISO-8859-1"
        objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")
        objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")


        'Define os destinatários do e-mail Suporte e quem enviou
        Para = ""

        If Enviar_Suporte = True Then Para = Para & _EMAIL_SUPORTE & ","
        If Enviar_Administrador = True Then Para = Para & _EMAIL_ADMINISTRADOR & ","
        If Len(Email1) > 0 Then Para = Para & Email1 & ","
        If Len(Email2) > 0 Then Para = Para & Email2 & ","
        Para = Left(Para, (Len(Para) - 1))

        sqlEmail = ""
        sqlEmail = sqlEmail & " Insert into TBL_LOG_EMAIL(DATA, EMAIL_DE, EMAIL_PARA, ASSUNTO, MENSAGEM, STATUS) Values ("
        sqlEmail = sqlEmail & RecuperaData() & ", "
        sqlEmail = sqlEmail & " 'Sistema', "
        sqlEmail = sqlEmail & " '" & Para & "', "
        sqlEmail = sqlEmail & " '" & ConverteTexto(Assunto) & "', "
        sqlEmail = sqlEmail & " '" & ConverteTexto(Mensagem) & "', "
        objEmail.To.Add(Para)
        Try
            'CONFIGURAÇÕESDO E-MAIL DE ENVIO
            Dim c As New System.Net.NetworkCredential
            c.Password = _SENHA_SMTP
            c.UserName = _EMAIL_SMTP
            objSmtp.UseDefaultCredentials = False
            objSmtp.Credentials = c
            objSmtp.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            objSmtp.EnableSsl = True
            objSmtp.Port = 587
            objSmtp.Host = _SMTP
            objSmtp.Send(objEmail)
            sqlEmail = sqlEmail & " 'ENVIADO COM SUCESSO') "
        Catch ex As Exception
            objEmail.To.Clear()
            objEmail.To.Add(_EMAIL_SUPORTE)
            objEmail.Subject = "ERRO AO ENVIAR E-MAIL " & Assunto
            objEmail.Body = "Para: " & Para & Chr(10) & "Mensagem: " & Mensagem
            objSmtp.Send(objEmail)
            sqlEmail = sqlEmail & " 'FALHA NO ENVIO') "
        End Try
        ExecutarSQL(sqlEmail)
        'Excluímos o objeto de e-mail da memória
        objEmail.Dispose()
    End Sub
    Public Sub LogPagina(ByVal Sessao_Login As String, ByVal IP_Login As String, ByVal Email_Login As String, ByVal Pagina As String, ByVal Comando As String, ByVal Descricao As String)
        Dim sql As String

        'GRAVA LOG NA TABELA TBL_LOG_PAGINA ACESSO E COMANDOS EETUADOS NA PAGINA
        sql = ""
        sql = sql & " Insert Into TBL_LOG_PAGINA "
        sql = sql & " (SESSION_ID,IP,EMAIL,DATA,ANO,MES,DIA,HORA,MINUTO,SEGUNDO,PAGINA,COMANDO,DESCRICAO_COMANDO,VERSAO_SISTEMA) "
        sql = sql & " Values ("
        sql = sql & "'" & Sessao_Login & "', "
        sql = sql & "'" & IP_Login & "', "
        sql = sql & "'" & Email_Login & "', "
        sql = sql & RecuperaData() & ", "
        sql = sql & Left(RecuperaData, 4) & ", " 'ANO
        sql = sql & Mid(RecuperaData, 5, 2) & ", " 'MES
        sql = sql & Mid(RecuperaData, 7, 2) & ", " 'DIA
        sql = sql & Mid(RecuperaData, 9, 2) & ", " 'HORA
        sql = sql & Mid(RecuperaData, 11, 2) & ", " 'MINUTO
        sql = sql & Mid(RecuperaData, 13, 2) & ", " 'SEGUNDO
        sql = sql & "'" & Pagina & "', "
        sql = sql & "'" & Comando & "', "
        sql = sql & "'" & Descricao & "', "
        sql = sql & "'" & _VERSAO_SISTEMA & "')"
        ExecutarSQL(sql)
    End Sub
    Function GerarSenha() As String
        Dim TamanhoSenha As Integer, Codigo As String, Novo As String

        Codigo = ""
        TamanhoSenha = 8

        Dim Letra(26) As String

        Letra(0) = "A"
        Letra(1) = "B"
        Letra(2) = "C"
        Letra(3) = "D"
        Letra(4) = "E"
        Letra(5) = "F"
        Letra(6) = "G"
        Letra(7) = "H"
        Letra(8) = "I"
        Letra(9) = "J"
        Letra(10) = "K"
        Letra(11) = "L"
        Letra(12) = "M"
        Letra(13) = "N"
        Letra(14) = "O"
        Letra(15) = "P"
        Letra(16) = "Q"
        Letra(17) = "R"
        Letra(18) = "S"
        Letra(19) = "T"
        Letra(20) = "U"
        Letra(21) = "V"
        Letra(22) = "X"
        Letra(23) = "W"
        Letra(24) = "Y"
        Letra(25) = "Z"

        Randomize()

        Do While Len(Codigo) < TamanhoSenha
            Novo = Letra(Int(26 * Rnd()))
            Codigo = Codigo & Novo
        Loop

        GerarSenha = Codigo

    End Function
    Public Function Consiste_Exclusao(Parametro As String, Coluna As String, Tabela As String) As Double
        'Verifica se um determinado registro em uma determinada tabela pode ser excluido
        On Error GoTo Err_Consiste_Exclusao

        Dim cn As New System.Data.SqlClient.SqlConnection
        Dim cmd As System.Data.SqlClient.SqlCommand = cn.CreateCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String

        Consiste_Exclusao = 0
        cn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cn.Open()

        sql = ""
        sql = "Select Count ([" & Coluna & "]) as QTD_REGISTROS From [" & Tabela & "] Where " & Coluna & " = '" & Parametro & "'"
        cmd.Connection = cn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader

        If dtr.HasRows Then
            dtr.Read()
            Consiste_Exclusao = dtr("QTD_REGISTROS")
        End If
        dtr.Close()
        cn.Close()

        Exit Function
Err_Consiste_Exclusao:
        Consiste_Exclusao = -1
    End Function
End Class