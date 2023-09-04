Public Class User
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly u As New clsUsers

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        u.CheckAccess()
        Dim UserEmail = m.CheckQueryStringParameter(Request.QueryString("UserEmail"), "~/Account/Users.aspx")
        Manage_Controls(u.LoggedProfile)
        If UserEmail = "LoggedUser" Then UserEmail = u.LoggedEmail
        cmb_User_Status.Enabled = True
        If IsPostBack() = False Then RecoverRecord(UserEmail)
        If IsPostBack() = True Then SaveRecord(UserEmail)

    End Sub
    Protected Sub Manage_Controls(LoggedProfile As String)

        Select Case LoggedProfile
            Case <> "001"
                cmb_User_Status.Enabled = False
                cmb_User_Profile_Code.Enabled = False
        End Select

    End Sub
    Sub RecoverRecord(Email As String)
        u.GetUserInfos(Email)
        cmb_User_Profile_Code.SelectedValue = u.UserProfile_Code
        cmb_User_Status.SelectedValue = u.UserStatus
        Select Case u.UserStatus
            Case = "UnConfirmed"
                cmb_User_Status.Enabled = False
                cmb_User_Status.CssClass = "form-control alert-warning"
            Case = "Locked"
                cmb_User_Status.Enabled = True
                cmb_User_Status.CssClass = "form-control alert-danger"
            Case = "Authorized"
                cmb_User_Status.Enabled = True
                cmb_User_Status.CssClass = "form-control alert-success"
        End Select
        txt_Email.Value = u.UserEmail
        txt_Name.Value = u.UserName
        txt_Birth_Date.Value = u.UserBirth_Date
        txt_Document.Value = u.UserDocument
        txt_Phone.Value = u.UserPhone
        txt_Mobile.Value = u.UserMobile
        txt_WhatsApp.Value = u.UserWhatsApp
        txt_Notes.Value = u.UserNotes
        txt_Last_Login_Date.Value = u.UserLogged_Date
    End Sub

    Sub SaveRecord(Email As String)
        Dim sql As String = ""
        sql &= " Update tb_Users Set "
        sql &= " User_Status = '" & cmb_User_Status.SelectedValue & "', "
        sql &= " User_Profile_Code = '" & cmb_User_Profile_Code.SelectedValue & "', "
        sql &= " Phone = '" & m.ConvertText(txt_Phone.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql &= " Mobile = '" & m.ConvertText(txt_Mobile.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql &= " WhatsApp = '" & m.ConvertText(txt_WhatsApp.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql &= " Notes = '" & m.ConvertText(txt_Notes.Value, clsMaster.TextCaseOptions.TextCase) & "', "
        sql &= " Update_User = '" & u.LoggedEmail & "', Update_Date = '" & m.GetDateTimeToString & "' "
        sql &= " Where Email = '" & Email & "'"
        m.ExecuteSQL(sql)

        If cmb_User_Status.SelectedValue = "UnConfirmed" Then m.ExecuteSQL("Update AspNetUsers Set EmailConfirmed = 0 Where Email = '" & Email & "'")
        m.ExecuteSQL(sql)

        RecoverRecord(Email)
        m.Alert(Me, u.UserName & " atualizado com sucesso", False, "")
    End Sub
    Sub ConsultaCEP()
        Dim cCEP As New svcCEP.CEP1
        cCEP = m.ConsultaCEP(txt_Address_ZIP.Value)
        Try
            txt_Address.Value = cCEP.TipoLogradouro & " " & cCEP.Logradouro.ToUpper
            txt_Address_District.Value = cCEP.Bairro.ToUpper
            txt_Address_City.Value = cCEP.CodigoIBGE.ToUpper & " - " & cCEP.Cidade.ToUpper
            txt_Address_State.Value = cCEP.UF & " - " & cCEP.Estado

        Catch ex As Exception
            txt_Address.Value = "INVALIDO"
            txt_Address.Value = "INVALIDO"
            txt_Address_District.Value = "INVALIDO"
            txt_Address_City.Value = "INVALIDO"
            txt_Address_State.Value = "INVALIDO"

            m.Alert(Me, "CEP INVÁLIDO")
        End Try
    End Sub

    Public Function FormataIcone(Parameter As String) As String
        FormataIcone = "Images/Colaborador_Icone.png"
        If Parameter = "Sim" Then FormataIcone = "Images/Brigadista_Icone.png"
    End Function

    Private Sub cmd_ConsultaCEP_ServerClick(sender As Object, e As EventArgs) Handles cmd_ConsultaCEP.ServerClick
        ConsultaCEP()
    End Sub
End Class