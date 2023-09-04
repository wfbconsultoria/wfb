<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Menu_operações.aspx.vb" Inherits="Menu_Relatorios" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
<form id="form1" runat="server">
<uc1:Cabecalho runat="server" ID="Cabecalho" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Operações</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>
<br />
<div id ="Corpo">
    <br />
    <h3><asp:HyperLink ID="lnk_Usuarios_Localizacao" runat="server" NavigateUrl="~/Usuarios_Localizacao.aspx" CssClass="link_submenu">Administrar Usuários</asp:HyperLink></h3>
    <div class="subtitulo">Página para cadastro e manutenção de usuários do sistema</div>
    
    <h3><asp:HyperLink ID="lnk_Download" runat="server" CssClass="link_submenu" NavigateUrl="~/Download.aspx">Download de Arquivos</asp:HyperLink></h3>
    <div class="subtitulo">Página para download de arquivos (Mapas/Relatórios/etc)</div>

    <h3><asp:HyperLink ID="lnk_Estabelecimentos_Grupos" runat="server" CssClass="link_submenu" NavigateUrl="~/Estabelecimentos_Grupos.aspx">Grupos de Clientes</asp:HyperLink></h3>
    <div class="subtitulo">Página para cadastrar Grupos de Clientes, agrupando dados de demanda </div>
    
    <h3><asp:HyperLink ID="lnk_Estabelecimentos_Pesquisa_RF" runat="server" CssClass="link_submenu" NavigateUrl="~/Estabelecimentos_Pesquisa_RF.aspx">Incluir novo cliente</asp:HyperLink></h3>
    <div class="subtitulo">Página para cadastro de estabelecimentos no sistema, onde os dados são extraidos da Receita Federal</div>

    <h3><asp:HyperLink ID="lnk_Troca_Senha_Usuario" runat="server" NavigateUrl="~/Troca_Senha_Usuario.aspx" CssClass="link_submenu">Trocar Senha</asp:HyperLink></h3>
    <div class="subtitulo">Página para troca de senha de usuário</div>
        
</div>
</form>
</body>

</html>
