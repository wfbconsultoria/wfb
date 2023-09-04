
Imports System.Net
Imports System.Net.Mail

Public Class clsMaster
    Public cnn As System.Data.SqlClient.SqlConnection
    Public cnnStr As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
    Public LojaSigla As String = ConfigurationManager.AppSettings("Loja_Sigla").ToString
    Public Loja As String = ConfigurationManager.AppSettings("Loja").ToString

    Public sqlLoja As String = "Select * From view_Lojas Where Sigla_Loja = '" & LojaSigla & "'"
    Public sqlAndar As String = "Select * From view_Andares Where Sigla_Loja = '" & LojaSigla & "'"
    Public sqlZona As String = "Select * From view_Zonas Where Sigla_Loja = '" & LojaSigla & "'"
    Public sqlUniverso As String = "Select * From view_Universos Where Sigla_Loja = '" & LojaSigla & "'"
    Public sqlPessoas As String = "Select * From view_Pessoas_Ativos Where Sigla_Loja = '" & LojaSigla & "'"

    Public sqlQtdPessoasLoja As String = "Select * From view_Qtd_Pessoas_01_Loja Where Sigla_Loja = '" & LojaSigla & "'"
    Public sqlQtdPessoasAndar As String = "Select * From view_Qtd_Pessoas_02_Andar Where Sigla_Loja = '" & LojaSigla & "'"
    Public sqlQtdPessoasZona As String = "Select * From view_Qtd_Pessoas_03_Zona Where Sigla_Loja = '" & LojaSigla & "'"
    Public sqlQtdPessoasUniverso As String = "Select * From view_Qtd_Pessoas_03_Universo Where Sigla_Loja = '" & LojaSigla & "'"
    Public sqlQtdPessoasTipo As String = "Select * From view_Qtd_Pessoas_05_Tipo Where Sigla_Loja = '" & LojaSigla & "'"
    Public sqlQtdPessoas As String = "Select * From view_Qtd_Pessoas_06_Pessoas Where Sigla_Loja = '" & LojaSigla & "'"

    Public Function DatabaseConnect() As Boolean
        On Error GoTo Err_DatabaseConnect

        DatabaseConnect = False
        cnn = New System.Data.SqlClient.SqlConnection
        cnn.ConnectionString = cnnStr
        cnn.Open()
        DatabaseConnect = True
        Exit Function

Err_DatabaseConnect:
        DatabaseConnect = False
        SystemError(Err.Number, Err.Description, "", "Function: clsMaster.DatabaseConnect")
    End Function
    Public Function ExecuteSQL(ByVal SQL As String) As Boolean
        On Error GoTo Err_ExecutarSQL
        ExecuteSQL = False
        If Not IsNothing(cnn) Then
            If cnn.State = ConnectionState.Open Then cnn.Close()
        End If
        DatabaseConnect()

        Dim cmd As System.Data.SqlClient.SqlCommand = cnn.CreateCommand
        cmd.CommandText = SQL
        cmd.ExecuteNonQuery()
        ExecuteSQL = True
        Exit Function

