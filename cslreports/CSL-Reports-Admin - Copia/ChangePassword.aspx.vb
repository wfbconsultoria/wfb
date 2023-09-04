
Partial Class ChangePassword
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Private Sub ChangePassword_Load(sender As Object, e As EventArgs) Handles Me.Load
         Page.Title = ConfigurationManager.AppSettings("ChangePassword.title")
        rfv_ConfirmNewPassword.ErrorMessage=ConfigurationManager.AppSettings("msg.FieldRequired")
        rfv_CurrentPassword.ErrorMessage=ConfigurationManager.AppSettings("msg.FieldRequired")
        rfv_NewPassword.ErrorMessage=ConfigurationManager.AppSettings("msg.FieldRequired")
        cpv_ConfirmNewPassword.ErrorMessage=ConfigurationManager.AppSettings("msg.FieldNoMatch")
    End Sub

    Private Sub cmd_ChangePassword_Click(sender As Object, e As EventArgs) Handles cmd_ChangePassword.Click
        'declaração de variaveis
        Dim d As System.Data.SqlClient.SqlDataReader
        Dim sql As String = "Select * From vw_Users Where USER_EMAIL = '" & Session("USER_EMAIL").ToString & "' and USER_PASSWORD = '" & m.ConvertText(CurrentPassword.Text, clsMaster.TextCaseOptions.TextCase) & "'"
        d = m.ExecuteSelect(sql)
        If d.HasRows Then
            If m.ExecuteSQL("Update tb_Users Set USER_PASSWORD = '" & m.ConvertText(NewPassword.Text, clsMaster.TextCaseOptions.TextCase) & "', Update_User = '" & Session("USER_EMAIL") & "' Where USER_EMAIL = '" & Session("USER_EMAIL") & "'") = True Then
                m.EnviarEmail(Session("USER_EMAIL"), ConfigurationManager.AppSettings("msg.ChangedPassword"))
                Alert(ConfigurationManager.AppSettings("msg.ChangedPassword"), True, "Default.aspx")
            Else
                m.SystemError(ConfigurationManager.AppSettings("msg.ErrChangePassword"), "", "", "ChangePassword.aspx:cmd_ChangePassword")
            End If
        Else
            Alert(ConfigurationManager.AppSettings("msg.ChangePasswordNotMatch"), False, "")
            Exit Sub
        End If
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

