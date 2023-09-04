<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="EPlanner.Login" %>

<%@ Register Src="~/App_Controls/Meta.ascx" TagPrefix="uc1" TagName="Meta" %>
<%@ Register Src="~/App_Controls/Scripts_Header.ascx" TagPrefix="uc1" TagName="Scripts_Header" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <uc1:Meta runat="server" ID="Meta" />
    <uc1:Scripts_Header runat="server" ID="Scripts_Header" />
    <title>Login</title>
</head>
<body class="authentication-page">
    <form id="form1" runat="server">
        <div class="account-pages my-5 pt-md-5">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-8 col-lg-6 col-xl-5">

                        <div class="card mt-4" style="background-color: #081C3B; color: #FFFFFF">

                            <div class="card-body p-4">
                                <div class="text-center pb-1">

                                    <img src="assets/images/DECATHLON.png" alt="" height="72" />

                                </div>
                                <div class="text-center mb-4">
                                    <h3 class="text-uppercase">E-PLANNER</h3>
                                </div>

                                <div class="p-2">

                                    <div class="form-group mb-3">
                                        <input runat="server" id="txt_Email" class="form-control" type="email" required="" placeholder="seu e-mail @decathlon.com" />
                                    </div>

                                    <div class="form-group mb-3">
                                        <input runat="server" id="txt_Senha" class="form-control" type="password" required="" placeholder="sua senha" />
                                    </div>

                                    <div class="form-group mb-4">
                                        
                                        <button type="submit" class="btn btn-lg btn-block  waves-effect waves-light" style="background-color: #052D51; color: #FFFFFF; vertical-align: middle; text-align: center;"><span style="vertical-align: middle"><i class="mdi mdi-36pxmdi mdi-login"></i></span><span>&nbsp;LOG-IN</span></button>
                                    </div>
                                    

                                    <a href="#" class="text-muted"><i class="mdi mdi-lock mr-1"></i>Esqueci a senha (IMPLEMENTAR)</a>

                                </div>

                            </div>
                            <!-- end card-body -->
                        </div>
                        <!-- end card -->

                        <!-- end row -->

                    </div>
                    <!-- end col -->
                </div>
                <!-- end row -->
            </div>
            <!-- end container -->
        </div>
        <!-- end page -->

        <!-- Vendor js -->
        <script src="assets/js/vendor.min.js"></script>

        <!-- App js -->
        <script src="assets/js/app.min.js"></script>
    </form>
</body>
</html>
