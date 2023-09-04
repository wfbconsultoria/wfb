<%@ Page Title="Página Publica" Language="VB" MasterPageFile="~/_Logged.master" AutoEventWireup="false" CodeFile="_PageModel_Public.aspx.vb" Inherits="_PageModel_Public" %>

<%@ Register Src="~/_PageTitle_Public.ascx" TagPrefix="uc1" TagName="_PageTitle_Public" %>


<%--PAGINA PUBLICA NÃO REQUER CONTROLE DE ACESSO OU LOGIN--%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" Runat="Server">
   <div class="row d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-white border-bottom">
       <uc1:_PageTitle_Public runat="server" ID="_PageTitle_Public" />
        <%--Page Title--%>
        <%--<h5 class="my-0 mr-md-auto font-weight-normal"><%:Page.Title %></h5>--%>
        
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
        Conteudo da página, PUBLICO, não exige autenticação
    </div>
    <%--END Conteudo da página--%>
</asp:Content>
