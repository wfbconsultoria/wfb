Imports Microsoft.VisualBasic

Public Class clsUsuarios
    ReadOnly m As New clsMaster
    Public Function CheckAccess(EMAIL_LOGIN As String) As Boolean
        CheckAccess = True
        If m.CheckExists("TBL_USUARIOS", "EMAIL", EMAIL_LOGIN) = False Then
            CheckAccess = False
        End If
    End Function
End Class
