
Imports System.Data
Imports ASP

Partial Class Medico_Incluir
    Inherits System.Web.UI.Page

    ReadOnly m As New clsMaster
    ReadOnly s As New clsEstabelecimentos
    ReadOnly d As New clsMedicos
    ReadOnly c As New clsCEP
    Dim IdEstabelecimento As String = ""
    Dim strCRM_UF As String = ""
    Dim strCRM As String = ""
    Dim strUF_CRM As String = ""
    Dim strCNPJ As String = ""
    Private Sub Medico_Incluir_Load(sender As Object, e As EventArgs) Handles Me.Load

        IdEstabelecimento = Request.QueryString("IdEstabelecimento")

        'Recupera CNJP do estabelecimento
        Dim dtr As SqlClient.SqlDataReader
        dtr = m.ExecuteSelect(s.sql_Estabelecimentos("ficha", Request.QueryString("idEstabelecimento")))
        If dtr.HasRows Then
            dtr.Read()
            strCNPJ = dtr("CNPJ")
        Else
            m.Alert(Me, "Selecione um estabelecimento para incluir o médico", True, "Estabelecimentos_aspx")
        End If

        strCRM_UF = Request.QueryString("CRM_UF")
        CRM.Value = Left(strCRM_UF, 8)
        UF_CRM.Value = Right(strCRM_UF, 2)
        strCRM = Left(strCRM_UF, 8)
        strUF_CRM = Right(strCRM_UF, 2)

        dts_ESPECIALIDADES.SelectCommand = d.sql_especialidades("lista")
        dts_ESPECIALIDADES.DataBind()

        dts_TIPOS.SelectCommand = d.sql_tipos("lista")
        dts_TIPOS.DataBind()

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
        Dim sql As String = ""
        If validaCampos() = False Then Exit Function

        If m.CheckExists("TBL_MEDICOS", "CRM_UF", d.FormatCRM(CRM.Value) & UF_CRM.Value) = True Then
            sql = ""
            sql &= " INSERT INTO [TBL_MEDICOS_ESTABELECIMENTOS] ([CRM_UF],[CNPJ]) VALUES ( "
            sql &= " '" & d.FormatCRM(CRM.Value) & UF_CRM.Value & "', "
            sql &= " '" & strCNPJ & "') "
            m.ExecuteSQL(sql)
            Incluir = True
            m.Alert(Me, "Médico Incluido com sucesso", True, "Medicos.aspx")
        End If


        Dim dtr As SqlClient.SqlDataReader

        Sql = ""
        sql &= " SELECT TBL_ESTABELECIMENTOS_BIH.CNPJ, TBL_MEDICOS_ESTABELECIMENTOS.CRM_UF "
        sql &= " FROM TBL_ESTABELECIMENTOS_BIH	INNER JOIN TBL_MEDICOS_ESTABELECIMENTOS "
        sql &= " ON TBL_ESTABELECIMENTOS_BIH.CNPJ = TBL_MEDICOS_ESTABELECIMENTOS.CNPJ "
        sql &= " WHERE	TBL_ESTABELECIMENTOS_BIH.ID = '" & IdEstabelecimento & "' AND TBL_MEDICOS_ESTABELECIMENTOS.CRM_UF = '" & strCRM_UF & "'"

        dtr = m.ExecuteSelect(sql)
        If dtr.HasRows Then
            m.Alert(Me, "Este CRM já está cadastrado neste estabelecimento")
            Exit Function
        End If

        Try
            Incluir = False
            sql = ""
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
            sql &= " '" & d.FormatCRM(CRM.Value) & UF_CRM.Value & "' "
            sql &= " ,'" & d.FormatCRM(CRM.Value) & "' "
            sql &= " ,'" & UF_CRM.Value & "' "
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
                sql &= " '" & d.FormatCRM(CRM.Value) & UF_CRM.Value & "', "
                sql &= " '" & strCNPJ & "') "
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
        If d.FormatCRM(CRM.Value) = "00000000" Or Len(CRM.Value) = 0 Then validaCampos = False
        If UF_CRM.Value = "00" Or Len(UF_CRM.Value) = 0 Then validaCampos = False
        If ID_ESPECIALIDADE.Text = "" Or Len(ID_ESPECIALIDADE.Text) = 0 Then validaCampos = False
        If ID_TIPO.Text = "" Or Len(ID_TIPO.Text) = 0 Then validaCampos = False
        If m.ConvertText(NOME.Value = "") Or Len(m.ConvertText(NOME.Value = "")) = 0 Then validaCampos = False
        If validaCampos = False Then
            m.Alert(Me, "Preencha corretamente os campos em vermelho (*)", False, "")
        End If
    End Function
End Class



