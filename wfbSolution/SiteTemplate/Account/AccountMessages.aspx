<%@ Page Title="Account Messages" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="AccountMessages.aspx.vb" Inherits="SiteTemplate.AccountMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel runat="server" ID="pnl_Message" CssClass="alert alert-danger">
        <h4 class="alert-heading">
            <asp:Literal ID="ltr_Title" runat="server"></asp:Literal></h4>
        <p>
            <asp:Literal ID="ltr_Message" runat="server"></asp:Literal>
        </p>
        <hr>
        <p class="mb-0">
            <asp:LinkButton ID="cmdLogin" runat="server" CssClass="alert-link">Fazer logon ou registrar novo usuario</asp:LinkButton>
            <asp:LinkButton ID="cmdConfirm" runat="server" CssClass="alert-link">Receber e-mail com link para confirmação do seu usuario</asp:LinkButton>
        </p>
    </asp:Panel>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
