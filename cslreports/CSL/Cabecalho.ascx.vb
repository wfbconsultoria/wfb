
Partial Class Header
    Inherits System.Web.UI.UserControl
    Dim M As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'QUANDO PUBLICAR EM AMBIENTE DE PRODUÇÃO TIRARO COMENTÁRIO DAS LINHAS ABAIXO
        ''REDIRECIONAMNETO HTTPS PARA https://www.bihospitalar.com.br
        'If Request.Url.GetLeftPart(UriPartial.Authority) <> "https://www.bihospitalar.com.br" Then
            'Response.Redirect("https://www.bihospitalar.com.br" & VirtualPathUtility.ToAbsolute("~"))
       ' End If
       ' If Not Request.IsSecureConnection Then
        '    'redirect visitor to SSL connection
          ' Response.Redirect(Request.Url.AbsoluteUri.Replace("http://", "https://"))
        'End If
        
        If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Login.aspx")
        lbl_Login.Text = ConfigurationManager.AppSettings("CLIENTE").ToString & " - " & Session("USUARIO_LOGIN") & " - " & Session("PERFIL_LOGIN")
    End Sub
End Class