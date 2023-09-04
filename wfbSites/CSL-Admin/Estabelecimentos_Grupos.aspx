<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Grupos.aspx.vb" Inherits="Estabelecimentos_Grupos" %>
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
    <div id ="Titulo_Pagina_Cabecalho">Grupos de Clientes</div>
    <div id ="Titulo_Pagina_Links">
        <asp:LinkButton ID="cmd_Excel" runat="server">Excel</asp:LinkButton>&nbsp;
    </div>
</div>
<br />    
<div id ="Corpo">
   <br /> Para incluir um novo digite o nome  &nbsp;<asp:TextBox ID="txt_Grupo" runat="server"></asp:TextBox>&nbsp;clique em &nbsp;<asp:Button ID="cmd_Gravar" runat="server" Text="Incluir" />
   <br /> <br />
    <asp:GridView ID="gdv_Lista" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID_GRUPO_ESTABELECIMENTO,GRUPO_ESTABELECIMENTO" DataSourceID="dts_Lista" Width="100%">
        <Columns>
            <asp:CommandField EditText="Alterar" SelectText="Excluir" ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="GRUPO_ESTABELECIMENTO" HeaderText="Grupo de Cliente" SortExpression="GRUPO_ESTABELECIMENTO" >
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="90%" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="90%" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</div>
<asp:SqlDataSource ID="dts_Lista" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" DeleteCommand="DELETE FROM [TBL_ESTABELECIMENTOS_GRUPOS] WHERE [ID_GRUPO_ESTABELECIMENTO] = @original_ID_GRUPO_ESTABELECIMENTO" InsertCommand="INSERT INTO [TBL_ESTABELECIMENTOS_GRUPOS] ([GRUPO_ESTABELECIMENTO]) VALUES (@GRUPO_ESTABELECIMENTO)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [TBL_ESTABELECIMENTOS_GRUPOS] WHERE ([ID_GRUPO_ESTABELECIMENTO] &gt; @ID_GRUPO_ESTABELECIMENTO) ORDER BY [ID_GRUPO_ESTABELECIMENTO]" UpdateCommand="UPDATE [TBL_ESTABELECIMENTOS_GRUPOS] SET [GRUPO_ESTABELECIMENTO] = @GRUPO_ESTABELECIMENTO WHERE [ID_GRUPO_ESTABELECIMENTO] = @original_ID_GRUPO_ESTABELECIMENTO">
        <DeleteParameters>
            <asp:Parameter Name="original_ID_GRUPO_ESTABELECIMENTO" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="GRUPO_ESTABELECIMENTO" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="ID_GRUPO_ESTABELECIMENTO" Type="Decimal" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="GRUPO_ESTABELECIMENTO" Type="String" />
            <asp:Parameter Name="original_ID_GRUPO_ESTABELECIMENTO" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
</form>
</body>
</html>