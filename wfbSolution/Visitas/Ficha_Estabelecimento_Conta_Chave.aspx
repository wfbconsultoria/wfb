<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Ficha_Estabelecimento_Conta_Chave.aspx.vb" Inherits="Ficha_Estabelecimento_Conta_Chave" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Análise de Contas Chave</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Análise de Contas Chave &nbsp;<asp:DropDownList ID="cmb_CONTAS_CHAVE" runat="server" DataSourceID="dts_CONTAS_CHAVE" DataTextField="CONTA_CHAVE" DataValueField="CONTA_CHAVE" AutoPostBack="True">
        </asp:DropDownList>
        &nbsp;<asp:Label ID="lbl_ANO" runat="server" Text="Ano"></asp:Label>
        <asp:DropDownList ID="cmb_Ano" runat="server" AutoPostBack="True" DataSourceID="dts_Anos" DataTextField="ANO_VALOR" DataValueField="ANO_VALOR">
        </asp:DropDownList>
&nbsp;&nbsp
                </div>
    <div id ="Titulo_Pagina_Links"></div>
</div>
<br />
<div id ="Corpo">
    <br />
    <asp:Label ID="lbl_LINHAS" runat="server" Text="Linha de Produto"></asp:Label>
    <br />
    <asp:DropDownList ID="cmb_LINHAS" runat="server" DataSourceID="dts_LINHAS" DataTextField="LINHA" DataValueField="COD" AutoPostBack="True">
    </asp:DropDownList>
    <br />
    <asp:Label ID="lbl_GERENTE_NACIONAL" runat="server" Text="Gerente Nacional"></asp:Label>
    <% If lbl_GERENTE_NACIONAL.Visible = True Then%>
    <br />
    <% End If%>
    <asp:DropDownList ID="cmb_GERENTE_NACIONAL" runat="server" DataSourceID="dts_GERENTE_NACIONAL" DataTextField="USUARIO" DataValueField="EMAIL" AutoPostBack="True">
    </asp:DropDownList>
    <% If cmb_GERENTE_NACIONAL.Visible = True Then%>
    <br />
    <% End If%>
    <asp:Label ID="lbl_GERENTE_REGIONAL" runat="server" Text="Gerente Regional"></asp:Label>
    <% If lbl_GERENTE_REGIONAL.Visible = True Then%>
    <br />
    <% End If%>
    <asp:DropDownList ID="cmb_GERENTE_REGIONAL" runat="server" DataSourceID="dts_GERENTE_REGIONAL" DataTextField="USUARIO" DataValueField="EMAIL" AutoPostBack="True">
    </asp:DropDownList>
    <% If cmb_GERENTE_REGIONAL.Visible = True Then%>
    <br />
    <% End If%>
    <asp:Label ID="lbl_REPRESENTANTE" runat="server" Text="Representante"></asp:Label>
    <% If lbl_REPRESENTANTE.Visible = True Then%>
    <br />
    <% End If%>
    <asp:DropDownList ID="cmb_REPRESENTANTE" runat="server" DataSourceID="dts_REPRESENTANTE" DataTextField="USUARIO" DataValueField="EMAIL" AutoPostBack="True">
    </asp:DropDownList>
    <% If cmb_REPRESENTANTE.Visible = True Then%>
    <br />
    <% End If%>
    <asp:Table ID="tbl_Report" runat="server" BorderStyle="None" BorderWidth="0px" BorderColor="White"
            CaptionAlign="Left" Font-Names="Calibri" Font-Size="Small" 
            GridLines="Both" HorizontalAlign="Left" 
            style="text-align: center" Width="100%">
   </asp:Table>
    <br />
    <br />
    <br />
    Demanda por Estabelecimentos
    <asp:GridView ID="gdv_Report" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="CNPJ" DataSourceID="dts_Report" Font-Names="Calibri" ShowHeaderWhenEmpty="True" Width="100%">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="CNPJ" DataNavigateUrlFormatString="Estabelecimentos_Ficha.aspx?CNPJ={0}" DataTextField="ESTABELECIMENTO_CNPJ" HeaderText="Estabelecimento" SortExpression="ESTABELECIMENTO_CNPJ" Target="_blank">
            <HeaderStyle Width="35%" />
            <ItemStyle Width="35%" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="TARGET_2" HeaderText="Target" SortExpression="TARGET_2">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="4%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="4%" />
            </asp:BoundField>
            <asp:BoundField DataField="JAN" HeaderText="JAN" SortExpression="JAN">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="FEV" HeaderText="FEV" SortExpression="FEV">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="MAR" HeaderText="MAR" SortExpression="MAR">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="ABR" HeaderText="ABR" SortExpression="ABR">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="MAI" HeaderText="MAI" SortExpression="MAU">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="JUN" HeaderText="JUN" SortExpression="JUN">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="JUL" HeaderText="JUL" SortExpression="JUL">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="AGO" HeaderText="AGO" SortExpression="AGO">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="SET" HeaderText="SET" SortExpression="SET">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="OUT" HeaderText="OUT" SortExpression="OUT">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="NOV" HeaderText="NOV" SortExpression="NOV">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="DEZ" HeaderText="DEZ" SortExpression="DEZ">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="TRI01" HeaderText="1º Tri" SortExpression="TRI01">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="TRI02" HeaderText="2º Tri" SortExpression="TRI02">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="TRI03" HeaderText="3º Tri" SortExpression="TRI03">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="TRI04" HeaderText="4º Tri" SortExpression="TRI04">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="YTD" HeaderText="YTD" SortExpression="YTD">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="TOTAL" HeaderText="Total" SortExpression="TOTAL">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
            <asp:BoundField DataField="MEDIA" DataFormatString="{0:n}" HeaderText="Média" SortExpression="MEDIA">
            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="3%" />
            </asp:BoundField>
        </Columns>
        <HeaderStyle Font-Size="Small" HorizontalAlign="Center" VerticalAlign="Middle" />
        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
    </asp:GridView>
