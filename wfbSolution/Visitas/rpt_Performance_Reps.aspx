<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Performance_Reps.aspx.vb" Inherits="rpt_Performance_Reps" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>KPI Performance</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Performance Mês 
        <asp:DropDownList ID="cmb_Mes" runat="server" AutoPostBack="True">
            <asp:ListItem Value="JAN">Janeiro</asp:ListItem>
            <asp:ListItem Value="FEV">Fevereiro</asp:ListItem>
            <asp:ListItem Value="MAR">Março</asp:ListItem>
            <asp:ListItem Value="ABR">Abril</asp:ListItem>
            <asp:ListItem Value="MAI">Maio</asp:ListItem>
            <asp:ListItem Value="JUN">Junho</asp:ListItem>
            <asp:ListItem Value="JUL">Julho</asp:ListItem>
            <asp:ListItem Value="AGO">Agosto</asp:ListItem>
            <asp:ListItem Value="SET">Setembro</asp:ListItem>
            <asp:ListItem Value="OUT">Outubro</asp:ListItem>
            <asp:ListItem Value="NOV">Novembro</asp:ListItem>
            <asp:ListItem Value="DEZ">Dezembro</asp:ListItem>
            <asp:ListItem Value="YTD">YTD</asp:ListItem>
            <asp:ListItem Value="Q1">1º Trimestre</asp:ListItem>
            <asp:ListItem Value="Q2">2º Trimestre</asp:ListItem>
            <asp:ListItem Value="Q3">3º Trimestre</asp:ListItem>
            <asp:ListItem Value="Q4">4º Trimestre</asp:ListItem>
            <asp:ListItem Value="SEM01">1º Semestre</asp:ListItem>
            <asp:ListItem Value="SEM02">2º Semestre</asp:ListItem>
            <asp:ListItem Value="TOTAL">Ano Todo</asp:ListItem>
        </asp:DropDownList>
        &nbsp;
        Ano 
        <asp:DropDownList ID="cmb_Ano" runat="server" AutoPostBack="True" DataSourceID="dts_Anos" DataTextField="ANO_VALOR" DataValueField="ANO_VALOR">
        </asp:DropDownList>
    </div>
    <div id ="Titulo_Pagina_Links"></div>    

</div>

<div id ="Corpo">
    <asp:Table ID="tbl_Report" runat="server" BorderStyle="None" BorderWidth="0px" BorderColor="White"
        CaptionAlign="Left" Font-Names="Calibri" Font-Size="Small" 
        GridLines="Both" HorizontalAlign="Left" 
        style="text-align: center" Width="100%">
    </asp:Table>
</div>
    <br /><br />
        <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT ANO_VALOR, ANO_TEXTO, ANO_FECHADO, ANO_BISSESTO, ANO_ANALISAR, ANO_PERIODO, ANO_FECHADO_CALCULO_INCENTIVO, ANO_FECHADO_COTAS, ANO_ABERTO_VISITACAO, ANO_ABERTO_OPORTUNIDADES FROM tbl_DATAS_ANOS WHERE (ANO_ANALISAR = @ANO_ANALISAR) AND (ANO_VALOR &gt;= 2014) ORDER BY ANO_VALOR DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="ANO_ANALISAR" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Meses" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_DATAS_MESES] ORDER BY [MES_NUMERO_VALOR]"></asp:SqlDataSource>
 </form>
</body>
</html>