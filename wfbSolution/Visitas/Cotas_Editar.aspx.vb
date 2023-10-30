
Partial Class Cotas_Editar
    Inherits System.Web.UI.Page
    Dim M As New clsMaster
    Dim Pagina As String = "Cotas_Editar.aspx"
    Dim Mensagem As String
    Dim ANO As String
    Dim SQL As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Session("COD_PERFIL_LOGIN") = "0" Then 0
        'If Session("COD_PERFIL_LOGIN") = "1" Then 0
        'If Session("COD_PERFIL_LOGIN") = "2" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "3" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "4" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "5" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "6" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")
        If Session("COD_PERFIL_LOGIN") = "7" Then Alert("Você não tem acesso a esta página", True, "Default.aspx")

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ANTERIOR") = Session("PAGINA_ATUAL")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If

        If cmb_Anos.Text = "" Then
            ANO = Year(Now())
        Else
            ANO = cmb_Anos.Text
        End If

        SQL = "Select * From VIEW_USUARIOS WHERE COD_PERFIL = 4"
        If Session("COD_PERFIL_LOGIN") = "4" Then SQL = "Select * FRom VIEW_USUARIOS Where EMAIL = '" & Session("EMAIL_LOGIN") & "' AND COD_PERFIL = 4"
        If Session("COD_PERFIL_LOGIN") = "3" Then SQL = "Select * From VIEW_USUARIOS Where EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "'"
        If Session("COD_PERFIL_LOGIN") = "2" Then SQL = "Select * From VIEW_USUARIOS Where EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "' or EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' AND COD_PERFIL = 4"
        If Session("COD_PERFIL_LOGIN") = "1" Then SQL = "Select * From VIEW_USUARIOS Where EMAIL_COORDENADOR = '" & Session("EMAIL_LOGIN") & "' or EMAIL_GERENTE = '" & Session("EMAIL_LOGIN") & "' or EMAIL_DIRETOR = '" & Session("EMAIL_LOGIN") & "' AND COD_PERFIL = 4"
        SQL = SQL & " ORDER BY USUARIO, PERFIL"
        dts_Usuarios.SelectCommand = SQL
        If Session("EMAIL_LOGIN") = "camila@wfbconsultoria.com.br" Or Session("EMAIL_LOGIN") = "heloiza@wfbconsultoria.com.br" Then
            txt_JAN_01.Enabled = True
            txt_FEV_01.Enabled = True
            txt_MAR_01.Enabled = True
            txt_ABR_01.Enabled = True
            txt_MAI_01.Enabled = True
            txt_JUN_01.Enabled = True
            txt_JUL_01.Enabled = True
            txt_AGO_01.Enabled = True
            txt_SET_01.Enabled = True
            txt_OUT_01.Enabled = True
            txt_NOV_01.Enabled = True
            txt_DEZ_01.Enabled = True

            txt_JAN_02.Enabled = True
            txt_FEV_02.Enabled = True
            txt_MAR_02.Enabled = True
            txt_ABR_02.Enabled = True
            txt_MAI_02.Enabled = True
            txt_JUN_02.Enabled = True
            txt_JUL_02.Enabled = True
            txt_AGO_02.Enabled = True
            txt_SET_02.Enabled = True
            txt_OUT_02.Enabled = True
            txt_NOV_02.Enabled = True
            txt_DEZ_02.Enabled = True

            txt_JAN_03.Enabled = True
            txt_FEV_03.Enabled = True
            txt_MAR_03.Enabled = True
            txt_ABR_03.Enabled = True
            txt_MAI_03.Enabled = True
            txt_JUN_03.Enabled = True
            txt_JUL_03.Enabled = True
            txt_AGO_03.Enabled = True
            txt_SET_03.Enabled = True
            txt_OUT_03.Enabled = True
            txt_NOV_03.Enabled = True
            txt_DEZ_03.Enabled = True

            txt_JAN_04.Enabled = True
            txt_FEV_04.Enabled = True
            txt_MAR_04.Enabled = True
            txt_ABR_04.Enabled = True
            txt_MAI_04.Enabled = True
            txt_JUN_04.Enabled = True
            txt_JUL_04.Enabled = True
            txt_AGO_04.Enabled = True
            txt_SET_04.Enabled = True
            txt_OUT_04.Enabled = True
            txt_NOV_04.Enabled = True
            txt_DEZ_04.Enabled = True

            txt_JAN_05.Enabled = True
            txt_FEV_05.Enabled = True
            txt_MAR_05.Enabled = True
            txt_ABR_05.Enabled = True
            txt_MAI_05.Enabled = True
            txt_JUN_05.Enabled = True
            txt_JUL_05.Enabled = True
            txt_AGO_05.Enabled = True
            txt_SET_05.Enabled = True
            txt_OUT_05.Enabled = True
            txt_NOV_05.Enabled = True
            txt_DEZ_05.Enabled = True
        End If
    End Sub

    Protected Sub cmd_Gravar_Click(sender As Object, e As EventArgs) Handles cmd_Gravar.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim sql As String

        sql = ""
        sql = "Update TBL_COTAS SET JAN = " & txt_JAN_01.Text & ", FEV = " & txt_FEV_01.Text & ", MAR = " & txt_MAR_01.Text & ", "
        sql = sql & "ABR = " & txt_ABR_01.Text & ", MAI = " & txt_MAI_01.Text & ", JUN = " & txt_JUN_01.Text & ", "
        sql = sql & "JUL = " & txt_JUL_01.Text & ", AGO = " & txt_AGO_01.Text & ", [SET] = " & txt_SET_01.Text & ", "
        sql = sql & "OUT = " & txt_OUT_01.Text & ", NOV = " & txt_NOV_01.Text & ", DEZ = " & txt_DEZ_01.Text
        sql = sql & " Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_linha_Produtos_01.Text

        M.ExecutarSQL(sql)

        sql = ""
        sql = "Update TBL_COTAS SET JAN = " & txt_JAN_02.Text & ", FEV = " & txt_FEV_02.Text & ", MAR = " & txt_MAR_02.Text & ", "
        sql = sql & "ABR = " & txt_ABR_02.Text & ", MAI = " & txt_MAI_02.Text & ", JUN = " & txt_JUN_02.Text & ", "
        sql = sql & "JUL = " & txt_JUL_02.Text & ", AGO = " & txt_AGO_02.Text & ", [SET] = " & txt_SET_02.Text & ", "
        sql = sql & "OUT = " & txt_OUT_02.Text & ", NOV = " & txt_NOV_02.Text & ", DEZ = " & txt_DEZ_02.Text
        sql = sql & " Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_linha_Produtos_02.Text

        M.ExecutarSQL(sql)

        sql = ""
        sql = "Update TBL_COTAS SET JAN = " & txt_JAN_03.Text & ", FEV = " & txt_FEV_03.Text & ", MAR = " & txt_MAR_03.Text & ", "
        sql = sql & "ABR = " & txt_ABR_03.Text & ", MAI = " & txt_MAI_03.Text & ", JUN = " & txt_JUN_03.Text & ", "
        sql = sql & "JUL = " & txt_JUL_03.Text & ", AGO = " & txt_AGO_03.Text & ", [SET] = " & txt_SET_03.Text & ", "
        sql = sql & "OUT = " & txt_OUT_03.Text & ", NOV = " & txt_NOV_03.Text & ", DEZ = " & txt_DEZ_03.Text
        sql = sql & " Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_linha_Produtos_03.Text

        M.ExecutarSQL(sql)

        sql = ""
        sql = "Update TBL_COTAS SET JAN = " & txt_JAN_04.Text & ", FEV = " & txt_FEV_04.Text & ", MAR = " & txt_MAR_04.Text & ", "
        sql = sql & "ABR = " & txt_ABR_04.Text & ", MAI = " & txt_MAI_04.Text & ", JUN = " & txt_JUN_04.Text & ", "
        sql = sql & "JUL = " & txt_JUL_04.Text & ", AGO = " & txt_AGO_04.Text & ", [SET] = " & txt_SET_04.Text & ", "
        sql = sql & "OUT = " & txt_OUT_04.Text & ", NOV = " & txt_NOV_04.Text & ", DEZ = " & txt_DEZ_04.Text
        sql = sql & " Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_linha_Produtos_04.Text

        M.ExecutarSQL(sql)

        sql = ""
        sql = "Update TBL_COTAS SET JAN = " & txt_JAN_05.Text & ", FEV = " & txt_FEV_05.Text & ", MAR = " & txt_MAR_05.Text & ", "
        sql = sql & "ABR = " & txt_ABR_05.Text & ", MAI = " & txt_MAI_05.Text & ", JUN = " & txt_JUN_05.Text & ", "
        sql = sql & "JUL = " & txt_JUL_05.Text & ", AGO = " & txt_AGO_05.Text & ", [SET] = " & txt_SET_05.Text & ", "
        sql = sql & "OUT = " & txt_OUT_05.Text & ", NOV = " & txt_NOV_05.Text & ", DEZ = " & txt_DEZ_05.Text
        sql = sql & " Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_linha_Produtos_05.Text

        If M.ExecutarSQL(sql) = True Then
            Alert("COTA INCLUIDA COM SUCESSO", False, "")
        Else
            Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
        End If

    End Sub
    Protected Sub cmb_Usuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Usuarios.SelectedIndexChanged
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String

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


        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()

        'RECUPERA REGISTRO DA LINHA 1 - EDDS
        sql = ""
        sql = "Select * From TBL_COTAS Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_linha_Produtos_01.Text
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("JAN")) Then txt_JAN_01.Text = dtr("JAN")
            If Not IsDBNull(dtr("FEV")) Then txt_FEV_01.Text = dtr("FEV")
            If Not IsDBNull(dtr("MAR")) Then txt_MAR_01.Text = dtr("MAR")
            If Not IsDBNull(dtr("ABR")) Then txt_ABR_01.Text = dtr("ABR")
            If Not IsDBNull(dtr("MAI")) Then txt_MAI_01.Text = dtr("MAI")
            If Not IsDBNull(dtr("JUN")) Then txt_JUN_01.Text = dtr("JUN")
            If Not IsDBNull(dtr("JUL")) Then txt_JUL_01.Text = dtr("JUL")
            If Not IsDBNull(dtr("AGO")) Then txt_AGO_01.Text = dtr("AGO")
            If Not IsDBNull(dtr("SET")) Then txt_SET_01.Text = dtr("SET")
            If Not IsDBNull(dtr("OUT")) Then txt_OUT_01.Text = dtr("OUT")
            If Not IsDBNull(dtr("NOV")) Then txt_NOV_01.Text = dtr("NOV")
            If Not IsDBNull(dtr("DEZ")) Then txt_DEZ_01.Text = dtr("DEZ")
        Else
            sql = ""
            sql = sql & "Insert INTO TBL_COTAS (EMAIL, ANO, COD_LINHA_PRODUTO, JAN, FEV, MAR, ABR, MAI, JUN, JUL, AGO, [SET], OUT, NOV, DEZ) "
            sql = sql & "Values ('" & cmb_Usuarios.Text & "', " & cmb_Anos.Text & ", " & cmb_linha_Produtos_01.Text & ", 0,0,0,0,0,0,0,0,0,0,0,0) "
            If M.ExecutarSQL(sql) = False Then
                Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
            End If
        End If
        dtr.Close()


        'RECUPERA REGISTRO DA LINHA 2 - GEMSTAR
        sql = ""
        sql = "Select * From TBL_COTAS Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_linha_Produtos_02.Text
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("JAN")) Then txt_JAN_02.Text = dtr("JAN")
            If Not IsDBNull(dtr("FEV")) Then txt_FEV_02.Text = dtr("FEV")
            If Not IsDBNull(dtr("MAR")) Then txt_MAR_02.Text = dtr("MAR")
            If Not IsDBNull(dtr("ABR")) Then txt_ABR_02.Text = dtr("ABR")
            If Not IsDBNull(dtr("MAI")) Then txt_MAI_02.Text = dtr("MAI")
            If Not IsDBNull(dtr("JUN")) Then txt_JUN_02.Text = dtr("JUN")
            If Not IsDBNull(dtr("JUL")) Then txt_JUL_02.Text = dtr("JUL")
            If Not IsDBNull(dtr("AGO")) Then txt_AGO_02.Text = dtr("AGO")
            If Not IsDBNull(dtr("SET")) Then txt_SET_02.Text = dtr("SET")
            If Not IsDBNull(dtr("OUT")) Then txt_OUT_02.Text = dtr("OUT")
            If Not IsDBNull(dtr("NOV")) Then txt_NOV_02.Text = dtr("NOV")
            If Not IsDBNull(dtr("DEZ")) Then txt_DEZ_02.Text = dtr("DEZ")
        Else
            sql = ""
            sql = sql & "Insert INTO TBL_COTAS (EMAIL, ANO, COD_LINHA_PRODUTO, JAN, FEV, MAR, ABR, MAI, JUN, JUL, AGO, [SET], OUT, NOV, DEZ) "
            sql = sql & "Values ('" & cmb_Usuarios.Text & "', " & cmb_Anos.Text & ", " & cmb_linha_Produtos_02.Text & ", 0,0,0,0,0,0,0,0,0,0,0,0) "
            If M.ExecutarSQL(sql) = False Then
                Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
            End If
        End If
        dtr.Close()

        'RECUPERA REGISTRO DA LINHA 3 - CLAVE
        sql = ""
        sql = "Select * From TBL_COTAS Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_linha_Produtos_03.Text
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("JAN")) Then txt_JAN_03.Text = dtr("JAN")
            If Not IsDBNull(dtr("FEV")) Then txt_FEV_03.Text = dtr("FEV")
            If Not IsDBNull(dtr("MAR")) Then txt_MAR_03.Text = dtr("MAR")
            If Not IsDBNull(dtr("ABR")) Then txt_ABR_03.Text = dtr("ABR")
            If Not IsDBNull(dtr("MAI")) Then txt_MAI_03.Text = dtr("MAI")
            If Not IsDBNull(dtr("JUN")) Then txt_JUN_03.Text = dtr("JUN")
            If Not IsDBNull(dtr("JUL")) Then txt_JUL_03.Text = dtr("JUL")
            If Not IsDBNull(dtr("AGO")) Then txt_AGO_03.Text = dtr("AGO")
            If Not IsDBNull(dtr("SET")) Then txt_SET_03.Text = dtr("SET")
            If Not IsDBNull(dtr("OUT")) Then txt_OUT_03.Text = dtr("OUT")
            If Not IsDBNull(dtr("NOV")) Then txt_NOV_03.Text = dtr("NOV")
            If Not IsDBNull(dtr("DEZ")) Then txt_DEZ_03.Text = dtr("DEZ")
        Else
            sql = ""
            sql = sql & "Insert INTO TBL_COTAS (EMAIL, ANO, COD_LINHA_PRODUTO, JAN, FEV, MAR, ABR, MAI, JUN, JUL, AGO, [SET], OUT, NOV, DEZ) "
            sql = sql & "Values ('" & cmb_Usuarios.Text & "', " & cmb_Anos.Text & ", " & cmb_linha_Produtos_03.Text & ", 0,0,0,0,0,0,0,0,0,0,0,0) "
            If M.ExecutarSQL(sql) = False Then
                Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
            End If
        End If
        dtr.Close()

        'RECUPERA REGISTRO DA LINHA 4 - Receptal
        sql = ""
        sql = "Select * From TBL_COTAS Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_linha_Produtos_04.Text
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("JAN")) Then txt_JAN_04.Text = dtr("JAN")
            If Not IsDBNull(dtr("FEV")) Then txt_FEV_04.Text = dtr("FEV")
            If Not IsDBNull(dtr("MAR")) Then txt_MAR_04.Text = dtr("MAR")
            If Not IsDBNull(dtr("ABR")) Then txt_ABR_04.Text = dtr("ABR")
            If Not IsDBNull(dtr("MAI")) Then txt_MAI_04.Text = dtr("MAI")
            If Not IsDBNull(dtr("JUN")) Then txt_JUN_04.Text = dtr("JUN")
            If Not IsDBNull(dtr("JUL")) Then txt_JUL_04.Text = dtr("JUL")
            If Not IsDBNull(dtr("AGO")) Then txt_AGO_04.Text = dtr("AGO")
            If Not IsDBNull(dtr("SET")) Then txt_SET_04.Text = dtr("SET")
            If Not IsDBNull(dtr("OUT")) Then txt_OUT_04.Text = dtr("OUT")
            If Not IsDBNull(dtr("NOV")) Then txt_NOV_04.Text = dtr("NOV")
            If Not IsDBNull(dtr("DEZ")) Then txt_DEZ_04.Text = dtr("DEZ")
        Else
            sql = ""
            sql = sql & "Insert INTO TBL_COTAS (EMAIL, ANO, COD_LINHA_PRODUTO, JAN, FEV, MAR, ABR, MAI, JUN, JUL, AGO, [SET], OUT, NOV, DEZ) "
            sql = sql & "Values ('" & cmb_Usuarios.Text & "', " & cmb_Anos.Text & ", " & cmb_linha_Produtos_04.Text & ", 0,0,0,0,0,0,0,0,0,0,0,0) "
            If M.ExecutarSQL(sql) = False Then
                Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
            End If
        End If
        dtr.Close()

        'RECUPERA REGISTRO DA LINHA 4 - SuperCath
        sql = ""
        sql = "Select * From TBL_COTAS Where EMAIL = '" & cmb_Usuarios.Text & "' AND ANO = " & cmb_Anos.Text & " AND COD_LINHA_PRODUTO = " & cmb_linha_Produtos_05.Text
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            dtr.Read()
            If Not IsDBNull(dtr("JAN")) Then txt_JAN_05.Text = dtr("JAN")
            If Not IsDBNull(dtr("FEV")) Then txt_FEV_05.Text = dtr("FEV")
            If Not IsDBNull(dtr("MAR")) Then txt_MAR_05.Text = dtr("MAR")
            If Not IsDBNull(dtr("ABR")) Then txt_ABR_05.Text = dtr("ABR")
            If Not IsDBNull(dtr("MAI")) Then txt_MAI_05.Text = dtr("MAI")
            If Not IsDBNull(dtr("JUN")) Then txt_JUN_05.Text = dtr("JUN")
            If Not IsDBNull(dtr("JUL")) Then txt_JUL_05.Text = dtr("JUL")
            If Not IsDBNull(dtr("AGO")) Then txt_AGO_05.Text = dtr("AGO")
            If Not IsDBNull(dtr("SET")) Then txt_SET_05.Text = dtr("SET")
            If Not IsDBNull(dtr("OUT")) Then txt_OUT_05.Text = dtr("OUT")
            If Not IsDBNull(dtr("NOV")) Then txt_NOV_05.Text = dtr("NOV")
            If Not IsDBNull(dtr("DEZ")) Then txt_DEZ_05.Text = dtr("DEZ")
        Else
            sql = ""
            sql = sql & "Insert INTO TBL_COTAS (EMAIL, ANO, COD_LINHA_PRODUTO, JAN, FEV, MAR, ABR, MAI, JUN, JUL, AGO, [SET], OUT, NOV, DEZ) "
            sql = sql & "Values ('" & cmb_Usuarios.Text & "', " & cmb_Anos.Text & ", " & cmb_linha_Produtos_05.Text & ", 0,0,0,0,0,0,0,0,0,0,0,0) "
            If M.ExecutarSQL(sql) = False Then
                Alert("Não foi possível efetuar esta operação, um e-mail foi enviado ao administrador para verificação!", False, "")
            End If
        End If
        dtr.Close()


        cnn.Close()
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
