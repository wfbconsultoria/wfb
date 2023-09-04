<%@ Page Title="Usuário Bloqueado" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master_Public.Master" CodeBehind="UserLocked.aspx.vb" Inherits="BiHospitalar2020.UserLocked" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <div class="container">
        <h3 class="alert alert-danger">Acesso bloqueado!</h3>
        <h4>Seu usuário foi bloqueado pelo administrador</h4>
        <h4>Envie mensagem informando seu nome e e-mail registrado para <%:ConfigurationManager.AppSettings("App.Support.Email") %> e solicite o desbloqueio </h4>
        <br />
        <asp:HyperLink ID="cmdLogOut" runat="server" CssClass="btn btn-danger" NavigateUrl="~/Account/LogOut.aspx">Log off</asp:HyperLink>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
