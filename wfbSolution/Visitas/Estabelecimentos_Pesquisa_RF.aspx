<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Pesquisa_RF.aspx.vb" Inherits="Estabelecimentos_Pesquisa_RF" %>

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

<form id="form1" runat="server">
<uc1:Cabecalho runat="server" id="Cabecalho" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Incluir Cliente</div>
    <div id ="Titulo_Pagina_Links">
        <a href="Menu_operações.aspx">Voltar/Cancelar</a>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    Incluir um novo cliente:<br />
    1 - Selecione a personalidade jurídica
    <asp:DropDownList ID="cmb_TIPO_PESSOA" runat="server" DataSourceID="dts_TIPO_PESSOA" DataTextField="TIPO_PESSOA" DataValueField="COD_TIPO_PESSOA">
    </asp:DropDownList>
    &nbsp;
    <br />
    2 - Digite o número do documento (CNPJ ou CPF)
    <asp:TextBox ID="txt_DOCUMENTO" runat="server" MaxLength="14" style="font-weight: 700"></asp:TextBox>
     <br />
    3 - Clique em
    <asp:Button ID="cmd_Consultar" runat="server" Text="Consultar" />
    &nbsp;<br />
    <span class="auto-style2"><span class="auto-style1">A consulta é efetuada na Receita Federal do Brasil</span><br class="auto-style1" />
    <span class="auto-style1">Somente podem ser incluído CNPJ ou CPF válido</span></span><br />
    &nbsp;<asp:SqlDataSource ID="dts_TIPO_PESSOA" runat="server" ConnectionString="<%$ ConnectionStrings:cnnReceitaFederal %>" SelectCommand="SELECT * FROM [TBL_RF_TIPO_PESSOA]"></asp:SqlDataSource>
</div>
</form>
</body>
</html>
