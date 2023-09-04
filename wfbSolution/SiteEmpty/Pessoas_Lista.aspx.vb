Public Class Pessoas_Lista
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sql As String = ""
        If IsNothing(Request.QueryString("TipoLista")) Then Response.Redirect("Default.aspx")
        If Request.QueryString("TipoLista") = "" Then Response.Redirect("Default.aspx")

        Select Case Request.QueryString("TipoLista")
            Case = "LojaTodosColaboradores"
                sql = m.strSQL(m.sqlQtdPessoas, "Nome")
        End Select


        dtsPessoas.SelectCommand = sql
        dtsPessoas.DataBind()
    End Sub

End Class