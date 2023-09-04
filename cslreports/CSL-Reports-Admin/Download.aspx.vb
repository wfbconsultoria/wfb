
Partial Class Download
    Inherits System.Web.UI.Page
    Dim m As New clsMaster

    Private Sub Download_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Verificando sessão ativa
        If Session("USER_EMAIL") = Nothing Then Response.Redirect("Login")
        If Session("USER_EMAIL") = "" Then Response.Redirect("Login")

        'Liberar link para cadastrar outros downloads apenas para usuário do tipo SYSTEM ADMINISTRATOR da WFB
        Dim domain As String = m.onlyDomain(Session("USER_EMAIL").ToString)

        If Session("USER_PROFILE_CODE").ToString = "001" And domain = "wfbconsultoria.com.br" Then
            lnkRegisterDownload.Visible = True
            lnkRegisterDownload.HRef = "RegisterDownload.aspx"
        End If

        Dim dtr As System.Data.SqlClient.SqlDataReader
        'Resgatando dados para tabela
        If Session("USER_PROFILE_CODE").ToString = "001" And domain = "wfbconsultoria.com.br" Then
            dtr = m.ExecuteSelect("SELECT DISTINCT ID, DOWNLOAD_TITLE, DOWNLOAD_DESCRIPTION, DOWNLOAD_LINK From vw_Downloads_Users ORDER BY DOWNLOAD_TITLE ASC")
        Else
            dtr = m.ExecuteSelect("SELECT ID, DOWNLOAD_TITLE, DOWNLOAD_DESCRIPTION, DOWNLOAD_LINK, Insert_User, Insert_Date From vw_Downloads_Users Where Active = 1 and USER_EMAIL = '" & Session("USER_EMAIL").ToString & "'" & "ORDER BY DOWNLOAD_TITLE ASC")
        End If
        Repeater1.DataSource = dtr
            Repeater1.DataBind()
    End Sub
End Class
