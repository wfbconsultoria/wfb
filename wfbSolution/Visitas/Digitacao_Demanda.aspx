<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Digitacao_Demanda.aspx.vb" Inherits="Digitacao_Demanda" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Digitar Demanda</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Digitar Demanda</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>    
<br />
<div id ="Corpo">
    <br />
    1 - Pesquise o estabelecimento, selecione na lista abaixo
    <br />
    2 - Preencha todos os dados COM ATENÇÃO e depois clique em gravar
    <br />
    Localizar Estabelecimento
    <br />
    Que contenha
    <br />
    <asp:TextBox ID="txt_Parametro" runat="server" style="text-align: left; " Width="25%" MaxLength="200" CssClass="style5"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv_Parametro" runat="server" ControlToValidate="txt_Parametro" ErrorMessage="DIGITE O PARÂMETRO"></asp:RequiredFieldValidator>
    <br />
    Na coluna
    <br />
    <asp:DropDownList 
        ID="cmb_Filtro" runat="server">
        <asp:ListItem Selected="True">CNPJ</asp:ListItem>
        <asp:ListItem Value="ESTABELECIMENTO">Nome Fantasia</asp:ListItem>
        <asp:ListItem Value="RAZAO_SOCIAL">Razão Social</asp:ListItem>
        <asp:ListItem Value="MUNICIPIO">Município</asp:ListItem>
        <asp:ListItem Value="UF">UF</asp:ListItem>
        <asp:ListItem Value="CNES">CNES</asp:ListItem>
    </asp:DropDownList>
    <br />
    Classificando por
    <br /> 
    <asp:DropDownList 
        ID="cmb_Ordem" runat="server">
        <asp:ListItem Value="ESTABELECIMENTO" Selected="True">Nome Fantasia</asp:ListItem>
        <asp:ListItem Value="RAZAO_SOCIAL">Razão Social</asp:ListItem>
        <asp:ListItem>CNPJ</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="cmd_Pesquisar" runat="server" Text="Pesquisar" />
    <br /><br />
    Digitar Demanda
    <br />
    Ano
    <br />
    <asp:DropDownList ID="cmb_ANO" runat="server" DataSourceID="dts_Anos" DataTextField="ANO_VALOR" DataValueField="ANO_VALOR"></asp:DropDownList>
    <br />
    Mês
    <br />
    <asp:DropDownList ID="cmb_MES" runat="server" 
        DataSourceID="dts_Meses" DataTextField="MES_SIGLA" 
        DataValueField="MES_NUMERO_VALOR">
    </asp:DropDownList>
    <br />
    Distribuidor
    <br />
    <asp:DropDownList 
        ID="cmb_CNPJ_DISTRIBUIDOR" runat="server" DataSourceID="dts_Distribuidores" 
        DataTextField="DISTRIBUIDOR" DataValueField="CNPJ">
    </asp:DropDownList>
    <br />
    Produto
    <br />
    <asp:DropDownList ID="cmb_COD_PRODUTO" runat="server" 
        DataSourceID="dts_Produtos" DataTextField="PRODUTO" 
        DataValueField="COD">
    </asp:DropDownList>
    <br />
    Quantidade
    <br />    
    <asp:TextBox ID="txt_QTD" runat="server" style="text-align: center; font-weight: 700"></asp:TextBox>
    <br />
    <asp:Button ID="cmd_Gravar" runat="server" Text="Gravar" CausesValidation="False" />
    <br />
        <asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" 
            CellPadding="3" DataKeyNames="CNPJ" 
            DataSourceID="dts_Estabelecimentos" 
            GridLines="Vertical" Width="100%" CaptionAlign="Left" 
        ForeColor="Black" BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
        BorderWidth="1px">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Digitar" >
                <HeaderStyle HorizontalAlign="Center" Width="2%" />
                <ItemStyle Font-Bold="True" ForeColor="Blue" HorizontalAlign="Center" 
                    Width="2%" />
                </asp:CommandField>
                <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" SortExpression="CNPJ" >
                <HeaderStyle HorizontalAlign="Center" Width="7%" />
                <ItemStyle HorizontalAlign="Right" Width="7%" />
                </asp:BoundField>
                <asp:BoundField DataField="ESTABELECIMENTO" HeaderText="ESTABELECIMENTO" 
                    SortExpression="ESTABELECIMENTO" />
                <asp:BoundField DataField="RAZAO_SOCIAL" HeaderText="RAZÃO SOCIAL" 
                    SortExpression="RAZAO_SOCIAL" />
                <asp:BoundField DataField="ESFERA" HeaderText="ESFERA" 
                    SortExpression="ESFERA" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" 
                HorizontalAlign="Left" VerticalAlign="Middle" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
</div>
    <asp:SqlDataSource ID="dts_Anos" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT [ANO_VALOR] FROM [TBL_DATAS_ANOS] WHERE ([ANO_FECHADO] = @ANO_FECHADO)">
            <SelectParameters>
                <asp:Parameter DefaultValue="False" Name="ANO_FECHADO" Type="Boolean" />
            </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Meses" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_DATAS_MESES] WHERE ([MES_FECHADO] = @MES_FECHADO)">
        <SelectParameters>
            <asp:Parameter DefaultValue="False" Name="MES_FECHADO" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Distribuidores" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_DISTRIBUIDORES] WHERE ([CAPTAR_DEMANDA] = @CAPTAR_DEMANDA) ORDER BY [GRUPO], [DISTRIBUIDOR]">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="CAPTAR_DEMANDA" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Estabelecimentos" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS] ORDER BY [ESTABELECIMENTO_CNPJ]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Produtos" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT COD, COD_REDUZIDO, PRODUTO + ' - ' + COD AS PRODUTO, COD_DIVISAO, DIVISAO, COD_TIPO, TIPO, COD_LINHA, LINHA, COD_GRUPO, GRUPO, COD_GRUPO_BOMBAS, GRUPO_BOMBA, SUB_GRUPO_BOMBA, ATIVO, ANALISAR, COTA, CAPTAR_DEMANDA, QTD_EMBALAGEM_VENDA, ASP, PRECO_BASE_BRL, PRECO_BASE_USD, PRODUTO + ' - ' + COD AS PRODUTO_DETALHADO FROM VIEW_PRODUTOS WHERE (CAPTAR_DEMANDA = @CAPTAR_DEMANDA) ORDER BY PRODUTO + ' - ' + COD">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="CAPTAR_DEMANDA" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
</form>
</body>
</html>
