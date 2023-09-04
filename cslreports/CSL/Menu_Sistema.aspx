<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Menu_Sistema.aspx.vb" Inherits="Menu_Sistema" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>

<body>
<form id="form1" runat="server">
<uc1:Cabecalho runat="server" ID="Cabecalho" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Sistema</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>
<br />
<div id ="Corpo">
    <br/>

    <h3><asp:HyperLink ID="lnk_Mapa_Estoque" runat="server" NavigateUrl="~/Estoque_Mapa_Distribuidor.aspx" CssClass="link_submenu" Visible="True">Mapa de Estoque por distribuidor</asp:HyperLink></h3>
    <div class="subtitulo">Relatório de Estoque por Distribuidor com filtros por mês e ano</div>

    <h3><asp:HyperLink ID="lnk_Digitacao_Demanda" runat="server" NavigateUrl="~/Digitacao_Demanda.aspx" CssClass="link_submenu" Enabled="True">Digitar Demanda</asp:HyperLink></h3>
    <div class="subtitulo">Página para digitação de demanda conforme mapa informado pelo distribuidor</div>

    <h3><asp:HyperLink ID="lnk_Digitacao_Estoque" runat="server" NavigateUrl="~/Digitacao_Estoque.aspx" CssClass="link_submenu" Enabled="True">Digitar Estoque</asp:HyperLink></h3>
    <div class="subtitulo">Página para digitação de estoque conforme mapa informado pelo distribuidor</div>

    <h3><asp:HyperLink ID="lnk_Digitacao_Demanda_Manutencao" runat="server" NavigateUrl="~/Digitacao_Demanda_Manutencao.aspx" CssClass="link_submenu" Enabled="True">Manutenção de Demanda</asp:HyperLink></h3>
    <div class="subtitulo">Página para manutenção nos valores de demanda inseridos no sistema</div>
 
    <h3><asp:HyperLink ID="lnk_Digitacao_Demanda_Transferencia" runat="server" NavigateUrl="~/Digitacao_Demanda_Transferencia.aspx" CssClass="link_submenu" Enabled="True">Transferência de Demanda</asp:HyperLink></h3>
    <div class="subtitulo">Página para transferência de demanda entre estabelecimentos</div>

</div>
</form>
</body>
</html>
