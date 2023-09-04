<%@ Page Title="Validar e-mail" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="SendConfirm.aspx.vb" Inherits="BiPharmaceuticals.SendConfirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="container">
        <div class=" jumbotron">
            <h4 class="text-danger text-uppercase">Validar E-mail</h4>
            <h5 runat="server" id="Name"></h5>
            <h6 runat="server" id="Email"></h6>

            <h5>Você está registrado no <%:ConfigurationManager.AppSettings("App.Name") %>, porém,  ainda não confirmou a propriedade do seu e-mail</h5>
            <h5>Caso necessário, REENVIE o e-mail solicitando a confirmação clicando
                <asp:LinkButton ID="cmdConfirm" runat="server" CssClass="alert-link">aqui</asp:LinkButton>
            </h5>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