Err_ExecutarSQL:
        ExecuteSQL = False
        SystemError(Err.Number, Err.Description, SQL, "Function: clsMaster.ExecuteSQL")
    End Function

    Public Function strSQL(ByVal SQL As String, Optional Ordem As String = "", Optional Onde As String = "") As String

        If SQL = "qtdPessoas" Then SQL = sqlQtdPessoas
        If SQL = "qtdPessoasTipo" Then SQL = sqlQtdPessoasTipo
        If SQL = "qtdPessoasUniverso" Then SQL = sqlQtdPessoasUniverso
        If SQL = "qtdPessoasZona" Then SQL = sqlQtdPessoasZona
        If SQL = "qtdPessoasAndar" Then SQL = sqlQtdPessoasAndar
        If SQL = "qtdPessoasLoja" Then SQL = sqlQtdPessoasLoja

        If SQL = "Universo" Then SQL = sqlLoja
        If SQL = "Zona" Then SQL = sqlZona
        If SQL = "Andar" Then SQL = sqlAndar
        If SQL = "Loja" Then SQL = sqlLoja
        If SQL = "Pessoas" Then SQL = sqlPessoas

        If Onde <> "" And Len(Onde) > 0 Then SQL = SQL & " and '" & Onde & "' "
        If Ordem <> "" And Len(Ordem) > 0 Then SQL = SQL & " Order By [" & Ordem & "] "

        strSQL = SQL

    End Function
    Public Function ExecuteSelect(ByVal SQL As String, Optional Ordem As String = "", Optional Onde As String = "") As System.Data.SqlClient.SqlDataReader
        On Error GoTo Err_ExcuteSelect
        ExecuteSelect = Nothing

        If Not IsNothing(cnn) Then
            If cnn.State = ConnectionState.Open Then cnn.Close()
        End If

        DatabaseConnect()
        If SQL = "qtdPessoas" Then SQL = sqlQtdPessoas
        If SQL = "qtdPessoasTipo" Then SQL = sqlQtdPessoasTipo
        If SQL = "qtdPessoasUniverso" Then SQL = sqlQtdPessoasUniverso
        If SQL = "qtdPessoasZona" Then SQL = sqlQtdPessoasZona
        If SQL = "qtdPessoasAndar" Then SQL = sqlQtdPessoasAndar
        If SQL = "qtdPessoasLoja" Then SQL = sqlQtdPessoasLoja

        If SQL = "Universo" Then SQL = sqlLoja
        If SQL = "Zona" Then SQL = sqlZona
        If SQL = "Andar" Then SQL = sqlAndar
        If SQL = "Loja" Then SQL = sqlLoja
        If SQL = "Pessoas" Then SQL = sqlPessoas

        If Onde <> "" And Len(Onde) > 0 Then SQL = SQL & " and '" & Onde & "' "
        If Ordem <> "" And Len(Ordem) > 0 Then SQL = SQL & " Order By [" & Ordem & "] "

        Dim cmd As System.Data.SqlClient.SqlCommand = cnn.CreateCommand
        cmd.Connection = cnn
        cmd.CommandText = SQL
        ExecuteSelect = cmd.ExecuteReader
        Exit Function

Err_ExcuteSelect:
        ExecuteSelect = Nothing
        SystemError(Err.Number, Err.Description, SQL, "Function: clsMaster.ExecuteSelect")
    End Function

    Public Function CheckExists(ByVal Table As String, ByVal KeyColumn As String, ByVal Parameter As String) As Boolean
        On Error GoTo Err_CheckExists

        CheckExists = False
        Dim d As System.Data.SqlClient.SqlDataReader
        Dim sql As String

        sql = "Select * From [" & Table & "] Where [" & KeyColumn & "] = '" & Parameter & "'"
        d = ExecuteSelect(sql)

        If d.HasRows Then CheckExists = True

        Exit Function

