<%@ Page Title="Selleers" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="Sellers_form.aspx.vb" Inherits="BiHospitalar2020.Sellers_forme" %>


<%@ Register Src="~/_Page_Header_Private.ascx" TagPrefix="uc1" TagName="_Page_Header_Private" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-white border-bottom">
        <uc1:_Page_Header_Private runat="server" ID="_Page_Header_Private" />

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

        <%--Modelo de formulário--%>

        <div class="form-group">
            <asp:Label runat="server" ID="lbl_nome" AssociatedControlID="txt_nome" CssClass="col-md-2 control-label" Text="Nome:"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txt_nome" CssClass="form-control" TextMode="SingleLine" MaxLength="250" required="required" placeholder="Nome Completo" />
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txt_nome" CssClass="text-danger" ErrorMessage="preenchimento obrigatório" Display="Dynamic" />
            </div>
        </div>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label runat="server" ID="lbl_email" AssociatedControlID="txt_email" CssClass="col-md-2 control-label" Text="E-mail:"></asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txt_email" CssClass="form-control" TextMode="Email" MaxLength="50" required="required" placeholder="Preencha como o E-mail" />
                    <asp:RequiredFieldValidator runat="server" ID="rfv_email" ControlToValidate="txt_email" CssClass="text-danger" ErrorMessage="preenchimento obrigatório" Display="Dynamic" />
                </div>
            </div>


            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" ID="cmd_Model" Text="Cadastrar" CssClass="btn btn-primary rounded" />
                </div>
            </div>
        </div>
        <%--END Modelo de formulário--%>
    </div>
    <%--END Conteudo da página--%>
</asp:Content>

<%--Footer Scrpits--%>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
