Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        WebBrowser1.ScriptErrorsSuppressed = True
        WebBrowser1.Navigate("https://app.powerbi.com/view?r=eyJrIjoiNDA2Y2E1ZmMtZWRmZi00OGJlLThhNDQtYWExMGM3MTE2YjBkIiwidCI6Ijc2YjM2MTMwLTMzZjUtNGY2MC05NWVmLTg0MzlmOTQ4NmNmZiJ9")
    End Sub
End Class
