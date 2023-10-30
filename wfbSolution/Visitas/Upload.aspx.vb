Imports System.IO

Partial Class Upload
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Public jscript As String
    Dim Pagina As String = "Upload.aspx"
    Dim Titulo As String = "Upload - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
    Dim Pasta As String
    Dim Arquivo As String
    Dim raiz As String = ConfigurationManager.AppSettings("RAIZ_DOWNLOAD").ToString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        If Session("UPLOAD") = True Then Acesso = True 'Upload
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
            Alert("Seu perfil de usuário não permite acesso a esta página!", True, "Estabelecimentos_Ficha.aspx?CNPJ=" & Request.QueryString("CNPJ"))
        End If
        '____________________________________________________________________________________________________________________________________________

        'Código customizado da página

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
    End Sub
    Protected Sub Atualiza_Arquivos()
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
        lbl_raiz.Text = Pasta
    End Sub
    Protected Sub TreeView1_SelectedNodeChanged(sender As Object, e As EventArgs) Handles TreeView1.SelectedNodeChanged
        Atualiza_Arquivos()
    End Sub
    Protected Sub btn_Upload_Enviar_Click(sender As Object, e As EventArgs) Handles btn_Upload_Enviar.Click
        Dim sql As String
        Dim s1 As String
        Dim s2 As String
        Dim pos As Integer

        'configura arquivo para enviar
        s1 = fup_Mapas.PostedFile.FileName
        pos = s1.LastIndexOf("\") + 1
        s2 = s1.Substring(pos)

        'carrega variavel com caminho que será armazenado o arquivo
        Arquivo = lbl_raiz.Text & "\" & s2

        'Link de referencia para upload e validações (Tirar espaços) = http:// www. encodedna.com/2013/02/multiple-file-upload-in-aspdotnet .htm
        'verifica se algum arquivo foi selecionado
        Dim fileSize As Integer = fup_Mapas.PostedFile.ContentLength
        If fileSize < 20971520 Then
            If fup_Mapas.HasFile Then
                If Not File.Exists(Arquivo) Then
                    Dim hpf As HttpPostedFile = fup_Mapas.PostedFile
                    'envia o arquivo
                    fup_Mapas.PostedFile.SaveAs(Arquivo)

                    'GRAVA LOG NA TABELA TBL_LOG_SITE
                    sql = ""
                    sql = sql & " Insert Into TBL_ARQUIVOS "
                    sql = sql & " (SESSION_ID, INCLUSAO_EMAIL, INCLUSAO_DATA, ANO, MES, DIA, HORA, MINUTO, SEGUNDO, NOME, TAMANHO, EXTENSAO, CAMINHO, OBSERVACAO) "
                    sql = sql & " Values ("
                    sql = sql & "'" & Session("SESSAO_LOGIN").ToString & "', "
                    sql = sql & "'" & Session("EMAIL_LOGIN").ToString & "', "
                    sql = sql & M.RecuperaData & ", "
                    sql = sql & Left(M.RecuperaData, 4) & ", " 'ANO
                    sql = sql & Mid(M.RecuperaData, 5, 2) & ", " 'MES
                    sql = sql & Mid(M.RecuperaData, 7, 2) & ", " 'DIA
                    sql = sql & Mid(M.RecuperaData, 9, 2) & ", " 'HORA
                    sql = sql & Mid(M.RecuperaData, 11, 2) & ", " 'MINUTO
                    sql = sql & Mid(M.RecuperaData, 13, 2) & ", " 'SEGUNDO
                    sql = sql & "'" & fup_Mapas.PostedFile.FileName & "', "
                    sql = sql & "'" & fileSize & "', "
                    sql = sql & "'" & Path.GetExtension(hpf.FileName) & "', "
                    sql = sql & "'" & Arquivo & "', "
                    sql = sql & "'" & M.ConverteTexto(txt_OBSERVACAO.Text) & "')"
                    M.ExecutarSQL(sql)
                    txt_OBSERVACAO.Text = ""
                    Alert("Arquivo(s) enviados com sucesso!", False, "")
                    Atualiza_Arquivos()
                Else
                    Alert("Já existe um arquivo com este nome nesta pasta! Caso queira substitui-lo, entre em contato com um administrador.", False, "")
                End If
            Else
                Alert("Nenhuma Arquivo selecionado! Selecione um arquivo para enviar.", False, "")
            End If
        Else
            Alert("O tamanho do arquivo não pode ser superior à 20 MB!", False, "")
        End If
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