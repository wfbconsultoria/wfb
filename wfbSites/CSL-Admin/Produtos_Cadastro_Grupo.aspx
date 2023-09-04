<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Produtos_Cadastro_Grupo.aspx.vb" Inherits="Produtos_Cadastro_Grupo" %>

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
    <div id ="Titulo_Pagina_Cabecalho">Grupos de Produto</div>
    <div id ="Titulo_Pagina_Links">
        <a href="Menu_Produto_Cadastros.aspx">Menu Produtos</a>&nbsp;&nbsp;
        <asp:LinkButton ID="cmd_Excel" runat="server">Excel</asp:LinkButton>&nbsp;
    </div>
</div>
<br />    
<div id ="Corpo">
   <br /> Para incluir um novo grupo<br />
    digite o nome  &nbsp;<asp:TextBox ID="txt_Grupo" runat="server" Width="25%"></asp:TextBox>&nbsp;<br />
    e
    clique em &nbsp;<asp:Button ID="cmd_Gravar" runat="server" Text="Incluir" />
   <br /> <br />
    <asp:GridView ID="gdv_Lista" runat="server" AutoGenerateColumns="False" DataKeyNames="COD_PRODUTO_GRUPO" DataSourceID="dts_Lista" AllowSorting="True">
        <Columns>
            <asp:CommandField CancelText="Cancelar" DeleteText="Excluir" EditText="Editar" InsertText="Inserir" NewText="Novo" SelectText="Excluir" ShowEditButton="True" ShowSelectButton="True" UpdateText="Atualizar" >
            <HeaderStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemStyle Width="10%" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:CommandField>
            <asp:TemplateField HeaderText="Grupo" SortExpression="PRODUTO_GRUPO">
                <EditItemTemplate>
                    <asp:TextBox ID="txt_Grupo" runat="server" Text='<%# Bind("PRODUTO_GRUPO") %>' Width="50%"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Grupo" runat="server" ControlToValidate="txt_Grupo" ErrorMessage="Obrigatório" style="color: #FF0000; font-weight: 700"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbl_Grupo" runat="server" Text='<%# Eval("PRODUTO_GRUPO") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="25%" />
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="dts_Lista" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_PRODUTOS_GRUPOS] WHERE ([COD_PRODUTO_GRUPO] &gt; @COD_PRODUTO_GRUPO)" 
        DeleteCommand="DELETE FROM [TBL_PRODUTOS_GRUPOS] WHERE [COD_PRODUTO_GRUPO] = @COD_PRODUTO_GRUPO" 
        InsertCommand="INSERT INTO [TBL_PRODUTOS_GRUPOS] ([PRODUTO_GRUPO], [INCLUSAO_EMAIL], [INCLUSAO_DATA], [ALTERACAO_EMAIL], [ALTERACAO_DATA], [EXCLUSAO_EMAIL], [EXCLUSAO_DATA]) VALUES (@PRODUTO_GRUPO, @INCLUSAO_EMAIL, @INCLUSAO_DATA, @ALTERACAO_EMAIL, @ALTERACAO_DATA, @EXCLUSAO_EMAIL, @EXCLUSAO_DATA)" 
        UpdateCommand="UPDATE [TBL_PRODUTOS_GRUPOS] SET [PRODUTO_GRUPO] = @PRODUTO_GRUPO WHERE [COD_PRODUTO_GRUPO] = @COD_PRODUTO_GRUPO">
        <DeleteParameters>
            <asp:Parameter Name="COD_PRODUTO_GRUPO" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="PRODUTO_GRUPO" Type="String" />
            <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
            <asp:Parameter Name="ALTERACAO_EMAIL" Type="String" />
            <asp:Parameter Name="ALTERACAO_DATA" Type="Decimal" />
            <asp:Parameter Name="EXCLUSAO_EMAIL" Type="String" />
            <asp:Parameter Name="EXCLUSAO_DATA" Type="Decimal" />
        </InsertParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="COD_PRODUTO_GRUPO" Type="Decimal" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="PRODUTO_GRUPO" Type="String" />
            <asp:Parameter Name="COD_PRODUTO_GRUPO" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
</div>
</form>
</body>
</html>