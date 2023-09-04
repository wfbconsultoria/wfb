<%@ Page Title="Confirmação de Conta" Language="vb" MasterPageFile="~/_Master_Public.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.vb" Inherits="BiHospitalar2020.Confirm" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <div class="container">
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <br />
            <h3 class="text-success">Obrigado por confirmar sua conta!</h3>
            <h4>Você receberá um e-mail de liberação enviado pelo administrador</h4>
            <%--<p>Clique <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">aqui</asp:HyperLink></p> --%>            
        </asp:PlaceHolder>
        
        <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
            <h3 class="text-danger">Ocorreu um erro</h3>
        </asp:PlaceHolder>
    </div>
</asp:Content>
