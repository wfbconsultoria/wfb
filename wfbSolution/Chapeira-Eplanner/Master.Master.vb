Public Class Master
    Inherits System.Web.UI.MasterPage
    Dim l As New clsLojas
    Dim c As New clsColaboradores
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Verifica se o usário está logado como Administrador e habilita o menu de configurações

        If c.CheckLogin(False) = False Then
            menu_Configuracoes.Visible = False
            menu_LogIn.Visible = True
            menu_LogOut.Visible = False
            menu_ChangePassword.Visible = False
        Else
            menu_Configuracoes.Visible = True
            menu_LogIn.Visible = False
            menu_LogOut.Visible = True
            menu_ChangePassword.Visible = True
        End If

        'Preenche nome do usuário caso esteja logado
        If IsNothing(Session("NOME_LOGIN")) Or Session("NOME_LOGIN") = "" Then
            ltrLoggedUser.Text = ""
        Else
            ltrLoggedUser.Text = Session("NOME_LOGIN")
        End If

        'Recupera informações da loja
        l.GetInfoLoja()

        'Preenche Barra de Navegação inferior com dados da loja
        Loja.InnerHtml = l.Loja
        Qtd_Colaboradores_Presentes.InnerHtml = l.Loja_Colaboradores_Presentes_Qtd
        Qtd_Brigadistas_Presentes.InnerHtml = l.Loja_Brigadistas_Presentes_Qtd
        Qtd_NaoBrigadistas_Presentes.InnerHtml = l.Loja_NaoBrigadistas_Presentes_Qtd
        Qtd_Terceiros_Presentes.InnerHtml = l.Loja_Terceiros_Presentes_Qtd
        Qtd_Visitantes_Presentes.InnerHtml = l.Loja_Visitantes_Presentes_Qtd

    End Sub
End Class