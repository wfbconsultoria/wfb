<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PageError.aspx.vb" Inherits="Chapeira_Eplanner.PageError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <title>Erro</title>
</head>
<body>
    <div class="container">
        <form id="frm_Error" runat="server">
            <br />
            <div class="jumbotron alert-danger container">
                <h3 class="text-primary text-uppercase"><%:ConfigurationManager.AppSettings("App.Name") %>&nbsp;&nbsp;<span class="text-danger">Erro</span></h3>
                <h5 class="text-primary text-uppercase"><%:ConfigurationManager.AppSettings("Loja") %></h5>
                <div class="row"><b>Nome Do Erro:
                    <asp:Label ID="lbl_ErrDescription" runat="server" Text="Nome do problema" CssClass="text-danger"></asp:Label></b></div>
                <div class="row"><b>Descrição Do Erro: </b>
                    <asp:Label ID="lbl_ErrMessage" runat="server" Text="Descrição do problema"></asp:Label></div>
                <div class="row"><b>Localização Do Erro: </b>
                    <asp:Label ID="lbl_ErrLocation" runat="server" Text="Local do problema"></asp:Label></div>
                <div class="row"><b>IP Origem: </b>
                    <asp:Label ID="lbl_IP" runat="server" Text="IP Origem"></asp:Label></div>
                <br />
                <div class="row"><a href="Default.aspx" class="btn btn-primary ">Ir para início e recomeçar</a></div>
            </div>

        </form>
    </div>
</body>
</html>
