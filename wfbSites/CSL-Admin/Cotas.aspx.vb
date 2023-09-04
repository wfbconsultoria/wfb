
Partial Class Cotas
    Inherits System.Web.UI.Page
    Public jscript As String
    'Váriaveis Padrão
    Dim M As New clsMaster
    Dim F As New clsFiscal
    Dim C As New clsCotas
    Dim Pagina As String = "Cotas_Demanda.aspx"
    Dim Titulo As String = "Manutenção de Cotas de Demanda - " & ConfigurationManager.AppSettings("NOME_SISTEMA").ToString
    Dim Acesso As Boolean
    Dim Mensagem As String
    'Variaveis da pagina
    Dim ANO As String
    Dim SQL As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '____________________________________________________________________________________________________________________________________________
        'Código padrão para todas as páginas (Controle de log e acesso a página, titulo)
        Acesso = False
        Page.Title = Titulo

        If Session("COD_PERFIL_LOGIN") = 0 Then Acesso = False 'Administrador
        If Session("COD_PERFIL_LOGIN") = 1 Then Acesso = False 'Diretor
        If Session("COD_PERFIL_LOGIN") = 2 Then Acesso = False 'Gerente
        If Session("COD_PERFIL_LOGIN") = 3 Then Acesso = False 'Coordenador
        If Session("COD_PERFIL_LOGIN") = 4 Then Acesso = False 'Representante
        If Session("COD_PERFIL_LOGIN") = 10 Then Acesso = False 'Key Account
        If Session("COD_PERFIL_LOGIN") = 20 Then Acesso = False 'Visitante
        If Session("COD_PERFIL_LOGIN") = 30 Then Acesso = False 'Distribuidor
        'apenas usuarios com perfil de administrador de cotas tem permissão para acessar essa página
        If Session("ADMINISTRADOR_COTAS") = True Then Acesso = True 'Administrador de Cotas 

        'Verifica se o perfil do usuário tem acesso a página
        If Acesso = True Then
            'Grava log de permissão de acesso
            If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSO PERMITIDO", "")
                Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
                Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
            End If
        Else
            'Grava log de recusa de acesso
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSO RECUSADO", "")
            Alert("Seu perfil de usuário não permite acesso a esta página!", True, "Default.aspx")
        End If
        '____________________________________________________________________________________________________________________________________________

        'Código customizado da página

        'bloqueia todos os campos ao entrar na tela
        ConfigCampos("2")

        'verifica se o ano foi selecionado
        If cmb_Anos.Text = "" Then
            ANO = Year(Now())
        Else
            ANO = cmb_Anos.Text
        End If

        'Monta o combo de representante

        ' Verifica perfil e carrega o combo de usuarios
        SQL = "Select '@' as EMAIL,  '# Selecione' AS NOME Union All "
        SQL = SQL & " Select EMAIL, NOME From VIEW_USUARIOS Where (COD_PERFIL = '4') And (ATIVO = 'True') "
        If Session("COD_PERFIL_LOGIN") = "0" Then SQL = SQL
        If Session("COD_PERFIL_LOGIN") = "1" Then SQL = SQL & " And (DIRETOR = '" & Session("EMAIL_LOGIN") & "')"
        If Session("COD_PERFIL_LOGIN") = "2" Then SQL = SQL & " And (GERENTE = '" & Session("EMAIL_LOGIN") & "')"
        If Session("COD_PERFIL_LOGIN") = "3" Then SQL = SQL & " And (EMAIL = '" & Session("EMAIL_LOGIN") & "')"
        If Session("COD_PERFIL_LOGIN") = "4" Then SQL = SQL & " And (EMAIL = '" & Session("EMAIL_LOGIN") & "')"
        SQL = SQL & " Order By NOME"
        dts_Usuarios.SelectCommand = SQL

        'Monta campo de Ano
        SQL = "SELECT DISTINCT top(3) [ANO_FISCAL] FROM [VIEW_DATAS] WHERE ([ANO] >=" & Year(Now()) & " ) Order by ANO_FISCAL "
        dts_Anos.SelectCommand = SQL

    End Sub
    Protected Sub cmb_Usuarios_TextChanged(sender As Object, e As EventArgs) Handles cmb_Usuarios.TextChanged
        'libera os campos no caso de ter sido selecionado um representante
        ConfigCampos("1")
    End Sub
    Protected Sub cmb_Anos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Anos.SelectedIndexChanged
        ConfigCampos("1")
    End Sub
    Protected Sub cmb_Usuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Usuarios.SelectedIndexChanged
        'preenche campo com o valor 0 padrão de inicio
        ConfigCampos("3")

        '11020301 Codigo de Tipo de movimento
        '11020301 - Cota de Venda em Reais / Calendário Universal

        'COTA DE VENDA CSL
        If C.RecuperaCota("TBL_COTAS", cmb_Anos.Text, cmb_Usuarios.Text, "0", "11020301") = False Then
            C.IncluiCotas("TBL_COTAS", cmb_Anos.Text, cmb_Usuarios.Text, "0", "11020301", Session("EMAIL_LOGIN"))
        Else
            txt_JAN_01.Text = C.COTAS_MES1
            txt_FEV_01.Text = C.COTAS_MES2
            txt_MAR_01.Text = C.COTAS_MES3
            txt_ABR_01.Text = C.COTAS_MES4
            txt_MAI_01.Text = C.COTAS_MES5
            txt_JUN_01.Text = C.COTAS_MES6
            txt_JUL_01.Text = C.COTAS_MES7
            txt_AGO_01.Text = C.COTAS_MES8
            txt_SET_01.Text = C.COTAS_MES9
            txt_OUT_01.Text = C.COTAS_MES10
            txt_NOV_01.Text = C.COTAS_MES11
            txt_DEZ_01.Text = C.COTAS_MES12
        End If

        'COTA DE VENDA EM REAIS - LINHA DE PRODUTO ALBUREX
        If C.RecuperaCota("TBL_COTAS", cmb_Anos.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_02.Text, "11020301") = False Then
            C.IncluiCotas("TBL_COTAS", cmb_Anos.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_02.Text, "11020301", Session("EMAIL_LOGIN"))
        Else
            txt_JAN_02.Text = C.COTAS_MES1
            txt_FEV_02.Text = C.COTAS_MES2
            txt_MAR_02.Text = C.COTAS_MES3
            txt_ABR_02.Text = C.COTAS_MES4
            txt_MAI_02.Text = C.COTAS_MES5
            txt_JUN_02.Text = C.COTAS_MES6
            txt_JUL_02.Text = C.COTAS_MES7
            txt_AGO_02.Text = C.COTAS_MES8
            txt_SET_02.Text = C.COTAS_MES9
            txt_OUT_02.Text = C.COTAS_MES10
            txt_NOV_02.Text = C.COTAS_MES11
            txt_DEZ_02.Text = C.COTAS_MES12
        End If

        '10010201 Codigo de Tipo de movimento
        '10010201 - Cota de demanda em unidade Equivalente / Calendário Universal

        'COTA DE DEMANDA EM UNIDADE UNIVERSAL - LINHA DE PRODUTO HAEMOCOMPLETAN
        If C.RecuperaCota("TBL_COTAS", cmb_Anos.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_03.Text, "10010201") = False Then
            C.IncluiCotas("TBL_COTAS", cmb_Anos.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_03.Text, "10010201", Session("EMAIL_LOGIN"))
        Else
            txt_JAN_03.Text = C.COTAS_MES1
            txt_FEV_03.Text = C.COTAS_MES2
            txt_MAR_03.Text = C.COTAS_MES3
            txt_ABR_03.Text = C.COTAS_MES4
            txt_MAI_03.Text = C.COTAS_MES5
            txt_JUN_03.Text = C.COTAS_MES6
            txt_JUL_03.Text = C.COTAS_MES7
            txt_AGO_03.Text = C.COTAS_MES8
            txt_SET_03.Text = C.COTAS_MES9
            txt_OUT_03.Text = C.COTAS_MES10
            txt_NOV_03.Text = C.COTAS_MES11
            txt_DEZ_03.Text = C.COTAS_MES12
        End If

        'COTA DE DEMANDA EM UNIDADE UNIVERSAL - LINHA DE PRODUTO BERIPLAST
        If C.RecuperaCota("TBL_COTAS", cmb_Anos.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_04.Text, "10010201") = False Then
            C.IncluiCotas("TBL_COTAS", cmb_Anos.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_04.Text, "10010201", Session("EMAIL_LOGIN"))
        Else
            txt_JAN_04.Text = C.COTAS_MES1
            txt_FEV_04.Text = C.COTAS_MES2
            txt_MAR_04.Text = C.COTAS_MES3
            txt_ABR_04.Text = C.COTAS_MES4
            txt_MAI_04.Text = C.COTAS_MES5
            txt_JUN_04.Text = C.COTAS_MES6
            txt_JUL_04.Text = C.COTAS_MES7
            txt_AGO_04.Text = C.COTAS_MES8
            txt_SET_04.Text = C.COTAS_MES9
            txt_OUT_04.Text = C.COTAS_MES10
            txt_NOV_04.Text = C.COTAS_MES11
            txt_DEZ_04.Text = C.COTAS_MES12
        End If

        'COTA DE DEMANDA EM UNIDADE UNIVERSAL - LINHA DE PRODUTO RHOPHYLAC
        If C.RecuperaCota("TBL_COTAS", cmb_Anos.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_05.Text, "10010201") = False Then
            C.IncluiCotas("TBL_COTAS", cmb_Anos.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_05.Text, "10010201", Session("EMAIL_LOGIN"))
        Else
            txt_JAN_05.Text = C.COTAS_MES1
            txt_FEV_05.Text = C.COTAS_MES2
            txt_MAR_05.Text = C.COTAS_MES3
            txt_ABR_05.Text = C.COTAS_MES4
            txt_MAI_05.Text = C.COTAS_MES5
            txt_JUN_05.Text = C.COTAS_MES6
            txt_JUL_05.Text = C.COTAS_MES7
            txt_AGO_05.Text = C.COTAS_MES8
            txt_SET_05.Text = C.COTAS_MES9
            txt_OUT_05.Text = C.COTAS_MES10
            txt_NOV_05.Text = C.COTAS_MES11
            txt_DEZ_05.Text = C.COTAS_MES12
        End If

        'COTA DE DEMANDA EM UNIDADE UNIVERSAL - LINHA DE PRODUTO PRIVIGEN/SANDOGLOBINA
        If C.RecuperaCota("TBL_COTAS", cmb_Anos.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_06.Text, "10010201") = False Then
            C.IncluiCotas("TBL_COTAS", cmb_Anos.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_06.Text, "10010201", Session("EMAIL_LOGIN"))
        Else
            txt_JAN_06.Text = C.COTAS_MES1
            txt_FEV_06.Text = C.COTAS_MES2
            txt_MAR_06.Text = C.COTAS_MES3
            txt_ABR_06.Text = C.COTAS_MES4
            txt_MAI_06.Text = C.COTAS_MES5
            txt_JUN_06.Text = C.COTAS_MES6
            txt_JUL_06.Text = C.COTAS_MES7
            txt_AGO_06.Text = C.COTAS_MES8
            txt_SET_06.Text = C.COTAS_MES9
            txt_OUT_06.Text = C.COTAS_MES10
            txt_NOV_06.Text = C.COTAS_MES11
            txt_DEZ_06.Text = C.COTAS_MES12
        End If

        'COTA DE DEMANDA EM UNIDADE UNIVERSAL - LINHA DE PRODUTO PRIVIGEN/SANDOGLOBINA
        If C.RecuperaCota("TBL_COTAS", cmb_Anos.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_07.Text, "10010201") = False Then
            C.IncluiCotas("TBL_COTAS", cmb_Anos.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_07.Text, "10010201", Session("EMAIL_LOGIN"))
        Else
            txt_JAN_07.Text = C.COTAS_MES1
            txt_FEV_07.Text = C.COTAS_MES2
            txt_MAR_07.Text = C.COTAS_MES3
            txt_ABR_07.Text = C.COTAS_MES4
            txt_MAI_07.Text = C.COTAS_MES5
            txt_JUN_07.Text = C.COTAS_MES6
            txt_JUL_07.Text = C.COTAS_MES7
            txt_AGO_07.Text = C.COTAS_MES8
            txt_SET_07.Text = C.COTAS_MES9
            txt_OUT_07.Text = C.COTAS_MES10
            txt_NOV_07.Text = C.COTAS_MES11
            txt_DEZ_07.Text = C.COTAS_MES12
        End If

        'COTA DE DEMANDA EM UNIDADE UNIVERSAL - LINHA DE PRODUTO ALBUREX
        If C.RecuperaCota("TBL_COTAS", cmb_Anos.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_08.Text, "10010201") = False Then
            C.IncluiCotas("TBL_COTAS", cmb_Anos.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_08.Text, "10010201", Session("EMAIL_LOGIN"))
        Else
            txt_JAN_08.Text = C.COTAS_MES1
            txt_FEV_08.Text = C.COTAS_MES2
            txt_MAR_08.Text = C.COTAS_MES3
            txt_ABR_08.Text = C.COTAS_MES4
            txt_MAI_08.Text = C.COTAS_MES5
            txt_JUN_08.Text = C.COTAS_MES6
            txt_JUL_08.Text = C.COTAS_MES7
            txt_AGO_08.Text = C.COTAS_MES8
            txt_SET_08.Text = C.COTAS_MES9
            txt_OUT_08.Text = C.COTAS_MES10
            txt_NOV_08.Text = C.COTAS_MES11
            txt_DEZ_08.Text = C.COTAS_MES12
        End If


    End Sub
    Protected Sub cmd_Gravar_Click(sender As Object, e As EventArgs) Handles cmd_Gravar.Click
        Dim AtualizacaoErro As Boolean

        AtualizacaoErro = False

        If cmb_Usuarios.Text = "@" Then
            Alert("Escolha um Representante para inserir a cota!", False, "")
        Else
            'Cotas de Venda Em Reais ATUALIZAÇÃO
            'Cota CSL COD_PRODUTO LINHA 0
            If C.AtualizaCotas("TBL_COTAS", cmb_Anos.Text, txt_JAN_01.Text, txt_FEV_01.Text, txt_MAR_01.Text, txt_ABR_01.Text, txt_MAI_01.Text, txt_JUN_01.Text, txt_JUL_01.Text, txt_AGO_01.Text, txt_SET_01.Text, txt_OUT_01.Text, txt_NOV_01.Text, txt_DEZ_01.Text, cmb_Usuarios.Text, "0", "11020301", Session("EMAIL_LOGIN")) = False Then
                AtualizacaoErro = True
            End If

            'Cota Venda Linha de Produto Alburex
            If C.AtualizaCotas("TBL_COTAS", cmb_Anos.Text, txt_JAN_02.Text, txt_FEV_02.Text, txt_MAR_02.Text, txt_ABR_02.Text, txt_MAI_02.Text, txt_JUN_02.Text, txt_JUL_02.Text, txt_AGO_02.Text, txt_SET_02.Text, txt_OUT_02.Text, txt_NOV_02.Text, txt_DEZ_02.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_02.Text, "11020301", Session("EMAIL_LOGIN")) = False Then
                AtualizacaoErro = True
            End If

            'Cota Demanda Linha de Produto em unidade Equivalente
            If C.AtualizaCotas("TBL_COTAS", cmb_Anos.Text, txt_JAN_03.Text, txt_FEV_03.Text, txt_MAR_03.Text, txt_ABR_03.Text, txt_MAI_03.Text, txt_JUN_03.Text, txt_JUL_03.Text, txt_AGO_03.Text, txt_SET_03.Text, txt_OUT_03.Text, txt_NOV_03.Text, txt_DEZ_03.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_03.Text, "10010201", Session("EMAIL_LOGIN")) = False Then
                AtualizacaoErro = True
            End If

            If C.AtualizaCotas("TBL_COTAS", cmb_Anos.Text, txt_JAN_04.Text, txt_FEV_04.Text, txt_MAR_04.Text, txt_ABR_04.Text, txt_MAI_04.Text, txt_JUN_04.Text, txt_JUL_04.Text, txt_AGO_04.Text, txt_SET_04.Text, txt_OUT_04.Text, txt_NOV_04.Text, txt_DEZ_04.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_04.Text, "10010201", Session("EMAIL_LOGIN")) = False Then
                AtualizacaoErro = True
            End If
            If C.AtualizaCotas("TBL_COTAS", cmb_Anos.Text, txt_JAN_05.Text, txt_FEV_05.Text, txt_MAR_05.Text, txt_ABR_05.Text, txt_MAI_05.Text, txt_JUN_05.Text, txt_JUL_05.Text, txt_AGO_05.Text, txt_SET_05.Text, txt_OUT_05.Text, txt_NOV_05.Text, txt_DEZ_05.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_05.Text, "10010201", Session("EMAIL_LOGIN")) = False Then
                AtualizacaoErro = True
            End If

            If C.AtualizaCotas("TBL_COTAS", cmb_Anos.Text, txt_JAN_06.Text, txt_FEV_06.Text, txt_MAR_06.Text, txt_ABR_06.Text, txt_MAI_06.Text, txt_JUN_06.Text, txt_JUL_06.Text, txt_AGO_06.Text, txt_SET_06.Text, txt_OUT_06.Text, txt_NOV_06.Text, txt_DEZ_06.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_06.Text, "10010201", Session("EMAIL_LOGIN")) = False Then
                AtualizacaoErro = True
            End If
            If C.AtualizaCotas("TBL_COTAS", cmb_Anos.Text, txt_JAN_07.Text, txt_FEV_07.Text, txt_MAR_07.Text, txt_ABR_07.Text, txt_MAI_07.Text, txt_JUN_07.Text, txt_JUL_07.Text, txt_AGO_07.Text, txt_SET_07.Text, txt_OUT_07.Text, txt_NOV_07.Text, txt_DEZ_07.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_07.Text, "10010201", Session("EMAIL_LOGIN")) = False Then
                AtualizacaoErro = True
            End If
            If C.AtualizaCotas("TBL_COTAS", cmb_Anos.Text, txt_JAN_08.Text, txt_FEV_08.Text, txt_MAR_08.Text, txt_ABR_08.Text, txt_MAI_08.Text, txt_JUN_08.Text, txt_JUL_08.Text, txt_AGO_08.Text, txt_SET_08.Text, txt_OUT_08.Text, txt_NOV_08.Text, txt_DEZ_08.Text, cmb_Usuarios.Text, cmb_Tipo_Produto_08.Text, "10010201", Session("EMAIL_LOGIN")) = False Then
                AtualizacaoErro = True
            End If
        End If

        If AtualizacaoErro = False Then
            Alert("Cotas Atualizadas com sucesso!", False, "")
        Else
            Alert("Erro ao atualizar cotas, um e-mail foi enviado ao suporte para análise!", False, "")
        End If

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
    Function ConfigCampos(AbrirCampo As String) As Boolean
        ConfigCampos = True
        ' 1 é para abrir os campos de texto (campos de meses)
        ' 2 é para a fechar os campos de texto (campos de meses)
        ' 3 é para atribuir 0 para os campos de texto (campos de meses)
        If AbrirCampo = "1" Then
            'verifica se o um usuario foi selecionado
            If (cmb_Usuarios.Text <> "@") Then
                'verifica se o ano e o mes está aberta ou fechado (Mês e Ano que ja passaram se tornam meses fechados)
                If C.AnoMesFechado(cmb_Anos.Text, "1") = True Then
                    txt_JAN_01.Enabled = True
                    txt_JAN_02.Enabled = True
                    txt_JAN_03.Enabled = True
                    txt_JAN_04.Enabled = True
                    txt_JAN_05.Enabled = True
                    txt_JAN_06.Enabled = True
                    txt_JAN_07.Enabled = True
                    txt_JAN_08.Enabled = True
                Else
                    txt_JAN_01.Enabled = False
                    txt_JAN_02.Enabled = False
                    txt_JAN_03.Enabled = False
                    txt_JAN_04.Enabled = False
                    txt_JAN_05.Enabled = False
                    txt_JAN_06.Enabled = False
                    txt_JAN_07.Enabled = False
                    txt_JAN_08.Enabled = False
                End If
                If C.AnoMesFechado(cmb_Anos.Text, "2") = True Then
                    txt_FEV_01.Enabled = True
                    txt_FEV_02.Enabled = True
                    txt_FEV_03.Enabled = True
                    txt_FEV_04.Enabled = True
                    txt_FEV_05.Enabled = True
                    txt_FEV_06.Enabled = True
                    txt_FEV_07.Enabled = True
                    txt_FEV_08.Enabled = True
                Else
                    txt_FEV_01.Enabled = False
                    txt_FEV_02.Enabled = False
                    txt_FEV_03.Enabled = False
                    txt_FEV_04.Enabled = False
                    txt_FEV_05.Enabled = False
                    txt_FEV_06.Enabled = False
                    txt_FEV_07.Enabled = False
                    txt_FEV_08.Enabled = False
                End If
                If C.AnoMesFechado(cmb_Anos.Text, "3") = True Then
                    txt_MAR_01.Enabled = True
                    txt_MAR_02.Enabled = True
                    txt_MAR_03.Enabled = True
                    txt_MAR_04.Enabled = True
                    txt_MAR_05.Enabled = True
                    txt_MAR_06.Enabled = True
                    txt_MAR_07.Enabled = True
                    txt_MAR_08.Enabled = True
                Else
                    txt_MAR_01.Enabled = False
                    txt_MAR_02.Enabled = False
                    txt_MAR_03.Enabled = False
                    txt_MAR_04.Enabled = False
                    txt_MAR_05.Enabled = False
                    txt_MAR_06.Enabled = False
                    txt_MAR_07.Enabled = False
                    txt_MAR_08.Enabled = False
                End If
                If C.AnoMesFechado(cmb_Anos.Text, "4") = True Then
                    txt_ABR_01.Enabled = True
                    txt_ABR_02.Enabled = True
                    txt_ABR_03.Enabled = True
                    txt_ABR_04.Enabled = True
                    txt_ABR_05.Enabled = True
                    txt_ABR_06.Enabled = True
                    txt_ABR_07.Enabled = True
                    txt_ABR_08.Enabled = True
                Else
                    txt_ABR_01.Enabled = False
                    txt_ABR_02.Enabled = False
                    txt_ABR_03.Enabled = False
                    txt_ABR_04.Enabled = False
                    txt_ABR_05.Enabled = False
                    txt_ABR_06.Enabled = False
                    txt_ABR_07.Enabled = False
                    txt_ABR_08.Enabled = False
                End If
                If C.AnoMesFechado(cmb_Anos.Text, "5") = True Then
                    txt_MAI_01.Enabled = True
                    txt_MAI_02.Enabled = True
                    txt_MAI_03.Enabled = True
                    txt_MAI_04.Enabled = True
                    txt_MAI_05.Enabled = True
                    txt_MAI_06.Enabled = True
                    txt_MAI_07.Enabled = True
                    txt_MAI_08.Enabled = True
                Else
                    txt_MAI_01.Enabled = False
                    txt_MAI_02.Enabled = False
                    txt_MAI_03.Enabled = False
                    txt_MAI_04.Enabled = False
                    txt_MAI_05.Enabled = False
                    txt_MAI_06.Enabled = False
                    txt_MAI_07.Enabled = False
                    txt_MAI_08.Enabled = False
                End If
                If C.AnoMesFechado(cmb_Anos.Text, "6") = True Then
                    txt_JUN_01.Enabled = True
                    txt_JUN_02.Enabled = True
                    txt_JUN_03.Enabled = True
                    txt_JUN_04.Enabled = True
                    txt_JUN_05.Enabled = True
                    txt_JUN_06.Enabled = True
                    txt_JUN_07.Enabled = True
                    txt_JUN_08.Enabled = True
                Else
                    txt_JUN_01.Enabled = False
                    txt_JUN_02.Enabled = False
                    txt_JUN_03.Enabled = False
                    txt_JUN_04.Enabled = False
                    txt_JUN_05.Enabled = False
                    txt_JUN_06.Enabled = False
                    txt_JUN_07.Enabled = False
                    txt_JUN_08.Enabled = False
                End If
                If C.AnoMesFechado(cmb_Anos.Text, "7") = True Then
                    txt_JUL_01.Enabled = True
                    txt_JUL_02.Enabled = True
                    txt_JUL_03.Enabled = True
                    txt_JUL_04.Enabled = True
                    txt_JUL_05.Enabled = True
                    txt_JUL_06.Enabled = True
                    txt_JUL_07.Enabled = True
                    txt_JUL_08.Enabled = True
                Else
                    txt_JUL_01.Enabled = False
                    txt_JUL_02.Enabled = False
                    txt_JUL_03.Enabled = False
                    txt_JUL_04.Enabled = False
                    txt_JUL_05.Enabled = False
                    txt_JUL_06.Enabled = False
                    txt_JUL_07.Enabled = False
                    txt_JUL_08.Enabled = False
                End If
                If C.AnoMesFechado(cmb_Anos.Text, "8") = True Then
                    txt_AGO_01.Enabled = True
                    txt_AGO_02.Enabled = True
                    txt_AGO_03.Enabled = True
                    txt_AGO_04.Enabled = True
                    txt_AGO_05.Enabled = True
                    txt_AGO_06.Enabled = True
                    txt_AGO_07.Enabled = True
                    txt_AGO_08.Enabled = True
                Else
                    txt_AGO_01.Enabled = False
                    txt_AGO_02.Enabled = False
                    txt_AGO_03.Enabled = False
                    txt_AGO_04.Enabled = False
                    txt_AGO_05.Enabled = False
                    txt_AGO_06.Enabled = False
                    txt_AGO_07.Enabled = False
                    txt_AGO_08.Enabled = False
                End If
                If C.AnoMesFechado(cmb_Anos.Text, "9") = True Then
                    txt_SET_01.Enabled = True
                    txt_SET_02.Enabled = True
                    txt_SET_03.Enabled = True
                    txt_SET_04.Enabled = True
                    txt_SET_05.Enabled = True
                    txt_SET_06.Enabled = True
                    txt_SET_07.Enabled = True
                    txt_SET_08.Enabled = True
                Else
                    txt_SET_01.Enabled = False
                    txt_SET_02.Enabled = False
                    txt_SET_03.Enabled = False
                    txt_SET_04.Enabled = False
                    txt_SET_05.Enabled = False
                    txt_SET_06.Enabled = False
                    txt_SET_07.Enabled = False
                    txt_SET_08.Enabled = False
                End If
                If C.AnoMesFechado(cmb_Anos.Text, "10") = True Then
                    txt_OUT_01.Enabled = True
                    txt_OUT_02.Enabled = True
                    txt_OUT_03.Enabled = True
                    txt_OUT_04.Enabled = True
                    txt_OUT_05.Enabled = True
                    txt_OUT_06.Enabled = True
                    txt_OUT_07.Enabled = True
                    txt_OUT_08.Enabled = True
                Else
                    txt_OUT_01.Enabled = False
                    txt_OUT_02.Enabled = False
                    txt_OUT_03.Enabled = False
                    txt_OUT_04.Enabled = False
                    txt_OUT_05.Enabled = False
                    txt_OUT_06.Enabled = False
                    txt_OUT_07.Enabled = False
                    txt_OUT_08.Enabled = False
                End If
                If C.AnoMesFechado(cmb_Anos.Text, "11") = True Then
                    txt_NOV_01.Enabled = True
                    txt_NOV_02.Enabled = True
                    txt_NOV_03.Enabled = True
                    txt_NOV_04.Enabled = True
                    txt_NOV_05.Enabled = True
                    txt_NOV_06.Enabled = True
                    txt_NOV_07.Enabled = True
                    txt_NOV_08.Enabled = True
                Else
                    txt_NOV_01.Enabled = False
                    txt_NOV_02.Enabled = False
                    txt_NOV_03.Enabled = False
                    txt_NOV_04.Enabled = False
                    txt_NOV_05.Enabled = False
                    txt_NOV_06.Enabled = False
                    txt_NOV_07.Enabled = False
                    txt_NOV_08.Enabled = False
                End If
                If C.AnoMesFechado(cmb_Anos.Text, "12") = True Then
                    txt_DEZ_01.Enabled = True
                    txt_DEZ_02.Enabled = True
                    txt_DEZ_03.Enabled = True
                    txt_DEZ_04.Enabled = True
                    txt_DEZ_05.Enabled = True
                    txt_DEZ_06.Enabled = True
                    txt_DEZ_07.Enabled = True
                    txt_DEZ_08.Enabled = True
                Else
                    txt_DEZ_01.Enabled = False
                    txt_DEZ_02.Enabled = False
                    txt_DEZ_03.Enabled = False
                    txt_DEZ_04.Enabled = False
                    txt_DEZ_05.Enabled = False
                    txt_DEZ_06.Enabled = False
                    txt_DEZ_07.Enabled = False
                    txt_DEZ_08.Enabled = False
                End If
            End If
        ElseIf AbrirCampo = "2" Then
            If (cmb_Usuarios.Text = "@") Then
                txt_JAN_01.Enabled = False
                txt_FEV_01.Enabled = False
                txt_MAR_01.Enabled = False
                txt_ABR_01.Enabled = False
                txt_MAI_01.Enabled = False
                txt_JUN_01.Enabled = False
                txt_JUL_01.Enabled = False
                txt_AGO_01.Enabled = False
                txt_SET_01.Enabled = False
                txt_OUT_01.Enabled = False
                txt_NOV_01.Enabled = False
                txt_DEZ_01.Enabled = False

                txt_JAN_02.Enabled = False
                txt_FEV_02.Enabled = False
                txt_MAR_02.Enabled = False
                txt_ABR_02.Enabled = False
                txt_MAI_02.Enabled = False
                txt_JUN_02.Enabled = False
                txt_JUL_02.Enabled = False
                txt_AGO_02.Enabled = False
                txt_SET_02.Enabled = False
                txt_OUT_02.Enabled = False
                txt_NOV_02.Enabled = False
                txt_DEZ_02.Enabled = False

                txt_JAN_03.Enabled = False
                txt_FEV_03.Enabled = False
                txt_MAR_03.Enabled = False
                txt_ABR_03.Enabled = False
                txt_MAI_03.Enabled = False
                txt_JUN_03.Enabled = False
                txt_JUL_03.Enabled = False
                txt_AGO_03.Enabled = False
                txt_SET_03.Enabled = False
                txt_OUT_03.Enabled = False
                txt_NOV_03.Enabled = False
                txt_DEZ_03.Enabled = False

                txt_JAN_04.Enabled = False
                txt_FEV_04.Enabled = False
                txt_MAR_04.Enabled = False
                txt_ABR_04.Enabled = False
                txt_MAI_04.Enabled = False
                txt_JUN_04.Enabled = False
                txt_JUL_04.Enabled = False
                txt_AGO_04.Enabled = False
                txt_SET_04.Enabled = False
                txt_OUT_04.Enabled = False
                txt_NOV_04.Enabled = False
                txt_DEZ_04.Enabled = False

                txt_JAN_05.Enabled = False
                txt_FEV_05.Enabled = False
                txt_MAR_05.Enabled = False
                txt_ABR_05.Enabled = False
                txt_MAI_05.Enabled = False
                txt_JUN_05.Enabled = False
                txt_JUL_05.Enabled = False
                txt_AGO_05.Enabled = False
                txt_SET_05.Enabled = False
                txt_OUT_05.Enabled = False
                txt_NOV_05.Enabled = False
                txt_DEZ_05.Enabled = False

                txt_JAN_06.Enabled = False
                txt_FEV_06.Enabled = False
                txt_MAR_06.Enabled = False
                txt_ABR_06.Enabled = False
                txt_MAI_06.Enabled = False
                txt_JUN_06.Enabled = False
                txt_JUL_06.Enabled = False
                txt_AGO_06.Enabled = False
                txt_SET_06.Enabled = False
                txt_OUT_06.Enabled = False
                txt_NOV_06.Enabled = False
                txt_DEZ_06.Enabled = False

                txt_JAN_07.Enabled = False
                txt_FEV_07.Enabled = False
                txt_MAR_07.Enabled = False
                txt_ABR_07.Enabled = False
                txt_MAI_07.Enabled = False
                txt_JUN_07.Enabled = False
                txt_JUL_07.Enabled = False
                txt_AGO_07.Enabled = False
                txt_SET_07.Enabled = False
                txt_OUT_07.Enabled = False
                txt_NOV_07.Enabled = False
                txt_DEZ_07.Enabled = False

                txt_JAN_08.Enabled = False
                txt_FEV_08.Enabled = False
                txt_MAR_08.Enabled = False
                txt_ABR_08.Enabled = False
                txt_MAI_08.Enabled = False
                txt_JUN_08.Enabled = False
                txt_JUL_08.Enabled = False
                txt_AGO_08.Enabled = False
                txt_SET_08.Enabled = False
                txt_OUT_08.Enabled = False
                txt_NOV_08.Enabled = False
                txt_DEZ_08.Enabled = False
            End If
        ElseIf AbrirCampo = "3" Then
            'preenche campo com o valor 0 padrão de inicio
            txt_JAN_01.Text = 0
            txt_FEV_01.Text = 0
            txt_MAR_01.Text = 0
            txt_ABR_01.Text = 0
            txt_MAI_01.Text = 0
            txt_JUN_01.Text = 0
            txt_JUL_01.Text = 0
            txt_AGO_01.Text = 0
            txt_SET_01.Text = 0
            txt_OUT_01.Text = 0
            txt_NOV_01.Text = 0
            txt_DEZ_01.Text = 0

            txt_JAN_02.Text = 0
            txt_FEV_02.Text = 0
            txt_MAR_02.Text = 0
            txt_ABR_02.Text = 0
            txt_MAI_02.Text = 0
            txt_JUN_02.Text = 0
            txt_JUL_02.Text = 0
            txt_AGO_02.Text = 0
            txt_SET_02.Text = 0
            txt_OUT_02.Text = 0
            txt_NOV_02.Text = 0
            txt_DEZ_02.Text = 0

            txt_JAN_03.Text = 0
            txt_FEV_03.Text = 0
            txt_MAR_03.Text = 0
            txt_ABR_03.Text = 0
            txt_MAI_03.Text = 0
            txt_JUN_03.Text = 0
            txt_JUL_03.Text = 0
            txt_AGO_03.Text = 0
            txt_SET_03.Text = 0
            txt_OUT_03.Text = 0
            txt_NOV_03.Text = 0
            txt_DEZ_03.Text = 0

            txt_JAN_04.Text = 0
            txt_FEV_04.Text = 0
            txt_MAR_04.Text = 0
            txt_ABR_04.Text = 0
            txt_MAI_04.Text = 0
            txt_JUN_04.Text = 0
            txt_JUL_04.Text = 0
            txt_AGO_04.Text = 0
            txt_SET_04.Text = 0
            txt_OUT_04.Text = 0
            txt_NOV_04.Text = 0
            txt_DEZ_04.Text = 0

            txt_JAN_05.Text = 0
            txt_FEV_05.Text = 0
            txt_MAR_05.Text = 0
            txt_ABR_05.Text = 0
            txt_MAI_05.Text = 0
            txt_JUN_05.Text = 0
            txt_JUL_05.Text = 0
            txt_AGO_05.Text = 0
            txt_SET_05.Text = 0
            txt_OUT_05.Text = 0
            txt_NOV_05.Text = 0
            txt_DEZ_05.Text = 0

            txt_JAN_06.Text = 0
            txt_FEV_06.Text = 0
            txt_MAR_06.Text = 0
            txt_ABR_06.Text = 0
            txt_MAI_06.Text = 0
            txt_JUN_06.Text = 0
            txt_JUL_06.Text = 0
            txt_AGO_06.Text = 0
            txt_SET_06.Text = 0
            txt_OUT_06.Text = 0
            txt_NOV_06.Text = 0
            txt_DEZ_06.Text = 0

            txt_JAN_07.Text = 0
            txt_FEV_07.Text = 0
            txt_MAR_07.Text = 0
            txt_ABR_07.Text = 0
            txt_MAI_07.Text = 0
            txt_JUN_07.Text = 0
            txt_JUL_07.Text = 0
            txt_AGO_07.Text = 0
            txt_SET_07.Text = 0
            txt_OUT_07.Text = 0
            txt_NOV_07.Text = 0
            txt_DEZ_07.Text = 0

            txt_JAN_08.Text = 0
            txt_FEV_08.Text = 0
            txt_MAR_08.Text = 0
            txt_ABR_08.Text = 0
            txt_MAI_08.Text = 0
            txt_JUN_08.Text = 0
            txt_JUL_08.Text = 0
            txt_AGO_08.Text = 0
            txt_SET_08.Text = 0
            txt_OUT_08.Text = 0
            txt_NOV_08.Text = 0
            txt_DEZ_08.Text = 0
        End If
        ConfigCampos = True
    End Function
End Class