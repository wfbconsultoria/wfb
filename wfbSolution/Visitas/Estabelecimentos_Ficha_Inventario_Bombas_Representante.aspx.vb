
Partial Class Estabelecimentos_Ficha_Inventario_Bombas_Representante
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Estabelecimentos_Ficha_Inventario_Bombas_Representante.aspx"
    Dim Mensagem As String

    Dim cnn As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        'verifica se existe sessão de login
        If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Default.aspx")

        'Verifica se a existe variável de sessão para CNPJ
        Session("CNPJ") = ""
        Session("CNPJ") = Request.QueryString("CNPJ")
        If Session("CNPJ").ToString = "" Then Response.Redirect("Estabelecimentos_Localizar.aspx")

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
        lbl_ANO.Text = Session("ANO_ATUAL")

    End Sub
    Protected Sub cmd_Gravar_Click(sender As Object, e As EventArgs) Handles cmd_GRAVAR.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim sql As String

        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()
        'VERIFICA SE EXISTE LANÇAMENTO PARA O MODELO DE BOMBA NO MÊS
        sql = ""
        sql = "Select *  From TBL_BOMBAS_INVENTARIO_REPRESENTANTE WHERE CNPJ =" & Session("CNPJ") & " AND COD_GRUPO_BOMBA = " & cmb_MODELO_BOMBA.Text & " AND ANO = " & lbl_ANO.Text & " AND MES = " & cmb_MES.Text
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            sql = "Delete  From TBL_BOMBAS_INVENTARIO_REPRESENTANTE WHERE CNPJ =" & Session("CNPJ") & " AND COD_GRUPO_BOMBA = " & cmb_MODELO_BOMBA.Text & " AND ANO = " & lbl_ANO.Text & " AND MES = " & cmb_MES.Text
            M.ExecutarSQL(sql)
        End If

        'INSERE INFORMAÇÕES NO BANCO DE DADOS
        sql = ""
        sql = sql & " Insert Into TBL_BOMBAS_INVENTARIO_REPRESENTANTE "
        sql = sql & " ("
        sql = sql & "CNPJ, "
        sql = sql & "COD_GRUPO_BOMBA, ANO, MES, QTD, "
        sql = sql & "INCLUSAO_EMAIL, "
        sql = sql & "INCLUSAO_DATA) "
        sql = sql & " Values ("
        sql = sql & "'" & Session("CNPJ") & "', "
        sql = sql & "'" & cmb_MODELO_BOMBA.Text & "', "
        sql = sql & "'" & Session("ANO_ATUAL") & "', "
        sql = sql & "'" & cmb_MES.Text & "', "
        sql = sql & "'" & txt_QTD_BOMBA.Text & "', "

        'LOG INCLUSAO
        sql = sql & "'" & Session("EMAIL_LOGIN") & "', "
        sql = sql & M.RecuperaData & ")"

        ' EXECUTA OS COMANDOS SQL
        If M.ExecutarSQL(sql) = True Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "INVENTARIO BOMBA'", "Incluiu inventário de bomba de infusão no CNPJ " & Session("CNPJ") & " COD MODELO " & cmb_MODELO_BOMBA.Text & " QTD " & txt_QTD_BOMBA.Text)
            Alert("INCLUSÃO REALIZADA COM SUCESSO", True, "Estabelecimentos_Ficha_Inventario_Bombas_Representante.aspx?CNPJ=" & Session("CNPJ"))
        Else
            Mensagem = "ERRO - INCLUSAO DE INVENTARIO DE BOMBA - " & Now() & Chr(10)
            Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN")
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO AO INCLUIR INVENTARIO DE BOMBA", Session("CNPJ"))
            M.EnviarEmail("ERRO - INCLUSAO INVENTARIO DE BOMBA", Mensagem, True, False, "", "")
            Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", True, "Estabelecimentos_Ficha.aspx?CNPJ=" & Session("CNPJ"))
        End If

        cnn.Close()
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
