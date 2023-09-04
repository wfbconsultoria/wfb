<%@ Page Title="User Edit" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="UserEdit.aspx.vb" Inherits="UserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container body-content">
        <div class="row col-md-12 text-muted">
            <h4><strong>Editar Usuário</strong></h4>
        </div>

        <div class="row">
            <div class="col-md-12">
                <!-- Page Links Top -->
                <h6 class="container">
                    <a href="UsersList.aspx"><%:ConfigurationManager.AppSettings("UsersList.Title")%></a>&nbsp;&nbsp;
                <a href="UserRegister.aspx"><%:ConfigurationManager.AppSettings("UserRegister.Title")%></a>
                </h6>
                <!--/ Page Links Top -->

                <!-- Page Content -->

                <div class="form-horizontal">
                    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />

                    <!-- User Status -->
                    <div class="form-group">
                        <asp:Label runat="server" ID="lbl_UserStatus" AssociatedControlID="txt_UserStatus" CssClass="col-md-2 control-label"><%:ConfigurationManager.AppSettings("UserRegister.lbl.UserStatus")%></asp:Label>
                        <div class="col-md-2">
                            <asp:TextBox runat="server" ID="txt_UserStatus" CssClass="form-control" Enabled="False" />
                        </div>
                        <div class="col-md-1">
                            <asp:LinkButton ID="cmd_on" runat="server" Text="User Register" ValidationGroup="UserRegister" CssClass="btn btn-primary btn-sm"><%:ConfigurationManager.AppSettings("btn.On")%></asp:LinkButton>
                            <asp:LinkButton ID="cmd_off" runat="server" Text="User Register" ValidationGroup="UserRegister" CssClass="btn btn-danger btn-sm"><%:ConfigurationManager.AppSettings("btn.Off")%></asp:LinkButton>
                        </div>
                    </div>

                    <!-- User Name -->
                    <div class="form-group">
                        <asp:Label runat="server" ID="lbl_UserName" AssociatedControlID="txt_UserName" CssClass="col-md-2 control-label"><%:ConfigurationManager.AppSettings("UserRegister.lbl.UserName")%></asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txt_UserName" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="rfv_UserName" runat="server" ControlToValidate="txt_UserName"
                                CssClass="text-danger" ErrorMessage="This field is required."
                                ValidationGroup="UserRegister" Display="Dynamic" />
                        </div>
                    </div>

                    <!-- User Email -->
                    <div class="form-group">
                        <asp:Label runat="server" ID="lbl_UserEmail" AssociatedControlID="txt_UserEmail" CssClass="col-md-2 control-label" Enabled="False"><%:ConfigurationManager.AppSettings("UserRegister.lbl.UserEmail")%></asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txt_UserEmail" TextMode="Email" CssClass="form-control" Enabled="False" />
                            <asp:RequiredFieldValidator ID="rfv_UserEmail" runat="server" ControlToValidate="txt_UserEmail"
                                CssClass="text-danger" ErrorMessage="This field is required."
                                ValidationGroup="UserRegister" Display="Dynamic" />
                        </div>
                    </div>

                    <!-- User Profile -->
                    <div class="form-group">
                        <asp:Label runat="server" ID="lbl_UserProfile" AssociatedControlID="cmb_UserProfile" CssClass="col-md-2 control-label"><%:ConfigurationManager.AppSettings("UserRegister.lbl.UserProfile")%></asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList ID="cmb_UserProfile" runat="server" CssClass="form-control" DataSourceID="dts_UserProfile" DataTextField="USER_PROFILE" DataValueField="USER_PROFILE_CODE"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfv_UserProfile" runat="server" ControlToValidate="cmb_UserProfile" InitialValue="000"
                                CssClass="text-danger" ErrorMessage="This field is required."
                                ValidationGroup="UserRegister" Display="Dynamic" />
                        </div>
                    </div>

                    <!-- cmd_UserRegister-->
                    <div class="row">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:LinkButton ID="cmd_Save" runat="server" Text="User Register" ValidationGroup="UserRegister" CssClass="btn btn-default btn-sm" style="margin-top: 3px;"><%:ConfigurationManager.AppSettings("btn.Save")%></asp:LinkButton>
                            <asp:LinkButton ID="cmd_Cancel" runat="server" Text="Cancel" ValidationGroup="UserRegister" CssClass="btn btn-danger btn-sm" CausesValidation="False"><%:ConfigurationManager.AppSettings("btn.cancel")%></asp:LinkButton>
                        </div>
                    </div>
                </div>

                <!-- Data sources-->
                <asp:SqlDataSource ID="dts_UserProfile" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [tb_Users_Profiles] WHERE ([Active] = @Active) ORDER BY [USER_PROFILE_CODE]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="True" Name="Active" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
                <asp:SqlDataSource ID="dts_EmailDomain" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [USER_DOMAIN] FROM [tb_Users_Domains] WHERE ([Active] = @Active) ORDER BY [ID]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="True" Name="Active" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <!--/ Page Content -->

                <!-- Page Links Botton-->
                <h6>&nbsp;</h6>
                <!--/ Page Links Botton -->
            </div>
        </div>
    </div>
</asp:Content>


