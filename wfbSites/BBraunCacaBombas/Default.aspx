<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/_Logged.master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Src="~/_PageTitle_Public.ascx" TagPrefix="uc1" TagName="_PageTitle_Public" %>


<%--PAGINA PUBLICA NÃO REQUER CONTROLE DE ACESSO OU LOGIN--%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" Runat="Server">
    <div class="row d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-white border-bottom">
        <!--Page Titlte -->
        <uc1:_PageTitle_Public runat="server" ID="_PageTitle_Public" />
        <%--<h5 class="my-0 mr-md-auto font-weight-normal"><%:Page.Title %></h5>--%>
        <!--Page LInks and commnads -->
        <%--<nav class="my-2 my-md-0 mr-md-3">
            <a class="p-2" href="#">Page Link</a>
            <a class="p-2" href="#">Page Link</a>
            <a class="p-2" href="#">Page Link</a>
            <asp:LinkButton ID="cmd_01" runat="server" CssClass="p-2 text-dark">Commnad</asp:LinkButton>
            <asp:LinkButton ID="cmd_02" runat="server" CssClass="p-2 text-info">Action</asp:LinkButton>
            <asp:LinkButton ID="cmd_03" runat="server" CssClass="p-2 text-success">Sucess</asp:LinkButton>
            <asp:LinkButton ID="cmd_04" runat="server" CssClass="p-2 text-danger">Danger</asp:LinkButton>
        </nav>--%>
    </div>

    <!--Page Content-->
    
    <div class="row">
        <div class=" col-md-12 text-center">
            <h1 style="color:#00B482;">Caça Bombas</h1>
        </div>      
        <div class=" col-md-12 text-center">
            <img class="img-responsive" src="Images/Mira.png" alt="Imagem"/>
        </div>              
    </div>

</asp:Content>
