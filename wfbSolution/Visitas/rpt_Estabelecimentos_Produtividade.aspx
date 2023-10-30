<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Estabelecimentos_Produtividade.aspx.vb" Inherits="Estabelecimentos_Ficha" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Produtividade por Estabelecimento</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Produtividade do Estabelecimento
        &nbsp; Ano: <asp:DropDownList ID="cmb_Ano" runat="server" AutoPostBack="True" DataSourceID="dts_Anos" DataTextField="ANO_VALOR" DataValueField="ANO_VALOR"></asp:DropDownList>
    </div>
    <div id ="Titulo_Pagina_Links">

    </div>    
&nbsp;Linha de Produto: <asp:DropDownList ID="cmb_Linha_Produto" runat="server" AutoPostBack="True" DataSourceID="dts_PRODUTOS_LINHAS" DataTextField="LINHA" DataValueField="COD"></asp:DropDownList>
    <asp:SqlDataSource ID="dts_PRODUTOS_LINHAS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_PRODUTOS_LINHAS] WHERE (([ANALISAR] = @ANALISAR) AND ([COD_GRUPO_BOMBA] &lt;&gt; @COD_GRUPO_BOMBA)) ORDER BY [LINHA]">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="ANALISAR" Type="Boolean" />
            <asp:Parameter DefaultValue="0" Name="COD_GRUPO_BOMBA" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
</div>

<div id ="Corpo">
    <br />
   
    <asp:Table ID="tbl_Report" runat="server" BorderStyle="None" BorderWidth="0px" BorderColor="White"
        CaptionAlign="Left" Font-Names="Calibri" Font-Size="Small" 
        GridLines="Both" HorizontalAlign="Left" 
        style="text-align: center" Width="100%">
    </asp:Table>
</div>
    <br /><br /><br /><br />
        <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_DATAS_ANOS] WHERE ([ANO_ANALISAR] = @ANO_ANALISAR) ORDER BY [ANO_VALOR] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="ANO_ANALISAR" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Estabelecimento" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS]">
    </asp:SqlDataSource>
</form>
</body>
</html>