
Partial Class Estabelecimentos_Setorizacao_Previsao_Localizar
    Inherits System.Web.UI.Page
    'Váriaveis Padrão
    Dim M As New clsMaster
    Public jscript As String
    Dim Pagina As String = "Estabelecimentos_Setorizacao_Previsao_Localizacao.aspx"
    Dim Titulo As String = "Manutenção de Setor - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean

    'Váriáveis da Página
    Dim gdvRow As GridViewRow
    Dim Mensagem As String

    Dim cnn As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = False 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = True 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = True 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = True 'Cordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = True 'Representante
        If Session("COD_PERFIL_LOGIN") = 10 Then Acesso = False 'Key Account
        If Session("COD_PERFIL_LOGIN") = 20 Then Acesso = False 'Visitante
        If Session("COD_PERFIL_LOGIN") = 30 Then Acesso = False 'Distribuidor
        If Session("ADMINISTRADOR_SETORIZACAO") = True Then Acesso = True 'ADMINISTRADOR DE SETORIZACAO
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
        'CONTROLA OS ACESSO E FUNÇÕES CONFORME O PERFIL DE ACESSO
        sql = ""
        sql = "Select * From VIEW_USUARIOS Where COD_PERFIL = '4' AND BLOQUEADO = 'False' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "0" Then
            sql = "Select * From VIEW_USUARIOS Where COD_PERFIL = '4' AND BLOQUEADO = 'False' ORDER BY NOME"
        End If
        If Session("COD_PERFIL_LOGIN") = "1" Then
            sql = "Select * From VIEW_USUARIOS Where EMAIL_DIRETOR= '" & Session("EMAIL_LOGIN") & "' AND COD_PERFIL = '4' AND BLOQUEADO = 'False' ORDER BY NOME"
        End If

        If Session("COD_PERFIL_LOGIN") = "2" Then
            sql = "Select * From VIEW_USUARIOS Where EMAIL_GERENTE= '" & Session("EMAIL_LOGIN") & "' AND COD_PERFIL = '4' AND BLOQUEADO = 'False' ORDER BY NOME"
        End If
        If Session("COD_PERFIL_LOGIN") = "3" Then
            sql = "Select * From VIEW_USUARIOS Where EMAIL_COORDENADOR= '" & Session("EMAIL_LOGIN") & "' AND COD_PERFIL = '4' AND BLOQUEADO = 'False' ORDER BY NOME"
        End If
        If Session("COD_PERFIL_LOGIN") = "4" Then
            sql = "Select * From VIEW_USUARIOS Where EMAIL = '" & Session("EMAIL_LOGIN") & "' AND BLOQUEADO = 'False' ORDER BY NOME"
        End If
        If Session("ADMINISTRADOR_SETORIZACAO") = True Then
            sql = "Select * From VIEW_USUARIOS Where COD_PERFIL = '4' AND BLOQUEADO = 'False' ORDER BY NOME"
        End If

        dts_Usuarios.SelectCommand = sql
    End Sub
    Protected Sub gdv_Localizar_RowDataBound1(sender As Object, e As GridViewRowEventArgs) Handles gdv_Localizar.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cmb_EMAIL_REPRESENTANTE As DropDownList = DirectCast(e.Row.FindControl("cmb_EMAIL_REPRESENTANTE"), DropDownList)
            Dim chk_Excluir As CheckBox = DirectCast(e.Row.FindControl("chk_Excluir"), CheckBox)

            If Session("COD_PERFIL_LOGIN") = "0" Then
                cmb_EMAIL_REPRESENTANTE.Enabled = False
                chk_Excluir.Enabled = False
            End If
            If Session("COD_PERFIL_LOGIN") = "1" Then
                cmb_EMAIL_REPRESENTANTE.Enabled = True
                chk_Excluir.Enabled = False
            End If

            If Session("COD_PERFIL_LOGIN") = "2" Then
                cmb_EMAIL_REPRESENTANTE.Enabled = True
                chk_Excluir.Enabled = False
            End If
            If Session("COD_PERFIL_LOGIN") = "3" Then
                cmb_EMAIL_REPRESENTANTE.Enabled = True
                chk_Excluir.Enabled = False
            End If
            If Session("COD_PERFIL_LOGIN") = "4" Then
                cmb_EMAIL_REPRESENTANTE.Enabled = False
                chk_Excluir.Enabled = False
            End If
            If Session("ADMINISTRADOR_SETORIZACAO") = True Then
                cmb_EMAIL_REPRESENTANTE.Enabled = True
                chk_Excluir.Enabled = True
            End If
        End If
    End Sub
    Protected Sub Atualiza_Relatório()
        sql = " Select * From VIEW_SETORIZACAO_PREVISAO WHERE CNPJ <> 0 "

        'ESTADO
        If cmb_ESTADO.Text <> "@" Then sql = sql & "and UF = '" & cmb_ESTADO.Text & "' "

        'MUNICIPIO
        If cmb_MUNICIPIO.Text <> "@" Then sql = sql & "and MUNICIPIO = '" & cmb_MUNICIPIO.Text & "' "

        'ESFERA
        If cmb_ESFERA.Text <> "@" Then sql = sql & " and ESFERA = '" & cmb_ESFERA.Text & "' "

        'REPRESENTANTE
        If cmb_EMAIL_REPRESENTANTE.Text <> "@" Then sql = sql & " and EMAIL_REPRESENTANTE = '" & cmb_EMAIL_REPRESENTANTE.Text & "' "

        sql = sql & "ORDER BY ESTABELECIMENTO"

        dts_Localizar.SelectCommand = sql
    End Sub
    Protected Sub cmb_ESTADO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_ESTADO.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub

    Protected Sub cmb_MUNICIPIO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_MUNICIPIO.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub

    Protected Sub cmb_ESFERA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_ESFERA.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub

    Protected Sub cmb_EMAIL_REPRESENTANTE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_EMAIL_REPRESENTANTE.SelectedIndexChanged
        Atualiza_Relatório()
    End Sub
    Protected Sub cmd_Gravar_Click(sender As Object, e As System.EventArgs) Handles cmd_Gravar.Click
        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()

        'VARIAVEIS DO LOOP
        Dim EMAIL As String
        Dim TARGET As String
        Dim CNPJ As String
        Dim EXCLUIR As Boolean

        'limpa variaveis
        EMAIL = ""
        TARGET = ""
        CNPJ = ""


        For Each gdvrow As GridViewRow In gdv_Localizar.Rows
            EXCLUIR = CType(gdvrow.Cells(7).FindControl("chk_Excluir"), CheckBox).Checked()
            EMAIL = CType(gdvrow.Cells(6).FindControl("cmb_EMAIL_REPRESENTANTE"), DropDownList).SelectedValue()
            TARGET = CType(gdvrow.Cells(5).FindControl("cmb_TARGET"), DropDownList).SelectedValue()
            CNPJ = gdvrow.Cells(0).Text
            sql = "SELECT CNPJ FROM TBL_SETORIZACAO_PREVISAO WHERE CNPJ = " & M.Converte_Valor(CNPJ) & " AND EMAIL = '" & EMAIL & "'"
            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader

            If dtr.HasRows Then
                dtr.Read()
                If EMAIL <> cmb_EMAIL_REPRESENTANTE.Text Or EXCLUIR = True Then
                    sql = "DELETE FROM TBL_SETORIZACAO_PREVISAO WHERE CNPJ = " & M.Converte_Valor(CNPJ) & " AND EMAIL = '" & cmb_EMAIL_REPRESENTANTE.Text & "'"
                    M.ExecutarSQL(sql)

                Else
                    sql = ""
                    sql = sql & " UPDATE TBL_SETORIZACAO_PREVISAO SET"
                    sql = sql & " TARGET = '" & TARGET & "', "
                    sql = sql & " ALTERACAO_DATA = " & M.RecuperaData & ", "
                    sql = sql & " ALTERACAO_EMAIL = '" & Session("EMAIL_LOGIN") & "'"
                    sql = sql & " WHERE CNPJ= " & M.Converte_Valor(CNPJ) & " AND EMAIL = '" & cmb_EMAIL_REPRESENTANTE.Text & "'"
                End If
            Else
                sql = ""
                sql = sql & " UPDATE TBL_SETORIZACAO_PREVISAO SET"
                sql = sql & " EMAIL = '" & EMAIL & "', "
                sql = sql & " TARGET = '" & TARGET & "', "
                sql = sql & " INCLUSAO_DATA = " & M.RecuperaData & ", "
                sql = sql & " INCLUSAO_EMAIL = '" & Session("EMAIL_LOGIN") & "', "
                sql = sql & " TRANSFERIDO_POR = '" & Session("EMAIL_LOGIN") & "', "
                sql = sql & " TRANSFERIDO_DE = '" & cmb_EMAIL_REPRESENTANTE.Text & "', "
                sql = sql & " TRANSFERIDO_DATA = " & M.RecuperaData & " "
                sql = sql & " WHERE CNPJ= " & M.Converte_Valor(CNPJ) & " AND EMAIL = '" & cmb_EMAIL_REPRESENTANTE.Text & "'"
            End If
            dtr.Close()
            M.ExecutarSQL(sql)
        Next

        dts_Localizar.DataBind()
        gdv_Localizar.DataBind()
        Alert("Atualizações efetuadas", False, "")
        Atualiza_Relatório()
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