
Partial Class Estabelecimentos_Atualizacao_Receita
    Inherits System.Web.UI.Page
    'Variaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Estabelecimentos_Atualizacao_Receita.aspx"
    Dim Titulo As String = "Atualização Clientes RF - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean

    'Variáveis da Página
    'Variaveis de conexão com banco de dados do sistema
    Dim cnn As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String
    Dim sql_update As String
    'Variaveis de conexão com banco de dados ESTABELECIMERNTOS (Receita Federal)
    Dim cnnReceita As New System.Data.SqlClient.SqlConnection
    Dim cmdReceita As New System.Data.SqlClient.SqlCommand
    Dim dtrReceita As System.Data.SqlClient.SqlDataReader
    Dim sqlReceita As String
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
        Dim ESTABELECIMENTO As String
        Dim ESTABELECIMENTO_CNPJ As String
        Dim RAZAO_SOCIAL As String
        Dim NOME_FANTASIA As String

        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()
        cnnReceita.ConnectionString = ConfigurationManager.ConnectionStrings("cnnReceitaFederal").ConnectionString
        cnnReceita.Open()

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

        'RECUPERA DADOS DA BASE DE CLIENTES
        sql = ""
        sql = "Select *  From TBL_ESTABELECIMENTOS_RF ORDER BY CNPJ"
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            Do While dtr.Read
                Status = "ERRO"
                sql = ""
                If Not IsDBNull(dtr("CNPJ")) Then
                    cnpj = dtr("CNPJ")
                    'Recupera informações do banco ESTABELECIMENTOS RECEITA FEDERAL
                    sqlReceita = "Select * From VIEW_ESTABELECIMENTOS Where CNPJ = " & cnpj
                    cmdReceita.Connection = cnnReceita
                    cmdReceita.CommandText = sqlReceita
                    dtrReceita = cmdReceita.ExecuteReader

                    If dtrReceita.HasRows Then
                        dtrReceita.Read()

                        If Not IsDBNull(dtrReceita("ESTABELECIMENTO")) Then ESTABELECIMENTO = M.ConverteTexto(dtrReceita("ESTABELECIMENTO"))
                        If Not IsDBNull(dtrReceita("ESTABELECIMENTO_CNPJ")) Then ESTABELECIMENTO_CNPJ = M.ConverteTexto(dtrReceita("ESTABELECIMENTO_CNPJ"))
                        If Not IsDBNull(dtrReceita("RAZAO_SOCIAL")) Then RAZAO_SOCIAL = M.ConverteTexto(dtrReceita("RAZAO_SOCIAL"))
                        If Not IsDBNull(dtrReceita("NOME_FANTASIA")) Then NOME_FANTASIA = M.ConverteTexto(dtrReceita("NOME_FANTASIA"))

                        sql = ""
                        sql = sql & " Update TBL_ESTABELECIMENTOS_RF Set "
                        sql = sql & "CNPJ_FORMATADO = '" & dtrReceita("CNPJ_FORMATADO") & "', "
                        sql = sql & "COD_TIPO_PESSOA = '" & dtrReceita("COD_TIPO_PESSOA") & "', "
                        sql = sql & "TIPO_PESSOA = '" & dtrReceita("TIPO_PESSOA") & "', "
                        sql = sql & "ESTABELECIMENTO = '" & ESTABELECIMENTO & "', "
                        sql = sql & "ESTABELECIMENTO_CNPJ = '" & ESTABELECIMENTO_CNPJ & "', "
                        sql = sql & "RAZAO_SOCIAL = '" & RAZAO_SOCIAL & "', "
                        sql = sql & "NOME_FANTASIA = '" & NOME_FANTASIA & "', "
                        sql = sql & "ENDERECO = '" & dtrReceita("ENDERECO") & "', "
                        sql = sql & "LOGRADOURO = '" & dtrReceita("LOGRADOURO") & "', "
                        sql = sql & "NUMERO = '" & dtrReceita("NUMERO") & "', "
                        sql = sql & "COMPLEMENTO = '" & dtrReceita("COMPLEMENTO") & "', "
                        sql = sql & "BAIRRO = '" & dtrReceita("BAIRRO") & "', "
                        sql = sql & "CEP = '" & dtrReceita("CEP") & "', "
                        sql = sql & "COD_MUNICIPIO = '" & dtrReceita("COD_IBGE") & "', "
                        sql = sql & "CIDADE = '" & dtrReceita("CIDADE") & "', "
                        sql = sql & "UF = '" & dtrReceita("UF") & "', "
                        sql = sql & "ESTADO = '" & dtrReceita("ESTADO") & "', "
                        sql = sql & "REGIAO = '" & dtrReceita("REGIAO") & "', "
                        sql = sql & "REGIAO_SAUDE = '" & dtrReceita("REGIAO_SAUDE") & "', "
                        sql = sql & "MICRO_REGIAO_SAUDE = '" & dtrReceita("MICRO_REGIAO_SAUDE") & "', "
                        sql = sql & "COD_NATUREZA_JURIDICA = " & dtrReceita("COD_NATUREZA_JURIDICA") & ", "
                        sql = sql & "NATUREZA_JURIDICA_DESCRICAO = '" & dtrReceita("NATUREZA_JURIDICA_DESCRICAO") & "', "
                        sql = sql & "COD_ESFERA_ADMINISTRATIVA = '" & dtrReceita("COD_ESFERA_ADMINISTRATIVA") & "', "
                        sql = sql & "ESFERA = '" & dtrReceita("ESFERA") & "', "
                        sql = sql & "GESTAO = '" & dtrReceita("GESTAO") & "', "
                        sql = sql & "COD_CNAE = '" & dtrReceita("COD_CNAE") & "', "
                        sql = sql & "CNAE_DESCRICAO = '" & dtrReceita("CNAE_DESCRICAO") & "', "
                        If IsDBNull(dtrReceita("DATA_FUNDACAO")) Then
                            sql = sql & "DATA_FUNDACAO = NULL, "
                        Else
                            sql = sql & "DATA_FUNDACAO = '" & dtrReceita("DATA_FUNDACAO") & "', "
                        End If
                        If IsDBNull(dtrReceita("DATA_SITUACAORFB")) Then
                            sql = sql & "DATA_SITUACAORFB = NULL, "
                        Else
                            sql = sql & "DATA_SITUACAORFB = '" & dtrReceita("DATA_SITUACAORFB") & "', "
                        End If
                        sql = sql & "SITUACAORFB = '" & dtrReceita("SITUACAORFB") & "', "
                        sql = sql & "MOTIVO_SITUACAORFB = '" & dtrReceita("MOTIVO_SITUACAORFB") & "', "
                        sql = sql & "MOTIVO_ESPECIAL_SITUACAORFB = '" & dtrReceita("MOTIVO_ESPECIAL_SITUACAORFB") & "' "
                        sql = sql & "WHERE CNPJ =  " & cnpj
                        If M.ExecutarSQL(sql) = True Then
                            Status = "OK"
                            sql = ""
                            sql = sql & " Update TBL_ESTABELECIMENTOS_RF Set "
                            sql = sql & " ATUALIZACAO_RECEITA_DATA = " & M.RecuperaData & ", "
                            sql = sql & " ATUALIZACAO_RECEITA_CHECK = 1, "
                            sql = sql & " ATUALIZACAO_RECEITA_EMAIL = '" & Session("EMAIL_LOGIN") & "' "
                            sql = sql & "WHERE CNPJ =  " & cnpj
                            M.ExecutarSQL(sql)
                        Else
                            sql_update = sql
                            Status = "ERRO ATUALIZAÇÃO"
                            sql = ""
                            sql = sql & " Update TBL_ESTABELECIMENTOS_RF Set "
                            sql = sql & " ATUALIZACAO_RECEITA_DATA = " & M.RecuperaData & ", "
                            sql = sql & " ATUALIZACAO_RECEITA_CHECK = 0, "
                            sql = sql & " ATUALIZACAO_RECEITA_EMAIL = '" & Session("EMAIL_LOGIN") & "' "
                            sql = sql & "WHERE CNPJ =  " & cnpj
                            M.ExecutarSQL(sql)
                        End If

                    Else
                        Status = "CNPJ NÃO ENCONTRADO"
                        sql = ""
                        sql = sql & " Update TBL_ESTABELECIMENTOS_RF Set "
                        sql = sql & " ATUALIZACAO_RECEITA_DATA = " & M.RecuperaData & ", "
                        sql = sql & " ATUALIZACAO_RECEITA_CHECK = 0, "
                        sql = sql & " ATUALIZACAO_RECEITA_EMAIL = '" & Session("EMAIL_LOGIN") & "' "
                        sql = sql & "WHERE CNPJ =  " & cnpj
                        M.ExecutarSQL(sql)
                    End If

                    dtrReceita.Close()
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
        dtr.Close()
        cnn.Close()
        cnnReceita.Close()

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
