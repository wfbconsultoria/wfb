<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Distribuidores_Grupos.aspx.vb" Inherits="Distribuidores_Grupos" %>

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
    <div id ="Titulo_Pagina_Cabecalho">Grupos de Distribuidor</div>
    <div id ="Titulo_Pagina_Links">
        &nbsp;<a href="Menu_Distribuidor.aspx">Menu Distribuidor</a>
        <asp:LinkButton ID="cmd_Excel" runat="server">Excel</asp:LinkButton>&nbsp;
    </div>
</div>
<br />    
<div id ="Corpo">
   <br /> <strong>Para incluir um novo grupo</strong>
    <br />
    digite o nome <asp:TextBox ID="txt_Grupo" runat="server" Width="25%"></asp:TextBox>&nbsp;<br />
    e
    clique em &nbsp;<asp:Button ID="cmd_Gravar" runat="server" Text="Incluir" />
   <br /> <br />
    <asp:GridView ID="gdv_Lista" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID_GRUPO_DISTRIBUIDOR,GRUPO_DISTRIBUIDOR" DataSourceID="dts_Lista" Width="100%">
        <Columns>
            <asp:CommandField EditText="Alterar" SelectText="Excluir" ShowEditButton="True" ShowSelectButton="True" >
                <HeaderStyle Width="5%" />
                <ItemStyle Width="5%" />
            </asp:CommandField>
            <asp:BoundField DataField="GRUPO_DISTRIBUIDOR" HeaderText="Grupo de Distribuidor" SortExpression="GRUPO_DISTRIBUIDOR" >
            <ControlStyle Width="50%" />
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30%" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30%" />
            </asp:BoundField>
            <asp:BoundField DataField="CONTATO_SAC_TELEFONE" HeaderText="Telefone SAC" SortExpression="CONTATO_SAC_TELEFONE">
                <HeaderStyle Width="25%" />
                <ItemStyle Width="25%" />
            </asp:BoundField>
            <asp:BoundField DataField="CONTATO_SAC_EMAIL" HeaderText="E-mail SAC" SortExpression="CONTATO_SAC_EMAIL">
                <HeaderStyle Width="15%" />
                <ItemStyle Width="15%" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</div>
<asp:SqlDataSource ID="dts_Lista" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" DeleteCommand="DELETE FROM [TBL_DISTRIBUIDORES_GRUPOS] WHERE [ID_GRUPO_DISTRIBUIDOR] = @original_ID_GRUPO_DISTRIBUIDOR" InsertCommand="INSERT INTO [TBL_DISTRIBUIDORES_GRUPOS] ([GRUPO_DISTRIBUIDOR]) VALUES (@GRUPO_DISTRIBUIDOR)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [TBL_DISTRIBUIDORES_GRUPOS] WHERE ([ID_GRUPO_DISTRIBUIDOR] &gt; @ID_GRUPO_DISTRIBUIDOR) ORDER BY [ID_GRUPO_DISTRIBUIDOR]" UpdateCommand="UPDATE [TBL_DISTRIBUIDORES_GRUPOS] SET [GRUPO_DISTRIBUIDOR] = @GRUPO_DISTRIBUIDOR WHERE [ID_GRUPO_DISTRIBUIDOR] = @original_ID_GRUPO_DISTRIBUIDOR">
        <DeleteParameters>
            <asp:Parameter Name="original_ID_GRUPO_DISTRIBUIDOR" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="GRUPO_DISTRIBUIDOR" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="ID_GRUPO_DISTRIBUIDOR" Type="Decimal" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="GRUPO_DISTRIBUIDOR" Type="String" />
            <asp:Parameter Name="original_ID_GRUPO_DISTRIBUIDOR" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
</form>
</body>
</html>