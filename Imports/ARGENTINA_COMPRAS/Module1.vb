
Imports System.IO
Imports System.Text
Imports OpenQA.Selenium.IE
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Support.UI
Imports Microsoft.VisualBasic.FileIO
Imports SeleniumExtras.WaitHelpers

Module Module1
    Public titulo_aplicacao As String = "ARGENTINA - LICITACOES IMPORT"
    Public cnnStr As String = "Server=miro.bihospitalar.com.br;Port=5432;UserId=postgres;Password=@Mepm2412;Database=bih_datasus"
    Public cnn As New Npgsql.NpgsqlConnection
    Public cnn2 As New Npgsql.NpgsqlConnection
    Public schema As String = "ARGENTINA"
    Public tabela As String = "TBL_PROCESSOS"
    Public strSql As String = ""
    Public erros As Integer = 0
    Public tentativas As String
    Public mensagem_log As String


    Sub Main()
        Console.Title = "ARGENTINA - GET PROCESS URL - Inicio " & Now()
        Try

            Dim driver As IWebDriver
            driver = New ChromeDriver
            Dim wait As WebDriverWait = New WebDriverWait(driver, TimeSpan.FromSeconds(5))
            Dim txt_Numero_Processo As WebElement
            Dim btn_Localizar_Processo As WebElement
            Dim lnk_Processo As IWebElement



            Dim sql As String = ""
            sql &= " Select * From [ARGENTINA].[TBL_PROCESSOS] "
            sql &= " Where [ADJUDICADO] = 1 AND [URL_PROCESSO] IS NULL ORDER BY [ANO] DESC, [MES] DESC "
            Dim dtr As Npgsql.NpgsqlDataReader = ExecuteSelect(sql)
            Dim NUMERO_PROCESSO As String = ""
            Dim URL_PROCESSO As String = ""

            If dtr.HasRows Then

                Do While dtr.Read()
                    NUMERO_PROCESSO = dtr("Número de Proceso")
                    URL_PROCESSO = ""
                    driver.Navigate().GoToUrl("https://comprar.gob.ar/BuscarAvanzado.aspx")

                    tentativas = 0
                    Try
STEP_txt_Numero_Processo:
                        tentativas = tentativas + 1
                        'lnk_Processo = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ctl00_CPH1_GridListaPliegos_ctl02_lnkNumeroProceso")))
                        txt_Numero_Processo = wait.Until(ExpectedConditions.ElementExists(By.Id("ctl00_CPH1_txtNumeroProceso")))
                        txt_Numero_Processo.Clear()
                        txt_Numero_Processo.SendKeys(NUMERO_PROCESSO)
                    Catch
                        If tentativas > 10 Then GoTo PROXIMO_Processo
                        GoTo STEP_txt_Numero_Processo
                    End Try
                    tentativas = 0
                    Try
STEP_btn_Localizar_Processo:
                        tentativas = tentativas + 1
                        'btn_Localizar_Processo = driver.FindElement(By.Id("ctl00_CPH1_btnListarPliegoNumero"))
                        btn_Localizar_Processo = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ctl00_CPH1_btnListarPliegoNumero")))
                        btn_Localizar_Processo.Click()
                    Catch
                        If tentativas > 10 Then GoTo PROXIMO_Processo
                        GoTo STEP_btn_Localizar_Processo
                    End Try

                    tentativas = 0
                    Try
STEP_lnk_Processo:
                        tentativas = tentativas + 1
                        lnk_Processo = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ctl00_CPH1_GridListaPliegos_ctl02_lnkNumeroProceso")))
                        lnk_Processo.Click()
                    Catch
                        If tentativas > 10 Then GoTo PROXIMO_Processo
                        GoTo STEP_lnk_Processo
                    End Try

                    tentativas = 0
                    Try
STEP_url_Processo:
                        tentativas = tentativas + 1

                        'lnk_Processo = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ctl00_CPH1_UCVistaPreviaPliego_usrCabeceraPliego_lblNumPliego")))
                        txt_Numero_Processo = wait.Until(ExpectedConditions.ElementExists(By.Id("ctl00_CPH1_UCVistaPreviaPliego_usrCabeceraPliego_lblNumPliego")))
                        URL_PROCESSO = driver.Url
                        sql = "Update [ARGENTINA].[TBL_PROCESSOS] Set [URL_PROCESSO] = '" & URL_PROCESSO & "' Where [Número de Proceso] = '" & NUMERO_PROCESSO & "'"
                        ExecuteSQL(sql)
                        Mensagem(URL_PROCESSO)
                    Catch
                        If tentativas > 10 Then GoTo PROXIMO_Processo
                        GoTo STEP_url_Processo
                    End Try
