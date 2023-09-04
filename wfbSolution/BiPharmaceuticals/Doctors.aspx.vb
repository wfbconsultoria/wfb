Public Class Doctors
    Inherits System.Web.UI.Page
    ReadOnly u As New clsUsers
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sql As String = "Select * From View_Doctors  Where Active = 1 "
        u.CheckAccess()

        Select Case u.LoggedProfileCode
            Case = "003"
                sql &= " and Account_Executive_Email = '" & u.LoggedEmail & "'"
        End Select
        sql &= " Order By Doctor_Name "
        dtsDoctors.SelectCommand = sql
        dtsDoctors.DataBind()
    End Sub

End Class