﻿<%@ Page Title="Gerenciar conta" Language="vb" AutoEventWireup="false" MasterPageFile="~/_Master.Master" CodeBehind="Manage.aspx.vb" Inherits="BiPharmaceuticals.Manage" %>

<%@ Import Namespace="BiPharmaceuticals" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="SuccessMessagePlaceHolder" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-horizontal">
                <h4>Alterar as configurações de conta</h4>
                <hr />
                <dl class="dl-horizontal">
                    <dt>Senha:</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Change]" Visible="false" ID="ChangePassword" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Create]" Visible="false" ID="CreatePassword" runat="server" />
                    </dd>
                    <dt>Logins externos:</dt>
                    <dd><%:LoginsCount %>
                        <asp:HyperLink NavigateUrl="/Account/ManageLogins" Text="[Manage]" runat="server" />

                    </dd>
                    <%--
                        Phone Numbers can used as a second factor of verification in a two-factor authentication system.
                        See <a href="https://go.microsoft.com/fwlink/?LinkId=403804">this article</a>
                        for details on setting up this ASP.NET application to support two-factor authentication using SMS.
                        Uncomment the following blocks after you have set up two-factor authentication
                    --%>
                    <%--
                    <dt>Phone Number:</dt>
                     --%>
                    <% If HasPhoneNumber Then %>
                    <%--
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Add]" />
                    </dd>
                    --%>
                    <% Else %>
                    <%--
                    <dd>
                    
                        <asp:Label Text="" ID="PhoneNumber" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/AddPhoneNumber" runat="server" Text="[Change]" /> &nbsp;|&nbsp;
                        <asp:LinkButton Text="[Remove]" OnClick="RemovePhone_Click" runat="server" />
                    </dd>
                    --%>
                    <% End If %>
                    <dt>Autenticação de dois fatores:</dt>
                    <dd>
                        <p>
                            Não há provedores de autenticação de dois fatores configurados. Consulte <a href="https://go.microsoft.com/fwlink/?LinkId=403804">este artigo</a>
                            para obter detalhes sobre como configurar este aplicativo ASP.NET para dar suporte à autenticação de dois fatores.
                        </p>                        
                        <% If TwoFactorEnabled Then %>
                        <%--
                        Enabled
                        <asp:LinkButton Text="[Disable]" runat="server" CommandArgument="false" OnClick="TwoFactorDisable_Click" />
                        --%>
                        <% Else %>
                       	<%--
                       	Disabled
                        <asp:LinkButton Text="[Enable]" CommandArgument="true" OnClick="TwoFactorEnable_Click" runat="server" />
                        --%>
                        <% End If %>
                    </dd>
                </dl>
            </div>
        </div>
    </div>
</asp:Content>
