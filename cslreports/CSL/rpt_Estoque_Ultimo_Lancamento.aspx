<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_Estoque_Ultimo_Lancamento.aspx.vb" Inherits="Estoque_Mapa_Distribuidor" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Início</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/MasterTheme/Master.css" />

    <style>
        /* Merdia para manter report na tela toda */
        @media screen and (min-width: 2000px) {
            .report {
                width: 80vw;
            }
        }
    </style>
</head>
<uc1:Cabecalho runat="server" ID="Cabecalho" />
<body>
    <form id="form1" runat="server">
        <!--controle para visualizar relatorio-->
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="container-fluid report">
            <!-- Titulo da página -->
            <div class="row">
                <div class="col-md-12">
                    <div id="Titulo_Pagina_Cabecalho">Estoque última posição</div>
                </div>
            </div>

            <!--Produtos-->
            <div class="row">
                <div class="col-md-12">
                    Produto:
                <asp:DropDownList ID="cmb_Produtos" runat="server" DataSourceID="dts_Produtos" DataTextField="PRODUTO" DataValueField="COD_PRODUTO" AutoPostBack="True" CssClass="form-control">
                </asp:DropDownList><br />
                </div>
            </div>
            <!--Produtos-->

            <!--Relatório-->
            <div class="row">
                <div class="col-md-12">
                    <rsweb:ReportViewer ID="rpt_Report" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="420px" Width="100%">
                        <LocalReport ReportPath="Reports\rpt_Estoque_Ultimo_Lancamento.rdlc">
                            <DataSources>
                                <rsweb:ReportDataSource DataSourceId="dts_CSL_Reports" Name="dts_Reports" />
                            </DataSources>
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>
            </div>
            <!--Relatótio-->


        </div>
        <!--parametros-->
        <asp:SqlDataSource ID="dts_Produtos" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT [COD_PRODUTO], [PRODUTO] FROM [TBL_PRODUTOS] WHERE ([ATIVO] = @ATIVO) ORDER BY [PRODUTO]">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="ATIVO" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_CSL_Reports" runat="server" ConnectionString="<%$ ConnectionStrings:cnnReports %>" SelectCommand="SELECT * FROM [rpt_Ultimo_Lancamento_Estoque] WHERE ([Cod_Produto] = @Cod_Produto)">
            <SelectParameters>
                <asp:ControlParameter ControlID="cmb_Produtos" Name="Cod_Produto" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <!--parametros-->
    </form>
</body>
</html>
