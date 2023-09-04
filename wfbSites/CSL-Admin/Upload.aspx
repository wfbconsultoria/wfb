<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Upload.aspx.vb" Inherits="Upload" %>

<%@ Register Src="~/Cabecalho.ascx" TagPrefix="uc1" TagName="Cabecalho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Upload de Arquivos</title>
    <link rel="stylesheet" type="text/css" href="App_Themes/MasterTheme/Master.css" />
    <style type="text/css">

        .auto-style1 {
            font-size: small;
        }
    </style>
    </head>
<body>
<uc1:Cabecalho runat="server" id="Cabecalho" />
<form id="form1" runat="server">
<div id="Titulo_Pagina">
    <div id ="Titulo_Pagina_Cabecalho">Upload de Arquivos</div>
    <div id ="Titulo_Pagina_Links"></div>
</div>    
<div id ="Corpo">
                <asp:Label ID="lbl_raiz" runat="server" Text="Nenhuma Pasta Selecionada" style="font-weight: 700" Visible="False"></asp:Label>
    <br/>
    <table width="100%" >
        <tr>
            <td width="20%" style="vertical-align: top;">
                <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15">
                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    <Nodes>
                        <asp:TreeNode Text="Arquivos" Value="Arquivos" Expanded="False">
                            <asp:TreeNode Expanded="False" Text="Calculo de Incentivo" Value="Arquivos\Calculo de Incentivo">
                                <asp:TreeNode Expanded="False" Text="Cotas Demanda" Value="Arquivos\Calculo de Incentivo\Cotas Demanda">
                                    <asp:TreeNode Text="2014" Value="Arquivos\Calculo de Incentivo\Cotas Demanda\2014"></asp:TreeNode>
                                    <asp:TreeNode Text="2015" Value="Arquivos\Calculo de Incentivo\Cotas Demanda\2015"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Expanded="False" Text="Cotas Venda" Value="Arquivos\Calculo de Incentivo\Cotas Venda">
                                    <asp:TreeNode Text="2014" Value="Arquivos\Calculo de Incentivo\Cotas Venda\2014"></asp:TreeNode>
                                    <asp:TreeNode Text="2015" Value="Arquivos\Calculo de Incentivo\Cotas Venda\2015"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Expanded="False" Text="Demonstrativos" Value="Arquivos\Calculo de Incentivo\Demonstrativos">
                                    <asp:TreeNode Text="2012" Value="Arquivos\Calculo de Incentivo\Demonstrativos\2012"></asp:TreeNode>
                                    <asp:TreeNode Text="2013" Value="Arquivos\Calculo de Incentivo\Demonstrativos\2013"></asp:TreeNode>
                                    <asp:TreeNode Text="2014" Value="Arquivos\Calculo de Incentivo\Demonstrativos\2014"></asp:TreeNode>
                                    <asp:TreeNode Text="2015" Value="Arquivos\Calculo de Incentivo\Demonstrativos\2015"></asp:TreeNode>
                                </asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode Expanded="False" Text="Documentos" Value="Arquivos\Documentos">
                                <asp:TreeNode Expanded="False" Text="Arquivo" Value="Arquivos\Documentos\Arquivo">
                                    <asp:TreeNode Text="2014" Value="Arquivos\Documentos\Arquivo\2014"></asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Text="Concurso Alburex" Value="Arquivos\Documentos\Concurso Alburex"></asp:TreeNode>
                                <asp:TreeNode Text="Politicas" Value="Arquivos\Documentos\Politicas"></asp:TreeNode>
                                <asp:TreeNode Text="Reports" Value="Arquivos\documentos\Reports" Expanded="False"></asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode Expanded="False" Text="Mapas" Value="Arquivos\Mapas">
                                <asp:TreeNode Expanded="False" Text="Concurso Albumina (Alburex + Albuminar)" Value="Arquivos\Mapas\Concurso Albumina (Alburex + Albuminar)"></asp:TreeNode>
                                <asp:TreeNode Expanded="False" Text="Demanda" Value="Arquivos\Mapas\Demanda">
                                    <asp:TreeNode Expanded="False" Text="2014" Value="Arquivos\Mapas\Demanda\2014">
                                        <asp:TreeNode Text="201407" Value="Arquivos\Mapas\Demanda\2014\2014 07"></asp:TreeNode>
                                        <asp:TreeNode Text="201408" Value="Arquivos\Mapas\Demanda\2014\2014 08"></asp:TreeNode>
                                        <asp:TreeNode Text="201409" Value="Arquivos\Mapas\Demanda\2014\2014 09"></asp:TreeNode>
                                        <asp:TreeNode Text="201410" Value="Arquivos\Mapas\Demanda\2014\2014 10"></asp:TreeNode>
                                        <asp:TreeNode Text="201411" Value="Arquivos\Mapas\Demanda\2014\2014 11"></asp:TreeNode>
                                        <asp:TreeNode Text="201412" Value="Arquivos\Mapas\Demanda\2014\2014 12"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Expanded="False" Text="2015" Value="Arquivos\Mapas\Demanda\2015">
                                        <asp:TreeNode Text="201501" Value="Arquivos\Mapas\Demanda\2015\201501"></asp:TreeNode>
                                        <asp:TreeNode Text="201502" Value="Arquivos\Mapas\Demanda\2015\201502"></asp:TreeNode>
                                        <asp:TreeNode Text="201503" Value="Arquivos\Mapas\Demanda\2015\201503"></asp:TreeNode>
                                        <asp:TreeNode Text="201504" Value="Arquivos\Mapas\Demanda\2015\201504"></asp:TreeNode>
                                        <asp:TreeNode Text="201505" Value="Arquivos\Mapas\Demanda\2015\201505"></asp:TreeNode>
                                        <asp:TreeNode Text="201506" Value="Arquivos\Mapas\Demanda\2015\201506"></asp:TreeNode>
                                        <asp:TreeNode Text="201507" Value="Arquivos\Mapas\Demanda\2015\201507"></asp:TreeNode>
                                        <asp:TreeNode Text="201508" Value="Arquivos\Mapas\Demanda\2015\201508"></asp:TreeNode>
                                        <asp:TreeNode Text="201509" Value="Arquivos\Mapas\Demanda\2015\201509"></asp:TreeNode>
                                        <asp:TreeNode Text="201510" Value="Arquivos\Mapas\Demanda\2015\201510"></asp:TreeNode>
                                        <asp:TreeNode Text="201511" Value="Arquivos\Mapas\Demanda\2015\201511"></asp:TreeNode>
                                        <asp:TreeNode Text="201512" Value="Arquivos\Mapas\Demanda\2015\201512"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Expanded="False" Text="2016" Value="Arquivos\Mapas\Demanda\2016">
                                        <asp:TreeNode Text="201601" Value="Arquivos\Mapas\Demanda\2016\201601"></asp:TreeNode>
                                        <asp:TreeNode Text="201602" Value="Arquivos\Mapas\Demanda\2016\201602"></asp:TreeNode>
                                        <asp:TreeNode Text="201603" Value="Arquivos\Mapas\Demanda\2016\201603"></asp:TreeNode>
                                        <asp:TreeNode Text="201604" Value="Arquivos\Mapas\Demanda\2016\201604"></asp:TreeNode>
                                        <asp:TreeNode Text="201605" Value="Arquivos\Mapas\Demanda\2016\201605"></asp:TreeNode>
                                        <asp:TreeNode Text="201606" Value="Arquivos\Mapas\Demanda\2016\201606"></asp:TreeNode>
                                        <asp:TreeNode Text="201607" Value="Arquivos\Mapas\Demanda\2016\201607"></asp:TreeNode>
                                        <asp:TreeNode Text="201608" Value="Arquivos\Mapas\Demanda\2016\201608"></asp:TreeNode>
                                        <asp:TreeNode Text="201609" Value="Arquivos\Mapas\Demanda\2016\201609"></asp:TreeNode>
                                        <asp:TreeNode Text="201610" Value="Arquivos\Mapas\Demanda\2016\201610"></asp:TreeNode>
                                        <asp:TreeNode Text="201611" Value="Arquivos\Mapas\Demanda\2016\201611"></asp:TreeNode>
                                        <asp:TreeNode Text="201612" Value="Arquivos\Mapas\Demanda\2016\201612"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Expanded="False" Text="2017" Value="Arquivos\Mapas\Demanda\2017">
                                        <asp:TreeNode Text="201701" Value="Arquivos\Mapas\Demanda\2017\201701"></asp:TreeNode>
                                        <asp:TreeNode Text="201702" Value="Arquivos\Mapas\Demanda\2017\201702"></asp:TreeNode>
                                        <asp:TreeNode Text="201703" Value="Arquivos\Mapas\Demanda\2017\201703"></asp:TreeNode>
                                        <asp:TreeNode Text="201704" Value="Arquivos\Mapas\Demanda\2017\201704"></asp:TreeNode>
                                        <asp:TreeNode Text="201706" Value="Arquivos\Mapas\Demanda\2017\201706"></asp:TreeNode>
                                    </asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Expanded="False" Text="Estoque" Value="Arquivos\Mapas\Estoque">
                                    <asp:TreeNode Expanded="False" Text="2014" Value="Arquivos\Mapas\Estoque\2014">
