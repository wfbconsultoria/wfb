<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Menu_Listas.aspx.vb" Inherits="Menu_Listas" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Menu de Listas</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">

<div id ="Corpo">

    <h3><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Estabelecimentos_Localizar.aspx" CssClass="link_submenu">Meus Estabelecimentos</asp:HyperLink></h3>
    <div class="subtitulo"></div>
    <h3><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Oportunidades_Localizar.aspx" CssClass="link_submenu">Minhas Oportunidades</asp:HyperLink></h3>
    <div class="subtitulo"></div>
    <h3><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Medicos_Lista.aspx" CssClass="link_submenu">Meus Médicos</asp:HyperLink></h3>
    <div class="subtitulo"></div>
    <h3><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Contatos_Lista.aspx" CssClass="link_submenu">Meus Contatos</asp:HyperLink></h3>
    <div class="subtitulo"></div>
    <h3><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Representantes_Visitas.aspx" CssClass="link_submenu" Visible="false">Minhas Visitas</asp:HyperLink></h3>
    <div class="subtitulo"></div>
    <h3><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Visitas_Agenda.aspx" CssClass="link_submenu" Visible="false">Agenda de Visitas</asp:HyperLink></h3>
    <div class="subtitulo"></div>
 
</div>
</form>
</body>
    
</html>
