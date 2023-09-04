<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Master_Report2.aspx.vb" Inherits="rpt_Master_Report" %>

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
    <div id ="Titulo_Pagina_Cabecalho">Master Report</div>
    <div id ="Titulo_Pagina_Links">
        Selecione o relatório <asp:DropDownList ID="cmb_Reports" runat="server" AutoPostBack="True" DataSourceID="dts_Relatorios" DataTextField="RELATORIO" DataValueField="CAMINHO_NOME"></asp:DropDownList>
    </div>
</div>    
<br />
<div id ="Corpo">
    <br />
    Tipo de Movimento<br />
    <asp:DropDownList ID="cmb_TIPO_MOVIMENTO" runat="server" DataSourceID="dts_TIPO_MOVIMENTO" DataTextField="DESCRICAO" DataValueField="COD_TIPO_MOVIMENTO" AutoPostBack="True"></asp:DropDownList>
    <br />
    Ano
    <br />
    <asp:DropDownList ID="cmb_ANO" runat="server" DataSourceID="dts_Anos" DataTextField="ANO_DESC" DataValueField="ANO" AutoPostBack="True"></asp:DropDownList>
    <br />
    Grupo de Produtos
    <br />
    <asp:DropDownList ID="cmb_Grupo_Produto" runat="server" DataSourceID="dts_Grupos_Produtos" DataTextField="PRODUTO_GRUPO" DataValueField="COD_PRODUTO_GRUPO" AutoPostBack="True"></asp:DropDownList>    
    <br />
    Linha de Produtos
    <br />
    <asp:DropDownList ID="cmb_LINHA" runat="server" DataSourceID="dts_Linha" DataTextField="PRODUTO_LINHA" DataValueField="COD_PRODUTO_LINHA" AutoPostBack="True"></asp:DropDownList>    
    <br />
     Grupo
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
    <asp:DropDownList ID="cmb_ESTADO" runat="server" DataSourceID="dts_ESTADO" DataTextField="UF_DESC" DataValueField="UF" AutoPostBack="True"></asp:DropDownList>
    <br />
    Municipio
    <br />
    <asp:DropDownList ID="cmb_MUNICIPIO" runat="server" DataSourceID="dts_MUNICIPIO" DataTextField="MUNICIPIO_DESC" DataValueField="MUNICIPIO" AutoPostBack="True"></asp:DropDownList>
    <br />
    Esfera Administrativa
    <br />
    <asp:DropDownList ID="cmb_ESFERA" runat="server" DataSourceID="dts_Esfera" DataTextField="ESFERA" DataValueField="ESFERA_ADMINISTRATIVA" AutoPostBack="True"></asp:DropDownList>            
    <br />
    Target<br />
    <asp:DropDownList ID="cmb_TARGET" runat="server" AutoPostBack="True" DataSourceID="dts_TARGET" DataTextField="DESCRICAO" DataValueField="ATIVO" Enabled="False">
        <asp:ListItem Selected="True" Value="@"># Todos</asp:ListItem>
        <asp:ListItem Value="True">Sim</asp:ListItem>
        <asp:ListItem Value="False">Não</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    Sem Setorização
    <asp:CheckBox ID="chk_Sem_Setorização" runat="server" AutoPostBack="True" />
    <br />
     Gerente Nacional
    <br />
    <asp:DropDownList ID="cmb_DIRETOR" runat="server" DataSourceID="dts_Diretores" DataTextField="NOME" DataValueField="EMAIL" AutoPostBack="True"></asp:DropDownList>
    <br />
    Gerente Regional
    <br />
    <asp:DropDownList ID="cmb_GERENTE" runat="server" DataSourceID="dts_Gerentes" DataTextField="NOME" DataValueField="EMAIL" AutoPostBack="True"></asp:DropDownList>
    <br />
    Gerente Distrital<br />
    <asp:DropDownList ID="cmb_GERENTE_DISTRITAL" runat="server" DataSourceID="dts_Gerentes_Distrital" DataTextField="NOME" DataValueField="EMAIL" AutoPostBack="True"></asp:DropDownList>
    <br />
     Representante
    <br />
    <asp:DropDownList ID="cmb_REPRESENTANTE" runat="server" DataSourceID="dts_Representantes" DataTextField="NOME" DataValueField="EMAIL" AutoPostBack="True"></asp:DropDownList>
     <br />
     Key Account<br />
    <asp:DropDownList ID="cmb_GERENTE_CONTA" runat="server" DataSourceID="dts_Gerente_Conta" DataTextField="NOME" DataValueField="EMAIL" AutoPostBack="True"></asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="cmd_Gerar_Relatorio" runat="server"  Text="Gerar Relatório"  />
