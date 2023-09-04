
Imports Microsoft.AspNet.Identity

Public Class User_Profile
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Dim u As New clsUsers
    Dim email As String = Context.User.Identity.GetUserName().ToString
    Dim table As String = "tb_Users"
    Dim table_key As String = "Email"
    Dim table_key_parameter As String = Context.User.Identity.GetUserName().ToString
    Dim sql As String

    Dim Validar_Endereco As Boolean = True
    Dim Document, Birth_Date, Phone, Name, Address_ZIP, Address, Address_Number, Address_Complement,
        Address_District, Address_City, Address_City_Code, Address_State, Notes As String

    Private Sub User_Profile_Load(sender As Object, e As EventArgs) Handles Me.Load
        u.GetUserInfos()
        'txt_Email.Text = u.UserEmail
        'txt_Document.Text = u.Document
        'txt_Phone.Text = u.Phone
        'txt_Name.Text = u.Name
        'txt_Address.Value = u.Address
        'txt_Address_Number.Text = u.Address_Number
        'txt_Address_Complement.Value = u.Address_Complement
        'txt_Address_District.Text = u.Address_District
    End Sub
    Private Sub cmd_Update_Click(sender As Object, e As EventArgs) Handles cmd_Update.Click

        Dim sql As String = ""
        sql = sql & " Update tb_Users Set "
        sql = sql & " Document = '" & m.ConvertText(txt_Document.Text, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Birth_Date = '" & m.ConvertDate(txt_Birth_Date.Text) & "', "
        sql = sql & " Phone = '" & m.ConvertText(txt_Phone.Text, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Name = '" & m.ConvertText(txt_Name.Text, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Address_ZIP = '" & m.ConvertText(txt_Address_ZIP.Text, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Address = '" & m.ConvertText(txt_Address.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Address_Number = '" & m.ConvertText(txt_Address_Number.Text, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Address_Complement = '" & m.ConvertText(txt_Address_Complement.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Address_District = '" & m.ConvertText(txt_Address_District.Text, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Address_City = '" & m.ConvertText(txt_Address_City.Text, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Address_City_Code = '" & m.ConvertText(txt_Address_City_Code.Text, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Address_State = '" & m.ConvertText(txt_Address_State.Text, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Notes = '" & m.ConvertText(txt_Notes.Text, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " Profile_Updated = 1,"
        sql = sql & " Profile_Update_Date = '" & m.GetDateTimeToString() & "', "
        sql = sql & " Update_Date = '" & m.GetDateTimeToString() & "', "
        sql = sql & " Update_User = '" & u.UserEmail & "', "
        sql = sql & " Where Email = '" & txt_Email.Text & "'"

        If m.ExecuteSQL(sql) = True Then
            m.Alert(Me, txt_Email.Text & "atualizado com sucesso!", False, "")
        Else
            m.Alert(Me, txt_Email.Text & "Erro ao atualizar", False, "")
        End If
    End Sub

End Class