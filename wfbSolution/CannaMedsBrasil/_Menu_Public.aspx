<%@ Page Title="Menu Público" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="_Menu_Public.aspx.vb" Inherits="CannaMedsBrasil._Menu_Public" %>

<%@ Register Src="~/_Page_Header_Public.ascx" TagPrefix="uc1" TagName="_Page_Header_Public" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:_Page_Header_Public runat="server" ID="_Page_Header_Public" />
    <%--Conteudo da página--%>
    <div>
        <h5><a class="nav-link" runat="server" href="~/ConsultaIP">Consulta IP</a></h5>
        <h5><a class="nav-link" runat="server" href="~/ConsultaCPF">Consulta CPF</a></h5>
        <h5><a class="nav-link" runat="server" href="~/Default">Home</a></h5>
        <h5><a class="nav-link" runat="server" href="~/About">Sobre</a></h5>
        <h5><a class="nav-link" runat="server" href="~/Contact">Contato</a></h5>
        <h5><a class="nav-link" runat="server" href="~/SoaWEbServices_cpf">Teste</a></h5>
        <h5><a class="nav-link" runat="server" href="~/Ficha">Ficha</a></h5>
    </div>
    <%--END Conteudo da página--%>
</asp:Content>

<%--Footer Scrpits--%>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>