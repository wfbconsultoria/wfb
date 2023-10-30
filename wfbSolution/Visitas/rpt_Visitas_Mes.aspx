<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Visitas_Mes.aspx.vb" Inherits="rpt_Visitas_Mes" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Visitas por mês</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">
        Visitas por mês em: <asp:DropDownList ID="cmb_Ano" runat="server" AutoPostBack="True" DataSourceID="dts_Anos" DataTextField="ANO_DESCRICAO" DataValueField="ANO">
    </asp:DropDownList>
    </div>
    <div id ="Titulo_Pagina_Links"></div>
</div>
<div id ="Corpo">
    <br />
<br />
    <rsweb:ReportViewer ID="rptVisitasMes" runat="server" Height="403px" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" SizeToReportContent="True">
        <LocalReport ReportPath="Reports\rpt_Visitas_Mes.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="dts_Visitas" Name="dts_Visitas" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
</div>
    <asp:SqlDataSource ID="dts_Visitas" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_VISITAS_GERAL] WHERE ([ID_VISITA] = @ID_VISITA)">
        <SelectParameters>
           <asp:Parameter DefaultValue="0" Name="ID_VISITA" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT 9999 AS ANO, '@ Selecione' as ANO_DESCRICAO UNION ALL SELECT ANO_VALOR AS ANO, ANO_TEXTO AS ANO_DESCRICAO FROM [TBL_DATAS_ANOS]  WHERE ([ANO_ANALISAR] = 'True') ORDER BY [ANO] DESC">
    </asp:SqlDataSource>
</form>
</body>
</html>
