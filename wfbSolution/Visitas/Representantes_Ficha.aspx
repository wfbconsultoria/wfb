﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Representantes_Ficha.aspx.vb" Inherits="Representates_Ficha" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Ficha do Representante</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Ficha do Representante &nbsp
                <asp:DropDownList ID="cmb_EMAIL_REPRESENTANTE" runat="server" 
                    AutoPostBack="True" DataSourceID="dts_Representantes" DataTextField="NOME" 
                    DataValueField="EMAIL" style="font-weight: 700">
                </asp:DropDownList>
                <asp:DropDownList ID="cmb_Ano" runat="server" AutoPostBack="True" DataSourceID="dts_Anos" DataTextField="ANO_VALOR" DataValueField="ANO_VALOR">
                </asp:DropDownList>
   </div>
    <div id ="Titulo_Pagina_Links"></div>      
</div>    
<br />
<div id ="Corpo">
    <br/>
    Clique na linha que deseja ver: 
        &nbsp;<asp:LinkButton ID="lnk_Todos" runat="server">Todas as linhas</asp:LinkButton> /
        &nbsp;<asp:LinkButton ID="lnk_Equipos_Edds" runat="server">Equipos Edds</asp:LinkButton> /
        &nbsp;<asp:LinkButton ID="lnk_Equipos_Gemstar" runat="server">Equipos Gemstar</asp:LinkButton> / 
        &nbsp;<asp:LinkButton ID="lnk_Clave" runat="server">Clave</asp:LinkButton> / 
        &nbsp;<asp:LinkButton ID="lnk_Supercath" runat="server">Supercath</asp:LinkButton>
    <asp:Table ID="tbl_Report" runat="server" BorderStyle="None" BorderWidth="0px" BorderColor="White"
            CaptionAlign="Left" Font-Names="Calibri" Font-Size="Small" 
            GridLines="Both" HorizontalAlign="Left" 
            style="text-align: center" Width="100%">
   </asp:Table>
    <br />
    <br />
    <br />
</div>
    <asp:SqlDataSource ID="dts_Representantes" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
                    SelectCommand="SELECT * FROM [VIEW_USUARIOS] WHERE (([BLOQUEADO] = @BLOQUEADO) AND ([PERFIL] = @PERFIL)) ORDER BY [USUARIO]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="False" Name="BLOQUEADO" Type="Boolean" />
                        <asp:Parameter DefaultValue="Representante" Name="PERFIL" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Oportunidades" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_OPORTUNIDADES_FINAL] WHERE ([CNPJ] = @CNPJ)">
        <SelectParameters>
            <asp:SessionParameter Name="CNPJ" SessionField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_Anos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT ANO_VALOR, ANO_TEXTO, ANO_FECHADO, ANO_BISSESTO, ANO_ANALISAR, ANO_PERIODO, ANO_FECHADO_CALCULO_INCENTIVO, ANO_FECHADO_COTAS, ANO_ABERTO_VISITACAO, ANO_ABERTO_OPORTUNIDADES FROM tbl_DATAS_ANOS WHERE (ANO_ANALISAR = @ANO_ANALISAR) AND (ANO_VALOR &gt;= 2014) ORDER BY ANO_VALOR DESC">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="ANO_ANALISAR" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Linha" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="Select '# Selecione a Linha' as [LINHA] UNION ALL Select '# Todos' as [LINHA] UNION ALL Select LINHA From TBL_PRODUTOS_LINHAS Where Analisar = 'True'"></asp:SqlDataSource>
</form>
</body>
</html>