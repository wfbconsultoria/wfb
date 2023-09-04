Public Class Colaboradores_Ativos
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly l As New clsLojas
    ReadOnly c As New clsColaboradores
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dtsColaboradores.SelectCommand = c.sqlColaboradores("Colaboradores", "Sim", "Nome")
        dtsColaboradores.DataBind()
    End Sub
    Public Function FormataAtivo(Parameter As String) As String
        FormataAtivo = "alert-danger text-center"
        If Parameter = "Sim" Then FormataAtivo = "alert-success text-center"
    End Function
    Public Function FormataIcone(Parameter As String) As String
        FormataIcone = "Images/Colaborador_Icone.png"
        If Parameter = "Sim" Then FormataIcone = "Images/Brigadista_Icone.png"
    End Function

    Public Function FormataIconeAdm(Parameter As String) As String
        FormataIconeAdm = ""
        If Parameter = "Sim" Then FormataIconeAdm = "Images/Administrador_Icone.png"
    End Function

End Class