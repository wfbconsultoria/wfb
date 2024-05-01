
Partial Class _Default
    Inherits Page
    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim url_code As String = "I1NVCSLnJ5X6LoSW"
        Dim url_report As String = "https://halexistar-admin-app.azurewebsites.net/links/"
        url_report = url_report & url_code


        ifrm_Report.Src = url_report
        ifrm_Report2.Src = url_report


    End Sub
End Class