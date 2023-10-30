<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Digitacao_Demanda_Transferencia.aspx.vb" Inherits="Digitacao_Demanda_Transferencia" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Tranferir Demanda</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style5 {
            color: #FF0000;
        }
    </style>
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Tranferir Demanda</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>    
<br />
<div id ="Corpo">
    <br />
    <span class="auto-style5">Transfere demanda de um estabelecimento para outro</span>
    <br />
    <br />
    Estabelecimento DE
    <br />
    <span>
        &nbsp;<asp:DropDownList 
            ID="cmb_CNPJ_ESTABELECIMENTO_DE" runat="server" 
            DataSourceID="dts_Estabelecimentos" DataTextField="ESTABELECIMENTO_CNPJ" 
            DataValueField="CNPJ">
        </asp:DropDownList>
        <asp:SqlDataSource ID="dts_Estabelecimentos" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS] ORDER BY [ESTABELECIMENTO_CNPJ]">
        </asp:SqlDataSource>
    </span>
    <br />
    <br />
    Estabelecimento PARA
    <br />
    <span>
        &nbsp;<asp:DropDownList 
            ID="cmb_CNPJ_ESTABELECIMENTO_PARA" runat="server" 
            DataSourceID="dts_Estabelecimentos0" DataTextField="ESTABELECIMENTO_CNPJ" 
            DataValueField="CNPJ">
       </asp:DropDownList>
       <asp:SqlDataSource ID="dts_Estabelecimentos0" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS] ORDER BY [ESTABELECIMENTO_CNPJ]">
       </asp:SqlDataSource>
    </span>
    <br />
    <br />
    <asp:Button ID="cmd_Gravar" runat="server" Text="Gravar" />
</div>
</form>
</body>
</html>
