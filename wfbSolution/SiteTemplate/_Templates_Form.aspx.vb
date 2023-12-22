
Imports System.Data

Partial Class _Templates_Form
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    ReadOnly s As New clsEstabelecimentos
    ReadOnly d As New clsMedicos
    ReadOnly c As New clsCEP

    Private Sub _Templates_Form_Load(sender As Object, e As EventArgs) Handles Me.Load

        Atualiza_DTS()

    End Sub
    Private Sub Atualiza_DTS()

        dts_ESTABELECIMENTO.SelectCommand = s.sql_Estabelecimentos("ficha", Request.QueryString("idEstabelecimento"))
        dts_ESTABELECIMENTO.DataBind()
        'dtr_ESTABELECIMENTO.DataBind()

        Dim dtr As SqlClient.SqlDataReader
        dtr = m.ExecuteSelect(s.sql_Estabelecimentos("ficha", Request.QueryString("idEstabelecimento")))
        If dtr.HasRows Then
            dtr.Read()
            CNPJ.Value = dtr("CNPJ")
            ESTABELECIMENTO.Value = dtr("Estabelecimento")
            REPRESENTANTE.Value = dtr("Representante")
        End If

        If UF_CRM.Items.Count = 0 Then
            dts_UF.SelectCommand = s.sql_UF("lista")
            dts_UF.DataBind()
            UF_CRM.DataBind()
        End If

        If ID_ESPECIALIDADE.Items.Count = 0 Then
            dts_ESPECIALIDADES.SelectCommand = d.sql_especialidades("lista")
            dts_ESPECIALIDADES.DataBind()
            ID_ESPECIALIDADE.DataBind()
        End If

        If ID_TIPO.Items.Count = 0 Then
            dts_TIPOS.SelectCommand = d.sql_tipos("lista")
            dts_TIPOS.DataBind()
            ID_TIPO.DataBind()
        End If

    End Sub

    Private Sub cmd_CEP_ServerClick(sender As Object, e As EventArgs) Handles cmd_CEP.ServerClick

        If c.consultarCEP(CEP.Value) = True Then
            ENDERECO.Value = c.ENDERECO
            BAIRRO.Value = c.BAIRRO
            CIDADE.Value = c.CIDADE
            UF.Value = c.UF
            COD_IBGE_7.Value = c.COD_IBGE_7
        Else
            CEP.Value = ""
            ENDERECO.Value = ""
            BAIRRO.Value = ""
            CIDADE.Value = ""
            UF.Value = ""
            COD_IBGE_7.Value = ""
            m.Alert(Me, "CEP INVÁLIDO", False, "")
        End If

    End Sub

    Private Sub cmd_Gravar_ServerClick(sender As Object, e As EventArgs) Handles cmd_Gravar.ServerClick
        Incluir()
    End Sub

    Private Function Incluir() As Boolean
        Incluir = False

        If validaCampos() = False Then Exit Function

        If m.CheckExists("TBL_MEDICOS", "CRM_UF", d.FormatCRM(CRM.Value) & UF_CRM.Text) = True Then
            m.Alert(Me, "Médico já cadastrado", False, "")
            Exit Function
        End If

        Try
            Incluir = False
            Dim sql As String = ""
            sql &= " INSERT INTO [TBL_MEDICOS] "
            sql &= " ( "
            sql &= " [CRM_UF] "
            sql &= " ,[CRM] "
            sql &= " ,[UF_CRM] "
            sql &= " ,[NOME] "
            sql &= " ,[SOBRENOME] "
            sql &= " ,[ID_ESPECIALIDADE] "
            sql &= " ,[ID_TIPO] "
            sql &= " ,[EMAIL] "
            sql &= " ,[TELEFONE] "
            sql &= " ,[CELULAR] "
            sql &= " ,[CEP] "
            sql &= " ,[ENDERECO] "
            sql &= " ,[NUMERO] "
            sql &= " ,[COMPLEMENTO] "
            sql &= " ,[BAIRRO] "
            sql &= " ,[COD_IBGE_7] "
            sql &= " ,[CIDADE] "
            sql &= " ,[UF] "
            sql &= " ,[OBSERVACOES] "
            'sql &= " ,[ATIVO] "
            'sql &= " ,[DATA_INCLUSAO] "
            'sql &= " ,[DATA_ALTERACAO] "
            'sql &= " ,[EMAIL_INCLUSAO] "
            'sql &= " ,[EMAIL_ALTERACAO] "
            sql &= " ) "
            sql &= " VALUES "
            sql &= " ( "
            sql &= " '" & d.FormatCRM(CRM.Value) & UF_CRM.Text & "' "
            sql &= " ,'" & d.FormatCRM(CRM.Value) & "' "
            sql &= " ,'" & UF_CRM.Text & "' "
            sql &= " ,'" & m.ConvertText(NOME.Value) & "' "
            sql &= " ,'" & m.ConvertText(SOBRENOME.Value) & "' "
            sql &= " ,'" & m.ConvertValue(ID_ESPECIALIDADE.SelectedValue) & "' "
            sql &= " ,'" & m.ConvertValue(ID_TIPO.SelectedValue) & "' "
            sql &= " ,'" & m.ConvertText(EMAIL.Value) & "' "
            sql &= " ,'" & m.ConvertText(TELEFONE.Value) & "' "
            sql &= " ,'" & m.ConvertText(CELULAR.Value) & "' "
            sql &= " ,'" & c.FormatCEP(CEP.Value) & "' "
            sql &= " ,'" & m.ConvertText(ENDERECO.Value) & "' "
            sql &= " ,'" & m.ConvertText(NUMERO.Value) & "' "
            sql &= " ,'" & m.ConvertText(COMPLEMENTO.Value) & "' "
            sql &= " ,'" & m.ConvertText(BAIRRO.Value) & "' "
            sql &= " ,'" & m.ConvertText(COD_IBGE_7.Value) & "' "
            sql &= " ,'" & m.ConvertText(CIDADE.Value) & "' "
            sql &= " ,'" & m.ConvertText(UF.Value) & "' "
            sql &= " ,'" & m.ConvertText(OBSERVACOES.Value) & "' "
            'sql &= " , O "
            ',<DATA_INCLUSAO, datetime,>
            ',<DATA_ALTERACAO, datetime,>
            ',<EMAIL_INCLUSAO, varchar(256),>
            ',<EMAIL_ALTERACAO, varchar(256),>)
            sql &= " ) "

            If m.ExecuteSQL(sql) = False Then
                m.Alert(Me, "Erro ao incluir médico", False, "")
            Else
                sql = ""
                sql &= " INSERT INTO [TBL_MEDICOS_ESTABELECIMENTOS] ([CRM_UF],[CNPJ]) VALUES ( "
                sql &= " '" & d.FormatCRM(CRM.Value) & UF_CRM.Text & "', "
                sql &= " '" & CNPJ.Value & "') "
                m.ExecuteSQL(sql)
                Incluir = True
                m.Alert(Me, "Médico Incluido com sucesso", True, "Medicos.aspx")
            End If

        Catch
            Incluir = False
        End Try

    End Function

    Private Function validaCampos() As Boolean
        validaCampos = True
        If CNPJ.Value = "" Or Len(CNPJ.Value) = 0 Then validaCampos = False
        If d.FormatCRM(CRM.Value) = "00000000" Or Len(CRM.Value) = 0 Then validaCampos = False
        If UF_CRM.Text = "00" Or Len(UF_CRM.Text) = 0 Then validaCampos = False
        If ID_ESPECIALIDADE.Text = "" Or Len(ID_ESPECIALIDADE.Text) = 0 Then validaCampos = False
        If ID_TIPO.Text = "" Or Len(ID_TIPO.Text) = 0 Then validaCampos = False
        If m.ConvertText(NOME.Value = "") Or Len(m.ConvertText(NOME.Value = "")) = 0 Then validaCampos = False
        If validaCampos = False Then
            m.Alert(Me, "Preencha corretamente os campos em vermelho (*)", False, "")
        End If
    End Function
End Class
