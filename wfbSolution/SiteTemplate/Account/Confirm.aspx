<%@ Page Title="Confirmação de Conta" Language="vb" MasterPageFile="~/_Master.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.vb" Inherits="SiteTemplate.Confirm" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <p>
                Obrigado por confirmar sua conta. Clique <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">aqui</asp:HyperLink>  para fazer logon             
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
            <p class="text-danger">
                Ocorreu um erro.
            </p>
        </asp:PlaceHolder>
    </div>
</asp:Content>
