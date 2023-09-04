Public Class Address_Search
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m.CheckLogin()

        '        INSERT INTO [dbo].[tb_Address]
        '           ([Id]
        '           ,[Address_Key]
        '           ,[Address_ZIP]
        '           ,[Address]
        '           ,[Address_Number]
        '           ,[Address_Complement]
        '           ,[Address_District]
        '           ,[Address_City]
        '           ,[Address_City_Code]
        '           ,[Address_State]
        '           ,[Address_State_Code]
        '           ,[Address_Reference]
        '           ,[Address_Country])
        '     VALUES
        '           (<Id, uniqueidentifier,>
        '           ,<Address_Key, nvarchar(256),>
        '           ,<Address_ZIP, nvarchar(16),>
        '           ,<Address, nvarchar(max),>
        '           ,<Address_Number, nvarchar(32),>
        '           ,<Address_Complement, nvarchar(256),>
        '           ,<Address_District, nvarchar(256),>
        '           ,<Address_City, nvarchar(256),>
        '           ,<Address_City_Code, nvarchar(16),>
        '           ,<Address_State, nvarchar(128),>
        '           ,<Address_State_Code, nvarchar(16),>
        '           ,<Address_Reference, nvarchar(max),>
        '           ,<Address_Country, nvarchar(128),>)
        'GO


    End Sub

    Private Sub cmd_ConsultaCEP_ServerClick(sender As Object, e As EventArgs) Handles cmd_ConsultaCEP.ServerClick
        If Len(txt_Address_ZIP.Value) <> 9 Or IsNumeric(Replace(txt_Address_ZIP.Value, "-", "")) = False Then
            txt_Address.Value = ""
            txt_Address_District.Value = ""
            txt_Address_City_Code.Value = ""
            txt_Address_City.Value = ""
            txt_Address_State.Value = ""
            m.Alert(Me, "Digite um CEP válido")
            Exit Sub
        Else
            Dim cCEP As New svcCEP.CEP1
            cCEP = m.ConsultaCEP(txt_Address_ZIP.Value)
            Try
                txt_Address.Value = cCEP.TipoLogradouro & " " & cCEP.Logradouro.ToUpper
                txt_Address_District.Value = cCEP.Bairro.ToUpper
                txt_Address_City_Code.Value = cCEP.CodigoIBGE.ToUpper
                txt_Address_City.Value = cCEP.Cidade.ToUpper
                txt_Address_State.Value = cCEP.UF
                m.Alert(Me, "CEP encontrado com sucesso, preencha o número e complemento e clique em GRAVAR")
            Catch ex As Exception
                txt_Address.Value = ""
                txt_Address_District.Value = ""
                txt_Address_City_Code.Value = ""
                txt_Address_City.Value = ""
                txt_Address_State.Value = ""
                m.Alert(Me, "CEP inválido ou não encontrado")
            End Try
        End If
    End Sub
End Class