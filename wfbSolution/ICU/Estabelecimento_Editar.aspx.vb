Imports System.Activities.Statements
Imports System.Data

Partial Class Estabelecimento_Editar
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Dim Id_Estabelecimento As String
    Private Sub Estabelecimento_Editar_Load(sender As Object, e As EventArgs) Handles Me.Load

        If m.CheckQueryString("IdEstabelecimento") = False Then
            m.Alert(Me, "Selecione um estabelecimento", True, "Estabelecimentos.aspx")
            Exit Sub
        Else
            Atualiza_dts()
            Id_Estabelecimento = Request.QueryString("IdEstabelecimento")
            If m.CheckExists("TBL_ESTABELECIMENTOS", "Id", Id_Estabelecimento) = False Then
                m.Alert(Me, "Selecione um estabelecimento", True, "Estabelecimentos.aspx")
                Exit Sub
            End If
            If IsPostBack() = False Then RecoverRecord()
            If IsPostBack() = True Then UpdateRecord()
        End If
    End Sub
    Sub Atualiza_dts()
        Dim sql As String = ""

        'GRUPO_ESTABELECIMENTO
        sql = "Select * From TBL_ESTABELECIMENTOS_GRUPOS Order By GRUPO"
        dts_GRUPOS.SelectCommand = sql
        dts_GRUPOS.DataBind()
        ID_GRUPO_ESTABELECIMENTO.DataBind()

        'CLASSE_ESTABELECIMENTO
        sql = "Select * From TBL_ESTABELECIMENTOS_CLASSES Order By CLASSE_ESTABELECIMENTO"
        dts_CLASSES.SelectCommand = sql
        dts_CLASSES.DataBind()
        COD_CLASSE_ESTABELECIMENTO.DataBind()

        'SETORIZACAO_INCLUIR
        sql = ""
        sql &= " Select '0' as Id, '( Selecione para INCLUIR )' AS SETOR Union All "
        sql &= " Select CONVERT(VARCHAR(64), Id) as Id, SETOR + ' (' + RESPONSAVEL + ')' as SETOR From APP_SETORIZACAO_SETORES "
        sql &= " Where Id Not In (Select Id_Setor as Id From TBL_SETORIZACAO Where Id_Estabelecimento = '" & Id_Estabelecimento & "')"
        sql &= " Order By SETOR"
        dts_SETORIZACAO_INCLUIR.SelectCommand = sql
        dts_SETORIZACAO_INCLUIR.DataBind()
        SETORIZACAO_INCLUIR.DataBind()

        'SETORIZACAO EXCLUIR
        sql = ""
        sql &= " Select '0' as Id, '( Selecione para EXCLUIR )' AS SETOR Union All "
        sql &= " Select CONVERT(VARCHAR(64), Id) as Id, SETOR + ' (' + RESPONSAVEL + ')' as SETOR From APP_SETORIZACAO_SETORES "
        sql &= " Where Id In (Select Id_Setor as Id From TBL_SETORIZACAO Where Id_Estabelecimento = '" & Id_Estabelecimento & "')"
        sql &= " Order By SETOR"
        dts_SETORIZACAO_EXCLUIR.SelectCommand = sql
        dts_SETORIZACAO_EXCLUIR.DataBind()
        SETORIZACAO_EXCLUIR.DataBind()

        'SETORIZACAO
        sql = ""
        sql &= " Select * From APP_SETORIZACAO "
        sql &= "  Where Id_Estabelecimento = '" & Id_Estabelecimento & "'"
        sql &= " Order By Setor_SETOR"
        dts_SETORIZACAO.SelectCommand = sql
        dts_SETORIZACAO.DataBind()
        dtr_SETORIZACAO.DataBind()
    End Sub
    Sub RecoverRecord()
        Atualiza_dts()
        Dim dtr As SqlClient.SqlDataReader
        dtr = m.ExecuteSelect("Select * From APP_ESTABELECIMENTOS Where Id = '" & Id_Estabelecimento & "'")
        If dtr.HasRows Then
            dtr.Read()
            CNPJ.Value = dtr("CNPJ")
            txt_NOME_FANTASIA.Value = dtr("NOME_FANTASIA")
            txt_RAZAO_SOCIAL.Value = dtr("RAZAO_SOCIAL")
            txt_ENDERECO.Value = dtr("ENDERECO")
            txt_COMPLEMENTO.Value = dtr("COMPLEMENTO")
            txt_CEP.Value = dtr("CEP")
            txt_BAIRRO.Value = dtr("BAIRRO")
            txt_COD_IBGE_7.Value = dtr("COD_IBGE_7")
            txt_CIDADE.Value = dtr("MUNICIPIO")
            txt_UF.Value = dtr("UF")
            txt_COD_NATUREZA_JURIDICA.Value = dtr("COD_NATUREZA_JURIDICA")
            txt_NATUREZA_JURIDICA.Value = dtr("NATUREZA_JURIDICA")
            COD_CLASSE_ESTABELECIMENTO.Text = dtr("COD_CLASSE_ESTABELECIMENTO")
            ID_GRUPO_ESTABELECIMENTO.Text = dtr("ID_GRUPO_ESTABELECIMENTO")
        Else
            m.Alert(Me, "Selecione um estabelecimento", True, "Estabelecimentos.aspx")
        End If
    End Sub
    Sub UpdateRecord()
        'VALIDA NOME FANTASIA
        If Len(txt_NOME_FANTASIA.Value) < 3 Then
            m.Alert(Me, "NOME FANTASIA deve ter pelo meno 3 caracteres", False, "")
            Exit Sub
        End If

        'ATUALIZA ESTABELECIMENTO
        Dim sql As String = ""
        sql &= " Update TBL_ESTABELECIMENTOS Set "
        sql &= " NOME_FANTASIA = '" & m.ConvertText(txt_NOME_FANTASIA.Value, clsMaster.TextCaseOptions.UpperCase) & "',"
        sql &= " COD_CLASSE_ESTABELECIMENTO = '" & COD_CLASSE_ESTABELECIMENTO.Text & "',"
        sql &= " ID_GRUPO_ESTABELECIMENTO = '" & ID_GRUPO_ESTABELECIMENTO.Text & "'"
        sql &= " Where Id = '" & Id_Estabelecimento & "'"
        m.ExecuteSQL(sql)

        'INCLUI SETORIZACAO
        If SETORIZACAO_INCLUIR.Text <> "0" Then
            sql = ""
            sql &= " Insert Into TBL_SETORIZACAO"
            sql &= " (Id_Setor, Id_EStabelecimento, EMAIL_INCLUSAO)"
            sql &= " Values ('" & SETORIZACAO_INCLUIR.Text & "',"
            sql &= "'" & Id_Estabelecimento & "',"
            sql &= "'" & Session("EMAIL_LOGIN") & "')"
            m.ExecuteSQL(sql)
        End If
        'EXCLUI SETORIZACAO
        If SETORIZACAO_EXCLUIR.Text <> "0" Then
            sql = ""
            sql &= " Delete From TBL_SETORIZACAO"
            sql &= " Where Id_Setor = '" & SETORIZACAO_EXCLUIR.Text & "' And "
            sql &= " Id_Estabelecimento = '" & Id_Estabelecimento & "'"
            m.ExecuteSQL(sql)
        End If
        'Atualiza_dts()
        m.Alert(Me, "ESTABELECIMENTO atualizado com sucesso", False, "")
    End Sub

End Class
