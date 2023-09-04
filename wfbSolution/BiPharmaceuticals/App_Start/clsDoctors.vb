Public Class clsDoctors
    'Instancia demais classes
    ReadOnly m As New clsMaster

    Public Property CRM_UF As String = ""
    Public Property CRM As String = ""
    Public Property Doctor_Specialty_Code As String = ""
    Public Property Doctor_Specialty As String = ""
    Public Property Doctor_Type_Code As String = ""
    Public Property Doctor_Type As String = ""
    Public Property Doctor_Code as string = ""
    Public Property Doctor_Name As String = ""
    Public Property Birth_Date As String = ""
    Public Property Doctor_Document As String = ""
    Public Property Email As String = ""
    Public Property Phone as string = ""
    Public Property Mobile As String = ""
    Public Property WhatsApp as string = ""
    Public Property Address_ZIP As String = ""
    Public Property Address as string = ""
    Public Property Address_Number As String = ""
    Public Property Address_Complement as string = ""
    Public Property Address_District As String = ""
    Public Property Address_City as string = ""
    Public Property Address_City_Code As String = ""
    Public Property Address_State as string = ""
    Public Property Address_State_Code As String = ""
    Public Property Address_Country as string = ""
    Public Property Notes As String = ""
    Public Property Active As String = ""
    Public Property Locked As String = ""
    Public Property Show As String = ""
    Public Property Deleted As String = ""
    Public Property Account_Executive_Email As String = ""
    Public Property Account_Executive As String = ""
    Public Property Insert_User As String = ""
    Public Property Insert_Date As String = ""
    Public Property Update_User As String = ""
    Public Property Update_Date As String = ""
    Public Property Last_Visit_Email As String = ""
    Public Property Last_Visit_User As String = ""
    Public Property Last_Visit_Date As String = ""
    Public Property Last_Visit_Type As String = ""
    Public Property Last_Visit_Type_Code As String = ""

    Public Function GetDoctorInfos(DoctorCode As String) As Boolean
        GetDoctorInfos = False
        Try
            'Abre Conexao com banco de dados
            Dim cnn_Doctors = New System.Data.SqlClient.SqlConnection With {
                .ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
            }
            cnn_Doctors.Open()
            Dim cmd_Doctors As System.Data.SqlClient.SqlCommand = cnn_Doctors.CreateCommand

            Dim sql_Doctors As String = "Select * From view_Doctors Where Doctor_Code ='" & DoctorCode & "'"
            Dim dtr_Doctors As System.Data.SqlClient.SqlDataReader
            cmd_Doctors.CommandText = sql_Doctors
            dtr_Doctors = cmd_Doctors.ExecuteReader
            If dtr_Doctors.HasRows Then
                GetDoctorInfos = True
                dtr_Doctors.Read()
                Doctor_Code = m.ConvertText(dtr_Doctors("Doctor_Code"), clsMaster.TextCaseOptions.UpperCase)
                CRM_UF = m.ConvertText(dtr_Doctors("CRM_UF"), clsMaster.TextCaseOptions.UpperCase)
                CRM = m.ConvertText(dtr_Doctors("CRM"), clsMaster.TextCaseOptions.UpperCase)
                Doctor_Specialty_Code = m.ConvertText(dtr_Doctors("Doctor_Specialty_Code"), clsMaster.TextCaseOptions.UpperCase)
                Doctor_Specialty = m.ConvertText(dtr_Doctors("Doctor_Specialty"), clsMaster.TextCaseOptions.UpperCase)
                Doctor_Type_Code = m.ConvertText(dtr_Doctors("Doctor_Type_Code"), clsMaster.TextCaseOptions.UpperCase)
                Doctor_Type = m.ConvertText(dtr_Doctors("Doctor_Type"), clsMaster.TextCaseOptions.UpperCase)
                Doctor_Name = m.ConvertText(dtr_Doctors("Doctor_Name"), clsMaster.TextCaseOptions.UpperCase)
                Birth_Date = m.ConvertText(dtr_Doctors("Birth_Date"), clsMaster.TextCaseOptions.UpperCase)
                Doctor_Document = dtr_Doctors("Doctor_Document")
                Email = m.ConvertText(dtr_Doctors("Email"), clsMaster.TextCaseOptions.UpperCase)
                Phone = m.ConvertText(dtr_Doctors("Phone"), clsMaster.TextCaseOptions.UpperCase)
                Mobile = m.ConvertText(dtr_Doctors("Mobile"), clsMaster.TextCaseOptions.UpperCase)
                WhatsApp = m.ConvertText(dtr_Doctors("WhatsApp"), clsMaster.TextCaseOptions.UpperCase)
                Address_ZIP = m.ConvertText(dtr_Doctors("Address_ZIP"), clsMaster.TextCaseOptions.UpperCase)
                Address = m.ConvertText(dtr_Doctors("Address"), clsMaster.TextCaseOptions.UpperCase)
                Address_Number = m.ConvertText(dtr_Doctors("Address_Number"), clsMaster.TextCaseOptions.UpperCase)
                Address_Complement = m.ConvertText(dtr_Doctors("Address_Complement"), clsMaster.TextCaseOptions.UpperCase)
                Address_District = m.ConvertText(dtr_Doctors("Address_District"), clsMaster.TextCaseOptions.UpperCase)
                Address_City = m.ConvertText(dtr_Doctors("Address_City"), clsMaster.TextCaseOptions.UpperCase)
                Address_City_Code = m.ConvertText(dtr_Doctors("Address_City_Code"), clsMaster.TextCaseOptions.UpperCase)
                Address_State = m.ConvertText(dtr_Doctors("Address_State"), clsMaster.TextCaseOptions.UpperCase)
                Address_State_Code = m.ConvertText(dtr_Doctors("Address_State_Code"), clsMaster.TextCaseOptions.UpperCase)
                Address_Country = m.ConvertText(dtr_Doctors("Address_Country"), clsMaster.TextCaseOptions.UpperCase)
                Notes = m.ConvertText(dtr_Doctors("Notes"), clsMaster.TextCaseOptions.UpperCase)
                Account_Executive_Email = m.ConvertText(dtr_Doctors("Account_Executive_Email"), clsMaster.TextCaseOptions.LowerCase)
                Account_Executive = m.ConvertText(dtr_Doctors("Account_Executive"), clsMaster.TextCaseOptions.UpperCase)
                Insert_User = m.ConvertText(dtr_Doctors("Insert_User"), clsMaster.TextCaseOptions.UpperCase)
                Insert_Date = m.ConvertText(dtr_Doctors("Insert_Date"), clsMaster.TextCaseOptions.UpperCase)
                Update_User = m.ConvertText(dtr_Doctors("Update_User"), clsMaster.TextCaseOptions.UpperCase)
                Update_Date = m.ConvertText(dtr_Doctors("Update_Date"), clsMaster.TextCaseOptions.UpperCase)
                Last_Visit_Email = m.ConvertText(dtr_Doctors("Last_Visit_Email"), clsMaster.TextCaseOptions.UpperCase)
                Last_Visit_User = m.ConvertText(dtr_Doctors("Last_Visit_User"), clsMaster.TextCaseOptions.UpperCase)
                Last_Visit_Date = m.ConvertText(dtr_Doctors("Last_Visit_Date"), clsMaster.TextCaseOptions.UpperCase)
                Last_Visit_Type = m.ConvertText(dtr_Doctors("Last_Visit_Type"), clsMaster.TextCaseOptions.UpperCase)
                Last_Visit_Type_Code = m.ConvertText(dtr_Doctors("Last_Visit_Type_Code"), clsMaster.TextCaseOptions.UpperCase)
                Active = m.ConvertText(dtr_Doctors("Active"), clsMaster.TextCaseOptions.UpperCase)
                Locked = m.ConvertText(dtr_Doctors("Locked"), clsMaster.TextCaseOptions.UpperCase)
                Show = m.ConvertText(dtr_Doctors("Show"), clsMaster.TextCaseOptions.UpperCase)
                Deleted = m.ConvertText(dtr_Doctors("Deleted"), clsMaster.TextCaseOptions.UpperCase)
            Else
            End If

            cnn_Doctors.Close()
        Catch ex As Exception
            GetDoctorInfos = False
            m.SystemError("000", "Erro ao Recuperar Informações Do Médico", ex.Message.ToString, "clsDoctors.GetDoctorInfos")
        End Try
    End Function

    Public Function FormatCRM(CRM As String) As String
        CRM = Replace(CRM, " ", "")
        If IsDBNull(CRM) Or CRM = "" Or Len(Trim(CRM)) = 0 Then
            FormatCRM = "0000000"
        Else
            FormatCRM = Right("0000000" & CRM, 7)
        End If
    End Function
End Class
