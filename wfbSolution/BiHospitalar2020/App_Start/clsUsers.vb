Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Public Class clsUsers
    'Instancia demais classes
    ReadOnly m As New clsMaster
    Public Property SQL_DOCTORS As String = "Select * From vw_Doctors Where Doctor_Code= '0' "

    'Propriedades de login (identity AspNetUsers)
    Public Property Authenticated() As Boolean = HttpContext.Current.User.Identity.IsAuthenticated
    Public Property LoggedId() As String = "" 'view_Users.[AspNetUsers.Id] 
    Public Property LoggedEmail() As String = HttpContext.Current.User.Identity.GetUserName
    Public Property LoggedName() As String = "" 'view_Users.[AspNetUsers.UserName]
    Public Property LoggedConfirmed() As Boolean = False 'view_Users.[AspNetUsers.EmailConfirmed]
    Public Property LoggedStatus() As String = "" 'view_Users.[User_Status]
    Public Property LoggedStatusDescription() As String = "" 'view_Users.[Status_Description]
    Public Property LoggedProfileCode() As String = "" 'view_Users.[User_Profile_Code]
    Public Property LoggedProfile() As String = "" 'view_Users.[User_Profile]
    Public Property LoggedDate() As String = "" 'view_Users.[Login_Date]
    Public Property LoggedIP() As String = "" 'view_Users.[Login_IP]
    Public Property LoggedSession() As String = "" 'view_Users.[Login_Session]
    Public Property LoggedBrowser() As String = "" 'view_Users.[Login_Browser]

    Public Property LoggedActive() As Boolean = False 'view_Users.[Active]
    Public Property LoggedLocked() As Boolean = False 'view_Users.[Locked]
    Public Property LoggedDeleted() As Boolean = False 'view_Users.[Locked]
    Public Property LoggedRegistered() As Boolean = False



    'Propriedades de Perfil (view_Users)
    Public Property UserId() As String = "" 'sys_vw_Users.User_Id
    Public Property UserName() As String = "" 'sys_vw_Users.Name
    Public Property UserEmail() As String = "" 'sys_vw_Users.Email
    Public Property UserEmailConfirmed() As Boolean = False 'sys_vw_Users.[AspNetUsers.EmailConfirmed]
    Public Property UserCountry_Code() As String = "" 'sys_vw_Users.Country_Code
    Public Property UserProfile_Code() As String = "" 'sys_vw_Users.User_Profile_Code
    Public Property UserProfile() As String = "" 'sys_vw_Users.User_Profile
    Public Property UserStatus() As String = "" 'sys_vw_Users.User_Status
    Public Property UserStatusDescription() As String = "" 'sys_vw_Users.Status_Description
    Public Property UserDocument() As String = "" 'sys_vw_Users.[Document]
    Public Property UserBirth_Date() As String = "" 'sys_vw_Users.Birth_Date
    Public Property UserPhone() As String = "" 'sys_vw_Users.Phone
    Public Property UserMobile() As String = "" 'sys_vw_Users.Mobile
    Public Property UserWhatsApp() As String = "" 'sys_vw_Users.WhatsApp
    Public Property UserAddress_ZIP() As String = "" 'sys_vw_Users.Address_ZIP
    Public Property UserAddress() As String = "" 'sys_vw_Users.Address
    Public Property UserAddress_Number() As String = "" 'sys_vw_Users.Address_Number
    Public Property UserAddress_Complement() As String = "" 'sys_vw_Users.Address_Complement
    Public Property UserAddress_District() As String = "" 'sys_vw_Users.Address_District
    Public Property UserAddress_City() As String = "" 'sys_vw_Users.Address_City
    Public Property UserAddress_City_Code() As String = "" 'sys_vw_Users.Address_City_Code
    Public Property UserAddress_State() As String = "" 'sys_vw_Users.Address_State
    Public Property UserAddress_State_Code() As String = "" 'sys_vw_Users.Address_State_Code
    Public Property UserAddress_Country() As String = "" 'sys_vw_Users.Address_Country
    Public Property UserNotes() As String = "" 'sys_vw_Users.Notes
    Public Property UserLogged() As Boolean = False 'sys_vw_Users.Login
    Public Property UserLogged_Date() As String = "" 'sys_vw_Users.Login_Date
    Public Property UserActive() As Boolean = False 'sys_vw_Users.Active
    Public Property UserShow() As Boolean = False 'sys_vw_Users.Show
    Public Property UserLocked() As Boolean = True 'sys_vw_Users.Locked
    Public Property UserDeleted() As Boolean = False 'sys_vw_Users.Deleted
    Public Property Profile_Updated() As Boolean = False 'sys_vw_Users.Profile_Updated
    Public Property Profile_Registered() As Boolean = False 'verifica se o usuário está cadastrado na tabela sys_Users 
    Public Function CheckAccess() As String
        CheckAccess = ""
        If Authenticated = False Then
            CheckAccess = "UnAuthenticated"
            Logout(True, "~/Account/Login")
        Else
            GetLoggedUserInfos()
            If LoggedStatus = "UnConfirmed" Then
                CheckAccess = "UnConfirmed"
                HttpContext.Current.Response.Redirect("~/Account/SendConfirm?Email=" & LoggedEmail)
                Exit Function
            End If

            If LoggedStatus = "Confirmed" Then
                CheckAccess = "Confirmed"
                HttpContext.Current.Response.Redirect("~/Account/UserConfirmed?Email=" & LoggedEmail)
                Exit Function
            End If

            If LoggedStatus = "Locked" Then
                CheckAccess = "Locked"
                HttpContext.Current.Response.Redirect("~/Account/UserLocked?Email=" & LoggedEmail)
                Exit Function
            End If

            If LoggedStatus = "Authorized" Then
                CheckAccess = "Authorized"
                Exit Function
            End If

        End If
    End Function
    Public Function GetLoggedUserInfos() As Boolean
        Try
            GetLoggedUserInfos = True
            If Authenticated = True Then
                LoggedId = HttpContext.Current.User.Identity.GetUserId
                LoggedEmail = HttpContext.Current.User.Identity.GetUserName
                Dim LoggedUserManager = HttpContext.Current.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
                Dim LoggedUser As ApplicationUser = LoggedUserManager.FindByName(LoggedEmail)
                LoggedConfirmed = LoggedUser.EmailConfirmed

                Dim cnn_Logged = New System.Data.SqlClient.SqlConnection With {
                    .ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
                }
                cnn_Logged.Open()
                Dim cmd_Logged As System.Data.SqlClient.SqlCommand = cnn_Logged.CreateCommand

                Dim sql_Logged As String = "Select * From sys_vw_Users Where Email ='" & LoggedEmail & "'"
                Dim dtr_Logged As System.Data.SqlClient.SqlDataReader
                cmd_Logged.CommandText = sql_Logged
                dtr_Logged = cmd_Logged.ExecuteReader
                If dtr_Logged.HasRows Then
                    dtr_Logged.Read()
                    LoggedName = dtr_Logged("Name")
                    LoggedRegistered = True
                    LoggedActive = dtr_Logged("Active")
                    LoggedLocked = dtr_Logged("Locked")
                    LoggedStatus = dtr_Logged("User_Status")
                    LoggedStatusDescription = dtr_Logged("Status_Description")
                    LoggedProfile = dtr_Logged("User_Profile")
                    LoggedProfileCode = dtr_Logged("User_Profile_Code")
                    LoggedDate = m.ConvertText(dtr_Logged("Logged_Date"), clsMaster.TextCaseOptions.UpperCase)
                    'LoggedIP = m.ConvertText(dtr_Logged("Login_IP"), clsMaster.TextCaseOptions.UpperCase)
                    'LoggedSession = m.ConvertText(dtr_Logged("Login_Session"), clsMaster.TextCaseOptions.TextCase)
                    'LoggedBrowser = m.ConvertText(dtr_Logged("Login_Browser"), clsMaster.TextCaseOptions.TextCase)

                    'String  SQL PARA MÉDICOS conforme o pefil do usuário logado
                    Select Case LoggedProfileCode
                        Case = "000" 'Indefinido
                            SQL_DOCTORS = "Select * From vw_Doctors Where Doctor_Code = 0"
                        Case = "001" 'Administrador
                            SQL_DOCTORS = "Select * From vw_Doctors Order By Doctor_Name"
                        Case = "002" ' Diretor
                            SQL_DOCTORS = "Select * From vw_Doctors Order By Doctor_Name"
                        Case = "003" ' Gerente
                            SQL_DOCTORS = "Select * From vw_Doctors Order By Doctor_Name"
                        Case = "004" 'Representante
                            SQL_DOCTORS = "Select * From vw_Doctors Where Account_Executive_Email = '" & LoggedEmail & "' Order By Doctor_Name"
                    End Select
                End If
            End If
        Catch ex As Exception
            GetLoggedUserInfos = False
            m.SystemError("000", "Erro ao Recuperar Informações do Usuário Ativo (Logged)", ex.Message.ToString, "clsUser.GetLoggedUserInfos")
        End Try

    End Function

    Public Function GetUserInfos(Optional GetByEmail As String = "", Optional GetByDocument As String = "", Optional GetByUserId As String = "") As Boolean
        GetUserInfos = False

        Try
            'Abre Conexao com banco de dados
            Dim cnn_User = New System.Data.SqlClient.SqlConnection With {
                .ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
            }
            cnn_User.Open()
            Dim cmd_User As System.Data.SqlClient.SqlCommand = cnn_User.CreateCommand

            'Recupera Informações da tabela ApsNetUsers
            Dim sql_User As String = "Select * From sys_vw_Users Where Email ='" & LoggedEmail & "'" ' recupera do usuário logado
            If GetByEmail <> "" Then sql_User = "Select * From sys_vw_Users Where Email ='" & GetByEmail & "'"
            If GetByDocument <> "" Then sql_User = "Select * From sys_vw_Users Where Document ='" & GetByDocument & "'"

            Dim dtr_User As System.Data.SqlClient.SqlDataReader
            cmd_User.CommandText = sql_User
            dtr_User = cmd_User.ExecuteReader
            If dtr_User.HasRows Then
                GetUserInfos = True
                dtr_User.Read()
                'Propriedades de Perfil (view_Users)
                UserId = IIf(IsDBNull(dtr_User("User_Id")), "", dtr_User("User_Id").ToString)
                UserName = IIf(IsDBNull(dtr_User("Name")), "", dtr_User("Name").ToString)
                UserEmail = IIf(IsDBNull(dtr_User("Email")), "", dtr_User("Email").ToString)
                UserEmailConfirmed = IIf(IsDBNull(dtr_User("AspNetUsers.EmailConfirmed")), False, dtr_User("AspNetUsers.EmailConfirmed"))
                UserCountry_Code = IIf(IsDBNull(dtr_User("Country_Code")), "", dtr_User("Country_Code").ToString)
                UserProfile_Code = IIf(IsDBNull(dtr_User("User_Profile_Code")), "000", dtr_User("User_Profile_Code").ToString)
                UserProfile = IIf(IsDBNull(dtr_User("User_Profile")), "000", dtr_User("User_Profile").ToString)
                UserStatus = IIf(IsDBNull(dtr_User("User_Status")), "", dtr_User("User_Status").ToString)
                UserStatusDescription = IIf(IsDBNull(dtr_User("Status_Description")), "", dtr_User("Status_Description").ToString)
                UserDocument = IIf(IsDBNull(dtr_User("Document")), "", dtr_User("Document").ToString)
                UserBirth_Date = IIf(IsDBNull(dtr_User("Birth_Date")), "", dtr_User("Birth_Date").ToString)
                UserPhone = IIf(IsDBNull(dtr_User("Phone")), "", dtr_User("Phone").ToString)
                UserMobile = IIf(IsDBNull(dtr_User("Mobile")), "", dtr_User("Mobile").ToString)
                UserWhatsApp = IIf(IsDBNull(dtr_User("WhatsApp")), "", dtr_User("WhatsApp").ToString)
                UserAddress_ZIP = IIf(IsDBNull(dtr_User("Address_ZIP")), "", dtr_User("Address_ZIP").ToString)
                UserAddress = IIf(IsDBNull(dtr_User("Address")), "", dtr_User("Address").ToString)
                UserAddress_Number = IIf(IsDBNull(dtr_User("Address_Number")), "", dtr_User("Address_Number").ToString)
                UserAddress_Complement = IIf(IsDBNull(dtr_User("Address_Complement")), "", dtr_User("Address_Complement").ToString)
                UserAddress_District = IIf(IsDBNull(dtr_User("Address_District")), "", dtr_User("Address_District").ToString)
                UserAddress_City = IIf(IsDBNull(dtr_User("Address_City")), "", dtr_User("Address_City").ToString)
                UserAddress_City_Code = IIf(IsDBNull(dtr_User("Address_City_Code")), "", dtr_User("Address_City_Code").ToString)
                UserAddress_State = IIf(IsDBNull(dtr_User("Address_State")), "", dtr_User("Address_State").ToString)
                UserAddress_State_Code = IIf(IsDBNull(dtr_User("Address_State_Code")), "", dtr_User("Address_State_Code").ToString)
                UserAddress_Country = IIf(IsDBNull(dtr_User("Address_Country")), "", dtr_User("Address_Country").ToString)
                UserNotes = IIf(IsDBNull(dtr_User("Notes")), "", dtr_User("Notes").ToString)
                UserLogged = IIf(IsDBNull(dtr_User("Logged")), False, dtr_User("Logged"))
                UserLogged_Date = IIf(IsDBNull(dtr_User("Logged_Date")), "", dtr_User("Logged_Date"))
                UserActive = dtr_User("Active")
                UserShow = dtr_User("Show")
                UserLocked = dtr_User("Locked")
                UserDeleted = dtr_User("Deleted")
                Profile_Updated = dtr_User("Profile_Updated")
                Profile_Registered = dtr_User("Profile_Registered")
                GetUserInfos = True
            Else
                GetUserInfos = False
            End If
            dtr_User.Close()
            cnn_User.Close()
        Catch ex As Exception
            GetUserInfos = False
            m.SystemError("000", "Erro ao Recuperar Informações de Usuário", ex.Message.ToString, "clsUser.GetUserInfos")
        End Try

    End Function
    Public Function CheckUserDocument(StrDocument As String) As String
        CheckUserDocument = "UnRegistered"
        Try
            Dim dtr_Document As System.Data.SqlClient.SqlDataReader
            dtr_Document = m.ExecuteSelect("Select Document From sys_Users Where Document = '" & StrDocument & "'")
            If dtr_Document.HasRows Then CheckUserDocument = "Registered"
        Catch ex As Exception
            CheckUserDocument = "Failed"
        End Try
    End Function

    Public Sub RegisterLog(LogType As String)

        Dim LogDate = m.GetDateTimeToString.ToString
        Dim LoginIP As String = HttpContext.Current.Request.ServerVariables("REMOTE_ADDR").ToString
        Dim LoginSession As String = HttpContext.Current.Session.SessionID.ToString
        Dim LoginBrowser As String = HttpContext.Current.Request.ServerVariables("HTTP_USER_AGENT").ToString
        Dim LoginLocation As String = ""
        'Registra LogIn da tb_Users_Logins
        m.ExecuteSQL("Insert Into tb_Users_Logins (Email, Login_Date, Login_Ip, Login_Session, Login_Browser, Login_Location, Type, User_Status) Values ('" & LoggedEmail & "', '" & LogDate & "', '" & LoginIP & "', '" & LoginSession & "', '" & LoginBrowser & "', '" & LoginLocation & "', '" & LogType & "', '" & LoggedStatus & "')")
        If LogType = "LogIn" Then m.ExecuteSQL("Update tb_Users Set Login = 1, LogOut = 0, Login_Date = '" & LogDate & "', Login_Ip = '" & LoginIP & "', Login_Session = '" & LoginSession & "', Login_Browser = '" & LoginBrowser & "', Login_Location = '" & LoginLocation & "' Where Email = '" & LoggedEmail & "'")
        If LogType = "LogOut" Then m.ExecuteSQL("Update tb_Users Set Login = 0, LogOut = 1, LogOut_Date = '" & LogDate & "' Where Email = '" & LoggedEmail & "'")
    End Sub

    Public Function SendConfirmation(Optional Email As String = "") As Boolean
        SendConfirmation = False
        If GetLoggedUserInfos() = True Then
            If LoggedStatus = "UnConfirmed" Then
                Dim manager = HttpContext.Current.GetOwinContext().GetUserManager(Of ApplicationUserManager)()
                Dim user = New ApplicationUser() With {.UserName = LoggedEmail, .Email = LoggedEmail}
                Dim code = manager.GenerateEmailConfirmationToken(user.Id)
                Dim callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, UserId, HttpContext.Current.Request)
                Dim confirmMessage As String
                confirmMessage = ""
                confirmMessage = confirmMessage & "<h3>LEIA COM ATENÇÃO</h3>"
                confirmMessage = confirmMessage & " Declaro ser propriétário do e-mail " & user.UserName & " utilizado para registro e acesso ao site " & ConfigurationManager.AppSettings("App.Name").ToString & ".<br/>"
                confirmMessage = confirmMessage & " Estou ciente de que minha senha é pessoal e intransferivel e só poderá ser recuperada ou alterada por mim através do email " & user.UserName & ".<br/>"
                confirmMessage = confirmMessage & " Estou ciente de que todas as ações realizadas no site " & ConfigurationManager.AppSettings("App.Name").ToString & " serão registradas em log sob o email " & user.UserName & ".<br/>"
                confirmMessage = confirmMessage & " Estou ciente de que todas as informações registradas neste site são de propriedade da  " & ConfigurationManager.AppSettings("App.Customer").ToString & ".<br/>"
                confirmMessage = confirmMessage & "<br/>"
                confirmMessage = confirmMessage & " A sua senha definina durante registro é criptografada e nem os administradores e/ou usuários do " & ConfigurationManager.AppSettings("App.Name").ToString & " posssuem acesso.<br/>"
                confirmMessage = confirmMessage & " Portanto todas as informações incluidas, por você, são  de sua total responsabilidade quanto a veracidade.<br/>"
                confirmMessage = confirmMessage & "<br/><br/>"
                manager.SendEmail(user.Id, "Confirmar registro sua conta e propriedade do e-mail", confirmMessage & " Confirme se realmente é proprietário do e-mail " & user.UserName & " e está ciente <br/><br/><a href=""" & callbackUrl & """>Confirmo a propriedade do referido e-mail e estou ciente </a>.")
                SendConfirmation = True
                'Custom WFBDireciona para página de mensagens de usuarios
            Else
                SendConfirmation = False
            End If
        Else
            SendConfirmation = False
        End If
    End Function

    Public Sub Logout(Optional Redirect As Boolean = False, Optional PageTarget As String = "")
        HttpContext.Current.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
        If Redirect = True Then HttpContext.Current.Response.Redirect(PageTarget)
    End Sub
End Class
