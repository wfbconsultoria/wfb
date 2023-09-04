Public Class CheckIn_Mobis
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtsMobis.SelectCommand = "Select * From vw_Mobis"
        dtsMobis.DataBind()
    End Sub
    Public Function FormataAtivo(Parameter As String) As String
        FormataAtivo = "alert-danger text-center"
        If Parameter = "Sim" Then FormataAtivo = "alert-success text-center"
    End Function
    Public Function FormataIcone(Parameter As String) As String
        FormataIcone = "Images/Mobi_Indisponivel.png"
        If Parameter = "Disponivel" Then FormataIcone = "Images/Mobi_Disponivel.png"
    End Function



End Class