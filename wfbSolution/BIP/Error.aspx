<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Error.aspx.vb" Inherits="BIP._Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required Meta Tags Always Come First -->
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <title>Erro</title>

    <!-- Favicon -->
    <link rel="shortcut icon" href="favicon.ico" />
    <!-- Google Fonts -->
    <link rel="stylesheet" href="//fonts.googleapis.com/css?family=Open+Sans%3A400%2C300%2C500%2C600%2C700%7CPlayfair+Display%7CRoboto%7CRaleway%7CSpectral%7CRubik" />
    <!-- CSS Global Compulsory -->
    <link rel="stylesheet" href="assets/vendor/bootstrap/bootstrap.min.css" />
    <!-- CSS Unify -->
    <link rel="stylesheet" href="assets/css/unify-core.css" />
    <link rel="stylesheet" href="assets/css/unify-components.css" />
    <link rel="stylesheet" href="assets/css/unify-globals.css" />

    <!-- CSS Customization -->
    <link rel="stylesheet" href="assets/css/custom.css" />

</head>
<body>
    <form id="frm_Error" runat="server">
        <main class="g-min-height-100vh g-flex-centered g-pa-15">
            <div class="text-center g-flex-centered-item g-position-rel g-pb-15">
                <div class="g-font-size-180 g-font-size-240--sm g-line-height-1 g-font-weight-600er g-color-gray-light-v4"><%:Request.QueryString("ErrNumber") %></div>

                <div class="g-absolute-centered">
                    <h5 class="g-color-black g-mt-minus-8 mb-0"><%:Request.QueryString("ErrDescription") %></h5>
                    <hr class="g-brd-gray-light-v3 g-my-15" />
                    <p class="g-color-black g-mt-minus-8 mb-0"><%:Request.QueryString("ErrMessage") %></p>
                    <hr class="g-brd-gray-light-v3 g-my-15" />
                    <p class="g-color-black g-mt-minus-8 mb-0"><%:Request.QueryString("ErrLocation") %></p>
                    <hr class="g-brd-gray-light-v3 g-my-15" />
                    
                    <p class="g-font-size-18 mb-0">
                        <a href="Default.aspx" class="g-color-black g-color-primary--hover g-text-no-underline--hover">← Home Page</a>
                    </p>
                </div>
            </div>
        </main>
    </form>

    <!-- JS Global Compulsory -->
    <script src="assets/vendor/jquery/jquery.min.js"></script>
    <script src="assets/vendor/jquery-migrate/jquery-migrate.min.js"></script>
    <script src="assets/vendor/popper.js/popper.min.js"></script>
    <script src="assets/vendor/bootstrap/bootstrap.min.js"></script>

    <!-- JS Customization -->
    <script src="assets/js/custom.js"></script>
</body>
</html>
