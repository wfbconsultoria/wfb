<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Menu_Setorizacao.aspx.vb" Inherits="Menu_Setorizacao" %>

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
    <div id ="Titulo_Pagina_Cabecalho">Setorização</div>
    <div id ="Titulo_Pagina_Links">
        <a href="#">Help</a>
    </div>
</div>
<br />
<div id ="Corpo">
    <h3><asp:HyperLink ID="lnk_Estabelecimentos_Setorizacao_Localizar" runat="server" NavigateUrl="~/Estabelecimentos_Setorizacao_Localizar.aspx" CssClass="link_submenu" Enabled="True">Manutenção de Setor</asp:HyperLink></h3>
    <div class="subtitulo">Painel de manutenção no setor do representante, possibilita a transferência ou exclusão de um cliente do setor.</div>
    
    <h3><asp:HyperLink ID="lnk_Estabelecimentos_Setorizacao_NS" runat="server" NavigateUrl="~/Estabelecimentos_Setorizacao_NS.aspx" CssClass="link_submenu" Enabled="True">Setorização de Clientes órfãos</asp:HyperLink></h3>
    <div class="subtitulo">Painel para setorização de clientes não setorizados, permite setorizar estabelcimentos órfãos.</div>

    <h3><asp:HyperLink ID="Estabelecimentos_Setorizacao_Novo_Setor" runat="server" NavigateUrl="~/Estabelecimentos_Setorizacao_Novo_Setor.aspx" CssClass="link_submenu" Enabled="True" Visible="false">Novo Setor</asp:HyperLink></h3>
    <div class="subtitulo"></div>

</div>
</form>
</body>
</html>
