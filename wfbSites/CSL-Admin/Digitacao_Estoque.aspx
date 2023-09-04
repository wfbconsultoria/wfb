<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Digitacao_Estoque.aspx.vb" Inherits="Digitacao_Estoque" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>
<%@ Register Src="~/ScriptsHeader.ascx" TagPrefix="uc1" TagName="ScriptsHeader" %>
<%@ Register Src="~/ScriptsFooter.ascx" TagPrefix="uc1" TagName="ScriptsFooter" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Digitar Estoque</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body class="container">
    <uc1:Cabecalho runat="server" ID="Cabecalho" />
    <uc1:ScriptsHeader runat="server" ID="ScriptsHeader" />
    <form id="form1" runat="server">
        <div class="row" id="Titulo_Pagina">
            <div id="Titulo_Pagina_Cabecalho">Digitar Estoque</div>
            <div id="Titulo_Pagina_Links"></div>
        </div>

        <div id="Corpo">
            <div class="form-row">
                <div class="form-group col-md-2">
                    <label>Ano</label>
                    <asp:DropDownList CssClass="form-control" ID="cmb_ANO" runat="server" DataSourceID="dts_Anos" DataTextField="ANO_VALOR" DataValueField="ANO_VALOR" AutoPostBack="True"></asp:DropDownList>
                </div>
                <div class="form-group col-md-2">
                    <label>Mês</label>
                    <asp:DropDownList CssClass="form-control" ID="cmb_MES" runat="server" DataSourceID="dts_Meses" DataTextField="MES_SIGLA" DataValueField="MES" AutoPostBack="True"></asp:DropDownList>
                </div>
                <div class="form-group col-md-2">
                    <label>Dia</label>
                    <asp:DropDownList CssClass="form-control" ID="cmb_DIA" runat="server" DataSourceID="dts_Dias" DataTextField="DIA_EXTENSO" DataValueField="DIA" AutoPostBack="True"></asp:DropDownList>
                </div>
            </div>

            <div class="form-row">
                <div class="form-group col-md-8">
                    <label>Distribuidor</label>
                    <asp:DropDownList CssClass="form-control"
                        ID="cmb_CNPJ_DISTRIBUIDOR" runat="server" DataSourceID="dts_Distribuidores"
                        DataTextField="ESTABELECIMENTO_CNPJ" DataValueField="CNPJ" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label>Produto</label>
                    <asp:DropDownList CssClass="form-control" ID="cmb_COD_PRODUTO" runat="server"
                        DataSourceID="dts_Produtos" DataTextField="PRODUTO"
                        DataValueField="COD_PRODUTO" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="form-group col-md-2">
                    <label>Qtd (UN) </label>
                    <asp:TextBox CssClass="form-control" ID="txt_QTD" runat="server" Style="text-align: center; font-weight: 700"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                 <div class="form-group col-md-6">
                     <asp:Button CssClass="btn btn-primary" ID="cmd_Gravar" runat="server" Text="Gravar" CausesValidation="False" />
                </div>
            </div>

            <div class="row col-md-12">
                <asp:GridView CssClass="table table-reposnsive table-sm" ID="gdv_Movimento" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID_REGISTRO" DataSourceID="dts_Movimento" ForeColor="#333333" GridLines="None" Width="100%">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" DeleteImageUrl="~/Images/Excluir.png" />
                        <asp:BoundField DataField="ID_REGISTRO" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID_REGISTRO">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Ano" SortExpression="ANO">
                            <EditItemTemplate>
                                <asp:DropDownList ID="cmb_ANO" runat="server" DataSourceID="dts_Anos" DataTextField="ANO_VALOR" DataValueField="ANO_VALOR" SelectedValue='<%# Bind("ANO") %>'>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="cmb_ANO" runat="server" DataSourceID="dts_Anos" DataTextField="ANO_VALOR" DataValueField="ANO_VALOR" Enabled="False" SelectedValue='<%# Bind("ANO") %>'>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mês" SortExpression="MES">
                            <EditItemTemplate>
                                <asp:DropDownList ID="cmb_MES" runat="server" DataSourceID="dts_Meses" DataTextField="MES_SIGLA" DataValueField="MES" SelectedValue='<%# Bind("MES") %>'>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="cmb_MES" runat="server" DataSourceID="dts_Meses" DataTextField="MES_SIGLA" DataValueField="MES" Enabled="False" SelectedValue='<%# Bind("MES") %>'>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dia" SortExpression="DIA">
                            <EditItemTemplate>
                                <asp:DropDownList ID="cmb_DIA" runat="server" DataSourceID="dts_Dias" DataTextField="DIA_EXTENSO" DataValueField="DIA" SelectedValue='<%# Bind("DIA") %>' Width="80px">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="cmb_DIA" runat="server" DataSourceID="dts_Dias" DataTextField="DIA_EXTENSO" DataValueField="DIA" Enabled="False" SelectedValue='<%# Bind("DIA") %>' Width="80px">
                                </asp:DropDownList>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Distribuidor" SortExpression="CNPJ_DISTRIBUIDOR">
                            <EditItemTemplate>
                                <asp:DropDownList ID="cmb_CNPJ_DISTRIBUIDOR" runat="server" DataSourceID="dts_Distribuidores" DataTextField="ESTABELECIMENTO_CNPJ" DataValueField="CNPJ" SelectedValue='<%# Bind("CNPJ_DISTRIBUIDOR") %>'>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="cmb_CNPJ_DISTRIBUIDOR" runat="server" DataSourceID="dts_Distribuidores" DataTextField="ESTABELECIMENTO_CNPJ" DataValueField="CNPJ" Enabled="False" SelectedValue='<%# Bind("CNPJ_DISTRIBUIDOR") %>'>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Produto" SortExpression="COD_PRODUTO">
                            <EditItemTemplate>
                                <asp:DropDownList ID="cmb_COD_PRODUTO" runat="server" DataSourceID="dts_Produtos" DataTextField="PRODUTO" DataValueField="COD_PRODUTO" SelectedValue='<%# Bind("COD_PRODUTO") %>'>
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="cmb_COD_PRODUTO" runat="server" DataSourceID="dts_Produtos" DataTextField="PRODUTO" DataValueField="COD_PRODUTO" Enabled="False" SelectedValue='<%# Bind("COD_PRODUTO") %>'>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="QTD" HeaderText="Qtd" SortExpression="QTD">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#FFFFCC" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="Silver" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </div>
        </div>
        <asp:SqlDataSource ID="dts_Anos" runat="server"
            ConnectionString="<%$ ConnectionStrings:cnnStr %>"
            SelectCommand="SELECT [ANO_VALOR] FROM [TBL_DATAS_ANOS] WHERE ([ANO_FECHADO] = @ANO_FECHADO) ORDER BY [ANO_VALOR] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="False" Name="ANO_FECHADO" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="dts_Meses" runat="server"
            ConnectionString="<%$ ConnectionStrings:cnnStr %>"
            SelectCommand="SELECT * FROM [tbl_DATAS_MESES] ORDER BY [MES]"></asp:SqlDataSource>

        <asp:SqlDataSource ID="dts_Dias" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_DATAS_DIAS] ORDER BY [DIA]"></asp:SqlDataSource>

        <asp:SqlDataSource ID="dts_Distribuidores" runat="server"
            ConnectionString="<%$ ConnectionStrings:cnnStr %>"
            SelectCommand="SELECT * FROM [VIEW_DISTRIBUIDORES_001_DETALHADO] WHERE ([CAPTAR_ESTOQUE] = @CAPTAR_ESTOQUE) ORDER BY [GRUPO_DISTRIBUIDOR], [ESTABELECIMENTO_CNPJ]">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="CAPTAR_ESTOQUE" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="dts_Produtos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>"
            SelectCommand="SELECT * FROM [VIEW_PRODUTOS] WHERE ([ATIVO] = @ATIVO) ORDER BY [PRODUTO]">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="ATIVO" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="dts_Movimento" runat="server"
            ConnectionString="<%$ ConnectionStrings:cnnStr %>"
            DeleteCommand="DELETE FROM [tbl_MOVIMENTO_ESTOQUE] WHERE [ID_REGISTRO] = @ID_REGISTRO"
            InsertCommand="INSERT INTO [tbl_MOVIMENTO_ESTOQUE] ([ANO], [MES], [DIA], [CNPJ_DISTRIBUIDOR], [COD_PRODUTO], [QTD], [INCLUSAO_EMAIL], [INCLUSAO_DATA]) VALUES (@ANO, @MES, @DIA, @CNPJ_DISTRIBUIDOR, @COD_PRODUTO, @QTD, @INCLUSAO_EMAIL, @INCLUSAO_DATA)"
            SelectCommand="SELECT * FROM [tbl_MOVIMENTO_ESTOQUE] WHERE (([ANO] = @ANO) AND ([MES] = @MES)  AND ([CNPJ_DISTRIBUIDOR] = @CNPJ_DISTRIBUIDOR)) ORDER BY [ID_REGISTRO]"
            UpdateCommand="UPDATE [tbl_MOVIMENTO_ESTOQUE] SET [ANO] = @ANO, [MES] = @MES, [DIA] = @DIA, [CNPJ_DISTRIBUIDOR] = @CNPJ_DISTRIBUIDOR, [COD_PRODUTO] = @COD_PRODUTO, [QTD] = @QTD WHERE [ID_REGISTRO] = @ID_REGISTRO">
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
                <asp:ControlParameter ControlID="cmb_CNPJ_DISTRIBUIDOR" Name="CNPJ_DISTRIBUIDOR" PropertyName="SelectedValue" Type="Decimal" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="ANO" Type="Decimal" />
                <asp:Parameter Name="MES" Type="Decimal" />
                <asp:Parameter Name="DIA" Type="Decimal" />
                <asp:Parameter Name="CNPJ_DISTRIBUIDOR" Type="Decimal" />
                <asp:Parameter Name="COD_PRODUTO" Type="String" />
                <asp:Parameter Name="QTD" Type="Decimal" />
                <asp:Parameter Name="ID_REGISTRO" Type="Decimal" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <uc1:ScriptsFooter runat="server" ID="ScriptsFooter" />
    </form>
</body>
</html>
