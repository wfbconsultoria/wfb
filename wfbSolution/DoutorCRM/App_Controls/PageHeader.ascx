<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PageHeader.ascx.vb" Inherits="DoutorCRM.PageHeader" %>
<!-- VERFRIFICA LOGIN -->
<%If Session("EMAIL_LOGIN") = "" Then Response.Redirect("Login.aspx") %>

<!-- Barra de Navegação (nav) -->
<nav class="navbar navbar-expand-lg fixed-top navbar-dark bg-primary">
    
    <!-- Rotulo com nome da página atual -->
    <a class="navbar-brand mr-auto mr-lg-0" href="#">
        <span class="text-uppercase font-weight-bolder"><%:Page.Title%></span>
    </a>
    
    <!-- Menu sanduiche -->
    <button class="navbar-toggler p-0 border-0" type="button" data-toggle="offcanvas">
        <span class="navbar-toggler-icon"></span>
    </button>

    <div class="navbar-collapse offcanvas-collapse">
        
        <!-- Itens de Menu -->
        <ul class="navbar-nav mr-auto">
            <li class="nav-item "><a class="nav-link" href="Default.aspx">Início</a></li>
            <li class="nav-item "><a class="nav-link" href="Medicos_Lista.aspx">Médicos</a></li>
            <li class="nav-item "><a class="nav-link" href="Medico.aspx">Medico</a></li>
        </ul>

        <!-- Menu Usuario -->
        <div class="my-2 my-lg-0">
            <ul class="navbar-nav mr-auto">
                <li id="menu_LoginInfo" class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="dropdown_LoginInfo" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><%:Session("EMAIL_LOGIN").ToString %></a>
                    <div class="dropdown-menu" aria-labelledby="dropdown_LoginInfo">
                        <a class="dropdown-item text-alert" href="../User_Password_Change.aspx">Alterar Senha</a>
                    </div>
                </li>
                <li class="nav-item "><a class="nav-link text-danger" href="Login.aspx">Sair</a></li>
            </ul>
        </div>
    
    </div>
</nav>
<br />