<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Distribuidor_Ficha.aspx.vb" Inherits="Distribuidor_Ficha" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ficha do Distribuidor</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Ficha do Distribuidor</div>
    <div id ="Titulo_Pagina_Links">
        &nbsp;<a href="Menu_Distribuidor.aspx">Menu Distribuidor</a>
    </div>
</div>
<br />
<div id ="Corpo">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" ProcessingMode="Remote">
        <LocalReport>
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="dts_Demanda" Name="dts_Demanda" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:SqlDataSource ID="dts_Grupos_Distribuidores" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT DISTINCT [GRUPO] FROM [TBL_DISTRIBUIDORES] ORDER BY [GRUPO]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Demanda" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_DEMANDA_001_DETALHADO]"></asp:SqlDataSource>
</div>
</form>
</body>
</html>