PROXIMO_Processo:
                Loop
                Mensagem("SUCESSO - URL DE PROCESSOS RECUPERADAS COM SUCESSO")
            Else
                Mensagem("ERRO - TABELA DE PROCESSOS ESTÁ VAZIA")
            End If


        Catch exc As Exception
            LogErro(exc)
        Finally

    End Try
    End Sub

    Function ConectaBanco() As Boolean
        Try
            'Conexão Postgres
            cnn = New Npgsql.NpgsqlConnection(cnnStr)
            cnn.Open()
            ConectaBanco = True
        Catch e As Exception
            Console.BackgroundColor = ConsoleColor.Red
            Mensagem("ERRO CONEXÃO BANCO DE DADOS")
            Console.BackgroundColor = ConsoleColor.Black
            LogErro(e)
            ConectaBanco = False
        End Try
    End Function

    Public Function ExecuteSQL(SQL As String) As Boolean
        SQL = ConverteSQL_PSQL(SQL)
        Try
            ExecuteSQL = False
            cnn2 = New Npgsql.NpgsqlConnection(cnnStr)
            cnn2.Open()

            Dim cmd2 As Npgsql.NpgsqlCommand = cnn2.CreateCommand
            cmd2.CommandText = SQL
            cmd2.ExecuteNonQuery()
            ExecuteSQL = True
        Catch e As Exception
            ExecuteSQL = False
            LogErro(e, SQL)
        Finally
            cnn2.Close()
        End Try

    End Function
    Public Function ExecuteSelect(SQL As String) As Npgsql.NpgsqlDataReader
        SQL = ConverteSQL_PSQL(SQL)
        Try
            If Not IsNothing(cnn) Then
                If cnn.State = Data.ConnectionState.Open Then cnn.Close()
            End If
            ConectaBanco()
            Dim cmd As Npgsql.NpgsqlCommand = cnn.CreateCommand
            cmd.Connection = cnn
            cmd.CommandText = SQL
            ExecuteSelect = cmd.ExecuteReader
        Catch e As Exception
            LogErro(e)
            ExecuteSelect = Nothing
        End Try

    End Function

    Function ConverteSQL_PSQL(SQL As String) As String
        Try
            SQL = Replace(SQL, "[", Chr(34))
            SQL = Replace(SQL, "]", Chr(34))
        Catch
            SQL = ""
        End Try
        ConverteSQL_PSQL = SQL
    End Function
    Sub Mensagem(mensagem As String)
        Console.WriteLine(mensagem)
        mensagem_log = mensagem_log & mensagem & vbCrLf
    End Sub
    Public Sub LogErro(e As Exception, Optional mensagem_erro As String = "")
        erros = erros + 1
        Console.BackgroundColor = ConsoleColor.Red
        If mensagem_erro = "" Then
            Mensagem("ERRO " & Format(erros, "000000") & "; " & Replace(e.Message.ToString, vbCrLf, " "))
        Else
            Mensagem("ERRO " & Format(erros, "000000") & "; " & Replace(e.Message.ToString, vbCrLf, " ") & "; " & mensagem_erro)
        End If

        Console.BackgroundColor = ConsoleColor.Black
    End Sub

    Function Agora() As String
        Agora = Now().Year & "-" & Now.Month & "-" & Now().Day
    End Function
    Function TimeStamp() As String
        TimeStamp = Format(Now.Year, "0000") & "-" & Format(Now.Month, "00") & "-" & Format(Now.Day, "00") & "-" & Format(Now.Hour, "00") & "-" & Format(Now.Minute, "00") & "-" & Format(Now.Second, "00")
    End Function

    Function Formata_Texto(texto As String)
        Try
            If Len(texto) = 0 Or IsDBNull(texto) Then texto = ""
            texto = UCase(texto)
            texto = Trim(texto)
            'texto = Regex.Replace(texto, "[^\w\.@-]", "")

            texto = Replace(texto, Chr(39), "")
            texto = Replace(texto, Chr(34), "")
            texto = Replace(texto, "~", "")
            texto = Replace(texto, "^", "")
            texto = Replace(texto, "`", "")
            texto = Replace(texto, "´", "")
            texto = Replace(texto, "¨", "")
            texto = Replace(texto, ",", " ")
            texto = Replace(texto, ";", " ")
            texto = Replace(texto, "|", " ")
            texto = Replace(texto, "&", " ")
            texto = Replace(texto, "#", "")

            texto = Replace(texto, "Á", "A")
            texto = Replace(texto, "À", "A")
            texto = Replace(texto, "Â", "A")
            texto = Replace(texto, "Ã", "A")
            texto = Replace(texto, "Ä", "A")

            texto = Replace(texto, "É", "E")
            texto = Replace(texto, "È", "E")
            texto = Replace(texto, "Ê", "E")
            texto = Replace(texto, "Ë", "E")

            texto = Replace(texto, "Í", "I")
            texto = Replace(texto, "Ì", "I")
            texto = Replace(texto, "Î", "I")
            texto = Replace(texto, "", "I")
            texto = Replace(texto, "Ï", "I")

            texto = Replace(texto, "Ó", "O")
            texto = Replace(texto, "Ò", "O")
            texto = Replace(texto, "Ô", "O")
            texto = Replace(texto, "Õ", "O")
            texto = Replace(texto, "Ö", "O")

            texto = Replace(texto, "Ç", "C")

            texto = Replace(texto, "Ú", "U")
            texto = Replace(texto, "Ù", "U")
            texto = Replace(texto, "Û", "U")
            texto = Replace(texto, "Ü", "U")

            texto = Replace(texto, "Ñ", "N")
            texto = Replace(texto, "Ý", "Y")


        Catch
            texto = "ERRO CONVERSAO"
        End Try

        Formata_Texto = texto
    End Function

End Module

