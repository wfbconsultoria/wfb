
Partial Class Visitas_Incluir
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Incluir Visitas"
    Dim Mensagem As String
    Dim sql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'RECUPERA INFORMAÇÕES DA URL
        If Len(Request.QueryString("CNPJ")) > 0 Then Session("CNPJ") = Request.QueryString("CNPJ")
        If Len(Request.QueryString("NOME")) > 0 Then Session("NOME") = Request.QueryString("NOME")
        If Len(Request.QueryString("TIPO")) > 0 Then Session("TIPO") = Request.QueryString("TIPO")
        If Len(Request.QueryString("ID")) > 0 Then Session("ID") = Request.QueryString("ID")
        If Len(Request.QueryString("STATUS_ATIVO")) > 0 Then Session("STATUS_ATIVO") = Request.QueryString("STATUS_ATIVO")
        'VERIFICA AS SE SESSÕES USADAS ESTÃO CARREGADAS
        If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Default.aspx")
        If Session("CNPJ").ToString = "" Then Response.Redirect("Estabelecimentos_Localizar.aspx")

        If Session("STATUS_ATIVO").ToString = "INATIVO" Then Alert("Não é possível lançar para contatos inativos!", True, "Estabelecimentos_Ficha2.aspx?CNPJ=" & Session("CNPJ"))

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

        'ENCHE CAIXAS DE TEXTO COM AS INFORMAÇÕES DO CONTATO
        txt_NOME.Text = Session("NOME")
        txt_TIPO.Text = Session("TIPO")
        txt_ID.Text = Session("ID")

        'Define as datas disponíveis para lançamento de visita, somente até 3 dias atrás
        sql = "SELECT TOP 3 [DATA_VALOR], [DATA_EXTENSO] FROM [VIEW_DATAS] WHERE ([CALENDARIO_VISITAS] = 'True') And (DATA_VALOR < = " & Session("HOJE") & ") ORDER BY [DATA_VALOR] DESC"
        dts_DATA.SelectCommand = sql
    End Sub
    Protected Sub cmd_Gravar_Click(sender As Object, e As EventArgs) Handles cmd_GRAVAR.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim sql As String
        Dim Data_Visita As Double
        Dim Data_Proxima_visita As Double
        Dim Ano_Visita As Integer
        Dim Mes_Visita As Integer
        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()
        Data_Visita = cmb_DATA.Text
        Ano_Visita = Val(Left(Data_Visita, 4))
        Mes_Visita = Val(Mid(Data_Visita, 5, 2))
        Data_Proxima_visita = Format(Year(cld_Proxima_Visita.SelectedDate), "0000") & Format(Month(cld_Proxima_Visita.SelectedDate), "00") & Format(Day(cld_Proxima_Visita.SelectedDate), "00")

        'Verifica a data da pr´xima visita
        If Data_Proxima_visita = 10101 Then Data_Proxima_visita = 0
        If Data_Proxima_visita > 0 Then
            If Data_Proxima_visita <= Session("HOJE") Then
                Alert("Você só pode agendar visitas para datas posteriores a hoje", False, "")
                Exit Sub
            End If
        End If
        'INSERE INFORMAÇÕES NO BANCO DE DADOS
        sql = ""
        sql = sql & " Insert Into TBL_VISITAS_GERAL "
        sql = sql & " ("
        sql = sql & "ANO, MES, CNPJ, "
        sql = sql & "ID_TIPO_VISITADO, "
        If (txt_TIPO.Text = 1) Then
            sql = sql & "ID_MEDICO, "
        Else
            sql = sql & "ID_CONTATO, "
        End If
        sql = sql & "ID_DATA, "
        sql = sql & "DATA_VISITA, "
        sql = sql & "ID_PERIODO, "
        sql = sql & "ID_MINUTOS, "
        sql = sql & "ID_OBJETIVO, "
        sql = sql & "COMENTARIOS, "
        sql = sql & "PROXIMA_VISITA, "
        sql = sql & "ACAO_PROXIMA_VISITA, "
        sql = sql & "INCLUSAO_EMAIL, "
        sql = sql & "INCLUSAO_DATA) "
        sql = sql & " Values ("
        sql = sql & Ano_Visita & ", " & Mes_Visita & ", "
        sql = sql & "'" & Session("CNPJ") & "', "
        sql = sql & "'" & txt_TIPO.Text & "', "
        sql = sql & "'" & txt_ID.Text & "', "
        sql = sql & " '0', "
        sql = sql & Data_Visita & ", "
        sql = sql & "'" & cmb_PERIODO_VISITA.Text & "', "
        sql = sql & "'" & cmb_VISITAS_TEMPO.Text & "', "
        sql = sql & "'" & cmb_OBJETIVO.Text & "', "
        sql = sql & "'" & M.ConverteTexto(txt_COMENTARIOS.Text) & "', "
        sql = sql & Data_Proxima_visita & ", "
        sql = sql & "'" & M.ConverteTexto(txt_COMENTARIOS0.Text) & "', "
        
        'LOG INCLUSAO
        sql = sql & "'" & Session("EMAIL_LOGIN") & "', "
        sql = sql & M.RecuperaData & ")"
        
        ' EXECUTA OS COMANDOS SQL
        If M.ExecutarSQL(sql) = True Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "INCLUIU NOVA:'", "'")
            Alert("VISITA INCLUIDA COM SUCESSO", True, "Estabelecimentos_Ficha2.aspx?CNPJ=" & Session("CNPJ"))
        Else
            Mensagem = "ERRO - INCLUSAO DE VISITA - " & Now() & Chr(10)
            Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN")
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO AO INCLUIR VISITA", Session("CNPJ"))
            M.EnviarEmail("ERRO - INCLUSAO VISITA", Mensagem, True, False, "", "")
            Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", True, "Estabelecimentos_Ficha2.aspx?CNPJ=" & Session("CNPJ"))
        End If

        cnn.Close()
    End Sub
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
