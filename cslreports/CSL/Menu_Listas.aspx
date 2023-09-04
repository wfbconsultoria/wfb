<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Menu_Listas.aspx.vb" Inherits="Menu_Listas" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Menu de Listas</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<uc1:Cabecalho runat="server" ID="Cabecalho" />
<body>
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Listas</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>
<br />
<div id ="Corpo">
    <br />
    
<%--    <h3><asp:HyperLink ID="lnk_Visitas_Agenda" runat="server" NavigateUrl="~/Visitas_Agenda.aspx" CssClass="link_submenu" Visible="True">Agenda de Visitas</asp:HyperLink></h3>
    <div class="subtitulo">Agenda de Visitas do representante</div>--%>
   
    <h3><asp:HyperLink ID="lnk_Distribuidores_Localizar" runat="server" CssClass="link_submenu" NavigateUrl="~/Distribuidores_Localizar.aspx">Distribuidores</asp:HyperLink></h3>
    <div class="subtitulo">Lista com os Distribuidores cadastrados no sistema</div>

    <% If Session("SISTEMA") = True Then%>
    <h3><asp:HyperLink ID="lnk_Estabelecimentos_Localizar_CNES" runat="server" NavigateUrl="~/Estabelecimentos_Localizar_CNES.aspx" CssClass="link_submenu" Visible="True">Lista de Estabelecimentos CNES </asp:HyperLink></h3>
    <div class="subtitulo"></div>

    <h3><asp:HyperLink ID="Estabelecimentos_Localizar_CNPJ" runat="server" NavigateUrl="~/Estabelecimentos_Localizar_CNPJ.aspx" CssClass="link_submenu" Visible="True">Lista de Estabelecimentos CNPJ</asp:HyperLink></h3>
    <div class="subtitulo"></div>
    <% End If%>

</div>
</form>
</body>
</html>
