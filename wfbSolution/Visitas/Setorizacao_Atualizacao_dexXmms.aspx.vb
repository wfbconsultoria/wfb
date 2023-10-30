
Partial Class Setorizacao_Atualizacao_dexXmms
    Inherits System.Web.UI.Page
    'Variaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Setorizacao_Atualizacao_dexXmms.aspx"
    Dim Titulo As String = "Atualização Setorizacao de KA Dex x MMS - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean

    'Variáveis da Página
    'Variaveis de conexão com banco de dados do sistema
    Dim cnn As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String
    Dim sql_update As String
    'Variaveis de conexão com banco de dados ESTABELECIMERNTOS (Receita Federal)
    Dim cnnDex As New System.Data.SqlClient.SqlConnection
    Dim cmdDex As New System.Data.SqlClient.SqlCommand
    Dim dtrDex As System.Data.SqlClient.SqlDataReader
    Dim sqlDex As String
    Dim Status As String
    Dim cnpj As String
    Dim rw As TableRow
    Dim cel As TableCell
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = False 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = False 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = False 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = False 'Cordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = False 'Representante
        If Session("COD_PERFIL_LOGIN") = 10 Then Acesso = False 'Key Account
        If Session("COD_PERFIL_LOGIN") = 20 Then Acesso = False 'Visitante
        If Session("COD_PERFIL_LOGIN") = 30 Then Acesso = False 'Distribuidor
        If Session("SISTEMA") = True Then Acesso = True 'USUÁRIO DE SISTEMA

        'Verifica se o perfil do usuário tem acesso a página
        If Acesso = True Then
            'Grava log de permissão de acesso
            If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSO PERMITIDO", "")
                Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
                Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
            End If
        Else
            'Grava log de recusa de acesso
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSO RECUSADO", "")
            Alert("Seu perfil de usuário não permite acesso a esta página!", True, "Default.aspx")
        End If
        '____________________________________________________________________________________________________________________________________________
    End Sub


    Public Sub Atualizar_Estabelecimentos()
        Dim KA As String

        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()
        cnnDex.ConnectionString = ConfigurationManager.ConnectionStrings("cnnDex").ConnectionString
        cnnDex.Open()

        rw = New TableRow
        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "CNPJ"
        cel.Font.Size = 10
        cel.Font.Bold = True
        cel.VerticalAlign = VerticalAlign.Middle
        cel.HorizontalAlign = HorizontalAlign.Left
        cel.BorderWidth = 1
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Status"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "SQL"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        'Recupera informações do banco DEX
        sqlDex = ""
        sqlDex = "Select * From TBL_ESTABELECIMENTOS"
        cmdDex.Connection = cnnDex
        cmdDex.CommandText = sqlDex
        dtrDex = cmdDex.ExecuteReader
        If dtrDex.HasRows Then
            Do While dtrDex.Read()
                KA = ""
                Status = "ERRO"
                sql = ""
                If Not IsDBNull(dtrDex("CNPJ")) Then
                    cnpj = dtrDex("CNPJ")
                    'RECUPERA DADOS DA BASE DE MMS
                    sql = ""
                    sql = "Select *  From TBL_ESTABELECIMENTOS Where CNPJ = " & cnpj
                    cmd.Connection = cnn
                    cmd.CommandText = sql
                    dtr = cmd.ExecuteReader

                    If Not IsDBNull(dtrDex("EMAIL_GERENTE_CONTA")) Then
                        If dtrDex("EMAIL_GERENTE_CONTA") = "leticia.telles@hospira.com" Or dtrDex("EMAIL_GERENTE_CONTA") = "marcio.sousa@hospira.com" Or dtrDex("EMAIL_GERENTE_CONTA") = "carlos.carvalho@hospira.com" Then
                            KA = dtrDex("EMAIL_GERENTE_CONTA")
                        Else
                            KA = "@COORDENADOR"
                        End If
                    Else
                        KA = "@COORDENADOR"
                    End If

                    If dtr.HasRows Then
                        dtr.Read()
                        sql = ""
                        sql = sql & " Update TBL_ESTABELECIMENTOS Set "
                        sql = sql & "EMAIL_GERENTE_CONTA = '" & KA & "' "
                        sql = sql & "WHERE CNPJ =  " & cnpj
                        If M.ExecutarSQL(sql) = True Then
                            Status = "OK"
                            sql = ""
                            sql = sql & " Update TBL_ESTABELECIMENTOS Set "
                            sql = sql & " ALTERACAO_KA_EMAIL = '" & Session("EMAIL_LOGIN") & "', "
                            sql = sql & " ALTERACAO_KA_EM = " & M.RecuperaData
                            sql = sql & " WHERE CNPJ =  " & cnpj
                            M.ExecutarSQL(sql)
                        Else
                            sql_update = sql
                            Status = "ERRO ATUALIZAÇÃO"
                        End If

                    Else

                        sql = ""
                        sql_update = KA
                        Status = "CNPJ " & cnpj & " NÃO ENCONTRADO"
                    End If
                    dtr.Close()
                End If
                rw = New TableRow
                rw.BorderColor = Drawing.Color.Silver
                rw.BackColor = Drawing.Color.Transparent
                tbl_Report.Rows.Add(rw)

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = cnpj
                cel.Font.Size = 10
                cel.Font.Bold = True
                cel.VerticalAlign = VerticalAlign.Middle
                cel.HorizontalAlign = HorizontalAlign.Left
                cel.BorderWidth = 1
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.White

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = Status
                cel.Font.Size = 10
                cel.Font.Bold = True
                cel.VerticalAlign = VerticalAlign.Middle
                cel.HorizontalAlign = HorizontalAlign.Center
                cel.BorderWidth = 1
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.White
                Response.Flush()

                cel = New TableCell
                rw.Cells.Add(cel)
                cel.Text = sql_update
                cel.Font.Size = 10
                cel.Font.Bold = True
                cel.VerticalAlign = VerticalAlign.Middle
                cel.HorizontalAlign = HorizontalAlign.Center
                cel.BorderWidth = 1
                cel.BorderStyle = BorderStyle.Solid
                cel.BorderColor = Drawing.Color.White
                Response.Flush()
            Loop
        End If
        dtrDex.Close()

        cnn.Close()
        cnnDex.Close()

    End Sub

    Protected Sub cmd_Atualizar_Click(sender As Object, e As EventArgs) Handles cmd_Atualizar.Click
        Atualizar_Estabelecimentos()
    End Sub

    'Funções Padrão para todas as páginas
    Protected Function Alert(ByVal Texto_Mensagem As String, ByVal Redirecionar As Boolean, ByVal Pagina As String) As Boolean
        Dim jscript As String
        'caixa de mensagem
        If Redirecionar = True Then
            jscript = ""
            jscript += "<script language='JavaScript'>"
            jscript += ";alert('" & Texto_Mensagem & "'); document.location.href='" & Pagina & "'"
            jscript += "</script>"
        Else
            jscript = ""
            jscript += "<script language='JavaScript'>"
            jscript += ";alert('" & Texto_Mensagem & "');"
            jscript += "</script>"
        End If
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Mensagem", jscript)
        Alert = True
    End Function
End Class
