<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Digitacao_Estoque.aspx.vb" Inherits="Digitacao_Estoque" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Digitar Estoque</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Digitar Estoque</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>    
<br />
<div id ="Corpo">
    <br />
    1 - Selecione o Distribuidor
    <br />
    2 - Preencha todos os dados COM ATENÇÃO e depois clique em gravar
    <br /><br />
    <b>Ano</b>
    <br />
    <asp:DropDownList ID="cmb_ANO" runat="server" DataSourceID="dts_Anos" 
        DataTextField="ANO_VALOR" DataValueField="ANO_VALOR">
    </asp:DropDownList>
    <br />
    <b>Mês</b>
    <br />
    <asp:DropDownList ID="cmb_MES" runat="server" 
        DataSourceID="dts_Meses" DataTextField="MES_SIGLA" 
        DataValueField="MES_NUMERO_VALOR">
    </asp:DropDownList>
    <br />
    <b>Dia</b>
    <br />
    <asp:DropDownList ID="cmb_DIA" runat="server" 
        DataSourceID="dts_Dias" DataTextField="DIA_NUMERO_TEXTO" 
        DataValueField="DIA_NUMERO_VALOR">
    </asp:DropDownList>
    <br />
    <b>Distribuidor</b>
    <br />
    <asp:DropDownList 
        ID="cmb_CNPJ_DISTRIBUIDOR" runat="server" DataSourceID="dts_Distribuidores" 
        DataTextField="DISTRIBUIDOR" DataValueField="CNPJ">
    </asp:DropDownList>
    <br />
    <b>Produto</b>
    <br />
    <asp:DropDownList ID="cmb_COD_PRODUTO" runat="server" 
        DataSourceID="dts_Produtos" DataTextField="PRODUTO" 
        DataValueField="COD">
    </asp:DropDownList>
    <br />
    <b>Quantidade</b>
    <br />
    <asp:TextBox ID="txt_QTD" runat="server" style="text-align: center; font-weight: 700"></asp:TextBox></td>
    <br />
    <asp:Button ID="cmd_Gravar" runat="server" Text="Gravar" CausesValidation="False" />

        <asp:GridView ID="gdv_Movimento" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID_REGISTRO" DataSourceID="dts_Movimento" ForeColor="#333333" GridLines="None" Width="100%">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" DeleteText="Deletar" EditText="Editar" SelectText="Selecionar" />
                <asp:BoundField DataField="ID_REGISTRO" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID_REGISTRO" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="ANO" HeaderText="Ano" SortExpression="ANO" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="MES" HeaderText="Mês" SortExpression="MES" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="DIA" HeaderText="Dia" SortExpression="DIA" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="CNPJ_DISTRIBUIDOR" HeaderText="CNPJ do Ditribuidor" SortExpression="CNPJ_DISTRIBUIDOR" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="COD_PRODUTO" HeaderText="Código do Produto" SortExpression="COD_PRODUTO" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="QTD" HeaderText="QTD" SortExpression="QTD" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
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
        SelectCommand="SELECT * FROM [tbl_DATAS_MESES] ORDER BY [MES_NUMERO_VALOR]">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Dias" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_DATAS_DIAS] ORDER BY [DIA_NUMERO_VALOR]"></asp:SqlDataSource>
    
    <asp:SqlDataSource ID="dts_Distribuidores" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_DISTRIBUIDORES] WHERE ([CAPTAR_DEMANDA] = @CAPTAR_DEMANDA) ORDER BY [GRUPO], [DISTRIBUIDOR]">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="CAPTAR_DEMANDA" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Produtos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>"          
        SelectCommand="SELECT COD, PRODUTO + ' - ' + COD AS PRODUTO  FROM VIEW_PRODUTOS ORDER BY PRODUTO + ' - ' + COD">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Movimento" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" DeleteCommand="DELETE FROM [tbl_MOVIMENTO_ESTOQUE] WHERE [ID_REGISTRO] = @ID_REGISTRO" InsertCommand="INSERT INTO [tbl_MOVIMENTO_ESTOQUE] ([ANO], [MES], [DIA], [CNPJ_DISTRIBUIDOR], [COD_PRODUTO], [QTD], [INCLUSAO_EMAIL], [INCLUSAO_DATA]) VALUES (@ANO, @MES, @DIA, @CNPJ_DISTRIBUIDOR, @COD_PRODUTO, @QTD, @INCLUSAO_EMAIL, @INCLUSAO_DATA)" SelectCommand="SELECT * FROM [tbl_MOVIMENTO_ESTOQUE] WHERE (([ANO] = @ANO) AND ([MES] = @MES) AND ([DIA] = @DIA) AND ([CNPJ_DISTRIBUIDOR] = @CNPJ_DISTRIBUIDOR)) ORDER BY [ID_REGISTRO]" UpdateCommand="UPDATE [tbl_MOVIMENTO_ESTOQUE] SET [ANO] = @ANO, [MES] = @MES, [DIA] = @DIA, [CNPJ_DISTRIBUIDOR] = @CNPJ_DISTRIBUIDOR, [COD_PRODUTO] = @COD_PRODUTO, [QTD] = @QTD, [INCLUSAO_EMAIL] = @INCLUSAO_EMAIL, [INCLUSAO_DATA] = @INCLUSAO_DATA WHERE [ID_REGISTRO] = @ID_REGISTRO">
            <DeleteParameters>
                <asp:Parameter Name="ID_REGISTRO" Type="Decimal" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ANO" Type="Decimal" />
                <asp:Parameter Name="MES" Type="Decimal" />
                <asp:Parameter Name="DIA" Type="Decimal" />
                <asp:Parameter Name="CNPJ_DISTRIBUIDOR" Type="Decimal" />
                <asp:Parameter Name="COD_PRODUTO" Type="String" />
                <asp:Parameter Name="QTD" Type="Decimal" />
                <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
                <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="cmb_ANO" Name="ANO" PropertyName="SelectedValue" Type="Decimal" />
                <asp:ControlParameter ControlID="cmb_MES" Name="MES" PropertyName="SelectedValue" Type="Decimal" />
                <asp:ControlParameter ControlID="cmb_DIA" Name="DIA" PropertyName="SelectedValue" Type="Decimal" />
                <asp:ControlParameter ControlID="cmb_CNPJ_DISTRIBUIDOR" Name="CNPJ_DISTRIBUIDOR" PropertyName="SelectedValue" Type="Decimal" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="ANO" Type="Decimal" />
                <asp:Parameter Name="MES" Type="Decimal" />
                <asp:Parameter Name="DIA" Type="Decimal" />
                <asp:Parameter Name="CNPJ_DISTRIBUIDOR" Type="Decimal" />
                <asp:Parameter Name="COD_PRODUTO" Type="String" />
                <asp:Parameter Name="QTD" Type="Decimal" />
                <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
                <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
                <asp:Parameter Name="ID_REGISTRO" Type="Decimal" />
            </UpdateParameters>
        </asp:SqlDataSource>
</form>
</body>
</html>