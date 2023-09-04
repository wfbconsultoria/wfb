<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginMessage.aspx.vb" Inherits="EPlanner.LoginMessage" %>

<%@ Register Src="~/App_Controls/Meta.ascx" TagPrefix="uc1" TagName="Meta" %>
<%@ Register Src="~/App_Controls/Scripts_Header.ascx" TagPrefix="uc1" TagName="Scripts_Header" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <uc1:Meta runat="server" ID="Meta" />
    <uc1:Scripts_Header runat="server" ID="Scripts_Header" />
    <title><%:ConfigurationManager.AppSettings("App.Name") & " - LOGIN" %></title>
</head>
<body class="authentication-page">
    <form id="form1" runat="server">
        <div class="account-pages my-5 pt-md-5">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-8 col-lg-6 col-xl-5">
                        <div class="card mt-4" style="background-color: #081C3B; color: #FFFFFF">
                            <div class="card-body p-4">
                                <div class="text-center pb-1"><img src="assets/images/DECATHLON.png" alt="" height="72" /></div>
                                <div class="text-center mb-4"><h3 class="text-uppercase">E-PLANNER</h3></div>
                                <div class="text-center mb-4"><h3 class="text-uppercase">LOGIN</h3></div>
                                <div class="text-left mb-4">
                                    <asp:Label ID="lbl_Message" runat="server" Text="Mensagem"></asp:Label>
                                </div>
                                <hr />
                                <asp:HyperLink ID="lnk_Message" runat="server" NavigateUrl="~/Login.aspx" style="padding: 5px; margin: 5px; background-color: #052D51; color: #FFFFFF; vertical-align: middle; text-align: center;" CssClass="btn btn-lg btn-block  waves-effect waves-light"> /></asp:HyperLink>
                            </div>
                                
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Vendor js -->
        <script src="assets/js/vendor.min.js"></script>
        <!-- App js -->
        <script src="assets/js/app.min.js"></script>
    </form>
</body>
</html>
