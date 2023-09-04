<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Demanda_Mapa_Distribuidor.aspx.vb" Inherits="Demanda_Mapa_Distribuidor" %>


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
    <div id ="Titulo_Pagina_Cabecalho">Mapa de Demanda por Distribuidor</div>
</div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id ="Corpo">
        <Strong>
        <br />
        <br />
        Distribuidor</strong><br />
        <asp:DropDownList ID="cmb_Distribuidores" runat="server" DataSourceID="dts_distribuidores" DataTextField="ESTABELECIMENTO" DataValueField="CNPJ" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <strong>Ano</strong><br />
        <asp:DropDownList ID="cmb_ANO" runat="server" DataSourceID="dts_ANO" DataTextField="ANO" DataValueField="ANO" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <strong>Mês</strong><br />
        <asp:DropDownList ID="cmb_MES" runat="server" AutoPostBack="True" DataSourceID="dts_MES" DataTextField="MES_EXTENSO" DataValueField="MES">
        </asp:DropDownList>
        <br />
        <br />
   <rsweb:ReportViewer ID="rpt_Report" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="403px" Width="100%">
        <LocalReport ReportPath="Reports\rpt_Ditribuidor_Mapa_Demanda.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="dts_demanda" Name="dts_Demanda" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
        <br />
             

</div>
        <asp:SqlDataSource ID="dts_ANO" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT DISTINCT [ANO] FROM [VIEW_DEMANDA_001_DETALHADO] ORDER BY [ANO] DESC">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_MES" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT [MES_EXTENSO], [MES] FROM [TBL_DATAS_MESES] ORDER BY [MES]">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_demanda" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_DEMANDA_001_DETALHADO] WHERE (([CNPJ_DISTRIBUIDOR] = @CNPJ_DISTRIBUIDOR) AND ([ANO] = @ANO) AND ([MES] = @MES)) ORDER BY [ID_REGISTRO]">
            <SelectParameters>
                <asp:ControlParameter ControlID="cmb_Distribuidores" Name="CNPJ_DISTRIBUIDOR" PropertyName="SelectedValue" Type="Decimal" />
                <asp:ControlParameter ControlID="cmb_ANO" Name="ANO" PropertyName="SelectedValue" Type="Decimal" />
                <asp:ControlParameter ControlID="cmb_MES" Name="MES" PropertyName="SelectedValue" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
             

        <asp:SqlDataSource ID="dts_distribuidores" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT [CNPJ], [ESTABELECIMENTO] FROM [TBL_DISTRIBUIDORES] WHERE ([CAPTAR_DEMANDA] = @CAPTAR_DEMANDA) ORDER BY [ESTABELECIMENTO]">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="CAPTAR_DEMANDA" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
</form>
</body>
</html>