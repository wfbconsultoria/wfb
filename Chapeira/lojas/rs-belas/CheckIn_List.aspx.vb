
Partial Class lojas_WFB_CheckIn_List
    Inherits System.Web.UI.Page
    ReadOnly l As New clsLojas
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sql = "Select * From view_Colaboradores_Ativos Where Loja_Sigla = '" & l.Loja_Sigla & "' and Id_Universo = '" & Request.QueryString("IdUniverso") & "' Order By Nome"
        If Request.QueryString("IdUniverso") = "TODOS" Then sql = "Select * From view_Colaboradores_Ativos Where Loja_Sigla = '" & l.Loja_Sigla & "' Order By Nome"

        dtsColaboradores.SelectCommand = sql
        dtsColaboradores.DataBind()
    End Sub
    Public Function FormataIcone(Parameter As String) As String
        FormataIcone = "/Images/Colaborador_Icone.png"
        If Parameter = "Sim" Then FormataIcone = "/Images/Brigadista_Icone.png"
    End Function

    Public Function FormataStatus(Parameter As String) As String
        FormataStatus = "A"
        If Parameter = "Presente" Then FormataStatus = "P"
    End Function

End Class