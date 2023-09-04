Public Class Doctor_Visit
    Inherits System.Web.UI.Page
    ReadOnly d As New clsDoctors
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim url As Uri = Request.UrlReferrer
        If Request.QueryString("DoctorCode") Is Nothing Or Request.QueryString("DoctorCode") = "" Then
            Response.Redirect(url.ToString)
        Else
            RecoverRecord(Request.QueryString("DoctorCode").ToString)
        End If

    End Sub
    Private Sub RecoverRecord(strDoctorCode As String)
        d.GetDoctorInfos(strDoctorCode)
        txt_Doctor_Code.Value = d.Doctor_Code
        txt_Doctor_Name.Value = d.Doctor_Name
    End Sub
End Class