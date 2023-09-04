Public Class Doctors
    Inherits System.Web.UI.Page
    ReadOnly u As New clsUsers
    Dim sqlDoctors As String = ""
    Dim sqlDoctorsQtd As String = ""
    Dim sqlUsers As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        u.CheckAccess()
        cmb_AccountExecutive.Enabled = True

        'Lista de Represedntantes com médicos associados
        sqlUsers = ""
        sqlUsers &= " Select '(todos)' as Account_Executive_Email, '(todos representantes)' as Account_Executive "
        sqlUsers &= " Union All "
        sqlUsers &= " Select Account_Executive_Email, Account_Executive + N' - (' + CONVERT(VARCHAR, Qtd_Doctors) + N'  médicos )' AS Account_Executive "
        sqlUsers &= " From  dbo.vw_Doctors_by_Account_Executive "
        sqlUsers &= " Order By Account_Executive "

        'Lista de Médicos
        sqlDoctors = ""
        sqlDoctors &= " Select * From vw_Doctors Order By Doctor_Name "
        'Quantidade de Médicos
        sqlDoctorsQtd = ""
        sqlDoctorsQtd = " Select Count(Doctor_Code) From vw_Doctors "

        'Gerenciar informações conforme perfil do usuário atual
        Select Case u.LoggedProfileCode

            Case = "003"
                cmb_AccountExecutive.Enabled = False
                sqlUsers = ""
                sqlUsers &= " Select Account_Executive_Email, Account_Executive + N' - (' + CONVERT(VARCHAR, Qtd_Doctors) + N'  médicos )' AS Account_Executive "
                sqlUsers &= " From  dbo.vw_Doctors_by_Account_Executive Where Account_Executive_Email = '" & u.LoggedEmail & "'"
                sqlUsers &= " Order By Account_Executive "

                sqlDoctors = ""
                sqlDoctors &= "Select * From vw_Doctors  Where Account_Executive_Email = '" & u.LoggedEmail & "' Order By Doctor_Name"
                sqlDoctorsQtd = ""
                sqlDoctorsQtd &= " Select Count(Doctor_Code) From vw_Doctors Where Account_Executive_Email = '" & u.LoggedEmail & "'"
        End Select

        dtsDoctors.SelectCommand = u.SQL_DOCTORS
        dtsDoctors.DataBind()
        dtrDoctors.DataBind()

        dtsUsers.SelectCommand = sqlUsers
        dtsUsers.DataBind()
    End Sub

    Private Sub cmb_AccountExecutive_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_AccountExecutive.SelectedIndexChanged
        sqlDoctors = "Select * From vw_Doctors  Where Active = 1 and  Account_Executive_Email = '" & cmb_AccountExecutive.Text & "' Order By Doctor_Name"
        If cmb_AccountExecutive.Text = "(todos)" Then sqlDoctors = "Select * From vw_Doctors  Where Active = 1 Order By Doctor_Name"
        dtsDoctors.SelectCommand = sqlDoctors
        dtsDoctors.DataBind()
        dtrDoctors.DataBind()
    End Sub
End Class