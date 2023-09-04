<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Demanda_Crescimento.aspx.vb" Inherits="rpt_Demanda_Crescimento" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Relatório de Crescimento da Demanda</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho"></div>
</div>
<div id ="Corpo">
   <rsweb:ReportViewer ID="rpt_Demanda" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="200px" Width="100%" SizeToReportContent="True" BackColor="White" PageCountMode="Actual" ZoomMode="FullPage">
        <LocalReport ReportPath="Reports\rpt_Demanda_Crescimento.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="dts_Demanda" Name="dts_Demanda" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
     <br />
    <br />
     <asp:SqlDataSource ID="dts_Demanda" runat="server" ConnectionString="<%$ ConnectionStrings:cnnReports %>" SelectCommand="SELECT * FROM [rpt_Crescimento_Demanda_Fiscal_OR]"></asp:SqlDataSource>
</div>
</form>
</body>
</html>
