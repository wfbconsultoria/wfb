Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Public Class _Master
    Inherits System.Web.UI.MasterPage
    Private Const AntiXsrfTokenKey As String = "__AntiXsrfToken"
    Private Const AntiXsrfUserNameKey As String = "__AntiXsrfUserName"
    Private _antiXsrfTokenValue As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Dim UserAutenticade As Boolean = Context.User.Identity.IsAuthenticated
            Dim UserId = Context.User.Identity.GetUserId
            Dim manager = Context.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
            Dim confirmed = manager.IsEmailConfirmed(UserId)

            'If IsError(manager.IsEmailConfirmed(Context.User.Identity.GetUserId)) Then
            '    Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
            'Else
            '    If manager.IsEmailConfirmed(Context.User.Identity.GetUserId) = True Then
            '        LoginView_Right.Controls("lnk_Confirm").Visible = False
            '        LoginView_Right.Controls("lnk_Logged").Visible = True
            '    Else
            '        LoginView_Right.Controls("lnk_Confirm").Visible = True
            '        LoginView_Right.Controls("lnk_Logged").Visible = False
            '    End If
            'End If
            'Exit Sub
        Catch Exc As Exception
            Dim Err As String = Exc.Message
        End Try
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
        Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
    End Sub
End Class