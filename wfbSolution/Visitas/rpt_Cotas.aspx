<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Cotas.aspx.vb" Inherits="rpt_Cotas" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Cotas</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/MasterTheme/Master.css" />
    <style type="text/css">
        .auto-style2 {
            font-weight: normal;
        }
    </style>
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho"></div>
    <div id ="Titulo_Pagina_Links"></div>
</div>    
<div id ="Corpo">
        <div style="font-size: medium; font-weight: bold; color: #333333">Relatório de Cotas Devices<br />
            <br />
            <span class="auto-style2">Selecione o ano:</span>
            <asp:DropDownList ID="cmb_Anos" runat="server" DataSourceID="dts_Anos" DataTextField="ANO_TEXTO" DataValueField="ANO_VALOR" AutoPostBack="True">
            </asp:DropDownList>
        </div>
        <div>
        </div>
        <br /> 
        <rsweb:ReportViewer ID="rpt_Relatorio" runat="server" BackColor="White" BorderColor="#666666" BorderStyle="Solid" BorderWidth="0px" Height="500px" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="Reports\rpt_Cotas.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="dts_Report" Name="Reports" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
</div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_DATAS_ANOS] WHERE ([ANO_ANALISAR] = @ANO_ANALISAR) ORDER BY [ANO_VALOR] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="ANO_ANALISAR" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Report" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_COTAS] WHERE (([ANO] = @ANO) AND ([ATIVO] = @ATIVO)) ORDER BY [NOME]">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmb_Anos" Name="ANO" PropertyName="SelectedValue" Type="Decimal" />
            <asp:Parameter DefaultValue="True" Name="ATIVO" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
</form>
</body>
    
</html>
