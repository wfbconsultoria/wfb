<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Início</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Início</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>    
<br />
<div id ="Corpo">

    <h3><asp:HyperLink ID="lnk_Demanda_Estoque_Cotas" runat="server" NavigateUrl="~/Menu_Analise_Distribuidor.aspx" CssClass="link_submenu" Enabled="True">Analisar Distribuidor</asp:HyperLink></h3>
    <div class="subtitulo">Grupo de relatórios para Analisar Distribuidores.</div>
    
     <h3><asp:HyperLink ID="lnk_Menu_Listas" runat="server" NavigateUrl="~/Menu_Listas.aspx" CssClass="link_submenu">Listas</asp:HyperLink></h3>

    <h3><asp:HyperLink ID="lnk_Estabelecimentos_Localizar" runat="server" NavigateUrl="~/Estabelecimentos_Localizar.aspx" CssClass="link_submenu">Meus Estabelecimentos</asp:HyperLink></h3>

    <h3><asp:HyperLink ID="lnk_Cotas_Editar" runat="server" NavigateUrl="~/Cotas_Editar.aspx" CssClass="link_submenu">Manutenção de Cotas</asp:HyperLink></h3>
    <div class="subtitulo">Fechado</div>

     <h3><asp:HyperLink ID="lnk_Menu_Operacoes" runat="server" NavigateUrl="~/Menu_operações.aspx" CssClass="link_submenu">Operações</asp:HyperLink></h3>
    <h3><asp:HyperLink ID="lnk_Menu_Relatorios" runat="server" NavigateUrl="~/Menu_relatórios.aspx" CssClass="link_submenu">Relatórios</asp:HyperLink></h3>
  
    <h3><asp:HyperLink ID="lnk_Setorizacao" runat="server" NavigateUrl="~/Setorizacao.aspx" CssClass="link_submenu">Setorização</asp:HyperLink></h3>
    <div class="subtitulo">Aberto para alocação de estabelecimentos TARGET</div>
    
    
</div>
</form>
</body>
</html>