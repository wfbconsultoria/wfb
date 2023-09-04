<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Download.aspx.vb" Inherits="Download" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Download de Arquivos</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/MasterTheme/Master.css" />
</head>
<body>
    <uc1:cabecalho runat="server" id="Cabecalho" />
    <form id="form1" runat="server">
        <div class="container">

            <!-- Titulo -->
            <div class="row">
                <div class="col-md-12">
                    <div id="Titulo_Pagina_Cabecalho">Download de Arquivos</div>
                </div>
            </div>

            <!-- Arquivos -->
            <div class="row">
                <div class="col-md-3 col-sm-4" style="margin-bottom: 10px;">
                    <!-- Mensagem -->
                    <div class="row">
                        <div class="col-md-12">
                            <strong>Caminho do Arquivo:</strong>
                        </div>
                    </div>

                    <!-- Tree View -->
                    <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15" BorderStyle="NotSet">
                        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                        <Nodes>
                            <%--camada Arquivos--%>
                            <asp:TreeNode Text="Arquivos" Value="Arquivos" Expanded="False">
                                <%--/camada Arquivos--%>

                                <%--camada Calculo de incentivo--%>
                                <asp:TreeNode Expanded="False" Text="Calculo de IV" Value="Operacao\CSL\Calculo IV">

                                    <%--Camada Conhecimento--%>
                                    <asp:TreeNode Expanded="False" Text="Conhecimento" Value="Operacao\CSL\Calculo IV\Conhecimento">

                                        <%--Camada 2017--%>
                                        <asp:TreeNode Expanded="False" Text="2017" Value="Operacao\CSL\Calculo IV\Conhecimento\2017\"></asp:TreeNode>
                                        <%--/Camada 2017--%>

                                        <%--Camada 2018--%>
                                        <asp:TreeNode Expanded="False" Text="2018" Value="Operacao\CSL\Calculo IV\Conhecimento\2018\"></asp:TreeNode>
                                        <%--camada 2018--%>

                                    </asp:TreeNode>
                                    <%--/Camada Conhecimento--%>

                                    <%--Camada Cotas--%>
                                    <asp:TreeNode Expanded="False" Text="Cotas" Value="Operacao\CSL\Calculo IV\Cotas">

                                        <%--camada cotas demanda--%>
                                        <asp:TreeNode Expanded="False" Text="Cotas Demanda" Value="Operacao\CSL\Calculo IV\Cotas\Cotas Demanda">
                                            <%--Camada 2016--%>
                                            <asp:TreeNode Expanded="false" Text="2016" Value="Operacao\CSL\Calculo IV\Cotas\Cotas Demanda\2016"></asp:TreeNode>
                                            <%--/Camada 2016--%>

                                            <%--Camada 2017--%>
                                            <asp:TreeNode Expanded="False" Text="2017" Value="Operacao\CSL\Calculo IV\Cotas\Cotas Demanda\2017\"></asp:TreeNode>
                                            <%--/Camada 2017--%>

                                            <%--Camada 2018--%>
                                            <asp:TreeNode Expanded="False" Text="2018" Value="Operacao\CSL\Calculo IV\Cotas\Cotas Demanda\2018\"></asp:TreeNode>
                                            <%--camada 2018--%>

                                        </asp:TreeNode>
                                        <%--/camada cotas demanda--%>

                                        <%--camada cotas venda--%>
                                        <asp:TreeNode Expanded="False" Text="Cotas Venda" Value="Operacao\CSL\Calculo IV\Cotas\Cotas Venda">

                                            <%--2016--%>
                                            <asp:TreeNode Expanded="False" Text="2016" Value="Operacao\CSL\Calculo IV\Cotas\Cotas Venda\2016"></asp:TreeNode>
                                            <%--/2016--%>

                                            <%--2017--%>
                                            <asp:TreeNode Expanded="False" Text="2017" Value="Operacao\CSL\Calculo IV\Cotas\Cotas Venda\2017"></asp:TreeNode>
                                            <%--/2017--%>

                                            <%--2018--%>
                                            <asp:TreeNode Expanded="False" Text="2018" Value="Operacao\CSL\Calculo IV\Cotas\Cotas Venda\2018"></asp:TreeNode>
                                            <%--/2018--%>
                                        </asp:TreeNode>
                                        <%--camada cotas venda--%>

                                        <%--Camada Cotas csl--%>
                                        <asp:TreeNode Expanded="False" Text="Cotas" Value="Operacao\CSL\Calculo IV\Cotas"></asp:TreeNode>
                                        <%--/Camada Cotas csl--%>
                                        
                                    </asp:TreeNode>
                                    <%--/Camada Cotas--%>

                                    <%--Camada Demonstrativos--%>
                                    <asp:TreeNode Expanded="False" Text="Demonstrativos" Value="Operacao\CSL\Calculo IV\Demonstrativos">

                                        <%--Camada 2016--%>
                                        <asp:TreeNode Expanded="false" Text="2016" Value="Operacao\CSL\Calculo IV\Demonstrativos\2016"></asp:TreeNode>
                                        <%--/Camada 2016--%>

                                        <%--Camada 2017--%>
                                        <asp:TreeNode Expanded="False" Text="2017" Value="Operacao\CSL\Calculo IV\Demonstrativos\2017\"></asp:TreeNode>
                                        <%--/Camada 2017--%>

                                        <%--Camada 2018--%>
                                        <asp:TreeNode Expanded="False" Text="2018" Value="Operacao\CSL\Calculo IV\Demonstrativos\2018\"></asp:TreeNode>
                                        <%--camada 2018--%>

                                    </asp:TreeNode>
                                    <%--/camada Demonstrativos--%>
                                    <%--camada Premiação Dream Team--%>
                                    <asp:TreeNode Expanded="false" Text="Premiação Dream Team" Value="Operacao\CSL\Calculo IV\Premiação Dream Team">
                                        <asp:TreeNode Text="Mensal" Value="Operacao\CSL\Calculo IV\Premiação Dream Team\Mensal"></asp:TreeNode>
                                        <asp:TreeNode Text="Politicas" Value="Operacao\CSL\Calculo IV\Premiação Dream Team\Politicas"></asp:TreeNode>
                                        <asp:TreeNode Text="Viagem" Value="Operacao\CSL\Calculo IV\Premiação Dream Team\Viagem"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <%--/camada Premiação Dream Team--%>

                                    <%--camada Politicas--%>
                                    <asp:TreeNode Text="Politicas" Value="Operacao\CSL\Calculo IV\Politicas"></asp:TreeNode>
                                    <%--/camada Politicas--%>

                                    <%--Camada Cotas csl--%>
                                    <asp:TreeNode Expanded="False" Text="Cotas" Value="Operacao\CSL\Calculo IV\Cotas"></asp:TreeNode>
                                    <%--/Camada Cotas csl--%>

                                            
                                        
                                </asp:TreeNode>
                                <%--/calculo iv--%>

                                <%--Camada Mapas--%>
                                <asp:TreeNode Expanded="False" Text="Mapas" Value="Operacao\CSL">

                                    <%--Camada Demanda--%>
                                    <asp:TreeNode Expanded="False" Text="Demanda" Value="Operacao\CSL\Mapas\Demanda\">

                                        <%--2016--%>
                                        <asp:TreeNode Expanded="False" Text="2016" Value="Operacao\CSL\Mapas\Demanda\2016">
                                            <asp:TreeNode Text="201601" Value="Operacao\CSL\Mapas\Demanda\2016\201601"></asp:TreeNode>
                                            <asp:TreeNode Text="201602" Value="Operacao\CSL\Mapas\Demanda\2016\201602"></asp:TreeNode>
                                            <asp:TreeNode Text="201603" Value="Operacao\CSL\Mapas\Demanda\2016\201603"></asp:TreeNode>
                                            <asp:TreeNode Text="201604" Value="Operacao\CSL\Mapas\Demanda\2016\201604"></asp:TreeNode>
                                            <asp:TreeNode Text="201605" Value="Operacao\CSL\Mapas\Demanda\2016\201605"></asp:TreeNode>
                                            <asp:TreeNode Text="201606" Value="Operacao\CSL\Mapas\Demanda\2016\201606"></asp:TreeNode>
                                            <asp:TreeNode Text="201607" Value="Operacao\CSL\Mapas\Demanda\2016\201607"></asp:TreeNode>
                                            <asp:TreeNode Text="201608" Value="Operacao\CSL\Mapas\Demanda\2016\201608"></asp:TreeNode>
                                            <asp:TreeNode Text="201609" Value="Operacao\CSL\Mapas\Demanda\2016\201609"></asp:TreeNode>
                                            <asp:TreeNode Text="201610" Value="Operacao\CSL\Mapas\Demanda\2016\201610"></asp:TreeNode>
                                            <asp:TreeNode Text="201611" Value="Operacao\CSL\Mapas\Demanda\2016\201611"></asp:TreeNode>
                                            <asp:TreeNode Text="201612" Value="Operacao\CSL\Mapas\Demanda\2016\201612"></asp:TreeNode>
                                        </asp:TreeNode>
                                        <%--/2016--%>

                                        <%--/2017--%>
                                        <asp:TreeNode Expanded="False" Text="2017" Value="Operacao\CSL\Mapas\Demanda\2017">
                                            <asp:TreeNode Text="201701" Value="Operacao\CSL\Mapas\Demanda\2017\201701"></asp:TreeNode>
                                            <asp:TreeNode Text="201702" Value="Operacao\CSL\Mapas\Demanda\2017\201702"></asp:TreeNode>
                                            <asp:TreeNode Text="201703" Value="Operacao\CSL\Mapas\Demanda\2017\201703"></asp:TreeNode>
                                            <asp:TreeNode Text="201704" Value="Operacao\CSL\Mapas\Demanda\2017\201704"></asp:TreeNode>
                                            <asp:TreeNode Text="201705" Value="Operacao\CSL\Mapas\Demanda\2017\201705"></asp:TreeNode>
                                            <asp:TreeNode Text="201706" Value="Operacao\CSL\Mapas\Demanda\2017\201706"></asp:TreeNode>
                                            <asp:TreeNode Text="201707" Value="Operacao\CSL\Mapas\Demanda\2017\201707"></asp:TreeNode>
                                            <asp:TreeNode Text="201708" Value="Operacao\CSL\Mapas\Demanda\2017\201708"></asp:TreeNode>
                                            <asp:TreeNode Text="201709" Value="Operacao\CSL\Mapas\Demanda\2017\201709"></asp:TreeNode>
                                            <asp:TreeNode Text="201710" Value="Operacao\CSL\Mapas\Demanda\2017\201710"></asp:TreeNode>
                                            <asp:TreeNode Text="201711" Value="Operacao\CSL\Mapas\Demanda\2017\201711"></asp:TreeNode>
                                            <asp:TreeNode Text="201712" Value="Operacao\CSL\Mapas\Demanda\2017\201712"></asp:TreeNode>
                                        </asp:TreeNode>
                                        <%--/2017--%>

                                        <%--2018--%>
                                        <asp:TreeNode Expanded="False" Text="2018" Value="Operacao\CSL\Mapas\Demanda\2018">
                                            <asp:TreeNode Text="201801" Value="Operacao\CSL\Mapas\Demanda\2018\201801"></asp:TreeNode>
                                            <asp:TreeNode Text="201802" Value="Operacao\CSL\Mapas\Demanda\2018\201802"></asp:TreeNode>
                                            <asp:TreeNode Text="201803" Value="Operacao\CSL\Mapas\Demanda\2018\201803"></asp:TreeNode>
                                            <asp:TreeNode Text="201804" Value="Operacao\CSL\Mapas\Demanda\2018\201804"></asp:TreeNode>
                                            <asp:TreeNode Text="201805" Value="Operacao\CSL\Mapas\Demanda\2018\201805"></asp:TreeNode>
                                        </asp:TreeNode>
                                    </asp:TreeNode>
                                    <%--2018--%>

                                    <%--Estoque--%>

                                    <asp:TreeNode Expanded="False" Text="Estoque" Value="Operacao\CSL\Mapas\Estoque\">
                                        <asp:TreeNode Expanded="false" Text="2016" Value="Operacao\CSL\Mapas\Estoque\2016">
                                            <asp:TreeNode Text="201601" Value="Operacao\CSL\Mapas\Estoque\2016\201601"></asp:TreeNode>
                                            <asp:TreeNode Text="201602" Value="Operacao\CSL\Mapas\Estoque\2016\201602"></asp:TreeNode>
                                            <asp:TreeNode Text="201603" Value="Operacao\CSL\Mapas\Estoque\2016\201603"></asp:TreeNode>
                                            <asp:TreeNode Text="201604" Value="Operacao\CSL\Mapas\Estoque\2016\201604"></asp:TreeNode>
                                            <asp:TreeNode Text="201605" Value="Operacao\CSL\Mapas\Estoque\2016\201605"></asp:TreeNode>
                                            <asp:TreeNode Text="201606" Value="Operacao\CSL\Mapas\Estoque\2016\201606"></asp:TreeNode>
                                            <asp:TreeNode Text="201607" Value="Operacao\CSL\Mapas\Estoque\2016\201607"></asp:TreeNode>
                                            <asp:TreeNode Text="201608" Value="Operacao\CSL\Mapas\Estoque\2016\201608"></asp:TreeNode>
                                            <asp:TreeNode Text="201609" Value="Operacao\CSL\Mapas\Estoque\2016\201609"></asp:TreeNode>
                                            <asp:TreeNode Text="201610" Value="Operacao\CSL\Mapas\Estoque\2016\201610"></asp:TreeNode>
                                            <asp:TreeNode Text="201611" Value="Operacao\CSL\Mapas\Estoque\2016\201611"></asp:TreeNode>
                                            <asp:TreeNode Text="201612" Value="Operacao\CSL\Mapas\Estoque\2016\201612"></asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Expanded="false" Text="2017" Value="Operacao\CSL\Mapas\Estoque\2017">
                                            <asp:TreeNode Text="201701" Value="Operacao\CSL\Mapas\Estoque\2017\201701"></asp:TreeNode>
                                            <asp:TreeNode Text="201702" Value="Operacao\CSL\Mapas\Estoque\2017\201702"></asp:TreeNode>
                                            <asp:TreeNode Text="201703" Value="Operacao\CSL\Mapas\Estoque\2017\201703"></asp:TreeNode>
                                            <asp:TreeNode Text="201704" Value="Operacao\CSL\Mapas\Estoque\2017\201704"></asp:TreeNode>
                                            <asp:TreeNode Text="201705" Value="Operacao\CSL\Mapas\Estoque\2017\201705"></asp:TreeNode>
                                            <asp:TreeNode Text="201706" Value="Operacao\CSL\Mapas\Estoque\2017\201706"></asp:TreeNode>
                                            <asp:TreeNode Text="201707" Value="Operacao\CSL\Mapas\Estoque\2017\201707"></asp:TreeNode>
                                            <asp:TreeNode Text="201708" Value="Operacao\CSL\Mapas\Estoque\2017\201708"></asp:TreeNode>
                                            <asp:TreeNode Text="201709" Value="Operacao\CSL\Mapas\Estoque\2017\201709"></asp:TreeNode>
                                            <asp:TreeNode Text="201710" Value="Operacao\CSL\Mapas\Estoque\2017\201710"></asp:TreeNode>
                                            <asp:TreeNode Text="201711" Value="Operacao\CSL\Mapas\Estoque\2017\201711"></asp:TreeNode>
                                            <asp:TreeNode Text="201712" Value="Operacao\CSL\Mapas\Estoque\2017\201712"></asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Expanded="false" Text="2018" Value="Operacao\CSL\Mapas\Estoque\2018">
                                            <asp:TreeNode Text="201801" Value="Operacao\CSL\Mapas\Estoque\2018\201801"></asp:TreeNode>
                                            <asp:TreeNode Text="201802" Value="Operacao\CSL\Mapas\Estoque\2018\201802"></asp:TreeNode>
                                            <asp:TreeNode Text="201803" Value="Operacao\CSL\Mapas\Estoque\2018\201803"></asp:TreeNode>
                                        </asp:TreeNode>
                                        <asp:TreeNode Expanded="false" Text="Estoques Antigos" Value="Operacao\CSL\Mapas\Estoque\Estoques Antigos"></asp:TreeNode>
                                        <asp:TreeNode Expanded="false" Text="Estoque" Value="Operacao\CSL\Mapas\Estoque\"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <%--Vendas--%>
                                    <asp:TreeNode Expanded="false" Text="Vendas" Value="Operacao\CSL\Mapas\Vendas">
                                        <asp:TreeNode Text="2016" Value="Operacao\CSL\Mapas\Vendas\2016"></asp:TreeNode>
                                        <asp:TreeNode Text="2017" Value="Operacao\CSL\Mapas\Vendas\2017"></asp:TreeNode>
                                        <asp:TreeNode Text="2018" Value="Operacao\CSL\Mapas\Vendas\2018"></asp:TreeNode>
                                    </asp:TreeNode>

                                    <%--Documentos--%>
                                    <asp:TreeNode Text="Documentos" Value="Operacao\CSL\Mapas\Documentos"></asp:TreeNode>
                                    <%--/Documentos--%>

                                    <%--mapas--%>
                                    <asp:TreeNode Text="Mapas" Value="Operacao\CSL\Mapas"></asp:TreeNode>
                                    <%--/mapas--%>

                                </asp:TreeNode>
                                <%--/Estoque--%>
                                <%--Camada Documentos--%>
                                <asp:TreeNode Expanded="False" Text="Documentos" Value="Operacao\CSL\Documentos\"></asp:TreeNode>
                                <%--Camada Documentos--%>

                            </asp:TreeNode>
                            <%--/camada mapas--%>
                        </Nodes>
                        <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Bold="True" Font-Italic="False" BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </div>

                <!-- Baixar Arquivo -->
                <div class="col-md-5 col-sm-4" style="margin-bottom: 10px;">
                    <div class="row">
                        <div class="col-md-12">
                            <strong>Download do arquivo:</strong>
                        </div>
                    </div>
                    <!-- Mensagem -->
                    <div class="row">
                        <div class="col-md-12">
                            Selecione o arquivo desejado e clique em "Baixar".
                        </div>
                    </div>


                    <!-- Caminho -->
                    <div class="row">
                        <div class="col-md-12">
                            Caminho:
                            <asp:Label ID="lbl_Pasta" runat="server" Text="Nenhuma Pasta Selecionada"></asp:Label>
                        </div>
                    </div>

                    <!-- Select do arquivo -->
                    <div class="row">
                        <div class="col-md-12">
                            <asp:ListBox ID="lstArquivos" class="selectable-output" BorderThickness="0" CssClass="form-control" runat="server" Style="text-align: left; color: #000000; font-size: small; border: 1px solid rgba(0,0,0,.1); overflow: auto;" Width="100%" AutoPostBack="True" Rows="12" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="lstArquivos" ErrorMessage="Selecione o arquivo que deseja baixar!" Style="color: #FF0000"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <!-- Botão -->
                    <div class="row">
                        <div class="col-md-12">
                            <input id="btnDownload" runat="server" type="button" value="Baixar" style="float: left; margin-top: -20px;" onserverclick="btnDownload_ServerClick" class="btn btn-sm btn-primary" causesvalidation="True" />
                        </div>
                    </div>
                </div>

                <!-- Informações do arquivo -->
                <div class="col-md-4 col-sm-4">
                    <!-- Titulo -->
                    <div class="row">
                        <div class="col-md-12">
                            <strong>Informações do arquivo:</strong>
                        </div>
                    </div>

                    <!-- Informações -->
                    <div class="row">
                        <div class="col-md-12">
                            Tamanho:
                            <asp:Label ID="lbl_TAMANHO" runat="server" />
                            &nbsp;Bytes<br />
                            Extensão:
                            <asp:Label ID="lbl_EXTENCAO" runat="server" />
                            <asp:FormView ID="frv_Arquivo" runat="server" DataSourceID="dts_ARQUIVO" DataKeyNames="ID">
                                <ItemTemplate>
                                    <strong>Observação:</strong>
                                    <asp:Label ID="OBSERVACAOLabel" runat="server" Text='<%# Bind("OBSERVACAO") %>' />
                                </ItemTemplate>
                            </asp:FormView>
                            <br />
                        </div>
                    </div>

                    <!-- Ultimos Downloads -->
                    <div class="row">
                        <div class="col-md-12">
                            <strong>Últimos Downloads do arquivo:</strong>
                            <asp:GridView ID="gdv_LOG_DOWNLOAD" runat="server" AutoGenerateColumns="False" DataSourceID="dts_LOG_DOWNLOAD" Width="100%" Height="100%" ShowHeader="false">
                                <Columns>
                                    <asp:BoundField DataField="USUARIO" HeaderText="Usuário" SortExpression="USUARIO">
                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DATA_EXTENSO" HeaderText="Data" ReadOnly="True" SortExpression="DATA_EXTENSO">
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataTemplate>
                                    Nenhum log de download para o arquivo selecionado!
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Data source -->
        <asp:SqlDataSource ID="dts_LOG_DOWNLOAD" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT TOP (50) ARQUIVO, USUARIO, DATA_EXTENSO, DATA FROM VIEW_LOG_DOWNLOAD WHERE (ARQUIVO = @ARQUIVO) ORDER BY DATA DESC">
            <SelectParameters>
                <asp:ControlParameter ControlID="lbl_Pasta" Name="ARQUIVO" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="dts_ARQUIVO" runat="server" ConnectionString="<%$ ConnectionStrings:cnnStr %>" SelectCommand="SELECT * FROM [TBL_ARQUIVOS] WHERE ([CAMINHO] = @CAMINHO)">
            <SelectParameters>
                <asp:ControlParameter ControlID="lstArquivos" Name="CAMINHO" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
