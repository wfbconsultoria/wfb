<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Oportunidades_Localizar.aspx.vb" Inherits="Oportunidades_Localizar" enableeventvalidation="false" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Minhas Oportunidades</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Oportunidades</div>
    <div id ="Titulo_Pagina_Links">
        <asp:LinkButton ID="cmd_Excel" runat="server">Exportar para Excel</asp:LinkButton>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
        <div>
            Selecione o &nbsp;<asp:Label ID="Label1" runat="server" Text="Representante:"></asp:Label>
            <asp:DropDownList ID="cmb_Representante" runat="server" DataSourceID="dts_Representantes" DataTextField="NOME" DataValueField="EMAIL" AutoPostBack="True">
            </asp:DropDownList>
            &nbsp;e Ano de Conclusão
            <asp:DropDownList ID="cmb_Ano_Conclcusao" runat="server" DataSourceID="dts_Anos" DataTextField="ANO_OPORTUNIDADE" DataValueField="ANO_OPORTUNIDADE" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
        </div>
        <asp:GridView ID="gdv_Oportunidades" runat="server" AutoGenerateColumns="False" DataSourceID="dts_Oportunidades" HorizontalAlign="Center" AllowSorting="True">
            
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="ID_OPORTUNIDADE,CNPJ,ANO_OPORTUNIDADE" DataNavigateUrlFormatString="Oportunidades_Manutencao.aspx?PAGINA_ORIGEM=Oportunidades_Manutencao&amp;ID_OPORTUNIDADE={0}&amp;CNPJ={1}&amp;ANO={2}" DataTextField="ID_OPORTUNIDADE" HeaderText="ID" SortExpression="ID_OPORTUNIDADE" Target="_blank" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="MES_SIGLA" HeaderText="Mês" SortExpression="MES_FECHAMENTO_PREVISTO">
                <HeaderStyle Width="2%" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" Width="2%" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="CNPJ" DataNavigateUrlFormatString="Estabelecimentos_Ficha.aspx?CNPJ={0}" DataTextField="ESTABELECIMENTO_CNPJ" HeaderText="Estabelecimento" SortExpression="ESTABELECIMENTO_CNPJ" />
                <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição" SortExpression="DESCRICAO">
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle Font-Size="X-Small" HorizontalAlign="Left" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="FASE" HeaderText="Fase" SortExpression="FASE" >
                <HeaderStyle Font-Size="Small" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle Font-Size="X-Small" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="FASE_ATUAL_QTD_PREVISTA" HeaderText="Qtd" SortExpression="FASE_ATUAL_QTD_PREVISTA" DataFormatString="{0:n0}" ReadOnly="True">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
            </Columns>
            <EmptyDataTemplate>
                Selecione o Representante e Ano de Conclusão
            </EmptyDataTemplate>
            <HeaderStyle  HorizontalAlign="Center" VerticalAlign="Middle" />
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
    </div>
<asp:SqlDataSource ID="dts_Oportunidades" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_OPORTUNIDADES] WHERE (([EMAIL_REPRESENTANTE] = @EMAIL_REPRESENTANTE) AND ([ANO_OPORTUNIDADE] = @ANO_OPORTUNIDADE))">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmb_Representante" Name="EMAIL_REPRESENTANTE" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="cmb_Ano_Conclcusao" Name="ANO_OPORTUNIDADE" PropertyName="SelectedValue" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
<asp:SqlDataSource ID="dts_Representantes" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_USUARIOS] WHERE (([STATUS] = @STATUS) AND ([BLOQUEADO] = @BLOQUEADO) AND ([PERFIL] = @PERFIL)) ORDER BY [NOME]">
        <SelectParameters>
            <asp:Parameter DefaultValue="ATIVO" Name="STATUS" Type="String" />
            <asp:Parameter DefaultValue="False" Name="BLOQUEADO" Type="Boolean" />
            <asp:Parameter DefaultValue="Representante" Name="PERFIL" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
            
</form><asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                SelectCommand="SELECT DISTINCT ANO_OPORTUNIDADE FROM TBL_OPORTUNIDADES ORDER BY ANO_OPORTUNIDADE DESC">
            </asp:SqlDataSource>
</body>
</html>