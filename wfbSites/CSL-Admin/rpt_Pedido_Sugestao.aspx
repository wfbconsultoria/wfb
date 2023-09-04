<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Pedido_Sugestao.aspx.vb" Inherits="rpt_Estoque_Distribuidor_Sugestao" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sugestão de Pedido para Distribuidor detalhado por Produto</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            font-size: small;
        }
    </style>
    </head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Sugestão de Pedido para Distribuidor detalhado por Produto </div>
    <div id ="Titulo_Pagina_Links">
        <a href="rpt_Estoque_Distribuidor_Produto_Sugestao.aspx">Estoque por Produto com Sugestão de Pedido</a>
        &nbsp;
        <a href="Menu_Analise_Distribuidor.aspx">Analisar Distribuidor</a>
    </div>
</div>
<br />
<div id ="Corpo">
    <br/>
    Distribuidor: <asp:DropDownList ID="cmb_DISTRIBUIDOR" runat="server" DataSourceID="dts_DISTRIBUIDORES" DataTextField="GRUPO" DataValueField="GRUPO" AutoPostBack="True"></asp:DropDownList>
    &nbsp;<br />
    <span class="auto-style2">Obs.: Estoque calculado a partir do mês de Março de 2015.<br />
    Obs.: Informações presentes neste relatórios são referentes ao Ano Atual.</span><br />
    <asp:Table ID="tbl_Report" runat="server" Width="100%" BorderColor="White" 
        BorderStyle="Solid" BorderWidth="1px" GridLines="Both" Height="1px">
    </asp:Table>
    <br /><br /><br />
    </div>

    <asp:SqlDataSource ID="dts_DISTRIBUIDORES" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '# Selecione' as [GRUPO] UNION ALL SELECT DISTINCT [GRUPO] FROM [VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL]  ORDER BY [GRUPO]">
    </asp:SqlDataSource>

</form>
     </body>
    
</html>
