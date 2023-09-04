<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master_Public.Master" CodeBehind="_Page_Error.aspx.vb" Inherits="CannaMedsBrasil._Page_Error" %>

<%@ Register Src="~/_Page_Header_Public.ascx" TagPrefix="uc1" TagName="_Page_Header_Public" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:_Page_Header_Public runat="server" ID="_Page_Header_Public" />
    <%--Conteudo da página--%>
    <div>
        <h1 class="display-4 text-center"><%:ConfigurationManager.AppSettings("App.Name") %></h1>
        <h2 class="text-danger text-center" style="margin-bottom: 50px;">Erro</h2>
        <b>Nome do Erro: </b><asp:Label ID="lbl_ErrDescription" runat="server" Text="Nome do problema" CssClass="text-danger"></asp:Label> <br />
        <b>Descrição do Erro: </b><asp:Label ID="lbl_ErrMessage" runat="server" Text="Descrição do problema"></asp:Label><br />
        <b>Localização do Erro: </b><asp:Label ID="lbl_ErrLocation" runat="server" Text="Local do problema"></asp:Label> <br />
    </div>
    <%--END Conteudo da página--%>
</asp:Content>

<%--Footer Scrpits--%>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
