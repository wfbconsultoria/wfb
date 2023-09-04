<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="RegisterExternalLogin.aspx.vb" Inherits="BiPharmaceuticals.RegisterExternalLogin" Async="true" %>

<%@ Import Namespace="BiPharmaceuticals" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<h3>Registre-se com a sua conta <%: ProviderName %></h3>

    <asp:PlaceHolder runat="server">
        <div class="form-horizontal">
            <h4>Formulário de associação</h4>
            <hr />
            <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
            <p class="text-info">
                Você foi autenticado com <strong><%: ProviderName %></strong>. Insira um e-mail abaixo para o site atual
                e clique no botão Iniciar sessão.
            </p>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="email" CssClass="col-md-2 control-label">E-mail</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="email" CssClass="form-control" TextMode="Email" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="email"
                        Display="Dynamic" CssClass="text-danger" ErrorMessage="O e-mail é exigido" />
                    <asp:ModelErrorMessage runat="server" ModelStateKey="email" CssClass="text-error" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Logon" CssClass="btn btn-default" OnClick="LogIn_Click" />
                </div>
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>
