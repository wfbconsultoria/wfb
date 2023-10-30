<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Estoque_Distribuidor_Produto_Sugestao.aspx.vb" Inherits="rpt_Estoque_Distribuidor_Sugestao" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Estoque Distribuidores</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style3 {
            background-color: #DCDCDC;
        }
        .auto-style4 {
            background-color: #E6E6FA;
            color: #696969;
        }
        .auto-style5 {
            font-size: small;
        }
    </style>
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Estoque Detalhado Por Produto com sugestão de pedido</div>
    <div id ="Titulo_Pagina_Links">
        <a href="rpt_Pedido_Sugestao.aspx">Sugestão de pedido</a>
        &nbsp;
        <a href="rpt_Estoque_Linha.aspx">Relatório de Estoque por Distribuidor</a>
        &nbsp;
        <a href="Menu_Analise_Distribuidor.aspx">Analisar Distribuidor</a>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    Ano: <asp:DropDownList ID="cmb_Anos" runat="server" DataSourceID="dts_Anos" DataTextField="ANO_DESC" DataValueField="ANO" AutoPostBack="True"></asp:DropDownList> 
    &nbsp;Distribuidor: <asp:DropDownList ID="cmb_DISTRIBUIDOR" runat="server" DataSourceID="dts_DISTRIBUIDORES" DataTextField="GRUPO" DataValueField="GRUPO" AutoPostBack="True"></asp:DropDownList>
    &nbsp;Linha de Produto: &nbsp;<asp:DropDownList ID="cmb_LINHA" runat="server" DataSourceID="dts_Linha_Produto" DataTextField="LINHA" DataValueField="LINHA" AutoPostBack="True"></asp:DropDownList>
    &nbsp;<br />
    <span class="auto-style4">Estoque calculado a partir do mês de Março de 2015. </span>
    <br/>

    <asp:Table ID="tbl_Report" runat="server" Width="100%" BorderColor="White" 
        BorderStyle="Solid" BorderWidth="1px" GridLines="Both" Height="1px">
    </asp:Table>
    <br /><br /><br />
    </div>

     <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '9999' as [ANO], '# Selecione' as [ANO_DESC] UNION ALL SELECT DISTINCT [ANO], CONVERT(varchar(10), ANO)[as [ANO_DESC] FROM [VIEW_DISTRIBUIDORES_ESTOQUE] ORDER BY [ANO] DESC"></asp:SqlDataSource>
     <asp:SqlDataSource ID="dts_Linha_Produto" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '# Selecione' as [LINHA] UNION ALL SELECT [LINHA] FROM [tbl_PRODUTOS_LINHAS] WHERE ([ANALISAR] = @ANALISAR) ORDER BY [LINHA]">
         <SelectParameters>
             <asp:Parameter DefaultValue="True" Name="ANALISAR" Type="Boolean" />
         </SelectParameters>
    </asp:SqlDataSource>
   <asp:SqlDataSource ID="dts_PRODUTOS" runat="server" 
       ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
       SelectCommand="SELECT '# Todos' as [PRODUTO] UNION ALL SELECT DISTINCT [PRODUTO] FROM [VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_TOTAL] WHERE ([LINHA] = @LINHA) ORDER BY [PRODUTO]">
            <SelectParameters>
                <asp:ControlParameter ControlID="cmb_LINHA" Name="LINHA" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_DISTRIBUIDORES" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '# Selecione' as [GRUPO] UNION ALL SELECT DISTINCT [GRUPO] FROM [VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL] WHERE (([ANO] = @ANO)) ORDER BY [GRUPO]">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmb_Anos" Name="ANO" PropertyName="SelectedValue" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>

</form>
     </body>
    
</html>
