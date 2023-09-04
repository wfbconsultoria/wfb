Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Public Class LogOut
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly u As New clsUsers
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        u.GetLoggedUserInfos()
        Dim UserName As String = u.LoggedName
        Dim UserEmail As String = u.LoggedEmail
        Dim UserStatus As String = u.LoggedStatus

        Dim LogDate = m.GetDateTimeToString.ToString
        Dim LogIP As String = Request.ServerVariables("REMOTE_ADDR").ToString
        Dim LogSession As String = Session.SessionID.ToString
        Dim LogBrowser As String = Request.ServerVariables("HTTP_USER_AGENT").ToString
        Dim LogLocation As String = ""
        Dim sql As String = ""

        sql = sql & " Insert Into tb_Users_Logins (Email, LogIn_Date, LogIn_Ip, LogIn_Session, LogIn_Browser, Type, User_Status) Values( "
        sql = sql & "'" & UserEmail & "', "
        sql = sql & "'" & LogDate & "', "
        sql = sql & "'" & LogIP & "', "
        sql = sql & "'" & Session.SessionID.ToString & "', "
        sql = sql & "'" & LogBrowser & "', "
        sql = sql & "'LogOut', "
        sql = sql & "'" & UserStatus & "') "
        m.ExecuteSQL(sql)
        m.ExecuteSQL("Update tb_Users Set Login = 0, Login_Date = NULL, LogOut = 1, LogOut_Date = '" & LogDate & "', Login_Ip = '" & LogIP & "', Login_Session = '" & LogSession & "', Login_Browser = '" & LogBrowser & "', Login_Location = '" & LogLocation & "' Where Email = '" & UserEmail & "'")
        Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
        m.Alert(Me, UserName & " LogOut em " & m.GetDateTimeToString, False, "")
    End Sub

End Class