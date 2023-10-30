<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Menu_operações.aspx.vb" Inherits="Menu_Relatorios" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu de Operações</title>
    
</head>
<uc1:Cabecalho runat="server" ID="Cabecalho" />
<body>
<form id="form1" runat="server">
<div id ="Corpo">

    <h3><asp:HyperLink ID="lnk_Download" runat="server" CssClass="link_submenu" NavigateUrl="~/Download.aspx">Download de Arquivos</asp:HyperLink></h3>
    <div class="subtitulo">Página para download de arquivos (Mapas/Relatórios/etc).</div>

    <h3><asp:HyperLink ID="lnk_Estabelecimentos_Contas_Chave" runat="server" NavigateUrl="~/Estabelecimentos_Contas_Chave.aspx" CssClass="link_submenu">Definir Contas Chave</asp:HyperLink></h3>
    <div class="subtitulo"></div>
    
    <h3><asp:HyperLink ID="lnk_Cotas_Editar" runat="server" NavigateUrl="~/Cotas_Editar.aspx" CssClass="link_submenu">Manutenção de Cotas</asp:HyperLink></h3>
    <div class="subtitulo">Fechado</div>

    <h3><asp:HyperLink ID="lnk_Setorizacao" runat="server" NavigateUrl="~/Setorizacao.aspx" CssClass="link_submenu">Setorização</asp:HyperLink></h3>
    <div class="subtitulo">Aberto para manutenção e alocação de estabelecimentos TARGET</div>

    <h3><asp:HyperLink ID="lnk_Setorizacao_Orfao" runat="server" NavigateUrl="~/Setorizacao_Orfao.aspx" CssClass="link_submenu">Setorização Orfãos</asp:HyperLink></h3>
    <div class="subtitulo">Somente para Gerentes Regionais efetuarem alocação de estabelecimentos orfãos</div>

    <h3><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Setorizacao_KA.aspx" CssClass="link_submenu">Setorização de KA</asp:HyperLink></h3>
    <%--<div class="subtitulo">Fechado</div>--%>

    <h3><asp:HyperLink ID="lnk_Troca_Senha_Usuario" runat="server" NavigateUrl="~/Troca_Senha_Usuario.aspx" CssClass="link_submenu">Trocar Senha</asp:HyperLink></h3>
    <div class="subtitulo"></div>
    
    <h3><asp:HyperLink ID="lnk_Estabelecimentos_CNES" runat="server" CssClass="link_submenu" NavigateUrl="~/Estabelecimentos_CNES.aspx" Visible="false">Incluir novo estabelecimento</asp:HyperLink></h3>
    <div class="subtitulo"></div>

    </div>
    </form>
</body>
</html>
