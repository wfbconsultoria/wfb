<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="App_Themes/MasterTheme/Login.css" rel="stylesheet" />
    <link href="Images/icon.png" rel="icon" type="Images/x-icon" />
    <title>Login</title>
 
    <style type="text/css">
        .auto-style3 {
            width: 116px;
            height: 51px;
        }

        #support {
            color: rgb(51,142,207);
            margin-top: -3px;
            font-size: 20px;
            font-family: Calibri;
            position: absolute;
        }
    </style>
 
</head>
<body style="background-color:#d9d9d9;">
<form id="form1" runat="server" enableviewstate="False">
    <div id="login_form">
    <br />
        
        <p style="text-align:center; width:100%; vertical-align:middle"><img alt=""  src="Images/hospira_Pfe_web-768x768.png" style="height: 197px; width: 291px" /></p>
        
        <p style="text-align:left; width:100%; vertical-align:middle">
            Digite o E-mail:<br />
            <asp:TextBox ID="txt_EMAIL" runat="server" Cssclass="label_login" ></asp:TextBox>&nbsp;
        </p>

        <p style="text-align:left; width:100%; vertical-align:middle">
            Senha:<asp:HyperLink ID="lnk_Troca_Senha" CssClass="esquecisenha_buton" runat="server" NavigateUrl="~/Troca_Senha.aspx">Esqueci a Senha</asp:HyperLink><br />
            <asp:TextBox ID="txt_SENHA" TextMode="Password" runat="server" Cssclass="label_login" ></asp:TextBox>
        </p>
        
        <br />
        <p style="text-align:left; width:100%; vertical-align:middle">
            <asp:Button ID="cmd_Login" runat="server" CssClass="buton_login" Text="Login" />
        </p>
        
        <br />

        <p style="margin-top: 10px;">
            <!-- link Support Lite -->
            <img  src="Images/Untitled-1.png" /> <span id="support">Suporte</span> <br />
            <!-- link Support Lite -->

            Telefone: (11)2408-0730 <br />
            E-mail: suporte@bihospitalar.com.br <br />
            Horários: 09:00 ás 17:00
        </p>
        <br />
       
        
        <p style="border-width: thin; border-color: #C0C0C0; text-align:center; width:100%; vertical-align:middle">
            <a href="https://security.trustsign.com.br?url=www.bihospitalar.com.br" target="_blank" style="text-align: left">
            <img alt="" class="auto-style3" src="Images/BiHospitalar_Sigla_250.png" /><img name="trustseal" alt="Site Autêntico" src="https://security.trustsign.com.br/static/seals/selo-pro-957329bd52122d204c96e132b5d329eb-pt.png" border="0" title="Clique para Validar" style="height: 60px; width: 111px" />
            </a>
        </p>
        <p style="text-align:center; width:100%; vertical-align:middle; font-family: 'Calibri Light'; font-size: xx-small;  color: #808080;">Waldomiro de Freitas Barbosa Informática Ltda - Guarulhos - SP - Brasil</p>
        <br />
    </div>
    
</form>
</body>
</html>

