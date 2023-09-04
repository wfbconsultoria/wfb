<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Menu_Distribuidor.aspx.vb" Inherits="Menu_Distribuidor" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<uc1:Cabecalho runat="server" ID="Cabecalho" />
<body>
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Distribuidores</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>
<br />
<div id="Corpo">
    <h3><asp:HyperLink ID="lnk_Distribuidores_Grupos" runat="server" CssClass="link_submenu" NavigateUrl="~/Distribuidores_Grupos.aspx">Grupos de Distribuidor</asp:HyperLink></h3>
    <div class="subtitulo"></div>

    <h3><asp:HyperLink ID="lnk_Distribuidores_Pesquisa_RF" runat="server" CssClass="link_submenu" NavigateUrl="~/Distribuidores_Pesquisa_RF.aspx">Incluir novo distribuidor</asp:HyperLink></h3>
    <div class="subtitulo">Pesquisa na Receita Federal</div>

    <h3><asp:HyperLink ID="lnk_Distribuidores_Localizar" runat="server" CssClass="link_submenu" NavigateUrl="~/Distribuidores_Localizar.aspx">Lista de distribuidores</asp:HyperLink></h3>
    <div class="subtitulo"></div>


   
</div>
</form>
</body>
</html>