</div>
 <br /> <br />
    <asp:SqlDataSource ID="dts_Reports" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_MOVIMENTO_001_DETALHADO_FISCAL]  WHERE ANO = 9999"></asp:SqlDataSource>
   
    <asp:SqlDataSource ID="dts_Relatorios" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_CONFIG_RELATORIOS] WHERE ([PAGINA] = @PAGINA) ORDER BY RELATORIO">
        <SelectParameters>
            <asp:Parameter DefaultValue="rpt_Master_Report.aspx" Name="PAGINA" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_TIPO_MOVIMENTO" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '@' AS COD_TIPO_MOVIMENTO, '# Selecione' AS DESCRICAO UNION ALL SELECT [COD_TIPO_MOVIMENTO], [DESCRICAO] FROM [VIEW_CONFIG_TIPO_MOVIMENTO] WHERE ([ATIVO] = @ATIVO) ORDER BY [DESCRICAO]">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="ATIVO" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Anos" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand= "SELECT 9999 AS ANO, '# Selecione' AS ANO_DESC ORDER BY ANO DESC">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Linha" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
         SelectCommand="SELECT '0' AS COD_PRODUTO_LINHA, '# Todos' AS PRODUTO_LINHA ORDER BY PRODUTO_LINHA">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Grupos_Produtos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '0' AS COD_PRODUTO_GRUPO, '# Todos' AS PRODUTO_GRUPO ORDER BY PRODUTO_GRUPO"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Grupo_Distribuidores" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '0' AS COD_GRUPO_DISTRIBUIDOR, '# Todos' AS DISTRIBUIDOR_GRUPO ORDER BY DISTRIBUIDOR_GRUPO"></asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Distribuidores" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>"
        SelectCommand="SELECT '@' AS GRUPO, '# Todos' as GRUPO_DISTRIBUIDOR ORDER BY GRUPO_DISTRIBUIDOR">
    </asp:SqlDataSource>
 
    <asp:SqlDataSource ID="dts_Grupo_Estabeleicmento" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>"
        SelectCommand="SELECT '@' AS GRUPO, '# Todos' as GRUPO_ESTABELECIMENTO ORDER BY [GRUPO_ESTABELECIMENTO]">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_ESTADO" runat="server"
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
         SelectCommand="SELECT '@' AS UF, '# Todos' as UF_DESC ORDER BY UF">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_MUNICIPIO" runat="server"
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
         SelectCommand="SELECT '@' AS MUNICIPIO, '# Todos' as MUNICIPIO_DESC ORDER BY MUNICIPIO">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Esfera" runat="server"
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
         SelectCommand="SELECT '@' AS ESFERA_ADMINISTRATIVA, '# Todos' as ESFERA ORDER BY [ESFERA]">
    </asp:SqlDataSource>
    
    <asp:SqlDataSource ID="dts_Diretores" runat="server"
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT '@' AS EMAIL, '# Todos' as NOME ORDER BY [NOME]">
    </asp:SqlDataSource>

     <asp:SqlDataSource ID="dts_TARGET" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '@' AS ATIVO, '# Todos' AS DESCRICAO UNION ALL  SELECT 'True' AS ATIVO, 'Sim' AS DESCRICAO UNION ALL SELECT 'False' AS ATIVO, 'Não' AS DESCRICAO ORDER BY DESCRICAO"></asp:SqlDataSource>

     <asp:SqlDataSource ID="dts_Gerentes" runat="server"
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
         SelectCommand="SELECT '#' AS EMAIL, '# Todos' as NOME ORDER BY [NOME]">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Gerentes_Distrital" runat="server"
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
         SelectCommand="SELECT '@' AS EMAIL, '# Todos' as NOME ORDER BY [NOME]">
    </asp:SqlDataSource>
     
    <asp:SqlDataSource ID="dts_Representantes" runat="server"
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
         SelectCommand="SELECT '@' AS EMAIL, '# Todos' as NOME ORDER BY [NOME]">
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="dts_Gerente_Conta" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>"
        SelectCommand="SELECT '@' AS EMAIL, '# Todos' as NOME ORDER BY [NOME]">
    </asp:SqlDataSource>

</form>
</body>
</html>