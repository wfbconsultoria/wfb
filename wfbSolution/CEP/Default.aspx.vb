
Imports System.Runtime.Remoting

Partial Class _Default
    Inherits System.Web.UI.Page

    Private Sub CONSULTAR_Click(sender As Object, e As EventArgs) Handles CONSULTAR.Click
        Dim WS As New wsCorreios.AtendeClienteClient
        Dim wsCEP = WS.consultaCEP(CEP.Text)
        LOGRADOURO.Text = wsCEP.end
    End Sub
End Class
