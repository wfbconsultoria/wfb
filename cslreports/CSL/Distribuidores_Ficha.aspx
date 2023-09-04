<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Distribuidores_Ficha.aspx.vb" Inherits="Distribuidores_Ficha" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ficha do Estabelecimento</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            color: #0066CB;
        }
        </style>
    </head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Ficha de Distribuidor</div>
    <div id ="Titulo_Pagina_Links">
        &nbsp;<a href="Distribuidores_Editar.aspx?CNPJ=<%=Request.QueryString("CNPJ")%>">Alterar</a>&nbsp;
        &nbsp;<a href="Menu_Distribuidor.aspx">Menu Distribuidor</a>
    </div>
</div>
<br />
<div id ="Corpo">
    <br/>
    <asp:FormView ID="frm_Distribuidor_Ficha" runat="server" DataSourceID="dts_Distribuidor" Width="100%">
        <EditItemTemplate></EditItemTemplate>
        <InsertItemTemplate></InsertItemTemplate>
        <ItemTemplate>
            <asp:Label ID="ESTABELECIMENTO_CNPJ_Label" runat="server" style="font-weight: 700" Text='<%# Bind("NOME_FANTASIA") %>' />
            <br />
            <asp:Label ID="RAZAO_SOCIAL_Label" runat="server" Text='<%# Bind("RAZAO_SOCIAL") %>' />
            <br />
            <asp:Label ID="ENDERECO_Label" runat="server" Text='<%# Bind("ENDERECO") %>' />
            &nbsp;-
            <asp:Label ID="BAIRRO_Label" runat="server" Text='<%# Bind("BAIRRO") %>' />
            <br />
            <asp:Label ID="MUNICIPIO_Label" runat="server" Text='<%# Bind("MUNICIPIO") %>' />
            &nbsp;-
            <asp:Label ID="UF_Label" runat="server" Text='<%# Bind("UF") %>' />
            <br />
            Documento
            <asp:Label ID="CNPJ_FORMATADO_Label" runat="server" Text='<%# Bind("CNPJ_FORMATADO") %>' />
            <br />
        </ItemTemplate>
     </asp:FormView>
    <hr />
</div>
    <asp:SqlDataSource ID="dts_Distribuidor" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [VIEW_DISTRIBUIDORES_001_DETALHADO] WHERE ([CNPJ] = @CNPJ)">
        <SelectParameters>
            <asp:QueryStringParameter Name="CNPJ" QueryStringField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
</form> 
</body>
</html>