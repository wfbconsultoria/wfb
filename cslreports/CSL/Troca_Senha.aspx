<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Troca_Senha.aspx.vb" Inherits="Troca_Senha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Solicitar troca de senha</title>
   <link href="App_Themes/MasterTheme/Master.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
 <div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Solicitar nova senha</div>
    <div id ="Titulo_Pagina_Links">
        <asp:HyperLink ID="lnk_Help" runat="server" NavigateUrl="~/Default_Help.aspx" Target="_blank" Visible="false">Ajuda</asp:HyperLink>&nbsp
        <asp:HyperLink ID="lnk_Logout" runat="server" NavigateUrl="~/Login.aspx">Login</asp:HyperLink>
    </div>
</div>
<br />
<div id ="Corpo">
    <p>&nbsp;</p>
    <p>Se esqueceu sua senha ou este é o seu primeiro acesso ao <%Response.Write(ConfigurationManager.AppSettings("NOME_SISTEMA").ToString)%></p>
    <br />
    <p>Digite o E-MAIL utilizado para acesso ao sistema</p>
    <p><asp:TextBox ID="txt_EMAIL" runat="server" Width="50%"></asp:TextBox></p>
    <br />
    <p>Clique em</p>
    <p><asp:Button ID="cmd_Troca_Senha" runat="server" CssClass="buton_gravar" Text="Solicitar troca de senha" /></p>
    <p>O sistema irá gerar uma senha aleatória, liberada para acesso, que será enviada para o seu email.</p>
    <br />
    <p>
        <span>
            Ou clique
            <asp:HyperLink ID="lnk_Login" runat="server" NavigateUrl="~/Login.aspx" style="color: #0000FF">aqui</asp:HyperLink>
            &nbsp;para retornar a tela de login
        </span>
   </p>
</div>
 </form>
</body>
</html>
