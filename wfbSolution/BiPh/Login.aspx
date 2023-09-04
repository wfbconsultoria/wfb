<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="BiPh.Login" %>

<%@ Register Src="~/Master_Footer.ascx" TagPrefix="uc1" TagName="Master_Footer" %>
<%@ Register Src="~/Master_Header.ascx" TagPrefix="uc1" TagName="Master_Header" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <uc1:Master_Header runat="server" ID="Master_Header" />
    <link href="Login.css" rel="stylesheet" />
    <title>Login</title>
</head>
<body>
    <form id="frm_Login" class="form-signin" runat="server">
        <div style="text-align:center"><img class="mb-4" src="Images/_Logo.svg" alt="" /></div>
        
        <label for="inputEmail" class="sr-only">E-mail</label>
        <input runat="server" type="email" id="txt_Email" class="form-control" placeholder="Seu email" required="required" />
        <label for="inputPassword" class="sr-only">Senha</label>
        <input runat="server" type="password" id="txt_Password" class="form-control" placeholder="Senha" required="required" />
        <div class="checkbox mb-3">
            <label>
                <a runat="server" id="cmd_Forgot" class="d-inline-block g-font-size-12 mb-2" href="#">Esqueci a senha</a>
            </label>
        </div>
        <button runat="server" id="cmd_Login" class="btn btn-lg btn-primary btn-block" type="button">Login</button>
        <a runat="server" class="btn btn-sm btn-secondary btn-block" href="Default.aspx">Continuar sem login</a>
        
        <uc1:Master_Footer runat="server" ID="Master_Footer" />
    </form>
</body>
</html>
