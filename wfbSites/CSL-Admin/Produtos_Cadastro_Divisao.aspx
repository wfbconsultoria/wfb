<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Produtos_Cadastro_Divisao.aspx.vb" Inherits="Produtos_Cadastro_Divisao" %>

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
    <div id ="Titulo_Pagina_Cabecalho">Divisões de Produto</div>
    <div id ="Titulo_Pagina_Links">
        <a href="Menu_Produto_Cadastros.aspx">Menu Produtos</a>&nbsp;&nbsp;
        <asp:LinkButton ID="cmd_Excel" runat="server">Excel</asp:LinkButton>&nbsp;
    </div>
</div>
<br />    
<div id ="Corpo">
   <br /> Para incluir uma nova divisão<br />
    digite o nome  &nbsp;<asp:TextBox ID="txt_Divisao" runat="server" Width="25%"></asp:TextBox>&nbsp;<br />
    e
    clique em &nbsp;<asp:Button ID="cmd_Gravar" runat="server" Text="Incluir" />
   <br /> <br />
    <asp:SqlDataSource ID="dts_Lista" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_PRODUTOS_DIVISAO] WHERE ([COD_PRODUTO_DIVISAO] &gt; @COD_PRODUTO_DIVISAO)" 
        DeleteCommand="DELETE FROM [TBL_PRODUTOS_DIVISAO] WHERE [COD_PRODUTO_DIVISAO] = @COD_PRODUTO_DIVISAO" 
        InsertCommand="INSERT INTO [TBL_PRODUTOS_DIVISAO] ([PRODUTO_DIVISAO], [INCLUSAO_EMAIL], [INCLUSAO_DATA], [ALTERACAO_EMAIL], [ALTERACAO_DATA], [EXCLUSAO_EMAIL], [EXCLUSAO_DATA]) VALUES (@PRODUTO_DIVISAO, @INCLUSAO_EMAIL, @INCLUSAO_DATA, @ALTERACAO_EMAIL, @ALTERACAO_DATA, @EXCLUSAO_EMAIL, @EXCLUSAO_DATA)" 
        UpdateCommand="UPDATE [TBL_PRODUTOS_DIVISAO] SET [PRODUTO_DIVISAO] = @PRODUTO_DIVISAO WHERE [COD_PRODUTO_DIVISAO] = @COD_PRODUTO_DIVISAO">
        <DeleteParameters>
            <asp:Parameter Name="COD_PRODUTO_DIVISAO" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="PRODUTO_DIVISAO" Type="String" />
            <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
            <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />
            <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />
            <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />
        </InsertParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="COD_PRODUTO_DIVISAO" Type="Decimal" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="PRODUTO_DIVISAO" Type="String" />
            <asp:Parameter Name="COD_PRODUTO_DIVISAO" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="gdv_Lista" runat="server" AutoGenerateColumns="False" DataKeyNames="COD_PRODUTO_DIVISAO" DataSourceID="dts_Lista" AllowSorting="True">
        <Columns>
            <asp:CommandField CancelText="Cancelar" DeleteText="Excluir" EditText="Editar" InsertText="Inserir" NewText="Novo" SelectText="Excluir" ShowEditButton="True" ShowSelectButton="True" UpdateText="Atualizar" >
            <HeaderStyle Width="10%" />
            <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CommandField>
            <asp:TemplateField HeaderText="Divisão" SortExpression="PRODUTO_DIVISAO">
                <EditItemTemplate>
                    <asp:TextBox ID="txt_DIVISAO" runat="server" Text='<%# Bind("PRODUTO_DIVISAO") %>' Width="50%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_DIVISAO" runat="server" ControlToValidate="txt_DIVISAO" ErrorMessage="Obrigatório" style="color: #FF0000; font-weight: 700"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_Divisao" runat="server" Text='<%# Eval("PRODUTO_DIVISAO") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="25%" />
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
</form>
</body>

</html>