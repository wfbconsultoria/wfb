<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrorPage.aspx.cs" Inherits="ErrorPage" %>

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
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <div class="jumbotron">
                <!-- Cabeçalho -->
                <div class="row text-center">
                    <div class="col-md-12">
                        <!-- Nome da aplicação -->
                        <h2><%:ConfigurationManager.AppSettings["ApplicationName"]%></h2>
                        <!-- título da página de erro-->
                        <%:ConfigurationManager.AppSettings["ErrorPage"]%>
                    </div>
                </div>
                <!-- Nome do erro -->
                <div class="row mt-5">
                    <strong>Erro: </strong>
                    <label runat="server" id="lblErrNumber"></label>
                    &nbsp
                    <label runat="server" id="lblErrName"></label>
                </div>

                <!-- Descrição do erro -->
                <div class="row">
                    <strong>Descrição: </strong>
                    <label runat="server" id="lblErrDescription"></label>
                </div>

                <!-- Localização do erro -->
                <div class="row">
                    <strong>Local: </strong>
                    <label runat="server" id="lblErrLocation"></label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
