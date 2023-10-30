<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estoque_Mapa_Distribuidor.aspx.vb" Inherits="Estoque_Mapa_Distribuidor" %>


<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Início</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/MasterTheme/Master.css" />
</head>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<body>
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Mapa de Estoque por Distribuidor</div>
    <div id ="Titulo_Pagina_Links">
        <a href="rpt_Estoque_Linha.aspx">Demanda, Venda e Estoque por distribuidor</a>
        &nbsp;
        <a href="Menu_Analise_Distribuidor.aspx">Analisar Distribuidor</a>
    </div>
</div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id ="Corpo">
        <Strong>
        <br />
        <br />
        Ano<br />
        <asp:DropDownList ID="cmb_ANO" runat="server" DataSourceID="dts_ANO" DataTextField="ANO" DataValueField="ANO" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        Mês<br />
        <asp:DropDownList ID="cmb_MES" runat="server" AutoPostBack="True" DataSourceID="dts_MES" DataTextField="MES_EXTENSO" DataValueField="MES_NUMERO_VALOR">
        </asp:DropDownList>
        <br />
        Grupo
        Distribuidor<br />
        <asp:DropDownList ID="cmb_Grupo_Distribuidores" runat="server" DataSourceID="dts_Grupo_Distribuidor" DataTextField="GRUPO_DISTRIBUIDOR" DataValueField="GRUPO_DISTRIBUIDOR" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        Distribuidor</strong><br />
        <asp:DropDownList ID="cmb_Distribuidores" runat="server" DataSourceID="dts_distribuidores" DataTextField="DISTRIBUIDOR" DataValueField="CNPJ_DISTRIBUIDOR" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
   <rsweb:ReportViewer ID="rpt_Report" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="403px" Width="100%">
        <LocalReport ReportPath="Reports\rpt_Distribuidor_Mapa_Estoque.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="dts_estoque" Name="dts_Estoque" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
        <br />
             

</div>
        <asp:SqlDataSource ID="dts_ANO" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT DISTINCT [ANO] FROM [VIEW_MOVIMENTO_ESTOQUE] ORDER BY [ANO] DESC">
        </asp:SqlDataSource>
        <Strong>
        <asp:SqlDataSource ID="dts_Grupo_Distribuidor" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '# Selecione' as GRUPO_DISTRIBUIDOR UNION ALL SELECT DISTINCT [GRUPO_DISTRIBUIDOR] FROM [VIEW_MOVIMENTO_ESTOQUE] WHERE ([ANO] = @ANO) ORDER BY [GRUPO_DISTRIBUIDOR]">
            <SelectParameters>
                <asp:ControlParameter ControlID="cmb_ANO" Name="ANO" PropertyName="SelectedValue" Type="Decimal" />
            </SelectParameters>
    </asp:SqlDataSource>
    </strong>
        <asp:SqlDataSource ID="dts_MES" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT MES_EXTENSO, MES_NUMERO_VALOR FROM tbl_DATAS_MESES ORDER BY MES_NUMERO_VALOR">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_estoque" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_MOVIMENTO_ESTOQUE] WHERE (([ANO] = @ANO) AND ([MES] = @MES) AND ([GRUPO_DISTRIBUIDOR] = @GRUPO_DISTRIBUIDOR))">
            <SelectParameters>
                <asp:ControlParameter ControlID="cmb_ANO" Name="ANO" PropertyName="SelectedValue" Type="Decimal" />
                <asp:ControlParameter ControlID="cmb_MES" Name="MES" PropertyName="SelectedValue" Type="Decimal" />
                <asp:ControlParameter ControlID="cmb_Grupo_Distribuidores" Name="GRUPO_DISTRIBUIDOR" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
             

        <asp:SqlDataSource ID="dts_distribuidores" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT '0' as CNPJ_DISTRIBUIDOR, '# Todos' as DISTRIBUIDOR UNION ALL SELECT DISTINCT CNPJ_DISTRIBUIDOR, DISTRIBUIDOR FROM VIEW_MOVIMENTO_ESTOQUE WHERE (ANO = @ANO) AND (GRUPO_DISTRIBUIDOR = @GRUPO_DISTRIBUIDOR) ORDER BY DISTRIBUIDOR">
            <SelectParameters>
                <asp:ControlParameter ControlID="cmb_ANO" Name="ANO" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="cmb_Grupo_Distribuidores" Name="GRUPO_DISTRIBUIDOR" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
</form>
</body>
</html>