Imports System.IO

Partial Class Upload_Mapas
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Public jscript As String
    Dim Pagina As String = "Upload_Mapas.aspx"
    Dim Titulo As String = "Upload de Mapas - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
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
        If Session("UPLOAD_MAPAS") = True Then Acesso = True 'Upload de Mapas
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
    End Sub
    Protected Sub cmb_referencia_data_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_referencia_data.SelectedIndexChanged
        If cmb_referencia_data.Text = 0 Or cmb_Tipo_Mapa.Text = "0" Then
            lbl_Caminho.Text = "Nenhum caminho escolhido!"
        Else
            Caminho()
        End If
    End Sub

    Protected Sub cmb_Tipo_Mapa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Tipo_Mapa.SelectedIndexChanged
        If cmb_referencia_data.Text = 0 Or cmb_Tipo_Mapa.Text = "0" Then
            lbl_Caminho.Text = "Nenhum caminho escolhido!"
        Else
            Caminho()
        End If
    End Sub
    Protected Sub Caminho()
        Dim Arquivo As String
        Dim Arquivo_v As String
        Dim Mes_Atual As String
        Dim Ano_Atual As String

        'Configura a data para definir em qual pasta sera colocada os mapas Ex.: 2015\201503
        'sendo levado em consideração que se a referencia de data for Mensal, então será mês anterior, se for Parcial, será o mês atual
        If Month(Now()) = 1 Then
            If cmb_referencia_data.Text = 2 Then
                Ano_Atual = Year(Now()) - 1
            Else
                Ano_Atual = Year(Now())
            End If
        Else
            Ano_Atual = Year(Now())
        End If

        If Month(Now()) = 1 Then

            If cmb_referencia_data.Text = 2 Then
                Mes_Atual = 12
            Else
                If cmb_referencia_data.Text = 2 Then
                    If Month(Now()) < 10 Then
                        Mes_Atual = "0" & Month(Now()) - 1
                    Else
                        Mes_Atual = Month(Now()) - 1
                    End If
                Else
                    If Month(Now()) < 10 Then
                        Mes_Atual = "0" & Month(Now())
                    Else
                        Mes_Atual = Month(Now())
                    End If
                End If
            End If
        Else
            If cmb_referencia_data.Text = 2 Then
                If Month(Now()) < 10 Then
                    Mes_Atual = "0" & Month(Now()) - 1
                Else
                    Mes_Atual = Month(Now()) - 1
                End If
            Else
                If Month(Now()) < 10 Then
                    Mes_Atual = "0" & Month(Now())
                Else
                    Mes_Atual = Month(Now())
                End If
            End If
        End If
        'Link de referencia para upload e validações (Tirar espaços) = http:// www. encodedna.com/2013/02/multiple-file-upload-in-aspdotnet .htm
        'verifica se algum arquivo foi selecionado

        If cmb_Tipo_Mapa.Text = "Vendas" Then
            'carrega variavel com caminho visivel para o cliente
            Arquivo_v = "\Operacao\" & "CSL\" & "Mapas\" & cmb_Tipo_Mapa.Text & "\" & Ano_Atual
            'configura caminho que será colocado o arquivo
            Arquivo = raiz & "\Operacao\" & "CSL\" & "Mapas\" & cmb_Tipo_Mapa.Text & "\" & Ano_Atual

        ElseIf cmb_Tipo_Mapa.Text = "Cotas Venda" Then
            'carrega variavel com caminho visivel para o cliente
            Arquivo_v = "\Operacao\CSL\Calculo IV\Cotas\" & cmb_Tipo_Mapa.Text & "\" & Ano_Atual
            'configura caminho que será colocado o arquivo
            Arquivo = raiz & "\Operacao\CSL\Calculo IV\Cotas\" & cmb_Tipo_Mapa.Text & "\" & Ano_Atual

        ElseIf cmb_Tipo_Mapa.Text = "Cotas Demanda" Then
            'carrega variavel com caminho visivel para o cliente
            Arquivo_v = "\Operacao\CSL\Calculo IV\Cotas\" & cmb_Tipo_Mapa.Text & "\" & Ano_Atual
            'configura caminho que será colocado o arquivo
            Arquivo = raiz & "\Operacao\CSL\Calculo IV\Cotas\" & cmb_Tipo_Mapa.Text & "\" & Ano_Atual

        Else
            'carrega variavel com caminho visivel para o cliente
            Arquivo_v = "\Operacao\" & "CSL\" & "Mapas\" & cmb_Tipo_Mapa.Text & "\" & Ano_Atual & "\" & Ano_Atual & Mes_Atual
            'configura caminho que será colocado o arquivo
            Arquivo = raiz & "\Operacao\" & "CSL\" & "Mapas\" & cmb_Tipo_Mapa.Text & "\" & Ano_Atual & "\" & Ano_Atual & Mes_Atual
        End If
        lbl_Caminho.Text = Arquivo_v
        lbl_Caminho_Completo.Text = Arquivo
    End Sub
    Protected Sub btn_Upload_Enviar_Click(sender As Object, e As EventArgs) Handles btn_Upload_Enviar.Click
        Dim s1 As String
        Dim s2 As String
        Dim pos As Integer
        Dim arquivo As String
        Dim sql As String

        'configura arquivo para enviar
        s1 = fup_Mapas.PostedFile.FileName
        pos = s1.LastIndexOf("\") + 1
        s2 = s1.Substring(pos)

        arquivo = lbl_Caminho_Completo.Text & "\" & s2

        'Link de referencia para upload e validações (Tirar espaços) = http:// www. encodedna.com/2013/02/multiple-file-upload-in-aspdotnet .htm
        'verifica se algum arquivo foi selecionado
        Dim fileSize As Integer = fup_Mapas.PostedFile.ContentLength
        If fileSize < 20971520 Then
            If fup_Mapas.HasFile Then
                If Not File.Exists(arquivo) Then
                    Dim hpf As HttpPostedFile = fup_Mapas.PostedFile
                    'envia o arquivo
                    fup_Mapas.SaveAs(arquivo)
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
                    sql = sql & "'" & arquivo & "', "
                    sql = sql & "'" & M.ConverteTexto(txt_OBSERVACAO.Text) & "')"
                    M.ExecutarSQL(sql)
                    txt_OBSERVACAO.Text = ""
                    Alert("Arquivo(s) enviados com sucesso!", False, "")
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