<%@ Page Title="Recuperar Senha" Language="vb" MasterPageFile="~/_Master_Public.Master" AutoEventWireup="true" CodeBehind="Forgot.aspx.vb" Inherits="BiHospitalar2020.ForgotPassword" Async="true" %>

<%@ Register Src="~/_Page_Header_Public.ascx" TagPrefix="uc1" TagName="_Page_Header_Public" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="row">
        <div class="col-md-8">
            <asp:PlaceHolder ID="loginForm" runat="server">
                <div class="form-horizontal">
                    <uc1:_Page_Header_Public runat="server" ID="_Page_Header_Public1" />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">E-mail</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="O campo e-mail é exigido." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="Forgot" Text="Enviar link por email" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="DisplayEmail" Visible="false">
                <br />
                <h3 class="text-info">Foi enviado um e-mail para redefinir sua senha.
                </h3>
                <br />
            </asp:PlaceHolder>
        </div>
    </div>
</asp:Content>
