<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Master_Report_Distribuidor.aspx.vb" Inherits="rpt_Master_Report_Distribuidor" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Master Report</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Master Report Distribuidor</div>
    <div id ="Titulo_Pagina_Links">
        
        &nbsp;&nbsp;&nbsp;
        <a href="Menu_Analise_Distribuidor.aspx">Analisar Distribuidor</a>
    </div>
</div>    
<br />
<div id ="Corpo">
    <br />
    Selecione o relatório
    <br />
    <asp:DropDownList ID="cmb_Reports" runat="server" AutoPostBack="True" DataSourceID="dts_Relatorios" DataTextField="RELATORIO" DataValueField="CAMINHO_NOME"></asp:DropDownList>
    <br />
    Ano
    <br />
    <asp:DropDownList ID="cmb_ANO" runat="server" DataSourceID="dts_Anos" DataTextField="ANO" DataValueField="ANO" AutoPostBack="True"></asp:DropDownList>
    <br />
    Linha de Produtos
    <br />
    <asp:DropDownList ID="cmb_LINHA" runat="server" DataSourceID="dts_Linha" DataTextField="LINHA_PRODUTO" DataValueField="LINHA" AutoPostBack="True"></asp:DropDownList>    
    <br />
     Distribuidor
    <br />
    <asp:DropDownList ID="cmb_GRUPO_DISTRIBUIDOR" runat="server" DataSourceID="dts_Distribuidores" DataTextField="GRUPO_DISTRIBUIDOR" DataValueField="GRUPO" AutoPostBack="True"></asp:DropDownList>
    <br />
    Estado
    <br />
    <asp:DropDownList ID="cmb_ESTADO" runat="server" DataSourceID="dts_ESTADO" DataTextField="UF" DataValueField="COD_UF" AutoPostBack="True"></asp:DropDownList>
    <br />
    Municipio
    <br />
    <asp:DropDownList ID="cmb_MUNICIPIO" runat="server" DataSourceID="dts_MUNICIPIO" DataTextField="MUNICIPIO" DataValueField="COD_MUNICIPIO" AutoPostBack="True"></asp:DropDownList>
    <br />
    Esfera Administrativa
    <br />
    <asp:DropDownList ID="cmb_ESFERA" runat="server" DataSourceID="dts_Esfera" DataTextField="ESFERA_ADMINISTRATIVA" DataValueField="ESFERA" AutoPostBack="True"></asp:DropDownList>            
    <br />
    <br />
   <rsweb:ReportViewer ID="rpt_Demanda" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="403px" Width="100%">
        <LocalReport ReportPath="Reports\rpt_Master_Estabelecimentos_Linha.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="dts_Demanda" Name="dts_Demanda" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
