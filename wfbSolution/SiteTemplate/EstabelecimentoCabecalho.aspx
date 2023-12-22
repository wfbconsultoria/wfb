<%@ Page Title="Cabeçalho do Estabelecimento" Language="VB" MasterPageFile="~/Master.master" AutoEventWireup="false" CodeFile="EstabelecimentoCabecalho.aspx.vb" Inherits="EstabelecimentoCabecalho" %>

<%@ Register Src="~/Titulo_Pagina.ascx" TagPrefix="uc1" TagName="Titulo_Pagina" %>
<%@ Register Src="~/Estabelecimento_Cabecalho.ascx" TagPrefix="uc1" TagName="Estabelecimento_Cabecalho" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="Server">
    <%--Data Sources--%>
    <asp:SqlDataSource ID="dts" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" />
    <%--Titulo da Página--%>
    <uc1:Titulo_Pagina runat="server" ID="Titulo_Pagina" />
     <%--Cabeçalho Estabelecimento--%>
    <uc1:Estabelecimento_Cabecalho runat="server" ID="Estabelecimento_Cabecalho" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="Server">
</asp:Content>

