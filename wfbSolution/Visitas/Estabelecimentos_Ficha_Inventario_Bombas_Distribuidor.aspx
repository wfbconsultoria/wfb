<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Ficha_Inventario_Bombas_Distribuidor.aspx.vb" Inherits="Estabelecimentos_Ficha_Inventario_Bombas_Distribuidor" %>

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
        
        Preencha as informações para registrar o inventário de bombas neste estabelecimento<br />
        Ano:&nbsp;<asp:Label ID="lbl_ANO" runat="server" Text="Label"></asp:Label><br />
        Mês:&nbsp;<asp:DropDownList ID="cmb_MES" runat="server" DataSourceID="dts_Meses" DataTextField="MES_SIGLA" DataValueField="MES_NUMERO_VALOR"></asp:DropDownList>
       
        &nbsp;<asp:RangeValidator ID="rfv_MES" runat="server" ControlToValidate="cmb_MES" ErrorMessage="Selecione o mês" MaximumValue="1000" MinimumValue="1" Type="Integer"></asp:RangeValidator>
       
        <br />
        Modelo:&nbsp;<asp:DropDownList ID="cmb_MODELO_BOMBA" runat="server" DataSourceID="dts_Modelos_Bombas" DataTextField="GRUPO_BOMBA" DataValueField="COD_GRUPO_BOMBA"></asp:DropDownList>
       
        &nbsp;<asp:RangeValidator ID="rfv_MODELO_BOMA" runat="server" ControlToValidate="cmb_MODELO_BOMBA" ErrorMessage="Selecione o modelo de bomba" MaximumValue="1000" MinimumValue="1" Type="Integer"></asp:RangeValidator>
       
        <br />
        Quantidade:&nbsp;<asp:TextBox ID="txt_QTD_BOMBA" runat="server" style="text-align: center" TextMode="Number" Width="50px" MaxLength="3"></asp:TextBox>&nbsp;<asp:RangeValidator ID="rfv_QTD_BOMBA" runat="server" ControlToValidate="txt_QTD_BOMBA" Display="Dynamic" ErrorMessage="Quantidade inválida" MaximumValue="999" MinimumValue="1" Type="Integer"></asp:RangeValidator>
        <asp:RequiredFieldValidator ID="rfv_QTD" runat="server" ControlToValidate="txt_QTD_BOMBA" Display="Dynamic" ErrorMessage="Digite a quantidade"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Button ID="cmd_GRAVAR" runat="server" Text="Gravar" />
        <br />
        <br />
        <asp:GridView ID="gdv_Bomba_alocada" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="dts_INVENTARIO_BOMBAS">
            <Columns>
                <asp:BoundField DataField="GRUPO_BOMBA" HeaderText="Grupo" SortExpression="GRUPO_BOMBA" />
                <asp:BoundField DataField="QTD" HeaderText="QTD" SortExpression="QTD" />
                <asp:BoundField DataField="ANO" HeaderText="Ano" SortExpression="ANO" />
                <asp:BoundField DataField="MES_EXTENSO" HeaderText="Mês" SortExpression="MES_EXTENSO" />
            </Columns>
        </asp:GridView>
        <br />
    </div>
    <br /><br /><br />
    <asp:SqlDataSource ID="dts_INVENTARIO_BOMBAS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT top(1) * FROM [VIEW_BOMBAS_INVENTARIO_DISTRIBUIDOR] WHERE ([CNPJ] = @CNPJ) ORDER BY [ID] DESC">
        <SelectParameters>
            <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Meses" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT 0 AS  MES_NUMERO_VALOR, '@ Selecione' as MES_SIGLA union all
        SELECT MES_NUMERO_VALOR, MES_SIGLA FROM [tbl_DATAS_MESES]
        WHERE MES_NUMERO_VALOR&gt;0 ORDER BY [MES_NUMERO_VALOR]">
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
            <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />  
        </SelectParameters>
    </asp:SqlDataSource>
</form>
</body>
</html>