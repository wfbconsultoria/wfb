
Partial Class Estabelcimentos_Alterar_Sistema
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Estabelcimentos_Alterar_Sistema.aspx"
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

        'VARIAVEIS DO LOOP
        Dim CNPJ_PARA As String
        Dim CNPJ_CNES As String
        Dim CNES_PARA As String
        Dim CNPJ As String

        CNPJ_PARA = ""
        CNPJ_CNES = ""
        CNES_PARA = ""
        CNPJ = ""
        For Each gdvrow As GridViewRow In gdv_Localizar.Rows
            CNPJ_PARA = CType(gdvrow.Cells(3).FindControl("txt_CNPJ_PARA"), TextBox).Text
            CNPJ_CNES = CType(gdvrow.Cells(4).FindControl("txt_CNPJ_CNES"), TextBox).Text
            CNES_PARA = CType(gdvrow.Cells(5).FindControl("txt_CNES_PARA"), TextBox).Text
            CNPJ = gdvrow.Cells(0).Text

            If CNPJ_PARA = "1" Then
                CNPJ_PARA = 0
            End If
            If CNPJ_CNES = "" Then
                CNPJ_CNES = 0
            End If
            If CNES_PARA = "" Then
                CNES_PARA = 0
            End If

            SQL = ""
            SQL = SQL & " UPDATE TBL_ESTABELECIMENTOS SET"
            SQL = SQL & " CNPJ_PARA = '" & CNPJ_PARA & "' "
            SQL = SQL & ", CNPJ_CNES = '" & CNPJ_CNES & "' "
            SQL = SQL & ", CNES_PARA = '" & CNES_PARA & "' "
            SQL = SQL & " WHERE CNPJ= " & M.Converte_Valor(CNPJ)
            If M.ExecutarSQL(SQL) = False Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO - ATUALIZAR CNES", "CNPJ: " & CNPJ)
                Mensagem = "ERRO  - ATUALIZAR CNES" & Chr(10)
                Mensagem = Mensagem & "CNPJ " & CNPJ & Chr(10)
                Mensagem = Mensagem & "SQL " & SQL & Chr(10)
                M.EnviarEmail("ERRO  - ATUALIZAR CNES", Mensagem, True, False, "", "")
                Alert("As atualizações não foram efeturadas, um e-mail foi enviado ao suporte do sistema paa correções", False, "")
                Exit Sub
            End If
        Next
        dts_Localizar.DataBind()
        gdv_Localizar.DataBind()
        Alert("Atualizações efetuadas", False, "")
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