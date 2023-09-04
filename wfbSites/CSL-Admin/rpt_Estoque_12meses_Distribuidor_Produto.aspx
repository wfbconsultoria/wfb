<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Estoque_12meses_Distribuidor_Produto.aspx.vb" Inherits="rpt_Estoque_12meses_Distribuidor_Produto" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Estoque 12 meses</title>
    <link href="App_Themes/Master/Master.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            font-size: large;
        }

        /* Medias para manter relatórios na tela toda */
        @media screen and (min-width: 1600px) {
            .report {
                width: 80vw;
            }
        }

        @media screen and (min-width: 2000px) {
            .report {
                width: 60vw;
            }
        }
    </style>
</head>
<body>

    <uc1:Cabecalho runat="server" ID="Cabecalho" />
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <!-- Corpo da página -->
        <div class="container-fluid report">
            <!-- Titulo -->
            <div class="row">
                <div class="col-md-12" id="Titulo_Pagina_Cabecalho">Estoque 12 meses Distribuidor/Produtos</div>
            </div>

            <!-- Distribuidor -->
            <div class="row">
                <div class="col-md-12">
                    Distribuidor:
                <asp:DropDownList ID="cmbDistribuidor" runat="server" DataSourceID="dtsDistribuidores" DataTextField="GRUPO_DISTRIBUIDOR" DataValueField="ID_GRUPO_DISTRIBUDOR" AutoPostBack="True" CssClass="form-control"></asp:DropDownList>&nbsp;<asp:Literal ID="Info" runat="server"></asp:Literal>
                </div>
            </div>

            <!-- Report Viewer -->
            <div class="row">
                <div class="col-md-12">
                    <rsweb:ReportViewer ID="rptEstoque" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="450px">
                        <LocalReport ReportPath="Reports\rpt_Estoque_12meses_Distribuidor_Produto.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="dts_Report" Name="dts_Report" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </form>

    <!-- Data Source -->
    <asp:SqlDataSource ID="dtsDistribuidores" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT 0 AS ID_GRUPO_DISTRIBUDOR, '@ Selecione' as GRUPO_DISTRIBUIDOR UNION ALL SELECT DISTINCT [ID_GRUPO_DISTRIBUIDOR], [GRUPO_DISTRIBUIDOR] FROM [VIEW_DISTRIBUIDORES_GRUPOS_MOVIMENTO_ESTOQUE_CALCULADO] ORDER BY [GRUPO_DISTRIBUIDOR]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Report" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_DISTRIBUIDORES_GRUPOS_MOVIMENTO] WHERE ([ID_GRUPO_DISTRIBUIDOR] = @ID_GRUPO_DISTRIBUIDOR) ORDER BY [GRUPO_DISTRIBUIDOR], [PRODUTO]">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmbDistribuidor" Name="ID_GRUPO_DISTRIBUIDOR" PropertyName="SelectedValue" Type="Decimal" />
        </SelectParameters>
    </asp:SqlDataSource>

</body>
</html>
