<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Visitas_Agenda.aspx.vb" Inherits="Visitas_Agenda"  EnableEventValidation ="false" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Agenda de Visitas</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Agenda de Visitas</div>
    <div id ="Titulo_Pagina_Links">
        <asp:LinkButton ID="cmd_Excel" runat="server">Exportar para Excel</asp:LinkButton>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
    <asp:DropDownList ID="cmb_REPRESENTANTES" runat="server" AutoPostBack="True" DataSourceID="dts_REPRESENTANTE" DataTextField="NOME" DataValueField="EMAIL"></asp:DropDownList>
    &nbsp;
    <br />
    <br />
    <asp:GridView ID="gdv_Agenda" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="dts_Proximas_Visitas" GridLines="None">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ID_VISITA,CNPJ" DataNavigateUrlFormatString="Visita_Ficha.aspx?ID_VISITA={0}&amp;CNPJ={1}" DataTextField="ID_VISITA" HeaderText="ID" />
            <asp:BoundField DataField="PROXIMA_VISITA" HeaderText="Data" ReadOnly="True" SortExpression="PROXIMA_VISITA" />
            <asp:BoundField DataField="ESTABELECIMENTO_CNPJ" HeaderText="Estabelecimento" ReadOnly="True" SortExpression="ESTABELECIMENTO_CNPJ" >
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="NOME" HeaderText="Visitado" ReadOnly="True" SortExpression="NOME" >
            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="ACAO_PROXIMA_VISITA" HeaderText="Comentários" SortExpression="ACAO_PROXIMA_VISITA" >
            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>

</div>
    <asp:SqlDataSource ID="dts_REPRESENTANTE" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [NOME], [EMAIL] FROM [VIEW_USUARIOS] WHERE ([COD_PERFIL] = @COD_PERFIL) order by USUARIO">
        <SelectParameters>
            <asp:Parameter DefaultValue="4" Name="COD_PERFIL" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="dts_Proximas_Visitas" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_VISITAS_GERAL] WHERE (([EMAIL_VISITANTE] = @EMAIL_VISITANTE) AND ([DAT_PROXIMA_VISITA] &gt; @DAT_PROXIMA_VISITA))">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmb_REPRESENTANTES" Name="EMAIL_VISITANTE" PropertyName="SelectedValue" Type="String" />
            <asp:SessionParameter Name="DAT_PROXIMA_VISITA" SessionField="HOJE" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    
</form>
</body>
</html>
