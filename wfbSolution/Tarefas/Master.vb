Imports System.Configuration
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports Renci.SshNet

Module Master
    Public cnnProduction As SqlClient.SqlConnection 'Conexão sql server origem
    Public cnnBackup As SqlClient.SqlConnection 'Conexão sql server destino
    Public Banco As String

    Function DatabaseConnect_Production() As Boolean
        'Comentários sobre a função
        On Error GoTo Err_DatabaseConnect_Production
        DatabaseConnect_Production = False

        'Inicio - programação da função aqui, não esquecer comentários
        'Conexão banco de origem
        cnnProduction = New System.Data.SqlClient.SqlConnection
        cnnProduction.ConnectionString = ConfigurationManager.ConnectionStrings("cnnProduction").ConnectionString

        cnnProduction.Open()
        'Final - programação da função aqui, não esquecer comentários

        DatabaseConnect_Production = True

        Message("Conexão no servidor de produção realizada com sucesso!!!")

        Exit Function
Err_DatabaseConnect_Production:
        DatabaseConnect_Production = False
        System_Error("DatabaseConnect_Production", "Erro ao conetar banco de dados " & Banco & " de produção", Err.Number & " - " & Err.Description)
        DatabaseConnect_Production = False
        Exit Function
    End Function
    Function DatabaseConnect_Backup() As Boolean
        'Comentários sobre a função
        On Error GoTo Err_DatabaseConnect_Backup
        DatabaseConnect_Backup = False

        'Inicio - programação da função aqui, não esquecer comentários
        'Conexão banco de origem
        cnnProduction = New System.Data.SqlClient.SqlConnection
        cnnProduction.ConnectionString = ConfigurationManager.ConnectionStrings("cnnBackup").ConnectionString
        cnnProduction.Open()
        'Final - programação da função aqui, não esquecer comentários

        DatabaseConnect_Backup = True
        Message("Conexão no servidor de Backup realizada com sucesso!!!")
        Exit Function
Err_DatabaseConnect_Backup:
        DatabaseConnect_Backup = False
        System_Error("DatabaseConnect_Backup", "Erro ao conetar banco de dados de Backup " & Banco & "", Err.Number & " - " & Err.Description)

    End Function
    Sub Main()
        On Error GoTo Err_Main

        Dim Dia = DateTime.Today.Day

        If Dia <= 10 Or Dia = 27 Then
            If Backup_Csl_Novo() = True Then
                Message("1 - Backup do banco CSL_NOVO Realizado com sucesso")
            End If

            If Backup_CSL_Reports() = True Then
                Message("1 - Backup do banco CSL-Reports-2020 Realizado com sucesso")
            End If

            If Backup_Cep() = True Then
                Message("1 - Backup do banco CEP Realizado com sucesso")
            End If

            If Backup_Estabelecimentos() = True Then
                Message("1 - Backup do banco Estabelecimento Realizado com sucesso")
            End If

            If Backup_IBGE() = True Then
                Message("1 - Backup do banco IBGE Realizado com sucesso")
            End If

            If Backup_CSL() = True Then
                Message("1 - Backup do banco CSL Realizado com sucesso")
            End If

            If Backup_CSL_IV_2022_TRI_02() = True Then
                Message("1 - Backup do banco CSL_IV_2022_TRI_02 Realizado com sucesso")
            End If


        Else

            If Backup_Csl_Novo() = True Then
                Message("1 - Backup do banco CSL_NOVO Realizado com sucesso")
            End If

            If Backup_CSL_Reports() = True Then
                Message("1 - Backup do banco CSL-Reports-2020 Realizado com sucesso")
            End If


            If Backup_Estabelecimentos() = True Then
                Message("1 - Backup do banco Estabelecimento Realizado com sucesso")
            End If

            If Backup_CSL() = True Then
                Message("1 - Backup do banco CSL Realizado com sucesso")
            End If

            If Backup_CSL_IV_2022_TRI_02() = True Then
                Message("1 - Backup do banco CSL_IV_2022_TRI_02 Realizado com sucesso")
            End If


        End If

        Exit Sub
