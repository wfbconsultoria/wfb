<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Navigation_Header.ascx.vb" Inherits="Flacto.Navigation_Header" %>

<!-- Navigation Bar-->
<header id="topnav">
    
    <!-- Topbar Start Barra Superior -->
    <div class="navbar-custom">
        <div class="container-fluid">
            <!-- Right top menu -->
            <ul class="list-unstyled topnav-menu float-right mb-0">

                <!-- Mobile menu toggle SANDUICHE-->
                <li class="dropdown notification-list">
                    <a class="navbar-toggle nav-link">
                        <div class="lines">
                            <span></span>
                            <span></span>
                            <span></span>
                        </div>
                    </a>
                </li>
                <!-- End mobile menu toggle SANDUICHE-->

                <!--User info menu logoff -->
                <li class="dropdown notification-list">
                    <a class="nav-link dropdown-toggle nav-user mr-0 waves-effect waves-light" data-toggle="dropdown" href="#" role="button" aria-haspopup="false" aria-expanded="false">
                        <img src="assets/images/users/avatar-1.jpg" alt="user-image" class="rounded-circle" />
                    </a>
                    <div class="dropdown-menu dropdown-menu-right profile-dropdown ">
                        <!-- item-->
                        <div class="dropdown-header noti-title">
                            <h6 class="text-overflow m-0">Welcome !</h6>
                        </div>

                        <!-- item-->
                        <a href="javascript:void(0);" class="dropdown-item notify-item">
                            <i class="mdi mdi-account-outline"></i>
                            <span>Profile</span>
                        </a>

                        <!-- item-->
                        <a href="javascript:void(0);" class="dropdown-item notify-item">
                            <i class="mdi mdi-settings-outline"></i>
                            <span>Settings</span>
                        </a>

                        <!-- item-->
                        <a href="javascript:void(0);" class="dropdown-item notify-item">
                            <i class="mdi mdi-lock-outline"></i>
                            <span>Lock Screen</span>
                        </a>
                    </div>
                </li>
                <!--End User info menu logoff -->
            </ul>
            <!-- Right top menu -->

            <!-- LOGO -->
            <div class="logo-box">
                <a href="index.html" class="logo text-center logo-light">
                    <span class="logo-lg">
                        <img src="assets/images/logo-light.png" alt="" height="16" />
                        <!-- <span class="logo-lg-text-light">Flacto</span> -->
                    </span>
                    <span class="logo-sm">
                        <!-- <span class="logo-sm-text-dark">F</span> -->
                        <img src="assets/images/logo-sm.png" alt="" height="22" />
                    </span>
                </a>

                <a href="index.html" class="logo text-center logo-dark">
                    <span class="logo-lg">
                        <img src="assets/images/logo.png" alt="" height="16" />
                        <!-- <span class="logo-lg-text-dark">Flacto</span> -->
                    </span>
                    <span class="logo-sm">
                        <!-- <span class="logo-lg-text-dark">F</span> -->
                        <img src="assets/images/logo-sm.png" alt="" height="22" />
                    </span>
                </a>
            </div>
            <!-- End LOGO -->

            <div class="clearfix"></div>
        </div>
    </div>
    <!-- End Topbar Barra Superior -->

    <!--Barra de menus inferior (cinza)  -->
    <div class="topbar-menu">
        <div class="container-fluid">
            <div id="navigation">
                
                <!-- Navigation Menu-->
                <ul class="navigation-menu">
                    
                    <!-- Link-->
                    <li class="has-submenu"><a href="index.html"><i class="mdi mdi-speedometer"></i>Dashboard</a></li>
                    <!-- Link-->
                    <li class="has-submenu"><a href="index.html"><i class="mdi mdi-speedometer"></i>Dashboard</a></li>

                    <!-- Combo-->
                    <li class="has-submenu">
                        <a href="#"><i class="mdi mdi-cards-outline"></i>Pages<div class="arrow-down"></div></a>
                        <ul class="submenu">
                            <li><a href="pages-starter.html">Starter Page</a></li>
                            <li><a href="pages-timeline.html">Timeline</a></li>
                            <li><a href="pages-login.html">Login</a></li>
                            <li><a href="pages-register.html">Register</a></li>
                            <li><a href="pages-recoverpw.html">Recover Password</a></li>
                            <li><a href="pages-lock-screen.html">Lock Screen</a></li>
                            <li><a href="pages-confirm-mail.html">Confirm Mail</a></li>
                            <li><a href="pages-404.html">Error 404</a></li>
                        </ul>
                    </li>

                </ul>
                <!-- End navigation menu -->
                <div class="clearfix"></div>
            </div>
            <!-- end #navigation -->
        </div>
        <!-- end container -->
    </div>
    <!--End Barra de menus inferior (cinza)  -->

</header>
<!-- End Navigation Bar-->
