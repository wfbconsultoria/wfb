<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Gerente_Ficha_Representante.aspx.vb" Inherits="Gerente_Ficha_Representante" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Performance Brasil</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Ficha do Gerente Regional
                <asp:DropDownList ID="cmb_EMAIL_GERENTE" runat="server" 
                    AutoPostBack="True" DataSourceID="dts_GERENTE" DataTextField="NOME" 
                    DataValueField="EMAIL" style="font-weight: 700">
                </asp:DropDownList>
                &nbsp;<asp:DropDownList ID="cmb_Ano" runat="server" AutoPostBack="True" DataSourceID="dts_Anos" DataTextField="ANO_VALOR" DataValueField="ANO_VALOR">
        </asp:DropDownList>

&nbsp;<asp:DropDownList ID="cmb_TIPO_MOVIMENTO" runat="server" DataSourceID="dts_TIPO_MOVIMENTO" DataTextField="DESCRICAO" DataValueField="TABELA_ORIGEM" AutoPostBack="True"></asp:DropDownList>

        &nbsp
                </div>
    <div id ="Titulo_Pagina_Links"></div>
</div>
<br />
<div id ="Corpo">
    <br />
    Selecione a linha que deseja ver:<asp:DropDownList ID="cmb_Produto_Linha" runat="server" AutoPostBack="True" DataSourceID="dts_Linha" DataTextField="PRODUTO_LINHA" DataValueField="PRODUTO_LINHA" style="margin-bottom: 0px">
        </asp:DropDownList>

    <br />
    <br/>
    <asp:Table ID="tbl_Report" runat="server" BorderStyle="None" BorderWidth="0px" BorderColor="White"
            CaptionAlign="Left" Font-Names="Calibri" Font-Size="Small" 
            GridLines="Both" HorizontalAlign="Left" 
            style="text-align: center" Width="100%">
   </asp:Table>
</div>
    <asp:SqlDataSource ID="dts_GERENTE" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                    SelectCommand="SELECT * FROM [VIEW_USUARIOS] WHERE (([BLOQUEADO] = @BLOQUEADO) AND ([PERFIL] = @PERFIL)) ORDER BY [USUARIO]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="False" Name="BLOQUEADO" Type="Boolean" />
                        <asp:Parameter DefaultValue="Gerente" Name="PERFIL" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_DATAS_ANOS] WHERE ([ANO_ANALISAR] = @ANO_ANALISAR) ORDER BY [ANO_VALOR] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="ANO_ANALISAR" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_TIPO_MOVIMENTO" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '@' AS TABELA_ORIGEM, '# Selecione' AS DESCRICAO UNION ALL SELECT [TABELA_ORIGEM], [DESCRICAO] FROM [VIEW_CONFIG_TIPO_MOVIMENTO] WHERE ([COD_TIPO_MOVIMENTO] = @COD_TIPO_MOVIMENTO)  ORDER BY [DESCRICAO]">
        <SelectParameters>
            <asp:Parameter DefaultValue="01010202" Name="COD_TIPO_MOVIMENTO" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Linha" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '# Selecione' as [PRODUTO_LINHA] UNION ALL SELECT [PRODUTO_LINHA] FROM [TBL_PRODUTOS_LINHAS] WHERE ([ANALISAR] = @ANALISAR) ORDER BY [PRODUTO_LINHA]">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="ANALISAR" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
</form>
</body>
</html>