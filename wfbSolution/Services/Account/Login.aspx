<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- tags para padronizar a página -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title><%:ConfigurationManager.AppSettings["ApplicationTitle"]%></title>
    <link rel="shortcut icon" href="../<%:ConfigurationManager.AppSettings["ApplicationIcon"]%>" />

    <!-- tags para auxiliar na busca -->
    <meta name="author" content="<%:ConfigurationManager.AppSettings["MetaDeveloper"]%>" />
    <meta name="description" content="<%:ConfigurationManager.AppSettings["MetaDescription"]%>" />
    <meta name="keywords" content="<%:ConfigurationManager.AppSettings["MetaKeywords"]%>" />


    <!-- CSS (css comum para todas as págians) -->
    <link href="../css/Default/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/Custom/font-awesome/css/fontawesome-all.min.css" rel="stylesheet" />
    <link href="../css/Custom/Custom.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- conteudo do login -->
            <div class="vertical-center mr-auto ml-auto login">
                <!-- Titulo -->
                <div class="row text-center">
                    <div class="col-sm-12">
                        <img class="img-fluid" src="../<%:ConfigurationManager.AppSettings["ApplicationLogo"] %>" />
                        <h5>Login</h5>
                    </div>
                </div>
                <!-- Usuário -->
                <div class="row mt-3">
                    <div class="col-sm-12">
                        <input type="email" id="txtEmail" runat="server" class="form-control" required="required" placeholder="Insira seu e-mail" maxlength="50" />
                    </div>
                </div>
                <!-- Senha -->
                <div class="row mt-3">
                    <div class="col-sm-12">
                        <input type="password" id="txtPassword" runat="server" class="form-control" required="required" placeholder="Insira sua senha" maxlenght="100" />
                    </div>
                </div>
                <!-- Botões -->
                <div class="row mt-4 text-center">
                    <div class="col-sm-12">
                        <!-- Logar -->
                        <input type="submit" id="btnLogin" runat="server" class="btn btn-sm btn-primary" title="clique aqui para entrar no sistema" onserverclick="btnLogin_Click" />
                        <!-- Cadastrar -->
                        <a id="btnRegister" runat="server" class="btn btn-sm btn-secondary text-light" title="clique aqui para se registrar" onserverclick="btnRegister_Click"></a>
                    </div>
                </div>
                <!-- Recuperar senha -->
                <div class="row text-center">
                    <div class="col-sm-12">
                        <a href="RecoverPassword.aspx" id="btnRecoverPassword" runat="server" class="text-muted" title="clique aqui para recuperar sua senha"></a><br />
                        <!-- Voltar -->
                        <a href="../default.aspx" id="btnReturn" runat="server" class="text-muted" title="clique aqui para retornar ao inicio"></a>
                    </div>
                </div>
            </div>
        </div>

    </form>

    <!-- JS (Java script comum a todas as páginas) -->
    <script src="../js/Default/jquery-3.3.1.min.js"></script>
    <script src="../js/Default/bootstrap.min.js"></script>
    <script src="../js/Default/popper.min.js"></script>
</body>
</html>
