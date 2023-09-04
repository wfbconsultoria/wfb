<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PageError.aspx.vb" Inherits="SiteEmpty.PageError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Erro</title>
</head>
<body>
    <form id="frm_Error" runat="server">
        <div>
    <h1 class="display-4 text-center"><%:ConfigurationManager.AppSettings("App.Name") %></h1>
        <h2 class="text-danger text-center" style="margin-bottom: 50px;">Erro</h2>
        <b> Nome Do Erro: </b><asp:Label ID = "lbl_ErrDescription" runat="server" Text="Nome do problema" CssClass="text-danger"></asp:Label> <br />
        <b> Descrição Do Erro: </b><asp:Label ID = "lbl_ErrMessage" runat="server" Text="Descrição do problema"></asp:Label><br />
        <b> Localização Do Erro: </b><asp:Label ID = "lbl_ErrLocation" runat="server" Text="Local do problema"></asp:Label><br />
    </div>
    </form>
</body>
</html>
