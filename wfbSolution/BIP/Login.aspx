<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="BIP.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required Meta Tags Always Come First -->
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <title>Login</title>

    <!-- Favicon -->
    <link rel="shortcut icon" href="favicon.ico" />
    <!-- Google Fonts -->
    <link rel="stylesheet" href="//fonts.googleapis.com/css?family=Open+Sans%3A400%2C300%2C500%2C600%2C700%7CPlayfair+Display%7CRoboto%7CRaleway%7CSpectral%7CRubik" />
    <!-- CSS Global Compulsory -->
    <link rel="stylesheet" href="assets/vendor/bootstrap/bootstrap.min.css" />

    <link rel="stylesheet" href="assets/vendor/icon-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="assets/vendor/icon-hs/style.css" />
    <link rel="stylesheet" href="assets/vendor/animate.css" />
    <link rel="stylesheet" href="assets/vendor/hs-megamenu/src/hs.megamenu.css" />
    <link rel="stylesheet" href="assets/vendor/hamburgers/hamburgers.min.css" />

    <!-- CSS Unify -->
    <link rel="stylesheet" href="assets/css/unify-core.css" />
    <link rel="stylesheet" href="assets/css/unify-components.css" />
    <link rel="stylesheet" href="assets/css/unify-globals.css" />

    <!-- CSS Customization -->
    <link rel="stylesheet" href="assets/css/custom.css" />
</head>

<body>

    <main>
        <!-- Login -->
        <section class="container g-py-100">
            <div class="row justify-content-center">
                <div class="col-sm-8 col-lg-5">
                    <div class="g-brd-around g-brd-gray-light-v4 rounded g-py-40 g-px-30">
                        <header class="text-center mb-4">
                            <h2 class="h2 g-color-black g-font-weight-600 ">Login</h2>
                        </header>

                        <!-- Form -->
                        <form id="frm_Login" runat="server" class="g-py-15">
                            <!-- E-mail -->
                            <div class="mb-4">
                                <label class="g-color-gray-dark-v2 g-font-weight-600 g-font-size-13">Email:</label>
                                <input runat="server" id="txt_Email" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v4 g-brd-primary--hover rounded g-py-15 g-px-15" type="email" placeholder="E-mail" />
                            </div>
                            <!-- End E-mail -->

                            <div class="g-mb-35">
                                <!-- Password -->
                                <div class="row justify-content-between">
                                    <div class="col align-self-center">
                                        <label class="g-color-gray-dark-v2 g-font-weight-600 g-font-size-13">Senha:</label>
                                    </div>
                                    <div class="col align-self-center text-right">
                                        <a runat="server" id="cmd_Forgot" class="d-inline-block g-font-size-12 mb-2" href="#">Esqueci a senha</a>
                                    </div>
                                </div>
                                <input runat="server" id="txt_Password" class="form-control g-color-black g-bg-white g-bg-white--focus g-brd-gray-light-v4 g-brd-primary--hover rounded g-py-15 g-px-15 mb-3" type="password" placeholder="Password" />
                                <!-- End Password -->

                                <!-- Login Button -->
                                <div class="row justify-content-between">
                                    <div class="col-12 align-self-center">
                                        <button runat="server" id="cmd_Login" class="btn btn-md u-btn-primary rounded g-py-13 g-px-25" type="button">Login</button>
                                    </div>
                                </div>
                                <!-- End Login Button -->
                            </div>
                        </form>
                        <!-- End Form -->

                        <%--<footer class="text-center">
                            <p class="g-color-gray-dark-v5 g-font-size-13 mb-0">
                                Não tem uma conta? <a class="g-font-weight-600" href="User_Register.aspx">registre-se</a>
                            </p>
                        </footer>--%>
                    </div>
                </div>
            </div>
        </section>
        <!-- End Login -->

        <a class="js-go-to u-go-to-v1" href="#" data-type="fixed" data-position='{
     "bottom": 15,
     "right": 15
   }'
            data-offset-top="400" data-compensation="#js-header" data-show-effect="zoomIn">
            <i class="hs-icon hs-icon-arrow-top"></i>
        </a>
    </main>

    <div class="u-outer-spaces-helper"></div>


    <!-- JS Global Compulsory -->
    <script src="assets/vendor/jquery/jquery.min.js"></script>
    <script src="assets/vendor/jquery-migrate/jquery-migrate.min.js"></script>
    <script src="assets/vendor/popper.js/popper.min.js"></script>
    <script src="assets/vendor/bootstrap/bootstrap.min.js"></script>


    <!-- JS Implementing Plugins -->
    <script src="assets/vendor/hs-megamenu/src/hs.megamenu.js"></script>

    <!-- JS Unify -->
    <script src="assets/js/hs.core.js"></script>
    <script src="assets/js/components/hs.header.js"></script>
    <script src="assets/js/helpers/hs.hamburgers.js"></script>
    <script src="assets/js/components/hs.tabs.js"></script>
    <script src="assets/js/components/hs.go-to.js"></script>

    <!-- JS Customization -->
    <script src="assets/js/custom.js"></script>

    <!-- JS Plugins Init. -->
    <script>
        $(document).on('ready', function () {
            // initialization of tabs
            $.HSCore.components.HSTabs.init('[role="tablist"]');

            // initialization of go to
            $.HSCore.components.HSGoTo.init('.js-go-to');
        });

        $(window).on('load', function () {
            // initialization of header
            $.HSCore.components.HSHeader.init($('#js-header'));
            $.HSCore.helpers.HSHamburgers.init('.hamburger');

            // initialization of HSMegaMenu component
            $('.js-mega-menu').HSMegaMenu({
                event: 'hover',
                pageContainer: $('.container'),
                breakpoint: 991
            });
        });

        $(window).on('resize', function () {
            setTimeout(function () {
                $.HSCore.components.HSTabs.init('[role="tablist"]');
            }, 200);
        });
  </script>



</body>
</html>
