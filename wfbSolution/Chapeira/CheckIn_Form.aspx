<%@ Page Title="Check In/Out" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="CheckIn_Form.aspx.vb" Inherits="Chapeira.CheckIn_Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <%--<h4 class="text-secondary text-uppercase"><%:Page.Title %></h4>--%>

    <%-- Mensagem--%>
    <br />
    <div class="jumbotron bg-light">
        <h1 runat="server" id="txt_Loja" class="text-primary display-4 text-center"></h1>
        <h1 runat="server" id="txt_Titulo" class="text-primary text-center display-4"></h1>
        <h1 runat="server" id="txt_Nome" class="text-center display-4"></h1>
        <h1 runat="server" id="txt_Universo" class="text-center"></h1>

        <h1 runat="server" id="txt_Saudacao" class="text-primary text-center"></h1>
        <h3 runat="server" id="txt_CheckIn_Date" class="text-center"></h3>
        <h3 runat="server" id="txt_CheckIn_Status" class="text-center"></h3>
        <%--<h3 runat="server" id="txt_CheckIn_IP" class="text-center"></h3>--%>
        <%-- botoes de de comando--%>
        <div class="row">
            <div class="col-sm-4"></div>
            <div class="col-sm-4"><a href="Default.aspx" class="display-4 btn btn-primary btn-lg btn-block">OK</a></div>
            <div class="col-sm-4"></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
