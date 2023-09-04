Public Class Medico_Consulta_CRM
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack() = True Then SaveRecord()
    End Sub
    Private Sub SaveRecord()
        'Verifica se a UF do CRM foi selecionada
        If UF_CRM.Text = "00" Then
            m.Alert(Me, "SELECIONE A UF REFERENTE AO CRM", False, "")
            Exit Sub
        End If
        'Verifica se o numero do CRM foi preenchido
        If m.FormatCRM(CRM.Value) = "0000000" Then
            m.Alert(Me, "DIGITE O CRM", False, "")
            Exit Sub
        End If
        'Verifica se o nome foi preenchido
        If Len(m.ConvertText(NOME.Value)) < 5 Then
            m.Alert(Me, "NOME DO MÉDICO DEVE CONTER NO MÍNIMO 5 CARACTERES", False, "")
            Exit Sub
        End If

        'Valida se médico já não está cadastrado e inclui caso não esteja
        Dim dtr As Data.SqlClient.SqlDataReader
        Dim sql As String
        Dim msg As String

        sql = "Select CRMUF, NOME, EMAIL_REPRESENTANTE From TBL_MEDICOS Where CRMUF = '" & m.FormatCRM(CRM.Value) & "-" & UF_CRM.Text & "'"
        dtr = m.ExecuteSelect(sql)
        If dtr.HasRows Then
            dtr.Read()
            msg = ""
            msg &= "NÃO É POSSIVEL INCLUIR ESTE MÉDICO EM SEU PAINEL." & vbCrLf
            msg &= "Nome: " & dtr("NOME") & vbCrLf
            msg &= "Situação: CADASTRADO" & vbCrLf
            msg &= "E-mail Representante: " & dtr("EMAIL_REPRESENTANTE") & vbCrLf
            MENSAGEM.Value = msg
        Else
            sql = ""
            sql &= "Insert Into TBL_MEDICOS (CRMUF, NOME, EMAIL_REPRESENTANTE, DATA_CADASTRO) Values("
            sql &= "'" & m.FormatCRM(CRM.Value) & "-" & UF_CRM.Text & "', "
            sql &= "'" & m.ConvertText(NOME.Value).ToUpper & "', "
            sql &= "'" & Session("EMAIL_LOGIN").ToString & "', "
            sql &= "'" & m.GetDateToString & "') "
            If m.ExecuteSQL(sql) = True Then
                Response.Redirect("Medico.aspx?CRMUF=" & m.FormatCRM(CRM.Value) & "-" & UF_CRM.Text)
            Else
                msg = ""
                msg &= "OCORREU UM ERRO AO INCLUIR ESTE MÉDICO EM SEU PAINEL." & vbCrLf
                msg &= "Nome: " & NOME.Value & vbCrLf
                msg &= "Situação: NÃO CADASTRADO" & vbCrLf
                msg &= "E-mail Representante: " & Session("EMAIL_LOGIN").ToString & vbCrLf
                MENSAGEM.Value = msg
            End If
        End If

    End Sub

End Class