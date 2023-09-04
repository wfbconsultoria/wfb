<%@ Page Title="Log Out" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master_Public.Master" CodeBehind="LogOut.aspx.vb" Inherits="CannaMedsBrasil.LogOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="container alert alert-info">
        <h3>Grato por acessar <%:ConfigurationManager.AppSettings("App.Name").ToString %></h3>
    </div>
    <br />
    <asp:HyperLink ID="cmdLogin" runat="server" CssClass="btn btn-primary" NavigateUrl="~/Account/Login.aspx">Log In</asp:HyperLink>
</asp:Content>

