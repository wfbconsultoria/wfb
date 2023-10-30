<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Gerentes_Ficha.aspx.vb" Inherits="Gerentes_Ficha" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ficha do Gerente Regional</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Ficha do Gerente Regional &nbsp
                <asp:DropDownList ID="cmb_EMAIL_GERENTE" runat="server" 
                    AutoPostBack="True" DataSourceID="dts_GERENTE" DataTextField="NOME" 
                    DataValueField="EMAIL" style="font-weight: 700">
                </asp:DropDownList>
                &nbsp;
                <asp:DropDownList ID="cmb_Ano" runat="server" AutoPostBack="True" DataSourceID="dts_Anos" DataTextField="ANO_VALOR" DataValueField="ANO_VALOR">
                </asp:DropDownList>
   </div>
   <div id ="Titulo_Pagina_Links"></div>
</div>    
<br />
<div id ="Corpo">
    <asp:Table ID="tbl_Report" runat="server" BorderStyle="None" BorderWidth="0px" BorderColor="White"
            CaptionAlign="Left" Font-Names="Calibri" Font-Size="Small" 
            GridLines="Both" HorizontalAlign="Left" 
            style="text-align: center" Width="100%">
   </asp:Table>
    <br />
    <br />
    <br />
    <br />
</div>
    <asp:SqlDataSource ID="dts_GERENTE" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                    SelectCommand="SELECT * FROM [VIEW_USUARIOS] WHERE (([BLOQUEADO] = @BLOQUEADO) AND ([PERFIL] = @PERFIL)) ORDER BY [USUARIO]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="False" Name="BLOQUEADO" Type="Boolean" />
                        <asp:Parameter DefaultValue="Gerente" Name="PERFIL" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Oportunidades" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_OPORTUNIDADES_FINAL] WHERE ([CNPJ] = @CNPJ)">
        <SelectParameters>
            <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [tbl_DATAS_ANOS] WHERE ([ANO_ANALISAR] = @ANO_ANALISAR) ORDER BY [ANO_VALOR] DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="ANO_ANALISAR" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
</form>
</body>
</html>                