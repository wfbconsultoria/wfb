Imports System.Collections.Generic
Partial Class Estabelecimentos_Incluir
    Inherits System.Web.UI.Page
    Public jscript As String
    Dim M As New clsMaster
    Dim Pagina As String = "Estabelecimentos Incluir"
    Dim SQL As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'GRAVA LOG DE ACESSO A PAGINA
        If Session("PAGINA_ATUAL") <> HttpContext.Current.Handler.ToString Then
            M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ACESSOU", "")
            Session("PAGINA_ATUAL") = HttpContext.Current.Handler.ToString
        End If



        'PERMITE SOMENTE A DIGITACAO DE NÚMEROS NO CEP
        txt_CEP.Attributes.Add("OnKeyPress", "Digitar_Numeros(this);Mascara_Entrada(this,'00000000');")
        'PERMITE SOMENTE A DIGITACAO DE NÚMEROS NO CEP
        txt_CNPJ.Attributes.Add("OnKeyPress", "Digitar_Numeros(this);")

        'RECUPERA VALORES DA PAGINA DE PESQUISA CNES
        If Session("CNES_INCLUIR") = "0000000" Then
            txt_CNPJ.Text = Session("CNPJ_INCLUIR")
            txt_CNES.Text = Session("CNES_INCLUIR")
        Else
            Dim cnn As New System.Data.SqlClient.SqlConnection
            Dim cmd As New System.Data.SqlClient.SqlCommand
            Dim dtr As System.Data.SqlClient.SqlDataReader
            Dim sql As String
            cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnCNES").ConnectionString
            cnn.Open()

            'RECUPERA DADOS DA BASE CNES
            sql = ""
            sql = "Select *  From TBL_CADGER_J Where CNES = '" & Session("CNES_INCLUIR") & "'"
            cmd.Connection = cnn
            cmd.CommandText = sql
            dtr = cmd.ExecuteReader
            If dtr.HasRows Then
                dtr.Read()
                txt_CNPJ.Text = dtr("CNPJ").ToString
                txt_CNES.Text = dtr("CNES").ToString
                txt_NOME_FANTASIA.Text = dtr("NOME_FANTASIA").ToString
                txt_CEP.Text = dtr("CEP").ToString
                cmb_COD_MUNICIPIO.Text = dtr("COD_MUNICIPIO_IBGE").ToString
                cmb_ESFERA_ADMINISTRATIVA.Text = -1
                If dtr("ESFERA_ADMINISTRATIVA_02").ToString = "PRIVADO" Then cmb_ESFERA_ADMINISTRATIVA.Text = 0
                If dtr("ESFERA_ADMINISTRATIVA_02").ToString = "MUNICIPAL" Then cmb_ESFERA_ADMINISTRATIVA.Text = 1
                If dtr("ESFERA_ADMINISTRATIVA_02").ToString = "ESTADUAL" Then cmb_ESFERA_ADMINISTRATIVA.Text = 3
                If dtr("ESFERA_ADMINISTRATIVA_02").ToString = "FEDERAL" Then cmb_ESFERA_ADMINISTRATIVA.Text = 4
            End If
            dtr.Close()
            cnn.Close()
        End If
    End Sub

    Protected Sub cmd_Gravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmd_Gravar.Click
        Dim cnn As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim dtr As System.Data.SqlClient.SqlDataReader
        Dim sql As String
        Dim Mensagem As String

        'ABRE CONEXAO COM BANCO DE DADOS
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings("cnnStr").ConnectionString
        cnn.Open()

        'verifica se os campos estão preenchidos
        If Len(txt_CNPJ.Text) = 0 Then
            Alert("Preencher o CNPJ", False, "")
            Exit Sub
        End If

        If Len(txt_NOME_FANTASIA.Text) = 0 Then
            Alert("Preencher o Nome Fantasia", False, "")
            Exit Sub
        End If

        If cmb_COD_MUNICIPIO.Text = "0000000" Then
            Alert("Selecione a Cidade", False, "")
            Exit Sub
        End If
        If cmb_ESFERA_ADMINISTRATIVA.Text = "-1" Then
            Alert("Selecione a Esfera Administrativa", False, "")
            Exit Sub
        End If
        

        'VERIFICA SE O CNPJ JÁ ESTÁ CADASTRADO
        sql = ""
        sql = "Select *  From VIEW_ESTABELECIMENTOS Where CNPJ = " & txt_CNPJ.Text
        cmd.Connection = cnn
        cmd.CommandText = sql
        dtr = cmd.ExecuteReader
        If dtr.HasRows Then
            Session("CNPJ_INCLUIR") = ""
            Session("CNES_INCLUIR") = ""
            Alert("Este hospital já está cadastrado!", False, "")
            dtr.Close()
            Exit Sub
        Else
            dtr.Close()
            sql = ""
            sql = sql & " Insert Into TBL_ESTABELECIMENTOS "
            sql = sql & " (CNPJ, CNES, ESTABELECIMENTO, CEP, COD_MUNICIPIO, COD_ESFERA_ADMINISTRATIVA, INCLUSAO_DATA, INCLUSAO_EMAIL)"
            sql = sql & " Values ("
            sql = sql & M.Converte_Valor(txt_CNPJ.Text) & ", "

            If Len(txt_CNES.Text) = 0 Then
                sql = sql & "'NULL',"
            Else
                sql = sql & "'" & txt_CNES.Text & "', "
            End If

            sql = sql & "'" & M.ConverteTexto(txt_NOME_FANTASIA.Text) & "', "

            If Len(txt_CEP.Text) = 0 Then
                sql = sql & "'NULL',"
            Else
                sql = sql & "'" & Replace(txt_CEP.Text, "-", "") & "', "
            End If

            sql = sql & "'" & cmb_COD_MUNICIPIO.Text & "', "
            sql = sql & cmb_ESFERA_ADMINISTRATIVA.Text & ", "
            sql = sql & "'" & M.RecuperaData & "', "
            sql = sql & "'" & Session("EMAIL_LOGIN") & "') "

            If M.ExecutarSQL(sql) = True Then
                ' RECUPERA O ID_ESTABELECIMENTO INCLUIDO
                Session("CNPJ") = txt_CNPJ.Text

                'SETORIZA O ESTABELECIMENTO
                If Left(cmb_USUARIOS.Text, 1) <> "@" Then
                    sql = ""
                    sql = sql & " Insert Into TBL_SETORIZACAO "
                    sql = sql & " (CNPJ, EMAIL, TARGET, INCLUSAO_DATA, INCLUSAO_EMAIL)"
                    sql = sql & " Values ("
                    sql = sql & Session("CNPJ") & ", "
                    sql = sql & "'" & cmb_USUARIOS.Text & "', "
                    sql = sql & "'" & cmb_TARGET.Text & "', "
                    sql = sql & "'" & M.RecuperaData & "', "
                    sql = sql & "'" & Session("EMAIL_LOGIN") & "') "

                    If M.ExecutarSQL(sql) = True Then
                        M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "SETORIZOU ESTABELECIMENTO", "CNPJ: " & Session("CNPJ") & " - " & txt_NOME_FANTASIA.Text & " PARA: " & cmb_USUARIOS.Text)
                    Else
                        M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO EM SETORIZAR ESTABELECIMENTO", "CNPJ: " & Session("CNPJ") & " - " & txt_NOME_FANTASIA.Text & " PARA: " & cmb_USUARIOS.Text)
                        Mensagem = "ERRO  - SETORIZACAO DE ESTABELECIMENTOS" & Chr(10)
                        Mensagem = Mensagem & "CNPJ: " & Session("CNPJ") & " - " & txt_NOME_FANTASIA.Text & Chr(10)
                        Mensagem = Mensagem & "Para: " & cmb_USUARIOS.Text & Chr(10)
                        M.EnviarEmail("ERRO  - SETORIZACAO DE ESTABELECIMENTOS", Mensagem, True, False, "", "")
                    End If
                End If

                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "INCLUIU ESTABELECIMENTO", "CNPJ: " & txt_CNPJ.Text & " - " & txt_NOME_FANTASIA.Text)
                Alert("Estabelecimento incluido com  sucesso!", True, "Estabelecimentos_CNES.aspx")
                Exit Sub
            Else
                M.LogPagina(Session("SESSAO_LOGIN"), Session("IP_LOGIN"), Session("EMAIL_LOGIN"), Pagina, "ERRO INCLUSAO ESTABELECIMENTO", "CNPJ: " & txt_CNPJ.Text & " CNES: " & txt_CNES.Text)
                Mensagem = "ERRO  - INCLUSÃO DE ESTABELECIMENTOS" & Chr(10)
                Mensagem = Mensagem & "CNPJ: " & txt_CNPJ.Text & Chr(10)
                Mensagem = Mensagem & "Nome Fantasia: " & M.ConverteTexto(txt_NOME_FANTASIA.Text) & Chr(10)
                Mensagem = Mensagem & "Por: " & Session("USUARIO_LOGIN") & " - " & Session("EMAIL_LOGIN")
                M.EnviarEmail("ERRO - INCLUSÃO DE ESTABELECIMENTO", Mensagem, True, False, "", "")
                Alert("Não foi possível efetuar esta inclusao, um e-mail foi enviado ao administrador do sistema para verificação!", False, "")
            End If
            End If
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

