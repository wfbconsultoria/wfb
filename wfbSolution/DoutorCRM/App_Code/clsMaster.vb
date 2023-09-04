

Imports DoutorCRM

Public Class clsMaster
    Public cnn As Data.SqlClient.SqlConnection

    Public Function DatabaseConnect() As Boolean
        On Error GoTo Err_DatabaseConnect

        DatabaseConnect = False
        cnn = New Data.SqlClient.SqlConnection
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        cnn.Open()
        DatabaseConnect = True
        Exit Function

Err_DatabaseConnect:
        DatabaseConnect = False
        'SystemError(Err.Number, Err.Description, "", "Function: clsMaster.DatabaseConnect")
    End Function
    Public Function ExecuteSQL(ByVal SQL As String) As Boolean
        On Error GoTo Err_ExecutarSQL
        ExecuteSQL = False
        If Not IsNothing(cnn) Then
            If cnn.State = Data.ConnectionState.Open Then cnn.Close()
        End If

        DatabaseConnect()

        Dim cmd As System.Data.SqlClient.SqlCommand = cnn.CreateCommand
        cmd.CommandText = SQL
        cmd.ExecuteNonQuery()
        ExecuteSQL = True
        Exit Function

Err_ExecutarSQL:
        ExecuteSQL = False
        'SystemError(Err.Number, Err.Description, SQL, "Function: clsMaster.ExecuteSQL")
    End Function
    Public Function ExecuteSelect(ByVal SQL As String) As System.Data.SqlClient.SqlDataReader
        On Error GoTo Err_ExcuteSelect
        ExecuteSelect = Nothing

        If Not IsNothing(cnn) Then
            If cnn.State = Data.ConnectionState.Open Then cnn.Close()
        End If

        DatabaseConnect()

        Dim cmd As System.Data.SqlClient.SqlCommand = cnn.CreateCommand
        cmd.Connection = cnn
        cmd.CommandText = SQL
        ExecuteSelect = cmd.ExecuteReader
        Exit Function

Err_ExcuteSelect:

        ExecuteSelect = Nothing
        'SystemError(Err.Number, Err.Description, SQL, "Function: clsMaster.ExecuteSelect")
    End Function
    Public Function CheckExists(ByVal Table As String, ByVal KeyColumn As String, ByVal Parameter As String) As Boolean
        On Error GoTo Err_CheckExists

        CheckExists = False
        Dim d As Data.SqlClient.SqlDataReader
        Dim sql As String

        sql = "Select * From [" & Table & "] Where [" & KeyColumn & "] = '" & Parameter & "'"
        d = ExecuteSelect(sql)

        If d.HasRows Then CheckExists = True

        Exit Function

Err_CheckExists:
        CheckExists = False
        'SystemError(Err.Number, Err.Description, sql, "Function: clsMaster.CheckExists")
    End Function

    Public Function CheckLogin(Optional Redirect As Boolean = True, Optional PageTarget As String = "") As Boolean
        If IsNothing(HttpContext.Current.Session("EMAIL_LOGIN")) Or HttpContext.Current.Session("EMAIL_LOGIN") = "" Then
            CheckLogin = False
            If Redirect = True Then
                If PageTarget <> "" Then
                    HttpContext.Current.Response.Redirect(PageTarget)
                Else
                    HttpContext.Current.Response.Redirect("Default.aspx")
                End If
            End If
        Else
            CheckLogin = True
        End If
    End Function

    Public Function ConvertText(ByVal Text As String) As String
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
        End If
        ConvertText = Trim(Text)
    End Function
    Public Function GetDateToString() As String
        Dim UnivDate As Date = Now()
        Dim LocalDate As Date = TimeZoneInfo.ConvertTime(Date.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"))
        Dim strDate As String = ""

        strDate = strDate & Format(Day(LocalDate), "00") & "-"
        strDate = strDate & Format(Month(LocalDate), "00") & "-"
        strDate = strDate & Format(Year(LocalDate), "00")
        Return strDate

    End Function
    Public Function FormatCRM(CRM As String) As String
        CRM = Replace(CRM, " ", "")
        If IsDBNull(CRM) Or CRM = "" Or Len(Trim(CRM)) = 0 Then
            FormatCRM = "0000000"
        Else
            FormatCRM = Right("0000000" & CRM, 7)
        End If
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
    Public Function ConsultaCEP(ByVal strCEP As String) As svcCEP.CEP1
        Dim cCEP As New svcCEP.CEP1
        Dim credenciais As New svcCEP.Credenciais With {.Email = ConfigurationManager.AppSettings("SoaWebServices.User"), .Senha = ConfigurationManager.AppSettings("SoaWebServices.Password")}
        Dim wsCEP As New svcCEP.CEP

        Try
            cCEP = wsCEP.ConsultaCEP(credenciais, strCEP)
        Catch ex As Exception

        End Try

        Return cCEP
    End Function
    Public Function ConsultaPessoaFisicaSimplificada(ByVal Documento As String, ByVal DataNascimento As String) As svcCDC.PessoaFisicaSimplificada
        Dim pf As New svcCDC.PessoaFisicaSimplificada
        Dim credenciais As New svcCDC.Credenciais With {.Email = ConfigurationManager.AppSettings("SoaWebServices.User"), .Senha = ConfigurationManager.AppSettings("SoaWebServices.Password")}
        Dim wsPessoaFisicaSimplificada As New svcCDC.CDC

        Try
            pf = wsPessoaFisicaSimplificada.PessoaFisicaSimplificada(credenciais, Documento, DataNascimento)
        Catch ex As Exception

        End Try

        Return pf
    End Function
End Class
