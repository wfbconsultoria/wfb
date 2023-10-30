<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Ficha_Gerente_Conta.aspx.vb" Inherits="Ficha_Gerente_Conta" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Análise Key Account</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">
        Análise Key Account &nbsp;<asp:DropDownList ID="cmb_Usuario" runat="server" AutoPostBack="True" DataSourceID="dts_Usuarios" DataTextField="NOME" DataValueField="EMAIL"></asp:DropDownList>
        &nbsp;
        Ano&nbsp;<asp:DropDownList ID="cmb_Ano" runat="server" DataSourceID="dts_Anos" DataTextField="ANO_TEXTO" DataValueField="ANO_VALOR" AutoPostBack="True"></asp:DropDownList>
        <br /><span style="font-size: small; color: #808080">Os valores referem-se aos resultados apurados conforme setorização atual</span>
    </div>
    <div id ="Titulo_Pagina_Links"></div>
</div>
   
<br />
<div id ="Corpo">
    <br />
    <asp:Table ID="tbl_Report" runat="server" BorderStyle="None" BorderWidth="0px" BorderColor="White"
            CaptionAlign="Left" Font-Names="Calibri" Font-Size="Small" 
            GridLines="Both" HorizontalAlign="Left" 
            style="text-align: center" Width="100%">
   </asp:Table>
    <br />
    Demanda por Estabelecimentos
    <br />
    <asp:GridView ID="gdv_Report" runat="server" AutoGenerateColumns="False" DataSourceID="dts_Report" Width="100%"  Font-Names="Calibri" DataKeyNames="CNPJ" ShowHeaderWhenEmpty="True">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="CNPJ" DataNavigateUrlFormatString="Estabelecimentos_Ficha.aspx?CNPJ={0}" DataTextField="ESTABELECIMENTO_CNPJ" HeaderText="Estabelecimento" SortExpression="ESTABELECIMENTO_CNPJ" Target="_blank">
            <HeaderStyle Width="35%" />
            <ItemStyle Width="35%" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="TARGET_2" HeaderText="Target" 
                SortExpression="TARGET_2" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="4%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="4%" />
            </asp:BoundField>
            <asp:BoundField DataField="JAN" HeaderText="JAN" 
                SortExpression="JAN">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="FEV" HeaderText="FEV" 
                SortExpression="FEV" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="MAR" HeaderText="MAR" 
                SortExpression="MAR">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="ABR" HeaderText="ABR" 
                SortExpression="ABR">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="MAI" HeaderText="MAI" 
                SortExpression="MAU">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="JUN" HeaderText="JUN" 
                SortExpression="JUN" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="JUL" HeaderText="JUL" 
                SortExpression="JUL" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="AGO" HeaderText="AGO" 
                SortExpression="AGO" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="SET" HeaderText="SET" 
                SortExpression="SET" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="OUT" HeaderText="OUT" 
                SortExpression="OUT">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="NOV" HeaderText="NOV" 
                SortExpression="NOV" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="DEZ" HeaderText="DEZ" 
                SortExpression="DEZ">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="TRI01" HeaderText="1º Tri" SortExpression="TRI01" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="TRI02" HeaderText="2º Tri" SortExpression="TRI02" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="TRI03" HeaderText="3º Tri" SortExpression="TRI03" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="TRI04" HeaderText="4º Tri" SortExpression="TRI04" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="YTD" HeaderText="YTD" SortExpression="YTD" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="TOTAL" HeaderText="Total" SortExpression="TOTAL">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="MEDIA" HeaderText="Média" SortExpression="MEDIA" DataFormatString="{0:n}" >
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
        </Columns>
        <HeaderStyle 
            HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Small" />
        <RowStyle HorizontalAlign="Center" 
            VerticalAlign="Middle" />
    </asp:GridView>
    <br />
    <br />
</div>
    <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_DATAS_ANOS] WHERE ([ANO_ANALISAR] = @ANO_ANALISAR) ORDER BY [ANO_VALOR] DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="ANO_ANALISAR" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Usuarios" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_USUARIOS] WHERE (([COD_PERFIL] = @COD_PERFIL) AND ([ATIVO] = @ATIVO)) ORDER BY [NOME]">
        <SelectParameters>
            <asp:Parameter DefaultValue="3" Name="COD_PERFIL" Type="Decimal" />
            <asp:Parameter DefaultValue="True" Name="ATIVO" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
     <asp:SqlDataSource ID="dts_Report" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT * FROM [VIEW_DEMANDA_001_AGRUPADO_ESTABELECIMENTO] WHERE (([ANO] = @ANO) AND ([EMAIL_GERENTE_CONTA] = @EMAIL_REPRESENTANTE)) ORDER BY [TOTAL] DESC">
         <SelectParameters>
             <asp:ControlParameter ControlID="cmb_Ano" Name="ANO" PropertyName="SelectedValue" Type="Decimal" />
             <asp:ControlParameter ControlID="cmb_Usuario" Name="EMAIL_REPRESENTANTE" PropertyName="SelectedValue" Type="String" />
         </SelectParameters>
        </asp:SqlDataSource>
</form>
    </body>
</html>
