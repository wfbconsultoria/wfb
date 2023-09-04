<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Digitacao_Demanda_Manutencao.aspx.vb" Inherits="Digitar_Demanda_Manutencao" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manutenção na Demanda</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Manutenção na Demanda</div>
    <div id ="Titulo_Pagina_Links">
        
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
        <strong>Filtros</strong><strong><br />
        <b>Distribuidor</b>
        <br />
&nbsp;<asp:DropDownList ID="CMB_CNPJ_DISTRIBUIDOR" runat="server" 
            DataSourceID="dts_Distribuidores" DataTextField="ESTABELECIMENTO_CNPJ" 
            DataValueField="CNPJ" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        
        <b>Ano / Mês</b>
        <br />
&nbsp;<asp:DropDownList ID="cmb_ANO" runat="server" DataSourceID="dts_Anos" 
            DataTextField="ANO_VALOR" DataValueField="ANO_VALOR" AutoPostBack="True">
        </asp:DropDownList>
        
        &nbsp;
        <asp:DropDownList ID="cmb_MESES" runat="server" DataSourceID="dts_Meses" 
            DataTextField="MES_SIGLA" DataValueField="MES" 
            AutoPostBack="True">
        </asp:DropDownList>
        </strong>    
    <br />
    <asp:FormView ID="frv_Movimento_Demanda" runat="server" DataKeyNames="ID_REGISTRO" 
            DataSourceID="dts_Movimento_Demanda_Manutencao" Width="100%" 
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" ForeColor="Black" GridLines="Vertical">
            <EditItemTemplate>
                <asp:Label ID="Label5" runat="server" style="font-weight: 700" 
                    Text="Editar Registro" Width="7%"></asp:Label>
                <asp:Label ID="ID_REGISTROLabel1" runat="server" 
                    Text='<%# Eval("ID_REGISTRO") %>' style="color: #FF0000" />
                &nbsp;&nbsp;<asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" 
                    CommandName="Update" Text="Gravar" style="color: #FFFFFF" />
                &nbsp;&nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancelar" 
                    style="color: #FF0000" />
                <br />
                <asp:Label ID="Label6" runat="server" style="font-weight: 700" 
                    Text="Estabelecimento" Width="7%"></asp:Label>
                <asp:DropDownList ID="CNPJ_ESTABELECIMENTOTextBox" runat="server" 
                    DataSourceID="dts_Estabelecimentos" DataTextField="ESTABELECIMENTO_CNPJ" 
                    DataValueField="CNPJ" SelectedValue='<%# Bind("CNPJ_ESTABELECIMENTO") %>'>
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label7" runat="server" style="font-weight: 700" Text="Produto" 
                    Width="7%"></asp:Label>
                <asp:DropDownList ID="COD_PRODUTOTextBox" runat="server" 
                    DataSourceID="dts_Produtos" DataTextField="PRODUTO" DataValueField="COD_PRODUTO" 
                    SelectedValue='<%# Bind("COD_PRODUTO") %>'>
                </asp:DropDownList>
                <br />
                <asp:Label ID="Label8" runat="server" style="font-weight: 700" 
                    Text="Quantidade" Width="7%"></asp:Label>
                <asp:TextBox ID="QTDTextBox" runat="server" Text='<%# Bind("QTD") %>' 
                    style="text-align: center" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="QTDTextBox" ErrorMessage="DIGITE A QUANTIDADE" 
                    style="color: #FF0000; font-weight: 700"></asp:RequiredFieldValidator>
                &nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" 
                    ErrorMessage="VALOR INVÁLIDO" MaximumValue="999999" MinimumValue="1" 
                    style="color: #FF0000; font-weight: 700" Type="Integer" 
                    ControlToValidate="QTDTextBox"></asp:RangeValidator>
                <br />
            </EditItemTemplate>
            <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <InsertItemTemplate>
                ANO:
                <asp:TextBox ID="ANOTextBox" runat="server" Text='<%# Bind("ANO") %>' />
                <br />
                MES:
                <asp:TextBox ID="MESTextBox" runat="server" Text='<%# Bind("MES") %>' />
                <br />
                CNPJ_DISTRIBUIDOR:
                <asp:TextBox ID="CNPJ_DISTRIBUIDORTextBox" runat="server" 
                    Text='<%# Bind("CNPJ_DISTRIBUIDOR") %>' />
                <br />
                CNPJ_ESTABELECIMENTO:
                <asp:TextBox ID="CNPJ_ESTABELECIMENTOTextBox" runat="server" 
                    Text='<%# Bind("CNPJ_ESTABELECIMENTO") %>' />
                <br />
                COD_PRODUTO:
                <asp:TextBox ID="COD_PRODUTOTextBox" runat="server" 
                    Text='<%# Bind("COD_PRODUTO") %>' />
                <br />
                QTD:
                <asp:TextBox ID="QTDTextBox" runat="server" Text='<%# Bind("QTD") %>' />
                <br />
                DEMANDA_TRANSFERIDA_DE:
                <asp:TextBox ID="DEMANDA_TRANSFERIDA_DETextBox" runat="server" 
                    Text='<%# Bind("DEMANDA_TRANSFERIDA_DE") %>' />
                <br />
                DEMANDA_TRANSFERIDA_PARA:
                <asp:TextBox ID="DEMANDA_TRANSFERIDA_PARATextBox" runat="server" 
                    Text='<%# Bind("DEMANDA_TRANSFERIDA_PARA") %>' />
                <br />
                DEMANDA_TRANSFERIDA_POR:
                <asp:TextBox ID="DEMANDA_TRANSFERIDA_PORTextBox" runat="server" 
                    Text='<%# Bind("DEMANDA_TRANSFERIDA_POR") %>' />
                <br />
                DEMANDA_TRANSFERIDA_EM:
                <asp:TextBox ID="DEMANDA_TRANSFERIDA_EMTextBox" runat="server" 
                    Text='<%# Bind("DEMANDA_TRANSFERIDA_EM") %>' />
                <br />
                OBSERVACOES:
                <asp:TextBox ID="OBSERVACOESTextBox" runat="server" 
                    Text='<%# Bind("OBSERVACOES") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" 
                    CommandName="Insert" Text="Insert" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" 
                    CausesValidation="False" CommandName="Cancel" Text="Cancel" />
            </InsertItemTemplate>
            <ItemTemplate>
                <strong>
                <asp:Label ID="Label1" runat="server" Text="Id Registro" Width="7%"></asp:Label>
                </strong>&nbsp;<asp:Label ID="ID_REGISTROLabel" runat="server" style="color: #FF0000; font-weight: 700;" 
                    Text='<%# Eval("ID_REGISTRO") %>' />
                &nbsp;<asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" 
                    CommandName="Edit" Text="Editar" />
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" 
                    CommandName="Delete" Text="Excluir" style="color: #FF0000" />
                <br />
                <strong>
                <asp:Label ID="Label2" runat="server" Text="Estabelecimento" Width="7%"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" 
                    DataSourceID="dts_Estabelecimentos" DataTextField="ESTABELECIMENTO_CNPJ" 
                    DataValueField="CNPJ" Enabled="False" 
                    SelectedValue='<%# Bind("CNPJ_ESTABELECIMENTO") %>' style="font-weight: 700">
                </asp:DropDownList>
                </strong>
                <br />
                <strong>
                <asp:Label ID="Label3" runat="server" Text="Produto" Width="7%"></asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server" 
                    DataSourceID="dts_Produtos" DataTextField="PRODUTO" DataValueField="COD_PRODUTO" 
                    Enabled="False" SelectedValue='<%# Bind("COD_PRODUTO") %>' 
                    style="font-weight: 700">
                </asp:DropDownList>
                </strong>
                <br />
                <strong>
                <asp:Label ID="Label4" runat="server" Text="Quantidade" Width="7%"></asp:Label>
                </strong><asp:Label ID="QTDLabel" runat="server" Text='<%# Bind("QTD") %>' 
                    BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" 
                    style="text-align: center" Width="100px" />
                <br />
            </ItemTemplate>
            <PagerStyle ForeColor="Black" HorizontalAlign="Center" />
        </asp:FormView>
    
   <br />
   <br />
    <span class="style10"><strong>Lançamentos</strong></span>
    <asp:GridView ID="gdv_Movimento_Demanda" runat="server" AllowSorting="True" 
        AutoGenerateColumns="False" BorderColor="#E7E7FF" 
        BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        DataKeyNames="ID_REGISTRO" DataSourceID="dts_Movimento_Demanda" 
        GridLines="Horizontal" Width="100%">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/Images/Find.gif" 
                ShowSelectButton="True">
            <HeaderStyle HorizontalAlign="Center" Width="2%" />
            <ItemStyle HorizontalAlign="Center" Width="2%" />
            </asp:CommandField>
            <asp:BoundField DataField="ID_REGISTRO" HeaderText="Registro" 
                SortExpression="ID_REGISTRO">
            <HeaderStyle HorizontalAlign="Center" Width="3%" />
            <ItemStyle HorizontalAlign="Center" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="ESTABELECIMENTO" HeaderText="Estabelecimento" 
                ReadOnly="True" SortExpression="ESTABELECIMENTO" />
            <asp:BoundField DataField="PRODUTO" HeaderText="Produto" ReadOnly="True" 
                SortExpression="PRODUTO" />
            <asp:BoundField DataField="QTD" HeaderText="QTD" SortExpression="QTD">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    </asp:GridView>
    
   </div>
    </form>
    <asp:SqlDataSource ID="dts_Produtos" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT [COD_PRODUTO], [PRODUTO] FROM [VIEW_PRODUTOS] ORDER BY [PRODUTO]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Movimento_Demanda_Manutencao" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [tbl_MOVIMENTO_DEMANDA] WHERE ([ID_REGISTRO] = @ID_REGISTRO)" 
        DeleteCommand="DELETE FROM [tbl_MOVIMENTO_DEMANDA] WHERE [ID_REGISTRO] = @ID_REGISTRO" 
        InsertCommand="INSERT INTO [tbl_MOVIMENTO_DEMANDA] ([ANO], [MES], [CNPJ_DISTRIBUIDOR], [CNPJ_ESTABELECIMENTO], [COD_PRODUTO], [QTD], [DEMANDA_TRANSFERIDA_DE], [DEMANDA_TRANSFERIDA_PARA], [DEMANDA_TRANSFERIDA_POR], [DEMANDA_TRANSFERIDA_EM], [OBSERVACOES]) VALUES (@ANO, @MES, @CNPJ_DISTRIBUIDOR, @CNPJ_ESTABELECIMENTO, @COD_PRODUTO, @QTD, @DEMANDA_TRANSFERIDA_DE, @DEMANDA_TRANSFERIDA_PARA, @DEMANDA_TRANSFERIDA_POR, @DEMANDA_TRANSFERIDA_EM, @OBSERVACOES)" 
        UpdateCommand="UPDATE [tbl_MOVIMENTO_DEMANDA] SET  [CNPJ_ESTABELECIMENTO] = @CNPJ_ESTABELECIMENTO, [COD_PRODUTO] = @COD_PRODUTO, [QTD] = @QTD  WHERE [ID_REGISTRO] = @ID_REGISTRO">
            <DeleteParameters>
                <asp:Parameter Name="ID_REGISTRO" Type="Decimal" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ANO" Type="Decimal" />
                <asp:Parameter Name="MES" Type="Decimal" />
                <asp:Parameter Name="CNPJ_DISTRIBUIDOR" Type="Decimal" />
                <asp:Parameter Name="CNPJ_ESTABELECIMENTO" Type="Decimal" />
                <asp:Parameter Name="COD_PRODUTO" Type="String" />
                <asp:Parameter Name="QTD" Type="Decimal" />
                <asp:Parameter Name="DEMANDA_TRANSFERIDA_DE" Type="Decimal" />
                <asp:Parameter Name="DEMANDA_TRANSFERIDA_PARA" Type="Decimal" />
                <asp:Parameter Name="DEMANDA_TRANSFERIDA_POR" Type="String" />
                <asp:Parameter Name="DEMANDA_TRANSFERIDA_EM" Type="Decimal" />
                <asp:Parameter Name="OBSERVACOES" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="gdv_Movimento_Demanda" Name="ID_REGISTRO" 
                    PropertyName="SelectedValue" Type="Decimal" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="ANO" Type="Decimal" />
                <asp:Parameter Name="MES" Type="Decimal" />
                <asp:Parameter Name="CNPJ_DISTRIBUIDOR" Type="Decimal" />
                <asp:Parameter Name="CNPJ_ESTABELECIMENTO" Type="Decimal" />
                <asp:Parameter Name="COD_PRODUTO" Type="String" />
                <asp:Parameter Name="QTD" Type="Decimal" />
                <asp:Parameter Name="DEMANDA_TRANSFERIDA_DE" Type="Decimal" />
                <asp:Parameter Name="DEMANDA_TRANSFERIDA_PARA" Type="Decimal" />
                <asp:Parameter Name="DEMANDA_TRANSFERIDA_POR" Type="String" />
                <asp:Parameter Name="DEMANDA_TRANSFERIDA_EM" Type="Decimal" />
                <asp:Parameter Name="OBSERVACOES" Type="String" />
                <asp:Parameter Name="ID_REGISTRO" Type="Decimal" />
            </UpdateParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Meses" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT * FROM [TBL_DATAS_MESES] WHERE ([MES_FECHADO] = @MES_FECHADO) ORDER BY [MES]">
            <SelectParameters>
                <asp:Parameter DefaultValue="False" Name="MES_FECHADO" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource> 
    <asp:SqlDataSource ID="dts_Estabelecimentos" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                    SelectCommand="SELECT [CNPJ], [ESTABELECIMENTO_CNPJ] FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO] ORDER BY [ESTABELECIMENTO_CNPJ]">
                </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Movimento_Demanda" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        
        
        SelectCommand="SELECT * FROM [VIEW_DEMANDA_001_DETALHADO] WHERE (([CNPJ_DISTRIBUIDOR] = @CNPJ_DISTRIBUIDOR) AND ([ANO] = @ANO) AND ([MES] = @MES)) ORDER BY [ESTABELECIMENTO], [PRODUTO]">
        <SelectParameters>
            <asp:ControlParameter ControlID="CMB_CNPJ_DISTRIBUIDOR" 
                Name="CNPJ_DISTRIBUIDOR" PropertyName="SelectedValue" Type="Decimal" />
            <asp:ControlParameter ControlID="cmb_ANO" Name="ANO" 
                PropertyName="SelectedValue" Type="Decimal" />
            <asp:ControlParameter ControlID="cmb_MESES" Name="MES" 
                PropertyName="SelectedValue" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>    
    <asp:SqlDataSource ID="dts_Anos" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT [ANO_VALOR] FROM [tbl_DATAS_ANOS] WHERE ([ANO_FECHADO] = @ANO_FECHADO) ORDER BY [ANO_VALOR]">
            <SelectParameters>
                <asp:Parameter DefaultValue="False" Name="ANO_FECHADO" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Distribuidores" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT * FROM [VIEW_DISTRIBUIDORES_001_DETALHADO] ORDER BY [ESTABELECIMENTO_CNPJ]">
        </asp:SqlDataSource> 
</body>
</html>