<asp:TreeNode Text="2014 07" Value="Arquivos\Mapas\Estoque\2014\2014 07"></asp:TreeNode>
<asp:TreeNode Text="2014 08" Value="Arquivos\Mapas\Estoque\2014\2014 08"></asp:TreeNode>
<asp:TreeNode Text="2014 09" Value="Arquivos\Mapas\Estoque\2014\2014 09"></asp:TreeNode>
                                        <asp:TreeNode Text="2014 10" Value="Arquivos\Mapas\Estoque\2014\2014 10"></asp:TreeNode>
                                        <asp:TreeNode Text="2014 11" Value="Arquivos\Mapas\Estoque\2014\2014 11"></asp:TreeNode>
                                        <asp:TreeNode Text="2014 12" Value="Arquivos\Mapas\Estoque\2014\2014 12"></asp:TreeNode>
</asp:TreeNode>
<asp:TreeNode Expanded="False" Text="2015" Value="Arquivos\Mapas\Estoque\2015"><asp:TreeNode Text="2015 01" Value="Arquivos\Mapas\Estoque\2015\201501"></asp:TreeNode>
<asp:TreeNode Text="2015 02" Value="Arquivos\Mapas\Estoque\2015\201502"></asp:TreeNode>
<asp:TreeNode Text="2015 03" Value="Arquivos\Mapas\Estoque\2015\201503"></asp:TreeNode>
<asp:TreeNode Text="2015 04" Value="Arquivos\Mapas\Estoque\2015\201504"></asp:TreeNode>
<asp:TreeNode Text="2015 05" Value="Arquivos\Mapas\Estoque\2015\201505"></asp:TreeNode>
<asp:TreeNode Text="2015 06" Value="Arquivos\Mapas\Estoque\2015\201506"></asp:TreeNode>
<asp:TreeNode Text="2015 07" Value="Arquivos\Mapas\Estoque\2015\201507"></asp:TreeNode>
<asp:TreeNode Text="2015 08" Value="Arquivos\Mapas\Estoque\2015\201508"></asp:TreeNode>
<asp:TreeNode Text="2015 09" Value="Arquivos\Mapas\Estoque\2015\201509"></asp:TreeNode>
<asp:TreeNode Text="2015 10" Value="Arquivos\Mapas\Estoque\2015\201510"></asp:TreeNode>
<asp:TreeNode Text="2015 11" Value="Arquivos\Mapas\Estoque\2015\201511"></asp:TreeNode>
<asp:TreeNode Text="2015 12" Value="Arquivos\Mapas\Estoque\2015\201512"></asp:TreeNode>
</asp:TreeNode>

                                    <asp:TreeNode Expanded="False" Text="Estoques Antigos" Value="Arquivos\Mapas\Estoque\Estoques Antigos">
                                    </asp:TreeNode>
                                </asp:TreeNode>
                                <asp:TreeNode Expanded="False" Text="Venda" Value="Arquivos\Mapas\Venda">
                                    <asp:TreeNode Expanded="False" Text="2014" Value="Arquivos\Mapas\Venda\2014"></asp:TreeNode>
                                    <asp:TreeNode Expanded="False" Text="2015" Value="Arquivos\Mapas\Venda\2015"></asp:TreeNode>
                                </asp:TreeNode>
                            </asp:TreeNode>
                        </asp:TreeNode>
                    </Nodes>
                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                    <ParentNodeStyle Font-Bold="False" />
                    <SelectedNodeStyle Font-Bold="True" Font-Italic="False" BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px" />
                </asp:TreeView>
            </td>
            <td width="40%" aria-orientation="horizontal" style="vertical-align: top;">
                <asp:ListBox ID="lstArquivos" BorderThickness="0" Runat="server" Rows="6" style="text-align: left; color: #000000; font-size: small; border:0px;" Width="100%" Height="510px" />
            </td>
            <td width="40%" style="vertical-align: top;">

                Caminho:
                <asp:Label ID="lbl_Pasta" runat="server" Text="Nenhuma Pasta Selecionada" style="font-weight: 700"></asp:Label>
                <br />
    <span class="auto-style1">Obs: Só é aceito arquivos de no máximo 20MB!</span><br />
    
    <asp:FileUpload ID="fup_Mapas" runat="server" class="multi" />
    <br />
    Escreva alguma observação sobre o arquivo:<br />
    <asp:TextBox ID="txt_OBSERVACAO" runat="server" Rows="3" TextMode="MultiLine" Width="100%"></asp:TextBox>
    <br/>
    <asp:Button ID="btn_Upload_Enviar" runat="server" Text="Enviar" CssClass="buton_gravar" />
    
            </td>
        </tr>
    </table>
    <br />
    </div>
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
