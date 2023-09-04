<%@ Page Title="Login" Language="vb" AutoEventWireup="false" MasterPageFile="~/_MasterLogin.Master" CodeBehind="Login.aspx.vb" Inherits="CannaMedsBrasil.Login" Async="true" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <%--Page Title--%>
    <br />
    <div class="row">
        <div class="col-md-6">
            <img class="img-fluid" width=240  src="/Images/doutorCRM.png"/>
            <section id="loginForm">
                <div class="form-horizontal">
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger"><asp:Literal runat="server" ID="FailureText" /></p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">E-mail</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" onfocus="this.value='';"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="O campo e-mail é exigido." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Senha</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" onfocus="this.value='';" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="O campo de senha é obrigatório." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Lembrar-me?</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text="Login" CssClass="btn btn-outline-secondary" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-6">
                            <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled" CssClass="alert-link">Registre-se</asp:HyperLink>&nbsp;&nbsp;
                        </div>
                        <div class="col-md-offset-2 col-md-6">
                            <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled" CssClass="alert-link">Esqueci a senha</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </section>
        </div>

        <%-- <div class="col-md-4">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>--%>
    </div>
</asp:Content>
