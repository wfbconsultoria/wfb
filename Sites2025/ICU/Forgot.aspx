<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Forgot.aspx.vb" Inherits="Forgot" %>

<%@ Register Src="~/Scripts_Header.ascx" TagPrefix="uc1" TagName="Scripts_Header" %>
<%@ Register Src="~/Scripts_Footer.ascx" TagPrefix="uc1" TagName="Scripts_Footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <uc1:Scripts_Header runat="server" ID="Scripts_Header" />
    <link href="css/signin.css" rel="stylesheet" />
    <title></title>

</head>
<body>
    <main class="form-signin w-100 m-auto">

        <form id="frmLogin" runat="server">
            
            <img class="form-control" src="Images/_Logo.png" alt="" width="252" height="66" />
            <div class="form-floating">
                <input runat="server" id="txtEmail"  type="email" class="form-control" placeholder="name@example.com" required="required" />
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