Err_CheckExists:
        CheckExists = False
        SystemError(Err.Number, Err.Description, sql, "Function: clsMaster.CheckExists")
    End Function

    'Função para página de erro
    Public Function SystemError(ErrNUmber As String, ErrDescription As String, ErrMessage As String, ErrLocation As String) As String
        Dim EmailMessage As String = ""
        Dim UrlError = ""
        SystemError = ""
        UrlError = UrlError & "ErrNumber=" & ErrNUmber & "&ErrDescription=" & ErrDescription & "&ErrMessage=" & ErrMessage & "&ErrLocation=" & ErrLocation
        UrlError = Replace(UrlError, Chr(10), " ")
        SystemError = UrlError
        SendMail(ConfigurationManager.AppSettings("App.Support.Email").ToString, "Suporte Decathlon Chapeira Digital", ErrLocation, ErrMessage)
        HttpContext.Current.Response.Redirect("PageError.aspx?" & UrlError)
    End Function
    Public Function Percentual(Valor As Double, Divisor As Double) As Decimal
        Dim pPercentual As Decimal
        Try
            pPercentual = Valor / Divisor
            Return pPercentual
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function ConvertDate(ByVal Text As String) As String
        Dim StrDate As String = ""
        ConvertDate = ""
        If IsDBNull(Text) Then
            Text = ""
        Else
            StrDate = Right(Text, 4) & "-"
            StrDate = StrDate & Mid(Text, 4, 2) & "-"
            StrDate = StrDate & Left(Text, 2)
        End If

        Return StrDate
    End Function
    Public Function ConvertDateToString(strDate As Date) As String
        strDate = strDate & Year(Now()) & "-"
        strDate = strDate & Month(Now()) & "-"
        strDate = strDate & Day(Now())
        Return strDate
    End Function

    Public Function ConvertCPFToString(ByVal strCPF As String) As String
        Dim apenasDigitos = New Regex("[^\d]")
        Return apenasDigitos.Replace(strCPF, "")
    End Function

    Public Function ConvertText(ByVal Text As String, TextCase As TextCaseOptions) As String
        ConvertText = ""
        If IsDBNull(Text) Then
            Text = ""
        Else
            Text = Trim(Text)
            Text = Replace(Text, "á", "a")
            Text = Replace(Text, "à", "a")
            Text = Replace(Text, "ã", "a")
            Text = Replace(Text, "â", "a")
            Text = Replace(Text, "é", "e")
            Text = Replace(Text, "è", "e")
            Text = Replace(Text, "ê", "e")
            Text = Replace(Text, "í", "i")
            Text = Replace(Text, "ì", "i")
            Text = Replace(Text, "ó", "o")
            Text = Replace(Text, "ò", "o")
            Text = Replace(Text, "ô", "o")
            Text = Replace(Text, "õ", "o")
            Text = Replace(Text, "ú", "u")
            Text = Replace(Text, "ù", "u")
            Text = Replace(Text, "û", "u")
            Text = Replace(Text, "~", "")
            Text = Replace(Text, ",", " ")
            Text = Replace(Text, "ç", "c")
            Text = Replace(Text, Chr(10), " ") 'LIMPA ASPAS
            Text = Replace(Text, Chr(34), " ") 'LIMPA ASPAS
            Text = Replace(Text, Chr(39), "") 'LIMPA APOSTROFE

            If TextCase = TextCaseOptions.UpperCase Then Text = UCase(Text)
            If TextCase = TextCaseOptions.LowerCase Then Text = LCase(Text)
            If TextCase = TextCaseOptions.TextCase Then Text = Text

        End If
        ConvertText = Trim(Text)
    End Function
    Public Enum TextCaseOptions
        UpperCase
        LowerCase
        TextCase
    End Enum
    Public Function SendMail(MailToAddress As String, MailToName As String, MailSubject As String, MailMessage As String) As Boolean
        On Error GoTo Err_SendMail
        SendMail = False

        Dim credentials = New NetworkCredential(ConfigurationManager.AppSettings("App.SMTP.user").ToString, ConfigurationManager.AppSettings("App.SMTP.password").ToString)
        Dim smtp = New SmtpClient
        Dim msgFrom As New MailAddress(ConfigurationManager.AppSettings("App.MailFrom").ToString, ConfigurationManager.AppSettings("App.Name").ToString)
        Dim msgTo As New MailAddress(MailToAddress, MailToName)
        Dim msg As New MailMessage(msgFrom, msgTo)

        smtp.Host = ConfigurationManager.AppSettings("App.SMTP.host").ToString
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network
        smtp.UseDefaultCredentials = False
        smtp.Port = ConfigurationManager.AppSettings("App.SMTP.port")
        smtp.Credentials = credentials

        msg.Subject = MailSubject
        msg.IsBodyHtml = True
        msg.Body = "<h2>" & MailSubject & "</h2> <br/> <h3>" & MailMessage & "</h3>"

        smtp.Send(msg)

        SendMail = True
        Exit Function
Err_SendMail:
        SendMail = False
    End Function

    Public Function Alert(MyPage As Page, Mensagem As String, Optional Redirecionar As Boolean = False, Optional ParaPagina As String = "") As Boolean
        On Error GoTo Err_Alert

        Alert = False
        Dim jscript As String
        'CAIXA DE MENSAGEM
        If Redirecionar = True Then
            jscript = ""
            jscript += "<script language='JavaScript'>"
            jscript += ";alert('" & Mensagem & "'); document.location.href='" & ParaPagina & "'"
            jscript += "</script>"
        Else
            jscript = ""
            jscript += "<script language='JavaScript'>"
            jscript += ";alert('" & Mensagem & "');"
            jscript += "</script>"
        End If
        MyPage.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Mensagem", jscript)

        Alert = True
        Exit Function
Err_Alert:
        Alert = False
    End Function

End Class


