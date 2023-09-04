<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Produtos_Cadastro_Produto.aspx.vb" Inherits="Produtos_Cadastro_Produto" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="App_Themes/MasterTheme/Master.css" />
</head>

<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Produtos</div>
    <div id ="Titulo_Pagina_Links">
        <a href="Menu_Produto_Cadastros.aspx">Menu Produtos</a>&nbsp;&nbsp;
        <asp:LinkButton ID="cmd_Excel" runat="server">Excel</asp:LinkButton>&nbsp;
    </div>
</div>
<br />    
<div id ="Corpo">
   <br /> Para incluir um novo digite o nome  &nbsp;
    <br />
    <strong>Código do Produto
    </strong>
    <br />
    <asp:TextBox ID="txt_Cod_Produto" runat="server" Width="10%" style="text-align: center"></asp:TextBox>
    <br />
    Nome do Produto
    <br />
    <asp:TextBox ID="txt_Produto" runat="server" Width="25%"></asp:TextBox>
    <br />
    Embalagem de Venda
    <br />
    <asp:DropDownList ID="cmb_Embalagem_Venda" runat="server" DataSourceID="dts_Embalagem" DataTextField="PRODUTO_EMBALAGEM_VENDA" DataValueField="COD_PRODUTO_EMBALAGEM_VENDA"></asp:DropDownList>
    <br />
    Unidade de Venda
    <br />
    <asp:DropDownList ID="cmb_Unidade_Venda" runat="server" DataSourceID="dts_Unidade" DataTextField="PRODUTO_UNIDADE" DataValueField="COD_PRODUTO_UNIDADE"></asp:DropDownList>
    <br />
    Unidade Equivalente
    <br />
    <asp:DropDownList ID="cmb_Unidade_Equivalente" runat="server" DataSourceID="dts_Unidade" DataTextField="PRODUTO_UNIDADE" DataValueField="COD_PRODUTO_UNIDADE"></asp:DropDownList>
    <br />
    Calculo de Unidade Equivalente
    <br />
    <asp:DropDownList ID="cmb_Operador" runat="server">
        <asp:ListItem Value="0"># Selecione</asp:ListItem>
        <asp:ListItem Value="*">Multiplicar</asp:ListItem>
        <asp:ListItem Value="/">Dividir</asp:ListItem>
    </asp:DropDownList>
    <br />
    Quantidade de Unidades por Embalagem
    <br />
    <asp:TextBox ID="txt_Qtd_Unidades_Embalagem" runat="server" Width="5%" style="text-align: center"></asp:TextBox>
    <br />
    Fator de Conversão de Unidade
    <br />
    <asp:TextBox ID="txt_Fator_Conversao_Unidade" runat="server" Width="5%" style="text-align: center"></asp:TextBox>
    <br />
    Preço base de unidade de venda
    <br />
    <asp:TextBox ID="txt_Preco_Base_Unidade" runat="server" Width="5%" style="text-align: center"></asp:TextBox>
    <br />
    Linha
    <br />
    <asp:DropDownList ID="cmb_Linha" runat="server" DataSourceID="dts_Linha" DataTextField="PRODUTO_LINHA" DataValueField="COD_PRODUTO_LINHA"></asp:DropDownList>
    <br />
     Grupo
    <br />
    <asp:DropDownList ID="cmb_Grupo" runat="server" DataSourceID="dts_Grupo" DataTextField="PRODUTO_GRUPO" DataValueField="COD_PRODUTO_GRUPO"></asp:DropDownList>
    <br />
    Divisão
    <br />
    <asp:DropDownList ID="cmb_Divisao" runat="server" DataSourceID="dts_Divisao" DataTextField="PRODUTO_DIVISAO" DataValueField="COD_PRODUTO_DIVISAO"></asp:DropDownList>
    <br />
    <br />
    <asp:CheckBox ID="chk_Cota_Venda_Unidade" runat="server" Text="Cota de Venda em Unidade" />
    <br />
    <asp:CheckBox ID="chk_Cota_Venda_Valor" runat="server" Text="Cota de Venda em Valor" />
    <br />
    <br />
    <asp:Button ID="cmd_Gravar" runat="server" Text="Incluir" />
   <br /> <br />
    <asp:GridView ID="gdv_Lista" runat="server" AutoGenerateColumns="False" DataKeyNames="COD_PRODUTO" DataSourceID="dts_Lista" Width="100%" Height="250px">
        <Columns>
            <asp:CommandField CancelText="Cancelar" DeleteText="Deletar" EditText="Editar" InsertText="Inserir" NewText="Novo" SelectText="Excluir" ShowEditButton="True" ShowSelectButton="True" UpdateText="Atualizar" />
            <asp:BoundField DataField="COD_PRODUTO" HeaderText="Código" ReadOnly="True" SortExpression="COD_PRODUTO" >
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Nome">
                <EditItemTemplate>
                    <asp:TextBox ID="txt_Produto" runat="server" Text='<%# Bind("PRODUTO") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_Produto" ErrorMessage="Obrigatório" style="color: #FF0000; font-weight: 700"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_Produto" runat="server" Text='<%# Eval("PRODUTO") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cálculo" SortExpression="OPERADOR">
                <EditItemTemplate>
                    <asp:DropDownList ID="cmb_Operador" runat="server" SelectedValue='<%# Bind("OPERADOR") %>'>
                        <asp:ListItem Value="0"># Selecione</asp:ListItem>
                        <asp:ListItem Value="*">Multiplicar</asp:ListItem>
                        <asp:ListItem Value="/">Dividir</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="cmb_Operador" runat="server" Enabled="False" SelectedValue='<%# Bind("OPERADOR") %>'>
                        <asp:ListItem Value="0"># Selecione</asp:ListItem>
                        <asp:ListItem Value="*">Multiplicar</asp:ListItem>
                        <asp:ListItem Value="/">Dividir</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Qtd. por Embalagem" SortExpression="COD_PRODUTO_UNIDADE_VENDA">
                <EditItemTemplate>
                    <asp:TextBox ID="txt_Unidades_Embalagem" runat="server" Text='<%# Bind("QTD_UNIDADES_EMBALAGEM_VENDA") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Unidades_Embalagem" runat="server" ControlToValidate="txt_Unidades_Embalagem" ErrorMessage="Obrigatório" style="color: #FF0000; font-weight: 700"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_Unidades_Embalagem" runat="server" Text='<%# Eval("QTD_UNIDADES_EMBALAGEM_VENDA") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unidade Equivalente" SortExpression="COD_PRODUTO_UNIDADE_EQUIVALENTE">
                <EditItemTemplate>
                    <asp:TextBox ID="txt_Fator_Conversao" runat="server" Text='<%# Bind("FATOR_CONVERSAO_UNIDADE_EQUIVALENTE") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Fator_Conversao" runat="server" ControlToValidate="txt_Fator_Conversao" ErrorMessage="Obrigatório" style="color: #FF0000; font-weight: 700"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_Fator_Conversao" runat="server" Text='<%# Eval("FATOR_CONVERSAO_UNIDADE_EQUIVALENTE") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Preço" SortExpression="OPERADOR">
                <EditItemTemplate>
                    <asp:TextBox ID="txt_Preco_Base" runat="server" Text='<%# Bind("PRECO_BASE_UNIDADE_VENDA") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Preco_Unidade" runat="server" ControlToValidate="txt_Preco_Base" ErrorMessage="Obrigatório" style="color: #FF0000; font-weight: 700"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_Preco_Unidade" runat="server" Text='<%# Eval("PRECO_BASE_UNIDADE_VENDA") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Linha">
                <EditItemTemplate>
                    <asp:DropDownList ID="cmb_Linha" runat="server" DataSourceID="dts_Linha" DataTextField="PRODUTO_LINHA" DataValueField="COD_PRODUTO_LINHA" SelectedValue='<%# Bind("COD_PRODUTO_LINHA") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="cmb_Linha" runat="server" DataSourceID="dts_Linha" DataTextField="PRODUTO_LINHA" DataValueField="COD_PRODUTO_LINHA" Enabled="False" SelectedValue='<%# Bind("COD_PRODUTO_LINHA") %>'>
                    </asp:DropDownList>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Grupo">
                <EditItemTemplate>
                    <asp:DropDownList ID="cmb_Grupo" runat="server" DataSourceID="dts_Grupo" DataTextField="PRODUTO_GRUPO" DataValueField="COD_PRODUTO_GRUPO" SelectedValue='<%# Bind("COD_PRODUTO_GRUPO") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="cmb_Grupo" runat="server" DataSourceID="dts_Grupo" DataTextField="PRODUTO_GRUPO" DataValueField="COD_PRODUTO_GRUPO" Enabled="False" SelectedValue='<%# Bind("COD_PRODUTO_GRUPO") %>'>
                    </asp:DropDownList>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Divisão">
                <EditItemTemplate>
                    <asp:DropDownList ID="cmb_Divisao" runat="server" DataSourceID="dts_Divisao" DataTextField="PRODUTO_DIVISAO" DataValueField="COD_PRODUTO_DIVISAO" SelectedValue='<%# Bind("COD_PRODUTO_DIVISAO") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="cmb_Divisao" runat="server" DataSourceID="dts_Divisao" DataTextField="PRODUTO_DIVISAO" DataValueField="COD_PRODUTO_DIVISAO" Enabled="False" SelectedValue='<%# Bind("COD_PRODUTO_DIVISAO") %>'>
                    </asp:DropDownList>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Emb. de Venda" SortExpression="COD_PRODUTO_LINHA">
                <EditItemTemplate>
                    <asp:DropDownList ID="cmb_Embalagem_Venda" runat="server" DataSourceID="dts_Embalagem" DataTextField="PRODUTO_EMBALAGEM_VENDA" DataValueField="COD_PRODUTO_EMBALAGEM_VENDA" SelectedValue='<%# Bind("COD_PRODUTO_EMBALAGEM_VENDA") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="cmb_Embalagem_Venda" runat="server" DataSourceID="dts_Embalagem" DataTextField="PRODUTO_EMBALAGEM_VENDA" DataValueField="COD_PRODUTO_EMBALAGEM_VENDA" Enabled="False" SelectedValue='<%# Bind("COD_PRODUTO_EMBALAGEM_VENDA") %>'>
                    </asp:DropDownList>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Und. de Venda" SortExpression="COD_PRODUTO_GRUPO">
                <EditItemTemplate>
                    <asp:DropDownList ID="cmb_Unidade_Venda" runat="server" DataSourceID="dts_Unidade" DataTextField="PRODUTO_UNIDADE" DataValueField="COD_PRODUTO_UNIDADE" SelectedValue='<%# Bind("COD_PRODUTO_UNIDADE_VENDA") %>' >
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="cmb_Unidade_Venda" runat="server" DataSourceID="dts_Unidade" DataTextField="PRODUTO_UNIDADE" DataValueField="COD_PRODUTO_UNIDADE" Enabled="False" SelectedValue='<%# Bind("COD_PRODUTO_UNIDADE_VENDA") %>'>
                    </asp:DropDownList>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Und. Equivalente" SortExpression="COD_PRODUTO_DIVISAO">
                <EditItemTemplate>
                    <asp:DropDownList ID="cmb_Unidade_Equivalente" runat="server" DataSourceID="dts_Unidade" DataTextField="PRODUTO_UNIDADE" DataValueField="COD_PRODUTO_UNIDADE" SelectedValue='<%# Bind("COD_PRODUTO_UNIDADE_EQUIVALENTE") %>'>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="cmb_Unidade_Equivalente" runat="server" DataSourceID="dts_Unidade" DataTextField="PRODUTO_UNIDADE" DataValueField="COD_PRODUTO_UNIDADE" Enabled="False" SelectedValue='<%# Bind("COD_PRODUTO_UNIDADE_EQUIVALENTE") %>'>
                    </asp:DropDownList>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:CheckBoxField DataField="ATIVO" HeaderText="Ativo" SortExpression="ATIVO" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CheckBoxField>
            <asp:CheckBoxField DataField="COTA_VENDA_UNIDADE" HeaderText="Cota de Venda por Unidade" SortExpression="COTA_VENDA_UNIDADE" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CheckBoxField>
            <asp:CheckBoxField DataField="COTA_VENDA_VALOR" HeaderText="Cota de Venda em Valor" SortExpression="COTA_VENDA_VALOR" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CheckBoxField>
        </Columns>
        <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        <HeaderStyle Width="100%" />
        <RowStyle Width="100%" />
    </asp:GridView>
    <br />
    <asp:SqlDataSource ID="dts_Lista" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_PRODUTOS] WHERE ([COD_PRODUTO] &gt; @COD_PRODUTO)" 
        DeleteCommand="DELETE FROM [TBL_PRODUTOS] WHERE [COD_PRODUTO] = @COD_PRODUTO" 
        InsertCommand="INSERT INTO [TBL_PRODUTOS] ([COD_PRODUTO], [PRODUTO], [COD_PRODUTO_DIVISAO], [COD_PRODUTO_LINHA], [COD_PRODUTO_GRUPO], [COD_PRODUTO_EMBALAGEM_VENDA], [COD_PRODUTO_UNIDADE_VENDA], [COD_PRODUTO_UNIDADE_EQUIVALENTE], [QTD_UNIDADES_EMBALAGEM_VENDA], [FATOR_CONVERSAO_UNIDADE_EQUIVALENTE], [PRECO_BASE_UNIDADE_VENDA], [ATIVO], [INCLUSAO_EMAIL], [INCLUSAO_DATA], [ALTERACAO_EMAIL], [ALTERACAO_DATA], [EXCLUSAO_EMAIL], [EXCLUSAO_DATA]) VALUES (@COD_PRODUTO, @PRODUTO, @COD_PRODUTO_DIVISAO, @COD_PRODUTO_LINHA, @COD_PRODUTO_GRUPO, @COD_PRODUTO_EMBALAGEM_VENDA, @COD_PRODUTO_UNIDADE_VENDA, @COD_PRODUTO_UNIDADE_EQUIVALENTE, @QTD_UNIDADES_EMBALAGEM_VENDA, @FATOR_CONVERSAO_UNIDADE_EQUIVALENTE, @PRECO_BASE_UNIDADE_VENDA, @ATIVO, @INCLUSAO_EMAIL, @INCLUSAO_DATA, @ALTERACAO_EMAIL, @ALTERACAO_DATA, @EXCLUSAO_EMAIL, @EXCLUSAO_DATA)" 
        UpdateCommand="UPDATE [TBL_PRODUTOS] SET [PRODUTO] = @PRODUTO, [COD_PRODUTO_DIVISAO] = @COD_PRODUTO_DIVISAO, [COD_PRODUTO_LINHA] = @COD_PRODUTO_LINHA, [COD_PRODUTO_GRUPO] = @COD_PRODUTO_GRUPO, [COD_PRODUTO_EMBALAGEM_VENDA] = @COD_PRODUTO_EMBALAGEM_VENDA, [COD_PRODUTO_UNIDADE_VENDA] = @COD_PRODUTO_UNIDADE_VENDA, [COD_PRODUTO_UNIDADE_EQUIVALENTE] = @COD_PRODUTO_UNIDADE_EQUIVALENTE, [QTD_UNIDADES_EMBALAGEM_VENDA] = @QTD_UNIDADES_EMBALAGEM_VENDA, [FATOR_CONVERSAO_UNIDADE_EQUIVALENTE] = @FATOR_CONVERSAO_UNIDADE_EQUIVALENTE, [PRECO_BASE_UNIDADE_VENDA] = @PRECO_BASE_UNIDADE_VENDA, [ATIVO] = @ATIVO, [COTA_VENDA_UNIDADE] = @COTA_VENDA_UNIDADE, [COTA_VENDA_VALOR] = @COTA_VENDA_VALOR WHERE [COD_PRODUTO] = @COD_PRODUTO">
        <DeleteParameters>
            <asp:Parameter Name="COD_PRODUTO" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="COD_PRODUTO" Type="String" />
            <asp:Parameter Name="PRODUTO" Type="String" />
            <asp:Parameter Name="COD_PRODUTO_DIVISAO" Type="Decimal" />
            <asp:Parameter Name="COD_PRODUTO_LINHA" Type="Decimal" />
            <asp:Parameter Name="COD_PRODUTO_GRUPO" Type="Decimal" />
            <asp:Parameter Name="COD_PRODUTO_EMBALAGEM_VENDA" Type="Decimal" />
            <asp:Parameter Name="COD_PRODUTO_UNIDADE_VENDA" Type="Decimal" />
            <asp:Parameter Name="COD_PRODUTO_UNIDADE_EQUIVALENTE" Type="Decimal" />
            <asp:Parameter Name="QTD_UNIDADES_EMBALAGEM_VENDA" Type="Decimal" />
            <asp:Parameter Name="FATOR_CONVERSAO_UNIDADE_EQUIVALENTE" Type="Decimal" />
            <asp:Parameter Name="PRECO_BASE_UNIDADE_VENDA" Type="Decimal" />
            <asp:Parameter Name="ATIVO" Type="Boolean" />
            <asp:Parameter Name="COTA_VENDA_UNIDADE" Type="Boolean" />
            <asp:Parameter Name="COTA_VENDA_VALOR" Type="Boolean" />
            <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
            <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />
            <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />
            <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />
        </InsertParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="COD_PRODUTO" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="PRODUTO" Type="String" />
            <asp:Parameter Name="COD_PRODUTO_DIVISAO" Type="Decimal" />
            <asp:Parameter Name="COD_PRODUTO_LINHA" Type="Decimal" />
            <asp:Parameter Name="COD_PRODUTO_GRUPO" Type="Decimal" />
            <asp:Parameter Name="COD_PRODUTO_EMBALAGEM_VENDA" Type="Decimal" />
            <asp:Parameter Name="COD_PRODUTO_UNIDADE_VENDA" Type="Decimal" />
            <asp:Parameter Name="COD_PRODUTO_UNIDADE_EQUIVALENTE" Type="Decimal" />
            <asp:Parameter Name="QTD_UNIDADES_EMBALAGEM_VENDA" Type="Decimal" />
            <asp:Parameter Name="FATOR_CONVERSAO_UNIDADE_EQUIVALENTE" Type="Decimal" />
            <asp:Parameter Name="PRECO_BASE_UNIDADE_VENDA" Type="Decimal" />
            <asp:Parameter Name="ATIVO" Type="Boolean" />
            <asp:Parameter Name="COTA_VENDA_UNIDADE" Type="Boolean" />
            <asp:Parameter Name="COTA_VENDA_VALOR" Type="Boolean" />
            <asp:Parameter Name="COD_PRODUTO" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Linha" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_PRODUTOS_LINHAS]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Grupo" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_PRODUTOS_GRUPOS]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Unidade" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_PRODUTOS_UNIDADES]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Embalagem" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_PRODUTOS_EMBALAGEM]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Divisao" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_PRODUTOS_DIVISAO]"></asp:SqlDataSource>
</div>
</form>
</body>
</html>