<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Troca_Senha_Usuario.aspx.vb" Inherits="Troca_Senha_Usuario" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Trocar Senha</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Trocar Senha</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>    
<br />
<div id ="Corpo">
    <br />     
    <p>
        Digite sua nova senha
        <br />
        <asp:TextBox ID="txt_Senha" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Obrigatório" ControlToValidate="txt_Senha"></asp:RequiredFieldValidator>
    </p>
    <p>
        Confirme a senha
        <br />
        <asp:TextBox ID="txt_Senha_Confirma" runat="server"></asp:TextBox>
        &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txt_Senha_Confirma" ControlToValidate="txt_Senha" 
        Display="Dynamic" ErrorMessage="As senhas digitadas são diferentes" Width="50%"></asp:CompareValidator>
    </p>
    <p>
        <asp:Button ID="cmd_Gravar" runat="server" Text="Gravar" />
    </p>
</div>
</form>
</body>
</html>
