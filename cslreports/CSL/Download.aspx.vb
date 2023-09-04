Imports System.IO

Partial Class Download
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Public jscript As String
    Dim Pagina As String = "Download.aspx"
    Dim Titulo As String = "Download - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
    Dim Pasta As String
    Dim raiz As String = ConfigurationManager.AppSettings("RAIZ_DOWNLOAD").ToString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = True 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = True 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = True 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = False 'Cordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = False 'Representante
        If Session("COD_PERFIL_LOGIN") = 10 Then Acesso = False 'Key Account
        If Session("COD_PERFIL_LOGIN") = 20 Then Acesso = True 'Visitante
        If Session("COD_PERFIL_LOGIN") = 30 Then Acesso = True 'Distribuidor
        If Session("DOWNLOAD") = True Then Acesso = True 'Download
        If Session("SISTEMA") = True Then Acesso = True 'Sistema
        
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

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
        lbl_TAMANHO.Text = ""
        lbl_EXTENCAO.Text = ""
    End Sub
    Protected Sub lstArquivos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstArquivos.SelectedIndexChanged
        Dim sql As String
        Dim CAMINHO As String
        Dim arquivo As FileInfo


        Pasta = raiz & "\" & TreeView1.SelectedNode.Value
        CAMINHO = Pasta & "\" & lstArquivos.SelectedItem.Text

        'recupera log de down do arquivo
        sql = ""
        sql = "SELECT TOP (50) ARQUIVO, USUARIO, DATA_EXTENSO, DATA FROM VIEW_LOG_DOWNLOAD WHERE ARQUIVO = '" & CAMINHO & "' ORDER BY DATA DESC"
        dts_LOG_DOWNLOAD.SelectCommand = sql
        dts_LOG_DOWNLOAD.DataBind()
        gdv_LOG_DOWNLOAD.DataBind()

        'recupera log de down do arquivo
        sql = ""
        sql = "SELECT TOP (1) * FROM VIEW_ARQUIVOS WHERE CAMINHO = '" & CAMINHO & "' ORDER BY DATA"
        dts_ARQUIVO.SelectCommand = sql
        dts_ARQUIVO.DataBind()
        frv_Arquivo.DataBind()

        'Obtêm os dados do arquivo pois o tamanho é requerido para efetuar o download
        arquivo = New FileInfo(CAMINHO)

        Dim fileSize As Integer = arquivo.Length
        lbl_TAMANHO.Text = fileSize
        lbl_EXTENCAO.Text = Path.GetExtension(arquivo.Name)

    End Sub
    Protected Sub TreeView1_SelectedNodeChanged(sender As Object, e As EventArgs) Handles TreeView1.SelectedNodeChanged
        Dim arquivos() As String
        Dim pastas() As String

        Dim index As Integer

        Pasta = raiz & "\" & TreeView1.SelectedNode.Value

        'Obtem a lista de arquivos no diretório imagens
        arquivos = Directory.GetFiles(Pasta)
        pastas = Directory.GetFiles(Pasta)

        'removemos o caminho dos arquivos a serem exibidos

        For index = 0 To pastas.Length - 1
                pastas(index) = New FileInfo(pastas(index)).Name
        Next index

        For index = 0 To arquivos.Length - 1
                arquivos(index) = New FileInfo(arquivos(index)).Name
        Next index

        'vincula a lista dos arquivos ao controle no formulário
        lstArquivos.DataSource = pastas
        lstArquivos.DataBind()

        lbl_Pasta.Text = TreeView1.SelectedNode.Value

    End Sub
    Protected Sub btnDownload_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDownload.ServerClick
        Dim arquivo As FileInfo
        Dim nomeArquivo As String
        Dim sql As String

        Pasta = raiz & "\" & TreeView1.SelectedNode.Value

        'Obtêm o nome compleo do arquivo selecionado
        nomeArquivo = Pasta & "\" & lstArquivos.SelectedItem.Text

        'Obtêm os dados do arquivo pois o tamanho é requerido para efetuar o download
        arquivo = New FileInfo(nomeArquivo)
        'envia para o browser
        Response.Clear()
        Response.AddHeader("Content-Disposition", "attachment; filename=" & lstArquivos.SelectedItem.Text)
        Response.AddHeader("Content-Length", arquivo.Length.ToString())
        Response.ContentType = "application/octet-stream"
        Response.WriteFile(nomeArquivo)

        'GRAVA LOG NA TABELA TBL_LOG_SITE
        sql = ""
        sql = sql & " Insert Into TBL_LOG_DOWNLOAD "
        sql = sql & " (SESSION_ID,IP,EMAIL,DATA,ANO,MES,DIA,HORA,MINUTO,SEGUNDO,ARQUIVO) "
        sql = sql & " Values ("
        sql = sql & "'" & Session("SESSAO_LOGIN").ToString & "', "
        sql = sql & "'" & Session("IP_LOGIN").ToString & "', "
        sql = sql & "'" & Session("EMAIL_LOGIN").ToString & "', "
        sql = sql & M.RecuperaData & ", "
        sql = sql & Left(M.RecuperaData, 4) & ", " 'ANO
        sql = sql & Mid(M.RecuperaData, 5, 2) & ", " 'MES
        sql = sql & Mid(M.RecuperaData, 7, 2) & ", " 'DIA
        sql = sql & Mid(M.RecuperaData, 9, 2) & ", " 'HORA
        sql = sql & Mid(M.RecuperaData, 11, 2) & ", " 'MINUTO
        sql = sql & Mid(M.RecuperaData, 13, 2) & ", " 'SEGUNDO
        sql = sql & "'" & nomeArquivo & "')"
        M.ExecutarSQL(sql)

        'GRAVA LOG DE ACESSO AO SISTEMA
        M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "LOGOU COM SUCESSO", "")

        Response.End()
    End Sub
    Protected Function Alert(ByVal Texto_Mensagem As String, ByVal Redirecionar As Boolean, ByVal Pagina As String) As Boolean
        Dim jscript As String
        'CAIXA DE MENSAGEM
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