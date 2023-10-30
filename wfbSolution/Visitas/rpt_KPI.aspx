<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_KPI.aspx.vb" Inherits="rpt_KPI" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Início</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/MasterTheme/Master.css" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">KPI</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>    
<div id ="Corpo">
    
    </div>
    <asp:SqlDataSource ID="dts_Usuarios" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_USUARIOS] WHERE (([ATIVO] = @ATIVO) AND ([COD_PERFIL] = @COD_PERFIL))">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="ATIVO" Type="Boolean" />
            <asp:Parameter DefaultValue="4" Name="COD_PERFIL" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
