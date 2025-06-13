<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<%@ Register Src="~/Scripts_Header.ascx" TagPrefix="uc1" TagName="Scripts_Header" %>
<%@ Register Src="~/Scripts_Footer.ascx" TagPrefix="uc1" TagName="Scripts_Footer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <uc1:Scripts_Header runat="server" ID="Scripts_Header" />
    <link href="css/signin.css" rel="stylesheet" />
    <title>Login</title>
</head>

<body>
    <main class="form-signin w-100 m-auto">
        <form id="frmLogin" runat="server">

            <img class="form-control" src="Images/LOGO_ICU.png" alt="" width="240" height="120" />
            <div class="form-floating">
                <input runat="server" id="txtEmail" type="email" class="form-control" placeholder="name@example.com" required="required" />
                <label for="txtEmail">Email address</label>
            </div>

            <div class="form-floating">
                <input runat="server" id="txtPassword" type="password" class="form-control" placeholder="Password" required="required" />
                <label for="txtPassword">Senha</label>
            </div>

            <button runat="server" id="cmdLogin" class="w-100 btn btn-lg btn-primary" type="submit" causesvalidation="true">Sign in</button>
            
            <%-- LINKS --%>
            <a class="link" data-bs-toggle="collapse" href="#div_RESET_PASSWORD" role="button" aria-expanded="false" aria-controls="div_RESET_PASSWORD">trocar senha</a>
            <a class="link" href="Forgot.aspx" role="button" aria-expanded="false" aria-controls="">recuperar senha</a>
            <%-- LINKS --%>

            <%-- RESET_PASSWORD --%>
            <div id="div_RESET_PASSWORD" class="collapse">
                <div class="row g-2">
                    <div class="form-floating">
                        <input runat="server" id="NewPassword" type="text" class="form-control" placeholder="Password" required="required" />
                        <label for="NewPassword">Nova Senha</label>
                    </div>
                </div>
                
                <div class="row g-2">
                    <div class="form-floating">
                        <input runat="server" id="NewPasswordConfirm" type="password" class="form-control" placeholder="Confirm Password" required="required"/>
                        <label for="NewPasswordConfirm">Confirmar Nova Senha</label>
                    </div>
                </div>

                <button runat="server" id="cmdChangePassword" class="w-100 btn btn-lg btn-primary" type="submit" causesvalidation="true">Trocar Senha</button>
                <p class="mt-5 mb-3 text-muted">&copy; <%:ConfigurationManager.AppSettings("App.Owner") %></p>
            </div>
            <uc1:Scripts_Footer runat="server" ID="Scripts_Footer" />
        </form>
    </main>
</body>
</html>


