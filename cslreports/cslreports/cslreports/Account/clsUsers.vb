Imports Microsoft.Owin.Security
Imports Microsoft.Owin.Security.Cookies
Imports Microsoft.Owin.Security.OpenIdConnect
Public Class clsUsers
    'Instancia demais classes
    ReadOnly m As New clsMaster

    'Propriedades de login (identity AspNetUsers)
    Public Property Authenticated() As Boolean = False
    Public Property Email() As String = ""
    Public Property Name() As String = ""
    Public Property Document() As String = ""
    Public Property Birth_Date() As String = ""
    Public Property Phone() As String = ""
    Public Property Status() As String = ""
    Public Property ProfileId() As String = ""

    Public Function GetInfos() As Boolean
        GetInfos = False

        If Authenticated = True Then
            Email = HttpContext.Current.User.Identity.Name
            GetInfos()
        Else
            Logout()
        End If


        Try
            'Abre Conexao com banco de dados
            Dim cnn_User = New System.Data.SqlClient.SqlConnection With {
                .ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
            }
            cnn_User.Open()
            Dim cmd_User As System.Data.SqlClient.SqlCommand = cnn_User.CreateCommand

            'Recupera Informações da tabela ApsNetUsers
            Dim sql_User As String = "Select * From Users Where Email ='" & Email & "'" ' recupera do usuário logado


            Dim dtr_User As System.Data.SqlClient.SqlDataReader
            cmd_User.CommandText = sql_User
            dtr_User = cmd_User.ExecuteReader
            If dtr_User.HasRows Then
                GetInfos = True
                dtr_User.Read()
                Name = m.ConvertText(dtr_User("Name"))
                Birth_Date = m.ConvertText(dtr_User("Birth_Date"))
                Birth_Date = m.ConvertText(dtr_User("Document"))
                Phone = m.ConvertText(dtr_User("Birth_Date"))
                GetInfos = True
            Else
                GetInfos = False
            End If
            dtr_User.Close()
            cnn_User.Close()
        Catch ex As Exception
            GetInfos = False
            m.SystemError("000", "Erro ao Recuperar Informações de Usuário", ex.Message.ToString, "clsUser.GetUserInfos")
        End Try

    End Function

    Public Sub Logout()
        ' Redirecionar para ~/Account/SignOut após sair.
        Dim callbackUrl As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) & HttpContext.Current.Response.ApplyAppPathModifier("~/Account/SignOut.aspx")

        HttpContext.Current.GetOwinContext().Authentication.SignOut(
            New AuthenticationProperties() With {.RedirectUri = callbackUrl},
            OpenIdConnectAuthenticationDefaults.AuthenticationType,
            CookieAuthenticationDefaults.AuthenticationType)
    End Sub
End Class
