<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Estoque_Mapa_Distribuidor.aspx.vb" Inherits="Estoque_Mapa_Distribuidor" %>


<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Início</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/MasterTheme/Master.css" />
</head>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<body>
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Mapa de Estoque por Distribuidor</div>
</div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id ="Corpo">
        <Strong>
        <br />
        <br />
        Distribuidor</strong><br />
        <asp:DropDownList ID="cmb_Distribuidores" runat="server" DataSourceID="dts_distribuidores" DataTextField="ESTABELECIMENTO" DataValueField="CNPJ" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <strong>Ano</strong><br />
        <asp:DropDownList ID="cmb_ANO" runat="server" DataSourceID="dts_ANO" DataTextField="ANO" DataValueField="ANO" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <strong>Mês</strong><br />
        <asp:DropDownList ID="cmb_MES" runat="server" AutoPostBack="True" DataSourceID="dts_MES" DataTextField="MES_EXTENSO" DataValueField="MES">
        </asp:DropDownList>
        <br />
        <br />
   <rsweb:ReportViewer ID="rpt_Report" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="403px" Width="100%">
        <LocalReport ReportPath="Reports\rpt_Distribuidor_Mapa_Estoque.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="dts_estoque" Name="dts_Estoque" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
        <br />
             

</div>
        <asp:SqlDataSource ID="dts_ANO" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT DISTINCT [ANO] FROM [VIEW_MOVIMENTO_ESTOQUE_001_DETALHADO_FISCAL_UN_OR] ORDER BY [ANO] DESC">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_MES" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT [MES_EXTENSO], [MES] FROM [TBL_DATAS_MESES] ORDER BY [MES]">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_estoque" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT COD_TIPO_MOVIMENTO, TIPO_MOVIMENTO_DESCRICAO, ANO, ANO_TRIMESTRE, ANO_MES, ANO_MES_DIA, TRIMESTRE, TRIMESTRE_SIGLA, MES, MES_SIGLA, MES_YTD, MES_36, DIA, GRUPO_DISTRIBUIDOR, DISTRIBUIDOR, CNPJ_DISTRIBUIDOR, CNPJ_ESTABELECIMENTO, CNES, GRUPO_ESTABELECIMENTO, ESTABELECIMENTO, ESTABELECIMENTO_CNPJ, RAZAO_SOCIAL, CEP, COD_MUNICIPIO, MUNICIPIO, UF, ESTADO, REGIAO, MICRO_REGIAO_SAUDE, REGIAO_SAUDE, TIPO_PESSOA, COD_ESFERA_ADMINISTRATIVA, ESFERA, GESTAO, NATUREZA_JURIDICA_DESCRICAO, GERENTE_CONTA, EMAIL_GERENTE_CONTA, DIRETOR, EMAIL_DIRETOR, GERENTE, EMAIL_GERENTE, COORDENADOR, EMAIL_COORDENADOR, EMAIL_REPRESENTANTE, REPRESENTANTE, QTD_SETORIZACOES, COD_PRODUTO_DIVISAO, PRODUTO_DIVISAO, ID_EQUIPE, EQUIPE, COD_PRODUTO_LINHA, PRODUTO_LINHA, COD_PRODUTO_GRUPO, PRODUTO_GRUPO, COD_PRODUTO, PRODUTO, PRODUTO_UNIDADE_VENDA, PRODUTO_EMBALAGEM_VENDA, QTD_UNIDADES_EMBALAGEM_VENDA, PRECO_BASE_UNIDADE_VENDA, PRECO_BASE_EMBALAGEM_VENDA, FATOR_CONVERSAO_UNIDADE_EQUIVALENTE, PRODUTO_UNIDADE_EQUIVALENTE, QTD_EMBALAGEM_EQUIVALENTE, QTD_ORIGINAL, QTD, JAN, FEV, MAR, ABR, MAI, JUN, JUL, AGO, [SET], OUT, NOV, DEZ, YTD, TOTAL, TARGET FROM VIEW_MOVIMENTO_ESTOQUE_001_DETALHADO_UNIVERSAL_UN_OR WHERE (ANO = @ANO) AND (MES = @MES) AND (CNPJ_DISTRIBUIDOR = @CNPJ_DISTRIBUIDOR)">
            <SelectParameters>
                <asp:ControlParameter ControlID="cmb_ANO" Name="ANO" PropertyName="SelectedValue" Type="Decimal" />
                <asp:ControlParameter ControlID="cmb_MES" Name="MES" PropertyName="SelectedValue" Type="Decimal" />
                <asp:ControlParameter ControlID="cmb_Distribuidores" Name="CNPJ_DISTRIBUIDOR" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
             

        <asp:SqlDataSource ID="dts_distribuidores" runat="server" 
            ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
            SelectCommand="SELECT [CNPJ], [CAPTAR_ESTOQUE], [GRUPO_DISTRIBUIDOR], [ESTABELECIMENTO] FROM [VIEW_DISTRIBUIDORES_001_DETALHADO] ORDER BY [ESTABELECIMENTO]">
        </asp:SqlDataSource>
</form>
</body>
</html>