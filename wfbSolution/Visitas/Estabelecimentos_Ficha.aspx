<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estabelecimentos_Ficha.aspx.vb" Inherits="Estabelecimentos_Ficha" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ficha do Estabelecimento</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Ficha do Estabelecimento 
        &nbsp; Ano: <asp:DropDownList ID="cmb_Ano" runat="server" AutoPostBack="True" DataSourceID="dts_Anos" DataTextField="ANO_VALOR" DataValueField="ANO_VALOR"></asp:DropDownList>
    </div>
    <div id ="Titulo_Pagina_Links">
        <a href="rpt_Demanda_Detalhada.aspx?CNPJ=<%=Session("CNPJ")%>">Demanda Detalhada</a>
        &nbsp;
        <a href="Estabelecimentos_Ficha_Inventario_Bombas_Representante.aspx?CNPJ=<%=Session("CNPJ")%>">Inventário Bombas</a>
        &nbsp;
        <%--<% If Session("SISTEMA") = True Then%>
        <a href="Estabelecimentos_Cotas.aspx?CNPJ=<%=Session("CNPJ")%>">Cotas do Estabelecimento</a>        <% End If%>--%>
    </div>    
</div>

<div id ="Corpo">
    <br />
        <asp:FormView ID="frm_Estabelecimento_Ficha" runat="server" 
        DataSourceID="dts_Estabelecimento" Width="100%" Height="20px">
        <EditItemTemplate></EditItemTemplate>
        <InsertItemTemplate></InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl_Estabelecimento" runat="server"  Text='<%# Eval("ESTABELECIMENTO_CNPJ") %>' style="font-weight: 700" />
                <br />
                Atendido por &nbsp;<asp:Label ID="Label_Representante" runat="server"  Text='<%# Eval("REPRESENTANTE") %>' />
                &nbsp;- Inclusão
                <asp:Label ID="Label_Representante0" runat="server" Text='<%# Eval("INCLUSAO_SETORIZACAO") %>' />
                &nbsp;/ Alteração
                <asp:Label ID="Label_Representante1" runat="server" Text='<%# Eval("ALTERACAO_SETORIZACAO")%>' />
                <br />
                Gerente de Conta:
                <asp:Label ID="Label_Gerente_Conta" runat="server" Text='<%# Eval("GERENTE_CONTA")%>' />
            </ItemTemplate>
        </asp:FormView>
   
    <asp:Table ID="tbl_Report" runat="server" BorderStyle="None" BorderWidth="0px" BorderColor="White"
        CaptionAlign="Left" Font-Names="Calibri" Font-Size="Small" 
        GridLines="Both" HorizontalAlign="Left" 
        style="text-align: center" Width="100%">
    </asp:Table>
</div>
    <br /><br /><br /><br />
        <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_DATAS_ANOS] WHERE ([ANO_ANALISAR] = @ANO_ANALISAR) ORDER BY [ANO_VALOR] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="ANO_ANALISAR" Type="Boolean" />
            </SelectParameters>
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