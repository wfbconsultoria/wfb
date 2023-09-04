<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Distribuidores_Pesquisa_RF.aspx.vb" Inherits="Distribuidores_Pesquisa_RF" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Incluir Estabelecimento</title>
    <script src="JavaScript.js" type="text/javascript"></script>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            font-size: small;
        }
        .auto-style2 {
            color: #FF0000;
        }
    </style>
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Incluir Distribuidor</div>
    <div id ="Titulo_Pagina_Links">
        &nbsp;<a href="Menu_Distribuidor.aspx">Menu Distribuidor</a>
    </div>
</div>
<br /><br />
<div id ="Corpo">
    1 - Digite o número do CNPJ
    <asp:TextBox ID="txt_DOCUMENTO" runat="server" MaxLength="14" style="font-weight: 700"></asp:TextBox>
     <br />
    2 - Clique em
    <asp:Button ID="cmd_Consultar" runat="server" Text="Consultar" />
    &nbsp;<br />
    <span class="auto-style2"><span class="auto-style1">A consulta é efetuada na Receita Federal do Brasil</span><br class="auto-style1" />
    <span class="auto-style1">Somente podem ser incluído CNPJ válido</span></span><br />
    </div>
    </form>
</body>
</html>