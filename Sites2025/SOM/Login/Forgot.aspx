<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Forgot.aspx.vb" Inherits="Login_Forgot" %>

<%@ Register Src="~/Shared/Scripts_Footer.ascx" TagPrefix="uc1" TagName="Scripts_Footer" %>
<%@ Register Src="~/Shared/Scripts_Header.ascx" TagPrefix="uc1" TagName="Scripts_Header" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <uc1:Scripts_Header runat="server" ID="Scripts_Header" />
    <link href="signin.css" rel="stylesheet" />
    <title>Recover Password &nbsp<%:ConfigurationManager.AppSettings("App.Customer")%>Login</title>
</head>
<body>
    <main class="form-signin w-100 m-auto">

        <form id="frmForgot" runat="server">

            <img class="form-control" src="../Images/_Logo.png" alt="" width="210" height="90" />
            <br />
            <div class="form-floating">
                <input runat="server" id="txtEmail" type="email" class="form-control" placeholder="name@example.com" required="required" />
                <label for="txtEmail">Email address</label>
            </div>

            <div class="checkbox mb-3">
                <a href="Login.aspx">login</a>
            </div>

            <button runat="server" id="cmdRecover" class="w-100 btn btn-lg btn-primary" type="submit" causesvalidation="true">Recover Password</button>
            <p class="mt-5 mb-3 text-muted">&copy; <%:ConfigurationManager.AppSettings("App.Owner") %></p>

            <uc1:Scripts_Footer runat="server" ID="Scripts_Footer" />
        </form>
    </main>
</body>
</html>
