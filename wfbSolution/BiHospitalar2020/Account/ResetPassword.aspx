<%@ Page Title="Redefinir senha" Language="vb" MasterPageFile="~/_Master_Public.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.vb" Inherits="BiHospitalar2020.ResetPassword" Async="true" %>

<%@ Register Src="~/_Page_Header_Private.ascx" TagPrefix="uc1" TagName="_Page_Header_Private" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <uc1:_Page_Header_Private runat="server" ID="_Page_Header_Private" />
    <p class="text-danger"><asp:Literal runat="server" ID="ErrorMessage" /></p>

    <div class="form-horizontal">
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">E-mail</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="O campo e-mail é exigido." Display="Dynamic" />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Senha</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="O campo senha é exigido." Display="Dynamic" />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirmar senha</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"  CssClass="text-danger" Display="Dynamic" ErrorMessage="O campo senha de confirmação é exigido." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"  CssClass="text-danger" Display="Dynamic" ErrorMessage="As senhas não correspondem." />
            </div>
        </div>
        
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="Reset_Click" Text="Redefinir" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
</asp:Content>
