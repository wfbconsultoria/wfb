
Partial Class Estabelecimentos_Associar_Grupo2
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Estabelecimentos_Associar_Grupo2.aspx"
    Dim gdvRow As GridViewRow
    Dim cnn As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
        'CONTROLA OS ACESSO E FUNÇÕES CONFORME O PERFIL DE ACESSO
        If Session("SISTEMA") = False Then
            If Session("COD_PERFIL_LOGIN") = "0" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
            If Session("COD_PERFIL_LOGIN") = "1" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
            If Session("COD_PERFIL_LOGIN") = "2" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
            If Session("COD_PERFIL_LOGIN") = "3" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
            If Session("COD_PERFIL_LOGIN") = "4" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
            If Session("COD_PERFIL_LOGIN") = "5" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
            If Session("COD_PERFIL_LOGIN") = "6" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
            If Session("COD_PERFIL_LOGIN") = "7" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        End If
    End Sub
    Protected Sub cmd_Gravar_Click(sender As Object, e As System.EventArgs) Handles cmd_Gravar.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim Mensagem As String
        Dim SQL As String
        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()

        'VARIAVEIS DO LOOP
        Dim COD_GRUPO2 As String
        Dim CNPJ As String

        COD_GRUPO2 = ""
        CNPJ = ""
        For Each gdvrow As GridViewRow In gdv_Localizar.Rows
            COD_GRUPO2 = CType(gdvrow.Cells(3).FindControl("cmb_GRUPO2"), DropDownList).SelectedValue()
            CNPJ = gdvrow.Cells(0).Text

            SQL = ""
            SQL = SQL & " UPDATE TBL_ESTABELECIMENTOS SET"
            SQL = SQL & " COD_GRUPO2 = '" & COD_GRUPO2 & "' "
            SQL = SQL & " WHERE CNPJ= " & M.Converte_Valor(CNPJ)
            If M.ExecutarSQL(SQL) = False Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO - ATUALIZAR ASSOCIAÇÃO DE GRUPO 2", "CNPJ: " & CNPJ & " Cod Grupo: " & COD_GRUPO2)
                Mensagem = "ERRO  - ATUALIZAR GRUPO 2" & Chr(10)
                Mensagem = Mensagem & "CNPJ " & CNPJ & Chr(10)
                Mensagem = Mensagem & "Cod Grupo " & COD_GRUPO2 & Chr(10)
                M.EnviarEmail("ERRO  - ATUALIZAR GRUPO 2", Mensagem, True, False, "", "")
                Alert("As atualizações não foram efeturadas, um e-mail foi enviado ao suporte do sistema para correções", False, "")
                dts_GRUPO2.DataBind()
                gdv_Localizar.DataBind()
                Exit Sub
            End If
        Next
        Alert("Atualizações efetuadas", False, "")
        dts_GRUPO2.DataBind()
        gdv_Localizar.DataBind()
    End Sub
    Protected Sub Atualiza_Relatório()

        sql = " Select * From VIEW_ESTABELECIMENTOS_001_DETALHADO WHERE CNPJ <> 0 "

        'ESTADO
        If cmb_ESTADO.Text <> "@" Then sql = sql & "and UF = '" & cmb_ESTADO.Text & "' "

        'MUNICIPIO
        If cmb_MUNICIPIO.Text <> "@" Then sql = sql & "and MUNICIPIO = '" & cmb_MUNICIPIO.Text & "' "

        'ESFERA
        If cmb_ESFERA.Text <> "@" Then sql = sql & " and ESFERA = '" & cmb_ESFERA.Text & "' "

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
    Protected Sub cmd_Excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Excel.Click
        'EXPORTA GRIG DE LOCALIZACAO PARA O EXCEL
        M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "EXPORTOU EXCEL", "")
        gdv_Localizar.Caption = "Estabelecimentos Grupos 2"
        gdv_Localizar.AllowPaging = "False"
        gdv_Localizar.DataBind()
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment;filename=SETORIZACAO.xls")
        Response.Charset = ""
        EnableViewState = False
        Controls.Add(frm)
        frm.Controls.Add(gdv_Localizar)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        gdv_Localizar.AllowPaging = "True"
        gdv_Localizar.DataBind()
    End Sub
End Class