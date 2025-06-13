Imports System.Activities.Statements
Imports System.Data
Imports System.Numerics

Partial Class Estabelecimento_Editar
    Inherits System.Web.UI.Page
    ReadOnly m As New clsMaster
    Dim Id_Estabelecimento As String
    Dim ACAO As String = ""
    Private Sub Estabelecimento_Editar_Load(sender As Object, e As EventArgs) Handles Me.Load
        If m.CheckQueryString("acao") = True Then ACAO = Request.QueryString("acao").ToString

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
            If ACAO = "DeleteRecord" Then DeleteRecord()
            If IsPostBack() = False Then RecoverRecord()
            If IsPostBack() = True Then UpdateRecord()
        End If
    End Sub
    Sub Atualiza_dts()
        Dim sql As String = ""

        'GRUPO_ESTABELECIMENTO
        sql = ""
        sql &= "Select -1 Id, '( Nenhum )' AS GRUPO Union All "
        sql &= "Select Id, GRUPO From TBL_ESTABELECIMENTOS_GRUPOS Order By GRUPO"
        dts_GRUPOS.SelectCommand = sql
        dts_GRUPOS.DataBind()

        'GRUPO_DISTRIBUIDOR
        sql = ""
        sql &= "Select -1 as Id, '( Nenhum )' AS GRUPO_DISTRIBUIDOR Union All "
        sql &= "Select Id, GRUPO_DISTRIBUIDOR From TBL_DISTRIBUIDORES_GRUPOS Order By GRUPO_DISTRIBUIDOR"
        dts_GRUPOS_DISTRIBUIDORES.SelectCommand = sql
        dts_GRUPOS_DISTRIBUIDORES.DataBind()

        'CLASSE_ESTABELECIMENTO
        sql = "Select * From TBL_ESTABELECIMENTOS_CLASSES Order By CLASSE_ESTABELECIMENTO"
        dts_CLASSES.SelectCommand = sql
        dts_CLASSES.DataBind()

        'SETORIZACAO_INCLUIR
        sql = ""
        sql &= " Select -1 as Id, '( Selecione para INCLUIR )' AS SETOR Union All "
        sql &= " Select Id, SETOR + ' (' + RESPONSAVEL + ')' as SETOR From APP_SETORIZACAO_SETORES "
        sql &= " Where Id Not In (Select Id_Setor as Id From TBL_SETORIZACAO Where Id_Estabelecimento = '" & Id_Estabelecimento & "')"
        sql &= " Order By SETOR"
        dts_SETORIZACAO_INCLUIR.SelectCommand = sql
        dts_SETORIZACAO_INCLUIR.DataBind()

        'SETORIZACAO EXCLUIR
        sql = ""
        sql &= " Select -1 as Id, '( Selecione para EXCLUIR )' AS SETOR Union All "
        sql &= " Select Id as Id, SETOR + ' (' + RESPONSAVEL + ')' as SETOR From APP_SETORIZACAO_SETORES "
        sql &= " Where Id In (Select Id_Setor as Id From TBL_SETORIZACAO Where Id_Estabelecimento = '" & Id_Estabelecimento & "')"
        sql &= " Order By SETOR"
        dts_SETORIZACAO_EXCLUIR.SelectCommand = sql
        dts_SETORIZACAO_EXCLUIR.DataBind()

        'SETORIZACAO
        sql = ""
        sql &= " Select * From APP_SETORIZACAO "
        sql &= "  Where Id_Estabelecimento = '" & Id_Estabelecimento & "'"
        sql &= " Order By Setor_SETOR"
        dts_SETORIZACAO.SelectCommand = sql
        dts_SETORIZACAO.DataBind()

    End Sub
    Sub RecoverRecord()
        Atualiza_dts()
        Dim dtr As SqlClient.SqlDataReader
        dtr = m.ExecuteSelect("Select * From APP_ESTABELECIMENTOS Where Id = '" & Id_Estabelecimento & "'")
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("NOME_FANTASIA")) Then EXCLUIR.Value = dtr("NOME_FANTASIA")
            CNPJ.Value = dtr("CNPJ")
            If Not IsDBNull(dtr("NOME_FANTASIA")) Then txt_NOME_FANTASIA.Value = dtr("NOME_FANTASIA")
            If Not IsDBNull(dtr("RAZAO_SOCIAL")) Then txt_RAZAO_SOCIAL.Value = dtr("RAZAO_SOCIAL")
            If Not IsDBNull(dtr("ENDERECO")) Then txt_ENDERECO.Value = dtr("ENDERECO")
            If Not IsDBNull(dtr("COMPLEMENTO")) Then txt_COMPLEMENTO.Value = dtr("COMPLEMENTO")
            If Not IsDBNull(dtr("CEP")) Then txt_CEP.Value = dtr("CEP")
            If Not IsDBNull(dtr("BAIRRO")) Then txt_BAIRRO.Value = dtr("BAIRRO")
            If Not IsDBNull(dtr("COD_IBGE_7")) Then txt_COD_IBGE_7.Value = dtr("COD_IBGE_7")
            If Not IsDBNull(dtr("MUNICIPIO")) Then txt_CIDADE.Value = dtr("MUNICIPIO")
            If Not IsDBNull(dtr("UF")) Then txt_UF.Value = dtr("UF")
            If Not IsDBNull(dtr("ESFERA")) Then txt_ESFERA.Value = dtr("ESFERA")
            If Not IsDBNull(dtr("NATUREZA_JURIDICA")) Then txt_NATUREZA_JURIDICA.Value = dtr("NATUREZA_JURIDICA")
            If Not IsDBNull(dtr("CNAE_SUBCLASSE_DESC")) Then txt_NATUREZA_JURIDICA.Value = dtr("CNAE_SUBCLASSE_DESC")
            If Not IsDBNull(dtr("COD_CLASSE_ESTABELECIMENTO")) Then COD_CLASSE_ESTABELECIMENTO.Text = dtr("COD_CLASSE_ESTABELECIMENTO")
            If Not IsDBNull(dtr("Id_Grupo_Estabelecimento")) Then ID_GRUPO_ESTABELECIMENTO.Text = dtr("Id_Grupo_Estabelecimento").ToString
            If Not IsDBNull(dtr("Id_Grupo_Distribuidor")) Then ID_GRUPO_DISTRIBUIDOR.Text = dtr("Id_Grupo_Distribuidor").ToString
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

        If ID_GRUPO_ESTABELECIMENTO.Text = -1 Then
            sql &= " Id_Grupo_Estabelecimento = Null,"
        Else
            sql &= " Id_Grupo_Estabelecimento = '" & ID_GRUPO_ESTABELECIMENTO.Text & "',"
        End If

        If ID_GRUPO_DISTRIBUIDOR.Text = -1 Then
            sql &= "Id_Grupo_Distribuidor = Null,"
        Else
            sql &= "Id_Grupo_Distribuidor = '" & ID_GRUPO_DISTRIBUIDOR.Text & "',"
        End If

        sql &= "[DATA_ALTERACAO] = '" & m.GettDateToString & "',"
        sql &= "[EMAIL_ALTERACAO] = '" & Session("EMAIL_LOGIN") & "'"

        sql &= " Where Id = '" & Id_Estabelecimento & "'"
        m.ExecuteSQL(sql)

        'INCLUI SETORIZACAO
        If SETORIZACAO_INCLUIR.Text <> -1 Then
            sql = ""
            sql &= " Insert Into TBL_SETORIZACAO"
            sql &= " (Id_Setor, Id_EStabelecimento, EMAIL_INCLUSAO)"
            sql &= " Values ('" & SETORIZACAO_INCLUIR.Text & "',"
            sql &= "'" & Id_Estabelecimento & "',"
            sql &= "'" & Session("EMAIL_LOGIN") & "')"
            m.ExecuteSQL(sql)
        End If
        'EXCLUI SETORIZACAO
        If SETORIZACAO_EXCLUIR.Text <> -1 Then
            sql = ""
            sql &= " Delete From TBL_SETORIZACAO"
            sql &= " Where Id_Setor = '" & SETORIZACAO_EXCLUIR.Text & "' And "
            sql &= " Id_Estabelecimento = '" & Id_Estabelecimento & "'"
            m.ExecuteSQL(sql)
        End If
        m.Alert(Me, "ESTABELECIMENTO atualizado com sucesso", True, "Estabelecimento_Editar.aspx?idEstabelecimento=" & Id_Estabelecimento)
    End Sub

    Sub DeleteRecord()
        RecoverRecord()
        Dim pagina_retorno As String = "Estabelecimentos.aspx?IdEstabelecimento=" & Request.QueryString("IdEstabelecimento")
        'check tabelas

        If m.CheckExists("TBL_ESTABELECIMENTOS", "Id", Request.QueryString("IdEstabelecimento")) = False Then
            m.Alert(Me, "NÃO É POSSIVEL EXCLUIR ESTABELECIMENTO NÃO CADASTRADO", True, pagina_retorno)
            Exit Sub
        End If

        If m.CheckExists("TBL_SETORIZACAO", "Id_Estabelecimento", Request.QueryString("IdEstabelecimento")) = True Then
            m.Alert(Me, "NÃO É POSSIVEL EXCLUIR " & txt_NOME_FANTASIA.Value & ", associado a um ou mais SETORES", True, "Estabelecimento_Editar.aspx?IdEstabelecimento=" & Request.QueryString("IdEstabelecimento"))
            Exit Sub
        End If

        'exclui
        Dim sql As String = ""
        sql = "Delete From TBL_ESTABELECIMENTOS Where Id = '" & Request.QueryString("IdEstabelecimento") & "'"
        If m.ExecuteSQL(sql) = True Then
            m.Alert(Me, "ESTABELECIMENTO EXCLUIDO COM SUCESSO", True, pagina_retorno)
            Exit Sub
        End If

    End Sub
    Private Sub cmd_Excluir_ServerClick(sender As Object, e As EventArgs) Handles cmd_Excluir.ServerClick
        Response.Redirect("EStabelecimento_Editar.aspx?IdEstabelecimento=" & Request.QueryString("IdEstabelecimento") & "&acao=DeleteRecord")
    End Sub

End Class

