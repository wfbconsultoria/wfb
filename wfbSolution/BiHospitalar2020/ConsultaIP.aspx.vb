

Public Class ConsultaIP

    Inherits System.Web.UI.Page
    Dim u As New clsUsers
    Dim w As New clsWebInfos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        u.GetUserInfos()
        txt_UserEmail.Value = u.UserEmail
        w.GetWebInfos()
        txt_IP.Value = w.Ip
        txt_Country_Code.Value = w.IpCountryCode
        txt_Country.Value = w.IpCountry
        txt_State.Value = w.IpState
        txt_City.Value = w.IpCity
        txt_Latitude.Value = w.IpLatitude
        txt_Longitue.Value = w.IpLongitude
    End Sub
End Class