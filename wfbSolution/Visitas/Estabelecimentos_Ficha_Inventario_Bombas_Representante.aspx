<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Ficha_Inventario_Bombas_Representante.aspx.vb" Inherits="Estabelecimentos_Ficha_Inventario_Bombas_Representante" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Invetário de Bombas</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
   <div id ="Titulo_Pagina_Cabecalho">Inventário de Bombas</div>
   <div id ="Titulo_Pagina_Links"><a href="Estabelecimentos_Ficha.aspx?CNPJ=<%=Session("CNPJ")%>">Voltar</a></div>
</div>    
<br />
    <div id ="Corpo">
        <br />
        <asp:FormView ID="frm_Estabelecimento_Ficha" runat="server"  DataSourceID="dts_Estabelecimento" Width="100%">
            <EditItemTemplate></EditItemTemplate>
            <InsertItemTemplate></InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="ESTABELECIMENTOLabel" runat="server" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' style="font-weight: 700" />
            </ItemTemplate>
        </asp:FormView>
        
        Preencha as informações para registrar o inventário de bombas neste estabelecimento e clique em &nbsp;<asp:Button ID="cmd_GRAVAR" runat="server" Text="Gravar" /><br />
        Ano:&nbsp;<asp:Label ID="lbl_ANO" runat="server" Text="Label"></asp:Label><br />
        Mês:&nbsp;<asp:DropDownList ID="cmb_MES" runat="server" DataSourceID="dts_Meses" DataTextField="MES_SIGLA" DataValueField="MES_NUMERO_VALOR" Enabled="False"></asp:DropDownList>
       
        &nbsp;<asp:RangeValidator ID="rfv_MES" runat="server" ControlToValidate="cmb_MES" ErrorMessage="Selecione o mês" MaximumValue="1000" MinimumValue="1" Type="Integer"></asp:RangeValidator>
       
        <br />
        Modelo:&nbsp;<asp:DropDownList ID="cmb_MODELO_BOMBA" runat="server" DataSourceID="dts_Modelos_Bombas" DataTextField="GRUPO_BOMBA" DataValueField="COD_GRUPO_BOMBA"></asp:DropDownList>
       
        &nbsp;<asp:RangeValidator ID="rfv_MODELO_BOMA" runat="server" ControlToValidate="cmb_MODELO_BOMBA" ErrorMessage="Selecione o modelo de bomba" MaximumValue="1000" MinimumValue="1" Type="Integer"></asp:RangeValidator>
       
        <br />
        Quantidade:&nbsp;<asp:TextBox ID="txt_QTD_BOMBA" runat="server" style="text-align: center" TextMode="Number" Width="50px" MaxLength="9999999"></asp:TextBox>&nbsp;<asp:RangeValidator ID="rfv_QTD_BOMBA" runat="server" ControlToValidate="txt_QTD_BOMBA" Display="Dynamic" ErrorMessage="Quantidade inválida" MaximumValue="99999999" MinimumValue="1" Type="Integer"></asp:RangeValidator>
        <asp:RequiredFieldValidator ID="rfv_QTD" runat="server" ControlToValidate="txt_QTD_BOMBA" Display="Dynamic" ErrorMessage="Digite a quantidade"></asp:RequiredFieldValidator>
        <br /><br />
       
        O registro de inventário será atualizado na lista abaixo<br />
        Caso ocorra inventário no mesmo mê para o mesmo modelo de bomba o sistema automaticamente exclui o regitro anterior<br />
        Se necessário exclua o registro e inclua novamente<br />
        <br />
        <asp:GridView ID="gdv_Inventario" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="dts_Inventario" Width="100%">
            <Columns>
                <asp:CommandField DeleteText="Excluir" ShowDeleteButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="ANO" HeaderText="Ano" SortExpression="ANO">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="MES" HeaderText="Mês" SortExpression="MES">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="QTD" HeaderText="Qtd Bombas" SortExpression="QTD">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Modelo Bomba" SortExpression="COD_GRUPO_BOMBA">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("COD_GRUPO_BOMBA") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:DropDownList ID="cmb_Grupo_Bomba" runat="server" DataSourceID="dts_Modelos_Bombas" DataTextField="GRUPO_BOMBA" DataValueField="COD_GRUPO_BOMBA" SelectedValue='<%# Bind("COD_GRUPO_BOMBA") %>' Enabled="False">
                        </asp:DropDownList>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Inventariado por" SortExpression="INCLUSAO_EMAIL">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("INCLUSAO_EMAIL") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:DropDownList ID="cmb_Email_Inclusao" runat="server" DataSourceID="dts_Usuarios" DataTextField="NOME" DataValueField="EMAIL" Enabled="False" SelectedValue='<%# Bind("INCLUSAO_EMAIL") %>'>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="dts_Usuarios" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_USUARIOS]"></asp:SqlDataSource>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="dts_Inventario" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" DeleteCommand="DELETE FROM [TBL_BOMBAS_INVENTARIO_REPRESENTANTE] WHERE [ID] = @ID" InsertCommand="INSERT INTO [TBL_BOMBAS_INVENTARIO_REPRESENTANTE] ([CNPJ], [COD_GRUPO_BOMBA], [ANO], [MES], [QTD], [INCLUSAO_EMAIL], [INCLUSAO_DATA]) VALUES (@CNPJ, @COD_GRUPO_BOMBA, @ANO, @MES, @QTD, @INCLUSAO_EMAIL, @INCLUSAO_DATA)" SelectCommand="SELECT * FROM [TBL_BOMBAS_INVENTARIO_REPRESENTANTE] WHERE ([CNPJ] = @CNPJ) ORDER BY [ID] DESC" UpdateCommand="UPDATE [TBL_BOMBAS_INVENTARIO_REPRESENTANTE] SET [CNPJ] = @CNPJ, [COD_GRUPO_BOMBA] = @COD_GRUPO_BOMBA, [ANO] = @ANO, [MES] = @MES, [QTD] = @QTD, [INCLUSAO_EMAIL] = @INCLUSAO_EMAIL, [INCLUSAO_DATA] = @INCLUSAO_DATA WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Decimal" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="CNPJ" Type="Decimal" />
                <asp:Parameter Name="COD_GRUPO_BOMBA" Type="Decimal" />
                <asp:Parameter Name="ANO" Type="Decimal" />
                <asp:Parameter Name="MES" Type="Decimal" />
                <asp:Parameter Name="QTD" Type="Decimal" />
                <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
                <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="CNPJ" Type="Decimal" />
                <asp:Parameter Name="COD_GRUPO_BOMBA" Type="Decimal" />
                <asp:Parameter Name="ANO" Type="Decimal" />
                <asp:Parameter Name="MES" Type="Decimal" />
                <asp:Parameter Name="QTD" Type="Decimal" />
                <asp:Parameter Name="INCLUSAO_EMAIL" Type="String" />
                <asp:Parameter Name="INCLUSAO_DATA" Type="Decimal" />
                <asp:Parameter Name="ID" Type="Decimal" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
    </div>
    <br /><br /><br />
    <asp:SqlDataSource ID="dts_INVENTARIO_BOMBAS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_BOMBAS_INVENTARIO_REPRESENTANTE] WHERE ([CNPJ] = @CNPJ) ORDER BY [ID] DESC">
        <SelectParameters>
            <asp:QueryStringParameter Name="CNPJ" QueryStringField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Meses" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [tbl_DATAS_MESES] WHERE ([MES_NUMERO_VALOR] = @MES_NUMERO_VALOR)">
        <SelectParameters>
            <asp:SessionParameter Name="MES_NUMERO_VALOR" SessionField="MES_ATUAL" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Modelos_Bombas" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT  0 as COD_GRUPO_BOMBA, '@ Selecione' as GRUPO_BOMBA union all
        SELECT  COD_GRUPO_BOMBA, GRUPO_BOMBA FROM [tbl_BOMBAS_GRUPOS] 
        WHERE INVENTARIO_REPRESENTANTE = 'True' ORDER BY [GRUPO_BOMBA]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Estabelecimento" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS] WHERE ([CNPJ] = @CNPJ)">
        <SelectParameters>
            <asp:QueryStringParameter Name="CNPJ" QueryStringField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
</form>
</body>
</html>