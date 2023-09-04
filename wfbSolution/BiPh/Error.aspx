<%@ Page Title="Erro" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Error.aspx.vb" Inherits="BiPh._Error" %>
<%@ Register Src="~/Page_Header.ascx" TagPrefix="uc1" TagName="Page_Header" %>
<%@ Register Src="~/Page_Footer.ascx" TagPrefix="uc1" TagName="Page_Footer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head_Content" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body_Content" runat="server">
    <!--Cabeçalho da página -->
    <uc1:Page_Header runat="server" ID="Page_Header" />
    
    <div>
        <h1 class="display-4 text-center"><%:ConfigurationManager.AppSettings("App.Name") %></h1>
        <h2 class="text-danger text-center" style="margin-bottom: 50px;">Erro</h2>
        <b>Nome do Erro: </b><asp:Label ID="lbl_ErrDescription" runat="server" Text="Nome do problema" CssClass="text-danger"></asp:Label> <br />
        <b>Descrição do Erro: </b><asp:Label ID="lbl_ErrMessage" runat="server" Text="Descrição do problema"></asp:Label><br />
        <b>Localização do Erro: </b><asp:Label ID="lbl_ErrLocation" runat="server" Text="Local do problema"></asp:Label> <br />
    </div>
    <uc1:Page_Footer runat="server" ID="Page_Footer" />
    <!--Datasources -->
    <asp:SqlDataSource ID="dtsDoctor" runat="server" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>'></asp:SqlDataSource>
</asp:Content>
    
    <%--END Conteudo da página--%>