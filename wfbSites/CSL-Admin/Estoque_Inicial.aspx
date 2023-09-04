<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estoque_Inicial.aspx.vb" Inherits="Estoque_Inicial" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Estoque Distribuidores</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    </head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho"></div>
    <div id ="Titulo_Pagina_Links">
    </div>
</div>
<br />
<div id ="Corpo">
    <asp:Button ID="cmd_Atualizar_Estoque_Distribuidor" runat="server" Text="Atualizar Estoque Inicial por Distribuidores" />
&nbsp;&nbsp;
    <asp:Button ID="cmd_Atualizar_Estoque_Total" runat="server" Text="Atualizar Estoque Inicial Total" />
&nbsp;&nbsp;
    <asp:Button ID="cmd_Atualizar_Estoque_Vazio" runat="server" Text="Atualizar Estoque Vazio" />

</form>
     </body>
    
</html>
