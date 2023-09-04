
Partial Class lojas_WFB_CheckIn_Form_Terceiros
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly l As New clsLojas
    ReadOnly c As New clsColaboradores
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim LogIP As String = Request.ServerVariables("REMOTE_ADDR").ToString
        Dim LogSession As String = Session.SessionID.ToString
        Dim LogBrowser As String = Request.ServerVariables("HTTP_USER_AGENT").ToString
        If Request.QueryString("IdColaborador") = "" Then Response.Redirect("Default.aspx")

        m.ExecuteSQL("Update tb_Colaboradores Set CheckIn = 1 , Checkin_IP = '" & LogIP & "', CheckIn_Browser = '" & LogBrowser & "', CheckIn_Session = '" & LogSession & "'  Where Id = '" & Request.QueryString("IdColaborador").ToString & "'")
        RecoverRecord()

    End Sub

    Sub RecoverRecord(Optional NewIdKey As String = "")
        l.GetInfoLoja()
        c.GetInfoColaborador(Request.QueryString("IdColaborador"))
        If c.ColaboradorCheckIn_Status = "Presente" Then
            txt_Titulo.InnerHtml = "SEJA BEM VINDO"
        Else
            txt_Titulo.InnerHtml = "AGRADECE A SUA PRESENÇA"
        End If
        txt_Loja.InnerHtml = l.Loja
        txt_Nome.InnerHtml = c.ColaboradorNome.ToString
        txt_Empresa.InnerHtml = c.ColaboradorEmpresa.ToString
        txt_CheckIn_Date.InnerHtml = c.ColaboradorCheckIn_Date.ToString
    End Sub
End Class