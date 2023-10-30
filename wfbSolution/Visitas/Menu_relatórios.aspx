<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Menu_relatórios.aspx.vb" Inherits="Menu_Acoes" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu de Relatórios</title>
    <style type="text/css">
        .auto-style2 {}
    </style>
    </head>
<body>
    <uc1:Cabecalho runat="server" ID="Cabecalho" />
    <form id="form1" runat="server">
<div id ="Corpo">
    
    <h3><asp:HyperLink ID="lnk_Demanda_Estoque_Cotas" runat="server" NavigateUrl="~/Menu_Analise_Distribuidor.aspx" CssClass="link_submenu" Enabled="True">Analise de Distribuidores</asp:HyperLink>&nbsp;<span class="auto-style2">Novo</span></h3>
    <div class="subtitulo">Grupo de relatórios para Analisar Distribuidores.</div>

    <h3><asp:HyperLink ID="lnk_Master_Report" runat="server" NavigateUrl="~/rpt_Master_Report.aspx" CssClass="link_submenu" Enabled="True">Master Report</asp:HyperLink></h3>
    <div class="subtitulo">Relatório de demanda por ano com várias visões e filtros</div>

   <h3><asp:HyperLink ID="lnk_Log_Acesso" runat="server" NavigateUrl="~/Log_Site.aspx" CssClass="link_submenu">Log de acesso</asp:HyperLink></h3>
    <div class="subtitulo">Últimos 1.000 registros de acesso ao portal</div>

     <h3><asp:HyperLink ID="lnk_Cotas" runat="server" NavigateUrl="~/rpt_Cotas.aspx" CssClass="link_submenu" Enabled="True">Relatório de Cotas</asp:HyperLink></h3>
    <div class="subtitulo">Relatório de Cotas com filtro por Ano</div>
    
    <h3><asp:HyperLink ID="lnk_Performance_FV" runat="server" NavigateUrl="~/Menu_relatórios_Performance.aspx" CssClass="link_submenu">Relatórios de KPI e Performance</asp:HyperLink></h3>
    <div class="subtitulo">Grupo de relatórios sobre KPI e Performance</div>  

    <h3><asp:HyperLink ID="lnk_Resumo_Visitas" runat="server" NavigateUrl="~/rpt_Visitas.aspx" CssClass="link_submenu" Visible="false">Resumo de Visitas</asp:HyperLink></h3>
    <div class="subtitulo"></div>

    <h3><asp:HyperLink ID="lnk_ReVisitas" runat="server" NavigateUrl="~/rpt_ReVisitas.aspx" CssClass="link_submenu" Visible="false">Re Visitas</asp:HyperLink></h3>
    <div class="subtitulo"></div>

    <h3><asp:HyperLink ID="lnk_Visitas_Mes" runat="server" NavigateUrl="~/rpt_Visitas_Mes.aspx" CssClass="link_submenu" Visible="false">Visitas por mês</asp:HyperLink></h3>
    <div class="subtitulo"></div>
    
</div>
</form>
</body>
</html>
