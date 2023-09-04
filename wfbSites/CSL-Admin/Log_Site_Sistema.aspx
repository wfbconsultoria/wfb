<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Log_Site_Sistema.aspx.vb" Inherits="Log_Site" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %><!DOCTYPE html><html xmlns="http://www.w3.org/1999/xhtml"><head id="Head1" runat="server"><title>Log de Acesso</title><link href="App_Themes/Master/Master.css" rel="stylesheet" /></head><body><form id="form1" runat="server">
    <uc1:Cabecalho runat="server" id="Cabecalho" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Log de Acesso (últimos 5000)</div>
    <div id ="Titulo_Pagina_Links">
        <asp:LinkButton ID="cmd_Excel" runat="server">Exportar para Excel</asp:LinkButton>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    Ano:
    <asp:DropDownList ID="cmb_Anos" runat="server" AutoPostBack="True" DataSourceID="dts_Anos" DataTextField="ANO_DESC" DataValueField="ANO">
    </asp:DropDownList>
    <br />
    Mês:
    <asp:DropDownList ID="cmb_Mes" runat="server" AutoPostBack="True" DataSourceID="dts_Mes" DataTextField="MES_EXTENSO" DataValueField="MES" style="height: 22px">
    </asp:DropDownList>
    <br />
    Usuario:
    <asp:DropDownList ID="cmb_usuario" runat="server" AutoPostBack="True" DataSourceID="dts_Usuarios" DataTextField="NOME" DataValueField="EMAIL">
    </asp:DropDownList>
    <br />
    <br />
    <asp:GridView ID="gdv_Log_Site" runat="server" AutoGenerateColumns="False" DataSourceID="dts_VIEW_LOG_SITE" Width="100%" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="ANO" HeaderText="Ano" SortExpression="ANO" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="MES" HeaderText="Mês" SortExpression="MES" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="DIA" HeaderText="Dia" SortExpression="DIA">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="HORA" HeaderText="Hora" SortExpression="HORA">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="MINUTO" HeaderText="Minuto" SortExpression="MINUTO" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="SEGUNDO" HeaderText="Segundo" SortExpression="SEGUNDO" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="EMAIL" HeaderText="E-mail" SortExpression="EMAIL" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="NOME" HeaderText="Usuário" SortExpression="NOME" >
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="IP" HeaderText="IP do Computador" SortExpression="IP" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
       
    </asp:GridView>

    </div>

        <asp:SqlDataSource ID="dts_VIEW_LOG_SITE" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT TOP 5000 * FROM [VIEW_LOG_SITE] ORDER BY [DATA] DESC, [NOME], [EMAIL]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="Select '9999' as ANO, '#Todos' as ANO_DESC UNION ALL SELECT DISTINCT [ANO] as ANO, CONVERT(VARCHAR, ANO) as ANO_DESC FROM [VIEW_LOG_SITE] ORDER BY [ANO] DESC"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Mes" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="Select '0' as MES, '# Todos' as MES_EXTENSO UNION ALL SELECT distinct [MES], [MES_EXTENSO] FROM [VIEW_DATAS_MESES] ORDER BY [MES]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Usuarios" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="Select '@' as EMAIL, '#Todos' as NOME UNION ALL SELECT EMAIL,NOME FROM [VIEW_USUARIOS] WHERE ([BLOQUEADO] = @BLOQUEADO) ORDER BY [NOME]">
        <SelectParameters>
            <asp:Parameter DefaultValue="false" Name="BLOQUEADO" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>

</form>
        </body>
    
</html>
