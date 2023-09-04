Public Class clsDoctors
    'Instancia demais classes
    ReadOnly m As New clsMaster

    Public Property Doctor_Id As String = ""
    Public Property Doctor_Code As String = ""
    Public Property CRM_UF As String = ""
    Public Property CRM As String = ""
    Public Property Doctor_Specialty_Code As String = ""
    Public Property Doctor_Specialty As String = ""
    Public Property Doctor_Type_Code As String = ""
    Public Property Doctor_Type As String = ""
    Public Property Doctor_Name As String = ""
    Public Property Birth_Date As String = ""
    Public Property Birth_Month As String = ""
    Public Property Birth_Day As String = ""
    Public Property Birth_Year As String = ""
    Public Property Doctor_Document As String = ""
    Public Property Email As String = ""
    Public Property Phone As String = ""
    Public Property Mobile As String = ""
    Public Property WhatsApp As String = ""
    Public Property Address_ZIP As String = ""
    Public Property Address As String = ""
    Public Property Address_Number As String = ""
    Public Property Address_Complement As String = ""
    Public Property Address_District As String = ""
    Public Property Address_City As String = ""
    Public Property Address_City_Code As String = ""
    Public Property Address_State As String = ""
    Public Property Address_State_Code As String = ""
    Public Property Address_Country As String = ""
    Public Property Notes As String = ""
    Public Property Active As String = ""
    Public Property Account_Executive_Email As String = ""
    Public Property Account_Executive As String = ""
    Public Property Insert_User As String = ""
    Public Property Insert_Date As String = ""
    Public Property Update_User As String = ""
    Public Property Update_Date As String = ""

    Public Function GetDoctorInfos(DoctorCode As String) As Boolean
        GetDoctorInfos = False
        Try
            'Abre Conexao com banco de dados
            Dim cnn_Doctor = New System.Data.SqlClient.SqlConnection With {
                .ConnectionString = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
            }
            cnn_Doctor.Open()
            Dim cmd_Doctor As System.Data.SqlClient.SqlCommand = cnn_Doctor.CreateCommand

            Dim sql_Doctor As String = "Select * From vw_Doctors Where Doctor_Code ='" & DoctorCode & "'"
            Dim dtr_Doctor As System.Data.SqlClient.SqlDataReader
            cmd_Doctor.CommandText = sql_Doctor
            dtr_Doctor = cmd_Doctor.ExecuteReader
            If dtr_Doctor.HasRows Then
                GetDoctorInfos = True
                dtr_Doctor.Read()
                Doctor_Id = m.ConvertText(dtr_Doctor("Doctor_Id").ToString, clsMaster.TextCaseOptions.TextCase)
                Doctor_Code = m.ConvertText(dtr_Doctor("Doctor_Code"), clsMaster.TextCaseOptions.UpperCase)
                CRM_UF = m.ConvertText(dtr_Doctor("CRM_UF"), clsMaster.TextCaseOptions.UpperCase)
                CRM = m.ConvertText(dtr_Doctor("CRM"), clsMaster.TextCaseOptions.UpperCase)
                Doctor_Specialty_Code = m.ConvertText(dtr_Doctor("Doctor_Specialty_Code"), clsMaster.TextCaseOptions.UpperCase)
                Doctor_Specialty = m.ConvertText(dtr_Doctor("Doctor_Specialty"), clsMaster.TextCaseOptions.UpperCase)
                Doctor_Type_Code = m.ConvertText(dtr_Doctor("Doctor_Type_Code"), clsMaster.TextCaseOptions.UpperCase)
                Doctor_Type = m.ConvertText(dtr_Doctor("Doctor_Type"), clsMaster.TextCaseOptions.UpperCase)
                Doctor_Name = m.ConvertText(dtr_Doctor("Doctor_Name"), clsMaster.TextCaseOptions.UpperCase)
                Birth_Date = m.ConvertText(dtr_Doctor("Birth_Date"), clsMaster.TextCaseOptions.UpperCase)
                Birth_Month = m.ConvertText(dtr_Doctor("Birth_Month"), clsMaster.TextCaseOptions.UpperCase)
                Birth_Day = m.ConvertText(dtr_Doctor("Birth_Day"), clsMaster.TextCaseOptions.UpperCase)
                Birth_Year = m.ConvertText(dtr_Doctor("Birth_Year"), clsMaster.TextCaseOptions.UpperCase)
                Doctor_Document = dtr_Doctor("Doctor_Document")
                Email = m.ConvertText(dtr_Doctor("Email"), clsMaster.TextCaseOptions.UpperCase)
                Phone = m.ConvertText(dtr_Doctor("Phone"), clsMaster.TextCaseOptions.UpperCase)
                Mobile = m.ConvertText(dtr_Doctor("Mobile"), clsMaster.TextCaseOptions.UpperCase)
                WhatsApp = m.ConvertText(dtr_Doctor("WhatsApp"), clsMaster.TextCaseOptions.UpperCase)
                Address_ZIP = m.ConvertText(dtr_Doctor("Address_ZIP"), clsMaster.TextCaseOptions.UpperCase)
                Address = m.ConvertText(dtr_Doctor("Address"), clsMaster.TextCaseOptions.UpperCase)
                Address_Number = m.ConvertText(dtr_Doctor("Address_Number"), clsMaster.TextCaseOptions.UpperCase)
                Address_Complement = m.ConvertText(dtr_Doctor("Address_Complement"), clsMaster.TextCaseOptions.UpperCase)
                Address_District = m.ConvertText(dtr_Doctor("Address_District"), clsMaster.TextCaseOptions.UpperCase)
                Address_City = m.ConvertText(dtr_Doctor("Address_City"), clsMaster.TextCaseOptions.UpperCase)
                Address_City_Code = m.ConvertText(dtr_Doctor("Address_City_Code"), clsMaster.TextCaseOptions.UpperCase)
                Address_State = m.ConvertText(dtr_Doctor("Address_State"), clsMaster.TextCaseOptions.UpperCase)
                Address_State_Code = m.ConvertText(dtr_Doctor("Address_State_Code"), clsMaster.TextCaseOptions.UpperCase)
                Address_Country = m.ConvertText(dtr_Doctor("Address_Country"), clsMaster.TextCaseOptions.UpperCase)
                Notes = m.ConvertText(dtr_Doctor("Notes"), clsMaster.TextCaseOptions.UpperCase)
                Account_Executive_Email = m.ConvertText(dtr_Doctor("Account_Executive_Email"), clsMaster.TextCaseOptions.LowerCase)
                Account_Executive = m.ConvertText(dtr_Doctor("Account_Executive"), clsMaster.TextCaseOptions.UpperCase)
                Insert_User = m.ConvertText(dtr_Doctor("Insert_User"), clsMaster.TextCaseOptions.UpperCase)
                Insert_Date = m.ConvertText(dtr_Doctor("Insert_Date"), clsMaster.TextCaseOptions.UpperCase)
                Update_User = m.ConvertText(dtr_Doctor("Update_User"), clsMaster.TextCaseOptions.UpperCase)
                Update_Date = m.ConvertText(dtr_Doctor("Update_Date"), clsMaster.TextCaseOptions.UpperCase)
                Active = m.ConvertText(dtr_Doctor("Active"), clsMaster.TextCaseOptions.UpperCase)
            Else
            End If

            cnn_Doctor.Close()
        Catch ex As Exception
            GetDoctorInfos = False
            m.SystemError("000", "Erro ao Recuperar Informações Do Médico", ex.Message.ToString, "clsDoctor.GetDoctorInfos")
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
