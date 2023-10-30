<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Estoque_12meses_Produto_Distribuidor.aspx.vb" Inherits="rpt_Estoque_12meses_Produto_Distribuidor" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Estoque 12 meses</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            font-size: large;
        }
    </style>
</head>
<body>   
<uc1:Cabecalho runat="server" ID="Cabecalho" />
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Estoque 12 meses Produto Distribuidor</div><br />
    <div id ="Titulo_Pagina_Links"></div>
</div>    
<div id ="Corpo">
    Produto&nbsp<asp:DropDownList ID="cmbPRODUTO" runat="server" DataSourceID="dtsPRODUTOS" DataTextField="PRODUTO" DataValueField="COD_REDUZIDO" AutoPostBack="True"></asp:DropDownList>&nbsp;<asp:Literal ID="Info" runat="server"></asp:Literal>
    <hr />
    <rsweb:ReportViewer ID="rptEstoque" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="450px">
        <localreport reportpath="Reports\rpt_Estoque_12meses_Produto_Distribuidor.rdlc">
            <datasources>
                <rsweb:ReportDataSource DataSourceId="dts_Report" Name="dts_Report" />
            </datasources>
        </localreport>
    </rsweb:ReportViewer>
    <br /><br />
    </div>
   
    </form>
    <asp:SqlDataSource ID="dtsPRODUTOS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT DISTINCT [COD_REDUZIDO], [PRODUTO] FROM [tbl_PRODUTOS] WHERE ([CAPTAR_DEMANDA] = @CAPTAR_DEMANDA) ORDER BY [PRODUTO]">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="CAPTAR_DEMANDA" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Report" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_DISTRIBUIDORES_GRUPOS_MOVIMENTO_CALCULADO] WHERE ([COD_PRODUTO_REDUZIDO] = @COD_PRODUTO_REDUZIDO) and MES_36 > 24 AND MES_36 < 38 ORDER BY [TIPO]">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmbPRODUTO" Name="COD_PRODUTO_REDUZIDO" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

</body>
</html>
