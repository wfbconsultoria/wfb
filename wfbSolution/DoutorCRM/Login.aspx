<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="DoutorCRM.Login" %>

<%@ Register Src="~/App_Controls/ScriptsHeader.ascx" TagPrefix="uc1" TagName="ScriptsHeader" %>
<%@ Register Src="~/App_Controls/ScriptsFooter.ascx" TagPrefix="uc1" TagName="ScriptsFooter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <uc1:ScriptsHeader runat="server" ID="ScriptsHeader" />
    <link href="Css/Login.css" rel="stylesheet" />
    <title>Login</title>
</head>
<body class="text-center">
    <form id="frm_LOGIN" runat="server" class="form-signin">
        <img class="mb-4" src="Images/Logo_Login.png" alt="" width="216" height="72" />

        <label for="inputEmail" class="sr-only">Endereço de email</label>
        <input runat="server" type="email" id="txt_EMAIL" class="form-control" placeholder="Seu email" required="required" autofocus="autofocus" />
        <label for="inputPassword" class="sr-only">Senha</label>
        <input runat="server" type="password" id="txt_SENHA" class="form-control" placeholder="Senha" required="required" />

        <button runat="server" id="cmd_LOGIN" class="btn btn-lg btn-primary btn-block" type="submit">Login</button>
        <p class="mt-5 mb-3 text-muted">&copy; <%:ConfigurationManager.AppSettings("App.Owner") %></p>

    </form>
    <uc1:ScriptsFooter runat="server" ID="ScriptsFooter" />
</body>
</html>
