﻿Imports System.Activities.Statements
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
            Id_Estabelecimento = Request.QueryString("IdEstabelecimento")
            Atualiza_dts()
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
        Dim sql As String

        'GRUPO_ESTABELECIMENTO
        sql = "Select Id, GRUPO From TBL_ESTABELECIMENTOS_GRUPOS Order By GRUPO"
        dts_GRUPOS.SelectCommand = sql
        dts_GRUPOS.DataBind()

        'GRUPO_DISTRIBUIDOR
        sql = "Select GRUPO_DISTRIBUIDOR_ID, GRUPO_DISTRIBUIDOR From TBL_DISTRIBUIDORES_GRUPOS Order By GRUPO_DISTRIBUIDOR"
        dts_GRUPOS_DISTRIBUIDORES.SelectCommand = sql
        dts_GRUPOS_DISTRIBUIDORES.DataBind()

        'CLASSE_ESTABELECIMENTO
        sql = "Select CLASSE_ESTABELECIMENTO_ID, CLASSE_ESTABELECIMENTO From TBL_ESTABELECIMENTOS_CLASSES Order By CLASSE_ESTABELECIMENTO"
        dts_CLASSES.SelectCommand = sql
        dts_CLASSES.DataBind()

        'SETORIZACAO_INCLUIR
        sql = ""
        sql &= " Select '-1' as SETOR_ID, '( Selecione para INCLUIR )' AS SETOR Union All "
        sql &= " Select SETOR_ID, SETOR + ' (' + REP + ')' as SETOR From VIEW_SETORIZACAO_SETORES "
        sql &= " Where SETOR_ID Not In (Select SETOR_ID  From VIEW_ESTABELECIMENTOS_SETORIZADOS Where ESTABELECIMENTO_ID = '" & Id_Estabelecimento & "')"
        sql &= " Order By SETOR"
        dts_SETORIZACAO_INCLUIR.SelectCommand = sql
        dts_SETORIZACAO_INCLUIR.DataBind()

        'SETORIZACAO EXCLUIR
        sql = ""
        sql &= " Select '-1' as SETOR_ID, '( Selecione para INCLUIR )' AS SETOR Union All "
        sql &= " Select SETOR_ID, SETOR + ' (' + REP + ')' as SETOR From VIEW_SETORIZACAO_SETORES "
        sql &= " Where SETOR_ID In (Select SETOR_ID  From VIEW_ESTABELECIMENTOS_SETORIZADOS Where ESTABELECIMENTO_ID = '" & Id_Estabelecimento & "')"
        sql &= " Order By SETOR"
        dts_SETORIZACAO_EXCLUIR.SelectCommand = sql
        dts_SETORIZACAO_EXCLUIR.DataBind()

        'SETORIZACAO
        sql = ""
        sql &= " Select SETOR_ID, SETOR, REP + ' (' + REP_FUNCAO + ')' AS REP From VIEW_ESTABELECIMENTOS_SETORIZADOS "
        sql &= "  Where ESTABELECIMENTO_ID = '" & Id_Estabelecimento & "'"
        sql &= " Order By SETOR"
        dts_SETORIZACAO.SelectCommand = sql
        dts_SETORIZACAO.DataBind()

    End Sub
    Sub RecoverRecord()
        Atualiza_dts()
        Dim dtr As SqlClient.SqlDataReader
        dtr = m.ExecuteSelect("Select * From VIEW_ESTABELECIMENTOS Where ESTABELECIMENTO_ID = '" & Id_Estabelecimento & "'")
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
            If Not IsDBNull(dtr("MUNICIPIO_ID")) Then txt_MUNICIPIO_ID.Value = dtr("MUNICIPIO_ID")
            If Not IsDBNull(dtr("MUNICIPIO_UF")) Then txt_MUNICIPIO_UF.Value = dtr("MUNICIPIO_UF")
            If Not IsDBNull(dtr("UF")) Then txt_UF.Value = dtr("UF")
            If Not IsDBNull(dtr("ESFERA")) Then txt_ESFERA.Value = dtr("ESFERA")
            If Not IsDBNull(dtr("NATUREZA")) Then txt_NATUREZA.Value = dtr("NATUREZA")
            If Not IsDBNull(dtr("CLASSE_ESTABELECIMENTO_ID")) Then CLASSE_ESTABELECIMENTO_ID.Text = dtr("CLASSE_ESTABELECIMENTO_ID")
            If Not IsDBNull(dtr("GRUPO_ESTABELECIMENTO_ID")) Then GRUPO_ESTABELECIMENTO_ID.Text = dtr("GRUPO_ESTABELECIMENTO_ID").ToString
            If Not IsDBNull(dtr("GRUPO_DISTRIBUIDOR_ID")) Then GRUPO_DISTRIBUIDOR_ID.Text = dtr("GRUPO_DISTRIBUIDOR_ID").ToString
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
        sql &= " CLASSE_ESTABELECIMENTO_ID = '" & CLASSE_ESTABELECIMENTO_ID.Text & "',"
        sql &= " GRUPO_ESTABELECIMENTO_ID = '" & GRUPO_ESTABELECIMENTO_ID.Text & "',"
        sql &= " GRUPO_DISTRIBUIDOR_ID = '" & GRUPO_ESTABELECIMENTO_ID.Text & "',"
        sql &= "[ATUALIZACAO_EMAIL] = '" & Session("EMAIL_LOGIN") & "'"
        sql &= " Where ID = '" & Id_Estabelecimento & "'"
        m.ExecuteSQL(sql)

        'INCLUI SETORIZACAO
        If SETORIZACAO_INCLUIR.Text <> -1 Then
            sql = ""
            sql &= " Insert Into TBL_SETORIZACAO_ESTABELECIMENTOS"
            sql &= " (SETOR_ID, CNPJ, SETORIZACAO_ACAO_ID, INCLUSAO_EMAIL)"
            sql &= " Values ('" & SETORIZACAO_INCLUIR.Text & "',"
            sql &= "'" & Val(CNPJ.Value) & "',1,"
            sql &= "'" & Session("EMAIL_LOGIN") & "')"
            m.ExecuteSQL(sql)
        End If

        'EXCLUI SETORIZACAO
        If SETORIZACAO_EXCLUIR.Text <> -1 Then
            Dim SETORIZACAO_TIPO As String = ""
            'VERIFICA SE A SETORIZAÇÃO É POR ESTABELECIMENTOS OU MUNICIPIOS
            sql = ""
            sql &= " SELECT SETORIZACAO_TIPO From VIEW_SETORIZACAO"
            sql &= " Where SETOR_ID = '" & SETORIZACAO_EXCLUIR.Text & "' And "
            sql &= " CNPJ = '" & Val(CNPJ.Value) & "'"

            If m.ExecuteSQL(sql) = True Then
                Dim dtr As SqlClient.SqlDataReader = m.ExecuteSelect(sql)
                If dtr.HasRows Then
                    dtr.Read()
                    SETORIZACAO_TIPO = dtr("SETORIZACAO_TIPO")
                End If
            End If

            'CASO SEJA ESTABELECIMENTO EXCLUI A LINHA
            If SETORIZACAO_TIPO = "ESTABELECIMENTO" Then
                sql = ""
                sql &= " Delete From TBL_SETORIZACAO_ESTABELECIMENTOS"
                sql &= " Where SETOR_ID = '" & SETORIZACAO_EXCLUIR.Text & "' And "
                sql &= " CNPJ = '" & Val(CNPJ.Value) & "'"
                m.ExecuteSQL(sql)
            End If
            'CASO SEJA MUNICIPIO ATUALIZA
            If SETORIZACAO_TIPO = "MUNICIPIO" Then
                sql = ""
                sql &= " UPDATE TBL_SETORIZACAO_ESTABELECIMENTOS SET SETORIZACAO_ACAO_ID = 2"
                sql &= " Where SETOR_ID = '" & SETORIZACAO_EXCLUIR.Text & "' And "
                sql &= " CNPJ = '" & Val(CNPJ.Value) & "'"
                m.ExecuteSQL(sql)
            End If
        End If
        m.Alert(Me, "ESTABELECIMENTO atualizado com sucesso", True, "Estabelecimento_Editar.aspx?idEstabelecimento=" & Id_Estabelecimento)
    End Sub

    Sub DeleteRecord()
        'RecoverRecord()
        'Dim pagina_retorno As String = "Estabelecimentos.aspx?IdEstabelecimento=" & Request.QueryString("IdEstabelecimento")
        ''check tabelas

        'If m.CheckExists("TBL_ESTABELECIMENTOS", "Id", Request.QueryString("IdEstabelecimento")) = False Then
        '    m.Alert(Me, "NÃO É POSSIVEL EXCLUIR ESTABELECIMENTO NÃO CADASTRADO", True, pagina_retorno)
        '    Exit Sub
        'End If

        'If m.CheckExists("TBL_SETORIZACAO", "Id_Estabelecimento", Request.QueryString("IdEstabelecimento")) = True Then
        '    m.Alert(Me, "NÃO É POSSIVEL EXCLUIR " & txt_NOME_FANTASIA.Value & ", associado a um ou mais SETORES", True, "Estabelecimento_Editar.aspx?IdEstabelecimento=" & Request.QueryString("IdEstabelecimento"))
        '    Exit Sub
        'End If

        ''exclui
        'Dim sql As String
        'sql = "Delete From TBL_ESTABELECIMENTOS Where Id = '" & Request.QueryString("IdEstabelecimento") & "'"
        'If m.ExecuteSQL(sql) = True Then
        '    m.Alert(Me, "ESTABELECIMENTO EXCLUIDO COM SUCESSO", True, pagina_retorno)
        '    Exit Sub
        'End If
        m.Alert(Me, "NAO É POSSÍVEL EFETUAR EXCLUSOES, CONTATE O ADMINISTRADOR", False, "")

    End Sub
    Private Sub cmd_Excluir_ServerClick(sender As Object, e As EventArgs) Handles cmd_Excluir.ServerClick
        m.Alert(Me, "NAO É POSSÍVEL EFETUAR EXCLUSOES, CONTATE O ADMINISTRADOR", False, "")
        'Response.Redirect("EStabelecimento_Editar.aspx?IdEstabelecimento=" & Request.QueryString("IdEstabelecimento") & "&acao=DeleteRecord")
    End Sub

End Class

