<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Estoque_Ultimo_Lancamento.aspx.vb" Inherits="Estoque_Mapa_Distribuidor" %>


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
    <div id ="Titulo_Pagina_Cabecalho">Último Lançamento de Estoque por Produtos</div>
</div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id ="Corpo">
        <br />
        <strong>
        <br />
        Produto</strong><br />
        <asp:DropDownList ID="cmb_Produtos" runat="server" DataSourceID="dts_Produtos" DataTextField="PRODUTO" DataValueField="COD_PRODUTO" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
   <rsweb:ReportViewer ID="rpt_Report" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="420px" Width="100%">
        <LocalReport ReportPath="Reports\rpt_Estoque_Ultimo_Lancamento.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="dts_CSL_Reports" Name="dts_Reports" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
        <br />
             

</div>
        <asp:SqlDataSource ID="dts_Produtos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [COD_PRODUTO], [PRODUTO] FROM [TBL_PRODUTOS] WHERE ([ATIVO] = @ATIVO) ORDER BY [PRODUTO]">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="ATIVO" Type="Boolean" />
            </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_CSL_Reports" runat="server" ConnectionString="<%$ ConnectionStrings:cnnReports %>" SelectCommand="SELECT [Data], [Dias_Passados], [Grupo_Distribuidor], [Distribuidor], [CNPJ_Distribuidor], [Linha_Produto], [Produto], [Cod_Produto], [Unidades] FROM [rpt_Ultimo_Lancamento_Estoque] WHERE ([Cod_Produto] = @Cod_Produto) ORDER BY [Data] DESC, [Distribuidor] DESC">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmb_Produtos" Name="Cod_Produto" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</form>
</body>
</html>