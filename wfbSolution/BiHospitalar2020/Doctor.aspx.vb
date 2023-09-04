Imports Microsoft.AspNet.Identity
Public Class Doctor
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly u As New clsUsers
    ReadOnly d As New clsDoctors
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        u.CheckAccess()

        Select Case u.LoggedProfileCode
            Case = "003"
                cmb_Account_Executive.Enabled = False
        End Select

        If Request.QueryString("DoctorCode") = "NOVO" Then

            If IsPostBack() = False Then NewRecord()
            If IsPostBack() = True Then InsertRecord()
        Else

            If IsPostBack() = False Then RecoverRecord(Request.QueryString("DoctorCode").ToString)
            If IsPostBack() = True Then SaveRecord()
        End If
    End Sub
    Private Sub cmd_ConsultaCEP_ServerClick(sender As Object, e As EventArgs) Handles cmd_ConsultaCEP.ServerClick
        ConsultaCEP()
    End Sub
    Private Sub cmd_ConsultaCPF_ServerClick(sender As Object, e As EventArgs) Handles cmd_ConsultaCPF.ServerClick
        ConsultaCPF()
    End Sub
    Private Sub InsertRecord()
        'Verifica se A uf do CRM foi selecionada
        If cmb_CRM_UF.Text = "00" Then
            m.Alert(Me, "SELECIONE A UF REFERENTE AO CRM", False, "")
            Exit Sub
        End If

        If d.FormatCRM(txt_CRM.Value) = "0000000" Then
            m.Alert(Me, "DIGITE O CRM", False, "")
            Exit Sub
        End If

        'Verifica se O MÉDICO JÁ ESTÁ CADASTRADO
        Dim Doctor_Code As String = m.ConvertText(cmb_CRM_UF.Text, clsMaster.TextCaseOptions.UpperCase) & "-" & d.FormatCRM(txt_CRM.Value)
        If d.GetDoctorInfos(Doctor_Code) = True Then
            m.Alert(Me, "O MEDICO " & UCase(txt_Doctor_Name.Value) & "CRM: " & Doctor_Code & " JÁ ESTÁ CADASTRADO PARA " & d.Account_Executive, False, "")
            Exit Sub
        End If

        Dim dt As String = m.GetDateTimeToString()
        Dim sql As String
        sql = ""
        sql = sql & "Insert Into tb_Doctors ( "
        sql = sql & " [CRM_UF], "
        sql = sql & " [CRM], "
        sql = sql & " [Doctor_Specialty_Code], "
        sql = sql & " [Doctor_Type_Code], "
        sql = sql & " [Doctor_Code], "
        sql = sql & " [Doctor_Name], "
        sql = sql & " [Birth_Date], "
        sql = sql & " [Doctor_Document], "
        sql = sql & " [Email], "
        sql = sql & " [Phone], "
        sql = sql & " [Mobile], "
        sql = sql & " [WhatsApp], "
        sql = sql & " [Address_ZIP], "
        sql = sql & " [Address], "
        sql = sql & " [Address_Number], "
        sql = sql & " [Address_Complement], "
        sql = sql & " [Address_District], "
        sql = sql & " [Address_City], "
        sql = sql & " [Address_City_Code], "
        sql = sql & " [Address_State], "
        sql = sql & " [Address_State_Code], "
        sql = sql & " [Address_Country], "
        sql = sql & " [Notes], "
        sql = sql & " [Account_Executive_Email], "
        sql = sql & " [Insert_User], "
        sql = sql & " [Insert_Date], "
        sql = sql & " [Update_User], "
        sql = sql & " [Update_Date], "
        sql = sql & " [Last_Visit_Email], "
        sql = sql & " [Last_Visit_Date], "
        sql = sql & " [Last_Visit_Type_Code]) "
        sql = sql & "Values( "
        sql = sql & " '" & m.ConvertText(cmb_CRM_UF.Text, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " '" & d.FormatCRM(txt_CRM.Value) & "', "
        sql = sql & " '" & m.ConvertText(cmb_Doctor_Specialty_Code.Text, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " '" & m.ConvertText(cmb_Doctor_Type_Code.Text, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " '" & Doctor_Code & "', "
        sql = sql & " '" & m.ConvertText(txt_Doctor_Name.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " '" & txt_Birth_Date.Value & "', "
        sql = sql & " '" & txt_Doctor_document.Value & "', "
        sql = sql & " '" & m.ConvertText(txt_Email.Value, clsMaster.TextCaseOptions.LowerCase) & "', "
        sql = sql & " '" & m.ConvertText(txt_Phone.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " '" & m.ConvertText(txt_Mobile.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " '" & m.ConvertText(txt_WhatsApp.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " '" & m.ConvertText(txt_Address_ZIP.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " '" & m.ConvertText(txt_Address.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " '" & m.ConvertText(txt_Address_Number.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " '" & m.ConvertText(txt_Address_Complement.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " '" & m.ConvertText(txt_Address_District.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " '" & m.ConvertText(txt_Address_City.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " '" & Left(m.ConvertText(txt_Address_City.Value, clsMaster.TextCaseOptions.UpperCase), 7) & "', "
        sql = sql & " '" & m.ConvertText(txt_Address_State.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " '" & Left(m.ConvertText(txt_Address_State.Value, clsMaster.TextCaseOptions.UpperCase), 2) & "', "
        sql = sql & " '" & ConfigurationManager.AppSettings("App.Country") & "', "
        sql = sql & " '" & m.ConvertText(txt_Notes.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " '" & m.ConvertText(cmb_Account_Executive.Text, clsMaster.TextCaseOptions.LowerCase) & "', "
        sql = sql & " '" & m.ConvertText(u.UserEmail, clsMaster.TextCaseOptions.LowerCase) & "', "
        sql = sql & " '" & dt & "', "
        sql = sql & " '" & m.ConvertText(u.UserEmail, clsMaster.TextCaseOptions.LowerCase) & "', "
        sql = sql & " '" & dt & "', "
        sql = sql & " '" & m.ConvertText(u.UserEmail, clsMaster.TextCaseOptions.LowerCase) & "', "
        sql = sql & " '" & dt & "', "
        sql = sql & " '000') "

        cmb_CRM_UF.Enabled = False
        txt_CRM.Disabled = True
        cmd_ConsultaCPF.Disabled = False
        txt_Doctor_Document.Disabled = False
        txt_Birth_Date.Disabled = False
        cmd_ConsultaCEP.Disabled = False
        txt_Address_ZIP.Disabled = False
        txt_Address_Complement.Disabled = False
        txt_Address_Number.Disabled = False

        If m.ExecuteSQL(sql) = True Then
            m.Alert(Me, m.ConvertText(txt_Doctor_Name.Value, clsMaster.TextCaseOptions.UpperCase) & " INCLUIDO COM SUCESSO, Complete as informações de ENDEREÇO, DATA DE NASCIMENTO E CPF (opicional)", True, "Doctor?DoctorCode=" & Doctor_Code)
        End If
    End Sub
    Private Sub NewRecord()
        cmb_CRM_UF.SelectedValue = "00"
        txt_CRM.Value = ""
        cmb_Doctor_Specialty_Code.SelectedValue = "000"
        cmb_Doctor_Type_Code.SelectedValue = "000"
        txt_Doctor_Name.Value = ""
        txt_Birth_Date.Value = ""
        txt_Doctor_Document.Value = ""
        txt_Email.Value = ""
        txt_Phone.Value = ""
        txt_Mobile.Value = ""
        txt_WhatsApp.Value = ""
        txt_Address_ZIP.Value = ""
        txt_Address.Value = ""
        txt_Address_Number.Value = ""
        txt_Address_Complement.Value = ""
        txt_Address_District.Value = ""
        txt_Address_City.Value = ""
        txt_Address_State.Value = ""
        txt_Address_Country.Value = ""
        txt_Notes.Value = ""
        cmb_Account_Executive.SelectedValue = "orfao@orfao"
        If u.LoggedProfileCode = "003" Then cmb_Account_Executive.SelectedValue = u.LoggedEmail
        txt_Insert_Date.Value = ""
        txt_Last_Visit_Date.Value = ""

        cmb_CRM_UF.Enabled = True
        txt_CRM.Disabled = False
        cmd_ConsultaCPF.Disabled = True
        txt_Doctor_Document.Disabled = True
        txt_Birth_Date.Disabled = True
        cmd_ConsultaCEP.Disabled = True
        txt_Address_ZIP.Disabled = True
        txt_Address_Complement.Disabled = True
        txt_Address_Number.Disabled = True

    End Sub
    Private Sub SaveRecord()

        If cmb_CRM_UF.Text = "00" Then
            m.Alert(Me, "SELECIONE A UF REFERENTE AO CRM", False, "")
            Exit Sub
        End If

        If txt_CRM.Value = "" Then
            m.Alert(Me, "DIGITE O CRM", False, "")
            Exit Sub
        End If

        Dim sql As String
        Dim Doctor_Code As String = m.ConvertText(cmb_CRM_UF.Text, clsMaster.TextCaseOptions.UpperCase) & "-" & d.FormatCRM(txt_CRM.Value)
        sql = ""
        sql = sql & "Update tb_Doctors Set  "
        sql = sql & " [CRM_UF]= '" & m.ConvertText(cmb_CRM_UF.Text, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " [CRM]= '" & d.FormatCRM(txt_CRM.Value) & "', "
        sql = sql & " [Doctor_Specialty_Code]= '" & m.ConvertText(cmb_Doctor_Specialty_Code.Text, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " [Doctor_Type_Code]= '" & m.ConvertText(cmb_Doctor_Type_Code.Text, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " [Doctor_Name]= '" & m.ConvertText(txt_Doctor_Name.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " [Birth_Date]= '" & txt_Birth_Date.Value & "', "
        sql = sql & " [Doctor_Document]= '" & txt_Doctor_Document.Value & "', "
        sql = sql & " [Email]= '" & m.ConvertText(txt_Email.Value, clsMaster.TextCaseOptions.LowerCase) & "', "
        sql = sql & " [Phone]= '" & m.ConvertText(txt_Phone.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " [Mobile]= '" & m.ConvertText(txt_Mobile.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " [WhatsApp]= '" & m.ConvertText(txt_WhatsApp.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " [Address_ZIP]= '" & m.ConvertText(txt_Address_ZIP.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " [Address]= '" & m.ConvertText(txt_Address.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " [Address_Number]= '" & m.ConvertText(txt_Address_Number.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " [Address_Complement]= '" & m.ConvertText(txt_Address_Complement.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " [Address_District]= '" & m.ConvertText(txt_Address_District.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " [Address_City]= '" & m.ConvertText(txt_Address_City.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " [Address_City_Code]= '" & Left(m.ConvertText(txt_Address_City.Value, clsMaster.TextCaseOptions.UpperCase), 7) & "', "
        sql = sql & " [Address_State]= '" & m.ConvertText(txt_Address_State.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " [Address_State_Code]= '" & Left(m.ConvertText(txt_Address_State.Value, clsMaster.TextCaseOptions.UpperCase), 2) & "', "
        sql = sql & " [Address_Country]= '" & ConfigurationManager.AppSettings("App.Country") & "', "
        sql = sql & " [Notes]= '" & m.ConvertText(txt_Notes.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " [Account_Executive_Email]= '" & m.ConvertText(cmb_Account_Executive.Text, clsMaster.TextCaseOptions.LowerCase) & "', "
        sql = sql & " [Update_User]= '" & m.ConvertText(u.UserEmail, clsMaster.TextCaseOptions.UpperCase) & "', "
        sql = sql & " [Update_Date]= '" & m.GetDateTimeToString() & "' "
        sql = sql & " Where Doctor_Code = '" & Doctor_Code & "'"
        If m.ExecuteSQL(sql) = True Then
            m.Alert(Me, m.ConvertText(txt_Doctor_Name.Value, clsMaster.TextCaseOptions.UpperCase) & " ATUALIZADO COM SUCESSO !", True, "Doctor?DoctorCode=" & Doctor_Code)
        End If
        'RecoverRecord(Doctor_Code)
    End Sub
    Private Sub RecoverRecord(strDoctorCode As String)
        d.GetDoctorInfos(strDoctorCode)
        cmb_CRM_UF.SelectedValue = d.CRM_UF
        txt_CRM.Value = d.CRM
        cmb_Doctor_Specialty_Code.SelectedValue = d.Doctor_Specialty_Code
        cmb_Doctor_Type_Code.SelectedValue = d.Doctor_Type_Code
        txt_Doctor_Name.Value = d.Doctor_Name
        txt_Birth_Date.Value = d.Birth_Date
        txt_Doctor_Document.Value = d.Doctor_Document
        txt_Email.Value = d.Email
        txt_Phone.Value = d.Phone
        txt_Mobile.Value = d.Mobile
        txt_WhatsApp.Value = d.WhatsApp
        txt_Address_ZIP.Value = d.Address_ZIP
        txt_Address.Value = d.Address
        txt_Address_Number.Value = d.Address_Number
        txt_Address_Complement.Value = d.Address_Complement
        txt_Address_District.Value = d.Address_District
        txt_Address_City.Value = d.Address_City
        txt_Address_State.Value = d.Address_State
        txt_Address_Country.Value = d.Address_Country
        txt_Notes.Value = d.Notes
        cmb_Account_Executive.SelectedValue = d.Account_Executive_Email
        txt_Insert_Date.Value = d.Insert_Date
        txt_Last_Visit_Date.Value = d.Last_Visit_Date

        cmb_CRM_UF.Enabled = False
        txt_CRM.Disabled = True
        cmd_ConsultaCPF.Disabled = False
        txt_Doctor_Document.Disabled = False
        txt_Birth_Date.Disabled = False
        cmd_ConsultaCEP.Disabled = False
        txt_Address_ZIP.Disabled = False
        txt_Address_Complement.Disabled = False
        txt_Address_Number.Disabled = False


    End Sub
    Private Sub ConsultaCEP()
        Dim cCEP As New svcCEP.CEP1
        cCEP = m.ConsultaCEP(txt_Address_ZIP.Value)
        Try
            txt_Address.Value = cCEP.TipoLogradouro & " " & cCEP.Logradouro.ToUpper
            txt_Address_District.Value = cCEP.Bairro.ToUpper
            txt_Address_City.Value = cCEP.CodigoIBGE.ToUpper & " - " & cCEP.Cidade.ToUpper
            txt_Address_State.Value = cCEP.UF & " - " & cCEP.Estado
            SaveRecord()
        Catch ex As Exception
            txt_Address.Value = "INVALIDO"
            txt_Address.Value = "INVALIDO"
            txt_Address_District.Value = "INVALIDO"
            txt_Address_City.Value = "INVALIDO"
            txt_Address_State.Value = "INVALIDO"
            SaveRecord()
            m.Alert(Me, "CEP INVÁLIDO")
        End Try
    End Sub
    Sub ConsultaCPF()
        Dim Doctor_Code As String = m.ConvertText(cmb_CRM_UF.Text, clsMaster.TextCaseOptions.UpperCase) & "-" & d.FormatCRM(txt_CRM.Value)
        If txt_Birth_Date.Value = "" Then
            m.Alert(Me, "PARA VALIDAR O CPF É NECESSÁRIO A DATA DE NASCIMENTO", False, "")
            Exit Sub
        End If

        Dim pf As New svcCDC.PessoaFisicaSimplificada
        pf = m.ConsultaPessoaFisicaSimplificada(txt_Doctor_Document.Value, txt_Birth_Date.Value)
        Try
            If pf.Status = False Then
                txt_Doctor_Document.Value = "INVÁLIDO"
                m.Alert(Me, m.ConvertText(txt_Doctor_Name.Value, clsMaster.TextCaseOptions.UpperCase) & " CPF OU DATA DE NASCIMENTO INVALIDOS", False, "")
                SaveRecord()
                Exit Sub
            End If
            txt_Doctor_Name.Value = pf.Nome.ToUpper
            SaveRecord()
        Catch ex As Exception
            txt_Doctor_Document.Value = "INVÁLIDO"
            SaveRecord()
            m.Alert(Me, m.ConvertText(txt_Doctor_Name.Value, clsMaster.TextCaseOptions.UpperCase) & " CPF OU DATA DE NASCIMENTO INVALIDOS", False, "")
        End Try
    End Sub

End Class