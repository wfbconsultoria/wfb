Public Class Users
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtsUsers.SelectCommand = "Select * From vw_Users Order By Name"
        dtsUsers.DataBind()
    End Sub

    Public Function FormataStatus(Parameter As String) As String
        FormataStatus = "alert-primary text-center"
        If Parameter = "Locked" Then FormataStatus = "alert-danger text-center"
        If Parameter = "UnConfirmed" Then FormataStatus = "alert-warning text-center"
    End Function
    Public Function FormataIcone(Parameter As String) As String
        FormataIcone = "../Images/Icone_success.png"
        If Parameter = "Confirmed" Then FormataIcone = "../Images/Icone_warning.png"
        If Parameter = "UnConfirmed" Then FormataIcone = "../Images/Icone_pending.png"
        If Parameter = "Locked" Then FormataIcone = "../Images/Icone_danger.png"
        If Parameter = "Locked" Then FormataIcone = "../Images/Icone_danger.png"
    End Function

End Class