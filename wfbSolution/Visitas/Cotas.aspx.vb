
Partial Class Cotas
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Cotas.aspx"
    Dim UF As String
    Dim SQL As String
    Dim ANO As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Session("COD_PERFIL_LOGIN") = "0" Then 0

        If Session("COD_PERFIL_LOGIN") = "1" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "2" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "3" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "4" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "5" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "6" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "7" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
        If cmb_ANOS_Filtro.Text = "" Then
            ANO = Year(Now())
        Else
            ANO = cmb_ANOS_Filtro.Text
        End If
        'Seleciona registro conforme perfil para a Grid Cotas
        SQL = "Select * From VIEW_COTAS Where ANO = " & ANO
        If Session("PERFIL_LOGIN") = "Representante" Then SQL = "Select * FRom VIEW_COTAS Where EMAIL = '" & Session("EMAIL_LOGIN") & "'and ANO = " & ANO
        If Session("PERFIL_LOGIN") = "Coordenador" Then SQL = "Select * From VIEW_COTAS Where EMAIL = '" & Session("EMAIL_LOGIN") & "' and ANO = " & ANO & " or EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "' and ANO = " & ANO
        If Session("PERFIL_LOGIN") = "Gerente" Then SQL = "Select * From VIEW_COTAS Where EMAIL = '" & Session("EMAIL_LOGIN") & "' and ANO = " & ANO & " or EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "' and ANO = " & ANO & " or EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' and ANO = " & ANO
        'If Session("PERFIL_LOGIN") = "Gerente" Then SQL = "Select * FRom VIEW_COTAS Where EMAIL_GERENTE = '" & Session("EMAIL") & "' and ANO = " & cmb_ANOS_Filtro.Text
        SQL = SQL & " ORDER BY PERFIL, NOME "
        dts_Cotas.SelectCommand = SQL

        SQL = "Select * From VIEW_USUARIOS "
        If Session("PERFIL_LOGIN") = "Representante" Then SQL = "Select * FRom VIEW_USUARIOS Where EMAIL = '" & Session("EMAIL_LOGIN") & "'"
        If Session("PERFIL_LOGIN") = "Coordenador" Then SQL = "Select * From VIEW_USUARIOS Where EMAIL = '" & Session("EMAIL_LOGIN") & "' or EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "'"
        If Session("PERFIL_LOGIN") = "Gerente" Then SQL = "Select * From VIEW_USUARIOS Where EMAIL = '" & Session("EMAIL_LOGIN") & "' or EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "' or EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "'"
        SQL = SQL & " ORDER BY USUARIO, PERFIL"
        dts_Usuarios.SelectCommand = SQL
    End Sub

    Protected Sub frv_Cotas_ItemDeleted(sender As Object, e As System.Web.UI.WebControls.FormViewDeletedEventArgs) Handles frv_Cotas.ItemDeleted
        dts_Cotas.DataBind()
        gdv_Cotas.DataBind()
    End Sub

    Protected Sub frv_Cotas_ItemInserted(sender As Object, e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles frv_Cotas.ItemInserted
        dts_Cotas.DataBind()
        gdv_Cotas.DataBind()
    End Sub

    Protected Sub frv_Cotas_ItemUpdated(sender As Object, e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles frv_Cotas.ItemUpdated
        dts_Cotas.DataBind()
        gdv_Cotas.DataBind()
    End Sub
    Protected Sub cmd_Excel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Excel.Click

        gdv_Cotas.Caption = "Cotas " & cmb_ANOS_Filtro.Text
        gdv_Cotas.AllowPaging = "False"
        gdv_Cotas.DataBind()
        Dim tw As New System.IO.StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
        Dim frm As HtmlForm = New HtmlForm()
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("content-disposition", "attachment;filename=Cotas " & cmb_ANOS_Filtro.Text & ".xls")
        Response.Charset = ""
        EnableViewState = False
        Controls.Add(frm)
        frm.Controls.Add(gdv_Cotas)
        frm.RenderControl(hw)
        Response.Write(tw.ToString())
        Response.End()
        gdv_Cotas.AllowPaging = "True"
        gdv_Cotas.DataBind()
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
