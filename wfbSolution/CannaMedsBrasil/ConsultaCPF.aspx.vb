Imports CannaMedsBrasil.svcCDC
Public Class ConsultaCPF
    Inherits System.Web.UI.Page
    Dim m As New clsMaster
    Dim u As New clsUsers

    Private Sub ConsultaCPF_Load(sender As Object, e As EventArgs) Handles Me.Load
        u.GetUserInfos()
        'txt_Email.Value = u.UserEmail
        'txt_Name.Value = u.Name
        'txt_Document.Value = u.Document
        'txt_Birth_Date.Value = u.Birth_Date
    End Sub

    Private Sub cmd_ConsultaCEP_ServerClick(sender As Object, e As EventArgs) Handles cmd_ConsultaCEP.ServerClick
        ConsultaCEP()
    End Sub

    Private Sub cmd_ConsultaCPF_ServerClick(sender As Object, e As EventArgs) Handles cmd_ConsultaCPF.ServerClick
        ConsultaCPF()
    End Sub

    Private Sub cmd_Save_ServerClick(sender As Object, e As EventArgs) Handles cmd_Save.ServerClick
        'sql = sql & " Update tb_Users Set "
        'sql = sql & " Document = '" & m.ConvertCPFToString(txt_Document.Value) & "', "
        'sql = sql & " Birth_Date = '" & m.ConvertDate(txt_Birth_Date.Value) & "', "
        'sql = sql & " Name = '" & m.ConvertText(txt_Name.Value, clsMaster.TextCaseOptions.UpperCase) & "', "
        'sql = sql & " Profile_Updated = 1,"
        'sql = sql & " Profile_Update_Date = '" & m.ConvertDateToString(Now()) & "', "
        'sql = sql & " Update_Date = '" & m.ConvertDateToString(Now()) & "', "
        'sql = sql & " Update_User = '" & u.UserEmail & "', "
        'sql = sql & " Update_IP = '" & u.IP & "'"
        'sql = sql & " Where Email = '" & txt_Email.Value & "'"
    End Sub
    Sub ConsultaCPF()
        Dim pf As New svcCDC.PessoaFisicaSimplificada
        pf = m.ConsultaPessoaFisicaSimplificada(txt_Document.Value, txt_Birth_Date.Value)
        Try
            txt_Name.Value = pf.Nome.ToUpper
        Catch ex As Exception
            txt_Name.Value = "ERRO - CPF ou DATA DE NASCIMENTO INVÁLIDOS"
            m.Alert(Me, "CPF ou DATA DE NASCIMENTO INVÁLIDOS")
        End Try
    End Sub
    Private Sub ConsultaCEP()
        Dim cCEP As New svcCEP.CEP1
        cCEP = m.ConsultaCEP(txt_Address_ZIP.Value)
        Try
            txt_Address.Value = cCEP.TipoLogradouro & " " & cCEP.Logradouro.ToUpper
            txt_Address_District.Value = cCEP.Bairro.ToUpper
            txt_Address_City.Value = cCEP.CodigoIBGE.ToUpper & " - " & cCEP.Cidade.ToUpper
            txt_Address_State.Value = cCEP.UF & " - " & cCEP.Estado
            txt_Address_Country.Value = ConfigurationManager.AppSettings("App.Country")
        Catch ex As Exception
            txt_Address.Value = "ERRO - CEP INVÁLIDO"
            m.Alert(Me, "CEP INVÁLIDO")
        End Try
    End Sub
    Private Sub Save()

    End Sub

End Class