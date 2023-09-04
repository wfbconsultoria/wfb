<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Produtos_Cadastro_Embalagem.aspx.vb" Inherits="Produtos_Cadastro_Embalagem" %>

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
    <div id ="Titulo_Pagina_Cabecalho">Embalagem de Venda</div>
    <div id ="Titulo_Pagina_Links">
        <a href="Menu_Produto_Cadastros.aspx">Menu Produtos</a>&nbsp;&nbsp;
        <asp:LinkButton ID="cmd_Excel" runat="server">Excel</asp:LinkButton>&nbsp;
    </div>
</div>
<br />    
<div id ="Corpo">
   <br /> Para incluir uma nova Embalagem<br />
    digite o nome  &nbsp;<asp:TextBox ID="txt_Embalagem" runat="server" Width="25%"></asp:TextBox>&nbsp;<br />
    e
    clique em &nbsp;<asp:Button ID="cmd_Gravar" runat="server" Text="Incluir" />
   <br /> <br />
    <asp:GridView ID="gdv_Lista" runat="server" AutoGenerateColumns="False" DataKeyNames="COD_PRODUTO_EMBALAGEM_VENDA" DataSourceID="dts_Lista" AllowSorting="True">
        <Columns>
            <asp:CommandField CancelText="Cancelar" DeleteText="Deletar" EditText="Editar" InsertText="Inserir" NewText="Novo" SelectText="Excluir" ShowEditButton="True" ShowSelectButton="True" UpdateText="Atualizar">
            <HeaderStyle Width="10%" />
            <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CommandField>
            <asp:TemplateField HeaderText="Embalagem de Venda" SortExpression="PRODUTO_EMBALAGEM_VENDA">
                <EditItemTemplate>
                    <asp:TextBox ID="txt_Embalagem" runat="server" Text='<%# Bind("PRODUTO_EMBALAGEM_VENDA") %>' Width="50%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_EMABALAGEM" runat="server" ControlToValidate="txt_Embalagem" ErrorMessage="Obrigatório" style="color: #FF0000; font-weight: 700"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_Embalagem" runat="server" Text='<%# Eval("PRODUTO_EMBALAGEM_VENDA") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="25%" />
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="dts_Lista" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_PRODUTOS_EMBALAGEM] WHERE ([COD_PRODUTO_EMBALAGEM_VENDA] &gt; @COD_PRODUTO_EMBALAGEM_VENDA)" 
        DeleteCommand="DELETE FROM [TBL_PRODUTOS_EMBALAGEM] WHERE [COD_PRODUTO_EMBALAGEM_VENDA] = @COD_PRODUTO_EMBALAGEM_VENDA" 
        InsertCommand="INSERT INTO [TBL_PRODUTOS_EMBALAGEM] ([PRODUTO_EMBALAGEM_VENDA], [INCLUSAO_EMAIL], [INCLUSAO_DATA], [ALTERACAO_EMAIL], [ALTERACAO_DATA], [EXCLUSAO_EMAIL], [EXCLUSAO_DATA]) VALUES (@PRODUTO_EMBALAGEM_VENDA, @INCLUSAO_EMAIL, @INCLUSAO_DATA, @ALTERACAO_EMAIL, @ALTERACAO_DATA, @EXCLUSAO_EMAIL, @EXCLUSAO_DATA)" 
        UpdateCommand="UPDATE [TBL_PRODUTOS_EMBALAGEM] SET [PRODUTO_EMBALAGEM_VENDA] = @PRODUTO_EMBALAGEM_VENDA WHERE [COD_PRODUTO_EMBALAGEM_VENDA] = @COD_PRODUTO_EMBALAGEM_VENDA">
        <DeleteParameters>
            <asp:Parameter Name="COD_PRODUTO_EMBALAGEM_VENDA" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="PRODUTO_EMBALAGEM_VENDA" Type="String" />
            <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
            <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />
            <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />
            <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />
        </InsertParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="COD_PRODUTO_EMBALAGEM_VENDA" Type="Decimal" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="PRODUTO_EMBALAGEM_VENDA" Type="String" />
            <asp:Parameter Name="COD_PRODUTO_EMBALAGEM_VENDA" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
</div>
</form>
</body>
</html>