Public Class Medicos_Lista
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sql As String
        If Session("ADMINISTRADOR").ToString = True Then
            sql = "Select * From TBL_MEDICOS Order By NOME"
        Else
            sql = "Select * From TBL_MEDICOS Where EMAIL_REPSENTANTE = '" & Session("EMAIL_LOGIN").ToString & "'  Order By NOME"
        End If

        dts_MEDICOS.SelectCommand = sql
        dts_MEDICOS.DataBind()
    End Sub

End Class