<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Visitas_Incluir.aspx.vb" Inherits="Visitas_Incluir_Contatos" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <script src="JavaScript.js" type="text/javascript"></script>
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Lançamento de Visita</div>
    <div id ="Titulo_Pagina_Links">
        <a href="Contatos_Ficha.aspx?CNPJ=<%=Session("COD_CONTATO")%>">Ficha do Contato</a>&nbsp;
        <% If Len(Request.QueryString("CNPJ")) > 1 Then%>
            <a href="Estabelecimentos_Ficha.aspx?CNPJ=<%=Request.QueryString("CNPJ")%>">Voltar Estabelecimento</a>
        <% End If%>
    </div>
</div>
<br />
<div id ="Corpo">
        <br />
        <asp:FormView ID="frv_CONTATO" runat="server" DataSourceID="dts_Contatos" Width="75%">
            <EditItemTemplate></EditItemTemplate>
            <InsertItemTemplate></InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="NOMELabel" runat="server" style="font-weight: 700" Text='<%# Bind("NOME") %>' />
                <br />
            </ItemTemplate>
        </asp:FormView>
        <asp:FormView ID="frv_CONTATO_ESTABELECIMENTO" runat="server" DataSourceID="dts_Contato_Estabelecimento" Width="75%">
            <EditItemTemplate></EditItemTemplate>
            <InsertItemTemplate></InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="EstabelecimentoLabel" runat="server" style="font-weight: 700" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' />
                <br />
            </ItemTemplate>
        </asp:FormView>
        <br />
        <asp:Label ID="lbl_DATA" runat="server" Font-Bold="True" Text="Data"></asp:Label>
        <br />
        <asp:DropDownList ID="cmb_DATA" runat="server" DataSourceID="dts_DATA" DataTextField="DATA_EXTENSO" DataValueField="ANO_MES_DIA"></asp:DropDownList>
        <br />
        <asp:Label ID="lbl_PERIODO" runat="server" Font-Bold="True" Text="Período"></asp:Label>
        <br />
        <asp:DropDownList ID="cmb_PERIODO_VISITA" runat="server" DataSourceID="dts_VISITAS_PERIODO" DataTextField="PERIODO" DataValueField="ID_PERIODO"></asp:DropDownList>
        <br />
        <asp:Label ID="lbl_STATUS" runat="server" Font-Bold="True" Text="Status"></asp:Label>
        <br />
        <asp:DropDownList ID="cmb_STATUS" runat="server" DataSourceID="dts_VISITAS_STATUS" DataTextField="STATUS_VISITA" DataValueField="ID_STATUS_VISITA"></asp:DropDownList>
        <br />
        <asp:Label ID="lbl_VISITA_TEMPO" runat="server" Font-Bold="True" Text="Tempo de Visita"></asp:Label>
        <br />
        <asp:DropDownList ID="cmb_VISITAS_TEMPO" runat="server" DataSourceID="dts_VISITAS_TEMPO" DataTextField="TEMPO" DataValueField="MINUTOS"></asp:DropDownList>
        <br />
        <asp:Label ID="lbl_OBJETIVO" runat="server" Font-Bold="True" Text="Objetivo"></asp:Label>
        <br />
        <asp:DropDownList ID="cmb_OBJETIVO" runat="server" DataSourceID="dts_VISITAS_OBJETIVOS" DataTextField="OBJETIVO" DataValueField="ID_OBJETIVO"></asp:DropDownList>
        <br />
        <asp:Label ID="lbl_PRODUTO_FOCO" runat="server" Font-Bold="True" Text="Linha de Produto (foco)"></asp:Label>
        <br />
        <asp:DropDownList ID="cmb_PRODUTO_FOCO" runat="server" DataSourceID="dts_Linha_Produtos" DataTextField="PRODUTO_LINHA" DataValueField="COD_PRODUTO_LINHA"></asp:DropDownList>
        <br />
        <asp:Label ID="lbl_COMENTARIO" runat="server" Font-Bold="True" Text="Comentário"></asp:Label>
&nbsp;<br />
        <asp:TextBox ID="txt_COMENTARIOS" runat="server" Rows="3" TextMode="MultiLine" Width="30%"></asp:TextBox>
        <br />
        <asp:Label ID="lbl_PROXIMA_VISITA" runat="server" Font-Bold="True" Font-Italic="False" Text="Agendar próxima visita "></asp:Label>
        &nbsp;<asp:DropDownList ID="cmb_PROXIMA_VISITA_LANCAR" runat="server" AutoPostBack="True" DataSourceID="dts_VISITA_PROXIMA" DataTextField="DESCRICAO" DataValueField="ATIVO">
        </asp:DropDownList>
        <br />
        <asp:Calendar ID="cld_PROXIMA_VISITA" runat="server" Height="16px" Width="30%" style="font-size: medium" Enabled="False"></asp:Calendar>
        <asp:Label ID="lbl_OBJETIVO_PROXIMA_VISITA" runat="server" Font-Bold="True" Text="Objetivo próxima visita"></asp:Label>
        <br />
        <asp:TextBox ID="txt_OBJETIVO_PROXIMA" runat="server" Rows="3" TextMode="MultiLine" Width="30%" Enabled="False"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="cmd_GRAVAR" runat="server" CssClass="buton_gravar" Text="Gravar" />
        <br />
        <br />
        <br />
        <br />
    </div>
        <asp:SqlDataSource ID="dts_Contatos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_CONTATOS] WHERE ([COD_CONTATO] = @COD_CONTATO)">
           <SelectParameters>
                <asp:QueryStringParameter Name="COD_CONTATO" QueryStringField="COD_CONTATO" Type="String" />
           </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Contato_Estabelecimento" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_CONTATOS_ESTABELECIMENTOS] WHERE (([COD_CONTATO] = @COD_CONTATO) AND ([CNPJ] = @CNPJ))">
            <SelectParameters>
                <asp:QueryStringParameter Name="COD_CONTATO" QueryStringField="COD_CONTATO" Type="String" />
                <asp:QueryStringParameter Name="CNPJ" QueryStringField="CNPJ" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_VISITAS_OBJETIVOS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [ID_OBJETIVO], [OBJETIVO] FROM [TBL_VISITAS_OBJETIVO]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_DATA" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT TOP 3 [DATA_EXTENSO], [ANO_MES_DIA] FROM [VIEW_DATAS] WHERE (([ANO_MES_DIA] &lt;= @ANO_MES_DIA) AND ([DIA_VISITA] = @DIA_VISITA)) ORDER BY [ANO_MES_DIA] DESC">
            <SelectParameters>
                <asp:SessionParameter Name="ANO_MES_DIA" SessionField="HOJE" Type="String" />
                <asp:Parameter DefaultValue="1" Name="DIA_VISITA" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_VISITAS_STATUS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [ID_STATUS_VISITA], [STATUS_VISITA] FROM [TBL_VISITAS_STATUS] ORDER BY [ID_STATUS_VISITA]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_VISITA_PROXIMA" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_ATIVO]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_VISITAS_PERIODO" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_VISITAS_PERIODOS]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_VISITAS_TEMPO" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [MINUTOS], [TEMPO] FROM [TBL_VISITAS_TEMPO]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Linha_Produtos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_PRODUTOS_LINHAS] ORDER BY [PRODUTO_LINHA]"></asp:SqlDataSource>
    </form>
</body>
</html>
