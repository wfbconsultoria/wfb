<%@ Page Language="VB" Debug="true" AutoEventWireup="false" CodeFile="Estabelecimentos_Ficha.aspx.vb" Inherits="Estabelecimentos_Ficha" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    </head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Ficha de Cliente</div>
    <div id ="Titulo_Pagina_Links">
        <% If Request.QueryString("ORFAO") <> "True" Then%>&nbsp;<a href="Estabelecimentos_Editar.aspx?CNPJ=<%=Request.QueryString("CNPJ")%>">Alterar</a>
        <% End If%>&nbsp;<a href="Estabelecimentos_Ficha_Report.aspx?CNPJ=<%=Request.QueryString("CNPJ")%>">Relatório do Estabelecimento</a>
        &nbsp;<a href="Estabelecimentos_Ficha_Contatos.aspx?CNPJ=<%=Request.QueryString("CNPJ")%>">Contatos</a>
        <!--&nbsp;<a href="Estabelecimentos_Setorizacao.aspx?CNPJ=<%=Request.QueryString("CNPJ")%>">Setorização</a>-->
    </div>
</div>
<br />
<div id ="Corpo">
    <rsweb:ReportViewer ID="rpt" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="700px">
        <LocalReport ReportPath="Reports\rpt_Estabelecimentos_Ficha_Master.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="dts_Movimento" Name="dts_Movimento" />
                <rsweb:ReportDataSource DataSourceId="dts_Setorizacao" Name="dts_Setorizacao" />
                <rsweb:ReportDataSource DataSourceId="dts_Estabelecimentos" Name="dts_Estabelecimentos" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <br />
    <asp:SqlDataSource ID="dts_Movimento" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_MOVIMENTO_001_DETALHADO_FISCAL] WHERE ([CNPJ_ESTABELECIMENTO] = @CNPJ_ESTABELECIMENTO)">
        <SelectParameters>
            <asp:QueryStringParameter Name="CNPJ_ESTABELECIMENTO" QueryStringField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Estabelecimentos" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO] WHERE ([CNPJ] = @CNPJ)">
        <SelectParameters>
            <asp:QueryStringParameter Name="CNPJ" QueryStringField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Setorizacao" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [VIEW_SETORIZACAO] WHERE ([CNPJ] = @CNPJ) ORDER BY [REPRESENTANTE]">
        <SelectParameters>
            <asp:QueryStringParameter Name="CNPJ" QueryStringField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource> 
    <br/>
</form> 
</body>
</html>
