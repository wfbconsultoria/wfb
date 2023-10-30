
Partial Class Medico_Estabelecimento_Editar
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Medico_Estabelecimento_Editar.aspx"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        Session("ID_MEDICO_ESTABELECIMENTO") = ""
        Session("ID_MEDICO_ESTABELECIMENTO") = Request.QueryString("ID_MEDICO_ESTABELECIMENTO")
        If Session("ID_MEDICO_ESTABELECIMENTO").ToString = "" Then Response.Redirect("Medicos_Lista.aspx")
        'RECUPERA REGISTRO
        sql = ""
        sql = "Select * From VIEW_MEDICOS_ESTABELECIMENTOS Where ID_MEDICO_ESTABELECIMENTO = '" & Session("ID_MEDICO_ESTABELECIMENTO") & "'"
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("EMAIL_REPRESENTANTE")) Then Session("EMAIL_REPRESENTANTE") = dtr("EMAIL_REPRESENTANTE")
            If Not IsDBNull(dtr("EMAIL_GERENTE_CONTA")) Then Session("EMAIL_GERENTE_CONTA") = dtr("EMAIL_GERENTE_CONTA")
            If Not IsDBNull(dtr("EMAIL_GERENTE")) Then Session("EMAIL_GERENTE") = dtr("EMAIL_GERENTE")
            If Not IsDBNull(dtr("EMAIL_DIRETOR")) Then Session("EMAIL_DIRETOR") = dtr("EMAIL_DIRETOR")
        End If
        If (Session("EMAIL_LOGIN") <> Session("EMAIL_REPRESENTANTE")) Then
            Alert("Você não tem autorização para editar o médico nesse estabelecimento.", True, "Medicos_Ficha.aspx?CRMUF=" & Session("CRMUF"))
        End If
        cnn.Close()
        dtr.Close()
    End Sub
    Protected Sub frv_MEDICO_ESTABELECIMENTO_ItemUpdated(sender As Object, e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles frv_MEDICO_ESTABELECIMENTO.ItemUpdated
        Response.Redirect("Medicos_Ficha.aspx?CRMUF=" & Session("CRMUF").ToString)
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
