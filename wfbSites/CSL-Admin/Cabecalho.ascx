<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Cabecalho.ascx.vb" Inherits="Header" %>
<link href="App_Themes/MasterTheme/Master.css" rel="stylesheet" />
<link href="Content/bootstrap.min.css" rel="stylesheet" />
<script src="JavaScript.js"></script>
<script src="Scripts/jquery-3.1.1.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
<style type="text/css">
    .auto-style1 {
        width: 92px;
    }

    .row {
        margin-bottom: 10px;
    }
</style>

    <link rel="icon" href="Images/icon.png" />
<!-- Menu -->
<div class="navbar navbar-default navbar-fixed-top" style="background-color: #ffffff;border-bottom: solid; border-bottom-color: #99c3c1; position: relative;">
    <div class="container">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <!-- Logo -->
            <a class="navbar-brand" style="padding-bottom: 9px; padding-top: 3px; margin-right: 20px;" href="#">
                <img class="img-responsive img-rounded" src="Images/CSLBehringRGBhighres.png" style="width: 130px; height: 45px;" />
            </a>
            <!--/Logo -->
        </div>
        <div class="navbar-collapse collapse">
            <div class="navbar-form">
                <!-- Informações do login -->
                <asp:Label ID="lbl_Login" runat="server" Text="Label" Font-Size="x-Small" ForeColor="Gray"></asp:Label>&nbsp;
                   <a href="Login.aspx" style="font-size: small; color: #FF0000;">sair</a>

                <!-- Opções do menu -->
                <div class=" form-inline">
                    <div class="form-group">
                        <a class="linkcolorido" href="Default.aspx">Início</a>&nbsp;
                    </div>
                    <div class="form-group">
                        <a class="linkcolorido" href="Estabelecimentos_Localizar.aspx">Meus Estabelecimentos</a>&nbsp;
                    </div>
                    <div class="form-group">
                        <a class="linkcolorido" href="Menu_Listas.aspx">Listas</a>&nbsp;
                    </div>
                    <div class="form-group">
                        <a class="linkcolorido" href="Menu_relatórios.aspx">Relatórios</a>&nbsp;
                    </div>
                    <div class="form-group">
                        <a class="linkcolorido" href="Menu_operações.aspx">Operações</a>&nbsp;
                    </div>
                                        <div class="form-group">
                        <a class="linkcolorido" href="Menu_sistema.aspx">Sistema</a>&nbsp;
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
