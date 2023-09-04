<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Ficha_Report.aspx.vb" Inherits="Estabelecimentos_Ficha_Report" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho"></div>
    <div id ="Titulo_Pagina_Links">
        &nbsp;<a href="Estabelecimentos_Ficha.aspx?CNPJ=<%=Request.QueryString("CNPJ")%>">Ficha do Estabelecimento</a>
    </div>
</div>
<br />
<div id ="Corpo">
     Selecione o relatório 
    <br />
    <asp:DropDownList ID="cmb_Reports" runat="server" AutoPostBack="True" DataSourceID="dts_Relatorios" DataTextField="RELATORIO" DataValueField="CAMINHO_NOME"></asp:DropDownList>
    <br />
    Tipo de Movimento<br />
    <asp:DropDownList ID="cmb_TIPO_MOVIMENTO" runat="server" DataSourceID="dts_TIPO_MOVIMENTO" DataTextField="DESCRICAO" DataValueField="COD_TIPO_MOVIMENTO" AutoPostBack="True"></asp:DropDownList>
    <br />
    Ano
    <br />
    <asp:DropDownList ID="cmb_ANO" runat="server" DataSourceID="dts_ANO" DataTextField="ANO_TEXTO" DataValueField="ANO_VALOR" AutoPostBack="True"></asp:DropDownList>
    <br />
    <br />
    
    <rsweb:ReportViewer ID="rpt_Report" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
        <LocalReport ReportPath="Reports\rpt_Ficha_Estabelecimento_Report.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="dts_Reports" Name="dts_Report" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    </div>

    <asp:SqlDataSource ID="dts_Reports" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_MOVIMENTO_001_DETALHADO_FISCAL]  WHERE ANO = 9999"></asp:SqlDataSource>
   
    <asp:SqlDataSource ID="dts_Relatorios" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_CONFIG_RELATORIOS] WHERE ([FICHA_ESTABELECIMENTO] = @FICHA_ESTABELECIMENTO) ORDER BY [RELATORIO]">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="FICHA_ESTABELECIMENTO" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="dts_TIPO_MOVIMENTO" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '@' AS COD_TIPO_MOVIMENTO, '# Selecione' AS DESCRICAO UNION ALL SELECT [COD_TIPO_MOVIMENTO], [DESCRICAO] FROM [VIEW_CONFIG_TIPO_MOVIMENTO] WHERE ([ATIVO] = @ATIVO) ORDER BY [DESCRICAO]">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="ATIVO" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_ANO" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [ANO_VALOR], [ANO_TEXTO] FROM [TBL_DATAS_ANOS] WHERE ([ANO_ANALISAR] = @ANO_ANALISAR) ORDER BY [ANO_TEXTO] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="ANO_ANALISAR" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    
</form> 
</body>
</html>