<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SignOut.aspx.vb" Inherits="cslreports.SignOut" %>

<%@ Register Src="~/Scripts_Header.ascx" TagPrefix="uc1" TagName="Scripts_Header" %>
<%@ Register Src="~/Scripts_Footer.ascx" TagPrefix="uc1" TagName="Scripts_Footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <uc1:Scripts_Header runat="server" ID="Scripts_Header" />
    <title>Sign Out</title>
</head>
<body class="container">
    <form id="frmMain" runat="server">
        <br />
        <div class="jumbotron">
            <h1><%:ConfigurationManager.AppSettings("App.Name") %></h1>
            <hr />
            <h3 class= "text-danger">Usuário desconectado com sucesso !</h3>
            <input id="btn_Login" runat="server" type="button" value="Entrar" class="btn btn-success" />
        </div>

        <uc1:Scripts_Footer runat="server" ID="Scripts_Footer" />
    </form>
</body>
</html>
