<%@ Page Title="Usuário" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="User.aspx.vb" Inherits="BiPh.User" %>
<%@ Register Src="~/Page_Header.ascx" TagPrefix="uc1" TagName="Page_Header" %>
<%@ Register Src="~/Page_Footer.ascx" TagPrefix="uc1" TagName="Page_Footer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body_Content" runat="server">
    <!--Cabeçalho da página -->
    <uc1:Page_Header runat="server" ID="Page_Header" />
    
    
    <uc1:Page_Footer runat="server" ID="Page_Footer" />
    <!--Datasources -->
    <asp:SqlDataSource ID="dtsUser" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'></asp:SqlDataSource>
</asp:Content>
