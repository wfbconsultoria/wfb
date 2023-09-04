<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Master_Report_Relatorio.aspx.vb" Inherits="rpt_Master_Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Master Report</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
<div id="Titulo_Pagina">
</div>

   <rsweb:ReportViewer ID="rpt_Demanda" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="403px" Width="100%">
        <LocalReport ReportPath="Reports\rpt_Master_Report.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="dts_Reports" Name="dts_Report" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
 <br /> <br />
    <asp:SqlDataSource ID="dts_Reports" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_MOVIMENTO_001_DETALHADO_FISCAL]  WHERE ANO = 9999"></asp:SqlDataSource>
   
    <asp:SqlDataSource ID="dts_Relatorios" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_CONFIG_RELATORIOS] WHERE ([PAGINA] = @PAGINA) ORDER BY RELATORIO">
        <SelectParameters>
            <asp:Parameter DefaultValue="rpt_Master_Report.aspx" Name="PAGINA" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

</form>
</body>
</html>