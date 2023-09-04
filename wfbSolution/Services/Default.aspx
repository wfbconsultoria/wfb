<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- tags para padronizar a página -->
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title><%:ConfigurationManager.AppSettings["ApplicationTitle"]%></title>
    <link rel="shortcut icon" href="<%:ConfigurationManager.AppSettings["ApplicationIcon"]%>" />

    <!-- tags para auxiliar na busca -->
    <meta name="author" content="<%:ConfigurationManager.AppSettings["MetaDeveloper"]%>" />
    <meta name="description" content="<%:ConfigurationManager.AppSettings["MetaDescription"]%>" />
    <meta name="keywords" content="<%:ConfigurationManager.AppSettings["MetaKeywords"]%>" />


    <!-- CSS (css comum para todas as págians) -->
    <link href="css/Default/bootstrap.min.css" rel="stylesheet" />
    <link href="css/Custom/font-awesome/css/fontawesome-all.min.css" rel="stylesheet" />
    <link href="css/Custom/Custom.css" rel="stylesheet" />
</head>
<body class="bg-light">
    <form id="form1" runat="server">
        <!-- Menu -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
            <!-- Sigla -->
            <a class="navbar-brand" href="#"><%: ConfigurationManager.AppSettings["ApplicationInitials"] + " - " %> <span class="font-15">Home</span></a>
            <!-- Botão para celular -->
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarWFB" aria-controls="navbarWFB" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <!-- Conteúdo do menu -->
            <div class="collapse navbar-collapse" id="navbarWFB">
                <ul class="navbar-nav navbar-right">
                    <!-- Home -->
                    <li class="nav-item mr-2">
                        <a class="nav-link" href="Account/Login.aspx">Login</a>
                    </li>
                </ul>
            </div>
        </nav>

        <div class="conteudo">
            <!-- Titulo -->
            <h1 class="text-center pt-3">Monitoramento</h1>
            <h3 class="text-center">Monitoramento dos servidores usados na WFB Consultoria</h3>

            <div class="row mt-5">
                <!-- Servidores -->
                <div class="col-md-12">
                    <!-- subtitulo -->
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:Timer ID="tmrServers" runat="server" Enabled="true" Interval="300000" OnTick="tmrServers_Tick">

                    </asp:Timer>
                    <!-- Lista de servidores -->
                    <div class="row text-center">
                        <div class="col-md-12">
                            <div id="dvServidores" runat="server">

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Rodapé da página -->
        <div class="footer fixed-bottom border-top p-2 bg-white">
            <!-- Desenvolvedor da aplicação e ano de desenvolvimento -->
            <div class="float-right">
                <small class="text-muted">&copy <%: ConfigurationManager.AppSettings["Developer"] + " - " + ConfigurationManager.AppSettings["Year"] %>
                </small>
            </div>
            <!-- Aplicação -->
            <label runat="server" class="text-secondary"><%: ConfigurationManager.AppSettings["ApplicationName"] %></label>
        </div>
    </form>

    <!-- JS (Java script comum a todas as páginas) -->
    <script src="js/Default/jquery-3.3.1.min.js"></script>
    <script src="js/Default/popper.min.js"></script>
    <script src="js/Default/bootstrap.min.js"></script>
</body>
</html>
