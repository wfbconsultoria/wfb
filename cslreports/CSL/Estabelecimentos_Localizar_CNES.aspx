<%@ Page Title="Meus Estabelecimentos" Language="VB" CodeFile="Estabelecimentos_Localizar_CNES.aspx.vb" Inherits="Estabelecimentos_Localizar_CNES" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
<uc1:Cabecalho runat="server" id="Cabecalho" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Clientes</div>
    <div id ="Titulo_Pagina_Links">
    </div>
</div>
<br />
<div id ="Corpo">
    <asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" DataSourceID="dts_Localizar" AllowSorting="True" Width="100%">
        <Columns>
             <asp:BoundField DataField="Origem" HeaderText="Origem" SortExpression="Origem">
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="cnes" DataNavigateUrlFormatString="Estabelecimento_Ficha_CNES.aspx?CNES={0}" DataTextField="CNES" HeaderText="CNES" />
            <asp:BoundField DataField="ESTABELECIMENTO" HeaderText="Estabelecimento" SortExpression="ESTABELECIMENTO">
            </asp:BoundField>
            <asp:BoundField DataField="Cidade" HeaderText="Cidade" SortExpression="Cidade" />
            <asp:BoundField DataField="UF" HeaderText="UF" SortExpression="UF" />
        </Columns>
    </asp:GridView> 
</div>
<br />
<asp:SqlDataSource ID="dts_Localizar" runat="server" 
    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
    SelectCommand="SELECT * FROM [tbl_CNES_Estabelecimentos_Mercado] ORDER BY [ESTABELECIMENTO]">
</asp:SqlDataSource>
</form>
</body>
</html>