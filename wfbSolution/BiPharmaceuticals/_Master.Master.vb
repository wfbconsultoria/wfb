
Public Class _Master
    Inherits System.Web.UI.MasterPage
    Private Const AntiXsrfTokenKey As String = "__AntiXsrfToken"
    Private Const AntiXsrfUserNameKey As String = "__AntiXsrfUserName"
    Private _antiXsrfTokenValue As String
    ReadOnly u As New clsUsers

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lgv_Master.FindControl("lnk_Home").Visible = False
        lgv_Master.FindControl("lnk_Users").Visible = False
        lgv_Master.FindControl("lnk_Doctors").Visible = False
        lgv_Master.FindControl("lnk_Patients").Visible = False
        lgv_Master.FindControl("lnk_Visits").Visible = False
        lgv_Master.FindControl("lnk_Reports").Visible = False
        u.CheckAccess()
        Select Case u.LoggedProfileCode
            Case = "000" 'Sem perfil definido
            Case = "001" 'Administrador
                lgv_Master.FindControl("lnk_Home").Visible = True
                lgv_Master.FindControl("lnk_Users").Visible = True
                lgv_Master.FindControl("lnk_Doctors").Visible = True
                lgv_Master.FindControl("lnk_Patients").Visible = False
                lgv_Master.FindControl("lnk_Visits").Visible = False
                lgv_Master.FindControl("lnk_Reports").Visible = False
            Case = "002" 'Gerente
                lgv_Master.FindControl("lnk_Home").Visible = True
                lgv_Master.FindControl("lnk_Doctors").Visible = True
            Case = "003" 'Representante
                lgv_Master.FindControl("lnk_Home").Visible = True
                lgv_Master.FindControl("lnk_Doctors").Visible = True
            Case = "010" 'Médico
                lgv_Master.FindControl("lnk_Home").Visible = True
            Case = "100" 'Paciente
                lgv_Master.FindControl("lnk_Home").Visible = True
        End Select

    End Sub

    Protected Sub Page_Init(sender As Object, e As EventArgs)
        ' O código abaixo ajuda a proteger contra ataques XSRF
        Dim requestCookie = Request.Cookies(AntiXsrfTokenKey)
        Dim requestCookieGuidValue As Guid
        If requestCookie IsNot Nothing AndAlso Guid.TryParse(requestCookie.Value, requestCookieGuidValue) Then
            ' Use o token Anti-XSRF do cookie
            _antiXsrfTokenValue = requestCookie.Value
            Page.ViewStateUserKey = _antiXsrfTokenValue
        Else
            ' Gerar um novo token Anti-XSRF e salvar no cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N")
            Page.ViewStateUserKey = _antiXsrfTokenValue

            Dim responseCookie = New HttpCookie(AntiXsrfTokenKey) With {
                 .HttpOnly = True,
                 .Value = _antiXsrfTokenValue
            }
            If FormsAuthentication.RequireSSL AndAlso Request.IsSecureConnection Then
                responseCookie.Secure = True
            End If
            Response.Cookies.[Set](responseCookie)
        End If

        AddHandler Page.PreLoad, AddressOf master_Page_PreLoad
    End Sub

    Protected Sub master_Page_PreLoad(sender As Object, e As EventArgs)
        If Not IsPostBack Then
            ' Configurar o token Anti-XSRF
            ViewState(AntiXsrfTokenKey) = Page.ViewStateUserKey
            ViewState(AntiXsrfUserNameKey) = If(Context.User.Identity.Name, [String].Empty)
        Else
            ' Validar o token Anti-XSRF
            If DirectCast(ViewState(AntiXsrfTokenKey), String) <> _antiXsrfTokenValue OrElse DirectCast(ViewState(AntiXsrfUserNameKey), String) <> (If(Context.User.Identity.Name, [String].Empty)) Then
                Throw New InvalidOperationException("Falha na validação do token Anti-XSRF.")
            End If
        End If
    End Sub

    Protected Sub Unnamed_LoggingOut(sender As Object, e As LoginCancelEventArgs)

    End Sub
End Class