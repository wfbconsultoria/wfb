<%@ Page Title="Meus Estabelecimentos" Language="VB" CodeFile="Estabelecimentos_Localizar.aspx.vb" Inherits="Estabelecimentos_Localizar"  EnableEventValidation ="false" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Meus Estabelecimentos</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
<uc1:Cabecalho runat="server" id="Cabecalho" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Meus Estabelecimentos</div>
    <div id ="Titulo_Pagina_Links">
        <asp:LinkButton ID="cmd_Excel" runat="server">Exportar para Excel</asp:LinkButton>&nbsp;
    </div>
</div>
<br />
<div id ="Corpo">
    <asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" DataSourceID="dts_Localizar" AllowSorting="True" Width="100%">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="CNPJ" 
                DataNavigateUrlFormatString="Estabelecimentos_Ficha.aspx?CNPJ={0}" 
                HeaderText="Estabelecimento" DataTextField="ESTABELECIMENTO" 
                SortExpression="ESTABELECIMENTO" >
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" SortExpression="CNPJ">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="MUNICIPIO" HeaderText="Cidade" SortExpression="MUNICIPIO">
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="UF" HeaderText="UF" SortExpression="UF">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="TARGET_2" HeaderText="Target" SortExpression="TARGET">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="REPRESENTANTE" HeaderText="Representante" SortExpression="REPRESENTANTE" >
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
    </asp:GridView> 
</div>
<br />
<asp:SqlDataSource ID="dts_Localizar" runat="server" 
    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
    SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO] ORDER BY [ESTABELECIMENTO]">
</asp:SqlDataSource>
</form>
</body>
</html>