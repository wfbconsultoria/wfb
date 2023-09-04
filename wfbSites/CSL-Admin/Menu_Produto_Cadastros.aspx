<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Menu_Produto_Cadastros.aspx.vb" Inherits="Menu_Produto_Cadastros" %>

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
    <div id ="Titulo_Pagina_Cabecalho">Operações</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>
<br />
<div id ="Corpo">
    
    <h3><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Produtos_Cadastro_Produto.aspx" CssClass="link_submenu" Enabled="True">Cadastro de Produto</asp:HyperLink></h3>
    <div class="subtitulo"></div>

     <h3><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Produtos_Cadastro_Linha.aspx" CssClass="link_submenu" Enabled="True">Cadastro de Linha de Produto</asp:HyperLink></h3>
    <div class="subtitulo"></div>

    <h3><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Produtos_Cadastro_Grupo.aspx" CssClass="link_submenu" Enabled="True">Cadastro de Grupo de Produto</asp:HyperLink></h3>
    <div class="subtitulo"></div>

    <h3><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Produtos_Cadastro_Divisao.aspx" CssClass="link_submenu" Enabled="True">Cadastro de Divisão de Produto</asp:HyperLink></h3>
    <div class="subtitulo"></div>

    <h3><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Produtos_Cadastro_Embalagem.aspx" CssClass="link_submenu" Enabled="True">Cadastro de Embalagem de Produto</asp:HyperLink></h3>
    <div class="subtitulo"></div>

    <h3><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Produtos_Cadastro_Unidade.aspx" CssClass="link_submenu" Enabled="True">Cadastro de Unidade de Produto</asp:HyperLink></h3>
    <div class="subtitulo"></div>
    
</div>
</form>
</body>

</html>
