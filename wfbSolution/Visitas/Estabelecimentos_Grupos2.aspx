<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Grupos2.aspx.vb" Inherits="Estabelecimentos_Grupos2" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Início</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/MasterTheme/Master.css" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Grupo de Estabelecimento 2</div>
    <div id ="Titulo_Pagina_Links"></div>
</div> 
<br />  
<div id ="Corpo">
    <br />
    Para incluir um novo grupo<br />
    digite o nome &nbsp;<asp:TextBox ID="txt_Grupo" runat="server" Width="25%"></asp:TextBox>
    <br />
    selecione a esfera
                    <asp:DropDownList ID="cmb_ESFERA_ADMINISTRATIVA" runat="server" 
                        DataSourceID="dts_Esfera_Administrativa" DataTextField="GESTAO" 
                        DataValueField="COD">
                    </asp:DropDownList>
                    <br />
    e clique em &nbsp;<asp:Button ID="cmd_Gravar" runat="server" Text="Gravar" />
    <br />
    <asp:GridView ID="gdv_GRUPOS2" runat="server" AutoGenerateColumns="False" DataKeyNames="COD_GRUPO2" DataSourceID="dts_ESTABELECIMENTOS_GRUPOS2" Width="100%">
        <Columns>
            <asp:CommandField CancelText="Cancelar" DeleteText="Excluir" EditText="Editar" InsertText="Inserir" NewText="Novo" SelectText="Excluir" ShowEditButton="True" UpdateText="Atualizar" ShowSelectButton="True" >
            <HeaderStyle Width="7%" />
            <ItemStyle Width="7%" />
            </asp:CommandField>
            <asp:BoundField DataField="GRUPO2" HeaderText="Grupo" SortExpression="GRUPO2" >
            <ControlStyle Width="50%" />
            <HeaderStyle Width="46.5%" />
            <ItemStyle Width="46.5%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Esfera Administrativa" SortExpression="COD_GRUPO2">
                <EditItemTemplate>
                    <asp:DropDownList ID="cmb_ESFERA_ADMINSTRATIVA" runat="server" SelectedValue='<%# Bind("COD_ESFERA_GRUPO2") %>' DataSourceID="dts_Esfera_Administrativa" DataTextField="GESTAO" DataValueField="COD">
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="cmb_ESFERA_ADMINSTRATIVA" runat="server" SelectedValue='<%# Bind("COD_ESFERA_GRUPO2") %>' DataSourceID="dts_Esfera_Administrativa" DataTextField="GESTAO" DataValueField="COD" Enabled="False">
                    </asp:DropDownList>
                </ItemTemplate>
                <HeaderStyle Width="46.5%" />
                <ItemStyle Width="46.5%" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="dts_ESTABELECIMENTOS_GRUPOS2" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" DeleteCommand="DELETE FROM [TBL_ESTABELECIMENTOS_GRUPOS2] WHERE [COD_GRUPO2] = @COD_GRUPO2" InsertCommand="INSERT INTO [TBL_ESTABELECIMENTOS_GRUPOS2] ([GRUPO2], [COD_ESFERA_GRUPO2]) VALUES (@GRUPO2, @COD_ESFERA_GRUPO2)" SelectCommand="SELECT * FROM [TBL_ESTABELECIMENTOS_GRUPOS2] ORDER BY [GRUPO2]" UpdateCommand="UPDATE [TBL_ESTABELECIMENTOS_GRUPOS2] SET [GRUPO2] = @GRUPO2, [COD_ESFERA_GRUPO2] = @COD_ESFERA_GRUPO2 WHERE [COD_GRUPO2] = @COD_GRUPO2">
        <DeleteParameters>
            <asp:Parameter Name="COD_GRUPO2" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="GRUPO2" Type="String" />
            <asp:Parameter Name="COD_ESFERA_GRUPO2" Type="Decimal" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="GRUPO2" Type="String" />
            <asp:Parameter Name="COD_ESFERA_GRUPO2" Type="Decimal" />
            <asp:Parameter Name="COD_GRUPO2" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Esfera_Administrativa" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [TBL_ESFERA_ADMINISTRATIVA] ORDER BY [COD]">
    </asp:SqlDataSource>
    
    </div>
</form>
</body>
</html>