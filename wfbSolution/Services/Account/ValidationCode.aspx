<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValidationCode.aspx.cs" Inherits="Account_ValidationCode" %>

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
            <!-- conteudo da validação de senha -->
            <div class="vertical-center mr-auto ml-auto login">
                <!-- Titulo -->
                <div class="row text-center">
                    <div class="col-sm-12">
                        <img class="img-fluid" src="../<%:ConfigurationManager.AppSettings["ApplicationLogo"] %>" />
                        <h5>Validação da conta</h5>
                    </div>
                </div>
                <!-- Usuário -->
                <div class="row mt-3">
                    <div class="col-sm-12">
                        <input type="email" id="txtEmail" runat="server" class="form-control" required="required" placeholder="Insira seu e-mail" maxlength="50" disabled="disabled" hidden="hidden"/>
                    </div>
                </div>
                <!-- Código -->
                <div class="row mt-3">
                    <div class="col-sm-12">
                        <input type="text" id="txtCode" runat="server" class="form-control" required="required" placeholder="Insira seu código aqui" maxlength="100"/>
                    </div>
                </div>
                <!-- Botões -->
                <div class="row mt-4 text-center">
                    <div class="col-sm-12">
                        <!-- Recuperar senha -->
                        <input type="submit" id="btnValidate" runat="server" class="btn btn-sm btn-primary" title="clique aqui para validar sua conta" onserverclick="btnValidate_Click" />
                        <!-- Cadastrar -->
                        <a id="btnReturn" runat="server" class="btn btn-sm btn-secondary text-light" title="clique aqui para voltar ao login" onserverclick="btnReturn_Click"></a>
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
