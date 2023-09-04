<%@ Page Title="Relatorios" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="_Menu_Private.aspx.vb" Inherits="BiPharmaceuticals._Menu_Private" %>

<%@ Register Src="~/_Page_Header_Private.ascx" TagPrefix="uc1" TagName="_Page_Header_Private" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:_Page_Header_Private runat="server" ID="_Page_Header_Private" />
    <%--Conteudo da página--%>
    <div>
        <h5><a class="nav-link" runat="server" href="#">Lista de Médicos</a></h5>
        <h5><a class="nav-link" runat="server" href="#">Lista de Pacientes</a></h5>
        <h5><a class="nav-link" runat="server" href="#">Dashboard Visitação</a></h5>
        <h5><a class="nav-link" runat="server" href="#">Agenda de Vistas</a></h5>
    </div>
    <%--END Conteudo da página--%>
</asp:Content>

<%--Footer Scrpits--%>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
