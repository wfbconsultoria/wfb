<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Chapeira.Login" %>

<%@ Register Src="~/_Header_Scripts.ascx" TagPrefix="uc1" TagName="_Header_Scripts" %>
<%@ Register Src="~/_Footer_Scripts.ascx" TagPrefix="uc1" TagName="_Footer_Scripts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <uc1:_Header_Scripts runat="server" ID="_Header_Scripts" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/sigIn.css" rel="stylesheet" />
    <title>Login</title>
</head>
<body class="text-center">
    <form id="frmLogin" runat="server" class="form-signin"> 
        <img class="mb-4" src="Images/Logo_Retangulo.png" alt="" />
        <h3 class="text-uppercase text-primary"><%:ConfigurationManager.AppSettings("App.Name")%></h3>
        <h4 class="text-uppercase" runat="server" id="Loja">nome da Loja</h4>
        <label for="inputEmail" class="sr-only">Email</label>
        <input runat="server" type="email" id="Email" class="form-control" placeholder="Seu email" autofocus="autofocus" />
        <label for="inputPassword" class="sr-only">Senha</label>
        <input runat="server" type="password" id="Password" class="form-control" placeholder="Senha"  />
        <button runat="server" id="cmdLogin" class="btn btn-lg btn-primary text-uppercase" type="button">Login</button>
        <button runat="server" id="cmdHome" class="btn btn-lg btn-link " type="button">Continuar sem login</button>
        <button runat="server" id="cmdRecoveryPassword" class="btn btn-lg btn-link " type="button">Recuperar Senha</button>
        <p class="mt-5 mb-3 text-muted">&copy; WFB Tecnologia 2020</p>
        <uc1:_Footer_Scripts runat="server" ID="_Footer_Scripts" />
    </form>
</body>
</html>
