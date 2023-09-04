Imports System.Data.SqlClient
Public Class _Model
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Dim l As New clsLojas
    Dim c As New clsColaboradores
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("IdColaborador") = "" Then Response.Redirect("Default.aspx")
        m.ExecuteSQL("Update tb_Colaboradores Set CheckIn = 1 Where Id = '" & Request.QueryString("IdColaborador").ToString & "'")
        RecoverRecord()
    End Sub

    Sub RecoverRecord(Optional NewIdKey As String = "")
        l.GetInfoLoja()
        c.GetInfoColaborador(Request.QueryString("IdColaborador"))
        If c.ColaboradorCheckIn_Status = "Presente" Then
            txt_Titulo.InnerHtml = "SEJA BEM VINDO"
        Else
            txt_Titulo.InnerHtml = "AGRADECE A SUA PRESENÇA"
        End If
        txt_Loja.InnerHtml = l.Loja
        txt_Nome.InnerHtml = c.ColaboradorNome.ToString
        txt_Universo.InnerHtml = c.ColaboradorUniverso.ToString
        txt_CheckIn_Date.InnerHtml = c.ColaboradorCheckIn_Date.ToString
    End Sub
End Class