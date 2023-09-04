Public Class User
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly u As New clsUsers

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim UserEmail = m.CheckQueryStringParameter(Request.QueryString("UserEmail"), "~/Account/Users.aspx")
        cmb_User_Status.Enabled = True
        If IsPostBack() = False Then RecoverRecord(UserEmail)
        If IsPostBack() = True Then SaveRecord(UserEmail)

    End Sub

    Sub RecoverRecord(email As String)
        u.GetUserInfos(email)
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

    Sub SaveRecord(email As String)
        Dim sql As String = ""
        sql &= " Update tb_Users Set "
        sql &= " User_Status = '" & cmb_User_Status.SelectedValue & "', "
        sql &= " User_Profile_Code = '" & cmb_User_Profile_Code.SelectedValue & "', "
        sql &= " Phone = '" & m.ConvertText(txt_Phone.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql &= " Mobile = '" & m.ConvertText(txt_Mobile.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql &= " WhatsApp = '" & m.ConvertText(txt_WhatsApp.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql &= " Notes = '" & m.ConvertText(txt_Notes.Value, clsMaster.TextCaseOptions.TextCase) & "', "
        sql &= " Update_User = '" & u.LoggedEmail & "', Update_Date = '" & m.GetDateTimeToString & "' "
        sql &= " Where Email = '" & email & "'"
        m.ExecuteSQL(sql)

        If cmb_User_Status.SelectedValue = "UnConfirmed" Then m.ExecuteSQL("Update AspNetUsers Set EmailConfirmed = 0 Where Email = '" & email & "'")
        m.ExecuteSQL(sql)

        RecoverRecord(email)
        m.Alert(Me, u.UserName & " atualizado com sucesso", False, "")
    End Sub
    Public Function FormataIcone(Parameter As String) As String
        FormataIcone = "Images/Colaborador_Icone.png"
        If Parameter = "Sim" Then FormataIcone = "Images/Brigadista_Icone.png"
    End Function
End Class