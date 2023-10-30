<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Demanda_Detalhada.aspx.vb" Inherits="rpt_Demanda_Detalhada" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Demanda Detalhada por Estabelecimento</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Demanda Detalhada por Estabelecimento</div>
    <div id ="Titulo_Pagina_Links">
        <a href="Estabelecimentos_Ficha.aspx?CNPJ=<%=Session("CNPJ")%>">Voltar para a Ficha</a>
    </div>
</div>    
<br />
<div id ="Corpo">
        <asp:FormView ID="frm_Estabelecimento_Ficha" runat="server" 
        DataSourceID="dts_Estabelecimento" Width="100%" Height="20px">
        <EditItemTemplate></EditItemTemplate>
        <InsertItemTemplate></InsertItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl_Estabelecimento" runat="server"  Text='<%# Eval("ESTABELECIMENTO_CNPJ") %>' style="font-weight: 700" />
                <br />
                Atendido por &nbsp;<asp:Label ID="Label_Representante" runat="server"  Text='<%# Eval("REPRESENTANTE") %>' />
                &nbsp;- Inclusão
                <asp:Label ID="Label_Representante0" runat="server" Text='<%# Eval("INCLUSAO_SETORIZACAO") %>' />
                &nbsp;/ Alteração
                <asp:Label ID="Label_Representante1" runat="server" Text='<%# Eval("ALTERACAO_SETORIZACAO")%>' />
            </ItemTemplate>
        </asp:FormView>
   
    <br />
    Ano
    <br />
    <asp:DropDownList ID="cmb_ANO" runat="server" DataSourceID="dts_Anos" DataTextField="ANO_DESC" DataValueField="ANO" AutoPostBack="True"></asp:DropDownList>
    <br />
    <br />
   <rsweb:ReportViewer ID="rpt_Demanda" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="403px" Width="100%">
        <LocalReport ReportPath="Reports\rpt_Demanda_Detalhada_Estabelecimento.rdlc">
             <DataSources>
                <rsweb:ReportDataSource DataSourceId="dts_Demanda" Name="dts_Demanda" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
</div>
 <br /> 
   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT '9999' as [ANO], '# Selecione' as [ANO_DESC] UNION ALL SELECT DISTINCT [ANO], CONVERT(varchar(10), ANO)[as [ANO_DESC] FROM [VIEW_DISTRIBUIDORES_ESTOQUE] ORDER BY [ANO] DESC"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Estabelecimento" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>" 
        SelectCommand="SELECT * FROM [VIEW_ESTABELECIMENTOS] WHERE ([CNPJ] = @CNPJ)">
        <SelectParameters>
            <asp:QueryStringParameter Name="CNPJ" QueryStringField="CNPJ" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Anos" runat="server" 
        ConnectionString="<%$ ConnectionStrings:cnnStr %>"
        SelectCommand="SELECT '9999' as [ANO], '# Selecione' as [ANO_DESC] UNION ALL SELECT DISTINCT [ANO], CONVERT(varchar(10), ANO)[as [ANO_DESC] FROM [VIEW_DEMANDA_001_DETALHADO] ORDER BY [ANO] DESC">
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