</div>
 <br /> <br />
   
    <asp:SqlDataSource ID="dts_Relatorios" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT ID, RELATORIO, CAMINHO_NOME, PAGINA, PERFIL_1, PERFIL_2, PERFIL_3, PERFIL_4, PERFIL_5, PERFIL_6, PERFIL_7, ANALISE_DISTRIBUDORES, ANALISE_REPRESENTANTES FROM TBL_CONFIG_RELATORIOS WHERE (PAGINA = @PAGINA) AND (ANALISE_DISTRIBUDORES = 1) ORDER BY RELATORIO">
        <SelectParameters>
            <asp:Parameter DefaultValue="rpt_Master_Report.aspx" Name="PAGINA" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Anos" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand= "SELECT DISTINCT ANO FROM VIEW_DEMANDA_001_DETALHADO ORDER BY ANO DESC">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Linha" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
         SelectCommand="SELECT '@' AS LINHA, '@ Todos' as LINHA_PRODUTO UNION ALL
            SELECT DISTINCT LINHA AS LINHA , LINHA  AS LINHA_PRODUTO 
            FROM  VIEW_DEMANDA_001_DETALHADO ORDER BY LINHA">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Distribuidores" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '@' AS GRUPO, '@ Todos' as GRUPO_DISTRIBUIDOR UNION ALL
            SELECT DISTINCT GRUPO_DISTRIBUIDOR AS GRUPO , GRUPO_DISTRIBUIDOR  AS GRUPO_DISTRIBUIDOR 
            FROM  VIEW_DEMANDA_001_DETALHADO  ORDER BY GRUPO_DISTRIBUIDOR">
    </asp:SqlDataSource>
 
    <asp:SqlDataSource ID="dts_Grupo_Estabeleicmento" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '@' AS GRUPO, '@ Todos' as GRUPO_ESTABELECIMENTO UNION ALL
            SELECT DISTINCT GRUPO_ESTABELECIMENTO AS GRUPO , GRUPO_ESTABELECIMENTO  AS GRUPO_ESTABELECIMENTO 
            FROM  VIEW_DEMANDA_001_DETALHADO WHERE (GRUPO_ESTABELECIMENTO &lt;&gt;'') ORDER BY GRUPO_ESTABELECIMENTO">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Esfera" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
         SelectCommand="SELECT '@' AS ESFERA, '@ Todos' as ESFERA_ADMINISTRATIVA UNION ALL
            SELECT DISTINCT ESFERA AS ESFERA , ESFERA  AS ESFERA_ADMINISTRATIVA 
            FROM  VIEW_DEMANDA_001_DETALHADO  ORDER BY ESFERA">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_ESTADO" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
         SelectCommand="SELECT '@' AS COD_UF, '@  Todos' as UF UNION ALL 
SELECT DISTINCT [COD_UF], [UF]  
            FROM  VIEW_DEMANDA_001_DETALHADO  ORDER BY UF">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_MUNICIPIO" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
         SelectCommand="SELECT '@' AS COD_MUNICIPIO, '@  Todos' as MUNICIPIO UNION ALL 
SELECT DISTINCT [COD_MUNICIPIO], [MUNICIPIO]  
            FROM  VIEW_DEMANDA_001_DETALHADO  ORDER BY MUNICIPIO">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Diretores" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '@' AS EMAIL_DIRETOR, '@  Todos' as DIRETOR UNION ALL 
SELECT DISTINCT [EMAIL_DIRETOR], [DIRETOR]  
            FROM  VIEW_DEMANDA_001_DETALHADO  ORDER BY DIRETOR">
    </asp:SqlDataSource>

     <asp:SqlDataSource ID="dts_Gerentes" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '@' AS EMAIL_GERENTE, '@  Todos' as GERENTE UNION ALL 
SELECT DISTINCT [EMAIL_GERENTE], [GERENTE]  
            FROM  VIEW_DEMANDA_001_DETALHADO  ORDER BY GERENTE">
    </asp:SqlDataSource>
     
    <asp:SqlDataSource ID="dts_Representantes" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '@' AS EMAIL_REPRESENTANTE, '@  Todos' as REPRESENTANTE UNION ALL 
SELECT DISTINCT [EMAIL_REPRESENTANTE], [REPRESENTANTE]  
            FROM  VIEW_DEMANDA_001_DETALHADO  ORDER BY REPRESENTANTE">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Gerente_Conta" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '@' AS EMAIL_GERENTE_CONTA, '@  Todos' as GERENTE_CONTA UNION ALL 
SELECT DISTINCT [EMAIL_GERENTE_CONTA], [GERENTE_CONTA]  
            FROM  VIEW_DEMANDA_001_DETALHADO

WHERE(GERENTE_CONTA &lt;&gt; '')
  ORDER BY GERENTE_CONTA">
    </asp:SqlDataSource>


    <asp:SqlDataSource ID="dts_Demanda" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_DEMANDA_001_DETALHADO] WHERE (([ANALISAR_LINHA_PRODUTO] = @ANALISAR_LINHA_PRODUTO) AND ([ANO] = @ANO))">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="ANALISAR_LINHA_PRODUTO" Type="Boolean" />
            <asp:ControlParameter ControlID="cmb_ANO" Name="ANO" PropertyName="SelectedValue" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
</form>
</body>
</html>