</div>
    <asp:SqlDataSource ID="dts_Oportunidades" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_OPORTUNIDADES_FINAL] WHERE ([CNPJ] = @CNPJ)">
        <SelectParameters>
            <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_GERENTE_NACIONAL" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '@' as EMAIL, '@ Todos' as USUARIO UNION ALL SELECT EMAIL, USUARIO FROM [VIEW_USUARIOS] WHERE (([COD_PERFIL] = @COD_PERFIL) AND ([ATIVO] = @ATIVO)) ORDER BY [USUARIO]">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="COD_PERFIL" Type="Decimal" />
            <asp:Parameter DefaultValue="True" Name="ATIVO" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_GERENTE_REGIONAL" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '@' as EMAIL, '@ Todos' as USUARIO UNION ALL SELECT EMAIL, USUARIO FROM [VIEW_USUARIOS] WHERE (([COD_PERFIL] = @COD_PERFIL) AND ([ATIVO] = @ATIVO)) ORDER BY [USUARIO]">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="COD_PERFIL" Type="Decimal" />
            <asp:Parameter DefaultValue="True" Name="ATIVO" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_REPRESENTANTE" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '@' as EMAIL, '# Todos' as USUARIO UNION ALL SELECT EMAIL, USUARIO FROM [VIEW_USUARIOS] WHERE (([COD_PERFIL] = @COD_PERFIL) AND ([ATIVO] = @ATIVO)) ORDER BY [USUARIO]">
        <SelectParameters>
            <asp:Parameter DefaultValue="4" Name="COD_PERFIL" Type="Decimal" />
            <asp:Parameter DefaultValue="True" Name="ATIVO" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_DATAS_ANOS] WHERE ([ANO_ANALISAR] = @ANO_ANALISAR) ORDER BY [ANO_VALOR] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="ANO_ANALISAR" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_LINHAS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '0' AS COD, '@ Selecione' as LINHA UNION ALL SELECT COD, LINHA FROM [tbl_PRODUTOS_LINHAS] WHERE ([ANALISAR] = @ANALISAR)">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="ANALISAR" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Report" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_DEMANDA_001_AGRUPADO_ESTABELECIMENTO] WHERE (([ANO] = @ANO) AND ([CONTA_CHAVE] = @CONTA_CHAVE)) ORDER BY [TOTAL]">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmb_Ano" Name="ANO" PropertyName="SelectedValue" Type="Decimal" />
            <asp:ControlParameter ControlID="cmb_CONTAS_CHAVE" Name="CONTA_CHAVE" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_CONTAS_CHAVE" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '@ Selecione' as CONTA_CHAVE UNION ALL SELECT 'TODOS' as CONTA_CHAVE UNION ALL SELECT 'TODOS CHAVE' as CONTA_CHAVE UNION ALL SELECT DISTINCT [CONTA_CHAVE] FROM [VIEW_ESTABELECIMENTOS_001_DETALHADO]"></asp:SqlDataSource>
</form>
</body>
</html>