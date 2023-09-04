<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Visitas_Localizar.aspx.vb" Inherits="Representantes_Visitas" EnableEventValidation ="false"%>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Visitas Por Representante</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Visitas</div>
    <div id ="Titulo_Pagina_Links">
        <asp:LinkButton ID="cmd_Excel" runat="server">Exportar para Excel</asp:LinkButton>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    &nbsp;<asp:DropDownList ID="cmb_REPRESENTANTES" runat="server" AutoPostBack="True" DataSourceID="dts_REPRESENTANTE" DataTextField="NOME" DataValueField="EMAIL"></asp:DropDownList>
    &nbsp; Ano:
    <asp:DropDownList ID="cmb_Ano" runat="server" AutoPostBack="True" DataSourceID="dts_Anos" DataTextField="ANO_TEXTO" DataValueField="ANO_VALOR">
        <asp:ListItem>2013</asp:ListItem>
        <asp:ListItem>2014</asp:ListItem>
    </asp:DropDownList>
    <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_DATAS_ANOS] WHERE ([ANO_ABERTO_VISITACAO] = @ANO_ABERTO_VISITACAO) ORDER BY [ANO_VALOR] Desc">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="ANO_ABERTO_VISITACAO" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
&nbsp;Mês:
    <asp:DropDownList ID="cmb_Mes" runat="server" AutoPostBack="True" DataSourceID="dts_Meses" DataTextField="MES_EXTENSO" DataValueField="MES">
    </asp:DropDownList>
    <br />
    <br />
    <asp:GridView ID="gdv_LISTA_VISITAS" runat="server" AutoGenerateColumns="False" DataSourceID="dts_LISTAS_VISITAS_REPRESENTANTES" AllowSorting="True" DataKeyNames="ID_VISITA" Width="100%">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ID_VISITA,CNPJ_ESTABELECIMENTO" DataNavigateUrlFormatString="Visita_Ficha.aspx?ID_VISITA={0}&amp;CNPJ={1}" DataTextField="ID_VISITA" HeaderText="ID">
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="DATA_EXTENSO" HeaderText="Data" SortExpression="DATA_VISITA" >
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="PERIODO" HeaderText="Período" SortExpression="PERIODO" >
            <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="ESTABELECIMENTO_CNPJ" HeaderText="Estabelecimento" SortExpression="ESTABELECIMENTO_CNPJ" >
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="COMENTARIOS" HeaderText="Comentários" SortExpression="COMENTARIOS" >
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="NOME" HeaderText="Visitado" SortExpression="NOME" ReadOnly="True" >
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="DATA_PROXIMA_EXTENSO" HeaderText="Próxima Visita" SortExpression="DATA_PROXIMA_VALOR" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="ACAO_PROXIMA_VISITA" HeaderText="Ações Próxima Visita" SortExpression="ACAO_PROXIMA_VISITA" >
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="dts_LISTAS_VISITAS_REPRESENTANTES" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_VISITAS] WHERE (([ANO] = @ANO) AND ([MES] = @MES) AND ([EMAIL_VISITANTE] = @EMAIL_VISITANTE)) ORDER BY [DATA_VISITA], [PERIODO], [ID_VISITA]">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmb_Ano" Name="ANO" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="cmb_Mes" Name="MES" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="cmb_REPRESENTANTES" Name="EMAIL_VISITANTE" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_REPRESENTANTE" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [NOME], [EMAIL] FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = @COD_PERFIL) order by USUARIO">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="COD_PERFIL" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="dts_Meses" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [MES], [MES_EXTENSO] FROM [TBL_DATAS_MESES] ORDER BY [MES]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
