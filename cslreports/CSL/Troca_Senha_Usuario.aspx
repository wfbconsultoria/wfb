<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Troca_Senha_Usuario.aspx.vb" Inherits="Troca_Senha_Usuario" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Troca Senha</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
    <uc1:Cabecalho runat="server" id="Cabecalho" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Troca Senha</div>
    <div id ="Titulo_Pagina_Links">
        
    </div>
</div>
<br />
<div id ="Corpo"> 
    <br />   
    <p>
        <b>Digite sua nova senha</b>
        <p><asp:TextBox ID="txt_Senha" runat="server" TextMode="Password"></asp:TextBox></p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="Obrigatório" ControlToValidate="txt_Senha"></asp:RequiredFieldValidator>
    </p>
    <p>
        <b>Confirme a senha</b>
        <p><asp:TextBox ID="txt_Senha_Confirma" runat="server" TextMode="Password"></asp:TextBox></p>
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToCompare="txt_Senha_Confirma" ControlToValidate="txt_Senha" 
            Display="Dynamic" ErrorMessage="As senhas digitadas são diferentes" Width="50%"></asp:CompareValidator>
    </p>
    <br />
    <p>
        <asp:Button ID="cmd_Gravar" runat="server" CssClass="buton_gravar" Text="Gravar" />
    </p>
    </div>

</form>
</body>
</html>
