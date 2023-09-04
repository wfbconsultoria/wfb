<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Menu_Cadastros.aspx.vb" Inherits="Menu_Cadastros" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu de Operações</title>
    
</head>
<uc1:Cabecalho runat="server" ID="Cabecalho" />
<body>
<form id="form1" runat="server">
    <div id="Titulo_Pagina">
        <div id ="Titulo_Pagina_Cabecalho">Cadastros</div>
        <div id ="Titulo_Pagina_Links"></div>
    </div>
<div id ="Corpo">
<br />

    <h3><asp:HyperLink ID="lnk_Estabelecimentos_Grupos" runat="server" NavigateUrl="~/Estabelecimentos_Grupos.aspx" CssClass="link_submenu" Enabled="True">Grupos de Clientes</asp:HyperLink></h3>
    <div class="subtitulo">&nbsp;</div>
    
</div>
</form>
</body>
</html>
