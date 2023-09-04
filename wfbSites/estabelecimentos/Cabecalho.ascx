<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Cabecalho.ascx.vb" Inherits="Cabecalho" %>

<link rel="stylesheet" type="text/css" href="Content/bootstrap.min.css" />
<link rel="stylesheet" type="text/css" href="Content/personalizado2.css"/>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="Plugins/js/bootstrap.min.js" type="text/javascript"></script>


<!-- Cabecalho -->
<div class="navbar navbar-default navbar-fixed-top" style="border-bottom: solid; border-bottom-color: #3581C4;">
    <div class="container">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <!-- Logo -->
                <img class="img-responsive" src="Images/Logo menor.png" style="margin-bottom: 2%;" />
            <!--/Logo -->
        </div>
        <div class="navbar-collapse collapse">
            <ul class="nav navbar-nav navbar-right">
                <li><a runat="server" href="~/Cadastrar_Manual.aspx">Cadastrar (Manual)</a></li>
                <li><a runat="server" href="~/Estabelecimentos_Pesquisar_RF.aspx">Cadastrar (Pesquisar na Receita)</a></li>
            </ul>
        </div>
    </div>
</div>
<!-- Cabecalho -->

