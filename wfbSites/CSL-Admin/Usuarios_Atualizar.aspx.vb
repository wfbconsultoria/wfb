
Partial Class Usuarios
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim Pagina As String = "Usuarios_Atualizar.aspx"
    Dim Titulo As String = "Manutenção de Usuario - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean

    'Váriáveis da Página
    Dim EMAIL_USUARIO As String
    Dim NOME_USUARIO As String
    Dim sql As String
    Dim Mensagem As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = True 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = False 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = False 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = False 'Cordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = False 'Representante
        If Session("COD_PERFIL_LOGIN") = 10 Then Acesso = False 'Key Account
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
        frv_Usuarios.DefaultMode = FormViewMode.Edit
        EMAIL_USUARIO = Request.QueryString("email").ToString
        Localizar()
    End Sub
    Protected Sub frv_Usuarios_ItemUpdated(sender As Object, e As FormViewUpdatedEventArgs) Handles frv_Usuarios.ItemUpdated

        'ATUALIZA O REGISTRO
        sql = ""
        sql = sql & " Update TBL_USUARIOS Set "
        sql = sql & " ALTERACAO_EMAIL = '" & Session("EMAIL_LOGIN") & "', "
        sql = sql & " ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & Request.QueryString("email").ToString & "'"

        If M.ExecutarSQL(sql) = True Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ALTEROU", EMAIL_USUARIO)
            Alert("Usuário atualizado com sucesso", True, "Usuarios_Localizacao.aspx")

        Else
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO", EMAIL_USUARIO)
            Mensagem = "ERRO - ATUALIZAÇÃO DE USUARIO - " & M.FormataData(M.RecuperaData) & Chr(10) & Chr(10)
            Mensagem = Mensagem & "E-mail alterado: " & EMAIL_USUARIO & Chr(10)
            Mensagem = Mensagem & "Nome: " & NOME_USUARIO & Chr(10)
            Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN") & Chr(10) & Chr(10) & Chr(10)
            Mensagem = Mensagem & "Esta mensagem foi enviada ao suporte da WFB Consultoria para verificação"
            M.EnviarEmail("ERRO - ATUALIZAÇÃO DE USUARIO", Mensagem, True, False, "", "")
            Alert("Não foi possível efetuar esta atualização, um e-mail foi enviado ao suporte da WFB Consultoria para verificação!", False, "")

        End If

    End Sub
    Protected Sub Localizar()
        Dim CN As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader

        'ABRE CONEXAO
        CN.ConnectionString = M.cnnStr
        CN.Open()
        cmd.Connection = CN

        'RECUPERA REGISTRO
        sql = ""
        sql = "Select * From VIEW_USUARIOS Where EMAIL = '" & EMAIL_USUARIO & "'"
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("INCLUSAO")) Then txtLogInclusao.Text = dtr("INCLUSAO")
            If Not IsDBNull(dtr("ALTERACAO")) Then txtLogAlteracao.Text = dtr("ALTERACAO")
        End If
        dtr.Close()
        CN.Close()
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