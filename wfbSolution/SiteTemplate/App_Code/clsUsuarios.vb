Imports Microsoft.VisualBasic

Public Class clsUsuarios
    ReadOnly m As New clsMaster
    Public Function CheckAccess(EMAIL_LOGIN As String) As String
        If m.CheckExists("TBL_USUARIOS", "EMAIL", EMAIL_LOGIN) = False Then

        End If
    End Function
End Class
