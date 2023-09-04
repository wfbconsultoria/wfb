<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Estoque_Produto_Distribuidor.aspx.vb" Inherits="rpt_Estoque_Produto_Distribuidor" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Estoque Distribuidores</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <%--<style type="text/css">
        .auto-style1 {
            background-color: #CCCCCC;
        }
        .auto-style2 {
            background-color: #70DBDB;
        }
        .auto-style3 {
            background-color: #DCDCDC;
        }
        .auto-style4 {
            background-color: #48D1CC;
            color: #000;
        }
        .auto-style5 {
            font-size: small;
        }
    </style>--%>
</head>
<body>
    <p>
<%--        <br style="color: rgb(0, 0, 0); font-family: Calibri, Arial, sans-serif; font-size: medium; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 24px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px;" />--%>
    </p>
<uc1:Cabecalho runat="server" ID="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina"> 
    <div id ="Titulo_Pagina_Cabecalho">Estoque Detalhado Por Produto (Unidade Original)</div>
    <div id ="Titulo_Pagina_Links">
    <br />
   <h4> <font color="black">Estoque informado até Maio de 2015.</font></h4>
   <h4> <font color="#48D1CC">Estoque calculado a partir de Junho de 2015.</font></h4>
    <br/>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    Ano: <asp:DropDownList ID="cmb_Anos" runat="server" DataSourceID="dts_Anos" DataTextField="ANO_DESC" DataValueField="ANO" AutoPostBack="True"></asp:DropDownList> 
    &nbsp;Distribuidor: <asp:DropDownList ID="cmb_DISTRIBUIDOR" runat="server" DataSourceID="dts_DISTRIBUIDORES" DataTextField="GRUPO" DataValueField="GRUPO" AutoPostBack="True"></asp:DropDownList>
    &nbsp;Linha de Produto: &nbsp;<asp:DropDownList ID="cmb_LINHA" runat="server" DataSourceID="dts_Linha_Produto" DataTextField="PRODUTO_LINHA" DataValueField="PRODUTO_LINHA" AutoPostBack="True"></asp:DropDownList>

    <asp:Table ID="tbl_Report" runat="server" Width="100%" BorderColor="White" 
        BorderStyle="Solid" BorderWidth="1px" GridLines="Both" Height="1px">
    </asp:Table>
    <br /><br /><br />
    </div>

     <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '9999' as [ANO], '# Selecione' as [ANO_DESC] UNION ALL SELECT DISTINCT [ANO], CONVERT(varchar(10), ANO)[as [ANO_DESC] FROM [VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_FISCAL_UN_OR] ORDER BY [ANO] DESC"></asp:SqlDataSource>
     <asp:SqlDataSource ID="dts_Linha_Produto" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '# Selecione' as PRODUTO_LINHA UNION ALL SELECT [PRODUTO_LINHA] FROM [TBL_PRODUTOS_LINHAS] WHERE ([COD_PRODUTO_LINHA] &gt; @COD_PRODUTO_LINHA) ORDER BY [PRODUTO_LINHA]">
         <SelectParameters>
             <asp:Parameter DefaultValue="0" Name="COD_PRODUTO_LINHA" Type="Decimal" />
         </SelectParameters>
    </asp:SqlDataSource>
   <asp:SqlDataSource ID="dts_PRODUTOS" runat="server" 
       ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
       SelectCommand="SELECT '# Todos' as [PRODUTO] UNION ALL SELECT DISTINCT [PRODUTO] FROM [VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_FISCAL_UN_OR] WHERE ([LINHA] = @LINHA) ORDER BY [PRODUTO]">
            <SelectParameters>
                <asp:ControlParameter ControlID="cmb_LINHA" Name="LINHA" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_DISTRIBUIDORES" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '# Selecione' AS GRUPO UNION ALL SELECT DISTINCT GRUPO FROM VIEW_DISTRIBUIDORES_MOVIMENTO_001_AGRUPADO_PRODUTO_TOTAL_FISCAL_UN_OR WHERE (ANO = @ANO) AND (GRUPO &lt;&gt; '01 - CSL BEHRING (Venda Direta)') ORDER BY GRUPO">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmb_Anos" Name="ANO" PropertyName="SelectedValue" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>

</form>
     </body>
    
</html>
