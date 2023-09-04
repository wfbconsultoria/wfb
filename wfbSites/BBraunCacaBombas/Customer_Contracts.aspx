<%@ Page Title="Contratos" Language="VB" MasterPageFile="~/_Logged.master" AutoEventWireup="false" CodeFile="Customer_Contracts.aspx.vb" Inherits="Customer_Contracts" %>

<%@ Register Src="~/_PageTitle_Logged.ascx" TagPrefix="uc1" TagName="_PageTitle_Logged" %>

<%--PAGINA RESTRITA REQUER CONTROLE DE ACESSO E LOGIN--%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" Runat="Server">
   <div class="row d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-white border-bottom">
       
        <%--Page Title--%>
       <uc1:_PageTitle_Logged runat="server" ID="_PageTitle_Logged" />
       
       <%--Links e comandos da página, caso não seja utilizados comentar este trecho de código--%>
        <nav class="my-2 my-md-0 mr-md-3">
            <a class="p-2" href="#">Page Link</a>
            <asp:LinkButton ID="cmd_01" runat="server" CssClass="p-2 text-dark">Commnad</asp:LinkButton>
            <asp:LinkButton ID="cmd_02" runat="server" CssClass="p-2 text-info">Action</asp:LinkButton>
            <asp:LinkButton ID="cmd_03" runat="server" CssClass="p-2 text-success">Sucess</asp:LinkButton>
            <asp:LinkButton ID="cmd_04" runat="server" CssClass="p-2 text-danger">Danger</asp:LinkButton>
        </nav>
        <%--END Links e comandos--%>
    </div>
    
    <%--Conteudo da página--%>
    <div>
        <h2>Lista com contratos e bombas por contrato</h2>
    </div>
    <%--END Conteudo da página--%>
</asp:Content>