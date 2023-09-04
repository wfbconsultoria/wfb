
Partial Class Digitacao_Estoque
    Inherits System.Web.UI.Page
    Public jscript As String
    Dim M As New clsMaster
    Dim Pagina As String = "Digitacao_Estoque.aspx"
    Dim SQL As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

        If Session("SISTEMA") <> True Then
            Alert("Você não tem acesso a esta página", True, "Default.aspx")
        End If

        'PERMITE SOMENTE A DIGITACAO DE NÚMEROS NO CAMPO QTD
        txt_QTD.Attributes.Add("OnKeyPress", "Digitar_Numeros(this);")

    End Sub

    Protected Sub cmd_Gravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Gravar.Click
        Dim sql As String
        Dim Mensagem As String
        Dim ANO As Integer
        Dim MES As Integer
        Dim DIA As Integer

        ANO = cmb_ANO.Text
        MES = cmb_MES.Text
        DIA = cmb_DIA.Text

        If Len(txt_QTD.Text) = 0 Then
            Alert("DIGITE A QUANTIDADE", False, "")
            Exit Sub
        End If

        If txt_QTD.Text = 0 Then
            Alert("DIGITE A QUANTIDADE", False, "")
            Exit Sub
        End If

        If cmb_MES.Text = 0 Then
            Alert("SELECIONE O MÊS", False, "")
            Exit Sub
        End If

        If cmb_DIA.Text = 0 Then
            Alert("SELECIONE O DIA", False, "")
            Exit Sub
        End If

        sql = ""
        sql = sql & " Insert Into TBL_MOVIMENTO_ESTOQUE "
        sql = sql & " (ANO, MES, DIA, CNPJ_DISTRIBUIDOR, COD_PRODUTO, QTD, INCLUSAO_DATA, INCLUSAO_EMAIL)"
        sql = sql & " Values ("
        sql = sql & cmb_ANO.Text & ", "
        sql = sql & cmb_MES.Text & ", "
        sql = sql & cmb_DIA.Text & ", "
        sql = sql & cmb_CNPJ_DISTRIBUIDOR.Text & ", "
        sql = sql & "'" & cmb_COD_PRODUTO.Text & "', "
        sql = sql & txt_QTD.Text & ", "
        sql = sql & M.RecuperaData & ", " 'DATA DE INICIO = DATA DE CADASTRO
        sql = sql & "'" & Session("EMAIL_LOGIN") & "' )" 'EMAIL DE QUEM CRIOU A OPORTUNIDADE
        If M.ExecutarSQL(sql) = True Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "DIGITOU ESTOQUE", "CNPJ DISTRIBUIDOR: " & " COD PRODUTO " & cmb_COD_PRODUTO.Text & " QTD " & txt_QTD.Text)
            Alert("Registro Incluido com sucesso", False, "")
            txt_QTD.Text = ""
            dts_Movimento.DataBind()
        Else
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO - DIGITAR ESTOQUE", "CNPJ DISTRIBUIDOR: " & cmb_CNPJ_DISTRIBUIDOR.Text & " COD PRODUTO " & cmb_COD_PRODUTO.Text & " QTD " & txt_QTD.Text)
            Mensagem = "ERRO  - DIGITACAO DEMANDA" & Chr(10)
            Mensagem = Mensagem & "CNPJ DISTRIBUIDOR: " & cmb_CNPJ_DISTRIBUIDOR.Text & " COD PRODUTO " & cmb_COD_PRODUTO.Text & " QTD " & txt_QTD.Text
            M.EnviarEmail("ERRO  - DIGITAÇÃO DE ESTOQUE ", Mensagem, True, False, "", "")
            Alert("Erro ao incluir registro, verifique se as infromações estão digitadas corretamente", False, "")
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
End Class