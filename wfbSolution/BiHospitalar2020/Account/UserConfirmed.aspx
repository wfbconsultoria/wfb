<%@ Page Title="Aguardar liberação de acesso" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master_Public.Master" CodeBehind="UserConfirmed.aspx.vb" Inherits="BiHospitalar2020.UserConfirmed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <div class="container">
        <h3 class="alert alert-warning">Aguardar a liberação de acesso</h3>
        <h4>Seu acesso está aguardando autorização do administrador</h4>
        <h4>Você receberá um e-mail informando quando estiver liberado</h4>
        <h4>Caso tenha dúvidas envie mensagem, informando seu nome e e-mail registrado para <%:ConfigurationManager.AppSettings("App.Support.Email") %></h4>
        <br />
        <asp:HyperLink ID="cmdLogOut" runat="server" CssClass="btn btn-danger" NavigateUrl="~/Account/LogOut.aspx">Log Out</asp:HyperLink>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
