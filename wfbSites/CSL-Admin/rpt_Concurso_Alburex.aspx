<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Concurso_Alburex.aspx.vb" Inherits="rpt_Concurso_Alburex" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Master Report</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Concurso Alburex</div>
</div>    
<br /><br />
<div id ="Corpo">
   <rsweb:ReportViewer ID="rpt_Report" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="403px" Width="100%">
        <LocalReport ReportPath="Reports\rpt_Concurso_Alburex.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="dts_Concurso_Alburex" Name="dts_Concurso_Alburex" />
                <rsweb:ReportDataSource DataSourceId="dts_Concurso_Cota" Name="dts_Concurso_Cota" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:SqlDataSource ID="dts_Concurso_Cota" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_CONCURSO_COTA]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Concurso_Alburex" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_CONCURSO_ALBUREX]"></asp:SqlDataSource>
</div>

</form>
</body>
</html>