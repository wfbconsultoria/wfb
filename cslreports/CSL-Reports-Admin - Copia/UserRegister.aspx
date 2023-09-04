<%@ Page Title="User Register" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="UserRegister.aspx.vb" Inherits="UserRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <div class="row col-md-12 text-muted">
            <h4><strong>Novo Usuario</strong></h4>
        </div>
    </div>
    <div class="container">
        <div class="col-md-12">
            <!-- Page Links Top -->
            <h6>
                <a href="UsersList.aspx"><%:ConfigurationManager.AppSettings("UsersList.Title")%></a>
            </h6>
            <!--/ Page Links Top -->

            <!-- Page Content -->
            <div class="form-horizontal">
                <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-danger" />

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
                    <asp:Label runat="server" ID="lbl_UserEmail" AssociatedControlID="txt_UserEmail" CssClass="col-md-2 control-label"><%:ConfigurationManager.AppSettings("UserRegister.lbl.UserEmail")%></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txt_UserEmail" TextMode="Email" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="rfv_UserEmail" runat="server" ControlToValidate="txt_UserEmail"
                            CssClass="text-danger" ErrorMessage="This field is required."
                            ValidationGroup="UserRegister" Display="Dynamic" />
                    </div>
                    <div class="col-md-4" id="txtEmailDomainSMT">
                        <asp:DropDownList ID="txt_EmailDomain" runat="server" DataSourceID="dts_EmailDomain" CssClass="form-control" DataTextField="USER_DOMAIN" DataValueField="USER_DOMAIN"></asp:DropDownList>
                    </div>
                </div>

                <!-- User Profile -->
                <div class="form-group">
                    <asp:Label runat="server" ID="lbl_UserProfile" AssociatedControlID="cmb_UserProfile" CssClass="col-md-2 control-label"><%:ConfigurationManager.AppSettings("UserRegister.lbl.UserProfile")%></asp:Label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="cmb_UserProfile" runat="server" CssClass="form-control" DataSourceID="dts_UserProfile" DataTextField="USER_PROFILE" DataValueField="USER_PROFILE_CODE"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_UserProfile" runat="server" ControlToValidate="cmb_UserProfile" InitialValue="000"
                            CssClass="text-danger" ErrorMessage="This field is required."
                            ValidationGroup="UserRegister" Display="Dynamic" />
                    </div>
                </div>

                <!-- cmd_UserRegister-->
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <asp:LinkButton ID="cmd_Save" runat="server" Text="User Register" ValidationGroup="UserRegister" CssClass="btn btn-default btn-sm" style="margin-top: 3px;"><%:ConfigurationManager.AppSettings("btn.Save")%></asp:LinkButton>
                        <asp:LinkButton ID="cmd_Cancel" runat="server" Text="Cancel" ValidationGroup="UserRegister" CssClass="btn btn-danger btn-sm" CausesValidation="False"><%:ConfigurationManager.AppSettings("btn.cancel")%></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Data sources-->
    <!-- profile-->
    <asp:SqlDataSource ID="dts_UserProfile" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [tb_Users_Profiles] WHERE ([Active] = @Active) ORDER BY [USER_PROFILE_CODE]">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="Active" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>

    <!-- email domain-->
    <asp:SqlDataSource ID="dts_EmailDomain" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [USER_DOMAIN] FROM [tb_Users_Domains] ORDER BY [Update_Date] DESC">
    </asp:SqlDataSource>

</asp:Content>



