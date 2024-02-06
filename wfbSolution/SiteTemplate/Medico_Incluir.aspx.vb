
Imports System.Data
Imports System.Drawing
Imports System.Threading
Imports ASP

Partial Class Medico_Incluir
    Inherits System.Web.UI.Page

    ReadOnly m As New clsMaster
    ReadOnly s As New clsEstabelecimentos
    ReadOnly d As New clsMedicos
    ReadOnly c As New clsCEP
    Dim IdEstabelecimento As String = ""
    Dim Cadastrado As Integer = 0
    Dim strCRM_UF As String = ""
    Dim strCRM As String = ""
    Dim strUF_CRM As String = ""
    Dim strCNPJ As String = ""

    Private Sub Medico_Incluir_Load(sender As Object, e As EventArgs) Handles Me.Load

        IdEstabelecimento = Request.QueryString("IdEstabelecimento")
        strCRM_UF = Request.QueryString("CRM_UF")
        'Cadastrado = Request.QueryString("Cadastrado")


        'Recupera CNPJ E NOME do estabelecimento
        Dim dtr_Estabelecimento As SqlClient.SqlDataReader = m.ExecuteSelect(s.sql_Estabelecimentos("ficha", Request.QueryString("idEstabelecimento")))
        If dtr_Estabelecimento.HasRows Then
            dtr_Estabelecimento.Read()
            strCNPJ = dtr_Estabelecimento("CNPJ")
        Else
            m.Alert(Me, "Inicie a inclusão do médico a partir de um estabelecimento", True, "Estabelecimentos_aspx")
        End If

        'Atualiza datasources da página
        Atualiza_DTS()

        If IsPostBack = True Then Gravar()

        'Verifica se o médico já existe na TBL_MEDICOS, caso exista, recupera informações
        CRM.Value = Left(strCRM_UF, 8)
        UF_CRM.Value = Right(strCRM_UF, 2)

        Dim dtr_medico As SqlClient.SqlDataReader = m.ExecuteSelect("Select * From APP_MEDICOS Where CRM_UF = '" & strCRM_UF & "'")
        If dtr_medico.HasRows Then
            dtr_medico.Read()
            CRM.Value = dtr_medico("CRM")
            UF_CRM.Value = dtr_medico("UF_CRM")
            ID_ESPECIALIDADE.Text = dtr_medico("ID_ESPECIALIDADE")
            ID_TIPO.Text = dtr_medico("ID_TIPO")
            NOME.Value = dtr_medico("NOME")
            SOBRENOME.Value = dtr_medico("SOBRENOME")
            EMAIL.Value = dtr_medico("EMAIL")
            CELULAR.Value = dtr_medico("CELULAR")
            TELEFONE.Value = dtr_medico("TELEFONE")
            CEP.Value = dtr_medico("CEP")
            ENDERECO.Value = dtr_medico("ENDERECO")
            NUMERO.Value = dtr_medico("NUMERO")
            COMPLEMENTO.Value = dtr_medico("COMPLEMENTO")
            BAIRRO.Value = dtr_medico("BAIRRO")
            COD_IBGE_7.Value = dtr_medico("COD_IBGE_7")
            OBSERVACOES.Value = dtr_medico("OBSERVACOES")
        End If

        'Verifica se o médico já existe na TBL_MEDICOS_ESTABELECIMENTOS, caso exista, recupera informações
        Dim dtr_medico_estabelecimento As SqlClient.SqlDataReader
        dtr_medico_estabelecimento = m.ExecuteSelect(" SELECT * FROM APP_MEDICOS_ESTABELECIMENTOS WHERE IdEstabelecimento = '" & IdEstabelecimento & "' AND CRM_UF = '" & strCRM_UF & "'")
        If dtr_medico_estabelecimento.HasRows Then
            dtr_medico_estabelecimento.Read()
            ID_FUNCAO.Text = dtr_medico_estabelecimento("ID_FUNCAO")
            If dtr_medico_estabelecimento("ATENDE_SEG") = True Then ATENDE_SEG.Checked = True Else ATENDE_SEG.Checked = False
            If dtr_medico_estabelecimento("ATENDE_TER") = True Then ATENDE_TER.Checked = True Else ATENDE_TER.Checked = False
            If dtr_medico_estabelecimento("ATENDE_QUA") = True Then ATENDE_QUA.Checked = True Else ATENDE_QUA.Checked = False
            If dtr_medico_estabelecimento("ATENDE_QUI") = True Then ATENDE_QUI.Checked = True Else ATENDE_QUI.Checked = False
            If dtr_medico_estabelecimento("ATENDE_SEX") = True Then ATENDE_SEX.Checked = True Else ATENDE_SEX.Checked = False


        End If

    End Sub

    Private Sub cmd_Gravar_ServerClick(sender As Object, e As EventArgs) Handles cmd_Gravar.ServerClick

    End Sub

    Private Function Gravar() As Boolean
        Gravar = False

        Dim sql As String = ""
        If validaCampos() = False Then Exit Function

        'Caso o CRM_UF JÁ EXISTA, ou seja, o médico já esteja cadastrado na TBL_MEDICOS, ATUALIZA CASO CONTRARIO, INCLUI
        If m.CheckExists("APP_MEDICOS", "CRM_UF", d.FormatCRM(CRM.Value) & UF_CRM.Value) = True Then
            'ATUALIZA
            sql &= "Update TBL_MEDICOS Set "
            sql &= " ID_ESPECIALIDADE = " & ID_ESPECIALIDADE.Text & ", "
            sql &= " ID_TIPO = " & ID_TIPO.Text & ", "
            sql &= " NOME = '" & m.ConvertText(NOME.Value) & "', "
            sql &= " SOBRENOME = '" & m.ConvertText(SOBRENOME.Value) & "', "
            sql &= " EMAIL = '" & m.ConvertText(EMAIL.Value) & "', "
            sql &= " TELEFONE = '" & m.ConvertText(TELEFONE.Value) & "', "
            sql &= " CELULAR = '" & m.ConvertText(CELULAR.Value) & "', "
            sql &= " CEP = '" & m.ConvertText(CEP.Value) & "', "
            sql &= " ENDERECO = '" & m.ConvertText(ENDERECO.Value) & "', "
            sql &= " NUMERO = '" & m.ConvertText(NUMERO.Value) & "', "
            sql &= " COMPLEMENTO = '" & m.ConvertText(COMPLEMENTO.Value) & "', "
            sql &= " BAIRRO = '" & m.ConvertText(BAIRRO.Value) & "', "
            sql &= " COD_IBGE_7 = '" & m.ConvertText(COD_IBGE_7.Value) & "', "
            sql &= " CIDADE = '" & m.ConvertText(CIDADE.Value) & "', "
            sql &= " UF = '" & m.ConvertText(UF.Value) & "', "
            sql &= " OBSERVACOES = '" & m.ConvertText(OBSERVACOES.Value) & "' "
            sql &= " Where CRM_UF = '" & strCRM_UF & "'"

            If m.ExecuteSQL(sql) = False Then
                Gravar = False
                m.Alert(Me, "Erro ao atualizar cadastro médico", False, "")
            Else
                Gravar = True
            End If
        Else
            'INCLUI
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
            sql &= " ," & ID_ESPECIALIDADE.SelectedValue
            sql &= " ," & ID_TIPO.SelectedValue
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
                Gravar = False
                m.Alert(Me, "Erro ao INCLUIR cadastro médico", False, "")
            Else
                Gravar = True
            End If
        End If

        'RECUPERA VALORES DE CHECKED DA PAGINA
        Dim bol_ATENDE_SEG As Integer = 0
        Dim bol_ATENDE_TER As Integer = 0
        Dim bol_ATENDE_QUA As Integer = 0
        Dim bol_ATENDE_QUI As Integer = 0
        Dim bol_ATENDE_SEX As Integer = 0
        If (ATENDE_SEG.Checked) Then bol_ATENDE_SEG = 1
        If (ATENDE_TER.Checked) Then bol_ATENDE_TER = 1
        If (ATENDE_QUA.Checked) Then bol_ATENDE_QUA = 1
        If (ATENDE_QUI.Checked) Then bol_ATENDE_QUI = 1
        If (ATENDE_SEX.Checked) Then bol_ATENDE_SEX = 1

        'verifica se o MEDICO já está cadastrado NA TBL_MEDICOS_ESTABELECIMENTOS, CASO ESTEJA ATUALIZA, CASO CONTRARIO INCLUI
        Dim dtr As SqlClient.SqlDataReader
        dtr = m.ExecuteSelect(" SELECT * FROM APP_MEDICOS_ESTABELECIMENTOS WHERE IdEstabelecimento = '" & IdEstabelecimento & "' AND CRM_UF = '" & strCRM_UF & "'")
        If dtr.HasRows Then
            'ATUALIZA
            sql = ""
            sql &= "Update TBL_MEDICOS_ESTABELECIMENTOS Set "
            sql &= " ID_FUNCAO = " & ID_FUNCAO.Text & ", "
            sql &= " ATENDE_SEG = " & bol_ATENDE_SEG & ", "
            sql &= " ATENDE_TER = " & bol_ATENDE_TER & ", "
            sql &= " ATENDE_QUA = " & bol_ATENDE_QUA & ", "
            sql &= " ATENDE_QUI = " & bol_ATENDE_QUI & ", "
            sql &= " ATENDE_SEX = " & bol_ATENDE_SEX & " "
            sql &= " WHERE CNPJ = '" & strCNPJ & "' AND CRM_UF = '" & strCRM_UF & "'"
            If m.ExecuteSQL(sql) = False Then
                Gravar = False
                m.Alert(Me, "Erro ao atualizar médico no estabelecimento", False, "")
            Else
                Gravar = True
            End If
        Else
            'INCLUI
            sql = ""
            sql &= " INSERT INTO [TBL_MEDICOS_ESTABELECIMENTOS] ([CRM_UF],[CNPJ],ID_FUNCAO,ATENDE_SEG,ATENDE_TER,ATENDE_QUA,ATENDE_QUI,ATENDE_SEX) VALUES ( "
            sql &= " '" & d.FormatCRM(CRM.Value) & UF_CRM.Value & "', "
            sql &= " '" & strCNPJ & "', "
            sql &= " '" & ID_FUNCAO.Text & "', "
            sql &= " '" & bol_ATENDE_SEG & "', "
            sql &= " '" & bol_ATENDE_TER & "', "
            sql &= " '" & bol_ATENDE_QUA & "', "
            sql &= " '" & bol_ATENDE_QUI & "', "
            sql &= " '" & bol_ATENDE_SEX & "') "

            If m.ExecuteSQL(sql) = False Then
                Gravar = False
                m.Alert(Me, "Erro ao incluir médico no estabelecimento", False, "")
            Else
                Gravar = True
            End If
        End If

        If Gravar = True Then
            m.Alert(Me, "Médico incluido ou atualizado com sucesso", False, "")
        Else
            m.Alert(Me, "Erro ao incluir ou atualizar médico", False, "")
        End If

    End Function

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
    Private Sub Atualiza_DTS()
        'Atualiza datasources da página
        dts_ESPECIALIDADES.SelectCommand = d.sql_especialidades("lista")
        dts_ESPECIALIDADES.DataBind()

        dts_TIPOS.SelectCommand = d.sql_tipos("lista")
        dts_TIPOS.DataBind()

        dts_FUNCOES.SelectCommand = d.sql_funcoes("lista")
        dts_FUNCOES.DataBind()
    End Sub
    Private Function validaCampos() As Boolean
        validaCampos = True
        If d.FormatCRM(CRM.Value) = "00000000" Or Len(CRM.Value) = 0 Then validaCampos = False
        If UF_CRM.Value = "00" Or Len(UF_CRM.Value) = 0 Then validaCampos = False
        If ID_ESPECIALIDADE.Text = "" Or Len(ID_ESPECIALIDADE.Text) = 0 Then validaCampos = False
        If ID_TIPO.Text = "" Or Len(ID_TIPO.Text) = 0 Then validaCampos = False
        If ID_FUNCAO.Text = "" Or Len(ID_FUNCAO.Text) = 0 Then validaCampos = False
        If m.ConvertText(NOME.Value = "") Or Len(m.ConvertText(NOME.Value = "")) = 0 Then validaCampos = False
        If validaCampos = False Then
            m.Alert(Me, "Preencha corretamente os campos em vermelho (*)", False, "")
        End If
    End Function
End Class



