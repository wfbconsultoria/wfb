
Partial Class Visitas_Incluir_Contatos
    Inherits System.Web.UI.Page
  'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Visitas_Incluir.aspx"
    Dim Titulo As String = "Incluir Visita - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
    Dim Mensagem As String
    'Váriáveis da Página
    Dim SQL As String
    Dim CNPJ As String
    Dim NOME As String
    Dim TIPO_VISITADO As String
    Dim COD_CONTATO As String
    Dim ATIVO As Boolean
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = True 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = True 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = True 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = True 'Cordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = True 'Representante
        If Session("COD_PERFIL_LOGIN") = 10 Then Acesso = True 'Key Account
        If Session("COD_PERFIL_LOGIN") = 20 Then Acesso = False 'Visitante
        If Session("COD_PERFIL_LOGIN") = 30 Then Acesso = False 'Distribuidor

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

        'Código customizado da página

        'Verifica se COD_CONTATO está na URL
        If Len(Request.QueryString("COD_CONTATO")) = 0 Then
            Alert("Selecione o contato antes de lançar visitas", True, "Contatos_Lista.aspx")
        End If
        'RECUPERA INFORMAÇÕES DA URL
        If Len(Request.QueryString("CNPJ")) > 0 Then CNPJ = Request.QueryString("CNPJ")
        If Len(Request.QueryString("NOME")) > 0 Then NOME = Request.QueryString("NOME")
        If Len(Request.QueryString("COD_CONTATO")) > 0 Then COD_CONTATO = Request.QueryString("COD_CONTATO")
        If Len(Request.QueryString("ATIVO")) > 0 Then ATIVO = Request.QueryString("ATIVO")
    End Sub
    Protected Sub cmb_Proxima_Visita_Lancar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_PROXIMA_VISITA_LANCAR.SelectedIndexChanged
        'habilita os desbilita os campos de proxima visita
        If cmb_PROXIMA_VISITA_LANCAR.Text = True Then
            cld_PROXIMA_VISITA.Enabled = True
            txt_OBJETIVO_PROXIMA.Enabled = True
        Else
            cld_PROXIMA_VISITA.Enabled = False
            txt_OBJETIVO_PROXIMA.Enabled = False
        End If
    End Sub
    Protected Sub cmd_Gravar_Click(sender As Object, e As EventArgs) Handles cmd_GRAVAR.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim sql As String
        'variaveis de tratamento de data
        Dim Data_Visita As String
        Dim Data_Visita_Valor As String
        Dim Data_Proxima As String
        Dim Data_Proxima_Valor As String

        'formata a data e o valor da data da visita
        Data_Visita = Left(cmb_DATA.Text, 4) & "-" & Mid(cmb_DATA.Text, 5, 2) & "-" & Mid(cmb_DATA.Text, 7, 2)
        Data_Visita_Valor = cmb_DATA.Text
        'formata o valor da data da proxima visita
        Data_Proxima_Valor = Format(Year(cld_PROXIMA_VISITA.SelectedDate), "0000") & Format(Month(cld_PROXIMA_VISITA.SelectedDate), "00") & Format(Day(cld_PROXIMA_VISITA.SelectedDate), "00")

        'Verifica se a data foi selecionada ou se foi selecionado para lançar uma proxima visita
        If Data_Proxima_Valor = 10101 Or cmb_PROXIMA_VISITA_LANCAR.Text = False Then Data_Proxima_Valor = "NULL"

        'verifica se foi agendada uma proxima visita
        If Data_Proxima_Valor = "NULL" Then
            Data_Proxima = Data_Proxima_Valor
        Else
            'verifica se a visita é superio ao dia atual
            If Data_Proxima_Valor > 0 Then
                If Data_Proxima_Valor <= Session("HOJE") Then
                    Alert("Você só pode agendar visitas para datas posteriores a hoje", False, "")
                    Exit Sub
                End If
            End If
            'formata a data da proxima visita
            Data_Proxima = Left(Data_Proxima_Valor, 4) & "-" & Mid(Data_Proxima_Valor, 5, 2) & "-" & Mid(Data_Proxima_Valor, 7, 2)
        End If


        'INSERE INFORMAÇÕES NO BANCO DE DADOS
        sql = ""
        sql = sql & " Insert Into TBL_VISITAS "
        sql = sql & " ("
        sql = sql & "COD_CONTATO, "
        'verifica se existe CNPJ - se existir libera o campo para lançar visita no cliente
        If CNPJ <> "" Then
            sql = sql & "CNPJ_ESTABELECIMENTO, "
        End If
        sql = sql & "DATA_VISITA, "
        sql = sql & "DATA_VISITA_VALOR, "
        sql = sql & "ID_PERIODO, "
        sql = sql & "ID_STATUS, "
        sql = sql & "MINUTOS, "
        sql = sql & "ID_OBJETIVO, "
        sql = sql & "COD_FOCO, "
        sql = sql & "COMENTARIOS, "
        sql = sql & "DATA_PROXIMA, "
        sql = sql & "DATA_PROXIMA_VALOR, "
        sql = sql & "ACAO_PROXIMA_VISITA, "
        sql = sql & "EMAIL_VISITANTE, "
        sql = sql & "INCLUSAO_EMAIL, "
        sql = sql & "INCLUSAO_DATA) "
        sql = sql & " Values ("
        sql = sql & " '" & COD_CONTATO & "', "
        'verifica se existe CNPJ - se existir libera o campo para lançar visita no cliente
        If CNPJ <> "" Then
            sql = sql & CNPJ & ","
        End If
        sql = sql & "'" & Data_Visita & "', "
        sql = sql & Data_Visita_Valor & ", "
        sql = sql & cmb_PERIODO_VISITA.Text & ", "
        sql = sql & cmb_STATUS.Text & ", "
        sql = sql & cmb_VISITAS_TEMPO.Text & ", "
        sql = sql & cmb_OBJETIVO.Text & ", "
        sql = sql & cmb_PRODUTO_FOCO.Text & ", "
        sql = sql & "'" & M.ConverteTexto(txt_COMENTARIOS.Text) & "', "
        'verifica se a visita é nula, se for , retira o apostrofo para não reconhecer como string
        If Data_Proxima_Valor = "NULL" Then
            sql = sql & Data_Proxima & ", "
        Else
            sql = sql & "'" & Data_Proxima & "', "
        End If
        sql = sql & Data_Proxima_Valor & ", "
        sql = sql & "'" & M.ConverteTexto(txt_OBJETIVO_PROXIMA.Text) & "', "
        sql = sql & "'" & Session("EMAIL_LOGIN") & "', "
        sql = sql & "'" & Session("EMAIL_LOGIN") & "', "
        sql = sql & M.RecuperaData & ")"

        ' EXECUTA OS COMANDOS SQL
        If M.ExecutarSQL(sql) = True Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "INCLUIU VISITA PARA CONTATO", Request.QueryString("ID_CONTATO") & " - " & Request.QueryString("NOME"))
            'Verifica se contato será associado a algum CLIENTE
            If Len(Request.QueryString("CNPJ")) > 0 Then
                Alert("VISITA INCLUIDA COM SUCESSO", True, "Estabelecimentos_Ficha.aspx?CNPJ=" & Request.QueryString("CNPJ"))
            Else
                Alert("VISITA INCLUIDA COM SUCESSO", True, "Contatos_Ficha.aspx?COD_CONTATO=" & Request.QueryString("COD_CONTATO"))
            End If
        Else
            Mensagem = "ERRO - INCLUSAO DE VISITA - " & Now() & Chr(10)
            Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN") & Chr(10)
            Mensagem = Mensagem & "SQL : " & sql & Chr(10)
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO AO INCLUIR VISITA PARA CONTATO", Session("CNPJ"))
            M.EnviarEmail("ERRO - INCLUSAO VISITA", Mensagem, True, False, "", "")
            Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", True, "Default.aspx")
        End If
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