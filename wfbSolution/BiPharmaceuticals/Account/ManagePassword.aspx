<%@ Page Title="Gerenciar senha" Language="vb" MasterPageFile="~/_Master.Master" AutoEventWireup="false" CodeBehind="ManagePassword.aspx.vb" Inherits="BiPharmaceuticals.ManagePassword" %>

<%@ Register Src="~/_Page_Header_Private.ascx" TagPrefix="uc1" TagName="_Page_Header_Private" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:_Page_Header_Private runat="server" ID="_Page_Header_Private" />
    <div class="form-horizontal">
        <section id="passwordForm">
            <asp:PlaceHolder runat="server" ID="setPassword" Visible="false">
                <p> Você não possui uma senha local para esse site, Adicione uma senha local para que você possa fazer logon sem um logon externo.</p>
                <div class="form-horizontal">
                    <h4>Formulário de definição de senha</h4>
                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                    <hr />
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="password" CssClass="col-md-2 control-label">Senha</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="password" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="password"
                                CssClass="text-danger" ErrorMessage="O campo senha é obrigatório."
                                Display="Dynamic" ValidationGroup="SetPassword" />
                            <asp:ModelErrorMessage runat="server" ModelStateKey="NewPassword" AssociatedControlID="password"
                                CssClass="text-danger" SetFocusOnError="true" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="confirmPassword" CssClass="col-md-2 control-label">Confirmar senha</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="confirmPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="O campo para confirmar senha é obrigatório."
                                ValidationGroup="SetPassword" />
                            <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="confirmPassword"
                                CssClass="text-danger" Display="Dynamic" ErrorMessage="A senha e a senha de confirmação não coincidem."
                                ValidationGroup="SetPassword" />

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" Text="Definir senha" ValidationGroup="SetPassword" OnClick="SetPassword_Click" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>

            <asp:PlaceHolder runat="server" ID="changePasswordHolder" Visible="false">
                <div class="form-horizontal">
                    <h5>Alterar Senha</h5>
                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />
                    
                    <div class="form-group">
                        <asp:Label runat="server" ID="CurrentPasswordLabel" AssociatedControlID="CurrentPassword" CssClass="col-md-2 control-label">Senha atual</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="CurrentPassword" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="CurrentPassword" CssClass="text-danger" ErrorMessage="O campo senha atual é obrigatório." ValidationGroup="ChangePassword" />
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <asp:Label runat="server" ID="NewPasswordLabel" AssociatedControlID="NewPassword" CssClass="col-md-2 control-label">Nova senha</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="NewPassword" CssClass="text-danger" ErrorMessage="A nova senha é obrigatória." ValidationGroup="ChangePassword" Display="Dynamic" />
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <asp:Label runat="server" ID="ConfirmNewPasswordLabel" AssociatedControlID="ConfirmNewPassword" CssClass="col-md-2 control-label">Confirmar nova senha</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="ConfirmNewPassword" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmNewPassword" CssClass="text-danger" Display="Dynamic" ErrorMessage="Confirmar nova senha é obrigatório."  ValidationGroup="ChangePassword" />
                            <asp:CompareValidator runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" CssClass="text-danger" Display="Dynamic" ErrorMessage="A nova senha e a senha de confirmação não coincidem." ValidationGroup="ChangePassword" />
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" Text="Alterar senha" ValidationGroup="ChangePassword" OnClick="ChangePassword_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                
                </div>
            </asp:PlaceHolder>
        </section>
    </div>
</asp:Content>
