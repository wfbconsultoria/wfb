<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Erro.aspx.vb" Inherits="Erro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title>Erro</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1 class="display-4 text-center"><%:ConfigurationManager.AppSettings("App.Name") %></h1>
            <h2 class="text-danger text-center" style="margin-bottom: 50px;">Erro</h2>
            <b>Nome do Erro: </b>
            <asp:Label ID="lbl_ErrDescription" runat="server" Text="Nome do problema" CssClass="text-danger"></asp:Label>
            <br />
            <b>Descrição do Erro: </b>
            <asp:Label ID="lbl_ErrMessage" runat="server" Text="Descrição do problema"></asp:Label><br />
            <b>Localização do Erro: </b>
            <asp:Label ID="lbl_ErrLocation" runat="server" Text="Local do problema"></asp:Label>
            <br />
        </div>
        <!-- script bootstrap -->
        <script src="Scripts/bootstrap.bundle.min.js"></script>
    </form>
</body>
</html>
