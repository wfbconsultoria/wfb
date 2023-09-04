<%@ Page Title="Redefinir Senha" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="ChangePassword.aspx.vb" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container body-content">
        <div class="row col-md-12 text-muted">
            <h4><strong>Redefinir Senha</strong></h4>
        </div>


        <!-- corpo da Página-->
        <div class="form-horizontal" id="redefinir-senha">
            <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
            <!--Senha Atual-->
            <div class="form-group">
                <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword" CssClass="col-md-3 control-label"><%:ConfigurationManager.AppSettings("ChangePassword.lbl.CurrentPassword")%></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfv_CurrentPassword" runat="server" ControlToValidate="CurrentPassword"
                        CssClass="text-danger" ErrorMessage="A senha atual é necessária."
                        ValidationGroup="ChangePassword" />
                </div>
            </div>
            <!--Nova Senha-->
            <div class="form-group">
                <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword" CssClass="col-md-3 control-label"><%:ConfigurationManager.AppSettings("ChangePassword.lbl.NewPassword")%></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfv_NewPassword" runat="server" ControlToValidate="NewPassword"
                        CssClass="text-danger" ErrorMessage="A nova senha é necessária."
                        ValidationGroup="ChangePassword" />
                </div>
            </div>
            <!--Confirmar senha-->
            <div class="form-group">
                <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword" CssClass="col-md-3 control-label"><%:ConfigurationManager.AppSettings("ChangePassword.lbl.ConfirmPassword")%></asp:Label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="rfv_ConfirmNewPassword" runat="server" ControlToValidate="ConfirmNewPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="Confirme sua nova senha."
                        ValidationGroup="ChangePassword" />
                    <asp:CompareValidator ID="cpv_ConfirmNewPassword" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="A nova senha e a senha de confirmação não coincidem."
                        ValidationGroup="ChangePassword" />
                </div>
            </div>
            <!--botão salvar-->
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:LinkButton ID="cmd_ChangePassword" runat="server" Text="Change Password" ValidationGroup="ChangePassword" CssClass="btn btn-default btn-sm"><%:ConfigurationManager.AppSettings("btn.Save")%></asp:LinkButton>
                </div>
            </div>
        </div>
        <!--/ Corpo da Página-->

    </div>
</asp:Content>



