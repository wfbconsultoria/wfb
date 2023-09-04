<%@ Page Title="Controle de Acesso" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master_Public.Master" CodeBehind="AccountMessages.aspx.vb" Inherits="BiHospitalar2020.AccountMessages" %>

<%@ Register Src="~/_Page_Header_Public.ascx" TagPrefix="uc1" TagName="_Page_Header_Public" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:_Page_Header_Public runat="server" ID="_Page_Header_Public" />
    <asp:Panel runat="server" ID="pnl_Message" CssClass="alert alert-danger">
        <h5 class="alert-heading">
            <asp:Literal ID="ltr_Title" runat="server"></asp:Literal></h5>
        <p>
            <asp:Literal ID="ltr_Message" runat="server"></asp:Literal>
        </p>
        <hr/>
        <p class="mb-0">
            <asp:LinkButton ID="cmdLogin" runat="server" CssClass="">Fazer LogIn ou registrar novo usuario</asp:LinkButton>
            <asp:LinkButton ID="cmdConfirm" runat="server" CssClass="alert-link">Re enviar e-mail para confirmação do seu registro</asp:LinkButton>
            <asp:LinkButton ID="cmdProfile" runat="server" CssClass="alert-link">Atualizar Perfil</asp:LinkButton>
        </p>
    </asp:Panel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
