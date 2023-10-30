<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Visitas_Incluir.aspx.vb" Inherits="Visitas_Incluir" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Lançamento de Visita</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <script src="JavaScript.js" type="text/javascript"></script>
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Lançamento de Visita</div>
    <div id ="Titulo_Pagina_Links">
        <a href="Estabelecimentos_Ficha2.aspx?CNPJ=<%=Session("CNPJ")%>">Voltar para Estabelecimento</a>
    </div>
</div>
<br />
<div id ="Corpo">
    <br />
        <asp:FormView ID="frm_Estabelecimento_Ficha" runat="server" DataSourceID="dts_Estabelecimento" Width="100%">
            <EditItemTemplate></EditItemTemplate>
            <InsertItemTemplate></InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="ESTABELECIMENTOLabel" runat="server" Text='<%# Bind("ESTABELECIMENTO_CNPJ") %>' style="font-weight: 700"/>
                <br />
            </ItemTemplate>
       </asp:FormView>
        <asp:TextBox ID="txt_NOME" runat="server" Enabled="False" Width="50%"></asp:TextBox>
        <asp:TextBox ID="txt_TIPO" runat="server" Enabled="False" EnableTheming="True" Visible="False"></asp:TextBox>
        <asp:TextBox ID="txt_ID" runat="server" Enabled="False" EnableTheming="True" Visible="False"></asp:TextBox>
        <br />
        <br />
        <b>Data</b>
        <br />
        <asp:DropDownList ID="cmb_DATA" runat="server" DataSourceID="dts_DATA" DataTextField="DATA_EXTENSO" DataValueField="DATA_VALOR">
        </asp:DropDownList>
        <br />
        <br />
        <strong>Período</strong><br />
        <asp:DropDownList ID="cmb_PERIODO_VISITA" runat="server" DataSourceID="dts_VISITAS_PERIODO" DataTextField="PERIODO" DataValueField="ID">
        </asp:DropDownList>
        <br />
        <br />
        <strong>Tempo da visita</strong><br />
        <asp:DropDownList ID="cmb_VISITAS_TEMPO" runat="server" DataSourceID="dts_VISITAS_TEMPO" DataTextField="TEMPO" DataValueField="MINUTOS">
        </asp:DropDownList>
        <br />
        <br />
        <b>Objetivo </b>
        <br />
        <asp:DropDownList ID="cmb_OBJETIVO" runat="server" DataSourceID="dts_VISITAS_OBJETIVOS" DataTextField="OBJETIVO" DataValueField="ID_OBJETIVO">
        </asp:DropDownList>
        <br />
        <br />
        <b>Comentário da Visita</b><br />
        <asp:TextBox ID="txt_COMENTARIOS" runat="server" Rows="3" TextMode="MultiLine" Width="75%"></asp:TextBox>
        <br />
        <br />
        <b>Próxima Visita 
        <asp:Calendar ID="cld_Proxima_Visita" runat="server" Height="16px" Width="50%"></asp:Calendar>
        </b>
        <br />
        <b>Objetivo para próxima visita</b><br />
        <asp:TextBox ID="txt_COMENTARIOS0" runat="server" Rows="3" TextMode="MultiLine" Width="75%"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="cmd_GRAVAR" runat="server" CssClass="buton_gravar" Text="Gravar" />
        <br />
        <asp:SqlDataSource ID="dts_Contatos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_MEDICOS_ESTABELECIMENTOS] WHERE ([CNPJ] = @CNPJ) ORDER BY [NOME]">
            <SelectParameters>
                <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_PRODUTOS_LINHAS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_PRODUTOS_LINHAS]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Estabelecimento" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS] WHERE ([CNPJ] = @CNPJ)">
            <SelectParameters>
                <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />  
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_VISITAS_OBJETIVOS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [ID_OBJETIVO], [OBJETIVO] FROM [TBL_VISITAS_OBJETIVO]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_DATA" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT Top 3 [DATA_VALOR], [DATA_EXTENSO] FROM [VIEW_DATAS] WHERE ([CALENDARIO_VISITAS] = @CALENDARIO_VISITAS) ORDER BY [DATA_VALOR] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="CALENDARIO_VISITAS" Type="Boolean" />
            </SelectParameters>
    </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_VISITAS_STATUS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [COD_STATUS_VISITA], [STATUS_VISITA] FROM [TBL_VISITAS_STATUS]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_VISITAS_PERIODO" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_VISITAS_PERIODOS]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_VISITAS_TEMPO" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [MINUTOS], [TEMPO] FROM [TBL_VISITAS_TEMPO]"></asp:SqlDataSource>
    </div>
    </form>
    <br /><br /><br />
</body>
</html>
