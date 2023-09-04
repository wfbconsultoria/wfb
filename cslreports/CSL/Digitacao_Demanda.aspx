<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Digitacao_Demanda.aspx.vb" Inherits="Digitacao_Demanda" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Digitação de Mapas</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Digitação de Mapas</div>
    <div id ="Titulo_Pagina_Links">
        
    </div>
</div>
<br />
<div id ="Corpo">
        <br />
            Pesquise o estabelecimento, selecione na lista abaixo<br />
            Preencha todos os dados <strong>COM ATENÇÃO</strong> e depois clique em gravar
        <br /><br />
        <b>Localizar Estabelecimento</b>
        <br />
        Que contenha
        <br />
                    <asp:TextBox ID="txt_Parametro" runat="server" style="text-align: left; " Width="25%" MaxLength="200"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_Parametro" runat="server" ControlToValidate="txt_Parametro" ErrorMessage="DIGITE O PARÂMETRO"></asp:RequiredFieldValidator>
        <br />
         Na coluna
        <br />
                    <asp:DropDownList 
                        ID="cmb_Filtro" runat="server">
                        <asp:ListItem Selected="True">CNPJ</asp:ListItem>
                        <asp:ListItem Value="ESTABELECIMENTO">Estabelecimento</asp:ListItem>
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
                        <asp:ListItem>CNPJ</asp:ListItem>
                    </asp:DropDownList>
            <br /><br />
            <asp:Button ID="cmd_Pesquisar" runat="server" CssClass="buton_gravar" Text="Pesquisar" /></td>
            <br /><br />
             <b>Digitar Demanda</b>
            <br />
             Ano
             <br />
             <asp:DropDownList ID="cmb_ANO" runat="server" DataSourceID="dts_Anos" 
                            DataTextField="ANO_VALOR" DataValueField="ANO_VALOR">
                        </asp:DropDownList>
             <br />
             Mês
             <br />
            <asp:DropDownList ID="cmb_MES" runat="server" DataSourceID="dts_Meses" DataTextField="MES_SIGLA" DataValueField="MES"></asp:DropDownList>
           <br />
        Dia<br />
        <asp:DropDownList ID="cmb_DIA" runat="server" DataSourceID="dts_dia" DataTextField="DIA_EXTENSO" DataValueField="DIA">
        </asp:DropDownList>
           <br />
           Distribuidor
            <br />
                    <asp:DropDownList 
                        ID="cmb_CNPJ_DISTRIBUIDOR" runat="server" DataSourceID="dts_Distribuidores" 
                        DataTextField="ESTABELECIMENTO_CNPJ" DataValueField="CNPJ">
                    </asp:DropDownList>
        <br />
             Produto
        <br />
                    <asp:DropDownList ID="cmb_COD_PRODUTO" runat="server" 
                        DataSourceID="dts_Produtos" DataTextField="PRODUTO" 
                        DataValueField="COD_PRODUTO">
                    </asp:DropDownList>
            <br />
             Quantidade
             <br />
                <asp:TextBox ID="txt_QTD" runat="server" style="text-align: center; font-weight: 700"></asp:TextBox>
            <br /><br />
                <asp:Button ID="cmd_Gravar" runat="server" Text="Gravar" CssClass="buton_gravar" CausesValidation="False" />      
            <br /> <br />
        <asp:GridView ID="gdv_Localizar" runat="server" AutoGenerateColumns="False" 
            CellPadding="3" DataKeyNames="CNPJ" 
            DataSourceID="dts_Estabelecimentos" 
            GridLines="Horizontal" Width="100%" CaptionAlign="Left" BackColor="White" BorderColor="#E7E7FF" 
        BorderStyle="None" BorderWidth="1px">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" SortExpression="CNPJ" />
                <asp:BoundField DataField="ESTABELECIMENTO" HeaderText="ESTABELECIMENTO" 
                    SortExpression="ESTABELECIMENTO" />
                <asp:BoundField DataField="ESFERA" HeaderText="ESFERA" 
                    SortExpression="ESFERA" />
            </Columns>
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" 
                HorizontalAlign="Left" VerticalAlign="Middle" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            
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
                        SelectCommand="SELECT * FROM [VIEW_DISTRIBUIDORES_001_DETALHADO] WHERE ([CAPTAR_DEMANDA] = @CAPTAR_DEMANDA) ORDER BY [ESTABELECIMENTO_CNPJ]">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="CAPTAR_DEMANDA" Type="Boolean" />
        </SelectParameters>
                    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_dia" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_DATAS_DIAS]"></asp:SqlDataSource>

</form>
    <asp:SqlDataSource ID="dts_Estabelecimentos" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                        SelectCommand="SELECT top(0) * FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO] ORDER BY [ESTABELECIMENTO_CNPJ]">
                    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Produtos" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                        SelectCommand="SELECT * FROM [VIEW_PRODUTOS] WHERE ([ATIVO] = @ATIVO) ORDER BY [PRODUTO]">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="ATIVO" Type="Boolean" />
        </SelectParameters>
                    </asp:SqlDataSource>
</body>
    
</html>
