<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Visitas.aspx.vb" Inherits="rpt_Visitas" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Resumo de Visitas</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">
        Resumo de Visitas Mês <asp:DropDownList ID="cmb_Mes" runat="server" AutoPostBack="True" DataSourceID="dts_Meses" DataTextField="MES_EXTENSO" DataValueField="MES_SIGLA"></asp:DropDownList>
        Ano: <asp:DropDownList ID="cmb_Ano" runat="server" AutoPostBack="True" DataSourceID="dts_Anos" DataTextField="ANO_TEXTO" DataValueField="ANO_VALOR">
        <asp:ListItem>2013</asp:ListItem>
        <asp:ListItem>2014</asp:ListItem>
    </asp:DropDownList>
    </div>
    <div id ="Titulo_Pagina_Links"></div>
</div>
<div id ="Corpo">
    <rsweb:ReportViewer ID="rptVisitas" runat="server" Height="403px" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="Reports\rpt_Visitas.rdlc">
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
    <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_DATAS_ANOS] WHERE ([ANO_ABERTO_VISITACAO] = @ANO_ABERTO_VISITACAO) ORDER BY [ANO_VALOR]">
        <SelectParameters>
           <asp:Parameter DefaultValue="True" Name="ANO_ABERTO_VISITACAO" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Meses" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_DATAS_MESES] ORDER BY [MES_NUMERO_VALOR]"></asp:SqlDataSource>
</form>
</body>
</html>
