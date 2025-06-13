
Imports System.Data
Imports System.Reflection

Partial Class Usuarios_Lista
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Private Sub Usuarios_Lista_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack() = True Then NovoLogin()
        dts.SelectCommand = "SELECT * FROM APP_USUARIOS ORDER BY NOME"
        dts.DataBind()
        If IsPostBack() = True Then NovoLogin()
    End Sub
    Sub NovoLogin()
        'EMAIL
        If Len(m.ConvertText(EMAIL.Value, clsMaster.TextCaseOptions.LowerCase)) < 6 Then
            m.Alert(Me, "Email deve ter no mínimo 6 caracteres (x@.com)", False, "")
            Exit Sub
        End If

        If m.CheckExists("TBL_USUARIOS", "EMAIL", EMAIL.Value) = True Then
            m.Alert(Me, "Este login já existe", True, "Usuario_Incluir.aspx?EMAIL=" & EMAIL.Value & "&acao=NewRecord")
        Else
            Response.Redirect("Usuario_Incluir.aspx?EMAIL=NOVO&EMAIL2=" & EMAIL.Value)
        End If

    End Sub
End Class
