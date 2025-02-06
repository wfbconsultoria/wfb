Imports Microsoft.VisualBasic

Public Class clsUsuarios
    ReadOnly m As New clsMaster
    Public Function CheckAccess(EMAIL_LOGIN As String) As Boolean
        CheckAccess = False
        If m.CheckExists("TBL_USUARIOS", "EMAIL", EMAIL_LOGIN) = True Then CheckAccess = True
    End Function
    Public Function GeneratePassword() As String
        GeneratePassword = ""
        Dim KeyLength As Integer = 8
        Dim Number(26) As String
        Number(0) = "0"
        Number(1) = "1"
        Number(2) = "2"
        Number(3) = "3"
        Number(4) = "4"
        Number(5) = "5"
        Number(6) = "6"
        Number(7) = "7"
        Number(8) = "8"
        Number(9) = "9"

        Dim Letter(26) As String
        Letter(0) = "A"
        Letter(1) = "B"
        Letter(2) = "C"
        Letter(3) = "D"
        Letter(4) = "E"
        Letter(5) = "F"
        Letter(6) = "G"
        Letter(7) = "H"
        Letter(8) = "I"
        Letter(9) = "J"
        Letter(10) = "K"
        Letter(11) = "L"
        Letter(12) = "M"
        Letter(13) = "N"
        Letter(14) = "O"
        Letter(15) = "P"
        Letter(16) = "Q"
        Letter(17) = "R"
        Letter(18) = "S"
        Letter(19) = "T"
        Letter(20) = "U"
        Letter(21) = "V"
        Letter(22) = "X"
        Letter(23) = "W"
        Letter(24) = "Y"
        Letter(25) = "Z"

        Randomize()

        For I = 1 To KeyLength
            GeneratePassword = GeneratePassword & Number(Int(10 * Rnd()))
            GeneratePassword = GeneratePassword & Letter(Int(26 * Rnd()))
        Next

    End Function
End Class
