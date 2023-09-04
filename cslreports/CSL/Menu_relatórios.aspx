<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Menu_relatórios.aspx.vb" Inherits="Menu_Acoes" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu de Relatórios</title>
</head>
<uc1:Cabecalho runat="server" ID="Cabecalho" />
<body>
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Relatórios</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>
<br />
    <div id ="Corpo">
            <br />
            
            <h3><asp:HyperLink ID="lnk_Estoque_12meses_Produto_Distribuidor" runat="server" NavigateUrl="~/rpt_Estoque_12meses_Produto_Distribuidor.aspx" CssClass="link_submenu" Enabled="True">Estoque 12 meses por Produto/Distribuidor</asp:HyperLink></h3>
            <div class="subtitulo">Estoque calculado dos últimos 12 meses com filtro de produtos por apresentação, inclui total Brasil com gráfico</div>

            <h3><asp:HyperLink ID="lnk_Estoque_12meses_Distribuidor_Produto" runat="server" NavigateUrl="~/rpt_Estoque_12meses_Distribuidor_Produto.aspx" CssClass="link_submenu" Enabled="True">Estoque 12 meses por Distribuidor/Produto</asp:HyperLink></h3>
            <div class="subtitulo">Estoque calculado dos últimos 12 meses com filtro por grupo Distribuidor, exibe a evolução do estoque por apresentação de produtos</div>

            <h3><asp:HyperLink ID="lnk_rpt_Estoque_Ultimo_Lancamento" runat="server" NavigateUrl="~/rpt_Estoque_Ultimo_Lancamento.aspx" CssClass="link_submenu" Enabled="True">Estoque última posição (SAC)</asp:HyperLink></h3>
            <div class="subtitulo">Estoque informado, exibe a última posição de estoque conforme mapa enviado pelo distribuidor</div>                    
     
            <h3><asp:HyperLink ID="lnk_Demanda_Mapa_Distribuidor" runat="server" NavigateUrl="~/Demanda_Mapa_Distribuidor.aspx" CssClass="link_submenu" Visible="True">Mapa de Demanda por distribuidor</asp:HyperLink></h3>
            <div class="subtitulo">Relatório de Demanda por Distribuidor com filtros por mês e ano</div>    
            
            <h3><asp:HyperLink ID="lnk_Log_Site" runat="server" NavigateUrl="~/Log_Site.aspx" CssClass="link_submenu" Visible="True">Log de acesso</asp:HyperLink></h3>
            <div class="subtitulo">Lista com os últimos 5000 registros de log de acesso ao site</div>

</div>
    </form>
</body>

</html>
