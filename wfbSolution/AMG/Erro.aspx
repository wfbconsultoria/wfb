<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Erro.aspx.vb" Inherits="Erro" %>

<%@ Register Src="~/Scripts_Header.ascx" TagPrefix="uc1" TagName="Scripts_Header" %>
<%@ Register Src="~/Scripts_Footer.ascx" TagPrefix="uc1" TagName="Scripts_Footer" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <uc1:Scripts_Header runat="server" ID="Scripts_Header" />
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
        <uc1:Scripts_Footer runat="server" ID="Scripts_Footer" />
    </form>
</body>
</html>
