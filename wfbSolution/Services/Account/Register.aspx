<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Account_Register" %>

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
        <div class="container mt-5">

            <div class="row text-center">
                <!-- Título -->
                <div class="col-md-12">
                    <h5 class="text-uppercase">Cadastro</h5>
                    <p>Todos os campos com <span class="text-danger">*</span> são obrigatórios</p>
                </div>
            </div>

            <div class="row">
                <!--Nome-->
                <div class="col-md-4 mt-4">
                    <label>Nome: </label>
                    <span class="text-danger">*</span>
                    <input type="text" id="txtName" runat="server" class="form-control" required="required" placeholder="Insira seu nome" maxlength="20" />
                </div>
                <!--Sobrenome-->
                <div class="col-md-8 mt-4">
                    <label>Sobrenome: </label>
                    <span class="text-danger">*</span>
                    <input type="text" id="txtLastname" runat="server" class="form-control" required="required" placeholder="Insira seu sobrenome" maxlength="70" />
                </div>
            </div>

            <div class="row">
                <!-- Email -->
                <div class="col-md-6 mt-2">
                    <label>E-mail: </label>
                    <span class="text-danger">*</span>
                    <input type="email" id="txtEmail" runat="server" class="form-control" required="required" placeholder="Insira seu e-mail" maxlength="70" />
                </div>
                <!-- Celular -->
                <div class="col-md-6 mt-2">
                    <label>Celular: </label>
                    <span class="text-danger">*</span>
                    <!-- Select / Caixa de texto -->
                    <div class="input-group">
                        <div class="input-group-prepend">
                            <select id="selDdd" runat="server" class="form-control input-group-text bg-transparent" required="required" style="max-width: 80px;">
                            </select>
                        </div>
                        <input type="number" id="txtCellphone" runat="server" class="form-control" required="required" placeholder="Insira seu celular" min="900000000" max="999999999" />
                    </div>
                </div>
            </div>

            <div class="row">
                <!-- CEP -->
                <div class="col-md-8">
                    <label>CEP: </label>
                    <input type="number" id="txtCEP" runat="server" class="form-control" placeholder="Insira seu CEP" max="99999999" onblur="pesquisacep(this.value);" />
                </div>
                <!-- Número -->
                <div class="col-md-2">
                    <label>Número: </label>
                    <input type="text" id="txtNumber" runat="server" class="form-control" placeholder="Ex: 42 B" maxlength="5" />
                </div>
                <!-- Uf -->
                <div class="col-md-2">
                    <label>UF: </label>
                    <input type="text" id="txtUf" runat="server" class="form-control" placeholder="Ex: SP" maxlength="2" />
                </div>
            </div>

            <div class="row">
                <!-- Cidade -->
                <div class="col-md-8">
                    <label>Cidade: </label>
                    <input type="text" id="txtCity" runat="server" class="form-control" placeholder="Insira sua cidade" maxlength="70" />
                </div>
                <!-- Bairro -->
                <div class="col-md-4">
                    <label>Bairro: </label>
                    <input type="text" id="txtNeighborhood" runat="server" class="form-control" placeholder="Insira seu bairro" maxlength="70" />
                </div>
            </div>

            <div class="row">
                <!-- Endereço -->
                <div class="col-md-12">
                    <label>Endereço: </label>
                    <input type="text" id="txtAddress" runat="server" class="form-control" placeholder="Insira seu endereço" maxlength="70" />
                </div>
            </div>

            <div class="row">
                <!-- Complemento -->
                <div class="col-md-12">
                    <label>Complemento: </label>
                    <input type="text" id="txtComplement" runat="server" class="form-control" placeholder="Insira um complemento" maxlength="70" />
                </div>
            </div>

        <div class="row mb-3">
            <!-- Nova senha -->
            <div class="col-md-6 mb-3">
                <label for="txtPassword">Nova Senha</label>
                <span class="text-danger">*</span>
                <input type="password" id="txtPassword" runat="server" class="form-control" required="required" placeholder="Digite sua nova senha" maxlength="100" />
            </div>
            <!-- Confirmar nova senha -->
            <div class="col-md-6 mb-3">
                <label for="txtConfirmPassword">Confirmar Senha</label>
                <span class="text-danger">*</span>
                <input type="password" id="txtConfirmPassword" runat="server" class="form-control" required="required" placeholder="Confirme sua nova senha" onblur="validationConfirmPassword('txtPassword','txtConfirmPassword')" maxlength="100" />
            </div>
        </div>

        <!-- Botões -->
        <div class="row">
            <div class="col-md-12">
                <input type="submit" id="btnRegister" runat="server" class="btn btn-sm btn-primary" title="clique para se cadastrar no sistema" onserverclick="btnRegister_Click" />
                <a id="btnReturn" runat="server" class="btn btn-sm btn-secondary text-light" onserverclick="Login" title="clique para voltar ao login"></a>
            </div>
        </div>
        </div>
    </form>

    <!-- JS (Java script comum a todas as páginas) -->
    <script src="../js/Default/jquery-3.3.1.min.js"></script>
    <script src="../js/Default/bootstrap.min.js"></script>
    <script src="../js/Default/popper.min.js"></script>

    <!-- Buscar cep no correio -->
    <script src="../js/Custom/buscarCep/BuscarCep.js"></script>

    <!-- script para validação dos campos de senha e confirmar senha -->
    <script src="../js/Custom/confirmPassword/confirmPassword.js"></script>
</body>
</html>
