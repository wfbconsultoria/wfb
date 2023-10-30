<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Master_Report_Gerente.aspx.vb" Inherits="rpt_Master_Report_Gerente" %>

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
    <div id ="Titulo_Pagina_Cabecalho">Master Report &nbsp;<asp:DropDownList ID="cmb_GERENTE" runat="server" DataSourceID="dts_Gerentes" DataTextField="NOME" DataValueField="EMAIL" AutoPostBack="True" Enabled="False"></asp:DropDownList></div>
    <div id ="Titulo_Pagina_Links">
        Selecione o relatório <asp:DropDownList ID="cmb_Reports" runat="server" AutoPostBack="True" DataSourceID="dts_Relatorios" DataTextField="RELATORIO" DataValueField="CAMINHO_NOME"></asp:DropDownList>
    </div>
</div>    
<br />
<div id ="Corpo">
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
     Grupo Estabelecimento
    <br />
    <asp:DropDownList ID="cmb_GRUPO_ESTABELECIMENTO" runat="server" DataSourceID="dts_Grupo_Estabeleicmento" DataTextField="GRUPO_ESTABELECIMENTO" DataValueField="GRUPO" AutoPostBack="True"></asp:DropDownList>
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
     Representante
    <br />
    <asp:DropDownList ID="cmb_REPRESENTANTE" runat="server" DataSourceID="dts_Representantes" DataTextField="REPRESENTANTE" DataValueField="EMAIL_REPRESENTANTE" AutoPostBack="True"></asp:DropDownList>
     <br />
     Key Account
    <br />
    <asp:DropDownList ID="cmb_GERENTE_CONTA" runat="server" DataSourceID="dts_Gerente_Conta" DataTextField="GERENTE_CONTA" DataValueField="EMAIL_GERENTE_CONTA" AutoPostBack="True"></asp:DropDownList>
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
   
    <asp:SqlDataSource ID="dts_Relatorios" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_CONFIG_RELATORIOS] WHERE ([PAGINA] = @PAGINA) ORDER BY [RELATORIO]">
        <SelectParameters>
            <asp:Parameter DefaultValue="rpt_Master_Report.aspx" Name="PAGINA" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Anos" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand= "SELECT DISTINCT [ANO] FROM [VIEW_DEMANDA_001_DETALHADO] WHERE ([EMAIL_GERENTE] = @EMAIL_GERENTE) ORDER BY [ANO] DESC">
        <SelectParameters>
            <asp:SessionParameter Name="EMAIL_GERENTE" SessionField="EMAIL_LOGIN" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Linha" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
         SelectCommand="
        SELECT '@' AS LINHA, '@ Todos' as LINHA_PRODUTO UNION ALL
        SELECT DISTINCT LINHA AS LINHA , LINHA  AS LINHA_PRODUTO 
        FROM  VIEW_DEMANDA_001_DETALHADO  WHERE ([EMAIL_GERENTE] = @EMAIL_GERENTE) ORDER BY [LINHA]">
        <SelectParameters>
            <asp:SessionParameter Name="EMAIL_GERENTE" SessionField="EMAIL_LOGIN" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Distribuidores" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '@' AS GRUPO, '@ Todos' as GRUPO_DISTRIBUIDOR UNION ALL
            SELECT DISTINCT GRUPO_DISTRIBUIDOR AS GRUPO , GRUPO_DISTRIBUIDOR  AS GRUPO_DISTRIBUIDOR 
            FROM  VIEW_DEMANDA_001_DETALHADO WHERE ([EMAIL_GERENTE] = @EMAIL_GERENTE) ORDER BY GRUPO_DISTRIBUIDOR">
         <SelectParameters>
            <asp:SessionParameter Name="EMAIL_GERENTE" SessionField="EMAIL_LOGIN" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
 
    <asp:SqlDataSource ID="dts_Grupo_Estabeleicmento" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '@' AS GRUPO, '@ Todos' as GRUPO_ESTABELECIMENTO UNION ALL
            SELECT DISTINCT GRUPO_ESTABELECIMENTO AS GRUPO , GRUPO_ESTABELECIMENTO  AS GRUPO_ESTABELECIMENTO 
            FROM  VIEW_DEMANDA_001_DETALHADO WHERE (GRUPO_ESTABELECIMENTO &lt;&gt;'') AND ([EMAIL_GERENTE] = @EMAIL_GERENTE) ORDER BY GRUPO_ESTABELECIMENTO">
        <SelectParameters>
            <asp:SessionParameter Name="EMAIL_GERENTE" SessionField="EMAIL_LOGIN" Type="String" />
        </SelectParameters>
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

    <asp:SqlDataSource ID="dts_Esfera" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
         SelectCommand="SELECT '@' AS ESFERA, '@ Todos' as ESFERA_ADMINISTRATIVA UNION ALL
            SELECT DISTINCT ESFERA AS ESFERA , ESFERA  AS ESFERA_ADMINISTRATIVA 
            FROM  VIEW_DEMANDA_001_DETALHADO WHERE ([EMAIL_GERENTE] = @EMAIL_GERENTE) ORDER BY ESFERA">
        <SelectParameters>
            <asp:SessionParameter Name="EMAIL_GERENTE" SessionField="EMAIL_LOGIN" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

     <asp:SqlDataSource ID="dts_Gerentes" runat="server" 
         ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [VIEW_USUARIOS] WHERE ([EMAIL] = @EMAIL)">
        <SelectParameters>
            <asp:SessionParameter Name="EMAIL" SessionField="EMAIL_LOGIN" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
     
    <asp:SqlDataSource ID="dts_Representantes" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '@' AS EMAIL_REPRESENTANTE, '@  Todos' as REPRESENTANTE UNION ALL 
            SELECT DISTINCT [EMAIL_REPRESENTANTE], [REPRESENTANTE]  
            FROM  VIEW_DEMANDA_001_DETALHADO WHERE ([EMAIL_GERENTE] = @EMAIL_GERENTE)  ORDER BY REPRESENTANTE">
        <SelectParameters>
            <asp:SessionParameter Name="EMAIL_GERENTE" SessionField="EMAIL_LOGIN" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Gerente_Conta" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '@' AS EMAIL_GERENTE_CONTA, '@  Todos' as GERENTE_CONTA UNION ALL 
            SELECT DISTINCT [EMAIL_GERENTE_CONTA], [GERENTE_CONTA]  
            FROM  VIEW_DEMANDA_001_DETALHADO WHERE(GERENTE_CONTA &lt;&gt; '') AND ([EMAIL_GERENTE] = @EMAIL_GERENTE)   ORDER BY GERENTE_CONTA">
    <SelectParameters>
            <asp:SessionParameter Name="EMAIL_GERENTE" SessionField="EMAIL_LOGIN" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>


    <asp:SqlDataSource ID="dts_Demanda" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_DEMANDA_001_DETALHADO] WHERE (([EMAIL_GERENTE] = @EMAIL_GERENTE)  AND ([ANO] = @ANO))">
        <SelectParameters>
            <asp:SessionParameter Name="EMAIL_GERENTE" SessionField="EMAIL_LOGIN" Type="String" />
            <asp:ControlParameter ControlID="cmb_ANO" Name="ANO" PropertyName="SelectedValue" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
</form>
</body>
</html>