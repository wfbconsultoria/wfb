<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Menu_relatórios.aspx.vb" Inherits="Menu_Acoes" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Relatórios de Performance</title>
    </head>
<body>
    <uc1:Cabecalho runat="server" ID="Cabecalho" />
    <form id="form1" runat="server">
<div id ="Corpo">

    <h3><asp:HyperLink ID="lnk_KPI_Performance_Brasil" runat="server" NavigateUrl="~/rpt_Performance_Reps.aspx" CssClass="link_submenu" Enabled="True">KPI Performance Brasil</asp:HyperLink></h3>
    <div class="subtitulo">Relatório de Desempenho da Equipe Devices</div>

    <h3><asp:HyperLink ID="lnk_Performance_Brasil" runat="server" NavigateUrl="~/Brasil_Ficha.aspx" CssClass="link_submenu" Enabled="True">Performance Brasil</asp:HyperLink></h3>
    <div class="subtitulo">Relatório com a Performance Total da Equipe Devices</div>

    <h3><asp:HyperLink ID="lnk_Performance_Representante" runat="server" NavigateUrl="~/Brasil_Ficha_Rep.aspx" CssClass="link_submenu" Enabled="True">Performance Brasil (Detalhado por Representante)</asp:HyperLink></h3>
    <div class="subtitulo">Relatório com a Performance Brasil detalhado por Representante, com filtro por Linha de Produto</div>

    <h3><asp:HyperLink ID="lnk_Performance_Setor_Representante" runat="server" NavigateUrl="~/Representantes_Ficha.aspx" CssClass="link_submenu" Enabled="True">Performance do Setor (Representante)</asp:HyperLink></h3>
    <div class="subtitulo">Relatório de Performance com filtro por Representante</div>
    
    <h3><asp:HyperLink ID="lnk_Performance_Rep_Estabelecimento" runat="server" NavigateUrl="~/Representantes_Ficha_Estabelecimento.aspx" CssClass="link_submenu" Enabled="True">Performance do Setor (Representante) - Detalhado por Estabelecimento</asp:HyperLink></h3>
    <div class="subtitulo">Relatório de Performance com filtro por Representante e Linha de Produto, detalhado por Estabelecimento</div>
 
    <h3><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Gerente_Conta_Ficha.aspx" CssClass="link_submenu" Enabled="True">Performance do Setor (Key Account)</asp:HyperLink></h3>
    <div class="subtitulo">Relatório de Performance com filtro por Key Account</div>
    
    <h3><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Gerente_Conta_Ficha_Estabelecimento.aspx" CssClass="link_submenu" Enabled="True">Performance do Setor (Key Account) - Detalhado por Estabelecimento</asp:HyperLink></h3>
    <div class="subtitulo">Relatório de Performance com filtro por Key Account e Linha de Produto, detalhado por Estabelecimento</div>

</div>
</form>
</body>
</html>
