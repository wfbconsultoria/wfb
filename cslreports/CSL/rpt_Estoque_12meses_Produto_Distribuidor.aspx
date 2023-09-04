<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Estoque_12meses_Produto_Distribuidor.aspx.vb" Inherits="rpt_Estoque_12meses_Produto_Distribuidor" %>

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
        <!-- Corpo da pagina -->
        <div class="container-fluid report">
            <!-- Titulo da página -->
            <div class="row">
                <div class="col-md-12">
                    <div id="Titulo_Pagina_Cabecalho">Estoque 12 meses Produto Distribuidor</div>
                </div>
            </div>

            <!-- Produto -->
            <div class="row">
                <div class="col-md-12">
                    Produto:
            <asp:DropDownList ID="cmbPRODUTO" runat="server" DataSourceID="dtsPRODUTOS" DataTextField="PRODUTO" DataValueField="COD_PRODUTO" AutoPostBack="True" CssClass="form-control"></asp:DropDownList>
                    &nbsp;
                    <asp:Literal ID="Info" runat="server"></asp:Literal>
                </div>
            </div>

            <!-- Report Viewer -->
            <div class="row">
                <div class="col-md-12">
                    <rsweb:ReportViewer ID="rptEstoque" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" Height="450px">
                        <LocalReport ReportPath="Reports\rpt_Estoque_12meses_Produto_Distribuidor.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="dts_Report" Name="dts_Report" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </form>

    <!-- Data source -->
    <asp:SqlDataSource ID="dtsPRODUTOS" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT 'Select' AS COD_PRODUTO, '# Selecione' as PRODUTO UNION ALL SELECT [COD_PRODUTO], [PRODUTO] FROM [TBL_PRODUTOS] WHERE ([COD_PRODUTO] &lt;&gt; @COD_PRODUTO) ORDER BY [PRODUTO]">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="COD_PRODUTO" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="dts_Report" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [VIEW_DISTRIBUIDORES_GRUPOS_MOVIMENTO_ESTOQUE_CALCULADO] WHERE (([TIPO] &lt;&gt; @TIPO) AND ([COD_PRODUTO] = @COD_PRODUTO)) ORDER BY [PRODUTO], [GRUPO_DISTRIBUIDOR], [PERIODO]">
        <SelectParameters>
            <asp:Parameter DefaultValue="Estoque Informado" Name="TIPO" Type="String" />
            <asp:ControlParameter ControlID="cmbPRODUTO" Name="COD_PRODUTO" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

</body>
</html>
