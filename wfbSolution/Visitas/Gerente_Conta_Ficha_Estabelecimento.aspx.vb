Imports System.Math
Partial Class Gerente_Conta_Ficha_Estabelecimento
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Gerente_Conta_Ficha_Estabelecimento.aspx"

    Dim cnn_linha_produto As New System.Data.SqlClient.SqlConnection
    Dim cmd_linha_produto As New System.Data.SqlClient.SqlCommand
    Dim dtr_linha_produto As System.Data.SqlClient.SqlDataReader
    Dim sql_linha_produto As String

    Dim cnn_estabelecimento As New System.Data.SqlClient.SqlConnection
    Dim cmd_estabelecimento As New System.Data.SqlClient.SqlCommand
    Dim dtr_estabelecimento As System.Data.SqlClient.SqlDataReader
    Dim sql_estabelecimento As String

    Dim cnn As New System.Data.SqlClient.SqlConnection
    Dim cmd As New System.Data.SqlClient.SqlCommand
    Dim dtr As System.Data.SqlClient.SqlDataReader
    Dim sql As String

    Dim rw As TableRow
    Dim cel As TableCell
    Dim EMAIL As String
    Dim ANO_RETRASADO As Integer
    Dim ANO_PASSADO As Integer
    Dim ANO_ATUAL As Integer
    Dim MES_ATUAL As Integer
    Dim LINHA_PRODUTO As String
    Dim COD_GRUPO_BOMBA As Integer

    Dim JAN_DEMANDA_RETRASADO As Integer
    Dim FEV_DEMANDA_RETRASADO As Integer
    Dim MAR_DEMANDA_RETRASADO As Integer
    Dim ABR_DEMANDA_RETRASADO As Integer
    Dim MAI_DEMANDA_RETRASADO As Integer
    Dim JUN_DEMANDA_RETRASADO As Integer
    Dim JUL_DEMANDA_RETRASADO As Integer
    Dim AGO_DEMANDA_RETRASADO As Integer
    Dim SET_DEMANDA_RETRASADO As Integer
    Dim OUT_DEMANDA_RETRASADO As Integer
    Dim NOV_DEMANDA_RETRASADO As Integer
    Dim DEZ_DEMANDA_RETRASADO As Integer
    Dim TRI01_DEMANDA_RETRASADO As Integer
    Dim TRI02_DEMANDA_RETRASADO As Integer
    Dim TRI03_DEMANDA_RETRASADO As Integer
    Dim TRI04_DEMANDA_RETRASADO As Integer
    Dim TOTAL_DEMANDA_RETRASADO As Integer
    Dim YTD_DEMANDA_RETRASADO As Integer

    Dim JAN_DEMANDA_PASSADO As Integer
    Dim FEV_DEMANDA_PASSADO As Integer
    Dim MAR_DEMANDA_PASSADO As Integer
    Dim ABR_DEMANDA_PASSADO As Integer
    Dim MAI_DEMANDA_PASSADO As Integer
    Dim JUN_DEMANDA_PASSADO As Integer
    Dim JUL_DEMANDA_PASSADO As Integer
    Dim AGO_DEMANDA_PASSADO As Integer
    Dim SET_DEMANDA_PASSADO As Integer
    Dim OUT_DEMANDA_PASSADO As Integer
    Dim NOV_DEMANDA_PASSADO As Integer
    Dim DEZ_DEMANDA_PASSADO As Integer
    Dim TRI01_DEMANDA_PASSADO As Integer
    Dim TRI02_DEMANDA_PASSADO As Integer
    Dim TRI03_DEMANDA_PASSADO As Integer
    Dim TRI04_DEMANDA_PASSADO As Integer
    Dim TOTAL_DEMANDA_PASSADO As Integer
    Dim YTD_DEMANDA_PASSADO As Integer

    Dim JAN_DEMANDA_ATUAL As Integer
    Dim FEV_DEMANDA_ATUAL As Integer
    Dim MAR_DEMANDA_ATUAL As Integer
    Dim ABR_DEMANDA_ATUAL As Integer
    Dim MAI_DEMANDA_ATUAL As Integer
    Dim JUN_DEMANDA_ATUAL As Integer
    Dim JUL_DEMANDA_ATUAL As Integer
    Dim AGO_DEMANDA_ATUAL As Integer
    Dim SET_DEMANDA_ATUAL As Integer
    Dim OUT_DEMANDA_ATUAL As Integer
    Dim NOV_DEMANDA_ATUAL As Integer
    Dim DEZ_DEMANDA_ATUAL As Integer
    Dim TRI01_DEMANDA_ATUAL As Integer
    Dim TRI02_DEMANDA_ATUAL As Integer
    Dim TRI03_DEMANDA_ATUAL As Integer
    Dim TRI04_DEMANDA_ATUAL As Integer
    Dim TOTAL_DEMANDA_ATUAL As Integer
    Dim YTD_DEMANDA_ATUAL As Integer

    Dim JAN_DEMANDA_ATUAL_ESTABELECIMENTO As Integer
    Dim FEV_DEMANDA_ATUAL_ESTABELECIMENTO As Integer
    Dim MAR_DEMANDA_ATUAL_ESTABELECIMENTO As Integer
    Dim ABR_DEMANDA_ATUAL_ESTABELECIMENTO As Integer
    Dim MAI_DEMANDA_ATUAL_ESTABELECIMENTO As Integer
    Dim JUN_DEMANDA_ATUAL_ESTABELECIMENTO As Integer
    Dim JUL_DEMANDA_ATUAL_ESTABELECIMENTO As Integer
    Dim AGO_DEMANDA_ATUAL_ESTABELECIMENTO As Integer
    Dim SET_DEMANDA_ATUAL_ESTABELECIMENTO As Integer
    Dim OUT_DEMANDA_ATUAL_ESTABELECIMENTO As Integer
    Dim NOV_DEMANDA_ATUAL_ESTABELECIMENTO As Integer
    Dim DEZ_DEMANDA_ATUAL_ESTABELECIMENTO As Integer
    Dim TRI01_DEMANDA_ATUAL_ESTABELECIMENTO As Integer
    Dim TRI02_DEMANDA_ATUAL_ESTABELECIMENTO As Integer
    Dim TRI03_DEMANDA_ATUAL_ESTABELECIMENTO As Integer
    Dim TRI04_DEMANDA_ATUAL_ESTABELECIMENTO As Integer
    Dim TOTAL_DEMANDA_ATUAL_ESTABELECIMENTO As Integer
    Dim YTD_DEMANDA_ATUAL_ESTABELECIMENTO As Integer

    Dim JAN_BASE_NEGOCIOS As Integer
    Dim FEV_BASE_NEGOCIOS As Integer
    Dim MAR_BASE_NEGOCIOS As Integer
    Dim ABR_BASE_NEGOCIOS As Integer
    Dim MAI_BASE_NEGOCIOS As Integer
    Dim JUN_BASE_NEGOCIOS As Integer
    Dim JUL_BASE_NEGOCIOS As Integer
    Dim AGO_BASE_NEGOCIOS As Integer
    Dim SET_BASE_NEGOCIOS As Integer
    Dim OUT_BASE_NEGOCIOS As Integer
    Dim NOV_BASE_NEGOCIOS As Integer
    Dim DEZ_BASE_NEGOCIOS As Integer
    Dim TRI01_BASE_NEGOCIOS As Integer
    Dim TRI02_BASE_NEGOCIOS As Integer
    Dim TRI03_BASE_NEGOCIOS As Integer
    Dim TRI04_BASE_NEGOCIOS As Integer
    Dim TOTAL_BASE_NEGOCIOS As Integer
    Dim YTD_BASE_NEGOCIOS As Integer

    Dim JAN_OPORTUNIDADES_025 As Integer
    Dim FEV_OPORTUNIDADES_025 As Integer
    Dim MAR_OPORTUNIDADES_025 As Integer
    Dim ABR_OPORTUNIDADES_025 As Integer
    Dim MAI_OPORTUNIDADES_025 As Integer
    Dim JUN_OPORTUNIDADES_025 As Integer
    Dim JUL_OPORTUNIDADES_025 As Integer
    Dim AGO_OPORTUNIDADES_025 As Integer
    Dim SET_OPORTUNIDADES_025 As Integer
    Dim OUT_OPORTUNIDADES_025 As Integer
    Dim NOV_OPORTUNIDADES_025 As Integer
    Dim DEZ_OPORTUNIDADES_025 As Integer
    Dim TRI01_OPORTUNIDADES_025 As Integer
    Dim TRI02_OPORTUNIDADES_025 As Integer
    Dim TRI03_OPORTUNIDADES_025 As Integer
    Dim TRI04_OPORTUNIDADES_025 As Integer
    Dim TOTAL_OPORTUNIDADES_025 As Integer
    Dim YTD_OPORTUNIDADES_025 As Integer

    Dim JAN_OPORTUNIDADES_050 As Integer
    Dim FEV_OPORTUNIDADES_050 As Integer
    Dim MAR_OPORTUNIDADES_050 As Integer
    Dim ABR_OPORTUNIDADES_050 As Integer
    Dim MAI_OPORTUNIDADES_050 As Integer
    Dim JUN_OPORTUNIDADES_050 As Integer
    Dim JUL_OPORTUNIDADES_050 As Integer
    Dim AGO_OPORTUNIDADES_050 As Integer
    Dim SET_OPORTUNIDADES_050 As Integer
    Dim OUT_OPORTUNIDADES_050 As Integer
    Dim NOV_OPORTUNIDADES_050 As Integer
    Dim DEZ_OPORTUNIDADES_050 As Integer
    Dim TRI01_OPORTUNIDADES_050 As Integer
    Dim TRI02_OPORTUNIDADES_050 As Integer
    Dim TRI03_OPORTUNIDADES_050 As Integer
    Dim TRI04_OPORTUNIDADES_050 As Integer
    Dim TOTAL_OPORTUNIDADES_050 As Integer
    Dim YTD_OPORTUNIDADES_050 As Integer

    Dim JAN_OPORTUNIDADES_075 As Integer
    Dim FEV_OPORTUNIDADES_075 As Integer
    Dim MAR_OPORTUNIDADES_075 As Integer
    Dim ABR_OPORTUNIDADES_075 As Integer
    Dim MAI_OPORTUNIDADES_075 As Integer
    Dim JUN_OPORTUNIDADES_075 As Integer
    Dim JUL_OPORTUNIDADES_075 As Integer
    Dim AGO_OPORTUNIDADES_075 As Integer
    Dim SET_OPORTUNIDADES_075 As Integer
    Dim OUT_OPORTUNIDADES_075 As Integer
    Dim NOV_OPORTUNIDADES_075 As Integer
    Dim DEZ_OPORTUNIDADES_075 As Integer
    Dim TRI01_OPORTUNIDADES_075 As Integer
    Dim TRI02_OPORTUNIDADES_075 As Integer
    Dim TRI03_OPORTUNIDADES_075 As Integer
    Dim TRI04_OPORTUNIDADES_075 As Integer
    Dim TOTAL_OPORTUNIDADES_075 As Integer
    Dim YTD_OPORTUNIDADES_075 As Integer

    Dim JAN_OPORTUNIDADES_100 As Integer
    Dim FEV_OPORTUNIDADES_100 As Integer
    Dim MAR_OPORTUNIDADES_100 As Integer
    Dim ABR_OPORTUNIDADES_100 As Integer
    Dim MAI_OPORTUNIDADES_100 As Integer
    Dim JUN_OPORTUNIDADES_100 As Integer
    Dim JUL_OPORTUNIDADES_100 As Integer
    Dim AGO_OPORTUNIDADES_100 As Integer
    Dim SET_OPORTUNIDADES_100 As Integer
    Dim OUT_OPORTUNIDADES_100 As Integer
    Dim NOV_OPORTUNIDADES_100 As Integer
    Dim DEZ_OPORTUNIDADES_100 As Integer
    Dim TRI01_OPORTUNIDADES_100 As Integer
    Dim TRI02_OPORTUNIDADES_100 As Integer
    Dim TRI03_OPORTUNIDADES_100 As Integer
    Dim TRI04_OPORTUNIDADES_100 As Integer
    Dim TOTAL_OPORTUNIDADES_100 As Integer
    Dim YTD_OPORTUNIDADES_100 As Integer

    Dim JAN_OPORTUNIDADES_TOTAL As Integer
    Dim FEV_OPORTUNIDADES_TOTAL As Integer
    Dim MAR_OPORTUNIDADES_TOTAL As Integer
    Dim ABR_OPORTUNIDADES_TOTAL As Integer
    Dim MAI_OPORTUNIDADES_TOTAL As Integer
    Dim JUN_OPORTUNIDADES_TOTAL As Integer
    Dim JUL_OPORTUNIDADES_TOTAL As Integer
    Dim AGO_OPORTUNIDADES_TOTAL As Integer
    Dim SET_OPORTUNIDADES_TOTAL As Integer
    Dim OUT_OPORTUNIDADES_TOTAL As Integer
    Dim NOV_OPORTUNIDADES_TOTAL As Integer
    Dim DEZ_OPORTUNIDADES_TOTAL As Integer
    Dim TRI01_OPORTUNIDADES_TOTAL As Integer
    Dim TRI02_OPORTUNIDADES_TOTAL As Integer
    Dim TRI03_OPORTUNIDADES_TOTAL As Integer
    Dim TRI04_OPORTUNIDADES_TOTAL As Integer
    Dim TOTAL_OPORTUNIDADES_TOTAL As Integer
    Dim YTD_OPORTUNIDADES_TOTAL As Integer

    Dim JAN_PREVISTO As Integer
    Dim FEV_PREVISTO As Integer
    Dim MAR_PREVISTO As Integer
    Dim ABR_PREVISTO As Integer
    Dim MAI_PREVISTO As Integer
    Dim JUN_PREVISTO As Integer
    Dim JUL_PREVISTO As Integer
    Dim AGO_PREVISTO As Integer
    Dim SET_PREVISTO As Integer
    Dim OUT_PREVISTO As Integer
    Dim NOV_PREVISTO As Integer
    Dim DEZ_PREVISTO As Integer
    Dim TRI01_PREVISTO As Integer
    Dim TRI02_PREVISTO As Integer
    Dim TRI03_PREVISTO As Integer
    Dim TRI04_PREVISTO As Integer
    Dim TOTAL_PREVISTO As Integer
    Dim YTD_PREVISTO As Integer

    Dim JAN_CRESCIMENTO_ATUAL_PASSADO As Double
    Dim FEV_CRESCIMENTO_ATUAL_PASSADO As Double
    Dim MAR_CRESCIMENTO_ATUAL_PASSADO As Double
    Dim ABR_CRESCIMENTO_ATUAL_PASSADO As Double
    Dim MAI_CRESCIMENTO_ATUAL_PASSADO As Double
    Dim JUN_CRESCIMENTO_ATUAL_PASSADO As Double
    Dim JUL_CRESCIMENTO_ATUAL_PASSADO As Double
    Dim AGO_CRESCIMENTO_ATUAL_PASSADO As Double
    Dim SET_CRESCIMENTO_ATUAL_PASSADO As Double
    Dim OUT_CRESCIMENTO_ATUAL_PASSADO As Double
    Dim NOV_CRESCIMENTO_ATUAL_PASSADO As Double
    Dim DEZ_CRESCIMENTO_ATUAL_PASSADO As Double
    Dim TRI01_CRESCIMENTO_ATUAL_PASSADO As Double
    Dim TRI02_CRESCIMENTO_ATUAL_PASSADO As Double
    Dim TRI03_CRESCIMENTO_ATUAL_PASSADO As Double
    Dim TRI04_CRESCIMENTO_ATUAL_PASSADO As Double
    Dim TOTAL_CRESCIMENTO_ATUAL_PASSADO As Double
    Dim YTD_CRESCIMENTO_ATUAL_PASSADO As Double

    Dim JAN_CRESCIMENTO_PASSADO_RETRASADO As Double
    Dim FEV_CRESCIMENTO_PASSADO_RETRASADO As Double
    Dim MAR_CRESCIMENTO_PASSADO_RETRASADO As Double
    Dim ABR_CRESCIMENTO_PASSADO_RETRASADO As Double
    Dim MAI_CRESCIMENTO_PASSADO_RETRASADO As Double
    Dim JUN_CRESCIMENTO_PASSADO_RETRASADO As Double
    Dim JUL_CRESCIMENTO_PASSADO_RETRASADO As Double
    Dim AGO_CRESCIMENTO_PASSADO_RETRASADO As Double
    Dim SET_CRESCIMENTO_PASSADO_RETRASADO As Double
    Dim OUT_CRESCIMENTO_PASSADO_RETRASADO As Double
    Dim NOV_CRESCIMENTO_PASSADO_RETRASADO As Double
    Dim DEZ_CRESCIMENTO_PASSADO_RETRASADO As Double
    Dim TRI01_CRESCIMENTO_PASSADO_RETRASADO As Double
    Dim TRI02_CRESCIMENTO_PASSADO_RETRASADO As Double
    Dim TRI03_CRESCIMENTO_PASSADO_RETRASADO As Double
    Dim TRI04_CRESCIMENTO_PASSADO_RETRASADO As Double
    Dim TOTAL_CRESCIMENTO_PASSADO_RETRASADO As Double
    Dim YTD_CRESCIMENTO_PASSADO_RETRASADO As Double

    Dim JAN_BOMBAS As Integer
    Dim FEV_BOMBAS As Integer
    Dim MAR_BOMBAS As Integer
    Dim ABR_BOMBAS As Integer
    Dim MAI_BOMBAS As Integer
    Dim JUN_BOMBAS As Integer
    Dim JUL_BOMBAS As Integer
    Dim AGO_BOMBAS As Integer
    Dim SET_BOMBAS As Integer
    Dim OUT_BOMBAS As Integer
    Dim NOV_BOMBAS As Integer
    Dim DEZ_BOMBAS As Integer
    Dim TRI01_BOMBAS As Integer
    Dim TRI02_BOMBAS As Integer
    Dim TRI03_BOMBAS As Integer
    Dim TRI04_BOMBAS As Integer
    Dim TOTAL_BOMBAS As Integer
    Dim YTD_BOMBAS As Integer

    Dim JAN_BOMBAS_estabelecimento As Integer
    Dim FEV_BOMBAS_estabelecimento As Integer
    Dim MAR_BOMBAS_estabelecimento As Integer
    Dim ABR_BOMBAS_estabelecimento As Integer
    Dim MAI_BOMBAS_estabelecimento As Integer
    Dim JUN_BOMBAS_estabelecimento As Integer
    Dim JUL_BOMBAS_estabelecimento As Integer
    Dim AGO_BOMBAS_estabelecimento As Integer
    Dim SET_BOMBAS_estabelecimento As Integer
    Dim OUT_BOMBAS_estabelecimento As Integer
    Dim NOV_BOMBAS_estabelecimento As Integer
    Dim DEZ_BOMBAS_estabelecimento As Integer
    Dim TRI01_BOMBAS_estabelecimento As Integer
    Dim TRI02_BOMBAS_estabelecimento As Integer
    Dim TRI03_BOMBAS_estabelecimento As Integer
    Dim TRI04_BOMBAS_estabelecimento As Integer
    Dim TOTAL_BOMBAS_estabelecimento As Integer
    Dim YTD_BOMBAS_estabelecimento As Integer

    Dim JAN_BOMBAS_REP As Integer
    Dim FEV_BOMBAS_REP As Integer
    Dim MAR_BOMBAS_REP As Integer
    Dim ABR_BOMBAS_REP As Integer
    Dim MAI_BOMBAS_REP As Integer
    Dim JUN_BOMBAS_REP As Integer
    Dim JUL_BOMBAS_REP As Integer
    Dim AGO_BOMBAS_REP As Integer
    Dim SET_BOMBAS_REP As Integer
    Dim OUT_BOMBAS_REP As Integer
    Dim NOV_BOMBAS_REP As Integer
    Dim DEZ_BOMBAS_REP As Integer
    Dim TRI01_BOMBAS_REP As Integer
    Dim TRI02_BOMBAS_REP As Integer
    Dim TRI03_BOMBAS_REP As Integer
    Dim TRI04_BOMBAS_REP As Integer
    Dim TOTAL_BOMBAS_REP As Integer
    Dim YTD_BOMBAS_REP As Integer

    Dim JAN_BOMBAS_DST As Integer
    Dim FEV_BOMBAS_DST As Integer
    Dim MAR_BOMBAS_DST As Integer
    Dim ABR_BOMBAS_DST As Integer
    Dim MAI_BOMBAS_DST As Integer
    Dim JUN_BOMBAS_DST As Integer
    Dim JUL_BOMBAS_DST As Integer
    Dim AGO_BOMBAS_DST As Integer
    Dim SET_BOMBAS_DST As Integer
    Dim OUT_BOMBAS_DST As Integer
    Dim NOV_BOMBAS_DST As Integer
    Dim DEZ_BOMBAS_DST As Integer
    Dim TRI01_BOMBAS_DST As Integer
    Dim TRI02_BOMBAS_DST As Integer
    Dim TRI03_BOMBAS_DST As Integer
    Dim TRI04_BOMBAS_DST As Integer
    Dim TOTAL_BOMBAS_DST As Integer
    Dim YTD_BOMBAS_DST As Integer

    Dim JAN_BOMBAS_PRODUTIVIDADE As Integer
    Dim FEV_BOMBAS_PRODUTIVIDADE As Integer
    Dim MAR_BOMBAS_PRODUTIVIDADE As Integer
    Dim ABR_BOMBAS_PRODUTIVIDADE As Integer
    Dim MAI_BOMBAS_PRODUTIVIDADE As Integer
    Dim JUN_BOMBAS_PRODUTIVIDADE As Integer
    Dim JUL_BOMBAS_PRODUTIVIDADE As Integer
    Dim AGO_BOMBAS_PRODUTIVIDADE As Integer
    Dim SET_BOMBAS_PRODUTIVIDADE As Integer
    Dim OUT_BOMBAS_PRODUTIVIDADE As Integer
    Dim NOV_BOMBAS_PRODUTIVIDADE As Integer
    Dim DEZ_BOMBAS_PRODUTIVIDADE As Integer
    Dim TRI01_BOMBAS_PRODUTIVIDADE As Integer
    Dim TRI02_BOMBAS_PRODUTIVIDADE As Integer
    Dim TRI03_BOMBAS_PRODUTIVIDADE As Integer
    Dim TRI04_BOMBAS_PRODUTIVIDADE As Integer
    Dim TOTAL_BOMBAS_PRODUTIVIDADE As Integer
    Dim YTD_BOMBAS_PRODUTIVIDADE As Integer

    Dim JAN_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer
    Dim FEV_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer
    Dim MAR_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer
    Dim ABR_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer
    Dim MAI_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer
    Dim JUN_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer
    Dim JUL_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer
    Dim AGO_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer
    Dim SET_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer
    Dim OUT_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer
    Dim NOV_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer
    Dim DEZ_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer
    Dim TRI01_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer
    Dim TRI02_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer
    Dim TRI03_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer
    Dim TRI04_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer
    Dim TOTAL_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer
    Dim YTD_BOMBAS_PRODUTIVIDADE_estabelecimento As Integer

    Dim JAN_BOMBAS_PRODUTIVIDADE_REP As Integer
    Dim FEV_BOMBAS_PRODUTIVIDADE_REP As Integer
    Dim MAR_BOMBAS_PRODUTIVIDADE_REP As Integer
    Dim ABR_BOMBAS_PRODUTIVIDADE_REP As Integer
    Dim MAI_BOMBAS_PRODUTIVIDADE_REP As Integer
    Dim JUN_BOMBAS_PRODUTIVIDADE_REP As Integer
    Dim JUL_BOMBAS_PRODUTIVIDADE_REP As Integer
    Dim AGO_BOMBAS_PRODUTIVIDADE_REP As Integer
    Dim SET_BOMBAS_PRODUTIVIDADE_REP As Integer
    Dim OUT_BOMBAS_PRODUTIVIDADE_REP As Integer
    Dim NOV_BOMBAS_PRODUTIVIDADE_REP As Integer
    Dim DEZ_BOMBAS_PRODUTIVIDADE_REP As Integer
    Dim TRI01_BOMBAS_PRODUTIVIDADE_REP As Integer
    Dim TRI02_BOMBAS_PRODUTIVIDADE_REP As Integer
    Dim TRI03_BOMBAS_PRODUTIVIDADE_REP As Integer
    Dim TRI04_BOMBAS_PRODUTIVIDADE_REP As Integer
    Dim TOTAL_BOMBAS_PRODUTIVIDADE_REP As Integer
    Dim YTD_BOMBAS_PRODUTIVIDADE_REP As Integer

    Dim JAN_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim FEV_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim MAR_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim ABR_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim MAI_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim JUN_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim JUL_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim AGO_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim SET_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim OUT_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim NOV_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim DEZ_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim TRI01_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim TRI02_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim TRI03_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim TRI04_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim TOTAL_BOMBAS_PRODUTIVIDADE_DST As Integer
    Dim YTD_BOMBAS_PRODUTIVIDADE_DST As Integer

    Dim JAN_COTA As Integer
    Dim FEV_COTA As Integer
    Dim MAR_COTA As Integer
    Dim ABR_COTA As Integer
    Dim MAI_COTA As Integer
    Dim JUN_COTA As Integer
    Dim JUL_COTA As Integer
    Dim AGO_COTA As Integer
    Dim SET_COTA As Integer
    Dim OUT_COTA As Integer
    Dim NOV_COTA As Integer
    Dim DEZ_COTA As Integer
    Dim TRI01_COTA As Integer
    Dim TRI02_COTA As Integer
    Dim TRI03_COTA As Integer
    Dim TRI04_COTA As Integer
    Dim TOTAL_COTA As Integer
    Dim YTD_COTA As Integer

    Dim JAN_PERFORMANCE As Double
    Dim FEV_PERFORMANCE As Double
    Dim MAR_PERFORMANCE As Double
    Dim ABR_PERFORMANCE As Double
    Dim MAI_PERFORMANCE As Double
    Dim JUN_PERFORMANCE As Double
    Dim JUL_PERFORMANCE As Double
    Dim AGO_PERFORMANCE As Double
    Dim SET_PERFORMANCE As Double
    Dim OUT_PERFORMANCE As Double
    Dim NOV_PERFORMANCE As Double
    Dim DEZ_PERFORMANCE As Double
    Dim TRI01_PERFORMANCE As Double
    Dim TRI02_PERFORMANCE As Double
    Dim TRI03_PERFORMANCE As Double
    Dim TRI04_PERFORMANCE As Double
    Dim TOTAL_PERFORMANCE As Double
    Dim YTD_PERFORMANCE As Double
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Default.aspx")

        'CONTROLA OS ACESSO E FUNÇÕES CONFORME O PERFIL DE ACESSO
        sql = ""
        sql = "Select * From VIEW_USUARIOS_ATIVOS ORDER BY NOME"

        If Session("COD_PERFIL_LOGIN") = "0" Then sql = "Select * From VIEW_USUARIOS_ATIVOS Where COD_PERFIL = '3' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "1" Then sql = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL_DIRETOR= '" & Session("EMAIL_LOGIN") & "' and COD_PERFIL = '3' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "2" Then sql = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL_GERENTE= '" & Session("EMAIL_LOGIN") & "' and COD_PERFIL = '3' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "3" Then sql = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL = '" & Session("EMAIL_LOGIN") & "' and COD_PERFIL = '3' ORDER BY NOME"
        If Session("COD_PERFIL_LOGIN") = "4" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "5" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "6" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        dts_Gerente_Conta.SelectCommand = sql

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If
    End Sub
    Protected Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        Atualiza_Relatorio()
    End Sub
    Protected Sub cmb_EMAIL_REPRESENTANTE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_EMAIL_GERENTE_CONTA.SelectedIndexChanged
        Response.Redirect("Gerente_Conta_Ficha_Estabelecimento.aspx?LINHA=" & Request.QueryString("LINHA") & "&ANO=" & cmb_Ano.Text & "&GERENTE_CONTA=" & cmb_EMAIL_GERENTE_CONTA.Text)
    End Sub
    Protected Sub cmb_Ano_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Ano.SelectedIndexChanged
        Response.Redirect("Gerente_Conta_Ficha_Estabelecimento.aspx?LINHA=" & Request.QueryString("LINHA") & "&ANO=" & cmb_Ano.Text & "&GERENTE_CONTA=" & cmb_EMAIL_GERENTE_CONTA.Text)
    End Sub
    Protected Sub lnk_Equipos_Edds_Click(sender As Object, e As EventArgs) Handles lnk_Equipos_Edds.Click
        Response.Redirect("Gerente_Conta_Ficha_Estabelecimento.aspx?LINHA=Equipos Edds&ANO=" & cmb_Ano.Text & "&GERENTE_CONTA=" & cmb_EMAIL_GERENTE_CONTA.Text)
    End Sub
    Protected Sub lnk_Equipos_Gemstar_Click(sender As Object, e As EventArgs) Handles lnk_Equipos_Gemstar.Click
        Response.Redirect("Gerente_Conta_Ficha_Estabelecimento.aspx?LINHA=Equipos Gemstar&ANO=" & cmb_Ano.Text & "&GERENTE_CONTA=" & cmb_EMAIL_GERENTE_CONTA.Text)
    End Sub
    Protected Sub lnk_Clave_Click(sender As Object, e As EventArgs) Handles lnk_Clave.Click
        Response.Redirect("Gerente_Conta_Ficha_Estabelecimento.aspx?LINHA=Clave&ANO=" & cmb_Ano.Text & "&GERENTE_CONTA=" & cmb_EMAIL_GERENTE_CONTA.Text)
    End Sub
    Protected Sub lnk_Supercath_Click(sender As Object, e As EventArgs) Handles lnk_Supercath.Click
        Response.Redirect("Gerente_Conta_Ficha_Estabelecimento.aspx?LINHA=Supercath&ANO=" & cmb_Ano.Text & "&GERENTE_CONTA=" & cmb_EMAIL_GERENTE_CONTA.Text)
    End Sub
    Public Sub Atualiza_Relatorio()
        'Recupera valor da query para manter os filtros
        If Request.QueryString("ANO") <> "" Then
            cmb_Ano.Text = Request.QueryString("ANO")
        End If
        cmb_Ano.DataBind()

        If Request.QueryString("Gerente_Conta") <> "" Then
            cmb_EMAIL_GERENTE_CONTA.Text = Request.QueryString("Gerente_Conta")
        End If
        cmb_EMAIL_GERENTE_CONTA.DataBind()
        'ABRE CONEXÃO
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()
        cnn_linha_produto.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn_linha_produto.Open()


        'DEFINE VARIAVEIS
        ANO_ATUAL = 0
        ANO_ATUAL = Val(cmb_Ano.Text)
        If ANO_ATUAL = 0 Then ANO_ATUAL = Year(Now())
        ANO_PASSADO = ANO_ATUAL - 1
        ANO_RETRASADO = ANO_ATUAL - 2
        MES_ATUAL = Month(Now())
        EMAIL = cmb_EMAIL_GERENTE_CONTA.Text

        dts_Linha.DataBind()

        sql_linha_produto = "Select * From TBL_PRODUTOS_LINHAS Where Analisar = 'True' AND LINHA = '" & Request.QueryString("LINHA") & "' Order By ORDEM"

        cmd_linha_produto.Connection = cnn_linha_produto
        cmd_linha_produto.CommandText = sql_linha_produto
        dtr_linha_produto = cmd_linha_produto.ExecuteReader

        If dtr_linha_produto.HasRows Then

            Do While dtr_linha_produto.Read

                'MONTA FICHA DO ESTABELECIMENTO
                COD_GRUPO_BOMBA = 0
                If Not IsDBNull(dtr_linha_produto("COD_GRUPO_BOMBA")) Then COD_GRUPO_BOMBA = dtr_linha_produto("COD_GRUPO_BOMBA")

                'RECUPERA VALORES DO RELATÓRIO
                Linha_Vazia(30, "", True)
                Linha_Titulo(dtr_linha_produto("LINHA"))
                Linha_Cabecalho_Meses("Performance " & ANO_ATUAL)
                Linha_Cota_Atual(dtr_linha_produto("LINHA"), "Cota", True)
                Linha_Demanda_Atual(dtr_linha_produto("LINHA"), "Demanda", True)
                Linha_Performance_Atual(dtr_linha_produto("LINHA"), "Performance (%)", True)

                If COD_GRUPO_BOMBA <> 0 Then
                    'Produtividade de Bombas Representante
                    Linha_Bombas_Representante(dtr_linha_produto("LINHA"), "Bombas Representante - Alocadas " & ANO_ATUAL, True)
                    Linha_Bombas_Produtividade_REP(dtr_linha_produto("LINHA"), "Bombas Representante - Produtividade " & ANO_ATUAL, True)
                    Linha_Bombas(dtr_linha_produto("LINHA"), "Bombas INET - Alocadas " & ANO_ATUAL, True)
                    Linha_Bombas_Produtividade(dtr_linha_produto("LINHA"), "Bombas INET - Produtividade " & ANO_ATUAL, True)
                End If

                Linha_Vazia(30, "", True)
                Linha_Titulo(dtr_linha_produto("LINHA") & " - Estabelecimentos")
                Linha_Vazia(10, "", True)

                cnn_estabelecimento.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
                cnn_estabelecimento.Open()

                sql_estabelecimento = "Select Distinct CNPJ, ESTABELECIMENTO_CNPJ From rpt_Representantes_Ficha_Estabelecimento WHERE COD_GRUPO_BOMBAS = '" & COD_GRUPO_BOMBA & "' AND ANO = '" & ANO_ATUAL & "' and EMAIL_GERENTE_CONTA = '" & cmb_EMAIL_GERENTE_CONTA.Text & "' Order By ESTABELECIMENTO_CNPJ"

                cmd_estabelecimento.Connection = cnn_estabelecimento
                cmd_estabelecimento.CommandText = sql_estabelecimento
                dtr_estabelecimento = cmd_estabelecimento.ExecuteReader

                If dtr_estabelecimento.HasRows Then

                    Do While dtr_estabelecimento.Read

                        Linha_Titulo_Estabelecimento(dtr_estabelecimento("ESTABELECIMENTO_CNPJ"))
                        Linha_Cabecalho_Meses("Demanda " & ANO_ATUAL)
                        Linha_Demanda_Atual_Estabelecimento(dtr_linha_produto("LINHA"), dtr_estabelecimento("CNPJ"), "Realizado", True)

                        If COD_GRUPO_BOMBA <> 0 Then
                            Linha_BOMBAS_estabelecimento(dtr_linha_produto("LINHA"), dtr_estabelecimento("CNPJ"), "Bombas Representante - Alocadas " & ANO_ATUAL, "REP", True)
                            Linha_Bombas_produtividade_estabelecimento(dtr_linha_produto("LINHA"), "Bombas Representante - Produtividade " & ANO_ATUAL, True)
                            Linha_BOMBAS_estabelecimento(dtr_linha_produto("LINHA"), dtr_estabelecimento("CNPJ"), "Bombas INET - Alocadas " & ANO_ATUAL, "INET", True)
                            Linha_Bombas_produtividade_estabelecimento(dtr_linha_produto("LINHA"), "Bombas INET - Produtividade " & ANO_ATUAL, True)
                        End If
                        Linha_Vazia(30, "", True)
                    Loop
                End If
                cnn_estabelecimento.Close()
            Loop
            cnn_linha_produto.Close()
            Linha_Vazia(30, "", True)

        End If
    End Sub

    Private Sub Linha_Titulo(TITULO As String)
        'LINHA DE titulo
        rw = New TableRow
        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.ColumnSpan = 19
        cel.Text = TITULO
        cel.Font.Bold = True
        cel.Font.Size = 14
        cel.HorizontalAlign = HorizontalAlign.Left
        cel.VerticalAlign = VerticalAlign.Middle



    End Sub
    Private Sub Linha_Titulo_Estabelecimento(TITULO As String)
        'LINHA DE titulo
        rw = New TableRow
        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.ColumnSpan = 19
        cel.Text = TITULO
        cel.Font.Bold = True
        cel.Font.Size = 10
        cel.HorizontalAlign = HorizontalAlign.Left
        cel.VerticalAlign = VerticalAlign.Middle



    End Sub
    Private Sub Linha_Cabecalho_Meses(TITULO As String)
        'LINHA DE CABEÇALHO
        rw = New TableRow
        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO
        cel.Font.Size = 10
        cel.Font.Bold = True
        cel.VerticalAlign = VerticalAlign.Middle
        cel.HorizontalAlign = HorizontalAlign.Left
        cel.BorderWidth = 1
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Jan"
        If MES_ATUAL >= 1 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 1 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Fev"
        If MES_ATUAL >= 2 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 2 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Mar"
        If MES_ATUAL >= 3 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 3 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Abr"
        If MES_ATUAL >= 4 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 4 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Mai"
        If MES_ATUAL >= 5 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 5 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Jun"
        If MES_ATUAL >= 6 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 6 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Jul"
        If MES_ATUAL >= 7 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 7 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Ago"
        If MES_ATUAL >= 8 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 8 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Set"
        If MES_ATUAL >= 9 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 9 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Out"
        If MES_ATUAL >= 10 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 10 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Nov"
        If MES_ATUAL >= 11 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 11 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Dez"
        If MES_ATUAL >= 12 Then cel.BackColor = Drawing.Color.Gainsboro
        If MES_ATUAL = 12 Then cel.BackColor = Drawing.Color.FromKnownColor(Drawing.KnownColor.ActiveCaption)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "1º Tri"
        If MES_ATUAL >= 3 Then cel.BackColor = Drawing.Color.Gainsboro
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "2º Tri"
        If MES_ATUAL >= 6 Then cel.BackColor = Drawing.Color.Gainsboro
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "3º Tri"
        If MES_ATUAL >= 9 Then cel.BackColor = Drawing.Color.Gainsboro
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "4º Tri"
        If MES_ATUAL >= 12 Then cel.BackColor = Drawing.Color.Gainsboro
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Ytd"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = "Total"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

    End Sub
    Private Sub Linha_Vazia(Altura As Integer, Titulo As String, Negrito As Boolean)
        'LINHA vazia
        rw = New TableRow
        rw.BackColor = Drawing.Color.Transparent
        rw.Height = Altura
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.ColumnSpan = 19
        cel.Text = Titulo

        cel.Font.Bold = Negrito
        cel.Font.Size = 12
        cel.HorizontalAlign = HorizontalAlign.Left
        cel.VerticalAlign = VerticalAlign.Middle
        cel.BorderStyle = BorderStyle.None
    End Sub
    Private Sub Linha_Demanda_Retrasado(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        'RECUPERA INFORMAÇÕES
        JAN_DEMANDA_RETRASADO = 0
        FEV_DEMANDA_RETRASADO = 0
        MAR_DEMANDA_RETRASADO = 0
        ABR_DEMANDA_RETRASADO = 0
        MAI_DEMANDA_RETRASADO = 0
        JUN_DEMANDA_RETRASADO = 0
        JUL_DEMANDA_RETRASADO = 0
        AGO_DEMANDA_RETRASADO = 0
        SET_DEMANDA_RETRASADO = 0
        OUT_DEMANDA_RETRASADO = 0
        NOV_DEMANDA_RETRASADO = 0
        DEZ_DEMANDA_RETRASADO = 0
        TRI01_DEMANDA_RETRASADO = 0
        TRI02_DEMANDA_RETRASADO = 0
        TRI03_DEMANDA_RETRASADO = 0
        TRI04_DEMANDA_RETRASADO = 0
        TOTAL_DEMANDA_RETRASADO = 0
        YTD_DEMANDA_RETRASADO = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
        sql = sql & "WHERE (ANO = " & ANO_RETRASADO & ") AND (EMAIL_GERENTE_CONTA = '" & EMAIL & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_DEMANDA_RETRASADO = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_DEMANDA_RETRASADO = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_DEMANDA_RETRASADO = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_DEMANDA_RETRASADO = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_DEMANDA_RETRASADO = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_DEMANDA_RETRASADO = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_DEMANDA_RETRASADO = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_DEMANDA_RETRASADO = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_DEMANDA_RETRASADO = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_DEMANDA_RETRASADO = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_DEMANDA_RETRASADO = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_DEMANDA_RETRASADO = dtr("DEZ")
        End If
        dtr.Close()
        TRI01_DEMANDA_RETRASADO = JAN_DEMANDA_RETRASADO + FEV_DEMANDA_RETRASADO + MAR_DEMANDA_RETRASADO
        TRI02_DEMANDA_RETRASADO = ABR_DEMANDA_RETRASADO + MAI_DEMANDA_RETRASADO + JUN_DEMANDA_RETRASADO
        TRI03_DEMANDA_RETRASADO = JUL_DEMANDA_RETRASADO + AGO_DEMANDA_RETRASADO + SET_DEMANDA_RETRASADO
        TRI04_DEMANDA_RETRASADO = OUT_DEMANDA_RETRASADO + NOV_DEMANDA_RETRASADO + DEZ_DEMANDA_RETRASADO
        TOTAL_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + TRI02_DEMANDA_RETRASADO + TRI03_DEMANDA_RETRASADO + TRI04_DEMANDA_RETRASADO

        If MES_ATUAL = 1 Then YTD_DEMANDA_RETRASADO = 0
        If MES_ATUAL = 2 Then YTD_DEMANDA_RETRASADO = JAN_DEMANDA_RETRASADO
        If MES_ATUAL = 3 Then YTD_DEMANDA_RETRASADO = JAN_DEMANDA_RETRASADO + FEV_DEMANDA_RETRASADO
        If MES_ATUAL = 4 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO
        If MES_ATUAL = 5 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + ABR_DEMANDA_RETRASADO
        If MES_ATUAL = 6 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + +ABR_DEMANDA_RETRASADO + MAI_DEMANDA_RETRASADO
        If MES_ATUAL = 7 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + TRI02_DEMANDA_RETRASADO
        If MES_ATUAL = 8 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + TRI02_DEMANDA_RETRASADO + JUL_DEMANDA_RETRASADO
        If MES_ATUAL = 9 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + TRI02_DEMANDA_RETRASADO + JUL_DEMANDA_RETRASADO + AGO_DEMANDA_RETRASADO
        If MES_ATUAL = 10 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + TRI02_DEMANDA_RETRASADO + TRI03_DEMANDA_RETRASADO
        If MES_ATUAL = 11 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + TRI02_DEMANDA_RETRASADO + TRI03_DEMANDA_RETRASADO + OUT_DEMANDA_RETRASADO
        If MES_ATUAL = 12 Then YTD_DEMANDA_RETRASADO = TRI01_DEMANDA_RETRASADO + TRI02_DEMANDA_RETRASADO + TRI03_DEMANDA_RETRASADO + +OUT_DEMANDA_RETRASADO + NOV_DEMANDA_RETRASADO

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        rw.BorderWidth = 1
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_DEMANDA_RETRASADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1


    End Sub
    Private Sub Linha_Bombas_produtividade_estabelecimento(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        If COD_GRUPO_BOMBA = 0 Then Exit Sub
        'RECUPERA INFORMAÇÕES
        JAN_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        FEV_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        MAR_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        ABR_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        MAI_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        JUN_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        JUL_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        AGO_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        SET_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        OUT_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        NOV_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        DEZ_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        TRI01_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        TRI02_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        TRI03_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        TRI04_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        TOTAL_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        YTD_BOMBAS_PRODUTIVIDADE_estabelecimento = 0


        If JAN_BOMBAS_estabelecimento = 0 Then
            JAN_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        Else
            If JAN_DEMANDA_ATUAL_ESTABELECIMENTO = 0 Then
                JAN_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
            Else
                JAN_BOMBAS_PRODUTIVIDADE_estabelecimento = JAN_DEMANDA_ATUAL_ESTABELECIMENTO / JAN_BOMBAS_estabelecimento
            End If
        End If

        If FEV_BOMBAS_estabelecimento = 0 Then
            FEV_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        Else
            If FEV_DEMANDA_ATUAL_ESTABELECIMENTO = 0 Then
                FEV_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
            Else
                FEV_BOMBAS_PRODUTIVIDADE_estabelecimento = FEV_DEMANDA_ATUAL_ESTABELECIMENTO / FEV_BOMBAS_estabelecimento
            End If
        End If

        If MAR_BOMBAS_estabelecimento = 0 Then
            MAR_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        Else
            If MAR_DEMANDA_ATUAL_ESTABELECIMENTO = 0 Then
                MAR_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
            Else
                MAR_BOMBAS_PRODUTIVIDADE_estabelecimento = MAR_DEMANDA_ATUAL_ESTABELECIMENTO / MAR_BOMBAS_estabelecimento
            End If
        End If

        If ABR_BOMBAS_estabelecimento = 0 Then
            ABR_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        Else
            If ABR_DEMANDA_ATUAL_ESTABELECIMENTO = 0 Then
                ABR_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
            Else
                ABR_BOMBAS_PRODUTIVIDADE_estabelecimento = ABR_DEMANDA_ATUAL_ESTABELECIMENTO / ABR_BOMBAS_estabelecimento
            End If
        End If

        If MAI_BOMBAS_estabelecimento = 0 Then
            MAI_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        Else
            If MAI_DEMANDA_ATUAL_ESTABELECIMENTO = 0 Then
                MAI_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
            Else
                MAI_BOMBAS_PRODUTIVIDADE_estabelecimento = MAI_DEMANDA_ATUAL_ESTABELECIMENTO / MAI_BOMBAS_estabelecimento
            End If
        End If

        If JUN_BOMBAS_estabelecimento = 0 Then
            JUN_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        Else
            If JUN_DEMANDA_ATUAL = 0 Then
                JUN_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
            Else
                JUN_BOMBAS_PRODUTIVIDADE_estabelecimento = JUN_DEMANDA_ATUAL_ESTABELECIMENTO / JUN_BOMBAS_estabelecimento
            End If
        End If

        If JUL_BOMBAS_estabelecimento = 0 Then
            JUL_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        Else
            If JUL_DEMANDA_ATUAL_ESTABELECIMENTO = 0 Then
                JUL_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
            Else
                JUL_BOMBAS_PRODUTIVIDADE_estabelecimento = JUL_DEMANDA_ATUAL_ESTABELECIMENTO / JUL_BOMBAS_estabelecimento
            End If
        End If

        If AGO_BOMBAS_estabelecimento = 0 Then
            AGO_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        Else
            If AGO_DEMANDA_ATUAL_ESTABELECIMENTO = 0 Then
                AGO_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
            Else
                AGO_BOMBAS_PRODUTIVIDADE_estabelecimento = AGO_DEMANDA_ATUAL_ESTABELECIMENTO / AGO_BOMBAS_estabelecimento
            End If
        End If

        If SET_BOMBAS_estabelecimento = 0 Then
            SET_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        Else
            If SET_DEMANDA_ATUAL_ESTABELECIMENTO = 0 Then
                SET_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
            Else
                SET_BOMBAS_PRODUTIVIDADE_estabelecimento = SET_DEMANDA_ATUAL_ESTABELECIMENTO / SET_BOMBAS_estabelecimento
            End If
        End If

        If OUT_BOMBAS_estabelecimento = 0 Then
            OUT_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        Else
            If OUT_DEMANDA_ATUAL_ESTABELECIMENTO = 0 Then
                OUT_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
            Else
                OUT_BOMBAS_PRODUTIVIDADE_estabelecimento = OUT_DEMANDA_ATUAL_ESTABELECIMENTO / OUT_BOMBAS_estabelecimento
            End If
        End If

        If NOV_BOMBAS_estabelecimento = 0 Then
            NOV_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        Else
            If NOV_DEMANDA_ATUAL_ESTABELECIMENTO = 0 Then
                NOV_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
            Else
                NOV_BOMBAS_PRODUTIVIDADE_estabelecimento = NOV_DEMANDA_ATUAL_ESTABELECIMENTO / NOV_BOMBAS_estabelecimento
            End If
        End If

        If DEZ_BOMBAS_estabelecimento = 0 Then
            DEZ_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
        Else
            If DEZ_DEMANDA_ATUAL_ESTABELECIMENTO = 0 Then
                DEZ_BOMBAS_PRODUTIVIDADE_estabelecimento = 0
            Else
                DEZ_BOMBAS_PRODUTIVIDADE_estabelecimento = DEZ_DEMANDA_ATUAL_ESTABELECIMENTO / DEZ_BOMBAS_estabelecimento
            End If
        End If

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JAN_BOMBAS_PRODUTIVIDADE_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FEV_BOMBAS_PRODUTIVIDADE_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAR_BOMBAS_PRODUTIVIDADE_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ABR_BOMBAS_PRODUTIVIDADE_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAI_BOMBAS_PRODUTIVIDADE_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUN_BOMBAS_PRODUTIVIDADE_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUL_BOMBAS_PRODUTIVIDADE_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = AGO_BOMBAS_PRODUTIVIDADE_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = SET_BOMBAS_PRODUTIVIDADE_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = OUT_BOMBAS_PRODUTIVIDADE_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = NOV_BOMBAS_PRODUTIVIDADE_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = DEZ_BOMBAS_PRODUTIVIDADE_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

    End Sub
    Private Sub Linha_BOMBAS_estabelecimento(LINHA_PRODUTO As String, CNPJ As String, TITULO_LINHA As String, TIPO_BOMBA As String, Exibir As Boolean)
        If COD_GRUPO_BOMBA = 0 Then Exit Sub
        'RECUPERA INFORMAÇÕES
        JAN_BOMBAS_estabelecimento = 0
        FEV_BOMBAS_estabelecimento = 0
        MAR_BOMBAS_estabelecimento = 0
        ABR_BOMBAS_estabelecimento = 0
        MAI_BOMBAS_estabelecimento = 0
        JUN_BOMBAS_estabelecimento = 0
        JUL_BOMBAS_estabelecimento = 0
        AGO_BOMBAS_estabelecimento = 0
        SET_BOMBAS_estabelecimento = 0
        OUT_BOMBAS_estabelecimento = 0
        NOV_BOMBAS_estabelecimento = 0
        DEZ_BOMBAS_estabelecimento = 0
        TRI01_BOMBAS_estabelecimento = 0
        TRI02_BOMBAS_estabelecimento = 0
        TRI03_BOMBAS_estabelecimento = 0
        TRI04_BOMBAS_estabelecimento = 0
        TOTAL_BOMBAS_estabelecimento = 0
        YTD_BOMBAS_estabelecimento = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        If TIPO_BOMBA = "REP" Then
            sql = sql & "FROM dbo.VIEW_BOMBAS_INVENTARIO_REPRESENTANTE "
            sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (CNPJ = " & CNPJ & ") AND (COD_GRUPO_BOMBA = '" & COD_GRUPO_BOMBA & "') "
        Else
            sql = sql & "FROM dbo.VIEW_BOMBAS_MOVIMENTO_MES_FINAL "
            sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (CNPJ_ESTABELECIMENTO = '" & CNPJ & "') AND (COD_GRUPO_BOMBAS = '" & COD_GRUPO_BOMBA & "') AND (TIPO_MOVIMENTO = 'BOMBAS')"
        End If

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_BOMBAS_estabelecimento = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_BOMBAS_estabelecimento = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_BOMBAS_estabelecimento = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_BOMBAS_estabelecimento = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_BOMBAS_estabelecimento = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_BOMBAS_estabelecimento = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_BOMBAS_estabelecimento = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_BOMBAS_estabelecimento = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_BOMBAS_estabelecimento = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_BOMBAS_estabelecimento = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_BOMBAS_estabelecimento = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_BOMBAS_estabelecimento = dtr("DEZ")
        End If
        dtr.Close()

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JAN_BOMBAS_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FEV_BOMBAS_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAR_BOMBAS_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ABR_BOMBAS_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAI_BOMBAS_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUN_BOMBAS_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUL_BOMBAS_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = AGO_BOMBAS_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = SET_BOMBAS_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = OUT_BOMBAS_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = NOV_BOMBAS_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = DEZ_BOMBAS_estabelecimento
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro


    End Sub
    Private Sub Linha_Demanda_Atual_Estabelecimento(LINHA_PRODUTO As String, CNPJ As String, TITULO_LINHA As String, Exibir As Boolean)
        'RECUPERA INFORMAÇÕES
        JAN_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        FEV_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        MAR_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        ABR_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        MAI_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        JUN_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        JUL_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        AGO_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        SET_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        OUT_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        NOV_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        DEZ_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        TRI01_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        TRI02_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        TRI03_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        TRI04_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        TOTAL_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        YTD_DEMANDA_ATUAL_ESTABELECIMENTO = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
        sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (CNPJ = " & CNPJ & ") AND (LINHA = '" & LINHA_PRODUTO & "')"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_DEMANDA_ATUAL_ESTABELECIMENTO = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_DEMANDA_ATUAL_ESTABELECIMENTO = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_DEMANDA_ATUAL_ESTABELECIMENTO = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_DEMANDA_ATUAL_ESTABELECIMENTO = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_DEMANDA_ATUAL_ESTABELECIMENTO = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_DEMANDA_ATUAL_ESTABELECIMENTO = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_DEMANDA_ATUAL_ESTABELECIMENTO = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_DEMANDA_ATUAL_ESTABELECIMENTO = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_DEMANDA_ATUAL_ESTABELECIMENTO = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_DEMANDA_ATUAL_ESTABELECIMENTO = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_DEMANDA_ATUAL_ESTABELECIMENTO = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_DEMANDA_ATUAL_ESTABELECIMENTO = dtr("DEZ")
        End If
        dtr.Close()
        TRI01_DEMANDA_ATUAL_ESTABELECIMENTO = JAN_DEMANDA_ATUAL_ESTABELECIMENTO + FEV_DEMANDA_ATUAL_ESTABELECIMENTO + MAR_DEMANDA_ATUAL_ESTABELECIMENTO
        TRI02_DEMANDA_ATUAL_ESTABELECIMENTO = ABR_DEMANDA_ATUAL_ESTABELECIMENTO + MAI_DEMANDA_ATUAL_ESTABELECIMENTO + JUN_DEMANDA_ATUAL_ESTABELECIMENTO
        TRI03_DEMANDA_ATUAL_ESTABELECIMENTO = JUL_DEMANDA_ATUAL_ESTABELECIMENTO + AGO_DEMANDA_ATUAL_ESTABELECIMENTO + SET_DEMANDA_ATUAL_ESTABELECIMENTO
        TRI04_DEMANDA_ATUAL_ESTABELECIMENTO = OUT_DEMANDA_ATUAL_ESTABELECIMENTO + NOV_DEMANDA_ATUAL_ESTABELECIMENTO + DEZ_DEMANDA_ATUAL_ESTABELECIMENTO
        TOTAL_DEMANDA_ATUAL_ESTABELECIMENTO = TRI01_DEMANDA_ATUAL_ESTABELECIMENTO + TRI02_DEMANDA_ATUAL_ESTABELECIMENTO + TRI03_DEMANDA_ATUAL_ESTABELECIMENTO + TRI04_DEMANDA_ATUAL_ESTABELECIMENTO

        If MES_ATUAL = 1 Then YTD_DEMANDA_ATUAL_ESTABELECIMENTO = 0
        If MES_ATUAL = 2 Then YTD_DEMANDA_ATUAL_ESTABELECIMENTO = JAN_DEMANDA_ATUAL_ESTABELECIMENTO
        If MES_ATUAL = 3 Then YTD_DEMANDA_ATUAL_ESTABELECIMENTO = JAN_DEMANDA_ATUAL_ESTABELECIMENTO + FEV_DEMANDA_ATUAL_ESTABELECIMENTO
        If MES_ATUAL = 4 Then YTD_DEMANDA_ATUAL_ESTABELECIMENTO = TRI01_DEMANDA_ATUAL_ESTABELECIMENTO
        If MES_ATUAL = 5 Then YTD_DEMANDA_ATUAL_ESTABELECIMENTO = TRI01_DEMANDA_ATUAL_ESTABELECIMENTO + ABR_DEMANDA_ATUAL_ESTABELECIMENTO
        If MES_ATUAL = 6 Then YTD_DEMANDA_ATUAL_ESTABELECIMENTO = TRI01_DEMANDA_ATUAL_ESTABELECIMENTO + +ABR_DEMANDA_ATUAL_ESTABELECIMENTO + MAI_DEMANDA_ATUAL_ESTABELECIMENTO
        If MES_ATUAL = 7 Then YTD_DEMANDA_ATUAL_ESTABELECIMENTO = TRI01_DEMANDA_ATUAL_ESTABELECIMENTO + TRI02_DEMANDA_ATUAL_ESTABELECIMENTO
        If MES_ATUAL = 8 Then YTD_DEMANDA_ATUAL_ESTABELECIMENTO = TRI01_DEMANDA_ATUAL_ESTABELECIMENTO + TRI02_DEMANDA_ATUAL_ESTABELECIMENTO + JUL_DEMANDA_ATUAL_ESTABELECIMENTO
        If MES_ATUAL = 9 Then YTD_DEMANDA_ATUAL_ESTABELECIMENTO = TRI01_DEMANDA_ATUAL_ESTABELECIMENTO + TRI02_DEMANDA_ATUAL_ESTABELECIMENTO + JUL_DEMANDA_ATUAL_ESTABELECIMENTO + AGO_DEMANDA_ATUAL_ESTABELECIMENTO
        If MES_ATUAL = 10 Then YTD_DEMANDA_ATUAL_ESTABELECIMENTO = TRI01_DEMANDA_ATUAL_ESTABELECIMENTO + TRI02_DEMANDA_ATUAL_ESTABELECIMENTO + TRI03_DEMANDA_ATUAL_ESTABELECIMENTO
        If MES_ATUAL = 11 Then YTD_DEMANDA_ATUAL_ESTABELECIMENTO = TRI01_DEMANDA_ATUAL_ESTABELECIMENTO + TRI02_DEMANDA_ATUAL_ESTABELECIMENTO + TRI03_DEMANDA_ATUAL_ESTABELECIMENTO + OUT_DEMANDA_ATUAL_ESTABELECIMENTO
        If MES_ATUAL = 12 Then YTD_DEMANDA_ATUAL_ESTABELECIMENTO = TRI01_DEMANDA_ATUAL_ESTABELECIMENTO + TRI02_DEMANDA_ATUAL_ESTABELECIMENTO + TRI03_DEMANDA_ATUAL_ESTABELECIMENTO + OUT_DEMANDA_ATUAL_ESTABELECIMENTO + NOV_DEMANDA_ATUAL_ESTABELECIMENTO

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow

        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        rw.BorderWidth = 1
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_DEMANDA_ATUAL_ESTABELECIMENTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1


    End Sub
    Private Sub Linha_Demanda_Passado(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        'RECUPERA INFORMAÇÕES
        JAN_DEMANDA_PASSADO = 0
        FEV_DEMANDA_PASSADO = 0
        MAR_DEMANDA_PASSADO = 0
        ABR_DEMANDA_PASSADO = 0
        MAI_DEMANDA_PASSADO = 0
        JUN_DEMANDA_PASSADO = 0
        JUL_DEMANDA_PASSADO = 0
        AGO_DEMANDA_PASSADO = 0
        SET_DEMANDA_PASSADO = 0
        OUT_DEMANDA_PASSADO = 0
        NOV_DEMANDA_PASSADO = 0
        DEZ_DEMANDA_PASSADO = 0
        TRI01_DEMANDA_PASSADO = 0
        TRI02_DEMANDA_PASSADO = 0
        TRI03_DEMANDA_PASSADO = 0
        TRI04_DEMANDA_PASSADO = 0
        TOTAL_DEMANDA_PASSADO = 0
        YTD_DEMANDA_PASSADO = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
        sql = sql & "WHERE (ANO = " & ANO_PASSADO & ") AND (EMAIL_GERENTE_CONTA = '" & EMAIL & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then

            If Not (IsDBNull(dtr("JAN"))) Then JAN_DEMANDA_PASSADO = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_DEMANDA_PASSADO = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_DEMANDA_PASSADO = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_DEMANDA_PASSADO = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_DEMANDA_PASSADO = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_DEMANDA_PASSADO = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_DEMANDA_PASSADO = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_DEMANDA_PASSADO = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_DEMANDA_PASSADO = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_DEMANDA_PASSADO = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_DEMANDA_PASSADO = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_DEMANDA_PASSADO = dtr("DEZ")
        End If
        dtr.Close()
        TRI01_DEMANDA_PASSADO = JAN_DEMANDA_PASSADO + FEV_DEMANDA_PASSADO + MAR_DEMANDA_PASSADO
        TRI02_DEMANDA_PASSADO = ABR_DEMANDA_PASSADO + MAI_DEMANDA_PASSADO + JUN_DEMANDA_PASSADO
        TRI03_DEMANDA_PASSADO = JUL_DEMANDA_PASSADO + AGO_DEMANDA_PASSADO + SET_DEMANDA_PASSADO
        TRI04_DEMANDA_PASSADO = OUT_DEMANDA_PASSADO + NOV_DEMANDA_PASSADO + DEZ_DEMANDA_PASSADO
        TOTAL_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + TRI02_DEMANDA_PASSADO + TRI03_DEMANDA_PASSADO + TRI04_DEMANDA_PASSADO

        If MES_ATUAL = 1 Then YTD_DEMANDA_PASSADO = 0
        If MES_ATUAL = 2 Then YTD_DEMANDA_PASSADO = JAN_DEMANDA_PASSADO
        If MES_ATUAL = 3 Then YTD_DEMANDA_PASSADO = JAN_DEMANDA_PASSADO + FEV_DEMANDA_PASSADO
        If MES_ATUAL = 4 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO
        If MES_ATUAL = 5 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + ABR_DEMANDA_PASSADO
        If MES_ATUAL = 6 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + ABR_DEMANDA_PASSADO + MAI_DEMANDA_PASSADO
        If MES_ATUAL = 7 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + TRI02_DEMANDA_PASSADO
        If MES_ATUAL = 8 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + TRI02_DEMANDA_PASSADO + JUL_DEMANDA_PASSADO
        If MES_ATUAL = 9 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + TRI02_DEMANDA_PASSADO + JUL_DEMANDA_PASSADO + AGO_DEMANDA_PASSADO
        If MES_ATUAL = 10 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + TRI02_DEMANDA_PASSADO + TRI03_DEMANDA_PASSADO
        If MES_ATUAL = 11 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + TRI02_DEMANDA_PASSADO + TRI03_DEMANDA_PASSADO + OUT_DEMANDA_PASSADO
        If MES_ATUAL = 12 Then YTD_DEMANDA_PASSADO = TRI01_DEMANDA_PASSADO + TRI02_DEMANDA_PASSADO + TRI03_DEMANDA_PASSADO + OUT_DEMANDA_PASSADO + NOV_DEMANDA_PASSADO

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow

        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        rw.BorderWidth = 1
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_DEMANDA_PASSADO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1


    End Sub
    Private Sub Linha_Demanda_Atual(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        'RECUPERA INFORMAÇÕES
        JAN_DEMANDA_ATUAL = 0
        FEV_DEMANDA_ATUAL = 0
        MAR_DEMANDA_ATUAL = 0
        ABR_DEMANDA_ATUAL = 0
        MAI_DEMANDA_ATUAL = 0
        JUN_DEMANDA_ATUAL = 0
        JUL_DEMANDA_ATUAL = 0
        AGO_DEMANDA_ATUAL = 0
        SET_DEMANDA_ATUAL = 0
        OUT_DEMANDA_ATUAL = 0
        NOV_DEMANDA_ATUAL = 0
        DEZ_DEMANDA_ATUAL = 0
        TRI01_DEMANDA_ATUAL = 0
        TRI02_DEMANDA_ATUAL = 0
        TRI03_DEMANDA_ATUAL = 0
        TRI04_DEMANDA_ATUAL = 0
        TOTAL_DEMANDA_ATUAL = 0
        YTD_DEMANDA_ATUAL = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_DEMANDA_001_DETALHADO "
        sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_GERENTE_CONTA = '" & EMAIL & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_DEMANDA_ATUAL = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_DEMANDA_ATUAL = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_DEMANDA_ATUAL = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_DEMANDA_ATUAL = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_DEMANDA_ATUAL = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_DEMANDA_ATUAL = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_DEMANDA_ATUAL = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_DEMANDA_ATUAL = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_DEMANDA_ATUAL = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_DEMANDA_ATUAL = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_DEMANDA_ATUAL = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_DEMANDA_ATUAL = dtr("DEZ")
        End If
        dtr.Close()
        TRI01_DEMANDA_ATUAL = JAN_DEMANDA_ATUAL + FEV_DEMANDA_ATUAL + MAR_DEMANDA_ATUAL
        TRI02_DEMANDA_ATUAL = ABR_DEMANDA_ATUAL + MAI_DEMANDA_ATUAL + JUN_DEMANDA_ATUAL
        TRI03_DEMANDA_ATUAL = JUL_DEMANDA_ATUAL + AGO_DEMANDA_ATUAL + SET_DEMANDA_ATUAL
        TRI04_DEMANDA_ATUAL = OUT_DEMANDA_ATUAL + NOV_DEMANDA_ATUAL + DEZ_DEMANDA_ATUAL
        TOTAL_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + TRI02_DEMANDA_ATUAL + TRI03_DEMANDA_ATUAL + TRI04_DEMANDA_ATUAL

        If MES_ATUAL = 1 Then YTD_DEMANDA_ATUAL = 0
        If MES_ATUAL = 2 Then YTD_DEMANDA_ATUAL = JAN_DEMANDA_ATUAL
        If MES_ATUAL = 3 Then YTD_DEMANDA_ATUAL = JAN_DEMANDA_ATUAL + FEV_DEMANDA_ATUAL
        If MES_ATUAL = 4 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL
        If MES_ATUAL = 5 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + ABR_DEMANDA_ATUAL
        If MES_ATUAL = 6 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + +ABR_DEMANDA_ATUAL + MAI_DEMANDA_ATUAL
        If MES_ATUAL = 7 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + TRI02_DEMANDA_ATUAL
        If MES_ATUAL = 8 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + TRI02_DEMANDA_ATUAL + JUL_DEMANDA_ATUAL
        If MES_ATUAL = 9 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + TRI02_DEMANDA_ATUAL + JUL_DEMANDA_ATUAL + AGO_DEMANDA_ATUAL
        If MES_ATUAL = 10 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + TRI02_DEMANDA_ATUAL + TRI03_DEMANDA_ATUAL
        If MES_ATUAL = 11 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + TRI02_DEMANDA_ATUAL + TRI03_DEMANDA_ATUAL + OUT_DEMANDA_ATUAL
        If MES_ATUAL = 12 Then YTD_DEMANDA_ATUAL = TRI01_DEMANDA_ATUAL + TRI02_DEMANDA_ATUAL + TRI03_DEMANDA_ATUAL + OUT_DEMANDA_ATUAL + NOV_DEMANDA_ATUAL

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow

        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        rw.BorderWidth = 1
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_DEMANDA_ATUAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1


    End Sub
    Private Sub Linha_Base_Negocios(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        'RECUPERA INFORMAÇÕES
        JAN_BASE_NEGOCIOS = 0
        FEV_BASE_NEGOCIOS = 0
        MAR_BASE_NEGOCIOS = 0
        ABR_BASE_NEGOCIOS = 0
        MAI_BASE_NEGOCIOS = 0
        JUN_BASE_NEGOCIOS = 0
        JUL_BASE_NEGOCIOS = 0
        AGO_BASE_NEGOCIOS = 0
        SET_BASE_NEGOCIOS = 0
        OUT_BASE_NEGOCIOS = 0
        NOV_BASE_NEGOCIOS = 0
        DEZ_BASE_NEGOCIOS = 0
        TRI01_BASE_NEGOCIOS = 0
        TRI02_BASE_NEGOCIOS = 0
        TRI03_BASE_NEGOCIOS = 0
        TRI04_BASE_NEGOCIOS = 0
        TOTAL_BASE_NEGOCIOS = 0
        YTD_BASE_NEGOCIOS = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_BASE_NEGOCIOS_001_DETALHADO "
        sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_GERENTE_CONTA = '" & EMAIL & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_BASE_NEGOCIOS = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_BASE_NEGOCIOS = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_BASE_NEGOCIOS = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_BASE_NEGOCIOS = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_BASE_NEGOCIOS = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_BASE_NEGOCIOS = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_BASE_NEGOCIOS = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_BASE_NEGOCIOS = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_BASE_NEGOCIOS = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_BASE_NEGOCIOS = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_BASE_NEGOCIOS = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_BASE_NEGOCIOS = dtr("DEZ")
        End If
        dtr.Close()
        TRI01_BASE_NEGOCIOS = JAN_BASE_NEGOCIOS + FEV_BASE_NEGOCIOS + MAR_BASE_NEGOCIOS
        TRI02_BASE_NEGOCIOS = ABR_BASE_NEGOCIOS + MAI_BASE_NEGOCIOS + JUN_BASE_NEGOCIOS
        TRI03_BASE_NEGOCIOS = JUL_BASE_NEGOCIOS + AGO_BASE_NEGOCIOS + SET_BASE_NEGOCIOS
        TRI04_BASE_NEGOCIOS = OUT_BASE_NEGOCIOS + NOV_BASE_NEGOCIOS + DEZ_BASE_NEGOCIOS
        TOTAL_BASE_NEGOCIOS = TRI01_BASE_NEGOCIOS + TRI02_BASE_NEGOCIOS + TRI03_BASE_NEGOCIOS + TRI04_BASE_NEGOCIOS

        If MES_ATUAL = 1 Then YTD_BASE_NEGOCIOS = 0
        If MES_ATUAL = 2 Then YTD_BASE_NEGOCIOS = JAN_BASE_NEGOCIOS
        If MES_ATUAL = 3 Then YTD_BASE_NEGOCIOS = JAN_BASE_NEGOCIOS + FEV_BASE_NEGOCIOS
        If MES_ATUAL = 4 Then YTD_BASE_NEGOCIOS = TRI01_BASE_NEGOCIOS
        If MES_ATUAL = 5 Then YTD_BASE_NEGOCIOS = TRI01_BASE_NEGOCIOS + ABR_BASE_NEGOCIOS
        If MES_ATUAL = 6 Then YTD_BASE_NEGOCIOS = TRI01_BASE_NEGOCIOS + ABR_BASE_NEGOCIOS + MAI_BASE_NEGOCIOS
        If MES_ATUAL = 7 Then YTD_BASE_NEGOCIOS = TRI01_BASE_NEGOCIOS + TRI02_BASE_NEGOCIOS
        If MES_ATUAL = 8 Then YTD_BASE_NEGOCIOS = TRI01_BASE_NEGOCIOS + TRI02_BASE_NEGOCIOS + JUL_BASE_NEGOCIOS
        If MES_ATUAL = 9 Then YTD_BASE_NEGOCIOS = TRI01_BASE_NEGOCIOS + TRI02_BASE_NEGOCIOS + JUL_BASE_NEGOCIOS + AGO_BASE_NEGOCIOS
        If MES_ATUAL = 10 Then YTD_BASE_NEGOCIOS = TRI01_BASE_NEGOCIOS + TRI02_BASE_NEGOCIOS + TRI03_BASE_NEGOCIOS
        If MES_ATUAL = 11 Then YTD_BASE_NEGOCIOS = TRI01_BASE_NEGOCIOS + TRI02_BASE_NEGOCIOS + TRI03_BASE_NEGOCIOS + OUT_BASE_NEGOCIOS
        If MES_ATUAL = 12 Then YTD_BASE_NEGOCIOS = TRI01_BASE_NEGOCIOS + TRI02_BASE_NEGOCIOS + TRI03_BASE_NEGOCIOS + +OUT_BASE_NEGOCIOS + NOV_BASE_NEGOCIOS

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow

        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        rw.BorderWidth = 1
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_BASE_NEGOCIOS, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1


    End Sub
    Private Sub Linha_Oportunidades_025(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        'RECUPERA INFORMAÇÕES
        JAN_OPORTUNIDADES_025 = 0
        FEV_OPORTUNIDADES_025 = 0
        MAR_OPORTUNIDADES_025 = 0
        ABR_OPORTUNIDADES_025 = 0
        MAI_OPORTUNIDADES_025 = 0
        JUN_OPORTUNIDADES_025 = 0
        JUL_OPORTUNIDADES_025 = 0
        AGO_OPORTUNIDADES_025 = 0
        SET_OPORTUNIDADES_025 = 0
        OUT_OPORTUNIDADES_025 = 0
        NOV_OPORTUNIDADES_025 = 0
        DEZ_OPORTUNIDADES_025 = 0
        TRI01_OPORTUNIDADES_025 = 0
        TRI02_OPORTUNIDADES_025 = 0
        TRI03_OPORTUNIDADES_025 = 0
        TRI04_OPORTUNIDADES_025 = 0
        TOTAL_OPORTUNIDADES_025 = 0
        YTD_OPORTUNIDADES_025 = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_OPORTUNIDADES_025 "
        sql = sql & "WHERE (ANO_OPORTUNIDADE = " & ANO_ATUAL & ") AND (EMAIL_GERENTE_CONTA = '" & EMAIL & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_OPORTUNIDADES_025 = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_OPORTUNIDADES_025 = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_OPORTUNIDADES_025 = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_OPORTUNIDADES_025 = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_OPORTUNIDADES_025 = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_OPORTUNIDADES_025 = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_OPORTUNIDADES_025 = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_OPORTUNIDADES_025 = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_OPORTUNIDADES_025 = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_OPORTUNIDADES_025 = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_OPORTUNIDADES_025 = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_OPORTUNIDADES_025 = dtr("DEZ")
        End If
        dtr.Close()
        TRI01_OPORTUNIDADES_025 = JAN_OPORTUNIDADES_025 + FEV_OPORTUNIDADES_025 + MAR_OPORTUNIDADES_025
        TRI02_OPORTUNIDADES_025 = ABR_OPORTUNIDADES_025 + MAI_OPORTUNIDADES_025 + JUN_OPORTUNIDADES_025
        TRI03_OPORTUNIDADES_025 = JUL_OPORTUNIDADES_025 + AGO_OPORTUNIDADES_025 + SET_OPORTUNIDADES_025
        TRI04_OPORTUNIDADES_025 = OUT_OPORTUNIDADES_025 + NOV_OPORTUNIDADES_025 + DEZ_OPORTUNIDADES_025
        TOTAL_OPORTUNIDADES_025 = TRI01_OPORTUNIDADES_025 + TRI02_OPORTUNIDADES_025 + TRI03_OPORTUNIDADES_025 + TRI04_OPORTUNIDADES_025

        If MES_ATUAL = 1 Then YTD_OPORTUNIDADES_025 = 0
        If MES_ATUAL = 2 Then YTD_OPORTUNIDADES_025 = JAN_OPORTUNIDADES_025
        If MES_ATUAL = 3 Then YTD_OPORTUNIDADES_025 = JAN_OPORTUNIDADES_025 + FEV_OPORTUNIDADES_025
        If MES_ATUAL = 4 Then YTD_OPORTUNIDADES_025 = TRI01_OPORTUNIDADES_025
        If MES_ATUAL = 5 Then YTD_OPORTUNIDADES_025 = TRI01_OPORTUNIDADES_025 + ABR_OPORTUNIDADES_025
        If MES_ATUAL = 6 Then YTD_OPORTUNIDADES_025 = TRI01_OPORTUNIDADES_025 + +ABR_OPORTUNIDADES_025 + MAI_OPORTUNIDADES_025
        If MES_ATUAL = 7 Then YTD_OPORTUNIDADES_025 = TRI01_OPORTUNIDADES_025 + TRI02_OPORTUNIDADES_025
        If MES_ATUAL = 8 Then YTD_OPORTUNIDADES_025 = TRI01_OPORTUNIDADES_025 + TRI02_OPORTUNIDADES_025 + JUL_OPORTUNIDADES_025
        If MES_ATUAL = 9 Then YTD_OPORTUNIDADES_025 = TRI01_OPORTUNIDADES_025 + TRI02_OPORTUNIDADES_025 + JUL_OPORTUNIDADES_025 + AGO_OPORTUNIDADES_025
        If MES_ATUAL = 10 Then YTD_OPORTUNIDADES_025 = TRI01_OPORTUNIDADES_025 + TRI02_OPORTUNIDADES_025 + TRI03_OPORTUNIDADES_025
        If MES_ATUAL = 11 Then YTD_OPORTUNIDADES_025 = TRI01_OPORTUNIDADES_025 + TRI02_OPORTUNIDADES_025 + TRI03_OPORTUNIDADES_025 + OUT_OPORTUNIDADES_025
        If MES_ATUAL = 12 Then YTD_OPORTUNIDADES_025 = TRI01_OPORTUNIDADES_025 + TRI02_OPORTUNIDADES_025 + TRI03_OPORTUNIDADES_025 + OUT_OPORTUNIDADES_025 + NOV_OPORTUNIDADES_025

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow

        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        rw.BorderWidth = 1
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_OPORTUNIDADES_025, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1



    End Sub
    Private Sub Linha_Oportunidades_050(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        'RECUPERA INFORMAÇÕES
        JAN_OPORTUNIDADES_050 = 0
        FEV_OPORTUNIDADES_050 = 0
        MAR_OPORTUNIDADES_050 = 0
        ABR_OPORTUNIDADES_050 = 0
        MAI_OPORTUNIDADES_050 = 0
        JUN_OPORTUNIDADES_050 = 0
        JUL_OPORTUNIDADES_050 = 0
        AGO_OPORTUNIDADES_050 = 0
        SET_OPORTUNIDADES_050 = 0
        OUT_OPORTUNIDADES_050 = 0
        NOV_OPORTUNIDADES_050 = 0
        DEZ_OPORTUNIDADES_050 = 0
        TRI01_OPORTUNIDADES_050 = 0
        TRI02_OPORTUNIDADES_050 = 0
        TRI03_OPORTUNIDADES_050 = 0
        TRI04_OPORTUNIDADES_050 = 0
        TOTAL_OPORTUNIDADES_050 = 0
        YTD_OPORTUNIDADES_050 = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_OPORTUNIDADES_050 "
        sql = sql & "WHERE (ANO_OPORTUNIDADE = " & ANO_ATUAL & ") AND (EMAIL_GERENTE_CONTA = '" & EMAIL & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_OPORTUNIDADES_050 = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_OPORTUNIDADES_050 = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_OPORTUNIDADES_050 = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_OPORTUNIDADES_050 = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_OPORTUNIDADES_050 = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_OPORTUNIDADES_050 = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_OPORTUNIDADES_050 = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_OPORTUNIDADES_050 = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_OPORTUNIDADES_050 = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_OPORTUNIDADES_050 = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_OPORTUNIDADES_050 = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_OPORTUNIDADES_050 = dtr("DEZ")
        End If
        dtr.Close()
        TRI01_OPORTUNIDADES_050 = JAN_OPORTUNIDADES_050 + FEV_OPORTUNIDADES_050 + MAR_OPORTUNIDADES_050
        TRI02_OPORTUNIDADES_050 = ABR_OPORTUNIDADES_050 + MAI_OPORTUNIDADES_050 + JUN_OPORTUNIDADES_050
        TRI03_OPORTUNIDADES_050 = JUL_OPORTUNIDADES_050 + AGO_OPORTUNIDADES_050 + SET_OPORTUNIDADES_050
        TRI04_OPORTUNIDADES_050 = OUT_OPORTUNIDADES_050 + NOV_OPORTUNIDADES_050 + DEZ_OPORTUNIDADES_050
        TOTAL_OPORTUNIDADES_050 = TRI01_OPORTUNIDADES_050 + TRI02_OPORTUNIDADES_050 + TRI03_OPORTUNIDADES_050 + TRI04_OPORTUNIDADES_050

        If MES_ATUAL = 1 Then YTD_OPORTUNIDADES_050 = 0
        If MES_ATUAL = 2 Then YTD_OPORTUNIDADES_050 = JAN_OPORTUNIDADES_050
        If MES_ATUAL = 3 Then YTD_OPORTUNIDADES_050 = JAN_OPORTUNIDADES_050 + FEV_OPORTUNIDADES_050
        If MES_ATUAL = 4 Then YTD_OPORTUNIDADES_050 = TRI01_OPORTUNIDADES_050
        If MES_ATUAL = 5 Then YTD_OPORTUNIDADES_050 = TRI01_OPORTUNIDADES_050 + ABR_OPORTUNIDADES_050
        If MES_ATUAL = 6 Then YTD_OPORTUNIDADES_050 = TRI01_OPORTUNIDADES_050 + +ABR_OPORTUNIDADES_050 + MAI_OPORTUNIDADES_050
        If MES_ATUAL = 7 Then YTD_OPORTUNIDADES_050 = TRI01_OPORTUNIDADES_050 + TRI02_OPORTUNIDADES_050
        If MES_ATUAL = 8 Then YTD_OPORTUNIDADES_050 = TRI01_OPORTUNIDADES_050 + TRI02_OPORTUNIDADES_050 + JUL_OPORTUNIDADES_050
        If MES_ATUAL = 9 Then YTD_OPORTUNIDADES_050 = TRI01_OPORTUNIDADES_050 + TRI02_OPORTUNIDADES_050 + JUL_OPORTUNIDADES_050 + AGO_OPORTUNIDADES_050
        If MES_ATUAL = 10 Then YTD_OPORTUNIDADES_050 = TRI01_OPORTUNIDADES_050 + TRI02_OPORTUNIDADES_050 + TRI03_OPORTUNIDADES_050
        If MES_ATUAL = 11 Then YTD_OPORTUNIDADES_050 = TRI01_OPORTUNIDADES_050 + TRI02_OPORTUNIDADES_050 + TRI03_OPORTUNIDADES_050 + OUT_OPORTUNIDADES_050
        If MES_ATUAL = 12 Then YTD_OPORTUNIDADES_050 = TRI01_OPORTUNIDADES_050 + TRI02_OPORTUNIDADES_050 + TRI03_OPORTUNIDADES_050 + OUT_OPORTUNIDADES_050 + NOV_OPORTUNIDADES_050

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow

        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        rw.BorderWidth = 1
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_OPORTUNIDADES_050, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1



    End Sub
    Private Sub Linha_Oportunidades_075(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        'RECUPERA INFORMAÇÕES
        JAN_OPORTUNIDADES_075 = 0
        FEV_OPORTUNIDADES_075 = 0
        MAR_OPORTUNIDADES_075 = 0
        ABR_OPORTUNIDADES_075 = 0
        MAI_OPORTUNIDADES_075 = 0
        JUN_OPORTUNIDADES_075 = 0
        JUL_OPORTUNIDADES_075 = 0
        AGO_OPORTUNIDADES_075 = 0
        SET_OPORTUNIDADES_075 = 0
        OUT_OPORTUNIDADES_075 = 0
        NOV_OPORTUNIDADES_075 = 0
        DEZ_OPORTUNIDADES_075 = 0
        TRI01_OPORTUNIDADES_075 = 0
        TRI02_OPORTUNIDADES_075 = 0
        TRI03_OPORTUNIDADES_075 = 0
        TRI04_OPORTUNIDADES_075 = 0
        TOTAL_OPORTUNIDADES_075 = 0
        YTD_OPORTUNIDADES_075 = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_OPORTUNIDADES_075 "
        sql = sql & "WHERE (ANO_OPORTUNIDADE = " & ANO_ATUAL & ") AND (EMAIL_GERENTE_CONTA = '" & EMAIL & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_OPORTUNIDADES_075 = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_OPORTUNIDADES_075 = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_OPORTUNIDADES_075 = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_OPORTUNIDADES_075 = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_OPORTUNIDADES_075 = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_OPORTUNIDADES_075 = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_OPORTUNIDADES_075 = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_OPORTUNIDADES_075 = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_OPORTUNIDADES_075 = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_OPORTUNIDADES_075 = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_OPORTUNIDADES_075 = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_OPORTUNIDADES_075 = dtr("DEZ")
        End If
        dtr.Close()
        TRI01_OPORTUNIDADES_075 = JAN_OPORTUNIDADES_075 + FEV_OPORTUNIDADES_075 + MAR_OPORTUNIDADES_075
        TRI02_OPORTUNIDADES_075 = ABR_OPORTUNIDADES_075 + MAI_OPORTUNIDADES_075 + JUN_OPORTUNIDADES_075
        TRI03_OPORTUNIDADES_075 = JUL_OPORTUNIDADES_075 + AGO_OPORTUNIDADES_075 + SET_OPORTUNIDADES_075
        TRI04_OPORTUNIDADES_075 = OUT_OPORTUNIDADES_075 + NOV_OPORTUNIDADES_075 + DEZ_OPORTUNIDADES_075
        TOTAL_OPORTUNIDADES_075 = TRI01_OPORTUNIDADES_075 + TRI02_OPORTUNIDADES_075 + TRI03_OPORTUNIDADES_075 + TRI04_OPORTUNIDADES_075

        If MES_ATUAL = 1 Then YTD_OPORTUNIDADES_075 = 0
        If MES_ATUAL = 2 Then YTD_OPORTUNIDADES_075 = JAN_OPORTUNIDADES_075
        If MES_ATUAL = 3 Then YTD_OPORTUNIDADES_075 = JAN_OPORTUNIDADES_075 + FEV_OPORTUNIDADES_075
        If MES_ATUAL = 4 Then YTD_OPORTUNIDADES_075 = TRI01_OPORTUNIDADES_075
        If MES_ATUAL = 5 Then YTD_OPORTUNIDADES_075 = TRI01_OPORTUNIDADES_075 + ABR_OPORTUNIDADES_075
        If MES_ATUAL = 6 Then YTD_OPORTUNIDADES_075 = TRI01_OPORTUNIDADES_075 + +ABR_OPORTUNIDADES_075 + MAI_OPORTUNIDADES_075
        If MES_ATUAL = 7 Then YTD_OPORTUNIDADES_075 = TRI01_OPORTUNIDADES_075 + TRI02_OPORTUNIDADES_075
        If MES_ATUAL = 8 Then YTD_OPORTUNIDADES_075 = TRI01_OPORTUNIDADES_075 + TRI02_OPORTUNIDADES_075 + JUL_OPORTUNIDADES_075
        If MES_ATUAL = 9 Then YTD_OPORTUNIDADES_075 = TRI01_OPORTUNIDADES_075 + TRI02_OPORTUNIDADES_075 + JUL_OPORTUNIDADES_075 + AGO_OPORTUNIDADES_075
        If MES_ATUAL = 10 Then YTD_OPORTUNIDADES_075 = TRI01_OPORTUNIDADES_075 + TRI02_OPORTUNIDADES_075 + TRI03_OPORTUNIDADES_075
        If MES_ATUAL = 11 Then YTD_OPORTUNIDADES_075 = TRI01_OPORTUNIDADES_075 + TRI02_OPORTUNIDADES_075 + TRI03_OPORTUNIDADES_075 + OUT_OPORTUNIDADES_075
        If MES_ATUAL = 12 Then YTD_OPORTUNIDADES_075 = TRI01_OPORTUNIDADES_075 + TRI02_OPORTUNIDADES_075 + TRI03_OPORTUNIDADES_075 + OUT_OPORTUNIDADES_075 + NOV_OPORTUNIDADES_075

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow

        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        rw.BorderWidth = 1
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_OPORTUNIDADES_075, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1



    End Sub
    Private Sub Linha_Oportunidades_100(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        'RECUPERA INFORMAÇÕES
        JAN_OPORTUNIDADES_100 = 0
        FEV_OPORTUNIDADES_100 = 0
        MAR_OPORTUNIDADES_100 = 0
        ABR_OPORTUNIDADES_100 = 0
        MAI_OPORTUNIDADES_100 = 0
        JUN_OPORTUNIDADES_100 = 0
        JUL_OPORTUNIDADES_100 = 0
        AGO_OPORTUNIDADES_100 = 0
        SET_OPORTUNIDADES_100 = 0
        OUT_OPORTUNIDADES_100 = 0
        NOV_OPORTUNIDADES_100 = 0
        DEZ_OPORTUNIDADES_100 = 0
        TRI01_OPORTUNIDADES_100 = 0
        TRI02_OPORTUNIDADES_100 = 0
        TRI03_OPORTUNIDADES_100 = 0
        TRI04_OPORTUNIDADES_100 = 0
        TOTAL_OPORTUNIDADES_100 = 0
        YTD_OPORTUNIDADES_100 = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_OPORTUNIDADES_100 "
        sql = sql & "WHERE (ANO_OPORTUNIDADE = " & ANO_ATUAL & ") AND (EMAIL_GERENTE_CONTA = '" & EMAIL & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_OPORTUNIDADES_100 = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_OPORTUNIDADES_100 = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_OPORTUNIDADES_100 = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_OPORTUNIDADES_100 = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_OPORTUNIDADES_100 = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_OPORTUNIDADES_100 = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_OPORTUNIDADES_100 = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_OPORTUNIDADES_100 = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_OPORTUNIDADES_100 = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_OPORTUNIDADES_100 = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_OPORTUNIDADES_100 = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_OPORTUNIDADES_100 = dtr("DEZ")
        End If
        dtr.Close()
        TRI01_OPORTUNIDADES_100 = JAN_OPORTUNIDADES_100 + FEV_OPORTUNIDADES_100 + MAR_OPORTUNIDADES_100
        TRI02_OPORTUNIDADES_100 = ABR_OPORTUNIDADES_100 + MAI_OPORTUNIDADES_100 + JUN_OPORTUNIDADES_100
        TRI03_OPORTUNIDADES_100 = JUL_OPORTUNIDADES_100 + AGO_OPORTUNIDADES_100 + SET_OPORTUNIDADES_100
        TRI04_OPORTUNIDADES_100 = OUT_OPORTUNIDADES_100 + NOV_OPORTUNIDADES_100 + DEZ_OPORTUNIDADES_100
        TOTAL_OPORTUNIDADES_100 = TRI01_OPORTUNIDADES_100 + TRI02_OPORTUNIDADES_100 + TRI03_OPORTUNIDADES_100 + TRI04_OPORTUNIDADES_100

        If MES_ATUAL = 1 Then YTD_OPORTUNIDADES_100 = 0
        If MES_ATUAL = 2 Then YTD_OPORTUNIDADES_100 = JAN_OPORTUNIDADES_100
        If MES_ATUAL = 3 Then YTD_OPORTUNIDADES_100 = JAN_OPORTUNIDADES_100 + FEV_OPORTUNIDADES_100
        If MES_ATUAL = 4 Then YTD_OPORTUNIDADES_100 = TRI01_OPORTUNIDADES_100
        If MES_ATUAL = 5 Then YTD_OPORTUNIDADES_100 = TRI01_OPORTUNIDADES_100 + ABR_OPORTUNIDADES_100
        If MES_ATUAL = 6 Then YTD_OPORTUNIDADES_100 = TRI01_OPORTUNIDADES_100 + +ABR_OPORTUNIDADES_100 + MAI_OPORTUNIDADES_100
        If MES_ATUAL = 7 Then YTD_OPORTUNIDADES_100 = TRI01_OPORTUNIDADES_100 + TRI02_OPORTUNIDADES_100
        If MES_ATUAL = 8 Then YTD_OPORTUNIDADES_100 = TRI01_OPORTUNIDADES_100 + TRI02_OPORTUNIDADES_100 + JUL_OPORTUNIDADES_100
        If MES_ATUAL = 9 Then YTD_OPORTUNIDADES_100 = TRI01_OPORTUNIDADES_100 + TRI02_OPORTUNIDADES_100 + JUL_OPORTUNIDADES_100 + AGO_OPORTUNIDADES_100
        If MES_ATUAL = 10 Then YTD_OPORTUNIDADES_100 = TRI01_OPORTUNIDADES_100 + TRI02_OPORTUNIDADES_100 + TRI03_OPORTUNIDADES_100
        If MES_ATUAL = 11 Then YTD_OPORTUNIDADES_100 = TRI01_OPORTUNIDADES_100 + TRI02_OPORTUNIDADES_100 + TRI03_OPORTUNIDADES_100 + OUT_OPORTUNIDADES_100
        If MES_ATUAL = 12 Then YTD_OPORTUNIDADES_100 = TRI01_OPORTUNIDADES_100 + TRI02_OPORTUNIDADES_100 + TRI03_OPORTUNIDADES_100 + OUT_OPORTUNIDADES_100 + NOV_OPORTUNIDADES_100

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow

        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        rw.BorderWidth = 1
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_OPORTUNIDADES_100, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1


    End Sub
    Private Sub Linha_Oportunidades_TOTAL(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        'RECUPERA INFORMAÇÕES
        JAN_OPORTUNIDADES_TOTAL = 0
        FEV_OPORTUNIDADES_TOTAL = 0
        MAR_OPORTUNIDADES_TOTAL = 0
        ABR_OPORTUNIDADES_TOTAL = 0
        MAI_OPORTUNIDADES_TOTAL = 0
        JUN_OPORTUNIDADES_TOTAL = 0
        JUL_OPORTUNIDADES_TOTAL = 0
        AGO_OPORTUNIDADES_TOTAL = 0
        SET_OPORTUNIDADES_TOTAL = 0
        OUT_OPORTUNIDADES_TOTAL = 0
        NOV_OPORTUNIDADES_TOTAL = 0
        DEZ_OPORTUNIDADES_TOTAL = 0
        TRI01_OPORTUNIDADES_TOTAL = 0
        TRI02_OPORTUNIDADES_TOTAL = 0
        TRI03_OPORTUNIDADES_TOTAL = 0
        TRI04_OPORTUNIDADES_TOTAL = 0
        TOTAL_OPORTUNIDADES_TOTAL = 0
        YTD_OPORTUNIDADES_TOTAL = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_OPORTUNIDADES_TOTAL "
        sql = sql & "WHERE (ANO_OPORTUNIDADE = " & ANO_ATUAL & ") AND (EMAIL_GERENTE_CONTA = '" & EMAIL & "') AND (LINHA = '" & LINHA_PRODUTO & "')"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_OPORTUNIDADES_TOTAL = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_OPORTUNIDADES_TOTAL = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_OPORTUNIDADES_TOTAL = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_OPORTUNIDADES_TOTAL = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_OPORTUNIDADES_TOTAL = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_OPORTUNIDADES_TOTAL = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_OPORTUNIDADES_TOTAL = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_OPORTUNIDADES_TOTAL = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_OPORTUNIDADES_TOTAL = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_OPORTUNIDADES_TOTAL = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_OPORTUNIDADES_TOTAL = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_OPORTUNIDADES_TOTAL = dtr("DEZ")
        End If
        dtr.Close()
        TRI01_OPORTUNIDADES_TOTAL = JAN_OPORTUNIDADES_TOTAL + FEV_OPORTUNIDADES_TOTAL + MAR_OPORTUNIDADES_TOTAL
        TRI02_OPORTUNIDADES_TOTAL = ABR_OPORTUNIDADES_TOTAL + MAI_OPORTUNIDADES_TOTAL + JUN_OPORTUNIDADES_TOTAL
        TRI03_OPORTUNIDADES_TOTAL = JUL_OPORTUNIDADES_TOTAL + AGO_OPORTUNIDADES_TOTAL + SET_OPORTUNIDADES_TOTAL
        TRI04_OPORTUNIDADES_TOTAL = OUT_OPORTUNIDADES_TOTAL + NOV_OPORTUNIDADES_TOTAL + DEZ_OPORTUNIDADES_TOTAL
        TOTAL_OPORTUNIDADES_TOTAL = TRI01_OPORTUNIDADES_TOTAL + TRI02_OPORTUNIDADES_TOTAL + TRI03_OPORTUNIDADES_TOTAL + TRI04_OPORTUNIDADES_TOTAL

        If MES_ATUAL = 1 Then YTD_OPORTUNIDADES_TOTAL = 0
        If MES_ATUAL = 2 Then YTD_OPORTUNIDADES_TOTAL = JAN_OPORTUNIDADES_TOTAL
        If MES_ATUAL = 3 Then YTD_OPORTUNIDADES_TOTAL = JAN_OPORTUNIDADES_TOTAL + FEV_OPORTUNIDADES_TOTAL
        If MES_ATUAL = 4 Then YTD_OPORTUNIDADES_TOTAL = TRI01_OPORTUNIDADES_TOTAL
        If MES_ATUAL = 5 Then YTD_OPORTUNIDADES_TOTAL = TRI01_OPORTUNIDADES_TOTAL + ABR_OPORTUNIDADES_TOTAL
        If MES_ATUAL = 6 Then YTD_OPORTUNIDADES_TOTAL = TRI01_OPORTUNIDADES_TOTAL + ABR_OPORTUNIDADES_TOTAL + MAI_OPORTUNIDADES_TOTAL
        If MES_ATUAL = 7 Then YTD_OPORTUNIDADES_TOTAL = TRI01_OPORTUNIDADES_TOTAL + TRI02_OPORTUNIDADES_TOTAL
        If MES_ATUAL = 8 Then YTD_OPORTUNIDADES_TOTAL = TRI01_OPORTUNIDADES_TOTAL + TRI02_OPORTUNIDADES_TOTAL + JUL_OPORTUNIDADES_TOTAL
        If MES_ATUAL = 9 Then YTD_OPORTUNIDADES_TOTAL = TRI01_OPORTUNIDADES_TOTAL + TRI02_OPORTUNIDADES_TOTAL + JUL_OPORTUNIDADES_TOTAL + AGO_OPORTUNIDADES_TOTAL
        If MES_ATUAL = 10 Then YTD_OPORTUNIDADES_TOTAL = TRI01_OPORTUNIDADES_TOTAL + TRI02_OPORTUNIDADES_TOTAL + TRI03_OPORTUNIDADES_TOTAL
        If MES_ATUAL = 11 Then YTD_OPORTUNIDADES_TOTAL = TRI01_OPORTUNIDADES_TOTAL + TRI02_OPORTUNIDADES_TOTAL + TRI03_OPORTUNIDADES_TOTAL + OUT_OPORTUNIDADES_TOTAL
        If MES_ATUAL = 12 Then YTD_OPORTUNIDADES_TOTAL = TRI01_OPORTUNIDADES_TOTAL + TRI02_OPORTUNIDADES_TOTAL + TRI03_OPORTUNIDADES_TOTAL + OUT_OPORTUNIDADES_TOTAL + NOV_OPORTUNIDADES_TOTAL

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow

        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Gainsboro
        rw.BorderWidth = 1
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_OPORTUNIDADES_TOTAL, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1


    End Sub
    Private Sub Linha_PREVISTO(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        'RECUPERA INFORMAÇÕES
        JAN_PREVISTO = 0
        FEV_PREVISTO = 0
        MAR_PREVISTO = 0
        ABR_PREVISTO = 0
        MAI_PREVISTO = 0
        JUN_PREVISTO = 0
        JUL_PREVISTO = 0
        AGO_PREVISTO = 0
        SET_PREVISTO = 0
        OUT_PREVISTO = 0
        NOV_PREVISTO = 0
        DEZ_PREVISTO = 0
        TRI01_PREVISTO = 0
        TRI02_PREVISTO = 0
        TRI03_PREVISTO = 0
        TRI04_PREVISTO = 0
        TOTAL_PREVISTO = 0
        YTD_PREVISTO = 0

        If MES_ATUAL > 1 Then
            JAN_PREVISTO = JAN_DEMANDA_ATUAL
        Else
            JAN_PREVISTO = JAN_BASE_NEGOCIOS + JAN_OPORTUNIDADES_TOTAL
        End If

        If MES_ATUAL > 2 Then
            FEV_PREVISTO = FEV_DEMANDA_ATUAL
        Else
            FEV_PREVISTO = FEV_BASE_NEGOCIOS + FEV_OPORTUNIDADES_TOTAL
        End If

        If MES_ATUAL > 3 Then
            MAR_PREVISTO = MAR_DEMANDA_ATUAL
        Else
            MAR_PREVISTO = MAR_BASE_NEGOCIOS + MAR_OPORTUNIDADES_TOTAL
        End If

        If MES_ATUAL > 4 Then
            ABR_PREVISTO = ABR_DEMANDA_ATUAL
        Else
            ABR_PREVISTO = ABR_BASE_NEGOCIOS + ABR_OPORTUNIDADES_TOTAL
        End If

        If MES_ATUAL > 5 Then
            MAI_PREVISTO = MAI_DEMANDA_ATUAL
        Else
            MAI_PREVISTO = MAI_BASE_NEGOCIOS + MAI_OPORTUNIDADES_TOTAL
        End If

        If MES_ATUAL > 6 Then
            JUN_PREVISTO = JUN_DEMANDA_ATUAL
        Else
            JUN_PREVISTO = JUN_BASE_NEGOCIOS + JUN_OPORTUNIDADES_TOTAL
        End If

        If MES_ATUAL > 7 Then
            JUL_PREVISTO = JUL_DEMANDA_ATUAL
        Else
            JUL_PREVISTO = JUL_BASE_NEGOCIOS + JUL_OPORTUNIDADES_TOTAL
        End If

        If MES_ATUAL > 8 Then
            AGO_PREVISTO = AGO_DEMANDA_ATUAL
        Else
            AGO_PREVISTO = AGO_BASE_NEGOCIOS + AGO_OPORTUNIDADES_TOTAL
        End If

        If MES_ATUAL > 9 Then
            SET_PREVISTO = SET_DEMANDA_ATUAL
        Else
            SET_PREVISTO = SET_BASE_NEGOCIOS + SET_OPORTUNIDADES_TOTAL
        End If

        If MES_ATUAL > 10 Then
            OUT_PREVISTO = OUT_DEMANDA_ATUAL
        Else
            OUT_PREVISTO = OUT_BASE_NEGOCIOS + OUT_OPORTUNIDADES_TOTAL
        End If

        If MES_ATUAL > 11 Then
            NOV_PREVISTO = NOV_DEMANDA_ATUAL
        Else
            NOV_PREVISTO = NOV_BASE_NEGOCIOS + NOV_OPORTUNIDADES_TOTAL
        End If

        If MES_ATUAL = 1 Then
            DEZ_PREVISTO = DEZ_DEMANDA_ATUAL
        Else
            DEZ_PREVISTO = DEZ_BASE_NEGOCIOS + DEZ_OPORTUNIDADES_TOTAL
        End If

        TRI01_PREVISTO = JAN_PREVISTO + FEV_PREVISTO + MAR_PREVISTO
        TRI02_PREVISTO = ABR_PREVISTO + MAI_PREVISTO + JUN_PREVISTO
        TRI03_PREVISTO = JUL_PREVISTO + AGO_PREVISTO + SET_PREVISTO
        TRI04_PREVISTO = OUT_PREVISTO + NOV_PREVISTO + DEZ_PREVISTO
        TOTAL_PREVISTO = TRI01_PREVISTO + TRI02_PREVISTO + TRI03_PREVISTO + TRI04_PREVISTO

        If MES_ATUAL = 1 Then YTD_PREVISTO = 0
        If MES_ATUAL = 2 Then YTD_PREVISTO = JAN_PREVISTO
        If MES_ATUAL = 3 Then YTD_PREVISTO = JAN_PREVISTO + FEV_PREVISTO
        If MES_ATUAL = 4 Then YTD_PREVISTO = TRI01_PREVISTO
        If MES_ATUAL = 5 Then YTD_PREVISTO = TRI01_PREVISTO + ABR_PREVISTO
        If MES_ATUAL = 6 Then YTD_PREVISTO = TRI01_PREVISTO + +ABR_PREVISTO + MAI_PREVISTO
        If MES_ATUAL = 7 Then YTD_PREVISTO = TRI01_PREVISTO + TRI02_PREVISTO
        If MES_ATUAL = 8 Then YTD_PREVISTO = TRI01_PREVISTO + TRI02_PREVISTO + JUL_PREVISTO
        If MES_ATUAL = 9 Then YTD_PREVISTO = TRI01_PREVISTO + TRI02_PREVISTO + JUL_PREVISTO + AGO_PREVISTO
        If MES_ATUAL = 10 Then YTD_PREVISTO = TRI01_PREVISTO + TRI02_PREVISTO + TRI03_PREVISTO
        If MES_ATUAL = 11 Then YTD_PREVISTO = TRI01_PREVISTO + TRI02_PREVISTO + TRI03_PREVISTO + OUT_PREVISTO
        If MES_ATUAL = 12 Then YTD_PREVISTO = TRI01_PREVISTO + TRI02_PREVISTO + TRI03_PREVISTO + OUT_PREVISTO + NOV_PREVISTO

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow

        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        rw.BorderWidth = 1
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MES_ATUAL > 1 Then cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MES_ATUAL > 2 Then cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MES_ATUAL > 3 Then cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MES_ATUAL > 4 Then cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MES_ATUAL > 5 Then cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MES_ATUAL > 6 Then cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MES_ATUAL > 7 Then cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MES_ATUAL > 8 Then cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MES_ATUAL > 9 Then cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MES_ATUAL > 10 Then cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MES_ATUAL > 11 Then cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MES_ATUAL > 12 Then cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MES_ATUAL > 3 Then cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MES_ATUAL > 6 Then cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MES_ATUAL > 9 Then cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MES_ATUAL > 12 Then cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_PREVISTO, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1


    End Sub
    Private Sub Linha_CRESCIMENTO_ATUAL_PASSADO(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        'RECUPERA INFORMAÇÕES
        JAN_CRESCIMENTO_ATUAL_PASSADO = 0
        FEV_CRESCIMENTO_ATUAL_PASSADO = 0
        MAR_CRESCIMENTO_ATUAL_PASSADO = 0
        ABR_CRESCIMENTO_ATUAL_PASSADO = 0
        MAI_CRESCIMENTO_ATUAL_PASSADO = 0
        JUN_CRESCIMENTO_ATUAL_PASSADO = 0
        JUL_CRESCIMENTO_ATUAL_PASSADO = 0
        AGO_CRESCIMENTO_ATUAL_PASSADO = 0
        SET_CRESCIMENTO_ATUAL_PASSADO = 0
        OUT_CRESCIMENTO_ATUAL_PASSADO = 0
        NOV_CRESCIMENTO_ATUAL_PASSADO = 0
        DEZ_CRESCIMENTO_ATUAL_PASSADO = 0
        TRI01_CRESCIMENTO_ATUAL_PASSADO = 0
        TRI02_CRESCIMENTO_ATUAL_PASSADO = 0
        TRI03_CRESCIMENTO_ATUAL_PASSADO = 0
        TRI04_CRESCIMENTO_ATUAL_PASSADO = 0
        TOTAL_CRESCIMENTO_ATUAL_PASSADO = 0
        YTD_CRESCIMENTO_ATUAL_PASSADO = 0

        If JAN_DEMANDA_ATUAL = 0 Then
            JAN_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If JAN_DEMANDA_PASSADO = 0 Then
                JAN_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                JAN_CRESCIMENTO_ATUAL_PASSADO = ((JAN_DEMANDA_ATUAL / JAN_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        If FEV_DEMANDA_ATUAL = 0 Then
            FEV_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If FEV_DEMANDA_PASSADO = 0 Then
                FEV_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                FEV_CRESCIMENTO_ATUAL_PASSADO = ((FEV_DEMANDA_ATUAL / FEV_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        If MAR_DEMANDA_ATUAL = 0 Then
            MAR_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If MAR_DEMANDA_PASSADO = 0 Then
                MAR_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                MAR_CRESCIMENTO_ATUAL_PASSADO = ((MAR_DEMANDA_ATUAL / MAR_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        If ABR_DEMANDA_ATUAL = 0 Then
            ABR_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If ABR_DEMANDA_PASSADO = 0 Then
                ABR_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                ABR_CRESCIMENTO_ATUAL_PASSADO = ((ABR_DEMANDA_ATUAL / ABR_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        If MAI_DEMANDA_ATUAL = 0 Then
            MAI_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If MAI_DEMANDA_PASSADO = 0 Then
                MAI_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                MAI_CRESCIMENTO_ATUAL_PASSADO = ((MAI_DEMANDA_ATUAL / MAI_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        If JUN_DEMANDA_ATUAL = 0 Then
            JUN_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If JUN_DEMANDA_PASSADO = 0 Then
                JUN_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                JUN_CRESCIMENTO_ATUAL_PASSADO = ((JUN_DEMANDA_ATUAL / JUN_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        If JUL_DEMANDA_ATUAL = 0 Then
            JUL_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If JUL_DEMANDA_PASSADO = 0 Then
                JUL_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                JUL_CRESCIMENTO_ATUAL_PASSADO = ((JUL_DEMANDA_ATUAL / JUL_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        If AGO_DEMANDA_ATUAL = 0 Then
            AGO_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If AGO_DEMANDA_PASSADO = 0 Then
                AGO_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                AGO_CRESCIMENTO_ATUAL_PASSADO = ((AGO_DEMANDA_ATUAL / AGO_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        If SET_DEMANDA_ATUAL = 0 Then
            SET_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If SET_DEMANDA_PASSADO = 0 Then
                SET_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                SET_CRESCIMENTO_ATUAL_PASSADO = ((SET_DEMANDA_ATUAL / SET_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        If OUT_DEMANDA_ATUAL = 0 Then
            OUT_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If OUT_DEMANDA_PASSADO = 0 Then
                OUT_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                OUT_CRESCIMENTO_ATUAL_PASSADO = ((OUT_DEMANDA_ATUAL / OUT_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        If NOV_DEMANDA_ATUAL = 0 Then
            NOV_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If NOV_DEMANDA_PASSADO = 0 Then
                NOV_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                NOV_CRESCIMENTO_ATUAL_PASSADO = ((NOV_DEMANDA_ATUAL / NOV_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        If DEZ_DEMANDA_ATUAL = 0 Then
            DEZ_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If DEZ_DEMANDA_PASSADO = 0 Then
                DEZ_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                DEZ_CRESCIMENTO_ATUAL_PASSADO = ((DEZ_DEMANDA_ATUAL / DEZ_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        If TRI01_DEMANDA_ATUAL = 0 Then
            TRI01_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If TRI01_DEMANDA_PASSADO = 0 Then
                TRI01_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                TRI01_CRESCIMENTO_ATUAL_PASSADO = ((TRI01_DEMANDA_ATUAL / TRI01_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        If TRI02_DEMANDA_ATUAL = 0 Then
            TRI02_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If TRI02_DEMANDA_PASSADO = 0 Then
                TRI02_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                TRI02_CRESCIMENTO_ATUAL_PASSADO = ((TRI02_DEMANDA_ATUAL / TRI02_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        If TRI03_DEMANDA_ATUAL = 0 Then
            TRI03_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If TRI03_DEMANDA_PASSADO = 0 Then
                TRI03_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                TRI03_CRESCIMENTO_ATUAL_PASSADO = ((TRI03_DEMANDA_ATUAL / TRI03_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        If TRI04_DEMANDA_ATUAL = 0 Then
            TRI04_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If TRI04_DEMANDA_PASSADO = 0 Then
                TRI04_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                TRI04_CRESCIMENTO_ATUAL_PASSADO = ((TRI04_DEMANDA_ATUAL / TRI04_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        If YTD_DEMANDA_ATUAL = 0 Then
            YTD_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If YTD_DEMANDA_PASSADO = 0 Then
                YTD_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                YTD_CRESCIMENTO_ATUAL_PASSADO = ((YTD_DEMANDA_ATUAL / YTD_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        If TOTAL_DEMANDA_ATUAL = 0 Then
            TOTAL_CRESCIMENTO_ATUAL_PASSADO = 0
        Else
            If TOTAL_DEMANDA_PASSADO = 0 Then
                TOTAL_CRESCIMENTO_ATUAL_PASSADO = 100
            Else
                TOTAL_CRESCIMENTO_ATUAL_PASSADO = ((TOTAL_DEMANDA_ATUAL / TOTAL_DEMANDA_PASSADO) - 1) * 100
            End If
        End If

        'MONTA RELATÓRIO

        If Exibir = False Then Exit Sub
        rw = New TableRow

        rw.BorderColor = Drawing.Color.Silver
        rw.BorderWidth = 1
        rw.BackColor = Drawing.Color.Transparent
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1


        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If JAN_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If JAN_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If JAN_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If FEV_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If FEV_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If FEV_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MAR_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If MAR_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If MAR_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If ABR_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If ABR_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If ABR_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MAI_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If MAI_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If MAI_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If JUN_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If JUN_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If JUN_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If JUL_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If JUL_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If JUL_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If AGO_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If AGO_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If AGO_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If SET_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If SET_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If SET_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If OUT_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If OUT_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If OUT_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If NOV_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If NOV_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If NOV_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If DEZ_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If DEZ_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If DEZ_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If TRI01_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If TRI01_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If TRI01_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If TRI02_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If TRI02_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If TRI02_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If TRI03_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If TRI03_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If TRI03_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If TRI04_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If TRI04_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If TRI04_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue


        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If YTD_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If YTD_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If YTD_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_CRESCIMENTO_ATUAL_PASSADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If TOTAL_CRESCIMENTO_ATUAL_PASSADO < 80 Then cel.BackColor = Drawing.Color.White
        If TOTAL_CRESCIMENTO_ATUAL_PASSADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If TOTAL_CRESCIMENTO_ATUAL_PASSADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

    End Sub
    Private Sub Linha_CRESCIMENTO_PASSADO_RETRASADO(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        'RECUPERA INFORMAÇÕES
        JAN_CRESCIMENTO_PASSADO_RETRASADO = 0
        FEV_CRESCIMENTO_PASSADO_RETRASADO = 0
        MAR_CRESCIMENTO_PASSADO_RETRASADO = 0
        ABR_CRESCIMENTO_PASSADO_RETRASADO = 0
        MAI_CRESCIMENTO_PASSADO_RETRASADO = 0
        JUN_CRESCIMENTO_PASSADO_RETRASADO = 0
        JUL_CRESCIMENTO_PASSADO_RETRASADO = 0
        AGO_CRESCIMENTO_PASSADO_RETRASADO = 0
        SET_CRESCIMENTO_PASSADO_RETRASADO = 0
        OUT_CRESCIMENTO_PASSADO_RETRASADO = 0
        NOV_CRESCIMENTO_PASSADO_RETRASADO = 0
        DEZ_CRESCIMENTO_PASSADO_RETRASADO = 0
        TRI01_CRESCIMENTO_PASSADO_RETRASADO = 0
        TRI02_CRESCIMENTO_PASSADO_RETRASADO = 0
        TRI03_CRESCIMENTO_PASSADO_RETRASADO = 0
        TRI04_CRESCIMENTO_PASSADO_RETRASADO = 0
        TOTAL_CRESCIMENTO_PASSADO_RETRASADO = 0
        YTD_CRESCIMENTO_PASSADO_RETRASADO = 0

        If JAN_DEMANDA_PASSADO = 0 Then
            JAN_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If JAN_DEMANDA_RETRASADO = 0 Then
                JAN_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                JAN_CRESCIMENTO_PASSADO_RETRASADO = ((JAN_DEMANDA_PASSADO / JAN_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If

        If FEV_DEMANDA_PASSADO = 0 Then
            FEV_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If FEV_DEMANDA_RETRASADO = 0 Then
                FEV_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                FEV_CRESCIMENTO_PASSADO_RETRASADO = ((FEV_DEMANDA_PASSADO / FEV_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If

        If MAR_DEMANDA_PASSADO = 0 Then
            MAR_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If MAR_DEMANDA_RETRASADO = 0 Then
                MAR_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                MAR_CRESCIMENTO_PASSADO_RETRASADO = ((MAR_DEMANDA_PASSADO / MAR_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If

        If ABR_DEMANDA_PASSADO = 0 Then
            ABR_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If ABR_DEMANDA_RETRASADO = 0 Then
                ABR_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                ABR_CRESCIMENTO_PASSADO_RETRASADO = ((ABR_DEMANDA_PASSADO / ABR_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If

        If MAI_DEMANDA_PASSADO = 0 Then
            MAI_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If MAI_DEMANDA_RETRASADO = 0 Then
                MAI_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                MAI_CRESCIMENTO_PASSADO_RETRASADO = ((MAI_DEMANDA_PASSADO / MAI_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If

        If JUN_DEMANDA_PASSADO = 0 Then
            JUN_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If JUN_DEMANDA_RETRASADO = 0 Then
                JUN_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                JUN_CRESCIMENTO_PASSADO_RETRASADO = ((JUN_DEMANDA_PASSADO / JUN_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If

        If JUL_DEMANDA_PASSADO = 0 Then
            JUL_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If JUL_DEMANDA_RETRASADO = 0 Then
                JUL_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                JUL_CRESCIMENTO_PASSADO_RETRASADO = ((JUL_DEMANDA_PASSADO / JUL_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If

        If AGO_DEMANDA_PASSADO = 0 Then
            AGO_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If AGO_DEMANDA_RETRASADO = 0 Then
                AGO_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                AGO_CRESCIMENTO_PASSADO_RETRASADO = ((AGO_DEMANDA_PASSADO / AGO_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If

        If SET_DEMANDA_PASSADO = 0 Then
            SET_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If SET_DEMANDA_RETRASADO = 0 Then
                SET_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                SET_CRESCIMENTO_PASSADO_RETRASADO = ((SET_DEMANDA_PASSADO / SET_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If

        If OUT_DEMANDA_PASSADO = 0 Then
            OUT_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If OUT_DEMANDA_RETRASADO = 0 Then
                OUT_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                OUT_CRESCIMENTO_PASSADO_RETRASADO = ((OUT_DEMANDA_PASSADO / OUT_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If

        If NOV_DEMANDA_PASSADO = 0 Then
            NOV_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If NOV_DEMANDA_RETRASADO = 0 Then
                NOV_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                NOV_CRESCIMENTO_PASSADO_RETRASADO = ((NOV_DEMANDA_PASSADO / NOV_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If

        If DEZ_DEMANDA_PASSADO = 0 Then
            DEZ_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If DEZ_DEMANDA_RETRASADO = 0 Then
                DEZ_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                DEZ_CRESCIMENTO_PASSADO_RETRASADO = ((DEZ_DEMANDA_PASSADO / DEZ_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If

        If TRI01_DEMANDA_PASSADO = 0 Then
            TRI01_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If TRI01_DEMANDA_RETRASADO = 0 Then
                TRI01_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                TRI01_CRESCIMENTO_PASSADO_RETRASADO = ((TRI01_DEMANDA_PASSADO / TRI01_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If

        If TRI02_DEMANDA_PASSADO = 0 Then
            TRI02_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If TRI02_DEMANDA_RETRASADO = 0 Then
                TRI02_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                TRI02_CRESCIMENTO_PASSADO_RETRASADO = ((TRI02_DEMANDA_PASSADO / TRI02_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If

        If TRI03_DEMANDA_PASSADO = 0 Then
            TRI03_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If TRI03_DEMANDA_RETRASADO = 0 Then
                TRI03_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                TRI03_CRESCIMENTO_PASSADO_RETRASADO = ((TRI03_DEMANDA_PASSADO / TRI03_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If

        If TRI04_DEMANDA_PASSADO = 0 Then
            TRI04_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If TRI04_DEMANDA_RETRASADO = 0 Then
                TRI04_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                TRI04_CRESCIMENTO_PASSADO_RETRASADO = ((TRI04_DEMANDA_PASSADO / TRI04_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If

        If YTD_DEMANDA_PASSADO = 0 Then
            YTD_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If YTD_DEMANDA_RETRASADO = 0 Then
                YTD_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                YTD_CRESCIMENTO_PASSADO_RETRASADO = ((YTD_DEMANDA_PASSADO / YTD_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If

        If TOTAL_DEMANDA_PASSADO = 0 Then
            TOTAL_CRESCIMENTO_PASSADO_RETRASADO = 0
        Else
            If TOTAL_DEMANDA_RETRASADO = 0 Then
                TOTAL_CRESCIMENTO_PASSADO_RETRASADO = 100
            Else
                TOTAL_CRESCIMENTO_PASSADO_RETRASADO = ((TOTAL_DEMANDA_PASSADO / TOTAL_DEMANDA_RETRASADO) - 1) * 100
            End If
        End If


        'MONTA RELATÓRIO

        If Exibir = False Then Exit Sub
        rw = New TableRow

        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        rw.BorderWidth = 1
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1


        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If JAN_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If JAN_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If JAN_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If FEV_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If FEV_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If FEV_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MAR_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If MAR_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If MAR_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If ABR_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If ABR_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If ABR_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If MAI_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If MAI_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If MAI_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If JUN_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If JUN_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If JUN_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If JUL_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If JUL_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If JUL_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If AGO_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If AGO_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If AGO_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If SET_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If SET_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If SET_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If OUT_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If OUT_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If OUT_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If NOV_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If NOV_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If NOV_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If DEZ_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If DEZ_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If DEZ_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If TRI01_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If TRI01_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If TRI01_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If TRI02_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If TRI02_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If TRI02_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If TRI03_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If TRI03_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If TRI03_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If TRI04_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If TRI04_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If TRI04_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue


        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If YTD_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If YTD_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If YTD_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_CRESCIMENTO_PASSADO_RETRASADO, 2) & " %"
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        If TOTAL_CRESCIMENTO_PASSADO_RETRASADO < 80 Then cel.BackColor = Drawing.Color.White
        If TOTAL_CRESCIMENTO_PASSADO_RETRASADO <= 0 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If TOTAL_CRESCIMENTO_PASSADO_RETRASADO > 30 Then cel.BackColor = Drawing.Color.LightSkyBlue

    End Sub
    Private Sub Linha_Bombas(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        If COD_GRUPO_BOMBA = 0 Then Exit Sub
        'RECUPERA INFORMAÇÕES
        JAN_BOMBAS = 0
        FEV_BOMBAS = 0
        MAR_BOMBAS = 0
        ABR_BOMBAS = 0
        MAI_BOMBAS = 0
        JUN_BOMBAS = 0
        JUL_BOMBAS = 0
        AGO_BOMBAS = 0
        SET_BOMBAS = 0
        OUT_BOMBAS = 0
        NOV_BOMBAS = 0
        DEZ_BOMBAS = 0
        TRI01_BOMBAS = 0
        TRI02_BOMBAS = 0
        TRI03_BOMBAS = 0
        TRI04_BOMBAS = 0
        TOTAL_BOMBAS = 0
        YTD_BOMBAS = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_BOMBAS_MOVIMENTO_MES_FINAL "
        sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_GERENTE_CONTA = '" & EMAIL & "') AND (COD_GRUPO_BOMBAS = '" & COD_GRUPO_BOMBA & "') AND (TIPO_MOVIMENTO = 'BOMBAS')"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_BOMBAS = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_BOMBAS = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_BOMBAS = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_BOMBAS = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_BOMBAS = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_BOMBAS = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_BOMBAS = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_BOMBAS = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_BOMBAS = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_BOMBAS = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_BOMBAS = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_BOMBAS = dtr("DEZ")
        End If
        dtr.Close()

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JAN_BOMBAS
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FEV_BOMBAS
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAR_BOMBAS
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ABR_BOMBAS
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAI_BOMBAS
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUN_BOMBAS
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUL_BOMBAS
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = AGO_BOMBAS
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = SET_BOMBAS
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = OUT_BOMBAS
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = NOV_BOMBAS
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = DEZ_BOMBAS
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro


    End Sub
    Private Sub Linha_Bombas_Representante(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        If COD_GRUPO_BOMBA = 0 Then Exit Sub
        'RECUPERA INFORMAÇÕES
        JAN_BOMBAS_REP = 0
        FEV_BOMBAS_REP = 0
        MAR_BOMBAS_REP = 0
        ABR_BOMBAS_REP = 0
        MAI_BOMBAS_REP = 0
        JUN_BOMBAS_REP = 0
        JUL_BOMBAS_REP = 0
        AGO_BOMBAS_REP = 0
        SET_BOMBAS_REP = 0
        OUT_BOMBAS_REP = 0
        NOV_BOMBAS_REP = 0
        DEZ_BOMBAS_REP = 0
        TRI01_BOMBAS_REP = 0
        TRI02_BOMBAS_REP = 0
        TRI03_BOMBAS_REP = 0
        TRI04_BOMBAS_REP = 0
        TOTAL_BOMBAS_REP = 0
        YTD_BOMBAS_REP = 0


        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_BOMBAS_INVENTARIO_REPRESENTANTE "
        sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_GERENTE_CONTA = '" & EMAIL & "') AND (COD_GRUPO_BOMBA = '" & COD_GRUPO_BOMBA & "')"


        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_BOMBAS_REP = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_BOMBAS_REP = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_BOMBAS_REP = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_BOMBAS_REP = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_BOMBAS_REP = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_BOMBAS_REP = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_BOMBAS_REP = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_BOMBAS_REP = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_BOMBAS_REP = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_BOMBAS_REP = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_BOMBAS_REP = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_BOMBAS_REP = dtr("DEZ")
        End If
        dtr.Close()

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JAN_BOMBAS_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FEV_BOMBAS_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAR_BOMBAS_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ABR_BOMBAS_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAI_BOMBAS_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUN_BOMBAS_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUL_BOMBAS_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = AGO_BOMBAS_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = SET_BOMBAS_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = OUT_BOMBAS_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = NOV_BOMBAS_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = DEZ_BOMBAS_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro


    End Sub
    Private Sub Linha_Bombas_Distribuidor(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        If COD_GRUPO_BOMBA = 0 Then Exit Sub
        'RECUPERA INFORMAÇÕES
        JAN_BOMBAS_DST = 0
        FEV_BOMBAS_DST = 0
        MAR_BOMBAS_DST = 0
        ABR_BOMBAS_DST = 0
        MAI_BOMBAS_DST = 0
        JUN_BOMBAS_DST = 0
        JUL_BOMBAS_DST = 0
        AGO_BOMBAS_DST = 0
        SET_BOMBAS_DST = 0
        OUT_BOMBAS_DST = 0
        NOV_BOMBAS_DST = 0
        DEZ_BOMBAS_DST = 0
        TRI01_BOMBAS_DST = 0
        TRI02_BOMBAS_DST = 0
        TRI03_BOMBAS_DST = 0
        TRI04_BOMBAS_DST = 0
        TOTAL_BOMBAS_DST = 0
        YTD_BOMBAS_DST = 0

        'sql = ""
        'sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        'sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        'sql = sql & "FROM dbo.VIEW_BOMBAS_MOVIMENTO_MES_FINAL "
        'sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL_REPRESENTANTE = '" & EMAIL & "') AND (COD_GRUPO_BOMBAS = '" & COD_GRUPO_BOMBA & "') AND (TIPO_MOVIMENTO = 'BOMBAS')"

        'cmd.Connection = cnn
        'cmd.CommandText = sql
        'dtr = cmd.ExecuteReader
        'dtr.Read()
        'If dtr.HasRows Then
        '    If Not (IsDBNull(dtr("JAN"))) Then JAN_BOMBAS_DST = dtr("JAN")
        '    If Not (IsDBNull(dtr("FEV"))) Then FEV_BOMBAS_DST = dtr("FEV")
        '    If Not (IsDBNull(dtr("MAR"))) Then MAR_BOMBAS_DST = dtr("MAR")
        '    If Not (IsDBNull(dtr("ABR"))) Then ABR_BOMBAS_DST = dtr("ABR")
        '    If Not (IsDBNull(dtr("MAI"))) Then MAI_BOMBAS_DST = dtr("MAI")
        '    If Not (IsDBNull(dtr("JUN"))) Then JUN_BOMBAS_DST = dtr("JUN")
        '    If Not (IsDBNull(dtr("JUL"))) Then JUL_BOMBAS_DST = dtr("JUL")
        '    If Not (IsDBNull(dtr("AGO"))) Then AGO_BOMBAS_DST = dtr("AGO")
        '    If Not (IsDBNull(dtr("SET"))) Then SET_BOMBAS_DST = dtr("SET")
        '    If Not (IsDBNull(dtr("OUT"))) Then OUT_BOMBAS_DST = dtr("OUT")
        '    If Not (IsDBNull(dtr("NOV"))) Then NOV_BOMBAS_DST = dtr("NOV")
        '    If Not (IsDBNull(dtr("DEZ"))) Then DEZ_BOMBAS_DST = dtr("DEZ")
        'End If
        'dtr.Close()

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JAN_BOMBAS_DST
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FEV_BOMBAS_DST
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAR_BOMBAS_DST
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ABR_BOMBAS_DST
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAI_BOMBAS_DST
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUN_BOMBAS_DST
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUL_BOMBAS_DST
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = AGO_BOMBAS_DST
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = SET_BOMBAS_DST
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = OUT_BOMBAS_DST
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = NOV_BOMBAS_DST
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = DEZ_BOMBAS_DST
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro


    End Sub
    Private Sub Linha_Bombas_Produtividade(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        If COD_GRUPO_BOMBA = 0 Then Exit Sub
        'RECUPERA INFORMAÇÕES
        JAN_BOMBAS_PRODUTIVIDADE = 0
        FEV_BOMBAS_PRODUTIVIDADE = 0
        MAR_BOMBAS_PRODUTIVIDADE = 0
        ABR_BOMBAS_PRODUTIVIDADE = 0
        MAI_BOMBAS_PRODUTIVIDADE = 0
        JUN_BOMBAS_PRODUTIVIDADE = 0
        JUL_BOMBAS_PRODUTIVIDADE = 0
        AGO_BOMBAS_PRODUTIVIDADE = 0
        SET_BOMBAS_PRODUTIVIDADE = 0
        OUT_BOMBAS_PRODUTIVIDADE = 0
        NOV_BOMBAS_PRODUTIVIDADE = 0
        DEZ_BOMBAS_PRODUTIVIDADE = 0
        TRI01_BOMBAS_PRODUTIVIDADE = 0
        TRI02_BOMBAS_PRODUTIVIDADE = 0
        TRI03_BOMBAS_PRODUTIVIDADE = 0
        TRI04_BOMBAS_PRODUTIVIDADE = 0
        TOTAL_BOMBAS_PRODUTIVIDADE = 0
        YTD_BOMBAS_PRODUTIVIDADE = 0


        If JAN_BOMBAS = 0 Then
            JAN_BOMBAS_PRODUTIVIDADE = 0
        Else
            If JAN_DEMANDA_ATUAL = 0 Then
                JAN_BOMBAS_PRODUTIVIDADE = 0
            Else
                JAN_BOMBAS_PRODUTIVIDADE = JAN_DEMANDA_ATUAL / JAN_BOMBAS
            End If
        End If

        If FEV_BOMBAS = 0 Then
            FEV_BOMBAS_PRODUTIVIDADE = 0
        Else
            If FEV_DEMANDA_ATUAL = 0 Then
                FEV_BOMBAS_PRODUTIVIDADE = 0
            Else
                FEV_BOMBAS_PRODUTIVIDADE = FEV_DEMANDA_ATUAL / FEV_BOMBAS
            End If
        End If

        If MAR_BOMBAS = 0 Then
            MAR_BOMBAS_PRODUTIVIDADE = 0
        Else
            If MAR_DEMANDA_ATUAL = 0 Then
                MAR_BOMBAS_PRODUTIVIDADE = 0
            Else
                MAR_BOMBAS_PRODUTIVIDADE = MAR_DEMANDA_ATUAL / MAR_BOMBAS
            End If
        End If

        If ABR_BOMBAS = 0 Then
            ABR_BOMBAS_PRODUTIVIDADE = 0
        Else
            If ABR_DEMANDA_ATUAL = 0 Then
                ABR_BOMBAS_PRODUTIVIDADE = 0
            Else
                ABR_BOMBAS_PRODUTIVIDADE = ABR_DEMANDA_ATUAL / ABR_BOMBAS
            End If
        End If

        If MAI_BOMBAS = 0 Then
            MAI_BOMBAS_PRODUTIVIDADE = 0
        Else
            If MAI_DEMANDA_ATUAL = 0 Then
                MAI_BOMBAS_PRODUTIVIDADE = 0
            Else
                MAI_BOMBAS_PRODUTIVIDADE = MAI_DEMANDA_ATUAL / MAI_BOMBAS
            End If
        End If

        If JUN_BOMBAS = 0 Then
            JUN_BOMBAS_PRODUTIVIDADE = 0
        Else
            If JUN_DEMANDA_ATUAL = 0 Then
                JUN_BOMBAS_PRODUTIVIDADE = 0
            Else
                JUN_BOMBAS_PRODUTIVIDADE = JUN_DEMANDA_ATUAL / JUN_BOMBAS
            End If
        End If

        If JUL_BOMBAS = 0 Then
            JUL_BOMBAS_PRODUTIVIDADE = 0
        Else
            If JUL_DEMANDA_ATUAL = 0 Then
                JUL_BOMBAS_PRODUTIVIDADE = 0
            Else
                JUL_BOMBAS_PRODUTIVIDADE = JUL_DEMANDA_ATUAL / JUL_BOMBAS
            End If
        End If

        If AGO_BOMBAS = 0 Then
            AGO_BOMBAS_PRODUTIVIDADE = 0
        Else
            If AGO_DEMANDA_ATUAL = 0 Then
                AGO_BOMBAS_PRODUTIVIDADE = 0
            Else
                AGO_BOMBAS_PRODUTIVIDADE = AGO_DEMANDA_ATUAL / AGO_BOMBAS
            End If
        End If

        If SET_BOMBAS = 0 Then
            SET_BOMBAS_PRODUTIVIDADE = 0
        Else
            If SET_DEMANDA_ATUAL = 0 Then
                SET_BOMBAS_PRODUTIVIDADE = 0
            Else
                SET_BOMBAS_PRODUTIVIDADE = SET_DEMANDA_ATUAL / SET_BOMBAS
            End If
        End If

        If OUT_BOMBAS = 0 Then
            OUT_BOMBAS_PRODUTIVIDADE = 0
        Else
            If OUT_DEMANDA_ATUAL = 0 Then
                OUT_BOMBAS_PRODUTIVIDADE = 0
            Else
                OUT_BOMBAS_PRODUTIVIDADE = OUT_DEMANDA_ATUAL / OUT_BOMBAS
            End If
        End If

        If NOV_BOMBAS = 0 Then
            NOV_BOMBAS_PRODUTIVIDADE = 0
        Else
            If NOV_DEMANDA_ATUAL = 0 Then
                NOV_BOMBAS_PRODUTIVIDADE = 0
            Else
                NOV_BOMBAS_PRODUTIVIDADE = NOV_DEMANDA_ATUAL / NOV_BOMBAS
            End If
        End If

        If DEZ_BOMBAS = 0 Then
            DEZ_BOMBAS_PRODUTIVIDADE = 0
        Else
            If DEZ_DEMANDA_ATUAL = 0 Then
                DEZ_BOMBAS_PRODUTIVIDADE = 0
            Else
                DEZ_BOMBAS_PRODUTIVIDADE = DEZ_DEMANDA_ATUAL / DEZ_BOMBAS
            End If
        End If

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JAN_BOMBAS_PRODUTIVIDADE
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FEV_BOMBAS_PRODUTIVIDADE
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAR_BOMBAS_PRODUTIVIDADE
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ABR_BOMBAS_PRODUTIVIDADE
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAI_BOMBAS_PRODUTIVIDADE
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUN_BOMBAS_PRODUTIVIDADE
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUL_BOMBAS_PRODUTIVIDADE
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = AGO_BOMBAS_PRODUTIVIDADE
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = SET_BOMBAS_PRODUTIVIDADE
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = OUT_BOMBAS_PRODUTIVIDADE
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = NOV_BOMBAS_PRODUTIVIDADE
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = DEZ_BOMBAS_PRODUTIVIDADE
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

    End Sub
    Private Sub Linha_Bombas_Produtividade_REP(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        If COD_GRUPO_BOMBA = 0 Then Exit Sub
        'RECUPERA INFORMAÇÕES
        JAN_BOMBAS_PRODUTIVIDADE_REP = 0
        FEV_BOMBAS_PRODUTIVIDADE_REP = 0
        MAR_BOMBAS_PRODUTIVIDADE_REP = 0
        ABR_BOMBAS_PRODUTIVIDADE_REP = 0
        MAI_BOMBAS_PRODUTIVIDADE_REP = 0
        JUN_BOMBAS_PRODUTIVIDADE_REP = 0
        JUL_BOMBAS_PRODUTIVIDADE_REP = 0
        AGO_BOMBAS_PRODUTIVIDADE_REP = 0
        SET_BOMBAS_PRODUTIVIDADE_REP = 0
        OUT_BOMBAS_PRODUTIVIDADE_REP = 0
        NOV_BOMBAS_PRODUTIVIDADE_REP = 0
        DEZ_BOMBAS_PRODUTIVIDADE_REP = 0
        TRI01_BOMBAS_PRODUTIVIDADE_REP = 0
        TRI02_BOMBAS_PRODUTIVIDADE_REP = 0
        TRI03_BOMBAS_PRODUTIVIDADE_REP = 0
        TRI04_BOMBAS_PRODUTIVIDADE_REP = 0
        TOTAL_BOMBAS_PRODUTIVIDADE_REP = 0
        YTD_BOMBAS_PRODUTIVIDADE_REP = 0

        If JAN_BOMBAS_REP = 0 Then
            JAN_BOMBAS_PRODUTIVIDADE_REP = 0
        Else
            If JAN_DEMANDA_ATUAL = 0 Then
                JAN_BOMBAS_PRODUTIVIDADE_REP = 0
            Else
                JAN_BOMBAS_PRODUTIVIDADE_REP = JAN_DEMANDA_ATUAL / JAN_BOMBAS_REP
            End If
        End If

        If FEV_BOMBAS_REP = 0 Then
            FEV_BOMBAS_PRODUTIVIDADE_REP = 0
        Else
            If FEV_DEMANDA_ATUAL = 0 Then
                FEV_BOMBAS_PRODUTIVIDADE_REP = 0
            Else
                FEV_BOMBAS_PRODUTIVIDADE_REP = FEV_DEMANDA_ATUAL / FEV_BOMBAS_REP
            End If
        End If

        If MAR_BOMBAS_REP = 0 Then
            MAR_BOMBAS_PRODUTIVIDADE_REP = 0
        Else
            If MAR_DEMANDA_ATUAL = 0 Then
                MAR_BOMBAS_PRODUTIVIDADE_REP = 0
            Else
                MAR_BOMBAS_PRODUTIVIDADE_REP = MAR_DEMANDA_ATUAL / MAR_BOMBAS_REP
            End If
        End If

        If ABR_BOMBAS_REP = 0 Then
            ABR_BOMBAS_PRODUTIVIDADE_REP = 0
        Else
            If ABR_DEMANDA_ATUAL = 0 Then
                ABR_BOMBAS_PRODUTIVIDADE_REP = 0
            Else
                ABR_BOMBAS_PRODUTIVIDADE_REP = ABR_DEMANDA_ATUAL / ABR_BOMBAS_REP
            End If
        End If

        If MAI_BOMBAS_REP = 0 Then
            MAI_BOMBAS_PRODUTIVIDADE_REP = 0
        Else
            If MAI_DEMANDA_ATUAL = 0 Then
                MAI_BOMBAS_PRODUTIVIDADE_REP = 0
            Else
                MAI_BOMBAS_PRODUTIVIDADE_REP = MAI_DEMANDA_ATUAL / MAI_BOMBAS_REP
            End If
        End If

        If JUN_BOMBAS_REP = 0 Then
            JUN_BOMBAS_PRODUTIVIDADE_REP = 0
        Else
            If JUN_DEMANDA_ATUAL = 0 Then
                JUN_BOMBAS_PRODUTIVIDADE_REP = 0
            Else
                JUN_BOMBAS_PRODUTIVIDADE_REP = JUN_DEMANDA_ATUAL / JUN_BOMBAS_REP
            End If
        End If

        If JUL_BOMBAS_REP = 0 Then
            JUL_BOMBAS_PRODUTIVIDADE_REP = 0
        Else
            If JUL_DEMANDA_ATUAL = 0 Then
                JUL_BOMBAS_PRODUTIVIDADE_REP = 0
            Else
                JUL_BOMBAS_PRODUTIVIDADE_REP = JUL_DEMANDA_ATUAL / JUL_BOMBAS_REP
            End If
        End If

        If AGO_BOMBAS_REP = 0 Then
            AGO_BOMBAS_PRODUTIVIDADE_REP = 0
        Else
            If AGO_DEMANDA_ATUAL = 0 Then
                AGO_BOMBAS_PRODUTIVIDADE_REP = 0
            Else
                AGO_BOMBAS_PRODUTIVIDADE_REP = AGO_DEMANDA_ATUAL / AGO_BOMBAS_REP
            End If
        End If

        If SET_BOMBAS_REP = 0 Then
            SET_BOMBAS_PRODUTIVIDADE_REP = 0
        Else
            If SET_DEMANDA_ATUAL = 0 Then
                SET_BOMBAS_PRODUTIVIDADE_REP = 0
            Else
                SET_BOMBAS_PRODUTIVIDADE_REP = SET_DEMANDA_ATUAL / SET_BOMBAS_REP
            End If
        End If

        If OUT_BOMBAS_REP = 0 Then
            OUT_BOMBAS_PRODUTIVIDADE_REP = 0
        Else
            If OUT_DEMANDA_ATUAL = 0 Then
                OUT_BOMBAS_PRODUTIVIDADE_REP = 0
            Else
                OUT_BOMBAS_PRODUTIVIDADE_REP = OUT_DEMANDA_ATUAL / OUT_BOMBAS_REP
            End If
        End If

        If NOV_BOMBAS_REP = 0 Then
            NOV_BOMBAS_PRODUTIVIDADE_REP = 0
        Else
            If NOV_DEMANDA_ATUAL = 0 Then
                NOV_BOMBAS_PRODUTIVIDADE_REP = 0
            Else
                NOV_BOMBAS_PRODUTIVIDADE_REP = NOV_DEMANDA_ATUAL / NOV_BOMBAS_REP
            End If
        End If

        If DEZ_BOMBAS_REP = 0 Then
            DEZ_BOMBAS_PRODUTIVIDADE_REP = 0
        Else
            If DEZ_DEMANDA_ATUAL = 0 Then
                DEZ_BOMBAS_PRODUTIVIDADE_REP = 0
            Else
                DEZ_BOMBAS_PRODUTIVIDADE_REP = DEZ_DEMANDA_ATUAL / DEZ_BOMBAS_REP
            End If
        End If

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JAN_BOMBAS_PRODUTIVIDADE_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FEV_BOMBAS_PRODUTIVIDADE_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAR_BOMBAS_PRODUTIVIDADE_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ABR_BOMBAS_PRODUTIVIDADE_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = MAI_BOMBAS_PRODUTIVIDADE_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUN_BOMBAS_PRODUTIVIDADE_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = JUL_BOMBAS_PRODUTIVIDADE_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = AGO_BOMBAS_PRODUTIVIDADE_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = SET_BOMBAS_PRODUTIVIDADE_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = OUT_BOMBAS_PRODUTIVIDADE_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = NOV_BOMBAS_PRODUTIVIDADE_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = DEZ_BOMBAS_PRODUTIVIDADE_REP
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = ""
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1
        cel.BackColor = Drawing.Color.Gainsboro

    End Sub
    Private Sub Linha_Cota_Atual(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        'RECUPERA INFORMAÇÕES
        JAN_COTA = 0
        FEV_COTA = 0
        MAR_COTA = 0
        ABR_COTA = 0
        MAI_COTA = 0
        JUN_COTA = 0
        JUL_COTA = 0
        AGO_COTA = 0
        SET_COTA = 0
        OUT_COTA = 0
        NOV_COTA = 0
        DEZ_COTA = 0
        TRI01_COTA = 0
        TRI02_COTA = 0
        TRI03_COTA = 0
        TRI04_COTA = 0
        TOTAL_COTA = 0
        YTD_COTA = 0

        sql = ""
        sql = sql & "SELECT SUM(JAN) AS JAN, SUM(FEV) AS FEV, SUM(MAR) AS MAR, SUM(ABR) AS ABR, SUM(MAI) AS MAI, SUM(JUN) AS JUN, SUM(JUL) AS JUL, "
        sql = sql & "SUM(AGO) AS AGO, SUM([SET]) AS [SET], SUM(OUT) AS OUT, SUM(NOV) AS NOV, SUM(DEZ) AS DEZ "
        sql = sql & "FROM dbo.VIEW_COTAS "
        sql = sql & "WHERE (ANO = " & ANO_ATUAL & ") AND (EMAIL = '" & EMAIL & "') AND (LINHA_PRODUTO = '" & LINHA_PRODUTO & "')"

        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        dtr.Read()
        If dtr.HasRows Then
            If Not (IsDBNull(dtr("JAN"))) Then JAN_COTA = dtr("JAN")
            If Not (IsDBNull(dtr("FEV"))) Then FEV_COTA = dtr("FEV")
            If Not (IsDBNull(dtr("MAR"))) Then MAR_COTA = dtr("MAR")
            If Not (IsDBNull(dtr("ABR"))) Then ABR_COTA = dtr("ABR")
            If Not (IsDBNull(dtr("MAI"))) Then MAI_COTA = dtr("MAI")
            If Not (IsDBNull(dtr("JUN"))) Then JUN_COTA = dtr("JUN")
            If Not (IsDBNull(dtr("JUL"))) Then JUL_COTA = dtr("JUL")
            If Not (IsDBNull(dtr("AGO"))) Then AGO_COTA = dtr("AGO")
            If Not (IsDBNull(dtr("SET"))) Then SET_COTA = dtr("SET")
            If Not (IsDBNull(dtr("OUT"))) Then OUT_COTA = dtr("OUT")
            If Not (IsDBNull(dtr("NOV"))) Then NOV_COTA = dtr("NOV")
            If Not (IsDBNull(dtr("DEZ"))) Then DEZ_COTA = dtr("DEZ")
        End If
        dtr.Close()
        TRI01_COTA = JAN_COTA + FEV_COTA + MAR_COTA
        TRI02_COTA = ABR_COTA + MAI_COTA + JUN_COTA
        TRI03_COTA = JUL_COTA + AGO_COTA + SET_COTA
        TRI04_COTA = OUT_COTA + NOV_COTA + DEZ_COTA
        TOTAL_COTA = TRI01_COTA + TRI02_COTA + TRI03_COTA + TRI04_COTA

        If MES_ATUAL = 1 Then YTD_COTA = 0
        If MES_ATUAL = 2 Then YTD_COTA = JAN_COTA
        If MES_ATUAL = 3 Then YTD_COTA = JAN_COTA + FEV_COTA
        If MES_ATUAL = 4 Then YTD_COTA = TRI01_COTA
        If MES_ATUAL = 5 Then YTD_COTA = TRI01_COTA + ABR_COTA
        If MES_ATUAL = 6 Then YTD_COTA = TRI01_COTA + JAN_COTA + FEV_COTA
        If MES_ATUAL = 7 Then YTD_COTA = TRI01_COTA + TRI02_COTA
        If MES_ATUAL = 8 Then YTD_COTA = TRI01_COTA + TRI02_COTA + JUL_COTA
        If MES_ATUAL = 9 Then YTD_COTA = TRI01_COTA + TRI02_COTA + JUL_COTA + AGO_COTA
        If MES_ATUAL = 10 Then YTD_COTA = TRI01_COTA + TRI02_COTA + TRI03_COTA
        If MES_ATUAL = 11 Then YTD_COTA = TRI01_COTA + TRI02_COTA + TRI03_COTA + OUT_COTA
        If MES_ATUAL = 12 Then YTD_COTA = TRI01_COTA + TRI02_COTA + TRI03_COTA + OUT_COTA + NOV_COTA

        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow
        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        rw.BorderWidth = 1
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_COTA, 0)
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1


    End Sub
    Private Sub Linha_Performance_Atual(LINHA_PRODUTO As String, TITULO_LINHA As String, Exibir As Boolean)
        JAN_PERFORMANCE = 0
        FEV_PERFORMANCE = 0
        MAR_PERFORMANCE = 0
        ABR_PERFORMANCE = 0
        MAI_PERFORMANCE = 0
        JUN_PERFORMANCE = 0
        JUL_PERFORMANCE = 0
        AGO_PERFORMANCE = 0
        SET_PERFORMANCE = 0
        OUT_PERFORMANCE = 0
        NOV_PERFORMANCE = 0
        DEZ_PERFORMANCE = 0
        TRI01_PERFORMANCE = 0
        TRI02_PERFORMANCE = 0
        TRI03_PERFORMANCE = 0
        TRI04_PERFORMANCE = 0
        TOTAL_PERFORMANCE = 0
        YTD_PERFORMANCE = 0

        If JAN_COTA <> 0 Then JAN_PERFORMANCE = Round((JAN_DEMANDA_ATUAL / JAN_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If FEV_COTA <> 0 Then FEV_PERFORMANCE = Round((FEV_DEMANDA_ATUAL / FEV_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If MAR_COTA <> 0 Then MAR_PERFORMANCE = Round((MAR_DEMANDA_ATUAL / MAR_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If ABR_COTA <> 0 Then ABR_PERFORMANCE = Round((ABR_DEMANDA_ATUAL / ABR_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If MAI_COTA <> 0 Then MAI_PERFORMANCE = Round((MAI_DEMANDA_ATUAL / MAI_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If JUN_COTA <> 0 Then JUN_PERFORMANCE = Round((JUN_DEMANDA_ATUAL / JUN_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If JUL_COTA <> 0 Then JUL_PERFORMANCE = Round((JUL_DEMANDA_ATUAL / JUL_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If AGO_COTA <> 0 Then AGO_PERFORMANCE = Round((AGO_DEMANDA_ATUAL / AGO_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If SET_COTA <> 0 Then SET_PERFORMANCE = Round((SET_DEMANDA_ATUAL / SET_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If OUT_COTA <> 0 Then OUT_PERFORMANCE = Round((OUT_DEMANDA_ATUAL / OUT_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If NOV_COTA <> 0 Then NOV_PERFORMANCE = Round((NOV_DEMANDA_ATUAL / NOV_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If DEZ_COTA <> 0 Then DEZ_PERFORMANCE = Round((DEZ_DEMANDA_ATUAL / DEZ_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If TRI01_COTA <> 0 Then TRI01_PERFORMANCE = Round((TRI01_DEMANDA_ATUAL / TRI01_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If TRI02_COTA <> 0 Then TRI02_PERFORMANCE = Round((TRI02_DEMANDA_ATUAL / TRI02_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If TRI03_COTA <> 0 Then TRI03_PERFORMANCE = Round((TRI03_DEMANDA_ATUAL / TRI03_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If TRI04_COTA <> 0 Then TRI04_PERFORMANCE = Round((TRI04_DEMANDA_ATUAL / TRI04_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If YTD_COTA <> 0 Then YTD_PERFORMANCE = Round((YTD_DEMANDA_ATUAL / YTD_COTA) * 100, 2, MidpointRounding.AwayFromZero)
        If TOTAL_COTA <> 0 Then TOTAL_PERFORMANCE = Round((TOTAL_DEMANDA_ATUAL / TOTAL_COTA) * 100, 2, MidpointRounding.AwayFromZero)


        'MONTA RELATÓRIO
        If Exibir = False Then Exit Sub
        rw = New TableRow

        rw.BorderColor = Drawing.Color.Silver
        rw.BackColor = Drawing.Color.Transparent
        rw.BorderWidth = 1
        tbl_Report.Rows.Add(rw)

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = TITULO_LINHA
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JAN_PERFORMANCE, 2) & " %"
        If JAN_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If JAN_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If JAN_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If JAN_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(FEV_PERFORMANCE, 2) & " %"
        If FEV_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If FEV_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If FEV_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If FEV_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAR_PERFORMANCE, 2) & " %"
        If MAR_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If MAR_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If MAR_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If MAR_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(ABR_PERFORMANCE, 2) & " %"
        If ABR_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If ABR_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If ABR_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If ABR_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(MAI_PERFORMANCE, 2) & " %"
        If MAI_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If MAI_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If MAI_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If MAI_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUN_PERFORMANCE, 2) & " %"
        If JUN_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If JUN_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If JUN_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If JUN_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(JUL_PERFORMANCE, 2) & " %"
        If JUL_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If JUL_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If JUL_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If JUL_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(AGO_PERFORMANCE, 2) & " %"
        If AGO_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If AGO_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If AGO_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If AGO_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(SET_PERFORMANCE, 2) & " %"
        If SET_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If SET_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If SET_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If SET_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(OUT_PERFORMANCE, 2) & " %"
        If OUT_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If OUT_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If OUT_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If OUT_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(NOV_PERFORMANCE, 2) & " %"
        If NOV_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If NOV_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If NOV_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If NOV_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(DEZ_PERFORMANCE, 2) & " %"
        If DEZ_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If DEZ_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If DEZ_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If DEZ_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI01_PERFORMANCE, 2) & " %"
        If TRI01_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If TRI01_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If TRI01_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If TRI01_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI02_PERFORMANCE, 2) & " %"
        If TRI02_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If TRI02_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If TRI02_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If TRI02_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI03_PERFORMANCE, 2) & " %"
        If TRI03_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If TRI03_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If TRI03_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If TRI03_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TRI04_PERFORMANCE, 2) & " %"
        If TRI04_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If TRI04_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If TRI04_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If TRI04_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(YTD_PERFORMANCE, 2) & " %"
        If YTD_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If YTD_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If YTD_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If YTD_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1

        cel = New TableCell
        rw.Cells.Add(cel)
        cel.Text = FormatNumber(TOTAL_PERFORMANCE, 2) & " %"
        If TOTAL_PERFORMANCE < 80 Then cel.BackColor = Drawing.Color.FromArgb(255, 100, 100)
        If TOTAL_PERFORMANCE >= 95 Then cel.BackColor = Drawing.Color.FromArgb(100, 255, 100)
        If TOTAL_PERFORMANCE >= 105 Then cel.BackColor = Drawing.Color.LightSkyBlue
        If TOTAL_PERFORMANCE = 0 Then cel.BackColor = Drawing.Color.White
        cel.BorderStyle = BorderStyle.Solid
        cel.BorderColor = Drawing.Color.Silver
        cel.BorderWidth = 1


    End Sub
    Protected Sub Navegar(ByVal Pagina As String)
        Dim jscript As String
        jscript = ""
        jscript += "<script language='JavaScript'>"
        jscript += ";; document.location.href='" & Pagina & "'"
        jscript += "</script>"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Navegar", jscript)
    End Sub
    Protected Function Alert(ByVal Texto_Mensagem As String, ByVal Redirecionar As Boolean, ByVal Pagina As String) As Boolean
        Dim jscript As String
        'caixa de mensagem
        If Redirecionar = True Then
            jscript = ""
            jscript += "<script language='JavaScript'>"
            jscript += ";alert('" & Texto_Mensagem & "'); document.location.href='" & Pagina & "'"
            jscript += "</script>"
        Else
            jscript = ""
            jscript += "<script language='JavaScript'>"
            jscript += ";alert('" & Texto_Mensagem & "');"
            jscript += "</script>"
        End If
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Mensagem", jscript)
        Alert = True
    End Function
End Class