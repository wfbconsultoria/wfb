<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Performance_Gerentes.aspx.vb" Inherits="rpt_Performance_Gerentes" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>KPI Performance Gerente</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Performance Mês 
        <asp:DropDownList ID="cmb_Mes" runat="server" AutoPostBack="True">
            <asp:ListItem Value="JAN">JANEIRO</asp:ListItem>
            <asp:ListItem Value="FEV">FEVEREIRO</asp:ListItem>
            <asp:ListItem Value="MAR">MARÇO</asp:ListItem>
            <asp:ListItem Value="ABR">ABRIL</asp:ListItem>
            <asp:ListItem Value="MAI">MAIO</asp:ListItem>
            <asp:ListItem Value="JUN">JUNHO</asp:ListItem>
            <asp:ListItem Value="JUL">JULHO</asp:ListItem>
            <asp:ListItem Value="AGO">AGOSTO</asp:ListItem>
            <asp:ListItem Value="SET">SETEMBRO</asp:ListItem>
            <asp:ListItem Value="OUT">OUTUBRO</asp:ListItem>
            <asp:ListItem Value="NOV">NOVEMBRO</asp:ListItem>
            <asp:ListItem Value="DEZ">DEZEMBRO</asp:ListItem>
            <asp:ListItem Value="Q1">1º Trimestre</asp:ListItem>
            <asp:ListItem Value="Q2">2º Trimestre</asp:ListItem>
            <asp:ListItem Value="Q3">3º Trimestre</asp:ListItem>
            <asp:ListItem Value="Q4">4º Trimestre</asp:ListItem>
            <asp:ListItem Value="SEM01">1º Semestre</asp:ListItem>
            <asp:ListItem Value="SEM02">2º Semestre</asp:ListItem>
            <asp:ListItem Value="TOTAL">ANO TODO</asp:ListItem>
        </asp:DropDownList>
            &nbsp;
        Ano 
        <asp:DropDownList ID="cmb_Ano" runat="server" AutoPostBack="True" DataSourceID="dts_Anos" DataTextField="ANO_VALOR" DataValueField="ANO_VALOR">
        </asp:DropDownList>
    </div>
    <div id ="Titulo_Pagina_Links"></div>    
&nbsp;</div>

<div id ="Corpo">
    <asp:Table ID="tbl_Report" runat="server" BorderStyle="None" BorderWidth="0px" BorderColor="White"
        CaptionAlign="Left" Font-Names="Calibri" Font-Size="Small" 
        GridLines="Both" HorizontalAlign="Left" 
        style="text-align: center" Width="100%">
    </asp:Table>
</div>
    <br /><br /><br />
    <asp:SqlDataSource ID="dts_Meses" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_DATAS_MESES] ORDER BY [MES_NUMERO_VALOR]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_DATAS_ANOS] WHERE ([ANO_ANALISAR] = @ANO_ANALISAR) ORDER BY [ANO_VALOR] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="ANO_ANALISAR" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Usuarios" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_USUARIOS_ATIVOS] WHERE ([COD_PERFIL] = @COD_PERFIL) ORDER BY [NOME]">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="COD_PERFIL" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
 </form>
</body>
</html>