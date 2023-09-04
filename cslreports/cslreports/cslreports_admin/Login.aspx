<%@ Page Title="Login" Language="VB" MasterPageFile="~/Site.Public.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="row">
        <div class="col-md-4 col-sm-3"></div>
        <!-- div para manter reponsividade -->
        <!-- Conteudo da página -->
        <div class="container col-md-4 col-sm-6" style="margin-top: -5px; padding: 50px;">
            <!-- Titulo -->
            <div class="row">
                <img class="img-responsive img-rounded" src="Images/CSL.png" style="width: 200px; height: 100px; margin: 10px auto;" />
                <h2 style="text-align: center; font-size: 20px; color: black;">Reports 2020</h2>
            </div>
            <!-- Nome -->
            <div class="row">
                <asp:Label ID="lbl_email" runat="server" Text="Usuário" AssociatedControlID="txtEmail" CssClass="control-label"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" placeholder="e-mail sem o domínio" CssClass="form-control" CausesValidation="true"></asp:TextBox>

            </div>

            <!--Email domain -->
            <div class="row">
                <asp:Label ID="lbl_dominio" runat="server" Text="Selecione o domínio do seu e-mail:" AssociatedControlID="EmailDomain" CssClass="control-label"></asp:Label>
                <asp:DropDownList ID="EmailDomain" runat="server" DataSourceID="dts_EmailDomain" CssClass="form-control" DataTextField="USER_DOMAIN" DataValueField="USER_DOMAIN"></asp:DropDownList>
            </div>

            <!-- Senha -->
            <div class="row">
                <asp:Label ID="lbl_password" runat="server" Text="Senha:" AssociatedControlID="txtPassword" CssClass="control-label"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="sua senha" TextMode="Password"></asp:TextBox>
            </div>

            <div class="row">
                <!--Login-->
                <asp:LinkButton ID="cmdLogin" runat="server" CssClass="form-control btn btn-sm" Enabled="true" Style="text-align: center; background-color: black; color: white; font-size: medium">Log In</asp:LinkButton>
            </div>
            <div class="row">
                <!--Certificate Image-->
                <script type="text/javascript"> //<![CDATA[
                        var tlJsHost = ((window.location.protocol == "https:") ? "https://secure.trust-provider.com/" : "http://www.trustlogo.com/");
                        document.write(unescape("%3Cscript src='" + tlJsHost + "trustlogo/javascript/trustlogo.js' type='text/javascript'%3E%3C/script%3E"));
                        //]]>
                </script>
                <script language="JavaScript" type="text/javascript">
                TrustLogo("https://www.positivessl.com/images/seals/positivessl_trust_seal_lg_222x54.png", "POSDV", "none");
                </script>
                
            </div>
            <div class="row">
                <!-- Recuperar senha -->
                <asp:LinkButton ID="cmd_Forgot" runat="server" Style="text-align: center; text-decoration-line: underline; color: black"><%:ConfigurationManager.AppSettings("menu.Forgot") %></asp:LinkButton>
            </div>
            <asp:Literal ID="ltr_teste" runat="server"></asp:Literal>
        </div>


        <div class="col-md-4 col-sm-3"></div>
        <!-- div para manter reponsividade -->

        <!--Data Sources -->
        <asp:SqlDataSource ID="dts_EmailDomain" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [USER_DOMAIN] FROM [tb_Users_Domains] ORDER BY [ID] ASC"></asp:SqlDataSource>
    </div>

</asp:Content>

