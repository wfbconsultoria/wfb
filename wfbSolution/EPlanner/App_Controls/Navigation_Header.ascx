<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Navigation_Header.ascx.vb" Inherits="EPlanner.Navigation_Header" %>
<%@ Register Src="~/App_Controls/Access_Control.ascx" TagPrefix="uc1" TagName="Access_Control" %>

<!-- Controle(ascx) controle de acesso-->
<uc1:Access_Control runat="server" ID="Access_Control" />

<!-- Barra de Navegação Padrão-->
<!-- Navigation Bar-->
<header id="topnav">

    <!-- Topbar Start Barra Superior -->
    <div class="navbar-custom" style="background-color:#081C3B">
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
                        <img src="assets/images/user.png" alt="user-image" class="rounded-circle" />
                    </a>
                    <div class="dropdown-menu dropdown-menu-right profile-dropdown ">
                        <!-- item EMAIL -->
                        <a href="javascript:void(0);" class="dropdown-item notify-item">
                            <span><%:Session("EMAIL_LOGIN").ToString%></span>
                        </a>
                        <!-- item NOME -->
                        <a href="javascript:void(0);" class="dropdown-item notify-item">
                            <i class="mdi mdi-account-outline"></i>
                            <span><%:Session("NOME_LOGIN").ToString%></span>
                        </a>
                        <!-- item LOJA -->
                        <a href="javascript:void(0);" class="dropdown-item notify-item">
                            <i class="mdi mdi-store"></i>
                            <span><%:Session("LOJA").ToString%></span>
                        </a>
                        <!-- item UNIVERSO -->
                        <a href="javascript:void(0);" class="dropdown-item notify-item">
                            <i class="mdi mdi-run"></i>
                            <span><%:Session("UNIVERSO").ToString%></span>
                        </a>
                        <!-- item-->
                        <a href="javascript:void(0);" class="dropdown-item notify-item">
                            <i class="mdi mdi-timetable"></i>
                            <span><%:Session("DATE_LOGIN").ToString%></span>
                        </a>

                        <!-- item-->
                        <a href="javascript:void(0);" class="dropdown-item notify-item">
                            <i class="mdi mdi-ip-network"></i>
                            <span><%:Session("IP_LOGIN").ToString%></span>
                        </a>

                        <!-- item-->
                        <a href="../Login.aspx" class="dropdown-item notify-item">
                            <i class="mdi mdi-logout"></i>
                            <span class="text-danger">Sair (Sign Out)</span>
                        </a>
                    </div>
                </li>
                <!--End User info menu logoff -->
            </ul>
            <!-- Right top menu -->

            <!-- LOGO -->
            <div class="logo-box">
                <a href="../Default.aspx" class="logo text-center logo-light">
                    <span class="logo-lg">
                        <img src="../assets/images/logo-bandeira-brasil.png" alt="" height="42" /> &nbsp;<span style="font-size: large; color: #FFFFFF; font-weight: bold">E-PLANNER</span>
                    </span>
                    <span class="logo-sm">
                        <img src="../assets/images/logo-bandeira-brasil.png" alt="" height="42" />&nbsp;<span style="font-size: large; color: #FFFFFF; font-weight: bold">E-PLANNER</span>
                    </span>
                </a>
                <a href="../Default.aspx" class="logo text-center logo-dark">
                    <span class="logo-lg">
                        <img src="../assets/images/logo-bandeira-brasil.png" alt="" height="42" />&nbsp;<span style="font-size: large; color: #FFFFFF; font-weight: bold">E-PLANNER</span>
                    </span>
                    <span class="logo-sm">
                        <img src="../assets/images/logo-bandeira-brasil.png" alt="" height="42" />&nbsp;<span style="font-size: large; color: #FFFFFF; font-weight: bold">E-PLANNER</span>
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

                    <!-- Link Home-->
                    <li class="has-submenu"><a href="../Default.aspx"><i class="mdi mdi-home"></i>Início</a></li>
                     <!-- Link Calendario Mes-->
                    <li class="has-submenu"><a href="#"><i class="mdi mdi-tools"></i>Configurações</a></li>

                    <!-- Combo-->
                    <li class="has-submenu">
                        <a href="#"><i class="mdi mdi-cards-outline"></i>Modelos<div class="arrow-down"></div></a>
                        <ul class="submenu">
                            <li><a href="../Modelo.aspx">Modelo Aspx</a></li>
                            <li><a href="../Datas_Selecao.aspx">Seleção de Datas</a></li>
                            <li><a href="https://app01.wfbconsultoria.net.br/" target="_blank">Flacto</a></li>
                            <li><a href="../Error.aspx">Erro</a></li>
                            <li><a href="../Login.aspx">Login</a></li>
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
