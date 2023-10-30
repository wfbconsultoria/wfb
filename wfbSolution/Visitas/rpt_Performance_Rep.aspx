<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Performance_Rep.aspx.vb" Inherits="Contatos_Alterar" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Performance Representante</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            font-weight: bold;
        }
        .auto-style2 {
            font-size: large;
        }
    </style>
</head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">    
    <div id ="Titulo_Pagina_Cabecalho"></div>
    <strong><span class="auto-style2">Performance Representante</span></strong></div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
<div id ="Corpo">
    <strong>Representante:</strong>
    <asp:DropDownList ID="cmb_Usuarios" runat="server" DataSourceID="dts_Usuarios" DataTextField="NOME" DataValueField="EMAIL" AutoPostBack="True">
    </asp:DropDownList>

    <br /><br />

    <rsweb:ReportViewer ID="rpt_Performance_Rep" runat="server" Width="1140px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="475px">
        <LocalReport ReportPath="Reports\rpt_Performance_Representante.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="dts_Performance" Name="Reports" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>

    

    <asp:SqlDataSource ID="dts_Performance" runat="server" ConnectionString="<%$ ConnectionStrings:cnnReports %>" SelectCommand="SELECT * FROM [rpt_Representantes_12_Atual] WHERE ([EmailRepresentante] = @EmailRepresentante)">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmb_Usuarios" Name="EmailRepresentante" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    

    <asp:SqlDataSource ID="dts_Usuarios" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [EMAIL], [NOME] FROM [tbl_USUARIOS] WHERE (([ATIVO] = @ATIVO) AND ([COD_FUNCAO] = @COD_FUNCAO)) ORDER BY [EMAIL]">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="ATIVO" Type="Boolean" />
            <asp:Parameter DefaultValue="7" Name="COD_FUNCAO" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>

    

    <br />

</div>
</form>
</body>
</html>