Err_Main:
        System_Error("Main - Procediemntos", "Erro para execultar os procedimentos" & Banco & "", Err.Number & " - " & Err.Description)

    End Sub
    Function Backup_Csl_Novo()
        On Error GoTo Err_Backup_Csl_Novo
        Backup_Csl_Novo = False

        Dim Sql_backup As String
        Dim sql_Restore As String

        'Abrir conexão com o banco de Produção
        If DatabaseConnect_Production() = False Then GoTo Err_Backup_Csl_Novo

        'Nome do Banco
        Banco = ""
        Banco = "CSL_NOVO"

        'Scriprt Backup banco de Produção
        Sql_backup = ""
        Sql_backup = Sql_backup & "USE " & Banco & ""
        'Sql_backup = Sql_backup & " ;EXEC Atualiza_@BI"
        Sql_backup = Sql_backup & " ;DBCC SHRINKFILE (N'WFB_Log' , 0, TRUNCATEONLY)"
        Sql_backup = Sql_backup & " ;DBCC SHRINKFILE(N'WFB_Data' , 0, TRUNCATEONLY)"
        Sql_backup = Sql_backup & " ;DBCC SHRINKDATABASE(N'" & Banco & "' ) "
        Sql_backup = Sql_backup & " ;BACKUP DATABASE [CSL_NOVO] TO  DISK = N'/var/opt/mssql/data/backup/CSL_NOVO.bak' WITH NOFORMAT, INIT,  NAME = N'CSL_NOVO-Completo Banco de Dados Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"

        'Execultar o Backup
        If ExecuteSQL_Production(Sql_backup) = False Then GoTo Err_Backup_Csl_Novo

        'Fechar Conexão com o banco de produção
        cnnProduction.Close()

        'Fazer Downalod do arquivo de backup
        If sftp_Download("/var/opt/mssql/data/backup/" & Banco & ".bak", "D:\DATABASE\Restore\" & Banco & "") = False Then GoTo Err_Backup_Csl_Novo

        'Abrir conexão com o banco de Backup
        If DatabaseConnect_Backup() = False Then GoTo Err_Backup_Csl_Novo

        sql_Restore = ""
        sql_Restore = "RESTORE DATABASE [CSL_NOVO] FROM  DISK = N'D:\DATABASE\Restore\CSL_NOVO' WITH  FILE = 1,  MOVE N'WFB_Data' TO N'D:\DATABASE\CSL_NOVO.mdf',  MOVE N'WFB_Log' TO N'D:\DATABASE\CSL_NOVO_log.ldf',  NOUNLOAD,  REPLACE,  STATS = 5"

        'Execultar o Restore
        If ExecuteSQL_Production(sql_Restore) = False Then GoTo Err_Backup_Csl_Novo

        'Fechar Conexão com o banco de produção
        cnnProduction.Close()

        SendMail("Backup do banco " & Banco & " realizado com Sucesso!", Now())

        Backup_Csl_Novo = True

        Exit Function

Err_Backup_Csl_Novo:
        System_Error("Backup_Csl_Novo", "Erro quando execuldado o processo de backup do banco " & Banco & "", Err.Number & " - " & Err.Description)
        Backup_Csl_Novo = False
        Exit Function
    End Function

    Function Backup_CSL_Reports()
        On Error GoTo Err_Backup_CSL_Reports
        Backup_CSL_Reports = False

        Dim Sql_backup As String
        Dim sql_Restore As String

        'Abrir conexão com o banco de Produção
        If DatabaseConnect_Production() = False Then GoTo Err_Backup_CSL_Reports

        'Nome do Banco
        Banco = ""
        Banco = "CSL-Reports-2020"

        'Scriprt Backup banco de Produção
        Sql_backup = ""
        Sql_backup = Sql_backup & "USE [CSL-Reports-2020]"
        Sql_backup = Sql_backup & " ;DBCC SHRINKFILE (N'CSL-Reports-2020_log' , 0, TRUNCATEONLY)"
        Sql_backup = Sql_backup & " ;DBCC SHRINKFILE (N'CSL-Reports-2020' , 0, TRUNCATEONLY)"
        Sql_backup = Sql_backup & " ;DBCC SHRINKDATABASE(N'" & Banco & "' ) "
        Sql_backup = Sql_backup & " ;BACKUP DATABASE [CSL-Reports-2020] TO  DISK = N'/var/opt/mssql/data/backup/CSL-Reports-2020.bak' WITH NOFORMAT, INIT,  NAME = N'CSL-Reports-2020-Completo Banco de Dados Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"

        'Execultar o Backup
        If ExecuteSQL_Production(Sql_backup) = False Then GoTo Err_Backup_CSL_Reports

        'Fechar Conexão com o banco de produção
        cnnProduction.Close()

        'Fazer Downalod do arquivo de backup
        If sftp_Download("/var/opt/mssql/data/backup/" & Banco & ".bak", "D:\DATABASE\Restore\" & Banco & "") = False Then GoTo Err_Backup_CSL_Reports

        'Abrir conexão com o banco de Backup
        If DatabaseConnect_Backup() = False Then GoTo Err_Backup_CSL_Reports

        sql_Restore = ""
        sql_Restore = "RESTORE DATABASE [CSL-Reports-2020] FROM  DISK = N'D:\DATABASE\Restore\CSL-Reports-2020' WITH  FILE = 1,  MOVE N'CSL-Reports-2020' TO N'D:\DATABASE\CSL-Reports-2020.mdf',  MOVE N'CSL-Reports-2020_log' TO N'D:\DATABASE\CSL-Reports-2020_log.ldf',  NOUNLOAD,  REPLACE,  STATS = 5"

        'Execultar o Restore
        If ExecuteSQL_Production(sql_Restore) = False Then GoTo Err_Backup_CSL_Reports

        'Fechar Conexão com o banco de produção
        cnnProduction.Close()

        SendMail("Backup do banco " & Banco & " realizado com Sucesso!", Now())

        Backup_CSL_Reports = True

        Exit Function

Err_Backup_CSL_Reports:
        System_Error("Backup_Csl_Reports", "Erro quando execuldado o processo de backup do banco " & Banco & "", Err.Number & " - " & Err.Description)
        Backup_CSL_Reports = False
        Exit Function
    End Function
    Function Backup_Cep()
        On Error GoTo Err_Backup_Cep
        Backup_Cep = False

        Dim Sql_backup As String
        Dim sql_Restore As String

        'Abrir conexão com o banco de Produção
        If DatabaseConnect_Production() = False Then GoTo Err_Backup_Cep

        'Nome do Banco
        Banco = ""
        Banco = "CEP"

        'Scriprt Backup banco de Produção
        Sql_backup = ""
        Sql_backup = Sql_backup & "USE " & Banco & ""
        Sql_backup = Sql_backup & " ;DBCC SHRINKFILE (N'CEP_log' , 0, TRUNCATEONLY)"
        Sql_backup = Sql_backup & " ;DBCC SHRINKFILE (N'CEP' , 0, TRUNCATEONLY)"
        Sql_backup = Sql_backup & " ;DBCC SHRINKDATABASE(N'" & Banco & "' ) "
        Sql_backup = Sql_backup & " ;BACKUP DATABASE [CEP] TO  DISK = N'/var/opt/mssql/data/backup/CEP.bak' WITH NOFORMAT, INIT,  NAME = N'CEP-Completo Banco de Dados Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"

        'Execultar o Backup
        If ExecuteSQL_Production(Sql_backup) = False Then GoTo Err_Backup_Cep

        'Fechar Conexão com o banco de produção
        cnnProduction.Close()

        'Fazer Downalod do arquivo de backup
        If sftp_Download("/var/opt/mssql/data/backup/" & Banco & ".bak", "D:\DATABASE\Restore\" & Banco & "") = False Then GoTo Err_Backup_Cep

        'Abrir conexão com o banco de Backup
        If DatabaseConnect_Backup() = False Then GoTo Err_Backup_Cep

        sql_Restore = ""
        sql_Restore = "RESTORE DATABASE [CEP] FROM  DISK = N'D:\DATABASE\Restore\CEP' WITH  FILE = 1,  MOVE N'CEP' TO N'D:\DATABASE\CEP.mdf',  MOVE N'CEP_log' TO N'D:\DATABASE\CEP_log.ldf',  NOUNLOAD,  REPLACE,  STATS = 5"

        'Execultar o Restore
        If ExecuteSQL_Production(sql_Restore) = False Then GoTo Err_Backup_Cep

        'Fechar Conexão com o banco de produção
        cnnProduction.Close()

        SendMail("Backup do banco " & Banco & " realizado com Sucesso!", Now())

        Backup_Cep = True

        Exit Function

Err_Backup_Cep:
        System_Error("Backup_Cep", "Erro quando execuldado o processo de backup do banco " & Banco & "", Err.Number & " - " & Err.Description)
        Backup_Cep = False
        Exit Function
    End Function
    Function Backup_Estabelecimentos()
        On Error GoTo Err_Backup_Estabelecimentos
        Backup_Estabelecimentos = False

        Dim Sql_backup As String
        Dim sql_Restore As String

        'Abrir conexão com o banco de Produção
        If DatabaseConnect_Production() = False Then GoTo Err_Backup_Estabelecimentos

        'Nome do Banco
        Banco = ""
        Banco = "ESTABELECIMENTOS"

        'Scriprt Backup banco de Produção
        Sql_backup = ""
        Sql_backup = Sql_backup & "USE " & Banco & ""
        Sql_backup = Sql_backup & " ;DBCC SHRINKFILE (N'ESTABELECIMENTOS_log' , 0, TRUNCATEONLY)"
        Sql_backup = Sql_backup & " ;DBCC SHRINKFILE (N'ESTABELECIMENTOS' , 0, TRUNCATEONLY)"
        Sql_backup = Sql_backup & " ;DBCC SHRINKDATABASE(N'" & Banco & "' ) "
        Sql_backup = Sql_backup & " ;BACKUP DATABASE [ESTABELECIMENTOS] TO  DISK = N'/var/opt/mssql/data/backup/ESTABELECIMENTOS.bak' WITH NOFORMAT, INIT,  NAME = N'ESTABELECIMENTOS-Completo Banco de Dados Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"

        'Execultar o Backup
        If ExecuteSQL_Production(Sql_backup) = False Then GoTo Err_Backup_Estabelecimentos

        'Fechar Conexão com o banco de produção
        cnnProduction.Close()

        'Fazer Downalod do arquivo de backup
        If sftp_Download("/var/opt/mssql/data/backup/" & Banco & ".bak", "D:\DATABASE\Restore\" & Banco & "") = False Then GoTo Err_Backup_Estabelecimentos

        'Abrir conexão com o banco de Backup
        If DatabaseConnect_Backup() = False Then GoTo Err_Backup_Estabelecimentos

        sql_Restore = ""
        sql_Restore = "RESTORE DATABASE [ESTABELECIMENTOS] FROM  DISK = N'D:\DATABASE\Restore\ESTABELECIMENTOS' WITH  FILE = 1,  MOVE N'ESTABELECIMENTOS' TO N'D:\DATABASE\ESTABELECIMENTOS.mdf',  MOVE N'ESTABELECIMENTOS_log' TO N'D:\DATABASE\ESTABELECIMENTOS_log.ldf',  NOUNLOAD,  REPLACE,  STATS = 5"

        'Execultar o Restore
        If ExecuteSQL_Production(sql_Restore) = False Then GoTo Err_Backup_Estabelecimentos

        'Fechar Conexão com o banco de produção
        cnnProduction.Close()

        SendMail("Backup do banco " & Banco & " realizado com Sucesso!", Now())

        Backup_Estabelecimentos = True

        Exit Function

Err_Backup_Estabelecimentos:
        System_Error("Backup_Estabelecimentos", "Erro quando execuldado o processo de backup do banco " & Banco & "", Err.Number & " - " & Err.Description)
        Backup_Estabelecimentos = False
        Exit Function
    End Function

    Function Backup_IBGE()
        On Error GoTo Err_Backup_IBGE
        Backup_IBGE = False

        Dim Sql_backup As String
        Dim sql_Restore As String

        'Abrir conexão com o banco de Produção
        If DatabaseConnect_Production() = False Then GoTo Err_Backup_IBGE

        'Nome do Banco
        Banco = ""
        Banco = "IBGE"

        'Scriprt Backup banco de Produção
        Sql_backup = ""
        Sql_backup = Sql_backup & "USE " & Banco & ""
        Sql_backup = Sql_backup & " ;DBCC SHRINKFILE (N'IBGE_log' , 0, TRUNCATEONLY)"
        Sql_backup = Sql_backup & " ;DBCC SHRINKFILE (N'IBGE' , 0, TRUNCATEONLY)"
        Sql_backup = Sql_backup & " ;DBCC SHRINKDATABASE(N'" & Banco & "' ) "
        Sql_backup = Sql_backup & " ;BACKUP DATABASE [IBGE] TO  DISK = N'/var/opt/mssql/data/backup/IBGE.bak' WITH NOFORMAT, INIT,  NAME = N'IBGE-Completo Banco de Dados Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"

        'Execultar o Backup
        If ExecuteSQL_Production(Sql_backup) = False Then GoTo Err_Backup_IBGE

        'Fechar Conexão com o banco de produção
        cnnProduction.Close()

        'Fazer Downalod do arquivo de backup
        If sftp_Download("/var/opt/mssql/data/backup/" & Banco & ".bak", "D:\DATABASE\Restore\" & Banco & "") = False Then GoTo Err_Backup_IBGE

        'Abrir conexão com o banco de Backup
        If DatabaseConnect_Backup() = False Then GoTo Err_Backup_IBGE

        sql_Restore = ""
        sql_Restore = "RESTORE DATABASE [IBGE] FROM  DISK = N'D:\DATABASE\Restore\IBGE' WITH  FILE = 1,  MOVE N'IBGE' TO N'D:\DATABASE\IBGE.mdf',  MOVE N'IBGE_log' TO N'D:\DATABASE\IBGE_log.ldf',  NOUNLOAD,  REPLACE,  STATS = 5"

        'Execultar o Restore
        If ExecuteSQL_Production(sql_Restore) = False Then GoTo Err_Backup_IBGE

        'Fechar Conexão com o banco de produção
        cnnProduction.Close()

        SendMail("Backup do banco " & Banco & " realizado com Sucesso!", Now())

        Backup_IBGE = True

        Exit Function

Err_Backup_IBGE:
        System_Error("Backup_IBGE", "Erro quando execuldado o processo de backup do banco " & Banco & "", Err.Number & " - " & Err.Description)
        Backup_IBGE = False
        Exit Function
    End Function


    Function Backup_CSL()
        On Error GoTo Err_Backup_CSL
        Backup_CSL = False

        Dim Sql_backup As String
        Dim sql_Restore As String

        'Abrir conexão com o banco de Produção
        If DatabaseConnect_Production() = False Then GoTo Err_Backup_CSL

        'Nome do Banco
        Banco = ""
        Banco = "CSL"

        'Scriprt Backup banco de Produção
        Sql_backup = ""
        Sql_backup = Sql_backup & "USE " & Banco & ""
        Sql_backup = Sql_backup & " ;DBCC SHRINKDATABASE(N'CSL' )"
        Sql_backup = Sql_backup & " ;DBCC SHRINKFILE (N'CSL' , 0, TRUNCATEONLY)"
        Sql_backup = Sql_backup & " ;DBCC SHRINKFILE (N'CSL_log' , 0, TRUNCATEONLY) "
        Sql_backup = Sql_backup & " ;BACKUP DATABASE [CSL] TO  DISK = N'/var/opt/mssql/data/backup/CSL.bak' WITH NOFORMAT, INIT,  NAME = N'CSL-Completo Banco de Dados Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"

        'Execultar o Backup
        If ExecuteSQL_Production(Sql_backup) = False Then GoTo Err_Backup_CSL

        'Fechar Conexão com o banco de produção
        cnnProduction.Close()

        'Fazer Downalod do arquivo de backup
        If sftp_Download("/var/opt/mssql/data/backup/" & Banco & ".bak", "D:\DATABASE\Restore\" & Banco & "") = False Then GoTo Err_Backup_CSL

        'Abrir conexão com o banco de Backup
        If DatabaseConnect_Backup() = False Then GoTo Err_Backup_CSL

        sql_Restore = ""
        sql_Restore = "RESTORE DATABASE [CSL] FROM  DISK = N'D:\DATABASE\Restore\CSL' WITH  FILE = 1,  MOVE N'CSL' TO N'D:\DATABASE\CSL.mdf',  MOVE N'CSL_log' TO N'D:\DATABASE\CSL_log.ldf',  NOUNLOAD,  REPLACE,  STATS = 5"

        'Execultar o Restore
        If ExecuteSQL_Production(sql_Restore) = False Then GoTo Err_Backup_CSL

        'Fechar Conexão com o banco de produção
        cnnProduction.Close()

        SendMail("Backup do banco " & Banco & " realizado com Sucesso!", Now())

        Backup_CSL = True

        Exit Function

Err_Backup_CSL:
        System_Error("Backup_CSL", "Erro quando execuldado o processo de backup do banco " & Banco & "", Err.Number & " - " & Err.Description)
        Backup_CSL = False
        Exit Function
    End Function
    Function Backup_CSL_IV_2022_TRI_02()
        On Error GoTo Err_Backup_CSL_IV_2022_TRI_02
        Backup_CSL_IV_2022_TRI_02 = False

        Dim Sql_backup As String
        Dim sql_Restore As String

        'Abrir conexão com o banco de Produção
        If DatabaseConnect_Production() = False Then GoTo Err_Backup_CSL_IV_2022_TRI_02

        'Nome do Banco
        Banco = ""
        Banco = "CSL_IV_2022_TRI_02"

        'Scriprt Backup banco de Produção
        Sql_backup = ""
        Sql_backup = Sql_backup & "USE " & Banco & ""
        Sql_backup = Sql_backup & " ;DBCC SHRINKDATABASE(N'CSL_IV_2022_TRI_02' ) "
        Sql_backup = Sql_backup & " ;DBCC SHRINKFILE (N'CSL_IV_2020' , 0, TRUNCATEONLY) "
        Sql_backup = Sql_backup & " ;DBCC SHRINKFILE (N'CSL_IV_2020_log' , 0, TRUNCATEONLY)  "
        Sql_backup = Sql_backup & " ;BACKUP DATABASE [CSL_IV_2022_TRI_02] TO  DISK = N'/var/opt/mssql/data/backup/CSL_IV_2022_TRI_02.bak' WITH NOFORMAT, INIT,  NAME = N'CSL_IV_2022_TRI_02-Completo Banco de Dados Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"

        'Execultar o Backup
        If ExecuteSQL_Production(Sql_backup) = False Then GoTo Err_Backup_CSL_IV_2022_TRI_02

        'Fechar Conexão com o banco de produção
        cnnProduction.Close()

        'Fazer Downalod do arquivo de backup
        If sftp_Download("/var/opt/mssql/data/backup/" & Banco & ".bak", "D:\DATABASE\Restore\" & Banco & "") = False Then GoTo Err_Backup_CSL_IV_2022_TRI_02

        'Abrir conexão com o banco de Backup
        If DatabaseConnect_Backup() = False Then GoTo Err_Backup_CSL_IV_2022_TRI_02

        sql_Restore = ""
        sql_Restore = "RESTORE DATABASE [CSL_IV_2022_TRI_02] FROM  DISK = N'D:\DATABASE\Restore\CSL_IV_2022_TRI_02' WITH  FILE = 1,  MOVE N'CSL_IV_2020' TO N'D:\DATABASE\CSL_IV_2022_TRI_02.mdf',  MOVE N'CSL_IV_2020_log' TO N'D:\DATABASE\CSL_IV_2022_TRI_02_log.ldf',  NOUNLOAD,  REPLACE,  STATS = 5"

        'Execultar o Restore
        If ExecuteSQL_Production(sql_Restore) = False Then GoTo Err_Backup_CSL_IV_2022_TRI_02

        'Fechar Conexão com o banco de produção
        cnnProduction.Close()

        SendMail("Backup do banco " & Banco & " realizado com Sucesso!", Now())

        Backup_CSL_IV_2022_TRI_02 = True

        Exit Function

Err_Backup_CSL_IV_2022_TRI_02:
        System_Error("Backup_CSL_IV_2022_TRI_02", "Erro quando execuldado o processo de backup do banco " & Banco & "", Err.Number & " - " & Err.Description)
        Backup_CSL_IV_2022_TRI_02 = False
        Exit Function
    End Function

    Function sftp_Download(Caminho_Origem As String, Caminho_Destino As String) As Boolean
        On Error GoTo Err_FileTransfer_SFTP

        sftp_Download = False

        Using sftp As SftpClient = New SftpClient(ConfigurationManager.AppSettings("SFTP.production.host").ToString, ConfigurationManager.AppSettings("SFTP.production.user").ToString, ConfigurationManager.AppSettings("SFTP.production.password").ToString)
            sftp.Connect()
            Using fileStream As Stream = File.OpenWrite(Caminho_Destino)
                sftp.DownloadFile(Caminho_Origem, fileStream)
            End Using
            sftp.Disconnect()
            sftp_Download = True
        End Using

        Message("Download realizado com sucesso!!!")

        Exit Function
Err_FileTransfer_SFTP:
        sftp_Download = False
        System_Error("Download", "Erro para realizar o Download do banco " & Banco & "", Err.Number & " - " & Err.Description)
    End Function
    Public Function ExecuteSQL_Production(ByVal SQL As String) As Boolean
        'Comentários sobre a função
        On Error GoTo Err_ExecuteSQL_Production
        ExecuteSQL_Production = False

        'Inicio - programação da função aqui, não esquecer comentários
        Dim cmdProduction As System.Data.SqlClient.SqlCommand = cnnProduction.CreateCommand
        cmdProduction.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("SqlCommandTimeOut"))
        cmdProduction.CommandText = SQL
        cmdProduction.ExecuteNonQuery()

        'Final - programação da função aqui, não esquecer comentários

        ExecuteSQL_Production = True
        Exit Function
Err_ExecuteSQL_Production:
        ExecuteSQL_Production = False


    End Function

    Public Function System_Error(strFunction, strErrorMessage, strErrDescription) As Boolean
        'Comentários sobre a função
        On Error GoTo Err_System_Error
        System_Error = False
        Dim ErrMessage As String
        ErrMessage = "<p>Função: " & strFunction & "</p><p>Descrição: " & strErrorMessage & "</p><p> Descrição do sistema: " & strErrDescription & "</p>"
        'Inicio - programação da função aqui, não esquecer comentários
        SendMail(Banco & " - Erro em " & strFunction & " - " & Now(), ErrMessage)

        Process.GetCurrentProcess().Close() 'Encerra a aplicação

        'Final - programação da função aqui, não esquecer comentários

        System_Error = True
        Exit Function
Err_System_Error:
        System_Error = False
    End Function

    Public Sub Message(msg As String)
        Console.WriteLine(msg)
    End Sub
    Public Function SendMail(MailSubject As String, MailMessage As String) As Boolean
        On Error GoTo Err_SendMail

        Dim credentials = New NetworkCredential(ConfigurationManager.AppSettings("SMTP.user").ToString, ConfigurationManager.AppSettings("SMTP.password").ToString)
        Dim smtp = New SmtpClient
        Dim msgFrom As New MailAddress(ConfigurationManager.AppSettings("SMTP.user").ToString, ConfigurationManager.AppSettings("App.name").ToString)
        Dim msgTo As New MailAddress(ConfigurationManager.AppSettings("Email.to").ToString, ConfigurationManager.AppSettings("Email.to.name").ToString)
        Dim msgCopy As MailAddress = New MailAddress(ConfigurationManager.AppSettings("SMTP.user").ToString)
        Dim msg As New MailMessage(msgFrom, msgTo)
        Dim MailSignature As String = "<br/><hr/><p>Mensagem automatica, por favor, não responda</p>"

        'Configurações do Email
        MailSubject = ConfigurationManager.AppSettings("App.Name").ToString & " - " & UCase(MailSubject)
        msg.Subject = MailSubject
        msg.IsBodyHtml = True
        msg.Body = "<h3>" & MailSubject & "</h3> <hr/> <p>" & MailMessage & MailSignature & "</p>"
        msg.Bcc.Add(msgCopy)

        'Configurações de SMTP
        smtp.Host = ConfigurationManager.AppSettings("SMTP.host").ToString
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network
        smtp.UseDefaultCredentials = False
        smtp.Port = ConfigurationManager.AppSettings("SMTP.port")
        smtp.Credentials = credentials
        smtp.EnableSsl = True

        'Envia o e-mail
        smtp.Send(msg)
        SendMail = True

        Exit Function
Err_SendMail:
        SendMail = False

    End Function
End Module