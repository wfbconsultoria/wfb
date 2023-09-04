<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Início</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/MasterTheme/Master.css" />
</head>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<body>
<form id="form1" runat="server">
    <div class="container" style="text-align: justify;">
        <!-- Titulo -->
        <div class="row">
            <div class="col-md-12">
                <div id="Titulo_Pagina_Cabecalho"></div>
            </div>
        </div>

        <!-- Master Report-->
        <div class="row">
            <div class="col-md-12">
                <h4><asp:HyperLink ID="lnk_Master_Report" runat="server" NavigateUrl="~/rpt_Master_Report.aspx" CssClass="link_submenu" Visible="True">Master Report</asp:HyperLink></h4>
                Relatório Mensal com Vendas/Demanda
            </div>
        </div>

        <!-- Estoque 12 meses por produto -->
        <div class="row">
            <div class="col-md-12">
                <h4><asp:HyperLink ID="lnk_Estoque_12meses_Produto_Distribuidor" runat="server" NavigateUrl="~/rpt_Estoque_12meses_Produto_Distribuidor.aspx" CssClass="link_submenu" Enabled="True">Estoque 12 meses por Produto/Distribuidor</asp:HyperLink></h4>
                Estoque calculado dos últimos 12 meses com filtro de produtos por apresentação, inclui total Brasil com gráfico
            </div>
        </div>

        <!-- Estoque 12 meses distribuidor -->
        <div class="row">
            <div class="col-md-12">
                   <h4><asp:HyperLink ID="lnk_Estoque_12meses_Distribuidor_Produto" runat="server" NavigateUrl="~/rpt_Estoque_12meses_Distribuidor_Produto.aspx" CssClass="link_submenu" Enabled="True">Estoque 12 meses por Distribuidor/Produto</asp:HyperLink></h4>
                    Estoque calculado dos últimos 12 meses com filtro por grupo Distribuidor, exibe a evolução do estoque por apresentação de produtos
            </div>
        </div>

        <!-- Estoque ultimo lançamento -->
        <div class="row">
            <div class="col-md-12">
                <h4><asp:HyperLink ID="lnk_rpt_Estoque_Ultimo_Lancamento" runat="server" NavigateUrl="~/rpt_Estoque_Ultimo_Lancamento.aspx" CssClass="link_submenu" Enabled="True">Estoque última posição (SAC)</asp:HyperLink></h4>
                Estoque informado, exibe a última posição de estoque conforme mapa enviado pelo distribuidor
            </div>
        </div>

        <!-- Download -->
        <div class="row">
            <div class="col-md-12">
                <h4><asp:HyperLink ID="lnk_Download" runat="server" CssClass="link_submenu" NavigateUrl="~/Download.aspx">Download de Arquivos</asp:HyperLink></h4>
                Página para download de arquivos (Mapas/Relatórios/etc)
            </div>
        </div>
</div>
</form>
</body>
</html>


























