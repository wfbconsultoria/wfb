
Partial Class Usuarios
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Usuarios_Atualizar.aspx"
    Dim EMAIL_USUARIO As String
    Dim NOME_USUARIO As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Verifica permisão de acesso da página
        If Session("COD_PERFIL_LOGIN") <> 0 Then
            Alert("Somente administradores têm acesso a esta funcionalidade", True, "Default.aspx")
        End If

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

        EMAIL_USUARIO = Session("EMAIL_USUARIO")
        NOME_USUARIO = Session("NOME_USUARIO")
        If txt_Acao.Text = "Gravar" Then Gravar()
        cmdGravar.Attributes.Add("onclick", "txt_Acao.value = 'Gravar';")
        txt_ANO_NASCIMENTO.Attributes.Add("OnKeyPress", "Digitar_Numeros(this);")
        txt_DIA_NASCIMENTO.Attributes.Add("OnKeyPress", "Digitar_Numeros(this);")
        Localizar()

        'Acesso SIstema
        If Session("SISTEMA") = True Then
            opt_Sistema.Visible = True
            opt_Upload.Visible = True
        End If
    End Sub

    Protected Sub Localizar()
        Dim CN As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String
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
            If Not IsDBNull(dtr("EMAIL")) Then txt_EMAIL.Text = dtr("EMAIL")
            If Not IsDBNull(dtr("NOME")) Then txt_NOME.Text = dtr("NOME")
            If Not IsDBNull(dtr("TERRITORIO")) Then txt_Territorio.Text = dtr("TERRITORIO")
            If Not IsDBNull(dtr("COD_PERFIL")) Then cmb_PERFIL.Text = dtr("COD_PERFIL")
            If Not IsDBNull(dtr("EMAIL_DIRETOR")) Then cmb_EMAIL_DIRETOR.Text = dtr("EMAIL_DIRETOR")
            If Not IsDBNull(dtr("EMAIL_GERENTE")) Then cmb_EMAIL_GERENTE.Text = dtr("EMAIL_GERENTE")
            If Not IsDBNull(dtr("EMAIL_COORDENADOR")) Then cmb_EMAIL_COORDENADOR.Text = dtr("EMAIL_COORDENADOR")
            If Not IsDBNull(dtr("ANO_NASCIMENTO")) Then txt_ANO_NASCIMENTO.Text = dtr("ANO_NASCIMENTO")
            If Not IsDBNull(dtr("MES_NASCIMENTO")) Then cmb_MES_NASCIMENTO.Text = dtr("MES_NASCIMENTO")
            If Not IsDBNull(dtr("DIA_NASCIMENTO")) Then txt_DIA_NASCIMENTO.Text = dtr("DIA_NASCIMENTO")
            If Not IsDBNull(dtr("TELEFONE")) Then txt_TELEFONE.Text = dtr("TELEFONE")
            If Not IsDBNull(dtr("INCLUSAO")) Then txtLogInclusao.Text = dtr("INCLUSAO")
            If Not IsDBNull(dtr("ALTERACAO")) Then txtLogAlteracao.Text = dtr("ALTERACAO")

            If Not IsDBNull(dtr("ATIVO")) Then opt_Ativo.Checked = dtr("ATIVO")
            If Not IsDBNull(dtr("BLOQUEADO")) Then opt_Bloqueado.Checked = dtr("BLOQUEADO")
            If Not IsDBNull(dtr("LOGIN")) Then opt_Login.Checked = dtr("LOGIN")
            If Not IsDBNull(dtr("DOWNLOAD")) Then opt_Download.Checked = dtr("DOWNLOAD")
            If Not IsDBNull(dtr("UPLOAD")) Then opt_Upload.Checked = dtr("UPLOAD")
            If Not IsDBNull(dtr("UPLOAD_MAPAS")) Then opt_Upload_Mapas.Checked = dtr("UPLOAD_MAPAS")
            If Not IsDBNull(dtr("SISTEMA")) Then opt_Sistema.Checked = dtr("SISTEMA")


            Session("NOME_USUARIO") = dtr("NOME").ToString
            NOME_USUARIO = Session("NOME_USUARIO").ToString
        End If
        dtr.Close()
        CN.Close()
        'Acesso SIstema
        If Session("SISTEMA") = True Then
            opt_Sistema.Visible = True
            opt_Upload.Visible = True
        End If
    End Sub

    Protected Sub Gravar()
        Dim M As New clsMaster
        Dim CN As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String
        Dim Mensagem As String

        'CONSISTE OS REGISTROS ANTES DE GRAVAR
        'VERIFICA SE O PERFIL FOI SELECIONADO
        If cmb_PERFIL.Text = "-1" Then
            Alert("Selecione o PERFIL do usuário!", False, "")
            Exit Sub
        End If
        

        'VERIFICA SE O PERFIL FOI MUDADO
        'ABRE CONEXAO
        CN.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        CN.Open()
        cmd.Connection = CN
        sql = ""
        sql = "Select COD_PERFIL From VIEW_USUARIOS Where EMAIL = '" & EMAIL_USUARIO & "'"
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        'VERIFICA SE EXISTEM SUBORDINADOS
        If dtr("COD_PERFIL").ToString <> cmb_PERFIL.Text Then
            If dtr("COD_PERFIL") = "1" Or dtr("COD_PERFIL") = "2" Or dtr("COD_PERFIL") = "3" Then
                sql = "Select * From  VIEW_USUARIOS Where EMAIL_DIRETOR = '" & EMAIL_USUARIO & "' OR EMAIL_GERENTE = '" & EMAIL_USUARIO & "' OR EMAIL_COORDENADOR = '" & EMAIL_USUARIO & "'"
                dtr.Close()
                cmd.CommandText = sql
                dtr = cmd.ExecuteReader
                If dtr.HasRows Then
                    Alert("Este usuário possui SUBORDINADOS, exclua TODOS antes de alterar o PERFIL", False, "")
                    dtr.Close()
                    CN.Close()
                    Exit Sub
                End If
            End If
        End If
        dtr.Close()
        CN.Close()

        'ATUALIZA O REGISTRO
        sql = ""
        sql = sql & " Update TBL_USUARIOS Set "
        sql = sql & " NOME = '" & M.ConverteTexto(txt_NOME.Text) & "' , "
        sql = sql & " TERRITORIO = '" & M.ConverteTexto(txt_Territorio.Text) & "' , "
        sql = sql & " COD_PERFIL = '" & cmb_PERFIL.Text & "', "
        sql = sql & " DIRETOR = '" & cmb_EMAIL_DIRETOR.Text & "' , "
        sql = sql & " GERENTE = '" & cmb_EMAIL_GERENTE.Text & "' , "
        sql = sql & " COORDENADOR = '" & cmb_EMAIL_COORDENADOR.Text & "', "
        sql = sql & " ANO_NASCIMENTO = " & M.Converte_Valor(txt_ANO_NASCIMENTO.Text) & ", "
        sql = sql & " MES_NASCIMENTO = " & M.Converte_Valor(cmb_MES_NASCIMENTO.Text) & ", "
        sql = sql & " DIA_NASCIMENTO = " & M.Converte_Valor(txt_DIA_NASCIMENTO.Text) & ", "
        sql = sql & " TELEFONE = '" & M.ConverteTexto(txt_TELEFONE.Text) & "', "
        sql = sql & " ATIVO = '" & opt_Ativo.Checked & "', "
        sql = sql & " BLOQUEADO = '" & opt_Bloqueado.Checked & "', "

        sql = sql & " LOGIN = '" & opt_Login.Checked & "', "
        sql = sql & " DOWNLOAD = '" & opt_Download.Checked & "', "
        sql = sql & " UPLOAD = '" & opt_Upload.Checked & "', "
        sql = sql & " UPLOAD_MAPAS = '" & opt_Upload_Mapas.Checked & "', "
        sql = sql & " SISTEMA = '" & opt_Sistema.Checked & "', "

        sql = sql & " ALTERACAO_EMAIL = '" & Session("EMAIL_LOGIN") & "', "
        sql = sql & " ALTERACAO_DATA = " & M.RecuperaData
        sql = sql & " Where EMAIL = '" & EMAIL_USUARIO & "'"
        
        If M.ExecutarSQL(sql) = True Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ALTEROU", EMAIL_USUARIO)
            Alert("Usuário atualizado com sucesso", True, "Usuarios_Atualizar.aspx")
            txt_Acao.Text = "Alteração ok"
        Else
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO", EMAIL_USUARIO)
            Mensagem = "ERRO - ATUALIZAÇÃO DE USUARIO - " & M.FormataData(M.RecuperaData) & Chr(10) & Chr(10)
            Mensagem = Mensagem & "E-mail alterado: " & EMAIL_USUARIO & Chr(10)
            Mensagem = Mensagem & "Nome: " & NOME_USUARIO & Chr(10)
            Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN") & Chr(10) & Chr(10) & Chr(10)
            Mensagem = Mensagem & "Esta mensagem foi enviada ao suporte da WFB Consultoria para verificação"
            M.EnviarEmail("ERRO - ATUALIZAÇÃO DE USUARIO", Mensagem, True, False, "", "")
            Alert("Não foi possível efetuar esta atualização, um e-mail foi enviado ao suporte da WFB Consultoria para verificação!", True, "Usuarios_Atualizar.aspx")
            txt_Acao.Text = "Não foi possível efetuar a alteração"
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

    Protected Sub cmdGravar_Click(sender As Object, e As EventArgs) Handles cmdGravar.Click
        Gravar()
    End Sub
End Class
