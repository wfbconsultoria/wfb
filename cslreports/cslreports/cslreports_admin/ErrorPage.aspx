<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ErrorPage.aspx.vb" Inherits="ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="icon" href="Images/Logo.png" />
    <title>Error</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/pricing.css" rel="stylesheet" />
    <link href="Content/form-validation.css" rel="stylesheet" />
    <link href="Content/MyStyle9.css" rel="stylesheet" />
    <style>
        b{
            font-size: 18px;
            margin-right: 10px;
        }
    </style>
</head>
<body>
    <form id="frmError" runat="server">
    <div class="container">
    
        <div class="pricing-header px-3 py-3 pt-md-5 pb-md-4 mx-auto">
        <h1 class="display-4 text-center"><%:ConfigurationManager.AppSettings("app.name") %></h1>
        <h2 class="text-danger text-center" style="margin-bottom: 50px;">Erro</h2>
        <b>Nome do Erro: </b><asp:Label ID="lbl_ErrDescription" runat="server" Text="Nome do problema" CssClass="text-danger"></asp:Label> <br />
        <b>Descrição do Erro: </b><asp:Label ID="lbl_ErrMessage" runat="server" Text="Descrição do problema"></asp:Label><br />
        <b>Localização do Erro: </b><asp:Label ID="lbl_ErrLocation" runat="server" Text="Local do problema"></asp:Label> <br />

    </div>
        

    </div>
    </form>
</body>
</html>