<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Logout.aspx.vb" Inherits="Chapeira.Logout" %>

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
        <h4 class="text-uppercase text-primary"><%:ConfigurationManager.AppSettings("App.Name")%></h4>
        <h5 class="text-uppercase"><%:ConfigurationManager.AppSettings("Loja")%></h5>

        <h6 class="text-uppercase text-danger">Log Out efetuado com sucesso</h6>
        
        
        <button runat="server" id="cmdLogout" class="btn btn-lg btn-primary text-uppercase" type="button">Início</button>
        <p class="mt-5 mb-3 text-muted">&copy; WFB Tecnologia 2020</p>
        <uc1:_Footer_Scripts runat="server" ID="_Footer_Scripts" />
    </form>
</body>
</html>