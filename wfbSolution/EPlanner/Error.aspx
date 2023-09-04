<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Error.aspx.vb" Inherits="EPlanner._Error" %>

<%@ Register Src="~/App_Controls/Page_Footer.ascx" TagPrefix="uc1" TagName="Page_Footer" %>
<%@ Register Src="~/App_Controls/Navigation_Header.ascx" TagPrefix="uc1" TagName="Navigation_Header" %>
<%@ Register Src="~/App_Controls/Page_Header.ascx" TagPrefix="uc1" TagName="Page_Header" %>
<%@ Register Src="~/App_Controls/Meta.ascx" TagPrefix="uc1" TagName="Meta" %>
<%@ Register Src="~/App_Controls/Scripts_Header.ascx" TagPrefix="uc1" TagName="Scripts_Header" %>
<%@ Register Src="~/App_Controls/Scripts_Footer.ascx" TagPrefix="uc1" TagName="Scripts_Footer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <uc1:Meta runat="server" ID="Meta" />
    <uc1:Scripts_Header runat="server" ID="Scripts_Header" />
    <title>Erro</title>
</head>

<body class="authentication-page">
    <form id="form1" runat="server">
        <div class="account-pages my-5 pt-md-5">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-8 col-lg-6 col-xl-5">
                        <div class="text-center pb-1">
                            <a href="index.html">
                                <span>
                                    <img src="assets/images/logo.png" alt="" height="72"/></span>
                            </a>
                            <h5 class="font-14 text-muted mt-3"><%:ConfigurationManager.AppSettings("App.Name") %></h5>
                        </div>
                        <div class="card mt-4">

                            <div class="card-body p-4">
                                <div class="text-center">
                                    <h5 class="text-uppercase">Page not Found</h5>
                                    <div class="text-error">404</div>
                                    <p class="font-13 mb-0">
                                        It's looking like you may have taken a wrong turn. Don't worry... it happens to the best of us.
                                            You might want to check your internet connection tip that might help back on track.
                                    </p>
                                </div>

                            </div>
                            <!-- end card-body -->
                        </div>
                        <!-- end card -->

                        <div class="row mt-3">
                            <div class="col-12 text-center">
                                <p>Back to <a href="Default.aspx" class="text-primary ml-1"><b>Home</b></a></p>
                            </div>
                            <!-- end col -->
                        </div>
                        <!-- end row -->

                    </div>
                    <!-- end col -->
                </div>
                <!-- end row -->
            </div>
            <!-- end container -->
        </div>
        <!-- end page -->
    </form>
    <!-- Vendor js -->
    <script src="assets/js/vendor.min.js"></script>

    <!-- App js -->
    <script src="assets/js/app.min.js"></script>

</body>
</html>
