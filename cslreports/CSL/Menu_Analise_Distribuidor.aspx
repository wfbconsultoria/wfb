<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Menu_Analise_Distribuidor.aspx.vb" Inherits="Menu_Analise_Distribuidor" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Menu de Analise de Distribuidor</title>
    </head>
<body>
    <uc1:Cabecalho runat="server" ID="Cabecalho" />
    <form id="form1" runat="server">
<div id ="Corpo">
        <h3><asp:HyperLink ID="lnk_Relatorio_Estoque" runat="server" NavigateUrl="~/rpt_Estoque_Linha_2.aspx" CssClass="link_submenu" Enabled="True">Análise de Linha por Distribuidor</asp:HyperLink></h3>
    <div class="subtitulo">Relatório com informações de Estoque, Venda e Demanda de distribuidor com filtro de ano e linha</div>

    <h3><asp:HyperLink ID="lnk_Relatorio_Estoque_detalhado" runat="server" NavigateUrl="~/rpt_Estoque_Distribuidor_Produto_Sugestao.aspx" CssClass="link_submenu" Enabled="True">Análise de Distribuidor por Linha detalhada por Produto e com sugestão de pedido</asp:HyperLink></h3>
    <div class="subtitulo">Relatório com informações de Estoque, Venda e Demanda e susgestão de pedido por produto com filtro de ano, distribuidor e linha</div>

    <h3><asp:HyperLink ID="lnk_Master_Report" runat="server" NavigateUrl="~/rpt_Master_Report_Distribuidor.aspx" CssClass="link_submenu" Enabled="True">Master Report Distribuidor</asp:HyperLink></h3>
    <div class="subtitulo">Relatório de demanda por ano com várias visões e filtros</div>

    <h3><asp:HyperLink ID="lnk_Mapa_Demanda" runat="server" NavigateUrl="~/Demanda_Mapa_Distribuidor.aspx" CssClass="link_submenu" Enabled="True">Mapa de Demanda por Distribuidor</asp:HyperLink></h3>
    <div class="subtitulo">Dados de Demanda informados pelo Distribuidor</div>

    <h3><asp:HyperLink ID="lnk_Mapa_Estoque" runat="server" NavigateUrl="~/Estoque_Mapa_Distribuidor.aspx" CssClass="link_submenu" Enabled="True">Mapa de Estoque por Distribuidor</asp:HyperLink></h3>
    <div class="subtitulo">Dados de Estoque informados pelo Distribuidor</div>
    
    <h3><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/rpt_Pedido_Sugestao.aspx" CssClass="link_submenu" Enabled="True">Sugestão de Pedido para Distribuidor detalhado por Produto</asp:HyperLink></h3>
    <div class="subtitulo">Relatório com Sugestões de pedidos com filtro de distribuidor e detalhamento por produto.</div>
</div>
</form>
</body>
</html>