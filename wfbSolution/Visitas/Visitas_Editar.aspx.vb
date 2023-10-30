
Partial Class Visitas_Editar
    Inherits System.Web.UI.Page
    Dim Pagina As String = "Visitas_Editar.aspx"
    Dim M As New clsMaster
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String

        If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Default.aspx")
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
        'ABRE CONEXAO
        cnn.ConnectionString = M.cnnStr
        cnn.Open()
        cmd.Connection = cnn
        Session("ID_VISITA") = ""
        Session("ID_VISITA") = Request.QueryString("ID_VISITA")
        If Session("ID_VISITA").ToString = "" Then Response.Redirect("Menu_Listas.aspx")
        'RECUPERA REGISTRO
        sql = ""
        sql = "Select * From VIEW_VISITAS_GERAL Where ID_VISITA = '" & Session("ID_VISITA") & "'"
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("EMAIL_VISITANTE")) Then Session("EMAIL_VISITANTE") = dtr("EMAIL_VISITANTE")
        End If
        If (Session("EMAIL_LOGIN") <> Session("EMAIL_VISITANTE")) Then
            Alert("Você não tem autorização para editar essa visita.", True, "Visita_Ficha.aspx?ID_VISITA=" & Session("ID_VISITA") & "&PAGINA=" & Session("PAGINA"))
        End If
        cnn.Close()
        dtr.Close()

    End Sub

    Protected Sub Gravar()
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim sql As String
        Dim Mensagem As String
        Dim Data_Proxima_visita As Double
        Dim Data_Hoje As Double

        Data_Proxima_visita = Format(Year(cld_Proxima_Visita.SelectedDate), "0000") & Format(Month(cld_Proxima_Visita.SelectedDate), "00") & Format(Day(cld_Proxima_Visita.SelectedDate), "00")
        Data_Hoje = Format(Year(Now()), "0000") & Format(Month(Now()), "00") & Format(Day(Now()), "00")

        If (Data_Proxima_visita = 10101) And (txt_COMENTARIOS0.Text = "") Then
            Alert("Nenhum dado foi atualizado", True, "Visita_Ficha.aspx?ID_VISITA=" & Session("ID_VISITA"))
        Else
            'ATUALIZA O REGISTRO
            sql = ""
            sql = sql & " Update TBL_VISITAS_GERAL Set "
            If (Data_Proxima_visita <> 10101) Then
                If (Data_Proxima_visita > Data_Hoje) Then
                    If (txt_COMENTARIOS0.Text <> "") Then
                        sql = sql & " PROXIMA_VISITA = " & Data_Proxima_visita & ", "
                    Else
                        sql = sql & " PROXIMA_VISITA = " & Data_Proxima_visita & " "
                    End If
                Else
                    Alert("A data deve ser superior ao dia de hoje!", False, "")
                End If
            End If
            If (txt_COMENTARIOS0.Text <> "") Then
                sql = sql & " ACAO_PROXIMA_VISITA = '" & M.ConverteTexto(txt_COMENTARIOS0.Text) & "' "
            End If
            sql = sql & " WHERE ID_VISITA = '" & Session("ID_VISITA") & "'"
            ' EXECUTA OS COMANDOS SQL
            If M.ExecutarSQL(sql) = True Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ALTEROU VISITA :'", Session("ID_VISITA") & "'")
                Alert("VISITA ATUALIZADA COM SUCESSO", True, "Visita_Ficha.aspx?ID_VISITA=" & Session("ID_VISITA") & "&PAGINA=" & Session("PAGINA"))
            Else
                Mensagem = "ERRO - ALTERAR VISITA - " & Now() & Chr(10)
                Mensagem = Mensagem & "ID DA VISITA: " & Session("ID_VISITA") & Chr(10)
                Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN")
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO AO ALTERAR VISITA", Session("ID_VISITA"))
                M.EnviarEmail("ERRO - ALTERAR VISITA", Mensagem, True, False, "", "")
                Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
            End If
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

    Protected Sub cmd_GRAVAR_Click(sender As Object, e As EventArgs) Handles cmd_GRAVAR.Click
        Gravar()
    End Sub

    Protected Sub btn_CANCELAR_Click(sender As Object, e As EventArgs) Handles btn_CANCELAR.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim sql As String
        Dim Mensagem As String

        'ATUALIZA O REGISTRO
        sql = ""
        sql = sql & " Update TBL_VISITAS_GERAL Set "
        sql = sql & " PROXIMA_VISITA = '0' "
        sql = sql & " WHERE ID_VISITA = '" & Session("ID_VISITA") & "'"

        ' EXECUTA OS COMANDOS SQL
        If M.ExecutarSQL(sql) = True Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ALTEROU VISITA :'", Session("ID_VISITA") & "'")
            Alert("VISITA ATUALIZADA COM SUCESSO", True, "Visita_Ficha.aspx?ID_VISITA=" & Session("ID_VISITA") & "&PAGINA=" & Session("PAGINA"))
        Else
            Mensagem = "ERRO - ALTERAR VISITA - " & Now() & Chr(10)
            Mensagem = Mensagem & "ID DA VISITA: " & Session("ID_VISITA") & Chr(10)
            Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN")
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO AO ALTERAR VISITA", Session("ID_VISITA"))
            M.EnviarEmail("ERRO - ALTERAR VISITA", Mensagem, True, False, "", "")
            Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
        End If
        cnn.Close()
    End Sub
End Class