
Partial Class Cotas_Relatorios
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Cotas_Relatorios.aspx"
    Dim SQL As String
    Dim SQL_relatorio As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

        'CONTROLA OS ACESSO E FUNÇÕES CONFORME O PERFIL DE ACESSO
        SQL = ""
        SQL = "Select * From VIEW_USUARIOS_ATIVOS ORDER BY NOME"

        If Session("COD_PERFIL_LOGIN") = "0" Then
            SQL = "Select * From VIEW_USUARIOS_ATIVOS Where COD_PERFIL = '2' Or COD_PERFIL = '3' Or COD_PERFIL = '4' Or EMAIL= '" & Session("EMAIL_LOGIN") & "' ORDER BY NOME"
        End If
        If Session("COD_PERFIL_LOGIN") = "1" Then
            SQL = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL_DIRETOR= '" & Session("EMAIL_LOGIN") & "' Or EMAIL= '" & Session("EMAIL_LOGIN") & "' ORDER BY NOME"
        End If
        If Session("COD_PERFIL_LOGIN") = "2" Then
            SQL = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL_GERENTE= '" & Session("EMAIL_LOGIN") & "' Or EMAIL= '" & Session("EMAIL_LOGIN") & "' ORDER BY NOME"
        End If
        If Session("COD_PERFIL_LOGIN") = "3" Then
            SQL = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL = '" & Session("EMAIL_LOGIN") & "'  ORDER BY NOME"
        End If
        If Session("COD_PERFIL_LOGIN") = "4" Then
            SQL = "Select * From VIEW_USUARIOS_ATIVOS Where EMAIL = '" & Session("EMAIL_LOGIN") & "'  ORDER BY NOME"
        End If
        If Session("COD_PERFIL_LOGIN") = "5" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "6" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        dts_Usuarios.SelectCommand = SQL
    End Sub
    Protected Sub Atualiza_Relatorio()
        SQL_relatorio = ""
        SQL_relatorio = "SELECT SUM([JAN]) AS JAN, SUM([FEV]) AS FEV, SUM([MAR]) AS MAR, SUM([ABR]) AS ABR, SUM([MAI]) AS MAI, SUM([JUN]) AS JUN, SUM([JUL]) AS JUL, SUM([AGO]) AS AGO, SUM([SET]) AS [SET], SUM([OUT]) AS OUT, SUM([NOV]) AS NOV, SUM([DEZ]) AS DEZ, SUM([TRI1]) AS TRI1,"
        SQL_relatorio = SQL_relatorio & "SUM([TRI2]) AS TRI2, SUM([TRI3]) AS TRI3, SUM([TRI4]) AS TRI4, SUM([TOTAL]) AS TOTAL, [LINHA_PRODUTO] FROM [VIEW_COTAS] "
        SQL_relatorio = SQL_relatorio & "WHERE (([EMAIL_DIRETOR] = '" & cmb_Usuarios.Text & "') or ([EMAIL_GERENTE] = '" & cmb_Usuarios.Text & "') or "
        SQL_relatorio = SQL_relatorio & "([EMAIL_COORDENADOR] = '" & cmb_Usuarios.Text & "') or ([EMAIL] = '" & cmb_Usuarios.Text & "') "

        If Session("COD_PERFIL_LOGIN") = "1" Then
            If Session("EMAIL_LOGIN") = cmb_Usuarios.Text Then
                SQL_relatorio = ""
                SQL_relatorio = "SELECT SUM([JAN]) AS JAN, SUM([FEV]) AS FEV, SUM([MAR]) AS MAR, SUM([ABR]) AS ABR, SUM([MAI]) AS MAI, SUM([JUN]) AS JUN, SUM([JUL]) AS JUL, SUM([AGO]) AS AGO, SUM([SET]) AS [SET], SUM([OUT]) AS OUT, SUM([NOV]) AS NOV, SUM([DEZ]) AS DEZ, SUM([TRI1]) AS TRI1,"
                SQL_relatorio = SQL_relatorio & "SUM([TRI2]) AS TRI2, SUM([TRI3]) AS TRI3, SUM([TRI4]) AS TRI4, SUM([TOTAL]) AS TOTAL, [LINHA_PRODUTO] FROM [VIEW_COTAS] "
                SQL_relatorio = SQL_relatorio & "WHERE (([EMAIL_DIRETOR] = '" & cmb_Usuarios.Text & "')"
            End If
        End If

        SQL_relatorio = SQL_relatorio & "AND ([ANO] = " & cmb_Anos.Text & ")) GROUP BY [LINHA_PRODUTO]"
        dts_Cota_Linha_01.SelectCommand = SQL_relatorio
    End Sub

    Protected Sub cmb_Usuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Usuarios.SelectedIndexChanged
        Atualiza_Relatorio()
    End Sub
    Protected Sub cmb_Anos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Anos.SelectedIndexChanged
        Atualiza_Relatorio()
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