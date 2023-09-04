<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Distribuidores_Localizar.aspx.vb" Inherits="Distribuidores_Localizar" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Distribuidores</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
<uc1:Cabecalho runat="server" id="Cabecalho" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Distribuidores</div>
    <div id ="Titulo_Pagina_Links">
        <asp:HyperLink ID="lnk_Distribuidores_Incluir_RF" runat="server" NavigateUrl="~/Distribuidores_Pesquisa_RF.aspx">Incluir</asp:HyperLink>&nbsp;
        &nbsp;<a href="Menu_Distribuidor.aspx">Menu Distribuidor</a>
        <asp:LinkButton ID="cmd_Excel" runat="server">Excel</asp:LinkButton>&nbsp;
    </div>
</div>
<br />
<div id ="Corpo">
    <asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" DataSourceID="dts_Localizar" AllowSorting="True" Width="100%">
        <Columns>
              <asp:HyperLinkField DataNavigateUrlFields="CNPJ" 
                DataNavigateUrlFormatString="Distribuidores_Ficha.aspx?CNPJ={0}" 
                HeaderText="CNPJ" DataTextField="CNPJ" 
                SortExpression="CNPJ" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%" />
            </asp:HyperLinkField>
             <asp:BoundField DataField="GRUPO_DISTRIBUIDOR" HeaderText="Grupo Distribuidor" SortExpression="GRUPO_DISTRIBUIDOR">
            </asp:BoundField>
            <asp:BoundField DataField="ESTABELECIMENTO" HeaderText="Estabelecimento" SortExpression="ESTABELECIMENTO">
            </asp:BoundField>
            <asp:BoundField DataField="MUNICIPIO" HeaderText="Cidade" SortExpression="MUNICIPIO" >
            </asp:BoundField>
            <asp:BoundField DataField="UF" HeaderText="UF" SortExpression="UF" />
            <asp:BoundField DataField="ESFERA" HeaderText="Esfera" SortExpression="ESFERA" />
            <asp:BoundField DataField="PERIODO_INICIO_MES" HeaderText="Inicio Mes" SortExpression="PERIODO_INICIO_MES">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="PERIODO_INICIO_ANO" HeaderText="Inicio Ano" SortExpression="PERIODO_INICIO_ANO">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:CheckBoxField DataField="CAPTAR_ESTOQUE" HeaderText="Captar Estoque" SortExpression="CAPTAR_ESTOQUE">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CheckBoxField>
            <asp:CheckBoxField DataField="CAPTAR_DEMANDA" HeaderText="Captar Demanda" SortExpression="CAPTAR_DEMANDA">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CheckBoxField>
            <asp:CheckBoxField DataField="ATIVO" HeaderText="Ativo" SortExpression="ATIVO">
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CheckBoxField>
        </Columns>
    </asp:GridView> 
</div>
<br />
<asp:SqlDataSource ID="dts_Localizar" runat="server" 
    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
    SelectCommand="SELECT * FROM [VIEW_DISTRIBUIDORES_001_DETALHADO] ORDER BY [GRUPO_DISTRIBUIDOR], [NOME_FANTASIA], [CNPJ]">
</asp:SqlDataSource>
</form>
</body>
</html>